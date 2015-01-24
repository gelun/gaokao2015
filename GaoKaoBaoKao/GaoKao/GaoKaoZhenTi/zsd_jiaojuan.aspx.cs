using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace GaoKao.GaoKaoZhenTi
{
    public partial class zsd_jiaojuan : Base
    {
        protected int intSubjectId = 0;//科目
        protected string strSubjectName = "";

        protected int intTypeId = 0;//类型
        protected string strTypeName = "";
        protected string strZuBie = "";
        protected int intStudentId = 0;

        protected int intRightCount = 0;
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
            DataTable dt = DAL.student2tm.student2tmList("ZuBie = '" + strZuBie + "' AND StudentId = " + intStudentId);
            if (dt != null && dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    switch (dt.Rows[i]["Result"].ToString())
                    {
                        case "1":
                            ltlLi.Text += "<li class=\"green\">" + (i + 1) + "</li>";

                            intRightCount++;
                            break;
                        case "2":
                            ltlLi.Text += "<li class=\"red\">" + (i + 1) + "</li>";
                            break;
                        default:
                            ltlLi.Text += "<li>" + i + "</li>";
                            break;
                    }
                }
            }
        }

        //<li class="green">1</li>
        //                   <li>2</li>
        //                   <li class="red">3</li>
        //                   <li class="green">4</li>
        //                   <li class="green">5</li>
        //                   <li class="red">6</li>
        //                   <li class="red">7</li>
        //                   <li class="green">8</li>
        //                   <li class="green">9</li>
        //                   <li>10</li>
    }
}