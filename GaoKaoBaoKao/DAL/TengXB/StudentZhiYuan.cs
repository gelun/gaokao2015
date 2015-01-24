using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Basic;

namespace DAL.TengXB
{
    public class StudentZhiYuan
    {

        public static bool StudentZhiYuanDel(int ProvincePcId, int StudentId)
        {
            int intReturnValue = 0;
            intReturnValue = SqlDB.ExecuteNonQuery(CommandType.Text, "DELETE [StudentZhiYuan]  WHERE ProvincePcId = " + ProvincePcId + " and StudentId = " + StudentId);
            if (intReturnValue == 1)
                return true;
            return false;
        }
    }
}
