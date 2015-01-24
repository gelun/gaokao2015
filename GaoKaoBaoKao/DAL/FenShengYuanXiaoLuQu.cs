using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;

using Basic;
using Entity;

namespace DAL
{
	public class FenShengYuanXiaoLuQu
	{
		#region  FenShengYuanXiaoLuQu
		/// <summary>
		/// 调用存储过程增加一个
		/// </summary>
		/// <param name="info">实体对象</param>
		/// <returns>正常返回大于 0 的自增id, 0代表重复，否则返回-1</returns>
		public static int FenShengYuanXiaoLuQuAdd(Entity.FenShengYuanXiaoLuQu info)
		{
			SqlParameter[] prams = {
				SqlDB.MakeInParam("@DataYear", SqlDbType.Int, 4, info.DataYear),
				SqlDB.MakeInParam("@ProvinceId", SqlDbType.Int, 4, info.ProvinceId),
				SqlDB.MakeInParam("@ShengShi", SqlDbType.NVarChar, 15, info.ShengShi),
				SqlDB.MakeInParam("@CengCi", SqlDbType.Int, 4, info.CengCi),
				SqlDB.MakeInParam("@PiCi", SqlDbType.Int, 4, info.PiCi),
				SqlDB.MakeInParam("@PcLeiBie", SqlDbType.Int, 4, info.PcLeiBie),
				SqlDB.MakeInParam("@KeLei", SqlDbType.Int, 4, info.KeLei),
				SqlDB.MakeInParam("@KeLeiMingCheng", SqlDbType.NVarChar, 50, info.KeLeiMingCheng),
				SqlDB.MakeInParam("@SchoolId", SqlDbType.Int, 4, info.SchoolId),
				SqlDB.MakeInParam("@SchoolProvinceId", SqlDbType.Int, 4, info.SchoolProvinceId),
				SqlDB.MakeInParam("@YuanXiaoDaiMa", SqlDbType.Char, 5, info.YuanXiaoDaiMa),
				SqlDB.MakeInParam("@YuanXiaoMingCheng", SqlDbType.NVarChar, 64, info.YuanXiaoMingCheng),
				SqlDB.MakeInParam("@ZuiGaoFen", SqlDbType.Int, 4, info.ZuiGaoFen),
				SqlDB.MakeInParam("@PingJunFen", SqlDbType.Int, 4, info.PingJunFen),
				SqlDB.MakeInParam("@ZuiDiFen", SqlDbType.Int, 4, info.ZuiDiFen),
				SqlDB.MakeInParam("@ZuiDaWeiCi", SqlDbType.Int, 4, info.ZuiDaWeiCi),
				SqlDB.MakeInParam("@PingJunWeiCi", SqlDbType.Int, 4, info.PingJunWeiCi),
				SqlDB.MakeInParam("@ZuiXiaoWeiCi", SqlDbType.Int, 4, info.ZuiXiaoWeiCi),
				SqlDB.MakeInParam("@PiCiXian", SqlDbType.Int, 4, info.PiCiXian),
				SqlDB.MakeInParam("@PingJunXianCha", SqlDbType.Int, 4, info.PingJunXianCha),
				SqlDB.MakeInParam("@JiHuaShu", SqlDbType.Int, 4, info.JiHuaShu),
				SqlDB.MakeInParam("@TouDangBiLi", SqlDbType.Int, 4, info.TouDangBiLi),
				SqlDB.MakeInParam("@TouChuShu", SqlDbType.Int, 4, info.TouChuShu),
				SqlDB.MakeInParam("@LuQuShu", SqlDbType.Int, 4, info.LuQuShu),
				SqlDB.MakeInParam("@TouChuZuiDiFen", SqlDbType.Int, 4, info.TouChuZuiDiFen),
				SqlDB.MakeInParam("@TouChuZuiGaoFen", SqlDbType.Int, 4, info.TouChuZuiGaoFen),
				SqlDB.MakeInParam("@TouChuZuiXiaoWeiCi", SqlDbType.Int, 4, info.TouChuZuiXiaoWeiCi),
				SqlDB.MakeInParam("@TouChuZuiDaWeiCi", SqlDbType.Int, 4, info.TouChuZuiDaWeiCi),
				SqlDB.MakeInParam("@IsBuLu", SqlDbType.Int, 4, info.IsBuLu),
			};
			return Basic.Utils.StrToInt(SqlDB.ExecuteScalar(CommandType.StoredProcedure, "FenShengYuanXiaoLuQuAdd", prams).ToString(), -1);
		}
		
		/// <summary>
		/// 调用存储过程修改一个
		/// </summary>
		/// <param name="info">实体对象</param>
		/// <returns>更新成功返回ture，否则返回false</returns>
		public static bool FenShengYuanXiaoLuQuEdit(Entity.FenShengYuanXiaoLuQu info)
		{
			SqlParameter[] prams = {
				SqlDB.MakeInParam("@Id", SqlDbType.Int, 4, info.Id),
				SqlDB.MakeInParam("@DataYear", SqlDbType.Int, 4, info.DataYear),
				SqlDB.MakeInParam("@ProvinceId", SqlDbType.Int, 4, info.ProvinceId),
				SqlDB.MakeInParam("@ShengShi", SqlDbType.NVarChar, 15, info.ShengShi),
				SqlDB.MakeInParam("@CengCi", SqlDbType.Int, 4, info.CengCi),
				SqlDB.MakeInParam("@PiCi", SqlDbType.Int, 4, info.PiCi),
				SqlDB.MakeInParam("@PcLeiBie", SqlDbType.Int, 4, info.PcLeiBie),
				SqlDB.MakeInParam("@KeLei", SqlDbType.Int, 4, info.KeLei),
				SqlDB.MakeInParam("@KeLeiMingCheng", SqlDbType.NVarChar, 50, info.KeLeiMingCheng),
				SqlDB.MakeInParam("@SchoolId", SqlDbType.Int, 4, info.SchoolId),
				SqlDB.MakeInParam("@SchoolProvinceId", SqlDbType.Int, 4, info.SchoolProvinceId),
				SqlDB.MakeInParam("@YuanXiaoDaiMa", SqlDbType.Char, 5, info.YuanXiaoDaiMa),
				SqlDB.MakeInParam("@YuanXiaoMingCheng", SqlDbType.NVarChar, 64, info.YuanXiaoMingCheng),
				SqlDB.MakeInParam("@ZuiGaoFen", SqlDbType.Int, 4, info.ZuiGaoFen),
				SqlDB.MakeInParam("@PingJunFen", SqlDbType.Int, 4, info.PingJunFen),
				SqlDB.MakeInParam("@ZuiDiFen", SqlDbType.Int, 4, info.ZuiDiFen),
				SqlDB.MakeInParam("@ZuiDaWeiCi", SqlDbType.Int, 4, info.ZuiDaWeiCi),
				SqlDB.MakeInParam("@PingJunWeiCi", SqlDbType.Int, 4, info.PingJunWeiCi),
				SqlDB.MakeInParam("@ZuiXiaoWeiCi", SqlDbType.Int, 4, info.ZuiXiaoWeiCi),
				SqlDB.MakeInParam("@PiCiXian", SqlDbType.Int, 4, info.PiCiXian),
				SqlDB.MakeInParam("@PingJunXianCha", SqlDbType.Int, 4, info.PingJunXianCha),
				SqlDB.MakeInParam("@JiHuaShu", SqlDbType.Int, 4, info.JiHuaShu),
				SqlDB.MakeInParam("@TouDangBiLi", SqlDbType.Int, 4, info.TouDangBiLi),
				SqlDB.MakeInParam("@TouChuShu", SqlDbType.Int, 4, info.TouChuShu),
				SqlDB.MakeInParam("@LuQuShu", SqlDbType.Int, 4, info.LuQuShu),
				SqlDB.MakeInParam("@TouChuZuiDiFen", SqlDbType.Int, 4, info.TouChuZuiDiFen),
				SqlDB.MakeInParam("@TouChuZuiGaoFen", SqlDbType.Int, 4, info.TouChuZuiGaoFen),
				SqlDB.MakeInParam("@TouChuZuiXiaoWeiCi", SqlDbType.Int, 4, info.TouChuZuiXiaoWeiCi),
				SqlDB.MakeInParam("@TouChuZuiDaWeiCi", SqlDbType.Int, 4, info.TouChuZuiDaWeiCi),
				SqlDB.MakeInParam("@IsBuLu", SqlDbType.Int, 4, info.IsBuLu),
				};
			int intReturnValue = 0;
			intReturnValue = SqlDB.ExecuteNonQuery(CommandType.StoredProcedure, "FenShengYuanXiaoLuQuEdit", prams);
			if(intReturnValue == 1)
				return true;
			return false;
		}
		
		/// <summary>
		/// 暂停该值
		/// </summary>
		/// <param name="Id">自增id的值</param>
		/// <returns>暂停成功返回ture，否则返回false</returns>
        //public static bool FenShengYuanXiaoLuQuPause(Entity.FenShengYuanXiaoLuQu info)
        //{
        //    int intReturnValue = 0;
        //    intReturnValue = SqlDB.ExecuteNonQuery(CommandType.Text, "UPDATE [" + DAL.Common.GetYearTableName("FenShengYuanXiaoLuQu", strDataYear ) + "] SET IsPause = "+  info.IsPause +"  WHERE Id =  " +  info.Id);
        //    if(intReturnValue == 1)
        //        return true;
        //    return false;
        //}
		
		/// <summary>
		/// 获取所有的的值
		/// </summary>
		/// <param name="strWhere">条件，可以为空</param>
		/// <returns>返回DataTable</returns>
        //public static DataTable FenShengYuanXiaoLuQuList(string strWhere, string strDataYear)
        //{
        //    string strSql;
        //    if (!string.IsNullOrEmpty(strWhere.Trim()))
        //        strSql = "SELECT * FROM [" + DAL.Common.GetYearTableName("FenShengYuanXiaoLuQu", strDataYear ) + "] WHERE "+ strWhere +";";
        //    else
        //        strSql = "SELECT * FROM [" + DAL.Common.GetYearTableName("FenShengYuanXiaoLuQu", strDataYear ) + "] ;";
        //    return SqlDB.ExecuteDataset(CommandType.Text, strSql).Tables[0];
        //}


        public static DataTable FenShengYuanXiaoLuQuList(string strWhere,int ProvinceId, string strDataYear)
        {
            string strSql;
            if (!string.IsNullOrEmpty(strWhere.Trim()))
                strSql = "SELECT * FROM [" + DAL.Common.GetProvinceTableName("FenShengYuanXiaoLuQu",ProvinceId, strDataYear) + "] WHERE " + strWhere + ";";
            else
                strSql = "SELECT * FROM [" + DAL.Common.GetProvinceTableName("FenShengYuanXiaoLuQu",ProvinceId, strDataYear) + "] ;";
            return SqlDB.ExecuteDataset(CommandType.Text, strSql).Tables[0];
        }


        public static DataTable FenShengYuanXiaoLuQuList(int SchoolId, int StudentProvinceId)
        {
            string strSql = "SELECT * FROM [" + DAL.Common.GetYearTableName("FenShengYuanXiaoLuQu", "All") + "] WHERE SchoolId = " + SchoolId + " AND  ProvinceId" + StudentProvinceId;
            return SqlDB.ExecuteDataset(CommandType.Text, strSql).Tables[0];
        }



        public static DataTable GetFenShengYuanXiaoList(string strWhere,string strDataYear)
        {
            string strSql = "SELECT s.Id,s.SchoolName,s.Logo FROM [" + DAL.Common.GetYearTableName("FenShengYuanXiaoLuQu", strDataYear ) + "] as fsyx,[School] as s WHERE fsyx.SchoolId = s.Id ";
            if (!string.IsNullOrEmpty(strWhere.Trim()))
                strSql += " AND " + strWhere + ";";
            return SqlDB.ExecuteDataset(CommandType.Text, strSql).Tables[0];
        }
		
		/// <summary>
		/// 获取某一个DataTable
		/// </summary>
		/// <param name="Id">标识</param>
		/// <returns>返回DataTable</returns>
        public static DataTable FenShengYuanXiaoLuQuGet(int Id, string strDataYear)
		{
			return SqlDB.ExecuteDataset(CommandType.Text, "SELECT * FROM [" + DAL.Common.GetYearTableName("FenShengYuanXiaoLuQu", strDataYear ) + "] WHERE Id = "+Id+";").Tables[0];
		}
		
		/// <summary>
		/// 获取某一个实体
		/// </summary>
		/// <param name="Id">标识</param>
		/// <returns>返回Entity</returns>
        public static Entity.FenShengYuanXiaoLuQu FenShengYuanXiaoLuQuEntityGet(int ProvinceId, int PiCi, int KeLei, string strDataYear)
		{
			Entity.FenShengYuanXiaoLuQu info = new Entity.FenShengYuanXiaoLuQu();
            DataTable dt = SqlDB.ExecuteDataset(CommandType.Text, "SELECT * FROM [" + DAL.Common.GetYearTableName("FenShengYuanXiaoLuQu", strDataYear ) + "] WHERE ProvinceId = " + ProvinceId + " AND PiCi = " + PiCi + " AND KeLei = " + KeLei + ";").Tables[0];
			if(dt.Rows.Count >0)
			{
				info.Id = Basic.Utils.StrToInt(dt.Rows[0]["Id"].ToString(),0);
				info.DataYear = Basic.Utils.StrToInt(dt.Rows[0]["DataYear"].ToString(),0);
				info.ProvinceId = Basic.Utils.StrToInt(dt.Rows[0]["ProvinceId"].ToString(),0);
				info.ShengShi = dt.Rows[0]["ShengShi"].ToString();
				info.CengCi = Basic.Utils.StrToInt(dt.Rows[0]["CengCi"].ToString(),0);
				info.PiCi = Basic.Utils.StrToInt(dt.Rows[0]["PiCi"].ToString(),0);
				info.PcLeiBie = Basic.Utils.StrToInt(dt.Rows[0]["PcLeiBie"].ToString(),0);
				info.KeLei = Basic.Utils.StrToInt(dt.Rows[0]["KeLei"].ToString(),0);
				info.KeLeiMingCheng = dt.Rows[0]["KeLeiMingCheng"].ToString();
				info.SchoolId = Basic.Utils.StrToInt(dt.Rows[0]["SchoolId"].ToString(),0);
				info.SchoolProvinceId = Basic.Utils.StrToInt(dt.Rows[0]["SchoolProvinceId"].ToString(),0);
				info.YuanXiaoDaiMa = dt.Rows[0]["YuanXiaoDaiMa"].ToString();
				info.YuanXiaoMingCheng = dt.Rows[0]["YuanXiaoMingCheng"].ToString();
				info.ZuiGaoFen = Basic.Utils.StrToInt(dt.Rows[0]["ZuiGaoFen"].ToString(),0);
				info.PingJunFen = Basic.Utils.StrToInt(dt.Rows[0]["PingJunFen"].ToString(),0);
				info.ZuiDiFen = Basic.Utils.StrToInt(dt.Rows[0]["ZuiDiFen"].ToString(),0);
				info.ZuiDaWeiCi = Basic.Utils.StrToInt(dt.Rows[0]["ZuiDaWeiCi"].ToString(),0);
				info.PingJunWeiCi = Basic.Utils.StrToInt(dt.Rows[0]["PingJunWeiCi"].ToString(),0);
				info.ZuiXiaoWeiCi = Basic.Utils.StrToInt(dt.Rows[0]["ZuiXiaoWeiCi"].ToString(),0);
				info.PiCiXian = Basic.Utils.StrToInt(dt.Rows[0]["PiCiXian"].ToString(),0);
				info.PingJunXianCha = Basic.Utils.StrToInt(dt.Rows[0]["PingJunXianCha"].ToString(),0);
				info.JiHuaShu = Basic.Utils.StrToInt(dt.Rows[0]["JiHuaShu"].ToString(),0);
				info.TouDangBiLi = Basic.Utils.StrToInt(dt.Rows[0]["TouDangBiLi"].ToString(),0);
				info.TouChuShu = Basic.Utils.StrToInt(dt.Rows[0]["TouChuShu"].ToString(),0);
				info.LuQuShu = Basic.Utils.StrToInt(dt.Rows[0]["LuQuShu"].ToString(),0);
				info.TouChuZuiDiFen = Basic.Utils.StrToInt(dt.Rows[0]["TouChuZuiDiFen"].ToString(),0);
				info.TouChuZuiGaoFen = Basic.Utils.StrToInt(dt.Rows[0]["TouChuZuiGaoFen"].ToString(),0);
				info.TouChuZuiXiaoWeiCi = Basic.Utils.StrToInt(dt.Rows[0]["TouChuZuiXiaoWeiCi"].ToString(),0);
				info.TouChuZuiDaWeiCi = Basic.Utils.StrToInt(dt.Rows[0]["TouChuZuiDaWeiCi"].ToString(),0);
				info.IsBuLu = Basic.Utils.StrToInt(dt.Rows[0]["IsBuLu"].ToString(),0);
			}
			return info;
		}
        public static Entity.FenShengYuanXiaoLuQu FenShengYuanXiaoLuQuAllEntityGet(int ProvinceId, int PiCi, int KeLei,int SchoolId ,string strDataYear)
        {
            Entity.FenShengYuanXiaoLuQu info = new Entity.FenShengYuanXiaoLuQu();
            DataTable dt = SqlDB.ExecuteDataset(CommandType.Text, "SELECT * FROM [" + DAL.Common.GetYearTableName("FenShengYuanXiaoLuQu", "All") + "] WHERE DataYear = " + strDataYear + " AND ProvinceId = " + ProvinceId + " AND PiCi = " + PiCi + " AND KeLei = " + KeLei + " AND SchoolId = " + SchoolId).Tables[0];
            if (dt.Rows.Count > 0)
            {
                info.Id = Basic.Utils.StrToInt(dt.Rows[0]["Id"].ToString(), 0);
                info.DataYear = Basic.Utils.StrToInt(dt.Rows[0]["DataYear"].ToString(), 0);
                info.ProvinceId = Basic.Utils.StrToInt(dt.Rows[0]["ProvinceId"].ToString(), 0);
                info.ShengShi = dt.Rows[0]["ShengShi"].ToString();
                info.CengCi = Basic.Utils.StrToInt(dt.Rows[0]["CengCi"].ToString(), 0);
                info.PiCi = Basic.Utils.StrToInt(dt.Rows[0]["PiCi"].ToString(), 0);
                info.PcLeiBie = Basic.Utils.StrToInt(dt.Rows[0]["PcLeiBie"].ToString(), 0);
                info.KeLei = Basic.Utils.StrToInt(dt.Rows[0]["KeLei"].ToString(), 0);
                info.KeLeiMingCheng = dt.Rows[0]["KeLeiMingCheng"].ToString();
                info.SchoolId = Basic.Utils.StrToInt(dt.Rows[0]["SchoolId"].ToString(), 0);
                info.SchoolProvinceId = Basic.Utils.StrToInt(dt.Rows[0]["SchoolProvinceId"].ToString(), 0);
                info.YuanXiaoDaiMa = dt.Rows[0]["YuanXiaoDaiMa"].ToString();
                info.YuanXiaoMingCheng = dt.Rows[0]["YuanXiaoMingCheng"].ToString();
                info.ZuiGaoFen = Basic.Utils.StrToInt(dt.Rows[0]["ZuiGaoFen"].ToString(), 0);
                info.PingJunFen = Basic.Utils.StrToInt(dt.Rows[0]["PingJunFen"].ToString(), 0);
                info.ZuiDiFen = Basic.Utils.StrToInt(dt.Rows[0]["ZuiDiFen"].ToString(), 0);
                info.ZuiDaWeiCi = Basic.Utils.StrToInt(dt.Rows[0]["ZuiDaWeiCi"].ToString(), 0);
                info.PingJunWeiCi = Basic.Utils.StrToInt(dt.Rows[0]["PingJunWeiCi"].ToString(), 0);
                info.ZuiXiaoWeiCi = Basic.Utils.StrToInt(dt.Rows[0]["ZuiXiaoWeiCi"].ToString(), 0);
                info.PiCiXian = Basic.Utils.StrToInt(dt.Rows[0]["PiCiXian"].ToString(), 0);
                info.PingJunXianCha = Basic.Utils.StrToInt(dt.Rows[0]["PingJunXianCha"].ToString(), 0);
                info.JiHuaShu = Basic.Utils.StrToInt(dt.Rows[0]["JiHuaShu"].ToString(), 0);
                info.TouDangBiLi = Basic.Utils.StrToInt(dt.Rows[0]["TouDangBiLi"].ToString(), 0);
                info.TouChuShu = Basic.Utils.StrToInt(dt.Rows[0]["TouChuShu"].ToString(), 0);
                info.LuQuShu = Basic.Utils.StrToInt(dt.Rows[0]["LuQuShu"].ToString(), 0);
                info.TouChuZuiDiFen = Basic.Utils.StrToInt(dt.Rows[0]["TouChuZuiDiFen"].ToString(), 0);
                info.TouChuZuiGaoFen = Basic.Utils.StrToInt(dt.Rows[0]["TouChuZuiGaoFen"].ToString(), 0);
                info.TouChuZuiXiaoWeiCi = Basic.Utils.StrToInt(dt.Rows[0]["TouChuZuiXiaoWeiCi"].ToString(), 0);
                info.TouChuZuiDaWeiCi = Basic.Utils.StrToInt(dt.Rows[0]["TouChuZuiDaWeiCi"].ToString(), 0);
                info.IsBuLu = Basic.Utils.StrToInt(dt.Rows[0]["IsBuLu"].ToString(), 0);
            }
            return info;
        }
		
		/// <summary>
		/// 删除一个值
		/// </summary>
		/// <param name="Id">自增id的值</param>
		/// <returns>删除成功返回ture，否则返回false</returns>
        public static bool FenShengYuanXiaoLuQuDel(int Id, string strDataYear)
		{
			int intReturnValue = 0;
			intReturnValue = SqlDB.ExecuteNonQuery(CommandType.Text, "DELETE [" + DAL.Common.GetYearTableName("FenShengYuanXiaoLuQu", strDataYear ) + "]  WHERE Id =  " + Id);
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
        public static DataTable FenShengYuanXiaoLuQuTopGet(string strWhere, int TopNumber, string strDataYear)
		{
			string strSql;
			if (!string.IsNullOrEmpty(strWhere.Trim()))
				strSql = "SELECT TOP " + TopNumber.ToString() + " * FROM [" + DAL.Common.GetYearTableName("FenShengYuanXiaoLuQu", strDataYear ) + "] WHERE "+ strWhere +";";
			else
				strSql = "SELECT TOP " + TopNumber.ToString() + " * FROM [" + DAL.Common.GetYearTableName("FenShengYuanXiaoLuQu", strDataYear ) + "] ;";
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
        public static DataTable FenShengYuanXiaoLuQuPageList(string strWhere, int PageSize, int PageIndex, string strDataYear)
		{
			StringBuilder sbSql = new StringBuilder();
            sbSql.Append("SELECT * FROM [" + DAL.Common.GetYearTableName("FenShengYuanXiaoLuQu", strDataYear) + "]");
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
        public static int FenShengYuanXiaoLuQuCount(string strWhere, string strDataYear)
		{
			string strSql;
			if (!string.IsNullOrEmpty(strWhere.Trim()))
				strSql = "SELECT COUNT(*) FROM [" + DAL.Common.GetYearTableName("FenShengYuanXiaoLuQu", strDataYear ) + "] WHERE "+ strWhere +";";
			else
				strSql = "SELECT COUNT(*)  FROM [" + DAL.Common.GetYearTableName("FenShengYuanXiaoLuQu", strDataYear ) + "] ;";
			return Basic.Utils.StrToInt(SqlDB.ExecuteScalar(CommandType.Text, strSql).ToString(), 0);
		}
	#endregion
		
	}
}

