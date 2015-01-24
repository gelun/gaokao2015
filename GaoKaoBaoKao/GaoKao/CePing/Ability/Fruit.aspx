<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Fruit.aspx.cs" Inherits="GaoKao.CePing.GLGKZYXZ.Ability.Fruit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="../Rports/cssstyle.css" rel="stylesheet" type="text/css" />
    <link href="../css/style.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../js/jquery-1.4.2.min.js"></script>
    <script type="text/javascript">
        window.moveTo(-4, -4);
        window.resizeTo(window.screen.availWidth + 9, window.screen.availHeight + 9);
    </script>
    <style type="text/css">
        img
        {
            margin: 0px;
            border: 0px;
            padding: 0px;
        }
        
        dd
        {
            text-align: left;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div class="mbtitu hightu1">
        职业能力倾向</div>
    <div class="hightu2">
        测评报告</div>
    <div class="mbtitu3">
    </div>
    <div class="contants">
        <div class="tit1 tit4">
            职业能力倾向测评报告</div>
        <p>
            感谢您耐心的完成本次测评，您非常想通过本测评了解自己所擅长的能力，并帮助您规划职业的发展方向，由此可见，您在这方面能够较为理性的做出判断。</p>
    </div>
    <div class="contants">
        <div class="tit3 tit5">
            简介</div>
        <p>
            职业能力倾向类型测验（General Aptitude Test Battery,简称GATB）是根据各个职业领域中，在完成工作的前提下，测量个体对九种必要的、有代表性的能力倾向拥有的程度，以探索个人职业适应范围，进而为选择所希望的职业提供一份资料。</p>
        <p>
            GATB是美国劳工部就业保险局自1934年起花费近10年时间编制而成的。总共分析了2万个企业中的7万5千个职，结果发现可分为20个职业能力模式（Occupational
            ability Patterns,简称OAP），整理出OAP所需要具备的相应能力倾向，结果选出了不可缺少的9种能力倾向。</p>
    </div>
    <div class="contants">
        <div class="tit3 tit5">
            9种能力</div>
        <p>
            首先，我们将职业能力划分为以下9种，通过以上测验，可以得出您在这9种能力方面的强弱程度。</p>
        <p>
            G—<strong class="fontred">智能</strong> (inlelligence)</p>
        <p>
            V—<strong class="fontred">言语能力</strong> (verbal aptitude)</p>
        <p>
            N—<strong class="fontred">数字能力</strong> (numerical aptitude)</p>
        <p>
            Q—<strong class="fontred">文书知觉能力</strong> (clerical perception)</p>
        <p>
            S—<strong class="fontred">空间判断能力</strong> (spatial aptilude)</p>
        <p>
            P—<strong class="fontred">形状知觉能力</strong> (form perceplion)</p>
        <p>
            K—<strong class="fontred">运动协调能力</strong> (motor coordinalion)</p>
        <p>
            F—<strong class="fontred">手指灵巧度</strong> (finger dexlerity)</p>
        <p>
            M—<strong class="fontred">手腕灵巧度</strong> (manual dexterity)</p>
    </div>
    <div class="contants">
        <div class="tit3 tit5">
            测评结果</div>
        <p>
            根据您对本测评的完成情况，可以得出您在这9种能力上的强弱程度如下：</p>
        <div class="discuss">
            <p>
                <strong class="fontred">G—智能 (inlelligence)</strong> 得分：<span class="fen"><asp:Literal
                    ID="ltr_Language" runat="server">0</asp:Literal></span>
            </p>
            <dl>
                <dt>评价：</dt>
                <dd>
                    <strong class="fontblue">强</strong> —学习能力强，对说明、指导语和诸原理能够很好的理解，擅长推理判断，能够迅速的适应新环境。</dd>
                <dd>
                    <strong class="fontblue">较强</strong>——学习能力较强，对说明、指导语和诸原理能够较好的理解，推理判断能力较好，能够较好的适应新环境。</dd>
                <dd>
                    <strong class="fontblue">一般</strong>——学习能力一般，对说明、指导语和诸原理的理解能力一般，推理判断能力一般，适应新环境的速度较慢。</dd>
                <dd>
                    <strong class="fontblue">较弱</strong>——学习能力较差，不能很好的对说明、指导语和诸原理进行理解，推理判断能力较差，不能很好的适应新环境。</dd>
                <dd>
                    <strong class="fontblue">弱</strong>——学习能力很差，对说明、指导语和诸原理的理解能力很低，不具备推理判断能力，对新环境很难适应。</dd>
            </dl>
        </div>
        <div class="discuss">
            <p>
                <strong class="fontred">V—言语能力</strong> 得分：<span class="fen"><asp:Literal ID="ltr_Mathematics"
                    runat="server">0</asp:Literal></span>
            </p>
            <dl>
                <dt>评价：</dt>
                <dd>
                    <strong class="fontblue">强</strong>——能够很好的理解言语的意义及与其相关联的概念，并有效地掌握它。对言语间的相互关系及文章和句子意义的理解能力很强。能够清晰的表达信息和自己想法。</dd>
                <dd>
                    <strong class="fontblue">较强</strong>——能够较好的理解言语的意义及与其相关联的概念，并掌握它。对言语间的相互关系及文章和句子意义的理解能力较强。能够比较清晰的表达信息和自己想法。</dd>
                <dd>
                    <strong class="fontblue">一般</strong>——能够的理解一定言语的意义及与其相关联的概念，但不一定能够掌握。对言语间的相互关系及文章和句子意义的理解能力一般。能够的表达信息和自己想法，但可能不够清晰明确。</dd>
                <dd>
                    <strong class="fontblue">较弱</strong>——不能很好的理解言语的意义及与其相关联的概念。对言语间的相互关系及文章和句子意义的理解能力较差。表达信息和自己想法不够清晰。</dd>
                <dd>
                    <strong class="fontblue">弱</strong>——很难理解言语的意义及与其相关联的概念。对言语间的相互关系及文章和句子意义的理解能力很弱。不能清晰的表达信息和自己想法。</dd>
            </dl>
        </div>
        <div class="discuss">
            <p>
                <strong class="fontred">N—数字能力</strong> 得分：<span class="fen"><asp:Literal ID="ltr_Space"
                    runat="server">0</asp:Literal></span>
            </p>
            <dl>
                <dt>评价：</dt>
                <dd>
                    <strong class="fontblue">强</strong>——在正确快速进行计算的同时，能进行推理，解决应用问题。</dd>
                <dd>
                    <strong class="fontblue">较强</strong>——能够较快的进行计算，并保证较高的正确率，同时还能进行推理，并解决应用问题。</dd>
                <dd>
                    <strong class="fontblue">一般</strong>——进行正确计算的速度一般，同时对应用问题进行推理和解决的能力一般。</dd>
                <dd>
                    <strong class="fontblue">较弱</strong>——进行正确计算的速度较慢，同时对应用问题进行推理和解决的能力较差。</dd>
                <dd>
                    <strong class="fontblue">弱</strong>——不能较快的进行正确计算，很难推理和解决应用问题。</dd>
            </dl>
        </div>
        <div class="discuss">
            <p>
                <strong class="fontred">Q—文书知觉能力</strong> 得分：<span class="fen"><asp:Literal ID="ltr_Motion"
                    runat="server">0</asp:Literal></span>
            </p>
            <dl>
                <dt>评价：</dt>
                <dd>
                    <strong class="fontred">强</strong>——对词、印刷物、票类之细微部分正确知觉的能力很好。能够直观地比较辨别词语和数字，发现错误并进行校正。
                </dd>
                <dd>
                    <strong class="fontred">较强</strong>——对词、印刷物、票类之细微部分正确知觉的能力较好。能够直观地比较辨别词语和数字，发现错误并进行校正。</dd>
                <dd>
                    <strong class="fontred">一般</strong>——对词、印刷物、票类之细微部分正确知觉的能力一般。比较辨别词语和数字的能力一般，不能很好的发现错误并进行校正。</dd>
                <dd>
                    <strong class="fontred">较弱</strong>——对词、印刷物、票类之细微部分正确知觉的能力较差。比较辨别词语和数字的能力较差，较难发现错误并进行校正。</dd>
                <dd>
                    <strong class="fontred">弱</strong>——对词、印刷物、票类之细微部分正确知觉的能力很差。不擅长辨别词语和数字，很难发现错误并进行校正。</dd>
            </dl>
        </div>
        <div class="discuss">
            <p>
                <strong class="fontred">S—空间判断能力</strong> 得分：<span class="fen"><asp:Literal ID="ltr_Watch"
                    runat="server">0</asp:Literal></span>
            </p>
            <dl>
                <dt>评价：</dt>
                <dd>
                    <strong class="fontred">强</strong>——对立体图形以及平面图形与立体图形之关系的理解能力很好。</dd>
                <dd>
                    <strong class="fontred">较强</strong>——对立体图形以及平面图形与立体图形之关系的理解能力较好。</dd>
                <dd>
                    <strong class="fontred">一般</strong>——对立体图形以及平面图形与立体图形之关系的理解能力一般。</dd>
                <dd>
                    <strong class="fontred">较弱</strong>——对立体图形以及平面图形与立体图形之关系的理解能力较差。</dd>
                <dd>
                    <strong class="fontred">弱</strong>——对立体图形以及平面图形与立体图形之关系的理解能力很差。</dd>
            </dl>
        </div>
        <div class="discuss">
            <p>
                <strong class="fontred">P—形状知觉能力</strong> 得分：<span class="fen"><asp:Literal ID="ltr_Writing"
                    runat="server">0</asp:Literal></span>
            </p>
            <dl>
                <dt>评价：</dt>
                <dd>
                    <strong class="fontred">强</strong>——对实物或图解之细微部分正确知觉的能力很好。能轻松的使用视觉进行比较辨别。能够对图形的形状和阴影的细微差异、长宽的细小差异，进行很好的辨别。</dd>
                <dd>
                    <strong class="fontred">较强</strong>——对实物或图解之细微部分正确知觉的能力较好。能较好的使用视觉进行比较辨别。能够对图形的形状和阴影的细微差异、长宽的细小差异，进行较好的辨别。</dd>
                <dd>
                    <strong class="fontred">一般</strong>——对实物或图解之细微部分正确知觉的能力一般。不能很好的的使用视觉进行比较辨别。对图形的形状和阴影的细微差异、长宽的细小差异，有一定的辨别能力。</dd>
                <dd>
                    <strong class="fontred">较弱</strong>——对实物或图解之细微部分正确知觉的能力较差。不擅长使用视觉进行比较辨别。不能很好的对图形的形状和阴影的细微差异、长宽的细小差异进行辨别。</dd>
                <dd>
                    <strong class="fontred">弱</strong>——对实物或图解之细微部分正确知觉的能力很差。不擅长使用视觉进行比较辨别。很难对图形的形状和阴影的细微差异、长宽的细小差异进行辨别。</dd>
            </dl>
        </div>
        <div class="discuss">
            <p>
                <strong class="fontred">K—运动协调能力</strong> 得分：<span class="fen"><asp:Literal ID="ltr_Art"
                    runat="server">0</asp:Literal></span>
            </p>
            <dl>
                <dt>评价：</dt>
                <dd>
                    <strong class="fontred">强</strong>——能正确而迅速地使眼和手或指协调，并迅速完成作业；能正确而迅速地作出反应动作；能够使手能跟随着眼所看到的东西迅速运动，进行正确控制</dd>
                <dd>
                    <strong class="fontred">较强</strong>——能较好而迅速地使眼和手或指协调，并较快的完成作业；能较好、较快地作出反应动作；能够使手能跟随着眼所看到的东西迅速运动，进行控制。</dd>
                <dd>
                    <strong class="fontred">一般</strong>——使眼和手或手指协调的能力一般，不能迅速的完成作业；不能迅速正确的作出反应动作；能够使手能跟随着眼所看到的东西迅速运动，进行控制。</dd>
                <dd>
                    <strong class="fontred">较弱</strong>——使眼和手或手指协调的能力较差，完成作业的速度较慢；正确的作出反应动作的能力较差；不能很好的使手能跟随着眼所看到的东西迅速运动，进行控制。</dd>
                <dd>
                    <strong class="fontred">弱</strong>——使眼和手或手指协调的能力很差，完成作业的速度很慢；很难正确迅速的作出反应动作；不能自如的使手能跟随着眼所看到的东西迅速运动，进行控制。</dd>
            </dl>
        </div>
        <div class="discuss">
            <p>
                <strong class="fontred">F—手指灵巧度</strong> 得分：<span class="fen"><asp:Literal ID="ltr_Among"
                    runat="server">0</asp:Literal></span>
            </p>
            <dl>
                <dt>评价：</dt>
                <dd>
                    <strong class="fontred">强</strong>——能快速而正确地活动手指，用手指能很好地操作细小的东西。</dd>
                <dd>
                    <strong class="fontred">较强</strong>——能较快而正确的活动手指，用手指能较好的操作细小的东西。</dd>
                <dd>
                    <strong class="fontred">一般</strong>——快速而正确的活动手指的能力一般，不太擅长用手指操作细小的东西。</dd>
                <dd>
                    <strong class="fontred">较弱</strong>——快速而正确的活动手指的能力较差，不擅长用手指操作细小的东西。</dd>
                <dd>
                    <strong class="fontred">弱</strong>——不能快速而正确的活动手指，很难用手指操作细小的东西。</dd>
            </dl>
        </div>
        <div class="discuss">
            <p>
                <strong class="fontred">M—手腕灵巧度</strong> 得分：<span class="fen"><asp:Literal ID="ltr_Tissue"
                    runat="server">0</asp:Literal></span>
            </p>
            <dl>
                <dt>评价：</dt>
                <dd>
                    <strong class="fontred">强</strong>——能够随心所欲地、灵巧地活动手及腕。拿取、放置，调换、翻转物体时，手和手腕能够精巧自由的运动。</dd>
                <dd>
                    <strong class="fontred">较强</strong>——能够较为灵巧地活动手及腕。拿取、放置，调换、翻转物体时，手和手腕能够自如流畅的运动。</dd>
                <dd>
                    <strong class="fontred">一般</strong>——能够比较自如地活动手及腕。拿取、放置，调换、翻转物体时，手和手腕能够正常的运动。</dd>
                <dd>
                    <strong class="fontred">较弱</strong>——不能灵活自如的活动手及手腕。拿取、放置，调换、翻转物体时，手和手腕的活动比较僵硬。</dd>
                <dd>
                    <strong class="fontred">弱</strong>——手及手腕的活动比较迟钝。拿取、放置，调换、翻转物体时，手和手腕的活动非常较硬。</dd>
            </dl>
        </div>
        <p>
            根据测评结果，您在<strong class="fontred  qiang"></strong> 方面有不错的能力和潜力，比较适合需要此类能力的职业。</p>
        <p>
            但是，您在<strong class="fontred ruo"></strong>方面的能力和潜力相对较弱一些，可能不太适合需要此类能力的职业。</p>
        <p>
            同时，<strong class="fontred yiban"></strong> 方面的能力，您可以通过适当的锻炼进行提高，增加自己的优势能力可以给自己的工作带来巨大帮助。</p>
        <br />
        <p>
            根据以上测评结果，可以了解到您各方面职业能力的强弱，您可以根据不同职业所需要的能力范围，来判断自己是否适合该职业。 但若要通过测评得出具体适合的职业类型，还需要通过《职业能力高级测评》来更加深入的分析和系统的归纳总结。
        </p>
    </div>
    <asp:Panel ID="panel1" runat="server">
        <div class="contants">
            <p>
                恭喜您获得了《职业能力倾向类型高级测评报告》！</p>
            <p>
                通过初级测评报告，对您的9种能力进行了评估。但是，仅仅依靠每一项的单项能力评估，无法精确的判断您所适合的具体职业类型。</p>
            <p>
                我们将这9种能力归纳，并进行综合分析，得出了<strong class="fontred">《GATB职业能力倾向类型及其适合的职业类型》</strong></p>
        </div>
        <div class="contants">
            <div class="tit3 tit5">
                GATB职业能力倾向类型及其适合的职业类型</div>
            <p>
                以上9种能力可以分别构成15种职业能力倾向类型，每种职业能力倾向类型对应一种胜任的职业类型。</p>
            <div class="highcot">
                <p>
                    <strong class="fontblue">（1）G-V-N</strong> <span class="fontred">人文系统的专业职业 </span>
                </p>
                <p>
                    <strong class="fontblue">（2）G-V-Q</strong> <span class="fontred">特别需要言语能力的事务职业 </span>
                </p>
                <p>
                    <strong class="fontblue">（3）G-N-S</strong> <span class="fontred">自然科学系统的专门职业 </span>
                </p>
                <p>
                    <strong class="fontblue">（4）G-N-Q </strong><span class="fontred">需要数字能力的一般事务职业 </span>
                </p>
                <p>
                    <strong class="fontblue">（5）G-Q-K</strong> <span class="fontred">机械事务性职业 </span>
                </p>
                <p>
                    <strong class="fontblue">（6）G-Q-M</strong> <span class="fontred">机械装置的操纵、运转及警备、保安职业
                    </span>
                </p>
                <p>
                    <strong class="fontblue">（7）G-Q </strong><span class="fontred">需要一般性判断和注意力的职业 </span>
                </p>
                <p>
                    <strong class="fontblue">（8）G-S-P </strong><span class="fontred">美术作业的职业 </span>
                </p>
                <p>
                    <strong class="fontblue">（9）N-S-M</strong> <span class="fontred">设计、制图作业及电气职业 </span>
                </p>
                <p>
                    <strong class="fontblue">（10）Q-P-F</strong> <span class="fontred">制版、描图的职业 </span>
                </p>
                <p>
                    <strong class="fontblue">（11）Q-P</strong> <span class="fontred">检查分类职业 </span>
                </p>
                <p>
                    <strong class="fontblue">（12）S-P-F</strong> <span class="fontred">造型、手指作业的职业 </span>
                </p>
                <p>
                    <strong class="fontblue">（13）S-P-M</strong> <span class="fontred">造型、手臂作业的职业 </span>
                </p>
                <p>
                    <strong class="fontblue">（14）P-M</strong> <span class="fontred">手臂作业的职业 </span>
                </p>
                <p>
                    <strong class="fontblue">（15）K-F-M</strong> <span class="fontred">看视作业、身体性作业的职业
                    </span>
                </p>
            </div>
        </div>
        <div class="contants">
            <div class="tit3 tit5">
                测评结果</div>
            <p>
                从您在以上9种能力方面的情况来看，您在多项能力上都有不错的表现和潜力，我们将其中最突出的2~3项能力进行归纳总结，根据"ATB职业能力倾向类型及其适合的职业类型"可以得出相应职业能力倾向。</p>
            <div class="discuss1">
                <p>
                    根据测评结果分析，您可胜任一下几种类型的职业（结果由“最适合”到“较适合”排序。）：</p>
            </div>
            <div class="discuss G-V-N">
                <p>
                    <strong class="fontblue">（1）G-V-N</strong> 人文系统的专业职业
                </p>
                <p>
                    <strong class="fontred">G—智能 (inlelligence)</strong></p>
                <p>
                    <strong class="fontred">V—言语能力 (verbal aptitude)：</strong>理解言语的意义及与其相关联的概念，并有效地掌握它的能力。对言语间的相互关系及文章和句子意义的理解能力。表达信息和自己想法的能力。</p>
                <p>
                    <strong class="fontred">N—数理能力 (numerical aptitude)：</strong>在正确快速进行计算的同时，能进行推理，解决应用问题的能力。</p>
                <p>
                    <strong class="fontred">分析：</strong>您有很好的学习能力，对知识、概念的理解能力很强，擅长计算、推理、判断，并解决问题。同时语言表达能力很好，能正确的理解言语或文
                    字的意义及与其相关联的概念，并有效的掌握。</p>
                <p>
                    <strong class="fontred">结论：</strong>根据G-V-N职业能力特点分析，您比较适合如社会学家、文秘、法律事务、文化经营与管理、文化传播等人文系统的专业职业。</p>
            </div>
            <div class="discuss G-V-Q">
                <p>
                    <strong class="fontblue">（2）G-V-Q</strong> 特别需要言语能力的事务职业
                </p>
                <p>
                    <strong class="fontred">G—智能 (inlelligence)：</strong>一般的学习能力。对说明、指导语和诸原理的理解能力，推理判断的能力，迅速适应新环境的能力。</p>
                <p>
                    <strong class="fontred">V—言语能力 (verbal aptitude)：</strong>理解言语的意义及与其相关联的概念，并有效地掌握它的能力。对言语间的相互关系及文章和句子意义的理解
                    能力。表达信息和自己想法的能力。</p>
                <p>
                    <strong class="fontred">Q—书写的知觉 (clerical perception)：</strong>对词、印刷物、票类之细微部分正确知觉的能力。直观地比较辨别词和数字，发现错误或校正的能力。</p>
                <p>
                    <strong class="fontred">分析：</strong>您有很好的学习能力，对知识、概念的理解能力很强，对书面文字有很好的知觉，擅长发现其中的错误并予以矫正。同时语言表达能力很好，
                    能正确的理解言语或文字的意义及与其相关联的概念，并有效的掌握。</p>
                <p>
                    <strong class="fontred">结论：</strong>根据G-V-Q职业能力特点分析，您比较适合如作家、编辑、业务人员、客服等特别需要言语能力的事务职业。</p>
            </div>
            <div class="discuss G-N-S">
                <p>
                    <strong class="fontblue">（3）G-N-S</strong> 自然科学系统的专门职业
                </p>
                <p>
                    <strong class="fontred">G—智能 (inlelligence)：</strong>一般的学习能力。对说明、指导语和诸原理的理解能力，推理判断的能力，迅速适应新环境的能力。</p>
                <p>
                    <strong class="fontred">N—数理能力 (numerical aptitude)：</strong>在正确快速进行计算的同时，能进行推理，解决应用问题的能力。</p>
                <p>
                    <strong class="fontred">S—空间判断能力 (spatial aptilude)：</strong>对立体图形以及平面图形与立体图形之关系的理解能力。</p>
                <p>
                    <strong class="fontred">分析：</strong>您有很好的学习能力，对知识、概念的理解能力很强。同时空间感很好，擅长计算、推理、判断，并解决问题。</p>
                <p>
                    <strong class="fontred">结论：</strong>根据G-N-S职业能力特点分析，您比较适合如工程师、医生、化学研究、物理研究、机械研究等自然科学系统的专门职业。</p>
            </div>
            <div class="discuss G-N-Q">
                <p>
                    <strong class="fontblue">（4）G-N-Q</strong> 需要数字能力的一般事务职业
                </p>
                <p>
                    <strong class="fontred">G—智能 (inlelligence)：</strong>一般的学习能力。对说明、指导语和诸原理的理解能力，推理判断的能力，迅速适应新环境的能力。</p>
                <p>
                    <strong class="fontred">N—数理能力 (numerical aptitude)：</strong>在正确快速进行计算的同时，能进行推理，解决应用问题的能力。</p>
                <p>
                    <strong class="fontred">Q—书写的知觉 (clerical perception)：</strong>对词、印刷物、票类之细微部分正确知觉的能力。直观地比较辨别词和数字，发现错误或校正的能力。</p>
                <p>
                    <strong class="fontred">分析：</strong>您有很好的学习能力，对知识、概念的理解能力很强，擅长计算、推理、判断，并解决问题。同时对书面文字有很好的知觉，擅长发现其中的
                    错误并予以矫正。</p>
                <p>
                    <strong class="fontred">结论：</strong>根据G-N-Q职业能力特点分析，您比较适合如财务、精算师、审计、理财顾问、程序员等需要数字能力的一般事务职业。
                </p>
            </div>
            <div class="discuss G-Q-K">
                <p>
                    <strong class="fontblue">（5）G-Q-K</strong> 机械事务性职业
                </p>
                <p>
                    <strong class="fontred">G—智能 (inlelligence)：</strong>一般的学习能力。对说明、指导语和诸原理的理解能力，推理判断的能力，迅速适应新环境的能力。</p>
                <p>
                    <strong class="fontred">Q—书写的知觉 (clerical perception)：</strong>对词、印刷物、票类之细微部分正确知觉的能力。直观地比较辨别词和数字，发现错误或校正的能力。</p>
                <p>
                    <strong class="fontred">K—运动协调 (motor coordinalion)：</strong>正确而迅速地使眼和手或指协调，并迅速完成作业的能力。正确而迅速地作出反应动作的能力。使手能跟
                    随着眼所看到的东西迅速运动，进行正确控制的能力。</p>
                <p>
                    <strong class="fontred">分析：</strong>您有很好的学习能力，对知识、概念的理解能力很强，对书面文字有很好的知觉，擅长发现其中的错误并予以矫正。同时您的眼手协调能力很
                    好，能迅速的对相应工作做出正确反应和操作，并快速的完成工作。</p>
                <p>
                    <strong class="fontred">结论：</strong>根据G-Q-K职业能力特点分析，您比较适合如银行职员、工人、手工业者等机械事务性职业。
                </p>
            </div>
            <div class="discuss G-Q-M">
                <p>
                    <strong class="fontblue">（6）G-Q-M</strong> 机械装置的操纵、运转及警备、保安职业
                </p>
                <p>
                    <strong class="fontred">G—智能 (inlelligence)：</strong>一般的学习能力。对说明、指导语和诸原理的理解能力，推理判断的能力，迅速适应新环境的能力。</p>
                <p>
                    <strong class="fontred">Q—书写的知觉 (clerical perception)：</strong>对词、印刷物、票类之细微部分正确知觉的能力。直观地比较辨别词和数字，发现错误或校正的能力。</p>
                <p>
                    <strong class="fontred">M—手腕灵巧度 (manual dexterity)：</strong>随心所欲地、灵巧地活动手及腕的能力。拿取、放置，调换、翻转物体时手的精巧运动和手腕的自由运动
                    能力。</p>
                <p>
                    <strong class="fontred">分析：</strong>您有很好的学习能力，对知识、概念的理解能力很强，对书面文字有很好的知觉，擅长发现其中的错误并予以矫正。同时您的手腕非常灵巧，
                    相关工作中可以灵活自如的运用手和手腕的力量。</p>
                <p>
                    <strong class="fontred">结论：</strong>根据G-Q-M职业能力特点分析，您比较适合如警察、保安、技术工人、司机等操作、运转及警备、保安性职业。
                </p>
            </div>
            <div class="discuss G-Q">
                <p>
                    <strong class="fontblue">（7）G-Q</strong> 需要一般性判断和注意力的职业</p>
                <p>
                    <strong class="fontred">G—智能 (inlelligence)：</strong>一般的学习能力。对说明、指导语和诸原理的理解能力，推理判断的能力，迅速适应新环境的能力。</p>
                <p>
                    <strong class="fontred">Q—书写的知觉 (clerical perception)：</strong>对词、印刷物、票类之细微部分正确知觉的能力。直观地比较辨别词和数字，发现错误或校正的能力。</p>
                <p>
                    <strong class="fontred">分析：</strong>您有很好的学习能力，对知识、概念的理解能力很强，对书面文字有很好的知觉，擅长发现其中的错误并予以矫正。</p>
                <p>
                    <strong class="fontred">结论：</strong>根据G-Q职业能力特点分析，您比较适合如财务、校对等需要一般性判断和注意力的职业。</p>
            </div>
            <div class="discuss G-S-P">
                <p>
                    <strong class="fontblue">（8）G-S-P</strong> 美术作业的职业</p>
                <p>
                    <strong class="fontred">G—智能 (inlelligence)：</strong>一般的学习能力。对说明、指导语和诸原理的理解能力，推理判断的能力，迅速适应新环境的能力。</p>
                <p>
                    <strong class="fontred">S—空间判断能力 (spatial aptilude)：</strong>对立体图形以及平面图形与立体图形之关系的理解能力。</p>
                <p>
                    <strong class="fontred">P—形状知觉 (form perceplion)：</strong>对实物或图解之细微部分正确知觉的能力。使用视觉进行比较辨别的能力。对图形的形状和阴影的细微差异
                    、长宽的细小差异，进行辨别的能力。</p>
                <p>
                    <strong class="fontred">分析：</strong>您有很好的学习能力，对知识、概念的理解能力很强，空间感很好，对图形与实务、平面与立体的感知、想象和判断能力很强，能够对形状、
                    形态之间的细微差异进行辨别。</p>
                <p>
                    <strong class="fontred">结论：</strong>根据G-S-P职业能力特点分析，您比较适合如设计、画师、雕塑师、手工艺术、特效编辑等美术作业相关性质的职业。</p>
            </div>
            <div class="discuss N-S-M">
                <p>
                    <strong class="fontblue">（9）N-S-M </strong>设计、制图作业及电气职业
                </p>
                <p>
                    <strong class="fontred">N—数理能力 (numerical aptitude)：</strong>在正确快速进行计算的同时，能进行推理，解决应用问题的能力。
                </p>
                <p>
                    <strong class="fontred">S—空间判断能力 (spatial aptilude)：</strong>对立体图形以及平面图形与立体图形之关系的理解能力。</p>
                <p>
                    <strong class="fontred">M—手腕灵巧度 (manual dexterity)：</strong>随心所欲地、灵巧地活动手及腕的能力。拿取、放置，调换、翻转物体时手的精巧运动和手腕的自由运动
                    能力。</p>
                <p>
                    <strong class="fontred">分析：</strong>您的空间感很好，擅长计算、推理、判断，并解决问题，同时您的手腕非常灵巧，相关工作中可以灵活自如的运用手和手腕的力量。</p>
                <p>
                    <strong class="fontred">结论：</strong>根据N-S-M职业能力特点分析，您比较设和如图纸设计、电气操作、机械检修等相关性质的职业。</p>
            </div>
            <div class="discuss Q-P-F">
                <p>
                    <strong class="fontblue">（10）Q-P-F</strong> 制版、描图的职业</p>
                <p>
                    <strong class="fontred">Q—书写的知觉 (clerical perception)：</strong>对词、印刷物、票类之细微部分正确知觉的能力。直观地比较辨别词和数字，发现错误或校正的能力。</p>
                <p>
                    <strong class="fontred">P—形状知觉 (form perceplion)：</strong>对实物或图解之细微部分正确知觉的能力。使用视觉进行比较辨别的能力。对图形的形状和阴影的细微差异
                    、长宽的细小差异，进行辨别的能力。</p>
                <p>
                    <strong class="fontred">F—手指灵巧度 (finger dexlerity)：</strong>快速而正确地活动手指，用手指能很好地操作细小东西的能力。</p>
                <p>
                    <strong class="fontred">分析：</strong>您对对书面文字有很好的知觉，擅长发现其中的错误并予以矫正。对图形、实物细微部分的正确知觉很敏感，能够对形状、形态之间的细微差
                    异进行辨别。同时您的手指非常灵巧，能很好的完成细微操作。</p>
                <p>
                    <strong class="fontred">结论：</strong>根据Q-P-F职业能力特点分析，您比较适合质检、制表、绘图、雕塑、手工业等监督及手工相关性质的职业。</p>
            </div>
            <div class="discuss Q-P">
                <p>
                    <strong class="fontblue">（11）Q-P</strong> 检查分类职业
                </p>
                <p>
                    <strong class="fontred">Q—书写的知觉 (clerical perception)：</strong>对词、印刷物、票类之细微部分正确知觉的能力。直观地比较辨别词和数字，发现错误或校正的能力。</p>
                <p>
                    <strong class="fontred">P—形状知觉 (form perceplion)：</strong>对实物或图解之细微部分正确知觉的能力。使用视觉进行比较辨别的能力。对图形的形状和阴影的细微差异
                    、长宽的细小差异，进行辨别的能力。</p>
                <p>
                    <strong class="fontred">分析：</strong>您对对书面文字有很好的知觉，擅长发现其中的错误并予以矫正。对图形、实物细微部分的正确知觉很敏感，能够对形状、形态之间的细微差
                    异进行辨别。</p>
                <p>
                    <strong class="fontred">结论：</strong>根据Q-P职业能力特点分析，您比较适合校对、质检等监督性质的职业。</p>
            </div>
            <div class="discuss S-P-F">
                <p>
                    <strong class="fontblue">（12）S-P-F</strong> 造型、手指作业的职业
                </p>
                <p>
                    <strong class="fontred">S—空间判断能力 (spatial aptilude)：</strong>对立体图形以及平面图形与立体图形之关系的理解能力。</p>
                <p>
                    <strong class="fontred">P—形状知觉 (form perceplion)：</strong>对实物或图解之细微部分正确知觉的能力。使用视觉进行比较辨别的能力。对图形的形状和阴影的细微差异
                    、长宽的细小差异，进行辨别的能力。</p>
                <p>
                    <strong class="fontred">F—手指灵巧度 (finger dexlerity)：</strong>快速而正确地活动手指，用手指能很好地操作细小东西的能力。</p>
                <p>
                    <strong class="fontred">分析：</strong>您的空间感很好，对图形与实务、平面与立体的感知、想象和判断能力很强，能够对形状、形态之间的细微差异进行辨别。同时您的手指非常
                    灵巧，能很好的完成细微操作。</p>
                <p>
                    <strong class="fontred">结论：</strong>根据S-P-F职业能力特点分析，您比较适合雕塑、编织、美发师、化妆师、服装设计等造型和手指作业相关性质的职业。</p>
            </div>
            <div class="discuss S-P-M">
                <p>
                    <strong class="fontblue">（13）S-P-M</strong> 造型、手指作业的职业
                </p>
                <p>
                    <strong class="fontred">S—空间判断能力 (spatial aptilude)：</strong>对立体图形以及平面图形与立体图形之关系的理解能力。</p>
                <p>
                    <strong class="fontred">P—形状知觉 (form perceplion)：</strong>对实物或图解之细微部分正确知觉的能力。使用视觉进行比较辨别的能力。对图形的形状和阴影的细微差异
                    、长宽的细小差异，进行辨别的能力。</p>
                <p>
                    <strong class="fontred">M—手腕灵巧度 (manual dexterity)：</strong>随心所欲地、灵巧地活动手及腕的能力。拿取、放置，调换、翻转物体时手的精巧运动和手腕的自由运动
                    能力。</p>
                <p>
                    <strong class="fontred">分析：</strong>您的空间感很好，对图形与实务、平面与立体的感知、想象和判断能力很强，能够对形状、形态之间的细微差异进行辨别。同时您的手腕非常
                    灵巧，相关工作中可以灵活自如的运用手和手腕的力量。</p>
                <p>
                    <strong class="fontred">结论：</strong>根据S-P-F职业能力特点分析，您比较适合雕塑、编织、美发师、化妆师、服装设计等造型和手指作业相关性质的职业。</p>
            </div>
            <div class="discuss P-M">
                <p>
                    <strong class="fontblue">（14）P-M </strong>手臂作业的职业</p>
                <p>
                    <strong class="fontred">P—形状知觉 (form perceplion)：</strong>对实物或图解之细微部分正确知觉的能力。使用视觉进行比较辨别的能力。对图形的形状和阴影的细微差异
                    、长宽的细小差异，进行辨别的能力。</p>
                <p>
                    <strong class="fontred">M—手腕灵巧度 (manual dexterity)：</strong>随心所欲地、灵巧地活动手及腕的能力。拿取、放置，调换、翻转物体时手的精巧运动和手腕的自由运动
                    能力。</p>
                <p>
                    <strong class="fontred">分析：</strong>对图形、实物细微部分的正确知觉很敏感，能够对形状、形态之间的细微差异进行辨别。同时您的手腕非常灵巧，相关工作中可以灵活自如的
                    运用手和手腕的力量。</p>
                <p>
                    <strong class="fontred">结论：</strong>根据P-M职业能力特点分析，您比较适合按摩师、美容师、造型师等相关性质的职业。</p>
            </div>
            <div class="discuss S-P-M">
                <p>
                    <strong class="fontblue">（13）S-P-M</strong> 看视作业、身体性作业的职业
                </p>
                <p>
                    <strong class="fontred">K—运动协调 (motor coordinalion)：</strong>正确而迅速地使眼和手或指协调，并迅速完成作业的能力。正确而迅速地作出反应动作的能力。使手能跟
                    随着眼所看到的东西迅速运动，进行正确控制的能力。</p>
                <p>
                    <strong class="fontred">F—手指灵巧度 (finger dexlerity)：</strong>快速而正确地活动手指，用手指能很好地操作细小东西的能力。</p>
                <p>
                    <strong class="fontred">M—手腕灵巧度 (manual dexterity)：</strong>随心所欲地、灵巧地活动手及腕的能力。拿取、放置，调换、翻转物体时手的精巧运动和手腕的自由运动
                    能力。</p>
                <p>
                    <strong class="fontred">分析：</strong>手指和手腕非常灵巧，能很好的完成细微操作并自如的运用手腕的力量。同时您的眼手协调能力很好，能迅速的对相应工作做出正确反应和操
                    作，并快速的完成工作。</p>
                <p>
                    <strong class="fontred">结论：</strong>根据K-F-M职业能力特点分析，您比较适合舞蹈、机械操作等身体协调相关性质的能力。</p>
            </div>
            <p>
                以上就是针对您所擅长的不同能力，通过GATB分析出您能够胜任的各种职业类型。了解个人的职业能力倾向类型，对于选择职业方向、选聘和任用职业人员十分重要，既可了解不同个体在能力上的差异，又能指导人们在行业中去选择适合自己发展的领域。</p>
            <p>
                以上仅为针对个人能力的测评结果，在职业方向的选择上，还可结合个人的"职业性格特点"来作为综合判断因素。</p>
            <br />
            <br />
            <br />
            <br />
            <script type="text/javascript">
                $(function () {
                    $(".discuss").hide();
                    var ty = "<%=reTy %>";

                    var tyC = ty.split("|");
                    for (var i = 0; i < tyC.length; i++) {
                        $("." + tyC[i]).show();
                    }


                });
            </script>
        </div>
    </asp:Panel>
    </form>
    <script type="text/javascript">
        $(function () {

            $(".discuss  .fen").each(function () {
                var fen = $(this).text();

                if (fen == 5) {

                    $(this).parent().append("<span>高</span>");

                }
                if (fen == 4) {
                    $(this).parent().append("<span>较高</span>");

                }
                if (fen == 3) {
                    $(this).parent().append("<span>一般</span>");

                }
                if (fen == 2) {
                    $(this).parent().append("<span>较弱</span>");

                }
                if (fen == 1) {
                    $(this).parent().append("<span>弱</span>");

                }


            });

            var q = "";
            var r = "";
            var yb = "";
            $(".discuss  .fen").each(function () {
                var fen = $(this).text();
                if (fen > 2) {
                    q += $(this).prev().text() + "、";
                }
                else if (fen == 2) {
                    yb += $(this).prev().text() + "、";
                }
                else {
                    r += $(this).prev().text() + "、";
                }

            });
            if (q.length > 0) {
                q = q.substring(0, q.length - 2);
            }

            if (r.length > 0) {
                r = r.substring(0, r.length - 2);
            }

            if (yb.length > 0) {
                yb = yb.substring(0, yb.length - 2);
            }


            if (q.length > 0) {
                $(".qiang").html(q);
            }
            else {
                $(".qiang").parent().hide();
            }

            if (r.length > 0) {
                $(".ruo").html(r);
            }
            else {
                $(".ruo").parent().hide();
            }

            if (yb.length > 0) {
                $(".yiban").html(yb);
            }
            else {
                $(".yiban").parent().hide();
            }



        });
    </script>
    <!--#include file="/commonfile/baogao_detail.html"-->
</body>
</html>
