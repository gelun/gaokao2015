using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections.Specialized;
using GaoKao.GaoKaoCard;

namespace GaoKao.Art.GouMai
{
    public partial class NotifyUrl : System.Web.UI.Page
    {
        //交易状态，
        //只是生成订单的话，默认为0
        //返回的状态值，以此对应如下：
        //1.WAIT_BUYER_PAY:1       交易创建，等待买家付款。
        //2.TRADE_CLOSED:2       (1)在指定时间段内未支付时关闭的交易；(2)在交易完成全额退款成功时关闭的交易。
        //3.TRADE_SUCCESS:3    交易成功，且可对该交易做操作，如：多级分润、退款等。
        //4.TRADE_PENDING:4    等待卖家收款（买家付款后，如果卖家账号被冻结）。
        //5.TRADE_FINISHED:5    交易成功且结束，即不可再做任何操作
        protected void Page_Load(object sender, EventArgs e)
        {
            SortedDictionary<string, string> sPara = GetRequestPost();

            if (sPara.Count > 0)//判断是否有带返回参数
            {
                Notify aliNotify = new Notify();
                bool verifyResult = aliNotify.Verify(sPara, Request.Form["notify_id"], Request.Form["sign"]);

                if (verifyResult)//验证成功
                {
                    /////////////////////////////////////////////////////////////////////////////////////////////////////////////
                    //请在这里加上商户的业务逻辑程序代码

                    //商户订单号
                    string out_trade_no = Request.Form["out_trade_no"];
                    //支付宝交易号
                    string trade_no = Request.Form["trade_no"];
                    //交易状态
                    string trade_status = Request.Form["trade_status"];

                    //更新返回信息到数据库中
                    Entity.DingDan info = DAL.tengxb.dingdan.DingDanEntityGet(out_trade_no);
                    if (info != null)
                    {
                        //更新数据库中的状态值
                        info.State = 3;
                        switch (Request.Form["trade_status"])
                        {
                            case "WAIT_BUYER_PAY":
                                info.State = 1;
                                break;
                            case "TRADE_CLOSED":
                                info.State = 2;
                                break;
                            case "TRADE_SUCCESS":
                                info.State = 3;
                                break;
                            case "TRADE_PENDING":
                                info.State = 4;
                                break;
                            case "TRADE_FINISHED":
                                info.State = 5;
                                break;
                            default:
                                break;
                        }

                        info.Memo = "支付宝交易号：" + trade_no;
                        DAL.DingDan.DingDanEdit(info);
                    }


                    if (Request.Form["trade_status"] == "TRADE_FINISHED" || Request.Form["trade_status"] == "TRADE_SUCCESS")
                    {

                        Basic.Email.sendMail("qiaoht@gelun.org", "艺术高考VIP卡购买付款成功", "订单号：" + info.DingDanHao + "<br />" + info.Body + "<br />联系电话：" + info.CellMobile);
                        Basic.Email.sendMail("zhangyh@gelun.org", "艺术高考VIP卡购买付款成功", "订单号：" + info.DingDanHao + "<br />" + info.Body + "<br />联系电话：" + info.CellMobile);

                        //TRADE_SUCCESS
                        // 交易成功，且可对该交易做操作，如：多级分润、退款等。
                        if (DAL.GaoKaoCard.GaoKaoCardCount("DingDanHao = '" + info.DingDanHao + "'") < info.Count)
                        {
                            //分配高考卡，并发送短信
                            FenPeiGaoKaoCard.FenPeiCard(info, 1);
                        }
                    }
                    else
                    {
                        //付款失败
                        // Basic.SendMobile.SendMobileMsg("18500525896", "付款失败");
                    }

                    Response.Write("success");  //请不要修改或删除
                }
                else//验证失败
                {
                    Response.Write("fail");
                }
            }
            else
            {
                Response.Write("无通知参数");
            }
        }

        /// <summary>
        /// 获取支付宝POST过来通知消息，并以“参数名=参数值”的形式组成数组
        /// </summary>
        /// <returns>request回来的信息组成的数组</returns>
        public SortedDictionary<string, string> GetRequestPost()
        {
            int i = 0;
            SortedDictionary<string, string> sArray = new SortedDictionary<string, string>();
            NameValueCollection coll;
            //Load Form variables into NameValueCollection variable.
            coll = Request.Form;

            // Get names of all forms into a string array.
            String[] requestItem = coll.AllKeys;

            for (i = 0; i < requestItem.Length; i++)
            {
                sArray.Add(requestItem[i], Request.Form[requestItem[i]]);
            }

            return sArray;
        }
    }
}