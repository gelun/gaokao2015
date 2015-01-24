using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace DAL
{
    public class Common
    {
        public static string GetProvinceName(int ProvinceId)
        {
            switch (ProvinceId)
            {
                case 1: return "北京市";
                case 2: return "天津市";
                case 3: return "河北省";
                case 4: return "山西省";
                case 5: return "内蒙古";
                case 6: return "辽宁省";
                case 7: return "吉林省";
                case 8: return "黑龙江";
                case 9: return "上海市";
                case 10: return "江苏省";
                case 11: return "浙江省";
                case 12: return "安徽省";
                case 13: return "福建省";
                case 14: return "江西省";
                case 15: return "山东省";
                case 16: return "河南省";
                case 17: return "湖北省";
                case 18: return "湖南省";
                case 19: return "广东省";
                case 20: return "广西省";
                case 21: return "海南省";
                case 22: return "重庆市";
                case 23: return "四川省";
                case 24: return "贵州省";
                case 25: return "云南省";
                case 26: return "西藏";
                case 27: return "陕西省";
                case 28: return "甘肃省";
                case 29: return "青海省";
                case 30: return "宁夏";
                case 31: return "新疆";
                case 32: return "港澳台";
            }
            return "";
        }

        public static string GetLevelName(int KeLei)
        {
            switch (KeLei)
            {
                case 1: return "注册用户";
                case 2: return "高考查询卡";
                case 3: return "高考测试卡";
                case 4: return "格伦高考卡";
                case 5: return "VIP测试卡";
                case 6: return "报考VIP卡";
                case 9: return "格伦会员卡";
            }
            return "";
        }

        public static string GetKeLeiMingCheng(int Level)
        {
            switch (Level)
            {
                case -1: return "未选择文理科";
                case 0: return "文理综合";
                case 1: return "文史类";
                case 2: return "";
                case 3: return "艺术（文）";
                case 4: return "体育（文）";
                case 5: return "理工类";
                case 6: return "";
                case 7: return "艺术（理）";
                case 8: return "体育（理）";
                case 9: return "单独考试";
            }
            return "";
        }

        public static string GetStudentClass(int GKYear)
        {
            int NowYear = DateTime.Now.Year;
            int NowMonth = DateTime.Now.Month;
            if (NowYear == GKYear)
                return "高三学生";
            else if (NowYear == (GKYear - 1))
            {
                if (NowMonth >= 9)
                    return "高三学生";
                else
                    return "高二学生";
            }
            else if (NowYear == (GKYear - 2))
            {
                if (NowMonth >= 9)
                    return "高二学生";
                else
                    return "高一学生";
            }
            else
                return "高一学生";
        }

        public static string GetProvincePinYin(int ProvinceId)
        {
            switch (ProvinceId)
            {
                case 1: return "beijing";
                case 2: return "tianjin";
                case 3: return "hebei";
                case 4: return "shanxi";
                case 5: return "neimenggu";
                case 6: return "liaoning";
                case 7: return "jilin";
                case 8: return "heilongjiang";
                case 9: return "shanghai";
                case 10: return "jiangsu";
                case 11: return "zhejiang";
                case 12: return "anhui";
                case 13: return "fujian";
                case 14: return "jiangxi";
                case 15: return "shandong";
                case 16: return "henan";
                case 17: return "hubei";
                case 18: return "hunan";
                case 19: return "guangdong";
                case 20: return "guangxi";
                case 21: return "hainan";
                case 22: return "chongqing";
                case 23: return "sichuan";
                case 24: return "guizhou";
                case 25: return "yunnan";
                case 26: return "xizang";
                case 27: return "shanxi2";
                case 28: return "gansu";
                case 29: return "qinghai";
                case 30: return "ningxia";
                case 31: return "xinjiang";
                case 32: return "gangaotai";
            }
            return "";
        }

        public static string GetProvinceTableName(string strTable, int ProvinceId, string DataYear)
        {
            //if(ProvinceId != 0)
            //{
            //    Entity.ProvinceConfig provinceConfig = DAL.ProvinceConfig.ProvinceConfigEntityGet(ProvinceId);
            //    if (provinceConfig != null && provinceConfig.OwnTable == 1)
            //    {
            //        strTable = strTable + "_" + GetProvincePinYin(ProvinceId);
            //    }
            //}
            //if (DataYear != "")
            //    strTable = strTable + "_" + DataYear;

            Entity.ProvinceConfig provinceConfig = DAL.ProvinceConfig.ProvinceConfigEntityGet(ProvinceId);
            if (provinceConfig != null && provinceConfig.OwnTable == 1)
            {
                if (DataYear == "All")
                {
                    strTable = strTable + "_" + GetProvincePinYin(ProvinceId) + "_All";
                }
                else
                {
                    strTable = strTable + "_" + GetProvincePinYin(ProvinceId);
                }
            }
            else
            {
                if (DataYear != "")
                    strTable = strTable + "_" + DataYear;
            }
            return strTable;
        }


        public static string GetProvinceTableName(int ProvinceId, string strTable)
        {
            return GetProvinceTableName(strTable, ProvinceId, "");
        }


        public static string GetYearTableName(string strTable, string DataYear)
        {
            return GetProvinceTableName(strTable, 0, DataYear);
        }


        public static string GetCengCiMingCheng(int CengCi)
        {
            switch (CengCi)
            {
                case 1: return "本科";
                case 2: return "高职高专";
                case 3: return "预科";
            }
            return "";
        }


        public static string GetPiCiMingCheng(int PiCi)
        {
            switch (PiCi)
            {
                case 0: return "提前批";
                case 1: return "第一批";
                case 2: return "第二批";
                case 3: return "第三批";
                case 4: return "专科一批";
                case 5: return "专科二批";
            }
            return "";
        }



        public static string GetPiCiName(int PiCi, int ProvinceId)
        {
            DataTable dt = DAL.ProvincePiCi.ProvincePiCiList("ProvinceId = " + ProvinceId + " and PiCi = " + PiCi);
            if (dt != null && dt.Rows.Count > 0)
            {
                return dt.Rows[0]["PcName"].ToString();
            }
            else
            {
                return "";
            }
        }


        public static string GetPcLeiBieMingCheng(int PcLeiBie)
        {
            switch (PcLeiBie)
            {
                case 0: return "";
                case 1: return "A类";
                case 2: return "B类";
                case 3: return "C类";
            }
            return "";
        }

        /*院校特色相关html代码*/
        public static string GetYuanXiaoTeSeHtml(DataRow dr)
        {
            string strTeSe = "";

            //211
            if (dr["Is211"].ToString() == "1")
            {
                strTeSe += "<a href=\"javascript:void(0);\" title=\"211工程院校\">211</a>";
            }
            //Is985
            if (dr["Is985"].ToString() == "1")
            {
                strTeSe += "<a href=\"javascript:void(0);\" title=\"985工程院校\">985</a>";
            }
            //研究生院
            if (dr["IsGraduateSchool"].ToString() == "1")
            {
                strTeSe += "<a href=\"javascript:void(0);\" title=\"开设研究生院\">研</a>";
            }
            //自主招生
            if (dr["IsIndependentRecruitment"].ToString() == "1")
            {
                strTeSe += "<a href=\"javascript:void(0);\" title=\"自主招生高校\">自</a>";
            }
            //国防生
            if (dr["IsNationalDefense"].ToString() == "1")
            {
                strTeSe += "<a href=\"javascript:void(0);\" title=\"招收国防生高校\">国</a>";
            }
            //小211
            if (dr["IsMiNi211"].ToString() == "1")
            {
                strTeSe += "<a href=\"javascript:void(0);\" title=\"中西部高校基础能力建设工程（小211工程）\">小211</a>";
            }
            //农村专项
            if (dr["IsRuralSpecial"].ToString() == "1")
            {
                strTeSe += "<a href=\"javascript:void(0);\" title=\"农村专项批次招生院校\">农</a>";
            }
            //艺术生
            if (dr["IsArtSpecialty"].ToString() == "1")
            {
                strTeSe += "<a href=\"javascript:void(0);\" title=\"招收艺术特长生院校\">艺</a>";
            }
            //高水平运动员
            if (dr["IsHighLevelAthletes"].ToString() == "1")
            {
                strTeSe += "<a href=\"javascript:void(0);\" title=\"招收高水平运动员院校\">体</a>";
            }
            //卓越工程
            if (dr["IsExcellent"].ToString() == "1")
            {
                strTeSe += "<a href=\"javascript:void(0);\" title=\"卓越工程师教育培养计划高校\">卓</a>";
            }

            return strTeSe;
        }


        /*院校特色相关html代码*/
        public static string GetYuanXiaoTeSeJianHtml(DataRow dr)
        {
            string strTeSe = "";

            //211
            if (dr["Is211"].ToString() == "1")
            {
                strTeSe += "<a href=\"javascript:void(0);\" title=\"211工程院校\">211</a>";
            }
            //Is985
            if (dr["Is985"].ToString() == "1")
            {
                strTeSe += "<a href=\"javascript:void(0);\" title=\"985工程院校\">985</a>";
            }
            //研究生院
            if (dr["IsGraduateSchool"].ToString() == "1")
            {
                strTeSe += "<a href=\"javascript:void(0);\" title=\"开设研究生院\">研</a>";
            }
            ////自主招生
            //if (dr["IsIndependentRecruitment"].ToString() == "1")
            //{
            //    strTeSe += "<a href=\"javascript:void(0);\" title=\"自主招生高校\">自</a>";
            //}
            ////国防生
            //if (dr["IsNationalDefense"].ToString() == "1")
            //{
            //    strTeSe += "<a href=\"javascript:void(0);\" title=\"招收国防生高校\">国</a>";
            //}
            //小211
            if (dr["IsMiNi211"].ToString() == "1")
            {
                strTeSe += "<a href=\"javascript:void(0);\" title=\"中西部高校基础能力建设工程（小211工程）\">小211</a>";
            }
            ////农村专项
            //if (dr["IsRuralSpecial"].ToString() == "1")
            //{
            //    strTeSe += "<a href=\"javascript:void(0);\" title=\"农村专项批次招生院校\">农</a>";
            //}
            ////艺术生
            //if (dr["IsArtSpecialty"].ToString() == "1")
            //{
            //    strTeSe += "<a href=\"javascript:void(0);\" title=\"招收艺术特长生院校\">艺</a>";
            //}
            ////高水平运动员
            //if (dr["IsHighLevelAthletes"].ToString() == "1")
            //{
            //    strTeSe += "<a href=\"javascript:void(0);\" title=\"招收高水平运动员院校\">体</a>";
            //}
            //卓越工程
            if (dr["IsExcellent"].ToString() == "1")
            {
                strTeSe += "<a href=\"javascript:void(0);\" title=\"卓越工程师教育培养计划高校\">卓</a>";
            }

            return strTeSe;
        }

        public static string GetGaoKaoZhenTiTableName(int intSubjectId)
        {
            switch (intSubjectId)
            {
                case 1:
                    return "yw";
                case 2:
                    return "sx";
                case 3:
                    return "yy";
                case 4:
                    return "wl";
                case 5:
                    return "hx";
                case 6:
                    return "sw";
                case 7:
                    return "dl";
                case 8:
                    return "ls";
                case 9:
                    return "zz";
                default:
                    return "yw";

            }
        }


        public static string GetGaoKaoZhenTiKeMuName(int intSubjectId)
        {
            switch (intSubjectId)
            {
                case 1:
                    return "语文";
                case 2:
                    return "数学";
                case 3:
                    return "英语";
                case 4:
                    return "物理";
                case 5:
                    return "化学";
                case 6:
                    return "生物";
                case 7:
                    return "地理";
                case 8:
                    return "历史";
                case 9:
                    return "政治";
                default:
                    return "语文";

            }
        }


        public static string GetProvinceTableName(int ProvinceId, string strTable,string DataYear)
        {
        //    return GetProvinceTableName(strTable, ProvinceId, "");

            Entity.ProvinceConfig provinceConfig = DAL.ProvinceConfig.ProvinceConfigEntityGet(ProvinceId);
            if (provinceConfig != null && provinceConfig.OwnTable == 1)
            {
                if (DataYear == "All")
                {
                    strTable = strTable + "_" + GetProvincePinYin(ProvinceId) + "_All";
                }
                else
                {
                    strTable = strTable + "_" + GetProvincePinYin(ProvinceId);
                }
            }
            else
            {
                if (DataYear != "")
                    strTable = strTable + "_All";
            }
            return strTable;
        }
    }
}
