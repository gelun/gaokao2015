using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace GaoKao.CePing._16PF
{
    public partial class FruitSenior : UserBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!DAL.Comm.JCJH(user.StudentId))
            {
               Response.Redirect("Fruit.aspx");
            }

            if (!IsPostBack)
            {
                PfBind();
            }
        }


        #region   性格测评

        void PfBind()
        {
            //获取测评结果
            DataTable dt = DAL.Join_16PfResults.Join_16PfResultsList("[UserId]="+ this.user.StudentId);// + this.user.StudentId);
            if (dt != null && dt.Rows.Count > 0)
            {
                //DataTable newDt = new DataTable();

                lab_a.Text = dt.Rows[0]["A_type"].ToString();
                lab_b.Text = dt.Rows[0]["B_type"].ToString(); ;
                lab_c.Text = dt.Rows[0]["C_type"].ToString(); ;
                lab_e.Text = dt.Rows[0]["E_type"].ToString(); ;
                lab_f.Text = dt.Rows[0]["F_type"].ToString(); ;
                lab_g.Text = dt.Rows[0]["G_type"].ToString(); ;
                lab_h.Text = dt.Rows[0]["H_type"].ToString(); ;
                lab_i.Text = dt.Rows[0]["I_type"].ToString(); ;
                lab_l.Text = dt.Rows[0]["L_type"].ToString(); ;
                lab_m.Text = dt.Rows[0]["M_type"].ToString(); ;
                lab_n.Text = dt.Rows[0]["N_type"].ToString(); ;
                lab_o.Text = dt.Rows[0]["O_type"].ToString(); ;
                lab_q1.Text = dt.Rows[0]["Q1_type"].ToString(); ;
                lab_q2.Text = dt.Rows[0]["Q2_type"].ToString(); ;
                lab_q3.Text = dt.Rows[0]["Q3_type"].ToString(); ;
                lab_q4.Text = dt.Rows[0]["Q4_type"].ToString(); ;

             
            
                int  a=int.Parse(dt.Rows[0]["A_type"].ToString());
                  int  b=int.Parse(dt.Rows[0]["B_type"].ToString());
                  int  c=int.Parse(dt.Rows[0]["C_type"].ToString());
                  int  e=int.Parse(dt.Rows[0]["E_type"].ToString());
                  int  f=int.Parse(dt.Rows[0]["F_type"].ToString());
                  int  g=int.Parse(dt.Rows[0]["G_type"].ToString());
                  int  h=int.Parse(dt.Rows[0]["H_type"].ToString());
                  int  i=int.Parse(dt.Rows[0]["I_type"].ToString());
                  int  l=int.Parse(dt.Rows[0]["L_type"].ToString());
                  int  m=int.Parse(dt.Rows[0]["M_type"].ToString());
                  int  n=int.Parse(dt.Rows[0]["N_type"].ToString());
                  int  o=int.Parse(dt.Rows[0]["O_type"].ToString());
                  int  q1=int.Parse(dt.Rows[0]["Q1_type"].ToString());
                  int  q2=int.Parse(dt.Rows[0]["Q2_type"].ToString());
                  int  q3=int.Parse(dt.Rows[0]["Q3_type"].ToString());
                  int  q4=int.Parse(dt.Rows[0]["Q4_type"].ToString());



                  lab_CYX1.Text = ((38+2*l+3*o+4*q4-2*c-2*h-2*q3)/10).ToString();
                  lab_CYX2.Text = ((2*a+3*e+4*f+5*h-2*q2-11)/10).ToString();
                  lab_CYX3.Text = ((77+2*c+2*e+2*f+2*n-4*a-6*i-2*m)/10).ToString();
                  lab_CYX4.Text = ((4*e+3*m+4*q1+4*q2-3*a-2*g)/10).ToString();

                //Y1=C+F+（11-O）+（11-Q4）
                lab_Xinli.Text = int.Parse(dt.Rows[0]["C_type"].ToString()) + int.Parse(dt.Rows[0]["F_type"].ToString()) + (11 - int.Parse(dt.Rows[0]["O_type"].ToString())) + (11 - int.Parse(dt.Rows[0]["Q4_type"].ToString())) + "";
                lab_ZhuanYe.Text = 2 * q3 + 2 * g + 2 * c + e + n + q2 + q1 + "";
                lab_ChuangZao.Text=((11-a)*2+2*b+e+(11-f)*2+h*2+2*i+m+(11-n)+q1+2*q2).ToString();
                lab_XinHuanJing.Text = b + g + q3 + (11 - f) + "";
            
            }
            else
            {
                Basic.MsgHelper.AlertUrlMsg("您的还未进行性格测试不能查看报告，请先测试", "/16PF/Default.aspx");
                return;
            }

        }
        #endregion
    }

}