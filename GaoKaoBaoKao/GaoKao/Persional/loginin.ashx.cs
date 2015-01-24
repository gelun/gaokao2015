using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using Entity;


namespace GaoKao.Persional
{
    /// <summary>
    /// loginin 的摘要说明
    /// </summary>
    public class loginin : IHttpHandler
    {
        UserInfo user = new UserInfo();
        JsonCallBack infoJson = new JsonCallBack();

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";

            string strBank = Basic.RequestHelper.GetQueryString("bank");
            string strPwd = Basic.RequestHelper.GetQueryString("password");

            //status ：状态值的意义说明 
            //空或者0: 表示账号或者密码错误
            //1: 登陆成功
            //2：高考卡用户，尚未完善个人信息
            //3：高考卡用户，个人信息已经完善，但是该卡已经关闭或者有效期已过
            //4: 高考卡用户，个人信息已经完善，并且可以正常使用
            //5：注册用户，尚未完善个人信息
            //6：注册用户，已经完善个人信息
            //7：会员卡用户，尚未完善个人信息
            //8：会员卡用户，已经完善个人信息
            //9：会员卡用户，已过期


            /**     整理之后归纳如下     **/

            //空或者0：账号或者密码错误
            //1：未完善个人信息：目前只有账号和密码
            //2：账号被完全关闭账号：卡用户的卡已关闭或者过期；注册用户被关闭
            //3：高考卡用户：可以正常使用系统的账户
            //4.注册用户或者会员卡用户（如果是先注册，后绑定的报考卡，那么报考卡过期之后该用户又是一个普通注册用户了）


            string strJson = "";
            // 1 使用账号和密码 检测 GaoKaoCard 表
            strJson = GaoKaoCard(strBank, strPwd);
            if (strJson == "")
            {
                // 2 使用账号和密码 检测 Join_Card 表
                strJson = Join_Card(strBank, strPwd);
                if (strJson == "")
                {
                    // 3 使用账号和密码 检测 Join_Student 表
                    strJson = Join_Student(strBank, strPwd);
                }
            }

            if (strJson == "")
            {
                //账号或者密码失败
            }
            else
            {
                WriteCookie();
            }


            context.Response.Write(strJson);
        }

        /*   将数据 写入 Cookie 中   */
        void WriteCookie()
        {
            user.Status = infoJson.Status;//状态
            user.StudentLevel = infoJson.Level;//UserInfo
            user.StudentName = infoJson.StudentName;
            user.Bank = infoJson.Bank;
            user.ProvinceName = infoJson.ProvinceName;
            user.LevelName = infoJson.LevelName;

            //将 StudentId、StudentLevel、ProvinceId、KeLei、GKYear 信息存入 cookie 中 120分钟
            Basic.CookieHelper.WriteCookie("Student", "StudentId", user.StudentId.ToString(), 120);
            Basic.CookieHelper.WriteCookie("Student", "StudentLevel", user.StudentLevel.ToString(), 120);
            Basic.CookieHelper.WriteCookie("Student", "ProvinceId", user.ProvinceId.ToString(), 120);
            Basic.CookieHelper.WriteCookie("Student", "KeLei", user.KeLei.ToString(), 120);
            Basic.CookieHelper.WriteCookie("Student", "GKYear", user.GKYear.ToString(), 120);

            Basic.CookieHelper.WriteCookie("Student", "Status", user.Status.ToString(), 120);
            Basic.CookieHelper.WriteCookie("Student", "StudentName", user.StudentName, 120);
            Basic.CookieHelper.WriteCookie("Student", "Bank", user.Bank, 120);
            Basic.CookieHelper.WriteCookie("Student", "LevelName", user.LevelName, 120);
            Basic.CookieHelper.WriteCookie("Student", "ProvinceName", user.ProvinceName, 120);


            //Request.Cookies["user"].Values["Id"]
            Basic.CookieHelper.WriteCookieWithDomain("user", "Id", user.StudentId.ToString(), ".gelunjiaoyu.com", 120);

        }

        //空或者0：账号或者密码错误
        //1：未完善个人信息：目前只有账号和密码
        //2：账号被完全关闭账号：卡用户的卡已关闭或者过期；注册用户被关闭
        //3：高考卡用户：可以正常使用系统的账户
        //4.注册用户或者会员卡用户（如果是先注册，后绑定的报考卡，那么报考卡过期之后该用户又是一个普通注册用户了）

        /*使用账号和密码 检测 GaoKaoCard 表*/
        string GaoKaoCard(string strBank, string strPwd)
        {
            #region 针对卡号段  '19140600001' and '19140610000'  作如下处理

            if (strBank.StartsWith("191406"))
            {
                string strBank2 = strBank.Substring(6);
                int intBank = Basic.TypeConverter.StrToInt(strBank2, 0);
                if (intBank >= 1 && intBank <= 10000)
                {
                    strBank += DAL.AnalysisArea.GetProvinceIdByIp();
                }
            }

            #endregion

            Entity.GaoKaoCard infoCard = DAL.GaoKaoCard.GaoKaoCardEntityGetByKaHao(strBank, strPwd);
            if (infoCard != null)
            {
                //UserInfo
                user.ProvinceId = infoCard.ProvinceId;//UserInfo

                //JsonCallBack
                infoJson.Bank = infoCard.KaHao;//账号
                infoJson.Level = infoCard.CardLevel;//会员等级
                infoJson.ProvinceName = GetProvinceName(infoCard.ProvinceId);//省份

                //Basic.CookieHelper.WriteCookie("EndTime", infoCard.EndTime.ToString());
                //Basic.CookieHelper.WriteCookie("EndTime222", DateTime.Now.ToString());
                //判定是否已经关闭或者过期
                if (infoCard.IsPause == 1 || DateTime.Compare(DateTime.Now, infoCard.EndTime) > 0)
                {
                    infoJson.Status = 2;//高考卡已关闭或者过期
                }
                else
                {
                    //没有关闭也没有过期的一张卡,等待接下来的处理

                    //通过StudentId 验证Join_Student
                    int ProvinceId = ValidJoin_Student(3, infoCard.StudentId, infoCard.RegisterDate);
                    if (infoCard.ProvinceId == 0)
                    {
                        infoCard.ProvinceId = ProvinceId;
                        DAL.GaoKaoCard.GaoKaoCardEdit(infoCard);
                    }
                }

                return GetJson(infoJson);
            }
            else
            {
                return "";
            }
        }

        /*使用账号和密码 检测 Join_Card 表*/
        string Join_Card(string strBank, string strPwd)
        {
            Entity.Join_Card infoCard = DAL.TengXB.Join_Card.Join_CardEntityGetByCardBank(strBank, strPwd);
            if (infoCard != null)
            {
                //UserInfo
                user.ProvinceId = infoCard.ProvinceId;//UserInfo


                //JsonCallBack
                infoJson.Bank = infoCard.CardBank;  //账号
                infoJson.Level = 9; //会员等级：会员卡账号
                infoJson.ProvinceName = GetProvinceName(infoCard.ProvinceId);//省份


                //判定是否已经关闭
                if (infoCard.UseState == 1)
                {
                    infoJson.Status = 2;//会员卡已关闭
                }
                else
                {
                    //没有被关闭的一张卡 , 等待接下来的处理即可

                    //通过StudentId 验证Join_Student  主要是判定Status   返回的结果：0StudentId为0；1注册账号；2会员卡账号；3高考卡账号

                    int ProvinceId = ValidJoin_Student(4, infoCard.StudentId, infoCard.OpenCardTime);
                    if (infoCard.ProvinceId == 0)
                    {
                        infoJson.ProvinceName = GetProvinceName(ProvinceId);//省份
                        infoCard.ProvinceId = ProvinceId;
                        DAL.Join_Card.Join_CardEdit(infoCard);
                    }
                }

                return GetJson(infoJson);
            }
            else
            {
                return "";
            }
        }

        /*使用账号和密码 检测 Join_Student 表*/
        string Join_Student(string strBank, string strPwd)
        {
            //判定是否是注册账号
            Entity.Join_Student infoStudent = DAL.TengXB.Join_Student.Join_StudentEntityGetBank(strBank, strPwd);
            if (infoStudent != null)  //是注册账号
            {
                //UserInfo
                user.StudentId = infoStudent.StudentId;//UserInfo
                user.ProvinceId = infoStudent.ProvinceId;//UserInfo
                user.KeLei = infoStudent.WenLi;//UserInfo
                user.GKYear = infoStudent.GKYear;//UserInfo

                //JsonCallBack
                infoJson.StudentName = infoStudent.StudentName;//学生姓名
                infoJson.Bank = infoStudent.StudentBank;//账号
                infoJson.Level = 1;//会员等级：普通注册用户
                infoJson.Status = 4;//账号状态：注册用户
                infoJson.ProvinceName = GetProvinceName(infoStudent.ProvinceId);//省份

                //判定是否关闭
                if (infoStudent.IsPause == 1)
                {
                    infoJson.Status = 2;//账号状态：注册用户被关闭
                }
                else
                {
                    //判定是否绑定高考卡了
                    Entity.GaoKaoCard infoGaoKaoCard = DAL.GaoKaoCard.GaoKaoCardEntityGetByStudentId(infoStudent.StudentId);
                    if (infoGaoKaoCard != null)
                    {
                        infoJson.Status = 3;
                        infoJson.Level = infoGaoKaoCard.CardLevel;
                    }
                }

                return GetJson(infoJson);
            }
            else
            {
                //不是注册用户
                return "";
            }
        }


        /* intCardLevel：3表示高考卡；4表示会员卡 */
        int ValidJoin_Student(int intCardLevel, int intStudentId, DateTime dtRegisterDate)
        {
            int provinceid = 0;
            //判定该卡是否完善个人信息了
            Entity.Join_Student infoStudent = DAL.Join_Student.Join_StudentEntityGet(intStudentId);
            if (infoStudent != null)  //已经完善过个人信息了
            {
                provinceid = infoStudent.ProvinceId;

                user.KeLei = infoStudent.WenLi;//UserInfo
                user.GKYear = infoStudent.GKYear;//UserInfo
                user.StudentId = infoStudent.StudentId;//UserInfo

                infoJson.StudentName = infoStudent.StudentName;//学生姓名

                //一张完善过个人信息的正常的高考卡
                infoJson.Status = intCardLevel;//高考卡3    会员卡4
            }
            else
            {
                //Student表中不存在数据  这时候 说明需要先去完善个人信息
                infoJson.Status = 1;
            }

            //已经完善过个人信息的会员卡的话，需要去判定是否绑定了高考卡
            if (infoJson.Status == 4)
            {
                Entity.GaoKaoCard infoGaoKaoCard = DAL.GaoKaoCard.GaoKaoCardEntityGetByStudentId(intStudentId);
                if (infoGaoKaoCard != null)
                {
                    infoJson.Status = 3;
                    infoJson.Level = infoGaoKaoCard.CardLevel;
                }
            }

            return provinceid;
        }

        /**   根据省份id获取省份名称  **/
        string GetProvinceName(int ProvinceId)
        {
            if (ProvinceId == null || ProvinceId == 0)
            {
                infoJson.Status = 1;//未完善个人信息
                return "";
            }
            else
                return DAL.Common.GetProvinceName(ProvinceId);

            //Entity.S_Province infoProvince = DAL.S_Province.S_ProvinceEntityGet(ProvinceId);
            //if (infoProvince != null)
            //{
            //    return infoProvince.ProvinceName;
            //}
            //else
        }


        /**   拼接 返回的json串  **/
        string GetJson(JsonCallBack info)
        {
            info.LevelName = DAL.Common.GetLevelName(info.Level);

            return "{\"status\":\"" + info.Status + "\",\"studentname\":\"" + info.StudentName + "\",\"bank\":\"" + info.Bank + "\",\"level\":\"" + info.Level + "\",\"levelname\":\"" + info.LevelName + "\",\"province\":\"" + info.ProvinceName + "\"}";
        }



        /**   返回json时的实体对象  **/
        class JsonCallBack
        {
            public int Status { get; set; } //状态
            public string StudentName { get; set; } //学生姓名
            public string Bank { get; set; }    //账号
            public int Level { get; set; }  //用户等级
            public string LevelName { get; set; }  //用户等级
            public string ProvinceName { get; set; }    //省份
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}