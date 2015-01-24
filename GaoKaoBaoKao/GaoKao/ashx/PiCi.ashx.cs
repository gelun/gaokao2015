using System;
using System.Collections.Generic;
using System.Data;
using System.Web;

namespace GaoKao.ashx
{
    /// <summary>
    /// PiCi 的摘要说明
    /// </summary>
    public class PiCi : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            int ProvinceId = Basic.Utils.StrToInt(context.Request.QueryString["sfid"], 0);
            string html = "";
            //DataTable dt = DAL.ProvincePiCi.ProvincePiCiList("");
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