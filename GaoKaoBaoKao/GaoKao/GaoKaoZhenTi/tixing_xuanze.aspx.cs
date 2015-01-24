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
    public partial class tixing_xuanze : Base
    {
        protected int intSubjectId = 0;//科目
        protected string strSubjectName = "";

        protected int intTypeId = 0;//类型
        protected string strZuBie = "";

        protected string strDaTiKa = "";//答题卡

        protected int intStudentId = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            intStudentId = userinfo.StudentId;


            GetQueryString();
            strSubjectName = DAL.edu_subject.edu_subjectEntityGet(intSubjectId).name;

            Bind();
        }

        void GetQueryString()
        {
            intSubjectId = Basic.RequestHelper.GetQueryInt("subjectid", 0);
            intTypeId = Basic.RequestHelper.GetQueryInt("typeid", 0);

            switch (intSubjectId)
            {
                case 1:
                    if (!(intTypeId == 56))
                    {
                        ClientScript.RegisterStartupScript(GetType(), "", "<script>artDialog11('不合法的访问','','','1','index.aspx');</script>");
                        return;
                    }
                    break;
                case 2:
                    if (!(intTypeId == 27))
                    {
                        ClientScript.RegisterStartupScript(GetType(), "", "<script>artDialog11('不合法的访问','','','1','index.aspx');</script>");
                        return;
                    }
                    break;
                case 3:
                    if (!(intTypeId == 84))
                    {
                        ClientScript.RegisterStartupScript(GetType(), "", "<script>artDialog11('不合法的访问','','','1','index.aspx');</script>");
                        return;
                    }
                    break;
                case 4:
                    if (!(intTypeId == 42))
                    {
                        ClientScript.RegisterStartupScript(GetType(), "", "<script>artDialog11('不合法的访问','','','1','index.aspx');</script>");
                        return;
                    }
                    break;
                case 5:
                    if (!(intTypeId == 2))
                    {
                        ClientScript.RegisterStartupScript(GetType(), "", "<script>artDialog11('不合法的访问','','','1','index.aspx');</script>");
                        return;
                    }
                    break;
                case 6:
                    if (!(intTypeId == 22))
                    {
                        ClientScript.RegisterStartupScript(GetType(), "", "<script>artDialog11('不合法的访问','','','1','index.aspx');</script>");
                        return;
                    }
                    break;
                case 7:
                    if (!(intTypeId == 8))
                    {
                        ClientScript.RegisterStartupScript(GetType(), "", "<script>artDialog11('不合法的访问','','','1','index.aspx');</script>");
                        return;
                    }
                    break;
                case 8:
                    if (!(intTypeId == 15))
                    {
                        ClientScript.RegisterStartupScript(GetType(), "", "<script>artDialog11('不合法的访问','','','1','index.aspx');</script>");
                        return;
                    }
                    break;
                case 9:
                    if (!(intTypeId == 93))
                    {
                        ClientScript.RegisterStartupScript(GetType(), "", "<script>artDialog11('不合法的访问','','','1','index.aspx');</script>");
                        return;
                    }
                    break;
                default:
                    ClientScript.RegisterStartupScript(GetType(), "", "<script>artDialog11('不合法的访问','','','1','index.aspx');</script>");
                    return;
                    break;
            }
        }

        /// <summary>
        /// 答题卡号
        /// </summary>
        /// <param name="intCount"></param>
        void BindDaTiKaHao(int intCount)
        {

            int intLiCount = 0;
            if (intCount > 10)
            {
                intLiCount = 10;
            }
            else
            {
                intLiCount = intCount;
            }
            for (int i = 1; i <= intLiCount; i++)
            {
                strDaTiKa += "<li><a href=\"#shiti" + i + "\">" + i + "</a></li>";
            }
        }

        /// <summary>
        /// 绑定数据
        /// </summary>
        void Bind()
        {
            string strFirstWhere = " TiMuSuoYin.subject_id = " + intSubjectId + " AND edu_question_type.id = " + intTypeId;
            int intCount = DAL.tengxb.zhenti.TiMuCount(strFirstWhere);

            if (intCount > 0)
            {
                string strWhere = " (";
                //随机选出十条数据
                string strList = Basic.StringHelper.GetList(intCount, 10);
                string[] arr = strList.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

                //答题卡号
                BindDaTiKaHao(arr.Length);

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



                DataTable dt = DAL.tengxb.zhenti.TiMuList(strFirstWhere, strWhere);

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
        }

    }
}