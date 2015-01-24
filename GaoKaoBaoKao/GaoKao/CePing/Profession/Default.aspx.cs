using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace GaoKao.CePing.Profession
{


    /// <summary>
    /// 算法描述：
    /// 根据题目所属归组，然后让归组加上其
    /// 选择的项的分数
    /// </summary>
    public partial class ProfessionTest : UserBase
    {
        protected int page = 1;   //当前页码
        protected int pageSize = 10; //当前页大小
        protected int sumPage = 1;//总共页数
        protected int recordNumber = 52;

        #region   变量计算分数
        int group1 = 0; //利他主义
        int group2 = 0;  //美感
        int group3 = 0; //智力刺激
        int group4 = 0;//成就感
        int group5 = 0; //独立性
        int group6 = 0; //社会地位
        int group7 = 0;//管理
        int group8 = 0; //经济报酬
        int group9 = 0; //社会交际
        int group10 = 0;//安全感
        int group11 = 0;//舒适
        int group12 = 0; //人际关系
        int group13 = 0; //变异性


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
                group1 = 0;
                group2 = 0;
                group3 = 0;
                group4 = 0;
                group5 = 0;
                group6 = 0;
                group7 = 0;
                group8 = 0;
                group9 = 0;
                group10 = 0;
                group11 = 0;
                group12 = 0;
                group13 = 0;

            }
            else
            {

                if (Request.Cookies["testProfessionCook"] != null)
                {


                    if (Request.Cookies["testProfessionCook"]["group1"] != null)
                    {
                        group1 = int.Parse(Request.Cookies["testProfessionCook"]["group1"]);
                    }
                    if (Request.Cookies["testProfessionCook"]["group2"] != null)
                    {
                        group2 = int.Parse(Request.Cookies["testProfessionCook"]["group2"]);
                    }


                    if (Request.Cookies["testProfessionCook"]["group3"] != null)
                    {
                        group3 = int.Parse(Request.Cookies["testProfessionCook"]["group3"]);
                    }
                    if (Request.Cookies["testProfessionCook"]["group4"] != null)
                    {
                        group4 = int.Parse(Request.Cookies["testProfessionCook"]["group4"]);
                    }
                    if (Request.Cookies["testProfessionCook"]["group5"] != null)
                    {
                        group5 = int.Parse(Request.Cookies["testProfessionCook"]["group5"]);
                    }

                    if (Request.Cookies["testProfessionCook"]["group6"] != null)
                    {
                        group6 = int.Parse(Request.Cookies["testProfessionCook"]["group6"]);
                    }

                    if (Request.Cookies["testProfessionCook"]["group7"] != null)
                    {
                        group7 = int.Parse(Request.Cookies["testProfessionCook"]["group7"]);
                    }
                    if (Request.Cookies["testProfessionCook"]["group8"] != null)
                    {
                        group8 = int.Parse(Request.Cookies["testProfessionCook"]["group8"]);
                    }
                    if (Request.Cookies["testProfessionCook"]["group9"] != null)
                    {
                        group9 = int.Parse(Request.Cookies["testProfessionCook"]["group9"]);
                    }

                    if (Request.Cookies["testProfessionCook"]["group10"] != null)
                    {
                        group10 = int.Parse(Request.Cookies["testProfessionCook"]["group10"]);
                    }


                    if (Request.Cookies["testProfessionCook"]["group11"] != null)
                    {
                        group11 = int.Parse(Request.Cookies["testProfessionCook"]["group11"]);
                    }

                    if (Request.Cookies["testProfessionCook"]["group12"] != null)
                    {
                        group12 = int.Parse(Request.Cookies["testProfessionCook"]["group12"]);
                    }

                    if (Request.Cookies["testProfessionCook"]["group13"] != null)
                    {
                        group13 = int.Parse(Request.Cookies["testProfessionCook"]["group13"]);
                    }

                }
                else
                {
                    page = 1;
                    group1 = 0;
                    group2 = 0;
                    group3 = 0;
                    group4 = 0;
                    group5 = 0;
                    group6 = 0;
                    group7 = 0;
                    group8 = 0;
                    group9 = 0;
                    group10 = 0;
                    group11 = 0;
                    group12 = 0;
                    group13 = 0;
                }
            }


            #endregion

            #endregion

            if (!IsPostBack)
            {
                Entity.Join_ProfessionResults info = DAL.Join_ProfessionResults.Join_ProfessionResultsEntityGetByUserId(user.StudentId);
                if (info != null)
                {
                    DateTime dt1 = info.AddTime;
                    DateTime dt2 = DateTime.Now;
                    TimeSpan ts = dt2 - dt1;
                    if (ts.Days <= 90)
                    {
                        Basic.MsgHelper.AlertUrlMsg("为保证测试结果准确，三个月内只能进行一次测试。您已经进行过价值观测试了。请三个月后再进行本测试。", "/ceping/ceping4.aspx");
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


        #region 绑定数据

        void Bind()
        {
            DataTable dt = DAL.Join_ProfessionTest.Join_ProfessionTestPageList("", pageSize, page);

            rpt_List1.DataSource = dt;
            rpt_List1.DataBind();

        }






        #endregion



        #region   记录数据

        protected void subbut_Click(object sender, ImageClickEventArgs e)
        {
            #region 统计分数

            string hdtype = "";
            foreach (RepeaterItem ri in rpt_List1.Items)
            {

                HiddenField hd = (HiddenField)ri.FindControl("hd");

                hdtype = hd.Value;

                RadioButtonList cbl = (RadioButtonList)ri.FindControl("rdb_Check");
                if (cbl.SelectedIndex >= 0)
                {
                    //计算选择的答案的个数
                    switch (cbl.SelectedIndex)
                    {
                        case 0:
                            Calculate(hd.Value,5);
                            break;
                        case 1:
                            Calculate(hd.Value, 4);
                            break;
                        case 2:
                            Calculate(hd.Value, 3);
                            break;
                        case 3:
                            Calculate(hd.Value, 2);
                            break;
                        case 4:
                            Calculate(hd.Value, 1);
                            break;
                        default:
                            break;
                    }

                    //统计分数

                }

            }

        




          
            #endregion

            #region   记录分数到Cookie里


            HttpCookie myCook = new HttpCookie("testProfessionCook");
            myCook.Values["group1"] = group1.ToString();
            myCook.Values["group2"] = group2.ToString();
            myCook.Values["group3"] = group3.ToString();
            myCook.Values["group4"] = group4.ToString();
            myCook.Values["group5"] = group5.ToString();
            myCook.Values["group6"] = group6.ToString();
            myCook.Values["group7"] = group7.ToString();
            myCook.Values["group8"] = group8.ToString();
            myCook.Values["group9"] = group9.ToString();
            myCook.Values["group10"] = group10.ToString();
            myCook.Values["group11"] = group11.ToString();
            myCook.Values["group12"] = group12.ToString();
            myCook.Values["group13"] = group13.ToString();


            Response.Cookies.Add(myCook);
            #endregion

            #region   设计下一页数据

            if (page == sumPage)
            {
                //跳转到测评结果页
                #region 保存数据到数据库

                Entity.Join_ProfessionResults model = new Entity.Join_ProfessionResults();


                DataTable dt = DAL.Join_ProfessionResults.Join_ProfessionResultsList("UserId=" + this.user.StudentId); //获取该学生的测试结果

                if (dt == null || dt.Rows.Count <= 0)
                {
                    model.UserId = this.user.StudentId;

                    model.Group1 = group1;
                    model.Group2 = group2;
                    model.Group3 = group3;
                    model.Group4 = group4;
                    model.Group5 = group5;
                    model.Group6 = group6;
                    model.Group7 = group7;
                    model.Group8 = group8;
                    model.Group9 = group9;
                    model.Group10 = group10;
                    model.Group11 = group11;
                    model.Group12 = group12;
                    model.Group13 = group13;



                    //添加数据
                    DAL.Join_ProfessionResults.Join_ProfessionResultsAdd(model);


                }
                else
                {
                    model.ProfessionResultsId = int.Parse(dt.Rows[0]["ProfessionResultsId"].ToString());
                    model.UserId = this.user.StudentId;

                    model.Group1 = group1;
                    model.Group2 = group2;
                    model.Group3 = group3;
                    model.Group4 = group4;
                    model.Group5 = group5;
                    model.Group6 = group6;
                    model.Group7 = group7;
                    model.Group8 = group8;
                    model.Group9 = group9;
                    model.Group10 = group10;
                    model.Group11 = group11;
                    model.Group12 = group12;
                    model.Group13 = group13;

                    //更新数据

                    DAL.Join_ProfessionResults.Join_ProfessionResultsEdit(model);
                }


                //查看测评报告

                //跳转到测评结果页
                if (Request.QueryString["Zy"] != null && Request.QueryString["Zy"] == "true")
                {
                    Response.Redirect("/Rports/Rports.aspx?Zy=true");
                }
                else
                {

                    Server.Transfer("Ttarget.aspx"); //301跳转
                }
                
                #endregion

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
        /// <param name="type">类型</param>
        /// <param name="point">分数</param>
        void Calculate(string type ,int point)
        {
        


            switch (type.ToLower())
            {
                case "1":
                    group1 += point;
                    break;
                case "2":
                    group2 += point;
                    break;
                case "3":
                    group3 += point;
                    break;
                case "4":
                    group4 += point;
                    break;
                case "5":
                    group5 += point;
                    break;
                case "6":
                    group6 += point;
                    break;
                case "7":
                    group7 += point;
                    break;
                case "8":
                    group8 += point;
                    break;
                case "9":
                    group9 += point;
                    break;
                case "10":
                    group10 += point;
                    break;
                case "11":
                    group11 += point;
                    break;
                case "12":
                    group12 += point;
                    break;
                case "13":
                    group13 += point;
                    break;
                default:
                    break;
            }

       

        }

        #endregion

    }
}