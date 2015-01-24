using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GaoKao.CePing.JiaoLv
{
    public partial class Ttarget :UserBase
    {

        bool isMember = false;
        protected void Page_Load(object sender, EventArgs e)
        {

            isMember = DAL.Comm.JCJH(user.StudentId);

            ClientScript.RegisterClientScriptBlock(Page.GetType(), "jst", "<script type=\"text/javascript\">function openUrl(url){ window.open(url, \"name1\", \"fullscreen,location:yes,menubar:yes,resizable:yes,scrollbars:yes,status:yes,toolbar:yes\");}</script>");


            if (isMember)
            {


                ltr_Over.Visible = true;

                ltr_Over.Text = "<div class=\"result\"><p>已为您生成专属报告</p><p><a href=\"FruitSenior.aspx\"  target=\"_blank\"><img src=\"../images/on.jpg\" /></a></p></div>";



            }
            else
            {
                ltr_Over.Visible = true;
                ltr_Over.Text = "<div class=\"result\"><p>已为您生成专属报告</p><p><a href=\"Fruit.aspx\"  target=\"_blank\"><img src=\"../images/on.jpg\" /></a></p></div>";
            }
        }

    }
}