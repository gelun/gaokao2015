using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;

using Basic;
using Entity;

namespace DAL
{
    public class DingDan
    {
        #region  DingDan
        /// <summary>
        /// 调用存储过程增加一个
        /// </summary>
        /// <param name="info">实体对象</param>
        /// <returns>正常返回大于 0 的自增id, 0代表重复，否则返回-1</returns>
        public static int DingDanAdd(Entity.DingDan info)
        {
            SqlParameter[] prams = {
				SqlDB.MakeInParam("@State", SqlDbType.Int, 4, info.State),
				SqlDB.MakeInParam("@DingDanHao", SqlDbType.NVarChar, 100, info.DingDanHao),
				SqlDB.MakeInParam("@Subject", SqlDbType.NVarChar, 200, info.Subject),
				SqlDB.MakeInParam("@Body", SqlDbType.NText, 0, info.Body),
				SqlDB.MakeInParam("@Count", SqlDbType.Int, 4, info.Count),
				SqlDB.MakeInParam("@DanJia", SqlDbType.Decimal, 0, info.DanJia),
				SqlDB.MakeInParam("@DingDanJinE", SqlDbType.Decimal, 0, info.DingDanJinE),
				SqlDB.MakeInParam("@CellName", SqlDbType.NVarChar, 100, info.CellName),
				SqlDB.MakeInParam("@CellMobile", SqlDbType.NVarChar, 50, info.CellMobile),
				SqlDB.MakeInParam("@AddTime", SqlDbType.DateTime, 8, info.AddTime),
				SqlDB.MakeInParam("@Memo", SqlDbType.NText, 0, info.Memo),
				SqlDB.MakeInParam("@ProvinceId", SqlDbType.Int, 4, info.ProvinceId),
				SqlDB.MakeInParam("@WenLi", SqlDbType.Int, 4, info.WenLi),
				SqlDB.MakeInParam("@Address", SqlDbType.NVarChar, 200, info.Address),
				SqlDB.MakeInParam("@Category", SqlDbType.Int, 4, info.Category),
                
			};
            return Basic.Utils.StrToInt(SqlDB.ExecuteScalar(CommandType.StoredProcedure, "DingDanAdd", prams).ToString(), -1);
        }

        /// <summary>
        /// 调用存储过程修改一个
        /// </summary>
        /// <param name="info">实体对象</param>
        /// <returns>更新成功返回ture，否则返回false</returns>
        public static bool DingDanEdit(Entity.DingDan info)
        {
            SqlParameter[] prams = {
				SqlDB.MakeInParam("@Id", SqlDbType.Int, 4, info.Id),
				SqlDB.MakeInParam("@State", SqlDbType.Int, 4, info.State),
				SqlDB.MakeInParam("@DingDanHao", SqlDbType.NVarChar, 100, info.DingDanHao),
				SqlDB.MakeInParam("@Subject", SqlDbType.NVarChar, 200, info.Subject),
				SqlDB.MakeInParam("@Body", SqlDbType.NText, 0, info.Body),
				SqlDB.MakeInParam("@Count", SqlDbType.Int, 4, info.Count),
				SqlDB.MakeInParam("@DanJia", SqlDbType.Decimal, 0, info.DanJia),
				SqlDB.MakeInParam("@DingDanJinE", SqlDbType.Decimal, 0, info.DingDanJinE),
				SqlDB.MakeInParam("@CellName", SqlDbType.NVarChar, 100, info.CellName),
				SqlDB.MakeInParam("@CellMobile", SqlDbType.NVarChar, 50, info.CellMobile),
				SqlDB.MakeInParam("@AddTime", SqlDbType.DateTime, 8, info.AddTime),
				SqlDB.MakeInParam("@Memo", SqlDbType.NText, 0, info.Memo),
				SqlDB.MakeInParam("@ProvinceId", SqlDbType.Int, 4, info.ProvinceId),
				SqlDB.MakeInParam("@WenLi", SqlDbType.Int, 4, info.WenLi),
				SqlDB.MakeInParam("@Address", SqlDbType.NVarChar, 200, info.Address),
                SqlDB.MakeInParam("@Category", SqlDbType.Int, 4, info.Category),
				};
            int intReturnValue = 0;
            intReturnValue = SqlDB.ExecuteNonQuery(CommandType.StoredProcedure, "DingDanEdit", prams);
            if (intReturnValue == 1)
                return true;
            return false;
        }

        /// <summary>
        /// 获取所有的的值
        /// </summary>
        /// <param name="strWhere">条件，可以为空</param>
        /// <returns>返回DataTable</returns>
        public static DataTable DingDanList(string strWhere)
        {
            string strSql;
            if (!string.IsNullOrEmpty(strWhere.Trim()))
                strSql = "SELECT * FROM [DingDan] WHERE " + strWhere + ";";
            else
                strSql = "SELECT * FROM [DingDan] ;";
            return SqlDB.ExecuteDataset(CommandType.Text, strSql).Tables[0];
        }


        /// <summary>
        /// 获取某一个DataTable
        /// </summary>
        /// <param name="Id">标识</param>
        /// <returns>返回DataTable</returns>
        public static DataTable DingDanGet(int Id)
        {
            return SqlDB.ExecuteDataset(CommandType.Text, "SELECT * FROM [DingDan] WHERE Id = " + Id + ";").Tables[0];
        }

        /// <summary>
        /// 获取某一个实体
        /// </summary>
        /// <param name="Id">标识</param>
        /// <returns>返回Entity</returns>
        public static Entity.DingDan DingDanEntityGet(int Id)
        {
            Entity.DingDan info = new Entity.DingDan();
            DataTable dt = SqlDB.ExecuteDataset(CommandType.Text, "SELECT * FROM [DingDan] WHERE Id = " + Id + ";").Tables[0];
            if (dt.Rows.Count > 0)
            {
                info.Id = Basic.Utils.StrToInt(dt.Rows[0]["Id"].ToString(), 0);
                info.State = Basic.Utils.StrToInt(dt.Rows[0]["State"].ToString(), 0);
                info.DingDanHao = dt.Rows[0]["DingDanHao"].ToString();
                info.Subject = dt.Rows[0]["Subject"].ToString();
                info.Body = dt.Rows[0]["Body"].ToString();
                info.Count = Basic.Utils.StrToInt(dt.Rows[0]["Count"].ToString(), 0);
                info.DanJia = Basic.Utils.StrToDecimal(dt.Rows[0]["DanJia"].ToString(), 0);
                info.DingDanJinE = Basic.Utils.StrToDecimal(dt.Rows[0]["DingDanJinE"].ToString(), 0);
                info.CellName = dt.Rows[0]["CellName"].ToString();
                info.CellMobile = dt.Rows[0]["CellMobile"].ToString();
                info.AddTime = Basic.Utils.StrToDateTime(dt.Rows[0]["AddTime"].ToString());
                info.Memo = dt.Rows[0]["Memo"].ToString();
                info.ProvinceId = Basic.Utils.StrToInt(dt.Rows[0]["ProvinceId"].ToString(), 0);
                info.WenLi = Basic.Utils.StrToInt(dt.Rows[0]["WenLi"].ToString(), 0);
                info.Address = dt.Rows[0]["Address"].ToString();
                info.Category = Basic.Utils.StrToInt(dt.Rows[0]["Category"].ToString(), 0);
                return info;
            }
            return null;
        }

        public static Entity.DingDan DingDanEntityGetByDingDanHao(string DingDanHao)
        {
            Entity.DingDan info = new Entity.DingDan();
            DataTable dt = SqlDB.ExecuteDataset(CommandType.Text, "SELECT * FROM [DingDan] WHERE DingDanHao = '" + DingDanHao + "'").Tables[0];
            if (dt.Rows.Count > 0)
            {
                info.Id = Basic.Utils.StrToInt(dt.Rows[0]["Id"].ToString(), 0);
                info.State = Basic.Utils.StrToInt(dt.Rows[0]["State"].ToString(), 0);
                info.DingDanHao = dt.Rows[0]["DingDanHao"].ToString();
                info.Subject = dt.Rows[0]["Subject"].ToString();
                info.Body = dt.Rows[0]["Body"].ToString();
                info.Count = Basic.Utils.StrToInt(dt.Rows[0]["Count"].ToString(), 0);
                info.DanJia = Basic.Utils.StrToDecimal(dt.Rows[0]["DanJia"].ToString(), 0);
                info.DingDanJinE = Basic.Utils.StrToDecimal(dt.Rows[0]["DingDanJinE"].ToString(), 0);
                info.CellName = dt.Rows[0]["CellName"].ToString();
                info.CellMobile = dt.Rows[0]["CellMobile"].ToString();
                info.AddTime = Basic.Utils.StrToDateTime(dt.Rows[0]["AddTime"].ToString());
                info.Memo = dt.Rows[0]["Memo"].ToString();
                info.ProvinceId = Basic.Utils.StrToInt(dt.Rows[0]["ProvinceId"].ToString(), 0);
                info.WenLi = Basic.Utils.StrToInt(dt.Rows[0]["WenLi"].ToString(), 0);
                info.Address = dt.Rows[0]["Address"].ToString();
                info.Category = Basic.Utils.StrToInt(dt.Rows[0]["Category"].ToString(), 0);
                return info;
            }
            return null;
        }

        /// <summary>
        /// 删除一个值
        /// </summary>
        /// <param name="Id">自增id的值</param>
        /// <returns>删除成功返回ture，否则返回false</returns>
        public static bool DingDanDel(int Id)
        {
            int intReturnValue = 0;
            intReturnValue = SqlDB.ExecuteNonQuery(CommandType.Text, "DELETE [DingDan]  WHERE Id =  " + Id);
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
        public static DataTable DingDanTopGet(string strWhere, int TopNumber)
        {
            string strSql;
            if (!string.IsNullOrEmpty(strWhere.Trim()))
                strSql = "SELECT TOP " + TopNumber.ToString() + " * FROM [DingDan] WHERE " + strWhere + ";";
            else
                strSql = "SELECT TOP " + TopNumber.ToString() + " * FROM [DingDan] ;";
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
        public static DataTable DingDanPageList(string strWhere, int PageSize, int PageIndex)
        {
            StringBuilder sbSql = new StringBuilder();
            sbSql.Append("SELECT * FROM DingDan");
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
        public static int DingDanCount(string strWhere)
        {
            string strSql;
            if (!string.IsNullOrEmpty(strWhere.Trim()))
                strSql = "SELECT COUNT(*) FROM [DingDan] WHERE " + strWhere + ";";
            else
                strSql = "SELECT COUNT(*)  FROM [DingDan] ;";
            return Basic.Utils.StrToInt(SqlDB.ExecuteScalar(CommandType.Text, strSql).ToString(), 0);
        }
        #endregion

    }
}

