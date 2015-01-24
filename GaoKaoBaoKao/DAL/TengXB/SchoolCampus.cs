using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Basic;

namespace DAL.TengXB
{
   public class SchoolCampus
    {

        #region 2014 - 08 - 14 17:50:00
        public static DataTable GetSchoolCampusList(string strWhere)
        {
            string strSql;
            if (!string.IsNullOrEmpty(strWhere.Trim()))
                strSql = "SELECT Campus,Pano,Heading,Pitch,Zoom,Url FROM [SchoolCampus] WHERE " + strWhere + ";";
            else
                strSql = "SELECT Campus,Pano,Heading,Pitch,Zoom,Url FROM [SchoolCampus] ;";
            return SqlDB.ExecuteDataset(CommandType.Text, strSql).Tables[0];
        }
        #endregion
    }
}
