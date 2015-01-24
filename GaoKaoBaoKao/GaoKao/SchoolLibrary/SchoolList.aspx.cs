using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GaoKao.SchoolLibrary
{
    public partial class SchoolList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //this.nav1.lit_Nav.Text = "2222222";
            string strSchoolName = Basic.RequestHelper.GetQueryString("schoolname");
            if (strSchoolName != "")
            {
                hidSchoolName.Value = strSchoolName;
                ltlSchoolName.Text = "<a href=\"javascript:del(0,0);\" k=\"0\" v=\"0\">" + strSchoolName + "<span>X</span></a>";
            }
        }
    }
}