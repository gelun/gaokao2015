using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;

using Basic;
using Entity;

namespace DAL
{
    public class ProvinceWeiCi
    {
        #region  ProvinceWeiCi
        ///// <summary>
        ///// 调用存储过程增加一个
        ///// </summary>
        ///// <param name="info">实体对象</param>
        ///// <returns>正常返回大于 0 的自增id, 0代表重复，否则返回-1</returns>
        //public static int ProvinceWeiCiAdd(Entity.ProvinceWeiCi info)
        //{
        //    SqlParameter[] prams = {
        //        SqlDB.MakeInParam("@ProvinceName", SqlDbType.NVarChar, 50, info.ProvinceName),
        //        SqlDB.MakeInParam("@ProvinceId", SqlDbType.Int, 4, info.ProvinceId),
        //        SqlDB.MakeInParam("@KeLeiMingCheng", SqlDbType.NVarChar, 50, info.KeLeiMingCheng),
        //        SqlDB.MakeInParam("@KeLei", SqlDbType.Int, 4, info.KeLei),
        //        SqlDB.MakeInParam("@DataYear", SqlDbType.Int, 4, info.DataYear),
        //        SqlDB.MakeInParam("@FenShu", SqlDbType.Int, 4, info.FenShu),
        //        SqlDB.MakeInParam("@RenShu", SqlDbType.Int, 4, info.RenShu),
        //        SqlDB.MakeInParam("@LeiJiRenShu", SqlDbType.Int, 4, info.LeiJiRenShu),
        //        SqlDB.MakeInParam("@WeiCi", SqlDbType.Int, 4, info.WeiCi),
        //        SqlDB.MakeInParam("@IsKaoShiYuan", SqlDbType.Int, 4, info.IsKaoShiYuan),
        //        SqlDB.MakeInParam("@FenGe", SqlDbType.Int, 4, info.FenGe),
        //    };
        //    return Basic.Utils.StrToInt(SqlDB.ExecuteScalar(CommandType.StoredProcedure, "ProvinceWeiCiAdd", prams).ToString(), -1);
        //}

        ///// <summary>
        ///// 调用存储过程修改一个
        ///// </summary>
        ///// <param name="info">实体对象</param>
        ///// <returns>更新成功返回ture，否则返回false</returns>
        //public static bool ProvinceWeiCiEdit(Entity.ProvinceWeiCi info)
        //{
        //    SqlParameter[] prams = {
        //        SqlDB.MakeInParam("@Id", SqlDbType.Int, 4, info.Id),
        //        SqlDB.MakeInParam("@ProvinceName", SqlDbType.NVarChar, 50, info.ProvinceName),
        //        SqlDB.MakeInParam("@ProvinceId", SqlDbType.Int, 4, info.ProvinceId),
        //        SqlDB.MakeInParam("@KeLeiMingCheng", SqlDbType.NVarChar, 50, info.KeLeiMingCheng),
        //        SqlDB.MakeInParam("@KeLei", SqlDbType.Int, 4, info.KeLei),
        //        SqlDB.MakeInParam("@DataYear", SqlDbType.Int, 4, info.DataYear),
        //        SqlDB.MakeInParam("@FenShu", SqlDbType.Int, 4, info.FenShu),
        //        SqlDB.MakeInParam("@RenShu", SqlDbType.Int, 4, info.RenShu),
        //        SqlDB.MakeInParam("@LeiJiRenShu", SqlDbType.Int, 4, info.LeiJiRenShu),
        //        SqlDB.MakeInParam("@WeiCi", SqlDbType.Int, 4, info.WeiCi),
        //        SqlDB.MakeInParam("@IsKaoShiYuan", SqlDbType.Int, 4, info.IsKaoShiYuan),
        //        SqlDB.MakeInParam("@FenGe", SqlDbType.Int, 4, info.FenGe),
        //        };
        //    int intReturnValue = 0;
        //    intReturnValue = SqlDB.ExecuteNonQuery(CommandType.StoredProcedure, "ProvinceWeiCiEdit", prams);
        //    if(intReturnValue == 1)
        //        return true;
        //    return false;
        //}

        //[" + DAL.Common.GetProvinceTableName(ProvinceId, "ProvinceWeiCi", "") + "]
        /// <summary>
        /// 获取所有的的值
        /// </summary>
        /// <param name="strWhere">条件，可以为空</param>
        /// <returns>返回DataTable</returns>
        public static DataTable ProvinceWeiCiList(int ProvinceId, string strWhere)
        {
            string strSql;
            if (!string.IsNullOrEmpty(strWhere.Trim()))
                strSql = "SELECT * FROM [ProvinceWeiCi] WHERE " + strWhere + ";";
            else
                strSql = "SELECT * FROM [ProvinceWeiCi] ;";
            return SqlDB.ExecuteDataset(CommandType.Text, strSql).Tables[0];
        }


        public static DataTable ProvinceWeiCiGetByFenShuList(int FenShu, int ProvinceId, int KeLei)
        {
            int NowYear = DateTime.Now.Year;
            DataTable dt = new DataTable();
            DataTable dtCopy = new DataTable();
            //dt2 = dt.Copy();
            //dt2.Rows.Clear();
            //dt2.ImportRow(dt.Rows[0]);//这是加入的是第一行

            for (int i = NowYear; i >= 2010; i--)
            {
                string strSql = "SELECT TOP 1 * FROM [ProvinceWeiCi] WHERE ProvinceId = " + ProvinceId + " AND KeLei = " + KeLei + " AND FenShu <= " + FenShu + "  AND [DataYear]=" + i + "  ORDER BY IsKaoshiyuan DESC,WeiCi ASC,PiCi asc ";
                dt = SqlDB.ExecuteDataset(CommandType.Text, strSql).Tables[0];
                if (dtCopy.Rows.Count == 0 && dt.Rows.Count > 0)
                    dtCopy = dt.Copy();
                else if (dt.Rows.Count > 0)
                    dtCopy.ImportRow(dt.Rows[0]);
            }

            return dtCopy;
        }
        public static DataTable ProvinceWeiCiGetByFenShuList(int FenShu, int ProvinceId, int KeLei, int PiCi)
        {
            int NowYear = DateTime.Now.Year;
            DataTable dt = new DataTable();
            DataTable dtCopy = new DataTable();
            //dt2 = dt.Copy();
            //dt2.Rows.Clear();
            //dt2.ImportRow(dt.Rows[0]);//这是加入的是第一行

            for (int i = NowYear; i >= 2010; i--)
            {
                string strSql = "SELECT TOP 1 * FROM [ProvinceWeiCi] WHERE ProvinceId = " + ProvinceId + " AND KeLei = " + KeLei + " AND FenShu <= " + FenShu + "  AND [DataYear]=" + i + " AND PiCi = " + PiCi + " ORDER BY IsKaoshiyuan DESC,WeiCi ASC,PiCi asc ";
                dt = SqlDB.ExecuteDataset(CommandType.Text, strSql).Tables[0];
                if (dtCopy.Rows.Count == 0 && dt.Rows.Count > 0)
                    dtCopy = dt.Copy();
                else if (dt.Rows.Count > 0)
                    dtCopy.ImportRow(dt.Rows[0]);
            }

            return dtCopy;
        }

        public static DataTable ProvinceWeiCiGetByFenShu(int FenShu, int DataYear, int ProvinceId, int KeLei)
        {
            string strSql = "SELECT TOP 1 * FROM [ProvinceWeiCi] WHERE ProvinceId = " + ProvinceId + " AND KeLei = " + KeLei + " AND FenShu <= " + FenShu + "  AND [DataYear]=" + DataYear + "  ORDER BY IsKaoshiyuan DESC,WeiCi ASC,PiCi asc ";
            return SqlDB.ExecuteDataset(CommandType.Text, strSql).Tables[0];
        }


        public static Entity.ProvinceWeiCi ProvinceWeiCiEntityGetByFenShu(int FenShu, int DataYear, int ProvinceId, int KeLei)
        {
            Entity.ProvinceWeiCi info = new Entity.ProvinceWeiCi();
            string strSql = "SELECT TOP 1 * FROM [ProvinceWeiCi] WHERE ProvinceId = " + ProvinceId + " AND KeLei = " + KeLei + " AND FenShu <= " + FenShu + "  AND [DataYear]=" + DataYear + "  ORDER BY IsKaoshiyuan DESC,WeiCi ASC,PiCi asc ";
            DataTable dt = SqlDB.ExecuteDataset(CommandType.Text, strSql).Tables[0];
            if (dt.Rows.Count > 0)
            {
                info.Id = Basic.Utils.StrToInt(dt.Rows[0]["Id"].ToString(), 0);
                info.ProvinceName = dt.Rows[0]["ProvinceName"].ToString();
                info.ProvinceId = Basic.Utils.StrToInt(dt.Rows[0]["ProvinceId"].ToString(), 0);
                info.KeLeiMingCheng = dt.Rows[0]["KeLeiMingCheng"].ToString();
                info.KeLei = Basic.Utils.StrToInt(dt.Rows[0]["KeLei"].ToString(), 0);
                info.DataYear = Basic.Utils.StrToInt(dt.Rows[0]["DataYear"].ToString(), 0);
                info.FenShu = Basic.Utils.StrToInt(dt.Rows[0]["FenShu"].ToString(), 0);
                info.RenShu = Basic.Utils.StrToInt(dt.Rows[0]["RenShu"].ToString(), 0);
                info.LeiJiRenShu = Basic.Utils.StrToInt(dt.Rows[0]["LeiJiRenShu"].ToString(), 0);
                info.WeiCi = Basic.Utils.StrToInt(dt.Rows[0]["WeiCi"].ToString(), 0);
                info.IsKaoShiYuan = Basic.Utils.StrToInt(dt.Rows[0]["IsKaoShiYuan"].ToString(), 0);
                info.FenGe = Basic.Utils.StrToInt(dt.Rows[0]["FenGe"].ToString(), 0);
            }
            else
                return null;
            return info;
        }


        public static Entity.ProvinceWeiCi ProvinceWeiCiEntityGetMin(int DataYear, int ProvinceId, int KeLei)
        {
            Entity.ProvinceWeiCi info = new Entity.ProvinceWeiCi();
            string strSql = "SELECT TOP 1 * FROM [ProvinceWeiCi] WHERE ProvinceId = " + ProvinceId + " AND KeLei = " + KeLei + " AND [DataYear]=" + DataYear + "  ORDER BY IsKaoshiyuan DESC,WeiCi ASC,PiCi asc,FenShu ASC ";
            DataTable dt = SqlDB.ExecuteDataset(CommandType.Text, strSql).Tables[0];
            if (dt.Rows.Count > 0)
            {
                info.Id = Basic.Utils.StrToInt(dt.Rows[0]["Id"].ToString(), 0);
                info.ProvinceName = dt.Rows[0]["ProvinceName"].ToString();
                info.ProvinceId = Basic.Utils.StrToInt(dt.Rows[0]["ProvinceId"].ToString(), 0);
                info.KeLeiMingCheng = dt.Rows[0]["KeLeiMingCheng"].ToString();
                info.KeLei = Basic.Utils.StrToInt(dt.Rows[0]["KeLei"].ToString(), 0);
                info.DataYear = Basic.Utils.StrToInt(dt.Rows[0]["DataYear"].ToString(), 0);
                info.FenShu = Basic.Utils.StrToInt(dt.Rows[0]["FenShu"].ToString(), 0);
                info.RenShu = Basic.Utils.StrToInt(dt.Rows[0]["RenShu"].ToString(), 0);
                info.LeiJiRenShu = Basic.Utils.StrToInt(dt.Rows[0]["LeiJiRenShu"].ToString(), 0);
                info.WeiCi = Basic.Utils.StrToInt(dt.Rows[0]["WeiCi"].ToString(), 0);
                info.IsKaoShiYuan = Basic.Utils.StrToInt(dt.Rows[0]["IsKaoShiYuan"].ToString(), 0);
                info.FenGe = Basic.Utils.StrToInt(dt.Rows[0]["FenGe"].ToString(), 0);
            }
            else
                return null;
            return info;
        }
        public static Entity.ProvinceWeiCi ProvinceWeiCiEntityGetByFenShu(int FenShu, int DataYear, int ProvinceId, int KeLei,int PiCi)
        {
            Entity.ProvinceWeiCi info = new Entity.ProvinceWeiCi();
            string strSql = "SELECT TOP 1 * FROM [ProvinceWeiCi] WHERE ProvinceId = " + ProvinceId + " AND KeLei = " + KeLei + " AND FenShu <= " + FenShu + "  AND [DataYear]=" + DataYear + " AND PiCi = " + PiCi + " ORDER BY IsKaoshiyuan DESC,WeiCi ASC,PiCi asc ";
            DataTable dt = SqlDB.ExecuteDataset(CommandType.Text, strSql).Tables[0];
            if (dt.Rows.Count > 0)
            {
                info.Id = Basic.Utils.StrToInt(dt.Rows[0]["Id"].ToString(), 0);
                info.ProvinceName = dt.Rows[0]["ProvinceName"].ToString();
                info.ProvinceId = Basic.Utils.StrToInt(dt.Rows[0]["ProvinceId"].ToString(), 0);
                info.KeLeiMingCheng = dt.Rows[0]["KeLeiMingCheng"].ToString();
                info.KeLei = Basic.Utils.StrToInt(dt.Rows[0]["KeLei"].ToString(), 0);
                info.DataYear = Basic.Utils.StrToInt(dt.Rows[0]["DataYear"].ToString(), 0);
                info.FenShu = Basic.Utils.StrToInt(dt.Rows[0]["FenShu"].ToString(), 0);
                info.RenShu = Basic.Utils.StrToInt(dt.Rows[0]["RenShu"].ToString(), 0);
                info.LeiJiRenShu = Basic.Utils.StrToInt(dt.Rows[0]["LeiJiRenShu"].ToString(), 0);
                info.WeiCi = Basic.Utils.StrToInt(dt.Rows[0]["WeiCi"].ToString(), 0);
                info.IsKaoShiYuan = Basic.Utils.StrToInt(dt.Rows[0]["IsKaoShiYuan"].ToString(), 0);
                info.FenGe = Basic.Utils.StrToInt(dt.Rows[0]["FenGe"].ToString(), 0);
            }
            else
                return null;
            return info;
        }


        public static DataTable ProvinceFenShuGetByWeiCiList(int WeiCi, int ProvinceId, int KeLei)
        {
            int NowYear = DateTime.Now.Year;
            DataTable dt = new DataTable();
            DataTable dtCopy = new DataTable();

            for (int i = NowYear; i >= 2010; i--)
            {
                string strSql = "SELECT TOP 1 * FROM [ProvinceWeiCi] WHERE ProvinceId = " + ProvinceId + " AND KeLei = " + KeLei + " AND WeiCi <= " + WeiCi + "  AND [DataYear]=" + i + "  ORDER BY IsKaoshiyuan DESC,WeiCi DESC,PiCi asc ";
                dt = SqlDB.ExecuteDataset(CommandType.Text, strSql).Tables[0];
                if (dtCopy.Rows.Count == 0 && dt.Rows.Count > 0)
                    dtCopy = dt.Copy();
                else if (dt.Rows.Count > 0)
                    dtCopy.ImportRow(dt.Rows[0]);
            }

            return dtCopy;
        }

        public static DataTable ProvinceFenShuGetByWeiCi(int WeiCi, int DataYear, int ProvinceId, int KeLei)
        {
            string strSql = "SELECT TOP 1 * FROM [ProvinceWeiCi] WHERE ProvinceId = " + ProvinceId + " AND KeLei = " + KeLei + " AND WeiCi <= " + WeiCi + "  AND [DataYear]=" + DataYear + "  ORDER BY IsKaoshiyuan DESC,WeiCi DESC,PiCi asc ";
            return SqlDB.ExecuteDataset(CommandType.Text, strSql).Tables[0];
        }

        ///// <summary>
        ///// 获取某一个DataTable
        ///// </summary>
        ///// <param name="Id">标识</param>
        ///// <returns>返回DataTable</returns>
        //public static DataTable ProvinceWeiCiGet(int Id)
        //{
        //    return SqlDB.ExecuteDataset(CommandType.Text, "SELECT * FROM [ProvinceWeiCi] WHERE Id = "+Id+";").Tables[0];
        //}

        ///// <summary>
        ///// 获取某一个实体
        ///// </summary>
        ///// <param name="Id">标识</param>
        ///// <returns>返回Entity</returns>
        //public static Entity.ProvinceWeiCi ProvinceWeiCiEntityGet(int Id)
        //{
        //    Entity.ProvinceWeiCi info = new Entity.ProvinceWeiCi();
        //    DataTable dt = SqlDB.ExecuteDataset(CommandType.Text, "SELECT * FROM [ProvinceWeiCi] WHERE Id = "+Id+";").Tables[0];
        //    if(dt.Rows.Count >0)
        //    {
        //        info.Id = Basic.Utils.StrToInt(dt.Rows[0]["Id"].ToString(),0);
        //        info.ProvinceName = dt.Rows[0]["ProvinceName"].ToString();
        //        info.ProvinceId = Basic.Utils.StrToInt(dt.Rows[0]["ProvinceId"].ToString(),0);
        //        info.KeLeiMingCheng = dt.Rows[0]["KeLeiMingCheng"].ToString();
        //        info.KeLei = Basic.Utils.StrToInt(dt.Rows[0]["KeLei"].ToString(),0);
        //        info.DataYear = Basic.Utils.StrToInt(dt.Rows[0]["DataYear"].ToString(),0);
        //        info.FenShu = Basic.Utils.StrToInt(dt.Rows[0]["FenShu"].ToString(),0);
        //        info.RenShu = Basic.Utils.StrToInt(dt.Rows[0]["RenShu"].ToString(),0);
        //        info.LeiJiRenShu = Basic.Utils.StrToInt(dt.Rows[0]["LeiJiRenShu"].ToString(),0);
        //        info.WeiCi = Basic.Utils.StrToInt(dt.Rows[0]["WeiCi"].ToString(),0);
        //        info.IsKaoShiYuan = Basic.Utils.StrToInt(dt.Rows[0]["IsKaoShiYuan"].ToString(),0);
        //        info.FenGe = Basic.Utils.StrToInt(dt.Rows[0]["FenGe"].ToString(),0);
        //    }
        //    return info;
        //}

        ///// <summary>
        ///// 删除一个值
        ///// </summary>
        ///// <param name="Id">自增id的值</param>
        ///// <returns>删除成功返回ture，否则返回false</returns>
        //public static bool ProvinceWeiCiDel(int Id)
        //{
        //    int intReturnValue = 0;
        //    intReturnValue = SqlDB.ExecuteNonQuery(CommandType.Text, "DELETE [ProvinceWeiCi]  WHERE Id =  " + Id);
        //    if(intReturnValue == 1)
        //        return true;
        //    return false;
        //}

        ///// <summary>
        ///// 获取前多少的值
        ///// </summary>
        ///// <param name="strWhere">条件，可以为空</param>
        ///// <param name="TopNumber">数量</param>
        ///// <returns>返回DataTable</returns>
        //public static DataTable ProvinceWeiCiTopGet(string strWhere,int TopNumber)
        //{
        //    string strSql;
        //    if (!string.IsNullOrEmpty(strWhere.Trim()))
        //        strSql = "SELECT TOP " + TopNumber.ToString() + " * FROM [ProvinceWeiCi] WHERE "+ strWhere +";";
        //    else
        //        strSql = "SELECT TOP " + TopNumber.ToString() + " * FROM [ProvinceWeiCi] ;";
        //    return SqlDB.ExecuteDataset(CommandType.Text, strSql).Tables[0];
        //}

        /////
        ///// <summary>
        ///// 获取前多少的值
        ///// </summary>
        ///// <param name="TopNumber">数量</param>
        ///// <param name="PageSize">每页显示多少个</param>
        ///// <param name="PageIndex">当前页码，最少为1</param>
        ///// <returns>返回DataTable</returns>
        //public static DataTable ProvinceWeiCiPageList(string strWhere,int PageSize,int PageIndex)
        //{
        //    StringBuilder sbSql = new StringBuilder();
        //    sbSql.Append("SELECT * FROM ProvinceWeiCi");
        //    if (!string.IsNullOrEmpty(strWhere.Trim()))
        //    {
        //        sbSql.Append(" WHERE " + strWhere);
        //    }
        //    sbSql.Append(" ORDER BY Id DESC");
        //    DataSet ds = new DataSet();
        //    ds = SqlDB.ExecuteDataset((PageIndex-1)*PageSize, PageSize, CommandType.Text, sbSql.ToString());
        //    if (ds.Tables.Count > 0)
        //    {
        //        return ds.Tables[0];
        //    }
        //    return new DataTable();
        //}

        ///// <summary>
        ///// 获取该条件下的总的数量
        ///// </summary>
        ///// <param name="strWhere">条件，可以为空</param>
        ///// <returns>如果没有就返回0</returns>
        //public static int ProvinceWeiCiCount(string strWhere)
        //{
        //    string strSql;
        //    if (!string.IsNullOrEmpty(strWhere.Trim()))
        //        strSql = "SELECT COUNT(*) FROM [ProvinceWeiCi] WHERE "+ strWhere +";";
        //    else
        //        strSql = "SELECT COUNT(*)  FROM [ProvinceWeiCi] ;";
        //    return Basic.Utils.StrToInt(SqlDB.ExecuteScalar(CommandType.Text, strSql).ToString(), 0);
        //}
        #endregion

    }
}

