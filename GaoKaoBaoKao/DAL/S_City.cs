using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;

using Basic;
using Entity;
using System.Configuration;

namespace DAL
{
    public class S_City
    {
        private static string strCon = ConfigurationManager.ConnectionStrings["Join_ConnectionString"].ConnectionString;
        #region  S_City

        /// <summary>
        /// 获取所有的的值
        /// </summary>
        /// <param name="strWhere">条件，可以为空</param>
        /// <returns>返回DataTable</returns>
        public static DataTable S_CityList(string strWhere)
        {
            string strSql;
            if (!string.IsNullOrEmpty(strWhere.Trim()))
                strSql = "SELECT * FROM [S_City] WHERE " + strWhere + ";";
            else
                strSql = "SELECT * FROM [S_City] ;";
            return SqlDB.ExecuteDataset(strCon, CommandType.Text, strSql).Tables[0];
        }


        /// <summary>
        /// 获取某一个DataTable
        /// </summary>
        /// <param name="ProvinceID">标识</param>
        /// <returns>返回DataTable</returns>
        public static DataTable S_CityGet(int ProvinceID)
        {
            return SqlDB.ExecuteDataset(strCon, CommandType.Text, "SELECT * FROM [S_City] WHERE ProvinceID = " + ProvinceID + ";").Tables[0];
        }

        /// <summary>
        /// 获取某一个实体
        /// </summary>
        /// <param name="ProvinceID">标识</param>
        /// <returns>返回Entity</returns>
        public static Entity.S_City S_CityEntityGet(int ProvinceID)
        {
            Entity.S_City info = new Entity.S_City();
            DataTable dt = SqlDB.ExecuteDataset(strCon, CommandType.Text, "SELECT * FROM [S_City] WHERE ProvinceID = " + ProvinceID + ";").Tables[0];
            if (dt.Rows.Count > 0)
            {
                info.CityName = dt.Rows[0]["CityName"].ToString();
                return info;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 获取该条件下的总的数量
        /// </summary>
        /// <param name="strWhere">条件，可以为空</param>
        /// <returns>如果没有就返回0</returns>
        public static int S_CityCount(string strWhere)
        {
            string strSql;
            if (!string.IsNullOrEmpty(strWhere.Trim()))
                strSql = "SELECT COUNT(*) FROM [S_City] WHERE " + strWhere + ";";
            else
                strSql = "SELECT COUNT(*)  FROM [S_City] ;";
            return Basic.Utils.StrToInt(SqlDB.ExecuteScalar(strCon, CommandType.Text, strSql).ToString(), 0);
        }
        #endregion

    }
}

