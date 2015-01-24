using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace GaoKao.CePing.JiaoLv
{

    /// <summary>
    /// 算法说明:
    /// </summary>
    public partial class Default : UserBase
    {
        protected int page = 1;   //当前页码
        protected int pageSize = 10; //当前页大小
        protected int sumPage = 1;//总共页数
        protected int recordNumber = 33;

        #region   变量计算分数
        int fen = 0;

        #endregion

        bool isMember = true;


        protected void Page_Load(object sender, EventArgs e)
        {
            #region  页面参数初始化

            page = Basic.RequestHelper.GetFormInt("hdpage", 1);
            isMember = DAL.Comm.JCJH(user.StudentId);

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
                fen = 0;

            }
            else
            {

                if (Request.Cookies["testJiaoLvCook"] != null)
                {


                    if (Request.Cookies["testJiaoLvCook"]["fen"] != null)
                    {
                        fen = int.Parse(Request.Cookies["testJiaoLvCook"]["fen"]);
                    }

                }
                else
                {
                    page = 1;
                    fen = 0;
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
            DataTable dt = DAL.Join_JiaoLvTest.Join_JiaoLvTestPageList("", pageSize, page);

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

          
                RadioButtonList cbl = (RadioButtonList)ri.FindControl("rdb_Check");
                if (cbl.SelectedIndex >= 0)
                {
                    //计算选择的答案的个数
                    switch (cbl.SelectedIndex)
                    {
                        case 0:
                            fen += 3;
                            break;
                        case 1:
                            fen += 2;
                            break;
                        case 2:
                            fen += 1;
                            break;
                        case 3:
                        default:
                            break;
                    }
                }

            }


            #endregion

            #region   记录分数到Cookie里


            HttpCookie myCook = new HttpCookie("testJiaoLvCook");
            myCook.Values["fen"] = fen.ToString();



            Response.Cookies.Add(myCook);
            #endregion

            #region   设计下一页数据

            if (page == sumPage)
            {
                Server.Transfer("Ttarget.aspx"); //301跳转

                //查看 结果
         
             
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
        /// <param name="point">分数</param>
        void Calculate(int point)
        {



            switch (point)
            {
                case 1:
                    fen += 3;
                    break;
                case 2:
                    fen += 2;
                    break;
                case 3:
                    fen += 1;
                    break;
                case 4:
                    fen += 0;
                    break;

                default:
                    break;
            }



        }

        #endregion

    }

}