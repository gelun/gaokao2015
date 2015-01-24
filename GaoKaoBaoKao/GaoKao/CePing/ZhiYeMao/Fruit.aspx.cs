using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GaoKao.CePing.ZhiYeMao
{
    public partial class Fruit :UserBase
    {

        //选项集合
        protected string tsl = "";
        //归组集合
        protected string tgp = "";

        #region
        protected int tf_1 = 0;
        protected int gm_2 = 0;
        protected int au_3 = 0;
        protected int se_4 = 0;
        protected int ec_5 = 0;
        protected int sv_6 = 0;
        protected int ch_7 = 0;
        protected int ls_8 = 0;
        #endregion


        protected string zhuLieXing = "";
        protected string fuLeiXing = "";
        protected int zhuLeiXing值 = 0;
        protected int fuLeiXing值 = 0;

        bool isMember = true;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.Cookies["tesZhiYeMaotCook"] != null)
                {
                    if (Request.Cookies["tesZhiYeMaotCook"]["tsl"] != null)
                    {
                        tsl = Request.Cookies["tesZhiYeMaotCook"]["tsl"];
                    }
                    if (Request.Cookies["tesZhiYeMaotCook"]["tgp"] != null)
                    {
                        tgp = Request.Cookies["tesZhiYeMaotCook"]["tgp"];
                    }
                    Analyze();
                }
                else
                {
                    Response.Write("您还未进行过测评,请先测评 <a href=\"Default.aspx\">点击这里进行测评</a>");
                    Response.End();
                }

                isMember = DAL.Comm.JCJH(user.StudentId);

                panel.Visible = isMember;
               
            }

        }

        //解析答案
        void Analyze()
        {
            string[] tslArray = tsl.Split(',');
            string[] tgpArray = tgp.Split(',');
            
            for (int i = 0; i < 40; i++)
            {
                switch (tgpArray[i])
                {
                    case "1":
                        tf_1 +=int.Parse(tslArray[i]);
                        break;
                    case "2":
                        gm_2 += int.Parse(tslArray[i]);
                        break;
                    case "3":
                        au_3 += int.Parse(tslArray[i]);
                        break;
                    case "4":
                        se_4 += int.Parse(tslArray[i]);
                        break;
                    case "5":
                        ec_5 += int.Parse(tslArray[i]);
                        break;
                    case "6":
                        sv_6 += int.Parse(tslArray[i]);
                        break;
                    case "7":
                        ch_7 += int.Parse(tslArray[i]);
                        break;
                    case "8":
                        ls_8 += int.Parse(tslArray[i]);
                        break;
                    

                }
            }

            //得到最高分
            Dictionary<string, int> dic = new Dictionary<string, int>();

            dic.Add("tf", tf_1);
            dic.Add("gm", gm_2);
            dic.Add("au", au_3);
            dic.Add("se", se_4);
            dic.Add("ec", ec_5);
            dic.Add("sv", sv_6);
            dic.Add("ch", ch_7);
            dic.Add("ls", ls_8);

        

             //排序
            var result = from pair in dic

                         orderby pair.Value  descending  //

                         select pair;



            int m = 0;
           
            foreach(KeyValuePair<string, int> pair in result)
            {
                if (m == 0)
                {

                    zhuLieXing = pair.Key;

                   
                }
                else
                {
                    fuLeiXing = pair.Key;
                    break;
                }
                m++;
            }

            //得分最高的就是keys  得分是 vals；
        }


    }
}