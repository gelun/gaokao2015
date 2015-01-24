using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;

using Basic;
using Entity;

namespace DAL
{
    public class YuSheChengJi
    {
        #region  YuSheChengJi
        /// <summary>
        /// 调用存储过程增加一个
        /// </summary>
        /// <param name="info">实体对象</param>
        /// <returns>正常返回大于 0 的自增id, 0代表重复，否则返回-1</returns>
        public static int YuSheChengJiAdd(Entity.YuSheChengJi info)
        {
            SqlParameter[] prams = {
				SqlDB.MakeInParam("@StudentId", SqlDbType.Int, 4, info.StudentId),
                SqlDB.MakeInParam("@KeLei",SqlDbType.Int,4,info.KeLei),
                SqlDB.MakeInParam("@FenShu",SqlDbType.Int,4,info.FenShu),
				SqlDB.MakeInParam("@PcFirst", SqlDbType.Int, 4, info.PcFirst),
				SqlDB.MakeInParam("@PcSecond", SqlDbType.Int, 4, info.PcSecond),
				SqlDB.MakeInParam("@PcThird", SqlDbType.Int, 4, info.PcThird),
				SqlDB.MakeInParam("@PcZhuanKe", SqlDbType.Int, 4, info.PcZhuanKe),
			};
            return Basic.Utils.StrToInt(SqlDB.ExecuteScalar(CommandType.StoredProcedure, "YuSheChengJiAdd", prams).ToString(), -1);
        }

        /// <summary>
        /// 调用存储过程修改一个
        /// </summary>
        /// <param name="info">实体对象</param>
        /// <returns>更新成功返回ture，否则返回false</returns>
        public static bool YuSheChengJiEdit(Entity.YuSheChengJi info)
        {
            SqlParameter[] prams = {
				SqlDB.MakeInParam("@Id", SqlDbType.Int, 4, info.Id),
				SqlDB.MakeInParam("@StudentId", SqlDbType.Int, 4, info.StudentId),
                SqlDB.MakeInParam("@KeLei",SqlDbType.Int,4,info.KeLei),
                SqlDB.MakeInParam("@FenShu",SqlDbType.Int,4,info.FenShu),
				SqlDB.MakeInParam("@PcFirst", SqlDbType.Int, 4, info.PcFirst),
				SqlDB.MakeInParam("@PcSecond", SqlDbType.Int, 4, info.PcSecond),
				SqlDB.MakeInParam("@PcThird", SqlDbType.Int, 4, info.PcThird),
				SqlDB.MakeInParam("@PcZhuanKe", SqlDbType.Int, 4, info.PcZhuanKe),
				};
            int intReturnValue = 0;
            intReturnValue = SqlDB.ExecuteNonQuery(CommandType.StoredProcedure, "YuSheChengJiEdit", prams);
            if (intReturnValue == 1)
                return true;
            return false;
        }

        /// <summary>
        /// 获取所有的的值
        /// </summary>
        /// <param name="strWhere">条件，可以为空</param>
        /// <returns>返回DataTable</returns>
        public static DataTable YuSheChengJiList(string strWhere)
        {
            string strSql;
            if (!string.IsNullOrEmpty(strWhere.Trim()))
                strSql = "SELECT * FROM [YuSheChengJi] WHERE " + strWhere + ";";
            else
                strSql = "SELECT * FROM [YuSheChengJi] ;";
            return SqlDB.ExecuteDataset(CommandType.Text, strSql).Tables[0];
        }


        /// <summary>
        /// 获取某一个DataTable
        /// </summary>
        /// <param name="Id">标识</param>
        /// <returns>返回DataTable</returns>
        public static DataTable YuSheChengJiGet(int Id)
        {
            return SqlDB.ExecuteDataset(CommandType.Text, "SELECT * FROM [YuSheChengJi] WHERE Id = " + Id + ";").Tables[0];
        }

        /// <summary>
        /// 获取某一个实体
        /// </summary>
        /// <param name="Id">标识</param>
        /// <returns>返回Entity</returns>
        public static Entity.YuSheChengJi YuSheChengJiEntityGet(int StudentId)
        {
            Entity.YuSheChengJi info = new Entity.YuSheChengJi();
            DataTable dt = SqlDB.ExecuteDataset(CommandType.Text, "SELECT * FROM [YuSheChengJi] WHERE StudentId = " + StudentId + " ORDER BY ID DESC").Tables[0];
            if (dt.Rows.Count > 0)
            {
                info.Id = Basic.Utils.StrToInt(dt.Rows[0]["Id"].ToString(), 0);
                info.StudentId = Basic.Utils.StrToInt(dt.Rows[0]["StudentId"].ToString(), 0);
                info.KeLei = Basic.Utils.StrToInt(dt.Rows[0]["KeLei"].ToString(), 0);
                info.FenShu = Basic.Utils.StrToInt(dt.Rows[0]["FenShu"].ToString(), 0);
                info.PcFirst = Basic.Utils.StrToInt(dt.Rows[0]["PcFirst"].ToString(), 0);
                info.PcSecond = Basic.Utils.StrToInt(dt.Rows[0]["PcSecond"].ToString(), 0);
                info.PcThird = Basic.Utils.StrToInt(dt.Rows[0]["PcThird"].ToString(), 0);
                info.PcZhuanKe = Basic.Utils.StrToInt(dt.Rows[0]["PcZhuanKe"].ToString(), 0);
                info.AllowChangeCount = Basic.Utils.StrToInt(dt.Rows[0]["AllowChangeCount"].ToString(), 0);
                info.HaveChangeCount = Basic.Utils.StrToInt(dt.Rows[0]["HaveChangeCount"].ToString(), 0);
                info.AddTime = Basic.Utils.StrToDateTime(dt.Rows[0]["AddTime"].ToString());
                return info;
            }
            else
                return null;
        }

        /// <summary>
        /// 删除一个值
        /// </summary>
        /// <param name="Id">自增id的值</param>
        /// <returns>删除成功返回ture，否则返回false</returns>
        public static bool YuSheChengJiDel(int Id)
        {
            int intReturnValue = 0;
            intReturnValue = SqlDB.ExecuteNonQuery(CommandType.Text, "DELETE [YuSheChengJi]  WHERE Id =  " + Id);
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
        public static DataTable YuSheChengJiTopGet(string strWhere, int TopNumber)
        {
            string strSql;
            if (!string.IsNullOrEmpty(strWhere.Trim()))
                strSql = "SELECT TOP " + TopNumber.ToString() + " * FROM [YuSheChengJi] WHERE " + strWhere + ";";
            else
                strSql = "SELECT TOP " + TopNumber.ToString() + " * FROM [YuSheChengJi] ;";
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
        public static DataTable YuSheChengJiPageList(string strWhere, int PageSize, int PageIndex)
        {
            StringBuilder sbSql = new StringBuilder();
            sbSql.Append("SELECT * FROM YuSheChengJi");
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
        public static int YuSheChengJiCount(string strWhere)
        {
            string strSql;
            if (!string.IsNullOrEmpty(strWhere.Trim()))
                strSql = "SELECT COUNT(*) FROM [YuSheChengJi] WHERE " + strWhere + ";";
            else
                strSql = "SELECT COUNT(*)  FROM [YuSheChengJi] ;";
            return Basic.Utils.StrToInt(SqlDB.ExecuteScalar(CommandType.Text, strSql).ToString(), 0);
        }
        #endregion

    }
}

