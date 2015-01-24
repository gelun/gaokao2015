using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace GaoKao.CePing.GLGKZYXZ.Profession
{
    public partial class Fruit :UserBase
    {
        protected bool isMember = true;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Profession();
                isMember = DAL.Comm.JCJH(user.StudentId);
                gaoji.Visible = isMember;
            }

        }

        #region 职业价值观测试

        void Profession()
        {
            DataTable dt = DAL.Join_ProfessionResults.Join_ProfessionResultsList("[UserId]="+this.user.StudentId);


            if (dt != null && dt.Rows.Count > 0)
            {
                Dictionary<string, float> dic = new Dictionary<string, float>();


                ltr_Group1.Text = dt.Rows[0]["Group1"].ToString();
                ltr_Group2.Text = dt.Rows[0]["Group2"].ToString();
                ltr_Group3.Text = dt.Rows[0]["Group3"].ToString();
                ltr_Group4.Text = dt.Rows[0]["Group4"].ToString();
                ltr_Group5.Text = dt.Rows[0]["Group5"].ToString();
                ltr_Group6.Text = dt.Rows[0]["Group6"].ToString();
                ltr_Group7.Text = dt.Rows[0]["Group7"].ToString();
                ltr_Group8.Text = dt.Rows[0]["Group8"].ToString();
                ltr_Group9.Text = dt.Rows[0]["Group9"].ToString();
                ltr_Group10.Text = dt.Rows[0]["Group10"].ToString();
                ltr_Group11.Text = dt.Rows[0]["Group11"].ToString();
                ltr_Group12.Text = dt.Rows[0]["Group12"].ToString();
                ltr_Group13.Text = dt.Rows[0]["Group13"].ToString();

                dic.Add("Group1", float.Parse(dt.Rows[0]["Group1"].ToString()));
                dic.Add("Group2", float.Parse(dt.Rows[0]["Group2"].ToString()));
                dic.Add("Group3", float.Parse(dt.Rows[0]["Group3"].ToString()));
                dic.Add("Group4", float.Parse(dt.Rows[0]["Group4"].ToString()));
                dic.Add("Group5", float.Parse(dt.Rows[0]["Group5"].ToString()));
                dic.Add("Group6", float.Parse(dt.Rows[0]["Group6"].ToString()));
                dic.Add("Group7", float.Parse(dt.Rows[0]["Group7"].ToString()));
                dic.Add("Group8", float.Parse(dt.Rows[0]["Group8"].ToString()));
                dic.Add("Group9", float.Parse(dt.Rows[0]["Group9"].ToString()));
                dic.Add("Group10", float.Parse(dt.Rows[0]["Group10"].ToString()));
                dic.Add("Group11", float.Parse(dt.Rows[0]["Group11"].ToString()));
                dic.Add("Group12", float.Parse(dt.Rows[0]["Group12"].ToString()));
                dic.Add("Group13", float.Parse(dt.Rows[0]["Group13"].ToString()));
         


                var result = from pair in dic

                             orderby pair.Value   descending  

                             select pair;

                //倒序，根据 vlaue


                string[] keyArr = new string[result.Count()];
                string[] valArr = new string[result.Count()];

                //灌装数组
                int i = 0;
                foreach (KeyValuePair<string, float> pair in result)
                {
                    keyArr[i] = pair.Key;
                    valArr[i] = pair.Value.ToString();
                    i++;
                }

                //取出前三个，最高，取出后三个，最低
                lite.Text = "<span>" + keyArr [0]+ "</span>";
                lite.Text += "<span>" + keyArr[1] + "</span>";
                lite.Text += "<span>" + keyArr[2] + "</span>";

                litl.Text = "<span>" + keyArr[10] + "</span>";
                litl.Text = "<span>" + keyArr[11] + "</span>";
                litl.Text = "<span>" + keyArr[12] + "</span>";

            }
            else
            {
                Basic.MsgHelper.AlertUrlMsg("您的还未进行职业价值观测试，请先测试", "/CePing/Holland/Default.aspx");
                return;
            }
        }
        #endregion

    }
}