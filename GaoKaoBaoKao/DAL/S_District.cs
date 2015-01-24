using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;

using Basic;
using Entity;
using System.Configuration;

namespace DAL
{
    public class S_District
    {
        private static string strCon = ConfigurationManager.ConnectionStrings["Join_ConnectionString"].ConnectionString;
        #region  S_District

        /// <summary>
        /// 获取所有的的值
        /// </summary>
        /// <param name="strWhere">条件，可以为空</param>
        /// <returns>返回DataTable</returns>
        public static DataTable S_DistrictList(string strWhere)
        {
            string strSql;
            if (!string.IsNullOrEmpty(strWhere.Trim()))
                strSql = "SELECT * FROM [S_District] WHERE " + strWhere + ";";
            else
                strSql = "SELECT * FROM [S_District] ;";
            return SqlDB.ExecuteDataset(strCon, CommandType.Text, strSql).Tables[0];
        }


        /// <summary>
        /// 获取某一个DataTable
        /// </summary>
        /// <param name="ProvinceID">标识</param>
        /// <returns>返回DataTable</returns>
        public static DataTable S_DistrictGet(int CityID)
        {
            return SqlDB.ExecuteDataset(strCon, CommandType.Text, "SELECT * FROM [S_District] WHERE CityID = " + CityID + ";").Tables[0];
        }

        /// <summary>
        /// 获取某一个实体
        /// </summary>
        /// <param name="ProvinceID">标识</param>
        /// <returns>返回Entity</returns>
        public static Entity.S_District S_DistrictEntityGet(int CityID)
        {
            Entity.S_District info = new Entity.S_District();
            DataTable dt = SqlDB.ExecuteDataset(strCon, CommandType.Text, "SELECT * FROM [S_District] WHERE CityID = " + CityID + ";").Tables[0];
            if (dt.Rows.Count > 0)
            {
                info.DistrictName = dt.Rows[0]["DistrictName"].ToString();
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
        public static int S_DistrictCount(string strWhere)
        {
            string strSql;
            if (!string.IsNullOrEmpty(strWhere.Trim()))
                strSql = "SELECT COUNT(*) FROM [S_District] WHERE " + strWhere + ";";
            else
                strSql = "SELECT COUNT(*)  FROM [S_District] ;";
            return Basic.Utils.StrToInt(SqlDB.ExecuteScalar(strCon, CommandType.Text, strSql).ToString(), 0);
        }
        #endregion

    }
}

