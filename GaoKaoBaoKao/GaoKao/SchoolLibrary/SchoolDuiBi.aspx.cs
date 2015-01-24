using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace GaoKao.SchoolLibrary
{
    public partial class SchoolDuiBi : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Bind();
        }

        void Bind()
        {
            string strDuiBiList = Basic.CookieHelper.GetCookie("duibischool");
            if (strDuiBiList != "")
            {
                string[] arr = strDuiBiList.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                if (arr != null && arr.Length > 0)
                {
                    if (strDuiBiList.StartsWith(","))
                    {
                        strDuiBiList = strDuiBiList.Substring(1);
                    }
                    if (strDuiBiList.EndsWith(","))
                    {
                        strDuiBiList = strDuiBiList.Substring(0, strDuiBiList.Length - 1);
                    }

                    DataTable dt = DAL.School.SchoolList("Id in (" + strDuiBiList + ")");
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        int count = dt.Rows.Count;
                        for (int i = 0; i < count; i++)
                        {
                            int SchoolId = Basic.TypeConverter.StrToInt(dt.Rows[i]["Id"].ToString());
                            ltlLogoList.Text += "<td width=\"240\"><a target=\"_blank\" href=\"daxue-jianjie-" + SchoolId + ".shtml\" title=\"" + dt.Rows[i]["SchoolName"].ToString() + "\"><img src=\"/logo/" + (dt.Rows[i]["Logo"].ToString() == "" ? "default.png" : dt.Rows[i]["Logo"].ToString()) + "\" width=\"110\" height=\"110\"></a></td>";
                            ltlSchoolNameList.Text += "<td>" + dt.Rows[i]["SchoolName"].ToString() + "</td>";
                            ltlBiaoQianList.Text += "<td class=\"tdbq\">" + GetBiaoQian(dt.Rows[i]) + "</td>";
                            ltlFoundTimeList.Text += "<td>" + dt.Rows[i]["FoundingTime"].ToString() + "</td>";
                            ltlLeiXingList.Text += "<td>" + dt.Rows[i]["YuanXiaoLeiXing"].ToString() + "</td>";
                            ltlBoShiDianList.Text += "<td>" + dt.Rows[i]["BoShiDian"].ToString() + "</td>";
                            ltlShuoShiDianList.Text += "<td>" + dt.Rows[i]["ShuoShiDian"].ToString() + "</td>";
                            ltlZhongDianXueKeList.Text += "<td>" + dt.Rows[i]["ZhongDianXueKe"].ToString() + "</td>";
                            ltlWuShuLianList.Text += "<td>" + dt.Rows[i]["WuShuLianRanking"].ToString() + "</td>";
                            ltlXiaoYouHuiList.Text += "<td>" + dt.Rows[i]["XiaoYouHuiRanking"].ToString() + "</td>";
                            ltlZhongDianZhuanYeList.Text += "<td class=\"tdbq\">" + GetZhongDianZhuanYe(DAL.TengXB.SchoolDisciplines.YouShiZhuanYeList(" (IsYiJiZhongDian = 1 or IsErJiZhongDian = 1) AND sd.SchoolId = " + SchoolId)) + "</td>";
                            ltlTeSeZhuanYeList.Text += "<td class=\"tdbq\">" + GetTeSeZhuanYe(DAL.TengXB.SchoolDisciplines.YouShiZhuanYeList(" IsTeSe = 1 AND sd.SchoolId = " + SchoolId)) + "</td>";
                        }

                        string strTh = "";
                        string strTd = "";
                        for (int i = 0; i < 5 - count; i++)
                        {
                            strTh += "<td width=\"240\"></td>";
                            strTd += "<td></td>";
                        }

                        ltlLogoList.Text += strTh;
                        ltlSchoolNameList.Text += strTd;
                        ltlBiaoQianList.Text += strTd;
                        ltlFoundTimeList.Text += strTd;
                        ltlLeiXingList.Text += strTd;
                        ltlBoShiDianList.Text += strTd;
                        ltlShuoShiDianList.Text += strTd;
                        ltlZhongDianXueKeList.Text += strTd;
                        ltlWuShuLianList.Text += strTd;
                        ltlXiaoYouHuiList.Text += strTd;
                        ltlZhongDianZhuanYeList.Text += strTd;
                        ltlTeSeZhuanYeList.Text += strTd;

                    }


                }
                else
                {
                    Response.Redirect("/daxue.shtml");
                }
            }
            else
            {
                Response.Redirect("/daxue.shtml");
            }
        }


        string GetBiaoQian(DataRow dr)
        {
            string strTeSe = "";

            //211
            if (dr["Is211"].ToString() == "1")
            {
                strTeSe += "<a href=\"javascript:void(0);\">211</a>";
            }
            //Is985
            if (dr["Is985"].ToString() == "1")
            {
                strTeSe += "<a href=\"javascript:void(0);\">985</a>";
            }
            //研究生院
            if (dr["IsGraduateSchool"].ToString() == "1")
            {
                strTeSe += "<a href=\"javascript:void(0);\">研</a>";
            }
            //自主招生
            if (dr["IsIndependentRecruitment"].ToString() == "1")
            {
                strTeSe += "<a href=\"javascript:void(0);\">自</a>";
            }
            //国防生
            if (dr["IsNationalDefense"].ToString() == "1")
            {
                strTeSe += "<a href=\"javascript:void(0);\">国</a>";
            }
            //小211
            if (dr["IsMiNi211"].ToString() == "1")
            {
                strTeSe += "<a href=\"javascript:void(0);\">小211</a>";
            }
            //农村专项
            if (dr["IsRuralSpecial"].ToString() == "1")
            {
                strTeSe += "<a href=\"javascript:void(0);\">农</a>";
            }
            //艺术生
            if (dr["IsArtSpecialty"].ToString() == "1")
            {
                strTeSe += "<a href=\"javascript:void(0);\">艺</a>";
            }
            //高水平运动员
            if (dr["IsHighLevelAthletes"].ToString() == "1")
            {
                strTeSe += "<a href=\"javascript:void(0);\">体</a>";
            }
            //卓越工程
            if (dr["IsExcellent"].ToString() == "1")
            {
                strTeSe += "<a href=\"javascript:void(0);\">卓</a>";
            }

            return strTeSe;
        }


        /*  重点学科专业 */
        string GetZhongDianZhuanYe(DataTable dt)
        {
            string strHtml = "";

            if (dt != null && dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    strHtml += dt.Rows[i]["ProfessionalName"].ToString() + "，";
                }
                if (strHtml.EndsWith("，"))
                {
                    strHtml = strHtml.Substring(0, strHtml.Length - 1);
                }
            }
            return strHtml;
        }


        /*  特色专业 */
        string GetTeSeZhuanYe(DataTable dt)
        {
            string strHtml = "";
            if (dt != null && dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    strHtml += dt.Rows[i]["ProfessionalName"].ToString() + "，";
                }
                if (strHtml.EndsWith("，"))
                {
                    strHtml = strHtml.Substring(0, strHtml.Length - 1);
                }
            }
            return strHtml;
        }


    }
}