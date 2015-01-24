using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;

using Basic;
using Entity;
using System.Configuration;

namespace DAL
{
	public class TiMuSuoYin
    {
        private static string strCon = ConfigurationManager.ConnectionStrings["ShiTi_ConnectionString"].ConnectionString;

		#region  TiMuSuoYin
		/// <summary>
		/// 调用存储过程增加一个
		/// </summary>
		/// <param name="info">实体对象</param>
		/// <returns>正常返回大于 0 的自增id, 0代表重复，否则返回-1</returns>
		public static int TiMuSuoYinAdd(Entity.TiMuSuoYin info)
		{
			SqlParameter[] prams = {
				SqlDB.MakeInParam("@gid", SqlDbType.VarChar, 50, info.gid),
				SqlDB.MakeInParam("@zh_knowledge", SqlDbType.NVarChar, 128, info.zh_knowledge),
				SqlDB.MakeInParam("@difficulty", SqlDbType.Int, 4, info.difficulty),
				SqlDB.MakeInParam("@score", SqlDbType.Int, 4, info.score),
				SqlDB.MakeInParam("@objective_flag", SqlDbType.Int, 4, info.objective_flag),
				SqlDB.MakeInParam("@option_count", SqlDbType.Int, 4, info.option_count),
				SqlDB.MakeInParam("@group_count", SqlDbType.Int, 4, info.group_count),
				SqlDB.MakeInParam("@question_type", SqlDbType.NVarChar, 50, info.question_type),
				SqlDB.MakeInParam("@subject_id", SqlDbType.Int, 4, info.subject_id),
				SqlDB.MakeInParam("@grade_id", SqlDbType.Int, 4, info.grade_id),
				SqlDB.MakeInParam("@section_id", SqlDbType.Int, 4, info.section_id),
				SqlDB.MakeInParam("@edu_question_type_Id", SqlDbType.Int, 4, info.edu_question_type_Id),
				SqlDB.MakeInParam("@zhishidian_id", SqlDbType.Int, 4, info.zhishidian_id),
			};
			return Basic.Utils.StrToInt(SqlDB.ExecuteScalar(strCon,CommandType.StoredProcedure, "TiMuSuoYinAdd", prams).ToString(), -1);
		}
		
		/// <summary>
		/// 调用存储过程修改一个
		/// </summary>
		/// <param name="info">实体对象</param>
		/// <returns>更新成功返回ture，否则返回false</returns>
		public static bool TiMuSuoYinEdit(Entity.TiMuSuoYin info)
		{
			SqlParameter[] prams = {
				SqlDB.MakeInParam("@Id", SqlDbType.Int, 4, info.Id),
				SqlDB.MakeInParam("@gid", SqlDbType.VarChar, 50, info.gid),
				SqlDB.MakeInParam("@zh_knowledge", SqlDbType.NVarChar, 128, info.zh_knowledge),
				SqlDB.MakeInParam("@difficulty", SqlDbType.Int, 4, info.difficulty),
				SqlDB.MakeInParam("@score", SqlDbType.Int, 4, info.score),
				SqlDB.MakeInParam("@objective_flag", SqlDbType.Int, 4, info.objective_flag),
				SqlDB.MakeInParam("@option_count", SqlDbType.Int, 4, info.option_count),
				SqlDB.MakeInParam("@group_count", SqlDbType.Int, 4, info.group_count),
				SqlDB.MakeInParam("@question_type", SqlDbType.NVarChar, 50, info.question_type),
				SqlDB.MakeInParam("@subject_id", SqlDbType.Int, 4, info.subject_id),
				SqlDB.MakeInParam("@grade_id", SqlDbType.Int, 4, info.grade_id),
				SqlDB.MakeInParam("@section_id", SqlDbType.Int, 4, info.section_id),
				SqlDB.MakeInParam("@edu_question_type_Id", SqlDbType.Int, 4, info.edu_question_type_Id),
				SqlDB.MakeInParam("@zhishidian_id", SqlDbType.Int, 4, info.zhishidian_id),
				};
			int intReturnValue = 0;
			intReturnValue = SqlDB.ExecuteNonQuery(strCon,CommandType.StoredProcedure, "TiMuSuoYinEdit", prams);
			if(intReturnValue == 1)
				return true;
			return false;
		}
		
		/// <summary>
		/// 获取所有的的值
		/// </summary>
		/// <param name="strWhere">条件，可以为空</param>
		/// <returns>返回DataTable</returns>
		public static DataTable TiMuSuoYinList(string strWhere)
		{
			string strSql;
			if (!string.IsNullOrEmpty(strWhere.Trim()))
				strSql = "SELECT * FROM [TiMuSuoYin] WHERE "+ strWhere +";";
			else
				strSql = "SELECT * FROM [TiMuSuoYin] ;";
			return SqlDB.ExecuteDataset(strCon,CommandType.Text, strSql).Tables[0];
		}
		
		
		/// <summary>
		/// 获取某一个DataTable
		/// </summary>
		/// <param name="Id">标识</param>
		/// <returns>返回DataTable</returns>
		public static DataTable TiMuSuoYinGet(int Id)
		{
			return SqlDB.ExecuteDataset(strCon,CommandType.Text, "SELECT * FROM [TiMuSuoYin] WHERE Id = "+Id+";").Tables[0];
		}
		
		/// <summary>
		/// 获取某一个实体
		/// </summary>
		/// <param name="Id">标识</param>
		/// <returns>返回Entity</returns>
		public static Entity.TiMuSuoYin TiMuSuoYinEntityGet(int Id)
		{
			Entity.TiMuSuoYin info = new Entity.TiMuSuoYin();
			DataTable dt = SqlDB.ExecuteDataset(strCon,CommandType.Text, "SELECT * FROM [TiMuSuoYin] WHERE Id = "+Id+";").Tables[0];
			if(dt.Rows.Count >0)
			{
				info.Id = Basic.Utils.StrToInt(dt.Rows[0]["Id"].ToString(),0);
				info.gid = dt.Rows[0]["gid"].ToString();
				info.zh_knowledge = dt.Rows[0]["zh_knowledge"].ToString();
				info.difficulty = Basic.Utils.StrToInt(dt.Rows[0]["difficulty"].ToString(),0);
				info.score = Basic.Utils.StrToInt(dt.Rows[0]["score"].ToString(),0);
				info.objective_flag = Basic.Utils.StrToInt(dt.Rows[0]["objective_flag"].ToString(),0);
				info.option_count = Basic.Utils.StrToInt(dt.Rows[0]["option_count"].ToString(),0);
				info.group_count = Basic.Utils.StrToInt(dt.Rows[0]["group_count"].ToString(),0);
				info.question_type = dt.Rows[0]["question_type"].ToString();
				info.subject_id = Basic.Utils.StrToInt(dt.Rows[0]["subject_id"].ToString(),0);
				info.grade_id = Basic.Utils.StrToInt(dt.Rows[0]["grade_id"].ToString(),0);
				info.section_id = Basic.Utils.StrToInt(dt.Rows[0]["section_id"].ToString(),0);
				info.edu_question_type_Id = Basic.Utils.StrToInt(dt.Rows[0]["edu_question_type_Id"].ToString(),0);
				info.zhishidian_id = Basic.Utils.StrToInt(dt.Rows[0]["zhishidian_id"].ToString(),0);
			}
			return info;
		}
		
		/// <summary>
		/// 删除一个值
		/// </summary>
		/// <param name="Id">自增id的值</param>
		/// <returns>删除成功返回ture，否则返回false</returns>
		public static bool TiMuSuoYinDel(int Id)
		{
			int intReturnValue = 0;
			intReturnValue = SqlDB.ExecuteNonQuery(strCon,CommandType.Text, "DELETE [TiMuSuoYin]  WHERE Id =  " + Id);
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
		public static DataTable TiMuSuoYinTopGet(string strWhere,int TopNumber)
		{
			string strSql;
			if (!string.IsNullOrEmpty(strWhere.Trim()))
				strSql = "SELECT TOP " + TopNumber.ToString() + " * FROM [TiMuSuoYin] WHERE "+ strWhere +";";
			else
				strSql = "SELECT TOP " + TopNumber.ToString() + " * FROM [TiMuSuoYin] ;";
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
		public static DataTable TiMuSuoYinPageList(string strWhere,int PageSize,int PageIndex)
		{
			StringBuilder sbSql = new StringBuilder();
			sbSql.Append("SELECT * FROM TiMuSuoYin");
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
		public static int TiMuSuoYinCount(string strWhere)
		{
			string strSql;
			if (!string.IsNullOrEmpty(strWhere.Trim()))
				strSql = "SELECT COUNT(*) FROM [TiMuSuoYin] WHERE "+ strWhere +";";
			else
				strSql = "SELECT COUNT(*)  FROM [TiMuSuoYin] ;";
			return Basic.Utils.StrToInt(SqlDB.ExecuteScalar(strCon,CommandType.Text, strSql).ToString(), 0);
		}
	#endregion
		
	}
}

