using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace GaoKao.SchoolLibrary
{
    /// <summary>
    /// autocomplete_School 的摘要说明
    /// </summary>
    public class autocomplete_School : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";

            if (context.Request.QueryString["keyword"] != null && context.Request.QueryString["keyword"] != "")
            {
                string majorName = context.Request.QueryString["keyword"];

                DataTable dt = DAL.School.SchoolList("SchoolName like  '%" + majorName + "%'");

                if (dt != null && dt.Rows.Count > 0)
                {
                    string json = "";

                    foreach (DataRow dr in dt.Rows)
                    {
                        json += "\"" + dr["SchoolName"] + "\",";
                    }

                    if (json != "")
                    {
                        if (json.EndsWith(","))
                        {
                            json = json.Remove(json.Length - 1, 1);
                        }

                        json = "[" + json + "]";
                    }

                    context.Response.Write(json);
                    context.Response.End();

                }

            }
            context.Response.Write("[]");
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