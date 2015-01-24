using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace GaoKao.SchoolLibrary
{
    /// <summary>
    /// getZYFenShuXian 的摘要说明
    /// </summary>
    public class getZYFenShuXian : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            int intYear = Basic.RequestHelper.GetFormInt("year", 0);
            int intProvinceId = Basic.RequestHelper.GetFormInt("provinceid", 0);
            int intKeLei = Basic.RequestHelper.GetFormInt("kelei", 0);
           // int intPiCi = Basic.RequestHelper.GetFormInt("pici", 0);
            int intSchoolId = Basic.RequestHelper.GetFormInt("schoolid", 0);

            string strHtml = "";

            string strWhere = " ZYLQ.DataYear = " + intYear + " AND ZYLQ.KeLei = " + intKeLei + " AND ZYLQ.ProvinceId = " + intProvinceId + " AND ZYLQ.SchoolId = " + intSchoolId;


            strHtml += "<table id=\"yxfsxtable\" width=\"970\" border=\"1\">";
            strHtml += "<tr><th width=\"100\">年份</th><th width=\"177\">专业名称</th><th width=\"138\">最高分</th><th width=\"138\">最低分</th><th width=\"139\">平均分</th>";
            strHtml += "<th width=\"139\">省控线</th><th width=\"139\">录取批次</th></tr>";

            DataTable dt = DAL.FenShengZhuanYeLuQu.FenShengZhuanYeLuQuALLList(strWhere, "All");
            if (dt != null && dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    strHtml += "<tr>"
                                    + "<td>" + dt.Rows[i]["DataYear"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["ZhuanYeMingCheng"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["ZyZuiGaoFen"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["ZyZuiDiFen"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["ZyPingJunFen"].ToString() + "</td>"
                                    + "<td>" + GetShengKongXian(dt.Rows[i]) + "</td>"
                                    + "<td>" + GetPiCiName(intProvinceId, dt.Rows[i]["PiCi"].ToString()) + "</td>"
                            + "</tr>";
                }
            }
            else
            {
                strHtml += "<tr><td colspan=\"7\">没有相关数据！！</td></tr>";
            }

            strHtml += "</table>";


            DataView dv = dt.DefaultView;
            dv.Sort = "DataYear Asc";

            DataTable dt2 = dv.ToTable(true, new string[] { "ZhuanYeMingCheng", "zyPingJunFen", "zyPingJunXianCha" });
            strHtml += Basic.HighCharts.CreatHighChartsFromDT("zyfsx_pic", "column", "", "分数", "|平均分|平均线差", dt2);

            context.Response.Write(strHtml);
        }

        string GetShengKongXian(DataRow dr)
        {
            string strPiCi = dr["PiCi"].ToString();
            switch (strPiCi)
            {
                case "1":
                    return dr["PcFirst"].ToString();
                case "2":
                    return dr["PcSecond"].ToString();
                case "3":
                    return dr["PcThird"].ToString();
                case "4":
                    return dr["ZkFirst"].ToString();
                case "5":
                    return dr["ZkSecond"].ToString();
                default:
                    return "-";
            }
        }

        string GetPiCiName(int intProvinceId, string strPiCi)
        {
            //switch (strPiCi)
            //{
            //    case "1":
            //        return "本科一批";
            //    case "2":
            //        return "本科二批";
            //    case "3":
            //        return "本科三批";
            //    case "4":
            //        return "专科一批";
            //    case "5":
            //        return "专科二批";
            //    default:
            //        return "-";
            //}
            DataTable dt = DAL.ProvincePiCi.ProvincePiCiList("ProvinceId = " + intProvinceId + " and PiCi = " + strPiCi);
            if (dt!=null&&dt.Rows.Count>0)
            {
                return dt.Rows[0]["PcName"].ToString();
            }
            else
            {
                return "-";
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}