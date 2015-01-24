using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;

using Basic;
using Entity;
using System.Configuration;

namespace DAL
{
	public class edu_grade
    {
        private static string strCon = ConfigurationManager.ConnectionStrings["ShiTi_ConnectionString"].ConnectionString;

		#region  edu_grade
		/// <summary>
		/// 调用存储过程增加一个
		/// </summary>
		/// <param name="info">实体对象</param>
		/// <returns>正常返回大于 0 的自增id, 0代表重复，否则返回-1</returns>
		public static int edu_gradeAdd(Entity.edu_grade info)
		{
			SqlParameter[] prams = {
				SqlDB.MakeInParam("@name", SqlDbType.NVarChar, 64, info.name),
				SqlDB.MakeInParam("@code", SqlDbType.Char, 2, info.code),
				SqlDB.MakeInParam("@grade_index", SqlDbType.Int, 4, info.grade_index),
				SqlDB.MakeInParam("@display_flag", SqlDbType.Int, 4, info.display_flag),
				SqlDB.MakeInParam("@section_id", SqlDbType.Int, 4, info.section_id),
			};
			return Basic.Utils.StrToInt(SqlDB.ExecuteScalar(strCon,CommandType.StoredProcedure, "edu_gradeAdd", prams).ToString(), -1);
		}
		
		/// <summary>
		/// 调用存储过程修改一个
		/// </summary>
		/// <param name="info">实体对象</param>
		/// <returns>更新成功返回ture，否则返回false</returns>
		public static bool edu_gradeEdit(Entity.edu_grade info)
		{
			SqlParameter[] prams = {
				SqlDB.MakeInParam("@id", SqlDbType.Int, 4, info.id),
				SqlDB.MakeInParam("@name", SqlDbType.NVarChar, 64, info.name),
				SqlDB.MakeInParam("@code", SqlDbType.Char, 2, info.code),
				SqlDB.MakeInParam("@grade_index", SqlDbType.Int, 4, info.grade_index),
				SqlDB.MakeInParam("@display_flag", SqlDbType.Int, 4, info.display_flag),
				SqlDB.MakeInParam("@section_id", SqlDbType.Int, 4, info.section_id),
				};
			int intReturnValue = 0;
			intReturnValue = SqlDB.ExecuteNonQuery(strCon,CommandType.StoredProcedure, "edu_gradeEdit", prams);
			if(intReturnValue == 1)
				return true;
			return false;
		}
		
		/// <summary>
		/// 获取所有的的值
		/// </summary>
		/// <param name="strWhere">条件，可以为空</param>
		/// <returns>返回DataTable</returns>
		public static DataTable edu_gradeList(string strWhere)
		{
			string strSql;
			if (!string.IsNullOrEmpty(strWhere.Trim()))
				strSql = "SELECT * FROM [edu_grade] WHERE "+ strWhere +";";
			else
				strSql = "SELECT * FROM [edu_grade] ;";
			return SqlDB.ExecuteDataset(strCon,CommandType.Text, strSql).Tables[0];
		}
		
		
		/// <summary>
		/// 获取某一个DataTable
		/// </summary>
		/// <param name="id">标识</param>
		/// <returns>返回DataTable</returns>
		public static DataTable edu_gradeGet(int id)
		{
			return SqlDB.ExecuteDataset(strCon,CommandType.Text, "SELECT * FROM [edu_grade] WHERE id = "+id+";").Tables[0];
		}
		
		/// <summary>
		/// 获取某一个实体
		/// </summary>
		/// <param name="id">标识</param>
		/// <returns>返回Entity</returns>
		public static Entity.edu_grade edu_gradeEntityGet(int id)
		{
			Entity.edu_grade info = new Entity.edu_grade();
			DataTable dt = SqlDB.ExecuteDataset(strCon,CommandType.Text, "SELECT * FROM [edu_grade] WHERE id = "+id+";").Tables[0];
			if(dt.Rows.Count >0)
			{
				info.id = Basic.Utils.StrToInt(dt.Rows[0]["id"].ToString(),0);
				info.name = dt.Rows[0]["name"].ToString();
				info.code = dt.Rows[0]["code"].ToString();
				info.grade_index = Basic.Utils.StrToInt(dt.Rows[0]["grade_index"].ToString(),0);
				info.display_flag = Basic.Utils.StrToInt(dt.Rows[0]["display_flag"].ToString(),0);
				info.section_id = Basic.Utils.StrToInt(dt.Rows[0]["section_id"].ToString(),0);
			}
			return info;
		}
		
		/// <summary>
		/// 删除一个值
		/// </summary>
		/// <param name="id">自增id的值</param>
		/// <returns>删除成功返回ture，否则返回false</returns>
		public static bool edu_gradeDel(int id)
		{
			int intReturnValue = 0;
			intReturnValue = SqlDB.ExecuteNonQuery(strCon,CommandType.Text, "DELETE [edu_grade]  WHERE id =  " + id);
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
		public static DataTable edu_gradeTopGet(string strWhere,int TopNumber)
		{
			string strSql;
			if (!string.IsNullOrEmpty(strWhere.Trim()))
				strSql = "SELECT TOP " + TopNumber.ToString() + " * FROM [edu_grade] WHERE "+ strWhere +";";
			else
				strSql = "SELECT TOP " + TopNumber.ToString() + " * FROM [edu_grade] ;";
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
		public static DataTable edu_gradePageList(string strWhere,int PageSize,int PageIndex)
		{
			StringBuilder sbSql = new StringBuilder();
			sbSql.Append("SELECT * FROM edu_grade");
			if (!string.IsNullOrEmpty(strWhere.Trim()))
			{
				sbSql.Append(" WHERE " + strWhere);
			}
			sbSql.Append(" ORDER BY id DESC");
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
		public static int edu_gradeCount(string strWhere)
		{
			string strSql;
			if (!string.IsNullOrEmpty(strWhere.Trim()))
				strSql = "SELECT COUNT(*) FROM [edu_grade] WHERE "+ strWhere +";";
			else
				strSql = "SELECT COUNT(*)  FROM [edu_grade] ;";
			return Basic.Utils.StrToInt(SqlDB.ExecuteScalar(strCon,CommandType.Text, strSql).ToString(), 0);
		}
	#endregion
		
	}
}

