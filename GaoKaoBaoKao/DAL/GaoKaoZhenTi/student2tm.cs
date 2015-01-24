using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;

using Basic;
using Entity;
using System.Configuration;

namespace DAL
{
	public class student2tm
    {
        private static string strCon = ConfigurationManager.ConnectionStrings["ShiTi_ConnectionString"].ConnectionString;

		#region  student2tm
		/// <summary>
		/// 调用存储过程增加一个
		/// </summary>
		/// <param name="info">实体对象</param>
		/// <returns>正常返回大于 0 的自增id, 0代表重复，否则返回-1</returns>
		public static int student2tmAdd(Entity.student2tm info)
		{
			SqlParameter[] prams = {
				SqlDB.MakeInParam("@StudentId", SqlDbType.Int, 4, info.StudentId),
				SqlDB.MakeInParam("@Type", SqlDbType.Int, 4, info.Type),
				SqlDB.MakeInParam("@TiMuId", SqlDbType.Int, 4, info.TiMuId),
				SqlDB.MakeInParam("@Answer", SqlDbType.NVarChar, 50, info.Answer),
                SqlDB.MakeInParam("@RightAnswer",SqlDbType.NVarChar,50,info.RightAnswer),
				SqlDB.MakeInParam("@Result", SqlDbType.Int, 4, info.Result),
				SqlDB.MakeInParam("@ZuBie", SqlDbType.NVarChar, 50, info.ZuBie),
				SqlDB.MakeInParam("@sx", SqlDbType.NVarChar, 50, info.sx),
			};
			return Basic.Utils.StrToInt(SqlDB.ExecuteScalar(strCon,CommandType.StoredProcedure, "student2tmAdd", prams).ToString(), -1);
		}
		
		/// <summary>
		/// 调用存储过程修改一个
		/// </summary>
		/// <param name="info">实体对象</param>
		/// <returns>更新成功返回ture，否则返回false</returns>
		public static bool student2tmEdit(Entity.student2tm info)
		{
			SqlParameter[] prams = {
				SqlDB.MakeInParam("@Id", SqlDbType.Int, 4, info.Id),
				SqlDB.MakeInParam("@StudentId", SqlDbType.Int, 4, info.StudentId),
				SqlDB.MakeInParam("@Type", SqlDbType.Int, 4, info.Type),
				SqlDB.MakeInParam("@TiMuId", SqlDbType.Int, 4, info.TiMuId),
				SqlDB.MakeInParam("@Answer", SqlDbType.NVarChar, 50, info.Answer),
                SqlDB.MakeInParam("@RightAnswer",SqlDbType.NVarChar,50,info.RightAnswer),
				SqlDB.MakeInParam("@Result", SqlDbType.Int, 4, info.Result),
				SqlDB.MakeInParam("@ZuBie", SqlDbType.NVarChar, 50, info.ZuBie),
				SqlDB.MakeInParam("@sx", SqlDbType.NVarChar, 50, info.sx),
				};
			int intReturnValue = 0;
			intReturnValue = SqlDB.ExecuteNonQuery(strCon,CommandType.StoredProcedure, "student2tmEdit", prams);
			if(intReturnValue == 1)
				return true;
			return false;
		}
		
		/// <summary>
		/// 获取所有的的值
		/// </summary>
		/// <param name="strWhere">条件，可以为空</param>
		/// <returns>返回DataTable</returns>
		public static DataTable student2tmList(string strWhere)
		{
			string strSql;
			if (!string.IsNullOrEmpty(strWhere.Trim()))
				strSql = "SELECT * FROM [student2tm] WHERE "+ strWhere +";";
			else
				strSql = "SELECT * FROM [student2tm] ;";
			return SqlDB.ExecuteDataset(strCon,CommandType.Text, strSql).Tables[0];
		}
		
		
		/// <summary>
		/// 获取某一个DataTable
		/// </summary>
		/// <param name="Id">标识</param>
		/// <returns>返回DataTable</returns>
		public static DataTable student2tmGet(int Id)
		{
			return SqlDB.ExecuteDataset(strCon,CommandType.Text, "SELECT * FROM [student2tm] WHERE Id = "+Id+";").Tables[0];
		}
		
		/// <summary>
		/// 获取某一个实体
		/// </summary>
		/// <param name="Id">标识</param>
		/// <returns>返回Entity</returns>
		public static Entity.student2tm student2tmEntityGet(int Id)
		{
			Entity.student2tm info = new Entity.student2tm();
			DataTable dt = SqlDB.ExecuteDataset(strCon,CommandType.Text, "SELECT * FROM [student2tm] WHERE Id = "+Id+";").Tables[0];
			if(dt.Rows.Count >0)
			{
				info.Id = Basic.Utils.StrToInt(dt.Rows[0]["Id"].ToString(),0);
				info.StudentId = Basic.Utils.StrToInt(dt.Rows[0]["StudentId"].ToString(),0);
				info.Type = Basic.Utils.StrToInt(dt.Rows[0]["Type"].ToString(),0);
				info.TiMuId = Basic.Utils.StrToInt(dt.Rows[0]["TiMuId"].ToString(),0);
                info.Answer = dt.Rows[0]["Answer"].ToString();
                info.RightAnswer = dt.Rows[0]["RightAnswer"].ToString();
				info.Result = Basic.Utils.StrToInt(dt.Rows[0]["Result"].ToString(),0);
                info.ZuBie = dt.Rows[0]["ZuBie"].ToString();
                info.sx = Basic.Utils.StrToInt(dt.Rows[0]["sx"].ToString(), 0);
			}
			return info;
		}
		
		/// <summary>
		/// 删除一个值
		/// </summary>
		/// <param name="Id">自增id的值</param>
		/// <returns>删除成功返回ture，否则返回false</returns>
		public static bool student2tmDel(int Id)
		{
			int intReturnValue = 0;
			intReturnValue = SqlDB.ExecuteNonQuery(strCon,CommandType.Text, "DELETE [student2tm]  WHERE Id =  " + Id);
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
		public static DataTable student2tmTopGet(string strWhere,int TopNumber)
		{
			string strSql;
			if (!string.IsNullOrEmpty(strWhere.Trim()))
				strSql = "SELECT TOP " + TopNumber.ToString() + " * FROM [student2tm] WHERE "+ strWhere +";";
			else
				strSql = "SELECT TOP " + TopNumber.ToString() + " * FROM [student2tm] ;";
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
		public static DataTable student2tmPageList(string strWhere,int PageSize,int PageIndex)
		{
			StringBuilder sbSql = new StringBuilder();
			sbSql.Append("SELECT * FROM student2tm");
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
		public static int student2tmCount(string strWhere)
		{
			string strSql;
			if (!string.IsNullOrEmpty(strWhere.Trim()))
				strSql = "SELECT COUNT(*) FROM [student2tm] WHERE "+ strWhere +";";
			else
				strSql = "SELECT COUNT(*)  FROM [student2tm] ;";
			return Basic.Utils.StrToInt(SqlDB.ExecuteScalar(strCon,CommandType.Text, strSql).ToString(), 0);
		}
	#endregion


        public static Entity.student2tm DataTable { get; set; }
    }
}

