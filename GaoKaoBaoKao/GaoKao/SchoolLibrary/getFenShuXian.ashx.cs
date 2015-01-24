using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace GaoKao.SchoolLibrary
{
    /// <summary>
    /// getFenShuXian 的摘要说明
    /// </summary>
    public class getFenShuXian : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";

            int intProvinceId = Basic.RequestHelper.GetFormInt("provinceid", 0);
            int intKeLei = Basic.RequestHelper.GetFormInt("kelei", 0);
       //     int intPiCi = Basic.RequestHelper.GetFormInt("pici", 0);
            int intSchoolId = Basic.RequestHelper.GetFormInt("schoolid", 0);

            string strHtml = "";
            //string strWhere = " YXLQ.KeLei = " + intKeLei + " AND YXLQ.ProvinceId = " + intProvinceId + " AND YXLQ.PiCi = " + intPiCi + " AND YXLQ.SchoolId = " + intSchoolId;
            //DataTable dt = DAL.TengXB.FenShengYuanXiaoLuQu.FenShengYuanXiaoLuQuList(strWhere);

            string strWhere = " KeLei = " + intKeLei + " AND ProvinceId = " + intProvinceId + " AND SchoolId = " + intSchoolId + " ORDER BY DataYear DESC ";
            DataTable dt = DAL.FenShengYuanXiaoLuQu.FenShengYuanXiaoLuQuList(strWhere, intProvinceId, "All");

            strHtml += "<table id=\"yxfsxtable\" width=\"970\" border=\"1\">";
            strHtml += "<tr><th width=\"138\">年份</th><th width=\"138\">最高分</th><th width=\"138\">最低分</th><th width=\"139\">平均分</th>";
            strHtml += "<th width=\"139\">省控线</th><th width=\"139\">线差</th><th width=\"139\">录取批次</th></tr>";

            if (dt != null && dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    strHtml += "<tr>"
                                    + "<td>" + dt.Rows[i]["DataYear"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["ZuiGaoFen"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["ZuiDiFen"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["PingJunFen"].ToString() + "</td>"
                                    + "<td>" + dt.Rows[i]["PiCiXian"].ToString() + "</td>"
                        //+ "<td>" + GetShengKongXian(dt.Rows[i]) + "</td>"
                                    + "<td>" + dt.Rows[i]["PingJunXianCha"].ToString() + "</td>"
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

            DataTable dt2 = dv.ToTable(true, new string[] { "DataYear", "PingJunFen", "PingJunXianCha" });
            strHtml += Basic.HighCharts.CreatHighChartsFromDT("yxfsx_pic", "spline", "", "分数", "|平均分|平均线差", dt2);

            //
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
            if (dt != null && dt.Rows.Count > 0)
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