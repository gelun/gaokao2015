using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;

using Basic;
using Entity;
using System.Configuration;

namespace DAL
{
    public class edu_subject
    {
        private static string strCon = ConfigurationManager.ConnectionStrings["ShiTi_ConnectionString"].ConnectionString;

        #region  edu_subject
        /// <summary>
        /// 调用存储过程增加一个
        /// </summary>
        /// <param name="info">实体对象</param>
        /// <returns>正常返回大于 0 的自增id, 0代表重复，否则返回-1</returns>
        public static int edu_subjectAdd(Entity.edu_subject info)
        {
            SqlParameter[] prams = {
				SqlDB.MakeInParam("@name", SqlDbType.NVarChar, 64, info.name),
				SqlDB.MakeInParam("@subject_code", SqlDbType.Char, 2, info.subject_code),
				SqlDB.MakeInParam("@subject_index", SqlDbType.Int, 4, info.subject_index),
			};
            return Basic.Utils.StrToInt(SqlDB.ExecuteScalar(strCon, CommandType.StoredProcedure, "edu_subjectAdd", prams).ToString(), -1);
        }

        /// <summary>
        /// 调用存储过程修改一个
        /// </summary>
        /// <param name="info">实体对象</param>
        /// <returns>更新成功返回ture，否则返回false</returns>
        public static bool edu_subjectEdit(Entity.edu_subject info)
        {
            SqlParameter[] prams = {
				SqlDB.MakeInParam("@id", SqlDbType.Int, 4, info.id),
				SqlDB.MakeInParam("@name", SqlDbType.NVarChar, 64, info.name),
				SqlDB.MakeInParam("@subject_code", SqlDbType.Char, 2, info.subject_code),
				SqlDB.MakeInParam("@subject_index", SqlDbType.Int, 4, info.subject_index),
				};
            int intReturnValue = 0;
            intReturnValue = SqlDB.ExecuteNonQuery(strCon, CommandType.StoredProcedure, "edu_subjectEdit", prams);
            if (intReturnValue == 1)
                return true;
            return false;
        }

        /// <summary>
        /// 获取所有的的值
        /// </summary>
        /// <param name="strWhere">条件，可以为空</param>
        /// <returns>返回DataTable</returns>
        public static DataTable edu_subjectList(string strWhere)
        {
            string strSql;
            if (!string.IsNullOrEmpty(strWhere.Trim()))
                strSql = "SELECT * FROM [edu_subject] WHERE " + strWhere + ";";
            else
                strSql = "SELECT * FROM [edu_subject] ;";
            return SqlDB.ExecuteDataset(strCon, CommandType.Text, strSql).Tables[0];
        }


        /// <summary>
        /// 获取某一个DataTable
        /// </summary>
        /// <param name="id">标识</param>
        /// <returns>返回DataTable</returns>
        public static DataTable edu_subjectGet(int id)
        {
            return SqlDB.ExecuteDataset(strCon, CommandType.Text, "SELECT * FROM [edu_subject] WHERE id = " + id + ";").Tables[0];
        }

        /// <summary>
        /// 获取某一个实体
        /// </summary>
        /// <param name="id">标识</param>
        /// <returns>返回Entity</returns>
        public static Entity.edu_subject edu_subjectEntityGet(int id)
        {
            Entity.edu_subject info = new Entity.edu_subject();
            DataTable dt = SqlDB.ExecuteDataset(strCon, CommandType.Text, "SELECT * FROM [edu_subject] WHERE id = " + id + ";").Tables[0];
            if (dt.Rows.Count > 0)
            {
                info.id = Basic.Utils.StrToInt(dt.Rows[0]["id"].ToString(), 0);
                info.name = dt.Rows[0]["name"].ToString();
                info.subject_code = dt.Rows[0]["subject_code"].ToString();
                info.subject_index = Basic.Utils.StrToInt(dt.Rows[0]["subject_index"].ToString(), 0);
                return info;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 删除一个值
        /// </summary>
        /// <param name="id">自增id的值</param>
        /// <returns>删除成功返回ture，否则返回false</returns>
        public static bool edu_subjectDel(int id)
        {
            int intReturnValue = 0;
            intReturnValue = SqlDB.ExecuteNonQuery(strCon, CommandType.Text, "DELETE [edu_subject]  WHERE id =  " + id);
            if (intReturnValue == 1)
                return true;
            return false;
        }

        /// <summary>
        /// 获取前多少的值
        /// </summary>
        /// <param name="strWhere">条件，可以为空</param>
        /// <param name="TopNumber">数量</param>
        /// <returns>返回DataTable</returns>
        public static DataTable edu_subjectTopGet(string strWhere, int TopNumber)
        {
            string strSql;
            if (!string.IsNullOrEmpty(strWhere.Trim()))
                strSql = "SELECT TOP " + TopNumber.ToString() + " * FROM [edu_subject] WHERE " + strWhere + ";";
            else
                strSql = "SELECT TOP " + TopNumber.ToString() + " * FROM [edu_subject] ;";
            return SqlDB.ExecuteDataset(strCon, CommandType.Text, strSql).Tables[0];
        }

        ///
        /// <summary>
        /// 获取前多少的值
        /// </summary>
        /// <param name="TopNumber">数量</param>
        /// <param name="PageSize">每页显示多少个</param>
        /// <param name="PageIndex">当前页码，最少为1</param>
        /// <returns>返回DataTable</returns>
        public static DataTable edu_subjectPageList(string strWhere, int PageSize, int PageIndex)
        {
            StringBuilder sbSql = new StringBuilder();
            sbSql.Append("SELECT * FROM edu_subject");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                sbSql.Append(" WHERE " + strWhere);
            }
            sbSql.Append(" ORDER BY id DESC");
            DataSet ds = new DataSet();
            ds = SqlDB.ExecuteDataset((PageIndex - 1) * PageSize, PageSize, strCon, CommandType.Text, sbSql.ToString());
            if (ds.Tables.Count > 0)
            {
                return ds.Tables[0];
            }
            return new DataTable();
        }

        /// <summary>
        /// 获取该条件下的总的数量
        /// </summary>
        /// <param name="strWhere">条件，可以为空</param>
        /// <returns>如果没有就返回0</returns>
        public static int edu_subjectCount(string strWhere)
        {
            string strSql;
            if (!string.IsNullOrEmpty(strWhere.Trim()))
                strSql = "SELECT COUNT(*) FROM [edu_subject] WHERE " + strWhere + ";";
            else
                strSql = "SELECT COUNT(*)  FROM [edu_subject] ;";
            return Basic.Utils.StrToInt(SqlDB.ExecuteScalar(strCon, CommandType.Text, strSql).ToString(), 0);
        }
        #endregion

    }
}

