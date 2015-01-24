using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace GaoKao.TuiJian
{

    public partial class zhineng2_ZheJiang : BaseTuiJian
    {
        protected int ProvincePiCiId = 0;
        public Entity.ProvincePiCi provincePiCi = new Entity.ProvincePiCi();

        protected int intZhiYuanCount = 0;//允许填报的志愿数
        protected DataTable dtProvinceZhiYuan = null;

        protected int ZongFen = 0;
        protected Entity.ProvinceWeiCi infoProvinceWeiCi = new Entity.ProvinceWeiCi();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (userinfo.ProvinceId != 11)
            {
                Server.Transfer("zhineng2.spx");
            }
            ProvincePiCiId = Basic.RequestHelper.GetQueryInt("pcid", 0);
            if (ProvincePiCiId > 0)
                provincePiCi = DAL.ProvincePiCi.ProvincePiCiEntityGet(ProvincePiCiId);

            //获取该批次下应该使用的总分和位次等信息
            switch (provincePiCi.PiCi)
            {
                case 0: ZongFen = history_zhejiang.ZongFen1;
                    break;
                case 1: ZongFen = history_zhejiang.ZongFen1;
                    break;
                case 2: ZongFen = history_zhejiang.ZongFen2;
                    break;
                case 4: ZongFen = history_zhejiang.ZongFen3;
                    break;
                default:
                    break;
            }
            if (ZongFen == 0)
            {
                Basic.MsgHelper.AlertUrlMsg("请首先设置自己的考试成绩！", "/Persional/ChengJiEdit2.aspx"); //跳转到成绩输入页面
            }
            else
            {

                infoProvinceWeiCi = DAL.ProvinceWeiCi.ProvinceWeiCiEntityGetByFenShu(ZongFen, provinceConfig.LatestProvinceWeiCiYear, 11, userinfo.KeLei, (provincePiCi.PiCi == 0 ? 1 : provincePiCi.PiCi));//

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