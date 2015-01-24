using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace GaoKao.GaoKaoZhenTi
{
    public partial class shiti_list : Base
    {
        protected int intSubjectId = 0;
        protected string strSubjectName = "";

        protected int intYear = 0;
        protected int intProvinceId = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            GetQueryString();
           Entity.edu_subject info= DAL.edu_subject.edu_subjectEntityGet(intSubjectId);
           if (info!=null)
           {
               strSubjectName = info.name;
           }
           else
           {
               ClientScript.RegisterStartupScript(GetType(), "", "<script>artDialog11('不存在该科目');history.go(-1);</script>");
               return;
           }

            Bind();


        }

        void GetQueryString()
        {
            intSubjectId = Basic.RequestHelper.GetQueryInt("subjectid", 0);
            intYear = Basic.RequestHelper.GetQueryInt("year", 0);
            intProvinceId = Basic.RequestHelper.GetQueryInt("provinceid", 0);

            if (intYear == 0)
            {
                ClientScript.RegisterStartupScript(GetType(), "", "<script>artDialog11('不合法的访问');</script>");
                return;
            }
            if (intProvinceId == 0)
            {
                ClientScript.RegisterStartupScript(GetType(), "", "<script>artDialog11('不合法的访问');</script>");
                return;
            }
        }

        void Bind()
        {
            DataTable dt = DAL.tengxb.zhenti.sjTiMuList(" shijuan.subject_id = " + intSubjectId + " and shijuan.province_id = " + intProvinceId + " AND shijuan.year = '" + intYear + "年'");
            if (dt != null && dt.Rows.Count > 0)
            {
                ltlShiJuanName.Text = dt.Rows[0]["name"].ToString();

                rpt_List.DataSource = dt;
                rpt_List.DataBind();
            }
            else
            {
                ClientScript.RegisterStartupScript(GetType(), "", "<script>artDialog11('不存在该试卷');history.go(-1);</script>");
                return;
            }
        }
    }
}