using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace GaoKao.ProfessionalLibrary
{
    public partial class ProfessionalXiangGuanZhiYe : System.Web.UI.Page
    {
        protected int intProfessionalId = 0;
        protected string strProfessionalName = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            Bind();
        }

        void Bind()
        {
            intProfessionalId = Basic.RequestHelper.GetQueryInt("professionalid", 0);

            Entity.Professional info = DAL.TengXB.Professional.ProfessionalEntityGet(intProfessionalId);
            if (info != null)
            {
                strProfessionalName = info.ProfessionalName;

                ProfessionalBase1.info = info;
                ProfessionalLeft1.ProfessionalId = info.Id;
                ProfessionalLeft1.XueKeMenLeiName = info.XueKeMenLeiName;

                Crumb1.NavString = " <span>&gt;</span> <a href=\"/zhuanye.shtml\" title\"高考报考专业库\">高考报考专业库</a> <span>&gt;</span> <a href=\"/zhuanye-jianjie-" + info.Id + ".shtml\" title\"" + info.ProfessionalName + "\">" + info.ProfessionalName + "</a> <span>&gt;</span> 相关职业";

                BindZhiYe();//相关职业
            }
            else
            {
                Basic.MsgHelper.AlertBackMsg("获取专业信息失败");
            }
        }

        void BindZhiYe()
        {
            string strHtml = "";
            DataTable dt1 = null;

            dt1 = DAL.TengXB.ProfessionalXiangGuanZhiYe.YiJiZhiYeZhuanYeList(intProfessionalId);
            if (dt1 != null && dt1.Rows.Count > 0)
            {
                for (int i = 0; i < dt1.Rows.Count; i++)
                {
                    strHtml += "<div class=\"xgzybox\"><h3><a target=\"_blank\" href=\"/zhiye-list-" + dt1.Rows[i]["Id"].ToString() + ".shtml\" title=\"" + dt1.Rows[i]["ZhiYeName"].ToString() + "\" >" + dt1.Rows[i]["ZhiYeName"].ToString() + "</a></h3>";
                    DataTable dt2 = null;
                    dt2 = DAL.TengXB.ProfessionalXiangGuanZhiYe.ErJiZhiYeZhuanYeList(Basic.TypeConverter.StrToInt(dt1.Rows[i]["Id"].ToString()), intProfessionalId);
                    if (dt2 != null && dt2.Rows.Count > 0)
                    {
                        for (int j = 0; j < dt2.Rows.Count; j++)
                        {
                            strHtml += "<div class=\"xgzyul\">";
                            strHtml += "<div class=\"xgzyulL\"><a target=\"_blank\" href=\"/zhiye-list-" + dt2.Rows[j]["Id"].ToString() + ".shtml\" title=\"" + dt2.Rows[j]["ZhiYeName"].ToString() + "\" >" + dt2.Rows[j]["ZhiYeName"].ToString() + "</a>：</div>";
                            strHtml += "<div class=\"xgzyulR\"><ul>";
                            DataTable dt3 = null;
                            dt3 = DAL.TengXB.ProfessionalXiangGuanZhiYe.ZhiYeZhuanYeList(Basic.TypeConverter.StrToInt(dt2.Rows[j]["Id"].ToString()), intProfessionalId);
                            if (dt3 != null && dt3.Rows.Count > 0)
                            {
                                for (int n = 0; n < dt3.Rows.Count; n++)
                                {
                                    if ((n + 1) == dt3.Rows.Count)
                                    {
                                        strHtml += "<li><a target=\"_blank\" href=\"/zhiye-jianjie-" + dt3.Rows[n]["Id"].ToString() + ".shtml\" title=\"" + dt3.Rows[n]["ZhiYeName"].ToString() + "\" >" + dt3.Rows[n]["ZhiYeName"].ToString() + "</a></li>";
                                    }
                                    else
                                    {
                                        strHtml += "<li><a target=\"_blank\" href=\"/zhiye-jianjie-" + dt3.Rows[n]["Id"].ToString() + ".shtml\" title=\"" + dt3.Rows[n]["ZhiYeName"].ToString() + "\" >" + dt3.Rows[n]["ZhiYeName"].ToString() + "</a><span style=\"color:#999;\">|</span></li>";
                                    }
                                }
                            }
                            strHtml += "</ul></div>";
                            strHtml += "</div>";
                        }
                    }

                    strHtml += "</div>";
                }
            }

            ltlZhiYeList.Text = strHtml;
        }
    }
}