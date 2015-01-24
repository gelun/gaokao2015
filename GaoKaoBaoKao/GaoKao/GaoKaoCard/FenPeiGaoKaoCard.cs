using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GaoKao.GaoKaoCard
{
    public class FenPeiGaoKaoCard
    {

        /// <summary>
        /// 分配高考卡，并发送短信
        /// </summary>
        /// <param name="info"></param>
        public static void FenPeiCard(Entity.DingDan info)
        {
            //验证成功，验证是否缴费，如果是已经缴费，
            if (info != null)
            {
                //将卡号和密码发送短信给用户

                //发送内容为什么呢？，卡号和密码怎么来的呢？

                int count = 0;

                string strMobileContent = "用户您好：您于" + string.Format("{0:yyyy-MM-dd HH:mm}", DateTime.Now) + " 购买的格伦高考报考卡";
                if (info.Count > 0)
                {
                    for (int i = 0; i < info.Count; i++)
                    {
                        Entity.GaoKaoCard infoCard = new Entity.GaoKaoCard();
                        infoCard.KaHao = GetKaHao();//卡号
                        infoCard.MiMa = "GKBK" + new Random().Next(10000, 99999);//密码
                        infoCard.StudentId = 0;
                        infoCard.ProvinceId = 0;
                        infoCard.Belong = 2;//卡的属性：1总部 2网上购买 3加盟店 4代理商
                        infoCard.DianId = 4;
                        infoCard.CardLevel = 4;//卡的级别：2 高考查询卡，3 高考测试卡，4 格伦高考卡,5 VIP测试卡,6 报考VIP卡
                        infoCard.IsPause = 0;
                        infoCard.AllowChangeCount = 30;
                        infoCard.HaveChangeCount = 0;
                        infoCard.EndTime = DateTime.Parse("2015-09-01");
                      //  infoCard.RegisterDate = DateTime.Now;
                        infoCard.Memo = "网上购买";
                        infoCard.DingDanHao = info.DingDanHao;
                        


                        int GaoKaoCardId = DAL.GaoKaoCard.GaoKaoCardAdd(infoCard);
                        if (GaoKaoCardId > 0)
                        {
                            strMobileContent += "卡号：" + infoCard.KaHao + "，密码：" + infoCard.MiMa + "；";

                            count++;
                        }
                    }
                }
                if (count == info.Count)
                {
                    //发送短信
                    if (strMobileContent.EndsWith("；"))
                    {
                        strMobileContent = strMobileContent.Substring(0, strMobileContent.Length - 1);
                    }

                    strMobileContent += "请保存好您的账号密码。";

                    Basic.SendMobile.SendMobileMsg(info.CellMobile, strMobileContent);
                    //  Basic.Email.sendMail("tengxb@gelun.org", "购买报考卡(第二版本1)", strMobileContent);
                }
                else
                {
                    string strContent = "订单表中，订单号为" + info.DingDanHao + "的考生，在付款之后，往gaokaocard表中插入数据时失败，请处理。";
                    //18610241135
                    Basic.SendMobile.SendMobileMsg("18500525896", strContent);
                    //  Basic.Email.sendMail("tengxb@gelun.org", "购买报考卡(第二版本2)", strContent);
                }
            }
        }

        /*艺考*/
        public static void FenPeiCard(Entity.DingDan info,int intIsArt)
        {
            //验证成功，验证是否缴费，如果是已经缴费，
            if (info != null)
            {
                //将卡号和密码发送短信给用户

                //发送内容为什么呢？，卡号和密码怎么来的呢？

                int count = 0;

                string strMobileContent = "用户您好：您于" + string.Format("{0:yyyy-MM-dd HH:mm}", DateTime.Now) + " 购买的格伦高考报考卡";
                if (info.Count > 0)
                {
                    for (int i = 0; i < info.Count; i++)
                    {
                        Entity.GaoKaoCard infoCard = new Entity.GaoKaoCard();
                        infoCard.KaHao = GetKaHao();//卡号
                        infoCard.MiMa = "GKBK" + new Random().Next(10000, 99999);//密码
                        infoCard.StudentId = 0;
                        infoCard.ProvinceId = 0;
                        infoCard.Belong = 2;//卡的属性：1总部 2网上购买 3加盟店 4代理商
                        infoCard.DianId = 4;
                        infoCard.CardLevel = 4;//卡的级别：2 高考查询卡，3 高考测试卡，4 格伦高考卡,5 VIP测试卡,6 报考VIP卡
                        infoCard.IsPause = 0;
                        infoCard.AllowChangeCount = 30;
                        infoCard.HaveChangeCount = 0;
                        infoCard.EndTime = DateTime.Parse("2015-09-01");
                        //  infoCard.RegisterDate = DateTime.Now;
                        infoCard.Memo = "网上购买";
                        infoCard.DingDanHao = info.DingDanHao;

                        int GaoKaoCardId = DAL.GaoKaoCard.GaoKaoCardAdd(infoCard);
                        if (GaoKaoCardId > 0)
                        {
                            DAL.GaoKaoCard.GaoKaoCardIsArt(GaoKaoCardId);
                            strMobileContent += "卡号：" + infoCard.KaHao + "，密码：" + infoCard.MiMa + "；";

                            count++;
                        }
                    }
                }
                if (count == info.Count)
                {
                    //发送短信
                    if (strMobileContent.EndsWith("；"))
                    {
                        strMobileContent = strMobileContent.Substring(0, strMobileContent.Length - 1);
                    }

                    strMobileContent += "请保存好您的账号密码。";

                    Basic.SendMobile.SendMobileMsg(info.CellMobile, strMobileContent);
                    //  Basic.Email.sendMail("tengxb@gelun.org", "购买报考卡(第二版本1)", strMobileContent);
                }
                else
                {
                    string strContent = "订单表中，订单号为" + info.DingDanHao + "的考生，在付款之后，往gaokaocard表中插入数据时失败，请处理。";
                    //18610241135
                    Basic.SendMobile.SendMobileMsg("18500525896", strContent);
                    //  Basic.Email.sendMail("tengxb@gelun.org", "购买报考卡(第二版本2)", strContent);
                }
            }
        }
        //获取随机生成的卡号
        public static string GetKaHao()
        {
            string strKaHao = "GKBK2015" + new Random().Next(10000, 99999);//卡号

            if (DAL.GaoKaoCard.GaoKaoCardCount("KaHao = '" + strKaHao + "'") > 0)
            {
                GetKaHao();
            }

            return strKaHao;
        }
    }
}