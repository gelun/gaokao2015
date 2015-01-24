using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;

namespace GaoKao.SchoolLibrary
{
    public partial class SearchFenShuXian : System.Web.UI.Page
    {
        protected int intYuanXiaoDi = 0, intWenLi = 0, intYear = 0, intShengYuanDi = 0, intCurrentPageNum = 1;
        protected int intDataAll = 0;//总行数
        protected int intPageAll = 0;//总页数
        protected int intPageSize = 20;//每页显示的数量

        protected string strPage = "";//页码
        protected void Page_Load(object sender, EventArgs e)
        {
            GetQuesString();
            Bind();
        }

        void GetQuesString()
        {
            intYuanXiaoDi = Basic.RequestHelper.GetQueryInt("yxd", 1);
            intWenLi = Basic.RequestHelper.GetQueryInt("wl", 1);
            intYear = Basic.RequestHelper.GetQueryInt("year", 2011);
            intShengYuanDi = Basic.RequestHelper.GetQueryInt("syd", 1);
            intCurrentPageNum = Basic.RequestHelper.GetQueryInt("p", 1);
        }

        void Bind()
        {
            intDataAll = DAL.TengXB.FenShengYuanXiaoLuQu.ChaFenShuXianCount("", intYuanXiaoDi, intWenLi, intShengYuanDi, intYear);
            intPageAll = Basic.PageNumber.GetPageAll(intDataAll, intPageSize);
            intCurrentPageNum = Basic.PageNumber.GetCurrentPageNumber(intCurrentPageNum, intPageAll);

            DataTable dt = DAL.TengXB.FenShengYuanXiaoLuQu.ChaFenShuXianPageList("", intYuanXiaoDi, intWenLi, intShengYuanDi, intYear, intPageSize, intCurrentPageNum);
            if (dt != null)
            {
                rptList.DataSource = dt;
                rptList.DataBind();
            }

            strPage = CreatPageNumber(3);

        }

        string CreatPageNumber(int ArroundNumber)
        {
            if (intDataAll <= intPageSize)
                return "";

            StringBuilder sb = new StringBuilder();
            if (intCurrentPageNum>1)
            {
                sb.Append("<h2><a href=\"/chafenshuxian-" + intYuanXiaoDi + "-" + intWenLi + "-" + intYear + "-" + intShengYuanDi + "-" + (intCurrentPageNum - 1) + ".shtml\"><span style=\"color: #393939\">&lt;</span> 上一页</a></h2>\n");
            }
            else
            {
                sb.Append("<h2><a href=\"javascript:void(0);\"><span style=\"color: #393939\">&lt;</span> 上一页</a></h2>\n");
            }

            sb.Append("<ul class=\"ulbd\">\n");
            int PageAll = Basic.PageNumber.GetPageAll(intDataAll, intPageSize);
            intCurrentPageNum = Basic.PageNumber.GetCurrentPageNumber(intCurrentPageNum, PageAll);

            //处理当前页码前的显示
            int tempBegin = intCurrentPageNum - ArroundNumber;
            if (tempBegin > 2)
            {
                sb.Append("<li><a href=\"/chafenshuxian-" + intYuanXiaoDi + "-" + intWenLi + "-" + intYear + "-" + intShengYuanDi + "-1.shtml\">1</a></li>\n");
                sb.Append("<li><a href=\"/chafenshuxian-" + intYuanXiaoDi + "-" + intWenLi + "-" + intYear + "-" + intShengYuanDi + "-" + (intCurrentPageNum - 1) + ".shtml\">…</a></li>\n");
            }
            else
            {
                tempBegin = 1;
            }

            for (int i = tempBegin; i < intCurrentPageNum; i++)
            {
                sb.Append("<li><a href=\"/chafenshuxian-" + intYuanXiaoDi + "-" + intWenLi + "-" + intYear + "-" + intShengYuanDi + "-" + i + ".shtml\">" + i + "</a></li>\n");
            }

            //当前页码
            sb.Append("<li><a href=\"javascript:void(0);\" style=\"background:#4c83e1;color:#fff;\">" + intCurrentPageNum + "</a></li>\n");

            //处理当前页码后的显示
            int tempEnd = intCurrentPageNum + ArroundNumber;
            if (tempEnd > PageAll)
            {
                tempEnd = PageAll;
            }
            for (int i = intCurrentPageNum + 1; i <= tempEnd; i++)
            {
                sb.Append("<li><a href=\"/chafenshuxian-" + intYuanXiaoDi + "-" + intWenLi + "-" + intYear + "-" + intShengYuanDi + "-" + i + ".shtml\">" + i + "</a></li>\n");
            }

            if (tempEnd < PageAll)
            {
                sb.Append("<li><a href=\"javascript:void(0);\">…</a></li>\n");
                sb.Append("<li><a href=\"/chafenshuxian-" + intYuanXiaoDi + "-" + intWenLi + "-" + intYear + "-" + intShengYuanDi + "-" + PageAll + ".shtml\">" + PageAll + "</a></li>\n");
            }

            sb.Append("</ul>\n");

            //如果当前页不是最后一页
            if (intCurrentPageNum != PageAll)
            {
                sb.Append("<h2><a href=\"/chafenshuxian-" + intYuanXiaoDi + "-" + intWenLi + "-" + intYear + "-" + intShengYuanDi + "-" + (intCurrentPageNum + 1) + ".shtml\">下一页 <span>&gt;</span></a></h2>\n");
            }
            else
            {
                sb.Append("<h2><a href=\"javascript:void(0);\">下一页 <span>&gt;</span></a></h2>\n");
            }
            return sb.ToString();
        }
    }
}
