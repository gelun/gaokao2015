using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GaoKao.ChaXun
{
    public partial class cwc : Base
    {
        public int glFenShu = 0;
        public string strHighCharts = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            glFenShu = Basic.RequestHelper.GetQueryInt("fs", 0);

            DataTable dt = DAL.ProvinceWeiCi.ProvinceWeiCiGetByFenShuList(glFenShu, userinfo.ProvinceId, userinfo.KeLei);
            rpt_List.DataSource = dt;
            rpt_List.DataBind();

            DataView dv = dt.DefaultView;
            dv.Sort = "DataYear ASC";

            DataTable dt2 = dv.ToTable(true, new string[] { "DataYear", "WeiCi","LeiJiRenShu" });
            strHighCharts = Basic.HighCharts.CreatHighChartsFromDT("duibitu", "column", "", "分数", "|位次|累计人数", dt2);

        }
    }
}