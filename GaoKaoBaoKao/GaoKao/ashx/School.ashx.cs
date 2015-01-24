using System;
using System.Collections.Generic;
using System.Data;
using System.Web;

namespace GaoKao.ashx
{
    /// <summary>
    /// School 的摘要说明
    /// </summary>
    public class School : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            int SchoolProvinceId = Basic.Utils.StrToInt(context.Request.QueryString["yxsfid"], 0);
            string html = "";
            //DataTable dt = DAL.FenShengYuanXiaoLuQu.SchoolList(" 
            //html += "<option value=\"" + dr["SchoolId"] + "\">" + dr["SchoolName"] + "</option>";

            context.Response.Write(html);
            context.Response.End();
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