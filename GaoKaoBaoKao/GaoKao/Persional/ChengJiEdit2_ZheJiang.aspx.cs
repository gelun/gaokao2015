using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GaoKao.Persional
{
    public partial class ChengJiEdit2_ZheJiang : Base
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            UserCenterLeft1.userinfo = userinfo;

            //判断目前是否是报考时间，如果是就跳转到设置高考成绩界面
            if (DAL.CommonTuiJian.IsBaoKaoTime(provinceConfig, userinfo.GKYear))
                Response.Redirect("/Persional/ChengJiEdit3.aspx");

            Bind();
        }

        void Bind()
        {
            hidKeLei.Value = userinfo.KeLei.ToString();

            Entity.GaoKaoCard info = DAL.GaoKaoCard.GaoKaoCardEntityGetByStudentId(userinfo.StudentId);
            if (info != null)
            {
                //ltlTiXing3.Text = "提醒：您可以设定" + info.AllowChangeCount + "次成绩修改机会，已经设定" + info.HaveChangeCount + "次，还有" + (info.AllowChangeCount - info.HaveChangeCount) + "次设定机会";
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            int KeLei = Basic.RequestHelper.GetFormInt("ddlKeLei", -1);
            if (KeLei == -1 && userinfo.KeLei == -1)
                Basic.MsgHelper.AlertBackMsg("设置分数时，必须设置科类。");

            if (userinfo.KeLei == -1)
            {
                DAL.Join_Student.Join_StudentWenLi(userinfo.StudentId, KeLei);
                Basic.CookieHelper.WriteCookie("Student", "KeLei", KeLei.ToString(), 120);
            }

            int intYuWen = Basic.RequestHelper.GetFormInt(txtYuWen.ClientID, 0);
            int intShuXue = Basic.RequestHelper.GetFormInt(txtShuXue.ClientID, 0);
            int intYingYu = Basic.RequestHelper.GetFormInt(txtYingYu.ClientID, 0);
            int intZongHe = Basic.RequestHelper.GetFormInt(txtZongHe.ClientID, 0);
            int intZiXuan = Basic.RequestHelper.GetFormInt(txtZiXuan.ClientID, 0);
            int intJiShu = Basic.RequestHelper.GetFormInt(txtJiShu.ClientID, 0);



            Entity.StudentGaoKaoHistory_ZheJiang info = new Entity.StudentGaoKaoHistory_ZheJiang();
            info.AddTime = DateTime.Now;
            info.JiShu = intJiShu;
            info.ShuXue = intShuXue;
            info.StudentId = userinfo.StudentId;
            info.YingYu = intYingYu;
            info.YuWen = intYuWen;
            info.ZiXuan = intZiXuan;
            info.ZongFen1 = Basic.TypeConverter.StrToInt(hidZongFen1.Value, 0);
            info.ZongFen2 = Basic.TypeConverter.StrToInt(hidZongFen2.Value, 0);
            info.ZongFen3 = Basic.TypeConverter.StrToInt(hidZongFen3.Value, 0);
            info.ZongHe = intZongHe;

            info.IsGaoKao = 0;
            info.IsLatest = 1;

            //开始进行保存了
            DAL.StudentGaoKaoHistory_ZheJiang.StudentGaoKaoHistory_ZheJiangAdd(info);
            Basic.MsgHelper.AlertUrlMsg("您已经成功设置平时考试成绩，请使用相关功能。", "/tuijian/default.aspx");
        }
    }
}
