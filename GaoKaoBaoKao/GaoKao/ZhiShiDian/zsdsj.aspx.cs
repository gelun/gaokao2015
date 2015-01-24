using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace GaoKao.CePing.ZhiShiDian
{
    public partial class zsdsj : Base
    {
        protected int intKL = 0;
        protected string strList = "";
        protected int TiMuList = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            Bind();
        }

        void Bind()
        {
            intKL = Basic.RequestHelper.GetQueryInt("kl", 0);
            strList = Basic.RequestHelper.GetQueryString("zsdlist");
            //面包屑
            Crumb1.NavString = " <span>&gt;</span> <a href=\"/zhishidian/ZhiShiDianCPList.aspx\">知识点检测</a> <span>&gt;</span> 高中知识点 <span>&gt;</span> " + DAL.Common.GetGaoKaoZhenTiKeMuName(intKL + 1);

            string[] arrZhiShiDian = strList.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            if (arrZhiShiDian.Length > 0)
            {
                DataTable dtTiMu = new DataTable();
                DataColumn dc = null;
                dc = dtTiMu.Columns.Add("RowNum", Type.GetType("System.Int32"));
                dc.AutoIncrement = true;//自动增加
                dc.AutoIncrementSeed = 1;//起始为1
                dc.AutoIncrementStep = 1;//步长为1
                dc.AllowDBNull = false;//

                dc = dtTiMu.Columns.Add("gid", Type.GetType("System.String"));
                dc = dtTiMu.Columns.Add("difficulty", Type.GetType("System.String"));
                dc = dtTiMu.Columns.Add("score", Type.GetType("System.String"));
                dc = dtTiMu.Columns.Add("content", Type.GetType("System.String"));
                dc = dtTiMu.Columns.Add("answer", Type.GetType("System.String"));
                dc = dtTiMu.Columns.Add("objective_answer", Type.GetType("System.String"));

                DataRow newRow;

                for (int i = 0; i < arrZhiShiDian.Length; i++)
                {
                    if (i < 3)//为了防止有人  人为的在url地址栏中输入多个的话，程序中要求最多使用三个
                    {
                        DataTable dt = DAL.TengXB.ZhiShiDian.ShiTiList(DAL.Common.GetGaoKaoZhenTiTableName(intKL + 1), Basic.TypeConverter.StrToInt(arrZhiShiDian[i], 0));
                        if (dt != null && dt.Rows.Count > 0)
                        {
                            //声明数组存储rowid
                            int[] arrRowId = new int[dt.Rows.Count];
                            for (int j = 0; j < arrRowId.Length; j++)
                            {
                                arrRowId[j] = j;
                            }

                            int length = 5;
                            if (dt.Rows.Count < 5)
                            {
                                length = dt.Rows.Count;
                            }

                            //
                            int randValue = -1;
                            Random rand = new Random(unchecked((int)DateTime.Now.Ticks));
                            for (int j = 0; j < length; j++)
                            {
                                if (arrRowId.Length >= 1)//在数组arrRowId有数据的时候采取循环，不然会报错的
                                {
                                    if (arrRowId.Length == 1)
                                    {
                                        randValue = 0;
                                    }
                                    else
                                    {
                                        randValue = rand.Next(0, arrRowId.Length - 1);//随机获取一个值
                                    }

                                    //添加新行
                                    newRow = dtTiMu.NewRow();
                                    if (dtTiMu == null)
                                    {
                                        newRow["RowNum"] = 1;
                                    }
                                    else
                                    {
                                        newRow["RowNum"] = dtTiMu.Rows.Count + 1;
                                    }
                                    newRow["gid"] = dt.Rows[arrRowId[randValue]]["gid"].ToString();//arrRowId[randValue];// dt.Rows[0]["gid"].ToString();
                                    newRow["difficulty"] = dt.Rows[arrRowId[randValue]]["difficulty"].ToString();
                                    newRow["score"] = dt.Rows[arrRowId[randValue]]["score"].ToString();
                                    newRow["content"] = dt.Rows[arrRowId[randValue]]["content"].ToString();
                                    newRow["answer"] = dt.Rows[arrRowId[randValue]]["answer"].ToString();
                                    newRow["objective_answer"] = dt.Rows[arrRowId[randValue]]["objective_answer"].ToString();

                                    dtTiMu.Rows.Add(newRow);

                                    //删除已经被选中的元素
                                    List<int> list = arrRowId.ToList();
                                    list.RemoveAt(randValue);
                                    arrRowId = list.ToArray();
                                }
                            }
                        }
                        else
                        {
                          //  Basic.MsgHelper.AlertUrlMsg("该知识点下暂无题目", "ZhiShiDianCPList.aspx");
                        }
                    }
                    else
                    {
                        break;
                    }
                }

                if (dtTiMu != null && dtTiMu.Rows.Count > 0)
                {

                    //题号
                    TiMuList = dtTiMu.Rows.Count;
                    for (int i = 1; i <= TiMuList; i++)
                    {
                        if (i == 15)
                        {
                            ltlTiMu.Text += "<li style=\"width: 78px; border-right: 0;\"><a href=\"javascript:;\">" + i + "</a></li>";
                        }
                        else if (i == 1)
                        {
                            ltlTiMu.Text += "<li class=\"cur\"><a href=\"javascript:;\">" + i + "</a></li>";
                        }
                        else
                        {
                            ltlTiMu.Text += "<li><a href=\"javascript:;\">" + i + "</a></li>";
                        }
                    }
                    //绑定题目
                    rptList.DataSource = dtTiMu;
                    rptList.DataBind();

                    ltlTime.Text = (TiMuList * 3).ToString();
                }
                else
                {
                    Basic.MsgHelper.AlertUrlMsg("暂无题目", "ZhiShiDianCPList.aspx");
                }
            }
        }

        protected void rptList_OnItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Literal ltlNextTiMu = (Literal)e.Item.FindControl("ltlNextTiMu");
                if (e.Item.ItemIndex + 1 < TiMuList)
                {
                    ltlNextTiMu.Text = "下一题";
                }
                else
                {
                    ltlNextTiMu.Text = "最后一题";
                }

            }
        }
    }
}