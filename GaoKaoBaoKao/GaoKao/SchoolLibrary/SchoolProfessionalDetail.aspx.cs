using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GaoKao.SchoolLibrary
{
    public partial class SchoolProfessionalDetail : System.Web.UI.Page
    {
        protected string strProfessionalName = "", strSchoolName = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            Bind();
        }

        void Bind()
        {
            int intId = Basic.RequestHelper.GetQueryInt("spid", 0);
            Entity.SchoolProfessional info = DAL.SchoolProfessional.SchoolProfessionalEntityGet(intId);
            if (info != null)
            {
                strProfessionalName = info.ProfessionalName;//专业名称
                Entity.School infoSchool = DAL.School.SchoolEntityGet(info.SchoolId);
                if (infoSchool != null)
                {
                    SchoolLeft1.intSchoolId = info.SchoolId;
                    SchoolBase1.info = infoSchool;
                    strSchoolName = infoSchool.SchoolName;//院校名称

                    Crumb1.NavString = " <span>&gt;</span> <a href=\"/daxue.shtml\" title=\"高考报考院校库\">高考报考院校库</a> <span>&gt;</span> <a href=\"/daxue-jianjie-" + infoSchool.Id + ".shtml\" title=\"" + infoSchool.SchoolName + "\">" + infoSchool.SchoolName + "</a> <span>&gt;</span> " + strProfessionalName;

                }
                //专业相关信息
                ltlTitle.Text = info.ProfessionalName;
                string strIntro = info.ProfessionalIntro;
                if (strIntro.Trim() == "")
                {
                    Entity.Professional infoPro = DAL.Professional.ProfessionalEntityGet(info.ProfessionalId);
                    if (infoPro != null)
                    {
                        strIntro = infoPro.ProfessionalIntro;
                    }
                }

                ltlContent.Text = strIntro;
            }
            else
            {
                Basic.MsgHelper.AlertBackMsg("获取专业信息失败");
            }
        }
    }
}