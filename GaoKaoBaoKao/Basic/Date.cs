using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Basic
{
    public class Date
    {

        /// <summary>
        /// 获取该年中是第几周,周一为一周的第一天
        /// </summary>
        /// <param name="day">日期</param>
        /// <returns></returns>
        public static int WeekOfYear(System.DateTime day)
        {
            int weeknum;
            System.DateTime fDt = DateTime.Parse(day.Year.ToString() + "-01-01");
            int k = Convert.ToInt32(fDt.DayOfWeek);//得到该年的第一天是周几 
            if (k == 0)
            {
                k = 7;
            }
            int l = Convert.ToInt32(day.DayOfYear);//得到当天是该年的第几天 
            l = l - (7 - k + (-1));//括号里面的-1；默认周日是一周的第一天，所以周六作为一周的第一天，括号里为-1；如果周一为一周的第一天，括号里为1；
            if (l <= 0)
            {
                weeknum = 1;
            }
            else
            {
                if (l % 7 == 0)
                {
                    weeknum = l / 7 + 1;
                }
                else
                {
                    weeknum = l / 7 + 2;//不能整除的时候要加上前面的一周和后面的一周 
                }
            }
            return weeknum;
        }

        /// <summary>
        /// 获取该月中是第几周
        /// </summary>
        /// <param name="day">日期</param>
        /// <returns></returns>
        private int WeekOfMonth(System.DateTime day)
        {
            string y = day.Year.ToString();
            string m = day.Month.ToString();
            string s = y + "-" + m + "-1";

            DateTime dt = DateTime.Parse(s);

            int d = day.Day - dt.Day;
            int w = 1;
            for (int i = 1; i <= d; i++)
            {
                DateTime dt1 = dt.AddDays(i);
                if (dt1.DayOfWeek == DayOfWeek.Sunday)
                {
                    w = w + 1;
                }
            }
            return w;
        }

        /// <summary>
        /// 根据需求获取两个时间之间的差值：年月日时分秒
        /// </summary>
        /// <param name="howtocompare">获取两时间之间的什么差值：年份、月份还是天数、还是小时等</param>
        /// <param name="startDate">开始日期</param>
        /// <param name="endDate">结束日期</param>
        /// <returns>返回两时间之间的差值</returns>
        public static double DateDiff(string howtocompare, System.DateTime startDate, System.DateTime endDate)
        {
            double diff = 0;
            System.TimeSpan TS = new System.TimeSpan(endDate.Ticks - startDate.Ticks);

            switch (howtocompare.ToLower())
            {
                case "year":
                    diff = Convert.ToDouble(TS.TotalDays / 365);
                    break;
                case "month":
                    diff = Convert.ToDouble((TS.TotalDays / 365) * 12);
                    break;
                case "day":
                    diff = Convert.ToDouble(TS.TotalDays);
                    break;
                case "hour":
                    diff = Convert.ToDouble(TS.TotalHours);
                    break;
                case "minute":
                    diff = Convert.ToDouble(TS.TotalMinutes);
                    break;
                case "second":
                    diff = Convert.ToDouble(TS.TotalSeconds);
                    break;
            }

            return diff;
        }
    }
}