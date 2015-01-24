using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;

using Basic;
using Entity;

namespace DAL
{
	public class ZhiYe
	{
		#region  ZhiYe
		/// <summary>
		/// 调用存储过程增加一个
		/// </summary>
		/// <param name="info">实体对象</param>
		/// <returns>正常返回大于 0 的自增id, 0代表重复，否则返回-1</returns>
		public static int ZhiYeAdd(Entity.ZhiYe info)
		{
			SqlParameter[] prams = {
				SqlDB.MakeInParam("@Code", SqlDbType.NVarChar, 10, info.Code),
				SqlDB.MakeInParam("@ZhiYeName", SqlDbType.NVarChar, 150, info.ZhiYeName),
				SqlDB.MakeInParam("@Remark", SqlDbType.NVarChar, 100, info.Remark),
				SqlDB.MakeInParam("@ZhiYeLevel", SqlDbType.Int, 4, info.ZhiYeLevel),
				SqlDB.MakeInParam("@ParentId", SqlDbType.Int, 4, info.ParentId),
				SqlDB.MakeInParam("@Intro", SqlDbType.NVarChar, 0, info.Intro),
				SqlDB.MakeInParam("@ClickNum", SqlDbType.Int, 4, info.ClickNum),
				SqlDB.MakeInParam("@Url", SqlDbType.NVarChar, 200, info.Url),
			};
			return Basic.Utils.StrToInt(SqlDB.ExecuteScalar(CommandType.StoredProcedure, "ZhiYeAdd", prams).ToString(), -1);
		}
		
		/// <summary>
		/// 调用存储过程修改一个
		/// </summary>
		/// <param name="info">实体对象</param>
		/// <returns>更新成功返回ture，否则返回false</returns>
		public static bool ZhiYeEdit(Entity.ZhiYe info)
		{
			SqlParameter[] prams = {
				SqlDB.MakeInParam("@Id", SqlDbType.Int, 4, info.Id),
				SqlDB.MakeInParam("@Code", SqlDbType.NVarChar, 10, info.Code),
				SqlDB.MakeInParam("@ZhiYeName", SqlDbType.NVarChar, 150, info.ZhiYeName),
				SqlDB.MakeInParam("@Remark", SqlDbType.NVarChar, 100, info.Remark),
				SqlDB.MakeInParam("@ZhiYeLevel", SqlDbType.Int, 4, info.ZhiYeLevel),
				SqlDB.MakeInParam("@ParentId", SqlDbType.Int, 4, info.ParentId),
				SqlDB.MakeInParam("@Intro", SqlDbType.NVarChar, 0, info.Intro),
				SqlDB.MakeInParam("@ClickNum", SqlDbType.Int, 4, info.ClickNum),
				SqlDB.MakeInParam("@Url", SqlDbType.NVarChar, 200, info.Url),
				};
			int intReturnValue = 0;
			intReturnValue = SqlDB.ExecuteNonQuery(CommandType.StoredProcedure, "ZhiYeEdit", prams);
			if(intReturnValue == 1)
				return true;
			return false;
		}
		
		/// <summary>
		/// 获取所有的的值
		/// </summary>
		/// <param name="strWhere">条件，可以为空</param>
		/// <returns>返回DataTable</returns>
		public static DataTable ZhiYeList(string strWhere)
		{
			string strSql;
			if (!string.IsNullOrEmpty(strWhere.Trim()))
				strSql = "SELECT * FROM [ZhiYe] WHERE "+ strWhere +";";
			else
				strSql = "SELECT * FROM [ZhiYe] ;";
			return SqlDB.ExecuteDataset(CommandType.Text, strSql).Tables[0];
		}
		
		
		/// <summary>
		/// 获取某一个DataTable
		/// </summary>
		/// <param name="Id">标识</param>
		/// <returns>返回DataTable</returns>
		public static DataTable ZhiYeGet(int Id)
		{
			return SqlDB.ExecuteDataset(CommandType.Text, "SELECT * FROM [ZhiYe] WHERE Id = "+Id+";").Tables[0];
		}
		
		/// <summary>
		/// 获取某一个实体
		/// </summary>
		/// <param name="Id">标识</param>
		/// <returns>返回Entity</returns>
		public static Entity.ZhiYe ZhiYeEntityGet(int Id)
		{
			Entity.ZhiYe info = new Entity.ZhiYe();
			DataTable dt = SqlDB.ExecuteDataset(CommandType.Text, "SELECT * FROM [ZhiYe] WHERE Id = "+Id+";").Tables[0];
			if(dt.Rows.Count >0)
			{
				info.Id = Basic.Utils.StrToInt(dt.Rows[0]["Id"].ToString(),0);
				info.Code = dt.Rows[0]["Code"].ToString();
				info.ZhiYeName = dt.Rows[0]["ZhiYeName"].ToString();
				info.Remark = dt.Rows[0]["Remark"].ToString();
				info.ZhiYeLevel = Basic.Utils.StrToInt(dt.Rows[0]["ZhiYeLevel"].ToString(),0);
				info.ParentId = Basic.Utils.StrToInt(dt.Rows[0]["ParentId"].ToString(),0);
				info.Intro = dt.Rows[0]["Intro"].ToString();
				info.ClickNum = Basic.Utils.StrToInt(dt.Rows[0]["ClickNum"].ToString(),0);
				info.Url = dt.Rows[0]["Url"].ToString();

                return info;
            }
            else
            {
                return null;
            }
		}
		
		/// <summary>
		/// 删除一个值
		/// </summary>
		/// <param name="Id">自增id的值</param>
		/// <returns>删除成功返回ture，否则返回false</returns>
		public static bool ZhiYeDel(int Id)
		{
			int intReturnValue = 0;
			intReturnValue = SqlDB.ExecuteNonQuery(CommandType.Text, "DELETE [ZhiYe]  WHERE Id =  " + Id);
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
		public static DataTable ZhiYeTopGet(string strWhere,int TopNumber)
		{
			string strSql;
			if (!string.IsNullOrEmpty(strWhere.Trim()))
				strSql = "SELECT TOP " + TopNumber.ToString() + " * FROM [ZhiYe] WHERE "+ strWhere +";";
			else
				strSql = "SELECT TOP " + TopNumber.ToString() + " * FROM [ZhiYe] ;";
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
		public static DataTable ZhiYePageList(string strWhere,int PageSize,int PageIndex)
		{
			StringBuilder sbSql = new StringBuilder();
			sbSql.Append("SELECT * FROM ZhiYe");
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
		public static int ZhiYeCount(string strWhere)
		{
			string strSql;
			if (!string.IsNullOrEmpty(strWhere.Trim()))
				strSql = "SELECT COUNT(*) FROM [ZhiYe] WHERE "+ strWhere +";";
			else
				strSql = "SELECT COUNT(*)  FROM [ZhiYe] ;";
			return Basic.Utils.StrToInt(SqlDB.ExecuteScalar(CommandType.Text, strSql).ToString(), 0);
		}
	#endregion
		
	}
}

