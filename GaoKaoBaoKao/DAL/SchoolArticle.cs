using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;

using Basic;
using Entity;

namespace DAL
{
	public class SchoolArticle
	{
		#region  SchoolArticle
		/// <summary>
		/// 调用存储过程增加一个
		/// </summary>
		/// <param name="info">实体对象</param>
		/// <returns>正常返回大于 0 的自增id, 0代表重复，否则返回-1</returns>
		public static int SchoolArticleAdd(Entity.SchoolArticle info)
		{
			SqlParameter[] prams = {
				SqlDB.MakeInParam("@SchoolId", SqlDbType.Int, 4, info.SchoolId),
				SqlDB.MakeInParam("@CategoryId", SqlDbType.Int, 4, info.CategoryId),
				SqlDB.MakeInParam("@Icon", SqlDbType.NVarChar, 500, info.Icon),
				SqlDB.MakeInParam("@Title", SqlDbType.NVarChar, 200, info.Title),
				SqlDB.MakeInParam("@ShortTitle", SqlDbType.NVarChar, 200, info.ShortTitle),
				SqlDB.MakeInParam("@MetaTitle", SqlDbType.NVarChar, 200, info.MetaTitle),
				SqlDB.MakeInParam("@MetaKeyWords", SqlDbType.NVarChar, 200, info.MetaKeyWords),
				SqlDB.MakeInParam("@MetaDescription", SqlDbType.NVarChar, 300, info.MetaDescription),
				SqlDB.MakeInParam("@Summary", SqlDbType.NVarChar, 2000, info.Summary),
				SqlDB.MakeInParam("@Content", SqlDbType.NVarChar, 0, info.Content),
				SqlDB.MakeInParam("@PublishTime", SqlDbType.DateTime, 8, info.PublishTime),
				SqlDB.MakeInParam("@IsTuiJian", SqlDbType.Int, 4, info.IsTuiJian),
				SqlDB.MakeInParam("@IsNew", SqlDbType.Int, 4, info.IsNew),
				SqlDB.MakeInParam("@IsZhiDing", SqlDbType.Int, 4, info.IsZhiDing),
				SqlDB.MakeInParam("@ZhiDingTime", SqlDbType.DateTime, 8, info.ZhiDingTime),
				SqlDB.MakeInParam("@AddTime", SqlDbType.DateTime, 8, info.AddTime),
				SqlDB.MakeInParam("@AddWid", SqlDbType.Int, 4, info.AddWid),
				SqlDB.MakeInParam("@IsCheck", SqlDbType.Int, 4, info.IsCheck),
				SqlDB.MakeInParam("@CheckTime", SqlDbType.DateTime, 8, info.CheckTime),
				SqlDB.MakeInParam("@CheckWid", SqlDbType.Int, 4, info.CheckWid),
				SqlDB.MakeInParam("@ClickNum", SqlDbType.Int, 4, info.ClickNum),
				SqlDB.MakeInParam("@IsPause", SqlDbType.Int, 4, info.IsPause),
				SqlDB.MakeInParam("@Year", SqlDbType.Int, 4, info.Year),
			};
			return Basic.Utils.StrToInt(SqlDB.ExecuteScalar(CommandType.StoredProcedure, "SchoolArticleAdd", prams).ToString(), -1);
		}
		
		/// <summary>
		/// 调用存储过程修改一个
		/// </summary>
		/// <param name="info">实体对象</param>
		/// <returns>更新成功返回ture，否则返回false</returns>
		public static bool SchoolArticleEdit(Entity.SchoolArticle info)
		{
			SqlParameter[] prams = {
				SqlDB.MakeInParam("@Id", SqlDbType.Int, 4, info.Id),
				SqlDB.MakeInParam("@SchoolId", SqlDbType.Int, 4, info.SchoolId),
				SqlDB.MakeInParam("@CategoryId", SqlDbType.Int, 4, info.CategoryId),
				SqlDB.MakeInParam("@Icon", SqlDbType.NVarChar, 500, info.Icon),
				SqlDB.MakeInParam("@Title", SqlDbType.NVarChar, 200, info.Title),
				SqlDB.MakeInParam("@ShortTitle", SqlDbType.NVarChar, 200, info.ShortTitle),
				SqlDB.MakeInParam("@MetaTitle", SqlDbType.NVarChar, 200, info.MetaTitle),
				SqlDB.MakeInParam("@MetaKeyWords", SqlDbType.NVarChar, 200, info.MetaKeyWords),
				SqlDB.MakeInParam("@MetaDescription", SqlDbType.NVarChar, 300, info.MetaDescription),
				SqlDB.MakeInParam("@Summary", SqlDbType.NVarChar, 2000, info.Summary),
				SqlDB.MakeInParam("@Content", SqlDbType.NVarChar, 0, info.Content),
				SqlDB.MakeInParam("@PublishTime", SqlDbType.DateTime, 8, info.PublishTime),
				SqlDB.MakeInParam("@IsTuiJian", SqlDbType.Int, 4, info.IsTuiJian),
				SqlDB.MakeInParam("@IsNew", SqlDbType.Int, 4, info.IsNew),
				SqlDB.MakeInParam("@IsZhiDing", SqlDbType.Int, 4, info.IsZhiDing),
				SqlDB.MakeInParam("@ZhiDingTime", SqlDbType.DateTime, 8, info.ZhiDingTime),
				SqlDB.MakeInParam("@AddTime", SqlDbType.DateTime, 8, info.AddTime),
				SqlDB.MakeInParam("@AddWid", SqlDbType.Int, 4, info.AddWid),
				SqlDB.MakeInParam("@IsCheck", SqlDbType.Int, 4, info.IsCheck),
				SqlDB.MakeInParam("@CheckTime", SqlDbType.DateTime, 8, info.CheckTime),
				SqlDB.MakeInParam("@CheckWid", SqlDbType.Int, 4, info.CheckWid),
				SqlDB.MakeInParam("@ClickNum", SqlDbType.Int, 4, info.ClickNum),
				SqlDB.MakeInParam("@IsPause", SqlDbType.Int, 4, info.IsPause),
				SqlDB.MakeInParam("@Year", SqlDbType.Int, 4, info.Year),
				};
			int intReturnValue = 0;
			intReturnValue = SqlDB.ExecuteNonQuery(CommandType.StoredProcedure, "SchoolArticleEdit", prams);
			if(intReturnValue == 1)
				return true;
			return false;
		}
		
		/// <summary>
		/// 暂停该值
		/// </summary>
		/// <param name="Id">自增id的值</param>
		/// <returns>暂停成功返回ture，否则返回false</returns>
		public static bool SchoolArticlePause(Entity.SchoolArticle info)
		{
			int intReturnValue = 0;
			intReturnValue = SqlDB.ExecuteNonQuery(CommandType.Text, "UPDATE [SchoolArticle] SET IsPause = "+  info.IsPause +"  WHERE Id =  " +  info.Id);
			if(intReturnValue == 1)
				return true;
			return false;
		}
		
		/// <summary>
		/// 获取所有的的值
		/// </summary>
		/// <param name="strWhere">条件，可以为空</param>
		/// <returns>返回DataTable</returns>
		public static DataTable SchoolArticleList(string strWhere)
		{
			string strSql;
			if (!string.IsNullOrEmpty(strWhere.Trim()))
				strSql = "SELECT * FROM [SchoolArticle] WHERE "+ strWhere +";";
			else
				strSql = "SELECT * FROM [SchoolArticle] ;";
			return SqlDB.ExecuteDataset(CommandType.Text, strSql).Tables[0];
		}
		
		
		/// <summary>
		/// 获取某一个DataTable
		/// </summary>
		/// <param name="Id">标识</param>
		/// <returns>返回DataTable</returns>
		public static DataTable SchoolArticleGet(int Id)
		{
			return SqlDB.ExecuteDataset(CommandType.Text, "SELECT * FROM [SchoolArticle] WHERE Id = "+Id+";").Tables[0];
		}
		
		/// <summary>
		/// 获取某一个实体
		/// </summary>
		/// <param name="Id">标识</param>
		/// <returns>返回Entity</returns>
		public static Entity.SchoolArticle SchoolArticleEntityGet(int Id)
		{
			Entity.SchoolArticle info = new Entity.SchoolArticle();
			DataTable dt = SqlDB.ExecuteDataset(CommandType.Text, "SELECT * FROM [SchoolArticle] WHERE Id = "+Id+";").Tables[0];
			if(dt.Rows.Count >0)
			{
				info.Id = Basic.Utils.StrToInt(dt.Rows[0]["Id"].ToString(),0);
				info.SchoolId = Basic.Utils.StrToInt(dt.Rows[0]["SchoolId"].ToString(),0);
				info.CategoryId = Basic.Utils.StrToInt(dt.Rows[0]["CategoryId"].ToString(),0);
				info.Icon = dt.Rows[0]["Icon"].ToString();
				info.Title = dt.Rows[0]["Title"].ToString();
				info.ShortTitle = dt.Rows[0]["ShortTitle"].ToString();
				info.MetaTitle = dt.Rows[0]["MetaTitle"].ToString();
				info.MetaKeyWords = dt.Rows[0]["MetaKeyWords"].ToString();
				info.MetaDescription = dt.Rows[0]["MetaDescription"].ToString();
				info.Summary = dt.Rows[0]["Summary"].ToString();
				info.Content = dt.Rows[0]["Content"].ToString();
				info.IsTuiJian = Basic.Utils.StrToInt(dt.Rows[0]["IsTuiJian"].ToString(),0);
				info.IsNew = Basic.Utils.StrToInt(dt.Rows[0]["IsNew"].ToString(),0);
				info.IsZhiDing = Basic.Utils.StrToInt(dt.Rows[0]["IsZhiDing"].ToString(),0);
				info.AddWid = Basic.Utils.StrToInt(dt.Rows[0]["AddWid"].ToString(),0);
				info.IsCheck = Basic.Utils.StrToInt(dt.Rows[0]["IsCheck"].ToString(),0);
				info.CheckWid = Basic.Utils.StrToInt(dt.Rows[0]["CheckWid"].ToString(),0);
				info.ClickNum = Basic.Utils.StrToInt(dt.Rows[0]["ClickNum"].ToString(),0);
				info.IsPause = Basic.Utils.StrToInt(dt.Rows[0]["IsPause"].ToString(),0);
                info.Year = Basic.Utils.StrToInt(dt.Rows[0]["Year"].ToString(), 0);

                info.AddTime = Basic.Utils.StrToDateTime(dt.Rows[0]["AddTime"].ToString());
                info.CheckTime = Basic.Utils.StrToDateTime(dt.Rows[0]["CheckTime"].ToString());
                info.PublishTime = Basic.Utils.StrToDateTime(dt.Rows[0]["PublishTime"].ToString());
                info.ZhiDingTime = Basic.Utils.StrToDateTime(dt.Rows[0]["ZhiDingTime"].ToString());

                return info;
			}
			return null;
		}
		
		/// <summary>
		/// 删除一个值
		/// </summary>
		/// <param name="Id">自增id的值</param>
		/// <returns>删除成功返回ture，否则返回false</returns>
		public static bool SchoolArticleDel(int Id)
		{
			int intReturnValue = 0;
			intReturnValue = SqlDB.ExecuteNonQuery(CommandType.Text, "DELETE [SchoolArticle]  WHERE Id =  " + Id);
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
		public static DataTable SchoolArticleTopGet(string strWhere,int TopNumber)
		{
			string strSql;
			if (!string.IsNullOrEmpty(strWhere.Trim()))
				strSql = "SELECT TOP " + TopNumber.ToString() + " * FROM [SchoolArticle] WHERE "+ strWhere +";";
			else
				strSql = "SELECT TOP " + TopNumber.ToString() + " * FROM [SchoolArticle] ;";
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
		public static DataTable SchoolArticlePageList(string strWhere,int PageSize,int PageIndex)
		{
			StringBuilder sbSql = new StringBuilder();
			sbSql.Append("SELECT * FROM SchoolArticle");
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
		public static int SchoolArticleCount(string strWhere)
		{
			string strSql;
			if (!string.IsNullOrEmpty(strWhere.Trim()))
				strSql = "SELECT COUNT(*) FROM [SchoolArticle] WHERE "+ strWhere +";";
			else
				strSql = "SELECT COUNT(*)  FROM [SchoolArticle] ;";
			return Basic.Utils.StrToInt(SqlDB.ExecuteScalar(CommandType.Text, strSql).ToString(), 0);
		}
	#endregion
		
	}
}

