using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Collections;

namespace GaoKao.GaoKaoZhenTi
{
    public partial class tixing_feixuanze : Base
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
            intTypeId = Basic.RequestHelper.GetQueryInt("typeid", 0);
            Entity.edu_question_type info = DAL.edu_question_type.edu_question_typeEntityGet(intTypeId);
            if (info != null)
            {
                strTypeName = info.type_name;
            }
            else
            {
                ClientScript.RegisterStartupScript(GetType(), "", "<script>alert('不合法的访问');</script>");
                return;
            }
            Entity.edu_subject infosubject = DAL.edu_subject.edu_subjectEntityGet(intSubjectId);
            if (infosubject != null)
            {
                strSubjectName = infosubject.name;
            }
            else
            {
                ClientScript.RegisterStartupScript(GetType(), "", "<script>alert('不合法的访问');</script>");
                return;
            }
        }


        void Bind()
        {

            string strFirstWhere = " TiMuSuoYin.subject_id = " + intSubjectId + " AND edu_question_type.id = " + intTypeId;
            int intCount = DAL.tengxb.zhenti.fTiMuCount(strFirstWhere);

            if (intCount > 0)
            {

                string strWhere = " (";
                //随机选出十条数据
                string strList = Basic.StringHelper.GetList(intCount, 10);
                string[] arr = strList.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                for (int i = 0; i < arr.Length; i++)
                {
                    //拼接筛选条件
                    if (i == arr.Length - 1)
                    {
                        strWhere += " xuhao = " + arr[i];
                    }
                    else
                    {
                        strWhere += " xuhao = " + arr[i] + " OR ";
                    }
                }


                strWhere += " )";


                DataTable dt = DAL.tengxb.zhenti.fTiMuList(strFirstWhere, strWhere);

                strZuBie = DateTime.Now.ToString("yyyyMMddHHmmss");
                //保存这些产生的题目到数据库中
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    int intTiMuId = Basic.Utils.StrToInt(dt.Rows[i]["id"].ToString(), 0);
                    Entity.TiMuNeiRong infonr = DAL.TiMuNeiRong.TiMuNeiRongEntityGet(intTiMuId);
                    if (infonr == null)
                    {
                        //数据有问题呀！！！
                    }
                    //保存这些题目
                    Entity.student2tm infotm = new Entity.student2tm();
                    infotm.Answer = "";
                    infotm.RightAnswer = infonr.objective_answer;
                    infotm.Result = 0;
                    infotm.StudentId = intStudentId;
                    infotm.TiMuId = infonr.Id;
                    infotm.Type = 2;//1表示知识点；2表示题型
                    infotm.ZuBie = strZuBie;
                    infotm.sx = i + 1;

                    DAL.student2tm.student2tmAdd(infotm);

                }

                rpt_List.DataSource = dt;
                rpt_List.DataBind();
            }
            else
            {
            }
        }

    }
}