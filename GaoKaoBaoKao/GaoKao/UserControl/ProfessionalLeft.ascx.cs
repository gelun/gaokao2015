using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GaoKao.UserControl
{
    public partial class ProfessionalLeft : System.Web.UI.UserControl
    {
        public int ProfessionalId { get; set; }//专业id
        public string XueKeMenLeiName { get; set; }//学科门类名称
        public int Index { get; set; }//右侧导航中的索引
        protected string HasJiuYeLv = "";//是否有就业率
        protected void Page_Load(object sender, EventArgs e)
        {
            Bind();
        }

        void Bind()
        {
            if (ProfessionalId>0&&XueKeMenLeiName!="")
            {
                ltlXueKeMenLei.Text = XueKeMenLeiName;

                if (DAL.JiuYeLv.JiuYeLvCount("ZhuanYeId = " + ProfessionalId)>0)
                {
                    HasJiuYeLv = "yes";
                }
                else
                {
                    HasJiuYeLv = "no";
                }
            }
            else
            {
                Basic.MsgHelper.AlertBackMsg("获取专业信息失败");
            }
        }
    }
}