using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Basic;
using System.Configuration;

namespace DAL.tengxb
{
    public class zhenti
    {
        private static string strCon = ConfigurationManager.ConnectionStrings["ShiTi_ConnectionString"].ConnectionString;

        /// <summary>
        /// 题型_选择题
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public static int TiMuCount(string strWhere)
        {
            string strSql = "select COUNT(*) from TiMuSuoYin ,TiMuNeiRong ,edu_question_type where TiMuSuoYin.gid = TiMuNeiRong.gid and edu_question_type.id = TiMuSuoYin.edu_question_type_Id and len(ltrim(rtrim(TiMuNeiRong.objective_answer))) = 1 ";
            if (!string.IsNullOrEmpty(strWhere.Trim()))
                strSql += " AND " + strWhere;
            return Basic.Utils.StrToInt(SqlDB.ExecuteScalar(strCon, CommandType.Text, strSql).ToString(), 0);
        }
        /// <summary>
        /// 题型_选择题
        /// </summary>
        /// <param name="strFirstWhere"></param>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public static DataTable TiMuList(string strFirstWhere, string strWhere)
        {
            string strSql = "select * from (select ROW_NUMBER() OVER (order by TiMuNeiRong.id)as xuhao,TiMuSuoYin.*, TiMuNeiRong.content,TiMuNeiRong.objective_answer,TiMuNeiRong.answer from TiMuSuoYin ,TiMuNeiRong ,edu_question_type where TiMuSuoYin.gid = TiMuNeiRong.gid and edu_question_type.id = TiMuSuoYin.edu_question_type_Id and len(ltrim(rtrim(TiMuNeiRong.objective_answer))) = 1  ";
            if (!string.IsNullOrEmpty(strFirstWhere.Trim()))
                strSql += " AND " + strFirstWhere;
            strSql += ") as a ";
            if (!string.IsNullOrEmpty(strWhere.Trim()))
                strSql += " Where " + strWhere;
            return SqlDB.ExecuteDataset(strCon, CommandType.Text, strSql).Tables[0];
        }


        /// <summary>
        /// 题型_非选择题
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public static int fTiMuCount(string strWhere)
        {
            string strSql = "select COUNT(*) from TiMuSuoYin ,TiMuNeiRong ,edu_question_type where TiMuSuoYin.gid = TiMuNeiRong.gid and edu_question_type.id = TiMuSuoYin.edu_question_type_Id  and DataLength(TiMuNeiRong.content)>0 ";
            if (!string.IsNullOrEmpty(strWhere.Trim()))
                strSql += " AND " + strWhere;
            return Basic.Utils.StrToInt(SqlDB.ExecuteScalar(strCon, CommandType.Text, strSql).ToString(), 0);
        }
        /// <summary>
        /// 题型_非选择题
        /// </summary>
        /// <param name="strFirstWhere"></param>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public static DataTable fTiMuList(string strFirstWhere, string strWhere)
        {
            string strSql = "select * from (select ROW_NUMBER() OVER (order by TiMuNeiRong.id)as xuhao,TiMuSuoYin.*, TiMuNeiRong.content,TiMuNeiRong.objective_answer,TiMuNeiRong.answer from TiMuSuoYin ,TiMuNeiRong ,edu_question_type where TiMuSuoYin.gid = TiMuNeiRong.gid and edu_question_type.id = TiMuSuoYin.edu_question_type_Id and DataLength(TiMuNeiRong.content)>0 ";
            if (!string.IsNullOrEmpty(strFirstWhere.Trim()))
                strSql += " AND " + strFirstWhere;
            strSql += ") as a ";
            if (!string.IsNullOrEmpty(strWhere.Trim()))
                strSql += " Where " + strWhere;
            return SqlDB.ExecuteDataset(strCon, CommandType.Text, strSql).Tables[0];
        }

        /// <summary>
        /// 错题本 列表
        /// </summary>
        /// <param name="strWhere">条件，可以为空</param>
        /// <returns>返回DataTable</returns>
        public static DataTable CuoTiBenList(string strWhere)
        {
            string strSql;
            if (!string.IsNullOrEmpty(strWhere.Trim()))
                strSql = "SELECT TiMuNeiRong.*,cuotiben.Answer as cuotibenAnswer,cuotiben.Id as cuotibenId FROM [TiMuNeiRong],[cuotiben] WHERE TiMuNeiRong.id = cuotiben.TiMuId AND " + strWhere;
            else
                strSql = "SELECT TiMuNeiRong.*,cuotiben.Answer as cuotibenAnswer,cuotiben.Id as cuotibenId FROM [TiMuNeiRong],[cuotiben] WHERE TiMuNeiRong.id = cuotiben.TiMuId ";
            return SqlDB.ExecuteDataset(strCon, CommandType.Text, strSql).Tables[0];
        }

        /// <summary>
        /// 错题本 条数
        /// </summary>
        /// <param name="strWhere">条件，可以为空</param>
        /// <returns>返回DataTable</returns>
        public static int CuoTiBenCount(string strWhere)
        {
            string strSql;
            if (!string.IsNullOrEmpty(strWhere.Trim()))
                strSql = "SELECT count(*) FROM [TiMuNeiRong],[cuotiben] WHERE TiMuNeiRong.id = cuotiben.TiMuId AND " + strWhere;
            else
                strSql = "SELECT count(*) FROM [TiMuNeiRong],[cuotiben] WHERE TiMuNeiRong.id = cuotiben.TiMuId ";
            return Basic.Utils.StrToInt(SqlDB.ExecuteScalar(strCon, CommandType.Text, strSql).ToString(), 0);
        }

        /// <summary>
        /// 错题本 分页
        /// </summary>
        /// <param name="strWhere">条件，可以为空</param>
        /// <returns>返回DataTable</returns>
        public static DataTable CuoTiBenPageList(string strWhere, int PageSize, int PageIndex)
        {
            string strSql;
            if (!string.IsNullOrEmpty(strWhere.Trim()))
                strSql = "SELECT TiMuNeiRong.*,cuotiben.Answer as cuotibenAnswer,cuotiben.Id as cuotibenId FROM [TiMuNeiRong],[cuotiben] WHERE TiMuNeiRong.id = cuotiben.TiMuId AND " + strWhere;
            else
                strSql = "SELECT TiMuNeiRong.*,cuotiben.Answer as cuotibenAnswer,cuotiben.Id as cuotibenId FROM [TiMuNeiRong],[cuotiben] WHERE TiMuNeiRong.id = cuotiben.TiMuId ";

            strSql += " ORDER BY cuotibenId DESC";

            DataSet ds = new DataSet();
            ds = SqlDB.ExecuteDataset((PageIndex - 1) * PageSize, PageSize, strCon, CommandType.Text, strSql);
            if (ds.Tables.Count > 0)
            {
                return ds.Tables[0];
            }
            return new DataTable();
        }

        /// <summary>
        /// 知识点_选择题
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public static int zsdTiMuCount(string strWhere)
        {
            string strSql = "select COUNT(*) from TiMuSuoYin ,TiMuNeiRong ,edu_question_type,zhishidian,zhishidian2timusuoyin where TiMuSuoYin.gid = TiMuNeiRong.gid and edu_question_type.id = TiMuSuoYin.edu_question_type_Id and len(ltrim(rtrim(TiMuNeiRong.objective_answer))) = 1 and zhishidian2timusuoyin.ZhiShiDianId = zhishidian.Id and zhishidian2timusuoyin.TiMuSuoYinId = TiMuSuoYin.Id  ";
            if (!string.IsNullOrEmpty(strWhere.Trim()))
                strSql += " AND " + strWhere;
            return Basic.Utils.StrToInt(SqlDB.ExecuteScalar(strCon, CommandType.Text, strSql).ToString(), 0);
        }
        /// <summary>
        /// 知识点_选择题
        /// </summary>
        /// <param name="strFirstWhere"></param>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public static DataTable zsdTiMuList(string strFirstWhere, string strWhere)
        {
            string strSql = "select * from (select ROW_NUMBER() OVER (order by TiMuNeiRong.id)as xuhao,TiMuSuoYin.*, TiMuNeiRong.content,TiMuNeiRong.objective_answer,TiMuNeiRong.answer from TiMuSuoYin ,TiMuNeiRong ,edu_question_type,zhishidian,zhishidian2timusuoyin where TiMuSuoYin.gid = TiMuNeiRong.gid and edu_question_type.id = TiMuSuoYin.edu_question_type_Id and len(ltrim(rtrim(TiMuNeiRong.objective_answer))) = 1 and zhishidian2timusuoyin.ZhiShiDianId = zhishidian.Id and zhishidian2timusuoyin.TiMuSuoYinId = TiMuSuoYin.Id  ";
            if (!string.IsNullOrEmpty(strFirstWhere.Trim()))
                strSql += " AND " + strFirstWhere;
            strSql += ") as a ";
            if (!string.IsNullOrEmpty(strWhere.Trim()))
                strSql += " Where " + strWhere;
            return SqlDB.ExecuteDataset(strCon, CommandType.Text, strSql).Tables[0];
        }


        /// <summary>
        /// 试卷_选择题
        /// </summary>
        /// <param name="strFirstWhere"></param>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public static int sjTiMuCount(string strWhere)
        {
            string strSql = "select COUNT(*) from shijuan,ShiJuan2TiMu ,TiMuNeiRong where ShiJuan2TiMu.exam_id = shijuan.OldId and ShiJuan2TiMu.question_id = TiMuNeiRong.gid ";
            if (!string.IsNullOrEmpty(strWhere.Trim()))
                strSql += " AND " + strWhere;
            return Basic.Utils.StrToInt(SqlDB.ExecuteScalar(strCon, CommandType.Text, strSql).ToString(), 0);
        }
        /// <summary>
        /// 试卷_选择题
        /// </summary>
        /// <param name="strFirstWhere"></param>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public static DataTable sjTiMuList( string strWhere)
        {
            string strSql = "select shijuan.*,TiMuNeiRong.content as WenTi,TiMuNeiRong.answer,TiMuNeiRong.gid,TiMuNeiRong.objective_answer,TiMuNeiRong.Id as Id2  from shijuan,ShiJuan2TiMu ,TiMuNeiRong where ShiJuan2TiMu.exam_id = shijuan.OldId and ShiJuan2TiMu.question_id = TiMuNeiRong.gid ";
            if (!string.IsNullOrEmpty(strWhere.Trim()))
                strSql += " AND " + strWhere;
            return SqlDB.ExecuteDataset(strCon, CommandType.Text, strSql).Tables[0];
        }
    }
}
