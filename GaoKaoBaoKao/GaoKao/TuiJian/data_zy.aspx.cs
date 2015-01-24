using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GaoKao.TuiJian
{
    public partial class data_zy : BaseTuiJian
    {
        public string strHighCharts = "", strPageTitle = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            int SchoolId = Basic.RequestHelper.GetQueryInt("schoolid", 0);
            int PiCi = Basic.RequestHelper.GetQueryInt("pici", 0);
            int ZyId = Basic.RequestHelper.GetQueryInt("zyid", 0);
            int PcLeiBie = Basic.RequestHelper.GetQueryInt("pcleibie", 0);

            Entity.School school = DAL.School.SchoolEntityGet(SchoolId);
            if (ZyId == 0)
                return;
            Entity.Professional zhuanye = DAL.Professional.ProfessionalEntityGet(ZyId);
            
            strPageTitle = school.SchoolName + " " + zhuanye.ProfessionalName + "专业 <span>" + userinfo.ProvinceName + " " + userinfo.KeLeiMingCheng + " " + DAL.Common.GetPiCiName(PiCi,userinfo.ProvinceId) + DAL.Common.GetPcLeiBieMingCheng(PcLeiBie) + "</span>的历年录取情况";

            DataTable dt = DAL.FenShengZhuanYeLuQu.FenShengZhuanYeLuQuList("SchoolId = " + SchoolId + " AND ZyId = " + ZyId + " AND PiCi = " + PiCi + " AND PcLeiBie = " + PcLeiBie + " AND ProvinceId = " + userinfo.ProvinceId + " AND KeLei = " + userinfo.KeLei + " ORDER BY DataYear DESC",userinfo.ProvinceId, "All");
            rpt_List.DataSource = dt;
            rpt_List.DataBind();


            int XianCha = 0;
            if (userinfo.ProvinceId == 11)
            {
                XianCha = DAL.CommonTuiJian.GetUserPiCiXianCha(fenshuxian, history.FenShu, (PiCi == 0 ? 1 : PiCi));
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

            DataTable dt2 = dv.ToTable(true, new string[] { "DataYear", "zyZuiXiaoWeiCi", "zyPingJunWeiCi", "zyZuiDaWeiCi", "StudentWeiCi" });
            strHighCharts += Basic.HighCharts.CreatHighChartsFromDT("weicicontainer", "spline", "", "分数", "|最小位次|平均位次|最大位次|您的位次", dt2);

            DataTable dt3 = dv.ToTable(true, new string[] { "DataYear", "zyPingJunXianCha", "StudentXianCha" });
            strHighCharts += Basic.HighCharts.CreatHighChartsFromDT("xianchacontainer", "column", "", "分数", "|平均线差|您的线差", dt3);

            DataTable dt4 = dv.ToTable(true, new string[] { "DataYear", "zyZuiGaoFen", "zyPingJunFen", "zyZuiDiFen", "StudentFenShu" });
            strHighCharts += Basic.HighCharts.CreatHighChartsFromDT("fenshucontainer", "spline", "", "分数", "|最高分|平均分|最低分|您的分数", dt4);
        }
    }
}