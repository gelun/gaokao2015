using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GaoKao.CePing.QiZhi
{
    public partial class Fruit : System.Web.UI.Page
    {


        #region   变量计算分数
        int G_a = 0;
        int G_b = 0;
        int G_c = 0;
        int G_d = 0;
        int G_X = 0;
      

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Bind();
              
            }
        }


        void Bind()
        {

            #region  计分  

            if (Request.Cookies["testQiZhiCook"] != null)
            {



                if (Request.Cookies["testQiZhiCook"]["G_a"] != null)
                {
                    G_a = int.Parse(Request.Cookies["testQiZhiCook"]["G_a"]);
                }

                if (Request.Cookies["testQiZhiCook"]["G_b"] != null)
                {
                    G_b = int.Parse(Request.Cookies["testQiZhiCook"]["G_b"]);
                }

                if (Request.Cookies["testQiZhiCook"]["G_c"] != null)
                {
                    G_c = int.Parse(Request.Cookies["testQiZhiCook"]["G_c"]);
                }

                if (Request.Cookies["testQiZhiCook"]["G_d"] != null)
                {
                    G_d = int.Parse(Request.Cookies["testQiZhiCook"]["G_d"]);
                }


                if (Request.Cookies["testQiZhiCook"]["G_X"] != null)
                {
                    G_X = int.Parse(Request.Cookies["testQiZhiCook"]["G_X"]);
                }


          
            }

            #endregion

            #region  输出

           Dictionary<string, int> newsInfo = new Dictionary<string, int>();

           newsInfo.Add("G_a", G_a);
           newsInfo.Add("G_b", G_b);
           newsInfo.Add("G_c", G_c);
           newsInfo.Add("G_d", G_d);

      
            string[] leixing = {"胆汁质","多血质","粘液质","抑郁质" };

            string[] xingge = { "非常内向型", "比较内向型", "介于内外向之间", "比较外向", "非常外向" };
            //性格分数 G_X

         
            //对数组排序，倒叙
            //DAL.Comm.BubbleSortDow(fen);

              //对键值对排序
            var result = from pair in newsInfo orderby pair.Value select pair;

            List<KeyValuePair<string, int>> lstorder = result.OrderByDescending(c => c.Value).ToList();

            //取出第一和第二个数据
            int frist = lstorder[0].Value;
            int second = lstorder[1].Value;
            int  three=   lstorder[2].Value;
            int five= lstorder[3].Value;

            if (frist - second > 4)  //一种气质高出其他三种
            {


                if (frist > 20)
                {
                    //典型气质
                }
                else if (frist < 20 && frist > 10)
                {
                    //一般类型
                }
                else
                {
                    //选定为当前类型//
                }
            }
            else if (Math.Abs(frist - second) < 3 && (second - three) > 4)  //两种气质相近，并且明显高出其他三种4分
            {


            }
            else if (Math.Abs(frist - second) < 3 && Math.Abs(frist - three) < 3 && Math.Abs(frist - five) < 3 && Math.Abs(second - three) < 3 && Math.Abs(second - five) < 3 && Math.Abs(three - five) < 3 )
            {
                //如果四种气质接近

            }
            else if (frist < 10 && second < 10 && three < 10 && five < 10)
            {
                //各项都在10分一下

            }
           

            #endregion
        }



      


        /// <summary>
        /// 得到典型气质 基索引
        /// </summary>
        /// <param name="fens"></param>
        int DianXing(int[] fens)
        {
            //根据分数数组
            DAL.Comm.BubbleSortDow(fens);

            if (fens[0] > 20)
            {
                if (fens[1] > 20)
                {
                    if (fens[2] > 20)
                    {
                        if (fens[3] > 20)
                        {
                            //全部为典型气质
                            return 3;
                        }
                        else
                        {
                            //索引3以上为典型气质
                            return 2;
                        }
                    }
                    else
                    {
                         //索引2处以上为典型气质
                        return 1;
                    }
                }
                else
                {
                    //索引1是典型气质
                    return 0;
                }
            }
            else
            {
             
                //没有典型气质
                return -1;
            }
        }
    }
}