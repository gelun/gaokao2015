using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;

using Basic;
using Entity;

namespace DAL
{
    public class ProvinceConfig
    {
        #region  ProvinceConfig
        /// <summary>
        /// 调用存储过程增加一个
        /// </summary>
        /// <param name="info">实体对象</param>
        /// <returns>正常返回大于 0 的自增id, 0代表重复，否则返回-1</returns>
        public static int ProvinceConfigAdd(Entity.ProvinceConfig info)
        {
            SqlParameter[] prams = {
				SqlDB.MakeInParam("@ProvinceId", SqlDbType.Int, 4, info.ProvinceId),
				SqlDB.MakeInParam("@HasTiQianPi", SqlDbType.Int, 4, info.HasTiQianPi),
				SqlDB.MakeInParam("@HasZhuanKe", SqlDbType.Int, 4, info.HasZhuanKe),
				SqlDB.MakeInParam("@HasZhuanKe", SqlDbType.Int, 4, info.HasZhuanKe),
                
				SqlDB.MakeInParam("@HasZhuanKeZhuanYe", SqlDbType.Int, 4, info.HasZhuanKeZhuanYe),
				SqlDB.MakeInParam("@OwnTable", SqlDbType.Int, 4, info.OwnTable),
				SqlDB.MakeInParam("@ChangeEndTime", SqlDbType.DateTime, 8, info.ChangeEndTime),
				SqlDB.MakeInParam("@ReStartTime", SqlDbType.DateTime, 8, info.ReStartTime),
				SqlDB.MakeInParam("@LatestProvinceWeiCiYear", SqlDbType.Int, 4, info.LatestProvinceWeiCiYear),
				SqlDB.MakeInParam("@LatestBenKeYear", SqlDbType.Int, 4, info.LatestBenKeYear),
				SqlDB.MakeInParam("@LatestBenKeZhuanYeYear", SqlDbType.Int, 4, info.LatestBenKeZhuanYeYear),
				SqlDB.MakeInParam("@LatestZhuanKeYear", SqlDbType.Int, 4, info.LatestZhuanKeYear),
			};
            return Basic.Utils.StrToInt(SqlDB.ExecuteScalar(CommandType.StoredProcedure, "ProvinceConfigAdd", prams).ToString(), -1);
        }

        /// <summary>
        /// 调用存储过程修改一个
        /// </summary>
        /// <param name="info">实体对象</param>
        /// <returns>更新成功返回ture，否则返回false</returns>
        public static bool ProvinceConfigEdit(Entity.ProvinceConfig info)
        {
            SqlParameter[] prams = {
				SqlDB.MakeInParam("@Id", SqlDbType.Int, 4, info.Id),
				SqlDB.MakeInParam("@ProvinceId", SqlDbType.Int, 4, info.ProvinceId),
				SqlDB.MakeInParam("@HasTiQianPi", SqlDbType.Int, 4, info.HasTiQianPi),
				SqlDB.MakeInParam("@HasZhuanKe", SqlDbType.Int, 4, info.HasZhuanKe),
				SqlDB.MakeInParam("@HasZhuanKeZhuanYe", SqlDbType.Int, 4, info.HasZhuanKeZhuanYe),
				SqlDB.MakeInParam("@OwnTable", SqlDbType.Int, 4, info.OwnTable),
				SqlDB.MakeInParam("@ChangeEndTime", SqlDbType.DateTime, 8, info.ChangeEndTime),
				SqlDB.MakeInParam("@ReStartTime", SqlDbType.DateTime, 8, info.ReStartTime),
				SqlDB.MakeInParam("@LatestProvinceWeiCiYear", SqlDbType.Int, 4, info.LatestProvinceWeiCiYear),
				SqlDB.MakeInParam("@LatestBenKeYear", SqlDbType.Int, 4, info.LatestBenKeYear),
				SqlDB.MakeInParam("@LatestBenKeZhuanYeYear", SqlDbType.Int, 4, info.LatestBenKeZhuanYeYear),
				SqlDB.MakeInParam("@LatestZhuanKeYear", SqlDbType.Int, 4, info.LatestZhuanKeYear),
				};
            int intReturnValue = 0;
            intReturnValue = SqlDB.ExecuteNonQuery(CommandType.StoredProcedure, "ProvinceConfigEdit", prams);
            if (intReturnValue == 1)
                return true;
            return false;
        }

        /// <summary>
        /// 暂停该值
        /// </summary>
        /// <param name="Id">自增id的值</param>
        /// <returns>暂停成功返回ture，否则返回false</returns>
        //public static bool ProvinceConfigPause(Entity.ProvinceConfig info)
        //{
        //    int intReturnValue = 0;
        //    intReturnValue = SqlDB.ExecuteNonQuery(CommandType.Text, "UPDATE [ProvinceConfig] SET IsPause = "+  info.IsPause +"  WHERE Id =  " +  info.Id);
        //    if(intReturnValue == 1)
        //        return true;
        //    return false;
        //}

        /// <summary>
        /// 获取所有的的值
        /// </summary>
        /// <param name="strWhere">条件，可以为空</param>
        /// <returns>返回DataTable</returns>
        public static DataTable ProvinceConfigList(string strWhere)
        {
            string strSql;
            if (!string.IsNullOrEmpty(strWhere.Trim()))
                strSql = "SELECT * FROM [ProvinceConfig] WHERE " + strWhere + ";";
            else
                strSql = "SELECT * FROM [ProvinceConfig] ;";
            return SqlDB.ExecuteDataset(CommandType.Text, strSql).Tables[0];
        }


        /// <summary>
        /// 获取某一个DataTable
        /// </summary>
        /// <param name="Id">标识</param>
        /// <returns>返回DataTable</returns>
        public static DataTable ProvinceConfigGet(int Id)
        {
            return SqlDB.ExecuteDataset(CommandType.Text, "SELECT * FROM [ProvinceConfig] WHERE Id = " + Id + ";").Tables[0];
        }

        /// <summary>
        /// 获取某一个实体
        /// </summary>
        /// <param name="Id">标识</param>
        /// <returns>返回Entity</returns>
        public static Entity.ProvinceConfig ProvinceConfigEntityGet(int ProvinceId)
        {
            Entity.ProvinceConfig info = new Entity.ProvinceConfig();
            DataTable dt = SqlDB.ExecuteDataset(CommandType.Text, "SELECT * FROM [ProvinceConfig] WHERE ProvinceId = " + ProvinceId + ";").Tables[0];
            if (dt != null && dt.Rows.Count > 0)
            {
                info.Id = Basic.Utils.StrToInt(dt.Rows[0]["Id"].ToString(), 0);
                info.ProvinceId = Basic.Utils.StrToInt(dt.Rows[0]["ProvinceId"].ToString(), 0);
                info.HasTiQianPi = Basic.Utils.StrToInt(dt.Rows[0]["HasTiQianPi"].ToString(), 0);
                info.HasZhuanKe = Basic.Utils.StrToInt(dt.Rows[0]["HasZhuanKe"].ToString(), 0);
                info.HasZhuanKeZhuanYe = Basic.Utils.StrToInt(dt.Rows[0]["HasZhuanKeZhuanYe"].ToString(), 0);
                info.OwnTable = Basic.Utils.StrToInt(dt.Rows[0]["OwnTable"].ToString(), 0);
                info.LatestProvinceWeiCiYear = Basic.Utils.StrToInt(dt.Rows[0]["LatestProvinceWeiCiYear"].ToString(), 0);
                info.LatestBenKeYear = Basic.Utils.StrToInt(dt.Rows[0]["LatestBenKeYear"].ToString(), 2013);
                info.LatestBenKeZhuanYeYear = Basic.Utils.StrToInt(dt.Rows[0]["LatestBenKeZhuanYeYear"].ToString(), 2013);
                info.LatestZhuanKeYear = Basic.Utils.StrToInt(dt.Rows[0]["LatestZhuanKeYear"].ToString(), 0);
            }
            else
            {

                info.Id = 0;
                info.ProvinceId = ProvinceId;
                info.HasTiQianPi = 0;
                info.HasZhuanKe = 0;
                info.HasZhuanKeZhuanYe = 0;
                info.OwnTable = 0;
                info.LatestProvinceWeiCiYear = 2014;
                info.LatestBenKeYear = 2013;
                info.LatestBenKeZhuanYeYear = 2013;
                info.LatestZhuanKeYear = 0;

                if (ProvinceId == 1 || ProvinceId == 9 || ProvinceId == 11 || ProvinceId == 13 || ProvinceId == 21 || ProvinceId == 26 || ProvinceId == 27 || ProvinceId == 28 || ProvinceId == 29 || ProvinceId == 31 || ProvinceId == 32)
                {
                    info.LatestProvinceWeiCiYear = 2013;
                }
            }
            return info;
        }

        /// <summary>
        /// 删除一个值
        /// </summary>
        /// <param name="Id">自增id的值</param>
        /// <returns>删除成功返回ture，否则返回false</returns>
        public static bool ProvinceConfigDel(int Id)
        {
            int intReturnValue = 0;
            intReturnValue = SqlDB.ExecuteNonQuery(CommandType.Text, "DELETE [ProvinceConfig]  WHERE Id =  " + Id);
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
        public static DataTable ProvinceConfigTopGet(string strWhere, int TopNumber)
        {
            string strSql;
            if (!string.IsNullOrEmpty(strWhere.Trim()))
                strSql = "SELECT TOP " + TopNumber.ToString() + " * FROM [ProvinceConfig] WHERE " + strWhere + ";";
            else
                strSql = "SELECT TOP " + TopNumber.ToString() + " * FROM [ProvinceConfig] ;";
            return SqlDB.ExecuteDataset(CommandType.Text, strSql).Tables[0];
        }

        ///
        /// <summary>
        /// 获取前多少的值
        /// </summary>
        /// <param name="TopNumber">数量</param>
        /// <param name="PageSize">每页显示多少个</param>
        /// <param name="PageIndex">当前页码，最少为1</param>
        /// <returns>返回DataTable</returns>
        public static DataTable ProvinceConfigPageList(string strWhere, int PageSize, int PageIndex)
        {
            StringBuilder sbSql = new StringBuilder();
            sbSql.Append("SELECT * FROM ProvinceConfig");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                sbSql.Append(" WHERE " + strWhere);
            }
            sbSql.Append(" ORDER BY Id DESC");
            DataSet ds = new DataSet();
            ds = SqlDB.ExecuteDataset((PageIndex - 1) * PageSize, PageSize, CommandType.Text, sbSql.ToString());
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
        public static int ProvinceConfigCount(string strWhere)
        {
            string strSql;
            if (!string.IsNullOrEmpty(strWhere.Trim()))
                strSql = "SELECT COUNT(*) FROM [ProvinceConfig] WHERE " + strWhere + ";";
            else
                strSql = "SELECT COUNT(*)  FROM [ProvinceConfig] ;";
            return Basic.Utils.StrToInt(SqlDB.ExecuteScalar(CommandType.Text, strSql).ToString(), 0);
        }
        #endregion

    }
}

