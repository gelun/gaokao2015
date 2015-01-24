using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GaoKao.CePing.Disc
{
    public partial class Fruit :UserBase
    {
        #region

        protected int G1 = 0;//选项1   d
        protected int G2 = 0;//选项2   s
        protected int G3 = 0;//选项3   i
        protected int G4 = 0;//选项4   c

        #endregion


        protected string rg = "";

        bool isMember = true;

        protected void Page_Load(object sender, EventArgs e)
        {
            #region  设置值

            if (Request.Cookies["testDiscCook"] != null)
            {

                isMember = DAL.Comm.JCJH(user.StudentId);

                 

                #region

                G1 = int.Parse(Request.Cookies["testDiscCook"]["G1"]);
                G2 = int.Parse(Request.Cookies["testDiscCook"]["G2"]);
                G3 = int.Parse(Request.Cookies["testDiscCook"]["G3"]);
                G4 = int.Parse(Request.Cookies["testDiscCook"]["G4"]);

                #endregion

                JiSuanJigGuo();

                Panel1.Visible =isMember;

            }




            #endregion
        }


        void JiSuanJigGuo()
        {
            string[,] st = new string[4, 4];


            if (G1 > 10)
            {
                rg += "d";
            }
            if (G2 > 10)
            {
                rg += "s";
            }
            if (G3 > 10)
            {
                rg += "i";
            }
            if (G4 > 10)
            {
                rg += "c";
            }


            if (G1 > 13)     //d
            {
                rg += "d";
                lab_01.Text += "高支配D&nbsp;&nbsp;";
            }
            else if (G1 > 8 && G1 <= 12)
            {
                lab_01.Text += "中支配D&nbsp;&nbsp;";
            }
            else
            {
                lab_01.Text += "低支配D&nbsp;&nbsp;";
            }



            if (G2 > 10)   //s
            {
                rg += "s";
                lab_01.Text += "高稳定型S&nbsp;&nbsp;";
            }
            else if (G1 > 8 && G1 <= 12)
            {
                lab_01.Text += "中稳定型S&nbsp;&nbsp;";
            }
            else
            {
                lab_01.Text += "低稳定型S&nbsp;&nbsp;";
            }




            if (G3 > 10)  //i
            {
                lab_01.Text += "高服从者I&nbsp;&nbsp;";
            }
            else if (G1 > 8 && G1 <= 12)
            {
                lab_01.Text += "中服从者I&nbsp;&nbsp;";
            }
            else
            {
                lab_01.Text += "低服从者I&nbsp;&nbsp;";
            }




            if (G4 > 10)  //c
            {
                lab_01.Text += "高支配C&nbsp;&nbsp;";
            }
            else if (G1 > 8 && G1 <= 12)
            {
                lab_01.Text += "中支配C&nbsp;&nbsp;";
            }
            else
            {
                lab_01.Text += "低支配C&nbsp;&nbsp;";
            }
        }

    }

}

