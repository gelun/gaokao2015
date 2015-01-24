using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.UI.HtmlControls;

namespace GaoKao.CePing.StudyAbroad
{

    /// <summary>
    /// 算法描述：
    ///
    /// </summary>
    public partial class StudyAbroadTest : UserBase
    {
        //页码
        protected int page = 1;

        //总页码

        protected int countPage = 0;

        //页大小
        protected int pagesize = 10;

        protected int count = 20;

        #region 
        int trait_1 = 0;//英语情况
        int trait_2 = 0;//成绩
        int trait_3 = 0;//经济实力

        int t = 1;

        DataTable dt = null;
   

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {

         


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
                if (Request.Cookies["testStudyAbroadCook"] != null)
                {
                    HttpCookie myCook = new HttpCookie("testStudyAbroadCook");
                    Response.Cookies.Add(myCook);
                }

            }
            else
            {
                #region  设置值

                if (Request.Cookies["testStudyAbroadCook"] != null)
                {
                    trait_1 = int.Parse(Request.Cookies["testStudyAbroadCook"]["trait_1"]);
                    trait_2 = int.Parse(Request.Cookies["testStudyAbroadCook"]["trait_2"]);
                    trait_3 = int.Parse(Request.Cookies["testStudyAbroadCook"]["trait_3"]);
                 
                }

                #endregion

            }


            dt= DAL.Join_StudyAbroadAnswer.Join_StudyAbroadAnswerList("");


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
            DataTable dt = DAL.Join_StudyAbroad.Join_StudyAbroadPageList(" ", pagesize, this.page);
            rpt_List1.DataSource = dt;
            rpt_List1.DataBind();

            //if (dt != null && dt.Rows.Count == pagesize)
            //{
            //    //差分成两个表进行绑定

            //    DataTable drs = dt.Copy();

            //    for (int i = 0; i < pagesize / 2; i++)
            //    {
            //        drs.Rows.RemoveAt(pagesize / 2);
            //    }

            //    rpt_List1.DataSource = drs;
            //    rpt_List1.DataBind();

            //    drs = null;
            //    drs = dt.Copy();

            //    for (int i = 0; i < pagesize / 2; i++)
            //    {
            //        drs.Rows.RemoveAt(0);
            //    }

            //    rpt_List2.DataSource = drs;
            //    rpt_List2.DataBind();

            //}
            //else if (dt != null && dt.Rows.Count < pagesize)
            //{

            //    //当多出的记录数大于页码的一半时候
            //    DataTable drs = dt.Copy();

            //    for (int i = 0; i < dt.Rows.Count / 2; i++)
            //    {
            //        drs.Rows.RemoveAt(dt.Rows.Count / 2);
            //    }

            //    rpt_List1.DataSource = drs;
            //    rpt_List1.DataBind();

            //    drs = null;
            //    drs = dt.Copy();

            //    for (int i = 0; i < dt.Rows.Count / 2; i++)
            //    {
            //        drs.Rows.RemoveAt(0);
            //    }

            //    rpt_List2.DataSource = drs;
            //    rpt_List2.DataBind();


            //}

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
                HiddenField hid = (HiddenField)ri.FindControl("HiddenField1");
                RadioButtonList rbl = (RadioButtonList)ri.FindControl("rbl_Answer");

                int fen = 0;
                foreach (ListItem li in rbl.Items)
                {
                    if (li.Selected)
                    {
                        //计算分数
                        fen = int.Parse(li.Value);
                    }
                }


                if (hid.Value == "6")
                {
                    SetTrait(1, fen);
                    SetTrait(2, fen);
                }
                else
                {

                    t = GetT(int.Parse(hid.Value));
                    SetTrait(t, fen);
                }

            }

            //// 列表2
            //foreach (RepeaterItem ri in rpt_List2.Items)
            //{

            //    //题目编号
            //    HiddenField hid = (HiddenField)ri.FindControl("HiddenField1");
            //    RadioButtonList rbl = (RadioButtonList)ri.FindControl("rbl_Answer");

            //    int fen = 0;
            //    foreach (ListItem li in rbl.Items)
            //    {
            //        if (li.Selected)
            //        {
            //            //计算分数
            //            fen = int.Parse(li.Value);
            //        }
            //    }


            //    if (hid.Value == "6")
            //    {
            //        SetTrait(1, fen);
            //        SetTrait(2, fen);
            //    }
            //    else
            //    {

            //        t = GetT(int.Parse(hid.Value));
            //        SetTrait(t, fen);
            //    }

            //}


            HttpCookie myCook = new HttpCookie("testStudyAbroadCook");
            myCook.Values["trait_1"] = trait_1.ToString();
            myCook.Values["trait_2"] = trait_2.ToString();
            myCook.Values["trait_3"] = trait_3.ToString();
         

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

                //查看 结果
                Server.Transfer("Ttarget.aspx"); //301跳转
            }

        }

        #endregion


        #region  测评



        /// <summary>
        /// 设置性格的值
        /// </summary>
        /// <param name="trait"></param>
        /// <param name="an"></param>
        void SetTrait(int trait, int an)
        {


            switch (trait)
            {
                case 1:

                    trait_1 += an;
                    break;
                case 2:

                    trait_2 += an;
                    break;
                case 3:

                    trait_3 += an;
                    break;
             
                default:
                    break;

            }
        }

        #endregion


        int GetT(int  tnumber)
        {
            if (tnumber <= 6)
            {
                return 1;
            }
            else if (tnumber >6 && tnumber <= 8)
            {

                return 2;
            }
            else if (tnumber >= 9 & tnumber <= 13)
            {
                return 3;
            }
            return 0;
        }

        protected void rpt_List1_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            //绑定题目时，绑定答案
            if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
            {
                //绑定答案选项

                HiddenField  tnumber=(HiddenField)e.Item.FindControl("HiddenField1");

                RadioButtonList rpt = (RadioButtonList)e.Item.FindControl("rbl_Answer");
               

                DataRow[] drs=dt.Select("TestId="+tnumber.Value);


                foreach (DataRow dr in drs)
                {
                    ListItem li = new ListItem();
                    li.Value = dr[3].ToString();
                    li.Text = dr[4].ToString()+" "+dr[2].ToString();
                    rpt.Items.Add(li);
                }

            }

        }




    }
}