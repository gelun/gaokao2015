using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;

using Basic;
using Entity;

namespace DAL
{
	public class Join_TestWLResults
    {
        private static string strCon = System.Configuration.ConfigurationManager.ConnectionStrings["Join_ConnectionString"].ConnectionString;
		#region  Join_TestWLResults
		/// <summary>
		/// 调用存储过程增加一个
		/// </summary>
		/// <param name="info">实体对象</param>
		/// <returns>正常返回大于 0 的自增id, 0代表重复，否则返回-1</returns>
		public static int Join_TestWLResultsAdd(Entity.Join_TestWLResults info)
		{
			SqlParameter[] prams = {
				SqlDB.MakeInParam("@UserId", SqlDbType.Int, 4, info.UserId),
				SqlDB.MakeInParam("@WK", SqlDbType.Int, 4, info.WK),
				SqlDB.MakeInParam("@LK", SqlDbType.Int, 4, info.LK)
				
			};
			return Basic.Utils.StrToInt(SqlDB.ExecuteScalar(strCon,CommandType.StoredProcedure, "Join_TestWLResultsAdd", prams).ToString(), -1);
		}
		
		/// <summary>
		/// 调用存储过程修改一个
		/// </summary>
		/// <param name="info">实体对象</param>
		/// <returns>更新成功返回ture，否则返回false</returns>
		public static bool Join_TestWLResultsEdit(Entity.Join_TestWLResults info)
		{
			SqlParameter[] prams = {
				SqlDB.MakeInParam("@WlId", SqlDbType.Int, 4, info.WlId),
				SqlDB.MakeInParam("@UserId", SqlDbType.Int, 4, info.UserId),
				SqlDB.MakeInParam("@WK", SqlDbType.Int, 4, info.WK),
				SqlDB.MakeInParam("@LK", SqlDbType.Int, 4, info.LK)
			
				};
			int intReturnValue = 0;
			intReturnValue = SqlDB.ExecuteNonQuery(strCon,CommandType.StoredProcedure, "Join_TestWLResultsEdit", prams);
			if(intReturnValue == 1)
				return true;
			return false;
		}
		
        ///// <summary>
        ///// 暂停该值
        ///// </summary>
        ///// <param name="WlId">自增id的值</param>
        ///// <returns>暂停成功返回ture，否则返回false</returns>
        //public static bool Join_TestWLResultsPause(Entity.Join_TestWLResults info)
        //{
        //    int intReturnValue = 0;
        //    intReturnValue = SqlDB.ExecuteNonQuery(strCon,CommandType.Text, "UPDATE [Join_TestWLResults] SET IsPause = "+  info.IsPause +"  WHERE WlId =  " +  info.WlId);
        //    if(intReturnValue == 1)
        //        return true;
        //    return false;
        //}
		
		/// <summary>
		/// 获取所有的的值
		/// </summary>
		/// <param name="strWhere">条件，可以为空</param>
		/// <returns>返回DataTable</returns>
		public static DataTable Join_TestWLResultsList(string strWhere)
		{
			string strSql;
			if (!string.IsNullOrEmpty(strWhere.Trim()))
				strSql = "SELECT * FROM [Join_TestWLResults] WHERE "+ strWhere +";";
			else
				strSql = "SELECT * FROM [Join_TestWLResults] ;";
			return SqlDB.ExecuteDataset(strCon,CommandType.Text, strSql).Tables[0];
		}
		
		
		/// <summary>
		/// 获取某一个DataTable
		/// </summary>
		/// <param name="WlId">标识</param>
		/// <returns>返回DataTable</returns>
		public static DataTable Join_TestWLResultsGet(int WlId)
		{
			return SqlDB.ExecuteDataset(strCon,CommandType.Text, "SELECT * FROM [Join_TestWLResults] WHERE WlId = "+WlId+";").Tables[0];
		}
		
		/// <summary>
		/// 获取某一个实体
		/// </summary>
		/// <param name="WlId">标识</param>
		/// <returns>返回Entity</returns>
		public static Entity.Join_TestWLResults Join_TestWLResultsEntityGet(int WlId)
		{
			Entity.Join_TestWLResults info = new Entity.Join_TestWLResults();
			DataTable dt = SqlDB.ExecuteDataset(strCon,CommandType.Text, "SELECT * FROM [Join_TestWLResults] WHERE WlId = "+WlId+";").Tables[0];
			if(dt.Rows.Count >0)
			{
				info.WlId = Basic.Utils.StrToInt(dt.Rows[0]["WlId"].ToString(),0);
				info.UserId = Basic.Utils.StrToInt(dt.Rows[0]["UserId"].ToString(),0);
				info.WK = Basic.Utils.StrToInt(dt.Rows[0]["WK"].ToString(),0);
				info.LK = Basic.Utils.StrToInt(dt.Rows[0]["LK"].ToString(),0);
			}
			return info;
		}

        public static Entity.Join_TestWLResults Join_TestWLResultsEntityGetByUserId(int UserId)
        {
            Entity.Join_TestWLResults info = new Entity.Join_TestWLResults();
            DataTable dt = SqlDB.ExecuteDataset(strCon, CommandType.Text, "SELECT * FROM [Join_TestWLResults] WHERE UserId = " + UserId + " ORDER BY WlId DESC").Tables[0];
            if (dt.Rows.Count > 0)
            {
                info.WlId = Basic.Utils.StrToInt(dt.Rows[0]["WlId"].ToString(), 0);
                info.UserId = Basic.Utils.StrToInt(dt.Rows[0]["UserId"].ToString(), 0);
                info.WK = Basic.Utils.StrToInt(dt.Rows[0]["WK"].ToString(), 0);
                info.LK = Basic.Utils.StrToInt(dt.Rows[0]["LK"].ToString(), 0);
            }
            return info;
        }
		
		/// <summary>
		/// 删除一个值
		/// </summary>
		/// <param name="WlId">自增id的值</param>
		/// <returns>删除成功返回ture，否则返回false</returns>
		public static bool Join_TestWLResultsDel(int WlId)
		{
			int intReturnValue = 0;
			intReturnValue = SqlDB.ExecuteNonQuery(strCon,CommandType.Text, "DELETE [Join_TestWLResults]  WHERE WlId =  " + WlId);
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
		public static DataTable Join_TestWLResultsTopGet(string strWhere,int TopNumber)
		{
			string strSql;
			if (!string.IsNullOrEmpty(strWhere.Trim()))
				strSql = "SELECT TOP " + TopNumber.ToString() + " * FROM [Join_TestWLResults] WHERE "+ strWhere +";";
			else
				strSql = "SELECT TOP " + TopNumber.ToString() + " * FROM [Join_TestWLResults] ;";
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
		public static DataTable Join_TestWLResultsPageList(string strWhere,int PageSize,int PageIndex)
		{
			StringBuilder sbSql = new StringBuilder();
			sbSql.Append("SELECT * FROM Join_TestWLResults");
			if (!string.IsNullOrEmpty(strWhere.Trim()))
			{
				sbSql.Append(" WHERE " + strWhere);
			}
			sbSql.Append(" ORDER BY WlId DESC");
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
		public static int Join_TestWLResultsCount(string strWhere)
		{
			string strSql;
			if (!string.IsNullOrEmpty(strWhere.Trim()))
				strSql = "SELECT COUNT(*) FROM [Join_TestWLResults] WHERE "+ strWhere +";";
			else
				strSql = "SELECT COUNT(*)  FROM [Join_TestWLResults] ;";
			return Basic.Utils.StrToInt(SqlDB.ExecuteScalar(strCon,CommandType.Text, strSql).ToString(), 0);
		}
	#endregion
		
	}
}

