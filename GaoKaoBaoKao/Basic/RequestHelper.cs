using System;
using System.Web;

namespace Basic
{
	/// <summary>
	/// Request������
	/// </summary>
	public class RequestHelper
	{
		/// <summary>
		/// �жϵ�ǰҳ���Ƿ���յ���Post����
		/// </summary>
		/// <returns>�Ƿ���յ���Post����</returns>
		public static bool IsPost()
		{
			return HttpContext.Current.Request.HttpMethod.Equals("POST");
		}

		/// <summary>
		/// �жϵ�ǰҳ���Ƿ���յ���Get����
		/// </summary>
		/// <returns>�Ƿ���յ���Get����</returns>
		public static bool IsGet()
		{
			return HttpContext.Current.Request.HttpMethod.Equals("GET");
		}

		/// <summary>
		/// ����ָ���ķ�����������Ϣ
		/// </summary>
		/// <param name="strName">������������</param>
		/// <returns>������������Ϣ</returns>
		public static string GetServerString(string strName)
		{
			if (HttpContext.Current.Request.ServerVariables[strName] == null)
				return "";

            return HttpContext.Current.Request.ServerVariables[strName].ToString();
		}

		/// <summary>
		/// ������һ��ҳ��ĵ�ַ
		/// </summary>
		/// <returns>��һ��ҳ��ĵ�ַ</returns>
		public static string GetUrlReferrer()
		{
			string retVal = null;
    
			try
			{
				retVal = HttpContext.Current.Request.UrlReferrer.ToString();
			}
			catch{}
			
			if (retVal == null)
				return "";
    
			return retVal;
		}
		
		/// <summary>
		/// �õ���ǰ��������ͷ
		/// </summary>
		/// <returns></returns>
		public static string GetCurrentFullHost()
		{
			HttpRequest request = System.Web.HttpContext.Current.Request;
			if (!request.Url.IsDefaultPort)
				return string.Format("{0}:{1}", request.Url.Host, request.Url.Port.ToString());

            return request.Url.Host;
		}

		/// <summary>
		/// �õ�����ͷ
		/// </summary>
		/// <returns></returns>
		public static string GetHost()
		{
			return HttpContext.Current.Request.Url.Host;
		}


		/// <summary>
		/// ��ȡ��ǰ�����ԭʼ URL(URL ������Ϣ֮��Ĳ���,������ѯ�ַ���(�������))
		/// </summary>
		/// <returns>ԭʼ URL</returns>
		public static string GetRawUrl()
		{
			return HttpContext.Current.Server.UrlPathEncode(HttpContext.Current.Request.RawUrl);
		}

		/// <summary>
		/// �жϵ�ǰ�����Ƿ�������������
		/// </summary>
		/// <returns>��ǰ�����Ƿ�������������</returns>
		public static bool IsBrowserGet()
		{
			string[] BrowserName = {"ie", "opera", "netscape", "mozilla", "konqueror", "firefox"};
			string curBrowser = HttpContext.Current.Request.Browser.Type.ToLower();
			for (int i = 0; i < BrowserName.Length; i++)
			{
				if (curBrowser.IndexOf(BrowserName[i]) >= 0)
					return true;
			}
			return false;
		}

		/// <summary>
		/// �ж��Ƿ�����������������
		/// </summary>
		/// <returns>�Ƿ�����������������</returns>
		public static bool IsSearchEnginesGet()
		{
            if (HttpContext.Current.Request.UrlReferrer == null)
                return false;

            string[] SearchEngine = {"google", "yahoo", "msn", "baidu", "sogou", "sohu", "sina", "163", "lycos", "tom", "yisou", "iask", "soso", "gougou", "zhongsou"};
			string tmpReferrer = HttpContext.Current.Request.UrlReferrer.ToString().ToLower();
			for (int i = 0; i < SearchEngine.Length; i++)
			{
				if (tmpReferrer.IndexOf(SearchEngine[i]) >= 0)
					return true;
			}
			return false;
		}

		/// <summary>
		/// ��õ�ǰ����Url��ַ
		/// </summary>
		/// <returns>��ǰ����Url��ַ</returns>
		public static string GetUrl()
		{
			return HttpContext.Current.Request.Url.ToString();
		}

        /// <summary>
        /// ��õ�ǰҳ�����ƣ���/default.aspx��
        /// </summary>
        /// <returns>��ǰ����Url��ַ��path</returns>
        public static string GetPath()
        {
            return HttpContext.Current.Request.Path;
        }

		/// <summary>
		/// ��õ�ǰҳ�������
		/// </summary>
		/// <returns>��ǰҳ�������</returns>
		public static string GetPageName()
		{
			string [] urlArr = HttpContext.Current.Request.Url.AbsolutePath.Split('/');
			return urlArr[urlArr.Length - 1].ToLower();
		}

        /// <summary>
        /// ��õ�ǰҳ��ķ�����·��
        /// </summary>
        /// <returns>��ǰҳ�������</returns>
        public static string GetPagePath()
        {
            string AbsolutePath = HttpContext.Current.Request.Url.AbsolutePath;
            string[] urlArr = AbsolutePath.Split('/');

            return AbsolutePath.Substring(0, AbsolutePath.Length - urlArr[urlArr.Length - 1].Length);
        }
		/// <summary>
		/// ���ر���Url�������ܸ���
		/// </summary>
		/// <returns></returns>
		public static int GetParamCount()
		{
			return HttpContext.Current.Request.Form.Count + HttpContext.Current.Request.QueryString.Count;
		}

        #region ��ȡ����URL����ֵ
        /// <summary>
        /// ���ָ��Url������ֵ
        /// </summary>
        /// <param name="strName">Url����</param>
        /// <returns>Url������ֵ</returns>
        public static string GetQueryString(string strName)
        {
            return GetQueryString(strName, false);
        }

        /// <summary>
        /// ���ָ��Url������ֵ
        /// </summary> 
        /// <param name="strName">Url����</param>
        /// <param name="sqlSafeCheck">�Ƿ����SQL��ȫ���</param>
        /// <returns>Url������ֵ</returns>
        public static string GetQueryString(string strName, bool sqlSafeCheck)
        {
            if (HttpContext.Current.Request.QueryString[strName] == null)
                return "";

            if (sqlSafeCheck && !Utils.IsSafeSqlString(HttpContext.Current.Request.QueryString[strName]))
                return "unsafe string";

            return HttpContext.Current.Request.QueryString[strName];
        }

        /// <summary>
		/// ���ָ����������ֵ
		/// </summary>
		/// <param name="strName">������</param>
		/// <returns>��������ֵ</returns>
		public static string GetFormString(string strName)
		{
			return GetFormString(strName, false);
		}

        /// <summary>
        /// ���ָ����������ֵ
        /// </summary>
        /// <param name="strName">������</param>
        /// <param name="sqlSafeCheck">�Ƿ����SQL��ȫ���</param>
        /// <returns>��������ֵ</returns>
        public static string GetFormString(string strName, bool sqlSafeCheck)
        {
            if (HttpContext.Current.Request.Form[strName] == null)
                return "";

            if (sqlSafeCheck && !Utils.IsSafeSqlString(HttpContext.Current.Request.Form[strName]))
                return "unsafe string";

            return HttpContext.Current.Request.Form[strName];
        }

		/// <summary>
		/// ���Url���������ֵ, ���ж�Url�����Ƿ�Ϊ���ַ���, ��ΪTrue�򷵻ر�������ֵ
		/// </summary>
		/// <param name="strName">����</param>
		/// <returns>Url���������ֵ</returns>
		public static string GetString(string strName)
		{
            return GetString(strName, false);
		}

        /// <summary>
        /// ���Url���������ֵ, ���ж�Url�����Ƿ�Ϊ���ַ���, ��ΪTrue�򷵻ر�������ֵ
        /// </summary>
        /// <param name="strName">����</param>
        /// <param name="sqlSafeCheck">�Ƿ����SQL��ȫ���</param>
        /// <returns>Url���������ֵ</returns>
        public static string GetString(string strName, bool sqlSafeCheck)
        {
            if ("".Equals(GetQueryString(strName)))
                return GetFormString(strName, sqlSafeCheck);
            else
                return GetQueryString(strName, sqlSafeCheck);
        }

        /// <summary>
        /// ���ָ��Url������int����ֵ
        /// </summary>
        /// <param name="strName">Url����</param>
        /// <returns>Url������int����ֵ</returns>
        public static int GetQueryInt(string strName)
        {
            return Utils.StrToInt(HttpContext.Current.Request.QueryString[strName], 0);
        }


		/// <summary>
		/// ���ָ��Url������int����ֵ
		/// </summary>
		/// <param name="strName">Url����</param>
		/// <param name="defValue">ȱʡֵ</param>
		/// <returns>Url������int����ֵ</returns>
		public static int GetQueryInt(string strName, int defValue)
		{
			return Utils.StrToInt(HttpContext.Current.Request.QueryString[strName], defValue);
		}


		/// <summary>
		/// ���ָ����������int����ֵ
		/// </summary>
		/// <param name="strName">������</param>
		/// <param name="defValue">ȱʡֵ</param>
		/// <returns>��������int����ֵ</returns>
		public static int GetFormInt(string strName, int defValue)
		{
			return Utils.StrToInt(HttpContext.Current.Request.Form[strName], defValue);
		}

        #region Decimal
        public static decimal GetQueryDecimal(string strName)
        {
            return Utils.StrToDecimal(HttpContext.Current.Request.QueryString[strName], 0m);
        }
        public static decimal GetQueryDecimal(string strName, decimal defValue)
        {
            return Utils.StrToDecimal(HttpContext.Current.Request.QueryString[strName], defValue);
        }
        public static decimal GetFormDecimal(string strName, decimal defValue)
        {
            return Utils.StrToDecimal(HttpContext.Current.Request.Form[strName], defValue);
        }
        #endregion

        /// <summary>
		/// ���ָ��Url���������int����ֵ, ���ж�Url�����Ƿ�Ϊȱʡֵ, ��ΪTrue�򷵻ر�������ֵ
		/// </summary>
		/// <param name="strName">Url�������</param>
		/// <param name="defValue">ȱʡֵ</param>
		/// <returns>Url���������int����ֵ</returns>
		public static int GetInt(string strName, int defValue)
		{
			if (GetQueryInt(strName, defValue) == defValue)
				return GetFormInt(strName, defValue);
			else
				return GetQueryInt(strName, defValue);
		}

        #region float
        /// <summary>
		/// ���ָ��Url������float����ֵ
		/// </summary>
		/// <param name="strName">Url����</param>
		/// <param name="defValue">ȱʡֵ</param>
		/// <returns>Url������int����ֵ</returns>
		public static float GetQueryFloat(string strName, float defValue)
		{
			return Utils.StrToFloat(HttpContext.Current.Request.QueryString[strName], defValue);
		}


		/// <summary>
		/// ���ָ����������float����ֵ
		/// </summary>
		/// <param name="strName">������</param>
		/// <param name="defValue">ȱʡֵ</param>
		/// <returns>��������float����ֵ</returns>
		public static float GetFormFloat(string strName, float defValue)
		{
			return Utils.StrToFloat(HttpContext.Current.Request.Form[strName], defValue);
		}
		
		/// <summary>
		/// ���ָ��Url���������float����ֵ, ���ж�Url�����Ƿ�Ϊȱʡֵ, ��ΪTrue�򷵻ر�������ֵ
		/// </summary>
		/// <param name="strName">Url�������</param>
		/// <param name="defValue">ȱʡֵ</param>
		/// <returns>Url���������int����ֵ</returns>
		public static float GetFloat(string strName, float defValue)
		{
			if (GetQueryFloat(strName, defValue) == defValue)
				return GetFormFloat(strName, defValue);
			else
				return GetQueryFloat(strName, defValue);
		}
        #endregion

        /// <summary>
        /// ���ָ��Url������ֵ,Ĭ��1900��1��1��
        /// </summary>
        /// <param name="strName">Url����</param>
        /// <returns>Url������ֵ������1900��1��1��</returns>
        public static DateTime GetQueryDateTime(string strName)
        {
            return GetQueryDateTime(strName, Convert.ToDateTime("1900-1-1 00:00:01"));
        }

        /// <summary>
        /// ��ȡURL������ʱ��
        /// </summary>
        /// <param name="strName">Url����</param>
        /// <param name="datetime"></param>
        /// <returns>Url������ֵ</returns>
        public static DateTime GetQueryDateTime(string strName, DateTime datetime)
        {
            if (HttpContext.Current.Request.QueryString[strName] == null)
            {
                return datetime;
            }
            string str = HttpContext.Current.Request.QueryString[strName];
            if (str == "")
                return datetime;
            else
                return Convert.ToDateTime(str);
        }

        /// <summary>
        /// ���ָ��Form������ֵ,Ĭ��1900��1��1��
        /// </summary>
        /// <param name="strName">Url����</param>
        /// <returns>Url������ֵ������1900��1��1��</returns>
        public static DateTime GetFormDateTime(string strName)
        {
            return GetFormDateTime(strName, Convert.ToDateTime("1900-1-1 00:00:01"));
        }

        /// <summary>
        /// ��ȡURL������ʱ��
        /// </summary>
        /// <param name="strName">Url����</param>
        /// <param name="datetime"></param>
        /// <returns>Url������ֵ</returns>
        public static DateTime GetFormDateTime(string strName, DateTime datetime)
        {
            if (HttpContext.Current.Request.Form[strName] == null)
            {
                return datetime;
            }
            string str = HttpContext.Current.Request.Form[strName];
            if (str == "")
                return datetime;
            else
                return Convert.ToDateTime(str);
        }

        /// <summary>
        /// ҳ����һֵ��formȡֵ,������intֵ
        /// </summary>
        /// <param name="strName"></param>
        /// <returns>�ջ����ַ��������һ��,</returns>
        public static string GetFormListInt(string strName)
        {
            if (HttpContext.Current.Request.Form[strName] == null)
                return "";

            string str = HttpContext.Current.Request.Form[strName];
            if (string.IsNullOrEmpty(str) || ! System.Text.RegularExpressions.Regex.IsMatch(str.Trim(), @"^[1-9]([,]|[0-9])*$"))
                return "";
            else
                return str+",";
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cbl"></param>
        /// <returns>���ַ������� �����м��ã��ָ���</returns>
        public static string GetCheckBoxListValue(System.Web.UI.WebControls.CheckBoxList cbl)
        {
            //ȡ��CheckBoxListѡ�����ֵ
            string returnValue = "";
            if (cbl != null)
            {
                foreach (System.Web.UI.WebControls.ListItem item in cbl.Items)
                {
                    if(item.Selected == true)
                    {
                        returnValue += "," + item.Value;
                    }
                }
            }
            if (!string.IsNullOrEmpty(returnValue))
                returnValue = returnValue.Substring(1);
            return returnValue;
        }
        #endregion

        

        /// <summary>
		/// ��õ�ǰҳ��ͻ��˵�IP
		/// </summary>
		/// <returns>��ǰҳ��ͻ��˵�IP</returns>
		public static string GetIP()
		{
			string result = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
			if (string.IsNullOrEmpty(result))
                result = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];

			if (string.IsNullOrEmpty(result))
				result = HttpContext.Current.Request.UserHostAddress;

			if (string.IsNullOrEmpty(result) || !Utils.IsIP(result))
				return "127.0.0.1";

			return result;
		}

		/// <summary>
		/// �����û��ϴ����ļ�
		/// </summary>
		/// <param name="path">����·��</param>
		public static void SaveRequestFile(string path)
		{
			if (HttpContext.Current.Request.Files.Count > 0)
			{
				HttpContext.Current.Request.Files[0].SaveAs(path);
			}
		}
	}
}
