using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace GaoKao.ZhiYe
{
    public partial class ZhiYe : System.Web.UI.Page
    {
        protected int intId = 0;
        protected string strZhiYeName = "", strYiJiZhiYeName = "", strErJiZhiYeName = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            Bind();
            BindReMen();
        }

        void Bind()
        {

            intId = Basic.RequestHelper.GetQueryInt("id", 0);
            Entity.ZhiYe info = DAL.ZhiYe.ZhiYeEntityGet(intId);
            if (info != null)
            {
                info.ClickNum += 1;
                DAL.TengXB.ZhiYe.ZhiYeClickNum(info);

                ltlZhiYeName.Text = info.ZhiYeName;
                ltlIntro.Text = info.Intro;
                //相关行业
                Entity.ZhiYe infoErJi = DAL.ZhiYe.ZhiYeEntityGet(info.ParentId);
                Entity.ZhiYe infoYiJi = DAL.ZhiYe.ZhiYeEntityGet(infoErJi.ParentId);

                strZhiYeName = info.ZhiYeName;//职业名称
                strErJiZhiYeName = infoErJi.ZhiYeName;//二级职业名称
                strYiJiZhiYeName = infoYiJi.ZhiYeName;//一级职业名称

                ltlHangYe.Text += "<a href=\"zhiye-list-" + infoYiJi.Id + ".shtml\" title=\"" + infoYiJi.ZhiYeName + "\">" + infoYiJi.ZhiYeName + "</a>";
                ltlHangYe.Text += " - <a href=\"zhiye-list-" + infoErJi.Id + ".shtml\" title=\"" + infoErJi.ZhiYeName + "\">" + infoErJi.ZhiYeName + "</a>";

                Crumb1.NavString = " <span>&gt;</span> <a href=\"/zhiye.shtml\" title=\"高考报考职业库\">高考报考职业库</a> <span>&gt;</span> <a href=\"/zhiye-list-" + infoYiJi.Id + ".shtml\" title=\"" + infoYiJi.ZhiYeName + "\">" + infoYiJi.ZhiYeName + "</a> <span>&gt;</span> <a href=\"/zhiye-list-" + infoErJi.Id + ".shtml\" title=\"" + infoErJi.ZhiYeName + "\">" + infoErJi.ZhiYeName + "</a> <span>&gt;</span> " + info.ZhiYeName;

                //相关专业
                DataTable dt = DAL.TengXB.ZhiYeZhuanYe.ProfessionalList("ZhiYeZhuanYe.ZhiYeId = " + info.Id);
                if (dt!=null&&dt.Rows.Count>0)
                {
                    rptList.DataSource = dt;
                    rptList.DataBind();
                }
                else
                {
                    ltlNoXinXi.Text = "<span style=\"height: 28px;line-height: 28px;font-size: 16px;\">对不起，暂时没有匹配的大学本专科专业！</span>";
                }
            }
        }

        //热门行业  热门职业
        void BindReMen()
        {
            DataTable dt = null;
            //热门职业
            dt = DAL.ZhiYe.ZhiYeTopGet("ZhiYeLevel = 3 ORDER BY ClickNum DESC", 10);
            if (dt != null)
            {
                rptReMenZhiYe.DataSource = dt;
                rptReMenZhiYe.DataBind();
            }
            //热门行业
            dt = DAL.ZhiYe.ZhiYeTopGet("ZhiYeLevel = 2 ORDER BY ClickNum DESC", 10);
            if (dt != null)
            {
                rptReMenHangYe.DataSource = dt;
                rptReMenHangYe.DataBind();
            }
        }
    }
}