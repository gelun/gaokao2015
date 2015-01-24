using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;

using Basic;
using Entity;

namespace DAL
{
	public class SchoolCategory
	{
		#region  SchoolCategory
		/// <summary>
		/// 调用存储过程增加一个
		/// </summary>
		/// <param name="info">实体对象</param>
		/// <returns>正常返回大于 0 的自增id, 0代表重复，否则返回-1</returns>
		public static int SchoolCategoryAdd(Entity.SchoolCategory info)
		{
			SqlParameter[] prams = {
				SqlDB.MakeInParam("@CategoryName", SqlDbType.NVarChar, 200, info.CategoryName),
				SqlDB.MakeInParam("@Sort", SqlDbType.Int, 4, info.Sort),
				SqlDB.MakeInParam("@IsPause", SqlDbType.Int, 4, info.IsPause),
			};
			return Basic.Utils.StrToInt(SqlDB.ExecuteScalar(CommandType.StoredProcedure, "SchoolCategoryAdd", prams).ToString(), -1);
		}
		
		/// <summary>
		/// 调用存储过程修改一个
		/// </summary>
		/// <param name="info">实体对象</param>
		/// <returns>更新成功返回ture，否则返回false</returns>
		public static bool SchoolCategoryEdit(Entity.SchoolCategory info)
		{
			SqlParameter[] prams = {
				SqlDB.MakeInParam("@Int", SqlDbType.Int, 4, info.Int),
				SqlDB.MakeInParam("@CategoryName", SqlDbType.NVarChar, 200, info.CategoryName),
				SqlDB.MakeInParam("@Sort", SqlDbType.Int, 4, info.Sort),
				SqlDB.MakeInParam("@IsPause", SqlDbType.Int, 4, info.IsPause),
				};
			int intReturnValue = 0;
			intReturnValue = SqlDB.ExecuteNonQuery(CommandType.StoredProcedure, "SchoolCategoryEdit", prams);
			if(intReturnValue == 1)
				return true;
			return false;
		}
		
		/// <summary>
		/// 暂停该值
		/// </summary>
		/// <param name="Int">自增id的值</param>
		/// <returns>暂停成功返回ture，否则返回false</returns>
		public static bool SchoolCategoryPause(Entity.SchoolCategory info)
		{
			int intReturnValue = 0;
			intReturnValue = SqlDB.ExecuteNonQuery(CommandType.Text, "UPDATE [SchoolCategory] SET IsPause = "+  info.IsPause +"  WHERE Int =  " +  info.Int);
			if(intReturnValue == 1)
				return true;
			return false;
		}
		
		/// <summary>
		/// 获取所有的的值
		/// </summary>
		/// <param name="strWhere">条件，可以为空</param>
		/// <returns>返回DataTable</returns>
		public static DataTable SchoolCategoryList(string strWhere)
		{
			string strSql;
			if (!string.IsNullOrEmpty(strWhere.Trim()))
				strSql = "SELECT * FROM [SchoolCategory] WHERE "+ strWhere +";";
			else
				strSql = "SELECT * FROM [SchoolCategory] ;";
			return SqlDB.ExecuteDataset(CommandType.Text, strSql).Tables[0];
		}
		
		
		/// <summary>
		/// 获取某一个DataTable
		/// </summary>
		/// <param name="Int">标识</param>
		/// <returns>返回DataTable</returns>
		public static DataTable SchoolCategoryGet(int Int)
		{
			return SqlDB.ExecuteDataset(CommandType.Text, "SELECT * FROM [SchoolCategory] WHERE Int = "+Int+";").Tables[0];
		}
		
		/// <summary>
		/// 获取某一个实体
		/// </summary>
		/// <param name="Int">标识</param>
		/// <returns>返回Entity</returns>
		public static Entity.SchoolCategory SchoolCategoryEntityGet(int Int)
		{
			Entity.SchoolCategory info = new Entity.SchoolCategory();
			DataTable dt = SqlDB.ExecuteDataset(CommandType.Text, "SELECT * FROM [SchoolCategory] WHERE Int = "+Int+";").Tables[0];
			if(dt.Rows.Count >0)
			{
				info.Int = Basic.Utils.StrToInt(dt.Rows[0]["Int"].ToString(),0);
				info.CategoryName = dt.Rows[0]["CategoryName"].ToString();
				info.Sort = Basic.Utils.StrToInt(dt.Rows[0]["Sort"].ToString(),0);
				info.IsPause = Basic.Utils.StrToInt(dt.Rows[0]["IsPause"].ToString(),0);
			}
			return info;
		}
		
		/// <summary>
		/// 删除一个值
		/// </summary>
		/// <param name="Int">自增id的值</param>
		/// <returns>删除成功返回ture，否则返回false</returns>
		public static bool SchoolCategoryDel(int Int)
		{
			int intReturnValue = 0;
			intReturnValue = SqlDB.ExecuteNonQuery(CommandType.Text, "DELETE [SchoolCategory]  WHERE Int =  " + Int);
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
		public static DataTable SchoolCategoryTopGet(string strWhere,int TopNumber)
		{
			string strSql;
			if (!string.IsNullOrEmpty(strWhere.Trim()))
				strSql = "SELECT TOP " + TopNumber.ToString() + " * FROM [SchoolCategory] WHERE "+ strWhere +";";
			else
				strSql = "SELECT TOP " + TopNumber.ToString() + " * FROM [SchoolCategory] ;";
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
		public static DataTable SchoolCategoryPageList(string strWhere,int PageSize,int PageIndex)
		{
			StringBuilder sbSql = new StringBuilder();
			sbSql.Append("SELECT * FROM SchoolCategory");
			if (!string.IsNullOrEmpty(strWhere.Trim()))
			{
				sbSql.Append(" WHERE " + strWhere);
			}
			sbSql.Append(" ORDER BY Int DESC");
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
		public static int SchoolCategoryCount(string strWhere)
		{
			string strSql;
			if (!string.IsNullOrEmpty(strWhere.Trim()))
				strSql = "SELECT COUNT(*) FROM [SchoolCategory] WHERE "+ strWhere +";";
			else
				strSql = "SELECT COUNT(*)  FROM [SchoolCategory] ;";
			return Basic.Utils.StrToInt(SqlDB.ExecuteScalar(CommandType.Text, strSql).ToString(), 0);
		}
	#endregion
		
	}
}

