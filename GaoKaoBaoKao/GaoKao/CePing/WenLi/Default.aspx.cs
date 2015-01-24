using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GaoKao.CePing.WenLi
{

    /// <summary>
    /// 算法描述：前24题和后24题是两个类型题目（文理科）
    /// </summary>
    public partial class Test : UserBase
    {

        /// <summary>
        /// 1为文科测试 2为理科测试
        /// </summary>
        protected int testType = 1;

        protected int pagesize = 10;
        /// <summary>
        /// 页码
        /// </summary>
        protected int page = 1;


        #region  文理科分数计数器

        protected int WenKe = 0;
        protected int LiKe = 0;

        protected int countPage = 0;

        bool isMember = true;

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Form["hdpage"] != null)
            {
                page = int.Parse(Request.Form["hdpage"]);
            }

            if (Request.Form["hdType"] != null)
            {
                testType = int.Parse(Request.Form["hdType"]);
            }

            isMember = DAL.Comm.JCJH(user.StudentId);

            if (48 % pagesize > 0)
            {
                countPage = 48 / pagesize + 1;
            }
            else
            {
                countPage = 48 / pagesize;
            }



            #region   初始化计分器

            if (testType == 1 && page == 1)
            {
                //清楚cookie
                HttpCookie myCook = new HttpCookie("testWenLiCook");
                Response.AppendCookie(myCook);
            }

            if (Request.Cookies["testWenLiCook"] != null)
            {
                if (Request.Cookies["testWenLiCook"]["WenKe"] != null)
                {
                    WenKe = int.Parse(Request.Cookies["testWenLiCook"]["WenKe"]);
                }
                if (Request.Cookies["testWenLiCook"]["LiKe"] != null)
                {
                    LiKe = int.Parse(Request.Cookies["testWenLiCook"]["LiKe"]);
                }
            }
            else
            {

                page = 1;
            }

            #endregion

            if (!IsPostBack)
            {
                Entity.Join_TestWLResults info = DAL.Join_TestWLResults.Join_TestWLResultsEntityGetByUserId(user.StudentId);
                if (info != null)
                {
                    DateTime dt1 = info.AddTime;
                    DateTime dt2 = DateTime.Now;
                    TimeSpan ts = dt2 - dt1;
                    if (ts.Days <= 90)
                    {
                        Basic.MsgHelper.AlertUrlMsg("为保证测试结果准确，三个月内只能进行一次测试。您已经进行过文理分科测试了。请三个月后再进行本测试。", "/tuijian/default.aspx");
                    }
                    else
                    {
                        Response.Write("<script>alert('为保证测评质量，请认真进行本次测评。三个月内只能进行一次测试。');</script>");
                        Bind();
                    }
                }
                else
                {
                    Response.Write("<script>alert('为保证测评质量，请认真进行本次测评。三个月内只能进行一次测试。');</script>");
                    Bind();
                }
            }
        }


        #region   绑定数据

        void Bind()
        {

            DataTable dt = DAL.Join_TestWL.Join_TestWLPageList("", pagesize, page);
            rpt_List1.DataSource = dt;
            rpt_List1.DataBind();
        }


        #endregion

        protected void next_Click(object sender, ImageClickEventArgs e)
        {
            #region   统计分数


            foreach (RepeaterItem ri in rpt_List1.Items)
            {

                HiddenField hd = (HiddenField)ri.FindControl("hd1");
                RadioButtonList cbl = (RadioButtonList)ri.FindControl("rbL");
                if (cbl.SelectedIndex >= 0)
                {
                    switch (cbl.SelectedIndex)
                    {
                        case 0:
                            Calculate(hd.Value, 2);
                            break;
                        case 1:
                            Calculate(hd.Value, 1);
                            break;
                        case 2:
                            Calculate(hd.Value, 0);
                            break;
                        case 3:
                            Calculate(hd.Value, -1);
                            break;
                        case 4:
                            Calculate(hd.Value, -2);
                            break;
                        default:
                            break;

                    }
                }

            }




            #endregion


            #region   记录分数到Cookie里

            HttpCookie myCook = new HttpCookie("testWenLiCook");
            myCook.Values["WenKe"] = WenKe.ToString();
            myCook.Values["LiKe"] = LiKe.ToString();

            Response.Cookies.Add(myCook);


            #endregion

            #region   计算跳转地址

            if (page == countPage)
            {
                //hdType.Value = "2";
                //hdPage.Value = "1";

                //计算数据

                //保存分数到数据库中

                DataTable dt = DAL.Join_TestWLResults.Join_TestWLResultsList(" UserId=" + this.user.StudentId);

                if (dt != null && dt.Rows.Count > 0)
                {
                    Entity.Join_TestWLResults model = new Entity.Join_TestWLResults();

                    model.WlId = int.Parse(dt.Rows[0]["WlId"].ToString());
                    model.UserId = this.user.StudentId;
                    model.LK = LiKe;
                    model.WK = WenKe;


                    model.AddTime = DateTime.Now;

                    DAL.Join_TestWLResults.Join_TestWLResultsEdit(model);

                }
                else
                {


                    Entity.Join_TestWLResults model = new Entity.Join_TestWLResults();
                    model.UserId = this.user.StudentId;
                    model.LK = LiKe;
                    model.WK = WenKe;


                    model.AddTime = DateTime.Now;

                    DAL.Join_TestWLResults.Join_TestWLResultsAdd(model);
                }

                #region 输出结果


                Server.Transfer("Ttarget.aspx"); //301跳转
                #endregion


            }
            else
            {
                hdPage.Value = (page++).ToString();

            }

            hdType.Value = testType.ToString();
            hdPage.Value = page.ToString();


            #endregion

            Bind();
        }




        #region   分数计算

        /// <summary>
        /// 计算文理得分
        /// </summary>
        /// <param name="type">文理类别</param>
        /// <param name="point">分值</param>
        void Calculate(string type, int point)
        {
            int t = int.Parse(type) >= 24 ? 2 : 1;

            switch (t)
            {
                case 1:
                    WenKe += point;
                    break;
                case 2:
                    LiKe += point;
                    break;
                default:
                    break;
            }
        }

        #endregion


    }
}