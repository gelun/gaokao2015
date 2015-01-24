using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GaoKao.CePing.JiaoLv
{
    public partial class Fruit : System.Web.UI.Page
    {
        protected int fen = 0;
        protected int lvel = 1;//默认无级别

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["testJiaoLvCook"] != null)
            {
                if (Request.Cookies["testJiaoLvCook"]["fen"] != null)
                {
                    fen = int.Parse(Request.Cookies["testJiaoLvCook"]["fen"]);

                    if (fen <= 2)
                    {
                        lvel = 1;
                        //Response.Write("镇定");

                    }
                    else if (fen > 25 && fen <= 49)
                    {
                        lvel = 2;
                        //Response.Write("轻度焦虑");
                    }
                    else if (fen > 50 && fen <= 74)
                    {
                        lvel = 3;
                        //Response.Write("中度焦虑");
                    }
                    else if (fen > 75 && fen < 99)
                    {
                        lvel = 4;
                        //Response.Write("重度焦虑");
                    }

                }

            }
        }
    }
}