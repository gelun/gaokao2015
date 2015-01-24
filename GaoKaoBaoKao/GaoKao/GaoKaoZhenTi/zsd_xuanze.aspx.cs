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
    public partial class zsd_xuanze : Base
    {
        protected int intSubjectId = 0;//科目
        protected string strSubjectName = "";

        protected int intZsdId = 0;//类型
        protected int intTypeId = 0;//类型
        protected string strTypeName = "";

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
            intZsdId = Basic.RequestHelper.GetQueryInt("zsdid", 0);

            switch (intSubjectId)
            {
                case 1:
                    intTypeId = 56;
                    break;
                case 2:
                    intTypeId = 27;
                    break;
                case 3:
                    intTypeId = 63;//英语的选择题 没有题目，所以用到的是 单项填空（其实也是选择题）
                    break;
                case 4:
                    intTypeId = 42;
                    break;
                case 5:
                    intTypeId = 2;
                    break;
                case 6:
                    intTypeId = 22;
                    break;
                case 7:
                    intTypeId = 8;
                    break;
                case 8:
                    intTypeId = 15;
                    break;
                case 9:
                    intTypeId = 93;
                    break;
                default:

                    ClientScript.RegisterStartupScript(GetType(), "", "<script>artDialog11('不合法的访问','','','1','index.aspx');</script>");

                    return;
                    break;
            }


            Entity.zhishidian info = DAL.zhishidian.zhishidianEntityGet(intZsdId);
            if (info != null)
            {
                strTypeName = info.name;
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
            //Basic.MsgHelper.AlertBackMsg(intLiCount+"   "+intCount);
        }

        /// <summary>
        /// 绑定数据
        /// </summary>
        void Bind()
        {
            string strFirstWhere = " TiMuSuoYin.subject_id = " + intSubjectId + " AND edu_question_type.id = " + intTypeId + " AND zhishidian.Id = " + intZsdId;
            int intCount = DAL.tengxb.zhenti.zsdTiMuCount(strFirstWhere);

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



                DataTable dt = DAL.tengxb.zhenti.zsdTiMuList(strFirstWhere, strWhere);

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


        #region 随机获取10个不重复的数字

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="intCount"></param>
        ///// <param name="strList"></param>
        ///// <returns></returns>
        //string List_mmm(int intCount, List<int> listAr)
        //{
        //    if (listAr == null)
        //    {
        //        listAr = new List<int>();
        //    }


        //    Random rnd = new Random();


        //    for (int i = 0; i < 10; i++)
        //    {
        //        int n = rnd.Next(1, intCount);
        //        listAr.Add(cd(intCount, n, listAr));
        //    }


        //    if (listAr.Count >= 10)
        //    {
        //        string str = "";

        //        foreach (int i in listAr)
        //        {
        //            str += i + ",";
        //        }

        //        return str;
        //    }

        //    return string.Empty;

        //}

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="num"></param>
        ///// <param name="n"></param>
        ///// <param name="ar"></param>
        ///// <returns></returns>
        //int cd(int num, int n, List<int> ar)
        //{
        //    for (int i = 0; i < ar.Count; i++)
        //    {
        //        if (n == ar[i])
        //        {
        //            Random rnd = new Random();
        //            int current = rnd.Next(1, num);
        //            return cd(num, current, ar);

        //        }
        //    }

        //    return n;

        //}

        #endregion




        /// <summary>
        /// 
        /// </summary>
        /// <param name="intCount"></param>
        /// <param name="strList"></param>
        /// <returns></returns>
        string List(int intCount, string strList)
        {
            string[] str = strList.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

            Random rnd = new Random();
            int n = rnd.Next(1, intCount);


            if (IsExcit(str, n) == true)
            {
                List(intCount, strList);
            }
            else
            {
                strList += n + ",";
            }

            str = strList.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            if (Count(str) == false)
            {
                List(intCount, strList);
            }

            return strList;




        }



        /// <summary>
        /// 计算个数
        /// </summary>
        /// <param name="str1"></param>
        /// <returns></returns>
        bool Count(string[] str)
        {
            if (str.Length >= 10)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 判断在字符串中，是否包含某个整数
        /// </summary>
        /// <param name="str1"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        bool IsExcit(string[] str, int n)
        {
            bool hasFlag = false;
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == n.ToString())
                {
                    hasFlag = true;
                }
            }

            return hasFlag;
        }
    }
}