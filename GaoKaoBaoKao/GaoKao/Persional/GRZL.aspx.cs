using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace GaoKao.Persional
{
    public partial class GRZL : Base
    {
        protected int ProvinceId = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            UserCenterLeft1.userinfo = userinfo;

            ProvinceId = userinfo.ProvinceId;

            if (!IsPostBack)
            {
                Bind();
                GetSelList();
            }

        }

        void Bind()
        {
            Entity.Join_Student info = DAL.Join_Student.Join_StudentEntityGet(userinfo.StudentId);
            if (info != null)
            {
                txtBanJi.Text = info.BanJi;
                txtBanZhuRen.Text = info.BanZhuRen;
                txtBanZhuRenMobile.Text = info.BanZhuRenMobile;
                txtFMobile.Text = info.FuQinPhone;
                txtMMobile.Text = info.MuQinPhone;
                txtMobile.Text = info.CellPhone;
                txtSchoolName.Text = info.SchoolName;
                txtTrueName.Text = info.StudentName;

                DataTable dt = DAL.S_City.S_CityGet(userinfo.ProvinceId);
                sel2.DataSource = dt;
                sel2.DataTextField = "CityName";
                sel2.DataValueField = "CityID";
                sel2.DataBind();
                sel2.Items.Insert(0, new ListItem("--城市--", "0"));

                ddlGKYear.SelectedValue = info.GKYear.ToString();
                ddlSex.SelectedValue = info.Sex.ToString();
                ddlProvince.SelectedValue = userinfo.ProvinceId.ToString();
                sel2.SelectedValue = info.CityId.ToString();


                hidCityId.Value = info.CityId.ToString();
                hidCountyId.Value = info.CountyId.ToString();
                hidKeLei.Value = info.WenLi.ToString();

            }
        }



        void GetSelList()
        {
            string ajaxRequest = Basic.RequestHelper.GetQueryString("ty");
            int proId = Basic.RequestHelper.GetQueryInt("proid", 0);
            if (proId > 0)
            {
                Response.Write(AjaxRequest(ajaxRequest, proId));
                Response.End();
            }
        }

        string AjaxRequest(string ajaxRequest, int proId)
        {
            string json = "";
            DataTable dt = null;
            if (ajaxRequest == "citylist")
            {
                dt = DAL.S_City.S_CityGet(proId);
                if (dt != null && dt.Rows.Count > 0)  //根据省份id  获取城市列表
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        json += "{\"id\":\"" + dt.Rows[i]["CityID"] + "\",\"name\":\"" + dt.Rows[i]["CityName"] + "\"},";
                    }
                    if (json.EndsWith(","))
                    {
                        json = json.Substring(0, json.Length - 1);
                    }

                    if (json != "")
                    {
                        json = "[" + json + "]";
                    }
                }
            }
            else if (ajaxRequest == "districtlist")  //根据城市id  获取地区
            {
                dt = DAL.S_District.S_DistrictGet(proId);
                if (dt != null && dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        json += "{\"id\":\"" + dt.Rows[i]["DistrictID"] + "\",\"name\":\"" + dt.Rows[i]["DistrictName"] + "\"},";
                    }
                    if (json.EndsWith(","))
                    {
                        json = json.Substring(0, json.Length - 1);
                    }

                    if (json != "")
                    {
                        json = "[" + json + "]";
                    }
                }
            }
            return json;
        }

        /*点击提交*/
        protected void goSave_Click(object sender, EventArgs e)
        {
            int intCityId = Basic.TypeConverter.StrToInt(hidCityId.Value, 0);//城市
            int intCountyId = Basic.TypeConverter.StrToInt(hidCountyId.Value, 0);//区/县
            int intKeLei = Basic.TypeConverter.StrToInt(hidKeLei.Value, 0);//科类
            if (intKeLei == 0)
            {
                Basic.MsgHelper.AlertBackMsg("请选择高考分科");
            }

            int intGKYear = Basic.TypeConverter.StrToInt(ddlGKYear.SelectedValue, 0);//高考年份
            if (intGKYear == 0)
            {
                Basic.MsgHelper.AlertBackMsg("请选择高考年份");
            }

            string strTrueName = this.txtTrueName.Text;//真实姓名
            if (strTrueName == "")
            {
                Basic.MsgHelper.AlertBackMsg("请填写学生姓名");
            }
            int intSex = Basic.TypeConverter.StrToInt(ddlSex.SelectedValue, 0);//性别
            string strMobile = this.txtMobile.Text;//学生手机
            string strFMobile = this.txtFMobile.Text;//父亲手机
            string strMMobile = this.txtMMobile.Text;//母亲手机
            string strSchoolName = this.txtSchoolName.Text;//就读学校
            string strBanJi = this.txtBanJi.Text;//就读班级
            string strBanZhuRen = this.txtBanZhuRen.Text;//班主任姓名
            string strBanZhuRenMobile = this.txtBanZhuRenMobile.Text;//班主任手机

            Entity.Join_Student info = DAL.Join_Student.Join_StudentEntityGet(userinfo.StudentId);
            info.BanJi = strBanJi;
            info.BanZhuRen = strBanZhuRen;
            info.BanZhuRenMobile = strBanZhuRenMobile;
            info.CellPhone = strMobile;
            info.CityId = intCityId;
            info.CountyId = intCountyId;
            info.FuQinPhone = strFMobile;
            info.GKYear = intGKYear;
            info.MuQinPhone = strMMobile;
            info.ProvinceId = userinfo.ProvinceId;
            info.SchoolName = strSchoolName;
            info.Sex = intSex;
            info.StudentName = strTrueName;
            info.WenLi = intKeLei;

            if (userinfo.StudentLevel == 1)
            {
                info.StudentLevel = 1;
            }
            else if (userinfo.StudentLevel == 9)
            {
                info.StudentLevel = 2;
            }
            else
            {
                info.StudentLevel = 3;
            }

            bool b = DAL.TengXB.Join_Student.Join_StudentEdit_WanShanXinXi(info);


            if (b == true)
            {
                #region 重写cookie

                Basic.CookieHelper.WriteCookie("Student", "StudentName", strTrueName, 120);
                Basic.CookieHelper.WriteCookie("Student", "KeLei", intKeLei.ToString(), 120);
                Basic.CookieHelper.WriteCookie("Student", "GKYear", intGKYear.ToString(), 120);

                #endregion

                //提交成功，跳转路径
                // Basic.MsgHelper.AlertUrlMsg("提交成功", "#");
                Basic.MsgHelper.AlertUrlMsg("提交成功", "/TuiJian/default.aspx");
            }
            else
            {
                //提交失败
                Basic.MsgHelper.AlertBackMsg("提交失败");
            }
        }
    }
}