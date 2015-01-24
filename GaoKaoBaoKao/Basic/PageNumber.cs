using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;
using Basic.Generic;

namespace Basic
{
    /// <summary>
    /// TemplateΪҳ��ģ����.
    /// </summary>
    public abstract class PageNumber
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="DataNumberAll">����Ҫ��ʾ������</param>
        /// <param name="PageSize">ҳ����ʾ����</param>
        /// <param name="CurrentPageNumber">��ǰҳ�룬����Ϊ0</param>
        /// <param name="ArroundNumber">��ǰҳ��ǰ��������ʾ������</param>
        /// <param name="PageUrl">�滻��Url��ַ�������Ǵ���õĺ���ֱ�Ӽ����־�OK</param>
        /// <returns></returns>
        public static string CreatPageNumberThis(int DataNumberAll, int PageSize, int CurrentPageNumber, int ArroundNumber, string PageUrl)
        {
            if (DataNumberAll <= PageSize)
                return "";

            //�϶�Ҫ����1ҳ��
            StringBuilder sb = new StringBuilder();
            sb.Append("\n");
            int PageAll = GetPageAll(DataNumberAll, PageSize);
            CurrentPageNumber = GetCurrentPageNumber(CurrentPageNumber, PageAll);
            //�����ǰҳ���ǵ�һҳ
            if (CurrentPageNumber != 1)
            {
                sb.Append("<a href=\"");
                sb.Append(PageUrl);
                sb.Append(CurrentPageNumber - 1);
                sb.Append("\">&laquo;</a>\n");
            }
            else
            {
                sb.Append("<a href=\"");
                sb.Append(PageUrl);
                sb.Append(CurrentPageNumber - 1);
                sb.Append("\">&laquo;</a>\n");
            }

            //����ǰҳ��ǰ����ʾ
            int tempBegin = CurrentPageNumber - ArroundNumber;
            if (tempBegin > 2)
            {
                sb.Append("<a href=\"");
                sb.Append(PageUrl);
                sb.Append("1\">1</a>\n");
                sb.Append("<a href=\"");
                sb.Append(PageUrl);
                sb.Append("\" class=\"Cese\">��</a>\n");
            }
            else
            {
                tempBegin = 1;
            }

            for (int i = tempBegin; i < CurrentPageNumber; i++)
            {
                sb.Append("<a href=\"");
                sb.Append(PageUrl);
                sb.Append(i);
                sb.Append("\">");
                sb.Append(i);
                sb.Append("</a>\n");
            }

            //��ǰҳ��
            sb.Append("<a href=\"");
            sb.Append(PageUrl);
            sb.Append(CurrentPageNumber);
            sb.Append("\" class=\"Cese\">");
            sb.Append(CurrentPageNumber);
            sb.Append("</a>\n");

            //����ǰҳ������ʾ
            int tempEnd = CurrentPageNumber + ArroundNumber;
            if (tempEnd > PageAll)
            {
                tempEnd = PageAll;
            }
            for (int i = CurrentPageNumber + 1; i <= tempEnd; i++)
            {
                sb.Append("<a href=\"");
                sb.Append(PageUrl);
                sb.Append(i);
                sb.Append("\">");
                sb.Append(i);
                sb.Append("</a>\n");
            }

            if (tempEnd < PageAll)
            {
                sb.Append("<a href=\"#\" class=\"Cese\">��</a>\n");
                sb.Append("<a href=\"");
                sb.Append(PageUrl);
                sb.Append(PageAll);
                sb.Append("\">");
                sb.Append(PageAll);
                sb.Append("</a>\n");
            }


            //�����ǰҳ�������һҳ
            if (CurrentPageNumber != PageAll)
            {
                sb.Append("<a href=\"");
                sb.Append(PageUrl);
                sb.Append(CurrentPageNumber + 1);
                sb.Append("\">&raquo;</a>\n");
            }
            else
            {
                sb.Append("<a href=\"");
                sb.Append(PageUrl);
                sb.Append(CurrentPageNumber + 1);
                sb.Append("\">&raquo;</a>\n");
            }
            sb.Append("\n");
            return sb.ToString();
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="DataNumberAll">����Ҫ��ʾ������</param>
        /// <param name="PageSize">ҳ����ʾ����</param>
        /// <param name="CurrentPageNumber">��ǰҳ�룬����Ϊ0</param>
        /// <param name="ArroundNumber">��ǰҳ��ǰ��������ʾ������</param>
        /// <param name="PageUrl">�滻��Url��ַ�������Ǵ���õĺ���ֱ�Ӽ����־�OK</param>
        /// <returns></returns>
        public static string CreatPageNumber(int DataNumberAll, int PageSize, int CurrentPageNumber, int ArroundNumber, string PageUrl)
        {
            if (DataNumberAll <= PageSize)
                return "";

            //<ul>
            //  
            //  <li class="active"><a href="#">1</a></li>
            //  <li><a href="#">2</a></li>
            //  <li><a href="#">3</a></li>
            //  <li><a href="#">4</a></li>
            //  <li><a href="#">Next</a></li>
            //</ul>

            //�϶�Ҫ����1ҳ��
            StringBuilder sb = new StringBuilder();
            sb.Append("<ul>\n");
            int PageAll = GetPageAll(DataNumberAll, PageSize);
            CurrentPageNumber = GetCurrentPageNumber(CurrentPageNumber, PageAll);
            //�����ǰҳ���ǵ�һҳ
            if (CurrentPageNumber != 1)
            {
                sb.Append("<li><a href=\"");
                sb.Append(PageUrl);
                sb.Append(CurrentPageNumber - 1);
                sb.Append("\">&laquo;</a></li>\n");
            }
            else
            {
                sb.Append("<li class=\"disabled\"><a href=\"");
                sb.Append(PageUrl);
                sb.Append(CurrentPageNumber - 1);
                sb.Append("\">&laquo;</a></li>\n");
            }

            //����ǰҳ��ǰ����ʾ
            int tempBegin = CurrentPageNumber - ArroundNumber;
            if (tempBegin > 2)
            {
                sb.Append("<li><a href=\"");
                sb.Append(PageUrl);
                sb.Append("1\">1</a></li>\n");
                sb.Append("<li class=\"active\"><a href=\"");
                sb.Append(PageUrl);
                sb.Append("\">��</a></li>\n");
            }
            else
            {
                tempBegin = 1;
            }

            for (int i = tempBegin; i < CurrentPageNumber; i++)
            {
                sb.Append("<li><a href=\"");
                sb.Append(PageUrl);
                sb.Append(i);
                sb.Append("\">");
                sb.Append(i);
                sb.Append("</a></li>\n");
            }

            //��ǰҳ��
            sb.Append("<li><span>");
            sb.Append(CurrentPageNumber);
            sb.Append("</span></li>\n");
            //sb.Append("<li class=\"active\"><a href=\"");
            //sb.Append(PageUrl);
            //sb.Append(CurrentPageNumber);
            //sb.Append("\">");
            //sb.Append(CurrentPageNumber);
            //sb.Append("</a></li>\n");

            //����ǰҳ������ʾ
            int tempEnd = CurrentPageNumber + ArroundNumber;
            if (tempEnd > PageAll)
            {
                tempEnd = PageAll;
            }
            for (int i = CurrentPageNumber + 1; i <= tempEnd; i++)
            {
                sb.Append("<li><a href=\"");
                sb.Append(PageUrl);
                sb.Append(i);
                sb.Append("\">");
                sb.Append(i);
                sb.Append("</a></li>\n");
            }

            if (tempEnd < PageAll)
            {
                sb.Append("<li class=\"active\"><a href=\"#\">��</a></li>\n");
                sb.Append("<li><a href=\"");
                sb.Append(PageUrl);
                sb.Append(PageAll);
                sb.Append("\">");
                sb.Append(PageAll);
                sb.Append("</a></li>\n");
            }


            //�����ǰҳ�������һҳ
            if (CurrentPageNumber != PageAll)
            {
                sb.Append("<li><a href=\"");
                sb.Append(PageUrl);
                sb.Append(CurrentPageNumber + 1);
                sb.Append("\">&raquo;</a><li>\n");
            }
            else
            {
                sb.Append("<li class=\"disabled\"><a href=\"");
                sb.Append(PageUrl);
                sb.Append(CurrentPageNumber + 1);
                sb.Append("\">&raquo;</a></li>\n");
            }
            sb.Append("</ul>\n");
            return sb.ToString();
        }

        /// <summary>
        /// ���������������õ���ʵ��ҳ��
        /// </summary>
        /// <param name="DataNumberAll"></param>
        /// <param name="PageSize"></param>
        /// <returns></returns>
        public static int GetPageAll(int DataNumberAll, int PageSize)
        {
            int PageAll = 1;

            if ((DataNumberAll % PageSize) > 0)
            {
                PageAll = DataNumberAll / PageSize + 1;
            }
            else
            {
                PageAll = DataNumberAll / PageSize;
            }
            return PageAll;
        }

        /// <summary>
        /// ��֤Ŀǰ��ҳ�룬������Ϊ������ҳ��
        /// </summary>
        /// <param name="pagesize"></param>
        /// <returns></returns>
        public static int GetCurrentPageNumber(int CurrentPageNumber, int PageAll)
        {
            if (CurrentPageNumber <= 1)
                return 1;
            else if (CurrentPageNumber > PageAll)
            {
                return PageAll;
            }
            else
                return CurrentPageNumber;
        }
    }
}