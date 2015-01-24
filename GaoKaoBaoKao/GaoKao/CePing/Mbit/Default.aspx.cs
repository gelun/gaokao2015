using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace GaoKao.CePing.Mbit
{


    /// <summary>
    /// 算法说明：
    /// 对题目进行分组
    /// 根据题目所属分组及选择的项为每组的a,b两项计分
    /// 然后将对应的项分数合并到  e  i  s  n  t  f  j  p  八个选项中
    /// </summary>
    public partial class Default : UserBase
    {
        //页码
        protected int page = 1;

        //总页码

        protected int countPage = 0;

        //页大小
        protected int pagesize = 10;

        protected int count = 70;

        #region
        int G1_A = 0;//归组1 E
        int G1_B = 0;//归组1 I
        int G2_A = 0;//归组2 S
        int G2_B = 0;//归组2  N

        int G3_A = 0;//归组3 S
        int G3_B = 0;//归组3 N
        int G4_A = 0;//归组4  T
        int G4_B = 0;//归组4  E

        int G5_A = 0;//归组5 T
        int G5_B = 0;//归组5 E
        int G6_A = 0;//归组6  J
        int G6_B = 0;//归组6  P

        int G7_A = 0;//经济实力J
        int G7_B = 0;//经济实力P

        int t = 1;


        DataTable anDt = null;
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {



            anDt = DAL.Join_MbitAnswer.Join_MbitAnswerList("");


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
                if (Request.Cookies["testMbitCook"] != null)
                {
                    HttpCookie myCook = new HttpCookie("testMbitCook");
                    Response.Cookies.Add(myCook);
                }

            }
            else
            {
                #region  设置值

                if (Request.Cookies["testMbitCook"] != null)
                {

                    G1_A = int.Parse(Request.Cookies["testMbitCook"]["G1_A"]);
                    G1_B = int.Parse(Request.Cookies["testMbitCook"]["G1_B"]);
                    G2_A = int.Parse(Request.Cookies["testMbitCook"]["G2_A"]);
                    G2_B = int.Parse(Request.Cookies["testMbitCook"]["G2_B"]);

                    G3_A = int.Parse(Request.Cookies["testMbitCook"]["G3_A"]);
                    G3_B = int.Parse(Request.Cookies["testMbitCook"]["G3_B"]);
                    G4_A = int.Parse(Request.Cookies["testMbitCook"]["G4_A"]);
                    G4_B = int.Parse(Request.Cookies["testMbitCook"]["G4_B"]);

                    G5_A = int.Parse(Request.Cookies["testMbitCook"]["G5_A"]);
                    G5_B = int.Parse(Request.Cookies["testMbitCook"]["G5_B"]);
                    G6_A = int.Parse(Request.Cookies["testMbitCook"]["G6_A"]);
                    G6_B = int.Parse(Request.Cookies["testMbitCook"]["G6_B"]);

                    G7_A = int.Parse(Request.Cookies["testMbitCook"]["G7_A"]);
                    G7_B = int.Parse(Request.Cookies["testMbitCook"]["G7_B"]);



                }

                #endregion

            }



            if (!IsPostBack)
            {
                Entity.Join_MbtiResults info = DAL.Join_MbtiResults.Join_MbtiResultsEntityGetByStudentId(user.StudentId);
                if (info != null)
                {
                    DateTime dt1 = info.AddTime;
                    DateTime dt2 = DateTime.Now;
                    TimeSpan ts = dt2 - dt1;
                    if (ts.Days <= 90)
                    {
                        Basic.MsgHelper.AlertUrlMsg("为保证测试结果准确，三个月内只能进行一次测试。您已经进行过性格测试了。请三个月后再进行本测试。", "/ceping/ceping1.aspx");
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
            DataTable dt = DAL.Join_MbitTest.Join_MbitTestPageList(" ", pagesize, this.page);
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
                        SetTrait(li.Value.ToLower(), int.Parse(hid.Value));
                    }
                }
            }


            HttpCookie myCook = new HttpCookie("testMbitCook");


            myCook.Values["G1_A"] = G1_A.ToString();
            myCook.Values["G1_B"] = G1_B.ToString();
            myCook.Values["G2_A"] = G2_A.ToString();
            myCook.Values["G2_B"] = G2_B.ToString();

            myCook.Values["G3_A"] = G3_A.ToString();
            myCook.Values["G3_B"] = G3_B.ToString();
            myCook.Values["G4_A"] = G4_A.ToString();
            myCook.Values["G4_B"] = G4_B.ToString();

            myCook.Values["G5_A"] = G5_A.ToString();
            myCook.Values["G5_B"] = G5_B.ToString();
            myCook.Values["G6_A"] = G6_A.ToString();
            myCook.Values["G6_B"] = G6_B.ToString();

            myCook.Values["G7_A"] = G7_A.ToString();
            myCook.Values["G7_B"] = G7_B.ToString();


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
                //将数据保存到数据库

                int E = G1_A;
                int I = G1_B;
                int S = G2_A + G3_A;
                int N = G2_B + G3_B;
                int T = G4_A + G5_A;
                int F = G4_B + G5_B;
                int J = G6_A + G7_A;
                int P = G6_B + G7_B;

                Entity.Join_MbtiResults info = new Entity.Join_MbtiResults();
                info.E = E;
                info.I = I;
                info.S = S;
                info.N = N;
                info.T = T;
                info.F = F;
                info.J = J;
                info.P = P;
                info.StudentId = user.StudentId;

                DAL.Join_MbtiResults.Join_MbtiResultsAdd(info);

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
        void SetTrait(string option, int type)
        {
            switch (type)
            {
                case 1:
                    if (option == "a")
                    {
                        G1_A += 1;
                    }
                    else
                    {
                        G1_B += 1;
                    }


                    break;
                case 2:
                    if (option == "a")
                    {
                        G2_A += 1;
                    }
                    else
                    {
                        G2_B += 1;
                    }
                    break;
                case 3:
                    if (option == "a")
                    {
                        G3_A += 1;
                    }
                    else
                    {
                        G3_B += 1;
                    }
                    break;
                case 4:
                    if (option == "a")
                    {
                        G4_A += 1;
                    }
                    else
                    {
                        G4_B += 1;
                    }
                    break;
                case 5:
                    if (option == "a")
                    {
                        G5_A += 1;
                    }
                    else
                    {
                        G5_B += 1;
                    }
                    break;
                case 6:
                    if (option == "a")
                    {
                        G6_A += 1;
                    }
                    else
                    {
                        G6_B += 1;
                    }
                    break;
                case 7:
                    if (option == "a")
                    {
                        G7_A += 1;
                    }
                    else
                    {
                        G7_B += 1;
                    }
                    break;
                default:
                    break;

            }


        }

        #endregion




        protected void rpt_List1_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            //绑定题目时，绑定答案
            if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
            {
                //绑定答案选项

                HiddenField tnumber = (HiddenField)e.Item.FindControl("hd");

                RadioButtonList rpt = (RadioButtonList)e.Item.FindControl("rdb_Check");


                if (anDt != null)
                {



                    DataRow[] drs = anDt.Select("TestId=" + tnumber.Value);


                    foreach (DataRow dr in drs)
                    {
                        ListItem li = new ListItem();
                        li.Value = dr[3].ToString();
                        li.Text = dr[3].ToString() + " " + dr[2].ToString();
                        rpt.Items.Add(li);
                    }

                }

            }

        }




    }
}