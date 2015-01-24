using System;
using System.Collections.Generic;
using System.Data;
using System.Web;

namespace GaoKao
{
    public class BaseTuiJian : System.Web.UI.Page
    {
        public Entity.UserInfo userinfo = new Entity.UserInfo();
        public Entity.StudentGaoKaoHistory history = new Entity.StudentGaoKaoHistory();
        public Entity.StudentGaoKaoHistory_ZheJiang history_zhejiang = new Entity.StudentGaoKaoHistory_ZheJiang();
        public Entity.StudentChengJi studentChengJi = new Entity.StudentChengJi();
        public Entity.FenShuXian fenshuxian = new Entity.FenShuXian();
        public int StudentChengJiPiCi = 0;
        public string StudentChengJiPiCiMingCheng = "";
        public int StudentChengJiXianChaShang = 0;//上一批次的线差
        public int StudentChengJiXianCha = 0;//批次的线差
        public int StudentChengJiPiCiXian = 0;//批次线
        public Entity.ProvinceConfig provinceConfig = new Entity.ProvinceConfig();

        public BaseTuiJian()
        {
            //初始化
            this.Load += new EventHandler(page_Loading);

        }

        void page_Loading(object sender, EventArgs e)
        {
            #region 用户登录信息
            userinfo.StudentId = Basic.Utils.StrToInt(Basic.CookieHelper.GetCookie("Student", "StudentId"), 0);
            userinfo.StudentLevel = Basic.Utils.StrToInt(Basic.CookieHelper.GetCookie("Student", "StudentLevel"), 0);//用户等级id：1普通注册用户;2高考查看卡; 3普通测试卡; 4普通卡;  5VIP测试卡;  6VIP卡;9会员卡
            userinfo.ProvinceId = Basic.Utils.StrToInt(Basic.CookieHelper.GetCookie("Student", "ProvinceId"), 0);//省份id
            userinfo.KeLei = Basic.Utils.StrToInt(Basic.CookieHelper.GetCookie("Student", "KeLei"), 0);//科类
            userinfo.GKYear = Basic.Utils.StrToInt(Basic.CookieHelper.GetCookie("Student", "GKYear"), 0);//参加高考的年份
            userinfo.Status = Basic.Utils.StrToInt(Basic.CookieHelper.GetCookie("Student", "Status"), 0);//登陆之后的状态值
            userinfo.StudentName = Basic.CookieHelper.GetCookie("Student", "StudentName");//学生姓名
            userinfo.Bank = Basic.CookieHelper.GetCookie("Student", "Bank");//当前登陆的账号
            userinfo.LevelName = Basic.CookieHelper.GetCookie("Student", "LevelName");//用户等级名称: 1普通注册用户;2高考查看卡; 3普通测试卡; 4普通卡;  5VIP测试卡;  6VIP卡;9会员卡
            userinfo.ProvinceName = Basic.CookieHelper.GetCookie("Student", "ProvinceName"); //省份名称

            //userinfo.StudentId = Basic.Utils.StrToInt(Basic.CookieHelper.GetCookie("Student", "StudentId"), 5);
            //userinfo.StudentLevel = Basic.Utils.StrToInt(Basic.CookieHelper.GetCookie("Student", "StudentLevel"), 4);//用户等级id：1普通注册用户;2高考查看卡; 3普通测试卡; 4普通卡;  5VIP测试卡;  6VIP卡;9会员卡
            //userinfo.ProvinceId = Basic.Utils.StrToInt(Basic.CookieHelper.GetCookie("Student", "ProvinceId"), 3);//省份id
            //userinfo.KeLei = Basic.Utils.StrToInt(Basic.CookieHelper.GetCookie("Student", "KeLei"), 5);//科类
            //userinfo.GKYear = Basic.Utils.StrToInt(Basic.CookieHelper.GetCookie("Student", "GKYear"), 2014);//参加高考的年份
            //userinfo.Status = Basic.Utils.StrToInt(Basic.CookieHelper.GetCookie("Student", "Status"), 1);//登陆之后的状态值

            userinfo.ProvinceName = DAL.Common.GetProvinceName(userinfo.ProvinceId);
            userinfo.KeLeiMingCheng = DAL.Common.GetKeLeiMingCheng(userinfo.KeLei);
            #endregion


            #region 新疆乌鲁木齐咨询中心的卡不能在喀什地区使用

            if (userinfo.ProvinceId == 72)//新疆乌鲁木齐咨询中心
            {
                Entity.AreaJson infoAreaJson = DAL.AnalysisArea.GetAreaModel();
                if (infoAreaJson != null)
                {
                    if (infoAreaJson.code == "0")
                    {
                        if (infoAreaJson.data.city_id == "653100")
                        {
                            //新疆乌鲁木齐咨询中心的卡不能在喀什地区使用
                            Basic.MsgHelper.AlertUrlMsg("该卡不能在喀什地区使用", "/logout.aspx");
                        }
                    }
                }
            }
            #endregion


            Status(); //根据状态  判定去向

            //根据登陆用户的省份，去取一下省份的志愿配置信息
            int ProvinceId = userinfo.ProvinceId;

            provinceConfig = DAL.ProvinceConfig.ProvinceConfigEntityGet(userinfo.ProvinceId);

            //测试数据
            //history.LeiJiRenShu = 1000;
            //history.RenShu = 99;
            //history.WeiCi = 900;
            //history.FenShu = 600;

            if (userinfo.ProvinceId == 11)//浙江
            {
                history_zhejiang = DAL.StudentGaoKaoHistory_ZheJiang.StudentGaoKaoHistory_ZheJiangEntityGetByStudentId(userinfo.StudentId);
                if (history_zhejiang == null)
                {
                    Basic.MsgHelper.AlertUrlMsg("请首先设置自己的考试成绩！", "/Persional/ChengJiEdit2.aspx"); //跳转到成绩输入页面
                }
                if (history_zhejiang.ZongFen1 == 0 && history_zhejiang.ZongFen2 == 0 && history_zhejiang.ZongFen3 == 0)
                    Basic.MsgHelper.AlertUrlMsg("您的成绩设置有问题，请重新设置后使用", "/Persional/ChengJiEdit2.aspx");

                //判断第几批次，批次线差
                fenshuxian = DAL.FenShuXian.FenShuXianEntityGet(ProvinceId, " AND KeLei = " + userinfo.KeLei);
                // studentChengJi = DAL.CommonTuiJian.GetZheJiangUserPiCi(fenshuxian, history_zhejiang.ZongFen1, provinceConfig.LatestProvinceWeiCiYear, ProvinceId, userinfo.KeLei);

                //if (studentChengJi.PiCi == 0)
                //    Basic.MsgHelper.AlertUrlMsg("您的成绩设置有问题，请重新设置后使用", "/Persional/ChengJiEdit2.aspx");

                //StudentChengJiPiCi = studentChengJi.PiCi;
                ////studentChengJi.PiCiMingCheng = DAL.Common.GetPiCiName(StudentChengJiPiCi, userinfo.ProvinceId);
                //if (StudentChengJiPiCi <= 3)
                //    StudentChengJiPiCiMingCheng = "本科" + StudentChengJiPiCiMingCheng;

            }
            else
            {
                history = DAL.StudentGaoKaoHistory.StudentGaoKaoHistoryEntityGet(userinfo.StudentId);

                //非浙江
                if (history == null)
                {
                    Basic.MsgHelper.AlertUrlMsg("请首先设置自己的考试成绩！", "/Persional/ChengJiEdit2.aspx"); //跳转到成绩输入页面
                }
                if (history.FenShu == 0)
                    Basic.MsgHelper.AlertUrlMsg("您的成绩设置有问题，请重新设置后使用", "/Persional/ChengJiEdit2.aspx");


                if (history.IsSetUpWeiCi == 0)
                {
                    Entity.ProvinceWeiCi infoProvinceWeiCi = null;
                    if (userinfo.ProvinceId == 10)//江苏
                    {
                        //if (history.FenShu < 180)
                        //{
                        //    history.FenShu = 180;
                        //}
                        infoProvinceWeiCi = DAL.ProvinceWeiCi.ProvinceWeiCiEntityGetByFenShu(history.FenShu, provinceConfig.LatestProvinceWeiCiYear, userinfo.ProvinceId, userinfo.KeLei);
                    }
                    else
                    {
                        infoProvinceWeiCi = DAL.ProvinceWeiCi.ProvinceWeiCiEntityGetByFenShu(history.FenShu, provinceConfig.LatestProvinceWeiCiYear, userinfo.ProvinceId, userinfo.KeLei);
                    }
                    if (infoProvinceWeiCi != null)
                    {
                        history.WeiCi = infoProvinceWeiCi.WeiCi;
                    }
                    else
                    {
                        Basic.MsgHelper.AlertUrlMsg("您设置的成绩有问题，请重新设置后使用", "/Persional/ChengJiEdit2.aspx");
                    }
                }

                //判断第几批次，批次线差
                fenshuxian = DAL.FenShuXian.FenShuXianEntityGet(ProvinceId, " AND KeLei = " + userinfo.KeLei);
                if (history.IsSetUpFenShuXian == 1)
                {
                    fenshuxian.PcFirst = (history.PcFirst > 0 ? history.PcFirst : fenshuxian.PcFirst);
                    fenshuxian.PcSecond = (history.PcSecond > 0 ? history.PcSecond : fenshuxian.PcSecond);
                    fenshuxian.PcThird = (history.PcThird > 0 ? history.PcThird : fenshuxian.PcThird);
                    fenshuxian.ZkFirst = (history.PcZhuanKeFirst > 0 ? history.PcZhuanKeFirst : fenshuxian.ZkFirst);
                    fenshuxian.ZkSecond = (history.PcZhuanKeSecond > 0 ? history.PcZhuanKeSecond : fenshuxian.ZkSecond);
                }


                studentChengJi = DAL.CommonTuiJian.GetUserPiCi(fenshuxian, history.FenShu, provinceConfig.LatestProvinceWeiCiYear, ProvinceId, userinfo.KeLei);
                if (studentChengJi.PiCi == 0)
                    Basic.MsgHelper.AlertUrlMsg("您的成绩设置有问题，请重新设置后使用", "/Persional/ChengJiEdit2.aspx");

                StudentChengJiPiCi = studentChengJi.PiCi;
                //<%=DAL.Common.GetPiCiMingCheng(studentChengJi.PiCi) %>
                if (history.IsSetUpFenShuXian == 1)
                {
                    switch (StudentChengJiPiCi)
                    {
                        case 1:
                            if (history.PcFirst > 0)
                            {
                                studentChengJi.PiCiMingCheng = "预估" + DAL.Common.GetPiCiName(StudentChengJiPiCi, userinfo.ProvinceId);
                            }
                            break;
                        case 2:
                            if (history.PcSecond > 0)
                            {
                                studentChengJi.PiCiMingCheng = "预估" + DAL.Common.GetPiCiName(StudentChengJiPiCi, userinfo.ProvinceId);
                            }
                            break;
                        case 3:
                            if (history.PcThird > 0)
                            {
                                studentChengJi.PiCiMingCheng = "预估" + DAL.Common.GetPiCiName(StudentChengJiPiCi, userinfo.ProvinceId);
                            }
                            break;
                        case 4:
                            if (history.PcZhuanKeFirst > 0)
                            {
                                studentChengJi.PiCiMingCheng = "预估" + DAL.Common.GetPiCiName(StudentChengJiPiCi, userinfo.ProvinceId);
                            }
                            break;
                        case 5:
                            if (history.PcZhuanKeSecond > 0)
                            {
                                studentChengJi.PiCiMingCheng = "预估" + DAL.Common.GetPiCiName(StudentChengJiPiCi, userinfo.ProvinceId);
                            }
                            break;
                        default:
                            studentChengJi.PiCiMingCheng = DAL.Common.GetPiCiName(StudentChengJiPiCi, userinfo.ProvinceId);
                            break;
                    }
                }
                else
                {
                    studentChengJi.PiCiMingCheng = DAL.Common.GetPiCiName(StudentChengJiPiCi, userinfo.ProvinceId);
                }
                if (StudentChengJiPiCi <= 3)
                {
                    StudentChengJiPiCiMingCheng = "本科" + StudentChengJiPiCiMingCheng;
                }
            }
        }

        /*  根据状态  判定去向  */
        void Status()
        {
            //根据状态  判定去向
            switch (userinfo.Status)
            {
                case 0://账号或者密码错误
                    Response.Redirect("/login.shtml");
                    break;
                case 1://1：未完善个人信息：目前只有账号和密码
                    Response.Redirect("/Persional/LetterForParent.aspx");
                    break;
                case 2://2：账号被完全关闭账号：卡用户的卡已关闭或者过期；注册用户被关闭
                    Response.Redirect("/logout.aspx");
                    break;
                case 3://3：高考卡用户：可以正常使用系统的账户
                    if (userinfo.StudentId == 0)
                    {
                        //此时说明，登陆时候的判定逻辑（Persional/loginin.ashx）或者系统中的数据出问题了，正常情况下，这时候的 StudentId 应该是真是存在的
                        Response.Redirect("/logout.aspx");
                    }
                    else
                    {
                        //正常处理
                    }
                    break;
                case 4://4.注册用户或者会员卡用户（如果是先注册，后绑定的报考卡，那么报考卡过期之后该用户又是一个普通注册用户了）
                    if (userinfo.StudentId == 0)
                    {
                        //此时说明，登陆时候的判定逻辑（Persional/loginin.ashx）或者系统中的数据出问题了，正常情况下，这时候的 StudentId 应该是真是存在的
                        Response.Redirect("/logout.aspx");
                    }
                    else
                    {
                        //正常处理
                        Basic.MsgHelper.AlertUrlMsg("购买高考报考卡之后，才可使用本功能，请先购买", "/GaoKaoCard/GouKa.aspx");
                    }
                    break;
                default://账号或者密码错误
                    Response.Redirect("/logout.aspx");
                    break;
            }
        }

    }
}
