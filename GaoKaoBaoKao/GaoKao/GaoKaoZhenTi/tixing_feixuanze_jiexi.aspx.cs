using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace GaoKao.GaoKaoZhenTi
{
    public partial class tixing_feixuanze_jiexi : Base
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
            strZuBie = Basic.RequestHelper.GetQueryString("zubie");
            intSubjectId = Basic.RequestHelper.GetQueryInt("subjectid", 0);
            intTypeId = Basic.RequestHelper.GetQueryInt("typeid", 0);

            Entity.edu_question_type info = DAL.edu_question_type.edu_question_typeEntityGet(intTypeId);
            if (info != null)
            {
                strTypeName = info.type_name;
            }
            else
            {
                ClientScript.RegisterStartupScript(GetType(), "", "<script>artDialog11('不合法的访问');</script>");
                return;
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

            DataTable dtList = DAL.tengxb.zhenti.fTiMuList("", GetCondition(dt));
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="intCount"></param>
        /// <param name="strList"></param>
        /// <returns></returns>
        string List_mmm(int intCount, List<int> listAr)
        {
            if (listAr == null)
            {
                listAr = new List<int>();
            }


            Random rnd = new Random();


            for (int i = 0; i < 10; i++)
            {
                int n = rnd.Next(1, intCount);
                listAr.Add(cd(intCount, n, listAr));
            }


            if (listAr.Count >= 10)
            {
                string str = "";

                foreach (int i in listAr)
                {
                    str += i + ",";
                }

                return str;
            }

            return string.Empty;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="num"></param>
        /// <param name="n"></param>
        /// <param name="ar"></param>
        /// <returns></returns>
        int cd(int num, int n, List<int> ar)
        {
            for (int i = 0; i < ar.Count; i++)
            {
                if (n == ar[i])
                {
                    Random rnd = new Random();
                    int current = rnd.Next(1, num);
                    return cd(num, current, ar);

                }
            }

            return n;

        }


    }
}