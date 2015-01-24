using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Basic;

namespace DAL.TengXB
{
  public  class SchoolDisciplines
    {
        #region 2014 - 08 - 14  10:58:00

        public static DataTable GetSchoolDisciplinesList(string strWhere)
        {
            string strSql = "SELECT sd.Id as SchoolDisciplinesId,sd.ProfessionalCount as ProfessionalCount, p.ProfessionalName as DisciplinesName ";
            strSql += " FROM SchoolDisciplines as sd,Professional as p ";
            strSql += " WHERE sd.DisciplinesId= p.Id ";
            if (!string.IsNullOrEmpty(strWhere.Trim()))
                strSql += " AND " + strWhere + ";";

            return SqlDB.ExecuteDataset(CommandType.Text, strSql).Tables[0];
        }

        public static DataTable GetSchoolProfessionalList(string strWhere)
        {
            string strSql = "SELECT SchoolProfessional.Id as SchoolProfessionalId,SchoolProfessional.ProfessionalName as ProfessionalName ";
            strSql += " FROM SchoolProfessional ";
            if (!string.IsNullOrEmpty(strWhere.Trim()))
                strSql += " WHERE " + strWhere + ";";

            return SqlDB.ExecuteDataset(CommandType.Text, strSql).Tables[0];
        }


        public static DataTable YouShiZhuanYeList(string strWhere)
        {
            string strSql = "SELECT sp.Id as SchoolProfessionalId,sp.ProfessionalName as ProfessionalName ";
            strSql += " FROM SchoolProfessional as sp ,SchoolDisciplines as sd ";
            strSql += " WHERE sp.SchoolDisciplinesId = sd.Id ";
            if (!string.IsNullOrEmpty(strWhere.Trim()))
                strSql += " AND " + strWhere + ";";

            return SqlDB.ExecuteDataset(CommandType.Text, strSql).Tables[0];
        }

        #endregion


    }
}
