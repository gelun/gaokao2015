using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Basic;

namespace DAL.TengXB
{
    public class ProfessionalArticle
    {

        public static Entity.ProfessionalArticle ProfessionalArticleEntityGetByProfessionalId(int intProfessionalId)
        {
            Entity.ProfessionalArticle info = new Entity.ProfessionalArticle();
            DataTable dt = SqlDB.ExecuteDataset(CommandType.Text, "SELECT Top 1 * FROM [ProfessionalArticle] WHERE ProfessionalId = " + intProfessionalId + " ORDER BY Id DESC").Tables[0];
            if (dt.Rows.Count > 0)
            {
                info.Id = Basic.Utils.StrToInt(dt.Rows[0]["Id"].ToString(), 0);
                info.ProfessionalId = Basic.Utils.StrToInt(dt.Rows[0]["ProfessionalId"].ToString(), 0);
                info.CategoryId = Basic.Utils.StrToInt(dt.Rows[0]["CategoryId"].ToString(), 0);
                info.Icon = dt.Rows[0]["Icon"].ToString();
                info.Title = dt.Rows[0]["Title"].ToString();
                info.ShortTitle = dt.Rows[0]["ShortTitle"].ToString();
                info.MetaTitle = dt.Rows[0]["MetaTitle"].ToString();
                info.MetaKeyWords = dt.Rows[0]["MetaKeyWords"].ToString();
                info.MetaDescription = dt.Rows[0]["MetaDescription"].ToString();
                info.Summary = dt.Rows[0]["Summary"].ToString();
                info.Content = dt.Rows[0]["Content"].ToString();
                info.IsPause = Basic.Utils.StrToInt(dt.Rows[0]["IsPause"].ToString(), 0);
                info.IsTuiJian = Basic.Utils.StrToInt(dt.Rows[0]["IsTuiJian"].ToString(), 0);
                info.IsNew = Basic.Utils.StrToInt(dt.Rows[0]["IsNew"].ToString(), 0);
                info.IsZhiDing = Basic.Utils.StrToInt(dt.Rows[0]["IsZhiDing"].ToString(), 0);
                info.AddWid = Basic.Utils.StrToInt(dt.Rows[0]["AddWid"].ToString(), 0);
                info.IsCheck = Basic.Utils.StrToInt(dt.Rows[0]["IsCheck"].ToString(), 0);
                info.CheckWid = Basic.Utils.StrToInt(dt.Rows[0]["CheckWid"].ToString(), 0);
                info.ClickNum = Basic.Utils.StrToInt(dt.Rows[0]["ClickNum"].ToString(), 0);
                info.AddTime = Basic.Utils.StrToDateTime(dt.Rows[0]["AddTime"].ToString());
                info.CheckTime = Basic.Utils.StrToDateTime(dt.Rows[0]["CheckTime"].ToString());
                info.PublishTime = Basic.Utils.StrToDateTime(dt.Rows[0]["PublishTime"].ToString());
                info.ZhiDingTime = Basic.Utils.StrToDateTime(dt.Rows[0]["ZhiDingTime"].ToString());
                return info;
            }
            else
                return null;
        }

        public static DataTable ProfessionalAndArticleList(string strWhere)
        {
            string strSql = "SELECT Article.Id,Article.Title,Article.Summary,Article.Content FROM Article , ProfessionalArticle WHERE Article.Id = ProfessionalArticle.ArticleId ";
            if (!string.IsNullOrEmpty(strWhere.Trim()))
                strSql += " AND" + strWhere;
            return SqlDB.ExecuteDataset(CommandType.Text, strSql).Tables[0];
        }
    }
}
