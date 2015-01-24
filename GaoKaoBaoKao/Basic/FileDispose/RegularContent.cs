using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Basic.FileDispose;

namespace Basic.FileDispose
{

    /// <summary>
    /// 替换文件内容
    /// </summary>
    public  class RegularContent
    {


        /// <summary>
        ///  取得网站模板
        /// </summary>
        /// <param name="strPage">模板类型</param>
        /// <param name="strPage">模板路径</param>
        /// <returns>返回生成的页面</returns>
        public   static string GetTemplate(string strPage)
        {

            //string WSbody = "页面生成出现错误！";
            //try
            //{
            //    if (strPage == "") return "没有传入模板路径或类型";
            //    //获取模板路径
            //    string strdir = Basic.XMLProcess.Read("xml/Template.xml", "/template/system", "url");   //获取系统节点模板的基路径
            //    string strfile = Basic.XMLProcess.Read("xml/Template.xml", "/template/system/mode[@type='" + strPage + "']", "url"); //获取页面模板的路径
            //    string Path = AppDomain.CurrentDomain.BaseDirectory.ToString() + strdir + strfile;
            //    if (!FileDispose.CheckFile(Path))
            //        return "模板不存在";
            //    else
            //    {
            //        Tempinc Temp = new Tempinc(strPage);

            //        Basic.FileDispose.FileDispose fd = new Basic.FileDispose.FileDispose();
            //        WSbody = fd.GetFileContent(Path);
            //    }
            //}
            //catch (Exception e)
            //{
            //    throw e;
            //}
            //return WSbody;

            return string.Empty;
        }
    }
}
