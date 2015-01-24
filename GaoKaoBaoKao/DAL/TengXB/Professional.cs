using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Basic;

namespace DAL.TengXB
{
    public class Professional
    {
        /// <summary>
        /// 获取某一个实体
        /// </summary>
        /// <param name="Id">标识</param>
        /// <returns>返回Entity</returns>
        public static Entity.Professional ProfessionalEntityGet(int Id)
        {
            Entity.Professional info = new Entity.Professional();
            DataTable dt = SqlDB.ExecuteDataset(CommandType.Text, "select P3.* ,P2.ProfessionalName AS ZhaunYeLeiName,P1.ProfessionalName AS XueKeMenLeiName from Professional as P3,Professional as P2,Professional as P1 where P3.ParentId=P2.Id and P2.ParentId = P1.Id and P3.Id = " + Id + ";").Tables[0];
            if (dt.Rows.Count > 0)
            {
                info.Id = Basic.Utils.StrToInt(dt.Rows[0]["Id"].ToString(), 0);
                info.Code = dt.Rows[0]["Code"].ToString();
                info.ProfessionalName = dt.Rows[0]["ProfessionalName"].ToString();
                info.Remark = dt.Rows[0]["Remark"].ToString();
                info.ProfessionalGrade = Basic.Utils.StrToInt(dt.Rows[0]["ProfessionalGrade"].ToString(), 0);
                info.ParentId = Basic.Utils.StrToInt(dt.Rows[0]["ParentId"].ToString(), 0);
                info.ProfessionalIntro = dt.Rows[0]["ProfessionalIntro"].ToString();
                info.IsBen = Basic.Utils.StrToInt(dt.Rows[0]["IsBen"].ToString(), 0);
                info.ClickNum = Basic.Utils.StrToInt(dt.Rows[0]["ClickNum"].ToString(), 0);
                info.ZhaunYeLeiName = dt.Rows[0]["ZhaunYeLeiName"].ToString();
                info.XueKeMenLeiName = dt.Rows[0]["XueKeMenLeiName"].ToString();

                return info;
            }
            else
                return null;
        }


        /// <summary>
        /// 获取某一个DataTable
        /// </summary>
        /// <param name="Id">标识</param>
        /// <returns>返回DataTable</returns>
        public static DataTable ProfessionalListGet(string strProfessionalName)
        {
            string strSql = "SELECT P3.Id,P3.ProfessionalName,P3.Code,P3.IsBen,P2.ProfessionalName as ZhuanYeLeiName FROM [Professional] as P3, Professional as P2 WHERE P3.ParentId = P2.Id AND P3.ProfessionalGrade = 3 AND P2.ProfessionalGrade = 2 ";

            if (strProfessionalName != "")
            {
                strSql += " AND P3.ProfessionalName LIKE '%" + strProfessionalName + "%'";
            }
            return SqlDB.ExecuteDataset(CommandType.Text, strSql).Tables[0];
        }


        public static bool ProfessionalClickNum(Entity.Professional info)
        {
            int intReturnValue = 0;
            intReturnValue = SqlDB.ExecuteNonQuery(CommandType.Text, "UPDATE [Professional] SET ClickNum = " + info.ClickNum + "  WHERE Id =  " + info.Id);
            if (intReturnValue == 1)
                return true;
            return false;
        }

        
        public static DataTable TuiJian_ProfessionalList(string strWhere)
        {
            string strSql = "select ZY.Id ,ZY.ProfessionalName  from Professional as ZY,Professional as XKML,Professional as ZYDL where ZY.ParentId = ZYDL.Id and ZYDL.ParentId = XKML.Id ";

            if (!string.IsNullOrEmpty(strWhere))
            {
                strSql += " AND " + strWhere;
            }
            return SqlDB.ExecuteDataset(CommandType.Text, strSql).Tables[0];
        }
    }
}
