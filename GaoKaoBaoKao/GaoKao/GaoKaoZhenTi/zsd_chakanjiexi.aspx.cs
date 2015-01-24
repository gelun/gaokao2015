using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace GaoKao.GaoKaoZhenTi
{
    public partial class zsd_chakanjiexi : Base
    {
        protected int intSubjectId = 0;//科目
        protected string strSubjectName = "";

        protected int intTypeId = 0;//类型
        protected string strTypeName = "";
        protected string strZuBie = "";
        protected int intStudentId = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            intStudentId = userinfo.StudentId;
            GetQueryString();

            Bind();
        }

        void GetQueryString()
        {
            intSubjectId = Basic.RequestHelper.GetQueryInt("subjectid", 0);
            intTypeId = Basic.RequestHelper.GetQueryInt("zsdid", 0);
            strZuBie = Basic.RequestHelper.GetQueryString("zubie");

            Entity.zhishidian info = DAL.zhishidian.zhishidianEntityGet(intTypeId);
            if (info == null)
            {
                ClientScript.RegisterStartupScript(GetType(), "", "<script>artDialog11('不合法的访问');</script>");
                return;
            }
            else
            {
                strTypeName = info.name;
            }
            Entity.edu_subject infosubject = DAL.edu_subject.edu_subjectEntityGet(intSubjectId);
            if (infosubject != null)
            {
                strSubjectName = infosubject.name;
            }
            else
            {
                ClientScript.RegisterStartupScript(GetType(), "", "<script>artDialog11('不合法的访问');</script>");
                return;
            }
        }

        void Bind()
        {
            DataTable dt = DAL.student2tm.student2tmList("ZuBie = '" + strZuBie + "'");

            DataTable dtList = DAL.tengxb.zhenti.TiMuList("", GetCondition(dt));
            rpt_List.DataSource = dtList;
            rpt_List.DataBind();
        }

        string GetCondition(DataTable dt)
        {
            string strCondition = "";
            if (dt != null && dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (i == dt.Rows.Count - 1)
                    {
                        strCondition += " id = " + dt.Rows[i]["TiMuId"].ToString();
                    }
                    else
                    {
                        strCondition += " id = " + dt.Rows[i]["TiMuId"].ToString() + " OR";
                    }
                }
            }
            return strCondition;
        }

        protected string GetResult(object obId)
        {
            //<span class="one">回答正确</span><i><img src="images/icon_gou2.jpg"
            //                               width="24" height="21" />

            string strResult = "";

            DataTable dt = DAL.student2tm.student2tmList("StudentId = " + intStudentId + " and ZuBie = '" + strZuBie + "' AND TiMuId = " + obId);
            if (dt != null && dt.Rows.Count > 0)
            {
                switch (dt.Rows[0]["Result"].ToString())
                {
                    case "1":
                        strResult="<span class=\"one\">回答正确</span><i><img src=\"images/icon_gou2.jpg\" width=\"24\" height=\"21\" /></i>";
                        break;
                    case "2":
                        strResult = "<span class=\"two\">回答错误</span><i><img src=\"images/icon_cha2.jpg\" width=\"24\" height=\"21\" /></i>";
                        break;
                    default:
                        break;
                }
            }

            return strResult;
        }
    }
}