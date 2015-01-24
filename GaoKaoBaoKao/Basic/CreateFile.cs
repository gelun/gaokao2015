using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace Basic
{
    public class CreateFile
    {

        /// <summary>
        /// 保存文件
        /// </summary>
        /// <param name="strDirectorys">文件路径，格式为：  /files/2013/10/27/   </param>
        /// <param name="strFielName">文件名，格式为：  news-1.shtml   </param>
        /// <param name="strContent">文件内容</param>
        /// <returns>保存成功与否</returns>
        public static bool strSaveFile(string strDirectorys, string strFielName, string strContent)
        {
            try
            {
                //判断路径，不存在的话，进行创建
                Basic.Utils.IsExistDirectory(strDirectorys);

                //Basic.FileDispose.FileDispose fd = new Basic.FileDispose.FileDispose();

                string strPath = strDirectorys + strFielName;
                Basic.FileDispose.FileDispose.SaveFile(strContent, HttpContext.Current.Server.MapPath(strPath));

                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
