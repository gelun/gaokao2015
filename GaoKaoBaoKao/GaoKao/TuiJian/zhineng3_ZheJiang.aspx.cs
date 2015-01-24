using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Collections;

namespace GaoKao.TuiJian
{
    public partial class zhineng3_ZheJiang : BaseTuiJian
    {
        protected int ProvincePiCiId = 0;
        public Entity.ProvincePiCi provincePiCi = new Entity.ProvincePiCi();
        public DataTable dtProvinceZhiYuan = null;
        public int intZhiYuanCount = 0;//每个志愿允许填报的专业的个数
        //public int latestZhuanKeYear = 2013;

        protected int ZongFen = 0;
        protected Entity.ProvinceWeiCi infoProvinceWeiCi = new Entity.ProvinceWeiCi();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (userinfo.ProvinceId != 11)
            {
                Server.Transfer("zhineng3.spx");
            }
            //latestZhuanKeYear = provinceConfig.LatestZhuanKeYear
            ProvincePiCiId = Basic.RequestHelper.GetQueryInt("pcid", 0);
            if (ProvincePiCiId > 0)
            {
                //省份批次实体对象
                provincePiCi = DAL.ProvincePiCi.ProvincePiCiEntityGet(ProvincePiCiId);

                //获取该批次下应该使用的总分和位次等信息
                switch (provincePiCi.PiCi)
                {
                    case 1: ZongFen = history_zhejiang.ZongFen1;
                        break;
                    case 2: ZongFen = history_zhejiang.ZongFen2;
                        break;
                    case 3: ZongFen = history_zhejiang.ZongFen3;
                        break;
                    default:
                        break;
                }
                if (ZongFen == 0)
                {
                    Basic.MsgHelper.AlertUrlMsg("请首先设置自己的考试成绩！", "/Persional/ChengJiEdit2.aspx"); //跳转到成绩输入页面
                }
                else
                {
                    intZhiYuanCount = provincePiCi.MajorCount;

                    infoProvinceWeiCi = DAL.ProvinceWeiCi.ProvinceWeiCiEntityGetByFenShu(ZongFen, provinceConfig.LatestProvinceWeiCiYear, 11, userinfo.KeLei, (provincePiCi.PiCi == 0 ? 1 : provincePiCi.PiCi));//

                    //志愿相关信息
                    dtProvinceZhiYuan = DAL.ProvinceZhiYuan.ProvinceZhiYuanList("IsPause = 0 AND ProvincePcId = " + ProvincePiCiId + " ORDER BY ShowOrder ASC");
                }
            }
            else
                Response.Redirect("zhineng1.aspx");
            BindSchoolList();
        }


        void BindSchoolList()
        {
            //获取传递过来的院校
            string strSchoolList = Basic.RequestHelper.GetQueryString("schoollist");
            if (strSchoolList == "")
            {
                Basic.MsgHelper.AlertBackMsg("请先选择院校");
            }


            #region 根据传递过来的院校id，拼接筛选条件

            string[] arr = strSchoolList.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            string Where = "";
            for (int i = 0; i < arr.Length; i++)
            {
                int SchoolId = Basic.TypeConverter.StrToInt(arr[i], 0);
                if (SchoolId > 0)
                {
                    Where += " Id = " + SchoolId + "OR";
                }
                else
                {
                    //如果传递过来的id正整数，则将其移除掉
                    ArrayList al = new ArrayList(arr);
                    al.RemoveAt(i);
                    arr = (string[])al.ToArray(typeof(string));
                }
            }

            if (Where.EndsWith("OR"))
            {
                Where = Where.Substring(0, Where.Length - 2);
            }
            else
            {
                Basic.MsgHelper.AlertBackMsg("请先选择院校");
            }

            #endregion


            DataTable dt = DAL.TengXB.School.YxkSchoolList("(" + Where + ")");
            if (dt != null && dt.Rows.Count > 0)
            {
                //将从数据库中取出来的院校按照 传递过来的顺序进行重新排序
                DataTable dtnew = dt.Clone();//将表dt里的列信息复制到dtnew里，不是复制数据 
                for (int i = 0; i < arr.Length; i++)
                {
                    DataRow dr = dt.Select("Id=" + arr[i])[0];//查找id为1的信息
                    dtnew.Rows.Add(dr.ItemArray);//把过滤好的信息加入到dtnew里  
                }

                bool SaveAndContinue = true;

                #region 判定是继续选报专业，还是直接保存院校并返回zhineng1页面
                //本科批次
                if (provincePiCi.PiCi >= 1 && provincePiCi.PiCi <= 3)
                {
                    SaveAndContinue = true;
                }
                //专科批次
                else if (provincePiCi.PiCi > 3)
                {
                    if (provinceConfig.HasZhuanKeZhuanYe == 1)
                    {
                        SaveAndContinue = true;
                    }
                    else
                    {
                        SaveAndContinue = false;//说明是专科批次，并且还没有专科专业
                    }
                }
                //提前批次
                else if (provincePiCi.PiCi == 0)
                {
                    if (provinceConfig.HasTiQianPiZhuanYe == 1)
                    {
                        SaveAndContinue = true;
                    }
                    else
                    {
                        SaveAndContinue = false;//说明是提前批次，并且还没有提前批专业
                    }
                }
                #endregion

                if (SaveAndContinue == false)
                {
                    //如果传递过来的批次不是本科批次，并且目前还没有专业相关的数据，就只保存院校信息，然后直接返回zhineng1.aspx页面
                    SaveZhuanKeZhiYuanWithoutZhuanYe(dtnew);
                }
                else
                {
                    //绑定页面志愿表信息
                    rptList.DataSource = dtnew;
                    rptList.DataBind();

                    ltlZhiYuanList.Text = "<tr><th width=\"10%\">志愿</th><th width=\"14%\">院校名称</th>";
                    for (int j = 1; j <= intZhiYuanCount; j++)
                    {
                        ltlZhiYuanList.Text += "<th width=\"10%\">专业" + j + "</th>";
                    }
                    ltlZhiYuanList.Text += "<th width=\"10%\">允许调剂</th></tr>";

                    //绑定页面底部志愿表信息
                    for (int i = 0; i < dtnew.Rows.Count; i++)
                    {
                        ltlZhiYuanList.Text += "<tr sid='" + dtnew.Rows[i]["Id"].ToString() + "' sn='" + dtnew.Rows[i]["SchoolName"].ToString() + "' pczyid='" + GetZhiYuanId(i) + "'>";
                        ltlZhiYuanList.Text += "<td>" + GetZhiYuanMing(i) + "</td>";
                        //ltlZhiYuanList.Text += "<td>" + dt.Rows[i]["SchoolName"].ToString() + "<img src=\"/images/2015zntb/jtT.jpg\" class=\"up\" onclick=\"SelectUp(this);\"><img src=\"/images/2015zntb/jtB.jpg\" class=\"down\" onclick=\"SelectDown(this);\"></td>";
                        ltlZhiYuanList.Text += "<td>" + dtnew.Rows[i]["SchoolName"].ToString() + "</td>";

                        for (int j = 0; j < intZhiYuanCount; j++)
                        {
                            ltlZhiYuanList.Text += "<td></td>";
                        }

                        ltlZhiYuanList.Text += "<td tj=\"1\"><div class=\"xzzybtm\"><input type=\"checkbox\" checked=\"checked\" class=\"xytj\" sid='" + dtnew.Rows[i]["Id"].ToString() + "' />允许调剂</div></td>";
                        ltlZhiYuanList.Text += "</tr>";
                    }
                }
            }
        }

        protected void rptList_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Repeater rptList = e.Item.FindControl("rptList") as Repeater;
                DataRowView rowv = (DataRowView)e.Item.DataItem;
                int SchoolId = Convert.ToInt32(rowv["Id"]);

                DataTable dt = null;
                string strWhere = "fszylq.DataYear = " + provinceConfig.LatestBenKeYear + " and ProvinceId = " + userinfo.ProvinceId + " and PiCi = " + provincePiCi.PiCi + " and KeLei = " + userinfo.KeLei + " and SchoolId = " + SchoolId;
                dt = DAL.FenShengZhuanYeLuQu.GetZhuanYeList(strWhere, userinfo.ProvinceId, provinceConfig.LatestBenKeZhuanYeYear);
                if (dt != null && dt.Rows.Count > 0)
                {
                    rptList.DataSource = dt;
                    rptList.DataBind();
                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string strList = hidZhiYuan.Value;//获取填报的志愿数据  json格式的数据：{pczyid:111,schoolid:11,schoolname:北京大学,zyid:11,zyname:fsdf,tj:1},{schoolid:11,zyid:11,zyname:'fsdf',tj:1},

            string[] arr = strList.Split(new string[] { "}," }, StringSplitOptions.RemoveEmptyEntries);
            if (arr.Length == 0)
            {
                Basic.MsgHelper.AlertBackMsg("请选报专业1");
            }
            else
            {
                //删除旧数据
                DAL.TengXB.StudentZhiYuan.StudentZhiYuanDel(ProvincePiCiId, userinfo.StudentId);
                //循环添加新数据
                for (int i = 0; i < arr.Length; i++)
                {
                    int intZhiYuanId = 0;//ProvinceZhiYuan表中的 id
                    int intSchoolId = 0;//学校id
                    string strSchoolName = "";//学校名称
                    int intIsTiaoJi = 0;//是否服从调剂
                    string strMajorList = "";//所报专业
                    int intIsAllMajor = 0;

                    string ZhiYuanList = arr[i].Replace("{", "").Replace("}", "");
                    string[] arrZhiYuan = ZhiYuanList.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                    if (arrZhiYuan.Length >= 7)
                    {
                        //ProvinceZhiYuan表中的 id
                        intZhiYuanId = Basic.TypeConverter.StrToInt(arrZhiYuan[0].Replace("pczyid:", "").Replace(" ", ""), 0);
                        //学校id
                        intSchoolId = Basic.TypeConverter.StrToInt(arrZhiYuan[1].Replace("schoolid:", "").Replace(" ", ""), 0);
                        //学校名称
                        strSchoolName = arrZhiYuan[2].Replace("schoolname:", "").Replace(" ", "");
                        //是否选择了本院校全部的专业
                        intIsAllMajor = Basic.TypeConverter.StrToInt(arrZhiYuan[(arrZhiYuan.Length - 2)].Replace("isallmajor:", "").Replace(" ", ""), 0);
                        //是否服从调剂
                        intIsTiaoJi = Basic.TypeConverter.StrToInt(arrZhiYuan[(arrZhiYuan.Length - 1)].Replace("tj:", "").Replace(" ", ""), 0);

                        //所报专业:   1:哲学,2:经济学,3:心理学,
                        for (int j = 3; j < arrZhiYuan.Length - 2; j++)
                        {
                            if (j % 2 == 1)
                            {
                                int intZhuanYeId = Basic.TypeConverter.StrToInt(arrZhiYuan[j].Replace("zyid:", "").Replace(" ", ""), 0);
                                if (intZhuanYeId > 0)
                                {
                                    strMajorList += intZhuanYeId + ":";//专业id
                                }
                            }
                            else
                            {
                                string strZhuanYeName = arrZhiYuan[j].Replace("zyname:", "").Replace(" ", "");
                                if (strZhuanYeName != "''")
                                {
                                    strMajorList += strZhuanYeName + ",";//专业名称
                                }
                            }
                        }

                        //构造实体，将志愿存入数据库中
                        Entity.StudentZhiYuan infoZhiYuan = new Entity.StudentZhiYuan();
                        //新建
                        infoZhiYuan.IsAllMajor = intIsAllMajor;//是否选择了本院校全部的专业
                        infoZhiYuan.IsTiaoJi = intIsTiaoJi;
                        infoZhiYuan.MajorCount = intZhiYuanCount;
                        infoZhiYuan.MajorList = strMajorList;
                        infoZhiYuan.Memo = "";
                        infoZhiYuan.ProvincePcId = ProvincePiCiId;
                        infoZhiYuan.ProvinceZhiYuanId = intZhiYuanId;
                        infoZhiYuan.SchoolId = intSchoolId;
                        infoZhiYuan.SchoolName = strSchoolName;
                        infoZhiYuan.StudentId = userinfo.StudentId;

                        if (DAL.StudentZhiYuan.StudentZhiYuanAdd(infoZhiYuan) > 0)
                        {
                            // Basic.MsgHelper.AlertUrlMsg("保存成功", "zhineng1.aspx");
                        }
                        else
                        {
                            Basic.MsgHelper.AlertBackMsg("保存失败");
                        }
                    }
                    else
                    {
                        Basic.MsgHelper.AlertBackMsg("请选报专业2");
                    }
                }
                Basic.MsgHelper.AlertUrlMsg("保存成功", "zhineng1.aspx");
            }
        }

        //获取志愿名称
        protected string GetZhiYuanMing(int intIndex)
        {
            //省份志愿表 实体对象
            if (dtProvinceZhiYuan != null && dtProvinceZhiYuan.Rows.Count > 0)
            {
                return dtProvinceZhiYuan.Rows[intIndex]["ZhiYuanMing"].ToString();//志愿名称
            }
            else
            {
                return "";
            }
        }

        //获取志愿Id
        protected int GetZhiYuanId(int intIndex)
        {
            //省份志愿表 实体对象
            if (dtProvinceZhiYuan != null && dtProvinceZhiYuan.Rows.Count > 0)
            {
                return Basic.TypeConverter.StrToInt(dtProvinceZhiYuan.Rows[intIndex]["Id"].ToString(),0);//志愿名称
            }
            else
            {
                return 0;
            }
        }

        /*如果传递过来的批次不是本科批次，并且目前还没有专业相关的数据，就只保存院校信息，然后直接返回zhineng1.aspx页面*/
        void SaveZhuanKeZhiYuanWithoutZhuanYe(DataTable dt)
        {
            //删除旧数据
            DAL.TengXB.StudentZhiYuan.StudentZhiYuanDel(ProvincePiCiId, userinfo.StudentId);
            //循环添加新数据
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                int intZhiYuanId = GetZhiYuanId(i);//ProvinceZhiYuan表中的 id
                int intSchoolId = Basic.TypeConverter.StrToInt(dt.Rows[i]["Id"].ToString(), 0);//学校id
                string strSchoolName = dt.Rows[i]["SchoolName"].ToString();//学校名称
                int intIsTiaoJi = 1;//是否服从调剂
                string strMajorList = "";//所报专业
                int intIsAllMajor = 0;

                //构造实体，将志愿存入数据库中
                Entity.StudentZhiYuan infoZhiYuan = new Entity.StudentZhiYuan();
                //新建
                infoZhiYuan.IsAllMajor = intIsAllMajor;//是否选择了本院校全部的专业
                infoZhiYuan.IsTiaoJi = intIsTiaoJi;
                infoZhiYuan.MajorCount = intZhiYuanCount;
                infoZhiYuan.MajorList = strMajorList;
                infoZhiYuan.Memo = "暂无本科专业";
                infoZhiYuan.ProvincePcId = ProvincePiCiId;
                infoZhiYuan.ProvinceZhiYuanId = intZhiYuanId;
                infoZhiYuan.SchoolId = intSchoolId;
                infoZhiYuan.SchoolName = strSchoolName;
                infoZhiYuan.StudentId = userinfo.StudentId;

                if (DAL.StudentZhiYuan.StudentZhiYuanAdd(infoZhiYuan) > 0)
                {
                    // Basic.MsgHelper.AlertUrlMsg("保存成功", "zhineng1.aspx");
                }
                else
                {
                    Basic.MsgHelper.AlertBackMsg("保存失败");
                }
            }
            Basic.MsgHelper.AlertUrlMsg("保存成功", "zhineng1.aspx");
        }
    }
}