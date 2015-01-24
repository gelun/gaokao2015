using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;

using Basic;
using Entity;
using System.Configuration;

namespace DAL
{
    public class area_province
    {
        private static string strCon = ConfigurationManager.ConnectionStrings["ShiTi_ConnectionString"].ConnectionString;

        #region  area_province
        /// <summary>
        /// 调用存储过程增加一个
        /// </summary>
        /// <param name="info">实体对象</param>
        /// <returns>正常返回大于 0 的自增id, 0代表重复，否则返回-1</returns>
        public static int area_provinceAdd(Entity.area_province info)
        {
            SqlParameter[] prams = {
				SqlDB.MakeInParam("@Name", SqlDbType.NVarChar, 32, info.Name),
				SqlDB.MakeInParam("@country_id", SqlDbType.VarChar, 6, info.country_id),
			};
            return Basic.Utils.StrToInt(SqlDB.ExecuteScalar(strCon, CommandType.StoredProcedure, "area_provinceAdd", prams).ToString(), -1);
        }

        /// <summary>
        /// 调用存储过程修改一个
        /// </summary>
        /// <param name="info">实体对象</param>
        /// <returns>更新成功返回ture，否则返回false</returns>
        public static bool area_provinceEdit(Entity.area_province info)
        {
            SqlParameter[] prams = {
				SqlDB.MakeInParam("@id", SqlDbType.VarChar, 6, info.id),
				SqlDB.MakeInParam("@Name", SqlDbType.NVarChar, 32, info.Name),
				SqlDB.MakeInParam("@country_id", SqlDbType.VarChar, 6, info.country_id),
				};
            int intReturnValue = 0;
            intReturnValue = SqlDB.ExecuteNonQuery(strCon, CommandType.StoredProcedure, "area_provinceEdit", prams);
            if (intReturnValue == 1)
                return true;
            return false;
        }

        /// <summary>
        /// 获取所有的的值
        /// </summary>
        /// <param name="strWhere">条件，可以为空</param>
        /// <returns>返回DataTable</returns>
        public static DataTable area_provinceList(string strWhere)
        {
            string strSql;
            if (!string.IsNullOrEmpty(strWhere.Trim()))
                strSql = "SELECT * FROM [area_province] WHERE " + strWhere + ";";
            else
                strSql = "SELECT * FROM [area_province] ;";
            return SqlDB.ExecuteDataset(strCon, CommandType.Text, strSql).Tables[0];
        }


        /// <summary>
        /// 获取某一个DataTable
        /// </summary>
        /// <param name="id">标识</param>
        /// <returns>返回DataTable</returns>
        public static DataTable area_provinceGet(int id)
        {
            return SqlDB.ExecuteDataset(strCon, CommandType.Text, "SELECT * FROM [area_province] WHERE id = " + id + ";").Tables[0];
        }

        /// <summary>
        /// 获取某一个实体
        /// </summary>
        /// <param name="id">标识</param>
        /// <returns>返回Entity</returns>
        public static Entity.area_province area_provinceEntityGet(int id)
        {
            Entity.area_province info = new Entity.area_province();
            DataTable dt = SqlDB.ExecuteDataset(strCon, CommandType.Text, "SELECT * FROM [area_province] WHERE id = " + id + ";").Tables[0];
            if (dt.Rows.Count > 0)
            {
                info.id = dt.Rows[0]["id"].ToString();
                info.Name = dt.Rows[0]["Name"].ToString();
                info.country_id = dt.Rows[0]["country_id"].ToString();
            }
            return info;
        }

        /// <summary>
        /// 删除一个值
        /// </summary>
        /// <param name="id">自增id的值</param>
        /// <returns>删除成功返回ture，否则返回false</returns>
        public static bool area_provinceDel(int id)
        {
            int intReturnValue = 0;
            intReturnValue = SqlDB.ExecuteNonQuery(strCon, CommandType.Text, "DELETE [area_province]  WHERE id =  " + id);
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
        public static DataTable area_provinceTopGet(string strWhere, int TopNumber)
        {
            string strSql;
            if (!string.IsNullOrEmpty(strWhere.Trim()))
                strSql = "SELECT TOP " + TopNumber.ToString() + " * FROM [area_province] WHERE " + strWhere + ";";
            else
                strSql = "SELECT TOP " + TopNumber.ToString() + " * FROM [area_province] ;";
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
        public static DataTable area_provincePageList(string strWhere, int PageSize, int PageIndex)
        {
            StringBuilder sbSql = new StringBuilder();
            sbSql.Append("SELECT * FROM area_province");
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
        public static int area_provinceCount(string strWhere)
        {
            string strSql;
            if (!string.IsNullOrEmpty(strWhere.Trim()))
                strSql = "SELECT COUNT(*) FROM [area_province] WHERE " + strWhere + ";";
            else
                strSql = "SELECT COUNT(*)  FROM [area_province] ;";
            return Basic.Utils.StrToInt(SqlDB.ExecuteScalar(strCon, CommandType.Text, strSql).ToString(), 0);
        }
        #endregion

    }
}

