using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;

using Basic;
using Entity;

namespace DAL
{
	public class ShiPin
	{
		#region  ShiPin
		/// <summary>
		/// 调用存储过程增加一个
		/// </summary>
		/// <param name="info">实体对象</param>
		/// <returns>正常返回大于 0 的自增id, 0代表重复，否则返回-1</returns>
		public static int ShiPinAdd(Entity.ShiPin info)
		{
			SqlParameter[] prams = {
				SqlDB.MakeInParam("@Title", SqlDbType.NVarChar, 200, info.Title),
				SqlDB.MakeInParam("@Content", SqlDbType.NText, 0, info.Content),
				SqlDB.MakeInParam("@Video", SqlDbType.NText, 0, info.Video),
				SqlDB.MakeInParam("@TypeName", SqlDbType.NVarChar, 100, info.TypeName),
				SqlDB.MakeInParam("@TypeId", SqlDbType.Int, 4, info.TypeId),
				SqlDB.MakeInParam("@AddTime", SqlDbType.DateTime, 8, info.AddTime),
				SqlDB.MakeInParam("@IsPause", SqlDbType.Int, 4, info.IsPause),
			};
			return Basic.Utils.StrToInt(SqlDB.ExecuteScalar(CommandType.StoredProcedure, "ShiPinAdd", prams).ToString(), -1);
		}
		
		/// <summary>
		/// 调用存储过程修改一个
		/// </summary>
		/// <param name="info">实体对象</param>
		/// <returns>更新成功返回ture，否则返回false</returns>
		public static bool ShiPinEdit(Entity.ShiPin info)
		{
			SqlParameter[] prams = {
				SqlDB.MakeInParam("@Id", SqlDbType.Int, 4, info.Id),
				SqlDB.MakeInParam("@Title", SqlDbType.NVarChar, 200, info.Title),
				SqlDB.MakeInParam("@Content", SqlDbType.NText, 0, info.Content),
				SqlDB.MakeInParam("@Video", SqlDbType.NText, 0, info.Video),
				SqlDB.MakeInParam("@TypeName", SqlDbType.NVarChar, 100, info.TypeName),
				SqlDB.MakeInParam("@TypeId", SqlDbType.Int, 4, info.TypeId),
				SqlDB.MakeInParam("@AddTime", SqlDbType.DateTime, 8, info.AddTime),
				SqlDB.MakeInParam("@IsPause", SqlDbType.Int, 4, info.IsPause),
				};
			int intReturnValue = 0;
			intReturnValue = SqlDB.ExecuteNonQuery(CommandType.StoredProcedure, "ShiPinEdit", prams);
			if(intReturnValue == 1)
				return true;
			return false;
		}
		
		/// <summary>
		/// 暂停该值
		/// </summary>
		/// <param name="Id">自增id的值</param>
		/// <returns>暂停成功返回ture，否则返回false</returns>
		public static bool ShiPinPause(Entity.ShiPin info)
		{
			int intReturnValue = 0;
			intReturnValue = SqlDB.ExecuteNonQuery(CommandType.Text, "UPDATE [ShiPin] SET IsPause = "+  info.IsPause +"  WHERE Id =  " +  info.Id);
			if(intReturnValue == 1)
				return true;
			return false;
		}
		
		/// <summary>
		/// 获取所有的的值
		/// </summary>
		/// <param name="strWhere">条件，可以为空</param>
		/// <returns>返回DataTable</returns>
		public static DataTable ShiPinList(string strWhere)
		{
			string strSql;
			if (!string.IsNullOrEmpty(strWhere.Trim()))
				strSql = "SELECT * FROM [ShiPin] WHERE "+ strWhere +";";
			else
				strSql = "SELECT * FROM [ShiPin] ;";
			return SqlDB.ExecuteDataset(CommandType.Text, strSql).Tables[0];
		}
		
		
		/// <summary>
		/// 获取某一个DataTable
		/// </summary>
		/// <param name="Id">标识</param>
		/// <returns>返回DataTable</returns>
		public static DataTable ShiPinGet(int Id)
		{
			return SqlDB.ExecuteDataset(CommandType.Text, "SELECT * FROM [ShiPin] WHERE Id = "+Id+";").Tables[0];
		}
		
		/// <summary>
		/// 获取某一个实体
		/// </summary>
		/// <param name="Id">标识</param>
		/// <returns>返回Entity</returns>
        public static Entity.ShiPin ShiPinEntityGet(int Id)
        {
            Entity.ShiPin info = new Entity.ShiPin();
            DataTable dt = SqlDB.ExecuteDataset(CommandType.Text, "SELECT * FROM [ShiPin] WHERE Id = " + Id + ";").Tables[0];
            if (dt.Rows.Count > 0)
            {
                info.Id = Basic.Utils.StrToInt(dt.Rows[0]["Id"].ToString(), 0);
                info.Title = dt.Rows[0]["Title"].ToString();
                info.Content = dt.Rows[0]["Content"].ToString();
                info.Video = dt.Rows[0]["Video"].ToString();
                info.TypeName = dt.Rows[0]["TypeName"].ToString();
                info.TypeId = Basic.Utils.StrToInt(dt.Rows[0]["TypeId"].ToString(), 0);
                info.IsPause = Basic.Utils.StrToInt(dt.Rows[0]["IsPause"].ToString(), 0);
                info.AddTime = Basic.Utils.StrToDateTime(dt.Rows[0]["AddTime"].ToString());
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
		public static bool ShiPinDel(int Id)
		{
			int intReturnValue = 0;
			intReturnValue = SqlDB.ExecuteNonQuery(CommandType.Text, "DELETE [ShiPin]  WHERE Id =  " + Id);
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
		public static DataTable ShiPinTopGet(string strWhere,int TopNumber)
		{
			string strSql;
			if (!string.IsNullOrEmpty(strWhere.Trim()))
				strSql = "SELECT TOP " + TopNumber.ToString() + " * FROM [ShiPin] WHERE "+ strWhere +";";
			else
				strSql = "SELECT TOP " + TopNumber.ToString() + " * FROM [ShiPin] ;";
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
		public static DataTable ShiPinPageList(string strWhere,int PageSize,int PageIndex)
		{
			StringBuilder sbSql = new StringBuilder();
			sbSql.Append("SELECT * FROM ShiPin");
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
		public static int ShiPinCount(string strWhere)
		{
			string strSql;
			if (!string.IsNullOrEmpty(strWhere.Trim()))
				strSql = "SELECT COUNT(*) FROM [ShiPin] WHERE "+ strWhere +";";
			else
				strSql = "SELECT COUNT(*)  FROM [ShiPin] ;";
			return Basic.Utils.StrToInt(SqlDB.ExecuteScalar(CommandType.Text, strSql).ToString(), 0);
		}
	#endregion
		
	}
}

