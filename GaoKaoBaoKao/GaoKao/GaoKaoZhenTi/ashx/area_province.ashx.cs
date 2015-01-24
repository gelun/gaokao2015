using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace GaoKao.GaoKaoZhenTi.ashx
{
    /// <summary>
    /// area_province 的摘要说明
    /// </summary>
    public class area_province : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";

            string strHtml = "<option value=\"0\">选择省份</option>";

            DataTable dt = DAL.area_province.area_provinceList("");
            if (dt != null)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    strHtml += "<option value=\"" + dt.Rows[i]["id"].ToString() + "\">" + dt.Rows[i]["name"].ToString() + "</option>";
                }
            }



            context.Response.Write(strHtml);
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