using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Basic;

namespace DAL.TengXB
{
    public class ZhiYeZhuanYe
    {
        public static DataTable ProfessionalList(string strWhere)
        {
            string strSql = "select Professional.Id as ProfessionalId,Professional.ProfessionalName ";
            strSql += " from ZhiYeZhuanYe,Professional ";
            strSql += " where ZhiYeZhuanYe.ProfessionalId = Professional.Id ";
            if (!string.IsNullOrEmpty(strWhere.Trim()))
                strSql += " and " + strWhere;
            return SqlDB.ExecuteDataset(CommandType.Text, strSql).Tables[0];
        }
    }
}
