using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GaoKao.CePing.ZhongKe
{
    public partial class Ttarget :System.Web.UI.Page
    {

        protected string typ = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            typ = Basic.RequestHelper.GetQueryString("ty");

            if (!IsPostBack)
            {

                ClientScript.RegisterClientScriptBlock(Page.GetType(), "jst", "<script type=\"text/javascript\">function openUrl(url){ window.open(url, \"name1\", \"fullscreen,location:yes,menubar:yes,resizable:yes,scrollbars:yes,status:yes,toolbar:yes\");}</script>");

                    ltr_Over.Visible = true;

                    if (typ == "xxl")
                    {

                        ltr_Over.Text = "<div class=\"result\"><p>已为您生成专属报告</p><p><a href=\"Fruit.aspx\"  target=\"_blank\"><img src=\"../../images/on.jpg\" /></a></p></div>";

                    }
                    else
                    {
                        ltr_Over.Text = "<div class=\"result\"><p>已为您生成专属报告</p><p><a href=\"shengcunliFruit.aspx\"  target=\"_blank\"><img src=\"../../images/on.jpg\" /></a></p></div>";
                    }                                                                                                                                      

              
            
             
            }
        }

    }
}