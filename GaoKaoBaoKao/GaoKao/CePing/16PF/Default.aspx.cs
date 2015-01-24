using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace GaoKao.CePing._16PF
{
    public partial class Default : UserBase
    {
        protected int page = 1;   //当前页码
        protected int pageSize = 10; //当前页大小
        protected int sumPage = 1;//总共页数
        protected int recordNumber = 187;

        #region   变量计算分数
        int a = 0;
        int b = 0;
        int c = 0;
        int e = 0;
        int f = 0;
        int g = 0;
        int h = 0;
        int i = 0;
        int l = 0;
        int m = 0;
        int n = 0;
        int o = 0;
        int q1 = 0;
        int q2 = 0;
        int q3 = 0;
        int q4 = 0;



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

            if (page == sumPage)
            {

            }

            #region  ---------------

            if (Request.Cookies["test16pfCook"] != null)
            {


                if (Request.Cookies["test16pfCook"]["a"] != null)
                {
                    a = int.Parse(Request.Cookies["test16pfCook"]["a"]);
                }
                if (Request.Cookies["test16pfCook"]["b"] != null)
                {
                    b = int.Parse(Request.Cookies["test16pfCook"]["b"]);
                }


                if (Request.Cookies["test16pfCook"]["c"] != null)
                {
                    c = int.Parse(Request.Cookies["test16pfCook"]["c"]);
                }
                if (Request.Cookies["test16pfCook"]["e"] != null)
                {
                    this.e = int.Parse(Request.Cookies["test16pfCook"]["e"]);
                }
                if (Request.Cookies["test16pfCook"]["f"] != null)
                {
                    f = int.Parse(Request.Cookies["test16pfCook"]["f"]);
                }

                if (Request.Cookies["test16pfCook"]["g"] != null)
                {
                    g = int.Parse(Request.Cookies["test16pfCook"]["g"]);
                }

                if (Request.Cookies["test16pfCook"]["h"] != null)
                {
                    h = int.Parse(Request.Cookies["test16pfCook"]["h"]);
                }
                if (Request.Cookies["test16pfCook"]["i"] != null)
                {
                    i = int.Parse(Request.Cookies["test16pfCook"]["i"]);
                }
                if (Request.Cookies["test16pfCook"]["l"] != null)
                {
                    l = int.Parse(Request.Cookies["test16pfCook"]["l"]);
                }
                if (Request.Cookies["test16pfCook"]["m"] != null)
                {
                    m = int.Parse(Request.Cookies["test16pfCook"]["m"]);
                }
                if (Request.Cookies["test16pfCook"]["n"] != null)
                {
                    n = int.Parse(Request.Cookies["test16pfCook"]["n"]);
                }
                if (Request.Cookies["test16pfCook"]["o"] != null)
                {
                    o = int.Parse(Request.Cookies["test16pfCook"]["o"]);
                }
                if (Request.Cookies["test16pfCook"]["q1"] != null)
                {
                    q1 = int.Parse(Request.Cookies["test16pfCook"]["q1"]);
                }
                if (Request.Cookies["test16pfCook"]["q2"] != null)
                {
                    q2 = int.Parse(Request.Cookies["test16pfCook"]["q2"]);
                }

                if (Request.Cookies["test16pfCook"]["q3"] != null)
                {
                    q3 = int.Parse(Request.Cookies["test16pfCook"]["q3"]);
                }

                if (Request.Cookies["test16pfCook"]["q4"] != null)
                {
                    q4 = int.Parse(Request.Cookies["test16pfCook"]["q4"]);
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
            DataTable dt = DAL.Join_16PfTest.Join_16PfTestPageList("", pageSize, page);
            rpt_List1.DataSource = dt;
            rpt_List1.DataBind();
        }





        protected void rpt_List1_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            //绑定答案选项
            if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
            {
                HiddenField hd = (HiddenField)e.Item.FindControl("hd");
                RadioButtonList rd = (RadioButtonList)e.Item.FindControl("rdb_Check");

                rd.DataSource = DAL.Join_16PfAnswer.Join_16PfAnswerList("TestId=" + hd.Value);
                rd.DataTextField = "AnswerContent";
                rd.DataValueField = "Fraction";
                rd.DataBind();

            }

        }

        #endregion



        #region   记录数据

        protected void subbut_Click(object sender, ImageClickEventArgs e)
        {
            #region 统计分数


            foreach (RepeaterItem ri in rpt_List1.Items)
            {

                HiddenField hd = (HiddenField)ri.FindControl("hdType");     //fe
                RadioButtonList cbl = (RadioButtonList)ri.FindControl("rdb_Check");
                if (cbl.SelectedIndex >= 0)
                {
                    ListItem li = cbl.SelectedItem;
                    Calculate(hd.Value, int.Parse(li.Value));
                }

            }


            #endregion

            #region   记录分数到Cookie里


            HttpCookie myCook = new HttpCookie("test16pfCook");
            myCook.Values["a"] = a.ToString();
            myCook.Values["b"] = b.ToString();
            myCook.Values["c"] = c.ToString();
            myCook.Values["e"] = this.e.ToString();
            myCook.Values["f"] = this.f.ToString();
            myCook.Values["g"] = g.ToString();
            myCook.Values["h"] = h.ToString();
            myCook.Values["i"] = i.ToString();
            myCook.Values["l"] = l.ToString();
            myCook.Values["m"] = m.ToString();
            myCook.Values["n"] = n.ToString();
            myCook.Values["o"] = o.ToString();
            myCook.Values["q1"] = q1.ToString();
            myCook.Values["q2"] = q2.ToString();
            myCook.Values["q3"] = q3.ToString();
            myCook.Values["q4"] = q4.ToString();

            Response.Cookies.Add(myCook);
            #endregion

            #region   设计下一页数据

            if (page == sumPage)
            {
                #region 保存数据到数据库



                Entity.Join_16PfResults model = new Entity.Join_16PfResults();


                DataTable dt = DAL.Join_16PfResults.Join_16PfResultsList("UserId=" + this.user.StudentId); //获取该学生的测试结果

                if (dt == null || dt.Rows.Count <= 0)
                {
                    model.UserId = this.user.StudentId;
                    model.A_type = compute(a, 0, 1, 2, 3, 3, 4, 6, 6, 7, 8, 9, 11, 12, 13, 14, 14, 15, 16, 17, 20);
                    model.B_type = compute(b, 0, 3, 4, 4, 5, 5, 6, 6, 7, 7, 8, 8, 9, 9, 10, 10, 11, 11, 12, 13);
                    model.C_type = compute(c, 0, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 16, 17, 18, 19, 20, 21, 22, 23, 26);
                    model.E_type = compute(this.e, 0, 2, 3, 4, 5, 5, 6, 7, 8, 9, 10, 12, 13, 14, 15, 16, 17, 18, 19, 26);
                    model.F_type = compute(f, 0, 3, 4, 4, 5, 6, 7, 7, 8, 9, 10, 12, 13, 14, 15, 16, 17, 18, 19, 16); ;
                    model.G_type = compute(g, 0, 5, 6, 7, 8, 9, 10, 10, 11, 12, 13, 14, 15, 16, 17, 17, 18, 18, 19, 20); ;
                    model.H_type = compute(h, 0, 1, 2, 2, 3, 3, 4, 6, 7, 8, 9, 11, 12, 14, 15, 16, 17, 19, 20, 26); ;
                    model.I_type = compute(i, 0, 5, 6, 6, 7, 8, 9, 9, 10, 11, 12, 13, 14, 14, 15, 16, 17, 17, 18, 19); ;
                    model.L_type = compute(l, 0, 3, 4, 5, 6, 6, 7, 8, 9, 10,11, 12, 13, 13, 14, 15, 16, 16, 17, 20); ;
                    model.M_type = compute(m, 0, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 20, 21, 26); ;
                    model.N_type = compute(n, 0, 2, 3, 3, 4, 4, 5, 6, 7, 8, 9, 10, 11, 11, 12, 13, 14, 14, 15, 20); ;
                    model.O_type = compute(o, 0, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18,19, 26); ;
                    model.Q1_type = compute(q1, 0, 4, 5, 5, 6, 7, 8, 8, 9, 10, 11, 12, 13, 13, 14, 14, 15, 15, 16, 20); ;
                    model.Q2_type = compute(q2, 0, 5, 6, 7, 8, 8, 9, 10, 11, 12, 13, 14, 15, 15, 16, 17, 18, 18, 19, 20); ;
                    model.Q3_type = compute(q3, 0, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 15, 16, 17, 18, 18, 19, 20); ;
                    model.Q4_type = compute(q4, 0, 2, 3, 4, 5, 6, 7, 8, 9, 11, 12, 14, 15, 16, 17, 19, 20, 21, 22, 26); ;

                    try
                    {
                        //添加数据
                        DAL.Join_16PfResults.Join_16PfResultsAdd(model);

                    }
                    catch (Exception ex)
                    {
                        Response.Write(ex.Message);
                    }


                }
                else
                {


                    model.PfResultsId = int.Parse(dt.Rows[0]["PfResultsId"].ToString());
                    model.UserId = this.user.StudentId;
                    model.A_type = a;
                    model.B_type = b;
                    model.C_type = c;
                    model.E_type = this.e;
                    model.F_type = f;
                    model.G_type = g;
                    model.H_type = h;
                    model.I_type = i;
                    model.L_type = l;
                    model.M_type = m;
                    model.N_type = n;
                    model.O_type = o;
                    model.Q1_type = q1;
                    model.Q2_type = q2;
                    model.Q3_type = q3;
                    model.Q4_type = q4;



                    //更新数据
                    try
                    {

                        DAL.Join_16PfResults.Join_16PfResultsEdit(model);

                    }
                    catch (Exception ex)
                    {
                        Response.Write(ex.Message);
                    }



                }


                //查看测评报告


                #endregion

                if (Request.QueryString["Zy"] != null && Request.QueryString["Zy"] == "true")
                {
                    Response.Redirect("../Holland/Test.aspx?Zy=true");
                }
                else
                {

                    Server.Transfer("Ttarget.aspx"); //301跳转
                }


                return;
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
        void Calculate(string type, int point)
        {
            switch (type.ToLower())
            {
                case "a":
                    a += point;
                    break;
                case "b":
                    b += point;
                    break;
                case "c":
                    c += point;
                    break;
                case "e":
                    e += point;
                    break;
                case "f":
                    f += point;
                    break;
                case "g":
                    g += point;
                    break;
                case "h":
                    h += point;
                    break;
                case "i":
                    i += point;
                    break;
                case "l":
                    l += point;
                    break;
                case "m":
                    m += point;
                    break;
                case "n":
                    n += point;
                    break;
                case "o":
                    o += point;
                    break;
                case "q1":
                    q1 += point;
                    break;
                case "q2":
                    q2 += point;
                    break;
                case "q3":
                    q3 += point;
                    break;
                case "q4":
                    q4 += point;
                    ;
                    break;
                default:
                    break;
            }
        }

        #endregion


        int compute(int fen, int min1, int max1, int min2, int max2, int min3, int max3, int min4, int max4, int min5, int max5, int min6, int max6, int min7, int max7, int min8, int max8, int min9, int max9, int min10, int max10)
        {
            if (fen >= min1 && fen <= max1)
            {
                return 1;
            }

            if (fen >= min2 && fen <= max2)
            {
                return 2;
            }

            if (fen >= min3 && fen <= max3)
            {
                return 3;
            }

            if (fen >= min4 && fen <= max4)
            {
                return 4;
            }

            if (fen >= min5 && fen <= max5)
            {
                return 5;
            }

            if (fen >= min6 && fen <= max6)
            {
                return 6;
            }

            if (fen >= min7 && fen <= max7)
            {
                return 7;
            }

            if (fen >= min8 && fen <= max8)
            {
                return 8;
            }

            if (fen >= min9 && fen <= max9)
            {
                return 9;
            }

            if (fen >= min10)
            {
                return 10;
            }

            return 0;
        }

    }

}