using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace GaoKao.TuiJian
{
    /// <summary>
    /// getProfessionalList 的摘要说明
    /// </summary>
    public class getProfessionalList : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string strHtml = "";
            int intZhuanYeLeiId = Basic.RequestHelper.GetQueryInt("xkml", 0);
            string strZhuanYeName = Basic.RequestHelper.GetQueryString("zyn");

            string strWhere = " ZY.ProfessionalGrade = 3 AND ZY.IsBen = 1";
            if (intZhuanYeLeiId > 0)
            {
                strWhere += " AND XKML.Id = " + intZhuanYeLeiId;
            }

            if (strZhuanYeName != "")
            {
                strWhere += " AND ZY.ProfessionalName like '%" + strZhuanYeName + "%'";
            }

            DataTable dt = DAL.TengXB.Professional.TuiJian_ProfessionalList(strWhere);
            if (dt != null && dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    strHtml += "{Id:\"" + dt.Rows[i]["Id"].ToString() + "\",ProfessionalName:\"" + dt.Rows[i]["ProfessionalName"].ToString() + "\"}";
                    if (i<dt.Rows.Count-1)
                    {
                        strHtml += ",";
                    }
                }
            }
            strHtml = "{zhuanye:[" + strHtml + "]}";


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