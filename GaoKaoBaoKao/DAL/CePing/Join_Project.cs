using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;

using Basic;
using Entity;

namespace DAL
{
    public class Join_Project
    {
        private static string strCon = System.Configuration.ConfigurationManager.ConnectionStrings["Join_ConnectionString"].ConnectionString;
        #region  Join_Project
        /// <summary>
        /// 调用存储过程增加一个
        /// </summary>
        /// <param name="info">实体对象</param>
        /// <returns>正常返回大于 0 的自增id, 0代表重复，否则返回-1</returns>
        public static int Join_ProjectAdd(Entity.Join_Project info)
        {
            SqlParameter[] prams = {
				SqlDB.MakeInParam("@ProjectName", SqlDbType.NVarChar, 1000, info.ProjectName),
				SqlDB.MakeInParam("@Content",SqlDbType.NText, 0, info.Content),
				SqlDB.MakeInParam("@PCid", SqlDbType.Int, 4, info.PCid),
				SqlDB.MakeInParam("@ApplicantFile", SqlDbType.NVarChar, 500, info.ApplicantFile),
			};
            return Basic.Utils.StrToInt(SqlDB.ExecuteScalar(strCon,CommandType.StoredProcedure, "Join_ProjectAdd", prams).ToString(), -1);
        }

        /// <summary>
        /// 调用存储过程修改一个
        /// </summary>
        /// <param name="info">实体对象</param>
        /// <returns>更新成功返回ture，否则返回false</returns>
        public static bool Join_ProjectEdit(Entity.Join_Project info)
        {
            SqlParameter[] prams = {
				SqlDB.MakeInParam("@ProjectId", SqlDbType.Int, 4, info.ProjectId),
				SqlDB.MakeInParam("@ProjectName", SqlDbType.NVarChar, 1000, info.ProjectName),
				SqlDB.MakeInParam("@Content",SqlDbType.NText, 0, info.Content),
				SqlDB.MakeInParam("@PCid", SqlDbType.Int, 4, info.PCid),
				SqlDB.MakeInParam("@ApplicantFile", SqlDbType.NVarChar, 500, info.ApplicantFile),
				};
            int intReturnValue = 0;
            intReturnValue = SqlDB.ExecuteNonQuery(strCon,CommandType.StoredProcedure, "Join_ProjectEdit", prams);
            if (intReturnValue == 1)
                return true;
            return false;
        }

        /// <summary>
        /// 调用存储过程修改一个
        /// </summary>
        /// <param name="info">实体对象</param>
        /// <returns>更新成功返回ture，否则返回false</returns>
        public static bool Join_ProjectEditNew(Entity.Join_Project info)
        {
            SqlParameter[] prams = {
				SqlDB.MakeInParam("@ProjectId", SqlDbType.Int, 4, info.ProjectId),
				SqlDB.MakeInParam("@ProjectName", SqlDbType.NVarChar, 500, info.ProjectName),
				SqlDB.MakeInParam("@Content", SqlDbType.NText, 0, info.Content),
				SqlDB.MakeInParam("@TopPCid", SqlDbType.Int, 4, info.TopPCid),
				SqlDB.MakeInParam("@PCidList", SqlDbType.NVarChar, 100, info.PCidList),
				SqlDB.MakeInParam("@PCid", SqlDbType.Int, 4, info.PCid),
				SqlDB.MakeInParam("@ApplicantFile", SqlDbType.NVarChar, 500, info.ApplicantFile),
				SqlDB.MakeInParam("@IsValid", SqlDbType.Int, 4, info.IsValid),
				SqlDB.MakeInParam("@IsPause", SqlDbType.Int, 4, info.IsPause),
				SqlDB.MakeInParam("@AddTime", SqlDbType.DateTime, 8, info.AddTime),
				SqlDB.MakeInParam("@IsCheck", SqlDbType.Int, 4, info.IsCheck),
				SqlDB.MakeInParam("@IsHot", SqlDbType.Int, 4, info.IsHot),
				};
            int intReturnValue = 0;
            intReturnValue = SqlDB.ExecuteNonQuery(strCon,CommandType.StoredProcedure, "Join_ProjectEditNew", prams);
            if (intReturnValue == 1)
                return true;
            return false;
        }

        /// <summary>
        /// 暂停该值
        /// </summary>
        /// <param name="ProjectId">自增id的值</param>
        /// <returns>暂停成功返回ture，否则返回false</returns>
        public static bool Join_ProjectPause(Entity.Join_Project info)
        {
            int intReturnValue = 0;
            intReturnValue = SqlDB.ExecuteNonQuery(strCon,CommandType.Text, "UPDATE [Join_Project] SET IsPause = " + info.IsPause + "  WHERE ProjectId =  " + info.ProjectId);
            if (intReturnValue == 1)
                return true;
            return false;
        }

        /// <summary>
        /// 信息状态
        /// </summary>
        /// <param name="ProjectId">自增id的值</param>
        /// <returns>暂停成功返回ture，否则返回false</returns>
        public static bool Join_ProjectHot(Entity.Join_Project info)
        {
            int intReturnValue = 0;
            intReturnValue = SqlDB.ExecuteNonQuery(strCon,CommandType.Text, "UPDATE [Join_Project] SET IsHot = " + info.IsHot + "  WHERE ProjectId =  " + info.ProjectId);
            if (intReturnValue == 1)
                return true;
            return false;
        }

        /// <summary>
        /// 暂停该值
        /// </summary>
        /// <param name="ProjectId">自增id的值</param>
        /// <returns>暂停成功返回ture，否则返回false</returns>
        public static bool Join_ProjectValid(Entity.Join_Project info)
        {
            int intReturnValue = 0;
            intReturnValue = SqlDB.ExecuteNonQuery(strCon,CommandType.Text, "UPDATE [Join_Project] SET IsValid = " + info.IsValid + "  WHERE ProjectId =  " + info.ProjectId);
            if (intReturnValue == 1)
                return true;
            return false;
        }
        /// <summary>
        /// 获取所有的的值
        /// </summary>
        /// <param name="strWhere">条件，可以为空</param>
        /// <returns>返回DataTable</returns>
        public static DataTable Join_ProjectList(string strWhere)
        {
            string strSql;
            if (!string.IsNullOrEmpty(strWhere.Trim()))
                strSql = "SELECT * FROM [Join_Project] WHERE " + strWhere + ";";
            else
                strSql = "SELECT * FROM [Join_Project] ;";
            return SqlDB.ExecuteDataset(strCon,CommandType.Text, strSql).Tables[0];
        }


        #endregion


        #region  Join_Project
        /// <summary>
        /// 获取某一个DataTable
        /// </summary>
        /// <param name="ProjectId">标识</param>
        /// <returns>返回DataTable</returns>
        public static DataTable Join_ProjectGet(int ProjectId)
        {
            return SqlDB.ExecuteDataset(strCon,CommandType.Text, "SELECT * FROM [Join_Project] WHERE ProjectId = " + ProjectId + ";").Tables[0];
        }

        /// <summary>
        /// 获取某一个实体
        /// </summary>
        /// <param name="ProjectId">标识</param>
        /// <returns>返回Entity</returns>
        public static Entity.Join_Project Join_ProjectEntityGet(int ProjectId)
        {
            Entity.Join_Project info = new Entity.Join_Project();
            DataTable dt = SqlDB.ExecuteDataset(strCon,CommandType.Text, "SELECT * FROM [Join_Project] WHERE ProjectId = " + ProjectId + ";").Tables[0];
            if (dt.Rows.Count > 0)
            {
                info.ProjectId = Basic.Utils.StrToInt(dt.Rows[0]["ProjectId"].ToString(), 0);
                info.ProjectName = dt.Rows[0]["ProjectName"].ToString();
                info.Content = dt.Rows[0]["Content"].ToString();
                info.TopPCid = Basic.Utils.StrToInt(dt.Rows[0]["TopPCid"].ToString(), 0);
                info.PCidList = dt.Rows[0]["PCidList"].ToString();
                info.PCid = Basic.Utils.StrToInt(dt.Rows[0]["PCid"].ToString(), 0);
                info.ApplicantFile = dt.Rows[0]["ApplicantFile"].ToString();
                info.IsValid = Basic.Utils.StrToInt(dt.Rows[0]["IsValid"].ToString(), 0);
                info.IsPause = Basic.Utils.StrToInt(dt.Rows[0]["IsPause"].ToString(), 0);
                info.IsCheck = Basic.Utils.StrToInt(dt.Rows[0]["IsCheck"].ToString(), 0);
                info.IsHot = Basic.Utils.StrToInt(dt.Rows[0]["IsHot"].ToString(), 0);
                info.AddTime = Basic.Utils.StrToDateTime(dt.Rows[0]["AddTime"].ToString());
            }
            return info;
        }

        /// <summary>
        /// 删除一个值
        /// </summary>
        /// <param name="ProjectId">自增id的值</param>
        /// <returns>删除成功返回ture，否则返回false</returns>
        public static bool Join_ProjectDel(int ProjectId)
        {
            int intReturnValue = 0;
            intReturnValue = SqlDB.ExecuteNonQuery(strCon,CommandType.Text, "DELETE [Join_Project]  WHERE ProjectId =  " + ProjectId);
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
        public static DataTable Join_ProjectTopGet(string strWhere, int TopNumber)
        {
            string strSql;
            if (!string.IsNullOrEmpty(strWhere.Trim()))
                strSql = "SELECT TOP " + TopNumber.ToString() + " * FROM [Join_Project] WHERE " + strWhere + ";";
            else
                strSql = "SELECT TOP " + TopNumber.ToString() + " * FROM [Join_Project] ;";
            return SqlDB.ExecuteDataset(strCon,CommandType.Text, strSql).Tables[0];
        }

        ///
        /// <summary>
        /// 获取前多少的值
        /// </summary>
        /// <param name="TopNumber">数量</param>
        /// <param name="PageSize">每页显示多少个</param>
        /// <param name="PageIndex">当前页码，最少为1</param>
        /// <returns>返回DataTable</returns>
        public static DataTable Join_ProjectPageList(string strWhere, int PageSize, int PageIndex)
        {
            StringBuilder sbSql = new StringBuilder();
            sbSql.Append("SELECT p.*,pc.ProjectCategoryName,pr.PPid FROM Join_Project as p left join Join_ProjectCategory as pc on p.PCid = pc.ProjectCategoryId left join Join_ProjectRelated as pr on p.ProjectId = pr.Pid WHERE pr.PPid > 0 and pr.IsValid = 1 ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                sbSql.Append(" AND " + strWhere);
            }
            sbSql.Append(" ORDER BY ProjectId DESC");
            DataSet ds = new DataSet();
            ds = SqlDB.ExecuteDataset((PageIndex - 1) * PageSize, PageSize, strCon,CommandType.Text, sbSql.ToString());
            if (ds.Tables.Count > 0)
            {
                return ds.Tables[0];
            }
            return new DataTable();
        }

        ///
        /// <summary>
        /// 获取前多少的值
        /// </summary>
        /// <param name="TopNumber">数量</param>
        /// <param name="PageSize">每页显示多少个</param>
        /// <param name="PageIndex">当前页码，最少为1</param>
        /// <returns>返回DataTable</returns>
        public static DataTable Join_ProjectPageListNew(string strWhere, int PageSize, int PageIndex)
        {
            StringBuilder sbSql = new StringBuilder();
            sbSql.Append("select p.*,pvr.ValueId,pvr.AttributeId from Join_Project as p left join Join_ProjectValRalition as pvr on p.ProjectId = pvr.ProjectId ");
            
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                sbSql.Append(" WHERE " + strWhere);
            }
            sbSql.Append(" ORDER BY p.ProjectId DESC");
            DataSet ds = new DataSet();
            ds = SqlDB.ExecuteDataset((PageIndex - 1) * PageSize, PageSize, strCon,CommandType.Text, sbSql.ToString());
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
        public static int Join_ProjectCountNew(string strWhere)
        {
            string strSql;
            if (!string.IsNullOrEmpty(strWhere.Trim()))
                strSql = "SELECT COUNT(*) FROM  Join_Project as p left join Join_ProjectValRalition as pvr on p.ProjectId =pvr.ProjectId WHERE " + strWhere + ";";
            else
                strSql = "SELECT COUNT(*)  FROM [Join_Project] ;";
            return Basic.Utils.StrToInt(SqlDB.ExecuteScalar(strCon,CommandType.Text, strSql).ToString(), 0);
        }

        /// <summary>
        /// 获取该条件下的总的数量
        /// </summary>
        /// <param name="strWhere">条件，可以为空</param>
        /// <returns>如果没有就返回0</returns>
        public static int Join_ProjectCount(string strWhere)
        {
            StringBuilder sbSql = new StringBuilder();
            sbSql.Append("SELECT count(*) FROM Join_Project as p left join Join_ProjectCategory as pc on p.PCid = pc.ProjectCategoryId left join Join_ProjectRelated as pr on p.ProjectId = pr.Pid WHERE pr.PPid > 0 and pr.IsValid = 1 ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                sbSql.Append(" AND " + strWhere);
            }
            return Basic.Utils.StrToInt(SqlDB.ExecuteScalar(strCon,CommandType.Text, sbSql.ToString()).ToString(), 0);
        }

        public static DataTable Join_ProjectPageListForFenPei(int Did, int PCid, int PageSize, int PageIndex)
        {
            String strSQL = "SELECT P.ProjectId,P.ProjectName,P.Content,PR.* FROM [Join_Project] AS P,[Join_ProjectRelated] AS PR WHERE P.ProjectId = PR.Pid AND PR.IsValid = 1 AND P.IsValid = 1 AND P.IsPause = 0 AND P.PCid = " + PCid;
            //strSQL = strSQL + " AND PR.Pid NOT IN (SELECT * FROM [Join_JiaMengDianProject] WHERE Did = "+ Did +")";
            strSQL = strSQL + "  ORDER BY PR.Pid DESC";
            DataSet ds = new DataSet();
            ds = SqlDB.ExecuteDataset((PageIndex - 1) * PageSize, PageSize, strCon,CommandType.Text, strSQL);
            if (ds.Tables.Count > 0)
            {
                return ds.Tables[0];
            }
            return new DataTable();
        }

        /// <summary>
        /// 加盟商所代理项目
        /// </summary>
        /// <param name="Did"></param>
        /// <param name="PCid"></param>
        /// <param name="PageSize"></param>
        /// <param name="PageIndex"></param>
        /// <returns></returns>
        public static DataTable Join_ProjectPageListForDaiLiFenPei(int Did, int PCid, int PageSize, int PageIndex)
        {
            String strSQL = "SELECT P.ProjectId,P.ProjectName,P.Content,PR.* FROM [Join_Project] AS P,[Join_ProjectRelated] AS PR,[Join_JiaMengDianProject] AS JMDP WHERE P.ProjectId = PR.Pid AND PR.IsValid = 1 AND P.IsValid = 1 AND P.IsPause = 0 AND P.PCid = " + PCid + "AND P.ProjectId = JMDP.Pid AND JMDP.Did = "+Did;
            //strSQL = strSQL + " AND PR.Pid NOT IN (SELECT * FROM [Join_JiaMengDianProject] WHERE Did = "+ Did +")";
            strSQL = strSQL + "  ORDER BY PR.Pid DESC";
            DataSet ds = new DataSet();
            ds = SqlDB.ExecuteDataset((PageIndex - 1) * PageSize, PageSize, strCon,CommandType.Text, strSQL);
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
        public static int Join_ProjectCountForFenPei(int Did, int PCid)
        {
            String strSQL = "SELECT count(*) FROM [Join_Project] AS P,[Join_ProjectRelated] AS PR WHERE P.ProjectId = PR.Pid AND PR.IsValid = 1 AND P.IsValid = 1 AND P.IsPause = 0 AND P.PCid = " + PCid;
            //strSQL = strSQL + " AND PR.Pid NOT IN (SELECT * FROM [Join_JiaMengDianProject] WHERE Did = " + Did + ")";
            //strSQL = strSQL + "  ORDER BY PR.Pid DESC";
            return Basic.Utils.StrToInt(SqlDB.ExecuteScalar(strCon,CommandType.Text, strSQL).ToString(), 0);
        }

        /// <summary>
        /// 获取该条件下的加盟商的总的数量
        /// </summary>
        /// <param name="strWhere">条件，可以为空</param>
        /// <returns>如果没有就返回0</returns>
        public static int Join_ProjectCountForDaiLiFenPei(int Did, int PCid)
        {
            String strSQL = "SELECT count(*) FROM [Join_Project] AS P,[Join_ProjectRelated] AS PR,[Join_JiaMengDianProject] AS JMDP WHERE P.ProjectId = PR.Pid AND PR.IsValid = 1 AND P.IsValid = 1 AND P.IsPause = 0 AND P.PCid = " + PCid + "AND P.ProjectId = JMDP.Pid AND JMDP.Did = " + Did;
            //strSQL = strSQL + " AND PR.Pid NOT IN (SELECT * FROM [Join_JiaMengDianProject] WHERE Did = " + Did + ")";
            //strSQL = strSQL + "  ORDER BY PR.Pid DESC";
            return Basic.Utils.StrToInt(SqlDB.ExecuteScalar(strCon,CommandType.Text, strSQL).ToString(), 0);
        }
        #endregion


        public static int Join_ProjectExSqlString(string sqlstring)
        {
            return SqlDB.ExecuteNonQuery(strCon,CommandType.Text, sqlstring);
        }

    }
}

