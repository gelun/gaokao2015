<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Rports.aspx.cs" Inherits="GaoKao.CePing.nf.Rports" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>测试结果</title>

<link href="cssstyle.css" rel="stylesheet" type="text/css" />
<script type="text/javascript" src="js/jquery.min.js"></SCRIPT>

<SCRIPT type="text/javascript">
    $().ready(function () {
        $("#xingqu").hide();
    });
    </SCRIPT>
    <style type="text/css">
        .style1
        {
            height: 104px;
        }
        img{ margin:0px; border:0px; padding:0px;}
    </style>
</head>

<body>

<div class=noprint>
	<div class="top_left">格伦高考专业选择测评报告</div>
    <%--<div class="top_right">学生姓名：<%=ltr_StudentName.Text%></div>--%>
</div>

<div class="page1"><img src="images/head6.jpg" />
<div class="xinxi">
     <h2>学生：<asp:Literal ID="ltr_StudentName" runat="server"></asp:Literal></h2>
  <%--   <h2>性别：<asp:Literal ID="ltr_StudentSex" runat="server"></asp:Literal></h2>--%>
     <%--<h2>测试日期：<asp:Literal ID="ltr_Time" runat="server"></asp:Literal></h2>--%>
</div>
</div>

<div class="page2"><b>目 录</b></div>
<div class="xinxi_t">
     <h2><a href="#daoyu">导语</a></h2>
     <h2><a href="#zhiyexingqu">职业兴趣测验结果</a></h2>
     <h2><a href="#xinggeceshi">性格测验结果</a></h2>
     <h2><a href="#nengliceshi">能力倾向测验结果</a></h2>
     <h2><a href="#jiazhiguanceshi">职业价值观测验结果</a></h2>
 <%--    <h2><a href="#">适合的专业</a></h2>
     <h2><a href="#">部分推荐专业介绍</a></h2>--%>
     <h2><a href="#jieshuyu">结束语</a></h2>
</div>


<div class="daoyu">
     <div class="page2" id="daoyu"><b>导 语</b></div>
     <h1>简介：</h1>
     <p>    高考是中国教育体制中的重要环节。选择专业和填报志愿专业性非常强，每年都让家长和学生头痛，因为要考虑的因素太多，总是左右为难，举棋不定。到底什么是自己的"最佳"专业，在确定"最佳"专业时，应该考虑哪些现实因素呢？</p>
     <p>    高考成功与否关系到考生能否有机会进一步接受高等教育，更关系到考生未来就业和职业生涯的发展。目前我国高校招生录取的主要依据是考生的高考分数和高考填报的志愿，很多考生和家长在选择高考志愿时主要考虑名校因素、就业因素、升学因素和成本因素，而往往忽视了最重要的一个因素一一一考生未来的职业发展因素。</p>
<p>    其实从人一生的发展来看，高考志愿的选择在一定程度上决定了未来就业的方向，选择合适的高考志愿能为未来就业莫定很好的基础，在就业过程中少走弯路，或取得更大的成就。</p>
<p>    “格伦教育咨询测评系统”以霍兰德职业兴趣理论为基础，结合卡特尔十六种人格因素问卷、能力倾向测验、职业价值观测验进行综合测评，帮助学生了解自己的专业兴趣、个性特征及其基本能力倾向，根据学生的不同特点，在365个职业和545个专业中匹配出适合的职业和专业，并提供院校信息，为学生填报志愿、选择专业提供有价值的参考。</p><br />
<br />
     <h1>阅读建议： </h1>
     <ul>
        <li>测验结果只是为您提供参考，填报志愿时，您还需要考虑其他方面的因素，如考试成绩、父母的资源、家庭经济状况等； </li>
        <li>兴趣、性格、价值观和能力，四个方面，认真仔细地思考一下，自己最重视哪几点，选择专业和职业时，不妨以此为出发点； </li>
        <li>花点时间与您身边的人，如家人、老师和职业指导或咨询专家讨论一下您在性格、专业兴趣上的发现，如果有不同意见，找到原因，深入剖析，有利于做出更好的选择； </li>
        <li>请认真阅读每一个环节测验结果的具体解释，并结合自己的实际情况，深入思考，测评结果对于今后就业方向也有很强的指导意义。 </li>
     </ul>
</div>

<div class="daoyu">

<div class="page2" id="zhiyexingqu"><b>职 业 兴 趣 测 验 结 果</b></div>
     <p>    一个人对某职业的兴趣如何，是在选择职业时应首先考虑的。因为一个人从事自己感兴趣的工作，就能发挥自己的积极性，最大程度挖掘自身潜力，努力将工作做好，而且可以从工作中得到满足，感到内心的愉悦。根据您的测评结果，孩子的职业兴趣为：社会型-现实型-艺术型</p>
     <TABLE class=table1 id="table1" border=1 cellSpacing=0 cellPadding=5 width=830>
  <TBODY>
  <TR>
    <TH width="15%">类型</TH>
    <TH width="9%">代码</TH>
    <TH width="67%"><IMG src="images/table1_1.jpg"> </TH>
    <TH width="9%">分数</TH></TR>
  <TR class=even>
    <TD>社会型</TD>
    <TD>S</TD>
    <TD style="TEXT-ALIGN: left" align=left><IMG src="images/col1_1_01.gif" 
      height=19><IMG  class="plan" src="images/col1_1_02.gif"   height=19><IMG 
      src="images/col1_1_03.gif" height=19></TD>
    <TD>
        <asp:Label ID="lb_Society" runat="server" >0</asp:Label></TD></TR>
  <TR class=odd>
    <TD>现实型</TD>
    <TD>R</TD>
    <TD style="TEXT-ALIGN: left" align=left><IMG src="images/col1_2_01.gif" 
      height=19><IMG class="plan" src="images/col1_2_02.gif"   height=19><IMG 
      src="images/col1_2_03.gif" height=19></TD>
    <TD><asp:Label ID="lb_Reality" runat="server" >0</asp:Label></TD></TR>
  <TR class=even>
    <TD>艺术型</TD>
    <TD>A</TD>
    <TD style="TEXT-ALIGN: left" align=left><IMG src="images/col1_3_01.gif" 
      height=19><IMG class="plan" src="images/col1_3_02.gif"   height=19><IMG 
      src="images/col1_3_03.gif" height=19></TD>
    <TD><asp:Label ID="lb_Art" runat="server" >0</asp:Label></TD></TR>
  <TR class=odd>
    <TD>常规型</TD>
    <TD>C</TD>
    <TD style="TEXT-ALIGN: left" align=left><IMG src="images/col1_4_01.gif" 
      height=19><IMG class="plan" src="images/col1_4_02.gif"   height=19><IMG 
      src="images/col1_4_03.gif" height=19></TD>
    <TD><asp:Label ID="lb_Tradition" runat="server" >0</asp:Label></TD></TR>
  <TR class=even>
    <TD>研究型</TD>
    <TD>I</TD>
    <TD style="TEXT-ALIGN: left" align=left><IMG src="images/col1_5_01.gif" 
      height=19><IMG class="plan" src="images/col1_5_02.gif"   height=19><IMG 
      src="images/col1_5_03.gif" height=19></TD>
    <TD><asp:Label ID="lb_Study" runat="server" >0</asp:Label></TD></TR>
  <TR class=odd>
    <TD>企业型</TD>
    <TD>E</TD>
    <TD style="TEXT-ALIGN: left" align=left><IMG src="images/col1_6_01.gif" 
      height=19><IMG  class="plan" src="images/col1_6_02.gif"  height=19><IMG 
      src="images/col1_6_03.gif" height=19></TD>
    <TD><asp:Label ID="lb_Business" runat="server" >0</asp:Label></TD></TR></TBODY></TABLE>
    <script type="text/javascript">
        $(function () {
            //设置职业兴趣分数条长度
            $("#table1 tr td span").each(function () {
                var fen = $(this).text();
                var zfen = fen * 100 / 15;

                var a = zfen.toString().indexOf(".");

                if (a >= 0) {
                    $(this).text(zfen.toString().substring(0, a))
                }
                else {
                    $(this).text(zfen);
                }

                $(this).parent().prev().find(".plan").css("width", 340 / 100 * zfen + 70);

            });

        })
  
  
  </script>
    
    <br /><br />

    <div class="t">
        <div class="p1">
            <p>孩子的职业兴趣类型为</p>
            <p><%=lb_HollandName.Text %></p>
        </div>
        <div class="p2"><asp:Literal ID="lb_Holland" runat="server"></asp:Literal></div>
    </div>
</div>



<a class=noprint onclick="$('#xingqu').show('slow')" 
href="javascript:void(0)">文字说明请点开查看</a> 
<DIV id=xingqu style="display:block;">
<TABLE class=table1 border=1 cellSpacing=0 borderColor=#00ff00 cellPadding=5 
width=830>
  <TBODY>
  <TR class=odd>
    <TH width="12%">性格类型</TH>
    <TH width="7%">代码</TH>
    <TH width="27%">爱好</TH>
    <TH width="27%">工作活动</TH>
    <TH width="27%">潜能要求</TH></TR>
  <TR class=even>
    <TD>现实型</TD>
    <TD>R</TD>
    <TD style="TEXT-ALIGN: left">机械，计算机网络，<BR>体育运动，户外工作</TD>
    <TD style="TEXT-ALIGN: left">操作设备，使用工具，<BR>建筑，修理，保安</TD>
    <TD style="TEXT-ALIGN: left">机械灵活性，身体协调</TD></TR>
  <TR class=odd>
    <TD>艺术型</TD>
    <TD>A</TD>
    <TD style="TEXT-ALIGN: left">自我表现，艺术鉴赏，<BR>沟通，文化</TD>
    <TD style="TEXT-ALIGN: left">作曲，表演，写作，<BR>视觉艺术</TD>
    <TD style="TEXT-ALIGN: left">创造力，音乐能力，<BR>艺术表演</TD></TR>
  <TR class=even>
    <TD>研究型</TD>
    <TD>I</TD>
    <TD style="TEXT-ALIGN: left">科学，医学，数学，研究</TD>
    <TD style="TEXT-ALIGN: left">实验室工作，<BR>解决抽象问题，管理研究</TD>
    <TD style="TEXT-ALIGN: left">数学能力，研究，写作<BR>，分析</TD></TR>
  <TR class=odd>
    <TD>社会型</TD>
    <TD>S</TD>
    <TD style="TEXT-ALIGN: left">人际关系，团队合作，<BR>助人，社区服务</TD>
    <TD style="TEXT-ALIGN: left">教学，管理，说服他人，<BR>市场营销</TD>
    <TD style="TEXT-ALIGN: left">人际技能，语言能力，<BR>倾听能力，理解能力</TD></TR>
  <TR class=even>
    <TD>企业型</TD>
    <TD>E</TD>
    <TD style="TEXT-ALIGN: left">商业，政治，领导，<BR>企业家地位</TD>
    <TD style="TEXT-ALIGN: left">销售，管理，说服他人，<BR>市场营销</TD>
    <TD style="TEXT-ALIGN: left">语言能力，<BR>激励与指导他人的能力</TD></TR>
  <TR class=odd>
    <TD>常规型</TD>
    <TD>C</TD>
    <TD style="TEXT-ALIGN: left">组织，数据管理，会计，<BR>投资，信息系统</TD>
    <TD style="TEXT-ALIGN: left">设置程序和系统，组织，<BR>记录，计算机软件开发</TD>
    <TD 
style="TEXT-ALIGN: left">数字运算能力，<BR>数据分析能力，<BR>金融，细节关注</TD></TR></TBODY></TABLE></DIV>
<div class="daoyu">
<div class="page2"><b>职 业 兴 趣 类 型</b></div>
     <div class="t1">测验分数表明您的孩子属于：<asp:Label ID="lb_HollandName" runat="server" ></asp:Label></div>
</div>
<asp:Literal ID="ltr_Holland" runat="server"></asp:Literal>
<div class="daoyu">
<div class="page2" id="xinggeceshi"><b>性 格 测 验 结 果</b></div>
     <p>性格没有“好”与“差”之分，但不同的性格适合不同的职业。性格若能与工作相匹配，将会得心应手、轻松愉快、富有成就；反之则会不适应、困难重重。你的典型性格特点是：高交际性、高活泼性、高乐群性、高影响性、低事故性、低紧张性、低忧虑性。</p>
     <TABLE class=table1 border=1   id="table2" cellSpacing=0 cellPadding=5 width=830>
  <TBODY>
  <TR>
    <TH width="4%">得分</TH>
    <TH width="15%">低分特征</TH>
    <TH width="67%"><IMG src="images/table1_1.jpg"> </TH>
    <TH width="14%">高分特征</TH></TR>
      
    <TR class=even>
            <TD>

            <span><asp:Literal ID="ltr_A" runat="server">0</asp:Literal></span> 
                </TD>
            <TD>缄默、孤独、冷漠、适合从事必须十分冷静严肃与正确才能圆满地完成任务的工作，如：机械操作、生产操作、机械工程师等工作</TD>
            <TD style="TEXT-ALIGN: left" align=left><IMG src="images/col1_1_01.gif" 
              height=19><IMG src="images/col1_1_02.gif" class="plan"   height=19><IMG 
              src="images/col1_1_03.gif" height=19>
                
              </TD>
            <TD>外向、热情、乐群，适合从事需要时时应付人与人间的复杂情绪或行为问题，而仍然能够保持乐观的态度的工作，如培训师和营销员等工作</TD></TR> 
  <TR class=odd>
    <TD> <span><asp:Literal ID="ltr_B" runat="server">0</asp:Literal></span> </TD>
    <TD>  比较迟钝 ， 学识浅薄 ， 抽象思考能力弱 ， 通常对学习与理解能力不强 ， 不善于 “ 举一反三 ” 
        ，迟钝的原因可能由于情绪不稳定等心理原因。从事例行琐碎工作，如打字员，能够不发生厌恶，久安其职。</TD>
    <td align="left" style="TEXT-ALIGN: left">
<img height="19" src="images/col1_2_01.gif"><img   class="plan" height="19" src="images/col1_2_02.gif"><img height="19" src="images/col1_2_03.gif"> 
</td>
    <TD>  职明 ， 富有才识 ， 善于抽象思考 ， 通常学习能力强 ， 思考敏捷准确 ， 教育 、 
        文化水准较高，个人心身状态健康；适合从事有专长的专业或者管理工作。</TD></TR>
  <TR class=even>
    <TD><span><asp:Literal ID="ltr_C" runat="server">0</asp:Literal></span></TD>
    <TD>情绪激动，易生烦恼，不适合公司绝大部分工作</TD>
   <td align="left" style="TEXT-ALIGN: left">
<img height="19" src="images/col1_3_01.gif"><img  class="plan" height="19" src="images/col1_3_02.gif"><img height="19" src="images/col1_3_03.gif">  


</td>
    <TD>  情绪稳定而成熟 ， 能面对现实 ， 适合从事管理工作 、 机械工程安装 、 推销 、 危机管理等等需要应付各种难题的工作。</TD></TR>
  <TR class=odd>
    <TD>
        <span><asp:Literal ID="ltr_E" runat="server">0</asp:Literal>  </span>
      </TD>
    <TD>&nbsp;  为人谦逊 、 顺从 、 通融 、 恭顺 ， 通常行为温顺 ， 迎合别人的意思 ， 也可能即使处在十全十美的境地，也有 “ 事事不如人 ” 
        之感，许多心理不健康的人都有这种消极的心情。</TD>
    <td align="left" style="TEXT-ALIGN: left">
<img height="19" src="images/col1_4_01.gif"><img   class="plan" height="19" src="images/col1_4_02.gif"><img height="19" src="images/col1_4_03.gif">
        
</td>
    <TD>  好强固执 ， 独立积极 ， 通常自视甚高 ， 自以为是 ， 可能非常地武断 ， 而时常驾驭不及自己的下级和个体 ， 并反抗有权势的领导等者 。 
        倾向成为领导 、 领袖及有地位有成就的人 。</TD></TR>
  <TR class=even>
    <TD>
       <span> <asp:Literal ID="ltr_F" runat="server">0</asp:Literal></span>
      </TD>
    <TD> 严肃、审慎、冷静、寡言；适合从事实验工作如质检，或者生产工作。</TD>
   <td align="left" style="TEXT-ALIGN: left">
<img height="19" src="images/col1_5_01.gif"><img   height="19" class="plan" src="images/col1_5_02.gif"><img height="19" src="images/col1_5_03.gif">
       
</td>
    <TD>  轻松兴奋 ， 随遇而安 ， 通常活泼 ， 愉快 、 健谈 。 更适合从事行政主管 、 人际竞争性的工作。</TD></TR>
  <TR class=odd>
    <TD>
       <span> <asp:Literal ID="ltr_G" runat="server">0</asp:Literal> </span>
      </TD>
    <TD>  苟且敷衍 ， 缺乏奉公办事的精神 ， 通常缺乏较高的目标和理想 ， 对于人群社会似乎没有绝对的责任感 ， 甚至于有时不惜知法犯法 ， 
        不择手段以达到某一目的 。 因此 ， 他常常能有效解决实际问题。</TD>
  <td align="left" style="TEXT-ALIGN: left">
<img height="19" src="images/col1_3_01.gif"><img  class="plan" height="19" src="images/col1_3_02.gif"><img height="19" src="images/col1_3_03.gif">  


</td>
    <TD>  有恒负责 ， 做事尽职 ， 通常细心周到 ， 有始有终 。 适合部门领导 、 业务管理和保卫工作。</TD>
    <TR class="even">
    <TD>
       <span> <asp:Literal ID="ltr_H" runat="server">0</asp:Literal> </span>
        </TD>
    <TD>畏怯退缩，缺乏自信心，通常在人群中羞怯，有不自然的姿态，有强烈的自卑感 。不善于发言，更不愿和陌生人交谈。适合从事具体事物性工作。</TD>
  <td align="left" style="TEXT-ALIGN: left">
<img height="19" src="images/col1_6_01.gif"><img  height="19" class="plan" src="images/col1_6_02.gif"><img height="19" src="images/col1_6_03.gif">
     
</td>
    <TD>  冒险敢为 ， 较少顾忌 ， 通常不掩饰 ， 不畏缩 ， 有敢作敢为的精神 ， 
        使他能经历艰辛而保持有刚毅力，有时注重向异性殷勤，常随年龄而增强，是团队领导必须具有的素质 。 适合从事危机管理等工作，倾向于适合从事领导管理等工作。</TD>
    </TR>

    <TR class="odd">
    <TD>
        <span><asp:Literal ID="ltr_I" runat="server">0</asp:Literal></span>
        </TD>
    <TD> 理智的，着重现实，自恃其力，常多以客观、坚强、独立的态度处理当前的问题 ，并不重视文化修养 ， 以及一些主观和感情用事的看法 ， 可能过分骄傲 ， 冷酷无情 
        。 适合从事工程师、研发员、统计师等工作。</TD>
  <td align="left" style="TEXT-ALIGN: left">
<img height="19" src="images/col1_3_01.gif"><img  class="plan" height="19" src="images/col1_3_02.gif"><img height="19" src="images/col1_3_03.gif">&nbsp;
   
</td>
    <TD>  敏感 ， 感情用事 ， 通常心肠软 ， 易受感动 ， 缺乏耐性与恒心 ， 不喜欢接近文化水平低的人和作笨重的工作 。 在团休活动中 ， 
        其不切实际的看法与行为常 常减低了团体的工作效率。适合从事设计、艺术类工作。</TD>
    </TR>


    <TR class="even">
    <TD>
       <span><asp:Literal ID="ltr_L" runat="server">0</asp:Literal></span>
        </TD>
    <TD>  依赖随和 ， 易与人相处 ， 通常无猜忌 ， 不与人角逐竞争 。 在团体活动中 ， 重视团体福利，更适合从事工程师、工人等工作。</TD>
  <td align="left" style="TEXT-ALIGN: left">
<img height="19" src="images/col1_6_01.gif"><img   height="19" class="plan" src="images/col1_6_02.gif"><img height="19" src="images/col1_6_03.gif">
      
</td>
    <TD>  怀疑 、 刚愎 、 固执己见 ， 通常多怀疑 ， 不信任别人 。 如果过分高 ， 达到 9 分 10 分 
        ，常常成事不足，败事有余。更适合从事行政工作和保安工作等。</TD>
    </TR>


    <TR class="odd">
    <TD>
        <span><asp:Literal ID="ltr_M" runat="server">0</asp:Literal></span>
        </TD>
    <TD> 现实，合乎成规，力求妥善合理，通常先要基本斟酌现实条件，而后决定取舍 ； 不鲁莽从事。更适合从事需要实际、机警、脚踏实地的工作。</TD>
  <td align="left" style="TEXT-ALIGN: left">
<img height="19" src="images/col1_5_01.gif"><img   height="19" class="plan" src="images/col1_5_02.gif"><img height="19" src="images/col1_5_03.gif"></td>
    <TD>  幻想的 ， 狂放不羁 ， 通常忽视生活的细节 ， 只以本身的动机 ， 当时的兴趣等主观因素为行为的出发点。适合从事艺术、写作及从事研究工作。</TD>
    </TR>


    <TR class="even">
    <TD>
      <span><asp:Literal ID="ltr_N" runat="server">0</asp:Literal></span>
        </TD>
    <TD>低；坦白、直率、天真，通常思想单纯，感情用事。适合在一线从事具体工作。</TD>
  <td align="left" style="TEXT-ALIGN: left">
<img height="19" src="images/col1_6_01.gif"><img   height="19"  class="plan" src="images/col1_6_02.gif"><img height="19" src="images/col1_6_03.gif">
      
</td>
    <TD> 精明能干，世故。适合从事研究、管理和工程师工作</TD>
    </TR>


    <TR class="odd">
    <TD class="style1">
        <span><asp:Literal ID="ltr_O" runat="server">0</asp:Literal></span>
        </TD>
    <TD class="style1"> 安详、沉着、有自信心。更适合电机工、管理等等工作。</TD>
  <td align="left" style="TEXT-ALIGN: left" class="style1">
<img height="19" src="images/col1_3_01.gif"><img  class="plan" height="19" src="images/col1_3_02.gif"><img height="19" src="images/col1_3_03.gif"></td>
    <TD class="style1"> 忧虑抑郁，烦恼自扰。通常觉得世道艰辛，人生不如意事常八九，甚至沮丧悲观 
        。时时有患得患失之感。自感不如人，也缺乏和人接近的勇气。</TD>
    </TR>


    <TR class="even">
    <TD>
        <span><asp:Literal ID="ltr_Q1" runat="server">0</asp:Literal></span>
        </TD>
    <TD>  保守的 、 新生传统观念与行为标准 。 通常无条件地接受社会中许多相沿已久而有权威性的见解 ， 不愿尝试探求新的境界 。 
        常常激烈的反对新思潮以及一切新的变动 。 在政治与宗教信仰上，默守成规，可能被称为老顽固或时代的落伍者。</TD>
  <td align="left" style="TEXT-ALIGN: left">
<img height="19" src="images/col1_3_01.gif"><img  class="plan" height="19" src="images/col1_3_02.gif"><img height="19" src="images/col1_3_03.gif">  


      </td>
    <TD> 自由的 、 批评激进 、 不拘泥于现实 。 高者通常喜欢考验一切现有的理想理论与现实 ，而予以新的评价 ， 不轻易判断是非 ， 
        企图了解较前进的思想与行为 。 可能广见多闻 ， 愿意充实自己的生活经验。适合行政主管、领导、研发工作。</TD>


<TR class="odd">
    <TD>
        <span><asp:Literal ID="ltr_Q2" runat="server">0</asp:Literal></span>
        </TD>
    <TD> 依赖、随附合。通常宁欲与人共同工作，而不愿独立孤行。常常放弃个人的主见 ，附合众议，以取得别人的好感。需要团体的支持以维持其自信心，却并非真正的乐群者 。 
        多不能胜任需要随机应变能力的职务。</TD>
  <td align="left" style="TEXT-ALIGN: left">
<img height="19" src="images/col1_6_01.gif"><img   height="19"  class="plan" src="images/col1_6_02.gif"><img height="19" src="images/col1_6_03.gif">
</td>
    <TD> 自立自强、当机立断。通常能够自作主张，独自完成自己的工作计划，不依赖人 ，也不受社会舆论的约束 ， 同样也无意控制或支配别人 ， 不嫌恶人 ， 
        但是也不需要别人的好感 。</TD>
    </TR>
<TR class="even">
    <TD>
        <span><asp:Literal ID="ltr_Q3" runat="server">0</asp:Literal></span>
        </TD>
    <TD>  矛盾冲突 ， 不顾大体 ， 通常既不能克制自己 ， 又不能尊重礼俗 ， 更不愿考虑别人的需要，充满矛盾，却无法解决，生活适应有问题者多有低 Q 3 。</TD>
  <td align="left" style="TEXT-ALIGN: left">
<img height="19" src="images/col1_4_01.gif"><img   class="plan" height="19" src="images/col1_4_02.gif"><img height="19" src="images/col1_4_03.gif">
        
</td>
    <TD>  知己知彼 ， 自律严谨 。 高者通常言行一致 ， 能够合理的支配自己的感情行动 。 为人处世 ， 总能保持其自尊心 ， 赢得人的尊重 ， 
        有时却不免太固执成见 。 是具有领导能力的必要条件之一，是做好生产部门主管的重要素质。</TD>
    </TR>
    <TR class="odd">
    <TD>
        <span><asp:Literal ID="ltr_Q4" runat="server">0</asp:Literal></span>
        </TD>
    <TD> 心平气和，闲散宁静。低者通常知足常乐，保持内心的平衡。也可能过份疏懒 ， 缺乏进取心。</TD>
  <td align="left" style="TEXT-ALIGN: left">
<img height="19" src="images/col1_6_01.gif"><img   height="19" class="plan" src="images/col1_6_02.gif"><img height="19" src="images/col1_6_03.gif">
      <br />
</td>
    <TD> 紧张闲扰，激动挣扎。高者通常缺乏耐心，心神不定，态度兴奋。时常感觉疲乏 ，又无法彻底摆脱以求宁静。在社群中，他对于人事一切都缺乏信念。每日生活战战兢兢 ， 
        而不能自已。不能在职业中发挥潜能的人多具高的该特点。</TD>
    </TR>



   </TBODY></TABLE>

     <script type="text/javascript">
         $(function () {
             $("#table2 tr td span").each(function (n) {

                 var fen = $(this).text();
                 var zfen = fen * 100 / 15;
                 var a = zfen.toString().indexOf(".");

                 if (a >= 0) {
                     $(this).text(zfen.toString().substring(0, a))
                 }
                 else {
                     $(this).text(zfen);
                 }
                 

                 $(this).parent().next().next().find(".plan").css("width", 340 / 100 * zfen + 70);

             });
         })
   
   
   </script>

    <br /><br />
    <asp:Literal ID="ltr_16pf" runat="server"></asp:Literal>


    

<div class="daoyu">
<div class="page2" id="nengliceshi"><b>能力倾向测试结果</b></div>
     <p>不同的职业有不同的能力要求,我们要了解自己的能力倾向，充分发展优势能力，选择与自己能力匹配的职业，才能出色的完成工作，并作出成绩。你有哪些能力，能做哪些工作？下面的能力测评结果揭示你的优势能力为言语能力，组织管理能力，人际交往能力，数理能力，运动协调能力。</p>
     <TABLE class=table1   id="table3" border=1 cellSpacing=0 cellPadding=5 width=830>
  <TBODY>
  <TR>
    <TH width="15%">类型</TH>
    <TH width="67%"><IMG src="images/table1_1.jpg"></TH>
    <TH width="18%">分数</TH></TR>
  <TR class=even>
    <TD>言语能力</TD>
    <TD style="TEXT-ALIGN: left" align=left><IMG src="images/col1_1_01.gif" 
      height=19><IMG src="images/col1_1_02.gif"  class="plan"   height=19><IMG 
      src="images/col1_1_03.gif" height=19></TD>
    <TD>
        <span><asp:Literal ID="ltr_Language" runat="server">0</asp:Literal></span>
    </TD></TR>
  <TR class=odd>
    <TD>组织管理能力</TD>
    <TD style="TEXT-ALIGN: left" align=left><IMG src="images/col1_2_01.gif" 
      height=19><IMG src="images/col1_2_02.gif" class="plan"   height=19><IMG 
      src="images/col1_2_03.gif" height=19></TD>
    <TD>
        <span><asp:Literal ID="ltr_Tissue" runat="server">0</asp:Literal></span>
      </TD></TR>
  <TR class=even>
    <TD>人际交往能力</TD>
    <TD style="TEXT-ALIGN: left" align=left><IMG src="images/col1_3_01.gif" 
      height=19><IMG src="images/col1_3_02.gif"  class="plan"   height=19><IMG 
      src="images/col1_3_03.gif" height=19></TD>
    <TD>
        <span><asp:Literal ID="ltr_Among" runat="server">0</asp:Literal></span>
      </TD></TR>
  <TR class=odd>
    <TD>数理能力</TD>
    <TD style="TEXT-ALIGN: left" align=left><IMG src="images/col1_4_01.gif" 
      height=19><IMG src="images/col1_4_02.gif"  class="plan"   height=19><IMG 
      src="images/col1_4_03.gif" height=19></TD>
    <TD>
        <span><asp:Literal ID="ltr_Mathematics" runat="server">0</asp:Literal></span>
      </TD></TR>
  <TR class=even>
    <TD>运动协调能力</TD>
    <TD style="TEXT-ALIGN: left" align=left><IMG src="images/col1_5_01.gif" 
      height=19><IMG src="images/col1_5_02.gif"  class="plan"   height=19><IMG 
      src="images/col1_5_03.gif" height=19></TD>
    <TD>
        <span><asp:Literal ID="ltr_Motion" runat="server">0</asp:Literal></span>
      </TD></TR>
  <TR class=odd>
    <TD>文字处理能力</TD>
    <TD style="TEXT-ALIGN: left" align=left><IMG src="images/col1_6_01.gif" 
      height=19><IMG src="images/col1_6_02.gif" class="plan"   height=19><IMG 
      src="images/col1_6_03.gif" height=19></TD>
    <TD>
        <span><asp:Literal ID="ltr_Writing" runat="server">0</asp:Literal></span>
      </TD></TR>
    <TR class=even>
    <TD>观察能力</TD>
    <TD style="TEXT-ALIGN: left" align=left><IMG src="images/col1_5_01.gif" 
      height=19><IMG src="images/col1_5_02.gif" class="plan"   height=19><IMG 
      src="images/col1_5_03.gif" height=19></TD>
    <TD>
        <span><asp:Literal ID="ltr_Watch" runat="server">0</asp:Literal></span>
        </TD></TR>
  <TR class=odd>
    <TD>空间能力</TD>
    <TD style="TEXT-ALIGN: left" align=left><IMG src="images/col1_6_01.gif" 
      height=19><IMG src="images/col1_6_02.gif"  class="plan"   height=19><IMG 
      src="images/col1_6_03.gif" height=19></TD>
    <TD>
        <span><asp:Literal ID="ltr_Space" runat="server">0</asp:Literal></span>
      </TD></TR>
    <TR class=even>
    <TD>艺术创作能力</TD>
    <TD style="TEXT-ALIGN: left" align=left><IMG src="images/col1_5_01.gif" 
      height=19><IMG src="images/col1_5_02.gif"  class="plan"   height=19><IMG 
      src="images/col1_5_03.gif" height=19></TD>
    <TD>
        <span><asp:Literal ID="ltr_Art" runat="server">0</asp:Literal></span>
        </TD></TR>
    </TBODY></TABLE>


     <script  type="text/javascript">

         $(function () {
             $("#table3 tr td span").each(function (n) {

                 var fen = $(this).text();
                 var zfen = 24 * fen;
                 var a = zfen.toString().indexOf(".");

                 if (a >= 0) {
                     $(this).text(zfen.toString().substring(0, a))
                 }
                 else {
                     $(this).text(zfen);
                 }
                 $(this).parent().prev().find(".plan").css("width", 340 / 100 * zfen + 70);


             });
         })
    
    
    </script>


    <br /><br />
    <div class="nengli">
    	<p style="color:#176fd9; font-size:20px; font-weight:bold;">言语能力</p>
        <p><span>指对词及其含义的理解和使用能力</span><span lang="EN-US">,</span><span>对词、句子、段落篇章的理解能力，以及善于清楚正确地表达自己的观念和向别人介绍信息的能力。</span></p>
    </div>
     <div class="nengli">
    	<p style="color:#176fd9; font-size:20px; font-weight:bold;">组织管理能力</p>
         <p class="MsoNormal">
             <span>指擅长组织上和安排各种活动，以用协调参加活动中人的人际关系的能力。</span></p>
        <p>&nbsp;</p>
    </div>
     <div class="nengli">
    	<p style="color:#176fd9; font-size:20px; font-weight:bold;">人际交往能力</p>
         <p class="MsoNormal">
             <span>指善于人与人之间的相互交往，相互联系，相互帮助，相互影响。从而协同工作或建立良好的人际关系。</span></p>
        <p>&nbsp;</p>
    </div>
     <div class="nengli">
    	<p style="color:#176fd9; font-size:20px; font-weight:bold;">数理能力</p>
         <p class="MsoNormal">
             <span>指迅速而准确地运算以及在准确的同时，能推理、解决应用问题的能力。</span></p>
    </div>
     <div class="nengli">
    	<p style="color:#176fd9; font-size:20px; font-weight:bold;">运动协调能力</p>
         <p class="MsoNormal">
             <span>指眼、手、脚、身体迅速准确随活动的作出精确的动作和运动反应，手能跟随眼所看到的东西迅速行动，进行正确控制的能力。</span></p>
        <p>&nbsp;</p>
    </div>
    <div class="nengli">
    	<p style="color:#176fd9; font-size:20px; font-weight:bold;">文字处理能力</p>
        <p>您文字驾驭能力较强，能通过语言顺畅、准确的表达自己的思想、观点、意见、使对方准确、清晰地接受传达的内容。表达富于逻辑，推理论证严密；语言形象生动，富有感染力。能胜任教师、文案、编辑、秘书、律师、主持人及播音员等工作。</p>
    </div>

    <div class="nengli">
    	<p style="color:#176fd9; font-size:20px; font-weight:bold;">观察能力</p>
        <p><span>指对物体或图形的有关细节具有正确的知觉能力，对于图形的明暗、线的宽度和长度作出区别和比较，看出其细微的差异。</span></p>
    </div>

    <div class="nengli">
    	<p style="color:#176fd9; font-size:20px; font-weight:bold;">空间能力</p>
        <p><span>指对立体图形以及平面图形与立体图形之间关系的理解能力，包括能看懂几何图形，对立体图形的三个面的理解力，识别物体在空间运动中的联系，解决几何问题。</span></p>
    </div>

    <div class="nengli">
    	<p style="color:#176fd9; font-size:20px; font-weight:bold;">艺术创作能力</p>
        <p><span>指手、手指、手腕能迅速而准确地活动和操作小的物体，在拿取、放置、换、翻转物体时手能作出精巧运动和腕的自由运动能力。</span></p>
    </div>

     </div>
    <div class="daoyu">
    <div class="page2" id="jiazhiguanceshi"><b>职 业 价 值 观 测 验 结 果</b></div>
     <p>那个职业好？哪个岗位适合自己？从事某一项工作的目的是什么？择业时想想自己工作是为了什么，工作是否满足了自己的这些期望，一下几个因素是你在未来工作中最看重的：创造性，贡献利他，自我发展，独立自由，智力激发。</p>
     <TABLE class=table1  id="table4" border=1 cellSpacing=0 cellPadding=5 width=830>
  <TBODY>
  <TR>
    <TH width="15%">类型</TH>
    <TH width="67%"><IMG src="images/table1_1.jpg"></TH>
    <TH width="18%">分数</TH></TR>
  <TR class=even>
    <TD>安全感</TD>
    <TD style="TEXT-ALIGN: left" align=left><IMG src="images/col1_1_01.gif" 
      height=19><IMG src="images/col1_1_02.gif" class="plan"   height=19><IMG 
      src="images/col1_1_03.gif" height=19></TD>
    <TD>
      <span><asp:Literal ID="ltr_Group10" runat="server">0</asp:Literal></span></TD></TR>
  <TR class=odd>
    <TD>贡献利他</TD>
    <TD style="TEXT-ALIGN: left" align=left><IMG src="images/col1_2_01.gif" 
      height=19><IMG src="images/col1_2_02.gif"  class="plan"   height=19><IMG 
      src="images/col1_2_03.gif" height=19></TD>
    <TD>
        <span><asp:Literal ID="ltr_Group1" runat="server">0</asp:Literal></span>
      </TD></TR>
  <TR class=even>
    <TD>自我发展</TD>
    <TD style="TEXT-ALIGN: left" align=left><IMG src="images/col1_3_01.gif" 
      height=19><IMG src="images/col1_3_02.gif" class="plan"   height=19><IMG 
      src="images/col1_3_03.gif" height=19></TD>
    <TD>
        <span><asp:Literal ID="ltr_Group9" runat="server">0</asp:Literal></span>
      </TD></TR>
  <TR class=odd>
    <TD>独立自由</TD>
    <TD style="TEXT-ALIGN: left" align=left><IMG src="images/col1_4_01.gif" 
      height=19><IMG src="images/col1_4_02.gif" class="plan"   height=19><IMG 
      src="images/col1_4_03.gif" height=19></TD>
    <TD>
       <span><asp:Literal ID="ltr_Group5" runat="server">0</asp:Literal></span>
      </TD></TR>
  <TR class=even>
    <TD>智力激发</TD>
    <TD style="TEXT-ALIGN: left" align=left><IMG src="images/col1_5_01.gif" 
      height=19><IMG src="images/col1_5_02.gif"  class="plan"   height=19><IMG 
      src="images/col1_5_03.gif" height=19></TD>
    <TD>
        <span><asp:Literal ID="ltr_Group3" runat="server">0</asp:Literal></span>
      </TD></TR>
  <TR class=odd>
    <TD>成就感</TD>
    <TD style="TEXT-ALIGN: left" align=left><IMG src="images/col1_6_01.gif" 
      height=19><IMG src="images/col1_6_02.gif"  class="plan"  height=19><IMG 
      src="images/col1_6_03.gif" height=19></TD>
    <TD>
        <span><asp:Literal ID="ltr_Group4" runat="server">0</asp:Literal></span>
      </TD></TR>
    <TR class=even>
    <TD>人际关系</TD>
    <TD style="TEXT-ALIGN: left" align=left><IMG src="images/col1_5_01.gif" 
      height=19><IMG src="images/col1_5_02.gif"  class="plan"   height=19><IMG 
      src="images/col1_5_03.gif" height=19></TD>
    <TD>
        <span><asp:Literal ID="ltr_Group12" runat="server">0</asp:Literal></span>
        </TD></TR>
  <TR class=odd>
    <TD>声誉地位</TD>
    <TD style="TEXT-ALIGN: left" align=left><IMG src="images/col1_6_01.gif" 
      height=19><IMG src="images/col1_6_02.gif"  class="plan"   height=19><IMG 
      src="images/col1_6_03.gif" height=19></TD>
    <TD>
        <span><asp:Literal ID="ltr_Group6" runat="server">0</asp:Literal></span>
      </TD></TR>
    <TR class=even>
    <TD>经济报酬</TD>
    <TD style="TEXT-ALIGN: left" align=left><IMG src="images/col1_5_01.gif" 
      height=19><IMG src="images/col1_5_02.gif"  class="plan"   height=19><IMG 
      src="images/col1_5_03.gif" height=19></TD>
    <TD>
        <span><asp:Literal ID="ltr_Group8" runat="server">0</asp:Literal></span>
        </TD></TR>
    <TR class=even>
    <TD>权力控制</TD>
    <TD style="TEXT-ALIGN: left" align=left><IMG src="images/col1_1_01.gif" 
      height=19><IMG src="images/col1_1_02.gif"  class="plan"   height=19><IMG 
      src="images/col1_1_03.gif" height=19></TD>
    <TD>
        <span><asp:Literal ID="ltr_Group7" runat="server">0</asp:Literal></span>
        </TD></TR>
  <TR class=odd>
    <TD>轻松舒适</TD>
    <TD style="TEXT-ALIGN: left" align=left><IMG src="images/col1_2_01.gif" 
      height=19><IMG src="images/col1_2_02.gif"  class="plan"   height=19><IMG 
      src="images/col1_2_03.gif" height=19></TD>
    <TD>
        <span><asp:Literal ID="ltr_Group11" runat="server">0</asp:Literal></span>
      </TD></TR>
  <TR class=even>
    <TD>艺术性</TD>
    <TD style="TEXT-ALIGN: left" align=left><IMG src="images/col1_3_01.gif" 
      height=19><IMG src="images/col1_3_02.gif" class="plan"   height=19><IMG 
      src="images/col1_3_03.gif" height=19></TD>
    <TD>
        <span><asp:Literal ID="ltr_Group2" runat="server">0</asp:Literal></span>
      </TD></TR>
  <TR class=odd>
    <TD>安全稳定</TD>
    <TD style="TEXT-ALIGN: left" align=left><IMG src="images/col1_4_01.gif" 
      height=19><IMG src="images/col1_4_02.gif"  class="plan"   height=19><IMG 
      src="images/col1_4_03.gif" height=19></TD>
    <TD>
        <span><asp:Literal ID="ltr_Group13" runat="server">0</asp:Literal></span>
      </TD></TR>
    </TBODY></TABLE>

        <script type="text/javascript">

            $(function () {
                $("#table4 tr td span").each(function (n) {

                    var fen = $(this).text();
                    var zfen = 5 * fen;

                    var a = zfen.toString().indexOf(".");

                    if (a >= 0) {
                        $(this).text(zfen.toString().substring(0, a))
                    }
                    else {
                        $(this).text(zfen);
                    }

                    $(this).parent().parent().find(".plan").css("width", 340 / 100 * zfen + 70);
                    

                });
            })
    
    
    </script>

    <br /><br />
    <div class="nengli">
    	<p style="color:#176fd9; font-size:20px; font-weight:bold;">安全感</p>
        <p><span>不管自己能力怎样</span><span lang="EN-US">,</span><span>希望在工作中有一个安稳的局面</span><span 
                lang="EN-US">,</span><span>不会因为奖金</span><span lang="EN-US">,</span><span>加工资</span><span 
                lang="EN-US">,</span><span>调动工作或来领导训斥等经常提心吊胆</span><span lang="EN-US">,</span><span>心烦意乱。</span></p>
    </div>
     <div class="nengli">
    	<p style="color:#176fd9; font-size:20px; font-weight:bold;">贡献利他</p>
        <p><span>工作目的和价值</span><span lang="EN-US">,</span><span>在于直接为大众的幸福和利益尽一份力</span>。</p>
    </div>
     <div class="nengli">
    	<p style="color:#176fd9; font-size:20px; font-weight:bold;">自我发展</p>
        <p><span>工作的目的和价值</span><span lang="EN-US">,</span><span>在于能和各种人交往</span><span 
                lang="EN-US">,</span><span>建立比较广泛的社会联系和关系</span><span lang="EN-US">,</span><span>甚至能和知名人物结识</span></p>
    </div>
     <div class="nengli">
    	<p style="color:#176fd9; font-size:20px; font-weight:bold;">独立自由</p>
        <p><span>工作的目的和价值</span><span lang="EN-US">,</span><span>在于能充分发挥自己的独立性和主动性</span><span 
                lang="EN-US">.</span><span>按自己的方式</span><span lang="EN-US">,</span><span>步调或想法去做</span><span 
                lang="EN-US">,</span><span>不受他人的干扰</span>。</p>
    </div>
     <div class="nengli">
    	<p style="color:#176fd9; font-size:20px; font-weight:bold;">智力激发</p>
        <p><span>工作的目的和价值</span><span lang="EN-US">,</span><span>在于不断进行智力的操作</span><span 
                lang="EN-US">,</span><span>动脑思考</span><span lang="EN-US">,</span><span>学习以及探索新事物</span><span 
                lang="EN-US">,</span><span>解决新问题。</span></p>
    </div>
    <div class="nengli">
    	<p style="color:#176fd9; font-size:20px; font-weight:bold;">成就感</p>
        <p><span>工作的目的和价值</span><span lang="EN-US">,</span><span>在于不断创新</span><span 
                lang="EN-US">,</span><span>不断取得成就</span><span lang="EN-US">,</span><span>不断得到领导与同事的赞扬或不断实现自己想要做的事</span>。</p>
    </div>
    <div class="nengli">
    	<p style="color:#176fd9; font-size:20px; font-weight:bold;">人际关系</p>
        <p><span>希望一起工作的大多数同事和领导人品较好</span><span lang="EN-US">,</span><span>相处在一起感到愉快</span><span 
                lang="EN-US">,</span><span>自然</span><span lang="EN-US">,</span><span>认为这就是很有价值的事</span><span 
                lang="EN-US">,</span><span>是一种极大的满足。</span></p>
    </div>
    <div class="nengli">
    	<p style="color:#176fd9; font-size:20px; font-weight:bold;">声誉地位</p>
        <p><span>工作的目的和价值</span><span lang="EN-US">,</span><span>在于所出事的工作在人们心目中有较高的社会地位</span><span 
                lang="EN-US">,</span><span>从而使自己得到他人的重视与尊重。</span></p>
    </div>
    <div class="nengli">
    	<p style="color:#176fd9; font-size:20px; font-weight:bold;">经济报酬</p>
        <p><span>工作的目的和价值</span><span lang="EN-US">,</span><span>在于获得优厚的报酬</span><span 
                lang="EN-US">,</span><span>使自己有足够的财力去获得自己想要的东西</span><span lang="EN-US">,</span><span>使生活过得较为富足</span>。</p>
    </div>
    <div class="nengli">
    	<p style="color:#176fd9; font-size:20px; font-weight:bold;">权利控制</p>
        <p><span>工作的目的和价值</span><span lang="EN-US">,</span><span>在于获得对他人或某事物的管理支配权</span><span 
                lang="EN-US">,</span><span>能指挥或调遣一定范围内的人或事。</span></p>
    </div>
    <div class="nengli">
    	<p style="color:#176fd9; font-size:20px; font-weight:bold;">轻松舒适</p>
        <p><span>希望能将工作做为一种消遣</span><span lang="EN-US">,</span><span>休息</span><span 
                lang="EN-US">,</span><span>或享受的形式</span><span lang="EN-US">,</span><span>追求比较舒适</span><span 
                lang="EN-US">,</span><span>轻松</span><span lang="EN-US">,</span><span>自由</span><span 
                lang="EN-US">,</span><span>优越的工作条件和环境。</span></p>
    </div>
    <div class="nengli">
    	<p style="color:#176fd9; font-size:20px; font-weight:bold;">艺术性</p>
        <p><span>工作的目的和价值</span><span lang="EN-US">,</span><span>在于能不断地追求美的东西</span><span 
                lang="EN-US">,</span><span>得到美的享受</span>。</p>
    </div>
    <div class="nengli">
    	<p style="color:#176fd9; font-size:20px; font-weight:bold;">安全稳定</p>
        <p><span>希望工作的内容经常变换</span><span lang="EN-US">,</span><span>使工作和生活显得丰富多彩</span><span 
                lang="EN-US">,</span><span>不单调枯燥</span>。</p>
    </div>

    </div>
    <%--<div class="daoyu">
   <div class="page2"><b>适 合 的 专 业</b></div>
     <p>
根据您对孩子的评价，综合以上测评结果，推荐孩子适合的专业为
<b> 书法学，学前教育，建筑工程教育，戏剧影视美术设计，教育学，舞蹈编导，体育教育，博物馆学，建筑材料工程教育，言语听觉科学。 </b>
表中的相关专业与具体职业是互相对应的，相应的职业都是从这些对应专业选拨人才的，所以选择专业时，先给自己一个规划，将来想从事什么职业，确定好职业后，再选择感兴趣的专业学习，这样以后就业会非常顺利。
</p>
<p>
<b class="f12">非常适合的职业和专业：★★★</b>
<span class="no">（您的孩子各方面非常符合该专业的要求，在此领域发展，您的孩子会如鱼得水，游刃有余）</span>
</p>
<TABLE class="table1 f8" border=0 cellSpacing=0 cellPadding=2 width=830>
  <TBODY>
  <TR>
    <TH width="15%">推荐类别</TH>
    <TH width="15%">具体职业</TH>
    <TH width="70%">相关专业</TH></TR>
  <TR class=even>
    <TD rowSpan=3>教育&nbsp;</TD>
    <TD>体育教练&nbsp;</TD>
    <TD>★★★ &nbsp;</TD></TR>
  <TR class=odd>
    <TD>幼教&nbsp;</TD>
    <TD>学前教育 ★★★ &nbsp;</TD></TR>
  <TR class=even>
    <TD>教师&nbsp;</TD>
    <TD>教育学、学前教育、言语听觉科学、建筑材料工程教育、建筑工程教育 ★★★ &nbsp;</TD></TR>
  <TR class=odd>
    <TD>专业服务&nbsp;</TD>
    <TD>培训师&nbsp;</TD>
    <TD>★★★ &nbsp;</TD></TR>
  <TR class=even>
    <TD>传媒传播&nbsp;</TD>
    <TD>道具师&nbsp;</TD>
    <TD>书法学 ★★★ &nbsp;</TD></TR>
  <TR class=odd>
    <TD>医疗&nbsp;</TD>
    <TD>护士&nbsp;</TD>
    <TD rowSpan=2>★★★ &nbsp;</TD></TR>
  <TR class=even>
    <TD>生产技术&nbsp;</TD>
    <TD>服装设计师&nbsp;</TD></TR></TBODY></TABLE><br />

    <p>
<b class="f12">一般适合的职业和专业：★</b>
<span class="no">
（您的孩子的某些特点符合该专业的要求，如果您的孩子对这里的职业和专业很感兴趣，
<br>
也不妨认真考虑。）
</span>
</p>
<table class="table1 f8" width="830" cellspacing="0" cellpadding="2" border="0">
<tbody>
<tr>
<th width="15%">推荐类别</th>
<th width="15%">具体职业</th>
<th width="70%">相关专业</th>
</tr>
<tr class="even">
<td>体育学类</td>
<td></td>
<td>体育教育 </td>
</tr>
<tr class="even">
<td>教育学类</td>
<td></td>
<td>教育学 </td>
</tr>
</tbody>
</table>
</div>--%>
<%--<div class="nengli">
<div class="page2"><b>部 分 推 荐 专 业 介 绍</b></div>
<p style="font-size:16px; font-family:微软雅黑;"><b>下面是我们根据你的测试结果，选择的最适合你的专业，依次为：财务会计教育，医学美容技术，心理学，护理学，教育学。请重点关注教育介绍。</b></p>
<p>通过培养目标和培养要求，你可以了解此专业的概貌，到底学什么，毕业后具备哪些能力；主要课程揭示了大学阶段要学习的具体科目，可以初步判断自己对这些课程是否感兴趣；职业方向明确了以后毕业将要从事的职业，看看自己是否喜欢从事这些工作，从而决定是否选择此专业进行学习。</p>
<p>专业确定后，学校首选特色专业和重点学科院校，这样转专业能力能够得到重点培养。</p>
<div class="font24">财务会计教育</div>
<p style="color:#19A6DE; text-indent:inherit;"><b>培养目标</b></p>
<p>本专业培养适应社会主义市场经济体制，现代化建设和社会进步，德、智、体、美全面发展，具备管理、经济、法律和会计学以及现代教育科学理论、教育管理技术和方法等方面的知识和能力，能在教育行政部门、大中学校、成人教育部门以及企、事业单位从事会计实务以及教学、科研方面工作的工商管理学科学教师、其他教育工作者的高级专门人才。</p>
<p style="color:#19A6DE; text-indent:inherit;"><b>培养要求</b></p>
<p>本专业学生主要学习会计、审计、工商管理和教学等方面的基本理论和基本知识，受到会计方法、技巧和教学技能等方面的基本训练，具体分析、解决会计问题和会计学专业教学的基本能力。</p>
<p style="color:#19A6DE; text-indent:inherit;"><b>主要课程</b></p>
<p>会计原理、财务会计、成本会计、管理会计、会计实务，西方财务会计，企业财务管理，审计学，社会经济统计原理，经济法，计算技术，职业教育学。</p>
<p style="color:#19A6DE; text-indent:inherit;"><b>职业方向</b></p>
<p>能在教育行政部门、大中学校、成人教育部门以及企、事业单位从事会计实务以及教学、科研方面工作的工商管理学科教学教师、其他教育工作者的高级专门人才。</p>
<p style="color:#19A6DE; text-indent:inherit;"><b>重点院校（特色专业或重点学科）</b></p>
<table class="table2 f8" width="830" cellspacing="0" cellpadding="2" border="0">
<tbody>
<tr>
<th width="10%">师范类</th>
<th class="bgf" width="90%">华中师范大学，</th>
</tr>
<tr>
<th width="10%">综合类</th>
<th class="bgf" width="90%">云南大学，</th>
</tr>
</tbody>
</table><br />
<p style="color:#19A6DE; text-indent:inherit;"><b>一般院校（特色专业或重点学科）</b></p>
<table class="table2 f8" width="830" cellspacing="0" cellpadding="2" border="0">
<tbody>
<tr>
<th width="10%">理工类</th>
<th class="bgf" width="90%">安徽科技学院，</th>
</tr>
<tr>
<th width="10%">师范类</th>
<th class="bgf" width="90%">湛江师范学院，天津职业技术师范大学，曲靖师范学院，河北师范大学，河北科技师范学院，广东技术师范学院，</th>
</tr>
<tr>
<th width="10%">民族类</th>
<th class="bgf" width="90%">云南民族大学，</th>
</tr>
<tr>
<th width="10%">农林类</th>
<th class="bgf" width="90%">内蒙古农业大学，浙江农林大学，</th>
</tr>
<tr>
<th width="10%">综合类</th>
<th class="bgf" width="90%">聊城大学，</th>
</tr>
</tbody>
</table>
</div>--%>
<%--<div class="nengli">
<div class="font24">医学美容技术</div>
<p style="color:#19A6DE; text-indent:inherit;"><b>培养目标</b></p>
<p>本专业主要培养具有医学美容技术及重要化妆品研发的基础理论、基本知识和基本技能，从事美容领域教学、科研、管理及中药化妆品研发、生产工作的高级复合型美容专业人才。</p>
<p style="color:#19A6DE; text-indent:inherit;"><b>培养要求</b></p>
<p>本专业注重医学美容基础理论、基本知识的教学，美容技能的训练。培养学生具有研究、生产中药美容护肤品，各类维护、修复、改善人体美的技术和方法的能力。要求学生达到一定的外语水平和计算机应用能力，并具有较强的自学和科研能力。</p>
<p style="color:#19A6DE; text-indent:inherit;"><b>主要课程</b></p>
<p>医学美学基础、医用细胞生物学、中医基础理论、中药学、中药化学、美容化妆品学、科研方法学、美容保健技术、美容实用技术等课程。</p>
<p style="color:#19A6DE; text-indent:inherit;"><b>职业方向</b></p>
<p>从事美容领域教学、科研、管理及中药化妆品研发、生产工作的高级复合型美容专业人才。</p>
<p style="color:#19A6DE; text-indent:inherit;"><b>一般院校（特色专业或重点学科）</b></p>
<table class="table2 f8" width="830" cellspacing="0" cellpadding="2" border="0">
<tbody>
<tr>
<th width="10%">医科类</th>
<th class="bgf" width="90%">昆明医学院，</th>
</tr>
<tr>
<th width="10%">综合类</th>
<th class="bgf" width="90%">宜春学院，</th>
</tr>
</tbody>
</table>
</div>--%>
<%--<div class="nengli">
<div class="font24">心理学</div>
<p style="color:#19A6DE; text-indent:inherit;"><b>培养目标</b></p>
<p>本专业主要培养具心理学的基本理论、基本知识、基本技能，能在科研部门、高等和中等学校、企事业单位等从事心理学科学研究、教学工作和管理工作的高级专门人才。</p>
<p style="color:#19A6DE; text-indent:inherit;"><b>培养要求</b></p>
<p>本专学生主要学习心理学方面的基本理论和基本知识，受到心理学科学思维和科学实验的基本训练，具有良好的科学素养，具备进行心理学实验和心理测量的基本能力。</p>
<p style="color:#19A6DE; text-indent:inherit;"><b>主要课程</b></p>
<p>普通心理学、实验心理学、心理统计、生理心理学、认知心理学、发展心理学、认知科学等。</p>
<p style="color:#19A6DE; text-indent:inherit;"><b>职业方向</b></p>
<p>能在科研部门、高等和中等学校、企事业单位等从事心理学科学研究、教学工作和管理工作。</p>
<p style="color:#19A6DE; text-indent:inherit;"><b>重点院校（特色专业或重点学科）</b></p>
<table class="table2 f8" width="830" cellspacing="0" cellpadding="2" border="0">
<tbody>
<tr>
<th width="10%">师范类</th>
<th class="bgf" width="90%">北京师范大学，华东师范大学，东北师范大学，</th>
</tr>
<tr>
<th width="10%">综合类</th>
<th class="bgf" width="90%">西南大学，</th>
</tr>
</tbody>
</table>
<p style="color:#19A6DE; text-indent:inherit;"><b>一般院校（特色专业或重点学科）</b></p>
<table class="table2 f8" width="830" cellspacing="0" cellpadding="2" border="0">
<tbody>
<tr>
<th width="10%">师范类</th>
<th class="bgf" width="90%">哈尔滨师范大学，内蒙古师范大学，</th>
</tr>
</tbody>
</table>
<p style="color:#19A6DE; text-indent:inherit;"><b>推荐院校（各省分布）</b></p>
<table class="table2 f8" width="830" cellspacing="0" cellpadding="2" border="0">
<tbody>
<tr>
<th width="10%">重庆</th>
<th class="bgf" width="90%">重庆大学985 211研，西南大学211，重庆师范大学，重庆文理学院，长江师范学院</th>
</tr>
</tbody>
</table>
</div>--%>
<%--<div class="nengli">
<div class="font24">护理学</div>
<p style="color:#19A6DE; text-indent:inherit;"><b>培养目标</b></p>
<p>本专业培养具备人文社会科学、医学、预防的基本知识及护理学的基本理论知识和技能，能在护理领域内从事临床护理、预防保健、护理管理、护理教学和护理科研的高级专门人才。</p>
<p style="color:#19A6DE; text-indent:inherit;"><b>培养要求</b></p>
<p>本专业学生主要学习相关的人文社会科学知识和医学基础、预防保健的基本理论知识，受到护理学的基本理论、基本知识和临床护理技能的基本训练，具有对服务对象实施整体护理及社区健康服务的基本能力。</p>
<p style="color:#19A6DE; text-indent:inherit;"><b>主要课程</b></p>
<p>人体解剖学、生理学、医学伦理学、心理学、病因学、药物治疗学、诊断学基础、护理学基础、急重症护理、内外科护理学、妇儿科护理学、精神护理学等。</p>
<p style="color:#19A6DE; text-indent:inherit;"><b>职业方向</b></p>
<p>能在教育行政部门、大中学校、成人教育部门以及企、事业单位从事会计实务以及教学、科研方面工作的工商管理学科教学教师、其他教育工作者的高级专门人才。</p>
<p style="color:#19A6DE; text-indent:inherit;"><b>重点院校（特色专业或重点学科）</b></p>
<table class="table2 f8" width="830" cellspacing="0" cellpadding="2" border="0">
<tbody>
<tr>
<th width="10%">理工类</th>
<th class="bgf" width="90%">上海交通大学，</th>
</tr>
<tr>
<th width="10%">综合类</th>
<th class="bgf" width="90%">四川大学，山东大学</th>
</tr>
<tr>
<th width="10%">医科类</th>
<th class="bgf" width="90%">天津医科大学，北京协和医学院，</th>
</tr>
</tbody>
</table><br />
<p style="color:#19A6DE; text-indent:inherit;"><b>一般院校（特色专业或重点学科）</b></p>
<table class="table2 f8" width="830" cellspacing="0" cellpadding="2" border="0">
<tbody>
<tr>
<th width="10%">医科类</th>
<th class="bgf" width="90%">首都医科大学，南京医科大学，山西医科大学，泰山医学院，新乡医学院，郧阳医学院，浙江中医药大学，南京中医药大学，中国医科大学，南方医科大学，滨州医学院，长春中医药大学，长治医学院，承德医学院，福建医科大学，广东医学院，广西医科大学，华北煤炭医学院，辽宁中医药大学，福建中医学院，</th>
</tr>
<tr>
<th width="10%">综合类</th>
<th class="bgf" width="90%">潍坊医学院，大连大学，</th>
</tr>
</tbody>
</table>
<p style="color:#19A6DE; text-indent:inherit;"><b>推荐院校（各省分布）</b></p>
<table class="table2 f8" width="830" cellspacing="0" cellpadding="2" border="0">
<tbody>
<tr>
<th width="10%">重庆</th>
<th class="bgf" width="90%">西南大学211，重庆师范大学，长江师范学院</th>
</tr>
</tbody>
</table>
</div>--%>
<div class="daoyu" id="jieshuyu">
<div class="page2"><b>结 束 语</b></div>
     <p style="color:#176fd9; font-size:20px; font-weight:bold; text-indent:inherit;">填报高考志愿的指导思想：</p><br />
     <ol>
<li><p>第一，考生填报志愿的时候要和自己的个人生涯发展规划紧密相连，有前瞻性，和自己将来发展相匹配。重点考虑毕业后要从事的职业，从职业出发选择相关专业。</p></li>
<li><p>第二，填报志愿是一个系统工程，要考虑分数、院校、专业、地域、经济、就业等因素，还有考生自身的兴趣、性格、价值观和潜能因素，这些都要综合评估。 </p></li>
<li><p>第三，一个理想志愿有两个条件，第一是适合考生长远的发展；第二是我能够达到。只有适合学生长远的发展，才会在将来升学、就业，以后工作中都能发展的更好。</p></li>
</ol>

</div>
<div class="daoyu">
	<p style="color:#176fd9; font-size:20px; font-weight:bold; text-indent:inherit;">填 报 高 考 志 愿 步 骤</p>
    <p>(1)收集信息，包括招生政策、录取形式、照顾政策，院校的历年分数线变化情况等；</p>
    <p>(2)了解自己的兴趣、性格和潜能等，为选专业做一些积淀；</p>
    <p>(3)查询职业和专业信息，锁定一个范围、详细深入了解专业就业情况、所学科目等；</p>
    <p>(4)了解院校和专业的历史沿革、归属、实力，以及学校的录取规则；</p>
    <p>(5)搜集一些填报志愿的错误案例，作为借鉴；</p>
    <p>(6)掌握自己的学习状况以及相关科目成绩实力的强弱，结合自己的特点和职业、专业的要求，综合分数等因素，来进行科学填报。</p>
<hr>
<p style="border-bottom:#000 1px solid;"></p>
<p>本测评结果只供测评者本人、家长及老师阅读。</p>
<p>咨询电话：400-0308-360</p>
<p>电子邮箱：gelun@gelun.org</p>
</div>
</div>
</body>
</html>
