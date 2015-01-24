using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace GaoKao.CePing.nf
{
    public partial class Rports : UserBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!DAL.Comm.JCJH(user.StudentId))
            {
                //未激活用户
                Basic.MsgHelper.AlertUrlMsg("您还未激活，请使用激活卡激活账户，才能使用这些服务", "http://user.glenedu.net/UserCenter/Activate.aspx");
                return;
                //Response.Redirect("");
            }


            if (!IsPostBack)
            {
                HollandBind();

                PfBind();

                Profession();

                Ability();


                Student();
            }
        }

        #region   学生信息

        /// <summary>
        /// 学生信息
        /// </summary>
        void Student()
        {
            Entity.Join_Student model = DAL.Join_Student.Join_StudentEntityGet(this.user.StudentId);
            if (model != null)
            {
                if (model.StudentName != "")
                {
                    ltr_StudentName.Text = model.StudentName;
                   
                    return;

                }
                else
                {
                    ltr_StudentName.Text = model.StudentBank;
                }
            }
            else
            {
                ltr_StudentName.Text = this.user.StudentId.ToString();
            }
            
        }


        #endregion


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

        #region   性格测评

        void PfBind()
        {
            DataTable dt = DAL.Join_16PfResults.Join_16PfResultsList("[UserId]=" + this.user.StudentId);
            if (dt != null && dt.Rows.Count > 0)
            {
                DataTable newDt = new DataTable();

                ltr_A.Text = dt.Rows[0]["A_type"].ToString();
                ltr_B.Text = dt.Rows[0]["B_type"].ToString();
                ltr_C.Text = dt.Rows[0]["C_type"].ToString();
                ltr_E.Text = dt.Rows[0]["E_type"].ToString();
                ltr_F.Text = dt.Rows[0]["F_type"].ToString();
                ltr_G.Text = dt.Rows[0]["G_type"].ToString();
                ltr_H.Text = dt.Rows[0]["H_type"].ToString();
                ltr_I.Text = dt.Rows[0]["I_type"].ToString();
                ltr_L.Text = dt.Rows[0]["L_type"].ToString();
                ltr_M.Text = dt.Rows[0]["M_type"].ToString();
                ltr_N.Text = dt.Rows[0]["N_type"].ToString();
                ltr_O.Text = dt.Rows[0]["O_type"].ToString();
                ltr_Q1.Text = dt.Rows[0]["Q1_type"].ToString();
                ltr_Q2.Text = dt.Rows[0]["Q2_type"].ToString();
                ltr_Q3.Text = dt.Rows[0]["Q3_type"].ToString();

                ltr_Q4.Text = dt.Rows[0]["Q4_type"].ToString();






                #region  性格
                Dictionary<string, float> dic = new Dictionary<string, float>();
                dic.Add("A_type", float.Parse(dt.Rows[0]["A_type"].ToString()));
                dic.Add("B_type", float.Parse(dt.Rows[0]["B_type"].ToString()));
                dic.Add("C_type", float.Parse(dt.Rows[0]["C_type"].ToString()));
                dic.Add("E_type", float.Parse(dt.Rows[0]["E_type"].ToString()));
                dic.Add("F_type", float.Parse(dt.Rows[0]["F_type"].ToString()));
                dic.Add("G_type", float.Parse(dt.Rows[0]["G_type"].ToString()));
                dic.Add("H_type", float.Parse(dt.Rows[0]["H_type"].ToString()));
                dic.Add("I_type", float.Parse(dt.Rows[0]["I_type"].ToString()));
                dic.Add("L_type", float.Parse(dt.Rows[0]["L_type"].ToString()));
                dic.Add("M_type", float.Parse(dt.Rows[0]["M_type"].ToString()));
                dic.Add("N_type", float.Parse(dt.Rows[0]["N_type"].ToString()));
                dic.Add("O_type", float.Parse(dt.Rows[0]["O_type"].ToString()));
                dic.Add("Q1_type", float.Parse(dt.Rows[0]["Q1_type"].ToString()));
                dic.Add("Q2_type", float.Parse(dt.Rows[0]["Q2_type"].ToString()));
                dic.Add("Q3_type", float.Parse(dt.Rows[0]["Q3_type"].ToString()));
                dic.Add("Q4_type", float.Parse(dt.Rows[0]["Q4_type"].ToString()));



                var result = from pair in dic

                             orderby pair.Value   //descending  

                             select pair;


                //KeyValuePair<string, int> pairs = result.i[result.Count()-1]; //返回最后一组元素，即排序最大的

                string[] array = new string[result.Count()];
                string[] varray = new string[result.Count()];
                int i = 0;
                foreach (KeyValuePair<string, float> pair in result)
                {
                    //排序后的结果
                    array[i] = pair.Key;

                    switch (pair.Key)
                    {
                        case "A_type":
                            if (pair.Value > 8.87f)
                            {
                                varray[i] = "1";
                            }
                            else
                            {
                                varray[i] = "0";
                            }
                            break;

                        case "B_type":
                            if (pair.Value > 8.17f)
                            {
                                varray[i] = "1";
                            }
                            else
                            {
                                varray[i] = "0";
                            }
                            break;
                        case "C_type":
                            if (pair.Value > 14.41f)
                            {
                                varray[i] = "1";
                            }
                            else
                            {
                                varray[i] = "0";
                            }
                            break;
                        case "E_type":
                            if (pair.Value > 11.41f)
                            {
                                varray[i] = "1";
                            }
                            else
                            {
                                varray[i] = "0";
                            }
                            break;
                        case "F_type":
                            if (pair.Value > 12.60f)
                            {
                                varray[i] = "1";
                            }
                            else
                            {
                                varray[i] = "0";
                            }
                            break;
                        case "G_type":
                            if (pair.Value > 12.60f)
                            {
                                varray[i] = "1";
                            }
                            else
                            {
                                varray[i] = "0";
                            }
                            break;
                        case "H_type":
                            if (pair.Value > 10.56f)
                            {
                                varray[i] = "1";
                            }
                            else
                            {
                                varray[i] = "0";
                            }
                            break;
                        case "I_type":
                            if (pair.Value > 10.49f)
                            {
                                varray[i] = "1";
                            }
                            else
                            {
                                varray[i] = "0";
                            }
                            break;
                        case "L_type":
                            if (pair.Value > 11.82f)
                            {
                                varray[i] = "1";
                            }
                            else
                            {
                                varray[i] = "0";
                            }
                            break;
                        case "M_type":
                            if (pair.Value > 12.51f)
                            {
                                varray[i] = "1";
                            }
                            else
                            {
                                varray[i] = "0";
                            }
                            break;
                        case "N_type":
                            if (pair.Value > 8.82f)
                            {
                                varray[i] = "1";
                            }
                            else
                            {
                                varray[i] = "0";
                            }
                            break;
                        case "O_type":
                            if (pair.Value > 10.64f)
                            {
                                varray[i] = "1";
                            }
                            else
                            {
                                varray[i] = "0";
                            }
                            break;
                        case "Q1_type":
                            if (pair.Value > 11.84f)
                            {
                                varray[i] = "1";
                            }
                            else
                            {
                                varray[i] = "0";
                            }
                            break;
                        case "Q2_type":
                            if (pair.Value > 12.86f)
                            {
                                varray[i] = "1";
                            }
                            else
                            {
                                varray[i] = "0";
                            }
                            break;
                        case "Q3_type":
                            if (pair.Value > 12.30f)
                            {
                                varray[i] = "1";
                            }
                            else
                            {
                                varray[i] = "0";
                            }
                            break;
                        case "Q4_type":
                            if (pair.Value > 11.12f)
                            {
                                varray[i] = "1";
                            }
                            else
                            {
                                varray[i] = "0";
                            }
                            break;
                        default:
                            break;

                    }


                    i++;
                }

                PfS(array[i - 1], varray[i - 1]);
                PfS(array[i - 2], varray[i - 2]);
                PfS(array[i - 3], varray[i - 3]);



                #endregion
            }
            else
            {
                Basic.MsgHelper.AlertUrlMsg("您的还未进行性格测试不能查看报告，请先测试", "/CePing/16PF/Default.aspx");
                return;
            }

        }


        /// <summary>
        /// 得到性格，前三名
        /// </summary>
        void PfS(string  XingGe,string  value)
        {
          string htmlString="   <div class=\"xingge\"> "
                +"<p style=\"color:#176fd9; font-size:20px; font-weight:bold;\">{Title}</p> "
                +"<p style=\"color:#979797; font-size:14px;\">{QingX}</p> "
                +"<p>{MiaoS}</p>"
            +"</div> " ;

          string Title = "";
          string QingX = "";
          string MiaoS = "";
          
        string[] gaofen=new string[16];
       
        gaofen[0] = "外向 、 热情 、 乐群 ， 适合从事需要时时应付人与人间的复杂情绪或行为问题 ， 而仍然能够保持其乐观的态度的工作，如培训师和营销员等工作；";
        gaofen[1] = "职明 ， 富有才识 ， 善于抽象思考 ， 通常学习能力强 ， 思考敏捷准确 ， 教育 、 文化水准较高，个人心身状态健康；适合从事有专长的专业或者管理工作。";
        gaofen[2] = "情绪稳定而成熟 ， 能面对现实 ， 适合从事管理工作 、 机械工程安装 、 推销 、 危机管理等等需要应付各种难题的工作。";
        gaofen[3] = "好强固执 ， 独立积极 ， 通常自视甚高 ， 自以为是 ， 可能非常地武断 ， 而时常驾驭不及自己的下级和个体 ， 并反抗有权势的领导等者 。 倾向成为领导 、 领袖及有地位有成就的人 。";
        gaofen[4] = "轻松兴奋 ， 随遇而安 ， 通常活泼 ， 愉快 、 健谈 。 更适合从事行政主管 、 人际竞争性的工作。";
        gaofen[5] = "有恒负责 ， 做事尽职 ， 通常细心周到 ， 有始有终 。 适合部门领导 、 业务管理和保卫工作。";
        gaofen[6] = "冒险敢为 ， 较少顾忌 ， 通常不掩饰 ， 不畏缩 ， 有敢作敢为的精神 ， 使他能经历艰辛而保持有刚毅力，有时注重向异性殷勤，常随年龄而增强，是团队领导必须具有的素质 。 适合从事危机管理等工作，倾向于适合从事领导管理等工作。";
        gaofen[7] = "敏感 ， 感情用事 ， 通常心肠软 ， 易受感动 ， 缺乏耐性与恒心 ， 不喜欢接近文化水平低的人和作笨重的工作 。 在团休活动中 ， 其不切实际的看法与行为常 常减低了团体的工作效率。适合从事设计、艺术类工作。";
        gaofen[8] = "怀疑 、 刚愎 、 固执己见 ， 通常多怀疑 ， 不信任别人 。 如果过分高 ， 达到 9 分 10 分 ，常常成事不足，败事有余。更适合从事行政工作和保安工作等。";
        gaofen[9] = "幻想的 ， 狂放不羁 ， 通常忽视生活的细节 ， 只以本身的动机 ， 当时的兴趣等主观因素为行为的出发点。适合从事艺术、写作及从事研究工作。";
        gaofen[10] = "精明能干，世故。适合从事研究、管理和工程师工作";
        gaofen[11] = "忧虑抑郁，烦恼自扰。通常觉得世道艰辛，人生不如意事常八九，甚至沮丧悲观 。时时有患得患失之感。自感不如人，也缺乏和人接近的勇气。";
        gaofen[12] = "自由的 、 批评激进 、 不拘泥于现实 。 高者通常喜欢考验一切现有的理想理论与现实 ，而予以新的评价 ， 不轻易判断是非 ， 企图了解较前进的思想与行为 。 可能广见多闻 ， 愿意充实自己的生活经验。适合行政主管、领导、研发工作。";
        gaofen[13] = "自立自强、当机立断。通常能够自作主张，独自完成自己的工作计划，不依赖人 ，也不受社会舆论的约束 ， 同样也无意控制或支配别人 ， 不嫌恶人 ， 但是也不需要别人的好感 。";
        gaofen[14] = "知己知彼 ， 自律严谨 。 高者通常言行一致 ， 能够合理的支配自己的感情行动 。 为人处世 ， 总能保持其自尊心 ， 赢得人的尊重 ， 有时却不免太固执成见 。 是具有领导能力的必要条件之一，是做好生产部门主管的重要素质。";
        gaofen[15] = "紧张闲扰，激动挣扎。高者通常缺乏耐心，心神不定，态度兴奋。时常感觉疲乏 ，又无法彻底摆脱以求宁静。在社群中，他对于人事一切都缺乏信念。每日生活战战兢兢 ， 而不能自已。不能在职业中发挥潜能的人多具高的该特点。";
      

        string[] difen = new string[16];

        difen[0] = "缄默 、 孤独 、 冷漠 ， 适合从事必须十分冷静严肃与正确才能圆满地完成任务的工作如机械操作、生产操作、机械工程师等工作。";
        difen[1] = "比较迟钝 ， 学识浅薄 ， 抽象思考能力弱 ， 通常对学习与理解能力不强 ， 不善于 “ 举一反三 ” ，迟钝的原因可能由于情绪不稳定等心理原因。从事例行琐碎工作，如打字员，能够不发生厌恶，久安其职。";
        difen[2] = "情绪激动，易生烦恼，不适合公司绝大部分工作。";
        difen[3] = "为人谦逊 、 顺从 、 通融 、 恭顺 ， 通常行为温顺 ， 迎合别人的意思 ， 也可能即使处在十全十美的境地，也有 “ 事事不如人 ” 之感，许多心理不健康的人都有这种消极的心情。";
        difen[4] = "严肃、审慎、冷静、寡言；适合从事实验工作如质检，或者生产工作。";
        difen[5] = "苟且敷衍 ， 缺乏奉公办事的精神 ， 通常缺乏较高的目标和理想 ， 对于人群社会似乎没有绝对的责任感 ， 甚至于有时不惜知法犯法 ， 不择手段以达到某一目的 。 因此 ， 他常常能有效解决实际问题。";
        difen[6] = "畏怯退缩，缺乏自信心，通常在人群中羞怯，有不自然的姿态，有强烈的自卑感 。不善于发言，更不愿和陌生人交谈。适合从事具体事物性工作。";
        difen[7] = "理智的，着重现实，自恃其力，常多以客观、坚强、独立的态度处理当前的问题 ，并不重视文化修养 ， 以及一些主观和感情用事的看法 ， 可能过分骄傲 ， 冷酷无情 。 适合从事工程师、研发员、统计师等工作。";
        difen[8] = "依赖随和 ， 易与人相处 ， 通常无猜忌 ， 不与人角逐竞争 。 在团体活动中 ， 重视团体福利，更适合从事工程师、工人等工作。";
        difen[9] = "现实，合乎成规，力求妥善合理，通常先要基本斟酌现实条件，而后决定取舍 , 不鲁莽从事。更适合从事需要实际、机警、脚踏实地的工作。";
        difen[10] = "坦白、直率、天真，通常思想单纯，感情用事。适合在一线从事具体工作。";
        difen[11] = "安详、沉着、有自信心。更适合电机工、管理等等工作。";
        difen[12] = "保守的 、 新生传统观念与行为标准 。 通常无条件地接受社会中许多相沿已久而有权威性的见解 ， 不愿尝试探求新的境界 。 常常激烈的反对新思潮以及一切新的变动 。 在政治与宗教信仰上，默守成规，可能被称为老顽固或时代的落伍者。";
        difen[13] = "依赖、随附合。通常宁欲与人共同工作，而不愿独立孤行。常常放弃个人的主见 ，附合众议，以取得别人的好感。需要团体的支持以维持其自信心，却并非真正的乐群者 。 多不能胜任需要随机应变能力的职务。";
        difen[14] = "矛盾冲突 ， 不顾大体 ， 通常既不能克制自己 ， 又不能尊重礼俗 ， 更不愿考虑别人的需要，充满矛盾，却无法解决，生活适应有问题者多有低 Q 3 。";
        difen[15] = "心平气和，闲散宁静。低者通常知足常乐，保持内心的平衡。也可能过份疏懒 ， 缺乏进取心。";


          switch (XingGe)
          {
              case "A_type":    //艺术性
                  if (value =="0")
                  {

                      MiaoS = difen[0];
                      QingX = "";
                      Title = "低乐群性";
                  }
                  else
                  {
                      MiaoS = gaofen[0];
                      QingX = "";
                      Title = "高乐群性";
                  }

                  break;
              case "B_type":    //艺术性
                  if (value == "0")
                  {

                      MiaoS = difen[1];
                      QingX = "";
                      MiaoS = "低聪慧性";
                  }
                  else
                  {
                      MiaoS = gaofen[1];
                      Title = "";
                      Title = "高聪慧性";
                  }

                  break;
              case "C_type":    //艺术性
                  if (value == "0")
                  {

                      MiaoS = difen[2];
                      QingX = "";
                      Title = "低稳定性";
                  }
                  else
                  {
                      MiaoS = gaofen[2];
                      QingX = "";
                      Title = "高稳定性";
                  }

                  break;
              case "E_type":    //艺术性
                  if (value == "0")
                  {

                      MiaoS = difen[3];
                      QingX = "";
                      Title = "低特强性";
                  }
                  else
                  {
                      MiaoS = gaofen[3];
                      QingX = "";
                      Title = "高特强性";
                  }

                  break;
              case "F_type":    //艺术性
                  if (value == "0")
                  {

                      MiaoS = difen[4];
                      QingX = "";
                      Title = "低兴奋性";
                  }
                  else
                  {
                      MiaoS = gaofen[4];
                      QingX = "";
                      Title = "高兴奋性";
                  }

                  break;
              case "G_type":    //艺术性
                  if (value == "0")
                  {

                      MiaoS = difen[5];
                      QingX = "";
                      Title = "低有恒性";
                  }
                  else
                  {
                      MiaoS = gaofen[5];
                      QingX = "";
                      Title = "高有恒性";
                  }

                  break;
              case "H_type":    //艺术性
                  if (value == "0")
                  {

                      MiaoS = difen[6];
                      QingX = "";
                      Title = "低敢为者";
                  }
                  else
                  {
                      MiaoS = gaofen[6];
                      QingX = "";
                      Title = "高敢为者";
                  }

                  break;
              case "I_type":    //艺术性
                  if (value == "0")
                  {

                      MiaoS = difen[7];
                      QingX = "";
                      Title = "低敏感性";
                  }
                  else
                  {
                      MiaoS = gaofen[7];
                      QingX = "";
                      Title = "高敏感性";
                  }

                  break;
              case "L_type":    //艺术性
                  if (value == "0")
                  {

                      MiaoS = difen[8];
                      QingX = "";
                      Title = "低怀疑性";
                  }
                  else
                  {
                      MiaoS = gaofen[8];
                      QingX = "";
                      Title = "高怀疑性";
                  }

                  break;
              case "M_type":    //艺术性
                  if (value == "0")
                  {

                      MiaoS =difen[9];
                      QingX = "";
                      Title = "低幻想性";
                  }
                  else
                  {
                      MiaoS = gaofen[9];
                      QingX = "";
                      Title = "高幻想性";
                  }

                  break;
              case "N_type":    //艺术性
                  if (value == "0")
                  {

                      MiaoS =difen[10];
                      QingX = "";
                      Title = "低世故性";
                  }
                  else
                  {
                      MiaoS = gaofen[10];
                      QingX = "";
                      Title = "高世故性";
                  }

                  break;
              case "O_type":    //艺术性
                  if (value == "0")
                  {

                      MiaoS = difen[11];
                      QingX = "";
                      Title = "低忧虑性";
                  }
                  else
                  {
                      MiaoS = gaofen[11];
                      QingX = "";
                      Title = "高忧虑性";
                  }

                  break;
              case "Q1_type":    //艺术性
                  if (value == "0")
                  {

                      MiaoS =difen[12];
                      QingX = "";
                      Title = "低实验性";
                  }
                  else
                  {
                      MiaoS = gaofen[12];
                      QingX = "";
                      Title = "高实验性";
                  }

                  break;
              case "Q2_type":    //艺术性
                  if (value == "0")
                  {

                      MiaoS = difen[13];
                      QingX = "";
                      Title = "低独立性";
                  }
                  else
                  {
                      MiaoS = gaofen[13];
                      QingX = "";
                      Title = "高独立性";
                  }

                  break;
              case "Q3_type":    //艺术性
                  if (value == "0")
                  {

                      MiaoS = difen[14];
                      QingX = "";
                      Title = "低自律性";
                  }
                  else
                  {
                      MiaoS = gaofen[14];
                      QingX = "";
                      Title = "高自律性";
                  }

                  break;
              case "Q4_type":    //艺术性
                  if (value == "0")
                  {

                      MiaoS = difen[15];
                      QingX = "";
                      Title = "低紧张性";
                  }
                  else
                  {
                      MiaoS = gaofen[15];
                      QingX = "";
                      Title = "高紧张性";
                  }

                  break;
          }


          htmlString = htmlString.Replace("{Title}", Title);
          htmlString = htmlString.Replace("{QingX}", QingX);
          htmlString = htmlString.Replace("{MiaoS}", MiaoS);


          ltr_16pf.Text += htmlString;
        }


        #endregion

        #region 职业价值观测试

        void Profession()
        {
            DataTable dt = DAL.Join_ProfessionResults.Join_ProfessionResultsList("[UserId]=" + this.user.StudentId);


            if (dt != null && dt.Rows.Count > 0)
            {

                ltr_Group1.Text = dt.Rows[0]["Group1"].ToString();
                ltr_Group2.Text = dt.Rows[0]["Group2"].ToString();
                ltr_Group3.Text = dt.Rows[0]["Group3"].ToString();
                ltr_Group4.Text = dt.Rows[0]["Group4"].ToString();
                ltr_Group5.Text = dt.Rows[0]["Group5"].ToString();
                ltr_Group6.Text = dt.Rows[0]["Group6"].ToString();
                ltr_Group7.Text = dt.Rows[0]["Group7"].ToString();
                ltr_Group8.Text = dt.Rows[0]["Group8"].ToString();

                ltr_Group9.Text = dt.Rows[0]["Group9"].ToString();
                ltr_Group10.Text = dt.Rows[0]["Group10"].ToString();

                ltr_Group11.Text = dt.Rows[0]["Group11"].ToString();
                ltr_Group12.Text = dt.Rows[0]["Group12"].ToString();
                ltr_Group13.Text = dt.Rows[0]["Group13"].ToString();

            }
            else
            {

                Basic.MsgHelper.AlertUrlMsg("您的还未进行职业价值观测试，请先测试", "/CePing/Holland/Default.aspx");
                return;
            }
        }
        #endregion

                                   
        #region  职业能力测试

        void Ability()
        {
            DataTable dt = DAL.Join_AbilityResults.Join_AbilityResultsList("UserId=" + this.user.StudentId);


            if (dt != null && dt.Rows.Count > 0)
            {
                ltr_Language.Text = dt.Rows[0]["Language"].ToString();
                ltr_Tissue.Text = dt.Rows[0]["Tissue"].ToString();
                ltr_Among.Text = dt.Rows[0]["Among"].ToString();
                ltr_Mathematics.Text = dt.Rows[0]["Mathematics"].ToString();
                ltr_Motion.Text = dt.Rows[0]["Motion"].ToString();
                ltr_Writing.Text = dt.Rows[0]["Writing"].ToString();
                ltr_Watch.Text = dt.Rows[0]["Watch"].ToString();
                ltr_Space.Text = dt.Rows[0]["Space"].ToString();
                ltr_Art.Text = dt.Rows[0]["Art"].ToString();
            }
            else
            {
                Basic.MsgHelper.AlertUrlMsg("您的还未进行职业价值观测试，请先测试", "/CePing/Holland/Default.aspx");
                return;
            }

        }
        #endregion
    }
}