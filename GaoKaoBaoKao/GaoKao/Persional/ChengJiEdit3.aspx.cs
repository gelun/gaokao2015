using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace GaoKao.Persional
{
    public partial class ChengJiEdit3 : Base
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            UserCenterLeft1.userinfo = userinfo;

            //判断目前是否是报考时间，如果是就跳转到设置高考成绩界面，如果不是，跳回去
            if (!DAL.CommonTuiJian.IsBaoKaoTime(provinceConfig, userinfo.GKYear))
                Basic.MsgHelper.AlertUrlMsg("您所在的省高考成绩公布后，您才可以设置成绩。", "/Persional/ChengJiEdit2.aspx");
                //Response.Redirect("/Persional/ChengJiEdit2.aspx");

            Entity.StudentGaoKaoHistory histroy = DAL.StudentGaoKaoHistory.StudentGaoKaoHistoryEntityGet(userinfo.StudentId);
            if (histroy != null && histroy.IsGaoKao == 1)
                Basic.MsgHelper.AlertUrlMsg("您所在的省已经公布高考成绩，你已经设置完毕禁止修改，如果设置错误请与客服联系。", "/tuijian/default.aspx");

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
            //if (info != null)
            //{
            //    ltlTiXing3.Text = "提醒：您可以设定" + info.AllowChangeCount + "次成绩修改机会，已经设定" + info.HaveChangeCount + "次，还有" + (info.AllowChangeCount - info.HaveChangeCount) + "次设定机会";
            //}
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            int intFenShu = Basic.RequestHelper.GetFormInt(txtGaoKaoFen.ClientID, 0);
            int intWeiCi = Basic.RequestHelper.GetFormInt(txtWeiCi.ClientID, 0);



            int FirstLevel = Basic.RequestHelper.GetFormInt(ddlWuLi.ClientID, 0);
            int SecondLevel = Basic.RequestHelper.GetFormInt(ddlXuanCe.ClientID, 0);


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


            info.IsSetUpFenShuXian = 0;

            info.PcFirst = 0;
            info.PcSecond = 0;
            info.PcThird = 0;
            info.PcZhuanKeFirst = 0;
            info.PcZhuanKeSecond = 0;
            info.PcZhuanKeSecond = 0;
            

            info.IsGaoKao = 1;
            info.IsLatest = 1;

            //开始进行保存了
            DAL.StudentGaoKaoHistory.StudentGaoKaoHistoryAdd(info);
            Basic.MsgHelper.AlertUrlMsg("您已经成功设置平时考试成绩，请使用相关功能。", "/tuijian/default.aspx");
        }
    }
}