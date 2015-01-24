using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;

using Basic;
using Entity;
using System.Configuration;

namespace DAL
{
	public class shijuan
    {
        private static string strCon = ConfigurationManager.ConnectionStrings["ShiTi_ConnectionString"].ConnectionString;

		#region  shijuan
		/// <summary>
		/// 调用存储过程增加一个
		/// </summary>
		/// <param name="info">实体对象</param>
		/// <returns>正常返回大于 0 的自增id, 0代表重复，否则返回-1</returns>
		public static int shijuanAdd(Entity.shijuan info)
		{
			SqlParameter[] prams = {
				SqlDB.MakeInParam("@OldId", SqlDbType.Int, 4, info.OldId),
				SqlDB.MakeInParam("@name", SqlDbType.NVarChar, 128, info.name),
				SqlDB.MakeInParam("@exam_type", SqlDbType.Int, 4, info.exam_type),
				SqlDB.MakeInParam("@subject_id", SqlDbType.Int, 4, info.subject_id),
				SqlDB.MakeInParam("@section_id", SqlDbType.Int, 4, info.section_id),
				SqlDB.MakeInParam("@grade_id", SqlDbType.Int, 4, info.grade_id),
				SqlDB.MakeInParam("@province_id", SqlDbType.VarChar, 6, info.province_id),
				SqlDB.MakeInParam("@content", SqlDbType.NVarChar, 4000, info.content),
				SqlDB.MakeInParam("@year", SqlDbType.NVarChar, 50, info.year),
				SqlDB.MakeInParam("@score", SqlDbType.Int, 4, info.score),
				SqlDB.MakeInParam("@source", SqlDbType.NVarChar, 200, info.source),
				SqlDB.MakeInParam("@exam_time", SqlDbType.Int, 4, info.exam_time),
			};
			return Basic.Utils.StrToInt(SqlDB.ExecuteScalar(strCon,CommandType.StoredProcedure, "shijuanAdd", prams).ToString(), -1);
		}
		
		/// <summary>
		/// 调用存储过程修改一个
		/// </summary>
		/// <param name="info">实体对象</param>
		/// <returns>更新成功返回ture，否则返回false</returns>
		public static bool shijuanEdit(Entity.shijuan info)
		{
			SqlParameter[] prams = {
				SqlDB.MakeInParam("@Id", SqlDbType.Int, 4, info.Id),
				SqlDB.MakeInParam("@OldId", SqlDbType.Int, 4, info.OldId),
				SqlDB.MakeInParam("@name", SqlDbType.NVarChar, 128, info.name),
				SqlDB.MakeInParam("@exam_type", SqlDbType.Int, 4, info.exam_type),
				SqlDB.MakeInParam("@subject_id", SqlDbType.Int, 4, info.subject_id),
				SqlDB.MakeInParam("@section_id", SqlDbType.Int, 4, info.section_id),
				SqlDB.MakeInParam("@grade_id", SqlDbType.Int, 4, info.grade_id),
				SqlDB.MakeInParam("@province_id", SqlDbType.VarChar, 6, info.province_id),
				SqlDB.MakeInParam("@content", SqlDbType.NVarChar, 4000, info.content),
				SqlDB.MakeInParam("@year", SqlDbType.NVarChar, 50, info.year),
				SqlDB.MakeInParam("@score", SqlDbType.Int, 4, info.score),
				SqlDB.MakeInParam("@source", SqlDbType.NVarChar, 200, info.source),
				SqlDB.MakeInParam("@exam_time", SqlDbType.Int, 4, info.exam_time),
				};
			int intReturnValue = 0;
			intReturnValue = SqlDB.ExecuteNonQuery(strCon,CommandType.StoredProcedure, "shijuanEdit", prams);
			if(intReturnValue == 1)
				return true;
			return false;
		}
		
		/// <summary>
		/// 获取所有的的值
		/// </summary>
		/// <param name="strWhere">条件，可以为空</param>
		/// <returns>返回DataTable</returns>
		public static DataTable shijuanList(string strWhere)
		{
			string strSql;
			if (!string.IsNullOrEmpty(strWhere.Trim()))
				strSql = "SELECT * FROM [shijuan] WHERE "+ strWhere +";";
			else
				strSql = "SELECT * FROM [shijuan] ;";
			return SqlDB.ExecuteDataset(strCon,CommandType.Text, strSql).Tables[0];
		}
		
		
		/// <summary>
		/// 获取某一个DataTable
		/// </summary>
		/// <param name="Id">标识</param>
		/// <returns>返回DataTable</returns>
		public static DataTable shijuanGet(int Id)
		{
			return SqlDB.ExecuteDataset(strCon,CommandType.Text, "SELECT * FROM [shijuan] WHERE Id = "+Id+";").Tables[0];
		}
		
		/// <summary>
		/// 获取某一个实体
		/// </summary>
		/// <param name="Id">标识</param>
		/// <returns>返回Entity</returns>
		public static Entity.shijuan shijuanEntityGet(int Id)
		{
			Entity.shijuan info = new Entity.shijuan();
			DataTable dt = SqlDB.ExecuteDataset(strCon,CommandType.Text, "SELECT * FROM [shijuan] WHERE Id = "+Id+";").Tables[0];
			if(dt.Rows.Count >0)
			{
				info.Id = Basic.Utils.StrToInt(dt.Rows[0]["Id"].ToString(),0);
				info.OldId = Basic.Utils.StrToInt(dt.Rows[0]["OldId"].ToString(),0);
				info.name = dt.Rows[0]["name"].ToString();
				info.exam_type = Basic.Utils.StrToInt(dt.Rows[0]["exam_type"].ToString(),0);
				info.subject_id = Basic.Utils.StrToInt(dt.Rows[0]["subject_id"].ToString(),0);
				info.section_id = Basic.Utils.StrToInt(dt.Rows[0]["section_id"].ToString(),0);
				info.grade_id = Basic.Utils.StrToInt(dt.Rows[0]["grade_id"].ToString(),0);
				info.province_id = dt.Rows[0]["province_id"].ToString();
				info.content = dt.Rows[0]["content"].ToString();
				info.year = dt.Rows[0]["year"].ToString();
				info.score = Basic.Utils.StrToInt(dt.Rows[0]["score"].ToString(),0);
				info.source = dt.Rows[0]["source"].ToString();
				info.exam_time = Basic.Utils.StrToInt(dt.Rows[0]["exam_time"].ToString(),0);
			}
			return info;
		}
		
		/// <summary>
		/// 删除一个值
		/// </summary>
		/// <param name="Id">自增id的值</param>
		/// <returns>删除成功返回ture，否则返回false</returns>
		public static bool shijuanDel(int Id)
		{
			int intReturnValue = 0;
			intReturnValue = SqlDB.ExecuteNonQuery(strCon,CommandType.Text, "DELETE [shijuan]  WHERE Id =  " + Id);
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
		public static DataTable shijuanTopGet(string strWhere,int TopNumber)
		{
			string strSql;
			if (!string.IsNullOrEmpty(strWhere.Trim()))
				strSql = "SELECT TOP " + TopNumber.ToString() + " * FROM [shijuan] WHERE "+ strWhere +";";
			else
				strSql = "SELECT TOP " + TopNumber.ToString() + " * FROM [shijuan] ;";
			return SqlDB.ExecuteDataset(strCon,CommandType.Text, strSql).Tables[0];
		}
		
		///
		/// <summary>
		/// 获取前多少的值
		/// </summary>
		/// <param name="TopNumber">数量</param>
		/// <param name="PageSize">每页显示多少个</param>
		/// <param name="PageIndex">当前页码，最少为1</param>
		/// <returns>返回DataTable</returns>
		public static DataTable shijuanPageList(string strWhere,int PageSize,int PageIndex)
		{
			StringBuilder sbSql = new StringBuilder();
			sbSql.Append("SELECT * FROM shijuan");
			if (!string.IsNullOrEmpty(strWhere.Trim()))
			{
				sbSql.Append(" WHERE " + strWhere);
			}
			sbSql.Append(" ORDER BY Id DESC");
			DataSet ds = new DataSet();
			ds = SqlDB.ExecuteDataset((PageIndex-1)*PageSize, PageSize, strCon,CommandType.Text, sbSql.ToString());
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
		public static int shijuanCount(string strWhere)
		{
			string strSql;
			if (!string.IsNullOrEmpty(strWhere.Trim()))
				strSql = "SELECT COUNT(*) FROM [shijuan] WHERE "+ strWhere +";";
			else
				strSql = "SELECT COUNT(*)  FROM [shijuan] ;";
			return Basic.Utils.StrToInt(SqlDB.ExecuteScalar(strCon,CommandType.Text, strSql).ToString(), 0);
		}
	#endregion
		
	}
}

