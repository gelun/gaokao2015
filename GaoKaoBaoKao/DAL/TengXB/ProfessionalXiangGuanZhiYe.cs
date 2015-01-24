using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Basic;

namespace DAL.TengXB
{
   public class ProfessionalXiangGuanZhiYe
    {
       public static DataTable YiJiZhiYeZhuanYeList(int intProfessionalId)
       {
           string strSql = " select Id,ZhiYeName from ZhiYe where ZhiYeLevel = 1 and Id in ( select YiJiZhiYe.Id from ZhiYe as YiJiZhiYe,ZhiYe as ErJiZhiYe,ZhiYe,ZhiYeZhuanYe where ZhiYe.Id = ZhiYeZhuanYe.ZhiYeId and ZhiYe.ZhiYeLevel = 3 and ZhiYe.ParentId = ErJiZhiYe.Id and ErJiZhiYe.ZhiYeLevel = 2 and YiJiZhiYe.Id = ErJiZhiYe.ParentId and YiJiZhiYe.ZhiYeLevel = 1 ";
           if (intProfessionalId>0)
               strSql += " and ZhiYeZhuanYe.professionalId = " + intProfessionalId;
           strSql += " group by YiJiZhiYe.Id ) ";
           return SqlDB.ExecuteDataset(CommandType.Text, strSql).Tables[0];
       }

       public static DataTable ErJiZhiYeZhuanYeList(int intYiJiZhiYeId,int intProfessionalId)
       {
           string strSql = " select Id,ZhiYeName from ZhiYe where ZhiYeLevel = 2 and ParentId = " + intYiJiZhiYeId + " and Id in ( select ErJiZhiYe.Id from ZhiYe as YiJiZhiYe,ZhiYe as ErJiZhiYe,ZhiYe,ZhiYeZhuanYe where ZhiYe.Id = ZhiYeZhuanYe.ZhiYeId and ZhiYe.ZhiYeLevel = 3 and ZhiYe.ParentId = ErJiZhiYe.Id and ErJiZhiYe.ZhiYeLevel = 2 and YiJiZhiYe.Id = ErJiZhiYe.ParentId and YiJiZhiYe.ZhiYeLevel = 1 ";
           if (intProfessionalId > 0)
               strSql += " and ZhiYeZhuanYe.professionalId = " + intProfessionalId;
           strSql += " group by ErJiZhiYe.Id ) ";
           return SqlDB.ExecuteDataset(CommandType.Text, strSql).Tables[0];
       }


       public static DataTable ZhiYeZhuanYeList(int intErJiZhiYeId, int intProfessionalId)
       {
           string strSql = " select Id,ZhiYeName from ZhiYe where ZhiYeLevel = 3 and ParentId = " + intErJiZhiYeId + " and Id in ( select ZhiYe.Id from ZhiYe as YiJiZhiYe,ZhiYe as ErJiZhiYe,ZhiYe,ZhiYeZhuanYe where ZhiYe.Id = ZhiYeZhuanYe.ZhiYeId and ZhiYe.ZhiYeLevel = 3 and ZhiYe.ParentId = ErJiZhiYe.Id and ErJiZhiYe.ZhiYeLevel = 2 and YiJiZhiYe.Id = ErJiZhiYe.ParentId and YiJiZhiYe.ZhiYeLevel = 1 ";
           if (intProfessionalId > 0)
               strSql += " and ZhiYeZhuanYe.professionalId = " + intProfessionalId;
           strSql += " group by ZhiYe.Id ) ";
           return SqlDB.ExecuteDataset(CommandType.Text, strSql).Tables[0];
       }
    }
}
