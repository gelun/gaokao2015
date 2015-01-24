using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace GaoKao.SchoolLibrary
{
    /// <summary>
    /// getDuiBiLan 的摘要说明
    /// </summary>
    public class getDuiBiLan : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string strHtml = "";

            int intSchoolId = Basic.RequestHelper.GetFormInt("schoolid", 0);
            if (intSchoolId > 0)
            {
                strHtml += GetSchoolHtml(intSchoolId);
            }
            else
            {
                string strDuiBiList = Basic.CookieHelper.GetCookie("duibischool");
                if (strDuiBiList != "")
                {
                    string[] arr = strDuiBiList.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                    for (int i = 0; i < arr.Length; i++)
                    {
                        strHtml += GetSchoolHtml(Basic.TypeConverter.StrToInt(arr[i]));
                    }
                }
            }

            context.Response.Write(strHtml);
        }

        string GetSchoolHtml(int intSchoolId)
        {
            string strHtml = "";
            Entity.School info = DAL.School.SchoolEntityGet(intSchoolId);
            if (info != null)
            {
                strHtml += "<div class=\"dbdx\" sid='" + info.Id + "'>";
                strHtml += "<dl>";
                strHtml += "<dt><a target=\"_blank\" href=\"daxue-jianjie-" + info.Id + ".shtml\" title=\"" + info.SchoolName + "\"><img src=\"/logo/" + (info.Logo == "" ? "default.png" : info.Logo) + "\" width=\"72\" height=\"73\" /></a></dt>";
                strHtml += "<dd><a target=\"_blank\" href=\"daxue-jianjie-" + info.Id + ".shtml\" title=\"" + info.SchoolName + "\">" + Basic.Utils.GetUnicodeSubString(info.SchoolName, 20, "") + "</a></dd>";
                strHtml += "<dd><span><a href=\"javascript:cancelDuiBi(" + info.Id + ");\">[取消对比]</a></span></dd>";
                strHtml += "</dl>";
                strHtml += "</div>";
            }
            return strHtml;
        }


        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}