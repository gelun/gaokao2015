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
    public class Join_Student
    {
        private static string strCon = ConfigurationManager.ConnectionStrings["Join_ConnectionString"].ConnectionString;

        public static Entity.Join_Student Join_StudentEntityGetBank(string StudentBank, string StudentPass)
        {
            Entity.Join_Student info = new Entity.Join_Student();

            SqlParameter[] prams = {
				SqlDB.MakeInParam("@Bank", SqlDbType.NVarChar, 100, StudentBank),
				SqlDB.MakeInParam("@Pass", SqlDbType.NVarChar, 50, StudentPass),
				SqlDB.MakeInParam("@MD5Pass", SqlDbType.NVarChar, 50, Basic.CreateMD5.Md5Encrypt(StudentPass)),};
            DataTable dt = SqlDB.ExecuteDataset(strCon,CommandType.StoredProcedure, "StudentEntityGet", prams).Tables[0];
            // DataTable dt = SqlDB.ExecuteDataset(strCon, CommandType.Text, "SELECT * FROM [Join_Student] WHERE StudentBank = '" + StudentBank + "' AND (StudentPass = '" + StudentPass + "' OR StudentPass = '" + Basic.CreateMD5.Md5Encrypt(StudentPass) + "')").Tables[0];
            if (dt != null && dt.Rows.Count > 0)
            {
                info.StudentId = Basic.Utils.StrToInt(dt.Rows[0]["StudentId"].ToString(), 0);
                info.StudentBank = dt.Rows[0]["StudentBank"].ToString();
                info.StudentPass = dt.Rows[0]["StudentPass"].ToString();
                info.StudenName = dt.Rows[0]["StudenName"].ToString();
                info.StudentName = dt.Rows[0]["StudentName"].ToString();
                info.Sex = Basic.Utils.StrToInt(dt.Rows[0]["Sex"].ToString(), 0);
                info.CellTel = dt.Rows[0]["CellTel"].ToString();
                info.CellPhone = dt.Rows[0]["CellPhone"].ToString();
                info.CellPhoneCheck = Basic.Utils.StrToInt(dt.Rows[0]["CellPhoneCheck"].ToString(), 0);
                info.Address = dt.Rows[0]["Address"].ToString();
                info.SchoolName = dt.Rows[0]["SchoolName"].ToString();
                info.IdNumber = dt.Rows[0]["IdNumber"].ToString();
                info.CheckIdNumber = Basic.Utils.StrToInt(dt.Rows[0]["CheckIdNumber"].ToString(), 0);
                info.IdNumberPic = dt.Rows[0]["IdNumberPic"].ToString();
                info.BirthDate = dt.Rows[0]["BirthDate"].ToString();
                info.RegisterWay = Basic.Utils.StrToInt(dt.Rows[0]["RegisterWay"].ToString(), 0);
                info.RegisterOrigin = dt.Rows[0]["RegisterOrigin"].ToString();
                info.DldId = Basic.Utils.StrToInt(dt.Rows[0]["DldId"].ToString(), 0);
                info.UserCategory = Basic.Utils.StrToInt(dt.Rows[0]["UserCategory"].ToString(), 0);
                info.PositionCase = dt.Rows[0]["PositionCase"].ToString();
                info.IsPause = Basic.Utils.StrToInt(dt.Rows[0]["IsPause"].ToString(), 0);
                info.Mail = dt.Rows[0]["Mail"].ToString();
                info.QQ = dt.Rows[0]["QQ"].ToString();
                info.About = dt.Rows[0]["About"].ToString();
                info.Company = dt.Rows[0]["Company"].ToString();
                info.MSN = dt.Rows[0]["MSN"].ToString();
                info.ArtDialog = Basic.Utils.StrToInt(dt.Rows[0]["ArtDialog"].ToString(), 0);
                info.FuQinPhone = dt.Rows[0]["FuQinPhone"].ToString();
                info.MuQinPhone = dt.Rows[0]["MuQinPhone"].ToString();
                info.WenLi = Basic.Utils.StrToInt(dt.Rows[0]["WenLi"].ToString(), 0);
                info.BanJi = dt.Rows[0]["BanJi"].ToString();
                info.BanZhuRen = dt.Rows[0]["BanZhuRen"].ToString();
                info.ProvinceId = Basic.Utils.StrToInt(dt.Rows[0]["ProvinceId"].ToString(), 0);
                info.CityId = Basic.Utils.StrToInt(dt.Rows[0]["CityId"].ToString(), 0);
                info.CountyId = Basic.Utils.StrToInt(dt.Rows[0]["CountyId"].ToString(), 0);
                info.IsAutoCreat = Basic.Utils.StrToInt(dt.Rows[0]["IsAutoCreat"].ToString(), 0);
                info.BanZhuRenMobile = dt.Rows[0]["BanZhuRenMobile"].ToString();
                info.StudentLevel = Basic.Utils.StrToInt(dt.Rows[0]["StudentLevel"].ToString(), 0);
                info.GKYear = Basic.Utils.StrToInt(dt.Rows[0]["GKYear"].ToString(), 0);

                info.RegisterTime = Basic.Utils.StrToDateTime(dt.Rows[0]["RegisterTime"].ToString());

                return info;
            }
            else
                return null;
        }


        public static bool Join_StudentEdit_WanShanXinXi(Entity.Join_Student info)
        {
            SqlParameter[] prams = {
				SqlDB.MakeInParam("@StudentId", SqlDbType.Int, 4, info.StudentId),
				SqlDB.MakeInParam("@StudentName", SqlDbType.NVarChar, 50, info.StudentName),
				SqlDB.MakeInParam("@Sex", SqlDbType.Int, 4, info.Sex),
				SqlDB.MakeInParam("@CellPhone", SqlDbType.VarChar, 50, info.CellPhone),
				SqlDB.MakeInParam("@SchoolName", SqlDbType.NVarChar, 150, info.SchoolName),
				SqlDB.MakeInParam("@FuQinPhone", SqlDbType.NVarChar, 50, info.FuQinPhone),
				SqlDB.MakeInParam("@MuQinPhone", SqlDbType.NVarChar, 50, info.MuQinPhone),
				SqlDB.MakeInParam("@WenLi", SqlDbType.Int, 4, info.WenLi),
				SqlDB.MakeInParam("@BanJi", SqlDbType.NVarChar, 100, info.BanJi),
				SqlDB.MakeInParam("@BanZhuRen", SqlDbType.NVarChar, 100, info.BanZhuRen),
				SqlDB.MakeInParam("@ProvinceId", SqlDbType.Int, 4, info.ProvinceId),
				SqlDB.MakeInParam("@CityId", SqlDbType.Int, 4, info.CityId),
				SqlDB.MakeInParam("@CountyId", SqlDbType.Int, 4, info.CountyId),
				SqlDB.MakeInParam("@BanZhuRenMobile", SqlDbType.NVarChar, 100, info.BanZhuRenMobile),
				SqlDB.MakeInParam("@GKYear", SqlDbType.Int, 4, info.GKYear),
				SqlDB.MakeInParam("@StudentLevel", SqlDbType.Int, 4, info.StudentLevel),
				};
            int intReturnValue = 0;
            intReturnValue = SqlDB.ExecuteNonQuery(strCon, CommandType.StoredProcedure, "Join_StudentEdit_WanShanXinXi", prams);
            if (intReturnValue == 1)
                return true;
            return false;
        }

        public static int Join_StudentAdd_WanShanXinXi(Entity.Join_Student info)
        {
            SqlParameter[] prams = {
				SqlDB.MakeInParam("@StudentName", SqlDbType.NVarChar, 50, info.StudentName),
				SqlDB.MakeInParam("@Sex", SqlDbType.Int, 4, info.Sex),
				SqlDB.MakeInParam("@CellPhone", SqlDbType.VarChar, 50, info.CellPhone),
				SqlDB.MakeInParam("@SchoolName", SqlDbType.NVarChar, 150, info.SchoolName),
				SqlDB.MakeInParam("@FuQinPhone", SqlDbType.NVarChar, 50, info.FuQinPhone),
				SqlDB.MakeInParam("@MuQinPhone", SqlDbType.NVarChar, 50, info.MuQinPhone),
				SqlDB.MakeInParam("@WenLi", SqlDbType.Int, 4, info.WenLi),
				SqlDB.MakeInParam("@BanJi", SqlDbType.NVarChar, 100, info.BanJi),
				SqlDB.MakeInParam("@BanZhuRen", SqlDbType.NVarChar, 100, info.BanZhuRen),
				SqlDB.MakeInParam("@ProvinceId", SqlDbType.Int, 4, info.ProvinceId),
				SqlDB.MakeInParam("@CityId", SqlDbType.Int, 4, info.CityId),
				SqlDB.MakeInParam("@CountyId", SqlDbType.Int, 4, info.CountyId),
				SqlDB.MakeInParam("@BanZhuRenMobile", SqlDbType.NVarChar, 100, info.BanZhuRenMobile),
				SqlDB.MakeInParam("@GKYear", SqlDbType.Int, 4, info.GKYear),
				SqlDB.MakeInParam("@StudentLevel", SqlDbType.Int, 4, info.StudentLevel),
				};
            return Basic.Utils.StrToInt(SqlDB.ExecuteScalar(strCon, CommandType.StoredProcedure, "Join_StudentAdd_WanShanXinXi", prams).ToString(), -1);
        }


        public static int Join_StudentAdd_WanShanXinXi(Entity.Join_Student info,string KaHao,string MiMa)
        {
            SqlParameter[] prams = {
				SqlDB.MakeInParam("@StudentBank", SqlDbType.NVarChar, 50, KaHao),
				SqlDB.MakeInParam("@StudentPass", SqlDbType.NVarChar, 50, MiMa),
				SqlDB.MakeInParam("@StudentName", SqlDbType.NVarChar, 50, info.StudentName),
				SqlDB.MakeInParam("@Sex", SqlDbType.Int, 4, info.Sex),
				SqlDB.MakeInParam("@CellPhone", SqlDbType.VarChar, 50, info.CellPhone),
				SqlDB.MakeInParam("@SchoolName", SqlDbType.NVarChar, 150, info.SchoolName),
				SqlDB.MakeInParam("@FuQinPhone", SqlDbType.NVarChar, 50, info.FuQinPhone),
				SqlDB.MakeInParam("@MuQinPhone", SqlDbType.NVarChar, 50, info.MuQinPhone),
				SqlDB.MakeInParam("@WenLi", SqlDbType.Int, 4, info.WenLi),
				SqlDB.MakeInParam("@BanJi", SqlDbType.NVarChar, 100, info.BanJi),
				SqlDB.MakeInParam("@BanZhuRen", SqlDbType.NVarChar, 100, info.BanZhuRen),
				SqlDB.MakeInParam("@ProvinceId", SqlDbType.Int, 4, info.ProvinceId),
				SqlDB.MakeInParam("@CityId", SqlDbType.Int, 4, info.CityId),
				SqlDB.MakeInParam("@CountyId", SqlDbType.Int, 4, info.CountyId),
				SqlDB.MakeInParam("@BanZhuRenMobile", SqlDbType.NVarChar, 100, info.BanZhuRenMobile),
				SqlDB.MakeInParam("@GKYear", SqlDbType.Int, 4, info.GKYear),
				SqlDB.MakeInParam("@StudentLevel", SqlDbType.Int, 4, info.StudentLevel),
				};
            return Basic.Utils.StrToInt(SqlDB.ExecuteScalar(strCon, CommandType.StoredProcedure, "Join_StudentAdd_WanShanXinXi_KaMi", prams).ToString(), -1);
        }


        public static int Join_Student_CreateBank(string StudentBank, string StudentPass)
        {
            SqlParameter[] prams = {
				SqlDB.MakeInParam("@StudentBank", SqlDbType.NVarChar, 50, StudentBank),
				SqlDB.MakeInParam("@StudentPass", SqlDbType.NVarChar, 50, StudentPass),
				};
            return Basic.Utils.StrToInt(SqlDB.ExecuteScalar(strCon, CommandType.StoredProcedure, "Join_Student_CreateBank", prams).ToString(), -1);
        }
    }
}
