using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Basic
{
    public class Common
    {
        public static string GetRandom(int codeLen, string CodeSerial)
        {
            if (codeLen == 0)
            {
                codeLen = 4;
            }

            string[] arr = CodeSerial.Split(',');

            string code = "";

            int randValue = -1;

            Random rand = new Random(unchecked((int)DateTime.Now.Ticks));

            for (int i = 0; i < codeLen; i++)
            {
                randValue = rand.Next(0, arr.Length - 1);

                code += arr[randValue];
            }

            return code;
        }
    }
}