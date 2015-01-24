using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace GaoKao.CePing.WenLi
{
    public partial class FruitSenior :UserBase
    {
        protected int WenKe = 0;
        protected int LiKe =0;

        protected string ly = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!DAL.Comm.JCJH(user.StudentId))
            {
                Response.Redirect("Fruit.aspx");
            }

            DataTable dt = DAL.Join_TestWLResults.Join_TestWLResultsList(" UserId=" + this.user.StudentId);

            if (dt != null && dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0];


                WenKe = int.Parse(dr["WK"].ToString()) + 100;
                LiKe = int.Parse(dr["LK"].ToString()) + 100;


            }
            else
            {
                Basic.MsgHelper.AlertUrlMsg("您还未进行文理分科测评，请先进行测评", "Test.aspx");
            }


            DataTable dts = DAL.Join_HollandResults.Join_HollandResultsList("[UserId]=" + this.user.StudentId);


            Dictionary<string, int> dic = new Dictionary<string, int>();
       

            if (dts != null && dts.Rows.Count > 0)
            {
                //
                lb_Art.Text = dts.Rows[0]["Art"].ToString();
                lb_Business.Text = dts.Rows[0]["Business"].ToString();
                lb_Reality.Text = dts.Rows[0]["Reality"].ToString();
                lb_Society.Text = dts.Rows[0]["Society"].ToString();
                lb_Study.Text = dts.Rows[0]["Study"].ToString();
                lb_Tradition.Text = dts.Rows[0]["Tradition"].ToString();

                dic.Add("A", int.Parse(dts.Rows[0]["Art"].ToString()));
                dic.Add("E", int.Parse(dts.Rows[0]["Business"].ToString()));
                dic.Add("R", int.Parse(dts.Rows[0]["Reality"].ToString()));
                dic.Add("S", int.Parse(dts.Rows[0]["Society"].ToString()));
                dic.Add("I", int.Parse(dts.Rows[0]["Study"].ToString()));
                dic.Add("C", int.Parse(dts.Rows[0]["Tradition"].ToString()));



                var result = from pair in dic

                             orderby pair.Value   //descending  

                             select pair;


                int i = 0;
                foreach (var n in result)
                {
                    if (i > 1)
                    {
                        break;
                    }
                    else
                    {
                        ly += n.Key;
                    }
                }

            }
        }
    }
}