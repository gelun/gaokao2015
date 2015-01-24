using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GaoKao.CePing.Disc.innerpage
{
    public partial class d : System.Web.UI.Page
    {

        bool isMember = true;

        protected void Page_Load(object sender, EventArgs e)
        {
            panel.Visible = isMember;
        }
    }
}