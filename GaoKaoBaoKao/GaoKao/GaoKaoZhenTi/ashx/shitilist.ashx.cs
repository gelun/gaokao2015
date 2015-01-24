using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace GaoKao.GaoKaoZhenTi.ashx
{
    /// <summary>
    /// shitilist 的摘要说明
    /// </summary>
    public class shitilist : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";

            int intSubjectId = Basic.RequestHelper.GetFormInt("sid", 0);
            int intYear = Basic.RequestHelper.GetFormInt("y", 0);
            int intProvinceId = Basic.RequestHelper.GetFormInt("p", 0);

            DataTable dt = DAL.tengxb.zhenti.sjTiMuList(" shijuan.subject_id = " + intSubjectId + " and shijuan.province_id = " + intProvinceId + " AND shijuan.year = '" + intYear + "年'");
            if (dt != null && dt.Rows.Count > 0)
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