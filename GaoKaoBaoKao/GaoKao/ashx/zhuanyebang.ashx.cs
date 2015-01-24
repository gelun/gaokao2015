using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Text;

namespace GaoKao.ashx
{
    /// <summary>
    /// zhuanyebang 的摘要说明
    /// </summary>
    public class zhuanyebang : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";

            string strResult = "";
            string strCallBack = Basic.RequestHelper.GetQueryString("callback");

            int intRecordCount = Basic.RequestHelper.GetQueryInt("lg", 8); ;//调取的记录数

            int intLeiBie = Basic.RequestHelper.GetQueryInt("t", 1);


            DataTable dt = null;

            if (intLeiBie == 1)
            {
                dt = DAL.Professional.ProfessionalTopGet(" ProfessionalGrade = 3 AND IsBen = 1 ORDER BY ClickNum DESC", intRecordCount);//(" szy.IsPause = 0 AND zy.IsBen = 1 ORDER BY szy.ClickNum DESC ", intRecordCount);
                if (dt != null)
                {
                    strResult = DataTable2Json(dt, strCallBack);
                }
            }
            else
            {
                dt = DAL.Professional.ProfessionalTopGet(" ProfessionalGrade = 3 AND IsBen = 2 ORDER BY ClickNum DESC", intRecordCount);
                if (dt != null)
                {
                    strResult = DataTable2Json(dt, strCallBack);
                }
            }


            context.Response.Write(strResult);
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
                jsonBuilder.Append("\"ZhuanYeId\":\"");
                jsonBuilder.Append(dt.Rows[i]["Id"].ToString());
                jsonBuilder.Append("\",");
                jsonBuilder.Append("\"name\":\"");
                jsonBuilder.Append(Basic.Utils.GetUnicodeSubString(dt.Rows[i]["ProfessionalName"].ToString(), 18, ""));
                jsonBuilder.Append("\",");
                jsonBuilder.Append("\"ProfessionalName\":\"");
                jsonBuilder.Append(dt.Rows[i]["ProfessionalName"].ToString());
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