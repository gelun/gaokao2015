using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace GaoKao.CePing.ZhiYeMao
{


    /// <summary>
    /// 算法描述：
    /// 
    /// </summary>
    public partial class Default : UserBase
    {
        //页码
        protected int page = 1;

        //总页码

        protected int countPage = 0;

        //页大小
        protected int pagesize = 10;

        protected int count = 40;

        #region
        //题目索引对应
        string tsl = "";//存放每题选择的结果使用英文逗号分隔
        string tgp = ""; //存放每题所属归组，使用英文逗号分隔
        

 
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
                if (Request.Cookies["tesZhiYeMaotCook"] != null)
                {
                    HttpCookie myCook = new HttpCookie("tesZhiYeMaotCook");
                    Response.Cookies.Add(myCook);
                    tsl = "";
                    tgp = "";
                }

            }
            else
            {
                #region  设置值

                if (Request.Cookies["tesZhiYeMaotCook"] != null)
                {

                    tsl = Request.Cookies["tesZhiYeMaotCook"]["tsl"];
                    tgp =  Request.Cookies["tesZhiYeMaotCook"]["tgp"];

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
            DataTable dt = DAL.Join_ZhiYeMaoTest.Join_ZhiYeMaoTestPageList(" ", pagesize, this.page);
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
                        SetTrait(li.Value.ToLower(), hid.Value);
                    }
                }



            }


            HttpCookie myCook = new HttpCookie("tesZhiYeMaotCook");


            myCook.Values["tsl"] = tsl;
            myCook.Values["tgp"] = tgp;
         


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
                //拆分数据得到最高分的三条记录
                //取索引
                int[] indexAr = new int[3];

                string[] tslAr = tsl.Split(',');
                for (int i = 0; i < tslAr.Length; i++)
                {
                    if(tslAr[i]!=""){
                        int sl = int.Parse(tslAr[i]);
                        for(int m=0;m<3;m++){
                            if (indexAr[m] == 0)
                            {
                                //取出当前索引
                                indexAr[m] = i;
                            }
                            else
                            {
                               //对比当前索引的值大大小
                                if(int.Parse(tslAr[i])>int.Parse(tslAr[indexAr[m]])){
                                     //得到大的就将索引插到其 m前,其他数据后移动，否则对比下一个
                                    for (int n = 2; n > m; n--)
                                    {
                                      //数据后移
                                        indexAr[n] = indexAr[n - 1];
                                    }
                                    indexAr[m] = i;
                                }
                            }
                        }
                    }
                }

                //indexAr索引处的tslAr数据加4
                for (int i = 0; i < 3; i++)
                {
                    tslAr[indexAr[i]] = (int.Parse(tslAr[indexAr[i]])+4).ToString();
                }
                tsl = "";
                for (int i = 0; i < tslAr.Length; i++)
                {
                    tsl += tslAr[i];
                }

                Server.Transfer("Ttarget.aspx"); //301跳转
            }

        }
        #endregion


        #region  测评



        /// <summary>
        ///存储两个字符串对象
        ///一个用于存放题目选择结果
        ///一个用于存放题目归组
        ///题目标题和索引一一对应
        /// </summary>
        /// <param name="option">选项</param>
        /// <param name="type">归组</param>
        void SetTrait(string option, string type)
        {
            tsl += option + ",";
            tgp += type+",";
        }

        #endregion

    }
}