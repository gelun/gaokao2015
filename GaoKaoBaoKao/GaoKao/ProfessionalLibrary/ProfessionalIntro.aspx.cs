using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GaoKao.ProfessionalLibrary
{
    public partial class ProfessionalIntro : System.Web.UI.Page
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
                info.ClickNum += 1;
                DAL.TengXB.Professional.ProfessionalClickNum(info);

                Crumb1.NavString = " <span>&gt;</span> <a href=\"/zhuanye.shtml\" title\"高考报考专业库\">高考报考专业库</a> <span>&gt;</span> " + info.ProfessionalName;

                ProfessionalBase1.info = info;
                ProfessionalLeft1.ProfessionalId = info.Id;
                ProfessionalLeft1.XueKeMenLeiName = info.XueKeMenLeiName;

                strProfessionalName = info.ProfessionalName;//专业名称

                ltlContent.Text = info.ProfessionalIntro;
            }

        }
    }
}