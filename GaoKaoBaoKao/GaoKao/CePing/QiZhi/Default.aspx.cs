using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace GaoKao.CePing.QiZhi
{
    public partial class Default : UserBase
    {
        protected int page = 1;   //当前页码
        protected int pageSize = 3; //当前页大小
        protected int sumPage = 1;//总共页数
        protected int recordNumber = 33;

        #region   变量计算分数
        int G_a = 0;
        int G_b = 0;
        int G_c = 0;
        int G_d = 0;

         float G_X = 0f;
       
        #endregion




        protected void Page_Load(object sender, EventArgs e)
        {
            #region  页面参数初始化

            page = Basic.RequestHelper.GetFormInt("hdpage", 1);


            if (recordNumber % pageSize > 0)
            {
                sumPage = recordNumber / pageSize + 1;
            }
            else
            {
                sumPage = recordNumber / pageSize;
            }

            #region  ---------------

            if (page == 1)
            {
                 G_a = 0;
                 G_b = 0;
                 G_c = 0;
                 G_d = 0;
                 G_X = 0;
               
            }
            else
            {

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
                else
                {
                    page = 1;
                    G_a = 0;
                    G_b = 0;
                    G_c = 0;
                    G_d = 0;
                    G_X = 0;
                  
                }
            }


            #endregion

            #endregion

            if (!IsPostBack)
            {
                Bind();
            }

        }


        #region 绑定数据

        void Bind()
        {
            DataTable dt = DAL.Join_QiZhiTest.Join_QiZhiTestPageList("", pageSize, page);

            rpt_List1.DataSource = dt;
            rpt_List1.DataBind();

        }






        #endregion



        #region   记录数据

        protected void subbut_Click(object sender, ImageClickEventArgs e)
        {
            #region 统计分数


            foreach (RepeaterItem ri in rpt_List1.Items)
            {


                Label  lb=(Label)ri.FindControl("testNumber");
                HiddenField  hid=(HiddenField)ri.FindControl("hidd");
                RadioButtonList cbl = (RadioButtonList)ri.FindControl("rdb_Check");
                if (cbl.SelectedIndex >= 0)
                {
                    //计算选择的答案的个数
                    switch (cbl.SelectedIndex)
                    {
                        case 0:
                            Calculate(hid.Value, 2,int.Parse(lb.Text));
                            break;
                        case 1:
                            Calculate(hid.Value, 1,int.Parse(lb.Text));
                            break;
                        case 2:
                            Calculate(hid.Value, 0,int.Parse(lb.Text));
                            break;
                        case 3:
                            Calculate(hid.Value, -1, int.Parse(lb.Text));
                            break;
                        case 4:
                            Calculate(hid.Value, -2, int.Parse(lb.Text));
                            break;
                        default:
                            break;
                    }
                }

            }


            #endregion

            #region   记录分数到Cookie里


            HttpCookie myCook = new HttpCookie("testQiZhiCook");
            myCook.Values["G_a"] = G_a.ToString();
            myCook.Values["G_b"] = G_b.ToString();
            myCook.Values["G_c"] = G_c.ToString();
            myCook.Values["G_d"] = G_d.ToString();
            myCook.Values["G_X"] = G_X.ToString();


            Response.Cookies.Add(myCook);
            #endregion

            #region   设计下一页数据

            if (page == sumPage)
            {

                Server.Transfer("Ttarget.aspx"); //301跳转
            }
            else
            {
                page++;
                hdPage.Value = page.ToString();
            }

            #endregion

            Bind();
        }

        #endregion


        #region  统计分数

        /// <summary>
        /// 计算分数
        /// </summary>
        /// <param name="point">类型、分数</param>
        void Calculate(string sty ,int point ,int  testNumber)
        {



            switch (sty)
            {
                case "a":
                    G_a += point;
                    break;
                case "b":
                    G_b += point;
                    break;
                case "c":
                    G_c += point;
                    break;
                case "d":
                    G_d += point;
                    break;

                default:
                    break;
            }

            if (testNumber % 2 == 1)
            {
                //奇数
                if (point > 0)
                {
                    G_X += 1;
                }
               
            }
            else
            {
                //偶数
                if (point < 0)
                {
                    G_X += 0.5f;
                }
            }



        }

        #endregion

    }

}