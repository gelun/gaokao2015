using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;

using Basic;
using Entity;

namespace DAL
{
	public class SchoolProfessional
	{
		#region  SchoolProfessional
		/// <summary>
		/// 调用存储过程增加一个
		/// </summary>
		/// <param name="info">实体对象</param>
		/// <returns>正常返回大于 0 的自增id, 0代表重复，否则返回-1</returns>
		public static int SchoolProfessionalAdd(Entity.SchoolProfessional info)
		{
			SqlParameter[] prams = {
				SqlDB.MakeInParam("@SchoolDisciplinesId", SqlDbType.Int, 4, info.SchoolDisciplinesId),
				SqlDB.MakeInParam("@ProfessionalId", SqlDbType.Int, 4, info.ProfessionalId),
				SqlDB.MakeInParam("@ProfessionalName", SqlDbType.NVarChar, 100, info.ProfessionalName),
				SqlDB.MakeInParam("@ProfessionalIntro", SqlDbType.NText, 0, info.ProfessionalIntro),
				SqlDB.MakeInParam("@IsTeSe", SqlDbType.Int, 4, info.IsTeSe),
				SqlDB.MakeInParam("@IsXueKePaiMing", SqlDbType.Int, 4, info.IsXueKePaiMing),
				SqlDB.MakeInParam("@IsYiJiZhongDian", SqlDbType.Int, 4, info.IsYiJiZhongDian),
				SqlDB.MakeInParam("@IsErJiZhongDian", SqlDbType.Int, 4, info.IsErJiZhongDian),
				SqlDB.MakeInParam("@AddTime", SqlDbType.DateTime, 8, info.AddTime),
				SqlDB.MakeInParam("@AddWid", SqlDbType.Int, 4, info.AddWid),
				SqlDB.MakeInParam("@ClickNum", SqlDbType.Int, 4, info.ClickNum),
				SqlDB.MakeInParam("@IsPause", SqlDbType.Int, 4, info.IsPause),
			};
			return Basic.Utils.StrToInt(SqlDB.ExecuteScalar(CommandType.StoredProcedure, "SchoolProfessionalAdd", prams).ToString(), -1);
		}
		
		/// <summary>
		/// 调用存储过程修改一个
		/// </summary>
		/// <param name="info">实体对象</param>
		/// <returns>更新成功返回ture，否则返回false</returns>
		public static bool SchoolProfessionalEdit(Entity.SchoolProfessional info)
		{
			SqlParameter[] prams = {
				SqlDB.MakeInParam("@Id", SqlDbType.Int, 4, info.Id),
				SqlDB.MakeInParam("@SchoolDisciplinesId", SqlDbType.Int, 4, info.SchoolDisciplinesId),
				SqlDB.MakeInParam("@ProfessionalId", SqlDbType.Int, 4, info.ProfessionalId),
				SqlDB.MakeInParam("@ProfessionalName", SqlDbType.NVarChar, 100, info.ProfessionalName),
				SqlDB.MakeInParam("@ProfessionalIntro", SqlDbType.NText, 0, info.ProfessionalIntro),
				SqlDB.MakeInParam("@IsTeSe", SqlDbType.Int, 4, info.IsTeSe),
				SqlDB.MakeInParam("@IsXueKePaiMing", SqlDbType.Int, 4, info.IsXueKePaiMing),
				SqlDB.MakeInParam("@IsYiJiZhongDian", SqlDbType.Int, 4, info.IsYiJiZhongDian),
				SqlDB.MakeInParam("@IsErJiZhongDian", SqlDbType.Int, 4, info.IsErJiZhongDian),
				SqlDB.MakeInParam("@AddTime", SqlDbType.DateTime, 8, info.AddTime),
				SqlDB.MakeInParam("@AddWid", SqlDbType.Int, 4, info.AddWid),
				SqlDB.MakeInParam("@ClickNum", SqlDbType.Int, 4, info.ClickNum),
				SqlDB.MakeInParam("@IsPause", SqlDbType.Int, 4, info.IsPause),
				};
			int intReturnValue = 0;
			intReturnValue = SqlDB.ExecuteNonQuery(CommandType.StoredProcedure, "SchoolProfessionalEdit", prams);
			if(intReturnValue == 1)
				return true;
			return false;
		}
		
		/// <summary>
		/// 暂停该值
		/// </summary>
		/// <param name="Id">自增id的值</param>
		/// <returns>暂停成功返回ture，否则返回false</returns>
		public static bool SchoolProfessionalPause(Entity.SchoolProfessional info)
		{
			int intReturnValue = 0;
			intReturnValue = SqlDB.ExecuteNonQuery(CommandType.Text, "UPDATE [SchoolProfessional] SET IsPause = "+  info.IsPause +"  WHERE Id =  " +  info.Id);
			if(intReturnValue == 1)
				return true;
			return false;
		}
		
		/// <summary>
		/// 获取所有的的值
		/// </summary>
		/// <param name="strWhere">条件，可以为空</param>
		/// <returns>返回DataTable</returns>
		public static DataTable SchoolProfessionalList(string strWhere)
		{
			string strSql;
			if (!string.IsNullOrEmpty(strWhere.Trim()))
				strSql = "SELECT * FROM [SchoolProfessional] WHERE "+ strWhere +";";
			else
				strSql = "SELECT * FROM [SchoolProfessional] ;";
			return SqlDB.ExecuteDataset(CommandType.Text, strSql).Tables[0];
		}
		
		
		/// <summary>
		/// 获取某一个DataTable
		/// </summary>
		/// <param name="Id">标识</param>
		/// <returns>返回DataTable</returns>
		public static DataTable SchoolProfessionalGet(int Id)
		{
			return SqlDB.ExecuteDataset(CommandType.Text, "SELECT * FROM [SchoolProfessional] WHERE Id = "+Id+";").Tables[0];
		}
		
		/// <summary>
		/// 获取某一个实体
		/// </summary>
		/// <param name="Id">标识</param>
		/// <returns>返回Entity</returns>
		public static Entity.SchoolProfessional SchoolProfessionalEntityGet(int Id)
		{
			Entity.SchoolProfessional info = new Entity.SchoolProfessional();
            DataTable dt = SqlDB.ExecuteDataset(CommandType.Text, "select * from SchoolProfessional as sp,SchoolDisciplines as sd where sp.SchoolDisciplinesId = sd.Id AND sp.Id = " + Id + ";").Tables[0];
			if(dt.Rows.Count >0)
			{
				info.Id = Basic.Utils.StrToInt(dt.Rows[0]["Id"].ToString(),0);
				info.SchoolDisciplinesId = Basic.Utils.StrToInt(dt.Rows[0]["SchoolDisciplinesId"].ToString(),0);
				info.ProfessionalId = Basic.Utils.StrToInt(dt.Rows[0]["ProfessionalId"].ToString(),0);
				info.ProfessionalName = dt.Rows[0]["ProfessionalName"].ToString();
				info.ProfessionalIntro = dt.Rows[0]["ProfessionalIntro"].ToString();
				info.IsTeSe = Basic.Utils.StrToInt(dt.Rows[0]["IsTeSe"].ToString(),0);
				info.IsXueKePaiMing = Basic.Utils.StrToInt(dt.Rows[0]["IsXueKePaiMing"].ToString(),0);
				info.IsYiJiZhongDian = Basic.Utils.StrToInt(dt.Rows[0]["IsYiJiZhongDian"].ToString(),0);
				info.IsErJiZhongDian = Basic.Utils.StrToInt(dt.Rows[0]["IsErJiZhongDian"].ToString(),0);
				info.AddWid = Basic.Utils.StrToInt(dt.Rows[0]["AddWid"].ToString(),0);
				info.ClickNum = Basic.Utils.StrToInt(dt.Rows[0]["ClickNum"].ToString(),0);
                info.IsPause = Basic.Utils.StrToInt(dt.Rows[0]["IsPause"].ToString(), 0);
                info.SchoolId = Basic.Utils.StrToInt(dt.Rows[0]["SchoolId"].ToString(), 0);

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
		public static bool SchoolProfessionalDel(int Id)
		{
			int intReturnValue = 0;
			intReturnValue = SqlDB.ExecuteNonQuery(CommandType.Text, "DELETE [SchoolProfessional]  WHERE Id =  " + Id);
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
		public static DataTable SchoolProfessionalTopGet(string strWhere,int TopNumber)
		{
			string strSql;
			if (!string.IsNullOrEmpty(strWhere.Trim()))
				strSql = "SELECT TOP " + TopNumber.ToString() + " * FROM [SchoolProfessional] WHERE "+ strWhere +";";
			else
				strSql = "SELECT TOP " + TopNumber.ToString() + " * FROM [SchoolProfessional] ;";
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
		public static DataTable SchoolProfessionalPageList(string strWhere,int PageSize,int PageIndex)
		{
			StringBuilder sbSql = new StringBuilder();
			sbSql.Append("SELECT * FROM SchoolProfessional");
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
		public static int SchoolProfessionalCount(string strWhere)
		{
			string strSql;
			if (!string.IsNullOrEmpty(strWhere.Trim()))
				strSql = "SELECT COUNT(*) FROM [SchoolProfessional] WHERE "+ strWhere +";";
			else
				strSql = "SELECT COUNT(*)  FROM [SchoolProfessional] ;";
			return Basic.Utils.StrToInt(SqlDB.ExecuteScalar(CommandType.Text, strSql).ToString(), 0);
		}
	#endregion
		
	}
}

