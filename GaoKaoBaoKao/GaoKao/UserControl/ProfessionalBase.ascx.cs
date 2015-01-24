using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GaoKao.UserControl
{
    public partial class ProfessionalBase : System.Web.UI.UserControl
    {
        public Entity.Professional info { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            Bind();
        }

        void Bind()
        {
            if (info != null)
            {
                ltlCengCi.Text = info.IsBen == 1 ? "本科" : "专科";
                ltlProfessionalCode.Text = info.Code;
                ltlProfessionalName.Text = info.ProfessionalName;
                ltlRemark.Text = info.Remark == "" ? info.XueKeMenLeiName + "学士学位" : info.Remark;
                ltlXueKeMenLei.Text = info.XueKeMenLeiName;
                ltlZhuanYeLei.Text = info.ZhaunYeLeiName;
            }
            else
            {
                Basic.MsgHelper.AlertBackMsg("无法获取专业信息");
            }
        }
    }
}