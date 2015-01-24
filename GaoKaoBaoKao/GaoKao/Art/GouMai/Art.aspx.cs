using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;

namespace GaoKao.Art.GouMai
{
    public partial class Art : System.Web.UI.Page
    {
        protected string strGaKaoKaHao = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            strGaKaoKaHao = Basic.RequestHelper.GetQueryString("kh");
            Entity.GaoKaoCard info = DAL.GaoKaoCard.GaoKaoCardEntityGetByKaHao(strGaKaoKaHao);
            if (info == null || info.IsArt != 1)
            {
                Basic.MsgHelper.AlertBackMsg("不合法的访问");
            }
            else
            {
                Entity.YKStudentXinXi infoYK = DAL.YKStudentXinXi.YKStudentXinXiEntityGetByGaoKaoKaHao(strGaKaoKaHao);
                if (infoYK != null)
                {
                    Basic.MsgHelper.AlertUrlMsg("不合法的访问", "/");
                }
            }
        }

        protected void btnGoTo_Click(object sender, EventArgs e)
        {
            Entity.YKStudentXinXi YKInfo = new Entity.YKStudentXinXi();
            YKInfo.GaoKaoKaHao = strGaKaoKaHao;

            #region 表单验证
            string strName = Basic.RequestHelper.GetFormString(tbName.ClientID);
            if (string.IsNullOrEmpty(strName))
            {
                Basic.MsgHelper.AlertBackMsg("请填写姓名");
            }
            YKInfo.StudentName = strName;
            int intNanOrNv = Basic.Utils.StrToInt(ddlSex.SelectedValue, -1);
            if (intNanOrNv < 0)
            {
                Basic.MsgHelper.AlertBackMsg("请选择性别");
            }
            YKInfo.Sex = intNanOrNv;
            string strChuSheng = Basic.RequestHelper.GetFormString(tbChuSheng.ClientID);
            if (string.IsNullOrEmpty(strChuSheng))
            {
                Basic.MsgHelper.AlertBackMsg("请输入出生年月");
            }
            YKInfo.ChuShengRiQi = strChuSheng;
            string strBiYeSchool = Basic.RequestHelper.GetFormString(tbBiYeXueXiao.ClientID);
            YKInfo.BiYeXueXiao = strBiYeSchool;

            string strQq = Basic.RequestHelper.GetFormString(tbQq.ClientID);
            YKInfo.Sqq = strQq;

            int intJFFW = Basic.RequestHelper.GetFormInt(ddlJFRKFW.ClientID, -1);
            YKInfo.JiaFenFW = intJFFW;

            string strFZ = Basic.RequestHelper.GetFormString(tbFenZhi.ClientID);
            YKInfo.FenZhi = strFZ;

            string strZJZYSXQK = Basic.RequestHelper.GetFormString(tbTiJian.ClientID);
            YKInfo.TJZYSXQK = strZJZYSXQK;

            int inyYiKaoTypeId = Basic.RequestHelper.GetFormInt(ddlYKType.ClientID, 0);
            YKInfo.YiKaoChengShiId = inyYiKaoTypeId;

            string strYKCS = ddlYKType.SelectedItem.Text;
            YKInfo.YiKaoChengShi = strYKCS;


            int TpId = Basic.TypeConverter.StrToInt(HidYKZYTypeId.Value);
            string TpName = HidYKZYType.Value;
            if (TpId < 1)
            {
                Basic.MsgHelper.AlertBackMsg("请选择艺考专业");
            }
            YKInfo.YiKaoTypeId = TpId;
            YKInfo.YiKaoType = TpName;
            //int intYKType = Basic.RequestHelper.GetFormInt(ddlZhuaYeType.ClientID, 0);
            //YKInfo.YiKaoTypeId = intYKType;

            //string strYKT = ddlZhuaYeType.SelectedItem.Text;
            //YKInfo.YiKaoType = strYKT;

            string strYXDQ = Basic.RequestHelper.GetFormString(tbYXDQ.ClientID);
            YKInfo.YiXiangDiQu = strYXDQ;

            int strYXType = Basic.RequestHelper.GetFormInt(ddlYuanXiaoType.ClientID, 0);
            YKInfo.YuanXiaoType = strYXType;

            string strLianKao = Basic.RequestHelper.GetFormString(tbLianKaoChengJi.ClientID);
            YKInfo.LianKaoChengJi = strLianKao;

            int pId = Basic.TypeConverter.StrToInt(hidProvince.Value);
            string pName = hidProvinceName.Value;
            int cId = Basic.TypeConverter.StrToInt(hidCity.Value);
            string cName = hidCityName.Value;
            int xId = Basic.TypeConverter.StrToInt(hidCounty.Value);
            string xName = hidCountyName.Value;

            if (pId < 1)
            {
                Basic.MsgHelper.AlertBackMsg("请选择省份");
            }
            if (cId < 1)
            {
                Basic.MsgHelper.AlertBackMsg("请选择市");
            }
            if (xId < 1)
            {
                Basic.MsgHelper.AlertBackMsg("请选择区/县");
            }
            YKInfo.SshengId = pId;
            YKInfo.Ssheng = pName;
            YKInfo.SshiId = cId;
            YKInfo.Sshi = cName;
            YKInfo.SQuId = xId;
            YKInfo.SQu = xName;
            string strSPhone = Basic.RequestHelper.GetFormString(tbKaoShengPhone.ClientID);
            if (!System.Text.RegularExpressions.Regex.IsMatch(strSPhone, @"^(1[3|5|8|][0-9]|15[0|3|6|7|8|9]|18[8|9])\d{8}$") || string.IsNullOrEmpty(strSPhone))
            {
                Basic.MsgHelper.AlertBackMsg("您没有输入手机号，或者手机号输入格式有误");
            }
            YKInfo.KaoShengPhone = strSPhone;

            string strJiaZhangPhone = Basic.RequestHelper.GetFormString(tbJiaZhangPhone.ClientID);
            YKInfo.JiaZhangPhone = strJiaZhangPhone;
            string regex = "^([a-zA-Z0-9_\\.\\-])+\\@(([a-zA-Z0-9\\-])+\\.)+([a-zA-Z0-9]{2,4})+$";
            string strEmail = Basic.RequestHelper.GetFormString(tbEmail.ClientID);
            if (!Regex.IsMatch(strEmail, regex) || string.IsNullOrEmpty(strEmail))
            {
                Basic.MsgHelper.AlertBackMsg("您没有输入邮箱，或者邮箱输入格式有误");
            }
            YKInfo.Email = strEmail;

            int BaoKaoLeiBie = Basic.RequestHelper.GetFormInt(ddlBaoKaoType.ClientID, 0);
            YKInfo.BaoKaoType = BaoKaoLeiBie;


            int IsJianBao = Basic.RequestHelper.GetFormInt(ddlIsJianBao.ClientID, 0);
            YKInfo.IsJBWL = IsJianBao;

            int intKaoShengType = Basic.RequestHelper.GetFormInt(ddlKaoShengType.ClientID, 0);
            YKInfo.KaoShengType = intKaoShengType;

            string strYXZY = Basic.RequestHelper.GetFormString(tbYXZhuanYe.ClientID);
            YKInfo.YiXiangZhuanYe = strYXZY;

            string strYXYX = Basic.RequestHelper.GetFormString(tbYXYuanXiao.ClientID);
            YKInfo.YiXiangYuanXiao = strYXZY;

            int intBanXueType = Basic.RequestHelper.GetFormInt(ddlBanXueType.ClientID, 0);
            YKInfo.BanXueType = intBanXueType;

            string strXiaoKaoQK = Basic.RequestHelper.GetFormString("txtXiaoKao");
            YKInfo.XiaoKaoQingKuang = strXiaoKaoQK;

            string strTSSM = Basic.RequestHelper.GetFormString("txtMeto");

            YKInfo.Meto = strTSSM;

            string strYGYW = Basic.RequestHelper.GetFormString(tbYGYuWen.ClientID);
            YKInfo.YGYuWen = strYGYW;
            string strYGSX = Basic.RequestHelper.GetFormString(tbYGShuXue.ClientID);
            YKInfo.YGShuXue = strYGSX;
            string strYGYY = Basic.RequestHelper.GetFormString(tbYGYingYu.ClientID);
            YKInfo.YGYingYu = strYGYY;
            string strYGZH = Basic.RequestHelper.GetFormString(tbYGZongHe.ClientID);
            YKInfo.YGZongHe = strYGZH;
            string strYGZF = Basic.RequestHelper.GetFormString(tbYGZongFen.ClientID);
            YKInfo.YGZongFen = strYGZF;

            string strGKYW = Basic.RequestHelper.GetFormString(tbGKYuWen.ClientID);
            YKInfo.GKYuWen = strGKYW;
            string strGKSX = Basic.RequestHelper.GetFormString(tbGKShuXue.ClientID);
            YKInfo.GKShuXue = strGKSX;
            string strGKYY = Basic.RequestHelper.GetFormString(tbGKuYingYu.ClientID);
            YKInfo.GKYingYu = strGKYY;
            string strGKZH = Basic.RequestHelper.GetFormString(tbGKZongHe.ClientID);
            YKInfo.GKZhongHe = strGKZH;
            string strGKZF = Basic.RequestHelper.GetFormString(tbGKZongFen.ClientID);
            YKInfo.GKZongFen = strGKZF;

            int CountId = DAL.YKStudentXinXi.YKStudentXinXiAdd(YKInfo);

            if (CountId > 0)
            {
                Entity.Join_Student info = new Entity.Join_Student();
                info.BanJi = "";
                info.BanZhuRen = "";
                info.BanZhuRenMobile = "";
                info.CellPhone = YKInfo.KaoShengPhone;
                info.CityId = YKInfo.SshiId;
                info.CountyId = YKInfo.SQuId;
                info.FuQinPhone = YKInfo.JiaZhangPhone;
                info.GKYear = 2015;
                info.MuQinPhone = YKInfo.JiaZhangPhone;
                info.ProvinceId = YKInfo.SshengId;
                info.SchoolName = YKInfo.BiYeXueXiao;
                info.Sex = YKInfo.Sex;
                info.StudentName = YKInfo.StudentName;
                info.WenLi = (YKInfo.BaoKaoType == 1 ? 5 : 1);

                info.StudentLevel = 3;//会员卡是2 高考卡3

                int intId = DAL.TengXB.Join_Student.Join_StudentAdd_WanShanXinXi(info);
                if (intId > 0)
                {
                    if (DAL.GaoKaoCard.SetGaoKaoCardStudentId(intId, YKInfo.GaoKaoKaHao, YKInfo.SshengId))
                    {
                        Basic.MsgHelper.AlertUrlMsg("添加成功", "/");
                    }
                    else
                    {
                        Basic.MsgHelper.AlertBackMsg("添加失败...");
                    }
                }
                else
                {
                    Basic.MsgHelper.AlertBackMsg("添加失败..");
                }
            }
            else
            {
                Basic.MsgHelper.AlertBackMsg("添加失败");
            }

            #endregion

        }
    }
}