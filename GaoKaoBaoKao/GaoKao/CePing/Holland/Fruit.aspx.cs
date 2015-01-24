using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace GaoKao.CePing.GLGKZYXZ.Holland
{
    public partial class Fruit : UserBase
    {

        //是否是会员
        protected bool isMember = true;

        protected void Page_Load(object sender, EventArgs e)
        {
            //   this.user = new Entity.Join_Student();
            //  this.user.StudentId = 1;
            if (!IsPostBack)
            {
                HollandBind();
                isMember = DAL.Comm.JCJH(user.StudentId);

                diji.Visible = isMember;
                //是会员了才显示第四部分
                if (userinfo.StudentLevel > 1)
                {
                    panel1.Visible = true;
                }

            }
        }

        #region 职业兴趣测评

        //职业兴趣测评
        void HollandBind()
        {

            #region  职业兴趣测评


            DataTable dt = DAL.Join_HollandResults.Join_HollandResultsList("[UserId]=" + this.user.StudentId);
            if (dt != null && dt.Rows.Count > 0)
            {
                //
                lb_Art.Text = dt.Rows[0]["Art"].ToString();
                lb_Business.Text = dt.Rows[0]["Business"].ToString();
                lb_Reality.Text = dt.Rows[0]["Reality"].ToString();
                lb_Society.Text = dt.Rows[0]["Society"].ToString();
                lb_Study.Text = dt.Rows[0]["Study"].ToString();
                lb_Tradition.Text = dt.Rows[0]["Tradition"].ToString();
            }
            else
            {

                Basic.MsgHelper.AlertUrlMsg("您的职业兴趣还未进行测试，请先测试", "/CePing/Holland/Default.aspx");
                return;
            }


            //类型，所属类型，得到最大的


            Dictionary<string, int> dic = new Dictionary<string, int>();
            dic.Add("Art", int.Parse(dt.Rows[0]["Art"].ToString()));
            dic.Add("Business", int.Parse(dt.Rows[0]["Business"].ToString()));
            dic.Add("Reality", int.Parse(dt.Rows[0]["Reality"].ToString()));
            dic.Add("Society", int.Parse(dt.Rows[0]["Society"].ToString()));
            dic.Add("Study", int.Parse(dt.Rows[0]["Study"].ToString()));
            dic.Add("Tradition", int.Parse(dt.Rows[0]["Tradition"].ToString()));


            var result = from pair in dic

                         orderby pair.Value   //descending  

                         select pair;


            KeyValuePair<string, int> pairs = result.Last(); //返回最后一组元素，即排序最大的

            //根据数组里边的，判断是什么类型多一点，然后输出相关类型
            string[] holland = { "Art", "Business", "Reality", "Society", "Study", "Tradition" };
            for (int i = 0; i < holland.Length; i++)
            {
                if (holland[i] == pairs.Key)
                {
                    if (i != 0 && i != (holland.Length - 1))
                    {
                        //如果不在数组的两边则有上下文
                        //根据上下文得出主类型和相关类型
                        lb_Holland.Text += HollandCode(holland[i - 1]) + "-";
                        lb_Holland.Text += HollandCode(holland[i]) + "-";
                        lb_Holland.Text += HollandCode(holland[i + 1]);
                    }
                    else if (i == 0)
                    {
                        lb_Holland.Text += HollandCode(holland[holland.Length - 1]) + "-";
                        lb_Holland.Text += HollandCode(holland[i]) + "-";
                        lb_Holland.Text += HollandCode(holland[i + 1]);
                    }
                    else
                    {
                        lb_Holland.Text += HollandCode(holland[i - 1]) + "-";
                        lb_Holland.Text += HollandCode(holland[i]) + "-";
                        lb_Holland.Text += HollandCode(holland[0]);
                    }


                    //类型
                    HollandName();
                }
                else
                {
                    continue;
                }
            }

            #endregion
        }

        /// <summary>
        /// 职业兴趣名
        /// </summary>
        /// <param name="holland"></param>
        /// <returns></returns>

        string HollandCode(String holland)
        {

            switch (holland)
            {
                case "Art":    //艺术性
                    return "A";

                case "Business":  //企业型
                    return "E";

                case "Reality":   //现实型
                    return "R";

                case "Study":  // 研究型
                    return "I";

                case "Society": //社会
                    return "S";

                case "Tradition"://常规
                    return "C";

                default:
                    return string.Empty;

            }


        }



        /// <summary>
        /// 得到类型的名字
        /// </summary>
        /// <param name="hollandcode"></param>
        /// <returns></returns>
        string HollandName(String hollandcode)
        {

            switch (hollandcode)
            {
                case "a":    //艺术性
                    return "艺术型";

                case "e":  //企业型
                    return "企业型";

                case "r":   //现实型
                    return "现实型";

                case "i":  // 研究型
                    return "研究型";

                case "s": //社会
                    return "社会型";

                case "c"://常规
                    return "传统型";

                default:
                    return string.Empty;

            }
        }

        void HollandAbout(string hollandcode)
        {
            string htmlString = "<div class=\"shehui\"> "
                       + "<div class=\"{CssTop}\">{Title}</div> "
                    + " <p> {Content}</p>"
                 + "<p style=\"COLOR: #ff9900; text-indent: inherit;\">职业偏好：</p>"
                 + "<p>{PianH}</p>"
                + "<p style=\"COLOR: #ff9900; text-indent: inherit;\">可能喜欢的职业：</p>"
                + " <p>{ZhiY}</p>"
                + " </div>  ";

            string Title = "";
            string PianH = "";
            string ZhiY = "";
            string CssTop = "";
            string Content = "";

            switch (hollandcode)
            {
                case "a":    //艺术性
                    Title = "艺术性（A）";
                    Content = "喜欢艺术性的工作，如：音乐、舞蹈、唱歌、演员、艺术家、美术家、音乐家、设计师、编辑、作家和文艺评论家等。这种取向类型的人往往具有某些艺术上的技能，喜欢创造性的工作，富于想象力。这类人通常喜欢同观念而不是事务打交道的工作。他们较开放、好想象、独立、有创造性。";    // 艺术型
                    ZhiY = "艺术类、文学类、设计类等。如：演员、导演、主持人、艺术设计师、雕刻家、建筑师、摄影家、广告制作人、歌唱家、作曲家、乐队指挥、小说家、诗人、剧作家等。";
                    CssTop = "top1";
                    PianH = "喜欢从事具备艺术修养、创造力、表达能力和直觉的工作，并具备艺术鉴赏等能力，不善于事务性工作。";
                    break;

                case "e":  //企业型

                    Title = "企业型（E）";
                    Content = "喜欢诸如推销、服务、管理、企事业领导、经理、商业主任、销售员和人寿保险员等。这类人通常具有领导才能和口才，对金钱和权利感兴趣，喜欢影响、控制别人。这种人喜欢同人和观念而不是事务打交道的工作。他们爱户外交际、冒险、精力充沛、乐观、和蔼、细心、抱负心强。";    // 企业型
                    ZhiY = "管理类、销售类、司法类、政治类等工作。如企业家、管理者、商人、项目经理、销售人员，营销管理人员、政府官员、法官、律师等。";
                    CssTop = "top2";
                    PianH = "喜欢从事经营管理、领导、监督的工作，并以实现机构、社会及组织的利益为目标。";
                    break;

                case "r":   //现实型
                    Title = "现实型（R）";
                    Content = "喜欢现实性的实在的工作，如机械维修、木匠活、烹饪、电气技术、管子工、电工、机械工、摄影师、制图员等，也称“体能取向”、“机械取向”。这类人通常具有机械技能和体力，喜欢户外工作，乐于使用各种工具和机器设备。这种人喜欢同事务而不是人打交道的工作。他们真诚、谦逊、敏感、务实、朴素、节俭、腼腆。";   //现实型
                    ZhiY = "机械电子类、土木建筑类、农业类、体育类等。如：计算机硬件人员、工程师、机械师、技术员、制图员、测绘员、维修人员、安装人员、鱼类和野生动物专家、体育教练等。";
                    CssTop = "top3";
                    PianH = "喜欢使用工具、机器，需要基本操作技能的工作。对要求具备机械方面才能、体力或从事与物件、机器、工具、运动器材、植物、动物相关的职业有兴趣，并具备相应能力。";
                    break;

                case "i":  // 研究型
                    Title = "研究型（I）";
                    Content = "喜欢各种研究型工作，如：实验室研究员、医师、产品检验员、数学、物理学、化学、生物学等自然科学研究者、图书馆技师、计算机程序编制者和电子技术工作者等等。这类人通常具有较高的数学和科研能力，喜欢独立工作，喜欢解决问题；喜欢同观念而不是人或事务打交道。他们逻辑性强、好奇、聪明、仔细、独立、安详、俭朴。";    // 研究型
                    ZhiY = " 研究类，科学研究和科学实验工作。如：自然科学和社会科学方面的研究人员、教师、工程师、电脑编程人员、医生、系统分析员、飞机驾驶员等。";
                    CssTop = "top4";
                    PianH = "你喜欢需要抽象分析的任务，更喜欢与数据和概念打交道。你具备智力或分析才能，并能将这种才能用于观察、估测、衡量、形成理论和解决问题。";
                    break;

                case "s": //社会
                    Title = "社会型（S）";
                    Content = "喜欢社会交往性工作，如教师、教育行政人员、社会学家、社会工作者、咨询顾问、护士等。这类人通常喜欢周围有别人存在，对别人的事很有兴趣，乐于帮助别人解决难题。这种人喜欢与人而不是事务打交道的工作。他们助人为乐、有责任心、热情、善于合作、富于理想、友好、善良、慷慨、耐心。";    // 社会型
                    ZhiY = "为他人服务的工作，教育类、社会类、医疗类等。如：教师、行政人员、咨询人员、公关人员、福利人员、医护人员、服务人员等。";
                    CssTop = "top5";
                    PianH = "喜欢与人打交道，能够不断结交新的朋友，倾向于从事提供信息、启迪、帮助、培训、开发或治疗等事务，并具备相应能力。";
                    break;

                case "c"://常规
                    Title = "传统型（C）";
                    Content = "喜欢传统性的工作，如：记账、秘书、办事员，以及测算办公室人员、接待员、文件档案管理员、秘书、打字员、会计、出纳员等工作。这种人有很好的数字和计算能力，喜欢室内工作，乐于整理、安排事务。他们往往喜欢同文字、数字打交道的工作，比较顺从、务实、细心、节俭、做事利索、很有条理性、有耐性。";    // 常规型
                    ZhiY = " 银行、金融、会计、秘书等相关工作。如：秘书、办公室人员、记事员、会计、行政助理、图书馆管理员、出纳员、打字员、理财投资分析员、人事职员等。";
                    CssTop = "top6";
                    PianH = "你喜欢从事注重细节、精确度高、有系统、有条理的工作，具有良好的记忆力，擅于记录、归档、处理数据和文字信息等事务性工作。";
                    break;

                default:
                    break;

            }

            htmlString = htmlString.Replace("{Title}", Title);
            htmlString = htmlString.Replace("{Content}", Content);
            htmlString = htmlString.Replace("{PianH}", PianH);
            htmlString = htmlString.Replace("{ZhiY}", ZhiY);
            htmlString = htmlString.Replace("{CssTop}", CssTop);

            ltr_Holland.Text += htmlString;

        }

        void HollandName()
        {
            string a = lb_Holland.Text;
            foreach (string st in a.Split('-'))
            {
                lb_HollandName.Text += HollandName(st.ToLower()) + "-";
                HollandAbout(st.ToLower());
            }

            if (lb_HollandName.Text.EndsWith("-"))
            {
                lb_HollandName.Text = lb_HollandName.Text.Remove(lb_HollandName.Text.Length - 1, 1);
            }
        }

        #endregion
    }
}