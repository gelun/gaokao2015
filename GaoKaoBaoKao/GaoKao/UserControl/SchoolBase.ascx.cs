using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GaoKao.UserControl
{
    public partial class SchoolBase : System.Web.UI.UserControl
    {
        public Entity.School info { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            Bind();
        }

        void Bind()
        {
            //intSchoolId = Basic.RequestHelper.GetQueryInt("schoolid", 583);
            //Entity.School info = DAL.School.SchoolEntityGet(intSchoolId);
            if (info != null)
            {
                ltlBelongName.Text = info.BeLongName;
                ltlBoShiDian.Text = info.BoShiDian;
                ltlFoundingTime.Text = info.FoundingTime;
                ltlSchoolEnName.Text = info.SchoolEnName;
                ltlSchoolName.Text = info.SchoolName + "";
                ltlSchoolWebSite.Text = "<a target=\"_blank\" href=\"" + info.SchoolWebSite + "\">学校官网 >></a>";
                ltlShengShi.Text = info.ProvinceName + " " + info.CityName;
                ltlShuoShiDian.Text = info.ShuoShiDian;

                ltlYuanShi.Text = info.YuanShi;
                ltlYuanXiaoLeiXing.Text = info.YuanXiaoLeiXing;
                ltlZhaoShengTel.Text = info.ZhaoShengTel;
                ltlZhongDianXueKe.Text = info.ZhongDianXueKe;

                string strYouShi = "";
                if (info.Is211 == 1)
                {
                    strYouShi += "<a href=\"#\">211</a>";
                }
                if (info.Is985 == 1)
                {
                    strYouShi += "<a href=\"#\">985</a>";
                }
                if (info.IsArtSpecialty == 1)
                {
                    strYouShi += "<a href=\"#\">艺</a>";
                }
                if (info.IsExcellent == 1)
                {
                    strYouShi += "<a href=\"#\">卓</a>";
                }
                if (info.IsGraduateSchool == 1)
                {
                    strYouShi += "<a href=\"#\">研</a>";
                }
                if (info.IsHighLevelAthletes == 1)
                {
                    strYouShi += "<a href=\"#\">体</a>";
                }
                if (info.IsIndependentRecruitment == 1)
                {
                    strYouShi += "<a href=\"#\">自</a>";
                }
                if (info.IsMiNi211 == 1)
                {
                    strYouShi += "<a href=\"#\">小211</a>";
                }
                if (info.IsNationalDefense == 1)
                {
                    strYouShi += "<a href=\"#\">国</a>";
                }
                if (info.IsRuralSpecial == 1)
                {
                    strYouShi += "<a href=\"#\">农</a>";
                }

                ltlYouShi.Text = strYouShi;//211  985  ...
            }
            else
            {
                Basic.MsgHelper.AlertBackMsg("无法获取院校信息");
            }
        }
    }
}