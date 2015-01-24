using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Basic;
using System.Configuration;
using System.Data.SqlClient;

namespace DAL.TengXB
{
    public class Join_Card
    {
        private static string strCon = ConfigurationManager.ConnectionStrings["Join_ConnectionString"].ConnectionString;

        public static Entity.Join_Card Join_CardEntityGetByCardBank(string CardBank, string CardPass)
        {
            Entity.Join_Card info = new Entity.Join_Card();

            SqlParameter[] prams = {
				SqlDB.MakeInParam("@CardBank", SqlDbType.NVarChar, 100, CardBank),
				SqlDB.MakeInParam("@CardPass", SqlDbType.NVarChar, 50, CardPass),
			};

            DataTable dt = SqlDB.ExecuteDataset(strCon, CommandType.StoredProcedure, "Join_CardEntityGet", prams).Tables[0];
            //DataTable dt = SqlDB.ExecuteDataset(strCon, CommandType.Text, "SELECT * FROM [Join_Card] WHERE CardBank = '" + CardBank + "' AND CardPass = '" + CardPass + "'").Tables[0];
            if (dt.Rows.Count > 0)
            {
                info.CardId = Basic.Utils.StrToInt(dt.Rows[0]["CardId"].ToString(), 0);
                info.CardBank = dt.Rows[0]["CardBank"].ToString();
                info.CardPass = dt.Rows[0]["CardPass"].ToString();
                info.IsValid = Basic.Utils.StrToInt(dt.Rows[0]["IsValid"].ToString(), 0);
                info.UseState = Basic.Utils.StrToInt(dt.Rows[0]["UseState"].ToString(), 0);
                info.DianId = Basic.Utils.StrToInt(dt.Rows[0]["DianId"].ToString(), 0);
                info.ProvinceId = Basic.Utils.StrToInt(dt.Rows[0]["ProvinceId"].ToString(), 0);
                info.StudentId = Basic.Utils.StrToInt(dt.Rows[0]["StudentId"].ToString(), 0);
                info.UseIp = dt.Rows[0]["UseIp"].ToString();
                info.IsTest = Basic.Utils.StrToInt(dt.Rows[0]["IsTest"].ToString(), 0);
                info.OpenCardTime = Basic.TypeConverter.StrToDateTime(dt.Rows[0]["OpenCardTime"].ToString());
                info.UseTime = Basic.TypeConverter.StrToDateTime(dt.Rows[0]["UseTime"].ToString());

                info.OpenCardTime = Basic.TypeConverter.StrToDateTime(dt.Rows[0]["OpenCardTime"].ToString());
                info.UseTime = Basic.TypeConverter.StrToDateTime(dt.Rows[0]["UseTime"].ToString());

                return info;
            }
            else
            {
                return null;
            }
        }


        public static Entity.Join_Card Join_CardEntityGetByCardBank(string CardBank)
        {
            Entity.Join_Card info = new Entity.Join_Card();
            DataTable dt = SqlDB.ExecuteDataset(strCon, CommandType.Text, "SELECT * FROM [Join_Card] WHERE CardBank = '" + CardBank + "'").Tables[0];
            if (dt.Rows.Count > 0)
            {
                info.CardId = Basic.Utils.StrToInt(dt.Rows[0]["CardId"].ToString(), 0);
                info.CardBank = dt.Rows[0]["CardBank"].ToString();
                info.CardPass = dt.Rows[0]["CardPass"].ToString();
                info.IsValid = Basic.Utils.StrToInt(dt.Rows[0]["IsValid"].ToString(), 0);
                info.UseState = Basic.Utils.StrToInt(dt.Rows[0]["UseState"].ToString(), 0);
                info.DianId = Basic.Utils.StrToInt(dt.Rows[0]["DianId"].ToString(), 0);
                info.ProvinceId = Basic.Utils.StrToInt(dt.Rows[0]["ProvinceId"].ToString(), 0);
                info.StudentId = Basic.Utils.StrToInt(dt.Rows[0]["StudentId"].ToString(), 0);
                info.UseIp = dt.Rows[0]["UseIp"].ToString();
                info.IsTest = Basic.Utils.StrToInt(dt.Rows[0]["IsTest"].ToString(), 0);
                info.OpenCardTime = Basic.TypeConverter.StrToDateTime(dt.Rows[0]["OpenCardTime"].ToString());
                info.UseTime = Basic.TypeConverter.StrToDateTime(dt.Rows[0]["UseTime"].ToString());

                return info;
            }
            else
            {
                return null;
            }
        }


        //public static bool SetJoin_CardStudentId(int intStudentId, string KaHao)
        //{
        //    int intReturnValue = 0;
        //    intReturnValue = SqlDB.ExecuteNonQuery(strCon, CommandType.Text, "UPDATE [Join_Card] SET StudentId = " + intStudentId + "  WHERE CardBank =  '" + KaHao + "'");
        //    if (intReturnValue == 1)
        //        return true;
        //    return false;
        //}

        public static bool SetJoin_CardStudentId(int intStudentId, string KaHao, int ProvinceId)
        {
            SqlParameter[] prams = {
				SqlDB.MakeInParam("@StudentId", SqlDbType.Int, 4, intStudentId),
				SqlDB.MakeInParam("@JoinCardBank", SqlDbType.NVarChar, 200, KaHao),
				SqlDB.MakeInParam("@ProvinceId", SqlDbType.Int, 4, ProvinceId),
			};
            int intReturnValue = 0;
            intReturnValue = SqlDB.ExecuteNonQuery(strCon, CommandType.StoredProcedure, "SetJoinCardStudentId", prams);
            if (intReturnValue >= 2)
                return true;
            return false;
        }
    }
}
