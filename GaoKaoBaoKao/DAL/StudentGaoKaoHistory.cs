using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;

using Basic;
using Entity;

namespace DAL
{
	public class StudentGaoKaoHistory
	{
		#region  StudentGaoKaoHistory
		/// <summary>
		/// 调用存储过程增加一个
		/// </summary>
		/// <param name="info">实体对象</param>
		/// <returns>正常返回大于 0 的自增id, 0代表重复，否则返回-1</returns>
		public static int StudentGaoKaoHistoryAdd(Entity.StudentGaoKaoHistory info)
		{
			SqlParameter[] prams = {
				SqlDB.MakeInParam("@StudentId", SqlDbType.Int, 4, info.StudentId),
				SqlDB.MakeInParam("@FenShu", SqlDbType.Int, 4, info.FenShu),
				SqlDB.MakeInParam("@FirstLevel", SqlDbType.Int, 4, info.FirstLevel),
				SqlDB.MakeInParam("@SecondLevel", SqlDbType.Int, 4, info.SecondLevel),
				SqlDB.MakeInParam("@PcFirst", SqlDbType.Int, 4, info.PcFirst),
				SqlDB.MakeInParam("@PcSecond", SqlDbType.Int, 4, info.PcSecond),
				SqlDB.MakeInParam("@PcThird", SqlDbType.Int, 4, info.PcThird),
				SqlDB.MakeInParam("@PcZhuanKeFirst", SqlDbType.Int, 4, info.PcZhuanKeFirst),
				SqlDB.MakeInParam("@PcZhuanKeSecond", SqlDbType.Int, 4, info.PcZhuanKeSecond),
				SqlDB.MakeInParam("@IsSetUpFenShuXian", SqlDbType.Int, 4, info.IsSetUpFenShuXian),
				SqlDB.MakeInParam("@WeiCi", SqlDbType.Int, 4, info.WeiCi),
				SqlDB.MakeInParam("@IsSetUpWeiCi", SqlDbType.Int, 4, info.IsSetUpWeiCi),
				SqlDB.MakeInParam("@IsGaoKao", SqlDbType.Int, 4, info.IsGaoKao),
				SqlDB.MakeInParam("@IsLatest", SqlDbType.Int, 4, info.IsLatest),
			};
			return Basic.Utils.StrToInt(SqlDB.ExecuteScalar(CommandType.StoredProcedure, "StudentGaoKaoHistoryAdd", prams).ToString(), -1);
		}
		
		/// <summary>
		/// 调用存储过程修改一个
		/// </summary>
		/// <param name="info">实体对象</param>
		/// <returns>更新成功返回ture，否则返回false</returns>
		public static bool StudentGaoKaoHistoryEdit(Entity.StudentGaoKaoHistory info)
		{
			SqlParameter[] prams = {
				SqlDB.MakeInParam("@Id", SqlDbType.Int, 4, info.Id),
				SqlDB.MakeInParam("@StudentId", SqlDbType.Int, 4, info.StudentId),
				SqlDB.MakeInParam("@FenShu", SqlDbType.Int, 4, info.FenShu),
				SqlDB.MakeInParam("@FirstLevel", SqlDbType.Int, 4, info.FirstLevel),
				SqlDB.MakeInParam("@SecondLevel", SqlDbType.Int, 4, info.SecondLevel),
				SqlDB.MakeInParam("@PcFirst", SqlDbType.Int, 4, info.PcFirst),
				SqlDB.MakeInParam("@PcSecond", SqlDbType.Int, 4, info.PcSecond),
				SqlDB.MakeInParam("@PcThird", SqlDbType.Int, 4, info.PcThird),
				SqlDB.MakeInParam("@PcZhuanKeFirst", SqlDbType.Int, 4, info.PcZhuanKeFirst),
				SqlDB.MakeInParam("@PcZhuanKeSecond", SqlDbType.Int, 4, info.PcZhuanKeSecond),
				SqlDB.MakeInParam("@IsSetUpFenShuXian", SqlDbType.Int, 4, info.IsSetUpFenShuXian),
				SqlDB.MakeInParam("@WeiCi", SqlDbType.Int, 4, info.WeiCi),
				SqlDB.MakeInParam("@IsSetUpWeiCi", SqlDbType.Int, 4, info.IsSetUpWeiCi),
				SqlDB.MakeInParam("@AddTime", SqlDbType.DateTime, 8, info.AddTime),
				SqlDB.MakeInParam("@IsGaoKao", SqlDbType.Int, 4, info.IsGaoKao),
				SqlDB.MakeInParam("@IsLatest", SqlDbType.Int, 4, info.IsLatest),
				};
			int intReturnValue = 0;
			intReturnValue = SqlDB.ExecuteNonQuery(CommandType.StoredProcedure, "StudentGaoKaoHistoryEdit", prams);
			if(intReturnValue == 1)
				return true;
			return false;
		}
		
		/// <summary>
		/// 暂停该值
		/// </summary>
		/// <param name="Id">自增id的值</param>
		/// <returns>暂停成功返回ture，否则返回false</returns>
        //public static bool StudentGaoKaoHistoryPause(Entity.StudentGaoKaoHistory info)
        //{
        //    int intReturnValue = 0;
        //    intReturnValue = SqlDB.ExecuteNonQuery(CommandType.Text, "UPDATE [StudentGaoKaoHistory] SET IsPause = "+  info.IsPause +"  WHERE Id =  " +  info.Id);
        //    if(intReturnValue == 1)
        //        return true;
        //    return false;
        //}
		
		/// <summary>
		/// 获取所有的的值
		/// </summary>
		/// <param name="strWhere">条件，可以为空</param>
		/// <returns>返回DataTable</returns>
		public static DataTable StudentGaoKaoHistoryList(string strWhere)
		{
			string strSql;
			if (!string.IsNullOrEmpty(strWhere.Trim()))
				strSql = "SELECT * FROM [StudentGaoKaoHistory] WHERE "+ strWhere +";";
			else
				strSql = "SELECT * FROM [StudentGaoKaoHistory] ;";
			return SqlDB.ExecuteDataset(CommandType.Text, strSql).Tables[0];
		}
		
		
		/// <summary>
		/// 获取某一个DataTable
		/// </summary>
		/// <param name="Id">标识</param>
		/// <returns>返回DataTable</returns>
		public static DataTable StudentGaoKaoHistoryGet(int Id)
		{
			return SqlDB.ExecuteDataset(CommandType.Text, "SELECT * FROM [StudentGaoKaoHistory] WHERE Id = "+Id+";").Tables[0];
		}
		
		/// <summary>
		/// 获取某一个实体
		/// </summary>
		/// <param name="Id">标识</param>
		/// <returns>返回Entity</returns>
        public static Entity.StudentGaoKaoHistory StudentGaoKaoHistoryEntityGet(int StudentId)
		{
			Entity.StudentGaoKaoHistory info = new Entity.StudentGaoKaoHistory();
            DataTable dt = SqlDB.ExecuteDataset(CommandType.Text, "SELECT * FROM [StudentGaoKaoHistory] WHERE StudentId = " + StudentId + " ORDER BY ID DESC;").Tables[0];
            if (dt.Rows.Count > 0)
            {
                info.Id = Basic.Utils.StrToInt(dt.Rows[0]["Id"].ToString(), 0);
                info.StudentId = Basic.Utils.StrToInt(dt.Rows[0]["StudentId"].ToString(), 0);
                info.FenShu = Basic.Utils.StrToInt(dt.Rows[0]["FenShu"].ToString(), 0);
                info.FirstLevel = Basic.Utils.StrToInt(dt.Rows[0]["FirstLevel"].ToString(), 0);
                info.SecondLevel = Basic.Utils.StrToInt(dt.Rows[0]["SecondLevel"].ToString(), 0);
                info.PcFirst = Basic.Utils.StrToInt(dt.Rows[0]["PcFirst"].ToString(), 0);
                info.PcSecond = Basic.Utils.StrToInt(dt.Rows[0]["PcSecond"].ToString(), 0);
                info.PcThird = Basic.Utils.StrToInt(dt.Rows[0]["PcThird"].ToString(), 0);
                info.PcZhuanKeFirst = Basic.Utils.StrToInt(dt.Rows[0]["PcZhuanKeFirst"].ToString(), 0);
                info.PcZhuanKeSecond = Basic.Utils.StrToInt(dt.Rows[0]["PcZhuanKeSecond"].ToString(), 0);
                info.IsSetUpFenShuXian = Basic.Utils.StrToInt(dt.Rows[0]["IsSetUpFenShuXian"].ToString(), 0);
                info.WeiCi = Basic.Utils.StrToInt(dt.Rows[0]["WeiCi"].ToString(), 0);
                info.IsSetUpWeiCi = Basic.Utils.StrToInt(dt.Rows[0]["IsSetUpWeiCi"].ToString(), 0);
                info.IsGaoKao = Basic.Utils.StrToInt(dt.Rows[0]["IsGaoKao"].ToString(), 0);
                info.IsLatest = Basic.Utils.StrToInt(dt.Rows[0]["IsLatest"].ToString(), 0);
                info.AddTime = Basic.Utils.StrToDateTime(dt.Rows[0]["AddTime"].ToString());
            }
            else
                return null;
			return info;
		}
		
		/// <summary>
		/// 删除一个值
		/// </summary>
		/// <param name="Id">自增id的值</param>
		/// <returns>删除成功返回ture，否则返回false</returns>
		public static bool StudentGaoKaoHistoryDel(int Id)
		{
			int intReturnValue = 0;
			intReturnValue = SqlDB.ExecuteNonQuery(CommandType.Text, "DELETE [StudentGaoKaoHistory]  WHERE Id =  " + Id);
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
		public static DataTable StudentGaoKaoHistoryTopGet(string strWhere,int TopNumber)
		{
			string strSql;
			if (!string.IsNullOrEmpty(strWhere.Trim()))
				strSql = "SELECT TOP " + TopNumber.ToString() + " * FROM [StudentGaoKaoHistory] WHERE "+ strWhere +";";
			else
				strSql = "SELECT TOP " + TopNumber.ToString() + " * FROM [StudentGaoKaoHistory] ;";
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
		public static DataTable StudentGaoKaoHistoryPageList(string strWhere,int PageSize,int PageIndex)
		{
			StringBuilder sbSql = new StringBuilder();
			sbSql.Append("SELECT * FROM StudentGaoKaoHistory");
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
		public static int StudentGaoKaoHistoryCount(string strWhere)
		{
			string strSql;
			if (!string.IsNullOrEmpty(strWhere.Trim()))
				strSql = "SELECT COUNT(*) FROM [StudentGaoKaoHistory] WHERE "+ strWhere +";";
			else
				strSql = "SELECT COUNT(*)  FROM [StudentGaoKaoHistory] ;";
			return Basic.Utils.StrToInt(SqlDB.ExecuteScalar(CommandType.Text, strSql).ToString(), 0);
		}
	#endregion
		
	}
}

