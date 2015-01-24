using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace GaoKao.SchoolLibrary
{
    public partial class SchoolLuQuGuiZe : System.Web.UI.Page
    {
        protected int intSchoolId = 0;
        protected string strSchoolName = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            Bind();
        }

        void Bind()
        {
            intSchoolId = Basic.RequestHelper.GetQueryInt("schoolid", 0);
            Entity.School info=DAL.School.SchoolEntityGet(intSchoolId);
            if (info!=null)
            {
                SchoolLeft1.intSchoolId = intSchoolId;
                SchoolBase1.info = info;
                strSchoolName = info.SchoolName;

                Crumb1.NavString = " <span>&gt;</span> <a href=\"/daxue.shtml\" title=\"高考报考院校库\">高考报考院校库</a> <span>&gt;</span> <a href=\"/daxue-jianjie-" + info.Id + ".shtml\" title=\"" + info.SchoolName + "\">" + info.SchoolName + "</a> <span>&gt;</span> 录取规则";

            }
            else
            {
                Basic.MsgHelper.AlertBackMsg("不合法的访问");
            }

            DataTable dt = DAL.SchoolArticle.SchoolArticleList(" SchoolId = " + intSchoolId + " and CategoryId = 13 ORDER By Year DESC");
            if (dt != null && dt.Rows.Count > 0)
            {
                ltlContent.Text = dt.Rows[0]["Content"].ToString();
            }
        }
    }
}