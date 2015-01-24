using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;

using Basic;
using Entity;

namespace DAL
{
	public class ProfessionalZhiYeRelation
	{
		#region  ProfessionalZhiYeRelation
		/// <summary>
		/// 调用存储过程增加一个
		/// </summary>
		/// <param name="info">实体对象</param>
		/// <returns>正常返回大于 0 的自增id, 0代表重复，否则返回-1</returns>
		public static int ProfessionalZhiYeRelationAdd(Entity.ProfessionalZhiYeRelation info)
		{
			SqlParameter[] prams = {
				SqlDB.MakeInParam("@ZhiYeId", SqlDbType.Int, 4, info.ZhiYeId),
				SqlDB.MakeInParam("@ProfessionalId", SqlDbType.Int, 4, info.ProfessionalId),
				SqlDB.MakeInParam("@ProfessionalCode", SqlDbType.NVarChar, 50, info.ProfessionalCode),
				SqlDB.MakeInParam("@ProfessionalName", SqlDbType.NVarChar, 150, info.ProfessionalName),
			};
			return Basic.Utils.StrToInt(SqlDB.ExecuteScalar(CommandType.StoredProcedure, "ProfessionalZhiYeRelationAdd", prams).ToString(), -1);
		}
		
		/// <summary>
		/// 调用存储过程修改一个
		/// </summary>
		/// <param name="info">实体对象</param>
		/// <returns>更新成功返回ture，否则返回false</returns>
		public static bool ProfessionalZhiYeRelationEdit(Entity.ProfessionalZhiYeRelation info)
		{
			SqlParameter[] prams = {
				SqlDB.MakeInParam("@Id", SqlDbType.Int, 4, info.Id),
				SqlDB.MakeInParam("@ZhiYeId", SqlDbType.Int, 4, info.ZhiYeId),
				SqlDB.MakeInParam("@ProfessionalId", SqlDbType.Int, 4, info.ProfessionalId),
				SqlDB.MakeInParam("@ProfessionalCode", SqlDbType.NVarChar, 50, info.ProfessionalCode),
				SqlDB.MakeInParam("@ProfessionalName", SqlDbType.NVarChar, 150, info.ProfessionalName),
				};
			int intReturnValue = 0;
			intReturnValue = SqlDB.ExecuteNonQuery(CommandType.StoredProcedure, "ProfessionalZhiYeRelationEdit", prams);
			if(intReturnValue == 1)
				return true;
			return false;
		}
		
		/// <summary>
		/// 获取所有的的值
		/// </summary>
		/// <param name="strWhere">条件，可以为空</param>
		/// <returns>返回DataTable</returns>
		public static DataTable ProfessionalZhiYeRelationList(string strWhere)
		{
			string strSql;
			if (!string.IsNullOrEmpty(strWhere.Trim()))
				strSql = "SELECT * FROM [ProfessionalZhiYeRelation] WHERE "+ strWhere +";";
			else
				strSql = "SELECT * FROM [ProfessionalZhiYeRelation] ;";
			return SqlDB.ExecuteDataset(CommandType.Text, strSql).Tables[0];
		}
		
		
		/// <summary>
		/// 获取某一个DataTable
		/// </summary>
		/// <param name="Id">标识</param>
		/// <returns>返回DataTable</returns>
		public static DataTable ProfessionalZhiYeRelationGet(int Id)
		{
			return SqlDB.ExecuteDataset(CommandType.Text, "SELECT * FROM [ProfessionalZhiYeRelation] WHERE Id = "+Id+";").Tables[0];
		}
		
		/// <summary>
		/// 获取某一个实体
		/// </summary>
		/// <param name="Id">标识</param>
		/// <returns>返回Entity</returns>
		public static Entity.ProfessionalZhiYeRelation ProfessionalZhiYeRelationEntityGet(int Id)
		{
			Entity.ProfessionalZhiYeRelation info = new Entity.ProfessionalZhiYeRelation();
			DataTable dt = SqlDB.ExecuteDataset(CommandType.Text, "SELECT * FROM [ProfessionalZhiYeRelation] WHERE Id = "+Id+";").Tables[0];
			if(dt.Rows.Count >0)
			{
				info.Id = Basic.Utils.StrToInt(dt.Rows[0]["Id"].ToString(),0);
				info.ZhiYeId = Basic.Utils.StrToInt(dt.Rows[0]["ZhiYeId"].ToString(),0);
				info.ProfessionalId = Basic.Utils.StrToInt(dt.Rows[0]["ProfessionalId"].ToString(),0);
				info.ProfessionalCode = dt.Rows[0]["ProfessionalCode"].ToString();
				info.ProfessionalName = dt.Rows[0]["ProfessionalName"].ToString();
			}
			return info;
		}
		
		/// <summary>
		/// 删除一个值
		/// </summary>
		/// <param name="Id">自增id的值</param>
		/// <returns>删除成功返回ture，否则返回false</returns>
		public static bool ProfessionalZhiYeRelationDel(int Id)
		{
			int intReturnValue = 0;
			intReturnValue = SqlDB.ExecuteNonQuery(CommandType.Text, "DELETE [ProfessionalZhiYeRelation]  WHERE Id =  " + Id);
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
		public static DataTable ProfessionalZhiYeRelationTopGet(string strWhere,int TopNumber)
		{
			string strSql;
			if (!string.IsNullOrEmpty(strWhere.Trim()))
				strSql = "SELECT TOP " + TopNumber.ToString() + " * FROM [ProfessionalZhiYeRelation] WHERE "+ strWhere +";";
			else
				strSql = "SELECT TOP " + TopNumber.ToString() + " * FROM [ProfessionalZhiYeRelation] ;";
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
		public static DataTable ProfessionalZhiYeRelationPageList(string strWhere,int PageSize,int PageIndex)
		{
			StringBuilder sbSql = new StringBuilder();
			sbSql.Append("SELECT * FROM ProfessionalZhiYeRelation");
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
		public static int ProfessionalZhiYeRelationCount(string strWhere)
		{
			string strSql;
			if (!string.IsNullOrEmpty(strWhere.Trim()))
				strSql = "SELECT COUNT(*) FROM [ProfessionalZhiYeRelation] WHERE "+ strWhere +";";
			else
				strSql = "SELECT COUNT(*)  FROM [ProfessionalZhiYeRelation] ;";
			return Basic.Utils.StrToInt(SqlDB.ExecuteScalar(CommandType.Text, strSql).ToString(), 0);
		}
	#endregion
		
	}
}

