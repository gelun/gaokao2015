using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;
using System.Data;

namespace Basic.FileDispose
{
    public  class Tempinc
    {
        Regex[] regex = new Regex[5];
        private static string Model;

        public Tempinc(string StrModule)
        {
            this._StrModule = StrModule;
            Model = StrModule;
            RegexOptions options;
            options = RegexOptions.Singleline | RegexOptions.IgnoreCase;
            regex[0] = new Regex(@"{[WS][SY]_\w+}", options);
            regex[1] = new Regex(@"{PB_\w+([\(]+(\b[,0-9]+\b)?[\)]+)?}", options);
            regex[2] = new Regex(@"{PR_\w+}", options);
            regex[3] = new Regex(@"../../../", options);
        }
        private string _StrModule;//Purchase_Trade Supply_Trade......
        public string StrModule
        {
            get { return this._StrModule; }
        }


        /// <summary>
        /// 获取模板
        /// </summary>
        /// <param name="pathName">模板路径</param>
        /// <returns></returns>
        public string GetTemplate(string pathName)
        {
            StringBuilder builder = new StringBuilder();
            string str = "";
            using (StreamReader reader = new StreamReader(pathName, Encoding.Default))
            {
                StringBuilder builder2 = new StringBuilder();
                builder2.Append(reader.ReadToEnd());
                reader.Close();
                str = Hope_HtmlResult(builder2.ToString());
            }

            return str;
        }


        /// <summary>
        /// 外部调用函数
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public string Hope_HtmlResult(string str)
        {
            string resultHtml = "";
            resultHtml = Hope_htmlAll(str);
            resultHtml = Hope_htmlAll(resultHtml);  //使用三层，考虑资源问题
            return resultHtml;
        }


        /// <summary>
        /// 标签处理方法
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        private string Hope_htmlAll(string str)
        {
            string Restr = "";
            Restr = str;
            string strInfo_PB = "";
            string strInfo_PR = "";
            string strInfo_SY = "";
            string[] arrInfo;
            try
            {

                //处理私有标签
                foreach (Match match in regex[2].Matches(Restr))
                {
                    strInfo_PR = strInfo_PR + match.Groups[0].ToString() + "|";
                }
                if (strInfo_PR != "")
                    Restr = "";// PRFunction(Restr, strInfo_PR);


                foreach (Match match in regex[0].Matches(Restr))
                {
                    //string Fun = tempTitle(match0.Groups[i].ToString());
                    //ReStr = str.Replace(match0.Groups[i].ToString(), eval(Fun));
                    strInfo_SY = strInfo_SY + match.Groups[0].ToString() + "|";
                }
                arrInfo = strInfo_SY.Split('|');
                for (int i = 0; i < arrInfo.Length - 1; i++)
                {
                   // Restr = Restr.Replace(arrInfo[i], eval(staticTitle(arrInfo[i].ToString())));
                }


                //处理公共标签
                foreach (Match match in regex[1].Matches(Restr))
                    strInfo_PB = strInfo_PB + match.Value.ToString() + "|";
                if (strInfo_PB != "")
                    Restr = "";// PBFunction(Restr, strInfo_PB);

            }
            catch (Exception e)
            {
                throw e;
            }

            return Restr;
        }


        /// <summary>
        /// 替换函数标签
        /// </summary>
        /// <param name="funTitle"></param>
        /// <param name="arry"></param>
        /// <returns></returns>
        private string eval(string str)
        {

            string Restr = "";
            TSystemLable Temp = new TSystemLable();
            try
            {
                switch (str.Substring(0, 3).ToUpper())
                {
                    case "WS_":   //处理用户自定义标签
                       // Restr = WSFunction(str);
                        break;
                    case "SY_":   //处理系统标签
                       /// Temp = Get_Function(str);
                       // if (Temp.ID == 0) throw new Exception("{" + str + "}");
                       // Restr = SYFunction(Temp);
                        break;
                }
            }
            catch (Exception e)
            {
                Restr = e.Message.ToString();
            }
            return Restr;
        }


      
        private string GetSortName(string Sort)
        {
            if (Basic.Utils.IsInt(Sort))
            {
                DataTable dt = new DataTable();
                if (dt.Rows.Count > 0)
                {
                    return dt.Rows[0]["Name"].ToString();
                }
            }
            return "{参数错误}";
        }

    }
}