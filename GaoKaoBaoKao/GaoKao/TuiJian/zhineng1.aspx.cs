using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;

namespace GaoKao.TuiJian
{
    public partial class zhineng1 : BaseTuiJian
    {
        public string strHighCharts = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (userinfo.ProvinceId==11)
            {
                //浙江
                Server.Transfer("zhineng1_ZheJiang.aspx");
            }

            Entity.ProvinceConfig pConfig = DAL.ProvinceConfig.ProvinceConfigEntityGet(userinfo.ProvinceId);
            DataTable dt = DAL.ProvincePiCi.ProvincePiCiList(" ProvinceId = " + userinfo.ProvinceId + " AND LeiBie =  1  ORDER BY ShowOrder ASC,Id ASC ");
            rpt_PiCiList.DataSource = dt;
            rpt_PiCiList.DataBind();

            //
            DataTable dt2 = DAL.FenShuXian.FenShuXianList("DataYear,PcFirst,PcSecond,PcThird,ZkFirst,ZkSecond", " ProvinceId = " + userinfo.ProvinceId + " AND KeLei = " + userinfo.KeLei + " Order by DataYear DESC;");

            DataView dv1 = dt2.DefaultView;
            dv1.Sort = "DataYear Asc";
            DataTable dt3 = dv1.ToTable();

            //給DataTable
            dt3.Columns.Add("StudentFenShu", typeof(int));
            foreach (DataRow dr in dt3.Rows)
                dr["StudentFenShu"] = studentChengJi.FenShu;

            //userinfo.ProvinceName + userinfo.KeLeiMingCheng + "历年省控线对比图"

            //浙江必须要显示为文理科一批，文理科二批
            if (userinfo.ProvinceId == 11)
            {
                DataView dvZJ = dt3.DefaultView;
                dvZJ.Sort = "DataYear ASC";
                DataTable dtZJ = dvZJ.ToTable(true, new string[] { "DataYear", "PcFirst", "PcSecond", "ZkFirst", "StudentFenShu" });
                strHighCharts = Basic.HighCharts.CreatHighChartsFromDT("duibitu1", "spline", "", "分数", "文理科一批|文理科二批|文理科三批|学生成绩", dtZJ);
            }
            else
                strHighCharts = Basic.HighCharts.CreatHighChartsFromDT("duibitu1", "spline", "", "分数", "一本线|二本线|三本线|一专线|二专线|学生成绩", dt3);


            DataTable dt4 = DAL.ProvinceWeiCi.ProvinceWeiCiGetByFenShuList(studentChengJi.FenShu, userinfo.ProvinceId, userinfo.KeLei);
            DataView dv2 = dt4.DefaultView;
            dv2.Sort = "DataYear ASC";
            DataTable dt5 = dv2.ToTable(true, new string[] { "DataYear", "WeiCi", "LeiJiRenShu" });
            strHighCharts += Basic.HighCharts.CreatHighChartsFromDT("duibitu2", "column", "", "人", "|位次|累计人数", dt5);

            lit_Suggesiton.Text = ShowTiShiXinXi(studentChengJi.PiCi);

        }

        protected void rpt_PiCiList_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            Literal PcId = e.Item.FindControl("lit_PcId") as Literal;
            Literal CkFsx = e.Item.FindControl("lit_CkFsx") as Literal;

            Literal LatestPiCiXianList = e.Item.FindControl("lit_LatestPiCiXianList") as Literal;
            Literal LatestPiCiXian = e.Item.FindControl("lit_LatestPiCiXian") as Literal;
            Panel Panel1 = e.Item.FindControl("Panel1") as Panel;
            Panel Panel2 = e.Item.FindControl("Panel2") as Panel;

            DataTable dtStudentZhiYuanList = DAL.StudentZhiYuan.StudentZhiYuanList("StudentId = " + userinfo.StudentId + " AND ProvincePcId = " + PcId.Text);
            if (dtStudentZhiYuanList.Rows.Count > 0)
            {
                //已经保存有部分志愿了
                Panel1.Visible = false;
                Panel2.Visible = true;

                Literal lit_ProvinceZhiYuan = e.Item.FindControl("lit_ProvinceZhiYuan") as Literal;
              //  lit_ProvinceZhiYuan.Text = DAL.CommonTuiJian.ShowStudentZhiYuanList(Basic.Utils.StrToInt(PcId.Text, 0), userinfo.StudentId);

                bool bmlist = true;
                for (int i = 0; i < dtStudentZhiYuanList.Rows.Count; i++)
                {
                    if (dtStudentZhiYuanList.Rows[i]["MajorList"].ToString()!="")
                    {
                        bmlist = false;//有一行不为空，就不能为空
                    }
                }
                //省份志愿
                lit_ProvinceZhiYuan.Text = DAL.CommonTuiJian.ShowStudentZhiYuanList(Basic.Utils.StrToInt(PcId.Text, 0), userinfo.StudentId, bmlist);


                //Repeater rpt_ProvinceZhiYuan = e.Item.FindControl("rpt_ProvinceZhiYuan") as Repeater;
                //rpt_ProvinceZhiYuan.DataSource = dtStudentZhiYuanList;
                //rpt_ProvinceZhiYuan.DataBind();
            }
            else
            {
                //没有保存志愿
                Panel1.Visible = true;
                Panel2.Visible = false;
                //下面开始输出各个年份的分数线
                LatestPiCiXianList.Text = GetPcCkFsx(userinfo.KeLei, userinfo.ProvinceId, Basic.Utils.StrToInt(CkFsx.Text, 0));
            }
        }

        private static string GetPcCkFsx(int KeLei, int ProvinceId, int CkFsx)
        {
            string strOut = "";
            DataTable dt = DAL.FenShuXian.FenShuXianTopGet(" KeLei = " + KeLei + " AND ProvinceId = " + ProvinceId + " ORDER BY DataYear DESC", 4);
            for (int i = 0; i < dt.Rows.Count; i++)
                if (CkFsx == 1)
                    strOut = strOut + "<li>" + dt.Rows[i]["DataYear"].ToString() + "年批次控制线为" + dt.Rows[i]["PcFirst"].ToString() + "分</li>\r\n";
                else if (CkFsx == 2)
                    strOut = strOut + "<li>" + dt.Rows[i]["DataYear"].ToString() + "年批次控制线为" + dt.Rows[i]["PcSecond"].ToString() + "分</li>\r\n";
                else if (CkFsx == 3)
                    strOut = strOut + "<li>" + dt.Rows[i]["DataYear"].ToString() + "年批次控制线为" + dt.Rows[i]["PcThird"].ToString() + "分</li>\r\n";
                else if (CkFsx == 4)
                    strOut = strOut + "<li>" + dt.Rows[i]["DataYear"].ToString() + "年批次控制线为" + dt.Rows[i]["ZkFirst"].ToString() + "分</li>\r\n";
                else if (CkFsx == 5)
                    strOut = strOut + "<li>" + dt.Rows[i]["DataYear"].ToString() + "年批次控制线为" + dt.Rows[i]["PcFirst"].ToString() + "分</li>\r\n";
                else
                    strOut = "";
            return strOut;
        }

        protected void rpt_ProvinceZhiYuan_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {

        }

        private static string ShowTiShiXinXi(int HeShiPiCi)
        {
            //批次录取提示
            StringBuilder strOut = new StringBuilder();
            strOut.Append("<p>建议您填报提前批次，增加投档录取机会。</p>\r\n");
            if (HeShiPiCi == 1)
            {
                strOut.Append("<p>本科第一批录取：<strong>是您最可能进入批次。</strong></p>\r\n");
                strOut.Append("<p>本科第二批录取：是您次要填报批次。</p>\r\n");
                strOut.Append("<p>本科第三批录取：虽然你落到这个批次的可能性不大。 我们仍然建议你填报。</p>\r\n");
            }
            else if (HeShiPiCi == 2)
            {
                strOut.Append("<p>本科第一批录取：对于您来说有些困难。</p>\r\n");
                strOut.Append("<p>本科第二批录取：<strong>是您最可能进入批次。</strong></p>\r\n");
                strOut.Append("<p>本科第三批录取：是您次要填报批次。</p>\r\n");
            }
            else if (HeShiPiCi == 3)
            {
                strOut.Append("<p>本科第一批录取：对于您来说有些困难。</p>\r\n");
                strOut.Append("<p>本科第二批录取：对于您来说有些困难。</p>\r\n");
                strOut.Append("<p>本科第三批录取：<strong>是您最可能进入批次。</strong></p>\r\n");
            }
            else
            {
                strOut.Append("<p>您的分数很难进入本科层次录取，建议您考虑专科提前批次及其他批次学校。</p>\r\n");
            }
            return strOut.ToString();
        }
    }
}