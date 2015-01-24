using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace GaoKao.UserControl
{
    public partial class Crumb : System.Web.UI.UserControl
    {
       
        public string NavString { get; set; }   //定义参数 
        protected void Page_Load(object sender, EventArgs e)
        {
            Bind();
        }

        void Bind()
        {
           lit_Nav.Text = NavString;

           DataTable dt = DAL.Notice.NoticeList(" IsAll = 1 Order by Id desc");
           if (dt!=null&&dt.Rows.Count>0)
           {
               ltlNotice.Text = dt.Rows[0]["Content"].ToString();
           }
        }



    }
}