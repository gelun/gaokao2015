using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace Basic
{
    public class Code
    {


        static string Vchar = "a|b|c|d|e|f|g|h|i|j|k|m|n|o|p|q|r|s|t|u|v|w|x|y|z|0|1|2|3|5|6|7|8|9|A|B|C|D|E|F|G|H|I|J|K|L|M|N|O|P|Q|R|S|T|U|V|W|X|Y|Z";
        static string Vchar1 = "0|1|2|3|5|6|7|8|9|A|B|C|D|E|F|G|H|I|J|K|L|M|N|O|P|Q|R|S|T|U|V|W|X|Y|Z";

        /// <summary>
        /// 生成随机数
        /// </summary>
        /// <param name="place">随机数长度</param>
        public string CreateLENCode(int place)
        {


            string[] VcArray = Vchar.Split(new Char[] { '|' });//拆分成数组


            string VNum = "";
            int temp = -1;//记录上次随机数值，尽量避避免生产几个一样的随机数   

            Random rand = new Random();

            for (int i = 0; i < place; i++)
            {
                if (temp != -1)
                {
                    rand = new Random(i * temp * unchecked((int)DateTime.Now.Ticks));//初始化随机类   
                }
                int t = rand.Next(VcArray.Length);//获取随机数   
                if (temp != -1 && temp == t)
                {
                    return CreateLENCode(place);//如果获取的随机数重复，则递归调用   
                }
                temp = t;//把本次产生的随机数记录起来   
                VNum += VcArray[t];//随机数的位数加一   
            }
            return VNum;
        }



        /// <summary>
        /// 生成随机数
        /// </summary>
        /// <param name="place">随机数长度</param>
        public string CreateENCode(int place)
        {


            string[] VcArray = Vchar1.Split(new Char[] { '|' });//拆分成数组


            string VNum = "";
            int temp = -1;//记录上次随机数值，尽量避避免生产几个一样的随机数   

            Random rand = new Random();

            for (int i = 0; i < place; i++)
            {
                if (temp != -1)
                {
                    rand = new Random(i * temp * unchecked((int)DateTime.Now.Ticks));//初始化随机类   
                }
                int t = rand.Next(VcArray.Length);//获取随机数   
                if (temp != -1 && temp == t)
                {
                    return CreateENCode(place);//如果获取的随机数重复，则递归调用   
                }
                temp = t;//把本次产生的随机数记录起来   
                VNum += VcArray[t];//随机数的位数加一   
            }
            return VNum;
        }
    }

}