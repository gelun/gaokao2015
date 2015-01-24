using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;

using Basic;
using Entity;

namespace DAL
{
    public class CommonTuiJian
    {
        public static DataTable FenShengYuanXiaoLuQuList(string strWhere, int StudentProvinceId, int StudentId, int StudentKeLei, int StudentPiCi, int StudentPcLeiBie, int XianCha, int StudentFirstLevel, int StudentSecondLevel)
        {

            Entity.StudentGaoKaoHistory studentHistory = DAL.StudentGaoKaoHistory.StudentGaoKaoHistoryEntityGet(StudentId);
            string strSql;
            string strSqlColum = "";
            string strSqlTable = " WHERE FSYXLQ.SchoolId = S.Id ";

            //江苏的推荐算法，因为有科类等级的区分，所以需要特殊处理
            if (StudentProvinceId == 10)
            {
                strSqlTable = " WHERE FSYXLQ.SchoolId = S.Id AND ((fsyxlq.FirstAsk =0 AND fsyxlq.SecondAsk = 0) OR (fsyxlq.IsAsk = 1 AND fsyxlq.FirstAsk >=" + StudentFirstLevel + " AND  fsyxlq.SecondAsk >=" + StudentSecondLevel + ") OR (fsyxlq.IsAsk = 0 AND fsyxlq.FirstAsk >=" + StudentFirstLevel + " AND  fsyxlq.SecondAsk >=" + StudentSecondLevel + ") OR (fsyxlq.IsAsk = 0 AND fsyxlq.SecondAsk >=" + StudentFirstLevel + " AND  fsyxlq.FirstAsk >=" + StudentSecondLevel + ") )";
            }
            if (!string.IsNullOrEmpty(strWhere.Trim()))
                strSql = "SELECT TOP 80 FSYXLQ.*,S.*,S.Id as SchoolId,FSYXLQ.YuanXiaoDaiMa as SchoolCode " + strSqlColum + " FROM [" + DAL.Common.GetProvinceTableName(StudentProvinceId, "FenShengYuanXiaoLuQu") + "] AS FSYXLQ,[School] AS S " + strSqlTable + " AND " + strWhere;
            else
                strSql = "SELECT TOP 80 FSYXLQ.*,S.*,S.Id as SchoolId,FSYXLQ.YuanXiaoDaiMa as SchoolCode " + strSqlColum + " FROM [" + DAL.Common.GetProvinceTableName(StudentProvinceId, "FenShengYuanXiaoLuQu") + "] AS FSYXLQ,[School] AS S " + strSqlTable + "";
            //这个是有问题的，不过目的是先出来结果
            strSql = strSql + " AND FSYXLQ.ProvinceId = " + StudentProvinceId + " AND FSYXLQ.KeLei = " + StudentKeLei + " AND FSYXLQ.PiCi = " + StudentPiCi + " AND FSYXLQ.PcLeiBie = " + StudentPcLeiBie;

            if (XianCha > 0)
                strSql = strSql + " order by abs(" + XianCha + " - FSYXLQ.glPingJunXianCha) asc";
            else
                strSql = strSql + " order by FSYXLQ.glPingJunXianCha asc";

            strSql = strSql + "";
            
            return SqlDB.ExecuteDataset(CommandType.Text, strSql).Tables[0];
        }

        /// <summary>
        /// 通过最新一年的分数线，判断出对应分数进入的批次和线差等信息
        /// </summary>
        /// <param name="fenshuxian"></param>
        /// <param name="FenShu"></param>
        /// <returns></returns>
        public static Entity.StudentChengJi GetUserPiCi(Entity.FenShuXian fenshuxian, int FenShu, int DataYear, int ProvinceId, int KeLei)
        {
            Entity.StudentChengJi studentChengJi = new Entity.StudentChengJi();
            int PcFirst = fenshuxian.PcFirst;
            int PcSecond = fenshuxian.PcSecond;
            int PcThird = fenshuxian.PcThird;
            int ZkFirst = fenshuxian.ZkFirst;
            int ZkSecond = fenshuxian.ZkSecond;

            if (FenShu >= PcFirst)
            {
                studentChengJi.PiCi = 1;
                studentChengJi.XianChaShang = 0;//上一批次的线差
                studentChengJi.XianCha = FenShu - PcFirst;//批次线差
                studentChengJi.PiCiXian = PcFirst;
            }
            else if (FenShu >= PcSecond)
            {
                studentChengJi.PiCi = 2;
                studentChengJi.XianChaShang = PcFirst - FenShu;//上一批次的线差
                studentChengJi.XianCha = FenShu - PcSecond;//批次线差
                studentChengJi.PiCiXian = PcSecond;
            }
            else if (PcThird != 0 && FenShu >= PcThird)
            {
                studentChengJi.PiCi = 3;
                studentChengJi.XianChaShang = PcSecond - FenShu;//上一批次的线差
                studentChengJi.XianCha = FenShu - PcThird;//批次线差
                studentChengJi.PiCiXian = PcThird;
            }
            else if (ZkFirst != 0 && FenShu >= ZkFirst)
            {
                studentChengJi.PiCi = 4;
                studentChengJi.XianChaShang = (PcThird == 0 ? PcSecond : PcThird) - FenShu;//上一批次的线差
                studentChengJi.XianCha = FenShu - ZkFirst;//批次线差
                studentChengJi.PiCiXian = ZkFirst;
            }
            else if (ZkSecond != 0 && FenShu >= ZkSecond)
            {
                studentChengJi.PiCi = 5;
                studentChengJi.XianChaShang = ZkFirst - FenShu;//上一批次的线差
                studentChengJi.XianCha = FenShu - ZkSecond;//批次线差
                studentChengJi.PiCiXian = ZkSecond;
            }
            else
            {
                studentChengJi.PiCi = 0;
                studentChengJi.XianChaShang = 0;//上一批次的线差
                studentChengJi.XianCha = 0;//批次线差
                studentChengJi.PiCiXian = 0;
            }

            //下面根据成绩来取位次等信息
            Entity.ProvinceWeiCi provinceWeiCi = DAL.ProvinceWeiCi.ProvinceWeiCiEntityGetByFenShu(FenShu, DataYear, ProvinceId, KeLei);
            if (provinceWeiCi == null)
            {
                studentChengJi.WeiCi = 0;
                studentChengJi.RenShu = 0;
                studentChengJi.LeiJiRenShu = 0;
            }
            else
            {
                studentChengJi.WeiCi = provinceWeiCi.WeiCi;
                studentChengJi.RenShu = provinceWeiCi.RenShu;
                studentChengJi.LeiJiRenShu = provinceWeiCi.LeiJiRenShu;
            }
            studentChengJi.FenShu = FenShu;

            return studentChengJi;
        }

        public static int GetUserPiCiXianCha(Entity.FenShuXian fenshuxian, int FenShu, int PiCi)
        {
            int PcFirst = fenshuxian.PcFirst;
            int PcSecond = fenshuxian.PcSecond;
            int PcThird = fenshuxian.PcThird;
            int ZkFirst = fenshuxian.ZkFirst;
            int ZkSecond = fenshuxian.ZkSecond;

            int XianCha = 0;
            if (PiCi == 1)
            {
                XianCha = FenShu - PcFirst;//批次线差
            }
            else if (PiCi == 2)
            {
                XianCha = FenShu - PcSecond;//批次线差
            }
            else if (PiCi == 3)
            {
                XianCha = FenShu - PcThird;//批次线差
            }
            else if (PiCi == 4)
            {
                XianCha = FenShu - ZkFirst;//批次的线差
            }
            else if (PiCi == 5)
            {
                XianCha = FenShu - ZkSecond;//批次线差
            }
            else
            {
                XianCha = 0;//批次线差
            }

            return XianCha;
        }

        #region 原有的智能推荐算法
        public static int ShowSuggest(int StudentProvinceId, int CurrentPiCi, int FirstPiCiWeiCi, int UserWeiCi, int ZuiXiaoWeiCi, int ZuiDaWeiCi, int PingJunWeiCi, int UserXianCha, int PiCiXian, int ZuiGaoFen, int ZuiDiFen, int PingJunFen)
        {
            //江苏省特殊处理
            if (StudentProvinceId == 10)
                return ShowSuggest_JiangSu(UserXianCha, PiCiXian, ZuiGaoFen, ZuiDiFen, PingJunFen);
            else if(StudentProvinceId == 11) //浙江省的特殊处理
                return ShowSuggest_PingJunFen(UserXianCha, PiCiXian, PingJunFen);

            int intFlag = 0;
            int FenGeWeiCi = FirstPiCiWeiCi * 2 / 3;
            if (CurrentPiCi == 1 && UserWeiCi < FenGeWeiCi)
            {
                intFlag = ShowSuggest_WeiCi(UserWeiCi, ZuiXiaoWeiCi, ZuiDaWeiCi, PingJunWeiCi);
            }
            else
            {
                intFlag = ShowSuggest_XianCha(UserXianCha, PiCiXian, ZuiGaoFen, ZuiDiFen, PingJunFen);
            }
            return intFlag;

        }

        // 1有风险，2冲一冲，3稳一稳，4保一保，5垫一垫

        //基于完整数据的位次算法
        private static int ShowSuggest_WeiCi(int UserWeiCi, int ZuiXiaoWeiCi, int ZuiDaWeiCi, int PingJunWeiCi)
        {
            //最大最小位次之间的差值
            int WeiCiCha = ZuiDaWeiCi - ZuiXiaoWeiCi;
            //位次差值的三份
            int FenGe = WeiCiCha * 3 / 8;
            int FenGeWeiCiXiao = ZuiXiaoWeiCi + FenGe;
            int FenGeWeiCiDa = ZuiDaWeiCi - FenGe;

            // 1有风险，2冲一冲，3稳一稳，4保一保，5垫一垫
            if (UserWeiCi <= FenGeWeiCiDa && UserWeiCi >= FenGeWeiCiXiao)
            {
                return 3;
            }
            else if (UserWeiCi <= ZuiDaWeiCi && UserWeiCi >= FenGeWeiCiDa)
            {
                return 2;
            }
            else if (UserWeiCi >= ZuiXiaoWeiCi && UserWeiCi <= FenGeWeiCiXiao)
                return 4;
            else if (UserWeiCi <= ZuiXiaoWeiCi)
                return 5;
            else//if (UserWeiCi >= ZuiDaWeiCi)
            {
                return 1;
            }
        }

        //基于完整数据的线差算法
        private static int ShowSuggest_XianCha(int UserXianCha, int PiCiXian, int ZuiGaoFen, int ZuiDiFen, int PingJunFen)
        {
            //位次差值的三份
            int XianChaDa = ZuiGaoFen - PiCiXian;
            int XianChaXiao = ZuiDiFen - PiCiXian;
            int FenGe = (ZuiGaoFen - ZuiDiFen) * 3 / 8;
            int FenGeXianChaDa = XianChaDa - FenGe;
            int FenGeXianChaXiao = XianChaXiao + FenGe;

            // 1有风险，2冲一冲，3稳一稳，4保一保，5垫一垫
            if (UserXianCha <= FenGeXianChaDa && UserXianCha >= FenGeXianChaXiao)
            {
                return 3;
            }
            else if (UserXianCha <= FenGeXianChaXiao && UserXianCha >= XianChaXiao)
                return 2;
            else if (UserXianCha <= XianChaDa && UserXianCha >= FenGeXianChaDa)
            {
                return 4;
            }
            else if (UserXianCha >= XianChaDa)
            {
                return 5;
            }
            else
                return 1;
        }


        private static int ShowSuggest_XianChaNew(int UserXianCha, int PiCiXian, int ZuiGaoFen, int ZuiDiFen, int PingJunFen)
        {
            //位次差值的三份
            int XianChaDa = ZuiGaoFen - PiCiXian;
            int XianChaXiao = ZuiDiFen - PiCiXian;
            int XianChaPingJun = PingJunFen - PiCiXian;
            int FenGe = (ZuiGaoFen - ZuiDiFen) * 3 / 8;
            int FenGeXianChaDa = XianChaDa - FenGe;
            int FenGeXianChaXiao = XianChaXiao + FenGe;

            // 1有风险，2冲一冲，3稳一稳，4保一保，5垫一垫
            if (UserXianCha >= XianChaDa) //大于最大线差
            {
                if (UserXianCha >= (XianChaPingJun + 10))
                    return 5;
                else
                    return 4;
            }
            else if (UserXianCha <= XianChaDa && UserXianCha >= FenGeXianChaDa)
            {
                if (UserXianCha >= (XianChaPingJun + 10))
                    return 5;
                else if (UserXianCha >= (XianChaPingJun + 5))
                    return 4;
                else
                    return 3;
            }
            else if (UserXianCha <= FenGeXianChaDa && UserXianCha >= FenGeXianChaXiao)
                return 2;
            else if (UserXianCha >= XianChaDa)
            {
                return 5;
            }
            else
                return 1;
        }

        //基于录取最低分和录取最高分的算法
        private static int ShowSuggest_JiangSu(int UserXianCha, int PiCiXian, int ZuiGaoFen, int ZuiDiFen, int PingJunFen)
        {
            //位次差值的三份
            int XianChaDa = ZuiGaoFen - PiCiXian;
            int XianChaXiao = ZuiDiFen - PiCiXian;
            int FenGe = (ZuiGaoFen - ZuiDiFen) * 3 / 8;
            int FenGeXianChaDa = XianChaDa - FenGe;
            int FenGeXianChaXiao = XianChaXiao + FenGe;

            // 1有风险，2冲一冲，3稳一稳，4保一保，5垫一垫
            if (UserXianCha > (XianChaDa + 3))
            {
                return 5;
            }
            else if (UserXianCha <= (XianChaDa + 3) && UserXianCha > XianChaDa)
                return 4;
            else if (UserXianCha <= XianChaDa && UserXianCha > FenGeXianChaXiao)
            {
                return 3;
            }
            else if (UserXianCha <= FenGeXianChaXiao && UserXianCha > XianChaXiao)
            {
                return 2;
            }
            else
                return 1;
        }


        //基于录取最低分的算法
        private static int ShowSuggest_ZuiDiFen(int UserXianCha, int SchoolPiCiXian, int SchoolZuiDiFen)
        {
            //位次差值的三份
            int XianCha = SchoolZuiDiFen - SchoolPiCiXian;

            // 1有风险，2冲一冲，3稳一稳，4保一保，5垫一垫
            if (UserXianCha <= XianCha)
            {
                return 1;
            }
            else if (UserXianCha > XianCha && UserXianCha <= (XianCha + 5))
            {
                return 2;
            }
            else if (UserXianCha > (XianCha + 5) && UserXianCha <= (XianCha + 10))
            {
                return 3;
            }
            else if (UserXianCha > (XianCha + 10) && UserXianCha <= (XianCha + 15))
            {
                return 4;
            }
            else
                return 5;
        }


        //基于录取平均分的算法
        private static int ShowSuggest_PingJunFen(int UserXianCha, int SchoolPiCiXian, int SchoolPingJunFen)
        {
            //位次差值的三份
            int XianCha = SchoolPingJunFen - SchoolPiCiXian;

            // 1有风险，2冲一冲，3稳一稳，4保一保，5垫一垫
            if (UserXianCha <= (XianCha-6))
            {
                return 1;
            }
            else if (UserXianCha > (XianCha-6) && UserXianCha < (XianCha - 2))
            {
                return 2;
            }
            else if (UserXianCha >= (XianCha - 2) && UserXianCha < (XianCha + 5))
            {
                return 3;
            }
            else if (UserXianCha >= (XianCha + 5) && UserXianCha <= (XianCha + 10))
            {
                return 4;
            }
            else
                return 5;
        }




        #endregion


        public static bool IsBaoKaoTime(Entity.ProvinceConfig provinceConfig, int studentGKYear)
        {
            if (provinceConfig == null)
                return false;
            if (DateTime.Now.Year != studentGKYear)
                return false;
            DateTime now = DateTime.Now;
            if (provinceConfig.ReStartTime >= now && provinceConfig.ChangeEndTime <= now)
                return true;

            return false;
        }


        public static int GetZhuanHuanFenCha(Entity.FenShuXian fenshuxian, int FenShu)
        {
            int PcFirst = fenshuxian.PcFirst;
            int PcSecond = fenshuxian.PcSecond;
            int PcThird = fenshuxian.PcThird;
            int ZkFirst = fenshuxian.ZkFirst;
            int ZkSecond = fenshuxian.ZkSecond;

            int ZhuanHuanFenCha = 0;
            int PiCiXianShang = 0;
            int PiCiXianXia = 0;

            ////要注意一个问题，有可能一个学校是三本的，但是所有录取学生都是二本的学生，但是在这里没有区别吧！
            //if (FenShu >= PcFirst)
            //{
            //    ZhuanHuanFenCha = FenShu - PcFirst;
            //    return ZhuanHuanFenCha;
            //}
            //else if (FenShu >= PcSecond)
            //{
            //    PiCiXianShang = PcFirst;
            //    PiCiXianXia = PcSecond;

            //}
            //else if (PcThird != 0 && FenShu >= PcThird)
            //{
            //    PiCiXianShang = PcSecond;
            //    PiCiXianXia = PcThird;
            //}
            //else if (ZkFirst != 0 && FenShu >= ZkFirst)
            //{
            //    PiCiXianShang = (PcThird == 0 ? PcSecond : PcThird) - FenShu;//上一批次的线差
            //    PiCiXianXia = FenShu - ZkFirst;//批次线差
            //}
            //else if (ZkSecond != 0 && FenShu >= ZkSecond)
            //{
            //    PiCiXianShang = ZkFirst - FenShu;
            //    PiCiXianXia = FenShu - ZkSecond;
            //}
            //else
            //{
            //    studentChengJi.PiCi = 0;
            //    studentChengJi.XianChaShang = 0;//上一批次的线差
            //    studentChengJi.XianCha = 0;//批次线差
            //    studentChengJi.PiCiXian = 0;
            //}

            return ZhuanHuanFenCha;
        }





        public static string ShowStudentZhiYuanList(int PcId, int StudentId, bool ZhuanYeIsEmpty)
        {
            StringBuilder sb = new StringBuilder();

            Entity.ProvincePiCi obj = DAL.ProvincePiCi.ProvincePiCiEntityGet(PcId);
            sb.Append("<tr>");
            if (ZhuanYeIsEmpty == true)
            {
                sb.Append("<th width=\"30%\">志愿名</th>");
                sb.Append("<th width=\"50%\">院校名称</th>");
                sb.Append("<th width=\"20%\">专业调剂</th>");
            }
            else
            {
                sb.Append("<th width=\"8%\">志愿名</th>");
                sb.Append("<th width=\"24%\">院校名称</th>");
                for (int i = 1; i <= obj.MajorCount; i++)
                {
                    if (obj.MajorCount == 5)
                        sb.Append("<th width=\"12%\">专业" + i + "</th>");
                    else if (obj.MajorCount == 6)
                        sb.Append("<th width=\"10%\">专业" + i + "</th>");
                    else
                        sb.Append("<th>专业" + i + "</th>");
                }
                sb.Append("<th width=\"8%\">专业调剂</th>");
            }
            sb.Append("</tr>\r\n");

            DataTable dtStudentZhiYuanList = DAL.StudentZhiYuan.StudentZhiYuanList(" StudentId = " + StudentId + " AND ProvincePcId = " + PcId);
            DataTable dt = DAL.ProvinceZhiYuan.ProvinceZhiYuanList(PcId);
            for (int j = 0; j < dt.Rows.Count; j++)
            {
                Entity.StudentZhiYuan studentZhiYuan = DAL.StudentZhiYuan.StudentZhiYuanEntityGet(Basic.Utils.StrToInt(dt.Rows[j]["Id"].ToString(), 0), StudentId);
                if (studentZhiYuan == null)
                {
                    sb.Append("<tr><td>");
                    sb.Append(dt.Rows[j]["ZhiYuanMing"].ToString());
                    sb.Append("</td><td>");
                    sb.Append("</td>");
                    sb.Append(ShowZhuanYe("", obj.MajorCount, -1, ZhuanYeIsEmpty));
                    sb.Append("</tr>\r\n");
                }
                else
                {
                    sb.Append("<tr><td>");
                    sb.Append(dt.Rows[j]["ZhiYuanMing"].ToString());
                    sb.Append("</td><td>");
                    sb.Append(studentZhiYuan.SchoolName);
                    sb.Append("</td>");
                    sb.Append(ShowZhuanYe(studentZhiYuan.MajorList, obj.MajorCount, studentZhiYuan.IsTiaoJi, ZhuanYeIsEmpty));
                    sb.Append("</tr>\r\n");
                }
            }

            return sb.ToString();
        }

        protected static string ShowZhuanYe(string strMajorList, int MaxMajor, int IsTiaoJi, bool ZhuanYeIsEmpty)
        {
            string strOut = "";
            string[] Major = strMajorList.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            int intLength = Major.Length;
            if (intLength > 0)//保存专业数据了
            {
                int k = 0;
                for (int i = 0; i < intLength; i = i + 1)
                {
                    k = k + 1;
                    strOut += "<td>" + Major[i].Split(':')[1] + "</td>";
                }
                for (int j = k; j < MaxMajor; j++)
                    strOut += "<td></td>";
            }

            if (IsTiaoJi == 1)
                strOut += "<td>愿意</td>";
            else if (IsTiaoJi == 0)
                strOut += "<td>不愿意</td>";
            else
                strOut += "<td></td>";

            if (strOut == "<td></td>" && ZhuanYeIsEmpty == true)
            {
                strOut += "<td>愿意</td>";
            }

            return strOut;
        }



        #region 浙江
        public static Entity.StudentChengJi GetZheJiangUserPiCi(Entity.FenShuXian fenshuxian, int FenShu, int DataYear, int ProvinceId, int KeLei)
        {
            Entity.StudentChengJi studentChengJi = new Entity.StudentChengJi();
            int PcFirst = fenshuxian.PcFirst;
            int PcSecond = fenshuxian.PcSecond;
            int PcThird = fenshuxian.PcThird;
            int ZkFirst = fenshuxian.ZkFirst;
            int ZkSecond = fenshuxian.ZkSecond;

            if (FenShu >= PcFirst)
            {
                studentChengJi.PiCi = 1;
                studentChengJi.XianChaShang = 0;//上一批次的线差
                studentChengJi.XianCha = FenShu - PcFirst;//批次线差
                studentChengJi.PiCiXian = PcFirst;
            }
            else if (FenShu >= PcSecond)
            {
                studentChengJi.PiCi = 2;
                studentChengJi.XianChaShang = PcFirst - FenShu;//上一批次的线差
                studentChengJi.XianCha = FenShu - PcSecond;//批次线差
                studentChengJi.PiCiXian = PcSecond;
            }
            else if (PcThird != 0 && FenShu >= PcThird)
            {
                studentChengJi.PiCi = 3;
                studentChengJi.XianChaShang = PcSecond - FenShu;//上一批次的线差
                studentChengJi.XianCha = FenShu - PcThird;//批次线差
                studentChengJi.PiCiXian = PcThird;
            }
            else if (ZkFirst != 0 && FenShu >= ZkFirst)
            {
                studentChengJi.PiCi = 4;
                studentChengJi.XianChaShang = (PcThird == 0 ? PcSecond : PcThird) - FenShu;//上一批次的线差
                studentChengJi.XianCha = FenShu - ZkFirst;//批次线差
                studentChengJi.PiCiXian = ZkFirst;
            }
            else if (ZkSecond != 0 && FenShu >= ZkSecond)
            {
                studentChengJi.PiCi = 5;
                studentChengJi.XianChaShang = ZkFirst - FenShu;//上一批次的线差
                studentChengJi.XianCha = FenShu - ZkSecond;//批次线差
                studentChengJi.PiCiXian = ZkSecond;
            }
            else
            {
                studentChengJi.PiCi = 0;
                studentChengJi.XianChaShang = 0;//上一批次的线差
                studentChengJi.XianCha = 0;//批次线差
                studentChengJi.PiCiXian = 0;
            }

            //下面根据成绩来取位次等信息
            Entity.ProvinceWeiCi provinceWeiCi = DAL.ProvinceWeiCi.ProvinceWeiCiEntityGetByFenShu(FenShu, DataYear, ProvinceId, KeLei);
            if (provinceWeiCi == null)
            {
                studentChengJi.WeiCi = 0;
                studentChengJi.RenShu = 0;
                studentChengJi.LeiJiRenShu = 0;
            }
            else
            {
                studentChengJi.WeiCi = provinceWeiCi.WeiCi;
                studentChengJi.RenShu = provinceWeiCi.RenShu;
                studentChengJi.LeiJiRenShu = provinceWeiCi.LeiJiRenShu;
            }
            studentChengJi.FenShu = FenShu;

            return studentChengJi;
        }
        #endregion

    }
}
