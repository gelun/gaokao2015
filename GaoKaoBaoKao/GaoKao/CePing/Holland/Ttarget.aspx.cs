using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Drawing.Imaging;
using Svg;
using System.Text;
using System.Data;
using Word = Microsoft.Office.Interop.Word;

namespace GaoKao.CePing.Holland
{
    public partial class Ttarget : UserBase
    {
        protected int intArt = 0, intBusiness = 0, intReality = 0, intSociety = 0, intStudy = 0, intTradition = 0;

        //实际型（R）  现实
        protected string Reality = "工学（机械类、仪器仪表、材料类、能源动力类、电气类、自动化类、计算机类、土木类、测绘类、地质类、矿业类、纺织类、轻工类、交通运输类、建筑类等）";//
        //调研型（I）  研究
        protected string Study = "理学（数学类，物理学类，化学类，天文学类，地理科学类，大气科学类，海洋科学类，地球物理学类，地质学类，生物科学类，心理学类，统计学类）、经济学（经济学类，财政学类，金融学类，经济与贸易类）、法学（法学类）、教育学（教育学类）、医学（基础医学、中医学、药学）";//
        //艺术型（A）艺术
        protected string Art = "艺术类（音乐与舞蹈学类、戏剧与影视学类、美术学类、设计学类）、工学（纺织类、建筑类、工业设计）";//
        //社会型（S）社会
        protected string Society = "教育学（教育学类、体育学类）， 法学（社会学类，法学，政治学类、民族学类、马克思主义理论类、公安学类），文学（中国语言文学类，外国语言文学类，新闻传播学类），理学（心理学类）， 医学（护理学类）， 管理学（工商管理类、公共管理类、旅游管理类）， 经济学（经济学类，财政学类，金融学类，经济与贸易类）";//
        //企业型（E） 企业
        protected string Business = "管理学（工商管理类、公共管理类、物流管理与工程等） 法学（法学类、公安学类）  经济学（经济学类，财政学类，金融学类，经济与贸易类）";//
        //常规型（C）  常规
        protected string Tradition = "管理类（工商管理类:会计学、审计学、人力资源管理，图书情报与档案管理类、物流管理与工程类、工业工程类等）  医学类（中医学类、中药学类）";//

        //最强兴趣特点
        protected string strTeDian = "";

        //可能感兴趣专业
        protected string[] arrTuiJianZhuanYe;

        //不推荐专业
        protected string[] arrBuTuiJianZhuanYe;


        protected int[] list;
        protected int intMax = 0;//最大值
        protected int intMin = 0;//最小值
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                #region 获取霍兰德测试结果

                DataTable dt = DAL.Join_HollandResults.Join_HollandResultsList("[UserId]=" + this.user.StudentId);
                if (dt != null && dt.Rows.Count > 0)
                {
                    //
                    intArt = Basic.TypeConverter.StrToInt(dt.Rows[0]["Art"].ToString(), 0);
                    intBusiness = Basic.TypeConverter.StrToInt(dt.Rows[0]["Business"].ToString(), 0);
                    intReality = Basic.TypeConverter.StrToInt(dt.Rows[0]["Reality"].ToString(), 0);
                    intSociety = Basic.TypeConverter.StrToInt(dt.Rows[0]["Society"].ToString(), 0);
                    intStudy = Basic.TypeConverter.StrToInt(dt.Rows[0]["Study"].ToString(), 0);
                    intTradition = Basic.TypeConverter.StrToInt(dt.Rows[0]["Tradition"].ToString(), 0);

                    list = new int[] { intArt, intBusiness, intReality, intSociety, intStudy, intTradition };

                    DAL.Comm.BubbleSortUp(list);
                    intMax = list[5];//最大值
                    intMin = list[0];//最小值
                }
                else
                {

                    Basic.MsgHelper.AlertUrlMsg("您的职业兴趣还未进行测试，请先测试", "/CePing/Holland/Default.aspx");
                    return;
                }
                #endregion


                ClientScript.RegisterClientScriptBlock(Page.GetType(), "jst", "<script type=\"text/javascript\">function openUrl(url){ window.open(url, \"name1\", \"fullscreen,location:yes,menubar:yes,resizable:yes,scrollbars:yes,status:yes,toolbar:yes\");}</script>");

                ltr_Over.Visible = true;

                ltr_Over.Text = "<div class=\"result\"><p>已为您生成专属报告</p><p><a href=\"Fruit.aspx\"  target=\"_blank\"><img src=\"../images/on.jpg\" /></a></p></div>";



                //生成图片  稍后要导入到 word文档中去
                string ty = Basic.RequestHelper.GetFormString("ty");
                if (ty == "ht")
                {
                    string container = Basic.RequestHelper.GetFormString("container");
                    string strImgPath = ("/CePing/ImgOfResult/Holland/");
                    string strImg = user.StudentId + "_holland.jpg";
                    HuiTu(container, strImgPath, strImg);//绘图

                    ExpWordByWord();//生成word文档
                }
            }
        }

        //根据svg生成图片
        void HuiTu(string tSvg, string strImgPath, string strImg)
        {
            strImgPath = System.Web.HttpContext.Current.Server.MapPath(strImgPath);
            if (!Directory.Exists(strImgPath))
            {
                Directory.CreateDirectory(strImgPath);
            }

            MemoryStream tData = new MemoryStream(Encoding.UTF8.GetBytes(tSvg));
            MemoryStream tStream = new MemoryStream();
            string tTmp = new Random().Next().ToString();

            Svg.SvgDocument tSvgObj = SvgDocument.Open(tData);
            tSvgObj.Draw().Save(tStream, ImageFormat.Jpeg);

            FileStream fls = new FileStream(strImgPath, FileMode.Create);//创建文件  

            tStream.WriteTo(fls);
            tStream.Close();
            fls.Close();
        }

        //生成word文档
        void ExpWordByWord()
        {
            Word._Application app = new Word.Application();
            //表示System.Type信息中的缺少值
            object nothing = Type.Missing;
            try
            {
                //高考卡号
                string strKaHao = "";
                Entity.GaoKaoCard infoGaoKaoCard = DAL.GaoKaoCard.GaoKaoCardEntityGetByStudentId(userinfo.StudentId);
                if (infoGaoKaoCard != null)
                {
                    strKaHao = infoGaoKaoCard.KaHao;
                }
                //省份名称
                string strProvinceName = userinfo.ProvinceName;

                //读取模板文件
                object temp = System.Web.HttpContext.Current.Server.MapPath("~/CePing/职业兴趣模板.doc");//读取模板文件

                //建立一个基于摸版的文档
                Word._Document doc = app.Documents.Add(ref temp, ref nothing, ref nothing, ref nothing);
                //学生基本信息
                Word.Table tb1 = doc.Tables[1];
                if (tb1.Rows.Count == 4)
                {
                    //在指定单元格填值
                    //第1行
                    tb1.Cell(1, 2).Range.Text = userinfo.StudentName;
                    tb1.Cell(1, 4).Range.Text = (user.Sex == 1 ? "女" : "男");
                    //第2行
                    tb1.Cell(2, 2).Range.Text = user.SchoolName;
                    tb1.Cell(2, 4).Range.Text = (userinfo.KeLei == 1 ? "文史" : "理工");
                    //第3行
                    tb1.Cell(3, 2).Range.Text = strProvinceName;
                    tb1.Cell(3, 4).Range.Text = user.GKYear.ToString();
                    //第4行
                    tb1.Cell(4, 2).Range.Text = strKaHao;
                    tb1.Cell(4, 4).Range.Text = Basic.TypeConverter.StrToDateStr(DateTime.Now.ToString());
                }

                //插入图片
                Word.Table tb2 = doc.Tables[2];
                string path = AppDomain.CurrentDomain.BaseDirectory + ("CePing/ImgOfResult/Holland/") + user.StudentId + "_holland.jpg";
                string FileName = path;//@"C:\chart.jpeg";//图片所在路径
                object LinkToFile = false;
                object SaveWithDocument = true;
                object Anchor = tb2.Range;
                doc.Application.ActiveDocument.InlineShapes.AddPicture(FileName, ref LinkToFile, ref SaveWithDocument, ref Anchor);
                //doc.Application.ActiveDocument.InlineShapes[1].Width = 300f;//图片宽度
                //doc.Application.ActiveDocument.InlineShapes[1].Height = 200f;//图片高度

                //object readOnly = false;
                //object isVisible = false;

                //职业兴趣测评分类说明
                Word.Table tb3 = doc.Tables[3];
                if (tb3.Rows.Count == 7)
                {
                    //在指定单元格填值
                    //第2行 现实
                    tb3.Cell(2, 2).Range.Text = intReality.ToString();
                    tb3.Cell(2, 3).Range.Text = Level(intReality);
                    //第3行 研究
                    tb3.Cell(3, 2).Range.Text = intStudy.ToString();
                    tb3.Cell(3, 3).Range.Text = Level(intStudy);
                    //第4行 艺术
                    tb3.Cell(4, 2).Range.Text = intArt.ToString();
                    tb3.Cell(4, 3).Range.Text = Level(intArt);
                    //第5行 社会
                    tb3.Cell(5, 2).Range.Text = intSociety.ToString();
                    tb3.Cell(5, 3).Range.Text = Level(intSociety);
                    //第6行 企业
                    tb3.Cell(6, 2).Range.Text = intBusiness.ToString();
                    tb3.Cell(6, 3).Range.Text = Level(intBusiness);
                    //第7行 常规
                    tb3.Cell(7, 2).Range.Text = intTradition.ToString();
                    tb3.Cell(7, 3).Range.Text = Level(intTradition);
                }


                //模板中 占位符的替换
                Microsoft.Office.Interop.Word.Document oDoc = (Microsoft.Office.Interop.Word.Document)doc;
                bb();
                //根据你最强的兴趣，可见你的特点是
                ReplaceZF(oDoc, "@xqlx", strTeDian, Type.Missing);
                //你可能喜欢的专业
                for (int i = 0; i < arrTuiJianZhuanYe.Length; i++)
                {
                    ReplaceZF(oDoc, "@xihuanzhuanye" + i, arrTuiJianZhuanYe[i], Type.Missing);
                }
                if (arrTuiJianZhuanYe.Length < 6)
                {
                    for (int i = arrTuiJianZhuanYe.Length; i < 6; i++)
                    {
                        ReplaceZF(oDoc, "@xihuanzhuanye" + i, "", Type.Missing);
                    }
                }

                //不建议选择的专业范围
                for (int i = 0; i < arrBuTuiJianZhuanYe.Length; i++)
                {
                    ReplaceZF(oDoc, "@buxihuanzhuanye" + i, arrBuTuiJianZhuanYe[i], Type.Missing);
                }
                if (arrBuTuiJianZhuanYe.Length < 6)
                {
                    for (int i = arrBuTuiJianZhuanYe.Length; i < 6; i++)
                    {
                        ReplaceZF(oDoc, "@buxihuanzhuanye" + i, "", Type.Missing);
                    }
                }


                //保存到服务器
                object fileName = System.Web.HttpContext.Current.Server.MapPath("~/") + "CePing/ImgOfResult/Holland/" + strKaHao + "(" + userinfo.StudentName + "_" + userinfo.StudentId + ")" + "_职业兴趣测评.doc";//获取服务器路径
                //保存doc文档
                oDoc.SaveAs(ref fileName, ref nothing, ref nothing, ref nothing, ref nothing, ref nothing,
                ref nothing, ref nothing, ref nothing, ref nothing, ref nothing, ref nothing, ref nothing,
                ref nothing, ref nothing, ref nothing);
                oDoc.Close(ref nothing, ref nothing, ref nothing);
                app.Quit(ref nothing, ref nothing, ref nothing);

                //输出word
                ExtWord(fileName.ToString(), "ts.doc");

            }
            catch (Exception ex)
            {
                //  resultMsg = "导出错误：" + ex.Message;
                app.Quit(ref nothing, ref nothing, ref nothing);
            }
        }

        /// <summary>
        /// 替换字符
        /// </summary>
        /// <param name="oDoc"></param>
        /// <param name="FindText"></param>
        /// <param name="ReplaceWith"></param>
        /// <param name="MissingValue"></param>
        void ReplaceZF(Microsoft.Office.Interop.Word.Document oDoc, object FindText, object ReplaceWith, object MissingValue)
        {
            //wdReplaceAll - 替换找到的所有项。 
            //wdReplaceNone - 不替换找到的任何项。 
            //wdReplaceOne - 替换找到的第一项。 
            object Replace = Microsoft.Office.Interop.Word.WdReplace.wdReplaceAll;
            //移除Find的搜索文本和段落格式设置 
            oDoc.Content.Find.ClearFormatting();

            oDoc.Content.Find.Execute(ref FindText, ref MissingValue, ref MissingValue, ref MissingValue, ref MissingValue, ref MissingValue, ref MissingValue, ref MissingValue, ref MissingValue, ref ReplaceWith, ref Replace, ref MissingValue, ref MissingValue, ref MissingValue, ref MissingValue);
        }


        /// <summary>
        /// 输出word
        /// </summary>
        /// <param name="filename"></param>
        public void ExtWord(string fileName, string wordname)
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

        //根据分值获取测评等级
        string Level(int intFenShu)
        {
            if (intFenShu <= 5)
            {
                return "较低";
            }
            else if (intFenShu <= 10)
            {
                return "一般";
            }
            else
            {
                return "较高";
            }
        }

        void bb()
        {
            if (intMax == intMin)
            {
                //所有类型得分一样
                strTeDian = "现实型-研究型-艺术型-社会型-企业型-常规型";
                arrTuiJianZhuanYe = new string[] { Reality, Study, Art, Society, Business, Tradition };
                //最强兴趣特点
                //strTeDian arrTuiJianZhuanYe  arrBuTuiJianZhuanYe = "";
            }
            else
            {
                CountArr();
                int max = -1;
                int min = -1;
                //intArt 艺术性, intBusiness 企业, intReality = 0  现实, intSociety = 0 社会, intStudy = 0 研究, intTradition 常规型
                if (intArt == intMax)
                {
                    max++;
                    strTeDian = "艺术型";
                    arrTuiJianZhuanYe[max] = Art;
                }
                else if (intArt == intMin)
                {
                    min++;
                    arrBuTuiJianZhuanYe[min] = Art;
                }
                if (intBusiness == intMax)
                {
                    max++;
                    strTeDian += "-企业型";
                    arrTuiJianZhuanYe[max] = Business;
                }
                else if (intBusiness == intMin)
                {
                    min++;
                    arrBuTuiJianZhuanYe[min] = Business;
                }
                if (intReality == intMax)
                {
                    max++;
                    strTeDian += "-现实型";
                    arrTuiJianZhuanYe[max] = Reality;
                }
                else if (intReality == intMin)
                {
                    min++;
                    arrBuTuiJianZhuanYe[min] = Reality;
                }
                if (intSociety == intMax)
                {
                    max++;
                    strTeDian += "-社会型";
                    arrTuiJianZhuanYe[max] = Society;
                }
                else if (intSociety == intMin)
                {
                    min++;
                    arrBuTuiJianZhuanYe[min] = Society;
                }
                if (intStudy == intMax)
                {
                    max++;
                    strTeDian += "-研究型";
                    arrTuiJianZhuanYe[max] = Study;
                }
                else if (intStudy == intMin)
                {
                    min++;
                    arrBuTuiJianZhuanYe[min] = Study;
                }
                if (intTradition == intMax)
                {
                    max++;
                    strTeDian += "-常规型";
                    arrTuiJianZhuanYe[max] = Tradition;
                }
                else if (intTradition == intMin)
                {
                    min++;
                    arrBuTuiJianZhuanYe[min] = Tradition;
                }

                if (strTeDian.StartsWith("-"))
                {
                    strTeDian = strTeDian.Substring(1);
                }
            }
        }

        void CountArr()
        {
            int max = 0;
            int min = 0;
            if (intArt == intMax)
            {
                max++;
            }
            else if (intArt == intMin)
            {
                min++;
            }
            if (intBusiness == intMax)
            {
                max++;
            }
            else if (intBusiness == intMin)
            {
                min++;
            }
            if (intReality == intMax)
            {
                max++;
            }
            else if (intReality == intMin)
            {
                min++;
            }
            if (intSociety == intMax)
            {
                max++;
            }
            else if (intSociety == intMin)
            {
                min++;
            }
            if (intStudy == intMax)
            {
                max++;
            }
            else if (intStudy == intMin)
            {
                min++;
            }
            if (intTradition == intMax)
            {
                max++;
            }
            else if (intTradition == intMin)
            {
                min++;
            }

            arrTuiJianZhuanYe = new string[max];
            arrBuTuiJianZhuanYe = new string[min];
        }
    }
}