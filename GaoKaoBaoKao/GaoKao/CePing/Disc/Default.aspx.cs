using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace GaoKao.CePing.Disc
{
    /// <summary>
    /// 算法说明：
    /// 统计 根据用户的选择得出选择的是  d  s  i  c  项，
    /// 然后为对应的项 分数增加1
    /// 然后统计出分数
    /// </summary>


    public partial class Default : UserBase
    {   //页码
        protected int page = 1;

        //总页码

        protected int countPage = 0;

        //页大小
        protected int pagesize = 10;

        protected int count = 40;

        #region
        int G1 = 0;//选项1   d
        int G2 = 0;//选项2   s
        int G3 = 0;//选项3   i
        int G4 = 0;//选项4   c



        DataTable anDt = null;
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {

            anDt = DAL.Join_DISCTest.Join_DISCTestList("");


            if (count % pagesize > 0)
            {
                countPage = count / pagesize + 1;
            }
            else
            {
                countPage = count / pagesize;
            }


            if (Basic.RequestHelper.GetFormString("hdPage") != "")
            {
                page = int.Parse(Basic.RequestHelper.GetFormString("hdPage"));
            }
            else
            {
                page = 1;
            }

            if (page == 1)
            {
                //删除相关cookie
                if (Request.Cookies["testDiscCook"] != null)
                {
                    HttpCookie myCook = new HttpCookie("testDiscCook");
                    Response.Cookies.Add(myCook);
                }

            }
            else
            {
                #region  设置值

                if (Request.Cookies["testDiscCook"] != null)
                {

                    G1 = int.Parse(Request.Cookies["testDiscCook"]["G1"]);
                    G2 = int.Parse(Request.Cookies["testDiscCook"]["G2"]);
                    G3 = int.Parse(Request.Cookies["testDiscCook"]["G3"]);
                    G4 = int.Parse(Request.Cookies["testDiscCook"]["G4"]);

                }

                #endregion

            }



            if (!IsPostBack)
            {
                //绑定数据
                BindTest();
            }
        }





        #region   绑定数据

        void BindTest()
        {

            //分页获取数据
            DataTable dt = DAL.Join_DISCTest.Join_DISCGoupTestList("TestType>=" + (pagesize * (page - 1) + 1) + " and  TestType<=" + pagesize * page + " ");
            rpt_List1.DataSource = dt;
            rpt_List1.DataBind();

        }

        #endregion




        #region    保存数据到cookies中

        protected void next_Click(object sender, ImageClickEventArgs e)
        {


            #region 保存数据到cook中


            //列表1
            foreach (RepeaterItem ri in rpt_List1.Items)
            {

                //题目编号
                HiddenField hid = (HiddenField)ri.FindControl("hdType");//类型
                RadioButtonList rbl = (RadioButtonList)ri.FindControl("rdb_Check");


                foreach (ListItem li in rbl.Items)
                {
                    if (li.Selected)
                    {
                        SetTrait(li.Value.ToLower());
                    }
                }

                                         

            }


            HttpCookie myCook = new HttpCookie("testDiscCook");


            myCook.Values["G1"] = G1.ToString();
            myCook.Values["G2"] = G2.ToString();
            myCook.Values["G3"] = G3.ToString();
            myCook.Values["G4"] = G4.ToString();

       


            Response.Cookies.Add(myCook);
            #endregion

            if (page < countPage)
            {
                page++;

                hdPage.Value = page.ToString();
                //重新绑定
                BindTest();
            }
            else
            {

                Server.Transfer("Ttarget.aspx"); //301跳转
            }

        }
        #endregion


        #region  测评



        /// <summary>
        //根据选项和类型
        /// </summary>
        /// <param name="option">选项</param>
        /// <param name="type">归组</param>
        void SetTrait(string optione)
        {

            if (optione.Trim() == "d")
            {
                G1 += 1;
                return;
            }

            if (optione.Trim() == "s")
            {
                G2 += 1;
                return;
            }



            if (optione.Trim() == "i")
            {
                G3 += 1;
                return;
            }



            if (optione.Trim() == "c")
            {
                G4 += 1;
                return;
            }




        }

        #endregion




        protected void rpt_List1_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            //绑定题目时，绑定答案
            if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
            {
                //绑定答案选项

                HiddenField hdType = (HiddenField)e.Item.FindControl("hdType");

                RadioButtonList rpt = (RadioButtonList)e.Item.FindControl("rdb_Check");


                if (anDt != null)
                {



                    DataRow[] drs = anDt.Select("TestType=" + hdType.Value);


                    foreach (DataRow dr in drs)
                    {
                        ListItem li = new ListItem();
                        li.Value = dr[3].ToString();  //选项
                        li.Text = dr[1].ToString() + " " + dr[2].ToString();    //题号+题
                        rpt.Items.Add(li);
                    }

                }

            }

        }




    }
}