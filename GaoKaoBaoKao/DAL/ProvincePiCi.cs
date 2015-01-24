using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;

using Basic;
using Entity;

namespace DAL
{
	public class ProvincePiCi
	{
		#region  ProvincePiCi
		/// <summary>
		/// 调用存储过程增加一个
		/// </summary>
		/// <param name="info">实体对象</param>
		/// <returns>正常返回大于 0 的自增id, 0代表重复，否则返回-1</returns>
		public static int ProvincePiCiAdd(Entity.ProvincePiCi info)
		{
			SqlParameter[] prams = {
				SqlDB.MakeInParam("@ProvinceId", SqlDbType.Int, 4, info.ProvinceId),
				SqlDB.MakeInParam("@LeiBie", SqlDbType.Int, 4, info.LeiBie),
				SqlDB.MakeInParam("@CengCi", SqlDbType.Int, 4, info.CengCi),
				SqlDB.MakeInParam("@PiCi", SqlDbType.Int, 4, info.PiCi),
				SqlDB.MakeInParam("@PcLeiBie", SqlDbType.Int, 4, info.PcLeiBie),
				SqlDB.MakeInParam("@PcName", SqlDbType.NVarChar, 50, info.PcName),
				SqlDB.MakeInParam("@PcIntro", SqlDbType.NVarChar, 500, info.PcIntro),
				SqlDB.MakeInParam("@CkFsx", SqlDbType.Int, 4, info.CkFsx),
				SqlDB.MakeInParam("@MajorCount", SqlDbType.Int, 4, info.MajorCount),
				SqlDB.MakeInParam("@IsPause", SqlDbType.Int, 4, info.IsPause),
				SqlDB.MakeInParam("@ShowOrder", SqlDbType.Int, 4, info.ShowOrder),
			};
			return Basic.Utils.StrToInt(SqlDB.ExecuteScalar(CommandType.StoredProcedure, "ProvincePiCiAdd", prams).ToString(), -1);
		}
		
		/// <summary>
		/// 调用存储过程修改一个
		/// </summary>
		/// <param name="info">实体对象</param>
		/// <returns>更新成功返回ture，否则返回false</returns>
		public static bool ProvincePiCiEdit(Entity.ProvincePiCi info)
		{
			SqlParameter[] prams = {
				SqlDB.MakeInParam("@Id", SqlDbType.Int, 4, info.Id),
				SqlDB.MakeInParam("@ProvinceId", SqlDbType.Int, 4, info.ProvinceId),
				SqlDB.MakeInParam("@LeiBie", SqlDbType.Int, 4, info.LeiBie),
				SqlDB.MakeInParam("@CengCi", SqlDbType.Int, 4, info.CengCi),
				SqlDB.MakeInParam("@PiCi", SqlDbType.Int, 4, info.PiCi),
				SqlDB.MakeInParam("@PcLeiBie", SqlDbType.Int, 4, info.PcLeiBie),
				SqlDB.MakeInParam("@PcName", SqlDbType.NVarChar, 50, info.PcName),
				SqlDB.MakeInParam("@PcIntro", SqlDbType.NVarChar, 500, info.PcIntro),
				SqlDB.MakeInParam("@CkFsx", SqlDbType.Int, 4, info.CkFsx),
				SqlDB.MakeInParam("@MajorCount", SqlDbType.Int, 4, info.MajorCount),
				SqlDB.MakeInParam("@IsPause", SqlDbType.Int, 4, info.IsPause),
				SqlDB.MakeInParam("@ShowOrder", SqlDbType.Int, 4, info.ShowOrder),
				};
			int intReturnValue = 0;
			intReturnValue = SqlDB.ExecuteNonQuery(CommandType.StoredProcedure, "ProvincePiCiEdit", prams);
			if(intReturnValue == 1)
				return true;
			return false;
		}
		
		/// <summary>
		/// 暂停该值
		/// </summary>
		/// <param name="Id">自增id的值</param>
		/// <returns>暂停成功返回ture，否则返回false</returns>
		public static bool ProvincePiCiPause(Entity.ProvincePiCi info)
		{
			int intReturnValue = 0;
			intReturnValue = SqlDB.ExecuteNonQuery(CommandType.Text, "UPDATE [ProvincePiCi] SET IsPause = "+  info.IsPause +"  WHERE Id =  " +  info.Id);
			if(intReturnValue == 1)
				return true;
			return false;
		}
		
		/// <summary>
		/// 获取所有的的值
		/// </summary>
		/// <param name="strWhere">条件，可以为空</param>
		/// <returns>返回DataTable</returns>
		public static DataTable ProvincePiCiList(string strWhere)
		{
			string strSql;
			if (!string.IsNullOrEmpty(strWhere.Trim()))
				strSql = "SELECT * FROM [ProvincePiCi] WHERE "+ strWhere +";";
			else
				strSql = "SELECT * FROM [ProvincePiCi] ;";
			return SqlDB.ExecuteDataset(CommandType.Text, strSql).Tables[0];
		}
		
		
		/// <summary>
		/// 获取某一个DataTable
		/// </summary>
		/// <param name="Id">标识</param>
		/// <returns>返回DataTable</returns>
		public static DataTable ProvincePiCiGet(int Id)
		{
			return SqlDB.ExecuteDataset(CommandType.Text, "SELECT * FROM [ProvincePiCi] WHERE Id = "+Id+";").Tables[0];
		}
		
		/// <summary>
		/// 获取某一个实体
		/// </summary>
		/// <param name="Id">标识</param>
		/// <returns>返回Entity</returns>
        public static Entity.ProvincePiCi ProvincePiCiEntityGet(int Id)
        {
            Entity.ProvincePiCi info = new Entity.ProvincePiCi();
            DataTable dt = SqlDB.ExecuteDataset(CommandType.Text, "SELECT * FROM [ProvincePiCi] WHERE Id = " + Id + ";").Tables[0];
            if (dt.Rows.Count > 0)
            {
                info.Id = Basic.Utils.StrToInt(dt.Rows[0]["Id"].ToString(), 0);
                info.ProvinceId = Basic.Utils.StrToInt(dt.Rows[0]["ProvinceId"].ToString(), 0);
                info.LeiBie = Basic.Utils.StrToInt(dt.Rows[0]["LeiBie"].ToString(), 0);
                info.CengCi = Basic.Utils.StrToInt(dt.Rows[0]["CengCi"].ToString(), 0);
                info.PiCi = Basic.Utils.StrToInt(dt.Rows[0]["PiCi"].ToString(), 0);
                info.PcLeiBie = Basic.Utils.StrToInt(dt.Rows[0]["PcLeiBie"].ToString(), 0);
                info.PcName = dt.Rows[0]["PcName"].ToString();
                info.PcIntro = dt.Rows[0]["PcIntro"].ToString();
                info.CkFsx = Basic.Utils.StrToInt(dt.Rows[0]["CkFsx"].ToString(), 0);
                info.MajorCount = Basic.Utils.StrToInt(dt.Rows[0]["MajorCount"].ToString(), 0);
                info.IsPause = Basic.Utils.StrToInt(dt.Rows[0]["IsPause"].ToString(), 0);
                info.ShowOrder = Basic.Utils.StrToInt(dt.Rows[0]["ShowOrder"].ToString(), 0);
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
		public static bool ProvincePiCiDel(int Id)
		{
			int intReturnValue = 0;
			intReturnValue = SqlDB.ExecuteNonQuery(CommandType.Text, "DELETE [ProvincePiCi]  WHERE Id =  " + Id);
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
		public static DataTable ProvincePiCiTopGet(string strWhere,int TopNumber)
		{
			string strSql;
			if (!string.IsNullOrEmpty(strWhere.Trim()))
				strSql = "SELECT TOP " + TopNumber.ToString() + " * FROM [ProvincePiCi] WHERE "+ strWhere +";";
			else
				strSql = "SELECT TOP " + TopNumber.ToString() + " * FROM [ProvincePiCi] ;";
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
		public static DataTable ProvincePiCiPageList(string strWhere,int PageSize,int PageIndex)
		{
			StringBuilder sbSql = new StringBuilder();
			sbSql.Append("SELECT * FROM ProvincePiCi");
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
		public static int ProvincePiCiCount(string strWhere)
		{
			string strSql;
			if (!string.IsNullOrEmpty(strWhere.Trim()))
				strSql = "SELECT COUNT(*) FROM [ProvincePiCi] WHERE "+ strWhere +";";
			else
				strSql = "SELECT COUNT(*)  FROM [ProvincePiCi] ;";
			return Basic.Utils.StrToInt(SqlDB.ExecuteScalar(CommandType.Text, strSql).ToString(), 0);
		}
	#endregion
		
	}
}

