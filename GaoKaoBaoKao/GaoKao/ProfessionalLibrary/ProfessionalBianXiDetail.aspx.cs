using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GaoKao.ProfessionalLibrary
{
    public partial class ProfessionalBianXiDetail : System.Web.UI.Page
    {
        protected int intArticleId = 0;
        protected int intProfessionalId = 0;
        protected string strPageTitle = "";
        protected string strProfessionalName = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            Bind();
        }

        void Bind()
        {
            intArticleId = Basic.RequestHelper.GetQueryInt("articleid", 0);
            intProfessionalId = Basic.RequestHelper.GetQueryInt("professionalid", 0);

            Entity.Professional infoSP = DAL.Professional.ProfessionalEntityGet(intProfessionalId);
            if (infoSP != null)
            {
                strProfessionalName = infoSP.ProfessionalName;//专业名称
                ProfessionalBase1.info = infoSP;
                ProfessionalLeft1.ProfessionalId = infoSP.Id;
                ProfessionalLeft1.XueKeMenLeiName = infoSP.XueKeMenLeiName;

                Crumb1.NavString = " <span>&gt;</span> <a href=\"/zhuanye.shtml\" title\"高考报考专业库\">高考报考专业库</a> <span>&gt;</span> <a href=\"/zhuanye-jianjie-" + infoSP.Id + ".shtml\" title\"" + infoSP.ProfessionalName + "\">" + infoSP.ProfessionalName + "</a> <span>&gt;</span> <a href=\"/zhuanye-bianxi-" + infoSP.Id + ".shtml\" title\"" + infoSP.ProfessionalName + "专业辨析\">专业辨析</a>";

                Entity.Article info = DAL.Article.ArticleEntityGet(intArticleId);
                if (info != null)
                {
                    Crumb1.NavString += " <span>&gt;</span> " + info.Title;

                    strPageTitle = info.Title;//标题
                    ltlTitle.Text = info.Title;
                    ltlContent.Text = info.Content;
                }
                else
                {
                    Basic.MsgHelper.AlertBackMsg("获取专业信息失败");
                }
            }
            else
            {
                Basic.MsgHelper.AlertBackMsg("获取专业信息失败");
            }
        }
    }
}