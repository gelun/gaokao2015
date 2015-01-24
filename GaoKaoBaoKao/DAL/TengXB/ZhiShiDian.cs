using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Basic;
using System.Configuration;

namespace DAL.TengXB
{
    public class ZhiShiDian
    {
        private static string strCon = ConfigurationManager.ConnectionStrings["ShiTi_ConnectionString"].ConnectionString;

        public static DataTable ZhiShiDianList(string TablePre)
        {
            string strSql = "select zhishidian.Id, zhishidian.name from zhishidian "
                + "left join [GaoKaoBaoKao].[dbo].ZhiShiDianRelation as zsdr "
                + "on zhishidian.Id = zsdr.ZhenTiZSDId and zsdr.KMZSDId > 0 "
                + "left join " + TablePre + "_exam_question_index as kc "
                + " on zhishidian.name = kc.zh_knowledge and zhishidian.subject_id = kc.subject_id "
                + " left join " + TablePre + "_exam_question as kcq on kc.gid = kcq.gid "
                + " where (question_type = '选择题' or question_type = '单项填空') and LEN(objective_answer) = 1 "
                + " group by zhishidian.Id, zhishidian.name";
            DataSet ds = new DataSet();
            ds = SqlDB.ExecuteDataset(strCon, CommandType.Text, strSql);
            if (ds.Tables.Count > 0)
            {
                return ds.Tables[0];
            }
            return new DataTable();
        }


        public static DataTable ShiTiList(string TablePre, int ZhiShiDianId)
        {
            string strSql = "select * from (select ROW_NUMBER() over(order by kcq.gid asc) as row,kc.difficulty,kc.score,kcq.* from zhishidian left join " + TablePre + "_exam_question_index as kc "
                + " on zhishidian.name = kc.zh_knowledge and zhishidian.subject_id = kc.subject_id "
                + " left join " + TablePre + "_exam_question as kcq on kc.gid = kcq.gid "
                + " where (question_type = '选择题' or question_type = '单项填空') and LEN(objective_answer) = 1 "
                + " and zhishidian.Id = " + ZhiShiDianId
                + " ) as newtable";
            DataSet ds = new DataSet();
            ds = SqlDB.ExecuteDataset(strCon, CommandType.Text, strSql);
            if (ds.Tables.Count > 0)
            {
                return ds.Tables[0];
            }
            return new DataTable();
        }

        public static DataTable GetZhiShiDianList(string strIdList)
        {
            string strSql = "select Id, name from zhishidian "
                + " where Id in (" + strIdList + ")";
            DataSet ds = new DataSet();
            ds = SqlDB.ExecuteDataset(strCon, CommandType.Text, strSql);
            if (ds.Tables.Count > 0)
            {
                return ds.Tables[0];
            }
            return new DataTable();
        }

        public static DataTable ShiTiShowList(string TablePre, string strGidList)
        {
            string strSql = "select zhishidian.Id as zsdId, kc.difficulty,kc.score,kcq.*,TiMuNeiRong.Id "
                          + "from zhishidian left join " + TablePre + "_exam_question_index as kc "
                          + "on zhishidian.name = kc.zh_knowledge and zhishidian.subject_id = kc.subject_id "
                          + "left join " + TablePre + "_exam_question as kcq on kc.gid = kcq.gid "
                          + "left join TiMuNeiRong on kcq.gid = TiMuNeiRong.gid "
                          + "where (question_type = '选择题' or question_type = '单项填空') and LEN(kcq.objective_answer) = 1 and kcq.gid in (" + strGidList + ")";
            DataSet ds = new DataSet();
            ds = SqlDB.ExecuteDataset(strCon, CommandType.Text, strSql);
            if (ds.Tables.Count > 0)
            {
                return ds.Tables[0];
            }
            return new DataTable();
        }


        public static DataTable ZhiShiDianRelationList(string strWhere)
        {
            string strSql = "SELECT KM.Id,KM.Title FROM [ZhiShiDianRelation] as t1,KM WHERE t1.KMZSDId = KM.Id ";
            if (!string.IsNullOrEmpty(strWhere.Trim()))
                strSql += " and " + strWhere;
            return SqlDB.ExecuteDataset(CommandType.Text, strSql).Tables[0];
        }


        public static Entity.zhishidian zhishidianEntityGet(int Id)
        {
            Entity.zhishidian info = new Entity.zhishidian();
            DataTable dt = SqlDB.ExecuteDataset(strCon, CommandType.Text, "SELECT * FROM [zhishidian] WHERE Id = " + Id + ";").Tables[0];
            if (dt.Rows.Count > 0)
            {
                info.Id = Basic.Utils.StrToInt(dt.Rows[0]["Id"].ToString(), 0);
                info.name = dt.Rows[0]["name"].ToString();
                info.subject_id = Basic.Utils.StrToInt(dt.Rows[0]["subject_id"].ToString(), 0);
                return info;
            }
            return null;
        }

        public static int JiChuGongGuCount(string TablePre, int ZhiShiDianId)
        {
            string strSql = "select count(1) from zhishidian left join " + TablePre + "_exam_question_index as kc "
                + " on zhishidian.name = kc.zh_knowledge and zhishidian.subject_id = kc.subject_id "
                + " left join " + TablePre + "_exam_question as kcq on kc.gid = kcq.gid "
                + " where zhishidian.Id = " + ZhiShiDianId;
            return Basic.Utils.StrToInt(SqlDB.ExecuteScalar(strCon, CommandType.Text, strSql).ToString(), 0);
        }

        public static DataTable JiChuGongGuList(string TablePre, int ZhiShiDianId, int PageSize, int PageIndex)
        {
            string strSql = "select * from (select ROW_NUMBER() over(order by kcq.gid asc) as row,kc.difficulty,kc.score,kcq.* from zhishidian left join " + TablePre + "_exam_question_index as kc "
                + " on zhishidian.name = kc.zh_knowledge and zhishidian.subject_id = kc.subject_id "
                + " left join " + TablePre + "_exam_question as kcq on kc.gid = kcq.gid "
                + " where zhishidian.Id = " + ZhiShiDianId
                + " ) as newtable";
            DataSet ds = new DataSet();
            ds = SqlDB.ExecuteDataset((PageIndex - 1) * PageSize, PageSize, strCon, CommandType.Text, strSql);
            if (ds.Tables.Count > 0)
            {
                return ds.Tables[0];
            }
            return new DataTable();
        }
    }
}
