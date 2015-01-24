using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GaoKao.GaoKaoZhenTi.ashx
{
    /// <summary>
    /// cuotibendel 的摘要说明
    /// </summary>
    public class cuotibendel : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            int intId = Basic.RequestHelper.GetFormInt("cuotibenId", 0);
            if (DAL.cuotiben.cuotibenDel(intId))
            {
                context.Response.Write("success");
            }
            else
            {
                context.Response.Write("error");
            }
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