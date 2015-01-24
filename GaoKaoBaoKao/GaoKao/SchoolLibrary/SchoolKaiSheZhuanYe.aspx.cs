using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace GaoKao.SchoolLibrary
{
    public partial class SchoolKaiSheZhuanYe : System.Web.UI.Page
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

                Crumb1.NavString = " <span>&gt;</span> <a href=\"/daxue.shtml\" title=\"高考报考院校库\">高考报考院校库</a> <span>&gt;</span> <a href=\"/daxue-jianjie-" + info.Id + ".shtml\" title=\"" + info.SchoolName + "\">" + info.SchoolName + "</a> <span>&gt;</span> 开设专业";

            }
            else
            {
                Basic.MsgHelper.AlertBackMsg("不合法的访问");
            }


            DataTable dt = null;
            //本科
            dt = DAL.TengXB.SchoolDisciplines.GetSchoolDisciplinesList(" sd.SchoolId = " + intSchoolId + " AND p.IsBen = 1");
            if (dt != null && dt.Rows.Count > 0)
            {
                rptBenKeList.DataSource = dt;
                rptBenKeList.DataBind();
            }

            //专科
            dt = DAL.TengXB.SchoolDisciplines.GetSchoolDisciplinesList(" sd.SchoolId = " + intSchoolId + " AND p.IsBen = 2");
            if (dt != null && dt.Rows.Count > 0)
            {
                rptZhuanKeList.DataSource = dt;
                rptZhuanKeList.DataBind();
            }
        }

        protected void rptBenKeList_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Repeater rptList = e.Item.FindControl("rptList") as Repeater;//找到里层的repeater对象
                DataRowView rowv = (DataRowView)e.Item.DataItem;//找到分类Repeater关联的数据项 
                int intSchoolDisciplinesId = Convert.ToInt32(rowv["SchoolDisciplinesId"]); // 
                rptList.DataSource = DAL.TengXB.SchoolDisciplines.GetSchoolProfessionalList("SchoolDisciplinesId = " + intSchoolDisciplinesId);
                rptList.DataBind();
            }
        }

        protected void rptZhuanKeList_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Repeater rptList = e.Item.FindControl("rptList") as Repeater;//找到里层的repeater对象
                DataRowView rowv = (DataRowView)e.Item.DataItem;//找到分类Repeater关联的数据项 
                int intSchoolDisciplinesId = Convert.ToInt32(rowv["SchoolDisciplinesId"]); // 
                rptList.DataSource = DAL.TengXB.SchoolDisciplines.GetSchoolProfessionalList("SchoolDisciplinesId = " + intSchoolDisciplinesId);
                rptList.DataBind();
            }
        }
    }
}