using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;

using Basic;
using Entity;

namespace DAL
{
    public class StudentGaoKaoHistory_ZheJiang
    {
        #region  StudentGaoKaoHistory_ZheJiang
        /// <summary>
        /// 调用存储过程增加一个
        /// </summary>
        /// <param name="info">实体对象</param>
        /// <returns>正常返回大于 0 的自增id, 0代表重复，否则返回-1</returns>
        public static int StudentGaoKaoHistory_ZheJiangAdd(Entity.StudentGaoKaoHistory_ZheJiang info)
        {
            SqlParameter[] prams = {
				SqlDB.MakeInParam("@StudentId", SqlDbType.Int, 4, info.StudentId),
				SqlDB.MakeInParam("@YuWen", SqlDbType.Int, 4, info.YuWen),
				SqlDB.MakeInParam("@ShuXue", SqlDbType.Int, 4, info.ShuXue),
				SqlDB.MakeInParam("@YingYu", SqlDbType.Int, 4, info.YingYu),
				SqlDB.MakeInParam("@ZongHe", SqlDbType.Int, 4, info.ZongHe),
				SqlDB.MakeInParam("@ZiXuan", SqlDbType.Int, 4, info.ZiXuan),
				SqlDB.MakeInParam("@JiShu", SqlDbType.Int, 4, info.JiShu),
				SqlDB.MakeInParam("@ZongFen1", SqlDbType.Int, 4, info.ZongFen1),
				SqlDB.MakeInParam("@ZongFen2", SqlDbType.Int, 4, info.ZongFen2),
				SqlDB.MakeInParam("@ZongFen3", SqlDbType.Int, 4, info.ZongFen3),
				SqlDB.MakeInParam("@IsGaoKao", SqlDbType.Int, 4, info.IsGaoKao),
				SqlDB.MakeInParam("@IsLatest", SqlDbType.Int, 4, info.IsLatest),
				SqlDB.MakeInParam("@AddTime", SqlDbType.DateTime, 8, info.AddTime),
			};
            return Basic.Utils.StrToInt(SqlDB.ExecuteScalar(CommandType.StoredProcedure, "StudentGaoKaoHistory_ZheJiangAdd", prams).ToString(), -1);
        }

        /// <summary>
        /// 调用存储过程修改一个
        /// </summary>
        /// <param name="info">实体对象</param>
        /// <returns>更新成功返回ture，否则返回false</returns>
        public static bool StudentGaoKaoHistory_ZheJiangEdit(Entity.StudentGaoKaoHistory_ZheJiang info)
        {
            SqlParameter[] prams = {
				SqlDB.MakeInParam("@Id", SqlDbType.Int, 4, info.Id),
				SqlDB.MakeInParam("@StudentId", SqlDbType.Int, 4, info.StudentId),
				SqlDB.MakeInParam("@YuWen", SqlDbType.Int, 4, info.YuWen),
				SqlDB.MakeInParam("@ShuXue", SqlDbType.Int, 4, info.ShuXue),
				SqlDB.MakeInParam("@YingYu", SqlDbType.Int, 4, info.YingYu),
				SqlDB.MakeInParam("@ZongHe", SqlDbType.Int, 4, info.ZongHe),
				SqlDB.MakeInParam("@ZiXuan", SqlDbType.Int, 4, info.ZiXuan),
				SqlDB.MakeInParam("@JiShu", SqlDbType.Int, 4, info.JiShu),
				SqlDB.MakeInParam("@ZongFen1", SqlDbType.Int, 4, info.ZongFen1),
				SqlDB.MakeInParam("@ZongFen2", SqlDbType.Int, 4, info.ZongFen2),
				SqlDB.MakeInParam("@ZongFen3", SqlDbType.Int, 4, info.ZongFen3),
				SqlDB.MakeInParam("@IsGaoKao", SqlDbType.Int, 4, info.IsGaoKao),
				SqlDB.MakeInParam("@IsLatest", SqlDbType.Int, 4, info.IsLatest),
				SqlDB.MakeInParam("@AddTime", SqlDbType.DateTime, 8, info.AddTime),
				};
            int intReturnValue = 0;
            intReturnValue = SqlDB.ExecuteNonQuery(CommandType.StoredProcedure, "StudentGaoKaoHistory_ZheJiangEdit", prams);
            if (intReturnValue == 1)
                return true;
            return false;
        }

        /// <summary>
        /// 获取所有的的值
        /// </summary>
        /// <param name="strWhere">条件，可以为空</param>
        /// <returns>返回DataTable</returns>
        public static DataTable StudentGaoKaoHistory_ZheJiangList(string strWhere)
        {
            string strSql;
            if (!string.IsNullOrEmpty(strWhere.Trim()))
                strSql = "SELECT * FROM [StudentGaoKaoHistory_ZheJiang] WHERE " + strWhere + ";";
            else
                strSql = "SELECT * FROM [StudentGaoKaoHistory_ZheJiang] ;";
            return SqlDB.ExecuteDataset(CommandType.Text, strSql).Tables[0];
        }


        /// <summary>
        /// 获取某一个DataTable
        /// </summary>
        /// <param name="Id">标识</param>
        /// <returns>返回DataTable</returns>
        public static DataTable StudentGaoKaoHistory_ZheJiangGet(int Id)
        {
            return SqlDB.ExecuteDataset(CommandType.Text, "SELECT * FROM [StudentGaoKaoHistory_ZheJiang] WHERE Id = " + Id + ";").Tables[0];
        }

        /// <summary>
        /// 获取某一个实体
        /// </summary>
        /// <param name="Id">标识</param>
        /// <returns>返回Entity</returns>
        public static Entity.StudentGaoKaoHistory_ZheJiang StudentGaoKaoHistory_ZheJiangEntityGetByStudentId(int StudentId)
        {
            Entity.StudentGaoKaoHistory_ZheJiang info = new Entity.StudentGaoKaoHistory_ZheJiang();
            DataTable dt = SqlDB.ExecuteDataset(CommandType.Text, "SELECT top 1 * FROM [StudentGaoKaoHistory_ZheJiang] WHERE StudentId = " + StudentId + " and IsLatest = 1 order by Id desc").Tables[0];
            if (dt.Rows.Count > 0)
            {
                info.Id = Basic.Utils.StrToInt(dt.Rows[0]["Id"].ToString(), 0);
                info.StudentId = Basic.Utils.StrToInt(dt.Rows[0]["StudentId"].ToString(), 0);
                info.YuWen = Basic.Utils.StrToInt(dt.Rows[0]["YuWen"].ToString(), 0);
                info.ShuXue = Basic.Utils.StrToInt(dt.Rows[0]["ShuXue"].ToString(), 0);
                info.YingYu = Basic.Utils.StrToInt(dt.Rows[0]["YingYu"].ToString(), 0);
                info.ZongHe = Basic.Utils.StrToInt(dt.Rows[0]["ZongHe"].ToString(), 0);
                info.ZiXuan = Basic.Utils.StrToInt(dt.Rows[0]["ZiXuan"].ToString(), 0);
                info.JiShu = Basic.Utils.StrToInt(dt.Rows[0]["JiShu"].ToString(), 0);
                info.ZongFen1 = Basic.Utils.StrToInt(dt.Rows[0]["ZongFen1"].ToString(), 0);
                info.ZongFen2 = Basic.Utils.StrToInt(dt.Rows[0]["ZongFen2"].ToString(), 0);
                info.ZongFen3 = Basic.Utils.StrToInt(dt.Rows[0]["ZongFen3"].ToString(), 0);
                info.IsGaoKao = Basic.Utils.StrToInt(dt.Rows[0]["IsGaoKao"].ToString(), 0);
                info.IsLatest = Basic.Utils.StrToInt(dt.Rows[0]["IsLatest"].ToString(), 0);

                info.AddTime = Basic.Utils.StrToDateTime(dt.Rows[0]["AddTime"].ToString());

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
        public static bool StudentGaoKaoHistory_ZheJiangDel(int Id)
        {
            int intReturnValue = 0;
            intReturnValue = SqlDB.ExecuteNonQuery(CommandType.Text, "DELETE [StudentGaoKaoHistory_ZheJiang]  WHERE Id =  " + Id);
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
        public static DataTable StudentGaoKaoHistory_ZheJiangTopGet(string strWhere, int TopNumber)
        {
            string strSql;
            if (!string.IsNullOrEmpty(strWhere.Trim()))
                strSql = "SELECT TOP " + TopNumber.ToString() + " * FROM [StudentGaoKaoHistory_ZheJiang] WHERE " + strWhere + ";";
            else
                strSql = "SELECT TOP " + TopNumber.ToString() + " * FROM [StudentGaoKaoHistory_ZheJiang] ;";
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
        public static DataTable StudentGaoKaoHistory_ZheJiangPageList(string strWhere, int PageSize, int PageIndex)
        {
            StringBuilder sbSql = new StringBuilder();
            sbSql.Append("SELECT * FROM StudentGaoKaoHistory_ZheJiang");
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
        public static int StudentGaoKaoHistory_ZheJiangCount(string strWhere)
        {
            string strSql;
            if (!string.IsNullOrEmpty(strWhere.Trim()))
                strSql = "SELECT COUNT(*) FROM [StudentGaoKaoHistory_ZheJiang] WHERE " + strWhere + ";";
            else
                strSql = "SELECT COUNT(*)  FROM [StudentGaoKaoHistory_ZheJiang] ;";
            return Basic.Utils.StrToInt(SqlDB.ExecuteScalar(CommandType.Text, strSql).ToString(), 0);
        }
        #endregion

    }
}

