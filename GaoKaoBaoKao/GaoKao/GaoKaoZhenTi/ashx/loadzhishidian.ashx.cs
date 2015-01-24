using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace GaoKao.GaoKaoZhenTi.ashx
{
    /// <summary>
    /// loadzhishidian 的摘要说明
    /// </summary>
    public class loadzhishidian : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";

            string strHtml = "";


            int intKeMuId = Basic.RequestHelper.GetFormInt("kemu", 1);

            DataTable dt = null;
            dt = DAL.zhishidian.zhishidianList("subject_id = " + intKeMuId);
            if (dt != null && dt.Rows.Count > 0)
            {
                strHtml += "<ul>";

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    strHtml += "<li><a target=\"_blank\" href=\"zsd_xuanze.aspx?subjectid=" + intKeMuId + "&zsdid=" + dt.Rows[i]["id"].ToString() + "\">" + dt.Rows[i]["name"].ToString() + "</a></li>";
                }

                strHtml += "</ul>";
            }

            //题型
            dt = DAL.edu_question_type.edu_question_typeList(" id in (select edu_question_type.id from TiMuSuoYin ,TiMuNeiRong ,edu_question_type where TiMuSuoYin.gid = TiMuNeiRong.gid and edu_question_type.id = TiMuSuoYin.edu_question_type_Id and DataLength(TiMuNeiRong.content)>0 and TiMuSuoYin.subject_id = " + intKeMuId + " group by edu_question_type.id)");
            if (dt != null && dt.Rows.Count > 0)
            {
                strHtml += "|||<ul>";

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    strHtml += "<li><a target=\"_blank\" href=\"" + Link(intKeMuId, Basic.Utils.StrToInt(dt.Rows[i]["id"].ToString(), 0)) + "\">" + dt.Rows[i]["type_name"].ToString() + "</a></li>";
                }

                strHtml += "</ul>";
            }

            context.Response.Write(strHtml);
        }

        //链接地址
        string Link(int intSubjectId, int intTypeId)
        {
            string strLink = "";

            if (((intSubjectId == 1 && intTypeId == 56) || (intSubjectId == 2 && intTypeId == 27) || (intSubjectId == 3 && intTypeId == 63) ||
                (intSubjectId == 4 && intTypeId == 42) || (intSubjectId == 5 && intTypeId == 2) || (intSubjectId == 6 && intTypeId == 22) ||
                (intSubjectId == 7 && intTypeId == 8) || (intSubjectId == 8 && intTypeId == 15) || (intSubjectId == 9 && intTypeId == 93)))
            {
                strLink = "tixing_xuanze.aspx?subjectid=" + intSubjectId + "&typeid=" + intTypeId;
            }
            //else if (intTypeId == 0)
            //{
            //    strLink = "tixing_feixuanze.aspx?subjectid=" + intSubjectId + "&typeid=" + intTypeId;
            //}
            else
            {
                strLink = "tixing_feixuanze.aspx?subjectid=" + intSubjectId + "&typeid=" + intTypeId;
            }
            return strLink;
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