using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GaoKao.ChaXun
{
    public partial class skx : Base
    {
        public string strHighCharts = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            DataTable dt = DAL.FenShuXian.FenShuXianList("DataYear,PcFirst,PcSecond,PcThird,ZkFirst,ZkSecond", " ProvinceId = " + userinfo.ProvinceId + " AND KeLei = " + userinfo.KeLei + " Order by DataYear DESC;");
            rpt_List.DataSource = dt;
            rpt_List.DataBind();

            DataView dv = dt.DefaultView;
            dv.Sort = "DataYear Asc";
            DataTable dt2 = dv.ToTable();

            if (userinfo.ProvinceId != 11)
            {
                strHighCharts = Basic.HighCharts.CreatHighChartsFromDT("duibitu", "spline", userinfo.ProvinceName + userinfo.KeLeiMingCheng + "历年省控线对比图", "分数", "|一本线|二本线|三本线|一专线|二专线", dt2);
            }
            else
            {
                strHighCharts = Basic.HighCharts.CreatHighChartsFromZheJiangDT("duibitu", "spline", userinfo.ProvinceName + userinfo.KeLeiMingCheng + "历年省控线对比图", "分数", "|一批次线|二批次线|三批次线", dt2);
            }
        }
    }
}