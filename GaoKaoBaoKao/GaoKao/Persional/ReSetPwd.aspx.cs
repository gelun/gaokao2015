using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace GaoKao.Persional
{
    public partial class ReSetPwd : Base
    {
        protected int ProvinceId = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (userinfo.StudentLevel > 1 && userinfo.StudentLevel < 9)
            {

                Entity.GaoKaoCard info = DAL.GaoKaoCard.GaoKaoCardEntityGetByKaHao(userinfo.Bank);
                if (info != null)
                {
                    UserCenterLeft1.userinfo = userinfo;

                    ProvinceId = userinfo.ProvinceId;
                }
                else
                {
                    Basic.MsgHelper.AlertBackMsg("不合法的访问");
                }
            }
            else
            {
                Basic.MsgHelper.AlertBackMsg("不合法的访问");
            }
        }

        /*点击提交*/
        protected void goSave_Click(object sender, EventArgs e)
        {
            string strOldPwd = this.txtOldPwd.Text;//旧密码
            string strNewPwd = this.txtNewPwd.Text;//新密码
            string strNewPwd2 = this.txtNewPwd2.Text;//确认新密码

            if (strNewPwd != strNewPwd2)
            {
                Basic.MsgHelper.AlertBackMsg("两次输入的新密码不一致");
            }

            Entity.GaoKaoCard info = DAL.GaoKaoCard.GaoKaoCardEntityGetByKaHao(userinfo.Bank);
            if (info != null)
            {
                if (info.MiMa == strOldPwd)
                {
                    bool b = DAL.GaoKaoCard.UpdateGaoKaoCardPwd(userinfo.Bank, strNewPwd);
                    if (userinfo.StudentId > 0)
                    {
                        DAL.GaoKaoCard.UpdateJoinStudentPwd(userinfo.StudentId, strNewPwd);
                    }
                    if (b == true)
                    {
                        Basic.MsgHelper.AlertUrlMsg("密码修改成功", "/TuiJian/default.aspx");
                    }
                    else
                    {
                        Basic.MsgHelper.AlertBackMsg("密码修改失败");
                    }
                }
                else
                {
                    Basic.MsgHelper.AlertBackMsg("旧密码输入错误");
                }
            }
            else
            {
                Basic.MsgHelper.AlertBackMsg("不合法的访问");
            }
        }
    }
}