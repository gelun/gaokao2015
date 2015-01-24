using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;

using Basic;
using Entity;

namespace DAL
{
	public class FenShuXian
	{
		#region  FenShuXian
		/// <summary>
		/// 调用存储过程增加一个
		/// </summary>
		/// <param name="info">实体对象</param>
		/// <returns>正常返回大于 0 的自增id, 0代表重复，否则返回-1</returns>
		public static int FenShuXianAdd(Entity.FenShuXian info)
		{
			SqlParameter[] prams = {
				SqlDB.MakeInParam("@Province", SqlDbType.NVarChar, 50, info.Province),
				SqlDB.MakeInParam("@ProvinceId", SqlDbType.Int, 4, info.ProvinceId),
				SqlDB.MakeInParam("@KeLei", SqlDbType.Int, 4, info.KeLei),
				SqlDB.MakeInParam("@DataYear", SqlDbType.Int, 4, info.DataYear),
				SqlDB.MakeInParam("@PcFirst", SqlDbType.Int, 4, info.PcFirst),
				SqlDB.MakeInParam("@PcSecond", SqlDbType.Int, 4, info.PcSecond),
				SqlDB.MakeInParam("@PcThird", SqlDbType.Int, 4, info.PcThird),
				SqlDB.MakeInParam("@ZkFirst", SqlDbType.Int, 4, info.ZkFirst),
				SqlDB.MakeInParam("@ZkSecond", SqlDbType.Int, 4, info.ZkSecond),
			};
			return Basic.Utils.StrToInt(SqlDB.ExecuteScalar(CommandType.StoredProcedure, "FenShuXianAdd", prams).ToString(), -1);
		}
		
		/// <summary>
		/// 调用存储过程修改一个
		/// </summary>
		/// <param name="info">实体对象</param>
		/// <returns>更新成功返回ture，否则返回false</returns>
		public static bool FenShuXianEdit(Entity.FenShuXian info)
		{
			SqlParameter[] prams = {
				SqlDB.MakeInParam("@Id", SqlDbType.Int, 4, info.Id),
				SqlDB.MakeInParam("@Province", SqlDbType.NVarChar, 50, info.Province),
				SqlDB.MakeInParam("@ProvinceId", SqlDbType.Int, 4, info.ProvinceId),
				SqlDB.MakeInParam("@KeLei", SqlDbType.Int, 4, info.KeLei),
				SqlDB.MakeInParam("@DataYear", SqlDbType.Int, 4, info.DataYear),
				SqlDB.MakeInParam("@PcFirst", SqlDbType.Int, 4, info.PcFirst),
				SqlDB.MakeInParam("@PcSecond", SqlDbType.Int, 4, info.PcSecond),
				SqlDB.MakeInParam("@PcThird", SqlDbType.Int, 4, info.PcThird),
				SqlDB.MakeInParam("@ZkFirst", SqlDbType.Int, 4, info.ZkFirst),
				SqlDB.MakeInParam("@ZkSecond", SqlDbType.Int, 4, info.ZkSecond),
				};
			int intReturnValue = 0;
			intReturnValue = SqlDB.ExecuteNonQuery(CommandType.StoredProcedure, "FenShuXianEdit", prams);
			if(intReturnValue == 1)
				return true;
			return false;
		}
		
		/// <summary>
		/// 获取所有的的值
		/// </summary>
		/// <param name="strWhere">条件，可以为空</param>
		/// <returns>返回DataTable</returns>
		public static DataTable FenShuXianList(string strWhere)
		{
			string strSql;
			if (!string.IsNullOrEmpty(strWhere.Trim()))
				strSql = "SELECT * FROM [FenShuXian] WHERE "+ strWhere +";";
			else
				strSql = "SELECT * FROM [FenShuXian] ;";
			return SqlDB.ExecuteDataset(CommandType.Text, strSql).Tables[0];
		}

        public static DataTable FenShuXianList(string strColum,string strWhere)
        {
            string strSql;
            if (!string.IsNullOrEmpty(strWhere.Trim()))
                strSql = "SELECT " + strColum + " FROM [FenShuXian] WHERE " + strWhere + ";";
            else
                strSql = "SELECT " + strColum + " FROM [FenShuXian] ;";
            return SqlDB.ExecuteDataset(CommandType.Text, strSql).Tables[0];
        }
		
		
		/// <summary>
		/// 获取某一个DataTable
		/// </summary>
		/// <param name="Id">标识</param>
		/// <returns>返回DataTable</returns>
		public static DataTable FenShuXianGet(int Id)
		{
			return SqlDB.ExecuteDataset(CommandType.Text, "SELECT * FROM [FenShuXian] WHERE Id = "+Id+";").Tables[0];
		}
		
		/// <summary>
		/// 获取某一个实体
		/// </summary>
		/// <param name="Id">标识</param>
		/// <returns>返回Entity</returns>
        public static Entity.FenShuXian FenShuXianEntityGet(int ProvinceId,string strWhere )
		{
			Entity.FenShuXian info = new Entity.FenShuXian();
            DataTable dt = SqlDB.ExecuteDataset(CommandType.Text, "SELECT TOP 1 * FROM [FenShuXian] WHERE ProvinceId = " + ProvinceId + strWhere + " ORDER BY DataYear DESC;").Tables[0];
			if(dt.Rows.Count >0)
			{
				info.Id = Basic.Utils.StrToInt(dt.Rows[0]["Id"].ToString(),0);
				info.Province = dt.Rows[0]["Province"].ToString();
				info.ProvinceId = Basic.Utils.StrToInt(dt.Rows[0]["ProvinceId"].ToString(),0);
				info.KeLei = Basic.Utils.StrToInt(dt.Rows[0]["KeLei"].ToString(),0);
				info.DataYear = Basic.Utils.StrToInt(dt.Rows[0]["DataYear"].ToString(),0);
				info.PcFirst = Basic.Utils.StrToInt(dt.Rows[0]["PcFirst"].ToString(),0);
				info.PcSecond = Basic.Utils.StrToInt(dt.Rows[0]["PcSecond"].ToString(),0);
				info.PcThird = Basic.Utils.StrToInt(dt.Rows[0]["PcThird"].ToString(),0);
				info.ZkFirst = Basic.Utils.StrToInt(dt.Rows[0]["ZkFirst"].ToString(),0);
				info.ZkSecond = Basic.Utils.StrToInt(dt.Rows[0]["ZkSecond"].ToString(),0);
			}
			return info;
		}
		
		/// <summary>
		/// 删除一个值
		/// </summary>
		/// <param name="Id">自增id的值</param>
		/// <returns>删除成功返回ture，否则返回false</returns>
		public static bool FenShuXianDel(int Id)
		{
			int intReturnValue = 0;
			intReturnValue = SqlDB.ExecuteNonQuery(CommandType.Text, "DELETE [FenShuXian]  WHERE Id =  " + Id);
			if(intReturnValue == 1)
				return true;
			return false;
		}
		
		/// <summary>
		/// 获取前多少的值
		/// </summary>
		/// <param name="strWhere">条件，可以为空</param>
		/// <param name="TopNumber">数量</param>
		/// <returns>返回DataTable</returns>
		public static DataTable FenShuXianTopGet(string strWhere,int TopNumber)
		{
			string strSql;
			if (!string.IsNullOrEmpty(strWhere.Trim()))
				strSql = "SELECT TOP " + TopNumber.ToString() + " * FROM [FenShuXian] WHERE "+ strWhere +";";
			else
				strSql = "SELECT TOP " + TopNumber.ToString() + " * FROM [FenShuXian] ;";
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
		public static DataTable FenShuXianPageList(string strWhere,int PageSize,int PageIndex)
		{
			StringBuilder sbSql = new StringBuilder();
			sbSql.Append("SELECT * FROM FenShuXian");
			if (!string.IsNullOrEmpty(strWhere.Trim()))
			{
				sbSql.Append(" WHERE " + strWhere);
			}
			sbSql.Append(" ORDER BY Id DESC");
			DataSet ds = new DataSet();
			ds = SqlDB.ExecuteDataset((PageIndex-1)*PageSize, PageSize, CommandType.Text, sbSql.ToString());
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
		public static int FenShuXianCount(string strWhere)
		{
			string strSql;
			if (!string.IsNullOrEmpty(strWhere.Trim()))
				strSql = "SELECT COUNT(*) FROM [FenShuXian] WHERE "+ strWhere +";";
			else
				strSql = "SELECT COUNT(*)  FROM [FenShuXian] ;";
			return Basic.Utils.StrToInt(SqlDB.ExecuteScalar(CommandType.Text, strSql).ToString(), 0);
		}
	#endregion
		
	}
}

