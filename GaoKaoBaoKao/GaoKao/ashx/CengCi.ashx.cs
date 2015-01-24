using System;
using System.Collections.Generic;
using System.Data;
using System.Web;

namespace GaoKao.ashx
{
    /// <summary>
    /// CengCi 的摘要说明
    /// </summary>
    public class CengCi : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            int ProvinceId = Basic.Utils.StrToInt(context.Request.QueryString["sfid"], 0);
            string html = "";
            html += "<option value=\"1\">本科</option>";
            DataTable dt = DAL.ProvinceConfig.ProvinceConfigList(" ProvinceId = "+ProvinceId);
            if (dt.Rows.Count > 0)
            {
                if(dt.Rows[0]["HasZhuanKe"].ToString() == "1")
                    html += "<option value=\"2\">专科</option>";
            }

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