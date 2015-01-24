using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Basic;

namespace DAL.TengXB
{
    public class FenShengZhuanYeLuQu
    {
        public static DataTable GetFenShengZhuanYeLuQuList(string strWhere, int StudentProvinceId, int LatestBenKeZhuanYeYear)
        {
            string strSql = "SELECT p.Id,p.ProfessionalName FROM " + DAL.Common.GetProvinceTableName("FenShengZhuanYeLuQu", StudentProvinceId, LatestBenKeZhuanYeYear.ToString()) + " as fszy,[Professional] as p WHERE fszy.ZyId = p.Id ";
            if (!string.IsNullOrEmpty(strWhere.Trim()))
                strSql += " AND " + strWhere + ";";
            return SqlDB.ExecuteDataset(CommandType.Text, strSql).Tables[0];
        }
    }
}
