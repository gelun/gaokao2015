using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Basic;
using System.Data.SqlClient;

namespace DAL.TengXB
{
   public class School
    {



        #region 2014 - 08 - 14 17:20:00


        public static DataTable GetSchoolList(string strWhere, int intTop)
        {
            string strSql = "SELECT " + (intTop > 0 ? "TOP " + intTop : "") + " Id,SchoolName,Logo,ClickNum FROM [School] ";
            if (!string.IsNullOrEmpty(strWhere.Trim()))
                strSql += " WHERE " + strWhere + ";";

            return SqlDB.ExecuteDataset(CommandType.Text, strSql).Tables[0];
        }


        #endregion


        #region 2014 - 08 - 15 11:11:00

        public static DataTable YxkSchoolList(string strWhere)
        {
            string strSql = "SELECT Id , SchoolName, ProvinceName,CityName,YuanXiaoLeiXing,BeLongName,Is211,Is985,IsGraduateSchool,IsIndependentRecruitment,IsNationalDefense,IsExcellent,IsMiNi211,IsRuralSpecial,IsArtSpecialty,IsHighLevelAthletes ";
            strSql += " FROM School ";
            if (!string.IsNullOrEmpty(strWhere.Trim()))
                strSql += " WHERE " + strWhere;
            return SqlDB.ExecuteDataset(CommandType.Text, strSql).Tables[0];
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="intPageSize">每页显示的条数，比如10条</param>
        /// <param name="intDataCount">截止到当前页面 已展示的所有的数据的数量，比如第十一页，那么在它及它之前，已经展示过 11*10=110 条数据了</param>
        /// <param name="strWhere">拼接好的筛选条件</param>
        /// <returns>返回两张表：第一张表，只有总数量 一个字段；第二张表，返回的是数据列表</returns>
        public static DataTable YxkSchoolDt(int intPageSize, int intDataCount, string strWhere)
        {
            SqlParameter[] prams = {
				SqlDB.MakeInParam("@PageSize", SqlDbType.Int, 4, intPageSize),
				SqlDB.MakeInParam("@CountAgo", SqlDbType.Int, 4, intDataCount),
				SqlDB.MakeInParam("@Condition", SqlDbType.NVarChar, 2700, strWhere),
			};

            return SqlDB.ExecuteDataset(CommandType.StoredProcedure, "YxkSchoolList", prams).Tables[0];
        }
        #endregion


        public static bool SchoolClickNum(Entity.School info)
        {
            int intReturnValue = 0;
            intReturnValue = SqlDB.ExecuteNonQuery(CommandType.Text, "UPDATE [School] SET ClickNum = " + info.ClickNum + "  WHERE Id =  " + info.Id);
            if (intReturnValue == 1)
                return true;
            return false;
        }


        public static DataTable SchoolZhuanYeTopGet(string strWhere, int TopNumber)
        {
            string strSql = "select TOP " + TopNumber.ToString() + " sp.Id,sd.SchoolId,sp.ProfessionalId,sp.ProfessionalName,sp.ClickNum,p.IsBen from SchoolProfessional as sp,Professional as p,SchoolDisciplines as sd where sp.ProfessionalId = p.Id and sp.SchoolDisciplinesId = sd.Id ";
            if (!string.IsNullOrEmpty(strWhere.Trim()))
                strSql += " AND " + strWhere + ";";
            return SqlDB.ExecuteDataset(CommandType.Text, strSql).Tables[0];
        }
    }
}
