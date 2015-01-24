using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;

using Basic;
using Entity;

namespace DAL
{
	public class BenKeFenShu
	{
		#region  BenKeFenShu
		/// <summary>
		/// 调用存储过程增加一个
		/// </summary>
		/// <param name="info">实体对象</param>
		/// <returns>正常返回大于 0 的自增id, 0代表重复，否则返回-1</returns>
		public static int BenKeFenShuAdd(Entity.BenKeFenShu info)
		{
			SqlParameter[] prams = {
				SqlDB.MakeInParam("@DataYear", SqlDbType.Int, 4, info.DataYear),
				SqlDB.MakeInParam("@KaoShengHao", SqlDbType.VarChar, 50, info.KaoShengHao),
				SqlDB.MakeInParam("@ccdm", SqlDbType.VarChar, 50, info.Ccdm),
				SqlDB.MakeInParam("@KeLei", SqlDbType.Int, 4, info.KeLei),
				SqlDB.MakeInParam("@KeLeiDaiMa", SqlDbType.VarChar, 50, info.KeLeiDaiMa),
				SqlDB.MakeInParam("@SchoolId", SqlDbType.Int, 4, info.SchoolId),
				SqlDB.MakeInParam("@YuanXiaoDaiMa", SqlDbType.VarChar, 50, info.YuanXiaoDaiMa),
				SqlDB.MakeInParam("@YuanXiaoMingCheng", SqlDbType.VarChar, 500, info.YuanXiaoMingCheng),
				SqlDB.MakeInParam("@ZyId", SqlDbType.Int, 4, info.ZyId),
				SqlDB.MakeInParam("@ZhuanYeDaiMa", SqlDbType.VarChar, 50, info.ZhuanYeDaiMa),
				SqlDB.MakeInParam("@ZhuanYeMingCheng", SqlDbType.VarChar, 500, info.ZhuanYeMingCheng),
				SqlDB.MakeInParam("@LuQuPiCi", SqlDbType.VarChar, 50, info.LuQuPiCi),
				SqlDB.MakeInParam("@PiCi", SqlDbType.Int, 4, info.PiCi),
				SqlDB.MakeInParam("@PcLeiBie", SqlDbType.Int, 4, info.PcLeiBie),
				SqlDB.MakeInParam("@FenShu", SqlDbType.Int, 4, info.FenShu),
				SqlDB.MakeInParam("@WeiCi", SqlDbType.Int, 4, info.WeiCi),
				SqlDB.MakeInParam("@PiCiXian", SqlDbType.Int, 4, info.PiCiXian),
				SqlDB.MakeInParam("@IsAbove", SqlDbType.Int, 4, info.IsAbove),
				SqlDB.MakeInParam("@ShengShi", SqlDbType.VarChar, 10, info.ShengShi),
				SqlDB.MakeInParam("@ShengShiDaiMa", SqlDbType.VarChar, 10, info.ShengShiDaiMa),
				SqlDB.MakeInParam("@ProvinceId", SqlDbType.Int, 4, info.ProvinceId),
			};
			return Basic.Utils.StrToInt(SqlDB.ExecuteScalar(CommandType.StoredProcedure, "BenKeFenShuAdd", prams).ToString(), -1);
		}
		
		/// <summary>
		/// 调用存储过程修改一个
		/// </summary>
		/// <param name="info">实体对象</param>
		/// <returns>更新成功返回ture，否则返回false</returns>
		public static bool BenKeFenShuEdit(Entity.BenKeFenShu info)
		{
			SqlParameter[] prams = {
				SqlDB.MakeInParam("@Id", SqlDbType.Int, 4, info.Id),
				SqlDB.MakeInParam("@DataYear", SqlDbType.Int, 4, info.DataYear),
				SqlDB.MakeInParam("@KaoShengHao", SqlDbType.VarChar, 50, info.KaoShengHao),
				SqlDB.MakeInParam("@ccdm", SqlDbType.VarChar, 50, info.Ccdm),
				SqlDB.MakeInParam("@KeLei", SqlDbType.Int, 4, info.KeLei),
				SqlDB.MakeInParam("@KeLeiDaiMa", SqlDbType.VarChar, 50, info.KeLeiDaiMa),
				SqlDB.MakeInParam("@SchoolId", SqlDbType.Int, 4, info.SchoolId),
				SqlDB.MakeInParam("@YuanXiaoDaiMa", SqlDbType.VarChar, 50, info.YuanXiaoDaiMa),
				SqlDB.MakeInParam("@YuanXiaoMingCheng", SqlDbType.VarChar, 500, info.YuanXiaoMingCheng),
				SqlDB.MakeInParam("@ZyId", SqlDbType.Int, 4, info.ZyId),
				SqlDB.MakeInParam("@ZhuanYeDaiMa", SqlDbType.VarChar, 50, info.ZhuanYeDaiMa),
				SqlDB.MakeInParam("@ZhuanYeMingCheng", SqlDbType.VarChar, 500, info.ZhuanYeMingCheng),
				SqlDB.MakeInParam("@LuQuPiCi", SqlDbType.VarChar, 50, info.LuQuPiCi),
				SqlDB.MakeInParam("@PiCi", SqlDbType.Int, 4, info.PiCi),
				SqlDB.MakeInParam("@PcLeiBie", SqlDbType.Int, 4, info.PcLeiBie),
				SqlDB.MakeInParam("@FenShu", SqlDbType.Int, 4, info.FenShu),
				SqlDB.MakeInParam("@WeiCi", SqlDbType.Int, 4, info.WeiCi),
				SqlDB.MakeInParam("@PiCiXian", SqlDbType.Int, 4, info.PiCiXian),
				SqlDB.MakeInParam("@IsAbove", SqlDbType.Int, 4, info.IsAbove),
				SqlDB.MakeInParam("@ShengShi", SqlDbType.VarChar, 10, info.ShengShi),
				SqlDB.MakeInParam("@ShengShiDaiMa", SqlDbType.VarChar, 10, info.ShengShiDaiMa),
				SqlDB.MakeInParam("@ProvinceId", SqlDbType.Int, 4, info.ProvinceId),
				};
			int intReturnValue = 0;
			intReturnValue = SqlDB.ExecuteNonQuery(CommandType.StoredProcedure, "BenKeFenShuEdit", prams);
			if(intReturnValue == 1)
				return true;
			return false;
		}
		
		/// <summary>
		/// 获取所有的的值
		/// </summary>
		/// <param name="strWhere">条件，可以为空</param>
		/// <returns>返回DataTable</returns>
        public static DataTable BenKeFenShuList(string strWhere, string strDataYear)
		{
			string strSql;
			if (!string.IsNullOrEmpty(strWhere.Trim()))
				strSql = "SELECT * FROM [" + DAL.Common.GetYearTableName("BenKeFenShu", strDataYear) + "] WHERE "+ strWhere +";";
			else
				strSql = "SELECT * FROM [" + DAL.Common.GetYearTableName("BenKeFenShu", strDataYear) + "] ;";
			return SqlDB.ExecuteDataset(CommandType.Text, strSql).Tables[0];
		}


        /// <summary>
        /// 获取所有的的值
        /// </summary>
        /// <param name="strWhere">条件，可以为空</param>
        /// <returns>返回DataTable</returns>
        public static DataTable BenKeFenShuList(string strItem, string strWhere, string strDataYear)
        {
            string strSql;
            if (!string.IsNullOrEmpty(strWhere.Trim()))
                strSql = "SELECT " + strItem + " FROM [" + DAL.Common.GetYearTableName("BenKeFenShu", strDataYear) + "] WHERE " + strWhere + ";";
            else
                strSql = "SELECT " + strItem + " FROM [" + DAL.Common.GetYearTableName("BenKeFenShu", strDataYear) + "] ;";
            return SqlDB.ExecuteDataset(CommandType.Text, strSql).Tables[0];
        }

		/// <summary>
		/// 获取某一个DataTable
		/// </summary>
		/// <param name="Id">标识</param>
		/// <returns>返回DataTable</returns>
        public static DataTable BenKeFenShuGet(int Id, string strDataYear)
		{
			return SqlDB.ExecuteDataset(CommandType.Text, "SELECT * FROM [" + DAL.Common.GetYearTableName("BenKeFenShu", strDataYear) + "] WHERE Id = "+Id+";").Tables[0];
		}
		
		/// <summary>
		/// 获取某一个实体
		/// </summary>
		/// <param name="Id">标识</param>
		/// <returns>返回Entity</returns>
        public static Entity.BenKeFenShu BenKeFenShuEntityGet(int Id, string strDataYear)
		{
			Entity.BenKeFenShu info = new Entity.BenKeFenShu();
			DataTable dt = SqlDB.ExecuteDataset(CommandType.Text, "SELECT * FROM [" + DAL.Common.GetYearTableName("BenKeFenShu", strDataYear) + "] WHERE Id = "+Id+";").Tables[0];
			if(dt.Rows.Count >0)
			{
				info.Id = Basic.Utils.StrToInt(dt.Rows[0]["Id"].ToString(),0);
				info.DataYear = Basic.Utils.StrToInt(dt.Rows[0]["DataYear"].ToString(),0);
				info.KaoShengHao = dt.Rows[0]["KaoShengHao"].ToString();
				info.Ccdm = dt.Rows[0]["ccdm"].ToString();
				info.KeLei = Basic.Utils.StrToInt(dt.Rows[0]["KeLei"].ToString(),0);
				info.KeLeiDaiMa = dt.Rows[0]["KeLeiDaiMa"].ToString();
				info.SchoolId = Basic.Utils.StrToInt(dt.Rows[0]["SchoolId"].ToString(),0);
				info.YuanXiaoDaiMa = dt.Rows[0]["YuanXiaoDaiMa"].ToString();
				info.YuanXiaoMingCheng = dt.Rows[0]["YuanXiaoMingCheng"].ToString();
				info.ZyId = Basic.Utils.StrToInt(dt.Rows[0]["ZyId"].ToString(),0);
				info.ZhuanYeDaiMa = dt.Rows[0]["ZhuanYeDaiMa"].ToString();
				info.ZhuanYeMingCheng = dt.Rows[0]["ZhuanYeMingCheng"].ToString();
				info.LuQuPiCi = dt.Rows[0]["LuQuPiCi"].ToString();
				info.PiCi = Basic.Utils.StrToInt(dt.Rows[0]["PiCi"].ToString(),0);
				info.PcLeiBie = Basic.Utils.StrToInt(dt.Rows[0]["PcLeiBie"].ToString(),0);
				info.FenShu = Basic.Utils.StrToInt(dt.Rows[0]["FenShu"].ToString(),0);
				info.WeiCi = Basic.Utils.StrToInt(dt.Rows[0]["WeiCi"].ToString(),0);
				info.PiCiXian = Basic.Utils.StrToInt(dt.Rows[0]["PiCiXian"].ToString(),0);
				info.IsAbove = Basic.Utils.StrToInt(dt.Rows[0]["IsAbove"].ToString(),0);
				info.ShengShi = dt.Rows[0]["ShengShi"].ToString();
				info.ShengShiDaiMa = dt.Rows[0]["ShengShiDaiMa"].ToString();
				info.ProvinceId = Basic.Utils.StrToInt(dt.Rows[0]["ProvinceId"].ToString(),0);
			}
			return info;
		}
		
		/// <summary>
		/// 删除一个值
		/// </summary>
		/// <param name="Id">自增id的值</param>
		/// <returns>删除成功返回ture，否则返回false</returns>
        public static bool BenKeFenShuDel(int Id, string strDataYear)
		{
			int intReturnValue = 0;
			intReturnValue = SqlDB.ExecuteNonQuery(CommandType.Text, "DELETE [" + DAL.Common.GetYearTableName("BenKeFenShu", strDataYear) + "]  WHERE Id =  " + Id);
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
        public static DataTable BenKeFenShuTopGet(string strWhere, int TopNumber, string strDataYear)
		{
			string strSql;
			if (!string.IsNullOrEmpty(strWhere.Trim()))
				strSql = "SELECT TOP " + TopNumber.ToString() + " * FROM [" + DAL.Common.GetYearTableName("BenKeFenShu", strDataYear) + "] WHERE "+ strWhere +";";
			else
				strSql = "SELECT TOP " + TopNumber.ToString() + " * FROM [" + DAL.Common.GetYearTableName("BenKeFenShu", strDataYear) + "] ;";
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
        public static DataTable BenKeFenShuPageList(string strWhere, int PageSize, int PageIndex, string strDataYear)
		{
			StringBuilder sbSql = new StringBuilder();
            sbSql.Append("SELECT * FROM [" + DAL.Common.GetYearTableName("BenKeFenShu", strDataYear) + "]");
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
        public static int BenKeFenShuCount(string strWhere, string strDataYear)
		{
			string strSql;
			if (!string.IsNullOrEmpty(strWhere.Trim()))
				strSql = "SELECT COUNT(*) FROM [" + DAL.Common.GetYearTableName("BenKeFenShu", strDataYear) + "] WHERE "+ strWhere +"";
			else
				strSql = "SELECT COUNT(*)  FROM [" + DAL.Common.GetYearTableName("BenKeFenShu", strDataYear) + "] ";
			return Basic.Utils.StrToInt(SqlDB.ExecuteScalar(CommandType.Text, strSql).ToString(), 0);
		}
	#endregion
		
	}
}

