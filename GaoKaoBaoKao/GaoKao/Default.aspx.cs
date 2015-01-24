using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GaoKao
{
    public partial class Default : System.Web.UI.Page
    {
        public string Status; //状态
        public string StudentName; //学生姓名
        public string Bank;    //账号
        public string Level;  //用户等级
        public string LevelName;  //用户等级
        public string ProvinceName;    //省份

        protected void Page_Load(object sender, EventArgs e)
        {
            Bind();
        }

        void Bind()
        {
            //  Basic.CookieHelper.WriteCookie("Student", "0");
            ////如果登陆成功之后，又再次刷新登陆页面，如果需要加载用户信息，则通过cookie中保存的值调取即可
            Status = Basic.CookieHelper.GetCookie("Student", "Status");
            StudentName = Basic.CookieHelper.GetCookie("Student", "StudentName");
            Bank = Basic.CookieHelper.GetCookie("Student", "Bank");
            Level = Basic.CookieHelper.GetCookie("Student", "StudentLevel");
            LevelName = DAL.Common.GetLevelName(Basic.TypeConverter.StrToInt(Level, 0));
            ProvinceName = Basic.CookieHelper.GetCookie("Student", "ProvinceName");
        }
    }
}