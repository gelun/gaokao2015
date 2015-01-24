using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GaoKao
{
    public class Base : System.Web.UI.Page
    {
        public Entity.UserInfo userinfo = new Entity.UserInfo();
        public Entity.ProvinceConfig provinceConfig = new Entity.ProvinceConfig();

        public Base()
        {
            this.Load += new EventHandler(page_Loading);
        }

        void page_Loading(object sender, EventArgs e)
        {
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


            userinfo.KeLeiMingCheng = DAL.Common.GetKeLeiMingCheng(userinfo.KeLei); //科类名称


            provinceConfig = DAL.ProvinceConfig.ProvinceConfigEntityGet(userinfo.ProvinceId);

            //userinfo.StudentId = Basic.Utils.StrToInt(Basic.CookieHelper.GetCookie("Student", "StudentId"), 5);
            //userinfo.StudentLevel = Basic.Utils.StrToInt(Basic.CookieHelper.GetCookie("Student", "StudentLevel"), 4);//用户等级id：1普通注册用户;2高考查看卡; 3普通测试卡; 4普通卡;  5VIP测试卡;  6VIP卡;9会员卡
            //userinfo.ProvinceId = Basic.Utils.StrToInt(Basic.CookieHelper.GetCookie("Student", "ProvinceId"), 3);//省份id
            //userinfo.KeLei = Basic.Utils.StrToInt(Basic.CookieHelper.GetCookie("Student", "KeLei"), 5);//科类
            //userinfo.GKYear = Basic.Utils.StrToInt(Basic.CookieHelper.GetCookie("Student", "GKYear"), 2014);//参加高考的年份
            //userinfo.Status = Basic.Utils.StrToInt(Basic.CookieHelper.GetCookie("Student", "Status"), 1);//登陆之后的状态值


            Status(); //根据状态  判定去向

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
                    }
                    break;
                default://账号或者密码错误
                    Response.Redirect("/logout.aspx");
                    break;
            }
        }

    }
}