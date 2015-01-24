using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace GaoKao.CePing.ZhiShiDian
{
    public partial class JieGuo : Base
    {
        protected int intKL = 0;
        protected string strList = "";
        protected string strstlist = "";
        protected int TiMuList = 0;

        protected int intRightCount = 0;
        protected int intWrongCount = 0;
        protected int intWeiDaCount = 0;


        DataTable dtTiMu = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {

            DataColumn dc = null;
            //创建列
            //自增列
            dc = dtTiMu.Columns.Add("RowNum", Type.GetType("System.Int32"));
            dc.AutoIncrement = true;//自动增加
            dc.AutoIncrementSeed = 1;//起始为1
            dc.AutoIncrementStep = 1;//步长为1
            dc.AllowDBNull = false;//
            //
            dc = dtTiMu.Columns.Add("zsdId", Type.GetType("System.Int32"));
            dc = dtTiMu.Columns.Add("TiMuId", Type.GetType("System.Int32"));
            dc = dtTiMu.Columns.Add("gid", Type.GetType("System.String"));
            dc = dtTiMu.Columns.Add("difficulty", Type.GetType("System.String"));
            dc = dtTiMu.Columns.Add("score", Type.GetType("System.String"));
            dc = dtTiMu.Columns.Add("content", Type.GetType("System.String"));
            dc = dtTiMu.Columns.Add("answer", Type.GetType("System.String"));
            dc = dtTiMu.Columns.Add("objective_answer", Type.GetType("System.String"));
            dc = dtTiMu.Columns.Add("your_answer", Type.GetType("System.String"));



            Bind();
        }

        void Bind()
        {
            intKL = Basic.RequestHelper.GetQueryInt("kl", 0);
            strList = Basic.RequestHelper.GetQueryString("zsdlist");

            //面包屑
            Crumb1.NavString = " <span>&gt;</span> <a href=\"/zhishidian/ZhiShiDianCPList.aspx\">知识点检测</a> <span>&gt;</span> 高中知识点 <span>&gt;</span> " + DAL.Common.GetGaoKaoZhenTiKeMuName(intKL + 1) + " <span>&gt;</span> 检测结果";


            string strZhiShiDianList = "";
            string[] arrZhiShiDian = strList.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            if (arrZhiShiDian.Length > 0)
            {

                #region 绑定题目  为什么先绑定题目后绑定知识点呢？因为在绑定知识点的时候需要判定知识点的掌握程度，这时候需要知道做对了多少；做错了多少；未做的有多少。


                #region 将当前用户做的题与答案的对应关系存入一个datatable中

                strstlist = Basic.RequestHelper.GetQueryString("stlist");
                string[] arrShiTi = strstlist.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                string strGidList = "";
                for (int i = 0; i < arrShiTi.Length; i++)
                {
                    //arrShiTi[i]  ykm10009877:C
                    string[] arr = arrShiTi[i].Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries);
                    if (arr.Length == 2)
                    {
                        strGidList += "'" + arr[0] + "',";
                    }
                    else
                    {
                        Basic.MsgHelper.AlertBackMsg("不合法的访问11");
                    }
                }
                if (strGidList.EndsWith(","))
                {
                    strGidList = strGidList.Substring(0, strGidList.Length - 1);
                }
                DataTable dt = DAL.TengXB.ZhiShiDian.ShiTiShowList(DAL.Common.GetGaoKaoZhenTiTableName(intKL + 1), strGidList);
                if (dt == null || dt.Rows.Count != arrShiTi.Length)
                {
                    Basic.MsgHelper.AlertBackMsg("不合法的访问");
                    return;
                }
                #region 创建一个新的DataTable，用来存储调取出来的试题


                DataRow newRow;
                int rn = 0;
                while (rn < dt.Rows.Count)
                {
                    newRow = dtTiMu.NewRow();
                    if (dtTiMu == null)
                    {
                        newRow["RowNum"] = 1;
                    }
                    else
                    {
                        newRow["RowNum"] = dtTiMu.Rows.Count + 1;
                    }
                    //arrShiTi[i]  ykm10009877:C
                    string[] arr = arrShiTi[rn].Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries);

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        if (dt.Rows[i]["gid"].ToString() == arr[0])
                        {
                            newRow["zsdId"] = dt.Rows[i]["zsdId"].ToString();
                            newRow["TiMuId"] = dt.Rows[i]["Id"].ToString();
                            newRow["gid"] = dt.Rows[i]["gid"].ToString();
                            newRow["difficulty"] = dt.Rows[i]["difficulty"].ToString();
                            newRow["score"] = dt.Rows[i]["score"].ToString();
                            newRow["content"] = dt.Rows[i]["content"].ToString();
                            newRow["answer"] = dt.Rows[i]["answer"].ToString();
                            newRow["objective_answer"] = dt.Rows[i]["objective_answer"].ToString();
                            newRow["your_answer"] = (arr[1] == "0" ? "" : arr[1]);
                            dtTiMu.Rows.Add(newRow);

                        }
                    }
                    rn++;
                }

                #endregion

                #endregion


                #region 判定并处理

                TiMuList = dtTiMu.Rows.Count;
                for (int i = 1; i <= TiMuList; i++)
                {
                    //知识点id
                    int zsdId = Basic.Utils.StrToInt(dtTiMu.Rows[(i - 1)]["zsdId"].ToString(), 0);
                    //题目id
                    int intTiMuId = Basic.Utils.StrToInt(dtTiMu.Rows[(i - 1)]["TiMuId"].ToString(), 0);
                    //正确答案
                    string objective_answer = dtTiMu.Rows[(i - 1)]["objective_answer"].ToString();
                    //你的答案
                    string your_answer = dtTiMu.Rows[(i - 1)]["your_answer"].ToString();

                    //判定并处理
                    if (objective_answer == your_answer)
                    {
                        intRightCount++;
                        ltlTiMu.Text += TiHao(i, 1);
                    }
                    else if (your_answer == "")
                    {
                        intWeiDaCount++;
                        ltlTiMu.Text += TiHao(i, 2);
                    }
                    else
                    {
                        intWrongCount++;
                        CuoTiBen(intTiMuId, your_answer, objective_answer);//计入错题本
                        ltlTiMu.Text += TiHao(i, 3);
                    }
                }
                if (TiMuList < 15)
                {
                    for (int i = 0; i < 15 - TiMuList; i++)
                    {

                        ltlTiMu.Text += "<li style=\"border-top: 1px solid #e8e8e8;border-bottom:none; " + (i == (15 - TiMuList) - 1 ? " width:78px;" : "") + "\"></li>";
                    }
                }

                #endregion


                //绑定题目
                rptList.DataSource = dtTiMu;
                rptList.DataBind();

                #endregion

                #region 知识点的处理

                ltlZhiShiDianCount.Text = arrZhiShiDian.Length.ToString();//知识点的个数

                #region 绑定测试的知识点
                for (int i = 0; i < arrZhiShiDian.Length; i++)
                {
                    strZhiShiDianList += arrZhiShiDian[i] + ",";
                }
                if (strZhiShiDianList.EndsWith(","))
                {
                    strZhiShiDianList = strZhiShiDianList.Substring(0, strZhiShiDianList.Length - 1);
                }
                DataTable dtZhiShiDian = DAL.TengXB.ZhiShiDian.GetZhiShiDianList(strZhiShiDianList);

                rptZhiShiDianList.DataSource = dtZhiShiDian;
                rptZhiShiDianList.DataBind();
                #endregion

                #endregion
            }
        }

        string TiHao(int i, int result)
        {
            switch (i)
            {
                case 1:
                    if (result == 1)//答对
                    {
                        return "<li class=\"cur green\"><a href=\"javascript:;\">" + i + "</a></li>";
                    }
                    else if (result == 2)//未答
                    {
                        return "<li class=\"cur\" style=\"border-top:2px solid #F8F8F8;\"><a href=\"javascript:;\">" + i + "</a></li>";
                    }
                    else//答错
                    {
                        return "<li class=\"cur\"><a href=\"javascript:;\">" + i + "</a></li>";
                    }
                case 15:
                    if (result == 1)//答对
                    {
                        return "<li class=\"green\" style=\"width: 78px;\"><a href=\"javascript:;\" style=\"border-right: 0; width: 78px;\">" + i + "</a></li>";
                    }
                    else if (result == 2)//未答
                    {
                        return "<li style=\"border-top:2px solid #F8F8F8;width: 78px;\"><a href=\"javascript:;\" style=\"border-right: 0; width: 78px;\">" + i + "</a></li>";
                    }
                    else//答错
                    {
                        return "<li style=\"width: 78px;\"><a href=\"javascript:;\" style=\"border-right: 0; width: 78px;\">" + i + "</a></li>";
                    }
                default:
                    if (result == 1)//答对
                    {
                        return "<li class=\"green\"><a href=\"javascript:;\">" + i + "</a></li>";
                    }
                    else if (result == 2)//未答
                    {
                        return "<li style=\"border-top:2px solid #F8F8F8;\"><a href=\"javascript:;\">" + i + "</a></li>";
                    }
                    else//答错
                    {
                        return "<li><a href=\"javascript:;\">" + i + "</a></li>";
                    }
            }
        }

        //计入错题本
        void CuoTiBen(int intTiMuId, string strAnswer, string objective_answer)
        {


            //如果错题本中没有该题目，添加该题目
            DataTable dtcuoti = DAL.cuotiben.cuotibenList("TiMuId = " + intTiMuId + " and Wid = " + userinfo.StudentId);
            if (dtcuoti == null || dtcuoti.Rows.Count == 0)
            {
                //添加
                Entity.cuotiben infost = new Entity.cuotiben();
                infost.TiMuId = intTiMuId;
                infost.Wid = userinfo.StudentId;
                infost.Answer = strAnswer;
                infost.RightAnswer = objective_answer;

                if (!(DAL.cuotiben.cuotibenAdd(infost) > 0))
                {
                    //有问题
                    Response.Write("<script>alert('错题存入错题本失败');</script>");
                }
            }
            else
            {
                //删除
                DAL.cuotiben.cuotibenDel(Basic.Utils.StrToInt(dtcuoti.Rows[0]["id"].ToString(), 0));
                //添加
                Entity.cuotiben infost = new Entity.cuotiben();
                infost.TiMuId = intTiMuId;
                infost.Wid = userinfo.StudentId;
                infost.Answer = strAnswer;
                infost.RightAnswer = objective_answer;


                if (!(DAL.cuotiben.cuotibenAdd(infost) > 0))
                {
                    //有问题
                    Response.Write("<script>alert('错题存入错题本失败');</script>");
                }
            }
        }

        protected void rptZhiShiDianList_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Repeater rptList = e.Item.FindControl("rptList") as Repeater;//找到里层的repeater对象
                DataRowView rowv = (DataRowView)e.Item.DataItem;//找到分类Repeater关联的数据项 
                int ZhenTiZSDId = Convert.ToInt32(rowv["Id"]); //获取填充子类的id 
                rptList.DataSource = DAL.TengXB.ZhiShiDian.ZhiShiDianRelationList("t1.ZhenTiZSDId = " + ZhenTiZSDId);
                rptList.DataBind();

                //判定掌握程度
                Literal ltlZhangWo = e.Item.FindControl("ltlZhangWo") as Literal;

                //全部没有做的话，未知;全对的话，优秀；全错的话，较差；有对有错的话，一般
                DataRow[] dr = dtTiMu.Select("zsdId=" + ZhenTiZSDId);
                int TMCount = dr.Length;
                int rightcount = 0;
                int wrongcount = 0;
                int weizhicount = 0;
                for (int i = 0; i < TMCount; i++)
                {
                    //正确答案
                    string _objective_answer = dr[i]["objective_answer"].ToString();
                    //你的答案
                    string _your_answer = dr[i]["your_answer"].ToString();

                    //判定并处理
                    if (_objective_answer == _your_answer)
                    {
                        rightcount++;
                    }
                    else if (_your_answer == "")
                    {
                        weizhicount++;
                    }
                    else
                    {
                        wrongcount++;
                    }
                }
                if (weizhicount == TMCount)
                {
                    ltlZhangWo.Text = "未知";
                }
                else
                {
                    if (rightcount==TMCount)
                    {
                        ltlZhangWo.Text = "优秀";
                    }
                    else
                    {
                        if (wrongcount==TMCount)
                        {
                            ltlZhangWo.Text = "较差";
                        }
                        else
                        {
                            ltlZhangWo.Text = "一般";
                        }
                    }
                }
            }
        }


        protected void rptList_OnItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Literal ltlDifficulty = (Literal)e.Item.FindControl("ltlDifficulty");
                Literal ltlDifficult = (Literal)e.Item.FindControl("ltlDifficult");
                int intDifficulty = Basic.TypeConverter.StrToInt(ltlDifficulty.Text, 0);
                if (intDifficulty == 1)
                {
                    ltlDifficult.Text = "<ul><li class=\"cur\">易</li><li>中</li><li>难</li></ul>";
                }
                else if (intDifficulty == 2 || intDifficulty == 3)
                {
                    ltlDifficult.Text = "<ul><li>易</li><li class=\"cur\">中</li><li>难</li></ul>";
                }
                else if (intDifficulty == 4 || intDifficulty == 5)
                {
                    ltlDifficult.Text = "<ul><li>易</li><li>中</li><li class=\"cur\">难</li></ul>";
                }
            }
        }
    }
}