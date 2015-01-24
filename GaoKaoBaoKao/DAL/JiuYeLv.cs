using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;

using Basic;
using Entity;

namespace DAL
{
	public class JiuYeLv
	{
		#region  JiuYeLv
		/// <summary>
		/// 调用存储过程增加一个
		/// </summary>
		/// <param name="info">实体对象</param>
		/// <returns>正常返回大于 0 的自增id, 0代表重复，否则返回-1</returns>
		public static int JiuYeLvAdd(Entity.GKJiuYeLv info)
		{
			SqlParameter[] prams = {
				SqlDB.MakeInParam("@Year", SqlDbType.Int, 4, info.Year),
				SqlDB.MakeInParam("@IsBen", SqlDbType.Int, 4, info.IsBen),
				SqlDB.MakeInParam("@ZhuanYeId", SqlDbType.Int, 4, info.ZhuanYeId),
				SqlDB.MakeInParam("@ZhuanYeName", SqlDbType.NVarChar, 200, info.ZhuanYeName),
				SqlDB.MakeInParam("@JiuYeLv", SqlDbType.Int, 4, info.JiuYeLv),
				SqlDB.MakeInParam("@JiuYeLvA", SqlDbType.NVarChar, 20, info.JiuYeLvA),
				SqlDB.MakeInParam("@JiuYeLv211", SqlDbType.Int, 4, info.JiuYeLv211),
				SqlDB.MakeInParam("@JiuYeLvA211", SqlDbType.NVarChar, 20, info.JiuYeLvA211),
				SqlDB.MakeInParam("@CentralCollegeJiuYeLv", SqlDbType.Int, 4, info.CentralCollegeJiuYeLv),
				SqlDB.MakeInParam("@CentralCollegeJiuYeLvA", SqlDbType.NVarChar, 20, info.CentralCollegeJiuYeLvA),
				SqlDB.MakeInParam("@LocalCollegeJiuYeLv", SqlDbType.Int, 4, info.LocalCollegeJiuYeLv),
				SqlDB.MakeInParam("@LocalCollegeJiuYeLvA", SqlDbType.NVarChar, 20, info.LocalCollegeJiuYeLvA),
				SqlDB.MakeInParam("@BiYeShengGuiMo", SqlDbType.NVarChar, 200, info.BiYeShengGuiMo),
				SqlDB.MakeInParam("@XueKeMenLei", SqlDbType.Int, 4, info.XueKeMenLei),
				SqlDB.MakeInParam("@XueKeMenLeiName", SqlDbType.NVarChar, 50, info.XueKeMenLeiName),
				SqlDB.MakeInParam("@ZhuanYeLei", SqlDbType.Int, 4, info.ZhuanYeLei),
				SqlDB.MakeInParam("@ZhuanYeLeiName", SqlDbType.NVarChar, 50, info.ZhuanYeLeiName),
			};
			return Basic.Utils.StrToInt(SqlDB.ExecuteScalar(CommandType.StoredProcedure, "JiuYeLvAdd", prams).ToString(), -1);
		}
		
		/// <summary>
		/// 调用存储过程修改一个
		/// </summary>
		/// <param name="info">实体对象</param>
		/// <returns>更新成功返回ture，否则返回false</returns>
		public static bool JiuYeLvEdit(Entity.GKJiuYeLv info)
		{
			SqlParameter[] prams = {
				SqlDB.MakeInParam("@Id", SqlDbType.Int, 4, info.Id),
				SqlDB.MakeInParam("@Year", SqlDbType.Int, 4, info.Year),
				SqlDB.MakeInParam("@IsBen", SqlDbType.Int, 4, info.IsBen),
				SqlDB.MakeInParam("@ZhuanYeId", SqlDbType.Int, 4, info.ZhuanYeId),
				SqlDB.MakeInParam("@ZhuanYeName", SqlDbType.NVarChar, 200, info.ZhuanYeName),
				SqlDB.MakeInParam("@JiuYeLv", SqlDbType.Int, 4, info.JiuYeLv),
				SqlDB.MakeInParam("@JiuYeLvA", SqlDbType.NVarChar, 20, info.JiuYeLvA),
				SqlDB.MakeInParam("@JiuYeLv211", SqlDbType.Int, 4, info.JiuYeLv211),
				SqlDB.MakeInParam("@JiuYeLvA211", SqlDbType.NVarChar, 20, info.JiuYeLvA211),
				SqlDB.MakeInParam("@CentralCollegeJiuYeLv", SqlDbType.Int, 4, info.CentralCollegeJiuYeLv),
				SqlDB.MakeInParam("@CentralCollegeJiuYeLvA", SqlDbType.NVarChar, 20, info.CentralCollegeJiuYeLvA),
				SqlDB.MakeInParam("@LocalCollegeJiuYeLv", SqlDbType.Int, 4, info.LocalCollegeJiuYeLv),
				SqlDB.MakeInParam("@LocalCollegeJiuYeLvA", SqlDbType.NVarChar, 20, info.LocalCollegeJiuYeLvA),
				SqlDB.MakeInParam("@BiYeShengGuiMo", SqlDbType.NVarChar, 200, info.BiYeShengGuiMo),
				SqlDB.MakeInParam("@XueKeMenLei", SqlDbType.Int, 4, info.XueKeMenLei),
				SqlDB.MakeInParam("@XueKeMenLeiName", SqlDbType.NVarChar, 50, info.XueKeMenLeiName),
				SqlDB.MakeInParam("@ZhuanYeLei", SqlDbType.Int, 4, info.ZhuanYeLei),
				SqlDB.MakeInParam("@ZhuanYeLeiName", SqlDbType.NVarChar, 50, info.ZhuanYeLeiName),
				};
			int intReturnValue = 0;
			intReturnValue = SqlDB.ExecuteNonQuery(CommandType.StoredProcedure, "JiuYeLvEdit", prams);
			if(intReturnValue == 1)
				return true;
			return false;
		}
		
		/// <summary>
		/// 获取所有的的值
		/// </summary>
		/// <param name="strWhere">条件，可以为空</param>
		/// <returns>返回DataTable</returns>
		public static DataTable JiuYeLvList(string strWhere)
		{
			string strSql;
			if (!string.IsNullOrEmpty(strWhere.Trim()))
				strSql = "SELECT * FROM [JiuYeLv] WHERE "+ strWhere +";";
			else
				strSql = "SELECT * FROM [JiuYeLv] ;";
			return SqlDB.ExecuteDataset(CommandType.Text, strSql).Tables[0];
		}
		
		
		/// <summary>
		/// 获取某一个DataTable
		/// </summary>
		/// <param name="Id">标识</param>
		/// <returns>返回DataTable</returns>
		public static DataTable JiuYeLvGet(int Id)
		{
			return SqlDB.ExecuteDataset(CommandType.Text, "SELECT * FROM [JiuYeLv] WHERE Id = "+Id+";").Tables[0];
		}
		
		/// <summary>
		/// 获取某一个实体
		/// </summary>
		/// <param name="Id">标识</param>
		/// <returns>返回Entity</returns>
		public static Entity.GKJiuYeLv JiuYeLvEntityGet(int Id)
		{
			Entity.GKJiuYeLv info = new Entity.GKJiuYeLv();
			DataTable dt = SqlDB.ExecuteDataset(CommandType.Text, "SELECT * FROM [JiuYeLv] WHERE Id = "+Id+";").Tables[0];
			if(dt.Rows.Count >0)
			{
				info.Id = Basic.Utils.StrToInt(dt.Rows[0]["Id"].ToString(),0);
				info.Year = Basic.Utils.StrToInt(dt.Rows[0]["Year"].ToString(),0);
				info.IsBen = Basic.Utils.StrToInt(dt.Rows[0]["IsBen"].ToString(),0);
				info.ZhuanYeId = Basic.Utils.StrToInt(dt.Rows[0]["ZhuanYeId"].ToString(),0);
				info.ZhuanYeName = dt.Rows[0]["ZhuanYeName"].ToString();
				info.JiuYeLv = Basic.Utils.StrToInt(dt.Rows[0]["JiuYeLv"].ToString(),0);
				info.JiuYeLvA = dt.Rows[0]["JiuYeLvA"].ToString();
				info.JiuYeLv211 = Basic.Utils.StrToInt(dt.Rows[0]["JiuYeLv211"].ToString(),0);
				info.JiuYeLvA211 = dt.Rows[0]["JiuYeLvA211"].ToString();
				info.CentralCollegeJiuYeLv = Basic.Utils.StrToInt(dt.Rows[0]["CentralCollegeJiuYeLv"].ToString(),0);
				info.CentralCollegeJiuYeLvA = dt.Rows[0]["CentralCollegeJiuYeLvA"].ToString();
				info.LocalCollegeJiuYeLv = Basic.Utils.StrToInt(dt.Rows[0]["LocalCollegeJiuYeLv"].ToString(),0);
				info.LocalCollegeJiuYeLvA = dt.Rows[0]["LocalCollegeJiuYeLvA"].ToString();
				info.BiYeShengGuiMo = dt.Rows[0]["BiYeShengGuiMo"].ToString();
				info.XueKeMenLei = Basic.Utils.StrToInt(dt.Rows[0]["XueKeMenLei"].ToString(),0);
				info.XueKeMenLeiName = dt.Rows[0]["XueKeMenLeiName"].ToString();
				info.ZhuanYeLei = Basic.Utils.StrToInt(dt.Rows[0]["ZhuanYeLei"].ToString(),0);
				info.ZhuanYeLeiName = dt.Rows[0]["ZhuanYeLeiName"].ToString();
			}
			return info;
		}
		
		/// <summary>
		/// 删除一个值
		/// </summary>
		/// <param name="Id">自增id的值</param>
		/// <returns>删除成功返回ture，否则返回false</returns>
		public static bool JiuYeLvDel(int Id)
		{
			int intReturnValue = 0;
			intReturnValue = SqlDB.ExecuteNonQuery(CommandType.Text, "DELETE [JiuYeLv]  WHERE Id =  " + Id);
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
		public static DataTable JiuYeLvTopGet(string strWhere,int TopNumber)
		{
			string strSql;
			if (!string.IsNullOrEmpty(strWhere.Trim()))
				strSql = "SELECT TOP " + TopNumber.ToString() + " * FROM [JiuYeLv] WHERE "+ strWhere +";";
			else
				strSql = "SELECT TOP " + TopNumber.ToString() + " * FROM [JiuYeLv] ;";
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
		public static DataTable JiuYeLvPageList(string strWhere,int PageSize,int PageIndex)
		{
			StringBuilder sbSql = new StringBuilder();
			sbSql.Append("SELECT * FROM JiuYeLv");
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
		public static int JiuYeLvCount(string strWhere)
		{
			string strSql;
			if (!string.IsNullOrEmpty(strWhere.Trim()))
				strSql = "SELECT COUNT(*) FROM [JiuYeLv] WHERE "+ strWhere +";";
			else
				strSql = "SELECT COUNT(*)  FROM [JiuYeLv] ;";
			return Basic.Utils.StrToInt(SqlDB.ExecuteScalar(CommandType.Text, strSql).ToString(), 0);
		}
	#endregion
		
	}
}

