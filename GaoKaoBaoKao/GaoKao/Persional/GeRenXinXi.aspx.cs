using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace GaoKao.Persional
{
    public partial class GeRenXinXi : System.Web.UI.Page
    {
        protected int Level = 0;
        protected int ProvinceId = 0;

        public Entity.UserInfo userinfo = new Entity.UserInfo();
        protected void Page_Load(object sender, EventArgs e)
        {
            userinfo.StudentId = Basic.Utils.StrToInt(Basic.CookieHelper.GetCookie("Student", "StudentId"), 0);
            userinfo.StudentLevel = Basic.Utils.StrToInt(Basic.CookieHelper.GetCookie("Student", "StudentLevel"), 0);//用户等级id：1普通注册用户;2高考查看卡; 3普通测试卡; 4普通卡;  5VIP测试卡;  6VIP卡;9会员卡
            userinfo.ProvinceId = Basic.Utils.StrToInt(Basic.CookieHelper.GetCookie("Student", "ProvinceId"), 0);//省份id
            userinfo.KeLei = Basic.Utils.StrToInt(Basic.CookieHelper.GetCookie("Student", "KeLei"), 0);//科类
            userinfo.GKYear = Basic.Utils.StrToInt(Basic.CookieHelper.GetCookie("Student", "GKYear"), 0);//参加高考的年份
            userinfo.Status = Basic.Utils.StrToInt(Basic.CookieHelper.GetCookie("Student", "Status"), 0);//登陆之后的状态值
            userinfo.StudentName = Basic.CookieHelper.GetCookie("Student", "StudentName");//学生姓名
            userinfo.Bank = Basic.CookieHelper.GetCookie("Student", "Bank");//当前登陆的账号
            userinfo.LevelName = Basic.CookieHelper.GetCookie("Student", "LevelName");//用户等级名称: 1普通注册用户;2高考查看卡; 3普通测试卡; 4普通卡;  5VIP测试卡;  6VIP卡;9会员卡
            userinfo.ProvinceName = Basic.CookieHelper.GetCookie("Student", "ProvinceName"); //省份名称

            ValidStatus();//验证登陆状态

            Level = userinfo.StudentLevel;
            ProvinceId = userinfo.ProvinceId;
            if (ProvinceId > 0)
            {
                ddlProvince.SelectedValue = userinfo.ProvinceId.ToString();
            }

            GetSelList();
        }
        /*验证登陆状态*/
        void ValidStatus()
        {
            if (userinfo.Status != 1)
            {
                //说明是通过输入网址等方式打开本页面的，此时应该跳转到其他页面，现在默认跳转到登陆页面
                Response.Redirect("/login.shtml");
            }
        }

        void GetSelList()
        {
            if (!IsPostBack)
            {
                string ajaxRequest = Basic.RequestHelper.GetQueryString("ty");
                int proId = Basic.RequestHelper.GetQueryInt("proid", 0);
                if (proId > 0)
                {
                    Response.Write(AjaxRequest(ajaxRequest, proId));
                    Response.End();
                }
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
            //省份
            int intProvinceId = Basic.TypeConverter.StrToInt(ddlProvince.SelectedValue, userinfo.ProvinceId);
            if (intProvinceId == 0)
            {
                Basic.MsgHelper.AlertBackMsg("请选择省份");
            }
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

            Entity.Join_Student info = new Entity.Join_Student();

            bool b = false;
            if (userinfo.StudentLevel == 1) //普通注册用户
            {
                info = DAL.Join_Student.Join_StudentEntityGet(userinfo.StudentId);
                info.BanJi = strBanJi;
                info.BanZhuRen = strBanZhuRen;
                info.BanZhuRenMobile = strBanZhuRenMobile;
                info.CellPhone = strMobile;
                info.CityId = intCityId;
                info.CountyId = intCountyId;
                info.FuQinPhone = strFMobile;
                info.GKYear = intGKYear;
                info.MuQinPhone = strMMobile;
                info.ProvinceId = intProvinceId;
                info.SchoolName = strSchoolName;
                info.Sex = intSex;
                info.StudentName = strTrueName;
                info.WenLi = intKeLei;
                info.StudentLevel = 1;

                if (DAL.TengXB.Join_Student.Join_StudentEdit_WanShanXinXi(info))
                {
                    b = true;
                }
                else
                {
                    b = false;
                }
            }
            else  //高考卡用户
            {
                info.BanJi = strBanJi;
                info.BanZhuRen = strBanZhuRen;
                info.BanZhuRenMobile = strBanZhuRenMobile;
                info.CellPhone = strMobile;
                info.CityId = intCityId;
                info.CountyId = intCountyId;
                info.FuQinPhone = strFMobile;
                info.GKYear = intGKYear;
                info.MuQinPhone = strMMobile;
                info.ProvinceId = intProvinceId;
                info.SchoolName = strSchoolName;
                info.Sex = intSex;
                info.StudentName = strTrueName;
                info.WenLi = intKeLei;

                info.StudentLevel = (userinfo.StudentLevel == 9 ? 2 : 3);//会员卡是2 高考卡3

                int intId = DAL.TengXB.Join_Student.Join_StudentAdd_WanShanXinXi(info);
                if (intId > 0)
                {
                    userinfo.StudentId = intId;

                    if (userinfo.StudentLevel == 9)
                    {
                        if (DAL.TengXB.Join_Card.SetJoin_CardStudentId(intId, userinfo.Bank,intProvinceId))
                        {
                            b = true;
                        }
                        else
                        {
                            b = false;
                        }
                    }
                    else
                    {
                        if (DAL.GaoKaoCard.SetGaoKaoCardStudentId(intId, userinfo.Bank,intProvinceId))
                        {
                            b = true;
                        }
                        else
                        {
                            b = false;
                        }
                    }
                }
                else
                {
                    b = false;
                }
            }

            if (b == true)
            {
                #region 重写cookie

                Basic.CookieHelper.WriteCookie("Student", "StudentId", userinfo.StudentId.ToString(), 120);
                Basic.CookieHelper.WriteCookie("Student", "StudentLevel", userinfo.StudentLevel.ToString(), 120);
                Basic.CookieHelper.WriteCookie("Student", "StudentName", strTrueName, 120);

                Basic.CookieHelper.WriteCookie("Student", "ProvinceId", intProvinceId.ToString(), 120);
                Basic.CookieHelper.WriteCookie("Student", "ProvinceName", ddlProvince.SelectedItem.Text, 120);
                Basic.CookieHelper.WriteCookie("Student", "KeLei", intKeLei.ToString(), 120);
                Basic.CookieHelper.WriteCookie("Student", "GKYear", intGKYear.ToString(), 120);


                if (userinfo.StudentLevel == 1 || userinfo.StudentLevel == 9)//注册用户  或者  会员卡用户
                {
                    Basic.CookieHelper.WriteCookie("Student", "Status", "4", 120);
                }
                else if (userinfo.StudentLevel > 1 && userinfo.StudentLevel < 9)  //高考卡用户
                {
                    Basic.CookieHelper.WriteCookie("Student", "Status", "3", 120);
                }

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