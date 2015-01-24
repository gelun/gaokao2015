using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entity
{
    public class UserInfo
    {
        public int StudentId { get; set; } //StudentId
        public int StudentLevel { get; set; } //用户等级
        public int ProvinceId { get; set; } //省份Id
        public int KeLei { get; set; } //科类
        public string KeLeiMingCheng { get; set; } //科类名称
        public int GKYear { get; set; } //参加高考的年份
        public int Status { get; set; } //状态

        public string StudentName { get; set; } //学生姓名
        public string Bank { get; set; }    //账号
        public string LevelName { get; set; }  //用户等级
        public string ProvinceName { get; set; }    //省份
    }
}
