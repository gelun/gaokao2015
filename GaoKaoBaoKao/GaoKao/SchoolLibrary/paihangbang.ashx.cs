using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Text;

namespace GaoKao.SchoolLibrary
{
    /// <summary>
    /// TopSchoolList 的摘要说明
    /// </summary>
    public class paihangbang : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";

            string strResult = "";
            string strCallBack = Basic.RequestHelper.GetFormString("callback");

            int intCount = Basic.RequestHelper.GetFormInt("lg", 0);

            DataTable dt = DAL.TengXB.School.GetSchoolList(" 1 = 1 ORDER BY ClickNum DESC", intCount);

            if (dt != null && dt.Rows.Count > 0)
            {
                strResult = DataTable2Json(dt, strCallBack);

            }
            context.Response.Write(strResult);
            context.Response.End();
        }

        /// <summary>
        /// 获取返回结果
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="listName"></param>
        /// <returns></returns>
        string DataTable2Json(DataTable dt, string listName)
        {
            StringBuilder jsonBuilder = new StringBuilder();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                jsonBuilder.Append("{");
                jsonBuilder.Append("\"SchoolId\":\"");
                jsonBuilder.Append(dt.Rows[i]["Id"].ToString());
                jsonBuilder.Append("\",");
                jsonBuilder.Append("\"SchoolName\":\"");
                jsonBuilder.Append(dt.Rows[i]["SchoolName"].ToString());
                jsonBuilder.Append("\",");
                jsonBuilder.Append("\"ClickNum\":\"");
                jsonBuilder.Append(dt.Rows[i]["ClickNum"].ToString());
                jsonBuilder.Append("\"}");


                jsonBuilder.Append(",");
            }

            string strJson = jsonBuilder.ToString();

            if (strJson.Contains(","))
            {
                strJson = strJson.Substring(0, strJson.Length - 1);
            }



            return listName + "([" + strJson + "])";
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