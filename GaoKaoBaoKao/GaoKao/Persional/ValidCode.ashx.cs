using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;

namespace GaoKao.Persional
{
    /// <summary>
    /// ValidCode 的摘要说明
    /// </summary>
    public class ValidCode : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            
            string strCode = Basic.RequestHelper.GetQueryString("code");
            
            HttpSessionState session = context.Session;
            
            //获取存储在session中的验证码
            if (session["CheckCode"] != null)
            {
                string strCheckCode=session["CheckCode"].ToString().ToLower();
                if (strCheckCode != strCode.ToLower())
                {
                    //验证码不正确
                    context.Response.Write("输入的验证码不正确");
                }
                else
                {
                    //验证码正确
                    context.Response.Write("1");
                }
            }
            else
            {
                context.Response.Write("验证码已过期");
            }

        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }

        public void Abandon()
        {
            throw new NotImplementedException();
        }

        public void Add(string name, object value)
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public int CodePage
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public HttpCookieMode CookieMode
        {
            get { throw new NotImplementedException(); }
        }

        public void CopyTo(Array array, int index)
        {
            throw new NotImplementedException();
        }

        public int Count
        {
            get { throw new NotImplementedException(); }
        }

        public System.Collections.IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public bool IsCookieless
        {
            get { throw new NotImplementedException(); }
        }

        public bool IsNewSession
        {
            get { throw new NotImplementedException(); }
        }

        public bool IsReadOnly
        {
            get { throw new NotImplementedException(); }
        }

        public bool IsSynchronized
        {
            get { throw new NotImplementedException(); }
        }

        public System.Collections.Specialized.NameObjectCollectionBase.KeysCollection Keys
        {
            get { throw new NotImplementedException(); }
        }

        public int LCID
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public SessionStateMode Mode
        {
            get { throw new NotImplementedException(); }
        }

        public void Remove(string name)
        {
            throw new NotImplementedException();
        }

        public void RemoveAll()
        {
            throw new NotImplementedException();
        }

        public void RemoveAt(int index)
        {
            throw new NotImplementedException();
        }

        public string SessionID
        {
            get { throw new NotImplementedException(); }
        }

        public HttpStaticObjectsCollection StaticObjects
        {
            get { throw new NotImplementedException(); }
        }

        public object SyncRoot
        {
            get { throw new NotImplementedException(); }
        }

        public int Timeout
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public object this[int index]
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public object this[string name]
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }
    }
}