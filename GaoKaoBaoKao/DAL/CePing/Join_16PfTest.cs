using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;

using Basic;
using Entity;

namespace DAL
{
	public class Join_16PfTest
    {
        private static string strCon = System.Configuration.ConfigurationManager.ConnectionStrings["Join_ConnectionString"].ConnectionString;
		#region  Join_16PfTest
		/// <summary>
		/// 调用存储过程增加一个
		/// </summary>
		/// <param name="info">实体对象</param>
		/// <returns>正常返回大于 0 的自增id, 0代表重复，否则返回-1</returns>
		public static int Join_16PfTestAdd(Entity.Join_16PfTest info)
		{
			SqlParameter[] prams = {
				SqlDB.MakeInParam("@TestNumber", SqlDbType.Int, 4, info.TestNumber),
				SqlDB.MakeInParam("@TestTitle", SqlDbType.NVarChar, 500, info.TestTitle),
			};
			return Basic.Utils.StrToInt(SqlDB.ExecuteScalar(strCon,CommandType.StoredProcedure, "Join_16PfTestAdd", prams).ToString(), -1);
		}
		
		/// <summary>
		/// 调用存储过程修改一个
		/// </summary>
		/// <param name="info">实体对象</param>
		/// <returns>更新成功返回ture，否则返回false</returns>
		public static bool Join_16PfTestEdit(Entity.Join_16PfTest info)
		{
			SqlParameter[] prams = {
				SqlDB.MakeInParam("@TestId", SqlDbType.Int, 4, info.TestId),
				SqlDB.MakeInParam("@TestNumber", SqlDbType.Int, 4, info.TestNumber),
				SqlDB.MakeInParam("@TestTitle", SqlDbType.NVarChar, 500, info.TestTitle),
				};
			int intReturnValue = 0;
			intReturnValue = SqlDB.ExecuteNonQuery(strCon,CommandType.StoredProcedure, "Join_16PfTestEdit", prams);
			if(intReturnValue == 1)
				return true;
			return false;
		}
		
		
		
		/// <summary>
		/// 获取所有的的值
		/// </summary>
		/// <param name="strWhere">条件，可以为空</param>
		/// <returns>返回DataTable</returns>
		public static DataTable Join_16PfTestList(string strWhere)
		{
			string strSql;
			if (!string.IsNullOrEmpty(strWhere.Trim()))
                strSql = "SELECT * FROM [Join_16PfTest] WHERE " + strWhere + ";";               // left join Join_16PfAnswer  a on a.TestId=T.TestNumber 
			else
				strSql = "SELECT * FROM [Join_16PfTest] ;";
			return SqlDB.ExecuteDataset(strCon,CommandType.Text, strSql).Tables[0];
		}
		
		
		/// <summary>
		/// 获取某一个DataTable
		/// </summary>
		/// <param name="TestId">标识</param>
		/// <returns>返回DataTable</returns>
		public static DataTable Join_16PfTestGet(int TestId)
		{
			return SqlDB.ExecuteDataset(strCon,CommandType.Text, "SELECT * FROM [Join_16PfTest] WHERE TestId = "+TestId+";").Tables[0];
		}
		
		/// <summary>
		/// 获取某一个实体
		/// </summary>
		/// <param name="TestId">标识</param>
		/// <returns>返回Entity</returns>
		public static Entity.Join_16PfTest Join_16PfTestEntityGet(int TestId)
		{
			Entity.Join_16PfTest info = new Entity.Join_16PfTest();
			DataTable dt = SqlDB.ExecuteDataset(strCon,CommandType.Text, "SELECT * FROM [Join_16PfTest] WHERE TestId = "+TestId+";").Tables[0];
			if(dt.Rows.Count >0)
			{
				info.TestId = Basic.Utils.StrToInt(dt.Rows[0]["TestId"].ToString(),0);
				info.TestNumber = Basic.Utils.StrToInt(dt.Rows[0]["TestNumber"].ToString(),0);
				info.TestTitle = dt.Rows[0]["TestTitle"].ToString();
			}
			return info;
		}
		
		/// <summary>
		/// 删除一个值
		/// </summary>
		/// <param name="TestId">自增id的值</param>
		/// <returns>删除成功返回ture，否则返回false</returns>
		public static bool Join_16PfTestDel(int TestId)
		{
			int intReturnValue = 0;
			intReturnValue = SqlDB.ExecuteNonQuery(strCon,CommandType.Text, "DELETE [Join_16PfTest]  WHERE TestId =  " + TestId);
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
		public static DataTable Join_16PfTestTopGet(string strWhere,int TopNumber)
		{
			string strSql;
			if (!string.IsNullOrEmpty(strWhere.Trim()))
				strSql = "SELECT TOP " + TopNumber.ToString() + " * FROM [Join_16PfTest] WHERE "+ strWhere +";";
			else
				strSql = "SELECT TOP " + TopNumber.ToString() + " * FROM [Join_16PfTest] ;";
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
		public static DataTable Join_16PfTestPageList(string strWhere,int PageSize,int PageIndex)
		{
			StringBuilder sbSql = new StringBuilder();
			sbSql.Append("SELECT * FROM Join_16PfTest");
			if (!string.IsNullOrEmpty(strWhere.Trim()))
			{
				sbSql.Append(" WHERE " + strWhere);
			}
            sbSql.Append(" ORDER BY TestNumber asc");
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
		public static int Join_16PfTestCount(string strWhere)
		{
			string strSql;
			if (!string.IsNullOrEmpty(strWhere.Trim()))
				strSql = "SELECT COUNT(*) FROM [Join_16PfTest] WHERE "+ strWhere +";";
			else
				strSql = "SELECT COUNT(*)  FROM [Join_16PfTest] ;";
			return Basic.Utils.StrToInt(SqlDB.ExecuteScalar(strCon,CommandType.Text, strSql).ToString(), 0);
		}
	#endregion
		
	}
}

