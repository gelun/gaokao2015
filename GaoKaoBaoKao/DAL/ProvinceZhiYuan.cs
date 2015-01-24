using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;

using Basic;
using Entity;

namespace DAL
{
	public class ProvinceZhiYuan
	{
		#region  ProvinceZhiYuan
		/// <summary>
		/// 调用存储过程增加一个
		/// </summary>
		/// <param name="info">实体对象</param>
		/// <returns>正常返回大于 0 的自增id, 0代表重复，否则返回-1</returns>
		public static int ProvinceZhiYuanAdd(Entity.ProvinceZhiYuan info)
		{
			SqlParameter[] prams = {
				SqlDB.MakeInParam("@ProvincePcId", SqlDbType.Int, 4, info.ProvincePcId),
				SqlDB.MakeInParam("@ZhiYuanMing", SqlDbType.NVarChar, 50, info.ZhiYuanMing),
				SqlDB.MakeInParam("@Suggestion", SqlDbType.NVarChar, 500, info.Suggestion),
				SqlDB.MakeInParam("@ShowOrder", SqlDbType.Int, 4, info.ShowOrder),
				SqlDB.MakeInParam("@IsPause", SqlDbType.Int, 4, info.IsPause),
			};
			return Basic.Utils.StrToInt(SqlDB.ExecuteScalar(CommandType.StoredProcedure, "ProvinceZhiYuanAdd", prams).ToString(), -1);
		}
		
		/// <summary>
		/// 调用存储过程修改一个
		/// </summary>
		/// <param name="info">实体对象</param>
		/// <returns>更新成功返回ture，否则返回false</returns>
		public static bool ProvinceZhiYuanEdit(Entity.ProvinceZhiYuan info)
		{
			SqlParameter[] prams = {
				SqlDB.MakeInParam("@Id", SqlDbType.Int, 4, info.Id),
				SqlDB.MakeInParam("@ProvincePcId", SqlDbType.Int, 4, info.ProvincePcId),
				SqlDB.MakeInParam("@ZhiYuanMing", SqlDbType.NVarChar, 50, info.ZhiYuanMing),
				SqlDB.MakeInParam("@Suggestion", SqlDbType.NVarChar, 500, info.Suggestion),
				SqlDB.MakeInParam("@ShowOrder", SqlDbType.Int, 4, info.ShowOrder),
				SqlDB.MakeInParam("@IsPause", SqlDbType.Int, 4, info.IsPause),
				};
			int intReturnValue = 0;
			intReturnValue = SqlDB.ExecuteNonQuery(CommandType.StoredProcedure, "ProvinceZhiYuanEdit", prams);
			if(intReturnValue == 1)
				return true;
			return false;
		}
		
		/// <summary>
		/// 暂停该值
		/// </summary>
		/// <param name="Id">自增id的值</param>
		/// <returns>暂停成功返回ture，否则返回false</returns>
		public static bool ProvinceZhiYuanPause(Entity.ProvinceZhiYuan info)
		{
			int intReturnValue = 0;
			intReturnValue = SqlDB.ExecuteNonQuery(CommandType.Text, "UPDATE [ProvinceZhiYuan] SET IsPause = "+  info.IsPause +"  WHERE Id =  " +  info.Id);
			if(intReturnValue == 1)
				return true;
			return false;
		}
		
		/// <summary>
		/// 获取所有的的值
		/// </summary>
		/// <param name="strWhere">条件，可以为空</param>
		/// <returns>返回DataTable</returns>
		public static DataTable ProvinceZhiYuanList(string strWhere)
		{
			string strSql;
			if (!string.IsNullOrEmpty(strWhere.Trim()))
				strSql = "SELECT * FROM [ProvinceZhiYuan] WHERE "+ strWhere +";";
			else
				strSql = "SELECT * FROM [ProvinceZhiYuan] ;";
			return SqlDB.ExecuteDataset(CommandType.Text, strSql).Tables[0];
		}

        public static DataTable ProvinceZhiYuanList(int ProvincePcId)
        {
            string strSql;
            strSql = "SELECT * FROM [ProvinceZhiYuan] WHERE  ProvincePcId = " + ProvincePcId +" AND IsPause = 0 ORDER BY ShowOrder ASC";
            return SqlDB.ExecuteDataset(CommandType.Text, strSql).Tables[0];
        }


		
		/// <summary>
		/// 获取某一个DataTable
		/// </summary>
		/// <param name="Id">标识</param>
		/// <returns>返回DataTable</returns>
		public static DataTable ProvinceZhiYuanGet(int Id)
		{
			return SqlDB.ExecuteDataset(CommandType.Text, "SELECT * FROM [ProvinceZhiYuan] WHERE Id = "+Id+";").Tables[0];
		}
		
		/// <summary>
		/// 获取某一个实体
		/// </summary>
		/// <param name="Id">标识</param>
		/// <returns>返回Entity</returns>
        //public static Entity.ProvinceZhiYuan ProvinceZhiYuanEntityGet(int Id)
        //{
        //    Entity.ProvinceZhiYuan info = new Entity.ProvinceZhiYuan();
        //    DataTable dt = SqlDB.ExecuteDataset(CommandType.Text, "SELECT * FROM [ProvinceZhiYuan] WHERE Id = "+Id+";").Tables[0];
        //    if(dt.Rows.Count >0)
        //    {
        //        info.Id = Basic.Utils.StrToInt(dt.Rows[0]["Id"].ToString(),0);
        //        info.ProvincePcId = Basic.Utils.StrToInt(dt.Rows[0]["ProvincePcId"].ToString(), 0);
        //        info.ZhiYuanMing = dt.Rows[0]["ZhiYuanMing"].ToString();
        //        info.Suggestion = dt.Rows[0]["Suggestion"].ToString();
        //        info.ShowOrder = Basic.Utils.StrToInt(dt.Rows[0]["ShowOrder"].ToString(),0);
        //        info.IsPause = Basic.Utils.StrToInt(dt.Rows[0]["IsPause"].ToString(), 0);
        //        return info;
        //    }
        //    else
        //    {
        //        return null;
        //    }
        //}


        public static Entity.ProvinceZhiYuan ProvinceZhiYuanEntityGet(int ProvincePcId)
        {
            Entity.ProvinceZhiYuan info = new Entity.ProvinceZhiYuan();
            DataTable dt = SqlDB.ExecuteDataset(CommandType.Text, "SELECT * FROM [ProvinceZhiYuan] WHERE ProvincePcId = " + ProvincePcId + ";").Tables[0];
            if (dt.Rows.Count > 0)
            {
                info.Id = Basic.Utils.StrToInt(dt.Rows[0]["Id"].ToString(), 0);
                info.ProvincePcId = Basic.Utils.StrToInt(dt.Rows[0]["ProvincePcId"].ToString(), 0);
                info.ZhiYuanMing = dt.Rows[0]["ZhiYuanMing"].ToString();
                info.Suggestion = dt.Rows[0]["Suggestion"].ToString();
                info.ShowOrder = Basic.Utils.StrToInt(dt.Rows[0]["ShowOrder"].ToString(), 0);
                info.IsPause = Basic.Utils.StrToInt(dt.Rows[0]["IsPause"].ToString(), 0);
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
		public static bool ProvinceZhiYuanDel(int Id)
		{
			int intReturnValue = 0;
			intReturnValue = SqlDB.ExecuteNonQuery(CommandType.Text, "DELETE [ProvinceZhiYuan]  WHERE Id =  " + Id);
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
		public static DataTable ProvinceZhiYuanTopGet(string strWhere,int TopNumber)
		{
			string strSql;
			if (!string.IsNullOrEmpty(strWhere.Trim()))
				strSql = "SELECT TOP " + TopNumber.ToString() + " * FROM [ProvinceZhiYuan] WHERE "+ strWhere +";";
			else
				strSql = "SELECT TOP " + TopNumber.ToString() + " * FROM [ProvinceZhiYuan] ;";
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
		public static DataTable ProvinceZhiYuanPageList(string strWhere,int PageSize,int PageIndex)
		{
			StringBuilder sbSql = new StringBuilder();
			sbSql.Append("SELECT * FROM ProvinceZhiYuan");
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
		public static int ProvinceZhiYuanCount(string strWhere)
		{
			string strSql;
			if (!string.IsNullOrEmpty(strWhere.Trim()))
				strSql = "SELECT COUNT(*) FROM [ProvinceZhiYuan] WHERE "+ strWhere +";";
			else
				strSql = "SELECT COUNT(*)  FROM [ProvinceZhiYuan] ;";
			return Basic.Utils.StrToInt(SqlDB.ExecuteScalar(CommandType.Text, strSql).ToString(), 0);
		}
	#endregion
		
	}
}

