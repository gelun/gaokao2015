using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GaoKao.UserControl
{
    public partial class UserCenterLeft : System.Web.UI.UserControl
    {
        public Entity.UserInfo userinfo;
        public string strGender = "nv";
        protected void Page_Load(object sender, EventArgs e)
        {
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