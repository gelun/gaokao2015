using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GaoKao.UserControl
{
    public partial class SchoolLeft : System.Web.UI.UserControl
    {
        public int intSchoolId { get; set; }
        public int Index { get; set; }//右侧导航中的索引
        protected void Page_Load(object sender, EventArgs e)
        {
            Bind();
        }

        void Bind()
        {
            Entity.School info = DAL.School.SchoolEntityGet(intSchoolId);
            if (info != null)
            {
                SchoolLogo.Src = "../logo/" + (info.Logo == "" ? "default.png" : info.Logo);
            }
        }
    }
}