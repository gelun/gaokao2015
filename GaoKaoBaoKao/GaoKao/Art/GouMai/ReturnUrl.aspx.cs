using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections.Specialized;
using System.Data;
using GaoKao.GaoKaoCard;

namespace GaoKao.Art.GouMai
{
    public partial class ReturnUrl : System.Web.UI.Page
    {
        protected string strCardList = "";
        protected string strResult = "";
        protected string strMobile = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            SortedDictionary<string, string> sPara = GetRequestGet();

            if (sPara.Count > 0)//判断是否有带返回参数
            {
                Notify aliNotify = new Notify();
                bool verifyResult = aliNotify.Verify(sPara, Request.QueryString["notify_id"], Request.QueryString["sign"]);

                if (verifyResult)//验证成功
                {
                    /////////////////////////////////////////////////////////////////////////////////////////////////////////////
                    //请在这里加上商户的业务逻辑程序代码

                    //——请根据您的业务逻辑来编写程序（以下代码仅作参考）——
                    //获取支付宝的通知返回参数，可参考技术文档中服务器异步通知参数列表

                    //商户订单号
                    string out_trade_no = Request.QueryString["out_trade_no"];
                    //支付宝交易号
                    string trade_no = Request.QueryString["trade_no"];
                    //交易状态
                    string trade_status = Request.QueryString["trade_status"];
                    //更新返回信息到数据库中
                    Entity.DingDan info = DAL.tengxb.dingdan.DingDanEntityGet(out_trade_no);
                    if (info != null)
                    {
                        strMobile = info.CellMobile;
                        strMobile = strMobile.Substring(0, 3) + "****" + strMobile.Substring(6);
                        if (Request.QueryString["trade_status"] == "TRADE_FINISHED" || Request.QueryString["trade_status"] == "TRADE_SUCCESS")
                        {
                            //TRADE_SUCCESS
                            // 交易成功，且可对该交易做操作，如：多级分润、退款等。
                            strResult = "success";
                            if (DAL.GaoKaoCard.GaoKaoCardCount("DingDanHao = '" + info.DingDanHao + "'") < info.Count)
                            {
                                //分配高考卡，并发送短信
                                FenPeiGaoKaoCard.FenPeiCard(info, 1);
                                //展示卡号
                                DataTable dt = DAL.GaoKaoCard.GaoKaoCardList("DingDanHao = '" + info.DingDanHao + "'");
                                if (dt != null)
                                {
                                    for (int i = 0; i < dt.Rows.Count; i++)
                                    {
                                        strCardList += "<tr><td style=\"color: #ff8c00\">" + dt.Rows[i]["KaHao"].ToString() + "</td><td style=\"color: #ff8c00\">" + dt.Rows[i]["MiMa"].ToString() + "</td><td><a href=\"/art/goumai/art.aspx?kh=" + dt.Rows[i]["KaHao"].ToString() + "\" style=\"color: #0185D9\">完善信息</a></td></tr>";
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
                                        strCardList += "<tr><td style=\"color: #ff8c00\">" + dt.Rows[i]["KaHao"].ToString() + "</td><td style=\"color: #ff8c00\">" + dt.Rows[i]["MiMa"].ToString() + "</td><td><a href=\"/art/goumai/art.aspx?kh=" + dt.Rows[i]["KaHao"].ToString() + "\" style=\"color: #0185D9\">完善信息</a></td></tr>";
                                    }
                                }
                            }
                        }
                        else
                        {
                            //付款失败
                            // Basic.SendMobile.SendMobileMsg("15810621454", "付款失败");
                        }

                    }
                    /////////////////////////////////////////////////////////////////////////////////////////////////////////////
                }
                else//验证失败
                {
                    strResult = "fail";
                    Response.Write("fail");
                }
            }
            else
            {
                strResult = "无通知参数";
                // Response.Write("无通知参数");
            }
        }

        /// <summary>
        /// 获取支付宝GET过来通知消息，并以“参数名=参数值”的形式组成数组
        /// </summary>
        /// <returns>request回来的信息组成的数组</returns>
        public SortedDictionary<string, string> GetRequestGet()
        {
            int i = 0;
            SortedDictionary<string, string> sArray = new SortedDictionary<string, string>();
            NameValueCollection coll;
            //Load Form variables into NameValueCollection variable.
            coll = Request.QueryString;

            // Get names of all forms into a string array.
            String[] requestItem = coll.AllKeys;

            for (i = 0; i < requestItem.Length; i++)
            {
                sArray.Add(requestItem[i], Request.QueryString[requestItem[i]]);
            }

            return sArray;
        }
    }
}