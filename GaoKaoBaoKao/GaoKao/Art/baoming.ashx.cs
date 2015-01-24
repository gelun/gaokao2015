using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GaoKao.Art
{
    /// <summary>
    /// baoming 的摘要说明
    /// </summary>
    public class baoming : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";

            string strName = Basic.RequestHelper.GetQueryString("name");
            string strMobile = Basic.RequestHelper.GetQueryString("mobile");
            string strProvince = Basic.RequestHelper.GetQueryString("province");
            string strYK = Basic.RequestHelper.GetQueryString("yk");

            if (strName != "" && strMobile != "" && strProvince != "")
            {
                Basic.Email.sendMail("qiaoht@gelun.org", "艺考在线报名", "姓名：" + strName + "，电话：" + strMobile + "，省份:" + strProvince + ",艺考类型:" + strYK + "。(http://gaokao.gelunjiaoyu.com/2015ysgk1v1.shtml)");
                Basic.Email.sendMail("mahl@gelun.org", "艺考在线报名", "姓名：" + strName + "，电话：" + strMobile + "，省份:" + strProvince + ",艺考类型:" + strYK + "。(http://gaokao.gelunjiaoyu.com/2015ysgk1v1.shtml)");
                
                context.Response.Write("ok");
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