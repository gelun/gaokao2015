using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GaoKao.Persional
{
    public partial class ChengJiEdit_ZheJiang : Base
    {
        protected void Page_Load(object sender, EventArgs e)
        {
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
                Entity.StudentGaoKaoHistory_ZheJiang infoChengJi = DAL.StudentGaoKaoHistory_ZheJiang.StudentGaoKaoHistory_ZheJiangEntityGetByStudentId(userinfo.StudentId);
                if (infoChengJi != null)
                {
                    strTiXing1 = "<div class=\"tx\">"
                              + "提醒：" + Basic.Utils.StrToDateStr(infoChengJi.AddTime.ToString()) + "你设定分数如下"
                              + " </div>"
                              + " <div class=\"gkcjul\">"
                                  + " <ul>"
                                      + " <li>科类：" + DAL.Common.GetKeLeiMingCheng(userinfo.KeLei) + "</li>"
                                      + " <li>语文：" + infoChengJi.YuWen + "</li>"
                                      + " <li>数学：" + infoChengJi.ShuXue + "</li>"
                                      + " <li>外语：" + infoChengJi.YingYu + "</li>"
                                      + " <li>综合：" + infoChengJi.ZongHe + "</li>"
                                      + " <li>自选：" + infoChengJi.ZiXuan + "</li>"
                                      + " <li>技术：" + infoChengJi.JiShu + "</li>"
                                      + " <li>总分1：" + infoChengJi.ZongFen1 + "</li>"
                                      + " <li>总分2：" + infoChengJi.ZongFen2 + "</li>"
                                      + " <li>总分3：" + infoChengJi.ZongFen3 + "</li>";
                    strTiXing1 += " </ul></div>";
                }
                else
                {
                    strTiXing1 = "<div class=\"tx\">"
                               + "提醒：你还没有设定成绩"
                               + " </div>";
                }

                ltlTiXing1.Text = strTiXing1;

            }
        }
    }
}