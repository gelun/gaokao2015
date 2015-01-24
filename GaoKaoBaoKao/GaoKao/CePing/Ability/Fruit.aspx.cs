using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace GaoKao.CePing.GLGKZYXZ.Ability
{
    public partial class Fruit :UserBase
    {
        protected string reTy = "";


        bool isMemeber = false;
        protected void Page_Load(object sender, EventArgs e)
        {

            isMemeber = DAL.Comm.JCJH(user.StudentId);

            panel1.Visible = isMemeber;

            if (!IsPostBack)
            {
                Ability();
            }
        }


        #region  职业能力测试

        void Ability()
        {
            DataTable dt = DAL.Join_AbilityResults.Join_AbilityResultsList("UserId=" + this.user.StudentId);


            if (dt != null && dt.Rows.Count > 0)
            {
                ltr_Language.Text = dt.Rows[0]["Language"].ToString();
                ltr_Tissue.Text = dt.Rows[0]["Tissue"].ToString();
                ltr_Among.Text = dt.Rows[0]["Among"].ToString();
                ltr_Mathematics.Text = dt.Rows[0]["Mathematics"].ToString();
                ltr_Motion.Text = dt.Rows[0]["Motion"].ToString();
                ltr_Writing.Text = dt.Rows[0]["Writing"].ToString();
                ltr_Watch.Text = dt.Rows[0]["Watch"].ToString();
                ltr_Space.Text = dt.Rows[0]["Space"].ToString();
                ltr_Art.Text = dt.Rows[0]["Art"].ToString();

                Dictionary<string, float> dic = new Dictionary<string, float>();

                dic.Add("G", float.Parse(dt.Rows[0]["Language"].ToString()));    //一半能力 G
                dic.Add("M", float.Parse(dt.Rows[0]["Tissue"].ToString()));     //手腕灵巧能力 M
                dic.Add("F", float.Parse(dt.Rows[0]["Among"].ToString()));    //手指灵巧度    F
                dic.Add("V", float.Parse(dt.Rows[0]["Mathematics"].ToString()));  //语言能力  V
                dic.Add("Q", float.Parse(dt.Rows[0]["Motion"].ToString())); //文秘能力  Q
                dic.Add("P", float.Parse(dt.Rows[0]["Writing"].ToString()));  //形态知觉能力 P
                dic.Add("S", float.Parse(dt.Rows[0]["Watch"].ToString())); //空间判断能力   S
                dic.Add("N", float.Parse(dt.Rows[0]["Space"].ToString()));  //算数能力 N
                dic.Add("K", float.Parse(dt.Rows[0]["Art"].ToString()));  //眼收运动能力  K
            

                var result = from pair in dic

                             orderby pair.Value descending

                             select pair;

                //倒序，根据 vlaue


                string[] keyArr = new string[result.Count()];
                string[] valArr = new string[result.Count()];


               
                int i = 0;
                foreach (KeyValuePair<string, float> pair in result)
                {
                    keyArr[i] = pair.Key;
                    valArr[i] = pair.Value.ToString();

                    i++;
                }

                //顺序是倒序排列

                //选出前几项

                int index = 0;  //分水岭索引
                for (int m = 0; m < valArr.Length; m++)
                {
                    if (valArr[m] == "2")
                    {
                        index = m;
                    }
                }


                string anlayes = "";

                if ((index + 1) > 6)
                {
                    //前六个都比较强，选出前6个

                    for (int n = 0; n < 6; n++)
                    {
                        anlayes += keyArr[n];
                    }
                }
                else if (index == 0)
                {
                    //没有强的数据，选出前4个

                    for (int n = 0; n < 4; n++)
                    {
                        anlayes += keyArr[n];
                    }
                }
                else
                {
                    //选出前4个


                    for (int n = 0; n < 6; n++)
                    {
                        anlayes += keyArr[n];
                    }
                }

                string[] results = new string[15];
                results[0] = "G-V-N";
                results[1] = "G-V-Q";
                results[2] = "G-N-S";
                results[3] = "G-N-Q";
                results[4] = "G-Q-K";
                results[5] = "G-Q-M";
                results[6] = "G-Q";
                results[7] = "G-S-P";
                results[8] = "N-S-M";
                results[9] = "Q-P-F";
                results[10] = "Q-P";
                results[11] = "S-P-F";
                results[12] = "S-P-M";
                results[13] = "P-M";
                results[14] = "K-F-M";


                bool b = false;

                List<string> al = new List<string>();
                for (int m = 0; m < 15; m++)
                {
                    string[] lc = results[m].Split('-');
                    foreach (string st in lc)
                    {
                        //检索是否包含，


                        //检索是否含有当前字母
                        if (anlayes.IndexOf(st) < 0)
                        {
                            b = false;
                            break;
                        }
                        else
                        {
                            b = true;
                        }
                    }

                    if (b)
                    {
                        //含有该种类型
                        reTy += (results[m]) + "|";
                        b = false;
                    }

                }
             

            }
            else
            {
                Basic.MsgHelper.AlertUrlMsg("您的还未进行职业能力倾向测试，请先测试", "/Holland/AbilityTest.aspx");
                return;
            }

        }

        #endregion
    }
}
