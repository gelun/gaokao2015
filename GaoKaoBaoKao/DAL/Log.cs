using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;

using Basic;
using Entity;

namespace DAL
{
	public class Log
	{
		#region  Log
		/// <summary>
		/// 调用存储过程增加一个
		/// </summary>
		/// <param name="info">实体对象</param>
		/// <returns>正常返回大于 0 的自增id, 0代表重复，否则返回-1</returns>
		public static int LogAdd(Entity.Log info)
		{
			SqlParameter[] prams = {
				SqlDB.MakeInParam("@SchoolId", SqlDbType.Int, 4, info.SchoolId),
				SqlDB.MakeInParam("@SchoolName", SqlDbType.NVarChar, 200, info.SchoolName),
				SqlDB.MakeInParam("@Title", SqlDbType.NVarChar, 255, info.Title),
				SqlDB.MakeInParam("@UrlLink", SqlDbType.NVarChar, 200, info.UrlLink),
				SqlDB.MakeInParam("@CategoryName", SqlDbType.NVarChar, 255, info.CategoryName),
				SqlDB.MakeInParam("@BeiZhu", SqlDbType.NVarChar, 2000, info.BeiZhu),
				SqlDB.MakeInParam("@CaoZuoLeiBie", SqlDbType.NVarChar, 100, info.CaoZuoLeiBie),
				SqlDB.MakeInParam("@AddWid", SqlDbType.Int, 4, info.AddWid),
				SqlDB.MakeInParam("@AddTime", SqlDbType.DateTime, 8, info.AddTime),
			};
			return Basic.Utils.StrToInt(SqlDB.ExecuteScalar(CommandType.StoredProcedure, "LogAdd", prams).ToString(), -1);
		}
		
		/// <summary>
		/// 调用存储过程修改一个
		/// </summary>
		/// <param name="info">实体对象</param>
		/// <returns>更新成功返回ture，否则返回false</returns>
		public static bool LogEdit(Entity.Log info)
		{
			SqlParameter[] prams = {
				SqlDB.MakeInParam("@Id", SqlDbType.Int, 4, info.Id),
				SqlDB.MakeInParam("@SchoolId", SqlDbType.Int, 4, info.SchoolId),
				SqlDB.MakeInParam("@SchoolName", SqlDbType.NVarChar, 200, info.SchoolName),
				SqlDB.MakeInParam("@Title", SqlDbType.NVarChar, 255, info.Title),
				SqlDB.MakeInParam("@UrlLink", SqlDbType.NVarChar, 200, info.UrlLink),
				SqlDB.MakeInParam("@CategoryName", SqlDbType.NVarChar, 255, info.CategoryName),
				SqlDB.MakeInParam("@BeiZhu", SqlDbType.NVarChar, 2000, info.BeiZhu),
				SqlDB.MakeInParam("@CaoZuoLeiBie", SqlDbType.NVarChar, 100, info.CaoZuoLeiBie),
				SqlDB.MakeInParam("@AddWid", SqlDbType.Int, 4, info.AddWid),
				SqlDB.MakeInParam("@AddTime", SqlDbType.DateTime, 8, info.AddTime),
				};
			int intReturnValue = 0;
			intReturnValue = SqlDB.ExecuteNonQuery(CommandType.StoredProcedure, "LogEdit", prams);
			if(intReturnValue == 1)
				return true;
			return false;
		}
		
		/// <summary>
		/// 获取所有的的值
		/// </summary>
		/// <param name="strWhere">条件，可以为空</param>
		/// <returns>返回DataTable</returns>
		public static DataTable LogList(string strWhere)
		{
			string strSql;
			if (!string.IsNullOrEmpty(strWhere.Trim()))
				strSql = "SELECT * FROM [Log] WHERE "+ strWhere +";";
			else
				strSql = "SELECT * FROM [Log] ;";
			return SqlDB.ExecuteDataset(CommandType.Text, strSql).Tables[0];
		}
		
		
		/// <summary>
		/// 获取某一个DataTable
		/// </summary>
		/// <param name="Id">标识</param>
		/// <returns>返回DataTable</returns>
		public static DataTable LogGet(int Id)
		{
			return SqlDB.ExecuteDataset(CommandType.Text, "SELECT * FROM [Log] WHERE Id = "+Id+";").Tables[0];
		}
		
		/// <summary>
		/// 获取某一个实体
		/// </summary>
		/// <param name="Id">标识</param>
		/// <returns>返回Entity</returns>
		public static Entity.Log LogEntityGet(int Id)
		{
			Entity.Log info = new Entity.Log();
			DataTable dt = SqlDB.ExecuteDataset(CommandType.Text, "SELECT * FROM [Log] WHERE Id = "+Id+";").Tables[0];
			if(dt.Rows.Count >0)
			{
				info.Id = Basic.Utils.StrToInt(dt.Rows[0]["Id"].ToString(),0);
				info.SchoolId = Basic.Utils.StrToInt(dt.Rows[0]["SchoolId"].ToString(),0);
				info.SchoolName = dt.Rows[0]["SchoolName"].ToString();
				info.Title = dt.Rows[0]["Title"].ToString();
				info.UrlLink = dt.Rows[0]["UrlLink"].ToString();
				info.CategoryName = dt.Rows[0]["CategoryName"].ToString();
				info.BeiZhu = dt.Rows[0]["BeiZhu"].ToString();
				info.CaoZuoLeiBie = dt.Rows[0]["CaoZuoLeiBie"].ToString();
				info.AddWid = Basic.Utils.StrToInt(dt.Rows[0]["AddWid"].ToString(),0);
			}
			return info;
		}
		
		/// <summary>
		/// 删除一个值
		/// </summary>
		/// <param name="Id">自增id的值</param>
		/// <returns>删除成功返回ture，否则返回false</returns>
		public static bool LogDel(int Id)
		{
			int intReturnValue = 0;
			intReturnValue = SqlDB.ExecuteNonQuery(CommandType.Text, "DELETE [Log]  WHERE Id =  " + Id);
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
		public static DataTable LogTopGet(string strWhere,int TopNumber)
		{
			string strSql;
			if (!string.IsNullOrEmpty(strWhere.Trim()))
				strSql = "SELECT TOP " + TopNumber.ToString() + " * FROM [Log] WHERE "+ strWhere +";";
			else
				strSql = "SELECT TOP " + TopNumber.ToString() + " * FROM [Log] ;";
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
		public static DataTable LogPageList(string strWhere,int PageSize,int PageIndex)
		{
			StringBuilder sbSql = new StringBuilder();
			sbSql.Append("SELECT * FROM Log");
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
		public static int LogCount(string strWhere)
		{
			string strSql;
			if (!string.IsNullOrEmpty(strWhere.Trim()))
				strSql = "SELECT COUNT(*) FROM [Log] WHERE "+ strWhere +";";
			else
				strSql = "SELECT COUNT(*)  FROM [Log] ;";
			return Basic.Utils.StrToInt(SqlDB.ExecuteScalar(CommandType.Text, strSql).ToString(), 0);
		}
	#endregion
		
	}
}

