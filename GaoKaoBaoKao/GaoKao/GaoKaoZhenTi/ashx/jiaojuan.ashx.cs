using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Data;

namespace GaoKao.GaoKaoZhenTi.ashx
{
    /// <summary>
    /// jiaojuan1 的摘要说明
    /// </summary>
    public class jiaojuan : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";

            string strMsg = "error";
            string strData = Basic.RequestHelper.GetFormString("yjl");
            string strZuBie = Basic.RequestHelper.GetFormString("zubie");
            int intStudentId = Basic.RequestHelper.GetFormInt("studentid", 0);


            if (strData != "")
            {
                string[] arr = strData.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                if (arr.Length > 0)
                {
                    for (int i = 0; i < arr.Length; i++)
                    {
                        string[] arr2 = arr[i].Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries);
                        if (arr2.Length == 2)
                        {
                            int intId = Basic.Utils.StrToInt(arr2[0], 0);
                            //判断对错
                            Entity.TiMuNeiRong infonr = DAL.TiMuNeiRong.TiMuNeiRongEntityGet(intId);
                            if (infonr != null)
                            {
                                //判断对错
                                int intResult = 2;
                                if (infonr.objective_answer.Trim() == arr2[1])
                                {
                                    intResult = 1;
                                }

                                //更改题目组中该题对应的答题结果
                                DataTable dt = DAL.student2tm.student2tmList(" ZuBie = '" + strZuBie + "' AND StudentId = " + intStudentId + " AND TiMuId = " + arr2[0]);
                                if (dt != null && dt.Rows.Count > 0)
                                {
                                    Entity.student2tm infotm = DAL.student2tm.student2tmEntityGet(Basic.Utils.StrToInt(dt.Rows[0]["id"].ToString(), 0));
                                    infotm.Result = intResult;
                                    infotm.Answer = arr2[1];
                                    DAL.student2tm.student2tmEdit(infotm);
                                }


                                //如果错题本中没有该题目，添加该题目
                                DataTable dtcuoti = DAL.cuotiben.cuotibenList("TiMuId = " + intId + " and Wid = " + intStudentId);
                                if (dtcuoti == null || dtcuoti.Rows.Count == 0)
                                {
                                    //添加
                                    Entity.cuotiben infost = new Entity.cuotiben();
                                    infost.TiMuId = intId;
                                    infost.Wid = intStudentId;
                                    infost.Answer = arr2[1];
                                    infost.RightAnswer = infonr.objective_answer;

                                    if (DAL.cuotiben.cuotibenAdd(infost) > 0)
                                        strMsg = "success";
                                }
                                else
                                {
                                    //删除
                                    DAL.cuotiben.cuotibenDel(Basic.Utils.StrToInt(dtcuoti.Rows[0]["id"].ToString(),0));
                                    //添加
                                    Entity.cuotiben infost = new Entity.cuotiben();
                                    infost.TiMuId = intId;
                                    infost.Wid = intStudentId;
                                    infost.Answer = arr2[1];
                                    infost.RightAnswer = infonr.objective_answer;

                                    if (DAL.cuotiben.cuotibenAdd(infost) > 0)
                                        strMsg = "success";
                                }
                            }
                        }
                    }
                }
            }

            context.Response.Write(strMsg);
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