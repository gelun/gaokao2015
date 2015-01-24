using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace GaoKao.ashx
{
    /// <summary>
    /// FenShengZhuanYeLuQu 的摘要说明
    /// </summary>
    public class FenShengZhuanYeLuQu : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            int SchoolProvinceId = Basic.Utils.StrToInt(context.Request.QueryString["yxsfid"], 0);
            int ProvinceId = Basic.Utils.StrToInt(context.Request.QueryString["sfid"], 0);
            int PiCi = Basic.Utils.StrToInt(context.Request.QueryString["pc"], 0);
            int KeLei = Basic.Utils.StrToInt(context.Request.QueryString["kl"], 0);
            int SchoolId = Basic.Utils.StrToInt(context.Request.QueryString["lqyx"], 0);
            int LatestBenKeZhuanYeYear = Basic.Utils.StrToInt(context.Request.QueryString["dy"], 0);
            

            string html = "";
            //and fszy.SchoolProvinceId = " + SchoolProvinceId + "
            DataTable dt = DAL.TengXB.FenShengZhuanYeLuQu.GetFenShengZhuanYeLuQuList(" fszy.DataYear = " + LatestBenKeZhuanYeYear + "  AND fszy.ProvinceId = " + ProvinceId + " AND fszy.PiCi = " + PiCi + " AND fszy.KeLei = " + KeLei + " AND fszy.SchoolId = " + SchoolId, ProvinceId, LatestBenKeZhuanYeYear);
            
            if (dt != null && dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    html += "<option value=\"" + dt.Rows[i]["Id"].ToString() + "\">" + dt.Rows[i]["ProfessionalName"].ToString() + "</option>";
                }
            }

            context.Response.Write(html);
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