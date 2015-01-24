using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace GaoKao.SchoolLibrary
{
    /// <summary>
    /// getSchoolPage 的摘要说明
    /// </summary>
    public class getSchoolPage : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string strHtml = "";

            int intPageSize = 10;
            //当前页码
            int intCurrentPage = Basic.RequestHelper.GetFormInt("p", 1);


            //获取传递过来的参数  并 拼接筛选条件
            string strWhere = GetFormStringANDCondition();

            //总数据量
            int intDataAll = DAL.School.SchoolCount(strWhere);
            //总页码
            int intPageAll = 1;
            if (intDataAll > intPageSize)
            {
                intPageAll = intDataAll / intPageSize;
                if (intDataAll % intPageSize > 0)
                {
                    intPageAll++;
                }
            }

            strHtml += GetPage(intCurrentPage, intPageAll);//分页
            context.Response.Write(strHtml);
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

            string strWhere = " 1 = 1 ";
            if (schoolname != "")
            {
                strWhere += "AND SchoolName like '%" + schoolname + "%'";
            }

            strWhere += GetConditionTeSeHtml(tese);//院校特色

            strWhere += GetCondition(cengci, "SchoolCengCi");//院校层次
            strWhere += GetCondition(xingzhi, "SchoolNature");//院校性质
            strWhere += GetCondition(belong, "Belong");//院校隶属
            strWhere += GetCondition(leixing, "YuanXiaoLeiXingId");//院校类型
            strWhere += GetCondition(province, "ProvinceId");//省份


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
                        strWhere += " OR Is211 = 1";
                        break;
                    case "2"://985
                        strWhere += " OR Is985 = 1";
                        break;
                    case "3"://研究生院
                        strWhere += " OR IsGraduateSchool = 1";
                        break;
                    case "4"://自主招生
                        strWhere += " OR IsIndependentRecruitment = 1";
                        break;
                    case "5"://国防生
                        strWhere += " OR IsNationalDefense = 1";
                        break;
                    case "6"://农村专项
                        strWhere += " OR IsRuralSpecial = 1";
                        break;
                    case "7"://小211
                        strWhere += " OR IsMiNi211 = 1";
                        break;
                    case "8"://卓越工程
                        strWhere += " OR IsExcellent = 1";
                        break;
                    case "9"://艺术生
                        strWhere += " OR IsArtSpecialty = 1";
                        break;
                    case "10"://高水平运动员
                        strWhere += " OR IsHighLevelAthletes = 1";
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

        /*分页html代码*/
        string GetPage(int intCurrentPage, int intPageAll)
        {
            string strPageHtml = "";
            //上一页
            if (intCurrentPage > 1)
            {
                strPageHtml += "<a href=\"javascript:getSchoolList(" + (intCurrentPage - 1) + ");\" class=\"pageprev\" onclick=\"javascript:location='#header_5';\">上一页</a>";
            }
            else
            {
                strPageHtml += "<a href=\"javascript:void(0);\" class=\"pageprev\">上一页</a>";
            }
            //中间页面
            if (intPageAll <= 10)
            {
                for (int i = 0; i < intPageAll; i++)
                {
                    if (intCurrentPage == i + 1)
                    {
                        strPageHtml += "<a href=\"javascript:void(0);\" class=\"pagecur\">" + (i + 1) + "</a>";
                    }
                    else
                    {
                        strPageHtml += "<a href=\"javascript:getSchoolList(" + (i + 1) + ");\" onclick=\"javascript:location='#header_5';\">" + (i + 1) + "</a>";
                    }
                }
            }
            else
            {
                //后边有省略点
                if (intCurrentPage <= 5)
                {
                    if (intCurrentPage == 5)
                    {
                        strPageHtml += "<a href=\"javascript:getSchoolList(" + 1 + ");\" onclick=\"javascript:location='#header_5';\">" + 1 + "</a>";
                        strPageHtml += "<a href=\"javascript:getSchoolList(" + 2 + ");\" onclick=\"javascript:location='#header_5';\">" + 2 + "</a>";
                        strPageHtml += "<a href=\"javascript:void(0);\" class=\"pagemid\">...</a>";
                        strPageHtml += "<a href=\"javascript:getSchoolList(" + 4 + ");\" onclick=\"javascript:location='#header_5';\">" + 4 + "</a>";
                        strPageHtml += "<a href=\"javascript:void(0);\" class=\"pagecur\">" + 5 + "</a>";
                        strPageHtml += "<a href=\"javascript:getSchoolList(" + 6 + ");\" onclick=\"javascript:location='#header_5';\">" + 6 + "</a>";
                    }
                    else
                    {
                        for (int i = 0; i < 5; i++)
                        {
                            if (intCurrentPage == i + 1)
                            {
                                strPageHtml += "<a href=\"javascript:void(0);\" class=\"pagecur\">" + (i + 1) + "</a>";
                            }
                            else
                            {
                                strPageHtml += "<a href=\"javascript:getSchoolList(" + (i + 1) + ");\" onclick=\"javascript:location='#header_5';\">" + (i + 1) + "</a>";
                            }
                        }
                    }
                    strPageHtml += "<a href=\"javascript:void(0);\" class=\"pagemid\">...</a>";
                    strPageHtml += "<a href=\"javascript:getSchoolList(" + (intPageAll - 1) + ");\" onclick=\"javascript:location='#header_5';\">" + (intPageAll - 1) + "</a>";
                    strPageHtml += "<a href=\"javascript:getSchoolList(" + intPageAll + ");\" onclick=\"javascript:location='#header_5';\">" + intPageAll + "</a>";
                }
                //前边有省略点
                else if (intCurrentPage >= intPageAll - 4)
                {
                    strPageHtml += "<a href=\"javascript:getSchoolList(" + 1 + ");\" onclick=\"javascript:location='#header_5';\">" + 1 + "</a>";
                    strPageHtml += "<a href=\"javascript:getSchoolList(" + 2 + ");\" onclick=\"javascript:location='#header_5';\">" + 2 + "</a>";
                    strPageHtml += "<a href=\"javascript:void(0);\" class=\"pagemid\">...</a>";

                    if (intCurrentPage == intPageAll - 4)
                    {
                        strPageHtml += "<a href=\"javascript:getSchoolList(" + (intCurrentPage - 1) + ");\" onclick=\"javascript:location='#header_5';\">" + (intCurrentPage - 1) + "</a>";
                        strPageHtml += "<a href=\"javascript:void(0);\" class=\"pagecur\">" + intCurrentPage + "</a>";
                        strPageHtml += "<a href=\"javascript:getSchoolList(" + (intCurrentPage + 1) + ");\" onclick=\"javascript:location='#header_5';\">" + (intCurrentPage + 1) + "</a>";
                        strPageHtml += "<a href=\"javascript:void(0);\" class=\"pagemid\">...</a>";
                        strPageHtml += "<a href=\"javascript:getSchoolList(" + (intPageAll - 1) + ");\" onclick=\"javascript:location='#header_5';\">" + (intPageAll - 1) + "</a>";
                        strPageHtml += "<a href=\"javascript:getSchoolList(" + intPageAll + ");\" onclick=\"javascript:location='#header_5';\">" + intPageAll + "</a>";
                    }
                    else
                    {
                        for (int i = intPageAll - 5; i < intPageAll; i++)
                        {
                            if (intCurrentPage == i + 1)
                            {
                                strPageHtml += "<a href=\"javascript:void(0);\" class=\"pagecur\">" + (i + 1) + "</a>";
                            }
                            else
                            {
                                strPageHtml += "<a href=\"javascript:getSchoolList(" + (i + 1) + ");\" onclick=\"javascript:location='#header_5';\">" + (i + 1) + "</a>";
                            }
                        }
                    }
                }
                //两边都有省略点
                else if (intCurrentPage > 5 && intCurrentPage <= intPageAll - 5)
                {

                    strPageHtml += "<a href=\"javascript:getSchoolList(" + 1 + ");\" onclick=\"javascript:location='#header_5';\">" + 1 + "</a>";
                    strPageHtml += "<a href=\"javascript:getSchoolList(" + 2 + ");\" onclick=\"javascript:location='#header_5';\">" + 2 + "</a>";
                    strPageHtml += "<a href=\"javascript:void(0);\" class=\"pagemid\">...</a>";

                    strPageHtml += "<a href=\"javascript:getSchoolList(" + (intCurrentPage - 1) + ");\" onclick=\"javascript:location='#header_5';\">" + (intCurrentPage - 1) + "</a>";
                    strPageHtml += "<a href=\"javascript:void(0);\"  class=\"pagecur\">" + intCurrentPage + "</a>";
                    strPageHtml += "<a href=\"javascript:getSchoolList(" + (intCurrentPage + 1) + ");\" onclick=\"javascript:location='#header_5';\">" + (intCurrentPage + 1) + "</a>";

                    strPageHtml += "<a href=\"javascript:void(0);\" class=\"pagemid\">...</a>";
                    strPageHtml += "<a href=\"javascript:getSchoolList(" + (intPageAll - 1) + ");\" onclick=\"javascript:location='#header_5';\">" + (intPageAll - 1) + "</a>";
                    strPageHtml += "<a href=\"javascript:getSchoolList(" + intPageAll + ");\" onclick=\"javascript:location='#header_5';\">" + intPageAll + "</a>";
                }
            }

            //下一页
            if (intCurrentPage < intPageAll)
            {
                strPageHtml += "<a href=\"javascript:getSchoolList(" + (intCurrentPage + 1) + ");\" class=\"pagenext\" onclick=\"javascript:location='#header_5';\">下一页</a>";
            }
            else
            {
                strPageHtml += "<a href=\"javascript:void(0);\" class=\"pagenext\">下一页</a>";
            }

            return strPageHtml;
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