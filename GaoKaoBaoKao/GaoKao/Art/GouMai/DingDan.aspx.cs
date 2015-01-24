using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;
using com.unionpay.upop.sdk;

namespace GaoKao.Art.GouMai
{
    public partial class DingDan : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //卡的类别名称
            lblDanJia.Text = "4600.00";//"0.01";
        }

        /// <summary>
        /// 选择支付方式后，去购买
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void imgSave_Click(object sender, ImageClickEventArgs e)
        {
            int intCheck = 0;
            if (rbtZhiFuBao.Checked == true)
            {
                intCheck = 1;
            }
            if (rbtYinLian.Checked == true)
            {
                intCheck = 2;
            }
            if (intCheck == 0)
            {
                Basic.MsgHelper.AlertBackMsg("请选择付款方式");
            }
            else
            {
                string strCellName = this.txtCellName.Text.Trim();
                string strCellMobile = this.txtCellMobile.Text.Trim();
                string strCount = this.txtCount.Text.Trim();
                if (strCellName == "")
                {
                    //联系人姓名
                    Basic.MsgHelper.AlertBackMsg("请填写联系人姓名");
                }
                if (strCellMobile == "")
                {
                    //联系人手机
                    Basic.MsgHelper.AlertBackMsg("请填写联系人手机");
                }


                //购卡数量
                if (strCount == "")
                {
                    Basic.MsgHelper.AlertBackMsg("请填写购买数量");
                }
                else if (strCount == "0")
                {
                    Basic.MsgHelper.AlertBackMsg("购卡数量不能为0");
                }
                else if (new Regex("^[1-9]\\d*$").IsMatch(strCount) == false)
                {
                    Basic.MsgHelper.AlertBackMsg("购卡数量必须为阿拉伯数字");
                }
                int intCount = int.Parse(strCount);

                //卡的单价
                decimal decDanJia = decimal.Parse(lblDanJia.Text);

                //总金额
                decimal decTotleJinE = decDanJia * intCount;

                //购卡省份
                string strProvinceName = hiddProvinceName.Value;

                //订单名称
                //string strSubject = strCellName + "购买了" + intCount + "张，" + strProvinceName + "的" + strCardLeiBie;
                string strSubject = strCellName + "购买了" + intCount + "张，" + strProvinceName + " 艺考VIP卡";


                //订单详情
                string strBody = strCellName + "（" + strCellMobile + "）于" + DateTime.Now + "，购买了" + intCount + "张，" + strProvinceName + "的艺考VIP卡,每张卡的金额为" + lblDanJia.Text + "，此次订单的总金额为" + decTotleJinE + "。";



                //构建实体对象
                Entity.DingDan info = new Entity.DingDan();

                info.AddTime = DateTime.Now;
                info.Subject = strSubject;
                info.Body = strBody;
                info.CellMobile = strCellMobile;
                info.CellName = strCellName;
                info.Count = intCount;
                info.DanJia = decDanJia;
                info.DingDanHao = string.Format("{0:yyyyMMddHHmmssff}", DateTime.Now); //订单号
                info.DingDanJinE = decTotleJinE;//订单总金额
                info.State = 0;//订单状态
                info.Memo = "";
                info.ProvinceId = 0;
                info.WenLi = 0;
                info.Address = "";

                int intDingDanId = 0;
                //订单保存成功，现在需要去支付了
                switch (intCheck)
                {
                    case 1:  //支付宝
                        info.Category = 1;
                        intDingDanId = DAL.DingDan.DingDanAdd(info);
                        if (intDingDanId > 0)
                        {
                            //支付宝
                            ZhiFuBao(intDingDanId);
                        }
                        else
                        {
                            //订单保存失败
                            Basic.MsgHelper.AlertBackMsg("订单保存失败");
                        }
                        break;
                    case 2:  //银联
                        info.Category = 2;
                        intDingDanId = DAL.DingDan.DingDanAdd(info);
                        if (intDingDanId > 0)
                        {
                            YinLian(info);
                        }
                        else
                        {
                            //订单保存失败
                            Basic.MsgHelper.AlertBackMsg("订单保存失败");
                        }
                        break;
                    default:
                        Basic.MsgHelper.AlertBackMsg("订单保存失败");
                        break;
                }
            }
        }

        /// <summary>
        /// 支付宝 支付
        /// </summary>
        void ZhiFuBao(int intDingDanId)
        {
            Entity.DingDan info = DAL.DingDan.DingDanEntityGet(intDingDanId);

            if (info != null)
            {
                #region 支付宝即时到账参数

                //合作方身份id
                string partner = "2088801581813827";

                //支付类型
                string payment_type = "1";
                //必填，不能修改
                //服务器异步通知页面路径
                string notify_url = "http://gaokao.gelunjiaoyu.com/Art/GouMai/NotifyUrl.aspx";
                //需http://格式的完整路径，不能加?id=123这类自定义参数

                //页面跳转同步通知页面路径
                string return_url = "http://gaokao.gelunjiaoyu.com/Art/GouMai/ReturnUrl.aspx";
                //需http://格式的完整路径，不能加?id=123这类自定义参数，不能写成http://localhost/

                //卖家支付宝帐户
                string seller_email = "zhangyh@gelun.org";
                string seller_id = "2088801581813827";
                //必填

                //商户订单号
                string out_trade_no = info.DingDanHao;
                //商户网站订单系统中唯一订单号，必填

                int Count = info.Count;

                //订单名称
                string subject = info.Subject;
                //必填

                //付款金额
                string total_fee = string.Format("{0:N2}", info.DingDanJinE.ToString());
                //必填

                //订单描述
                string body = info.Body;



                //商品展示地址
                string show_url = "http://gaokao.gelunjiaoyu.com/Art/GouMai/ShowUrl.aspx";
                //需以http://开头的完整路径，例如：/gaokao/myorder.html

                //防钓鱼时间戳
                string anti_phishing_key = "";
                //若要使用请调用类文件submit中的query_timestamp函数

                //客户端的IP地址
                string exter_invoke_ip = Request.UserHostAddress;
                //非局域网的外网IP地址，如：221.0.0.1



                //代签名字符串
                string preStr = "_input_charset=utf-8" +
                    "&body=" + body +
                    "&exter_invoke_ip=" + exter_invoke_ip +
                    "&notify_url=" + notify_url +
                    "&out_trade_no=" + out_trade_no +
                    "&partner=" + partner +
                    "&payment_type=" + payment_type +
                    "&return_url=" + return_url +
                    "&seller_email=" + seller_email +
                    "&service=" + "create_direct_pay_by_user" +
                    "&show_url=" + show_url +
                    "&subject=" + subject +
                    "&total_fee=" + total_fee;

                #endregion

                #region 调用支付宝接口，发送请求

                ////////////////////////////////////////////////////////////////////////////////////////////////

                //把请求参数打包成数组
                SortedDictionary<string, string> sParaTemp = new SortedDictionary<string, string>();
                //sParaTemp.Add("anti_phishing_key", anti_phishing_key);
                sParaTemp.Add("_input_charset", Config.Input_charset.ToLower());
                sParaTemp.Add("body", body);
                sParaTemp.Add("exter_invoke_ip", exter_invoke_ip);
                sParaTemp.Add("notify_url", notify_url);
                sParaTemp.Add("out_trade_no", out_trade_no);
                sParaTemp.Add("partner", partner);
                sParaTemp.Add("payment_type", payment_type);
                sParaTemp.Add("return_url", return_url);
                sParaTemp.Add("seller_email", seller_email);
                sParaTemp.Add("service", "create_direct_pay_by_user");
                //sParaTemp.Add("seller_id", seller_id);
                sParaTemp.Add("show_url", show_url);
                sParaTemp.Add("subject", subject);
                sParaTemp.Add("total_fee", total_fee);
                //sParaTemp.Add("sign", AlipayMD5.Sign(preStr, "tozq0prk7lau6ue1khoq5kg1ek17qvmd", Config.Input_charset.ToLower()));
                //sParaTemp.Add("sign_type", Config.Sign_type);

                Config.Key = "tozq0prk7lau6ue1khoq5kg1ek17qvmd";

                //建立请求
                string sHtmlText = Submit.BuildRequest(sParaTemp, "get", "确认");

                Response.Write(sHtmlText);

                #endregion
            }
            else
            {
                Basic.MsgHelper.AlertBackMsg("服务器正忙...");
            }
        }


        /// <summary>
        /// 银联在线支付
        /// </summary>
        void YinLian(Entity.DingDan info)
        {
            if (info != null)
            {
                //info.DanJia = (decimal)0.01;
                //info.DingDanJinE = (decimal)0.01;
                // 要使用各种Srv必须先使用LoadConf载入配置
                UPOPSrv.LoadConf(HttpContext.Current.Server.MapPath("/App_Data/conf.xml.config"));

                // 使用Dictionary保存参数
                System.Collections.Generic.Dictionary<string, string> param = new System.Collections.Generic.Dictionary<string, string>();

                // 填写参数
                param["transType"] = UPOPSrv.TransType.CONSUME;                        // 交易类型，前台只支持CONSUME 和 PRE_AUTH
                param["commodityUrl"] = "http://gaokao.gelunjiaoyu.com/Art/GouMai/ReturnUrl.aspx";  // 商品URL
                param["commodityName"] = "格伦高考报考网-“报考卡”";                                    // 商品名称
                param["commodityUnitPrice"] = ((int)((info.DanJia) * 100)).ToString();                                  // 商品单价，分为单位
                param["commodityQuantity"] = info.Count.ToString();                                       // 商品数量
                param["orderNumber"] = info.DingDanHao;                                         // 订单号，必须唯一
                param["orderAmount"] = ((int)((info.DingDanJinE) * 100)).ToString();                                         // 交易金额
                param["orderCurrency"] = UPOPSrv.CURRENCY_CNY;                          // 币种
                param["orderTime"] = DateTime.Now.ToString("yyyyMMddHHmmss");           // 交易时间
                param["customerIp"] = System.Web.HttpContext.Current.Request.UserHostAddress;                                  // 用户IP
                param["frontEndUrl"] = "http://gaokao.gelunjiaoyu.com/Art/GouMai/YinLian/FontPay.aspx";  // 前台回调URL
                param["backEndUrl"] = "http://gaokao.gelunjiaoyu.com/Art/GouMai/YinLian/BackPay.aspx";   // 后台回调URL

                // 创建前台交易服务对象
                FrontPaySrv srv = new FrontPaySrv(param);

                // 将前台交易服务对象产生的Html文档写入页面，从而引导用户浏览器重定向
                Response.ContentEncoding = srv.Charset; // 指定输出编码
                Response.Write(srv.CreateHtml());       // 写入页面
            }
            else
            {
                ClientScript.RegisterStartupScript(GetType(), "", "<script>artDialog11('该订单不存在...');return false;</script>");
                return;
            }
        }
    }
}
