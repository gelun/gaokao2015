using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GaoKao.TuiJian
{
    public partial class _default : Base
    {
        public string strGender = "nv";
        protected int bYKStudentXinXi = 0;
        protected string Bank = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (userinfo.StudentLevel > 1 && userinfo.StudentLevel < 9)
            {
                Entity.GaoKaoCard info = DAL.GaoKaoCard.GaoKaoCardEntityGetByKaHao(userinfo.Bank);
                if (info != null)
                {
                    if (info.IsArt == 1)
                    {
                        if (DAL.YKStudentXinXi.YKStudentXinXiCount("GaoKaoKaHao = '" + info.KaHao + "'") == 0)
                        {
                            bYKStudentXinXi = 1;
                            Bank = info.KaHao;
                        }
                    }
                }
            }

            lit_ProvinceName.Text = DAL.Common.GetProvinceName(userinfo.ProvinceId);
            lit_KeLeiMingCheng.Text = DAL.Common.GetKeLeiMingCheng(userinfo.KeLei);
            lit_LevelName.Text = DAL.Common.GetLevelName(userinfo.StudentLevel);
            lit_NianJi.Text = DAL.Common.GetStudentClass(userinfo.GKYear);
            lit_GKYear.Text = userinfo.GKYear.ToString();

            int intGender = DAL.Join_Student.Join_StudentEntityGet(userinfo.StudentId).Sex;
            if (intGender == 1)
                strGender = "nv";
            else
                strGender = "nan";
        }
    }
}