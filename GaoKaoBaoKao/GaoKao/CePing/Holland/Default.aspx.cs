using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace GaoKao.CePing.Holland
{

    /// <summary>
    /// 算法说明：
    /// 分六种类型
    /// 题号%6==0则对应的类型，按顺序
    /// 根据选择项对每种类型进行加分
    /// </summary>

    public partial class Test : UserBase
    {
        //页码
        protected int page = 1;

        //总页码

        protected int countPage = 0;

        //页大小
        protected int pagesize = 10;

        protected int count = 90;

        #region 性格类型
        int trait_1 = 0;// 现实型
        int trait_2 = 0;// 研究型
        int trait_3 = 0;// 艺术性
        int trait_4 = 0;// 社会型
        int trait_5 = 0;// 企业型
        int trait_6 = 0;// 常规型

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {

            //if (!DAL.Comm.JCJH(user.StudentId))
            //{
            //    //未激活用户
            //    Basic.MsgHelper.AlertUrlMsg("您还未激活，请使用激活卡激活账户，才能使用这些服务", "http://user.glenedu.net/UserCenter/Activate.aspx");
            //    return;
            //    //Response.Redirect("");
            //}



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
                if (Request.Cookies["testHollandCook"] != null)
                {
                    HttpCookie myCook = new HttpCookie("testHollandCook");
                    Response.Cookies.Add(myCook);
                }

            }
            else
            {
                #region  设置值

                if (Request.Cookies["testHollandCook"] != null)
                {
                    trait_1 = int.Parse(Request.Cookies["testHollandCook"]["trait_1"]);
                    trait_2 = int.Parse(Request.Cookies["testHollandCook"]["trait_2"]);
                    trait_3 = int.Parse(Request.Cookies["testHollandCook"]["trait_3"]);
                    trait_4 = int.Parse(Request.Cookies["testHollandCook"]["trait_4"]);
                    trait_5 = int.Parse(Request.Cookies["testHollandCook"]["trait_5"]);
                    trait_6 = int.Parse(Request.Cookies["testHollandCook"]["trait_6"]);
                }

                #endregion

            }




            if (!IsPostBack)
            {
                Entity.Join_HollandResults info = DAL.Join_HollandResults.Join_HollandResultsEntityGetByUserId(user.StudentId);
                if (info != null)
                {
                    DateTime dt1 = info.AddTime;
                    DateTime dt2 = DateTime.Now;
                    TimeSpan ts = dt2 - dt1;
                    if (ts.Days <= 90)
                    {
                        Basic.MsgHelper.AlertUrlMsg("为保证测试结果准确，三个月内只能进行一次测试。您已经进行过兴趣测试了。请三个月后再进行本测试。", "/ceping/ceping3.aspx");
                    }
                    else
                    {
                        Response.Write("<script>alert('为保证测评质量，请认真进行本次测评。三个月内只能进行一次测试。');</script>");
                        //绑定数据
                        BindTest();
                    }
                }
                else
                {
                    Response.Write("<script>alert('为保证测评质量，请认真进行本次测评。三个月内只能进行一次测试。');</script>");
                    //绑定数据
                    BindTest();
                }
            }
        }





        #region   绑定数据

        void BindTest()
        {

            //分页获取数据
            DataTable dt = DAL.Join_Test.Join_TestPageList(" ", pagesize, this.page);

            rpt_List1.DataSource = dt;
            rpt_List1.DataBind();

        }

        #endregion




        #region    保存数据到cookies中

        protected void next_Click(object sender, ImageClickEventArgs e)
        {


            #region 保存数据到cook中



            int i = 1;

            //列表1
            foreach (RepeaterItem ri in rpt_List1.Items)
            {

                HiddenField hid = (HiddenField)ri.FindControl("HiddenField1");
                HtmlInputRadioButton hrb = (HtmlInputRadioButton)ri.FindControl("question");

                if (hrb.Checked)
                {
                    //如果选择是则创造


                    SetTrait((int.Parse(hid.Value) % 6), 0);
                }
                else
                {

                    SetTrait((int.Parse(hid.Value) % 6), 1);
                }


                i++;
            }



            HttpCookie myCook = new HttpCookie("testHollandCook");
            myCook.Values["trait_1"] = trait_1.ToString();
            myCook.Values["trait_2"] = trait_2.ToString();
            myCook.Values["trait_3"] = trait_3.ToString();
            myCook.Values["trait_4"] = trait_4.ToString();
            myCook.Values["trait_5"] = trait_5.ToString();
            myCook.Values["trait_6"] = trait_6.ToString();

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

                //保存图片


                #region 保存数据到数据库

                Entity.Join_HollandResults model = new Entity.Join_HollandResults();


                DataTable dt = DAL.Join_HollandResults.Join_HollandResultsList("UserId=" + this.user.StudentId); //获取该学生的测试结果

                if (dt == null || dt.Rows.Count <= 0)
                {
                    model.UserId = this.user.StudentId;
                    model.Reality = trait_1;
                    model.Study = trait_2;
                    model.Art = trait_3;
                    model.Society = trait_4;
                    model.Business = trait_5;
                    model.Tradition = trait_6;


                    // int trait_1 = 0;// 现实型
                    //int trait_2 = 0;// 研究型
                    //int trait_3 = 0;// 艺术性
                    //int trait_4 =0;// 社会型
                    //int trait_5 =0;// 企业型
                    //int trait_6 =0;// 常规型
                    //添加数据
                    DAL.Join_HollandResults.Join_HollandResultsAdd(model);


                }
                else
                {
                    //model.HollandResultsId = int.Parse(dt.Rows[0]["HollandResultsId"].ToString());
                    //model.UserId = this.user.StudentId;
                    //model.Reality = trait_1;
                    //model.Study = trait_2;
                    //model.Art = trait_3;
                    //model.Society = trait_4;
                    //model.Business = trait_5;
                    //model.Tradition = trait_6;
                    ////更新数据

                    //DAL.Join_HollandResults.Join_HollandResultsEdit(model);
                }


                //查看测评报告


                #endregion

                //查看 结果

                //跳转到测评结果页
                if (Request.QueryString["Zy"] != null && Request.QueryString["Zy"] == "true")
                {
                    Response.Redirect("../Ability/AbilityTest.aspx?Zy=true");
                }
                else
                {

                    Server.Transfer("Ttarget.aspx"); //301跳转
                }
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

                    trait_1 += an == 0 ? 1 : 0;
                    break;
                case 2:

                    trait_2 += an == 0 ? 1 : 0;
                    break;
                case 3:

                    trait_3 += an == 0 ? 1 : 0;
                    break;
                case 4:

                    trait_4 += an == 0 ? 1 : 0;
                    break;
                case 5:

                    trait_5 += an == 0 ? 1 : 0;
                    break;
                case 0:

                    trait_6 += an == 0 ? 1 : 0;
                    break;
                default:
                    break;

            }
        }

        #endregion




    }
}