using System;
using System.Collections.Generic;
using System.Data;
using System.Web;

namespace GaoKao.TuiJian
{
    /// <summary>
    /// GetSchoolList 的摘要说明
    /// </summary>
    public class GetSchoolList : IHttpHandler
    {
        public int StudentPiCi = 0;
        public int StudentProvinceId = 0;
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";

            //基础html
            string strHtml = "";


            StudentProvinceId = Basic.RequestHelper.GetFormInt("StudentProvinceId", 3);
            int StudentId = Basic.RequestHelper.GetFormInt("StudentId", 0);
            int StudentKeLei = Basic.RequestHelper.GetFormInt("StudentKeLei", 5);
            StudentPiCi = Basic.RequestHelper.GetFormInt("StudentPiCi", 1);
            int StudentPcLeiBie = Basic.RequestHelper.GetFormInt("StudentPcLeiBie", 0);

            //获取传递过来的参数  并 拼接筛选条件
            string strWhere = GetFormStringANDCondition();

            Entity.ProvinceConfig config = DAL.ProvinceConfig.ProvinceConfigEntityGet(StudentProvinceId);
            Entity.StudentGaoKaoHistory history = DAL.StudentGaoKaoHistory.StudentGaoKaoHistoryEntityGet(StudentId);
            if (history.IsSetUpWeiCi == 0)
                history.WeiCi = DAL.ProvinceWeiCi.ProvinceWeiCiEntityGetByFenShu(history.FenShu, config.LatestProvinceWeiCiYear, StudentProvinceId, StudentKeLei).WeiCi;
            Entity.FenShuXian fenshuxian = DAL.FenShuXian.FenShuXianEntityGet(StudentProvinceId, " AND KeLei = " + StudentKeLei + "  AND DataYear = " + config.LatestProvinceWeiCiYear);

            if (history.IsSetUpFenShuXian == 1)
            {
                fenshuxian.PcFirst = (history.PcFirst > 0 ? history.PcFirst : fenshuxian.PcFirst);
                fenshuxian.PcSecond = (history.PcSecond > 0 ? history.PcSecond : fenshuxian.PcSecond);
                fenshuxian.PcThird = (history.PcThird > 0 ? history.PcThird : fenshuxian.PcThird);
                fenshuxian.ZkFirst = (history.PcZhuanKeFirst > 0 ? history.PcZhuanKeFirst : fenshuxian.ZkFirst);
                fenshuxian.ZkSecond = (history.PcZhuanKeSecond > 0 ? history.PcZhuanKeSecond : fenshuxian.ZkSecond);
            }

            int FirstPiCiWeiCi = DAL.ProvinceWeiCi.ProvinceWeiCiEntityGetByFenShu(fenshuxian.PcFirst, config.LatestProvinceWeiCiYear, StudentProvinceId, StudentKeLei).WeiCi;
            Entity.StudentChengJi studentChengJi = DAL.CommonTuiJian.GetUserPiCi(fenshuxian, history.FenShu, config.LatestProvinceWeiCiYear, StudentProvinceId, StudentKeLei);

            int XianCha = 0;
            if (StudentProvinceId == 11 && StudentPiCi == 0)//浙江提前批的线差和一批次的线差一样
            {
                XianCha = DAL.CommonTuiJian.GetUserPiCiXianCha(fenshuxian, history.FenShu, 1);
            }
            else
            {
                XianCha = DAL.CommonTuiJian.GetUserPiCiXianCha(fenshuxian, history.FenShu, StudentPiCi);
            }

            int StudentFirstLevel = history.FirstLevel;
            int StudentSecondLevel = history.SecondLevel;
            DataTable dt = DAL.CommonTuiJian.FenShengYuanXiaoLuQuList(strWhere, StudentProvinceId, StudentId, StudentKeLei, StudentPiCi, StudentPcLeiBie, XianCha, StudentFirstLevel, StudentSecondLevel);
            //給DataTable
            if (dt!=null)
            {
                dt.Columns.Add("BaoKaoTuiJian", typeof(int));
                foreach (DataRow dr in dt.Rows)
                {
                    dr["BaoKaoTuiJian"] = DAL.CommonTuiJian.ShowSuggest(StudentProvinceId, StudentPiCi, FirstPiCiWeiCi, history.WeiCi, Basic.Utils.StrToInt(dr["glZuiXiaoWeiCi"].ToString(), 0), Basic.Utils.StrToInt(dr["glZuiDaWeiCi"].ToString(), 0), Basic.Utils.StrToInt(dr["glPingJunWeiCi"].ToString(), 0), XianCha, Basic.Utils.StrToInt(dr["PiCiXian"].ToString(), 0), Basic.Utils.StrToInt(dr["glZuiGaoFen"].ToString(), 0), Basic.Utils.StrToInt(dr["glZuiDiFen"].ToString(), 0), Basic.Utils.StrToInt(dr["glPingJunFen"].ToString(), 0));
                }

                DataView dv = dt.DefaultView;
                dv.Sort = "BaoKaoTuiJian ASC";

                DataTable dt2 = dv.ToTable();
                strHtml += GetBaseHtml();
                strHtml += GetSchoolHtml(dt2);//院校相关html
                context.Response.Write(strHtml);

                //ShowSuggestImg(int.Parse(Eval("glZuiXiaoWeiCi").ToString()), int.Parse(Eval("glZuiDaWeiCi").ToString()), int.Parse(Eval("glPingJunWeiCi").ToString()), int.Parse(Eval("PiCiXian").ToString()),  int.Parse(Eval("glZuiGaoFen").ToString()), int.Parse(Eval("glZuiDiFen").ToString()),int.Parse(Eval("glPingJunFen").ToString()))%>
            }
        }


        /*基础html*/
        string GetBaseHtml()
        {
            string strHtml = "";
            strHtml += "<tr>";
            strHtml += "<th width=\"8%\"></th>";
            strHtml += "<th width=\"18%\">院校名称</th>";
            if (StudentProvinceId == 10)
                strHtml += "<th width=\"10%\">选测等级</th>";
            strHtml += "<th width=\"10%\">院校特色</th>";
            strHtml += "<th width=\"9%\">院校属性</th>";
            strHtml += "<th width=\"10%\">省份</th>";
            strHtml += "<th width=\"15%\">隶属</th>";

            if (StudentProvinceId != 10)
                strHtml += "<th width=\"10%\">武书连排名</th>";
            strHtml += "<th width=\"9%\">报考推荐</th>";
            strHtml += "<th width=\"11%\">选报</th>";
            strHtml += "</tr>\r\n";

            return strHtml;
        }


        //接收参数 并 拼接筛选条件
        string GetFormStringANDCondition()
        {
            //tese: tese, cengci: cengci, xingzhi: xingzhi, belong: belong, leixing: leixing, province: province
            string tese = Basic.RequestHelper.GetFormString("tese");
            string cengci = Basic.RequestHelper.GetFormString("cengci");
            string xingzhi = Basic.RequestHelper.GetFormString("xingzhi");
            string belong = Basic.RequestHelper.GetFormString("belong");
            string leixing = Basic.RequestHelper.GetFormString("leixing");
            string province = Basic.RequestHelper.GetFormString("province");
            string schoolname = Basic.RequestHelper.GetFormString("schoolname");
            string zhuanye = Basic.RequestHelper.GetFormString("zhuanye");

            string strWhere = " 1 = 1 ";

            //院校名称
            if (schoolname != "")
            {
                string[] arr = schoolname.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                if (arr.Length > 0)
                {
                    strWhere += "AND (";
                    for (int i = 0; i < arr.Length; i++)
                    {
                        strWhere += " S.SchoolName like '%" + arr[i] + "%' OR";
                    }
                    if (strWhere.EndsWith("OR"))
                    {
                        strWhere = strWhere.Remove(strWhere.LastIndexOf("OR"));
                    }
                    strWhere += ")";
                }
            }

            //专业
            if (zhuanye != "")
            {
                string strZYList = "";
                string[] arr = zhuanye.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                if (arr.Length > 0)
                {
                    for (int i = 0; i < arr.Length; i++)
                    {
                        if (i==arr.Length-1)
                        {
                            strZYList += arr[i];
                        }
                        else
                        {
                            strZYList += arr[i] + ",";
                        }
                    }
                }

                if (strZYList.Length > 0)
                {
                    strWhere += " AND S.Id in (SELECT SchoolId FROM " + DAL.Common.GetProvinceTableName(StudentProvinceId, "FenShengZhuanYeLuQu") + " where ZyId in (" + strZYList + ")) ";
                }
            }


            strWhere += GetConditionTeSeHtml(tese);//院校特色

            strWhere += GetCondition(cengci, "S.SchoolCengCi");//院校层次
            strWhere += GetCondition(xingzhi, "S.SchoolNature");//院校性质
            strWhere += GetCondition(belong, "S.Belong");//院校隶属
            strWhere += GetCondition(leixing, "S.YuanXiaoLeiXingId");//院校类型
            strWhere += GetCondition(province, "S.ProvinceId");//省份


            return strWhere;
        }

        /*院校特色*/
        string GetConditionTeSeHtml(string strTeSe)
        {
            string strWhere = "";
            string[] arr = strTeSe.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < arr.Length; i++)
            {
                switch (arr[i])
                {
                    case "1"://211
                        strWhere += " OR S.Is211 = 1";
                        break;
                    case "2"://985
                        strWhere += " OR S.Is985 = 1";
                        break;
                    case "3"://研究生院
                        strWhere += " OR S.IsGraduateSchool = 1";
                        break;
                    case "4"://自主招生
                        strWhere += " OR S.IsIndependentRecruitment = 1";
                        break;
                    case "5"://国防生
                        strWhere += " OR S.IsNationalDefense = 1";
                        break;
                    case "6"://农村专项
                        strWhere += " OR S.IsRuralSpecial = 1";
                        break;
                    case "7"://小211
                        strWhere += " OR S.IsMiNi211 = 1";
                        break;
                    case "8"://卓越工程
                        strWhere += " OR S.IsExcellent = 1";
                        break;
                    case "9"://艺术生
                        strWhere += " OR S.IsArtSpecialty = 1";
                        break;
                    case "10"://高水平运动员
                        strWhere += " OR S.IsHighLevelAthletes = 1";
                        break;
                    default:
                        //没有进行任何选择
                        break;
                }
            }

            if (strWhere.StartsWith(" OR "))
            {
                strWhere = " AND (" + strWhere.Substring(3) + ")";
            }
            return strWhere;
        }

        /*筛选条件*/
        string GetCondition(string strPram, string strCondition)
        {
            string strNewPram = GetSubString(strPram);
            return strNewPram == "" ? "" : " AND " + strCondition + " IN (" + strNewPram + ")";
        }

        /*字符串去掉最后的 , */
        string GetSubString(string strString)
        {
            if (strString.EndsWith(","))
            {
                strString = strString.Substring(0, strString.Length - 1);
            }
            return strString;
        }



        /*院校相关信息生成的html代码*/
        string GetSchoolHtml(DataTable dt)
        {
            string strHtml = "";
            if (dt != null && dt.Rows.Count > 0)
            {
                for (int i = 0; i <= dt.Rows.Count - 1; i++)
                {
                    string strBaoKaoTuiJian = dt.Rows[i]["BaoKaoTuiJian"].ToString();

                    strHtml += "<tr tuijian='" + strBaoKaoTuiJian + "'>";
                    strHtml += "  <td><a href=\"/TuiJian/data_yx.aspx?schoolid=" + dt.Rows[i]["SchoolId"].ToString() + "&pici=" + StudentPiCi + "\"  class=\"fb\">历年分数线</a></td>";
                    //strHtml += "  <td sid=\"" + dt.Rows[i]["Id"].ToString() + "\" sn=\"" + dt.Rows[i]["SchoolName"].ToString() + "\"><a target=\"_blank\" href=\"SchoolIntro.aspx?schoolid=" + dt.Rows[i]["Id"].ToString() + "\" title=\"" + dt.Rows[i]["SchoolName"].ToString() + "\">" + dt.Rows[i]["SchoolName"].ToString() + "</a></td>";
                    strHtml += "  <td sid=\"" + dt.Rows[i]["SchoolId"].ToString() + "\" sn=\"" + dt.Rows[i]["SchoolName"].ToString() + "\"><a target=\"_blank\" href=\"/daxue-jianjie-" + dt.Rows[i]["SchoolId"].ToString() + ".shtml\">";

                    if (StudentProvinceId == 10)
                        strHtml += dt.Rows[i]["SchoolCode"].ToString();
                    strHtml += dt.Rows[i]["SchoolName"].ToString() + "</td>";

                    if (StudentProvinceId == 10)
                        strHtml += "  <td>" + dt.Rows[i]["AskDes"].ToString() + "</td>";
                    strHtml += "  <td class=\"tdbq\">" + DAL.Common.GetYuanXiaoTeSeJianHtml(dt.Rows[i]) + "</td>";
                    strHtml += "  <td>" + dt.Rows[i]["YuanXiaoLeiXing"].ToString() + "</td>";
                    strHtml += "  <td>" + dt.Rows[i]["ProvinceName"].ToString() + " " + dt.Rows[i]["CityName"].ToString() + "</td>";
                    strHtml += "  <td>" + dt.Rows[i]["BelongName"].ToString() + "</td>";
                    string strWuShuLianRanking = dt.Rows[i]["WuShuLianRanking"].ToString();
                    if (StudentProvinceId != 10)
                        strHtml += "  <td>" + (strWuShuLianRanking == "0" ? "-" : strWuShuLianRanking) + "</td>";
                    strHtml += "  <td><img src=\"/images/2015zntb/tuijian" + strBaoKaoTuiJian + ".png\" alt=\"\" /></td>";
                    strHtml += "<td><div class=\"gouxuan\"><input class=\"gx\" type=\"checkbox\" sid=\"" + dt.Rows[i]["SchoolId"].ToString() + "\"";
                    //判定是否已经在对比栏中了
                    string strDuiBiList = Basic.CookieHelper.GetCookie("tuijianschool");
                    if (strDuiBiList.Contains("," + dt.Rows[i]["SchoolId"].ToString() + ","))
                    {
                        strHtml += " checked=\"checked\" ";
                    }

                    strHtml += "><span>选报</span></div></td>";
                    strHtml += "</tr>\r\n";

                }
            }
            return strHtml;
        }


        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}