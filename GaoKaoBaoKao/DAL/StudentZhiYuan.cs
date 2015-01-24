using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;

using Basic;
using Entity;

namespace DAL
{
	public class StudentZhiYuan
	{
		#region  StudentZhiYuan
		/// <summary>
		/// 调用存储过程增加一个
		/// </summary>
		/// <param name="info">实体对象</param>
		/// <returns>正常返回大于 0 的自增id, 0代表重复，否则返回-1</returns>
		public static int StudentZhiYuanAdd(Entity.StudentZhiYuan info)
		{
			SqlParameter[] prams = {
				SqlDB.MakeInParam("@ProvincePcId", SqlDbType.Int, 4, info.ProvincePcId),
				SqlDB.MakeInParam("@ProvinceZhiYuanId", SqlDbType.Int, 4, info.ProvinceZhiYuanId),
				SqlDB.MakeInParam("@SchoolId", SqlDbType.Int, 4, info.SchoolId),
				SqlDB.MakeInParam("@SchoolName", SqlDbType.NVarChar, 100, info.SchoolName),
				SqlDB.MakeInParam("@MajorList", SqlDbType.NVarChar, 1000, info.MajorList),
				SqlDB.MakeInParam("@MajorCount", SqlDbType.Int, 4, info.MajorCount),
				SqlDB.MakeInParam("@IsTiaoJi", SqlDbType.Int, 4, info.IsTiaoJi),
				SqlDB.MakeInParam("@IsAllMajor", SqlDbType.Int, 4, info.IsAllMajor),
				SqlDB.MakeInParam("@StudentId", SqlDbType.Int, 4, info.StudentId),
				//SqlDB.MakeInParam("@AddTime", SqlDbType.DateTime, 8, info.AddTime),
				SqlDB.MakeInParam("@Memo", SqlDbType.NVarChar, 500, info.Memo),
			};
			return Basic.Utils.StrToInt(SqlDB.ExecuteScalar(CommandType.StoredProcedure, "StudentZhiYuanAdd", prams).ToString(), -1);
		}
		
		/// <summary>
		/// 调用存储过程修改一个
		/// </summary>
		/// <param name="info">实体对象</param>
		/// <returns>更新成功返回ture，否则返回false</returns>
		public static bool StudentZhiYuanEdit(Entity.StudentZhiYuan info)
		{
			SqlParameter[] prams = {
				SqlDB.MakeInParam("@id", SqlDbType.Int, 4, info.Id),
				SqlDB.MakeInParam("@ProvincePcId", SqlDbType.Int, 4, info.ProvincePcId),
				SqlDB.MakeInParam("@ProvinceZhiYuanId", SqlDbType.Int, 4, info.ProvinceZhiYuanId),
				SqlDB.MakeInParam("@SchoolId", SqlDbType.Int, 4, info.SchoolId),
				SqlDB.MakeInParam("@SchoolName", SqlDbType.NVarChar, 100, info.SchoolName),
				SqlDB.MakeInParam("@MajorList", SqlDbType.NVarChar, 1000, info.MajorList),
				SqlDB.MakeInParam("@MajorCount", SqlDbType.Int, 4, info.MajorCount),
				SqlDB.MakeInParam("@IsTiaoJi", SqlDbType.Int, 4, info.IsTiaoJi),
				SqlDB.MakeInParam("@IsAllMajor", SqlDbType.Int, 4, info.IsAllMajor),
				SqlDB.MakeInParam("@StudentId", SqlDbType.Int, 4, info.StudentId),
				SqlDB.MakeInParam("@AddTime", SqlDbType.DateTime, 8, info.AddTime),
				SqlDB.MakeInParam("@Memo", SqlDbType.NVarChar, 500, info.Memo),
				};
			int intReturnValue = 0;
			intReturnValue = SqlDB.ExecuteNonQuery(CommandType.StoredProcedure, "StudentZhiYuanEdit", prams);
			if(intReturnValue == 1)
				return true;
			return false;
		}
		
		/// <summary>
		/// 暂停该值
		/// </summary>
		/// <param name="id">自增id的值</param>
		/// <returns>暂停成功返回ture，否则返回false</returns>
        //public static bool StudentZhiYuanPause(Entity.StudentZhiYuan info)
        //{
        //    int intReturnValue = 0;
        //    intReturnValue = SqlDB.ExecuteNonQuery(CommandType.Text, "UPDATE [StudentZhiYuan] SET IsPause = "+  info.IsPause +"  WHERE id =  " +  info.id);
        //    if(intReturnValue == 1)
        //        return true;
        //    return false;
        //}
		
		/// <summary>
		/// 获取所有的的值
		/// </summary>
		/// <param name="strWhere">条件，可以为空</param>
		/// <returns>返回DataTable</returns>
		public static DataTable StudentZhiYuanList(string strWhere)
		{
			string strSql;
			if (!string.IsNullOrEmpty(strWhere.Trim()))
				strSql = "SELECT * FROM [StudentZhiYuan] WHERE "+ strWhere +";";
			else
				strSql = "SELECT * FROM [StudentZhiYuan] ;";
			return SqlDB.ExecuteDataset(CommandType.Text, strSql).Tables[0];
		}
		
		
		/// <summary>
		/// 获取某一个DataTable
		/// </summary>
		/// <param name="id">标识</param>
		/// <returns>返回DataTable</returns>
		public static DataTable StudentZhiYuanGet(int id)
		{
			return SqlDB.ExecuteDataset(CommandType.Text, "SELECT * FROM [StudentZhiYuan] WHERE id = "+id+";").Tables[0];
		}
		
		/// <summary>
		/// 获取某一个实体
		/// </summary>
		/// <param name="id">标识</param>
		/// <returns>返回Entity</returns>
        public static Entity.StudentZhiYuan StudentZhiYuanEntityGet(int ProvinceZhiYuanId, int StudentId)
		{
			Entity.StudentZhiYuan info = new Entity.StudentZhiYuan();
            DataTable dt = SqlDB.ExecuteDataset(CommandType.Text, "SELECT * FROM [StudentZhiYuan] WHERE StudentId = " + StudentId + " AND ProvinceZhiYuanId = " + ProvinceZhiYuanId + ";").Tables[0];
			if(dt.Rows.Count >0)
			{
				info.Id = Basic.Utils.StrToInt(dt.Rows[0]["id"].ToString(),0);
				info.ProvincePcId = Basic.Utils.StrToInt(dt.Rows[0]["ProvincePcId"].ToString(),0);
				info.ProvinceZhiYuanId = Basic.Utils.StrToInt(dt.Rows[0]["ProvinceZhiYuanId"].ToString(),0);
				info.SchoolId = Basic.Utils.StrToInt(dt.Rows[0]["SchoolId"].ToString(),0);
				info.SchoolName = dt.Rows[0]["SchoolName"].ToString();
				info.MajorList = dt.Rows[0]["MajorList"].ToString();
				info.MajorCount = Basic.Utils.StrToInt(dt.Rows[0]["MajorCount"].ToString(),0);
				info.IsTiaoJi = Basic.Utils.StrToInt(dt.Rows[0]["IsTiaoJi"].ToString(),0);
				info.IsAllMajor = Basic.Utils.StrToInt(dt.Rows[0]["IsAllMajor"].ToString(),0);
				info.StudentId = Basic.Utils.StrToInt(dt.Rows[0]["StudentId"].ToString(),0);
                info.Memo = dt.Rows[0]["Memo"].ToString();
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
		/// <param name="id">自增id的值</param>
		/// <returns>删除成功返回ture，否则返回false</returns>
		public static bool StudentZhiYuanDel(int id)
		{
			int intReturnValue = 0;
			intReturnValue = SqlDB.ExecuteNonQuery(CommandType.Text, "DELETE [StudentZhiYuan]  WHERE id =  " + id);
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
		public static DataTable StudentZhiYuanTopGet(string strWhere,int TopNumber)
		{
			string strSql;
			if (!string.IsNullOrEmpty(strWhere.Trim()))
				strSql = "SELECT TOP " + TopNumber.ToString() + " * FROM [StudentZhiYuan] WHERE "+ strWhere +";";
			else
				strSql = "SELECT TOP " + TopNumber.ToString() + " * FROM [StudentZhiYuan] ;";
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
		public static DataTable StudentZhiYuanPageList(string strWhere,int PageSize,int PageIndex)
		{
			StringBuilder sbSql = new StringBuilder();
			sbSql.Append("SELECT * FROM StudentZhiYuan");
			if (!string.IsNullOrEmpty(strWhere.Trim()))
			{
				sbSql.Append(" WHERE " + strWhere);
			}
			sbSql.Append(" ORDER BY id DESC");
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
		public static int StudentZhiYuanCount(string strWhere)
		{
			string strSql;
			if (!string.IsNullOrEmpty(strWhere.Trim()))
				strSql = "SELECT COUNT(*) FROM [StudentZhiYuan] WHERE "+ strWhere +";";
			else
				strSql = "SELECT COUNT(*)  FROM [StudentZhiYuan] ;";
			return Basic.Utils.StrToInt(SqlDB.ExecuteScalar(CommandType.Text, strSql).ToString(), 0);
		}
	#endregion
		
	}
}

