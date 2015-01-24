using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Basic;

namespace DAL.TengXB
{
    public class FenShengYuanXiaoLuQu
    {
        public static DataTable FenShengYuanXiaoLuQuList(string strWhere, int StudentProvinceId)
        {
            string strSql = " SELECT YXLQ.DataYear,YXLQ.PiCi,YXLQ.PingJunXianCha,YXLQ.ZuiGaoFen,YXLQ.ZuiDiFen,YXLQ.PingJunFen,FSX.PcFirst,FSX.PcSecond,FSX.PcThird,FSX.ZkFirst,FSX.ZkSecond ";
            strSql += " FROM " + DAL.Common.GetProvinceTableName("FenShengYuanXiaoLuQu", StudentProvinceId, "All") + " as YXLQ,[FenShuXian] AS FSX ";
            strSql += " WHERE YXLQ.ProvinceId = FSX.ProvinceId AND YXLQ.KeLei = FSX.KeLei AND YXLQ.DataYear = FSX.DataYear "; //调取的是2013年的数据
            if (!string.IsNullOrEmpty(strWhere.Trim()))
                strSql += " AND " + strWhere;
            strSql += " ORDER BY YXLQ.DataYear DESC";
            return SqlDB.ExecuteDataset(CommandType.Text, strSql).Tables[0];
        }

        public static DataTable GetFenShengYuanXiaoList(string strWhere, int StudentProvinceId)
        {
            string strSql = "SELECT s.Id,s.SchoolName,s.Logo FROM [" + DAL.Common.GetProvinceTableName("FenShengYuanXiaoLuQu", StudentProvinceId, "") + "] as fsyx,[School] as s WHERE fsyx.SchoolId = s.Id ";
            if (!string.IsNullOrEmpty(strWhere.Trim()))
                strSql += " AND " + strWhere + ";";
            return SqlDB.ExecuteDataset(CommandType.Text, strSql).Tables[0];
        }


        public static DataTable GetFenShengYuanXiaoList(string strWhere, int StudentProvinceId, int DataYear)
        {
            string strSql = "SELECT s.Id,s.SchoolName,s.Logo FROM [" + DAL.Common.GetProvinceTableName("FenShengYuanXiaoLuQu", StudentProvinceId, DataYear.ToString()) + "] as fsyx,[School] as s WHERE fsyx.SchoolId = s.Id ";
            if (!string.IsNullOrEmpty(strWhere.Trim()))
                strSql += " AND " + strWhere + ";";
            return SqlDB.ExecuteDataset(CommandType.Text, strSql).Tables[0];
        }

        public static DataTable ChaFenShuXianPageList(string strWhere, int SchoolProvinceId, int WenLi, int StudentProvinceId, int Year, int PageSize, int PageIndex)
        {
            string strSql;
            string strSqlTable = " WHERE FSYXLQ.SchoolId = S.Id ";
            if (SchoolProvinceId > 0)
            {
                strSqlTable += " and S.ProvinceId = " + SchoolProvinceId;
            }
            if (WenLi > 0)
            {
                strSqlTable += " and FSYXLQ.KeLei = " + WenLi;
            }
            if (StudentProvinceId > 0)
            {
                strSqlTable += " and FSYXLQ.ProvinceId = " + StudentProvinceId;
            }
            if (Year > 0)
            {
                strSqlTable += " and FSYXLQ.DataYear = " + Year;
            }

            if (!string.IsNullOrEmpty(strWhere.Trim()))
                strSql = "SELECT FSYXLQ.*,S.Id as SchoolId,S.SchoolName,S.ProvinceId as SProvinceId,S.ProvinceName as SProvinceName,FSYXLQ.YuanXiaoDaiMa as SchoolCode FROM [" + DAL.Common.GetProvinceTableName(StudentProvinceId, "FenShengYuanXiaoLuQu", (Year > 0 ? Year.ToString() : "All")) + "] AS FSYXLQ,[School] AS S " + strSqlTable + " AND " + strWhere;
            else
                strSql = "SELECT FSYXLQ.*,S.Id as SchoolId,S.SchoolName,S.ProvinceId as SProvinceId,S.ProvinceName as SProvinceName,FSYXLQ.YuanXiaoDaiMa as SchoolCode FROM [" + DAL.Common.GetProvinceTableName(StudentProvinceId, "FenShengYuanXiaoLuQu", (Year > 0 ? Year.ToString() : "All")) + "] AS FSYXLQ,[School] AS S " + strSqlTable;

            strSql = strSql + " order by S.Id asc";


            DataSet ds = new DataSet();
            ds = SqlDB.ExecuteDataset((PageIndex - 1) * PageSize, PageSize, CommandType.Text, strSql);
            if (ds.Tables.Count > 0)
            {
                return ds.Tables[0];
            }
            return new DataTable();
        }

        public static int ChaFenShuXianCount(string strWhere, int SchoolProvinceId, int WenLi, int StudentProvinceId, int Year)
        {
            string strSql;
            string strSqlTable = " WHERE FSYXLQ.SchoolId = S.Id ";
            if (SchoolProvinceId > 0)
            {
                strSqlTable += " and S.ProvinceId = " + SchoolProvinceId;
            }
            if (WenLi > 0)
            {
                strSqlTable += " and FSYXLQ.KeLei = " + WenLi;
            }
            if (StudentProvinceId > 0)
            {
                strSqlTable += " and FSYXLQ.ProvinceId = " + StudentProvinceId;
            }
            if (Year > 0)
            {
                strSqlTable += " and FSYXLQ.DataYear = " + Year;
            }

            if (!string.IsNullOrEmpty(strWhere.Trim()))
                strSql = "SELECT COUNT(1) FROM [" + DAL.Common.GetProvinceTableName(StudentProvinceId, "FenShengYuanXiaoLuQu", (Year > 0 ? Year.ToString() : "All")) + "] AS FSYXLQ,[School] AS S " + strSqlTable + " AND " + strWhere;
            else
                strSql = "SELECT COUNT(1) FROM [" + DAL.Common.GetProvinceTableName(StudentProvinceId, "FenShengYuanXiaoLuQu", (Year > 0 ? Year.ToString() : "All")) + "] AS FSYXLQ,[School] AS S " + strSqlTable;

            return Basic.Utils.StrToInt(SqlDB.ExecuteScalar(CommandType.Text, strSql).ToString(), 0);
        }

    }
}
