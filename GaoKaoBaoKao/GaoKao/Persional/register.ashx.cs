using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GaoKao.Persional
{
    /// <summary>
    /// register 的摘要说明
    /// </summary>
    public class register : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";

            string strBank = Basic.RequestHelper.GetFormString("bank");
            string strPwd = Basic.RequestHelper.GetFormString("password");

            if (string.IsNullOrEmpty(strBank))
            {
                context.Response.Write("账号不能为空");
            }
            else
            {
                if (string.IsNullOrEmpty(strPwd))
                {
                    context.Response.Write("密码不能为空");
                }
                else
                {
                    //检测账号是否已经存在了
                    if (DAL.Join_Student.Join_StudentCount("StudentBank = '" + strBank + "'") > 0)
                    {
                        context.Response.Write("本账号已存在");
                    }
                    else
                    {
                        if (DAL.TengXB.Join_Student.Join_Student_CreateBank(strBank, Basic.CreateMD5.Md5Encrypt(strPwd)) > 0)
                        {
                            context.Response.Write("注册成功");
                        }
                        else
                        {
                            context.Response.Write("注册失败");
                        }
                    }
                }
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