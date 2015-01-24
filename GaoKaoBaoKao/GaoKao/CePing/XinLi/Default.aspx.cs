using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace GaoKao.CePing.XinLi
{
    public partial class Default : UserBase
    {
        protected int page = 1;   //当前页码
        protected int pageSize = 10; //当前页大小
        protected int sumPage = 1;//总共页数
        protected int recordNumber = 90;

        #region   变量计算分数
        int G_1 = 0;
        int G_2 = 0;
        int G_3 = 0;
        int G_4 = 0;
        int G_5 = 0;
        int G_6 = 0;
        int G_7 = 0;
        int G_8 = 0;
        int G_9 = 0;
        int G_0 = 0;

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
                 G_1 = 0;
                 G_2 = 0;
                 G_3 = 0;
                 G_4 = 0;
                 G_5 = 0;
                 G_6 = 0;
                 G_7 = 0;
                 G_8 = 0;
                 G_9 = 0;
                 G_0 = 0;

            }
            else
            {

                if (Request.Cookies["testXinLiCook"] != null)
                {



                    if (Request.Cookies["testXinLiCook"]["G_1"] != null)
                    {
                        G_1 = int.Parse(Request.Cookies["testXinLiCook"]["G_1"]);
                    }

                    if (Request.Cookies["testXinLiCook"]["G_1"] != null)
                    {
                        G_1 = int.Parse(Request.Cookies["testXinLiCook"]["G_1"]);
                    }

                    if (Request.Cookies["testXinLiCook"]["G_1"] != null)
                    {
                        G_1 = int.Parse(Request.Cookies["testXinLiCook"]["G_1"]);
                    }

                    if (Request.Cookies["testXinLiCook"]["G_1"] != null)
                    {
                        G_1 = int.Parse(Request.Cookies["testXinLiCook"]["G_1"]);
                    }

                    if (Request.Cookies["testXinLiCook"]["G_1"] != null)
                    {
                        G_1 = int.Parse(Request.Cookies["testXinLiCook"]["G_1"]);
                    }

                    if (Request.Cookies["testXinLiCook"]["G_1"] != null)
                    {
                        G_1 = int.Parse(Request.Cookies["testXinLiCook"]["G_1"]);
                    }
                    if (Request.Cookies["testXinLiCook"]["G_1"] != null)
                    {
                        G_1 = int.Parse(Request.Cookies["testXinLiCook"]["G_1"]);
                    }

                    if (Request.Cookies["testXinLiCook"]["G_1"] != null)
                    {
                        G_1 = int.Parse(Request.Cookies["testXinLiCook"]["G_1"]);
                    }
                    if (Request.Cookies["testXinLiCook"]["G_1"] != null)
                    {
                        G_1 = int.Parse(Request.Cookies["testXinLiCook"]["G_1"]);
                    }

                    if (Request.Cookies["testXinLiCook"]["G_1"] != null)
                    {
                        G_1 = int.Parse(Request.Cookies["testXinLiCook"]["G_1"]);
                    }
                    if (Request.Cookies["testXinLiCook"]["G_1"] != null)
                    {
                        G_1 = int.Parse(Request.Cookies["testXinLiCook"]["G_1"]);
                    }

                    if (Request.Cookies["testXinLiCook"]["G_1"] != null)
                    {
                        G_1 = int.Parse(Request.Cookies["testXinLiCook"]["G_1"]);
                    }




                }
                else
                {
                    page = 1;
                    G_1 = 0;
                    G_2 = 0;
                    G_3 = 0;
                    G_4 = 0;
                    G_5 = 0;
                    G_6 = 0;
                    G_7 = 0;
                    G_8 = 0;
                    G_9 = 0;
                    G_0 = 0;


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
            DataTable dt = DAL.Join_XinLiTest.Join_XinLiTestPageList("", pageSize, page);

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


                Label lb = (Label)ri.FindControl("testNumber");
                HiddenField hid = (HiddenField)ri.FindControl("hidd");
                RadioButtonList cbl = (RadioButtonList)ri.FindControl("rdb_Check");
                if (cbl.SelectedIndex >= 0)
                {
                    //计算选择的答案的个数
                    switch (cbl.SelectedIndex)
                    {
                        case 0:
                            Calculate(hid.Value, 2, int.Parse(lb.Text));
                            break;
                        case 1:
                            Calculate(hid.Value, 1, int.Parse(lb.Text));
                            break;
                        case 2:
                            Calculate(hid.Value, 0, int.Parse(lb.Text));
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


            HttpCookie myCook = new HttpCookie("testXinLiCook");
            myCook.Values["G_1"] = G_1.ToString();
            myCook.Values["G_2"] = G_2.ToString();
            myCook.Values["G_3"] = G_3.ToString();
            myCook.Values["G_4"] = G_4.ToString();
            myCook.Values["G_5"] = G_5.ToString();
            myCook.Values["G_6"] = G_6.ToString();
            myCook.Values["G_7"] = G_7.ToString();
            myCook.Values["G_8"] = G_8.ToString();
            myCook.Values["G_9"] = G_9.ToString();
            myCook.Values["G_0"] = G_0.ToString();
         


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
        void Calculate(string sty, int point, int testNumber)
        {



            switch (sty)
            {
                case "a":
              
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