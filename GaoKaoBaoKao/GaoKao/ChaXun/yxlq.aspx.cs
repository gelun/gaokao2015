using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GaoKao.ChaXun
{
    public partial class yxlq : Base
    {
        public string SchoolName = "", CengCiMingCheng = "", PiCiMingCheng = "";
        public string strHighCharts = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            //cc=" + $("#ddl_yxlqcc").val() + "&pc=" + $("#ddl_yxlqpc").val() + "&yx=
            int CengCi = Basic.RequestHelper.GetQueryInt("cc", 1);
            int PiCi = Basic.RequestHelper.GetQueryInt("pc", 1);
            SchoolName = Basic.RequestHelper.GetQueryString("yx");
            int SchoolId = 0;

            CengCiMingCheng = DAL.Common.GetCengCiMingCheng(CengCi);
            PiCiMingCheng = DAL.Common.GetPiCiName(PiCi,userinfo.ProvinceId);

            DataTable school = DAL.School.SchoolList("  SchoolName = '"+ SchoolName +"'");
            if (school.Rows.Count < 1)
                Basic.MsgHelper.AlertUrlMsg("学校名称不存在，请重新输入", "sjcx.aspx");
            else
                SchoolId = Basic.Utils.StrToInt(school.Rows[0]["Id"].ToString(), 0);

            //" CengCi = "+  +
            string strCondition = " CengCi = " + CengCi + " AND ProvinceId = " + userinfo.ProvinceId + " AND KeLei = " + userinfo.KeLei;
            strCondition += " AND PiCi = " + PiCi;
            strCondition += " AND SchoolId= " + SchoolId + " ORDER BY DataYear DESC";
            DataTable dt = DAL.FenShengYuanXiaoLuQu.FenShengYuanXiaoLuQuList(strCondition, userinfo.ProvinceId, "All");
            rpt_List.DataSource = dt;
            rpt_List.DataBind();


            DataView dv = dt.DefaultView;
            dv.Sort = "DataYear ASC";

            DataTable dt2 = dv.ToTable(true, new string[] { "DataYear", "PingJunFen", "PingJunXianCha" });
            strHighCharts = Basic.HighCharts.CreatHighChartsFromDT("duibitu", "spline", "", "分数", "|平均分|平均线差", dt2);
            
        }
    }
}