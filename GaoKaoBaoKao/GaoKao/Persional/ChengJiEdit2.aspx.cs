using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GaoKao.Persional
{
    public partial class ChengJiEdit2 : Base
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (userinfo.ProvinceId==11)
            {
                Server.Transfer("ChengJiEdit2_ZheJiang.aspx");
            }

            UserCenterLeft1.userinfo = userinfo;

            //判断目前是否是报考时间，如果是就跳转到设置高考成绩界面
            if (DAL.CommonTuiJian.IsBaoKaoTime(provinceConfig, userinfo.GKYear))
                Response.Redirect("/Persional/ChengJiEdit3.aspx");
            if (userinfo.ProvinceId == 10)
            {
                if (userinfo.KeLei == 1)
                    ltlKeMu.Text = "历史成绩";
                else
                    ltlKeMu.Text = "物理成绩";

                Panel_XuanCe.Visible = true;
            }
            else
                Panel_XuanCe.Visible = false;

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
            int intFenShu = Basic.RequestHelper.GetFormInt(txtPingShiFenShu.ClientID, 0);
            int intWeiCi = Basic.RequestHelper.GetFormInt(txtWeiCi.ClientID, 0);

            if (intFenShu < 0 || intFenShu > 750)
                Basic.MsgHelper.AlertBackMsg("请输入正确的分数。");

            int KeLei = Basic.RequestHelper.GetFormInt("ddlKeLei", -1);
            if (KeLei == -1 && userinfo.KeLei == -1)
                Basic.MsgHelper.AlertBackMsg("设置分数时，必须设置科类。");

            if (userinfo.KeLei == -1)
            {
                DAL.Join_Student.Join_StudentWenLi(userinfo.StudentId, KeLei);

                Basic.CookieHelper.WriteCookie("Student", "KeLei", KeLei.ToString(), 120);

            }


            int FirstLevel = Basic.RequestHelper.GetFormInt(ddlWuLi.ClientID, 0);
            int SecondLevel = Basic.RequestHelper.GetFormInt(ddlXuanCe.ClientID, 0);
            if (userinfo.ProvinceId == 10)
            {
                if (FirstLevel == 0 || SecondLevel == 0)
                    Basic.MsgHelper.AlertBackMsg("设置分数时，必须选择科目评测等级。");
            }


            Entity.StudentGaoKaoHistory info = new Entity.StudentGaoKaoHistory();
            info.FirstLevel = FirstLevel;
            info.SecondLevel = SecondLevel;


            info.StudentId = userinfo.StudentId;
            info.FenShu = intFenShu;
            info.WeiCi = intWeiCi;
            if (intWeiCi == 0)
                info.IsSetUpWeiCi = 0;
            else
                info.IsSetUpWeiCi = 1;



            if (cb_SetUpFenShuXian.Checked)
            {
                info.IsSetUpFenShuXian = 1;

                int intPcFirst = Basic.RequestHelper.GetFormInt(txtPcFirst.ClientID, 0);
                int intPcSecond = Basic.RequestHelper.GetFormInt(txtPcSecond.ClientID, 0);
                int intPcThird = Basic.RequestHelper.GetFormInt(txtPcThird.ClientID, 0);
                int intPcZhuanKeFirst = Basic.RequestHelper.GetFormInt(txtPcZhuanKeFirst.ClientID, 0);
                int intPcZhuanKeSecond = Basic.RequestHelper.GetFormInt(txtPcZhuanKeSecond.ClientID, 0);

                info.PcFirst = intPcFirst;
                info.PcSecond = intPcSecond;
                info.PcThird = intPcThird;
                info.PcZhuanKeFirst = intPcZhuanKeFirst;
                info.PcZhuanKeSecond = intPcZhuanKeSecond;
                info.PcZhuanKeSecond = intPcZhuanKeSecond;
            }
            else
            {
                info.IsSetUpFenShuXian = 0;

                info.PcFirst = 0;
                info.PcSecond = 0;
                info.PcThird = 0;
                info.PcZhuanKeFirst = 0;
                info.PcZhuanKeSecond = 0;
                info.PcZhuanKeSecond = 0;
            }

            info.IsGaoKao = 0;
            info.IsLatest = 1;

            //开始进行保存了
            DAL.StudentGaoKaoHistory.StudentGaoKaoHistoryAdd(info);
            Basic.MsgHelper.AlertUrlMsg("您已经成功设置平时考试成绩，请使用相关功能。", "/tuijian/default.aspx");
        }
    }
}
