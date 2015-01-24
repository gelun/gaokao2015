using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace GaoKao.ashx
{
    /// <summary>
    /// fszydb 的摘要说明
    /// </summary>
    public class fszydb : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";

            string strHtml = "";

            int cxbl = Basic.RequestHelper.GetQueryInt("cxbl", -1);
            int sfid = Basic.RequestHelper.GetQueryInt("sfid", -1);
            int lqcc = Basic.RequestHelper.GetQueryInt("lqcc", -1);
            int lqpc = Basic.RequestHelper.GetQueryInt("lqpc", -1);
            int kl = Basic.RequestHelper.GetQueryInt("kl", -1);


            string strSidList = Basic.RequestHelper.GetQueryString("sidlist");
            int studentProvinceId = Basic.RequestHelper.GetQueryInt("sfid", 0);


            string[] strArray = strSidList.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            int[] tdindex = new int[strArray.Length];
            int[] schoollist = new int[strArray.Length];
            int[] zhuanyelist = new int[strArray.Length];
            for (int i = 0; i < strArray.Length; i++)
            {
                string[] arr = strArray[i].Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries);
                if (arr.Length == 3)
                {
                    tdindex[i] = Basic.TypeConverter.StrToInt(arr[0], 0);
                    schoollist[i] = Basic.TypeConverter.StrToInt(arr[1], 0);
                    zhuanyelist[i] = Basic.TypeConverter.StrToInt(arr[2], 0);
                }
            }

            DataTable dtPic = new DataTable();
            DataColumn dc = null;
            dc = dtPic.Columns.Add("DataYear", Type.GetType("System.Int32"));
            dc.AutoIncrement = true;//自动增加
            dc.AutoIncrementSeed = 1;//起始为1
            dc.AutoIncrementStep = 1;//步长为1
            dc.AllowDBNull = false;//

            dc = dtPic.Columns.Add("Professional1", Type.GetType("System.Int32"));
            dc = dtPic.Columns.Add("Professional2", Type.GetType("System.Int32"));
            dc = dtPic.Columns.Add("Professional3", Type.GetType("System.Int32"));
            dc = dtPic.Columns.Add("Professional4", Type.GetType("System.Int32"));
            dc = dtPic.Columns.Add("Professional5", Type.GetType("System.Int32"));

            DataRow newRow;



            Entity.ProvinceConfig provinceConfig = DAL.ProvinceConfig.ProvinceConfigEntityGet(studentProvinceId);
            DataTable dtFen = new DataTable();
            string strSchoolNameList = "";
            for (int i = provinceConfig.LatestBenKeYear; i >= 2010; i--)
            {
                newRow = dtPic.NewRow();
                newRow["DataYear"] = i;

                strHtml += "<tr><td>" + i + "</td>";
                for (int j = 1; j <= 5; j++)//循环获取5个td
                {
                    bool b = false;
                    for (int n = 0; n < tdindex.Length; n++)
                    {
                        if (j == tdindex[n])
                        {
                            b = true;
                            string strWhere = "A.ProvinceId=" + studentProvinceId + " and A.DataYear=" + i + " and A.SchoolId = " + schoollist[n] + " and A.ZyId = " + zhuanyelist[n];
                            DataTable dt = DAL.FenShengZhuanYeLuQu.FenShengZhuanYeLuQuWithSchoolList(strWhere,studentProvinceId, "All");//i.ToString()
                            if (dt != null && dt.Rows.Count > 0)
                            {
                                switch (cxbl)
                                {
                                    case 0://提档分
                                        strHtml += "<td>" + dt.Rows[0]["ZyZuiDiFen"].ToString() + "</td>";
                                        newRow["Professional" + j + ""] = dt.Rows[0]["ZyZuiDiFen"].ToString();
                                        break;
                                    case 1://平均分
                                        strHtml += "<td>" + dt.Rows[0]["ZyPingJunFen"].ToString() + "</td>";
                                        newRow["Professional" + j + ""] = dt.Rows[0]["ZyPingJunFen"].ToString();
                                        break;
                                    case 2://批次线差
                                        strHtml += "<td>" + dt.Rows[0]["ZyPingJunXianCha"].ToString() + "</td>";
                                        newRow["Professional" + j + ""] = dt.Rows[0]["ZyPingJunXianCha"].ToString();
                                        break;
                                    default:
                                        strHtml += "<td>0</td>";
                                        newRow["Professional" + j + ""] = "0";
                                        break;
                                }

                                strSchoolNameList += dt.Rows[0]["YuanXiaoMingCheng"].ToString() + "<br />" + dt.Rows[0]["ZhuanYeMingCheng"].ToString() + "|";
                            }
                            else
                            {
                                //不存在数据，那就是0了
                                strHtml += "<td>0</td>";
                                newRow["Professional" + j + ""] = "0";

                                strSchoolNameList += "未选择|";
                            }
                        }
                    }
                    if (b == false)
                    {
                        //不存在院校，那就是0了
                        strHtml += "<td>0</td>";
                        newRow["Professional" + j + ""] = "0";
                        strSchoolNameList += "未选择|";
                    }
                }
                strHtml += "</tr>";
                dtPic.Rows.Add(newRow);

            }

            strHtml += Basic.HighCharts.CreatHighChartsFromDT("duibitupian", "spline", "", "分数", strSchoolNameList, dtPic); ;
            context.Response.Write(strHtml);
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