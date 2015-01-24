using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace GaoKao.Persional
{
    public partial class BindCard : Base
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            UserCenterLeft1.userinfo = userinfo;
            BindGaoKaoCard();
        }


        void BindGaoKaoCard()
        {
            if (!IsPostBack)
            {
                string ajaxRequest = Basic.RequestHelper.GetQueryString("ty");
                string kahao = Basic.RequestHelper.GetQueryString("kahao");
                string mima = Basic.RequestHelper.GetQueryString("mima");
                if (ajaxRequest == "bind")
                {
                    Response.Write(AjaxRequest(kahao, mima));
                    Response.End();
                }
            }
        }


        string AjaxRequest(string kahao, string mima)
        {
            // 1 验证卡号密码是否正确
            // 2 判定当前登陆用户的类别

            DataTable dt = DAL.GaoKaoCard.GaoKaoCardList("KaHao = '" + kahao + "' AND MiMa = '" + mima + "'");
            if (dt != null && dt.Rows.Count == 1)
            {
                if (userinfo.StudentLevel == 1 || userinfo.StudentLevel == 9)
                {
                    DataTable dtCardList = DAL.GaoKaoCard.GaoKaoCardList(" StudentId = " + userinfo.StudentId);
                    if (dtCardList == null || dtCardList.Rows.Count != 1)
                    {
                        return "当前账号已经绑定过一张高考卡了";
                    }
                    else
                    {
                        //注册账号  会员卡用户
                        if (DAL.GaoKaoCard.SetGaoKaoCardStudentId(userinfo.StudentId, kahao,userinfo.ProvinceId))
                        {
                            //修改cookie中的对应数据   用户等级、当前状态、等级名称
                            Basic.CookieHelper.WriteCookie("Student", "StudentLevel", dt.Rows[0]["CardLevel"].ToString(), 120);
                            Basic.CookieHelper.WriteCookie("Student", "Status", "3", 120);
                            Basic.CookieHelper.WriteCookie("Student", "LevelName", DAL.Common.GetLevelName(Basic.TypeConverter.StrToInt(dt.Rows[0]["CardLevel"].ToString(), 0)), 120);
                            return "绑定成功";
                        }
                        else
                        {
                            return "绑定失败";
                        }
                    }
                }
                else
                {
                    //高考卡用户
                    return "当前登陆账号已经绑定过高考报考卡了";
                }
            }
            else
            {
                return "账号或密码错误";
            }
        }
    }
}
