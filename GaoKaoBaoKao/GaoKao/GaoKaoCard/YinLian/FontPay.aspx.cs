using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using com.unionpay.upop.sdk;
using System.Data;

namespace GaoKao.GaoKaoCard.YinLian
{
    public partial class FontPay : System.Web.UI.Page
    {
        protected string strResult = "";
        protected string strCardList = "";
        protected string message = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            NotifyCallback_Front();
        }

        //前台回调页面
        public string NotifyCallback_Front()
        {
            if (Request.HttpMethod == "POST")
            {
                // 要使用各种Srv必须先使用LoadConf载入配置
                string url = Server.MapPath("/App_Data/conf.xml.config");
                UPOPSrv.LoadConf(url);

                //拼接银联返回信息
                Dictionary<string, string> dic = Util.NameValueCollection2StrDict(Request.Form);
                foreach (KeyValuePair<string, string> kvp in dic)
                {
                    Console.WriteLine("key={0},value={1}", kvp.Key, kvp.Value);
                    message += kvp.Key + ":" + kvp.Value + " | ";
                }


                SrvResponse resp = new SrvResponse(dic);

                //订单号
                string orderNumber = resp.Fields["orderNumber"];

                //订单交易状态
                string respCode = resp.Fields["respCode"];
                //  int PayID = Convert.ToInt32(orderNumber.Replace(UnionConfig.UnionPayingPrefix, ""));


                //更新返回信息到数据库中
                Entity.DingDan info = DAL.tengxb.dingdan.DingDanEntityGet(orderNumber);
                if (info != null)
                {

                    //支付成功，且验证过了
                    if (info.State == 0)
                    {
                        switch (resp.ResponseCode)
                        {
                            case SrvResponse.RESP_SUCCESS:
                                {
                                    try
                                    {
                                        //string orderNumber = resp.Fields["orderNumber"];
                                        //int PayID = Convert.ToInt32(orderNumber.Substring(14, orderNumber.Length - 14));
                                        //修改订单的状态为“已支付” 

                                        info.State = 1;//00 支付成功

                                        //TRADE_SUCCESS
                                        // 交易成功，且可对该交易做操作，如：多级分润、退款等。
                                        if (DAL.GaoKaoCard.GaoKaoCardCount("DingDanHao = '" + info.DingDanHao + "'") < info.Count)
                                        {
                                            //分配高考卡，并发送短信
                                            FenPeiGaoKaoCard.FenPeiCard(info);
                                            //展示卡号
                                            DataTable dt = DAL.GaoKaoCard.GaoKaoCardList("DingDanHao = '" + info.DingDanHao + "'");
                                            if (dt != null)
                                            {
                                                for (int i = 0; i < dt.Rows.Count; i++)
                                                {
                                                    strCardList += "<p>账号：" + dt.Rows[i]["KaHao"].ToString() + " &nbsp;&nbsp; 密码：" + dt.Rows[i]["MiMa"].ToString() + "</p>";
                                                }
                                            }
                                        }
                                        else
                                        {
                                            //展示卡号
                                            DataTable dt = DAL.GaoKaoCard.GaoKaoCardList("DingDanHao = '" + info.DingDanHao + "'");
                                            if (dt != null)
                                            {
                                                for (int i = 0; i < dt.Rows.Count; i++)
                                                {
                                                    strCardList += "<p>账号：" + dt.Rows[i]["KaHao"].ToString() + " &nbsp;&nbsp; 密码：" + dt.Rows[i]["MiMa"].ToString() + "</p>";
                                                }
                                            }
                                        }
                                        /*返回码200代表商铺已经成功收到并正确解析出后台的通知，其他的返回码则认为通知失败，
                                        返回给银联支付，若不返回此码，银联会重发通知，最多5次*/
                                        //Response.Write("200");
                                    }
                                    catch { }
                                    finally {

                                        Basic.Email.sendMail("qiaoht@gelun.org", "高考报考卡购买付款成功", "订单号：" + info.DingDanHao + "<br />" + info.Body + "<br />联系电话：" + info.CellMobile + "<br />" + strCardList);
                                        Basic.Email.sendMail("zhangyh@gelun.org", "高考报考卡购买付款成功", "订单号：" + info.DingDanHao + "<br />" + info.Body + "<br />联系电话：" + info.CellMobile);

                                    }
                                }
                                break;
                            case "02":
                                info.State = 2;//02 卡号无效
                                break;
                            case "11":
                                info.State = 3;//11 余额不足
                                break;
                            default:
                                info.State = 4;//11 订单支付失败,请到您的订单列表中重新进行支付操作
                                break;
                        }

                        info.Memo = "高考报考卡_银联支付，返回的参数：" + message;
                        DAL.DingDan.DingDanEdit(info);


                    }
                    else
                    {
                        //Basic.Email.sendMail("tengxb@gelun.org", "银联支付", "又传过来一次了fontpay");
                    }


                    strResult = info.State.ToString();
                }
            }


            return message;
        }
    }
}