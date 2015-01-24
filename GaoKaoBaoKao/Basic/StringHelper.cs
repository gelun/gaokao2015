using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;

namespace Basic
{
    public class StringHelper
    {

        /// <summary>
        /// 随机获取10个不重复的数值
        /// </summary>
        /// <returns></returns>
        public static string GetList(int intCount,int intLength)
        {
            string list = "";

            if (intCount > intLength)
            {

                string strOldList = ",";
                int[] arr = new int[intCount];
                for (int i = 0; i < intCount; i++)
                {
                    arr[i] = i;
                }

                ArrayList b = new ArrayList(intLength);
                int n = 0;

                while (n < intLength)
                {
                    Random r = new Random((int)DateTime.Now.Ticks);
                    int x = r.Next(0, arr.Length);

                    if (!b.Contains(arr[x]))
                    {
                        //添加
                        b.Add(arr[x]);

                        //移除数组中的该项的值
                        ArrayList al = new ArrayList(arr);
                        al.RemoveAt(x);
                        arr = (int[])al.ToArray(typeof(int));

                        //n加1
                        n++;
                    }
                }

                foreach (object c in b)
                {
                    list += c + ",";
                }
            }
            else
            {
                for (int i = 1; i <= intCount; i++)
                {
                    list += i + ",";
                }
            }

            return list;
        }
    }
}