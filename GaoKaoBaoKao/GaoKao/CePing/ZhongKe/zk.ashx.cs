using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GaoKao.CePing.ZhongKe
{
    /// <summary>
    /// zk 的摘要说明
    /// </summary>
    public class zk : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            var rq = context.Request;
            if (rq.QueryString["kl"] != null)
            {
                string kl = rq.QueryString["kl"];
                //索引顺序
                //学习力： 学习被动值、厌学度、生动累信息采集量、学习比较性、学习方法、学习自检性、参与渠道
                //生存能力：分析力、自控自能力、社会沟通能力、主动思维能力、责任承担能力

                string[] st = kl.Split(',');
                int[] istGood = new int[st.Length];

                for (int i = 0; i < st.Length; i++)
                {
                    istGood[i] = Basic.TypeConverter.StrToInt(st[i],0);
                }

               string[,] G_1=new string[3,3];
               string[,] G_2 = new string[3, 3];
               string[,] G_3 = new string[3, 3];
               string[,] G_4 = new string[3, 3];
               string[,] G_5 = new string[3, 3];
               string[,] G_6 = new string[3, 3];
               string[,] G_7 = new string[3, 3];
               string[,] G_8 = new string[3, 3];
               string[,] G_9 = new string[3, 3];
               string[,] G_10 = new string[3, 3];
               string[,] G_11 = new string[3, 3];
               string[,] G_12 = new string[3, 3];

               //由差到好
               G_1[0, 0] = "孩子的学习主动性较高，说明孩子愿意学习，应继续保持。并且可以在日常多进行和孩子学习方面的探讨，让孩子习惯和父母商量遇到的学习问题的解决方法。";
               G_1[0, 1] = "孩子的会把学习当成自己自己的事，学习态度基本端正，需要注意的事，不要让孩子只关注学习，而是通过在家庭中的分担，继续让孩子保持对于特定环境的关注，继续保持学习主动性";
               G_1[0, 2] = "孩子的具有一定的学习兴趣，需要注意的是，当孩子知道学习自己的事的前提，不要再“不识趣”反复强调学习的重要性和自主性，也不要因为孩子可能出现的一两次“倦怠”而大发雷霆，而是和他一起解决问题。";
               G_1[1, 0] = "孩子处于“我要学”和“要我学”的交界处，知道自己要学习，但是却会反复，家长应该增强和孩子的沟通，找到孩子学习过程碰到的问题，不是指责而是帮助解决。";
               G_1[1, 1] = "关注孩子的情绪，当孩子出现情绪波动从而影响学习状态的时候，选择和孩子好好谈谈心，站在他的角度去理解他，让他慢慢习惯向遇到问题想父母求助。";
               G_1[1, 2] = "学会使用“承认+怎么办+方法”的方式处理孩子的问题，先跟后带，引导孩子降低对于学习的被动值。";
               G_1[2, 0] = "说十遍“你要学”不如孩子自己说“我要学”，指出孩子的十个问题不如帮孩子解决一个问题，家长的身份不是老师，不是提出要求，而是陪孩子一起面对、解决，每个孩子天生的都是热爱学习的，除了督促，记得鼓励！";
               G_1[2, 1] = "改变和孩子的沟通方式，从生活的事情入手，改善和孩子的沟通关系，先成为孩子依赖和信任的父母，再成为教导孩子的老师。";
               G_1[2, 2] = "坚决不要使用“交易式沟通”，即不要用好吃的、好玩的、钱作为和孩子交换成绩的筹码，因为学习是孩子自己的事，成绩好坏最受影响的是他自己，而非父母，而不是某件“筹码”的得失";

            }


        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}