using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace GaoKao.SchoolLibrary
{
    public partial class SchoolZhangCheng : System.Web.UI.Page
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
            Entity.School info = DAL.School.SchoolEntityGet(intSchoolId);
            if (info != null)
            {
                SchoolLeft1.intSchoolId = intSchoolId;
                SchoolBase1.info = info;
                strSchoolName = info.SchoolName;

                Crumb1.NavString = " <span>&gt;</span> <a href=\"/daxue.shtml\" title=\"高考报考院校库\">高考报考院校库</a> <span>&gt;</span> <a href=\"/daxue-jianjie-" + info.Id + ".shtml\" title=\"" + info.SchoolName + "\">" + info.SchoolName + "</a> <span>&gt;</span> 招生章程";

            }
            else
            {
                Basic.MsgHelper.AlertBackMsg("不合法的访问");
            }


            DataTable dt = DAL.SchoolArticle.SchoolArticleList(" SchoolId = " + intSchoolId + " and CategoryId = 2 ORDER By Year DESC");
            if (dt != null && dt.Rows.Count > 0)
            {
                string strYear = "";
                string strContent = "";
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    strYear += "<li " + (i == 0 ? "class=\"current\"" : "") + "><a href=\"javascript:void(0);\">" + dt.Rows[i]["Year"].ToString() + "年</a></li>";
                    strContent += "<div class=\"conRword\" " + (i > 0 ? "style=\"display: none;\"" : "") + ">" + dt.Rows[i]["Content"].ToString() + "</div>";
                }

                ltlYear.Text = strYear;

                ltlContent.Text = strContent;
            }
        }
    }
}