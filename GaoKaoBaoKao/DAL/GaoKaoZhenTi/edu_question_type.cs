using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;

using Basic;
using Entity;
using System.Configuration;

namespace DAL
{
	public class edu_question_type
    {
        private static string strCon = ConfigurationManager.ConnectionStrings["ShiTi_ConnectionString"].ConnectionString;

		#region  edu_question_type
		/// <summary>
		/// 调用存储过程增加一个
		/// </summary>
		/// <param name="info">实体对象</param>
		/// <returns>正常返回大于 0 的自增id, 0代表重复，否则返回-1</returns>
		public static int edu_question_typeAdd(Entity.edu_question_type info)
		{
			SqlParameter[] prams = {
				SqlDB.MakeInParam("@subject_id", SqlDbType.Int, 4, info.subject_id),
				SqlDB.MakeInParam("@type_name", SqlDbType.NVarChar, 64, info.type_name),
			};
			return Basic.Utils.StrToInt(SqlDB.ExecuteScalar(strCon,CommandType.StoredProcedure, "edu_question_typeAdd", prams).ToString(), -1);
		}
		
		/// <summary>
		/// 调用存储过程修改一个
		/// </summary>
		/// <param name="info">实体对象</param>
		/// <returns>更新成功返回ture，否则返回false</returns>
		public static bool edu_question_typeEdit(Entity.edu_question_type info)
		{
			SqlParameter[] prams = {
				SqlDB.MakeInParam("@id", SqlDbType.Int, 4, info.id),
				SqlDB.MakeInParam("@subject_id", SqlDbType.Int, 4, info.subject_id),
				SqlDB.MakeInParam("@type_name", SqlDbType.NVarChar, 64, info.type_name),
				};
			int intReturnValue = 0;
			intReturnValue = SqlDB.ExecuteNonQuery(strCon,CommandType.StoredProcedure, "edu_question_typeEdit", prams);
			if(intReturnValue == 1)
				return true;
			return false;
		}
		
		/// <summary>
		/// 获取所有的的值
		/// </summary>
		/// <param name="strWhere">条件，可以为空</param>
		/// <returns>返回DataTable</returns>        
		public static DataTable edu_question_typeList(string strWhere)
		{
			string strSql;
			if (!string.IsNullOrEmpty(strWhere.Trim()))
				strSql = "SELECT * FROM [edu_question_type] WHERE "+ strWhere +";";
			else
				strSql = "SELECT * FROM [edu_question_type] ;";
			return SqlDB.ExecuteDataset(strCon,CommandType.Text, strSql).Tables[0];
		}


		
		/// <summary>
		/// 获取某一个DataTable
		/// </summary>
		/// <param name="id">标识</param>
		/// <returns>返回DataTable</returns>
		public static DataTable edu_question_typeGet(int id)
		{
			return SqlDB.ExecuteDataset(strCon,CommandType.Text, "SELECT * FROM [edu_question_type] WHERE id = "+id+";").Tables[0];
		}
		
		/// <summary>
		/// 获取某一个实体
		/// </summary>
		/// <param name="id">标识</param>
		/// <returns>返回Entity</returns>
		public static Entity.edu_question_type edu_question_typeEntityGet(int id)
		{
			Entity.edu_question_type info = new Entity.edu_question_type();
			DataTable dt = SqlDB.ExecuteDataset(strCon,CommandType.Text, "SELECT * FROM [edu_question_type] WHERE id = "+id+";").Tables[0];
			if(dt.Rows.Count >0)
			{
				info.id = Basic.Utils.StrToInt(dt.Rows[0]["id"].ToString(),0);
				info.subject_id = Basic.Utils.StrToInt(dt.Rows[0]["subject_id"].ToString(),0);
				info.type_name = dt.Rows[0]["type_name"].ToString();
			}
			return info;
		}
		
		/// <summary>
		/// 删除一个值
		/// </summary>
		/// <param name="id">自增id的值</param>
		/// <returns>删除成功返回ture，否则返回false</returns>
		public static bool edu_question_typeDel(int id)
		{
			int intReturnValue = 0;
			intReturnValue = SqlDB.ExecuteNonQuery(strCon,CommandType.Text, "DELETE [edu_question_type]  WHERE id =  " + id);
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
		public static DataTable edu_question_typeTopGet(string strWhere,int TopNumber)
		{
			string strSql;
			if (!string.IsNullOrEmpty(strWhere.Trim()))
				strSql = "SELECT TOP " + TopNumber.ToString() + " * FROM [edu_question_type] WHERE "+ strWhere +";";
			else
				strSql = "SELECT TOP " + TopNumber.ToString() + " * FROM [edu_question_type] ;";
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
		public static DataTable edu_question_typePageList(string strWhere,int PageSize,int PageIndex)
		{
			StringBuilder sbSql = new StringBuilder();
			sbSql.Append("SELECT * FROM edu_question_type");
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
		public static int edu_question_typeCount(string strWhere)
		{
			string strSql;
			if (!string.IsNullOrEmpty(strWhere.Trim()))
				strSql = "SELECT COUNT(*) FROM [edu_question_type] WHERE "+ strWhere +";";
			else
				strSql = "SELECT COUNT(*)  FROM [edu_question_type] ;";
			return Basic.Utils.StrToInt(SqlDB.ExecuteScalar(strCon,CommandType.Text, strSql).ToString(), 0);
		}
	#endregion
		
	}
}

