using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;

using Basic;
using Entity;

namespace DAL
{
    public class YKStudentXinXi
    {
        #region  YKStudentXinXi
        /// <summary>
        /// 调用存储过程增加一个
        /// </summary>
        /// <param name="info">实体对象</param>
        /// <returns>正常返回大于 0 的自增id, 0代表重复，否则返回-1</returns>
        public static int YKStudentXinXiAdd(Entity.YKStudentXinXi info)
        {
            SqlParameter[] prams = {
				SqlDB.MakeInParam("@StudentName", SqlDbType.NVarChar, 50, info.StudentName),
				SqlDB.MakeInParam("@SshengId", SqlDbType.Int, 4, info.SshengId),
				SqlDB.MakeInParam("@Ssheng", SqlDbType.NVarChar, 50, info.Ssheng),
				SqlDB.MakeInParam("@SshiId", SqlDbType.Int, 4, info.SshiId),
				SqlDB.MakeInParam("@Sshi", SqlDbType.NVarChar, 50, info.Sshi),
				SqlDB.MakeInParam("@SQuId", SqlDbType.Int, 4, info.SQuId),
				SqlDB.MakeInParam("@SQu", SqlDbType.NVarChar, 50, info.SQu),
				SqlDB.MakeInParam("@Sex", SqlDbType.Int, 4, info.Sex),
				SqlDB.MakeInParam("@KaoShengPhone", SqlDbType.NVarChar, 50, info.KaoShengPhone),
				SqlDB.MakeInParam("@ChuShengRiQi", SqlDbType.NVarChar, 50, info.ChuShengRiQi),
				SqlDB.MakeInParam("@JiaZhangPhone", SqlDbType.NVarChar, 50, info.JiaZhangPhone),
				SqlDB.MakeInParam("@BiYeXueXiao", SqlDbType.NVarChar, 50, info.BiYeXueXiao),
				SqlDB.MakeInParam("@Email", SqlDbType.NVarChar, 50, info.Email),
				SqlDB.MakeInParam("@Sqq", SqlDbType.NVarChar, 50, info.Sqq),
				SqlDB.MakeInParam("@BaoKaoType", SqlDbType.Int, 4, info.BaoKaoType),
				SqlDB.MakeInParam("@JiaFenFW", SqlDbType.Int, 4, info.JiaFenFW),
				SqlDB.MakeInParam("@FenZhi", SqlDbType.NVarChar, 50, info.FenZhi),
				SqlDB.MakeInParam("@IsJBWL", SqlDbType.Int, 4, info.IsJBWL),
				SqlDB.MakeInParam("@TJZYSXQK", SqlDbType.NVarChar, 500, info.TJZYSXQK),
				SqlDB.MakeInParam("@GRChengJiYouShi", SqlDbType.Int, 4, info.GRChengJiYouShi),
				SqlDB.MakeInParam("@YiKaoChengShiId", SqlDbType.Int, 4, info.YiKaoChengShiId),
				SqlDB.MakeInParam("@YiKaoChengShi", SqlDbType.NVarChar, 50, info.YiKaoChengShi),
				SqlDB.MakeInParam("@YiKaoTypeId", SqlDbType.Int, 4, info.YiKaoTypeId),
				SqlDB.MakeInParam("@YiKaoType", SqlDbType.NVarChar, 50, info.YiKaoType),
				SqlDB.MakeInParam("@KaoShengType", SqlDbType.Int, 4, info.KaoShengType),
				SqlDB.MakeInParam("@YiXiangDiQu", SqlDbType.NVarChar, 100, info.YiXiangDiQu),
				SqlDB.MakeInParam("@YiXiangZhuanYe", SqlDbType.NVarChar, 100, info.YiXiangZhuanYe),
				SqlDB.MakeInParam("@YuanXiaoType", SqlDbType.Int, 4, info.YuanXiaoType),
				SqlDB.MakeInParam("@YiXiangYuanXiao", SqlDbType.NVarChar, 100, info.YiXiangYuanXiao),
				SqlDB.MakeInParam("@LianKaoChengJi", SqlDbType.NVarChar, 50, info.LianKaoChengJi),
				SqlDB.MakeInParam("@BanXueType", SqlDbType.Int, 4, info.BanXueType),
				SqlDB.MakeInParam("@XiaoKaoQingKuang", SqlDbType.NVarChar, 0, info.XiaoKaoQingKuang),
				SqlDB.MakeInParam("@Meto", SqlDbType.NVarChar, 0, info.Meto),
				SqlDB.MakeInParam("@YGYuWen", SqlDbType.NVarChar, 50, info.YGYuWen),
				SqlDB.MakeInParam("@YGShuXue", SqlDbType.NVarChar, 50, info.YGShuXue),
				SqlDB.MakeInParam("@YGYingYu", SqlDbType.NVarChar, 50, info.YGYingYu),
				SqlDB.MakeInParam("@YGZongHe", SqlDbType.NVarChar, 50, info.YGZongHe),
				SqlDB.MakeInParam("@YGZongFen", SqlDbType.NVarChar, 50, info.YGZongFen),
				SqlDB.MakeInParam("@GKYuWen", SqlDbType.NVarChar, 50, info.GKYuWen),
				SqlDB.MakeInParam("@GKShuXue", SqlDbType.NVarChar, 50, info.GKShuXue),
				SqlDB.MakeInParam("@GKYingYu", SqlDbType.NVarChar, 50, info.GKYingYu),
				SqlDB.MakeInParam("@GKZhongHe", SqlDbType.NVarChar, 50, info.GKZhongHe),
				SqlDB.MakeInParam("@GKZongFen", SqlDbType.NVarChar, 50, info.GKZongFen),
				SqlDB.MakeInParam("@DianId", SqlDbType.Int, 4, info.DianId),
				SqlDB.MakeInParam("@IsPause", SqlDbType.Int, 4, info.IsPause),
                SqlDB.MakeInParam("@GaoKaoKaHao", SqlDbType.NVarChar, 50, info.GaoKaoKaHao),
                
			};
            return Basic.Utils.StrToInt(SqlDB.ExecuteScalar(CommandType.StoredProcedure, "YKStudentXinXiAdd", prams).ToString(), -1);
        }

        /// <summary>
        /// 调用存储过程修改一个
        /// </summary>
        /// <param name="info">实体对象</param>
        /// <returns>更新成功返回ture，否则返回false</returns>
        public static bool YKStudentXinXiEdit(Entity.YKStudentXinXi info)
        {
            SqlParameter[] prams = {
				SqlDB.MakeInParam("@Id", SqlDbType.Int, 4, info.Id),
				SqlDB.MakeInParam("@StudentName", SqlDbType.NVarChar, 50, info.StudentName),
				SqlDB.MakeInParam("@SshengId", SqlDbType.Int, 4, info.SshengId),
				SqlDB.MakeInParam("@Ssheng", SqlDbType.NVarChar, 50, info.Ssheng),
				SqlDB.MakeInParam("@SshiId", SqlDbType.Int, 4, info.SshiId),
				SqlDB.MakeInParam("@Sshi", SqlDbType.NVarChar, 50, info.Sshi),
				SqlDB.MakeInParam("@SQuId", SqlDbType.Int, 4, info.SQuId),
				SqlDB.MakeInParam("@SQu", SqlDbType.NVarChar, 50, info.SQu),
				SqlDB.MakeInParam("@Sex", SqlDbType.Int, 4, info.Sex),
				SqlDB.MakeInParam("@KaoShengPhone", SqlDbType.NVarChar, 50, info.KaoShengPhone),
				SqlDB.MakeInParam("@ChuShengRiQi", SqlDbType.NVarChar, 50, info.ChuShengRiQi),
				SqlDB.MakeInParam("@JiaZhangPhone", SqlDbType.NVarChar, 50, info.JiaZhangPhone),
				SqlDB.MakeInParam("@BiYeXueXiao", SqlDbType.NVarChar, 50, info.BiYeXueXiao),
				SqlDB.MakeInParam("@Email", SqlDbType.NVarChar, 50, info.Email),
				SqlDB.MakeInParam("@Sqq", SqlDbType.NVarChar, 50, info.Sqq),
				SqlDB.MakeInParam("@BaoKaoType", SqlDbType.Int, 4, info.BaoKaoType),
				SqlDB.MakeInParam("@JiaFenFW", SqlDbType.Int, 4, info.JiaFenFW),
				SqlDB.MakeInParam("@FenZhi", SqlDbType.NVarChar, 50, info.FenZhi),
				SqlDB.MakeInParam("@IsJBWL", SqlDbType.Int, 4, info.IsJBWL),
				SqlDB.MakeInParam("@TJZYSXQK", SqlDbType.NVarChar, 500, info.TJZYSXQK),
				SqlDB.MakeInParam("@GRChengJiYouShi", SqlDbType.Int, 4, info.GRChengJiYouShi),
				SqlDB.MakeInParam("@YiKaoChengShiId", SqlDbType.Int, 4, info.YiKaoChengShiId),
				SqlDB.MakeInParam("@YiKaoChengShi", SqlDbType.NVarChar, 50, info.YiKaoChengShi),
				SqlDB.MakeInParam("@YiKaoTypeId", SqlDbType.Int, 4, info.YiKaoTypeId),
				SqlDB.MakeInParam("@YiKaoType", SqlDbType.NVarChar, 50, info.YiKaoType),
				SqlDB.MakeInParam("@KaoShengType", SqlDbType.Int, 4, info.KaoShengType),
				SqlDB.MakeInParam("@YiXiangDiQu", SqlDbType.NVarChar, 100, info.YiXiangDiQu),
				SqlDB.MakeInParam("@YiXiangZhuanYe", SqlDbType.NVarChar, 100, info.YiXiangZhuanYe),
				SqlDB.MakeInParam("@YuanXiaoType", SqlDbType.Int, 4, info.YuanXiaoType),
				SqlDB.MakeInParam("@YiXiangYuanXiao", SqlDbType.NVarChar, 100, info.YiXiangYuanXiao),
				SqlDB.MakeInParam("@LianKaoChengJi", SqlDbType.NVarChar, 50, info.LianKaoChengJi),
				SqlDB.MakeInParam("@BanXueType", SqlDbType.Int, 4, info.BanXueType),
				SqlDB.MakeInParam("@XiaoKaoQingKuang", SqlDbType.NVarChar, 0, info.XiaoKaoQingKuang),
				SqlDB.MakeInParam("@Meto", SqlDbType.NVarChar, 0, info.Meto),
				SqlDB.MakeInParam("@YGYuWen", SqlDbType.NVarChar, 50, info.YGYuWen),
				SqlDB.MakeInParam("@YGShuXue", SqlDbType.NVarChar, 50, info.YGShuXue),
				SqlDB.MakeInParam("@YGYingYu", SqlDbType.NVarChar, 50, info.YGYingYu),
				SqlDB.MakeInParam("@YGZongHe", SqlDbType.NVarChar, 50, info.YGZongHe),
				SqlDB.MakeInParam("@YGZongFen", SqlDbType.NVarChar, 50, info.YGZongFen),
				SqlDB.MakeInParam("@GKYuWen", SqlDbType.NVarChar, 50, info.GKYuWen),
				SqlDB.MakeInParam("@GKShuXue", SqlDbType.NVarChar, 50, info.GKShuXue),
				SqlDB.MakeInParam("@GKYingYu", SqlDbType.NVarChar, 50, info.GKYingYu),
				SqlDB.MakeInParam("@GKZhongHe", SqlDbType.NVarChar, 50, info.GKZhongHe),
				SqlDB.MakeInParam("@GKZongFen", SqlDbType.NVarChar, 50, info.GKZongFen),
				SqlDB.MakeInParam("@DianId", SqlDbType.Int, 4, info.DianId),
				SqlDB.MakeInParam("@IsPause", SqlDbType.Int, 4, info.IsPause),
                SqlDB.MakeInParam("@GaoKaoKaHao", SqlDbType.NVarChar, 50, info.GaoKaoKaHao),
                
				};
            int intReturnValue = 0;
            intReturnValue = SqlDB.ExecuteNonQuery(CommandType.StoredProcedure, "YKStudentXinXiEdit", prams);
            if (intReturnValue == 1)
                return true;
            return false;
        }



        public static bool YKStudentShangChuanWenDang(Entity.YKStudentXinXi info)
        {
            SqlParameter[] prams = {
				SqlDB.MakeInParam("@Id", SqlDbType.Int, 4, info.Id),
				SqlDB.MakeInParam("@SolutionUrl", SqlDbType.NVarChar, 50, info.SolutionUrl),
				};
            int intReturnValue = 0;
            intReturnValue = SqlDB.ExecuteNonQuery(CommandType.StoredProcedure, "YKStudentShangChuanWenDang", prams);
            if (intReturnValue == 1)
                return true;
            return false;
        }

        public static bool YKStudentBeiZhu(Entity.YKStudentXinXi info)
        {
            SqlParameter[] prams = {
				SqlDB.MakeInParam("@Id", SqlDbType.Int, 4, info.Id),
				SqlDB.MakeInParam("@BeiZhu", SqlDbType.NVarChar, 500, info.BeiZhu),
				};
            int intReturnValue = 0;
            intReturnValue = SqlDB.ExecuteNonQuery(CommandType.StoredProcedure, "YKStudentBeiZhu", prams);
            if (intReturnValue == 1)
                return true;
            return false;
        }

        /// <summary>
        /// 暂停该值
        /// </summary>
        /// <param name="Id">自增id的值</param>
        /// <returns>暂停成功返回ture，否则返回false</returns>
        public static bool YKStudentXinXiPause(Entity.YKStudentXinXi info)
        {
            int intReturnValue = 0;
            intReturnValue = SqlDB.ExecuteNonQuery(CommandType.Text, "UPDATE [YKStudentXinXi] SET IsPause = " + info.IsPause + "  WHERE Id =  " + info.Id);
            if (intReturnValue == 1)
                return true;
            return false;
        }

        /// <summary>
        /// 获取所有的的值
        /// </summary>
        /// <param name="strWhere">条件，可以为空</param>
        /// <returns>返回DataTable</returns>
        public static DataTable YKStudentXinXiList(string strWhere)
        {
            string strSql;
            if (!string.IsNullOrEmpty(strWhere.Trim()))
                strSql = "SELECT * FROM [YKStudentXinXi] WHERE " + strWhere + ";";
            else
                strSql = "SELECT * FROM [YKStudentXinXi] ;";
            return SqlDB.ExecuteDataset(CommandType.Text, strSql).Tables[0];
        }


        /// <summary>
        /// 获取某一个DataTable
        /// </summary>
        /// <param name="Id">标识</param>
        /// <returns>返回DataTable</returns>
        public static DataTable YKStudentXinXiGet(int Id)
        {
            return SqlDB.ExecuteDataset(CommandType.Text, "SELECT * FROM [YKStudentXinXi] WHERE Id = " + Id + ";").Tables[0];
        }

        /// <summary>
        /// 获取某一个实体
        /// </summary>
        /// <param name="Id">标识</param>
        /// <returns>返回Entity</returns>
        public static Entity.YKStudentXinXi YKStudentXinXiEntityGet(int Id)
        {
            Entity.YKStudentXinXi info = new Entity.YKStudentXinXi();
            DataTable dt = SqlDB.ExecuteDataset(CommandType.Text, "SELECT * FROM [YKStudentXinXi] WHERE Id = " + Id + ";").Tables[0];
            if (dt.Rows.Count > 0)
            {
                info.Id = Basic.Utils.StrToInt(dt.Rows[0]["Id"].ToString(), 0);
                info.StudentName = dt.Rows[0]["StudentName"].ToString();
                info.SshengId = Basic.Utils.StrToInt(dt.Rows[0]["SshengId"].ToString(), 0);
                info.Ssheng = dt.Rows[0]["Ssheng"].ToString();
                info.SshiId = Basic.Utils.StrToInt(dt.Rows[0]["SshiId"].ToString(), 0);
                info.Sshi = dt.Rows[0]["Sshi"].ToString();
                info.SQuId = Basic.Utils.StrToInt(dt.Rows[0]["SQuId"].ToString(), 0);
                info.SQu = dt.Rows[0]["SQu"].ToString();
                info.Sex = Basic.Utils.StrToInt(dt.Rows[0]["Sex"].ToString(), 0);
                info.KaoShengPhone = dt.Rows[0]["KaoShengPhone"].ToString();
                info.ChuShengRiQi = dt.Rows[0]["ChuShengRiQi"].ToString();
                info.JiaZhangPhone = dt.Rows[0]["JiaZhangPhone"].ToString();
                info.BiYeXueXiao = dt.Rows[0]["BiYeXueXiao"].ToString();
                info.Email = dt.Rows[0]["Email"].ToString();
                info.Sqq = dt.Rows[0]["Sqq"].ToString();
                info.BaoKaoType = Basic.Utils.StrToInt(dt.Rows[0]["BaoKaoType"].ToString(), 0);
                info.JiaFenFW = Basic.Utils.StrToInt(dt.Rows[0]["JiaFenFW"].ToString(), 0);
                info.FenZhi = dt.Rows[0]["FenZhi"].ToString();
                info.IsJBWL = Basic.Utils.StrToInt(dt.Rows[0]["IsJBWL"].ToString(), 0);
                info.TJZYSXQK = dt.Rows[0]["TJZYSXQK"].ToString();
                info.GRChengJiYouShi = Basic.Utils.StrToInt(dt.Rows[0]["GRChengJiYouShi"].ToString(), 0);
                info.YiKaoChengShiId = Basic.Utils.StrToInt(dt.Rows[0]["YiKaoChengShiId"].ToString(), 0);
                info.YiKaoChengShi = dt.Rows[0]["YiKaoChengShi"].ToString();
                info.YiKaoTypeId = Basic.Utils.StrToInt(dt.Rows[0]["YiKaoTypeId"].ToString(), 0);
                info.YiKaoType = dt.Rows[0]["YiKaoType"].ToString();
                info.KaoShengType = Basic.Utils.StrToInt(dt.Rows[0]["KaoShengType"].ToString(), 0);
                info.YiXiangDiQu = dt.Rows[0]["YiXiangDiQu"].ToString();
                info.YiXiangZhuanYe = dt.Rows[0]["YiXiangZhuanYe"].ToString();
                info.YuanXiaoType = Basic.Utils.StrToInt(dt.Rows[0]["YuanXiaoType"].ToString(), 0);
                info.YiXiangYuanXiao = dt.Rows[0]["YiXiangYuanXiao"].ToString();
                info.LianKaoChengJi = dt.Rows[0]["LianKaoChengJi"].ToString();
                info.BanXueType = Basic.Utils.StrToInt(dt.Rows[0]["BanXueType"].ToString(), 0);
                info.XiaoKaoQingKuang = dt.Rows[0]["XiaoKaoQingKuang"].ToString();
                info.Meto = dt.Rows[0]["Meto"].ToString();
                info.YGYuWen = dt.Rows[0]["YGYuWen"].ToString();
                info.YGShuXue = dt.Rows[0]["YGShuXue"].ToString();
                info.YGYingYu = dt.Rows[0]["YGYingYu"].ToString();
                info.YGZongHe = dt.Rows[0]["YGZongHe"].ToString();
                info.YGZongFen = dt.Rows[0]["YGZongFen"].ToString();
                info.GKYuWen = dt.Rows[0]["GKYuWen"].ToString();
                info.GKShuXue = dt.Rows[0]["GKShuXue"].ToString();
                info.GKYingYu = dt.Rows[0]["GKYingYu"].ToString();
                info.GKZhongHe = dt.Rows[0]["GKZhongHe"].ToString();
                info.GKZongFen = dt.Rows[0]["GKZongFen"].ToString();
                info.DianId = Basic.Utils.StrToInt(dt.Rows[0]["DianId"].ToString(), 0);
                info.IsPause = Basic.Utils.StrToInt(dt.Rows[0]["IsPause"].ToString(), 0);
                info.SolutionUrl = dt.Rows[0]["SolutionUrl"].ToString();
                info.BeiZhu = dt.Rows[0]["BeiZhu"].ToString();
                info.GaoKaoKaHao = dt.Rows[0]["GaoKaoKaHao"].ToString();
                info.AddTime = Basic.TypeConverter.ObjectToDateTime(dt.Rows[0]["AddTime"]);
                return info;
            }
            else
            {
                return null;
            }
          
        }

        /// <summary>
        /// 删除一个值
        /// </summary>
        /// <param name="Id">自增id的值</param>
        /// <returns>删除成功返回ture，否则返回false</returns>
        public static bool YKStudentXinXiDel(int Id)
        {
            int intReturnValue = 0;
            intReturnValue = SqlDB.ExecuteNonQuery(CommandType.Text, "DELETE [YKStudentXinXi]  WHERE Id =  " + Id);
            if (intReturnValue == 1)
                return true;
            return false;
        }

        /// <summary>
        /// 获取前多少的值
        /// </summary>
        /// <param name="strWhere">条件，可以为空</param>
        /// <param name="TopNumber">数量</param>
        /// <returns>返回DataTable</returns>
        public static DataTable YKStudentXinXiTopGet(string strWhere, int TopNumber)
        {
            string strSql;
            if (!string.IsNullOrEmpty(strWhere.Trim()))
                strSql = "SELECT TOP " + TopNumber.ToString() + " * FROM [YKStudentXinXi] WHERE " + strWhere + ";";
            else
                strSql = "SELECT TOP " + TopNumber.ToString() + " * FROM [YKStudentXinXi] ;";
            return SqlDB.ExecuteDataset(CommandType.Text, strSql).Tables[0];
        }

        ///
        /// <summary>
        /// 获取前多少的值
        /// </summary>
        /// <param name="TopNumber">数量</param>
        /// <param name="PageSize">每页显示多少个</param>
        /// <param name="PageIndex">当前页码，最少为1</param>
        /// <returns>返回DataTable</returns>
        public static DataTable YKStudentXinXiPageList(string strWhere, int PageSize, int PageIndex)
        {
            StringBuilder sbSql = new StringBuilder();
            sbSql.Append("SELECT * FROM YKStudentXinXi");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                sbSql.Append(" WHERE " + strWhere);
            }
            sbSql.Append(" ORDER BY Id DESC");
            DataSet ds = new DataSet();
            ds = SqlDB.ExecuteDataset((PageIndex - 1) * PageSize, PageSize, CommandType.Text, sbSql.ToString());
            if (ds.Tables.Count > 0)
            {
                return ds.Tables[0];
            }
            return new DataTable();
        }

        /// <summary>
        /// 获取该条件下的总的数量
        /// </summary>
        /// <param name="strWhere">条件，可以为空</param>
        /// <returns>如果没有就返回0</returns>
        public static int YKStudentXinXiCount(string strWhere)
        {
            string strSql;
            if (!string.IsNullOrEmpty(strWhere.Trim()))
                strSql = "SELECT COUNT(*) FROM [YKStudentXinXi] WHERE " + strWhere + ";";
            else
                strSql = "SELECT COUNT(*)  FROM [YKStudentXinXi] ;";
            return Basic.Utils.StrToInt(SqlDB.ExecuteScalar(CommandType.Text, strSql).ToString(), 0);
        }
        #endregion

        public static Entity.YKStudentXinXi YKStudentXinXiEntityGetByGaoKaoKaHao(string strGaKaoKaHao)
        {
            Entity.YKStudentXinXi info = new Entity.YKStudentXinXi();
            DataTable dt = SqlDB.ExecuteDataset(CommandType.Text, "SELECT * FROM [YKStudentXinXi] WHERE GaoKaoKaHao = '" + strGaKaoKaHao + "'").Tables[0];
            if (dt.Rows.Count > 0)
            {
                info.Id = Basic.Utils.StrToInt(dt.Rows[0]["Id"].ToString(), 0);
                info.StudentName = dt.Rows[0]["StudentName"].ToString();
                info.SshengId = Basic.Utils.StrToInt(dt.Rows[0]["SshengId"].ToString(), 0);
                info.Ssheng = dt.Rows[0]["Ssheng"].ToString();
                info.SshiId = Basic.Utils.StrToInt(dt.Rows[0]["SshiId"].ToString(), 0);
                info.Sshi = dt.Rows[0]["Sshi"].ToString();
                info.SQuId = Basic.Utils.StrToInt(dt.Rows[0]["SQuId"].ToString(), 0);
                info.SQu = dt.Rows[0]["SQu"].ToString();
                info.Sex = Basic.Utils.StrToInt(dt.Rows[0]["Sex"].ToString(), 0);
                info.KaoShengPhone = dt.Rows[0]["KaoShengPhone"].ToString();
                info.ChuShengRiQi = dt.Rows[0]["ChuShengRiQi"].ToString();
                info.JiaZhangPhone = dt.Rows[0]["JiaZhangPhone"].ToString();
                info.BiYeXueXiao = dt.Rows[0]["BiYeXueXiao"].ToString();
                info.Email = dt.Rows[0]["Email"].ToString();
                info.Sqq = dt.Rows[0]["Sqq"].ToString();
                info.BaoKaoType = Basic.Utils.StrToInt(dt.Rows[0]["BaoKaoType"].ToString(), 0);
                info.JiaFenFW = Basic.Utils.StrToInt(dt.Rows[0]["JiaFenFW"].ToString(), 0);
                info.FenZhi = dt.Rows[0]["FenZhi"].ToString();
                info.IsJBWL = Basic.Utils.StrToInt(dt.Rows[0]["IsJBWL"].ToString(), 0);
                info.TJZYSXQK = dt.Rows[0]["TJZYSXQK"].ToString();
                info.GRChengJiYouShi = Basic.Utils.StrToInt(dt.Rows[0]["GRChengJiYouShi"].ToString(), 0);
                info.YiKaoChengShiId = Basic.Utils.StrToInt(dt.Rows[0]["YiKaoChengShiId"].ToString(), 0);
                info.YiKaoChengShi = dt.Rows[0]["YiKaoChengShi"].ToString();
                info.YiKaoTypeId = Basic.Utils.StrToInt(dt.Rows[0]["YiKaoTypeId"].ToString(), 0);
                info.YiKaoType = dt.Rows[0]["YiKaoType"].ToString();
                info.KaoShengType = Basic.Utils.StrToInt(dt.Rows[0]["KaoShengType"].ToString(), 0);
                info.YiXiangDiQu = dt.Rows[0]["YiXiangDiQu"].ToString();
                info.YiXiangZhuanYe = dt.Rows[0]["YiXiangZhuanYe"].ToString();
                info.YuanXiaoType = Basic.Utils.StrToInt(dt.Rows[0]["YuanXiaoType"].ToString(), 0);
                info.YiXiangYuanXiao = dt.Rows[0]["YiXiangYuanXiao"].ToString();
                info.LianKaoChengJi = dt.Rows[0]["LianKaoChengJi"].ToString();
                info.BanXueType = Basic.Utils.StrToInt(dt.Rows[0]["BanXueType"].ToString(), 0);
                info.XiaoKaoQingKuang = dt.Rows[0]["XiaoKaoQingKuang"].ToString();
                info.Meto = dt.Rows[0]["Meto"].ToString();
                info.YGYuWen = dt.Rows[0]["YGYuWen"].ToString();
                info.YGShuXue = dt.Rows[0]["YGShuXue"].ToString();
                info.YGYingYu = dt.Rows[0]["YGYingYu"].ToString();
                info.YGZongHe = dt.Rows[0]["YGZongHe"].ToString();
                info.YGZongFen = dt.Rows[0]["YGZongFen"].ToString();
                info.GKYuWen = dt.Rows[0]["GKYuWen"].ToString();
                info.GKShuXue = dt.Rows[0]["GKShuXue"].ToString();
                info.GKYingYu = dt.Rows[0]["GKYingYu"].ToString();
                info.GKZhongHe = dt.Rows[0]["GKZhongHe"].ToString();
                info.GKZongFen = dt.Rows[0]["GKZongFen"].ToString();
                info.DianId = Basic.Utils.StrToInt(dt.Rows[0]["DianId"].ToString(), 0);
                info.IsPause = Basic.Utils.StrToInt(dt.Rows[0]["IsPause"].ToString(), 0);
                info.SolutionUrl = dt.Rows[0]["SolutionUrl"].ToString();
                info.BeiZhu = dt.Rows[0]["BeiZhu"].ToString();
                info.GaoKaoKaHao = dt.Rows[0]["GaoKaoKaHao"].ToString();
                info.AddTime = Basic.TypeConverter.ObjectToDateTime(dt.Rows[0]["AddTime"]);
                return info;
            }
            else
            {
                return null;
            }

        }
    }
}
