using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace GaoKao.ProfessionalLibrary
{
    public partial class ProfessionalJiuYe : System.Web.UI.Page
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

                Crumb1.NavString = " <span>&gt;</span> <a href=\"/zhuanye.shtml\" title\"高考报考专业库\">高考报考专业库</a> <span>&gt;</span> <a href=\"/zhuanye-jianjie-" + info.Id + ".shtml\" title\"" + info.ProfessionalName + "\">" + info.ProfessionalName + "</a> <span>&gt;</span> 历年就业率";

                string strWhere = "";
                Entity.Professional infoP = DAL.Professional.ProfessionalEntityGet(intProfessionalId);
                if (infoP != null)
                {
                    if (infoP.ProfessionalGrade == 1)
                    {
                        strWhere = "XueKeMenLei = " + intProfessionalId;
                    }
                    else if (infoP.ProfessionalGrade == 2)
                    {
                        strWhere = "ZhuanYeLei = " + intProfessionalId;
                    }
                    else
                    {
                        strWhere = "ZhuanYeId = " + intProfessionalId;
                    }
                }
                else
                {
                    Basic.MsgHelper.AlertBackMsg("获取专业信息失败");
                }

                strWhere += " ORDER BY Year DESC ";

                DataTable dt = DAL.JiuYeLv.JiuYeLvList(strWhere);
                if (dt != null && dt.Rows.Count > 0)
                {
                    rptList.DataSource = dt;
                    rptList.DataBind();
                }
                else
                {
                    //没有改专业的相关就业率数据
                }
            }
            else
            {
                Basic.MsgHelper.AlertBackMsg("获取专业信息失败");
            }
        }
    }
}