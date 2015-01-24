<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Fruit.aspx.cs" Inherits="GaoKao.CePing.ZhongKe.Fruit1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>学习力测评</title>
    <link href="../css/style.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../js/jquery-1.4.2.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div style="display: none;">
        <div class="daoyu">
            <br />
            <br />
            <div class="t">
                <div class="p1">
                    <p>
                        孩子的职业兴趣类型为</p>
                    <p>
                        <%=lb_HollandName.Text %></p>
                </div>
                <div class="p2">
                    <asp:Literal ID="lb_Holland" runat="server"></asp:Literal></div>
            </div>
        </div>
        <a class="noprint" onclick="$('#xingqu').show('slow')" href="javascript:void(0)">文字说明请点开查看</a>
        <div id="xingqu" style="display: block;">
            <table class="table1" border="1" cellspacing="0" bordercolor="#00ff00" cellpadding="5"
                width="830">
                <tbody>
                    <tr class="odd">
                        <th width="12%">
                            性格类型
                        </th>
                        <th width="7%">
                            代码
                        </th>
                        <th width="27%">
                            爱好
                        </th>
                        <th width="27%">
                            工作活动
                        </th>
                        <th width="27%">
                            潜能要求
                        </th>
                    </tr>
                    <tr class="even">
                        <td>
                            现实型
                        </td>
                        <td>
                            R
                        </td>
                        <td style="text-align: left">
                            机械，计算机网络，<br>
                            体育运动，户外工作
                        </td>
                        <td style="text-align: left">
                            操作设备，使用工具，<br>
                            建筑，修理，保安
                        </td>
                        <td style="text-align: left">
                            机械灵活性，身体协调
                        </td>
                    </tr>
                    <tr class="odd">
                        <td>
                            艺术型
                        </td>
                        <td>
                            A
                        </td>
                        <td style="text-align: left">
                            自我表现，艺术鉴赏，<br>
                            沟通，文化
                        </td>
                        <td style="text-align: left">
                            作曲，表演，写作，<br>
                            视觉艺术
                        </td>
                        <td style="text-align: left">
                            创造力，音乐能力，<br>
                            艺术表演
                        </td>
                    </tr>
                    <tr class="even">
                        <td>
                            研究型
                        </td>
                        <td>
                            I
                        </td>
                        <td style="text-align: left">
                            科学，医学，数学，研究
                        </td>
                        <td style="text-align: left">
                            实验室工作，<br>
                            解决抽象问题，管理研究
                        </td>
                        <td style="text-align: left">
                            数学能力，研究，写作<br>
                            ，分析
                        </td>
                    </tr>
                    <tr class="odd">
                        <td>
                            社会型
                        </td>
                        <td>
                            S
                        </td>
                        <td style="text-align: left">
                            人际关系，团队合作，<br>
                            助人，社区服务
                        </td>
                        <td style="text-align: left">
                            教学，管理，说服他人，<br>
                            市场营销
                        </td>
                        <td style="text-align: left">
                            人际技能，语言能力，<br>
                            倾听能力，理解能力
                        </td>
                    </tr>
                    <tr class="even">
                        <td>
                            企业型
                        </td>
                        <td>
                            E
                        </td>
                        <td style="text-align: left">
                            商业，政治，领导，<br>
                            企业家地位
                        </td>
                        <td style="text-align: left">
                            销售，管理，说服他人，<br>
                            市场营销
                        </td>
                        <td style="text-align: left">
                            语言能力，<br>
                            激励与指导他人的能力
                        </td>
                    </tr>
                    <tr class="odd">
                        <td>
                            常规型
                        </td>
                        <td>
                            C
                        </td>
                        <td style="text-align: left">
                            组织，数据管理，会计，<br>
                            投资，信息系统
                        </td>
                        <td style="text-align: left">
                            设置程序和系统，组织，<br>
                            记录，计算机软件开发
                        </td>
                        <td style="text-align: left">
                            数字运算能力，<br>
                            数据分析能力，<br>
                            金融，细节关注
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
        <div class="daoyu">
            <div class="page2">
                <b>职 业 兴 趣 类 型</b></div>
            <div class="t1">
                测验分数表明您的孩子属于：<asp:Label ID="lb_HollandName" runat="server"></asp:Label></div>
        </div>
        <asp:Literal ID="ltr_Holland" runat="server"></asp:Literal>
    </div>
    <div class="mbtitu hightu1">
        学习力和生存能力</div>
    <div class="hightu2">
        测评报告</div>
    <div class="mbtitu3">
    </div>
    <div class="contants">
        <div class="tit1 tit4">
            学习力测评报告</div>
        <div class="tab1">
        </div>
    </div>
    <div class="contants">
    

        <table width="1000" align="center" cellpadding="4" class="tab6">
            <tr>
                <th width="619" valign="top" colspan="4">
                    <p>
                        学习力测评结果
                    </p>
                </th>
            </tr>
            <tr>
                <td width="163" valign="top">
                    <p>
                        项目
                    </p>
                </td>
                <td width="72" valign="top">
                    <p>
                        分数
                    </p>
                </td>
                <td width="84" valign="top">
                    <p>
                        评价
                    </p>
                </td>
                <td width="300" valign="top">
                    <p>
                        建议
                    </p>
                </td>
            </tr>
            <tr>
                <td width="163" valign="top">
                    <p>
                        学习被动值
                    </p>
                </td>
                <td width="72" valign="bottom">
                    <p>
                        <asp:Label ID="beidong" runat="server" CssClass="fen"></asp:Label>
                    </p>
                </td>
                <td width="84" valign="top">
                    <p>
                    </p>
                </td>
                <td width="300" valign="top">
                </td>
            </tr>
            <tr>
                <td width="163" valign="top">
                    <p>
                        厌学度
                    </p>
                </td>
                <td width="72" valign="bottom">
                    <p>
                        <asp:Label ID="yanxue" runat="server" CssClass="fen"></asp:Label>
                    </p>
                </td>
                <td width="84" valign="top">
                    <p>
                    </p>
                </td>
                  <td width="300" valign="top">
                </td>
            </tr>
            <tr>
                <td width="163" valign="top">
                    <p>
                        生动类信息采集量
                    </p>
                </td>
                <td width="72" valign="bottom">
                    <p>
                        <asp:Label ID="caiji" runat="server" CssClass="fen"></asp:Label>
                    </p>
                </td>
                <td width="84" valign="top">
                    <p>
                    </p>
                </td>
                  <td width="300" valign="top">
                </td>
            </tr>
            <tr>
                <td width="163" valign="top">
                    <p>
                        学习比较性
                    </p>
                </td>
                <td width="72" valign="bottom">
                    <p>
                        <asp:Label ID="bijiao" runat="server" CssClass="fen"></asp:Label>
                    </p>
                </td>
                <td width="84" valign="top">
                    <p>
                    </p>
                </td>
                  <td width="300" valign="top">
                </td>
            </tr>
            <tr>
                <td width="163" valign="top">
                    <p>
                        学习方法
                    </p>
                </td>
                <td width="72" valign="bottom">
                    <p>
                        <asp:Label ID="fangfa" runat="server" CssClass="fen"></asp:Label>
                    </p>
                </td>
                <td width="84" valign="top">
                    <p>
                    </p>
                </td>
                  <td width="300" valign="top">
                </td>
            </tr>
            <tr>
                <td width="163" valign="top">
                    <p>
                        学习自检性
                    </p>
                </td>
                <td width="72" valign="bottom">
                    <p>
                        <asp:Label ID="zijian" runat="server" CssClass="fen"></asp:Label>
                    </p>
                </td>
                <td width="84" valign="top">
                    <p>
                    </p>
                </td>
                  <td width="300" valign="top">
                </td>
            </tr>
            <tr>
                <td width="163" valign="top">
                    <p>
                        参与渠道
                    </p>
                </td>
                <td width="72" valign="bottom">
                    <p>
                        <asp:Label ID="qudao" runat="server" CssClass="fen"></asp:Label>
                    </p>
                </td>
                <td width="84" valign="top">
                    <p>
                    </p>
                </td>
                  <td width="300" valign="top">
                </td>
            </tr>
            <tr>
                <td width="619" valign="top" colspan="4">
                    <p>
                        <strong>一些名词解释： </strong>
                    </p>
                    <p>
                        <strong>学习比较性：</strong>对于自己的和他人的学习的关注、比较度。比如是否在意、关注同学的成绩学习等。
                    </p>
                    <p>
                        <strong>学习自检性：</strong>对于已学过的东西会不会思考该怎么办才更好。比如考试是否只关心分数，不会去想错误的题该怎么修正、自己该怎么提升的问题。
                    </p>
                    <p>
                        <strong>参与渠道：</strong>学习中使用的方式是否多样化。比如：学习时是否只是静静地看、听，而不会用手去画、去写、用嘴大声地读。
                    </p>
                </td>
            </tr>
        </table>
          <table width="1000" align="center" cellpadding="4" class="tab6">
            <tr>
                <th width="619" valign="top" colspan="4">
                    <p>
                        生存能力测评结果
                    </p>
                </th>
            </tr>
            <tr>
                <td width="163" valign="top">
                    <p>
                        项目
                    </p>
                </td>
                <td width="72" valign="top">
                    <p>
                        分数
                    </p>
                </td>
                <td width="84" valign="top">
                    <p>
                        评价
                    </p>
                </td>
                <td width="300" valign="top">
                    <p>
                        建议
                    </p>
                </td>
            </tr>
            <tr>
                <td width="163" valign="top">
                    <p>
                        分析能力
                    </p>
                </td>
                <td width="72" valign="bottom">
                    <p>
                        <asp:Label ID="fenxi" runat="server" CssClass="fen"></asp:Label>
                    </p>
                </td>
                <td width="84" valign="top">
                    <p>
                    </p>
                </td>
                <td width="300" valign="top"  >
                 
                </td>
            </tr>
            <tr>
                <td width="163" valign="top">
                    <p>
                        自控自抑能力
                    </p>
                </td>
                <td width="72" valign="bottom">
                    <p>
                        <asp:Label ID="zikong" runat="server" CssClass="fen"></asp:Label>
                    </p>
                </td>
                <td width="84" valign="top">
                    <p>
                    </p>
                </td>
                  <td width="300" valign="top">
                </td>
            </tr>
            <tr>
                <td width="163" valign="top">
                    <p>
                        社会沟通能力
                    </p>
                </td>
                <td width="72" valign="bottom">
                    <p>
                        <asp:Label ID="goutong" runat="server" CssClass="fen"></asp:Label>
                    </p>
                </td>
                <td width="84" valign="top">
                    <p>
                    </p>
                </td>
                  <td width="300" valign="top">
                </td>
            </tr>
            <tr>
                <td width="163" valign="top">
                    <p>
                        主动思维能力
                    </p>
                </td>
                <td width="72" valign="bottom">
                    <p>
                        <asp:Label ID="siwei" runat="server" CssClass="fen"></asp:Label>
                    </p>
                </td>
                <td width="84" valign="top">
                    <p>
                    </p>
                </td>
                 <td width="300" valign="top">
                </td>
            </tr>
            <tr>
                <td width="163" valign="top">
                    <p>
                        责任承担能力
                    </p>
                </td>
                <td width="72" valign="bottom">
                    <p>
                        <asp:Label ID="chengdan" runat="server" CssClass="fen"></asp:Label>
                    </p>
                </td>
                <td width="84" valign="top">
                    <p>
                    </p>
                </td>
                  <td width="300" valign="top">
                </td>
            </tr>
            
            
        </table>
    </div>
    <asp:Panel ID="Panel1" runat="server">
        <div class="contants"  style=" display:none;">
            <p>
                <strong>1.</strong> 结合以上测评表综合来看，孩子在学习过程中的被动值<strong class="beidong">中等</strong>，并且已经有了<strong
                    class="yanxue">较高</strong>程度的厌学情绪。</p>
            <p>
                <strong>2.</strong> 孩子的学习比较性<strong class="bijiao">一般</strong>，学习自检<strong class="zijian">较差</strong>，<span
                    class="bijiao_ds">孩子能关心别人的成绩</span>，<span class="zijian_ds"></span></p>
            <p>
                <strong>3.</strong> 生动类信息采集的量<strong class="caiji">过低</strong>，需提高采集量
            </p>
            <p>
                <strong>4.</strong> 学习方法<strong class="qudao">较差</strong>，家长应该注意引导孩子寻找适合自己的学习方法。
            </p>
            <p>
                <strong>5.</strong> 五大能力综合比较中等水平<span  class="shengcun"></span>其他能力均需得到进一步的巩固和提升。
            </p>
        </div>
        <div class="contants">
            <p>
                多带孩子到户外活动，周末带孩子进行有主题的生动类信息采集，修复孩子在视触方面的自觉使用性，可以增强孩子的主动思维能力，学习中才能主动地去解决问题，而不是一遇到困难就问别人，在理解课文、写作文的时候也不会有太大的困难。
            </p>
            <p>
                提高学习的主动性：家长在辅导孩子学习的过程中少用“不学习，你以后就找不到好工作”“赶紧学习写作业”等等话语，这种命令式、要求式的叙述方式使孩子处于被动状态，会引起孩子的反感。也不要用交易式沟通，让孩子认为学习是家长要求的不是自己的责任。家长要让孩子了解：学习是自己的事，不是学给家长看的。同时家长和孩子可以一起寻找学习中的共同乐趣，在趣味学习中，孩子会喜欢上学习，会主动地去预习、复习，厌学度也就会降低。
            </p>
            <p>
                学习的自检性：孩子会关注他人的学习，说明他对于学习还是有期待竞争的，家长要做的就是引发孩子的学习自检性。每次考完试、放学后都可以和孩子交流一下今天的学习情况，思考一下该怎么提升自己，要注意语气，不要强硬、强制，要用温和、引导式的语气。
            </p>
            <p>
                学习方法的摸索：家长不要强硬地命令要求孩子去怎么写作业、背书，被动学习的效率永远不会高。家长可以在孩子放松的时候，和孩子一起探讨学习的方法，家长把自己以前的学习经历和孩子说说，比如：妈妈以前背书就是一句一句地死背，却还是背不出来，你有什么好办法呢；你这样做题的方法很好，妈妈以前就没有你这么聪明等等。适时地夸奖孩子，让孩子对学习树立信心，主动去思考学习的方法。还可以和孩子一起制定一个只针对放学后的学习计划：回到家先做什么后做什么、如果前一个没有完成就不能做后一个。然后学习计划逐步扩大到一天的、一星期的、一月的，通过这种方式，孩子会逐渐学会安排自己的时间。
            </p>
            <p>
                端正学习态度：家长遇到不开心的事跟孩子说，孩子是可以依赖的，把孩子当自己生活中的伴儿，可很好的增强孩子的责任承担能力，而责任承担能力是形成良好学习态度的前提，孩子会把学习当成自己的责任去自觉地承担。千万不要给孩子灌输这种类似的想法：只要你好好学习就行，家里任何事情都不用你来操心。恰恰相反，日常生活中的事情与学习态度和学习能力的形成是相辅相成的。还可以告诉孩子，你的学习和爸爸妈妈的工作是一样的，学习就是你的工作。爸爸妈妈必须要工作因为爸爸妈妈要对自己、你和爷爷奶奶负责，需要赚钱让我们生活快乐。而你必须要学习是因为你要对你自己负责，你需要学习来快点长大，才能做自己喜欢的事情，未来才能生活快乐等等。让孩子明白学习是自己的责任不是为别人而学。
            </p>
            <p>
                做任何事，都尽量提前约定，家长和孩子互相监督，家长要随时提醒孩子：监督爸爸妈妈有没有违反约定。前期家长可以故意做错，受到惩罚后和孩子一起分析，为什么爸爸妈妈违反了约定。通过这种方式逐渐修复孩子的自控自抑能力，同时孩子在分析、监督、遵守约定的过程中其他能力也都在修复。
            </p>
        </div>


         <div class="fx"  style=" display:none;">
          <div   class="beidong">
        <ul>
            <li>孩子的学习主动性较高，说明孩子愿意学习，应继续保持。并且可以在日常多进行和孩子学习方面的探讨，让孩子习惯和父母商量遇到的学习问题的解决方法。</li>
            <li>孩子的会把学习当成自己自己的事，学习态度基本端正，需要注意的事，不要让孩子只关注学习，而是通过在家庭中的分担，继续让孩子保持对于特定环境的关注，继续保持学习主动性</li>
            <li>孩子的具有一定的学习兴趣，需要注意的是，当孩子知道学习自己的事的前提，不要再“不识趣”反复强调学习的重要性和自主性，也不要因为孩子可能出现的一两次“倦怠”而大发雷霆，而是和他一起解决问题。</li>
        </ul>
         <ul>
            <li>孩子处于“我要学”和“要我学”的交界处，知道自己要学习，但是却会反复，家长应该增强和孩子的沟通，找到孩子学习过程碰到的问题，不是指责而是帮助解决。</li>
            <li>关注孩子的情绪，当孩子出现情绪波动从而影响学习状态的时候，选择和孩子好好谈谈心，站在他的角度去理解他，让他慢慢习惯向遇到问题想父母求助。</li>
            <li>学会使用“承认+怎么办+方法”的方式处理孩子的问题，先跟后带，引导孩子降低对于学习的被动值。</li>
        </ul>
         <ul>
            <li>说十遍“你要学”不如孩子自己说“我要学”，指出孩子的十个问题不如帮孩子解决一个问题，家长的身份不是老师，不是提出要求，而是陪孩子一起面对、解决，每个孩子天生的都是热爱学习的，除了督促，记得鼓励！</li>
            <li>改变和孩子的沟通方式，从生活的事情入手，改善和孩子的沟通关系，先成为孩子依赖和信任的父母，再成为教导孩子的老师。</li>
            <li>坚决不要使用“交易式沟通”，即不要用好吃的、好玩的、钱作为和孩子交换成绩的筹码，因为学习是孩子自己的事，成绩好坏最受影响的是他自己，而非父母，而不是某件“筹码”的得失 </li>
        </ul>
    </div>
     <div   class="yanxue">
        <ul>
            <li>孩子比较喜欢学习，家长需要的就是继续和孩子一起分享学习过程的欢乐，一起分享运用知识解决问题的快感，通过“学而时习之”，建立知识和生活的联系，让孩子继续对知识和学习产生浓厚的兴趣。</li>
            <li>帮助孩子从喜欢学习到爱学习转化，可以尝试找到孩子最感兴趣的学科，做适当的延伸和丰富，激发孩子学习的探索。</li>
            <li>家长可以在孩子面前“笨“一点，多请教他一些问题，让孩子体会拥有知识的幸福和快乐。</li>
        </ul>
         <ul>
            <li>“学习好不一定快乐，学习不好一定不快乐”坚信每个孩子都是希望自己能学好，想学好的，作为家长的您是否看到了这一点？所以，学习不是逼出来的，而是引导出来的。</li>
            <li>和孩子一起把学习的一些环节设计成生活中的活动或者游戏，比如将复习与预习作为一天中的固定安排，不一定是要复习和预习知识，哪怕只是总结一下今天做了什么，慢慢建立习惯，让孩子接受。</li>
            <li>学会使用“宰杀大象法”帮助孩子分割学习任务，并且合理的穿插安排，比如文理交替，不要只关注孩子的弱势科目上，增大孩子的抵触。</li>
        </ul>
         <ul>
            <li>学习仅是孩子整个成长过程中的一部分，父母是陪伴孩子，指导孩子一生的“朋友”，尝试换个角度，换个方式和孩子交流，先让孩子知道您是他的朋友，您可以理解他，再尝试沟通有关学习的话题。</li>
            <li>当孩子不喜欢学习的时候，首先要做的是了解孩子不喜欢的原因，不要简单的归结为学习态度的问题，可能是孩子不喜欢他的老师，或者在学校和同学之前有了误会，而我们却一直忽略了，先找到原因，在正确的引导和处理。</li>
 
        </ul>
    </div>
     <div   class="xinxicaiji">
        <ul>
            <li>在家里和孩子一起养一些植物，分别起好名字，和他一起做植物的成长观察记录，如果开始的时候，他不愿意，不用逼迫。家长持续进行，用自述的方式告诉他，慢慢引导共同关注。</li>
            <li>每周末抽出半天的时候和孩子一起到户外散散心，开始的时候以孩子的想法为主，可以只是简单散步等，慢慢的植入主题，和孩子共同进行。</li>
            <li>多带孩子到大自然中去，尽量起那些原始的自然环境，而不是大型的游乐场、公园，切记不是走马观花的照相、参观，而是针对性的主题采集</li>
        </ul>
         <ul>
            <li>孩子可能进行不习惯去接受大自然中的事物，会不感兴趣，可以先去一些比较有意思和挑战性的户外环境，比如：漂流、攀岩等，激发孩子对户外的兴趣。</li>
            <li>让孩子参与到家长的户外活动的某些环节中，可以帮助家长挑选的漂亮的照片，帮助家长发布博客等，然后逐步过渡到共同进行。</li>
            <li>在合适的时候，和孩子聊一些关系大自然的事情，可以是一些神奇的事情向孩子请教，可以让孩子说说自己喜欢的生动类信息类型，然后针对性的设计主题，可以先通过室内，在过渡到室外。</li>
        </ul>
         <ul>
          
        </ul>
    </div>
     <div   class="bijiao">
        <ul>
            <li>注意调整孩子成长环境的被主平衡，被动值过高会让孩子决绝比较，放弃对比，主动值过高会让孩子不屑比较，目中无人，这不但体现在学习成绩上，也会体现在日常生活中。</li>
            <li>减少因为家长面子的比较和“看看别人多好”这样的攀比，不仅不能激发孩子自觉的比较，激发自己，反而会让孩子更反感我们，甚至形成剥离。</li>
            <li>家长可以自己先成为和孩子对比的对象，和孩子一起制定规则并且坚持，甚至可以让孩子“监管”自己，让孩子自觉对比，不仅仅只是学习和学科上，从生活中入手，效果会更好。</li>
        </ul>
         <ul>
            <li>先建立孩子自己和自己的对比，建立学习的自检性，认可孩子的进步和获得，让孩子在比较中获得动力而非否定。</li>
            <li>可以帮助孩子建立一个不可抗拒的对比对象，不一定是同龄的同学，让孩子认可自己的不足，从而改变或者调整，可以适当使用“对比赏识”的技巧。</li>
            <li>家长一定要记得对比的目的，对比是为了让孩子自觉的努力和进步，找打学习的榜样，同时也是建立自信，所以，在引导孩子对比时，尽量客观的比较，向上比也向下比，而非单向比较。</li>
        </ul>
         <ul>
            <li>注意保护孩子的对比欲望，不要过度，是形成焦虑和压力，学会说“学习是你自己的事情，开心也是你自己的，我也会很开心，因为我爱你”</li>
            <li>继续保持和孩子的沟通方式和习惯，最好能够更客观的和孩子分析问题，让他已有的比较，不是因为虚荣，而是因为需要。</li>
            <li>学会对比后延伸，对比只是开始，重要和找到形成对比结果的原因和方法，和孩子一起分析，多听听他的，别轻易的否定，而是帮他找到更客观的原因，让孩子变得更好。</li>
        </ul>
    </div>
     <div   class="fangfa">
        <ul>
            <li>真正的学习方法是孩子在学习过程中自己形成的，不要盲目的“东施效颦”，先要找到孩子学习过程中的问题，针对性的和孩子一起制定或者尝试新的方法，并且承认这种方法取得的效果，让孩子愿意尝试新的方法和建立和适合自己的方法。</li>
            <li>最简单的学习方法就是跟随老师的步骤和方法，当您没有好的技巧和引导方式时，站在老师的角度说话，当然，不是简单的命令。而是陪着他一起执行，化解他的不良情绪。</li>
        </ul>
         <ul>
            <li>适当的让孩子参与到生活中的事情来，和孩子一起处理生活中的事，从而一起总结这些方法和技巧，再过渡到学习中，让他先看到效果，从而自觉执行。</li>
            <li>当孩子有了一种已近习惯的方法时，即便他可能不是很完美，别急着改变它，除非家长确定有一种更好的方法可以替换他，并且让孩子看到了效果，否则，孩子永远不会用适合自己的方法，只是我们给他的技巧。</li>
            <li>家长学习的时候和孩子现在学习的时候不一样，知识也不一样，环境也不一样，不要总是站在高位，减少使用总结性的语言，减少“马虎，认真“等模糊概念的使用。</li>
        </ul>
         <ul>
             <li>孩子已经慢慢形成了自己的学习方法，试着像个学生一样听听他的方法，甚至让他教教家长，这样的过程会让他自觉的完善自己的方法，家长也可以给出让他接受的建议。</li>
             <li>家长可以慢慢的从他的“学习方法”向“做事方法”过渡，让使用正确和科学、合适的方法，成为孩子做事的习惯。</li>
             <li>别轻易的直接用“状元技巧”“高效学习法”去覆盖、打破他已经在用的方法，可以把这些书推荐给他，让他从中自己找到合适的方法。</li>
        </ul>
    </div>
     <div   class="zijian">
        <ul>
            <li>避免使用“埋葬式沟通”如：“你只要学好习就成了，别的不用管”和“贬低式沟通”如：“如果不好好学习，以后就只能当个工人”等，那样只会让孩子更加不在学习的实质。</li>
            <li>家长不仅只是引导孩子关注学习的结果和学习成绩，学习是孩子能力和知识的储备过程，成绩是为了让孩子知道会了哪些和不会哪些，只是一次考试的结果体现，所以，多和孩子谈到学习成绩背后的东西，当然，不要只是指责。</li>
            <li>在生活中帮助孩子建立“自检性”思维，通过生活的事情，引导孩子自己分析造成事情结果的原因，比如：这件事情妈妈知道了，你好好想想，下次你注意吧。”</li>
        </ul>
         <ul>
            <li>即便没有考试，即便不是学习，也可以和孩子一起分享一下，这一天或者这一段时间的收获，家长可以说说自己在工作和生活中情况，孩子可以说学习的，也可以说学校的，或者是生活中的。</li>
            <li>家长需要自检一下，是不是平时和孩子的沟通中过于强调结果，和忽略了孩子在过程中的表现，孩子还处于成长阶段，而不是成人是使用阶段</li>
            <li></li>
        </ul>
         <ul>
            <li>即便孩子取得了较好的成绩，也和孩子一起分析，找到更好的原因。</li>
            <li>引导孩子进行定期的总结，不仅仅只是总结知识点，还有方法和心得。包括试卷分析和作业分析。</li>
            <li>和孩子一起做生活事物的分析和总结，或者是新闻上的，家长工作上的结果分析，了解孩子的分析思路和关注点，适当的引导孩子正确的找到问题的修正方法以及提升的方法。</li>
        </ul>
    </div>
     <div   class="qudao">
        <ul>
            <li>注意培养孩子触觉通道的使用，也就是让孩子多动手，给孩子各种动手尝试的机会。父母减少自己的包办代替。</li>
            <li>带孩子到生动的大自然环境中去，这时孩子视觉、听觉、触觉三个通道的自觉配合使用性最高，是修复通道的最好方法</li>
        </ul>
         <ul>
            <li>通过游戏比赛的形式，让孩子体验理解视觉、听觉、触觉互相配合能让自己的学习更轻松，让自己的记忆更深刻，比如让孩子只用听觉来记忆一段话，然后再尝试三个学习渠道共同使用学习能达到什么效果。</li>
            <li>寻找专业的机构给孩子做视觉、听觉、触觉使用性的测评，制定专业的修复改善方案。</li>
        </ul>
         <ul>
        </ul>
    </div>
     
     <div class="fenxili"><!--分析力-->
        <ul>
            <li>爸爸妈妈和孩子多沟通交流日常生活中的经验、社会经验等，这些都是孩子成长中必不可少的知识信息，更是增强孩子分析能力的第一步。</li>
            <li>分析能力比较弱，爸爸妈妈需要更多的创造机会，提高孩子对周围发生事情的关注性，让孩子对外面世界发生的事情产生更多的好奇，在孩子好奇的基础上向孩子传递各种知识信息，增加孩子信息量的积累。</li>
            <li>孩子分析能力较差，建议爸爸妈妈在平时多和孩子沟通交流，遇到什么事情和孩子一起讨论分析，目的不是让孩子能分析出什么结果，而是在孩子主动参与的情况下尽可能多的给孩子提供大量的信息，让孩子在遇到问题时有“材料”可分析。</li>
        </ul>
         <ul>
            <li>孩子分析能力一般，建议家长和孩子在沟通的过程中，尽可能多的向孩子传达有效、有用的信息，比如和孩子讨论米饭是从哪里来的？而不是和孩子沟通一些无效甚至是垃圾信息，比如骂人的脏话、主观评论某件事好某事不好，而又不准备和孩子讨论为什么好或为什么不好。</li>
            <li>父母替孩子做出的决定，请跟孩子说明白为什么。多用建议少用决定，这样做不仅可以增强孩子以后的分析能力，还会减少孩子与父母的对抗情绪。</li>
            <li>分析能力是孩子任何一种能力的基础，而分析能力的前提是提供给孩子足够多的且孩子能明白的有效信息，建议家长加强和孩子之间的有效沟通。比如少说一些大道理，多用孩子亲身经历和体验过的事情能达到事半功倍的效果。</li>
        </ul>
         <ul>
            <li>孩子分析能力较好，建议爸爸妈妈进一步学习、了解更专业的教育知识，比如知道孩子智慧是如何在发展的；知道孩子分析能力的基础是向孩子提供大量、有用的知识信息；知道信息是由生活经验类信息、社会经验类信息和科学文化知识类信息三大范畴组成的，并且清楚了解三类信息之间的关系等</li>
            <li>孩子分析能力较好，注意尽可能多的丰富孩子各类范畴的知识信息，信息储存越丰富意味着孩子形成强大分析能力的机会就越多，尽量避免出现“挑食”现象。</li>  
        </ul>
    </div>
     <div   class="zikongli">
        <ul>
            <li>孩子自控自抑能力较差，很多时候孩子的要求得不到满足就不依不饶或者很不开心，有可能是因为我们没有和孩子分析清楚这件事情为什么可以做或者为什么不可以做，是孩子分析能力较弱导致的一种表现。所以解决问题的前提是针对这件事情和孩子分析清楚。</li>
            <li>建议爸爸妈妈学会使用“提前沟通”的技巧，孩子自控自抑能力较弱需要进一步提高，在我们明确自己的培育目的后，和孩子一起做一件事情的时候至少需要提前一天开始沟通约定相关内容，而不是在事情发生的当时才提出相关要求。</li>
            <li>父母是孩子的一面镜子，很多时候孩子的表现都是在复制模仿父母的行为举止，说到做到是最起码的行为要求，假如父母自己做不到也就意味着很难让孩子拥有良好的自控自抑能力。所以父母自己的改变是调整孩子最好的方法之一。</li>
        </ul>
         <ul>
            <li>培养孩子的自控自抑能力可以结合身边很多日常生活小事进行，比如和孩子提前约定每天看动画片、上网的时间、帮父母排队购物等，针对这些事情进行充分讨论然后达成共识，当然一定要注意讨论如果孩子在执行过程中做不到时双方计划怎么办。</li>
            <li>孩子如果在别人眼中一直表现得很听话或者很乖，是父母需要引起注意的问题，这样的孩子并不意味着自控自抑能力很好，更多情况下可能是因为被动值过高导致的，可能丧失了做事情的主动性。</li>
            <li>在加强孩子自控自抑能力培育的过程中，家长需要严格遵守三个步骤：事前要约定、事中要适时提醒约定内容、事后有结果反馈，不能不了了之。否则孩子自控自抑能力培养起来就会出现偏差。</li>
        </ul>
         <ul>
            <li>孩子自控自抑能力表现较好，家长继续保持良好的培育方法。</li>
          
        </ul>
    </div>
     <div   class="goutong">
        <ul>
            <li>孩子在与人沟通时不顺畅，有可能是不知道如何表达自己的想法，有可能是沟通方式不对，父母需要针对事情、具体情况来帮助孩子，一次做的不好千万不要指责、批评孩子。教孩子有效表达自己的想法是增强社会沟通能力的核心。</li>
            <li>当孩子在和父母表达自己想法的时候，父母首先要学会的是静听，这同样是用实际行动在教育孩子良好的沟通需要学会静听，而不是主观打断对方的表达。</li>
            <li>社会沟通能力较弱的孩子往往是因为父母本身就存在大量的非秩序沟通，让孩子不会运用正确的沟通方式，父母以身作则的改变是提高孩子沟通能力的第一步。</li>
        </ul>
         <ul>
            <li>当父母想和孩子沟通一件事情的时候，先观察孩子正在做什么，而不是主观的打断或阻止，这样孩子在与他人沟通时才能学会尊重他人，这是形成良好社会沟通能力的前提</li>
            <li>在日常生活中可以多创造一些让孩子与陌生人沟通的机会，比如带父母去医院看病帮助询问看病的流程，或者外出吃饭时让孩子和服务员沟通交流自己的需求等。</li>
            <li>社会沟通能力是影响孩子在学校生活中的关键因素，孩子对学习产生被动、厌学情绪很多情况下是因为社会沟通能力不强导致的，父母需要重点培养孩子正确的沟通方式，避免使用非秩序性沟通方式。</li>
        </ul>
         <ul>
            <li>孩子社会沟通能力表现较好，家长继续保持良好的培育方法</li>
        </ul>
    </div>
     <div   class="siwei">
        <ul>
            <li>孩子主动思维能力需要进一步提高，当孩子向父母提问的时候，父母学会重复孩子的问题，并适当等待一段时间，给孩子主动思考的机会再和孩子探讨。</li>
            <li>建议父母每天花几分钟时间和孩子一起探讨今天发生在自己身上开心的事或者不太开心的事情，认真询问孩子假如是他碰到类似的问题时可以怎么办。积极倾听并鼓励孩子发表他的看法。</li>
            <li>当孩子遇到问题向父母习惯性求助的时候，不要立马回应，给他自己一段思考的时间。</li>
        </ul>
         <ul>
            <li>孩子的想法经常有点不靠谱或者不切合实际，同样是主动思维能力不强的表现，父母需要引导孩子多关注外界客观的信息，让孩子在客观信息的基础上发挥他的主动性。</li>
            <li>不是在孩子面前讨论社会上各种负面的事情，这样容易让孩子对社会形成厌倦和逃避，而不会积极正向关注身边的人和事，在解决问题时容易主观偏离实际。</li>
            <li>鼓励孩子在发表自己看法的时候，注意提醒孩子关注客观实际情况，预防孩子主动值偏高</li>
        </ul>
         <ul>
            <li>孩子主动思维能力表现较好，家长继续保持良好的培育方法</li>
        </ul>
    </div>
     <div   class="chengdanli">
        <ul>
            <li>真正的责任承担能力并不是要求孩子学会收拾自己的房间，整理好自己的东西，自己的事情自己做，这样培养出来的并不是一个自理能力很强的人，而是一个只会关注自己和照顾自己的人。</li>
            <li>建议父母引导孩子主动关注家里的各种生活琐事，让孩子建立家庭是父母和孩子共同生活的地方，孩子同样需要承担家庭中力所能及的事情，培养孩子的分担能力才是提高责任承担能力的关键。</li>
            <li>当孩子主动关心父母是否开心、是否不舒服时，父母学会接纳这份关注，而不是把孩子的关心推开。</li>
        </ul>
         <ul>
            <li>千万不要对孩子说，“这是大人的事情，小孩子不要管，赶紧学习去。”这是在剥夺孩子主动承担的机会。</li>
            <li>把家里买水、买电或者柴米油盐等相关事情分配给孩子，让孩子和父母一起承担家庭生活的责任。</li>
            <li>把孩子当成生活中的伴，学会依赖孩子，当父母对孩子的依赖性越强，孩子的责任承担能力也越强。</li>
        </ul>
         <ul>
            <li>孩子责任承担那能力表现较好，家长继续保持良好的培育方法</li>
        </ul>
    </div>
    



     
 </div>
    </asp:Panel>

 



    
    <div class="contants">
        <strong>本测评只是根据家长对测评表的反馈结果作出，一定有不全面的地方，在训练营结束后，经过与孩子的面对面了解，我们将会给家长反馈更为详尽和可操作的培育方案。
        </strong>
    </div>
    </form>
    <script type="text/javascript">
        $(function () {

            var shengcun01 = "";
            $(".fen").each(function (n) {

                var fen = $(this).text();
                var lvel = "";
                var writeStr = "";

                switch (n) {
                    case 0:
                        //被动
                        if (fen <= 30) {
                            lvel = "较低";
                            writeStr = getIndex(n, 0);
                        }
                        else if (fen >= 31 && fen <= 60) {
                            lvel = "中等";
                            writeStr = getIndex(n, 1);


                        }
                        else if (fen >= 61) {
                            lvel = "较高";
                            writeStr = getIndex(n, 2);
                        }

                        $(".beidong").text(lvel);
                        break;
                    case 1:
                        //厌学
                        if (fen >= 1 && fen <= 20) {
                            lvel = "较低";
                            writeStr = getIndex(n, 0);
                        }
                        else if (fen >= 21 && fen <= 40) {
                            lvel = "中等";
                            writeStr = getIndex(n, 1);
                        }
                        else if (fen >= 41) {
                            lvel = "较高";
                            writeStr = getIndex(n, 2);
                        }
                        $(".yanxue").text(lvel);
                        break;
                    case 2:

                        //采集
                        if (fen >= 1 && fen <= 5) {
                            lvel = "一般缺失";
                            writeStr = getIndex(n, 0);
                        }
                        else if (fen >= 6 && fen <= 15) {
                            lvel = "严重缺失";
                            writeStr = getIndex(n, 1);
                        }
                        else {
                            writeStr = getIndex(n, 2);
                        }
                        $(".caiji").text(lvel);
                        break;
                    case 3:
                        //比较
                        if (fen >= 4 && fen <= 5) {
                            lvel = "较好";
                            writeStr = getIndex(n, 0);
                        }
                        else if (fen >= 2 && fen <= 3) {
                            lvel = "中等";
                            writeStr = getIndex(n, 1);
                        }
                        else if (fen >= 1) {
                            lvel = "较差";
                            writeStr = getIndex(n, 2);
                        }
                        $(".bijiao").text(lvel);
                        break;
                    case 4:
                        //方法
                        if (fen >= 1 && fen <= 5) {
                            lvel = "较低";
                            writeStr = getIndex(n, 0);
                        }
                        else if (fen >= 6 && fen <= 15) {
                            lvel = "中等";
                            writeStr = getIndex(n, 1);
                        }
                        else if (fen >= 16) {
                            lvel = "较高";
                            writeStr = getIndex(n, 2);
                        }
                        $(".fangfa").text(lvel);
                        break;
                    case 5:
                        //学习检测
                        if (fen >= 4 && fen <= 5) {
                            lvel = "较低";
                            //$(".zijian_ds").text("对自己的学习怎么样不会检索，不会思考该怎么做才能更好。");
                            writeStr = getIndex(n, 0);
                        }
                        else if (fen >= 2 && fen <= 3) {
                            lvel = "一般";
                            //$(".zijian_ds").text("对自己的学习怎么样不会检索，不会思考该怎么做才能更好。");
                            writeStr = getIndex(n, 1);
                        }
                        else if (fen == 1) {
                            lvel = "较高";
                            writeStr = getIndex(n, 2);

                        }

                        $(".zijian").text(lvel);
                        break;



                    case 6:

                        //渠道
                        if (fen >= 1 && fen <= 3) {
                            lvel = "较多";
                            // $(".qudao").text(lvel);
                            writeStr = getIndex(n, 0);
                        }
                        else if (fen >= 4 && fen <= 7) {
                            lvel = "中等";
                            // $(".qudao").text(lvel + "家长应该注意引导孩子寻找适合自己的学习方法");
                            writeStr = getIndex(n, 1);
                        }
                        else if (fen >= 8 && fen <= 10) {
                            lvel = "较少";
                            // $(".qudao").text(lvel + "家长应该注意引导孩子寻找适合自己的学习方法");
                            writeStr = getIndex(n, 2);

                        }

                        break;


                    case 7:

                        //分析能力
                        if (fen >= 0 && fen <= 8) {
                            lvel = "较差";
                            shengcun01 += " 分析能力 ";
                            writeStr = getIndex(n, 0);
                        }
                        else if (fen >= 9 && fen <= 16) {
                            lvel = "中等";
                            writeStr = getIndex(n, 1);

                        }
                        else if (fen >= 17 && fen <= 24) {
                            lvel = "较好";
                            writeStr = getIndex(n, 2);

                        }

                        break;



                    case 8:

                        //自控能力
                        if (fen >= 3 && fen <= 14) {
                            lvel = "较差";
                            shengcun01 += " 自控自抑能力 ";
                            writeStr = getIndex(n, 0);
                        }
                        else if (fen >= 15 && fen <= 26) {
                            lvel = "中等";
                            writeStr = getIndex(n, 1);
                        }
                        else if (fen >= 27 && fen <= 39) {
                            lvel = "较好";
                            writeStr = getIndex(n, 2);

                        }

                        break;
                    case 9:

                        //社会沟通能力
                        if (fen >= 3 && fen <= 14) {
                            lvel = "较差";
                            // shengcun01 += " 社会沟通能力 ";
                            writeStr = getIndex(n, 0);
                        }
                        else if (fen >= 15 && fen <= 26) {
                            lvel = "中等";
                            writeStr = getIndex(n, 1);
                        }
                        else if (fen >= 27 && fen <= 39) {
                            lvel = "较好";
                            writeStr = getIndex(n, 2);
                        }

                        break;
                    case 10:

                        //主动思维能力
                        if (fen >= 8 && fen <= 24) {
                            lvel = "较多";
                            // shengcun01 += " 主动思维能力 ";
                            writeStr = getIndex(n, 0);
                        }
                        else if (fen >= 25 && fen <= 44) {
                            lvel = "中等";
                            writeStr = getIndex(n, 1);

                        }
                        else if (fen >= 45 && fen <= 65) {
                            lvel = "较少";
                            writeStr = getIndex(n, 2);

                        }

                        break;
                    case 11:

                        //责任承担能力
                        if (fen >= 8 && fen <= 24) {
                            lvel = "较差";
                            // shengcun01 += " 责任承担能力 ";
                            writeStr = getIndex(n, 0);
                        }
                        else if (fen >= 25 && fen <= 44) {
                            lvel = "中等";
                            writeStr = getIndex(n, 1);

                        }
                        else if (fen >= 45 && fen <= 65) {
                            lvel = "较好";
                            writeStr = getIndex(n, 2);

                        }

                        break;

                }


                $(this).parent().parent().next().text(lvel);
                $(this).parent().parent().next().next().text(writeStr);
            });


            //            if (shengcun01 != "") {
            //                $(".xiufushengcunli").text("一半可从" + shengcun01 + "入手，其他几项辅助提高");
            //            }


            //            if (shengcun01 != "") {
            //                shengcun01 += "较差";
            //                shengcun01 += "他能力均需得到进一步的巩固和提升。";
            //                $(".shengcun").text(shengcun01);
            //            }
        });

        function getIndex(din, ulin) {
            var tCount = GetRandomNum(0, $(".fx  div:eq(" + din + ") ul:eq(" + ulin + ")  li").length - 1);

            // alert(tCount);
            return $(".fx  div:eq(" + din + ") ul:eq(" + ulin + ")  li:eq(" + tCount + ")").text();
        }



        function GetRandomNum(Min, Max) {
            var Range = Max - Min;
            var Rand = Math.random();
            return (Min + Math.round(Rand * Range));
        }   
    </script>
</body>
</html>
