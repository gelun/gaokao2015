using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GaoKao.ChaXun
{
    public partial class zylq : Base
    {
        public string SchoolName = "", CengCiMingCheng = "", PiCiMingCheng = "";
        public string strHighCharts = "";
        public int DataYear = 2013;
        protected void Page_Load(object sender, EventArgs e)
        {
            //cc=" + $("#ddl_zylqcc").val() + "&pc=" + $("#ddl_zylqpc").val() + "&nf=" + $("#ddl_zylqnf").val() + "&yx=" + txtValue
            int CengCi = Basic.RequestHelper.GetQueryInt("cc", 1);
            int PiCi = Basic.RequestHelper.GetQueryInt("pc", 1);
            DataYear = Basic.RequestHelper.GetQueryInt("nf", 2013);
            SchoolName = Basic.RequestHelper.GetQueryString("yx");
            int SchoolId = 0;

            CengCiMingCheng = DAL.Common.GetCengCiMingCheng(CengCi);
            PiCiMingCheng = DAL.Common.GetPiCiName(PiCi,userinfo.ProvinceId);

            DataTable school = DAL.School.SchoolList("  SchoolName = '" + SchoolName + "'");
            if (school.Rows.Count < 1)
                Basic.MsgHelper.AlertUrlMsg("学校名称不存在，请重新输入","sjcx.aspx");
            else
                SchoolId = Basic.Utils.StrToInt(school.Rows[0]["Id"].ToString(), 0);

            //" CengCi = "+  +
            DataTable dt = DAL.FenShengZhuanYeLuQu.FenShengZhuanYeLuQuWithSchoolList(" CengCi = " + CengCi + " AND A.ProvinceId = " + userinfo.ProvinceId + " AND KeLei = " + userinfo.KeLei + " AND PiCi = " + PiCi + " AND SchoolId= " + SchoolId + " AND DataYear = " + DataYear + " ORDER BY DataYear DESC",userinfo.ProvinceId, "All");
            rpt_List.DataSource = dt;
            rpt_List.DataBind();


            DataView dv = dt.DefaultView;
            dv.Sort = "DataYear ASC";

            DataTable dt2 = dv.ToTable(true, new string[] { "ZhuanYeMingCheng", "zyPingJunFen", "zyPingJunXianCha" });
            strHighCharts = Basic.HighCharts.CreatHighChartsFromDT("duibitu", "column", "", "分数", "|平均分|平均线差", dt2);

        }
    }
}