using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GaoKao.SchoolLibrary
{
    public partial class SchoolFenShuXian : System.Web.UI.Page
    {
        protected int intSchoolId = 0;
        protected string strPageTitle = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            intSchoolId = Basic.RequestHelper.GetQueryInt("schoolid", 0);
            Entity.School info = DAL.School.SchoolEntityGet(intSchoolId);
            if (info != null)
            {
                SchoolBase1.info = info;
                SchoolLeft1.intSchoolId = info.Id;

                strPageTitle = info.SchoolName;

                Crumb1.NavString = " <span>&gt;</span> <a href=\"/daxue.shtml\" title=\"高考报考院校库\">高考报考院校库</a> <span>&gt;</span> <a href=\"/daxue-jianjie-" + info.Id + ".shtml\" title=\"" + info.SchoolName + "\">" + info.SchoolName + "</a> <span>&gt;</span> 历年分数线";

            }
            else
            {
                Basic.MsgHelper.AlertBackMsg("不合法的访问");
            }
        }
    }
}