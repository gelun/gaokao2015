using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;

using Basic;
using Entity;

namespace DAL
{
	public class SeniorMiddleSchool
	{
		#region  SeniorMiddleSchool
		/// <summary>
		/// 调用存储过程增加一个
		/// </summary>
		/// <param name="info">实体对象</param>
		/// <returns>正常返回大于 0 的自增id, 0代表重复，否则返回-1</returns>
		public static int SeniorMiddleSchoolAdd(Entity.SeniorMiddleSchool info)
		{
			SqlParameter[] prams = {
				SqlDB.MakeInParam("@SchoolName", SqlDbType.NVarChar, 50, info.SchoolName),
				SqlDB.MakeInParam("@Address", SqlDbType.NVarChar, 200, info.Address),
				SqlDB.MakeInParam("@ProvinceId", SqlDbType.Int, 4, info.ProvinceId),
				SqlDB.MakeInParam("@CityId", SqlDbType.Int, 4, info.CityId),
				SqlDB.MakeInParam("@XianId", SqlDbType.Int, 4, info.XianId),
				SqlDB.MakeInParam("@IsCheck", SqlDbType.Int, 4, info.IsCheck),
				SqlDB.MakeInParam("@IsPause", SqlDbType.Int, 4, info.IsPause),
				SqlDB.MakeInParam("@AddTime", SqlDbType.DateTime, 8, info.AddTime),
			};
			return Basic.Utils.StrToInt(SqlDB.ExecuteScalar(CommandType.StoredProcedure, "SeniorMiddleSchoolAdd", prams).ToString(), -1);
		}
		
		/// <summary>
		/// 调用存储过程修改一个
		/// </summary>
		/// <param name="info">实体对象</param>
		/// <returns>更新成功返回ture，否则返回false</returns>
		public static bool SeniorMiddleSchoolEdit(Entity.SeniorMiddleSchool info)
		{
			SqlParameter[] prams = {
				SqlDB.MakeInParam("@SchoolId", SqlDbType.Int, 4, info.SchoolId),
				SqlDB.MakeInParam("@SchoolName", SqlDbType.NVarChar, 50, info.SchoolName),
				SqlDB.MakeInParam("@Address", SqlDbType.NVarChar, 200, info.Address),
				SqlDB.MakeInParam("@ProvinceId", SqlDbType.Int, 4, info.ProvinceId),
				SqlDB.MakeInParam("@CityId", SqlDbType.Int, 4, info.CityId),
				SqlDB.MakeInParam("@XianId", SqlDbType.Int, 4, info.XianId),
				SqlDB.MakeInParam("@IsCheck", SqlDbType.Int, 4, info.IsCheck),
				SqlDB.MakeInParam("@IsPause", SqlDbType.Int, 4, info.IsPause),
				SqlDB.MakeInParam("@AddTime", SqlDbType.DateTime, 8, info.AddTime),
				};
			int intReturnValue = 0;
			intReturnValue = SqlDB.ExecuteNonQuery(CommandType.StoredProcedure, "SeniorMiddleSchoolEdit", prams);
			if(intReturnValue == 1)
				return true;
			return false;
		}
		
		/// <summary>
		/// 暂停该值
		/// </summary>
		/// <param name="SchoolId">自增id的值</param>
		/// <returns>暂停成功返回ture，否则返回false</returns>
		public static bool SeniorMiddleSchoolPause(Entity.SeniorMiddleSchool info)
		{
			int intReturnValue = 0;
			intReturnValue = SqlDB.ExecuteNonQuery(CommandType.Text, "UPDATE [SeniorMiddleSchool] SET IsPause = "+  info.IsPause +"  WHERE SchoolId =  " +  info.SchoolId);
			if(intReturnValue == 1)
				return true;
			return false;
		}
		
		/// <summary>
		/// 获取所有的的值
		/// </summary>
		/// <param name="strWhere">条件，可以为空</param>
		/// <returns>返回DataTable</returns>
		public static DataTable SeniorMiddleSchoolList(string strWhere)
		{
			string strSql;
			if (!string.IsNullOrEmpty(strWhere.Trim()))
				strSql = "SELECT * FROM [SeniorMiddleSchool] WHERE "+ strWhere +";";
			else
				strSql = "SELECT * FROM [SeniorMiddleSchool] ;";
			return SqlDB.ExecuteDataset(CommandType.Text, strSql).Tables[0];
		}
		
		
		/// <summary>
		/// 获取某一个DataTable
		/// </summary>
		/// <param name="SchoolId">标识</param>
		/// <returns>返回DataTable</returns>
		public static DataTable SeniorMiddleSchoolGet(int SchoolId)
		{
			return SqlDB.ExecuteDataset(CommandType.Text, "SELECT * FROM [SeniorMiddleSchool] WHERE SchoolId = "+SchoolId+";").Tables[0];
		}
		
		/// <summary>
		/// 获取某一个实体
		/// </summary>
		/// <param name="SchoolId">标识</param>
		/// <returns>返回Entity</returns>
		public static Entity.SeniorMiddleSchool SeniorMiddleSchoolEntityGet(int SchoolId)
		{
			Entity.SeniorMiddleSchool info = new Entity.SeniorMiddleSchool();
			DataTable dt = SqlDB.ExecuteDataset(CommandType.Text, "SELECT * FROM [SeniorMiddleSchool] WHERE SchoolId = "+SchoolId+";").Tables[0];
			if(dt.Rows.Count >0)
			{
				info.SchoolId = Basic.Utils.StrToInt(dt.Rows[0]["SchoolId"].ToString(),0);
				info.SchoolName = dt.Rows[0]["SchoolName"].ToString();
				info.Address = dt.Rows[0]["Address"].ToString();
				info.ProvinceId = Basic.Utils.StrToInt(dt.Rows[0]["ProvinceId"].ToString(),0);
				info.CityId = Basic.Utils.StrToInt(dt.Rows[0]["CityId"].ToString(),0);
				info.XianId = Basic.Utils.StrToInt(dt.Rows[0]["XianId"].ToString(),0);
				info.IsCheck = Basic.Utils.StrToInt(dt.Rows[0]["IsCheck"].ToString(),0);
				info.IsPause = Basic.Utils.StrToInt(dt.Rows[0]["IsPause"].ToString(),0);
			}
			return info;
		}
		
		/// <summary>
		/// 删除一个值
		/// </summary>
		/// <param name="SchoolId">自增id的值</param>
		/// <returns>删除成功返回ture，否则返回false</returns>
		public static bool SeniorMiddleSchoolDel(int SchoolId)
		{
			int intReturnValue = 0;
			intReturnValue = SqlDB.ExecuteNonQuery(CommandType.Text, "DELETE [SeniorMiddleSchool]  WHERE SchoolId =  " + SchoolId);
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
		public static DataTable SeniorMiddleSchoolTopGet(string strWhere,int TopNumber)
		{
			string strSql;
			if (!string.IsNullOrEmpty(strWhere.Trim()))
				strSql = "SELECT TOP " + TopNumber.ToString() + " * FROM [SeniorMiddleSchool] WHERE "+ strWhere +";";
			else
				strSql = "SELECT TOP " + TopNumber.ToString() + " * FROM [SeniorMiddleSchool] ;";
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
		public static DataTable SeniorMiddleSchoolPageList(string strWhere,int PageSize,int PageIndex)
		{
			StringBuilder sbSql = new StringBuilder();
			sbSql.Append("SELECT * FROM SeniorMiddleSchool");
			if (!string.IsNullOrEmpty(strWhere.Trim()))
			{
				sbSql.Append(" WHERE " + strWhere);
			}
			sbSql.Append(" ORDER BY SchoolId DESC");
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
		public static int SeniorMiddleSchoolCount(string strWhere)
		{
			string strSql;
			if (!string.IsNullOrEmpty(strWhere.Trim()))
				strSql = "SELECT COUNT(*) FROM [SeniorMiddleSchool] WHERE "+ strWhere +";";
			else
				strSql = "SELECT COUNT(*)  FROM [SeniorMiddleSchool] ;";
			return Basic.Utils.StrToInt(SqlDB.ExecuteScalar(CommandType.Text, strSql).ToString(), 0);
		}
	#endregion
		
	}
}

