using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace GaoKao.ashx
{
    /// <summary>
    /// yuanxiaopaihang 的摘要说明
    /// </summary>
    public class yuanxiaopaihang : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string strResult = "";
            string strCallBack = Basic.RequestHelper.GetQueryString("callback");

            int intRecordCount = Basic.RequestHelper.GetQueryInt("lg", 8); ;//调取的记录数

            DataTable dt = DAL.School.SchoolTopGet("IsPause=0   order by  ClickNum  desc  ", intRecordCount);

            if (dt != null && dt.Rows.Count > 0)
            {
                string json = "";
                foreach (DataRow dr in dt.Rows)
                {
                    json += "{\"SchoolName\":\"" + dr["SchoolName"] + "\",\"SchoolId\":\"" + dr["Id"] + "\",\"Click\":\"" + dr["ClickNum"] + "\"},";
                }

                if (json != "")
                {
                    json = json.Remove(json.Length - 1, 1);
                }

                context.Response.Write(strCallBack + "([" + json + "])");
                context.Response.End();

            }
            context.Response.Write(strCallBack + "([])");
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