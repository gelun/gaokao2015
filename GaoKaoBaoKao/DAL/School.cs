using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;

using Basic;
using Entity;

namespace DAL
{
    public class School
    {
        #region  School
        /// <summary>
        /// 调用存储过程增加一个
        /// </summary>
        /// <param name="info">实体对象</param>
        /// <returns>正常返回大于 0 的自增id, 0代表重复，否则返回-1</returns>
        public static int SchoolAdd(Entity.School info)
        {
            SqlParameter[] prams = {
				SqlDB.MakeInParam("@SchoolName", SqlDbType.NVarChar, 100, info.SchoolName),
				SqlDB.MakeInParam("@SchoolEnName", SqlDbType.NVarChar, 200, info.SchoolEnName),
				SqlDB.MakeInParam("@Logo", SqlDbType.NVarChar, 100, info.Logo),
				SqlDB.MakeInParam("@CengYongMing", SqlDbType.NVarChar, 500, info.CengYongMing),
				SqlDB.MakeInParam("@SchoolWebSite", SqlDbType.NVarChar, 200, info.SchoolWebSite),
				SqlDB.MakeInParam("@ZhaoShengWebSite", SqlDbType.NVarChar, 200, info.ZhaoShengWebSite),
				SqlDB.MakeInParam("@ZhaoShengTel", SqlDbType.NVarChar, 200, info.ZhaoShengTel),
				SqlDB.MakeInParam("@ProvinceId", SqlDbType.Int, 4, info.ProvinceId),
				SqlDB.MakeInParam("@ProvinceName", SqlDbType.NVarChar, 100, info.ProvinceName),
				SqlDB.MakeInParam("@CityName", SqlDbType.NVarChar, 100, info.CityName),
				SqlDB.MakeInParam("@Address", SqlDbType.NVarChar, 400, info.Address),
				SqlDB.MakeInParam("@FoundingTime", SqlDbType.NVarChar, 50, info.FoundingTime),
				SqlDB.MakeInParam("@YuanShi", SqlDbType.NVarChar, 50, info.YuanShi),
				SqlDB.MakeInParam("@ZhongDianXueKe", SqlDbType.NVarChar, 50, info.ZhongDianXueKe),
				SqlDB.MakeInParam("@BoShiDian", SqlDbType.NVarChar, 50, info.BoShiDian),
				SqlDB.MakeInParam("@ShuoShiDian", SqlDbType.NVarChar, 50, info.ShuoShiDian),
				SqlDB.MakeInParam("@SchoolIntro", SqlDbType.NText, 0, info.SchoolIntro),
				SqlDB.MakeInParam("@SchoolCengCi", SqlDbType.Int, 4, info.SchoolCengCi),
				SqlDB.MakeInParam("@SchoolNature", SqlDbType.Int, 4, info.SchoolNature),
				SqlDB.MakeInParam("@YuanXiaoLeiXingId", SqlDbType.Int, 4, info.YuanXiaoLeiXingId),
				SqlDB.MakeInParam("@YuanXiaoLeiXing", SqlDbType.NVarChar, 40, info.YuanXiaoLeiXing),
				SqlDB.MakeInParam("@Belong", SqlDbType.Int, 4, info.Belong),
				SqlDB.MakeInParam("@BeLongName", SqlDbType.NVarChar, 100, info.BeLongName),
				SqlDB.MakeInParam("@Is211", SqlDbType.Int, 4, info.Is211),
				SqlDB.MakeInParam("@Is985", SqlDbType.Int, 4, info.Is985),
				SqlDB.MakeInParam("@IsGraduateSchool", SqlDbType.Int, 4, info.IsGraduateSchool),
				SqlDB.MakeInParam("@IsIndependentRecruitment", SqlDbType.Int, 4, info.IsIndependentRecruitment),
				SqlDB.MakeInParam("@IsNationalDefense", SqlDbType.Int, 4, info.IsNationalDefense),
				SqlDB.MakeInParam("@IsExcellent", SqlDbType.Int, 4, info.IsExcellent),
				SqlDB.MakeInParam("@IsMiNi211", SqlDbType.Int, 4, info.IsMiNi211),
				SqlDB.MakeInParam("@IsRuralSpecial", SqlDbType.Int, 4, info.IsRuralSpecial),
				SqlDB.MakeInParam("@IsArtSpecialty", SqlDbType.Int, 4, info.IsArtSpecialty),
				SqlDB.MakeInParam("@IsHighLevelAthletes", SqlDbType.Int, 4, info.IsHighLevelAthletes),
				SqlDB.MakeInParam("@IsShiDian", SqlDbType.Int, 4, info.IsShiDian),
				SqlDB.MakeInParam("@WuShuLianRanking", SqlDbType.Int, 4, info.WuShuLianRanking),
				SqlDB.MakeInParam("@XiaoYouHuiRanking", SqlDbType.Int, 4, info.XiaoYouHuiRanking),
				SqlDB.MakeInParam("@MinBanRanking", SqlDbType.Int, 4, info.MinBanRanking),
				SqlDB.MakeInParam("@DuLiXueYuanRanking", SqlDbType.Int, 4, info.DuLiXueYuanRanking),
				SqlDB.MakeInParam("@ClickNum", SqlDbType.Int, 4, info.ClickNum),
				SqlDB.MakeInParam("@IsPause", SqlDbType.Int, 4, info.IsPause),
				SqlDB.MakeInParam("@BanXueLeiXing", SqlDbType.Int, 4, info.BanXueLeiXing),
				SqlDB.MakeInParam("@Email", SqlDbType.NVarChar, 50, info.Email),
				SqlDB.MakeInParam("@ZipCode", SqlDbType.NVarChar, 20, info.ZipCode),
				SqlDB.MakeInParam("@CollectionBooks", SqlDbType.NVarChar, 200, info.CollectionBooks),
				SqlDB.MakeInParam("@Pic", SqlDbType.NVarChar, 100, info.Pic),
				SqlDB.MakeInParam("@StudentCount", SqlDbType.NVarChar, 100, info.StudentCount),
			};
            return Basic.Utils.StrToInt(SqlDB.ExecuteScalar(CommandType.StoredProcedure, "SchoolAdd", prams).ToString(), -1);
        }

        /// <summary>
        /// 调用存储过程修改一个
        /// </summary>
        /// <param name="info">实体对象</param>
        /// <returns>更新成功返回ture，否则返回false</returns>
        public static bool SchoolEdit(Entity.School info)
        {
            SqlParameter[] prams = {
				SqlDB.MakeInParam("@Id", SqlDbType.Int, 4, info.Id),
				SqlDB.MakeInParam("@SchoolName", SqlDbType.NVarChar, 100, info.SchoolName),
				SqlDB.MakeInParam("@SchoolEnName", SqlDbType.NVarChar, 200, info.SchoolEnName),
				SqlDB.MakeInParam("@Logo", SqlDbType.NVarChar, 100, info.Logo),
				SqlDB.MakeInParam("@CengYongMing", SqlDbType.NVarChar, 500, info.CengYongMing),
				SqlDB.MakeInParam("@SchoolWebSite", SqlDbType.NVarChar, 200, info.SchoolWebSite),
				SqlDB.MakeInParam("@ZhaoShengWebSite", SqlDbType.NVarChar, 200, info.ZhaoShengWebSite),
				SqlDB.MakeInParam("@ZhaoShengTel", SqlDbType.NVarChar, 200, info.ZhaoShengTel),
				SqlDB.MakeInParam("@ProvinceId", SqlDbType.Int, 4, info.ProvinceId),
				SqlDB.MakeInParam("@ProvinceName", SqlDbType.NVarChar, 100, info.ProvinceName),
				SqlDB.MakeInParam("@CityName", SqlDbType.NVarChar, 100, info.CityName),
				SqlDB.MakeInParam("@Address", SqlDbType.NVarChar, 400, info.Address),
				SqlDB.MakeInParam("@FoundingTime", SqlDbType.NVarChar, 50, info.FoundingTime),
				SqlDB.MakeInParam("@YuanShi", SqlDbType.NVarChar, 50, info.YuanShi),
				SqlDB.MakeInParam("@ZhongDianXueKe", SqlDbType.NVarChar, 50, info.ZhongDianXueKe),
				SqlDB.MakeInParam("@BoShiDian", SqlDbType.NVarChar, 50, info.BoShiDian),
				SqlDB.MakeInParam("@ShuoShiDian", SqlDbType.NVarChar, 50, info.ShuoShiDian),
				SqlDB.MakeInParam("@SchoolIntro", SqlDbType.NText, 0, info.SchoolIntro),
				SqlDB.MakeInParam("@SchoolCengCi", SqlDbType.Int, 4, info.SchoolCengCi),
				SqlDB.MakeInParam("@SchoolNature", SqlDbType.Int, 4, info.SchoolNature),
				SqlDB.MakeInParam("@YuanXiaoLeiXingId", SqlDbType.Int, 4, info.YuanXiaoLeiXingId),
				SqlDB.MakeInParam("@YuanXiaoLeiXing", SqlDbType.NVarChar, 40, info.YuanXiaoLeiXing),
				SqlDB.MakeInParam("@Belong", SqlDbType.Int, 4, info.Belong),
				SqlDB.MakeInParam("@BeLongName", SqlDbType.NVarChar, 100, info.BeLongName),
				SqlDB.MakeInParam("@Is211", SqlDbType.Int, 4, info.Is211),
				SqlDB.MakeInParam("@Is985", SqlDbType.Int, 4, info.Is985),
				SqlDB.MakeInParam("@IsGraduateSchool", SqlDbType.Int, 4, info.IsGraduateSchool),
				SqlDB.MakeInParam("@IsIndependentRecruitment", SqlDbType.Int, 4, info.IsIndependentRecruitment),
				SqlDB.MakeInParam("@IsNationalDefense", SqlDbType.Int, 4, info.IsNationalDefense),
				SqlDB.MakeInParam("@IsExcellent", SqlDbType.Int, 4, info.IsExcellent),
				SqlDB.MakeInParam("@IsMiNi211", SqlDbType.Int, 4, info.IsMiNi211),
				SqlDB.MakeInParam("@IsRuralSpecial", SqlDbType.Int, 4, info.IsRuralSpecial),
				SqlDB.MakeInParam("@IsArtSpecialty", SqlDbType.Int, 4, info.IsArtSpecialty),
				SqlDB.MakeInParam("@IsHighLevelAthletes", SqlDbType.Int, 4, info.IsHighLevelAthletes),
				SqlDB.MakeInParam("@IsShiDian", SqlDbType.Int, 4, info.IsShiDian),
				SqlDB.MakeInParam("@WuShuLianRanking", SqlDbType.Int, 4, info.WuShuLianRanking),
				SqlDB.MakeInParam("@XiaoYouHuiRanking", SqlDbType.Int, 4, info.XiaoYouHuiRanking),
				SqlDB.MakeInParam("@MinBanRanking", SqlDbType.Int, 4, info.MinBanRanking),
				SqlDB.MakeInParam("@DuLiXueYuanRanking", SqlDbType.Int, 4, info.DuLiXueYuanRanking),
				SqlDB.MakeInParam("@ClickNum", SqlDbType.Int, 4, info.ClickNum),
				SqlDB.MakeInParam("@IsPause", SqlDbType.Int, 4, info.IsPause),
				SqlDB.MakeInParam("@BanXueLeiXing", SqlDbType.Int, 4, info.BanXueLeiXing),
				SqlDB.MakeInParam("@Email", SqlDbType.NVarChar, 50, info.Email),
				SqlDB.MakeInParam("@ZipCode", SqlDbType.NVarChar, 20, info.ZipCode),
				SqlDB.MakeInParam("@CollectionBooks", SqlDbType.NVarChar, 200, info.CollectionBooks),
				SqlDB.MakeInParam("@Pic", SqlDbType.NVarChar, 100, info.Pic),
				SqlDB.MakeInParam("@StudentCount", SqlDbType.NVarChar, 100, info.StudentCount),
				};
            int intReturnValue = 0;
            intReturnValue = SqlDB.ExecuteNonQuery(CommandType.StoredProcedure, "SchoolEdit", prams);
            if (intReturnValue == 1)
                return true;
            return false;
        }

        /// <summary>
        /// 暂停该值
        /// </summary>
        /// <param name="Id">自增id的值</param>
        /// <returns>暂停成功返回ture，否则返回false</returns>
        public static bool SchoolPause(Entity.School info)
        {
            int intReturnValue = 0;
            intReturnValue = SqlDB.ExecuteNonQuery(CommandType.Text, "UPDATE [School] SET IsPause = " + info.IsPause + "  WHERE Id =  " + info.Id);
            if (intReturnValue == 1)
                return true;
            return false;
        }

        /// <summary>
        /// 获取所有的的值
        /// </summary>
        /// <param name="strWhere">条件，可以为空</param>
        /// <returns>返回DataTable</returns>
        public static DataTable SchoolList(string strWhere)
        {
            string strSql;
            if (!string.IsNullOrEmpty(strWhere.Trim()))
                strSql = "SELECT * FROM [School] WHERE " + strWhere + ";";
            else
                strSql = "SELECT * FROM [School] ;";
            return SqlDB.ExecuteDataset(CommandType.Text, strSql).Tables[0];
        }


        /// <summary>
        /// 获取某一个DataTable
        /// </summary>
        /// <param name="Id">标识</param>
        /// <returns>返回DataTable</returns>
        public static DataTable SchoolGet(int Id)
        {
            return SqlDB.ExecuteDataset(CommandType.Text, "SELECT * FROM [School] WHERE Id = " + Id + ";").Tables[0];
        }

        /// <summary>
        /// 获取某一个实体
        /// </summary>
        /// <param name="Id">标识</param>
        /// <returns>返回Entity</returns>
        public static Entity.School SchoolEntityGet(int Id)
        {
            Entity.School info = new Entity.School();
            DataTable dt = SqlDB.ExecuteDataset(CommandType.Text, "SELECT * FROM [School] WHERE Id = " + Id + ";").Tables[0];
            if (dt.Rows.Count > 0)
            {
                info.Id = Basic.Utils.StrToInt(dt.Rows[0]["Id"].ToString(), 0);
                info.SchoolName = dt.Rows[0]["SchoolName"].ToString();
                info.SchoolEnName = dt.Rows[0]["SchoolEnName"].ToString();
                info.Logo = dt.Rows[0]["Logo"].ToString();
                info.CengYongMing = dt.Rows[0]["CengYongMing"].ToString();
                info.SchoolWebSite = dt.Rows[0]["SchoolWebSite"].ToString();
                info.ZhaoShengWebSite = dt.Rows[0]["ZhaoShengWebSite"].ToString();
                info.ZhaoShengTel = dt.Rows[0]["ZhaoShengTel"].ToString();
                info.ProvinceId = Basic.Utils.StrToInt(dt.Rows[0]["ProvinceId"].ToString(), 0);
                info.ProvinceName = dt.Rows[0]["ProvinceName"].ToString();
                info.CityName = dt.Rows[0]["CityName"].ToString();
                info.Address = dt.Rows[0]["Address"].ToString();
                info.FoundingTime = dt.Rows[0]["FoundingTime"].ToString();
                info.YuanShi = dt.Rows[0]["YuanShi"].ToString();
                info.ZhongDianXueKe = dt.Rows[0]["ZhongDianXueKe"].ToString();
                info.BoShiDian = dt.Rows[0]["BoShiDian"].ToString();
                info.ShuoShiDian = dt.Rows[0]["ShuoShiDian"].ToString();
                info.SchoolIntro = dt.Rows[0]["SchoolIntro"].ToString();
                info.SchoolCengCi = Basic.Utils.StrToInt(dt.Rows[0]["SchoolCengCi"].ToString(), 0);
                info.SchoolNature = Basic.Utils.StrToInt(dt.Rows[0]["SchoolNature"].ToString(), 0);
                info.YuanXiaoLeiXingId = Basic.Utils.StrToInt(dt.Rows[0]["YuanXiaoLeiXingId"].ToString(), 0);
                info.YuanXiaoLeiXing = dt.Rows[0]["YuanXiaoLeiXing"].ToString();
                info.Belong = Basic.Utils.StrToInt(dt.Rows[0]["Belong"].ToString(), 0);
                info.BeLongName = dt.Rows[0]["BeLongName"].ToString();
                info.Is211 = Basic.Utils.StrToInt(dt.Rows[0]["Is211"].ToString(), 0);
                info.Is985 = Basic.Utils.StrToInt(dt.Rows[0]["Is985"].ToString(), 0);
                info.IsGraduateSchool = Basic.Utils.StrToInt(dt.Rows[0]["IsGraduateSchool"].ToString(), 0);
                info.IsIndependentRecruitment = Basic.Utils.StrToInt(dt.Rows[0]["IsIndependentRecruitment"].ToString(), 0);
                info.IsNationalDefense = Basic.Utils.StrToInt(dt.Rows[0]["IsNationalDefense"].ToString(), 0);
                info.IsExcellent = Basic.Utils.StrToInt(dt.Rows[0]["IsExcellent"].ToString(), 0);
                info.IsMiNi211 = Basic.Utils.StrToInt(dt.Rows[0]["IsMiNi211"].ToString(), 0);
                info.IsRuralSpecial = Basic.Utils.StrToInt(dt.Rows[0]["IsRuralSpecial"].ToString(), 0);
                info.IsArtSpecialty = Basic.Utils.StrToInt(dt.Rows[0]["IsArtSpecialty"].ToString(), 0);
                info.IsHighLevelAthletes = Basic.Utils.StrToInt(dt.Rows[0]["IsHighLevelAthletes"].ToString(), 0);
                info.IsShiDian = Basic.Utils.StrToInt(dt.Rows[0]["IsShiDian"].ToString(), 0);
                info.WuShuLianRanking = Basic.Utils.StrToInt(dt.Rows[0]["WuShuLianRanking"].ToString(), 0);
                info.XiaoYouHuiRanking = Basic.Utils.StrToInt(dt.Rows[0]["XiaoYouHuiRanking"].ToString(), 0);
                info.MinBanRanking = Basic.Utils.StrToInt(dt.Rows[0]["MinBanRanking"].ToString(), 0);
                info.DuLiXueYuanRanking = Basic.Utils.StrToInt(dt.Rows[0]["DuLiXueYuanRanking"].ToString(), 0);
                info.ClickNum = Basic.Utils.StrToInt(dt.Rows[0]["ClickNum"].ToString(), 0);
                info.IsPause = Basic.Utils.StrToInt(dt.Rows[0]["IsPause"].ToString(), 0);
                info.BanXueLeiXing = Basic.Utils.StrToInt(dt.Rows[0]["BanXueLeiXing"].ToString(), 0);
                info.Email = dt.Rows[0]["Email"].ToString();
                info.ZipCode = dt.Rows[0]["ZipCode"].ToString();
                info.CollectionBooks = dt.Rows[0]["CollectionBooks"].ToString();
                info.Pic = dt.Rows[0]["Pic"].ToString();
                info.StudentCount = dt.Rows[0]["StudentCount"].ToString();

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
        public static bool SchoolDel(int Id)
        {
            int intReturnValue = 0;
            intReturnValue = SqlDB.ExecuteNonQuery(CommandType.Text, "DELETE [School]  WHERE Id =  " + Id);
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
        public static DataTable SchoolTopGet(string strWhere, int TopNumber)
        {
            string strSql;
            if (!string.IsNullOrEmpty(strWhere.Trim()))
                strSql = "SELECT TOP " + TopNumber.ToString() + " * FROM [School] WHERE " + strWhere + ";";
            else
                strSql = "SELECT TOP " + TopNumber.ToString() + " * FROM [School] ;";
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
        public static DataTable SchoolPageList(string strWhere, int PageSize, int PageIndex)
        {
            StringBuilder sbSql = new StringBuilder();
            sbSql.Append("SELECT * FROM School");
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
        public static int SchoolCount(string strWhere)
        {
            string strSql;
            if (!string.IsNullOrEmpty(strWhere.Trim()))
                strSql = "SELECT COUNT(*) FROM [School] WHERE " + strWhere + ";";
            else
                strSql = "SELECT COUNT(*)  FROM [School] ;";
            return Basic.Utils.StrToInt(SqlDB.ExecuteScalar(CommandType.Text, strSql).ToString(), 0);
        }
        #endregion

    }
}

