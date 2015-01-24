using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GaoKao.CePing
{
    public class Dian : System.Web.UI.Page
    {

        public Dian()
        {
            //初始化
            this.Load += new EventHandler(page_Loading);
        }

        void page_Loading(object sender, EventArgs e)
        {
            int intStudentId = Basic.Utils.StrToInt(Basic.CookieHelper.GetCookie("Student", "StudentId"), 0);
            Entity.GaoKaoCard info = DAL.GaoKaoCard.GaoKaoCardEntityGetByStudentId(intStudentId);
            if (info != null)
            {
                if (info.DianId > 0)
                {
                    Basic.CookieHelper.WriteCookie("dian", "ok");
                }
            }
        }
    }
}