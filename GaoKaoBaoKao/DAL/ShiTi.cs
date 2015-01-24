using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;

using Basic;
using Entity;
using System.Configuration;

namespace DAL
{
    public class ShiTi
    {
        private static string strCon = ConfigurationManager.ConnectionStrings["ShiTi_ConnectionString"].ConnectionString;
        public static int ShiJuanCount(string TablePre)
        {
            string strSql = "select count(*) from " + TablePre + "_exam_examination,edu_subject,edu_grade,area_province where subject_id = edu_subject.id and grade_id = edu_grade.id and province_id = area_province.id";
            return Basic.Utils.StrToInt(SqlDB.ExecuteScalar(strCon, CommandType.Text, strSql).ToString(), 0);

            //strSql = "select * from dl_exam_examination,edu_subject,edu_grade,area_province where subject_id = edu_subject.id and grade_id = edu_grade.id and province_id = area_province.id";
        }

        ///
        /// <summary>
        /// 获取前多少的值
        /// </summary>
        /// <param name="TopNumber">数量</param>
        /// <param name="PageSize">每页显示多少个</param>
        /// <param name="PageIndex">当前页码，最少为1</param>
        /// <returns>返回DataTable</returns>
        public static DataTable ShiJuanPageList(string strWhere, int PageSize, int PageIndex, string TablePre)
        {
            string strSql = "select * from " + TablePre + "_exam_examination,edu_subject,edu_grade,area_province where subject_id = edu_subject.id and grade_id = edu_grade.id and province_id = area_province.id  order by year desc";
            DataSet ds = new DataSet();
            ds = SqlDB.ExecuteDataset((PageIndex - 1) * PageSize, PageSize, new SqlConnection(strCon), CommandType.Text, strSql);
            if (ds.Tables.Count > 0)
            {
                return ds.Tables[0];
            }
            return new DataTable();
        }


        public static string ShiJuanNameGet(int ExamId, string TablePre)
        {
            DataTable dt = SqlDB.ExecuteDataset(new SqlConnection(strCon), CommandType.Text, "select " + TablePre + "_exam_examination.name from " + TablePre + "_exam_examination,edu_subject,edu_grade,area_province where subject_id = edu_subject.id and grade_id = edu_grade.id and province_id = area_province.id and " + TablePre + "_exam_examination.id= " + ExamId).Tables[0];
            if (dt != null)
                return dt.Rows[0][0].ToString();
            return "";
        }

        public static DataTable ShiJuanGet(int ExamId, string strTablePre)
        {
            return SqlDB.ExecuteDataset(new SqlConnection(strCon), CommandType.Text, "select * from " + strTablePre + "_exam_examination2question," + strTablePre + "_exam_question where exam_id = " + ExamId + " and " + strTablePre + "_exam_examination2question.question_id = " + strTablePre + "_exam_question.gid Order by q_index ASC").Tables[0];
        }


        public static DataTable SqlList(string strSql)
        {
            DataSet ds = new DataSet();
            ds = SqlDB.ExecuteDataset(CommandType.Text, strSql);
            if (ds.Tables.Count > 0)
            {
                return ds.Tables[0];
            }
            return new DataTable();
        }

    }
}