using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace GaoKao.CePing.Mbit
{
    public partial class Fruit : UserBase
    {

        #region

        protected int G1_A = 0;//归组1
        protected int G1_B = 0;//归组1 
        protected int G2_A = 0;//归组2
        protected int G2_B = 0;//归组2

        protected int G3_A = 0;//归组3
        protected int G3_B = 0;//归组3
        protected int G4_A = 0;//归组4
        protected int G4_B = 0;//归组4

        protected int G5_A = 0;//归组5
        protected int G5_B = 0;//归组5
        protected int G6_A = 0;//归组6
        protected int G6_B = 0;//归组6

        protected int G7_A = 0;//经济实力
        protected int G7_B = 0;//经济实力

        #endregion
        
        protected int E = 0, I = 0, S = 0, N = 0, T = 0, F = 0, J = 0, P = 0;//


        //分割类型
        protected string reGeLeiXing = "";
        protected bool isMember = true;
        protected string valList = "";



        protected void Page_Load(object sender, EventArgs e)
        {

            isMember = DAL.Comm.JCJH(user.StudentId);

            JiSuanJigGuo();
        }

        void JiSuanJigGuo()
        {
            DataTable dt = DAL.Join_MbtiResults.Join_MbtiResultsList("StudentId = "+user.StudentId);
            if (dt != null && dt.Rows.Count > 0)
            {
                E = Basic.TypeConverter.StrToInt(dt.Rows[0]["E"].ToString(), 0);
                I = Basic.TypeConverter.StrToInt(dt.Rows[0]["I"].ToString(), 0);
                S = Basic.TypeConverter.StrToInt(dt.Rows[0]["S"].ToString(), 0);
                N = Basic.TypeConverter.StrToInt(dt.Rows[0]["N"].ToString(), 0);
                T = Basic.TypeConverter.StrToInt(dt.Rows[0]["T"].ToString(), 0);
                F = Basic.TypeConverter.StrToInt(dt.Rows[0]["F"].ToString(), 0);
                J = Basic.TypeConverter.StrToInt(dt.Rows[0]["J"].ToString(), 0);
                P = Basic.TypeConverter.StrToInt(dt.Rows[0]["P"].ToString(), 0);

                //创建人格类型
                string[] renge = new string[4];
                if (E > I)
                {
                    renge[0] = "E";
                    valList += E + ",";
                }
                else
                {
                    renge[0] = "I";
                    valList += I + ",";
                }

                if (S > N)
                {
                    renge[1] = "S";
                    valList += S + ",";

                }
                else
                {
                    renge[1] = "N";
                    valList += N + ",";
                }


                if (T > F)
                {
                    renge[2] = "T";
                    valList += T + ",";
                }
                else
                {
                    renge[2] = "F";
                    valList += F + ",";
                }

                if (J > P)
                {
                    renge[3] = "J";
                    valList += J + ",";
                }
                else
                {
                    renge[3] = "P";
                    valList += P + ",";
                }

                //人格类型
                reGeLeiXing = "";
                foreach (string st in renge)
                {
                    reGeLeiXing += st;

                }
            }
            else
            {
                Basic.MsgHelper.AlertUrlMsg("您的还未进行职业性格测试，请先测试", "/CePing/Mbit/Default.aspx");
            }
        }
    }

}

