using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace GaoKao.ProfessionalLibrary
{
    /// <summary>
    /// GetProfessionalList 的摘要说明
    /// </summary>
    public class GetProfessionalList : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string strHtml = "";
            int intZhuanYeLeiId = Basic.RequestHelper.GetQueryInt("zylid", 0);
            DataTable dt = DAL.Professional.ProfessionalList("ProfessionalGrade = 3 AND ParentId = " + intZhuanYeLeiId);
            if (dt != null && dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string strId = dt.Rows[i]["Id"].ToString();
                    strHtml += "<tr>"
                            + "<td><a target=\"_blank\" href=\"zhuanye-jianjie-" + strId + ".shtml\" style=\"color: #298AFF; font-size: 14px;\">" + dt.Rows[i]["ProfessionalName"].ToString() + "</a></td>"
                            + "<td><a target=\"_blank\" href=\"zhuanye-daxue-" + strId + ".shtml\" style=\"color: #298AFF; font-size: 14px;\">查看</a></td>"
                            + "<td><a target=\"_blank\" href=\"zhuanye-jiuye-" + strId + ".shtml\" style=\"color: #298AFF; font-size: 14px;\">查看</a></td>"
                            + "<td><a target=\"_blank\" href=\"zhuanye-zhiye-" + strId + ".shtml\" style=\"color: #298AFF;font-size: 14px;\">查看</a></td>"
                            + "</tr>";
                }
            }
            else
            {
                strHtml = "error";
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