using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Svg;
using System.Text;
using Word = Microsoft.Office.Interop.Word;

namespace GaoKao.CePing.Ability
{
    public partial class AbilityTest : UserBase
    {

        protected int page = 1;   //当前页码
        protected int pageSize = 4; //当前页大小
        protected int sumPage = 1;//总共页数
        protected int recordNumber = 48;

        #region   变量计算分数
        float group1 = 0;  //一半学习能力倾向
        float group2 = 0;  //语言能力倾向
        float group3 = 0;  //算数能力倾向
        float group4 = 0;  //空间判断能力倾向

        float group5 = 0; //形态知觉能力倾向
        float group6 = 0; //文秘能力倾向
        float group7 = 0; //眼手运动协调能力倾向
        float group8 = 0; //手指灵巧倾向
        float group9 = 0;//手的灵巧倾向


        #endregion

        #region  答案计数器

        int sl1 = 0;
        int sl2 = 0;
        int sl3 = 0;
        int sl4 = 0;
        int sl5 = 0;

        #endregion

        #region 生成word文档报告
        protected int intYanYu = 0, intShuLi = 0, intKongJianPanDuan = 0, intChaJueXiJie = 0, intShuXie = 0,
            intYunDongXieTiao = 0, intDongShou = 0, intSheHuiJiaoWang = 0, intZuZhiGuanLi = 0;


        protected int[] list;
        protected int intMax = 0;//最大值
        protected int intMin = 0;//最小值
        //可能感兴趣专业
        protected string[] arrTuiJianZhuanYe;
        //不推荐专业
        protected string[] arrBuTuiJianZhuanYe;
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

            }
            else
            {

                if (Request.Cookies["testAbilityCook"] != null)
                {


                    if (Request.Cookies["testAbilityCook"]["group1"] != null)
                    {
                        group1 = float.Parse(Request.Cookies["testAbilityCook"]["group1"]);
                    }
                    if (Request.Cookies["testAbilityCook"]["group2"] != null)
                    {
                        group2 = float.Parse(Request.Cookies["testAbilityCook"]["group2"]);
                    }


                    if (Request.Cookies["testAbilityCook"]["group3"] != null)
                    {
                        group3 = float.Parse(Request.Cookies["testAbilityCook"]["group3"]);
                    }
                    if (Request.Cookies["testAbilityCook"]["group4"] != null)
                    {
                        group4 = float.Parse(Request.Cookies["testAbilityCook"]["group4"]);
                    }
                    if (Request.Cookies["testAbilityCook"]["group5"] != null)
                    {
                        group5 = float.Parse(Request.Cookies["testAbilityCook"]["group5"]);
                    }

                    if (Request.Cookies["testAbilityCook"]["group6"] != null)
                    {
                        group6 = float.Parse(Request.Cookies["testAbilityCook"]["group6"]);
                    }

                    if (Request.Cookies["testAbilityCook"]["group7"] != null)
                    {
                        group7 = float.Parse(Request.Cookies["testAbilityCook"]["group7"]);
                    }
                    if (Request.Cookies["testAbilityCook"]["group8"] != null)
                    {
                        group8 = float.Parse(Request.Cookies["testAbilityCook"]["group8"]);
                    }
                    if (Request.Cookies["testAbilityCook"]["group9"] != null)
                    {
                        group9 = float.Parse(Request.Cookies["testAbilityCook"]["group9"]);
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
                }
            }


            #endregion

            #endregion
            if (!IsPostBack)
            {
                Entity.Join_AbilityResults info = DAL.Join_AbilityResults.Join_AbilityResultsEntityGetByUserId(user.StudentId);
                if (info != null)
                {
                    DateTime dt1 = info.AddTime;
                    DateTime dt2 = DateTime.Now;
                    TimeSpan ts = dt2 - dt1;
                    if (ts.Days <= 90)
                    {
                        Basic.MsgHelper.AlertUrlMsg("为保证测试结果准确，三个月内只能进行一次测试。您已经进行过能力测试了。请三个月后再进行本测试。", "/ceping/ceping2.aspx");
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

        //绑定数据
        void Bind()
        {
            DataTable dt = DAL.Join_AbilityTest.Join_AbilityTestPageList("", pageSize, page);
            rpt_List1.DataSource = dt;
            rpt_List1.DataBind();
        }

        #region   记录数据

        protected void subbut_Click(object sender, ImageClickEventArgs e)
        {
            #region 统计分数
            string hdtype = "";
            foreach (RepeaterItem ri in rpt_List1.Items)
            {
                HiddenField hd = (HiddenField)ri.FindControl("hdType");
                hdtype = hd.Value;
                RadioButtonList cbl = (RadioButtonList)ri.FindControl("rdb_Check");
                if (cbl.SelectedIndex >= 0)
                {
                    //计算选择的答案的个数
                    switch (cbl.SelectedIndex)
                    {
                        case 0:
                            sl1++;
                            break;
                        case 1:
                            sl2++;
                            break;
                        case 2:
                            sl3++;
                            break;
                        case 3:
                            sl4++;
                            break;
                        case 4:
                            sl5++;
                            break;
                        default:
                            break;
                    }
                    //统计分数
                }
            }
            Calculate(hdtype);
            #endregion

            #region   记录分数到Cookie里

            HttpCookie myCook = new HttpCookie("testAbilityCook");
            myCook.Values["group1"] = group1.ToString();
            myCook.Values["group2"] = group2.ToString();
            myCook.Values["group3"] = group3.ToString();
            myCook.Values["group4"] = group4.ToString();
            myCook.Values["group5"] = group5.ToString();
            myCook.Values["group6"] = group6.ToString();
            myCook.Values["group7"] = group7.ToString();
            myCook.Values["group8"] = group8.ToString();
            myCook.Values["group9"] = group9.ToString();

            Response.Cookies.Add(myCook);
            #endregion

            #region   设计下一页数据

            if (page >= sumPage)
            {
                #region 保存数据到数据库

                Entity.Join_AbilityResults model = new Entity.Join_AbilityResults();
                DataTable dt = DAL.Join_AbilityResults.Join_AbilityResultsList("UserId=" + this.user.StudentId); //获取该学生的测试结果
                if (dt == null || dt.Rows.Count <= 0)
                {
                    model.UserId = this.user.StudentId;
                    model.Language = group1;
                    model.Mathematics = group2;
                    model.Space = group3;
                    model.Watch = group4;
                    model.Writing = group5;
                    model.Motion = group6;
                    model.Art = group7;
                    model.Among = group8;
                    model.Tissue = group9;
                    //添加数据
                    DAL.Join_AbilityResults.Join_AbilityResultsAdd(model);
                }
                else
                {
                    model.AbilityResultsId = int.Parse(dt.Rows[0]["AbilityResultsId"].ToString());
                    model.UserId = this.user.StudentId;

                    model.Language = group1;  //
                    model.Mathematics = group2;
                    model.Space = group3;
                    model.Watch = group4;
                    model.Writing = group5;
                    model.Motion = group6;
                    model.Art = group7;
                    model.Among = group8;
                    model.Tissue = group9;
                    //更新数据
                    DAL.Join_AbilityResults.Join_AbilityResultsEdit(model);
                }
                #endregion

                #region 生成word报告文档

                //  //各能力得分
                //  intYanYu = Basic.TypeConverter.StrToInt(group1.ToString());
                //  intShuLi = Basic.TypeConverter.StrToInt(group2.ToString());
                //  intKongJianPanDuan = Basic.TypeConverter.StrToInt(group3.ToString());
                //  intChaJueXiJie = Basic.TypeConverter.StrToInt(group4.ToString());
                //  intShuXie = Basic.TypeConverter.StrToInt(group5.ToString());
                //  intYunDongXieTiao = Basic.TypeConverter.StrToInt(group6.ToString());
                //  intDongShou = Basic.TypeConverter.StrToInt(group7.ToString());
                //  intSheHuiJiaoWang = Basic.TypeConverter.StrToInt(group8.ToString());
                //  intZuZhiGuanLi = Basic.TypeConverter.StrToInt(group9.ToString());

                //  //创建数组，通过冒泡排序得到最大值和最小值
                //  list = new int[] { intYanYu, intShuLi, intKongJianPanDuan, intChaJueXiJie, intShuXie, intYunDongXieTiao, intDongShou, intSheHuiJiaoWang, intZuZhiGuanLi };
                //  DAL.Comm.BubbleSortUp(list);
                //  intMax = list[8];//最大值
                //  intMin = list[0];//最小值

                //  //生成word报告文档
                ////  ExpWordByWord();

                #endregion

                //查看测评报告
                //跳转到测评结果页
                if (Request.QueryString["Zy"] != null && Request.QueryString["Zy"] == "true")
                {
                    Response.Redirect("../Ability/ProfessionTest.aspx?Zy=true");
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
        void Calculate(string type)
        {
            //计分
            // float point = (1 * sl1 + 2 * sl2 + 3 * sl3 + 4 * sl4 + 5 * sl5)/5;
            float point = (5 * sl1 + 4 * sl2 + 3 * sl3 + 2 * sl4 + 1 * sl5) / 5;

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
                default:
                    break;
            }

            sl1 = 0;
            sl2 = 0;
            sl3 = 0;
            sl4 = 0;
            sl5 = 0;

        }

        #endregion


    }
}