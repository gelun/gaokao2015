using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace GaoKao.ProfessionalLibrary
{
    /// <summary>
    /// autocomplete_Professional 的摘要说明
    /// </summary>
    public class autocomplete_Professional : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            if (context.Request.QueryString["keyword"] != null && context.Request.QueryString["keyword"] != "")
            {
                string majorName = context.Request.QueryString["keyword"];

                DataTable dt = DAL.Professional.ProfessionalList(" ProfessionalGrade = 3 AND ProfessionalName like  '%" + majorName + "%'");

                if (dt != null && dt.Rows.Count > 0)
                {
                    string json = "";

                    foreach (DataRow dr in dt.Rows)
                    {
                        json += "\"" + dr["ProfessionalName"] + "\",";
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