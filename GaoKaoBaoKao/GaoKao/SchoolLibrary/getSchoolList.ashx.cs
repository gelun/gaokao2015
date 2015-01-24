using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace GaoKao.SchoolLibrary
{
    /// <summary>
    /// getSchoolList 的摘要说明
    /// </summary>
    public class getSchoolList : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";


            //基础html
            string strHtml = GetBaseHtml();

            int intPageSize = 10;
            int intDataCount = 10;
            //当前页码
            int intCurrentPage = Basic.RequestHelper.GetFormInt("p", 1);
            intDataCount = intCurrentPage * intPageSize;

            //获取传递过来的参数  并 拼接筛选条件
            string strWhere = GetFormStringANDCondition();


            DataTable dt = DAL.TengXB.School.YxkSchoolDt(intPageSize, intDataCount, strWhere);

            strHtml += GetSchoolHtml(dt);//院校相关html

            //  strHtml += "</table>";
            //  strHtml += GetPage(intCurrentPage, intPageAll);//分页

            context.Response.Write(strHtml);
        }
        /*基础html*/
        string GetBaseHtml()
        {
            string strHtml = "";
            //  strHtml += "<table width=\"915\" border=\"1\">";
            strHtml += "<tr>";
            strHtml += "<th width=\"42\">序号</th>";
            strHtml += "<th>院校名称</th>";
            strHtml += "<th>所在地</th>";
            strHtml += "<th width=\"65\">属性</th>";
            strHtml += "<th><a class=\"demo-follow-cursor\" title=\"我国高校主管部门,可以分为国家教委所属院校、中央各部委所属院校和各省、市属地方院校...<a target='_blank' href='http://gaokao.gelunjiaoyu.com/yxgxzg.shtml' style='color: #1d8cff;text-decoration: underline;'>更多</a>\" style=\"text-decoration: none;color: #000;\">主管部门</a></th>";
            strHtml += "<th width=\"320\">院校特色</th>";
            strHtml += "<th width=\"110\">加入对比</th>";
            strHtml += "</tr>";

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



        /*院校相关信息生成的html代码*/
        string GetSchoolHtml(DataTable dt)
        {
            string strHtml = "";
            if (dt != null && dt.Rows.Count > 0)
            {
                for (int i = dt.Rows.Count - 1; i >= 0; i--)
                {
                    strHtml += "<tr>";
                    strHtml += "<td>" + (dt.Rows.Count - i) + "</td>";
                    strHtml += "<td><a target=\"_blank\" href=\"/daxue-jianjie-" + dt.Rows[i]["Id"].ToString() + ".shtml\" title=\"" + dt.Rows[i]["SchoolName"].ToString() + "\">" + dt.Rows[i]["SchoolName"].ToString() + "</a></td>";
                    strHtml += "<td>" + dt.Rows[i]["ProvinceName"].ToString() + dt.Rows[i]["CityName"].ToString() + "</td>";
                    strHtml += "<td>" + dt.Rows[i]["YuanXiaoLeiXing"].ToString() + "</td>";
                    strHtml += "<td>" + dt.Rows[i]["BelongName"].ToString() + "</td>";
                    strHtml += "<td class=\"tdbq\">" + GetTeSe(dt.Rows[i]) + "</td>";
                    strHtml += "<td><div class=\"gouxuan\"><input class=\"gx\" type=\"checkbox\" sid=" + dt.Rows[i]["Id"].ToString();
                    //判定是否已经在对比栏中了
                    string strDuiBiList = Basic.CookieHelper.GetCookie("duibischool");
                    if (strDuiBiList.Contains("," + dt.Rows[i]["Id"].ToString() + ","))
                    {
                        strHtml += " checked=\"checked\" ";
                    }

                    strHtml += "><span>对比</span></div></td>";
                    strHtml += "</tr>";
                }
            }
            return strHtml;
        }

        /*院校特色相关html代码*/
        string GetTeSe(DataRow dr)
        {
            string strTeSe = "";

            //211
            if (dr["Is211"].ToString() == "1")
            {
                strTeSe += "<a href=\"javascript:void(0);\" class=\"demo-follow-cursor\" title=\"211院校，即面向21世纪，在全国范围内重点建设100所左右的高等学校和一批重点学科，简称“211”...<a target='_blank' href='http://gaokao.gelunjiaoyu.com/yx211.shtml' style='color: #1d8cff;text-decoration: underline;'>更多</a>\">211</a>";
            }
            //Is985
            if (dr["Is985"].ToString() == "1")
            {
                strTeSe += "<a href=\"javascript:void(0);\" class=\"demo-follow-cursor\" title=\"985院校是我国政府为建设若干所世界一流大学和一批国际知名的高水平研究型大学而实施的高等教育建设工程...<a target='_blank' href='http://gaokao.gelunjiaoyu.com/yx985.shtml' style='color: #1d8cff;text-decoration: underline;'>更多</a>\">985</a>";
            }
            //研究生院
            if (dr["IsGraduateSchool"].ToString() == "1")
            {
                strTeSe += "<a href=\"javascript:void(0);\" class=\"demo-follow-cursor\" title=\"研究生院是指在承担研究生培养任务的单位中，负责组织实施研究生教育工作的内设部门；②专门承担研究生培养任务的独立机构...<a target='_blank' href='http://gaokao.gelunjiaoyu.com/yxyjs.shtml' style='color: #1d8cff;text-decoration: underline;'>更多</a>\">研</a>";
            }
            //自主招生
            if (dr["IsIndependentRecruitment"].ToString() == "1")
            {
                strTeSe += "<a href=\"javascript:void(0);\" class=\"demo-follow-cursor\" title=\"自主招生指符合条件的应届高中毕业生，由本人提出申请，经所在中学和自主招生学校评审后确定名额，高考以后最终确定是否录取...<a target='_blank' href='http://gaokao.gelunjiaoyu.com/yxzzzs.shtml' style='color: #1d8cff;text-decoration: underline;'>更多</a>\">自</a>";
            }
            //国防生
            if (dr["IsNationalDefense"].ToString() == "1")
            {
                strTeSe += "<a href=\"javascript:void(0);\" class=\"demo-follow-cursor\" title=\"国防生是指根据部队建设需要，由军队（武警部队）从应届高中毕业生中招收的和从在校大学生中选拔培养的后备军（警）官...<a target='_blank' href='http://gaokao.gelunjiaoyu.com/yxgfs.shtml' style='color: #1d8cff;text-decoration: underline;'>更多</a>\">国</a>";
            }
            //小211
            if (dr["IsMiNi211"].ToString() == "1")
            {
                strTeSe += "<a href=\"javascript:void(0);\" class=\"demo-follow-cursor\" title=\"小211工程是为振兴中西部高等教育，计划重点支持建设中西部高校的发展建设...<a target='_blank' href='http://gaokao.gelunjiaoyu.com/yxx211.shtml' style='color: #1d8cff;text-decoration: underline;'>更多</a>\">小211</a>";
            }
            //农村专项
            if (dr["IsRuralSpecial"].ToString() == "1")
            {
                strTeSe += "<a href=\"javascript:void(0);\" class=\"demo-follow-cursor\" title=\"农村专项是一项新的普通高校招生政策，又称贫困地区定向招生专项计划...<a target='_blank' href='http://gaokao.gelunjiaoyu.com/yxnczx.shtml' style='color: #1d8cff;text-decoration: underline;'>更多</a>\">农</a>";
            }
            //艺术生
            if (dr["IsArtSpecialty"].ToString() == "1")
            {
                strTeSe += "<a href=\"javascript:void(0);\" class=\"demo-follow-cursor\" title=\"艺术生是按照所学习的专业特点划分的部分学生人群...<a target='_blank' href='http://gaokao.gelunjiaoyu.com/yxyss.shtml' style='color: #1d8cff;text-decoration: underline;'>更多</a>\">艺</a>";
            }
            //高水平运动员
            if (dr["IsHighLevelAthletes"].ToString() == "1")
            {
                strTeSe += "<a href=\"javascript:void(0);\" class=\"demo-follow-cursor\" title=\"参加高水平运动员测试的考生应参加其户口所在地省级高校招生委员会办公室（以下简称省级招办）统一组织的高考报名...<a target='_blank' href='http://gaokao.gelunjiaoyu.com/yxydy.shtml' style='color: #1d8cff;text-decoration: underline;'>更多</a>\">体</a>";
            }
            //卓越工程
            if (dr["IsExcellent"].ToString() == "1")
            {
                strTeSe += "<a href=\"javascript:void(0);\" class=\"demo-follow-cursor\" title=\"卓越计划是贯彻落实《国家中长期教育改革和发展规划纲要》和《国家中长期人才发展规划纲要》的重大改革项目...<a target='_blank' href='http://gaokao.gelunjiaoyu.com/yxzyjh.shtml' style='color: #1d8cff;text-decoration: underline;'>更多</a>\">卓</a>";
            }

            return strTeSe;
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