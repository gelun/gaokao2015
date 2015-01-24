using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Configuration;

using Basic;
using Entity;

namespace DAL
{
	public class Province
	{
		#region  Province
		/// <summary>
		/// 调用存储过程增加一个
		/// </summary>
		/// <param name="info">实体对象</param>
		/// <returns>正常返回大于 0 的自增id, 0代表重复，否则返回-1</returns>
		public static int ProvinceAdd(Entity.Province info)
		{
			SqlParameter[] prams = {
				SqlDB.MakeInParam("@ProvinceName", SqlDbType.NVarChar, 50, info.ProvinceName),
				SqlDB.MakeInParam("@ProvincePinYin", SqlDbType.NVarChar, 50, info.ProvincePinYin),
				SqlDB.MakeInParam("@ProvinceCode", SqlDbType.NVarChar, 50, info.ProvinceCode),
				SqlDB.MakeInParam("@AdminCode", SqlDbType.NVarChar, 50, info.AdminCode),
			};
			return Basic.Utils.StrToInt(SqlDB.ExecuteScalar(CommandType.StoredProcedure, "ProvinceAdd", prams).ToString(), -1);
		}
		
		/// <summary>
		/// 调用存储过程修改一个
		/// </summary>
		/// <param name="info">实体对象</param>
		/// <returns>更新成功返回ture，否则返回false</returns>
		public static bool ProvinceEdit(Entity.Province info)
		{
			SqlParameter[] prams = {
				SqlDB.MakeInParam("@ProvinceID", SqlDbType.Int, 4, info.ProvinceID),
				SqlDB.MakeInParam("@ProvinceName", SqlDbType.NVarChar, 50, info.ProvinceName),
				SqlDB.MakeInParam("@ProvincePinYin", SqlDbType.NVarChar, 50, info.ProvincePinYin),
				SqlDB.MakeInParam("@ProvinceCode", SqlDbType.NVarChar, 50, info.ProvinceCode),
				SqlDB.MakeInParam("@AdminCode", SqlDbType.NVarChar, 50, info.AdminCode),
				};
			int intReturnValue = 0;
			intReturnValue = SqlDB.ExecuteNonQuery(CommandType.StoredProcedure, "ProvinceEdit", prams);
			if(intReturnValue == 1)
				return true;
			return false;
		}
		
		/// <summary>
		/// 获取所有的的值
		/// </summary>
		/// <param name="strWhere">条件，可以为空</param>
		/// <returns>返回DataTable</returns>
		public static DataTable ProvinceList(string strWhere)
		{
			string strSql;
			if (!string.IsNullOrEmpty(strWhere.Trim()))
				strSql = "SELECT * FROM [Province] WHERE "+ strWhere +";";
			else
				strSql = "SELECT * FROM [Province] ;";
			return SqlDB.ExecuteDataset(CommandType.Text, strSql).Tables[0];
		}
		
		
		/// <summary>
		/// 获取某一个DataTable
		/// </summary>
		/// <param name="ProvinceID">标识</param>
		/// <returns>返回DataTable</returns>
		public static DataTable ProvinceGet(int ProvinceID)
		{
			return SqlDB.ExecuteDataset(CommandType.Text, "SELECT * FROM [Province] WHERE ProvinceID = "+ProvinceID+";").Tables[0];
		}
		
		/// <summary>
		/// 获取某一个实体
		/// </summary>
		/// <param name="ProvinceID">标识</param>
		/// <returns>返回Entity</returns>
		public static Entity.Province ProvinceEntityGet(int ProvinceID)
		{
			Entity.Province info = new Entity.Province();
			DataTable dt = SqlDB.ExecuteDataset(CommandType.Text, "SELECT * FROM [Province] WHERE ProvinceID = "+ProvinceID+";").Tables[0];
			if(dt.Rows.Count >0)
			{
				info.ProvinceID = Basic.Utils.StrToInt(dt.Rows[0]["ProvinceID"].ToString(),0);
				info.ProvinceName = dt.Rows[0]["ProvinceName"].ToString();

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
		/// <param name="ProvinceID">自增id的值</param>
		/// <returns>删除成功返回ture，否则返回false</returns>
		public static bool ProvinceDel(int ProvinceID)
		{
			int intReturnValue = 0;
			intReturnValue = SqlDB.ExecuteNonQuery(CommandType.Text, "DELETE [Province]  WHERE ProvinceID =  " + ProvinceID);
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
		public static DataTable ProvinceTopGet(string strWhere,int TopNumber)
		{
			string strSql;
			if (!string.IsNullOrEmpty(strWhere.Trim()))
				strSql = "SELECT TOP " + TopNumber.ToString() + " * FROM [Province] WHERE "+ strWhere +";";
			else
				strSql = "SELECT TOP " + TopNumber.ToString() + " * FROM [Province] ;";
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
		public static DataTable ProvincePageList(string strWhere,int PageSize,int PageIndex)
		{
			StringBuilder sbSql = new StringBuilder();
			sbSql.Append("SELECT * FROM Province");
			if (!string.IsNullOrEmpty(strWhere.Trim()))
			{
				sbSql.Append(" WHERE " + strWhere);
			}
			sbSql.Append(" ORDER BY ProvinceID DESC");
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
		public static int ProvinceCount(string strWhere)
		{
			string strSql;
			if (!string.IsNullOrEmpty(strWhere.Trim()))
				strSql = "SELECT COUNT(*) FROM [Province] WHERE "+ strWhere +";";
			else
				strSql = "SELECT COUNT(*)  FROM [Province] ;";
			return Basic.Utils.StrToInt(SqlDB.ExecuteScalar(CommandType.Text, strSql).ToString(), 0);
		}
	#endregion
		
	}
}

