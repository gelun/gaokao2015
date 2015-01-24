using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Basic;
using System.Data.SqlClient;

namespace DAL.TengXB
{
    public class GaoKaoCard
    {



        public static Entity.GaoKaoCard GaoKaoCardEntityGetByStudentId(int StudentId)
        {
            Entity.GaoKaoCard info = new Entity.GaoKaoCard();
            DataTable dt = SqlDB.ExecuteDataset(CommandType.Text, "SELECT * FROM [GaoKaoCard] WHERE StudentId = '" + StudentId + "'").Tables[0];
            if (dt.Rows.Count > 0)
            {
                info.ID = Basic.Utils.StrToInt(dt.Rows[0]["ID"].ToString(), 0);
                info.KaHao = dt.Rows[0]["KaHao"].ToString();
                info.MiMa = dt.Rows[0]["MiMa"].ToString();
                info.StudentId = Basic.Utils.StrToInt(dt.Rows[0]["StudentId"].ToString(), 0);
                info.ProvinceId = Basic.Utils.StrToInt(dt.Rows[0]["ProvinceId"].ToString(), 0);
                info.Belong = Basic.Utils.StrToInt(dt.Rows[0]["Belong"].ToString(), 0);
                info.DianId = Basic.Utils.StrToInt(dt.Rows[0]["DianId"].ToString(), 0);
                info.CardLevel = Basic.Utils.StrToInt(dt.Rows[0]["CardLevel"].ToString(), 0);
                info.IsPause = Basic.Utils.StrToInt(dt.Rows[0]["IsPause"].ToString(), 0);
                info.AllowChangeCount = Basic.Utils.StrToInt(dt.Rows[0]["AllowChangeCount"].ToString(), 0);
                info.HaveChangeCount = Basic.Utils.StrToInt(dt.Rows[0]["HaveChangeCount"].ToString(), 0);
                info.Memo = dt.Rows[0]["Memo"].ToString();
                info.DingDanHao = dt.Rows[0]["DingDanHao"].ToString();

                info.EndTime = Basic.TypeConverter.StrToDateTime(dt.Rows[0]["DingDanHao"].ToString());
                info.RegisterDate = Basic.TypeConverter.StrToDateTime(dt.Rows[0]["RegisterDate"].ToString());

                return info;
            }
            else
                return null;
        }

        public static bool UpdateGaoKaoCardPwd(string KaHao, string MiMa)
        {
            int intReturnValue = 0;
            intReturnValue = SqlDB.ExecuteNonQuery(CommandType.Text, "UPDATE [GaoKaoCard] SET MiMa = '" + MiMa + "' WHERE KaHao = '" + KaHao + "'");
            if (intReturnValue == 1)
                return true;
            return false;
        }

        public static bool UpdateJoinStudentPwd(int StudentId, string MiMa)
        {
            int intReturnValue = 0;
            intReturnValue = SqlDB.ExecuteNonQuery(CommandType.Text, "UPDATE [Join].[dbo].[Join_Student] SET StudentPass = '" + MiMa + "' WHERE StudentId = " + StudentId);
            if (intReturnValue == 1)
                return true;
            return false;
        }

        //public static bool SetGaoKaoCardStudentId(int intStudentId, string KaHao)
        //{
        //    int intReturnValue = 0;
        //    intReturnValue = SqlDB.ExecuteNonQuery(CommandType.Text, "UPDATE [GaoKaoCard] SET StudentId = " + intStudentId + "  WHERE KaHao =  '" + KaHao + "'");
        //    if (intReturnValue == 1)
        //        return true;
        //    return false;
        //}


    }
}
