using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GaoKao.Art.GouMai.YinLian
{
    public partial class PayQuery : System.Web.UI.Page
    {
        protected string strResult = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            Bind();
        }

        void Bind()
        {

            // **************演示交易查询接口***********************

            if (Request.HttpMethod == "POST")
            {
                // 要使用各种Srv必须先使用LoadConf载入配置
                com.unionpay.upop.sdk.UPOPSrv.LoadConf(Server.MapPath("/App_Data/conf.xml.config"));

                //获取订单号和订单时间
                string orderNumber = Request.Form["txtOrderID"];
                DateTime orderTime = DateTime.Parse(Request.Form["txtOrderTime"]);

                // 使用Dictionary保存参数
                System.Collections.Generic.Dictionary<string, string> param = new System.Collections.Generic.Dictionary<string, string>();

                // 填写参数
                param["transType"] = com.unionpay.upop.sdk.UPOPSrv.TransType.CONSUME;
                param["orderNumber"] = orderNumber;
                param["orderTime"] = orderTime.ToString("yyyyMMddHHmmss");

                // 创建后台交查询务对象
                com.unionpay.upop.sdk.QuerySrv srv = new com.unionpay.upop.sdk.QuerySrv(param);

                // 请求查询服务，得到SrvResponse回应对象
                com.unionpay.upop.sdk.SrvResponse resp = srv.Request();

                strResult+="<h1>";

                string queryStat = "";
                if (resp.ResponseCode == com.unionpay.upop.sdk.SrvResponse.RESP_SUCCESS)
                {
                    switch (resp.Fields["queryResult"].Trim()) // 根据queryResult字段来判断交易状态
                    {
                        case com.unionpay.upop.sdk.QuerySrv.QUERY_SUCCESS:
                            queryStat = "交易成功";
                            break;
                        case com.unionpay.upop.sdk.QuerySrv.QUERY_WAIT:
                            queryStat = "交易正在进行中";
                            break;
                        default:
                            queryStat = "未知状态";
                            break;
                    }

                }
                else // respCode 不为 RESP_SUCCESS 时，则可能是交易失败，也可能是本次查询请求出错
                {
                    // queryResult == QUERY_FAIL 时，代表交易失败。此时ResponseCode表示失败原因
                    if (resp.HasField("queryResult") && resp.Fields["queryResult"].Trim() == com.unionpay.upop.sdk.QuerySrv.QUERY_FAIL)
                    {
                        queryStat = string.Format("交易失败  <h3>ErrorCode=[{0}]</h3>", resp.ResponseCode);
                    }
                    else // 否则则为本次查询请求出错
                    {
                        string msg = resp.HasField("respMsg") ? resp.Fields["respMsg"] : "";
                        strResult+=String.Format("Error [{0}] : {1} ", resp.Fields["respCode"], msg);
                    }
                }

                if (queryStat != "") { strResult+=("交易状态：" + queryStat); }
                strResult+="</h1><br/>";
                strResult+="post string:" + resp.OrigPostString;

            }

        }
    }
}