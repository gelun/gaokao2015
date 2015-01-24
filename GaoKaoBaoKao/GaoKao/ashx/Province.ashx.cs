using System;
using System.Collections.Generic;
using System.Data;
using System.Web;

namespace GaoKao.ashx
{
    /// <summary>
    /// Province 的摘要说明
    /// </summary>
    public class Province : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            //int ProvinceId = Basic.Utils.StrToInt(context.Request.QueryString["sfid"], 0);
            int YunXu = Basic.Utils.StrToInt(context.Request.QueryString["yxxx"], 1);
            string html = "";
            if(YunXu == 1)
                html += "<option value=\"0\">请选择</option>";
            html += "<option value=\"1\">北京</option>";
            html += "<option value=\"2\">天津</option>";
            html += "<option value=\"3\">河北</option>";
            html += "<option value=\"4\">山西</option>";
            html += "<option value=\"5\">内蒙古</option>";
            html += "<option value=\"6\">辽宁</option>";
            html += "<option value=\"7\">吉林</option>";
            html += "<option value=\"8\">黑龙江</option>";
            html += "<option value=\"9\">上海</option>";
            html += "<option value=\"10\">江苏</option>";
            html += "<option value=\"11\">浙江</option>";
            html += "<option value=\"12\">安徽</option>";
            html += "<option value=\"13\">福建</option>";
            html += "<option value=\"14\">江西</option>";
            html += "<option value=\"15\">山东</option>";
            html += "<option value=\"16\">河南</option>";
            html += "<option value=\"17\">湖北</option>";
            html += "<option value=\"18\">湖南</option>";
            html += "<option value=\"19\">广东</option>";
            html += "<option value=\"20\">广西</option>";
            html += "<option value=\"21\">海南</option>";
            html += "<option value=\"22\">重庆</option>";
            html += "<option value=\"23\">四川</option>";
            html += "<option value=\"24\">贵州</option>";
            html += "<option value=\"25\">云南</option>";
            html += "<option value=\"26\">西藏</option>";
            html += "<option value=\"27\">陕西</option>";
            html += "<option value=\"28\">甘肃</option>";
            html += "<option value=\"29\">青海</option>";
            html += "<option value=\"30\">宁夏</option>";
            html += "<option value=\"31\">新疆</option>";
            html += "<option value=\"32\">港澳台</option>";

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