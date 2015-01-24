using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GaoKao.CePing
{
    public class UserBase:Base
    {
        public Entity.Join_Student user;

        public UserBase()
        {
            //初始化
            this.Load += new EventHandler(page_Loading);

        }

        void page_Loading(object sender, EventArgs e)
        {

            if (userinfo.StudentId>0)
            {
                user = DAL.Join_Student.Join_StudentEntityGet(userinfo.StudentId);
            }
            else
            {
                Basic.MsgHelper.AlertUrlMsg("请先登录","/login.html");
            }

        }
    }
}