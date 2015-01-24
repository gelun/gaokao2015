using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace GaoKao.ProfessionalLibrary
{
    public partial class ProfessionalSearch : System.Web.UI.Page
    {
        protected string strProfessionalName = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            Bind();
        }

        void Bind()
        {
            strProfessionalName = Basic.RequestHelper.GetQueryString("professionalname").Trim();
            if (strProfessionalName != "")
            {
                DataTable dt = DAL.TengXB.Professional.ProfessionalListGet(strProfessionalName);
                if (dt != null && dt.Rows.Count > 0)
                {
                    rptList.DataSource = dt;
                    rptList.DataBind();
                }
            }

            Crumb1.NavString = " <span>&gt;</span> <a href=\"/zhuanye.shtml\" title\"高考报考专业库\">高考报考专业库</a> <span>&gt;</span> 专业搜索 <span>&gt;</span> " + strProfessionalName;

        }
    }
}