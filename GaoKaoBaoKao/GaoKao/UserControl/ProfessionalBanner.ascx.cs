using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GaoKao.UserControl
{
    public partial class ProfessionalBanner : System.Web.UI.UserControl
    {
        public string BannerWord { get; set; }   //定义参数 
        protected void Page_Load(object sender, EventArgs e)
        {
            lit_BannerWord.Text = BannerWord;
        }
    }
}