using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.IO;
using System.Text;
using Basic.SendMobiles;


namespace Basic
{
    public class SendMobile
    {
        /// <summary>
        /// 发送短信息
        /// </summary>
        /// <param name="strMobile">接收方的手机号码</param>
        /// <param name="strContent">短信内容</param>
        /// <returns></returns>
        public static bool SendMobileMsg(string strMobile, string strContent)
        {
            string phone = strMobile;
            //校验手机号码

            //RegexOptions options = RegexOptions.Singleline | RegexOptions.IgnoreCase;
            // Regex regex = new Regex(@"^(1[3|8|][0-9]|15[0|3|6|7|8|9]|18[8|9])\d{8}$", options);
            if (!System.Text.RegularExpressions.Regex.IsMatch(phone, @"^(1[3|8|][0-9]|15[0|3|6|7|8|9]|18[8|9])\d{8}$"))
            {
                return false;
            }


            //发送短信息

            WebService sms = new WebService();

            //string sn = "SDK-QXH-010-00001";
            //string pwd = Basic.CreateMD5.GetMD5(sn + "5a0@ac75");

            string sn = "SDK-WSS-010-05570";
            string pwd = Basic.CreateMD5.GetMD5(sn + "d-e[78-[");

            string mobile = strMobile;
            string content = strContent + "【格伦教育】";
            string ext = "";
            string sedtime = "";


            string result = sms.mt(sn, pwd, mobile, content, ext, sedtime, "");



            return true;
        }


        //public static bool SendMobileMsg(string msgContent, List<string> destListPhones)
        //{
        //    try
        //    {
        //        bool result = false;
        //        string strPhones = string.Join(";", destListPhones.ToArray());
        //        strPhones += ";";
        //        var encoding = System.Text.Encoding.GetEncoding("GB2312");

        //        string postData = string.Format("uid=用户名&pwd=密码&mobile={0};&msg={1}&dtime=", strPhones, msgContent);

        //        byte[] data = encoding.GetBytes(postData);

        //        // 定义 WebRequest
        //        HttpWebRequest myRequest =
        //       (HttpWebRequest)WebRequest.Create("http://www.smsadmin.cn/smsmarketing/wwwroot/api/post_send/");

        //        myRequest.Method = "POST";
        //        myRequest.ContentType = "application/x-www-form-urlencoded";
        //        myRequest.ContentLength = data.Length;

        //        Stream newStream = myRequest.GetRequestStream();

        //        //发送数据
        //        newStream.Write(data, 0, data.Length);
        //        newStream.Close();

        //        // 得到 Response
        //        HttpWebResponse myResponse = (HttpWebResponse)myRequest.GetResponse();
        //        StreamReader reader = new StreamReader(myResponse.GetResponseStream(), Encoding.Default);
        //        string content = reader.ReadToEnd();

        //        if (content.Substring(0, 1) == "0")
        //            result = true;
        //        else
        //        {
        //            if (content.Substring(0, 1) == "2") //余额不足
        //            {
        //                //"手机短信余额不足";
        //                //TODO
        //            }
        //            else
        //            {
        //                //短信发送失败的其他原因，请参看官方API
        //            }
        //            result = false;
        //        }

        //        return result;
        //    }
        //    catch
        //    {
        //        return false;
        //    }

        //}
    }
}