using System;
using System.Collections.Generic;
using System.Data;
using System.Web;

namespace GaoKao.ashx
{
    /// <summary>
    /// FenShengYuanXiaoLuQu 的摘要说明
    /// </summary>
    public class FenShengYuanXiaoLuQu : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            int SchoolProvinceId = Basic.Utils.StrToInt(context.Request.QueryString["yxsfid"], 0);
            int ProvinceId = Basic.Utils.StrToInt(context.Request.QueryString["sfid"], 0);
            int PiCi = Basic.Utils.StrToInt(context.Request.QueryString["pc"], 0);
            int KeLei = Basic.Utils.StrToInt(context.Request.QueryString["kl"], 0);
            string html = "";
            DataTable dt = DAL.TengXB.FenShengYuanXiaoLuQu.GetFenShengYuanXiaoList(" s.ProvinceId = " + SchoolProvinceId + " AND fsyx.ProvinceId = " + ProvinceId + " AND fsyx.PiCi = " + PiCi + " AND fsyx.KeLei = " + KeLei,ProvinceId);
            //yxsfid=&sfid=&pc=&kl=
            if (dt != null && dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    html += "<option value=\"" + dt.Rows[i]["Id"].ToString() + "\" k=\"" + dt.Rows[i]["Logo"].ToString() + "\">" + dt.Rows[i]["SchoolName"].ToString() + "</option>";
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