using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace GaoKao.CePing.ZhiShiDian
{
    public partial class zhishidianjiexi : Base
    {
        protected int intId = 3954;
        protected int LinkId=0;
        protected void Page_Load(object sender, EventArgs e)
        {
            Bind();
        }

        void Bind()
        {
            intId = Basic.RequestHelper.GetQueryInt("id", 3954);
            Entity.KM info = DAL.KM.KMEntityGet(intId);
            if (info != null)
            {
                LinkId = info.LinkId;
                ltlZongJie.Text = info.Content1.Replace("src=\"/attach/", "src=\"/HouTaiGuanLi/attach/");
                ltlKaoFa.Text = info.Content2;
                ltlWuQuTiXing.Text = info.Content3;

                ltlLeftZhiShiDianList.Text = GetZSDList(info.LinkId, info.ParentId);

                ltlKeMuTitle.Text = GetKeMu(info.LinkId);


                //面包屑
                Crumb1.NavString = " <span>&gt;</span> 知识点讲解 <span>&gt;</span> <a href=\"zhishidianjiexi.aspx?id=" + GetId(info.LinkId) + "\">" + GetKeMu(info.LinkId) + "</a> <span>&gt;</span>  <a href=\"zhishidianjiexi.aspx?id=" + intId + "\">" + info.Title + "</a>";

            }
        }

        int GetId(int intLinkId)
        {
            switch (intLinkId)
            {
                case 6:
                    return 3954;
                case 7:
                    return 4034;
                case 8:
                    return 3984;
                case 9:
                    return 4137;
                case 10:
                    return 4221;
                case 11:
                    return 4386;
                case 12:
                    return 4518;
                case 13:
                    return 4623;
                case 14:
                    return 4281;
                default:
                    return 3954;
            }
        }

        string GetKeMu(int intLinkId)
        {
            switch (intLinkId)
            {
                case 6:
                    return "语文";
                case 7:
                    return "数学";
                case 8:
                    return "英语";
                case 9:
                    return "物理";
                case 10:
                    return "化学";
                case 11:
                    return "历史";
                case 12:
                    return "地理";
                case 13:
                    return "政治";
                case 14:
                    return "生物";
                default:
                    return "语文";
            }
        }

        //获取知识点
        string GetZSDList(int intLinkId, int ParentId)
        {
            string strHtml = "";
            DataTable dt = DAL.KM.KMList("LinkId = " + intLinkId);
            if (dt != null)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (Basic.TypeConverter.StrToInt(dt.Rows[i]["ParentId"].ToString()) == 0)
                    {
                        strHtml += "</ul>";

                        if (dt.Rows[i]["Id"].ToString() == ParentId.ToString())
                        {
                            strHtml += "<li class=\"djzk\"><span class=\"zk main\"><a href=\"javascript:void(0);\">展开</a></span><a class=\"zktitle\" href=\"javascript:void(0);\">" + dt.Rows[i]["Title"].ToString() + "</a>";
                            strHtml += "<ul style=\"display: block;\">";
                        }
                        else
                        {
                            strHtml += "<li class=\"djzk\"><span class=\"zk\"><a href=\"javascript:void(0);\">展开</a></span><a class=\"zktitle\" href=\"javascript:void(0);\">" + dt.Rows[i]["Title"].ToString() + "</a>";
                            strHtml += "<ul style=\"display: none;\">";
                        }
                    }
                    else
                    {
                        if (dt.Rows[i]["Id"].ToString() == intId.ToString())
                        {
                            strHtml += "<li class=\"main2\"><a href=\"zhishidianjiexi.aspx?id=" + dt.Rows[i]["Id"].ToString() + "\">" + dt.Rows[i]["Title"].ToString() + "</a></li>";
                        }
                        else
                        {
                            strHtml += "<li><a href=\"zhishidianjiexi.aspx?id=" + dt.Rows[i]["Id"].ToString() + "\">" + dt.Rows[i]["Title"].ToString() + "</a></li>";
                        }
                    }
                }

                if (strHtml.StartsWith("</ul>"))
                {
                    strHtml = strHtml.Substring(5);
                }

                if (strHtml.EndsWith("<ul>"))
                {
                    strHtml = strHtml.Substring(0, strHtml.Length - 5);
                }

                strHtml = "<ul style=\"overflow-y: scroll;height: 586px;\">" + strHtml + "</ul>";
            }

            return strHtml;
        }
    }
}