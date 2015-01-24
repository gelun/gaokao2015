using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GaoKao.CePing
{
    public partial class ceping1 : Dian
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int intStudentId = Basic.Utils.StrToInt(Basic.CookieHelper.GetCookie("Student", "StudentId"), 0);
            Entity.GaoKaoCard info = DAL.GaoKaoCard.GaoKaoCardEntityGetByStudentId(intStudentId);
            if (info != null)
            {
                if (info.DianId > 0)
                {
                    //Basic.Utils.WriteCookie
                    Basic.CookieHelper.WriteCookie("dian", "ok");
                }
            }
        }
    }
}