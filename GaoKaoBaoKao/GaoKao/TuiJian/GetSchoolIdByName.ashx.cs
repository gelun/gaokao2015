using System;
using System.Collections.Generic;
using System.Data;
using System.Web;

namespace GaoKao.TuiJian
{
    /// <summary>
    /// GetSchoolIdByName 的摘要说明
    /// </summary>
    public class GetSchoolIdByName : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string strName = Basic.RequestHelper.GetFormString("sn");
            if (strName == "")
            {
                DataTable dt = DAL.School.SchoolList(" SchoolName = " + strName);
                if (dt.Rows.Count > 0)
                    context.Response.Write(dt.Rows[0]["Id"].ToString());
            }

            context.Response.Write("0");
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