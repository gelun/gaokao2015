using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Basic;

namespace DAL.tengxb
{
    public class dingdan
    {
        /// <summary>
        /// 获取某一个实体
        /// </summary>
        /// <param name="Id">标识</param>
        /// <returns>返回Entity</returns>
        public static Entity.DingDan DingDanEntityGet(string strDingDanHao)
        {
            Entity.DingDan info = new Entity.DingDan();
            DataTable dt = SqlDB.ExecuteDataset(CommandType.Text, "SELECT * FROM [DingDan] WHERE DingDanHao = '" + strDingDanHao + "'").Tables[0];
            if (dt != null && dt.Rows.Count > 0)
            {
                info.Id = Basic.Utils.StrToInt(dt.Rows[0]["Id"].ToString(), 0);
                info.State = Basic.Utils.StrToInt(dt.Rows[0]["State"].ToString(), 0);
                info.DingDanHao = dt.Rows[0]["DingDanHao"].ToString();
                info.Subject = dt.Rows[0]["Subject"].ToString();
                info.Body = dt.Rows[0]["Body"].ToString();
                info.Count = Basic.Utils.StrToInt(dt.Rows[0]["Count"].ToString(), 0);
                info.DanJia = Basic.Utils.StrToDecimal(dt.Rows[0]["DanJia"].ToString(), 0);
                info.DingDanJinE = Basic.Utils.StrToDecimal(dt.Rows[0]["DingDanJinE"].ToString(), 0);
                info.CellName = dt.Rows[0]["CellName"].ToString();
                info.CellMobile = dt.Rows[0]["CellMobile"].ToString();
                info.AddTime = Basic.Utils.StrToDateTime(dt.Rows[0]["AddTime"].ToString());
                info.Memo = dt.Rows[0]["Memo"].ToString();
                info.Category = Basic.Utils.StrToInt(dt.Rows[0]["Category"].ToString(), 0);

                return info;
            }
            return null;
        }
    }
}
