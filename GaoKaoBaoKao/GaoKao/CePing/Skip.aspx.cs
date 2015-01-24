using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GaoKao.CePing
{
    public partial class Skip : Base
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Basic.CookieHelper.WriteCookieWithDomain("user", "Id", userinfo.StudentId.ToString(), ".gelunjiaoyu.com", 120);
            int StudenId = Basic.Utils.StrToInt(Basic.CookieHelper.GetCookie("user", "Id"), 0);
            if (StudenId == 0)
            {
                Response.Redirect("/login.aspx");
            }
            else
            {

                //跳转到mbti测评
                int TypeId = Basic.RequestHelper.GetQueryInt("t", 1);
                if (TypeId == 1)
                    Response.Redirect("/CePing/Mbit/default.aspx");
                else if (TypeId == 2)
                    Response.Redirect("/CePing/Ability/default.aspx");
                else if (TypeId == 3)
                    Response.Redirect("/CePing/Holland/default.aspx");
                else if (TypeId == 4)
                    Response.Redirect("/CePing/Profession/default.aspx");
            }
        }
    }
}