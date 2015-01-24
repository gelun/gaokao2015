using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;

using Basic;
using Entity;

namespace DAL
{
	public class SchoolCampus
	{
		#region  SchoolCampus
		/// <summary>
		/// 调用存储过程增加一个
		/// </summary>
		/// <param name="info">实体对象</param>
		/// <returns>正常返回大于 0 的自增id, 0代表重复，否则返回-1</returns>
		public static int SchoolCampusAdd(Entity.SchoolCampus info)
		{
			SqlParameter[] prams = {
				SqlDB.MakeInParam("@SchoolId", SqlDbType.Int, 4, info.SchoolId),
				SqlDB.MakeInParam("@SchoolName", SqlDbType.NVarChar, 200, info.SchoolName),
				SqlDB.MakeInParam("@Campus", SqlDbType.NVarChar, 200, info.Campus),
				SqlDB.MakeInParam("@Pano", SqlDbType.NVarChar, 200, info.Pano),
				SqlDB.MakeInParam("@Heading", SqlDbType.NVarChar, 200, info.Heading),
				SqlDB.MakeInParam("@Pitch", SqlDbType.NVarChar, 200, info.Pitch),
				SqlDB.MakeInParam("@Zoom", SqlDbType.NVarChar, 200, info.Zoom),
				SqlDB.MakeInParam("@Url", SqlDbType.NVarChar, 200, info.Url),
			};
			return Basic.Utils.StrToInt(SqlDB.ExecuteScalar(CommandType.StoredProcedure, "SchoolCampusAdd", prams).ToString(), -1);
		}
		
		/// <summary>
		/// 调用存储过程修改一个
		/// </summary>
		/// <param name="info">实体对象</param>
		/// <returns>更新成功返回ture，否则返回false</returns>
		public static bool SchoolCampusEdit(Entity.SchoolCampus info)
		{
			SqlParameter[] prams = {
				SqlDB.MakeInParam("@Id", SqlDbType.Int, 4, info.Id),
				SqlDB.MakeInParam("@SchoolId", SqlDbType.Int, 4, info.SchoolId),
				SqlDB.MakeInParam("@SchoolName", SqlDbType.NVarChar, 200, info.SchoolName),
				SqlDB.MakeInParam("@Campus", SqlDbType.NVarChar, 200, info.Campus),
				SqlDB.MakeInParam("@Pano", SqlDbType.NVarChar, 200, info.Pano),
				SqlDB.MakeInParam("@Heading", SqlDbType.NVarChar, 200, info.Heading),
				SqlDB.MakeInParam("@Pitch", SqlDbType.NVarChar, 200, info.Pitch),
				SqlDB.MakeInParam("@Zoom", SqlDbType.NVarChar, 200, info.Zoom),
				SqlDB.MakeInParam("@Url", SqlDbType.NVarChar, 200, info.Url),
				};
			int intReturnValue = 0;
			intReturnValue = SqlDB.ExecuteNonQuery(CommandType.StoredProcedure, "SchoolCampusEdit", prams);
			if(intReturnValue == 1)
				return true;
			return false;
		}
		
		/// <summary>
		/// 获取所有的的值
		/// </summary>
		/// <param name="strWhere">条件，可以为空</param>
		/// <returns>返回DataTable</returns>
		public static DataTable SchoolCampusList(string strWhere)
		{
			string strSql;
			if (!string.IsNullOrEmpty(strWhere.Trim()))
				strSql = "SELECT * FROM [SchoolCampus] WHERE "+ strWhere +";";
			else
				strSql = "SELECT * FROM [SchoolCampus] ;";
			return SqlDB.ExecuteDataset(CommandType.Text, strSql).Tables[0];
		}
		
		
		/// <summary>
		/// 获取某一个DataTable
		/// </summary>
		/// <param name="Id">标识</param>
		/// <returns>返回DataTable</returns>
		public static DataTable SchoolCampusGet(int Id)
		{
			return SqlDB.ExecuteDataset(CommandType.Text, "SELECT * FROM [SchoolCampus] WHERE Id = "+Id+";").Tables[0];
		}
		
		/// <summary>
		/// 获取某一个实体
		/// </summary>
		/// <param name="Id">标识</param>
		/// <returns>返回Entity</returns>
		public static Entity.SchoolCampus SchoolCampusEntityGet(int Id)
		{
			Entity.SchoolCampus info = new Entity.SchoolCampus();
			DataTable dt = SqlDB.ExecuteDataset(CommandType.Text, "SELECT * FROM [SchoolCampus] WHERE Id = "+Id+";").Tables[0];
			if(dt.Rows.Count >0)
			{
				info.Id = Basic.Utils.StrToInt(dt.Rows[0]["Id"].ToString(),0);
				info.SchoolId = Basic.Utils.StrToInt(dt.Rows[0]["SchoolId"].ToString(),0);
				info.SchoolName = dt.Rows[0]["SchoolName"].ToString();
                info.Campus = dt.Rows[0]["Campus"].ToString();
                info.Pano = dt.Rows[0]["Pano"].ToString();
                info.Heading = dt.Rows[0]["Heading"].ToString();
                info.Pitch = dt.Rows[0]["Pitch"].ToString();
                info.Zoom = dt.Rows[0]["Zoom"].ToString();
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
		public static bool SchoolCampusDel(int Id)
		{
			int intReturnValue = 0;
			intReturnValue = SqlDB.ExecuteNonQuery(CommandType.Text, "DELETE [SchoolCampus]  WHERE Id =  " + Id);
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
		public static DataTable SchoolCampusTopGet(string strWhere,int TopNumber)
		{
			string strSql;
			if (!string.IsNullOrEmpty(strWhere.Trim()))
				strSql = "SELECT TOP " + TopNumber.ToString() + " * FROM [SchoolCampus] WHERE "+ strWhere +";";
			else
				strSql = "SELECT TOP " + TopNumber.ToString() + " * FROM [SchoolCampus] ;";
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
		public static DataTable SchoolCampusPageList(string strWhere,int PageSize,int PageIndex)
		{
			StringBuilder sbSql = new StringBuilder();
			sbSql.Append("SELECT * FROM SchoolCampus");
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
		public static int SchoolCampusCount(string strWhere)
		{
			string strSql;
			if (!string.IsNullOrEmpty(strWhere.Trim()))
				strSql = "SELECT COUNT(*) FROM [SchoolCampus] WHERE "+ strWhere +";";
			else
				strSql = "SELECT COUNT(*)  FROM [SchoolCampus] ;";
			return Basic.Utils.StrToInt(SqlDB.ExecuteScalar(CommandType.Text, strSql).ToString(), 0);
		}
	#endregion








    }
}

