﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace GaoKao.CePing.ZhongKe
{

    
    public partial class Default :System.Web.UI.Page
    {
        protected int page = 1;   //当前页码
        protected int pageSize = 10; //当前页大小
        protected int sumPage = 1;//总共页数
        protected int recordNumber = 22;

        #region   学习力

        int group_BeiDong = 0;    //学习被动值
        int group_YanXue = 0;     //厌学度
        int group_XinXiCaiJi = 0; //生动类信息采集量
        int group_FangFa = 0;  //学习方法
        int group_BiJiao = 0; //学习比较性
        int group_ZiJian = 0;  //学习自检性
        int group_QuDao = 0; //学习参与渠道

        #endregion

        #region  生存力

        int group_FenXi = 0;   //分析力
        int group_ZiKong = 0;  //自控能力
        int group_GouTong = 0; //沟通能力
        int group_SiWei = 0;  //思维能力
        int group_ChengDan = 0; //责任承担能力


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
                 group_BeiDong = 0;    //学习被动值
                 group_YanXue = 0;     //厌学度
                 group_XinXiCaiJi = 0; //生动类信息采集量
                 group_FangFa = 0;  //学习方法
                 group_BiJiao = 0; //学习比较性
                 group_ZiJian = 0;  //学习自检性
                 group_QuDao = 0; //学习参与渠道



                   group_FenXi = 0;
                   group_ZiKong = 0;
                   group_GouTong = 0;
                   group_SiWei = 0;
                   group_ChengDan = 0;
            }
            else
            {

                if (Request.Cookies["zhongkeCook"] != null)
                {
                    if (Request.Cookies["zhongkeCook"]["group_BeiDong"] != null)
                    {
                        group_BeiDong = int.Parse(Request.Cookies["zhongkeCook"]["group_BeiDong"]);
                    }
                    if (Request.Cookies["zhongkeCook"]["group_YanXue"] != null)
                    {
                        group_YanXue = int.Parse(Request.Cookies["zhongkeCook"]["group_YanXue"]);
                    }

                    if (Request.Cookies["zhongkeCook"]["group_XinXiCaiJi"] != null)
                    {
                        group_XinXiCaiJi = int.Parse(Request.Cookies["zhongkeCook"]["group_XinXiCaiJi"]);
                    }
                    if (Request.Cookies["zhongkeCook"]["group_FangFa"] != null)
                    {
                        group_FangFa = int.Parse(Request.Cookies["zhongkeCook"]["group_FangFa"]);
                    }
                    if (Request.Cookies["zhongkeCook"]["group_BiJiao"] != null)
                    {
                        group_BiJiao = int.Parse(Request.Cookies["zhongkeCook"]["group_BiJiao"]);
                    }

                    if (Request.Cookies["zhongkeCook"]["group_ZiJian"] != null)
                    {
                        group_ZiJian = int.Parse(Request.Cookies["zhongkeCook"]["group_ZiJian"]);
                    }

                    if (Request.Cookies["zhongkeCook"]["group_QuDao"] != null)
                    {
                        group_QuDao = int.Parse(Request.Cookies["zhongkeCook"]["group_QuDao"]);
                    }

                     /****************************************************************************/

                    if (Request.Cookies["zhongkeCook"]["group_FenXi"] != null)
                    {
                        group_FenXi = int.Parse(Request.Cookies["zhongkeCook"]["group_FenXi"]);
                    }

                    if (Request.Cookies["zhongkeCook"]["group_ZiKong"] != null)
                    {
                        group_ZiKong = int.Parse(Request.Cookies["zhongkeCook"]["group_ZiKong"]);
                    }
                    if (Request.Cookies["zhongkeCook"]["group_GouTong"] != null)
                    {
                        group_GouTong = int.Parse(Request.Cookies["zhongkeCook"]["group_GouTong"]);
                    }

                    if (Request.Cookies["zhongkeCook"]["group_SiWei"] != null)
                    {
                        group_SiWei = int.Parse(Request.Cookies["zhongkeCook"]["group_SiWei"]);
                    }

                    if (Request.Cookies["zhongkeCook"]["group_ChengDan"] != null)
                    {
                        group_ChengDan = int.Parse(Request.Cookies["zhongkeCook"]["group_ChengDan"]);
                    }
                }
                else
                {
                    page = 1;

               
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


            DataTable dt;
            

                dt = DAL.Join_ZhongKeTest.Join_ZhongKeTestPageList(" [TestNumber]<=22 ", pageSize, page);
          

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

                HiddenField hd = (HiddenField)ri.FindControl("hdType");

                hdtype = hd.Value;

                RadioButtonList cbl = (RadioButtonList)ri.FindControl("rdb_Check");
                if (cbl.SelectedIndex >= 0)
                {
                    
                    Calculate(hdtype,int.Parse(cbl.SelectedValue));
                 
                    //统计分数
                }

            }

          

            #endregion

            #region   记录分数到Cookie里


            HttpCookie myCook = new HttpCookie("zhongkeCook");

            myCook.Values["group_BeiDong"] = group_BeiDong.ToString() ;    //学习被动值
            myCook.Values["group_YanXue"] = group_YanXue.ToString();     //厌学度
            myCook.Values["group_XinXiCaiJi"] = group_XinXiCaiJi.ToString(); //生动类信息采集量
            myCook.Values["group_FangFa"] = group_FangFa.ToString();  //学习方法
            myCook.Values["group_BiJiao"] = group_BiJiao.ToString(); //学习比较性
            myCook.Values["group_ZiJian"] = group_ZiJian.ToString();  //学习自检性
            myCook.Values["group_QuDao"] = group_QuDao.ToString(); //学习参与渠道


            myCook.Values["group_FenXi"] = group_FenXi.ToString(); // 
            myCook.Values["group_ZiKong"] = group_ZiKong.ToString(); // 
            myCook.Values["group_GouTong"] = group_GouTong.ToString(); // 
            myCook.Values["group_SiWei"] = group_SiWei.ToString(); // 
            myCook.Values["group_ChengDan"] = group_ChengDan.ToString(); // 

            Response.Cookies.Add(myCook);
            #endregion

            #region   设计下一页数据

            if (page == sumPage)
            {

                Server.Transfer("Ttarget.aspx?ty=xxl"); //301跳转

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
        void Calculate(string type, int fen)
        {
            //解析该题所属类型
            string[] tAr = type.Split(',');
            foreach (string st in tAr)
            {

                //判断属于那一组，让该组总值加上分数
                switch (st)
                {
                    case "1":
                        group_BeiDong += fen;
                        break;
                    case "2":
                        group_YanXue += fen;
                        break;
                    case "3":
                        group_XinXiCaiJi += fen;
                        break;
                    case "4":
                        group_FangFa += fen;
                        break;
                    case "5":
                        group_BiJiao += fen;
                        break;
                    case "6":
                        group_ZiJian += fen;
                        break;
                    case "7":
                        group_QuDao += fen;
                        break;

                    case "8":
                        group_FenXi += fen;
                        break;
                    case "9":
                        group_ZiKong += fen;
                        break;
                    case "10":
                        group_GouTong += fen;
                        break;
                    case "11":
                        group_SiWei += fen;
                        break;
                    case "12":
                        group_ChengDan += fen;
                        break;

                    case "-8":
                        group_FenXi -= fen;
                        break;
                    case "-9":
                        group_ZiKong -= fen;
                        break;
                    case "-10":
                        group_GouTong -= fen;
                        break;
                    case "-11":
                        group_SiWei -= fen;
                        break;
                    case "-12":
                        group_ChengDan -= fen;
                        break;


                }
            }
        }

        #endregion

    }
}