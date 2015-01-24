using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GaoKao.Persional
{
    public partial class ChengJiEdit : Base
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (userinfo.ProvinceId == 11)
            {
                Server.Transfer("ChengJiEdit_ZheJiang.aspx");
            }
            UserCenterLeft1.userinfo = userinfo;
            Bind();
        }

        void Bind()
        {
            hidKeLei.Value = userinfo.KeLei.ToString();

            Entity.GaoKaoCard info = DAL.GaoKaoCard.GaoKaoCardEntityGetByStudentId(userinfo.StudentId);
            if (info != null)
            {
                string strTiXing1 = "";
                Entity.StudentGaoKaoHistory infoChengJi = DAL.StudentGaoKaoHistory.StudentGaoKaoHistoryEntityGet(userinfo.StudentId);
                if (infoChengJi != null)
                {
                    strTiXing1 = "<div class=\"tx\">"
                              + "提醒：" + Basic.Utils.StrToDateStr(infoChengJi.AddTime.ToString()) + "你设定分数如下"
                              + " </div>"
                              + " <div class=\"gkcjul\">"
                                  + " <ul>"
                                      + " <li>考生类别：" + DAL.Common.GetKeLeiMingCheng(userinfo.KeLei) + "</li>"
                                      + " <li>考生分数：" + infoChengJi.FenShu + "</li>";
                    if (userinfo.ProvinceId == 11)//浙江
                    {
                        strTiXing1 += " <li>一批次分数线预估：" + infoChengJi.PcFirst + "</li>"
                        + " <li>二批次分数线预估：" + infoChengJi.PcSecond + "</li>"
                        + " <li>三批次分数线预估：" + infoChengJi.PcThird + "</li>";
                    }
                    else
                    {
                        strTiXing1 += " <li>一本分数线预估：" + infoChengJi.PcFirst + "</li>"
                        + " <li>二本分数线预估：" + infoChengJi.PcSecond + "</li>"
                        + " <li>三本分数线预估：" + infoChengJi.PcThird + "</li>"
                        + " <li>专科分数线预估：" + infoChengJi.PcZhuanKeFirst + "</li>";
                    }
                    strTiXing1 += " </ul></div>";
                }
                else
                {
                    strTiXing1 = "<div class=\"tx\">"
                               + "提醒：你还没有设定分数"
                               + " </div>";
                }

                ltlTiXing1.Text = strTiXing1;

            }
        }
    }
}