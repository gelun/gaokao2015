using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GaoKao.CePing.StudyAbroad
{
    public partial class Fruit : System.Web.UI.Page
    {

        int trait_1 = 0;//英语情况
        int trait_2 = 0;//成绩
        int trait_3 = 0;//经济实力


        protected void Page_Load(object sender, EventArgs e)
        {
            //出国留学测评结果页面

            if (!IsPostBack)
            {

                if (Request.Cookies["testCook"] != null)
                {
                    trait_1 = int.Parse(Request.Cookies["testCook"]["trait_1"]);
                    trait_2 = int.Parse(Request.Cookies["testCook"]["trait_2"]);
                    trait_3 = int.Parse(Request.Cookies["testCook"]["trait_3"]);
                }

                FruitShow();
            }
        }

        void FruitShow()
        {
            //计算结果


            if (trait_3 > 0 && trait_2 > 0)
            {
                //           经济好、成绩好：
                //可依次选择国家：美国、英国、加拿大、澳大利亚、德国、法国、日本
                //建议学习专业：商科、工科
            }
            else if (trait_1 == 0 && trait_2 == 0 && trait_3 > 0)
            {
                //经济好、成绩一般、英语一般：
                //可依次选择国家：德国、法国、日本、意大利
            }
            else if (trait_1 > 0 && trait_2 == 0 && trait_3 > 0)
            {
                //经济好、成绩一般、英语好：
                //可依次选择国家：美国、英国、加拿大、澳大利亚
            }
            else if ( trait_2 > 0 && trait_3 == 0)
            {
                //经济一般、成绩好：
                //可依次选择国家：德国、法国、意大利、韩国
            }
            else if (trait_2 == 0 && trait_3 == 0)
            {

                //经济一般、成绩一般：
                //可依次选择国家：韩国、意大利、日本、法国
            }
            
        }
    }
}