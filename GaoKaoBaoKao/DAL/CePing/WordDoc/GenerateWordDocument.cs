using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace DAL.CePing.WordDoc
{

    public static class GenerateWordDocument
    {
        //填充学生报告的基本信息
        public static Microsoft.Office.Interop.Word.Table BaseInfo(Microsoft.Office.Interop.Word.Table tb1, Entity.GaoKaoCard infoGaoKaoCard, Entity.Join_Student infoStudent)
        {
            string strProvinceName = "";
            Entity.Province infoProvince=DAL.Province.ProvinceEntityGet(infoStudent.ProvinceId);
            if (infoProvince!=null)
            {
                strProvinceName = infoProvince.ProvinceName;
            }

            if (tb1.Rows.Count == 4)
            {
                //在指定单元格填值
                //第1行
                tb1.Cell(1, 2).Range.Text = infoStudent.StudentName;
                tb1.Cell(1, 4).Range.Text = (infoStudent.Sex == 1 ? "女" : "男");
                //第2行
                tb1.Cell(2, 2).Range.Text = infoStudent.SchoolName;
                tb1.Cell(2, 4).Range.Text = (infoStudent.WenLi == 1 ? "文史" : "理工");
                //第3行
                tb1.Cell(3, 2).Range.Text = strProvinceName;
                tb1.Cell(3, 4).Range.Text = infoStudent.GKYear.ToString();
                //第4行
                tb1.Cell(4, 2).Range.Text = infoGaoKaoCard.KaHao;
                tb1.Cell(4, 4).Range.Text = Basic.TypeConverter.StrToDateStr(DateTime.Now.ToString());
            }
            return tb1;
        }


        //替换字符
        public static void ReplaceZF(Microsoft.Office.Interop.Word.Document oDoc, object FindText, object ReplaceWith, object MissingValue)
        {
            //wdReplaceAll - 替换找到的所有项。 
            //wdReplaceNone - 不替换找到的任何项。 
            //wdReplaceOne - 替换找到的第一项。 
            object Replace = Microsoft.Office.Interop.Word.WdReplace.wdReplaceAll;
            //移除Find的搜索文本和段落格式设置 
            oDoc.Content.Find.ClearFormatting();

            oDoc.Content.Find.Execute(ref FindText, ref MissingValue, ref MissingValue, ref MissingValue, ref MissingValue, ref MissingValue, ref MissingValue, ref MissingValue, ref MissingValue, ref ReplaceWith, ref Replace, ref MissingValue, ref MissingValue, ref MissingValue, ref MissingValue);
        }

        //输出word
        public static void ExtWord(string fileName, string wordname)
        {
            //输出word
            System.IO.FileInfo file = new System.IO.FileInfo(fileName);
            System.Web.HttpContext.Current.Response.Clear();
            System.Web.HttpContext.Current.Response.Charset = "utf-8";
            System.Web.HttpContext.Current.Response.ContentEncoding = System.Text.Encoding.UTF8;
            // 添加头信息，为"文件下载/另存为"对话框指定默认文件名 
            System.Web.HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment; filename=" + HttpUtility.UrlEncode(wordname, System.Text.Encoding.UTF8));
            // 添加头信息，指定文件大小，让浏览器能够显示下载进度 
            System.Web.HttpContext.Current.Response.AddHeader("Content-Length", file.Length.ToString());

            // 指定返回的是一个不能被客户端读取的流，必须被下载 
            System.Web.HttpContext.Current.Response.ContentType = "application/ms-word";

            // 把文件流发送到客户端 
            System.Web.HttpContext.Current.Response.WriteFile(file.FullName);
            // 停止页面的执行 
            //HttpContext.Current.ApplicationInstance.CompleteRequest
            System.Web.HttpContext.Current.ApplicationInstance.CompleteRequest();
        }

        #region 职业能力

        //根据分值获取职业能力测评等级
        public static string AbilityLevel(int intFenShu)
        {
            switch (intFenShu)
            {
                case 1:
                    return "弱";
                case 2:
                    return "较弱";
                case 3:
                    return "一般";
                case 4:
                    return "较强";
                case 5:
                    return "强";
                default:
                    return "";
            }
        }

        //各个职业能力对应的专业
        public static string AbilityZhuanYe(int intIndex)
        {
            switch (intIndex)
            {
                case 0://言语能力
                    return "文学（中国语言文学类，外国语言文学类，新闻传播学类）；教育学（教育学类）艺术学（戏剧与影视学类）";
                case 1://数理能力
                    return "经济学（经济学类，财政学类，金融学类，经济与贸易类）；理学（数学类，物理学类，物理学类，天文学类，地球物理学类，心理学类，统计学类）；工学（力学类、机械类，仪器类，材料类，能源动力类，电气类，电子信息类，自动化类，计算机类，土木类，水利类，测绘类，航空航天类，兵器类，核工程类，安全科学与工程类，公安技术类）；管理学（工商管理类，管理科学与工程类）";
                case 2://空间判断能力
                    return "理学（数学类、物理学类、地球物理学类）；工学（土木类，水利类，测绘类，建筑类）；艺术学（设计学类）";
                case 3://察觉细节能力
                    return "教育学（教育学类）；经济学（经济学类，财政学类，金融学类，经济与贸易类）；工学（土木类，水利类，测绘类，建筑类）；艺术学（设计学类）；管理学（工商管理类，管理科学与工程类）";
                case 4://书写能力
                    return "教育学（教育学类）；经济学（经济学类，财政学类，金融学类，经济与贸易类）；管理学（工商管理类，管理科学与工程类）";
                case 5://运动协调能力
                    return "教育学（体育学类）；医学（临床医学类，口腔医学类，护理学类）";
                case 6://动手能力
                    return "医学（临床医学类，口腔医学类，护理学类）；工学（力学类、机械类，仪器类，材料类，测绘类，化工与制药类，地质类，矿业类，纺织类，轻工类，农业工程类，林业工程类，生物医学工程类，食品医学工程类，建筑类、航空航天类，兵器类，核工程类，安全科学与工程类，生物工程类，公安技术类）";
                case 7://社会交往能力
                    return "教育学（教育学类、体育学类）；法学（社会学类，法学，政治学类）；文学（中国语言文学类，外国语言文学类，新闻传播学类）；管理学（工商管理类，管理科学与工程类，公共管理类）";
                case 8://组织管理能力
                    return "管理学（工商管理类，管理科学与工程类，公共管理类）";
                default:
                    return "";
            }
        }

        #endregion
    }
}
