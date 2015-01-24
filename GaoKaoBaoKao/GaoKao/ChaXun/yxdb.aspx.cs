using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GaoKao.ChaXun
{
    public partial class yxdb : Base
    {
        public int gl_Lx = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            gl_Lx = Basic.RequestHelper.GetQueryInt("lx", 0);
        }
    }
}