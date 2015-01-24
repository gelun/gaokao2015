using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace GaoKao.TuiJian
{
    public partial class zhineng2 : BaseTuiJian
    {
        protected int ProvincePiCiId = 0;
        public Entity.ProvincePiCi provincePiCi = new Entity.ProvincePiCi();

        protected int intZhiYuanCount = 0;//允许填报的志愿数
        protected DataTable dtProvinceZhiYuan = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (userinfo.ProvinceId == 11)
            {
                //浙江
                Server.Transfer("zhineng2_ZheJiang.aspx");
            }

            ProvincePiCiId = Basic.RequestHelper.GetQueryInt("pcid", 0);
            if (ProvincePiCiId > 0)
                provincePiCi = DAL.ProvincePiCi.ProvincePiCiEntityGet(ProvincePiCiId);
            //志愿相关信息
            dtProvinceZhiYuan = DAL.ProvinceZhiYuan.ProvinceZhiYuanList("IsPause = 0 AND ProvincePcId = " + ProvincePiCiId + " ORDER BY ShowOrder ASC");
            if (dtProvinceZhiYuan != null && dtProvinceZhiYuan.Rows.Count > 0)
            {
                intZhiYuanCount = dtProvinceZhiYuan.Rows.Count;
                for (int i = 0; i < intZhiYuanCount; i++)
                {
                    ltlZhiYuanList.Text += "<tr><td>" + GetZhiYuanMing(i) + "</td><td></td><td></td><td>" + GetSuggestion(i) + "</td></tr>";
                }
            }
            else
                Response.Redirect("zhineng1.aspx");

            string strSuggestion = "";
            for (int i = 0; i < dtProvinceZhiYuan.Rows.Count; i++)
                strSuggestion += "<p><strong>" + dtProvinceZhiYuan.Rows[i]["ZhiYuanMing"].ToString() + "</strong>" + dtProvinceZhiYuan.Rows[i]["Suggestion"].ToString() + "</p>";
            lit_Suggestion.Text = strSuggestion;
        }


        //获取志愿名称
        protected string GetZhiYuanMing(int intIndex)
        {
            //省份志愿表 实体对象
            if (dtProvinceZhiYuan != null && dtProvinceZhiYuan.Rows.Count > 0)
            {
                return dtProvinceZhiYuan.Rows[intIndex]["ZhiYuanMing"].ToString();//志愿名称
            }
            else
            {
                return "";
            }
        }

        //获取推荐风险
        protected string GetSuggestion(int intIndex)
        {
            //省份志愿表 实体对象
            if (dtProvinceZhiYuan != null && dtProvinceZhiYuan.Rows.Count > 0)
            {
                string strSuggestion = dtProvinceZhiYuan.Rows[intIndex]["Suggestion"].ToString();//推荐风险
                return strSuggestion;
            }
            else
            {
                return "";
            }
        }
    }
}