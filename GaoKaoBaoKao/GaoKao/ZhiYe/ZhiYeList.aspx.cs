using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace GaoKao.ZhiYe
{
    public partial class ZhiYeList : System.Web.UI.Page
    {
        protected int intId = 0;
        protected string strZhiYeName = "";
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

                DataTable dt = null;
                if (info.ZhiYeLevel == 1)
                {
                    Crumb1.NavString = " <span>&gt;</span> <a href=\"/zhiye.shtml\" title=\"高考报考职业库\">高考报考职业库</a> <span>&gt;</span> " + info.ZhiYeName;

                    ltlQuanBu.Text = "<li class=\"cur\"><a href=\"zhiye-list-" + info.Id + ".shtml\" title=\"全部\">全部</a></li>";

                    ltlZhiYeName.Text = info.ZhiYeName;

                    dt = DAL.ZhiYe.ZhiYeList("ZhiYeLevel = 2 AND ParentId = " + info.Id);
                    string strList = "";
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        strList += dt.Rows[i]["Id"].ToString() + ",";
                    }
                    if (strList.EndsWith(","))
                    {
                        strList = strList.Remove(strList.Length - 1);
                    }
                    else
                    {
                        Basic.MsgHelper.AlertUrlMsg("不合法的访问", "zhiyeku.aspx");
                    }

                    BindList(info.Id, strList);
                }
                else if (info.ZhiYeLevel == 2)
                {
                    ltlQuanBu.Text = "<li><a href=\"zhiye-list-" + info.ParentId + ".shtml\" title=\"全部\">全部</a></li>";
                    Entity.ZhiYe infoYiJi = DAL.ZhiYe.ZhiYeEntityGet(info.ParentId);
                    if (infoYiJi != null)
                    {
                        Crumb1.NavString = " <span>&gt;</span> <a href=\"/zhiye.shtml\" title=\"高考报考职业库\">高考报考职业库</a> <span>&gt;</span> <a href=\"/zhiye-list-" + infoYiJi.Id + ".shtml\" title=\"" + infoYiJi.ZhiYeName + "\">" + infoYiJi.ZhiYeName + "</a> <span>&gt;</span> " + info.ZhiYeName;

                        ltlZhiYeName.Text = infoYiJi.ZhiYeName;
                        BindList(infoYiJi.Id, info.Id.ToString());
                    }
                    else
                    {
                        Basic.MsgHelper.AlertUrlMsg("不合法的访问", "zhiyeku.aspx");
                    }
                }

                strZhiYeName = ltlZhiYeName.Text;
            }
            else
            {
                Basic.MsgHelper.AlertUrlMsg("不合法的访问", "zhiyeku.aspx");
            }
        }

        void BindList(int YiJiId, string strList)
        {
            DataTable dtList = DAL.ZhiYe.ZhiYeList("ParentId = " + YiJiId);
            rptListHangYe.DataSource = dtList;
            rptListHangYe.DataBind();
            DataTable dt = null;
            if (strList.Contains(","))
            {
                dt = DAL.ZhiYe.ZhiYeList(" ZhiYeLevel = 3 AND ParentId in (" + strList + ")");
            }
            else
            {
                dt = DAL.ZhiYe.ZhiYeList(" ZhiYeLevel = 3 AND ParentId = " + strList);
            }
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (i == dt.Rows.Count - 1)
                {
                    ltlList.Text += "<div class=\"zykbox\" style=\"border-bottom: 0;\">";
                }
                else
                {
                    ltlList.Text += "<div class=\"zykbox\">";
                }
                ltlList.Text += "<h3><a href=\"zhiye-jianjie-" + dt.Rows[i]["Id"].ToString() + ".shtml\">" + dt.Rows[i]["ZhiYeName"].ToString() + "</a></h3>";
                ltlList.Text += "<p>" + Basic.Utils.GetUnicodeSubString(dt.Rows[i]["Intro"].ToString().Replace("<br>", ""), 200, "...") + "</p>";
                ltlList.Text += "</div>";
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