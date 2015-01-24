using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;

using Basic;
using Entity;
using System.Configuration;

namespace DAL
{
    public class TiMuNeiRong
    {
        private static string strCon = ConfigurationManager.ConnectionStrings["ShiTi_ConnectionString"].ConnectionString;

        #region  TiMuNeiRong
        /// <summary>
        /// 调用存储过程增加一个
        /// </summary>
        /// <param name="info">实体对象</param>
        /// <returns>正常返回大于 0 的自增id, 0代表重复，否则返回-1</returns>
        public static int TiMuNeiRongAdd(Entity.TiMuNeiRong info)
        {
            SqlParameter[] prams = {
				SqlDB.MakeInParam("@gid", SqlDbType.VarChar, 50, info.gid),
				SqlDB.MakeInParam("@content", SqlDbType.NText, 0, info.content),
				SqlDB.MakeInParam("@objective_answer", SqlDbType.NVarChar, 64, info.objective_answer),
				SqlDB.MakeInParam("@answer", SqlDbType.NText, 0, info.answer),
				SqlDB.MakeInParam("@subject_id", SqlDbType.Int, 4, info.subject_id),
			};
            return Basic.Utils.StrToInt(SqlDB.ExecuteScalar(strCon, CommandType.StoredProcedure, "TiMuNeiRongAdd", prams).ToString(), -1);
        }

        /// <summary>
        /// 调用存储过程修改一个
        /// </summary>
        /// <param name="info">实体对象</param>
        /// <returns>更新成功返回ture，否则返回false</returns>
        public static bool TiMuNeiRongEdit(Entity.TiMuNeiRong info)
        {
            SqlParameter[] prams = {
				SqlDB.MakeInParam("@Id", SqlDbType.Int, 4, info.Id),
				SqlDB.MakeInParam("@gid", SqlDbType.VarChar, 50, info.gid),
				SqlDB.MakeInParam("@content", SqlDbType.NText, 0, info.content),
				SqlDB.MakeInParam("@objective_answer", SqlDbType.NVarChar, 64, info.objective_answer),
				SqlDB.MakeInParam("@answer", SqlDbType.NText, 0, info.answer),
				SqlDB.MakeInParam("@subject_id", SqlDbType.Int, 4, info.subject_id),
				};
            int intReturnValue = 0;
            intReturnValue = SqlDB.ExecuteNonQuery(strCon, CommandType.StoredProcedure, "TiMuNeiRongEdit", prams);
            if (intReturnValue == 1)
                return true;
            return false;
        }

        /// <summary>
        /// 获取所有的的值
        /// </summary>
        /// <param name="strWhere">条件，可以为空</param>
        /// <returns>返回DataTable</returns>
        public static DataTable TiMuNeiRongList(string strWhere)
        {
            string strSql;
            if (!string.IsNullOrEmpty(strWhere.Trim()))
                strSql = "SELECT * FROM [TiMuNeiRong] WHERE " + strWhere + ";";
            else
                strSql = "SELECT * FROM [TiMuNeiRong] ;";
            return SqlDB.ExecuteDataset(strCon, CommandType.Text, strSql).Tables[0];
        }


        /// <summary>
        /// 获取某一个DataTable
        /// </summary>
        /// <param name="Id">标识</param>
        /// <returns>返回DataTable</returns>
        public static DataTable TiMuNeiRongGet(int Id)
        {
            return SqlDB.ExecuteDataset(strCon, CommandType.Text, "SELECT * FROM [TiMuNeiRong] WHERE Id = " + Id + ";").Tables[0];
        }

        /// <summary>
        /// 获取某一个实体
        /// </summary>
        /// <param name="Id">标识</param>
        /// <returns>返回Entity</returns>
        public static Entity.TiMuNeiRong TiMuNeiRongEntityGet(int Id)
        {
            Entity.TiMuNeiRong info = new Entity.TiMuNeiRong();
            DataTable dt = SqlDB.ExecuteDataset(strCon, CommandType.Text, "SELECT * FROM [TiMuNeiRong] WHERE Id = " + Id + ";").Tables[0];
            if (dt.Rows.Count > 0)
            {
                info.Id = Basic.Utils.StrToInt(dt.Rows[0]["Id"].ToString(), 0);
                info.gid = dt.Rows[0]["gid"].ToString();
                info.content = dt.Rows[0]["content"].ToString();
                info.objective_answer = dt.Rows[0]["objective_answer"].ToString();
                info.answer = dt.Rows[0]["answer"].ToString();
                info.subject_id = Basic.Utils.StrToInt(dt.Rows[0]["subject_id"].ToString(), 0);
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
        /// <param name="Id">自增id的值</param>
        /// <returns>删除成功返回ture，否则返回false</returns>
        public static bool TiMuNeiRongDel(int Id)
        {
            int intReturnValue = 0;
            intReturnValue = SqlDB.ExecuteNonQuery(strCon, CommandType.Text, "DELETE [TiMuNeiRong]  WHERE Id =  " + Id);
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
        public static DataTable TiMuNeiRongTopGet(string strWhere, int TopNumber)
        {
            string strSql;
            if (!string.IsNullOrEmpty(strWhere.Trim()))
                strSql = "SELECT TOP " + TopNumber.ToString() + " * FROM [TiMuNeiRong] WHERE " + strWhere + ";";
            else
                strSql = "SELECT TOP " + TopNumber.ToString() + " * FROM [TiMuNeiRong] ;";
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
        public static DataTable TiMuNeiRongPageList(string strWhere, int PageSize, int PageIndex)
        {
            StringBuilder sbSql = new StringBuilder();
            sbSql.Append("SELECT * FROM TiMuNeiRong");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                sbSql.Append(" WHERE " + strWhere);
            }
            sbSql.Append(" ORDER BY Id DESC");
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
        public static int TiMuNeiRongCount(string strWhere)
        {
            string strSql;
            if (!string.IsNullOrEmpty(strWhere.Trim()))
                strSql = "SELECT COUNT(*) FROM [TiMuNeiRong] WHERE " + strWhere + ";";
            else
                strSql = "SELECT COUNT(*)  FROM [TiMuNeiRong] ;";
            return Basic.Utils.StrToInt(SqlDB.ExecuteScalar(strCon, CommandType.Text, strSql).ToString(), 0);
        }
        #endregion

    }
}

