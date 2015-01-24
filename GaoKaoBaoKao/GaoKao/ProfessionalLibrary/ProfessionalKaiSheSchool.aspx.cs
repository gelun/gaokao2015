using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace GaoKao.ProfessionalLibrary
{
    public partial class ProfessionalKaiSheSchool : System.Web.UI.Page
    {
        protected int intProfessionalId = 0;
        protected string strProfessionalName = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            Bind();
        }

        void Bind()
        {
            intProfessionalId = Basic.RequestHelper.GetQueryInt("professionalid", 0);

            Entity.Professional info = DAL.TengXB.Professional.ProfessionalEntityGet(intProfessionalId);
            if (info != null)
            {
                strProfessionalName = info.ProfessionalName;//专业名称

                ProfessionalBase1.info = info;

                ProfessionalLeft1.ProfessionalId = info.Id;
                ProfessionalLeft1.XueKeMenLeiName = info.XueKeMenLeiName;

                Crumb1.NavString = " <span>&gt;</span> <a href=\"/zhuanye.shtml\" title\"高考报考专业库\">高考报考专业库</a> <span>&gt;</span> <a href=\"/zhuanye-jianjie-" + info.Id + ".shtml\" title\"" + info.ProfessionalName + "\">" + info.ProfessionalName + "</a> <span>&gt;</span> 开设院校";

                DataTable dt0 = DAL.FenShengZhuanYeLuQu.ZhuanYeKaiSheYuanXiaoList("ZyId = " + intProfessionalId, "2013");
                
                DataView dv = dt0.DefaultView;


                //1华东地区（包括15山东、10江苏、12安徽、11浙江、13福建、9上海）
                //2华南地区（包括19广东、20广西、21海南）
                //3华中地区（包括17湖北、18湖南、16河南、14江西）
                //4华北地区（包括1北京、2天津、3河北、4山西、5内蒙古）
                //5西北地区（包括30宁夏、31新疆、29青海、27陕西、28甘肃）
                //6西南地区（包括23四川、25云南、24贵州、26西藏、22重庆）
                //7东北地区（包括6辽宁、7吉林、8黑龙江）
                //8台港澳地区（32包括台湾、香港、澳门）

                dv.RowFilter=" SchoolProvinceId = 15 OR  SchoolProvinceId = 10 OR  SchoolProvinceId = 12 OR  SchoolProvinceId = 11 OR  SchoolProvinceId = 13 OR  SchoolProvinceId = 9  "; 
                DataTable dt1 = dv.ToTable();
                Repeater1.DataSource = dt1;
                Repeater1.DataBind();


                dv.RowFilter = " SchoolProvinceId = 19 OR  SchoolProvinceId = 20 OR  SchoolProvinceId = 21  ";
                DataTable dt2 = dv.ToTable();
                Repeater2.DataSource = dt2;
                Repeater2.DataBind();


                dv.RowFilter = " SchoolProvinceId = 17 OR  SchoolProvinceId = 18 OR  SchoolProvinceId = 16 OR  SchoolProvinceId = 14  ";
                DataTable dt3 = dv.ToTable();
                Repeater3.DataSource = dt3;
                Repeater3.DataBind();


                dv.RowFilter = " SchoolProvinceId = 1 OR  SchoolProvinceId = 2 OR  SchoolProvinceId = 3 OR  SchoolProvinceId = 4 OR  SchoolProvinceId = 5  ";
                DataTable dt4 = dv.ToTable();
                Repeater4.DataSource = dt4;
                Repeater4.DataBind();

                dv.RowFilter = " SchoolProvinceId = 30 OR  SchoolProvinceId = 31 OR  SchoolProvinceId = 29 OR  SchoolProvinceId = 27 OR  SchoolProvinceId = 28  ";
                DataTable dt5 = dv.ToTable();
                Repeater5.DataSource = dt5;
                Repeater5.DataBind();


                dv.RowFilter = " SchoolProvinceId = 23 OR  SchoolProvinceId = 25 OR  SchoolProvinceId = 24 OR  SchoolProvinceId = 26 OR  SchoolProvinceId = 22  ";
                DataTable dt6 = dv.ToTable();
                Repeater6.DataSource = dt6;
                Repeater6.DataBind();

                dv.RowFilter = " SchoolProvinceId = 6 OR  SchoolProvinceId = 7 OR  SchoolProvinceId = 8  ";
                DataTable dt7 = dv.ToTable();
                Repeater7.DataSource = dt7;
                Repeater7.DataBind();

            }
            else
            {
                Basic.MsgHelper.AlertBackMsg("获取专业信息失败");
            }
        }
    }
}