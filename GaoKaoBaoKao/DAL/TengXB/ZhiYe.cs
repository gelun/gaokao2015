using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Basic;
using System.Data;

namespace DAL.TengXB
{
    public class ZhiYe
    {
        public static bool ZhiYeClickNum(Entity.ZhiYe info)
        {
            int intReturnValue = 0;
            intReturnValue = SqlDB.ExecuteNonQuery(CommandType.Text, "UPDATE [ZhiYe] SET ClickNum = " + info.ClickNum + "  WHERE Id =  " + info.Id);
            if (intReturnValue == 1)
                return true;
            return false;
        }
    }
}
