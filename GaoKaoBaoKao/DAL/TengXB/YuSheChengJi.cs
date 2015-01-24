using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Basic;

namespace DAL.TengXB
{
    public class YuSheChengJi
    {

        public static Entity.YuSheChengJi YuSheChengJiEntityGetByStudentId(int StudentId)
        {
            Entity.YuSheChengJi info = new Entity.YuSheChengJi();
            DataTable dt = SqlDB.ExecuteDataset(CommandType.Text, "SELECT * FROM [YuSheChengJi] WHERE StudentId = " + StudentId + ";").Tables[0];
            if (dt.Rows.Count > 0)
            {
                info.Id = Basic.Utils.StrToInt(dt.Rows[0]["Id"].ToString(), 0);
                info.StudentId = Basic.Utils.StrToInt(dt.Rows[0]["StudentId"].ToString(), 0);
                info.KeLei = Basic.Utils.StrToInt(dt.Rows[0]["KeLei"].ToString(), 0);
                info.FenShu = Basic.Utils.StrToInt(dt.Rows[0]["FenShu"].ToString(), 0);
                info.PcFirst = Basic.Utils.StrToInt(dt.Rows[0]["PcFirst"].ToString(), 0);
                info.PcSecond = Basic.Utils.StrToInt(dt.Rows[0]["PcSecond"].ToString(), 0);
                info.PcThird = Basic.Utils.StrToInt(dt.Rows[0]["PcThird"].ToString(), 0);
                info.PcZhuanKe = Basic.Utils.StrToInt(dt.Rows[0]["PcZhuanKe"].ToString(), 0);
                info.AddTime = Basic.Utils.StrToDateTime(dt.Rows[0]["AddTime"].ToString());
                return info;
            }
            else
                return null;
        }
    }
}
