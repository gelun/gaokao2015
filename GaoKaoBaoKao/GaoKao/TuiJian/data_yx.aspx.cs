using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GaoKao.TuiJian
{
    public partial class data_yx : BaseTuiJian
    {
        public string strHighCharts = "",strPageTitle = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            int SchoolId = Basic.RequestHelper.GetQueryInt("schoolid", 0);
            int PiCi = Basic.RequestHelper.GetQueryInt("pici", 0);
            int PcLeiBie = Basic.RequestHelper.GetQueryInt("pcleibie", 0);

            Entity.School school = DAL.School.SchoolEntityGet(SchoolId);
            strPageTitle = school.SchoolName + " " +"<span>" +  userinfo.ProvinceName + " " + userinfo.KeLeiMingCheng + " " + DAL.Common.GetPiCiName(PiCi,userinfo.ProvinceId) + DAL.Common.GetPcLeiBieMingCheng(PcLeiBie) + "</span>的历年录取情况";

            DataTable dt = DAL.FenShengYuanXiaoLuQu.FenShengYuanXiaoLuQuList("SchoolId = " + SchoolId + " AND ProvinceId = " + userinfo.ProvinceId + " AND PiCi = " + PiCi + " AND PcLeiBie = " + PcLeiBie + " AND KeLei = " + userinfo.KeLei + " ORDER BY DataYear DESC",userinfo.ProvinceId, "All");
            rpt_List.DataSource = dt;
            rpt_List.DataBind();



            int XianCha = 0;
            if (userinfo.ProvinceId == 11 && PiCi == 0)//浙江提前批的线差和一批次的线差一样
            {
                XianCha = DAL.CommonTuiJian.GetUserPiCiXianCha(fenshuxian, history.FenShu, 1);
            }
            else
            {
                XianCha = DAL.CommonTuiJian.GetUserPiCiXianCha(fenshuxian, history.FenShu, PiCi);
            }
            //給DataTable
            dt.Columns.Add("StudentWeiCi", typeof(int));
            dt.Columns.Add("StudentFenShu", typeof(int));
            dt.Columns.Add("StudentXianCha", typeof(int));
            foreach (DataRow dr in dt.Rows)
            {
                dr["StudentWeiCi"] = studentChengJi.WeiCi;
                dr["StudentFenShu"] = studentChengJi.FenShu;
                dr["StudentXianCha"] = XianCha;
            }
            


            //位次 线差 分数
            DataView dv = dt.DefaultView;
            dv.Sort = "DataYear ASC";

            DataTable dt2 = dv.ToTable(true, new string[] { "DataYear", "ZuiXiaoWeiCi", "PingJunWeiCi", "ZuiDaWeiCi", "StudentWeiCi" });
            strHighCharts += Basic.HighCharts.CreatHighChartsFromDT("weicicontainer", "spline", "", "分数", "|最小位次|平均位次|最大位次|您的位次", dt2);

            DataTable dt3 = dv.ToTable(true, new string[] { "DataYear", "PingJunXianCha", "StudentXianCha" });
            strHighCharts += Basic.HighCharts.CreatHighChartsFromDT("xianchacontainer", "column", "", "分数", "|平均线差|您的线差", dt3);

            DataTable dt4 = dv.ToTable(true, new string[] { "DataYear", "ZuiGaoFen", "PingJunFen", "ZuiDiFen", "StudentFenShu" });
            strHighCharts += Basic.HighCharts.CreatHighChartsFromDT("fenshucontainer", "spline", "", "分数", "|最高分|平均分|最低分|您的分数", dt4);
        }
    }
}