using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GaoKao.SchoolLibrary
{
    public partial class SchoolFangTanDetail : System.Web.UI.Page
    {
        protected string strPageTitle = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            Bind();
        }

        void Bind()
        {
            int intId = Basic.RequestHelper.GetQueryInt("id", 0);
            Entity.SchoolArticle info = DAL.SchoolArticle.SchoolArticleEntityGet(intId);
            if (info != null)
            {
                Entity.School infoSchool = DAL.School.SchoolEntityGet(info.SchoolId);
                strPageTitle = info.Title;
                SchoolLeft1.intSchoolId = info.SchoolId;
                SchoolBase1.info = infoSchool;

                Crumb1.NavString = " <span>&gt;</span> <a href=\"/daxue.shtml\" title=\"高考报考院校库\">高考报考院校库</a> <span>&gt;</span> <a href=\"/daxue-jianjie-" + infoSchool.Id + ".shtml\" title=\"" + infoSchool.SchoolName + "\">" + infoSchool.SchoolName + "</a> <span>&gt;</span> <a href=\"/daxue-fangtan-" + infoSchool.Id + ".shtml\" title=\"" + infoSchool.SchoolName + "招办访谈\">招办访谈" + "</a> <span>&gt;</span> " + info.Title;

                ltlTitle.Text = info.Title;
                ltlContent.Text = info.Content;
            }
            else
            {
                Basic.MsgHelper.AlertBackMsg("该文章不存在");
            }
        }
    }
}