using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GaoKao.ChaXun
{
    public partial class zyqx : Base
    {
        public int gl_Lx = 0;
        public string CengCiMingCheng = "", PiCiMingCheng = "", strTypeTitle = "";
        public string strHighCharts = "";
        public int DataYear = 2013;
        public int FenShu1 = 0, FenShu2 = 0, XianCha = 0, WeiCi = 0, PiCi = 0;
        protected string strWhere = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            gl_Lx = Basic.RequestHelper.GetQueryInt("lx", 0);
            int CengCi = Basic.RequestHelper.GetQueryInt("cc", 1);
            PiCi = Basic.RequestHelper.GetQueryInt("pc", 1);
            DataYear = Basic.RequestHelper.GetQueryInt("nf", 2013);

            CengCiMingCheng = DAL.Common.GetCengCiMingCheng(CengCi);
            PiCiMingCheng = DAL.Common.GetPiCiName(PiCi,userinfo.ProvinceId);
            FenShu1 = Basic.RequestHelper.GetQueryInt("fs1", 0);
            FenShu2 = Basic.RequestHelper.GetQueryInt("fs2", 0);
            XianCha = Basic.RequestHelper.GetQueryInt("xc", 0);
            WeiCi = Basic.RequestHelper.GetQueryInt("wc", 0);

            strWhere = " ProvinceId = " + userinfo.ProvinceId + " AND KeLei = " + userinfo.KeLei + " AND PiCi = " + PiCi;
            if (gl_Lx == 0)
            {
                if (FenShu1 <= FenShu2)
                {
                    strWhere = strWhere + " AND FenShu >= " + FenShu1 + " AND FenShu <= " + FenShu2;
                    strTypeTitle = FenShu1 + " 到 " + FenShu2 + "分数区间";
                }
                else
                {
                    strWhere = strWhere + " AND FenShu >= " + FenShu2 + " AND FenShu <= " + FenShu1;
                    strTypeTitle = FenShu2 + "到" + FenShu1 + "分数区间";
                }
            }
            else if (gl_Lx == 1)
            {
                strWhere = strWhere + " AND PiCiXianCha = " + XianCha;
                strTypeTitle = "线差" + XianCha;
            }
            else if (gl_Lx == 2)
            {
                int intFenShu = 0;
                DataTable dt2 = DAL.ProvinceWeiCi.ProvinceFenShuGetByWeiCi(WeiCi, DataYear, userinfo.ProvinceId, userinfo.KeLei);
                if (dt2.Rows.Count == 1)
                    intFenShu = Basic.Utils.StrToInt(dt2.Rows[0]["FenShu"].ToString(), 0);
                strWhere = strWhere + " AND FenShu = " + intFenShu;
                strTypeTitle = "位次" + WeiCi;
            }

            DataTable dt = DAL.BenKeFenShu.BenKeFenShuList(" TOP 100 * ", strWhere, DataYear.ToString());
            rpt_List.DataSource = dt;
            rpt_List.DataBind();


            DataView dv = dt.DefaultView;
            dv.Sort = "DataYear ASC";

            DataTable dtSchoolProvince = DAL.BenKeFenShu.BenKeFenShuList(" TOP 20 SchoolProvinceName,Count(*) AS SchoolCount ", strWhere + " GROUP BY SchoolProvinceName ORDER BY SchoolCount DESC;", DataYear.ToString());
            DataTable dtSchool = DAL.BenKeFenShu.BenKeFenShuList(" TOP 20 ZhuanYeMingCheng,Count(*) AS SchoolCount ", strWhere + " GROUP BY ZhuanYeMingCheng ORDER BY SchoolCount DESC;", DataYear.ToString());

            strHighCharts = strHighCharts + Basic.HighCharts.CreatHighChartsPie3DFromDT("dqtjt", "", "专业去向比例", dtSchoolProvince);
            strHighCharts = strHighCharts + Basic.HighCharts.CreatHighChartsPie3DFromDT("yxtjt", "", "专业去向比例", dtSchool);

        }

        protected void rpt_List_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
            {
                Literal lit_SchoolId = e.Item.FindControl("lit_SchoolId") as Literal;
                Literal lit_ZongRenShu = e.Item.FindControl("lit_ZongRenShu") as Literal;
                Literal lit_QuJianZongRenShu = e.Item.FindControl("lit_QuJianZongRenShu") as Literal;

                int intSchoolId = Basic.Utils.StrToInt(lit_SchoolId.Text, 0);
                Entity.FenShengYuanXiaoLuQu FenShengYuanXiaoLuQu = DAL.FenShengYuanXiaoLuQu.FenShengYuanXiaoLuQuAllEntityGet(userinfo.ProvinceId, PiCi, userinfo.KeLei, intSchoolId, DataYear.ToString());
                lit_ZongRenShu.Text = FenShengYuanXiaoLuQu.LuQuShu.ToString();

                int intQuJianZongRenShu = DAL.BenKeFenShu.BenKeFenShuCount(strWhere + " AND SchoolId = " + intSchoolId, DataYear.ToString());
                lit_QuJianZongRenShu.Text = intQuJianZongRenShu.ToString();

            }
        }
    }
}