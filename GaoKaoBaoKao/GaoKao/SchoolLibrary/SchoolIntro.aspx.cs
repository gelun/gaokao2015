using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace GaoKao.SchoolLibrary
{
    public partial class SchoolIntro : System.Web.UI.Page
    {
        protected int intSchoolId = 0;
        protected string strHasCampus = "";
        public string strSchoolName = "", strSchoolEnName = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            Bind();
        }

        void Bind()
        {
            intSchoolId = Basic.RequestHelper.GetQueryInt("schoolid", 0);
            SchoolLeft1.intSchoolId = intSchoolId;

            Entity.School info = DAL.School.SchoolEntityGet(intSchoolId);
            if (info != null)
            {
                info.ClickNum += 1;
                DAL.TengXB.School.SchoolClickNum(info);

                SchoolBase1.info = info;
                strSchoolName = info.SchoolName;
                strSchoolEnName = info.SchoolEnName;


                //面包屑
                Crumb1.NavString = " <span>&gt;</span> <a href=\"/daxue.shtml\" title=\"高考报考院校库\">高考报考院校库</a> <span>&gt;</span> " + info.SchoolName;

                ltlSchoolIntro.Text = info.SchoolIntro;

                DataTable dt = DAL.TengXB.SchoolCampus.GetSchoolCampusList(" SchoolId = " + intSchoolId);
                if (dt != null && dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        string strCampus = dt.Rows[i]["Campus"].ToString();
                        if (strCampus == "")
                        {
                            strCampus = "本部校区";
                        }

                        ltlCampus.Text += "<li" + (i == 0 ? " class=\"current\"" : "") + " pano=\"" + dt.Rows[i]["Pano"].ToString() + "\" heading=\"" + dt.Rows[i]["Heading"].ToString() + "\" pitch=\"" + dt.Rows[i]["Pitch"].ToString() + "\" zoom=\"" + dt.Rows[i]["Zoom"].ToString() + "\"><a href=\"javascript:void(0)\">" + strCampus + "</a></li>";
                    }
                }
                else
                {
                    strHasCampus = "no";
                }

                BindSchools(info.ProvinceId);
            }
        }

        void BindSchools(int intProvinceId)
        {
            DataTable dt = DAL.TengXB.School.GetSchoolList("ProvinceId = " + intProvinceId, 18);
            if (dt != null && dt.Rows.Count > 0)
            {
                string strHtml = "<div class=\"conRtit\">同地区部分院校</div>";

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string strSchoolId = dt.Rows[i]["Id"].ToString();
                    string strSchoolName = dt.Rows[i]["SchoolName"].ToString();
                    string strLogo = dt.Rows[i]["Logo"].ToString();
                    if (strLogo == "")
                    {
                        strLogo = "default.png";
                    }

                    strHtml += (i + 1) % 9 == 1 ? "<div class=\"dxlist\">" : "";

                    strHtml += "<dl " + ((i + 1) % 9 == 1 ? "style=\"margin-left: 5px;\"" : "") + ">";
                    strHtml += "<dt><a href=\"daxue-jianjie-" + strSchoolId + ".shtml\" title=\"" + strSchoolName + "\"><img src=\"/logo/" + strLogo + "\" alt=\"" + strSchoolName + "\" width=\"80\" height=\"80\" /></a></dt>";
                    strHtml += "<dd><a href=\"daxue-jianjie-" + strSchoolId + ".shtml\" title=\"" + strSchoolName + "\">" + Basic.Utils.GetUnicodeSubString(strSchoolName, 12, "") + "</a></dd>";
                    strHtml += "</dl>";

                    if ((i + 1) == dt.Rows.Count)
                    {
                        strHtml += "</div>";
                    }
                    else
                    {
                        strHtml += (i + 1) % 9 == 0 ? "</div>" : "";
                    }
                }

                ltlSchoolList.Text = strHtml;
            }
        }
    }
}