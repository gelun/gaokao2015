using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace GaoKao.SchoolLibrary
{
    public partial class SchoolYouShiZhuanYe : System.Web.UI.Page
    {
        protected int intSchoolId = 0;
        protected string strPageTitle = "";
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
                strPageTitle = info.SchoolName;

                Crumb1.NavString = " <span>&gt;</span> <a href=\"/daxue.shtml\" title=\"高考报考院校库\">高考报考院校库</a> <span>&gt;</span> <a href=\"/daxue-jianjie-" + info.Id + ".shtml\" title=\"" + info.SchoolName + "\">" + info.SchoolName + "</a> <span>&gt;</span> 优势专业";

            }
            else
            {
                Basic.MsgHelper.AlertBackMsg("不合法的访问");
            }

            DataTable dt = null;
            string strWhere = "sd.SchoolId = " + intSchoolId;
            //特色专业
            strWhere = "sd.SchoolId = " + intSchoolId + " AND sp.IsTeSe = 1";
            dt = DAL.TengXB.SchoolDisciplines.YouShiZhuanYeList(strWhere);
            if (dt!=null&&dt.Rows.Count>0)
            {
                rpTeSetList.DataSource = dt;
                rpTeSetList.DataBind();
            }

            //一级重点学科
            strWhere = "sd.SchoolId = " + intSchoolId + " AND sp.IsYiJiZhongDian = 1";
            dt = DAL.TengXB.SchoolDisciplines.YouShiZhuanYeList(strWhere);
            if (dt != null && dt.Rows.Count > 0)
            {
                rptYiJiList.DataSource = dt;
                rptYiJiList.DataBind();
            }

            //二级重点学科
            strWhere = "sd.SchoolId = " + intSchoolId + " AND sp.IsErJiZhongDian = 1";
            dt = DAL.TengXB.SchoolDisciplines.YouShiZhuanYeList(strWhere);
            if (dt != null && dt.Rows.Count > 0)
            {
                rptErJiList.DataSource = dt;
                rptErJiList.DataBind();
            }
        }
    }
}