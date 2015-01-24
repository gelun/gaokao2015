using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace GaoKao.ProfessionalLibrary
{
    public partial class ProfessionalBianXi : System.Web.UI.Page
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
                strProfessionalName = info.ProfessionalName;//专业名称
                ProfessionalBase1.info = info;

                ProfessionalLeft1.ProfessionalId = info.Id;
                ProfessionalLeft1.XueKeMenLeiName = info.XueKeMenLeiName;

                Crumb1.NavString = " <span>&gt;</span> <a href=\"/zhuanye.shtml\" title\"高考报考专业库\">高考报考专业库</a> <span>&gt;</span> <a href=\"/zhuanye-jianjie-" + info.Id + ".shtml\" title\"" + info.ProfessionalName + "\">" + info.ProfessionalName + "</a> <span>&gt;</span> 专业辨析";

                //绑定辨析列表
                DataTable dt = DAL.TengXB.ProfessionalArticle.ProfessionalAndArticleList(" Article.CategoryId = 1 AND Article.IsPause = 0 AND ProfessionalId = " + intProfessionalId);
                if (dt != null && dt.Rows.Count > 0)
                {
                    rptList.DataSource = dt;
                    rptList.DataBind();
                }
            }
            else
            {
                Basic.MsgHelper.AlertBackMsg("获取专业信息失败");
            }
        }
    }
}