using System;
using System.Text;
using System.IO;
using System.Web;

namespace Basic.FileDispose
{
    public class FileDispose
    {

        /// <summary>
        /// 创建文件夹
        /// </summary>
        public static void CreateDir(string sPath)
        {
            //创建文件夹
            if (!Directory.Exists(sPath))//保存的文件夹
            {
                Directory.CreateDirectory(sPath);
            }
        }


        /// <summary>
        /// 检测文件是否存在
        /// </summary>
        /// <param name="FileUrl">文件路径</param>
        /// <returns></returns>
        public static bool CheckFile(string FileUrl)
        {
            if (File.Exists(FileUrl))
                return true;
            else
                return false;
        }





        /// <summary>
        /// 读取文件内容
        /// </summary>
        /// <param name="_path">文件路径</param>
        /// <returns>返回文件的内容</returns>
        public static string GetFileContent(string _path)
        {
            string path = _path;

            if (File.Exists(path))
            {
                using (FileStream fs = new FileStream(path, FileMode.Open, System.IO.FileAccess.Read))
                {

                    using (StreamReader sw = new StreamReader(fs, Encoding.UTF8))
                    {


                        //读取文件内容
                        string content = "";
                        content = sw.ReadToEnd();
                        sw.Close();
                        sw.Dispose();
                        fs.Close();
                        fs.Dispose();

                        return content;
                    }
                }
            }

            return string.Empty;
        }


        /// <summary>
        /// 拷贝文件
        /// </summary>
        /// <param name="_sourcePath">源文件</param>
        /// <param name="_targetPath">目标文件</param>
        public static void ShiftFile(string _sourcePath, string _targetPath)
        {
            File.Copy(_sourcePath, _targetPath, true);
        }





        /// <summary>
        /// 生成文件
        /// </summary>
        /// <param name="_content">写入文件的内容</param>
        /// <param name="_path">文件的物理地址</param>
        public static void SaveFile(string _content, string _path)
        {
            System.Text.UTF8Encoding utf8 = new System.Text.UTF8Encoding(true);
            SaveFile(_content, _path, utf8);

        }


        public static string MapPath(string strPath)
        {
            if (System.Web.HttpContext.Current != null)
            {
                return System.Web.HttpContext.Current.Server.MapPath(strPath);
            }
            else //非web程序引用 
            {
                strPath = strPath.Replace("/", "\\");
                if (strPath.StartsWith("\\") || strPath.StartsWith("~"))
                {
                    strPath = strPath.Substring(strPath.IndexOf('\\', 1)).TrimStart('\\');
                }
                return System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, strPath);
            }
        }


        /// <summary>
        /// 生成文件
        /// </summary>
        /// <param name="_content">写入文件的内容</param>
        /// <param name="_path">文件的物理地址</param>
        /// <param name="encodeing">文件采用编码方式</param>
        public static void SaveFile(string _content, string _path, System.Text.Encoding encodeing)
        {
            //保存数据


            String path = _path;
            if (File.Exists(path))
            {
                File.Delete(path);
            }

            StreamWriter sw = null;


            try
            {
                path =MapPath(path);
                string paths = Path.GetDirectoryName(path);
                CreateDir(paths);

                //处理文件夹问题，如果文件夹不存在，则创建
                //不存在就新建一个文本文件,并写入一些内容
                sw = new StreamWriter(path, false, encodeing);
                sw.WriteLine(_content);

                //sw = File.CreateText(path);
                //sw.WriteLine(_content);

             
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                if (sw != null)
                {
                    sw.Close();
                    sw.Dispose();
                }
            }
        }
    }
}

