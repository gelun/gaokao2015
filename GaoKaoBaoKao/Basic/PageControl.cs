using System;
using System.Web;
using System.ComponentModel;
using System.Text;

namespace Basic
{
    public class PageControl
    {
        /// <summary>
        /// 页大小
        /// </summary>
        int PageSize = 10;
        public int intPageSize
        {
            set { PageSize = value; }
            get { return PageSize; }
        }

        int ArroundNumber = 1;
        public int intArroundNumber
        {
            set { ArroundNumber = value; }
            get { return ArroundNumber; }
        }

        /// <summary>
        /// 省略号两端的空余数量
        /// </summary>
        int PageShengYu = 1;
        public int intPageShengYu
        {
            set { PageShengYu = value; }
            get { return PageShengYu; }
        }

        /// <summary>
        /// 当前索引
        /// </summary>
        int PageIndex = 1;
        public int intPageIndex
        {
            set { PageIndex = value; }
            get { return PageIndex; }
        }


        /// <summary>
        /// 总记录数
        /// </summary>
        int Record = 1;
        public int intRecord
        {
            set { Record = value; }
            get { return Record; }
        }

        /// <summary>
        /// 总页码数
        /// </summary>
        int PageCount = 0;
        public int intPageCount
        {
            get { return PageCount; }
        }


        /// <summary>
        /// URL的格式，如果不设定，则自动获取网站url拼接出url
        /// </summary>
        [Browsable(true),
        Category("导航按钮"),
        DefaultValue("转到第{0}页"),
        Description("页导航按钮工具提示文本的格式")]
        string UrlFormat = "";
        public string strUrlFormat
        {
            set { UrlFormat = value; }
            get { return UrlFormat; }
        }


        /// <summary>
        /// 显示页码按钮个数
        /// </summary>
        int PageButtonCount = 10;
        public int intPageButtonCount
        {
            set { PageButtonCount = value; }
            get { return PageButtonCount; }

        }


        /// <summary>
        /// 更多按钮显示的内容
        /// </summary>
        string more = "...";

        /// <summary>
        /// 是否显示更多页的按钮
        /// </summary>
        bool ShowMore = true;

        //页码轮番置为第一个所引处
        int FirstpagecurrentPage = 9;

        //初始化
        public PageControl()
        {

        }


        /// <summary>
        /// 计算页数
        /// </summary>
        void SetPageCount()
        {
            if (intRecord % intPageSize > 0)
            {
                PageCount = Record / PageSize + 1;
            }
            else
            {
                PageCount = Record / PageSize;
            }
        }



        /// <summary>
        /// 得到html代码
        /// </summary>
        /// <returns></returns>
        public string PageHTMLString()
        {
            //先设置页码
            SetPageCount();

            StringBuilder sb = new StringBuilder();

            sb.Append("<div class=\"pagination\">\n");
            //如果当前页不是第一页
            if (intPageIndex != 1)
            {
                sb.Append("<a class=\"prev-page\" href=\"");
                sb.Append(string.Format(UrlFormat, (intPageIndex - 1)));
                sb.Append("\">上一页<i></i></a>\n");
            }

            //处理当前页码前的显示
            int tempBegin = intPageIndex - ArroundNumber;
            if (tempBegin > PageShengYu + 1)
            {
                //sb.Append("<a href=\"");
                //sb.Append(string.Format(UrlFormat, 1));
                //sb.Append("\">1</a>\n");

                //sb.Append("<a href=\"");
                //sb.Append(string.Format(UrlFormat, 2));
                //sb.Append("\">2</a>\n");

                for (int i = 1; i <= PageShengYu; i++)
                {
                    sb.Append("<a href=\"");
                    sb.Append(string.Format(UrlFormat, i));
                    sb.Append("\">" + i + "</a>\n");
                }


                sb.Append("<span class=\"more-page\">...</span>\n");
            }
            else
            {
                tempBegin = 1;
            }


            for (int i = tempBegin; i < intPageIndex; i++)
            {
                sb.Append("<a href=\"");
                sb.Append(string.Format(UrlFormat, i));
                sb.Append("\">");
                sb.Append(i);
                sb.Append("</a>\n");
            }

            //当前页吗
            sb.Append("<span class=\"pagecurrent\">");
            sb.Append(intPageIndex);
            sb.Append("</span>\n");

            //处理当前页码后的显示
            int tempEnd = intPageIndex + ArroundNumber;
            if (tempEnd > intPageCount)
            {
                tempEnd = intPageCount;
            }

            for (int i = intPageIndex + 1; i <= tempEnd; i++)
            {
                sb.Append("<a href=\"");
                sb.Append(string.Format(UrlFormat, i));
                sb.Append("\">");
                sb.Append(i);
                sb.Append("</a>\n");
            }

            //if ((tempEnd + 2) < intPageCount)
            //{
            //    sb.Append("<span class=\"more-page\">...</span>\n");
            //}
            //if ((tempEnd + 2) <= intPageCount)
            //    tempEnd = intPageCount - 2;

            if ((tempEnd + PageShengYu) < intPageCount)
            {
                sb.Append("<span class=\"more-page\">...</span>\n");
            }
            if ((tempEnd + PageShengYu) <= intPageCount)
                tempEnd = intPageCount - PageShengYu;



            for (int i = tempEnd + 1; i <= intPageCount; i++)
            {
                sb.Append("<a href=\"");
                sb.Append(string.Format(UrlFormat, i));
                sb.Append("\">");
                sb.Append(i);
                sb.Append("</a>\n");
            }


            //下一页
            if (intPageIndex < intPageCount)
            {
                sb.Append("<a class=\"next-page\" href=\"");
                sb.Append(string.Format(UrlFormat, (intPageIndex + 1)));
                sb.Append("\">下一页<i></i></a>\n");
            }

            //如果当前页不是最后一页
            //if (intPageIndex != intPageCount)
            //{
            //    sb.Append("<a href=\"");
            //    sb.Append(string.Format(UrlFormat, intPageCount));
            //    sb.Append("\">尾页</a>\n");
            //}
            //else
            //{
            //    sb.Append("< class=\"disabled\"><a href=\"");
            //    sb.Append(string.Format(UrlFormat, intPageCount));
            //    sb.Append("\">尾页</a>\n");
            //}

            sb.Append("</div>\n");
            return sb.ToString();
        }


    }

}