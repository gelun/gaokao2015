using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.IO;
using System.Web.Script.Serialization;
using System.Data;

namespace DAL
{
    public class AnalysisArea
    {

        //解析所在地区
        public static int GetProvinceIdByIp()
        {
            int ProvinceId = 0;

            Entity.AreaJson areaJsonInfo = GetAreaModel();

            if (areaJsonInfo != null)
            {
                if (areaJsonInfo.code == "0")
                {
                    // string area_id = areaJsonInfo.data.area_id;
                    string RegionId = areaJsonInfo.data.region_id;

                    DataTable dt = DAL.Province.ProvinceList("AdminCode='" + RegionId + "'");
                    if (dt.Rows.Count > 0)
                    {
                        ProvinceId = Basic.TypeConverter.StrToInt(dt.Rows[0]["ProvinceID"].ToString(), 0);
                    }
                }
            }
            else
            {
                //获取数据失败
            }

            return ProvinceId;
        }

        public static Entity.AreaJson AreaJsonInfo() {
            return GetAreaModel();
        }


        public static Entity.AreaJson GetAreaModel()
        {
            //重新请求数据
            string ip = HttpContext.Current.Request.UserHostAddress;
            //请求数据

            string formUrl = "http://ip.taobao.com/service/getIpInfo.php?ip=" + ip;

            CookieContainer cookieContainer = new CookieContainer();
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(formUrl);

            string jsonCode = string.Empty;


            request.Method = "GET";
            request.KeepAlive = false;
            request.AllowAutoRedirect = true;
            request.ContentType = "application/x-www-form-urlencoded";
            request.UserAgent = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.1; SV1; .NET CLR  2.0.50727; .NET CLR 3.0.04506.648; .NET CLR 3.5.21022; .NET CLR  3.0.4506.2152; .NET CLR 3.5.30729)";
            request.CookieContainer = cookieContainer;
            HttpWebResponse SendSMSResponse = (HttpWebResponse)request.GetResponse();

            if (SendSMSResponse.StatusCode == HttpStatusCode.OK)
            {
                StreamReader SendSMSResponseStream = new StreamReader(SendSMSResponse.GetResponseStream());

                ////在这儿处理返回的文本就OK了,如：
                jsonCode = SendSMSResponseStream.ReadToEnd();

                JavaScriptSerializer js = new JavaScriptSerializer();//将json格式的数据jsont转换为Model.WebSet实体类对象   

                //return null;
                Entity.AreaJson arjson = js.Deserialize<Entity.AreaJson>(jsonCode);

                SendSMSResponse.Close();
                SendSMSResponseStream.Close();

                if (arjson != null)
                {
                    //对象获取成功
                    return arjson;
                }

            }

            return null;
        }

    }
}