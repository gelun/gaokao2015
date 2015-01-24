using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;

using Basic;
using Entity;

namespace DAL
{
    public class FenShengZhuanYeLuQu
    {
        #region  FenShengZhuanYeLuQu
        /// <summary>
        /// 调用存储过程增加一个
        /// </summary>
        /// <param name="info">实体对象</param>
        /// <returns>正常返回大于 0 的自增id, 0代表重复，否则返回-1</returns>
        public static int FenShengZhuanYeLuQuAdd(Entity.FenShengZhuanYeLuQu info)
        {
            SqlParameter[] prams = {
				SqlDB.MakeInParam("@DataYear", SqlDbType.Int, 4, info.DataYear),
				SqlDB.MakeInParam("@ProvinceId", SqlDbType.Int, 4, info.ProvinceId),
				SqlDB.MakeInParam("@ShengShi", SqlDbType.NVarChar, 15, info.ShengShi),
				SqlDB.MakeInParam("@CengCi", SqlDbType.Int, 4, info.CengCi),
				SqlDB.MakeInParam("@PiCi", SqlDbType.Int, 4, info.PiCi),
				SqlDB.MakeInParam("@PcLeiBie", SqlDbType.Int, 4, info.PcLeiBie),
				SqlDB.MakeInParam("@KeLei", SqlDbType.Int, 4, info.KeLei),
				SqlDB.MakeInParam("@KeLeiDaiMa", SqlDbType.Char, 1, info.KeLeiDaiMa),
				SqlDB.MakeInParam("@KeLeiMingCheng", SqlDbType.NVarChar, 50, info.KeLeiMingCheng),
				SqlDB.MakeInParam("@SchoolId", SqlDbType.Int, 4, info.SchoolId),
				SqlDB.MakeInParam("@SchoolProvinceId", SqlDbType.Int, 4, info.SchoolProvinceId),
				SqlDB.MakeInParam("@YuanXiaoDaiMa", SqlDbType.Char, 5, info.YuanXiaoDaiMa),
				SqlDB.MakeInParam("@YuanXiaoMingCheng", SqlDbType.NVarChar, 64, info.YuanXiaoMingCheng),
				SqlDB.MakeInParam("@ZyId", SqlDbType.Int, 4, info.ZyId),
				SqlDB.MakeInParam("@ZhuanYeDaiMa", SqlDbType.Char, 50, info.ZhuanYeDaiMa),
				SqlDB.MakeInParam("@ZhuanYeMingCheng", SqlDbType.NVarChar, 50, info.ZhuanYeMingCheng),
				SqlDB.MakeInParam("@ZyZuiGaoFen", SqlDbType.Int, 4, info.ZyZuiGaoFen),
				SqlDB.MakeInParam("@ZyPingJunFen", SqlDbType.Int, 4, info.ZyPingJunFen),
				SqlDB.MakeInParam("@ZyPiCiXian", SqlDbType.Int, 4, info.ZyPiCiXian),
				SqlDB.MakeInParam("@ZyPingJunXianCha", SqlDbType.Int, 4, info.ZyPingJunXianCha),
				SqlDB.MakeInParam("@ZyZuiDiFen", SqlDbType.Int, 4, info.ZyZuiDiFen),
				SqlDB.MakeInParam("@ZyZuiDaWeiCi", SqlDbType.Int, 4, info.ZyZuiDaWeiCi),
				SqlDB.MakeInParam("@ZyPingJunWeiCi", SqlDbType.Int, 4, info.ZyPingJunWeiCi),
				SqlDB.MakeInParam("@ZyZuiXiaoWeiCi", SqlDbType.Int, 4, info.ZyZuiXiaoWeiCi),
				SqlDB.MakeInParam("@ZYLuQuShu", SqlDbType.Int, 4, info.ZYLuQuShu),
				SqlDB.MakeInParam("@ZyProvinceCount", SqlDbType.Int, 4, info.ZyProvinceCount),
				SqlDB.MakeInParam("@ZyCountryCount", SqlDbType.Int, 4, info.ZyCountryCount),
			};
            return Basic.Utils.StrToInt(SqlDB.ExecuteScalar(CommandType.StoredProcedure, "FenShengZhuanYeLuQuAdd", prams).ToString(), -1);
        }

        /// <summary>
        /// 调用存储过程修改一个
        /// </summary>
        /// <param name="info">实体对象</param>
        /// <returns>更新成功返回ture，否则返回false</returns>
        public static bool FenShengZhuanYeLuQuEdit(Entity.FenShengZhuanYeLuQu info)
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
				SqlDB.MakeInParam("@KeLeiDaiMa", SqlDbType.Char, 1, info.KeLeiDaiMa),
				SqlDB.MakeInParam("@KeLeiMingCheng", SqlDbType.NVarChar, 50, info.KeLeiMingCheng),
				SqlDB.MakeInParam("@SchoolId", SqlDbType.Int, 4, info.SchoolId),
				SqlDB.MakeInParam("@SchoolProvinceId", SqlDbType.Int, 4, info.SchoolProvinceId),
				SqlDB.MakeInParam("@YuanXiaoDaiMa", SqlDbType.Char, 5, info.YuanXiaoDaiMa),
				SqlDB.MakeInParam("@YuanXiaoMingCheng", SqlDbType.NVarChar, 64, info.YuanXiaoMingCheng),
				SqlDB.MakeInParam("@ZyId", SqlDbType.Int, 4, info.ZyId),
				SqlDB.MakeInParam("@ZhuanYeDaiMa", SqlDbType.Char, 50, info.ZhuanYeDaiMa),
				SqlDB.MakeInParam("@ZhuanYeMingCheng", SqlDbType.NVarChar, 50, info.ZhuanYeMingCheng),
				SqlDB.MakeInParam("@ZyZuiGaoFen", SqlDbType.Int, 4, info.ZyZuiGaoFen),
				SqlDB.MakeInParam("@ZyPingJunFen", SqlDbType.Int, 4, info.ZyPingJunFen),
				SqlDB.MakeInParam("@ZyPiCiXian", SqlDbType.Int, 4, info.ZyPiCiXian),
				SqlDB.MakeInParam("@ZyPingJunXianCha", SqlDbType.Int, 4, info.ZyPingJunXianCha),
				SqlDB.MakeInParam("@ZyZuiDiFen", SqlDbType.Int, 4, info.ZyZuiDiFen),
				SqlDB.MakeInParam("@ZyZuiDaWeiCi", SqlDbType.Int, 4, info.ZyZuiDaWeiCi),
				SqlDB.MakeInParam("@ZyPingJunWeiCi", SqlDbType.Int, 4, info.ZyPingJunWeiCi),
				SqlDB.MakeInParam("@ZyZuiXiaoWeiCi", SqlDbType.Int, 4, info.ZyZuiXiaoWeiCi),
				SqlDB.MakeInParam("@ZYLuQuShu", SqlDbType.Int, 4, info.ZYLuQuShu),
				SqlDB.MakeInParam("@ZyProvinceCount", SqlDbType.Int, 4, info.ZyProvinceCount),
				SqlDB.MakeInParam("@ZyCountryCount", SqlDbType.Int, 4, info.ZyCountryCount),
				};
            int intReturnValue = 0;
            intReturnValue = SqlDB.ExecuteNonQuery(CommandType.StoredProcedure, "FenShengZhuanYeLuQuEdit", prams);
            if (intReturnValue == 1)
                return true;
            return false;
        }

        /// <summary>
        /// 暂停该值
        /// </summary>
        /// <param name="Id">自增id的值</param>
        /// <returns>暂停成功返回ture，否则返回false</returns>
        //public static bool FenShengZhuanYeLuQuPause(Entity.FenShengZhuanYeLuQu info)
        //{
        //    int intReturnValue = 0;
        //    intReturnValue = SqlDB.ExecuteNonQuery(CommandType.Text, "UPDATE [" + DAL.Common.GetYearTableName("FenShengZhuanYeLuQu", strDataYear ) + "] SET IsPause = "+  info.IsPause +"  WHERE Id =  " +  info.Id);
        //    if(intReturnValue == 1)
        //        return true;
        //    return false;
        //}



        /// <summary>
        /// 获取某一个DataTable
        /// </summary>
        /// <param name="Id">标识</param>
        /// <returns>返回DataTable</returns>
        public static DataTable FenShengZhuanYeLuQuGet(int Id, string strDataYear)
        {
            return SqlDB.ExecuteDataset(CommandType.Text, "SELECT * FROM [" + DAL.Common.GetYearTableName("FenShengZhuanYeLuQu", strDataYear) + "] WHERE Id = " + Id + ";").Tables[0];
        }

        /// <summary>
        /// 获取某一个实体
        /// </summary>
        /// <param name="Id">标识</param>
        /// <returns>返回Entity</returns>
        public static Entity.FenShengZhuanYeLuQu FenShengZhuanYeLuQuEntityGet(int Id, string strDataYear)
        {
            Entity.FenShengZhuanYeLuQu info = new Entity.FenShengZhuanYeLuQu();
            DataTable dt = SqlDB.ExecuteDataset(CommandType.Text, "SELECT * FROM [" + DAL.Common.GetYearTableName("FenShengZhuanYeLuQu", strDataYear) + "] WHERE Id = " + Id + ";").Tables[0];
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
                info.KeLeiDaiMa = dt.Rows[0]["KeLeiDaiMa"].ToString();
                info.KeLeiMingCheng = dt.Rows[0]["KeLeiMingCheng"].ToString();
                info.SchoolId = Basic.Utils.StrToInt(dt.Rows[0]["SchoolId"].ToString(), 0);
                info.SchoolProvinceId = Basic.Utils.StrToInt(dt.Rows[0]["SchoolProvinceId"].ToString(), 0);
                info.YuanXiaoDaiMa = dt.Rows[0]["YuanXiaoDaiMa"].ToString();
                info.YuanXiaoMingCheng = dt.Rows[0]["YuanXiaoMingCheng"].ToString();
                info.ZyId = Basic.Utils.StrToInt(dt.Rows[0]["ZyId"].ToString(), 0);
                info.ZhuanYeDaiMa = dt.Rows[0]["ZhuanYeDaiMa"].ToString();
                info.ZhuanYeMingCheng = dt.Rows[0]["ZhuanYeMingCheng"].ToString();
                info.ZyZuiGaoFen = Basic.Utils.StrToInt(dt.Rows[0]["ZyZuiGaoFen"].ToString(), 0);
                info.ZyPingJunFen = Basic.Utils.StrToInt(dt.Rows[0]["ZyPingJunFen"].ToString(), 0);
                info.ZyPiCiXian = Basic.Utils.StrToInt(dt.Rows[0]["ZyPiCiXian"].ToString(), 0);
                info.ZyPingJunXianCha = Basic.Utils.StrToInt(dt.Rows[0]["ZyPingJunXianCha"].ToString(), 0);
                info.ZyZuiDiFen = Basic.Utils.StrToInt(dt.Rows[0]["ZyZuiDiFen"].ToString(), 0);
                info.ZyZuiDaWeiCi = Basic.Utils.StrToInt(dt.Rows[0]["ZyZuiDaWeiCi"].ToString(), 0);
                info.ZyPingJunWeiCi = Basic.Utils.StrToInt(dt.Rows[0]["ZyPingJunWeiCi"].ToString(), 0);
                info.ZyZuiXiaoWeiCi = Basic.Utils.StrToInt(dt.Rows[0]["ZyZuiXiaoWeiCi"].ToString(), 0);
                info.ZYLuQuShu = Basic.Utils.StrToInt(dt.Rows[0]["ZYLuQuShu"].ToString(), 0);
                info.ZyProvinceCount = Basic.Utils.StrToInt(dt.Rows[0]["ZyProvinceCount"].ToString(), 0);
                info.ZyCountryCount = Basic.Utils.StrToInt(dt.Rows[0]["ZyCountryCount"].ToString(), 0);
            }
            return info;
        }

        /// <summary>
        /// 删除一个值
        /// </summary>
        /// <param name="Id">自增id的值</param>
        /// <returns>删除成功返回ture，否则返回false</returns>
        public static bool FenShengZhuanYeLuQuDel(int Id, string strDataYear)
        {
            int intReturnValue = 0;
            intReturnValue = SqlDB.ExecuteNonQuery(CommandType.Text, "DELETE [" + DAL.Common.GetYearTableName("FenShengZhuanYeLuQu", strDataYear) + "]  WHERE Id =  " + Id);
            if (intReturnValue == 1)
                return true;
            return false;
        }

        /// <summary>
        /// 获取前多少的值
        /// </summary>
        /// <param name="strWhere">条件，可以为空</param>
        /// <param name="TopNumber">数量</param>
        /// <returns>返回DataTable</returns>
        public static DataTable FenShengZhuanYeLuQuTopGet(string strWhere, int TopNumber, string strDataYear)
        {
            string strSql;
            if (!string.IsNullOrEmpty(strWhere.Trim()))
                strSql = "SELECT TOP " + TopNumber.ToString() + " * FROM [" + DAL.Common.GetYearTableName("FenShengZhuanYeLuQu", strDataYear) + "] WHERE " + strWhere + ";";
            else
                strSql = "SELECT TOP " + TopNumber.ToString() + " * FROM [" + DAL.Common.GetYearTableName("FenShengZhuanYeLuQu", strDataYear) + "] ;";
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
        public static DataTable FenShengZhuanYeLuQuPageList(string strWhere, int PageSize, int PageIndex, string strDataYear)
        {
            StringBuilder sbSql = new StringBuilder();
            sbSql.Append("SELECT * FROM [" + DAL.Common.GetYearTableName("FenShengZhuanYeLuQu", strDataYear) + "]");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                sbSql.Append(" WHERE " + strWhere);
            }
            sbSql.Append(" ORDER BY Id DESC");
            DataSet ds = new DataSet();
            ds = SqlDB.ExecuteDataset((PageIndex - 1) * PageSize, PageSize, CommandType.Text, sbSql.ToString());
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
        public static int FenShengZhuanYeLuQuCount(string strWhere, string strDataYear)
        {
            string strSql;
            if (!string.IsNullOrEmpty(strWhere.Trim()))
                strSql = "SELECT COUNT(*) FROM [" + DAL.Common.GetYearTableName("FenShengZhuanYeLuQu", strDataYear) + "] WHERE " + strWhere + ";";
            else
                strSql = "SELECT COUNT(*)  FROM [" + DAL.Common.GetYearTableName("FenShengZhuanYeLuQu", strDataYear) + "] ;";
            return Basic.Utils.StrToInt(SqlDB.ExecuteScalar(CommandType.Text, strSql).ToString(), 0);
        }
        #endregion


        public static DataTable FenShengZhuanYeLuQuList(string strWhere, int StudentProvinceId, string strDataYear)
        {
            string strSql = " SELECT * ";
            strSql += " FROM [" + DAL.Common.GetProvinceTableName("FenShengZhuanYeLuQu", StudentProvinceId, strDataYear) + "] ";

            if (!string.IsNullOrEmpty(strWhere.Trim()))
                strSql += " WHERE " + strWhere;

            return SqlDB.ExecuteDataset(CommandType.Text, strSql).Tables[0];
        }
        public static DataTable FenShengZhuanYeLuQuWithSchoolList(string strWhere, int StudentProvinceId, string strDataYear)
        {
            string strSql = " SELECT A.*,S.ProvinceName as ShengShi,S.SchoolName ";
            strSql += " FROM [" + DAL.Common.GetProvinceTableName("FenShengZhuanYeLuQu", StudentProvinceId, strDataYear) + "] as A,School as S ";
            strSql += " WHERE A.SchoolId = S.Id  ";
            if (!string.IsNullOrEmpty(strWhere.Trim()))
                strSql += " AND " + strWhere;

            return SqlDB.ExecuteDataset(CommandType.Text, strSql).Tables[0];
        }

        public static DataTable ZhuanYeKaiSheYuanXiaoList(string strWhere, string strDataYear)
        {
            string strSql = " SELECT YuanXiaoMingCheng,SchoolId,SchoolProvinceId ";
            strSql += " FROM [" + DAL.Common.GetYearTableName("FenShengZhuanYeLuQu", strDataYear) + "] as A";
            if (!string.IsNullOrEmpty(strWhere.Trim()))
                strSql += " WHERE " + strWhere;
            strSql += " GROUP BY  YuanXiaoMingCheng,SchoolId,SchoolProvinceId";

            return SqlDB.ExecuteDataset(CommandType.Text, strSql).Tables[0];
        }



        public static DataTable FenShengZhuanYeLuQuALLList(string strWhere, string strDataYear)
        {
            string strSql = " SELECT ZYLQ.DataYear,ZYLQ.ZhuanYeMingCheng,ZYLQ.YuanXiaoMingCheng,ZYLQ.PiCi,ZYLQ.ZyZuiGaoFen,ZYLQ.ZyZuiDiFen,ZYLQ.ZyPingJunFen,ZYLQ.zyPingJunXianCha,FSX.PcFirst,FSX.PcSecond,FSX.PcThird,FSX.ZkFirst,FSX.ZkSecond ";
            strSql += " FROM [" + DAL.Common.GetYearTableName("FenShengZhuanYeLuQu", strDataYear) + "] AS ZYLQ,[FenShuXian] AS FSX ";
            strSql += " WHERE ZYLQ.ProvinceId = FSX.ProvinceId AND ZYLQ.KeLei = FSX.KeLei AND ZYLQ.DataYear = FSX.DataYear ";
            if (!string.IsNullOrEmpty(strWhere.Trim()))
                strSql += " AND " + strWhere;

            return SqlDB.ExecuteDataset(CommandType.Text, strSql).Tables[0];
        }


        public static DataTable GetZhuanYeList(string strWhere, int StudentProvinceId, int DataYear)
        {
            string strSql = " select fszylq.SchoolId, fszylq.ZyId as ZhuanYeId ,fszylq.ZhuanYeMingCheng as ZhuanYeName, fszylq.ZyZuiGaoFen as ZuiGaoFen,fszylq.ZyPingJunFen as PingJunFen,fszylq.ZyZuiDiFen as ZuiDiFen,fszylq.ZYLuQuShu as LuQuRenShu,fszylq.* ";
            strSql += " from [" + DAL.Common.GetProvinceTableName("FenShengZhuanYeLuQu", StudentProvinceId, DataYear.ToString()) + "] as fszylq ";
            if (!string.IsNullOrEmpty(strWhere.Trim()))
                strSql += " where " + strWhere;

            return SqlDB.ExecuteDataset(CommandType.Text, strSql).Tables[0];
        }

        public static DataTable FenShengZhuanYeLuQu_AllList()
        {
            string strSql = " select t1.*,p.ProfessionalGrade,p.ParentId from (select SchoolId,ZyId,ZhuanYeMingCheng from FenShengZhuanYeLuQu_All where SchoolId > 0 and ZyId > 0 and datayear = 2013 group by SchoolId,ZyId,ZhuanYeMingCheng) as t1,Professional as p where t1.ZyId = p.Id order by SchoolId asc";

            return SqlDB.ExecuteDataset(CommandType.Text, strSql).Tables[0];
        }

        public static int SchoolZhuanYeCount(int SchoolId, int ProfessionalId)
        {
            string strSql = "select COUNT(1) from SchoolDisciplines sd,SchoolProfessional sp where sd.Id = sp.SchoolDisciplinesId and SchoolId = " + SchoolId + " and ProfessionalId = " + ProfessionalId;

            return Basic.Utils.StrToInt(SqlDB.ExecuteScalar(CommandType.Text, strSql).ToString(), 0);
        }

        public static DataTable FenShengZhuanYeLuQu_ZheJiang_AllList()
        {
            string strSql = " select t1.*,p.ProfessionalGrade,p.ParentId from (select SchoolId,ZyId,ZhuanYeMingCheng from FenShengZhuanYeLuQu_ZheJiang_All where SchoolId > 0 and ZyId > 0 and datayear = 2013 group by SchoolId,ZyId,ZhuanYeMingCheng) as t1,Professional as p where t1.ZyId = p.Id order by SchoolId asc";

            return SqlDB.ExecuteDataset(CommandType.Text, strSql).Tables[0];
        }
    }
}

