<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Fruit.aspx.cs" Inherits="GaoKao.CePing.Mbit.Fruit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>MBTI职业性格测评报告</title>
    <link href="../css/style.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../js/jquery-1.4.2.min.js"></script>
    <script type="text/javascript" src="../js/reportForms/highcharts.js"></script>
    <script type="text/javascript" src="../js/reportForms/exporting.js"></script>
    <script type="text/javascript">
        window.moveTo(-4, -4);
        window.resizeTo(window.screen.availWidth + 9, window.screen.availHeight + 9);
    </script>
    <script type="text/javascript">

        Highcharts.visualize = function (table, options) {
            // the categories
            options.xAxis.categories = [];
            $('tbody th', table).each(function (i) {
                options.xAxis.categories.push(this.innerHTML);
            });

            // the data series
            options.series = [];
            $('tr', table).each(function (i) {
                var tr = this;
                $('th, td', tr).each(function (j) {
                    if (j > 0) { // skip first column
                        if (i == 0) { // get the name and init the series
                            options.series[j - 1] = {
                                name: this.innerHTML,
                                data: []
                            };
                        } else { // add values
                            options.series[j - 1].data.push(parseFloat(this.innerHTML));
                        }
                    }
                });
            });

            var chart = new Highcharts.Chart(options);
        }



        $(document).ready(function () {
            var table = document.getElementById('datatable'),
				options = {
				    chart: {
				        renderTo: 'container',
				        defaultSeriesType: 'column'
				    },
				    title: {
				        text: '测评结果图'
				    },
				    xAxis: {
				},
				yAxis: {
				    title: {
				        text: 'Units'
				    }
				},
				tooltip: {
				    formatter: function () {
				        return '<b>' + this.series.name + '</b><br/>' +
					            this.y + ' ' + this.x.toLowerCase();
				    }
				}

};


            Highcharts.visualize(table, options);
        });
				
    </script>
</head>
<body>
    <form>
    <table id="datatable" style="display: none;">
        <thead>
            <tr>
                <th>
                </th>
                <th>
                </th>
                <th>
                </th>
            </tr>
        </thead>
        <tbody>
            <tr>
                <th>
                    外向*内向<br />
                    (E-I)
                </th>
                <td>
                    <%=E %>
                </td>
                <td>
                    <%=I %>
                </td>
            </tr>
            <tr>
                <th>
                    <font>实感*知觉<br />
                        (S-N)</font>
                </th>
                <td>
                    <%=S%>
                </td>
                <td>
                    <%=N%>
                </td>
            </tr>
            <tr>
                <th>
                    思考*情感<br />
                    (T-F)
                </th>
                <td>
                    <%=T%>
                </td>
                <td>
                    <%=F%>
                </td>
            </tr>
            <tr>
                <th>
                    判断*认知<br />
                    (J-P)
                </th>
                <td>
                    <%=J%>
                </td>
                <td>
                    <%=P%>
                </td>
            </tr>
        </tbody>
    </table>
    </form>
    <div class="mbtitu">
        MBTI职业性格测评</div>
    <div class="mbtitu2">
    </div>
    <div class="mbtitu3">
    </div>
    <div class="contants">
        <div class="tit1 tit4">
            您的性格类型</div>
        <div class="tit3 tit5">
            MBTI性格测评</div>
        <p>
            性格，也称之为人格，一般被界定为个体思想、情绪、行为与态度之总称，它也是心理学研究的重要对象。世界上关于个体性格的划分有很多种，我们按照卡尔荣格的理论将性格类型分为四个维度，每个维度有两个方向，共计八个方面，他们分别是</p>
        <br />
        <p>
            我们与世界相互作用的方式以及能量的来源： 外向——内向</p>
        <p>
            我们获取处理信息的主要方式： 实感——直觉</p>
        <p>
            我们的决策方式： 思考——情感</p>
        <p>
            我们的做事与生活的方式： 判断——知觉</p>
        <p>
            我们与世界相互作用的方式以及能量的来源： 外向——内向</p>
        <br />
        <p>
            每个人的性格都在四中维度相应分界点的这边或那边，我们称之为"偏好"。例如：如果您落在外向的那边，称为"您具有外向的偏好"；如果您落在个的那边，称为"您具有内向的偏好"。在现实生活中，每个维度的两个方面您都会用到，只是其中的一个方面您用的更频繁、更舒适，就好像每个人都会用到左手和右手。习惯用左手的人是左撇子，习惯用右手的人是右撇子。同样，您的性格类型就是您用的最频繁、最熟练的那种。</p>
        <p>
            按照这种对于人的心理类型的基本划分，人群分别属于外向型或内向型：前者倾向于在自我以外的外部世界发现意义，而后者则把相应的心理过程指向自身。接下来就是四中心理功能的划分：两种理性功能（思维和情感）以及两种感知功能（实感和直觉）。每个人都有自己的某一个主导类型，而圆满的状态，则是这四种心理能力的齐头并进。</p>
        <p class="mbti_tu4">
            <img src="../images/mbti4.jpg" /></p>
    </div>
    <div class="contants">
        <div class="tit3 tit5">
            性格维度</div>
        <h2>
            .性格维度说明</h2>
        <p>
            美国的凯恩琳•布里格斯和她的女儿伊莎贝尔•布里格斯•迈尔斯研制了迈尔斯－布里格斯类型指标(MBTI)。这个指标以瑞士心理学家荣格划分的8种类型为基础，加以扩展，形成四个维度，即</p>
        <br />
        <p>
            ① 外倾(E)－内倾(I)</p>
        <p>
            ① 外倾(E)－内倾(I)</p>
        <p>
            ① 外倾(E)－内倾(I)</p>
        <p>
            ① 外倾(E)－内倾(I)</p>
        <br />
        <p>
            四个维度如同四把标尺，每个人的性格都会落在标尺的某个点上，这个点靠近那个端点，就意味着个体就有哪方面的偏好。如在第一维度上，个体的性格靠近外倾这一端，就偏外倾，而且越接近端点，偏好越强。</p>
        <h2 class="h2two">
            .所属偏好</h2>
        <p>
            你的偏好是什么？</p>
        <p>
            我们现在首先要做的是弄清每个维度的含义，并且能估计出自己在每个维度上的偏好。</p>
        <h3>
            外倾－内倾</h3>
        <p>
            如果只能用一个维度将人群区分开来的话，那么，这个维度应该是内外倾向，它是区分个体的最基本的维度。我们以自身为界，可以将世界分为自身以外的世界和自我的世界两个部分，也可称为外部世界和内部世界。外倾的人倾向于将注意力和精力投注在外部世界，外在的人，外在的物，外在的环境等，而内倾的人则相反，较为关注自我的内部状况，如内心情感、思想。两种类型的个体在自己偏好的世界里会感觉自在、充满活力，而到相反的世界里则会不安、疲惫。因此，外倾与内倾的个体之间的区分是广泛而明显的，并不象我们平时讲的"外倾者健谈、内倾者害羞"那么简单，具体可以从下列几个方面进行分析：</p>
        <div class="tab1">
            <p>
                内倾型与外倾型的特征比较</p>
            <table width="90%" align="center" cellpadding="10">
                <tr style="background: #b7dee8;">
                    <th>
                        外倾型
                    </th>
                    <th>
                        内倾型
                    </th>
                </tr>
                <tr>
                    <td>
                        与他人相处精力充沛
                    </td>
                    <td>
                        独自度过时光精力充沛
                    </td>
                </tr>
                <tr>
                    <td>
                        行动，之后思考
                    </td>
                    <td>
                        思考，之后行动
                    </td>
                </tr>
                <tr>
                    <td>
                        喜欢边想边说出声
                    </td>
                    <td>
                        在心中思考问题
                    </td>
                </tr>
                <tr>
                    <td>
                        易于"读"和了解；随意地分享个人情况
                    </td>
                    <td>
                        更封闭，更愿意在经挑选的小群体中分享个人的情况
                    </td>
                </tr>
                <tr>
                    <td>
                        说的多于听的
                    </td>
                    <td>
                        听的比说的多
                    </td>
                </tr>
                <tr>
                    <td>
                        高度热情地社交
                    </td>
                    <td>
                        不把兴奋说出来
                    </td>
                </tr>
                <tr>
                    <td>
                        反应快，喜欢快节奏
                    </td>
                    <td>
                        仔细考虑后，才有所反应
                    </td>
                </tr>
                <tr>
                    <td>
                        重于广度而不是深度
                    </td>
                    <td>
                        喜欢深度而不是广度
                    </td>
                </tr>
            </table>
        </div>
        <p>
            参照上述的"条条框框"，你能确定你的内外倾向的偏好了吗？当然，不要期望每条标准都完全符合，大部分符合基本上就可以确定了。也不要要求每时每刻都以同样类型的方式行事。人毕竟生活在社会中，有时会顺应外在环境的、工作的需要调整自己的行为，再外倾的人，在权威人士面前或者十分隆重、严肃的场合，也会是个好的倾听者，再内倾的人，走上领导岗位，该发表意见的还得发表，准备充分的话，也会滔滔不绝。关键在于，我们需扪心自问：到底以什么样的方式行事，才是自己感觉最好的，最习惯的。</p>
        <h3>
            感觉－直觉</h3>
        <p>
            我们每个人都在不断接受着信息，这是我们跟上外界节拍的必要前提。但不同类型的个体接受信息的方式不同，这便有了感觉型与直觉型之别。首先，面对同样的情景，两者的注意中心不同，依赖的信息通道也不同。感觉型的人关注的是事实本身，注重细节，而直觉型的人注重的是基于事实的含义、关系和结论；感觉型的人信赖五官听到、看到、闻到、感觉到、尝到的实实在在、有形有据的事实和信息，而直觉型的人注重"第六感觉"，注重"弦外之音"，直觉型的人的许多结论在感觉型的人眼里，也许是飘忽的，不实在的。注重细节的结果是感觉型的人擅长记忆大量事实与材料，他们有时候像本"词典"，能清晰地讲出大量的数据、人名、概念乃至定义，常使其他人感到吃惊。而直觉型的更擅长解释事实，捕捉零星的信息，分析事情的发展趋向。其次，感觉型的人对待任务，习惯于按照规则、手册办事，比如照着手册使用家电，比如看着地图辨认交通路线，而直觉型的人，习惯尝试，跟着感觉走，他不习惯仔细地看完一大本说明书再动手，结果呢？可能比感觉型的人更快地完成了任务，也可能因为失败而须重新开始。感觉型习惯于固守现实，享受现实，使用已有的技能，直觉型的人更习惯变化、突破现实。简言之，感觉型注意"是什么"，实际而仔细。直觉型则更关心"可能是什么"。具体区别如下：</p>
        <div class="tab1">
            <p>
                感觉型与直觉型的特征比较</p>
            <table width="90%" align="center" cellpadding="10">
                <tr style="background: #b7dee8;">
                    <th>
                        感觉型
                    </th>
                    <th>
                        直觉型
                    </th>
                </tr>
                <tr>
                    <td>
                        相信确定和有型的东西
                    </td>
                    <td>
                        相信灵感和推断
                    </td>
                </tr>
                <tr>
                    <td>
                        喜欢新想法—除非它们有实际意义
                    </td>
                    <td>
                        为了自己的利益，喜欢新思想和概念
                    </td>
                </tr>
                <tr>
                    <td>
                        重视现实性和常情
                    </td>
                    <td>
                        重视想象力和独创力
                    </td>
                </tr>
                <tr>
                    <td>
                        喜欢使用和琢磨已知的技能
                    </td>
                    <td>
                        喜欢学习新技能，但掌握之后很容易就厌倦了
                    </td>
                </tr>
                <tr>
                    <td>
                        留心具体的和特殊的；进行细节描述
                    </td>
                    <td>
                        留心普遍的和有象征性的；使用隐喻和类比
                    </td>
                </tr>
                <tr>
                    <td>
                        循序渐进地讲述有关情况
                    </td>
                    <td>
                        跳跃性地展现事实
                    </td>
                </tr>
                <tr>
                    <td>
                        着眼于现实
                    </td>
                    <td>
                        以一种绕圈子的方式着眼于未来
                    </td>
                </tr>
            </table>
        </div>
        <p>
            在我们的周围，两种类型的人都会存在，当然极端典型的比较少，大多数人兼有两种特质，但其中一种会更突出一些，成为本人的特色，也由此可以确定本人的类型。使用哪种方式接受信息都有利有弊。作为个体，往往只擅长一种，了解到这点，直觉型的人就不必在百科全书式的人物面前自叹弗如，感觉型的人也无需在灵动、敏感的直觉者面前不好意思了。当然，我们在享受自我性格类型所带来的优势的同时，也不妨逐渐有意识地弥补弥补弱处，比如说，直觉型的人可多关注一些细节，而感觉型的人可多留神蕴含的潜在信息。国外的研究表明，25岁以后，伴随着对于人生的反思，个体完善自我性格的倾向会更明确。确定一下你的类型，看看这种类型的优势所在。</p>
        <h3>
            思维－情感</h3>
        <p>
            这是从作决策的方式来看。仅看这个维度的名称，也许你会觉得，思维型的人是理性的，而情感性的人是非理性的，事实上并非如此。两类人都有理性思考的成分，但作决定或下结论的主要依据不一样。情感型的人常从自我的价值观念出发，变通地贯彻规章制度，做出一些自己认定是对的决策，比较关注决策可能给他人带来的情绪体验，人情味较浓。思维型的人则比较注重依据客观事实的分析，一以贯之、一视同仁地贯彻规章制度，不太习惯根据人情因素变通，哪怕做出的决定并不令人舒服。具体区别如下：</p>
        <div class="tab1">
            <p>
                思维型与情感型的特征区别</p>
            <table width="90%" align="center" cellpadding="10">
                <tr style="background: #b7dee8;">
                    <th>
                        思维型
                    </th>
                    <th>
                        情感性
                    </th>
                </tr>
                <tr>
                    <td>
                        退后一步思考，对问题进行非个人因素的分析
                    </td>
                    <td>
                        超前思考，考虑行为对他人的影响
                    </td>
                </tr>
                <tr>
                    <td>
                        重视符合逻辑、公正、公平的价值；一视同仁
                    </td>
                    <td>
                        重视同情与和睦：重视准则的例外性
                    </td>
                </tr>
                <tr>
                    <td>
                        被认为冷酷、麻木、漠不关心
                    </td>
                    <td>
                        被认为感情过多，缺少逻辑性，软弱
                    </td>
                </tr>
                <tr>
                    <td>
                        认为圆通比坦率更重要
                    </td>
                    <td>
                        认为圆通与坦率同样重要
                    </td>
                </tr>
                <tr>
                    <td>
                        只有情感符合逻辑时，才认为它可取
                    </td>
                    <td>
                        无论是否有意义，认为任何感情都可取
                    </td>
                </tr>
                <tr>
                    <td>
                        被渴望成就而激励
                    </td>
                    <td>
                        被为了获得欣赏而激励
                    </td>
                </tr>
                <tr>
                    <td>
                        很自然地看到缺点，倾向于批评
                    </td>
                    <td>
                    </td>
                </tr>
            </table>
        </div>
        <p>
            不同性别的个体在这个维度上的偏好有所差异，据研究，大约2/3的女性偏好情感型，2/3的男性偏好思维型，什么原因造成的？也许社会本身对不同性别的人就给予了不同的期待，期待女性的同情心，期待男性的冷静、客观。其实，这两种类型无所谓好或坏，重要的是理解和自己不同类型的人的做法，并且尽量避免走入极端，极端的思维倾向，可能会给人"冷酷"的感觉，而极端的情感倾向则给人"无原则"的感觉。看看你的性格在这个维度上会有什么样的偏好？</p>
        <h3>
            判断－知觉</h3>
        <p>
            这是从喜好的生活方式来看。如果我们看看人们的办公桌上、包内或柜子里摆放的物品，可以发现，有些人经常是井然有序，而有些人就不那么习惯于保持整齐，前者是判断型具有的特征，后者是知觉型的人经常有的状态。不仅如此，在处事方式上，判断型的人目的性较强，一板一眼，他们喜欢有计划、有条理的世界，更愿意以比较有序的方式生活。知觉型的人好奇性、适宜性强，他们会不断关注新的信息，喜欢变化，也会考虑许多可能的变化因素，更愿意以比较灵活、随意、开放的方式生活。在做决策时，判断型的人较为果断，而知觉型的人总希望获得更多信息后再决断。逛了两天商场，还决定不了买什么的人，多半是知觉型的。两者的具体区别如下：</p>
        <div class="tab1">
            <p>
                判断型与知觉型的特征区别</p>
            <table width="90%" align="center" cellpadding="10">
                <tr style="background: #b7dee8;">
                    <th>
                        判断型
                    </th>
                    <th>
                        知觉型
                    </th>
                </tr>
                <tr>
                    <td>
                        做了决定后最为高兴
                    </td>
                    <td>
                        当各种选择都存在时，感到高兴
                    </td>
                </tr>
                <tr>
                    <td>
                        有"工作原则"：工作第一，玩其次（如果有时间的话）
                    </td>
                    <td>
                        "玩的原则"：现在享受，然后再完成工作（如果有时间的话）
                    </td>
                </tr>
                <tr>
                    <td>
                        建立目标，准时地完成
                    </td>
                    <td>
                        随着新信息的获取，不断改变目标
                    </td>
                </tr>
                <tr>
                    <td>
                        愿意知道它们将面对的情况
                    </td>
                    <td>
                        喜欢适应新情况
                    </td>
                </tr>
                <tr>
                    <td>
                        着重结果（重点在于完成任务）
                    </td>
                    <td>
                        着重过程（重点在于如何完成工作）
                    </td>
                </tr>
                <tr>
                    <td>
                        满足感来源于完成计划
                    </td>
                    <td>
                        满足感来源于计划的开始
                    </td>
                </tr>
                <tr>
                    <td>
                        把时间看作有限的资源，认真地对待最后期限
                    </td>
                    <td>
                        认为时间是可更新的资源，而最后期限也是有收缩的
                    </td>
                </tr>
            </table>
        </div>
        <p>
            大多数人兼具两种倾向，只是更偏向某一端。我们在日常生活、工作中，也会受其它因素影响，改变一贯的方式，如面临紧急的、或期限明确的任务，知觉型的人也会果断起来。兴致所至，也会把物品收拾的整整齐齐，但这些并不是他们常有的行为方式，也不是他们内心感到真正自然、舒服的方式。作为个体，一方面根据内心的感受识别自我的偏好，发挥优势，另一方面，则要约束一下性格的弱点。如完全的判断型，比较容易走入刻板、教条的境地，完全的知觉型则容易使事情的进行没有限制。看看最后一个维度上，你的偏好是什么？</p>
        <h2 class="h2two">
            .性格维度说明</h2>
        <div class="tab1">
            <p>
                四个维度的简单说明及人群中所占比例</p>
            <table width="70%" align="center" cellpadding="4" class="tab2" style="font-size: 12px;">
                <tr>
                    <th colspan="3">
                        我们与世界的相互作用方式以及能量的来源
                    </th>
                </tr>
                <tr>
                    <td width="10%" style="text-align: center">
                        外向
                    </td>
                    <td width="5%">
                        <img src="../images/mbtitu10.gif" />
                    </td>
                    <td width="85%">
                        关注自己如何影响外部环境：将心理能量和注意力聚集于外部世界和与他人的交往上。例如：聚会、讨论、聊天。<span class="fontred">外向的人占人群总数的44%</span>
                    </td>
                </tr>
                <tr>
                    <td style="text-align: center">
                        内向
                    </td>
                    <td>
                        <img src="../images/mbtitu11.gif" />
                    </td>
                    <td>
                        关注外部环境的变化对自己的影响：将心理能量和注意力聚集于内部世界，注重自己的内心体验。例如：独立思考，看书，避免成为注意的中心，听的比说的多。<span class="fontred">内向的人占人群总数的56%</span>
                    </td>
                </tr>
                <tr>
                    <th colspan="3">
                        我们获取处理信息的主要方式
                    </th>
                </tr>
                <tr>
                    <td style="text-align: center">
                        实感
                    </td>
                    <td>
                        <img src="../images/mbtitu12.gif" />
                    </td>
                    <td>
                        关注由感觉器官获取的具体信息：看到的、听到的、闻到的、尝到的、触摸到的事物。例如：关注细节、喜欢描述、喜欢使用和琢磨已知的技能。<span class="fontred">实感的人占人群总数的53%</span>
                    </td>
                </tr>
                <tr>
                    <td style="text-align: center">
                        直觉
                    </td>
                    <td>
                        <img src="../images/mbtitu13.gif" />
                    </td>
                    <td>
                        关注事物的整体和发展变化趋势：灵感、预测、暗示，重视推理。例如：重视想象力和独创力，喜欢学习新技能，但容易厌倦、喜欢使用比喻，跳跃性思地展现事实。<span class="fontred">直觉的人占人群总数的47%</span>
                    </td>
                </tr>
                <tr>
                    <td colspan="3">
                        我们的决策方式
                    </td>
                </tr>
                <tr>
                    <td style="text-align: center">
                        思考
                    </td>
                    <td>
                        <img src="../images/mbtitu14.gif" />
                    </td>
                    <td>
                        重视事物之间的逻辑关系，喜欢通过客观分析做决定评价。例如：理智、客观、公正、认为圆通比坦率更重要。<span class="fontred">思考的人占人群总数的39%</span>
                    </td>
                </tr>
                <tr>
                    <td style="text-align: center">
                        情感
                    </td>
                    <td>
                        <img src="../images/mbtitu15.gif" />
                    </td>
                    <td>
                        以自己和他人的感受为重，将价值观作为判定标准。例如：有同情心、善良、和睦、善解人意，考虑行为对他人情感的影响，认为圆通和坦率同样重要。<span class="fontred">情感的人占人群总数的61%</span>
                    </td>
                </tr>
                <tr>
                    <td colspan="3">
                        我们的做事与生活方式
                    </td>
                </tr>
                <tr>
                    <td style="text-align: center">
                        判断
                    </td>
                    <td>
                        <img src="../images/mbtitu16.gif" />
                    </td>
                    <td>
                        喜欢做计划和决定，愿意进行管理和控制，希望生后井然有序。例如：重视结果（重点在于完成任务）、按部就班、有条理、尊重时间期限、喜欢做决定。<span class="fontred">判断的人占人群总数的56%</span>
                    </td>
                </tr>
                <tr>
                    <td style="text-align: center">
                        知觉
                    </td>
                    <td>
                        <img src="../images/mbtitu17.gif" />
                    </td>
                    <td>
                        灵活、试图去理解、适应环境、倾向于留有余地，喜欢宽松自由的生活方式。例如：重视过程，随信息的变化不断调整目标，喜欢有多种选择。<span class="fontred">知觉的人占人群总数的44%</span>
                    </td>
                </tr>
            </table>
            <p class="fontred">
                （申明：以上的统计比例为实时的真实数据。样本量：343028，截止时间：13年X月X日）<br />
                （以上比例，及统计样本量，以343028为基数，根据参与测评者的实时数据进行自动更新）</p>
        </div>
    </div>
    <div class="contants">
        <div class="tit3 tit5">
            您的性格维度<span class="font12">（根据测评结果显示）</span></div>
        <p class="mbti_tu4">
            <div id="container" style="width: 800px; height: 400px; margin: 0 auto">
            </div>
        </p>
        <p>
            上图反应了您个性维度的相对强弱程度，通过对比，您可以了解您在各个性格维度方面的倾向。某个字母的分值越高，代表该字母所对应的性格方面有着更加明显的倾向。</p>
        <div class="tab1">
            <table width="50%" align="center" cellpadding="0" cellspacing="0" class="tab4">
                <tbody>
                    <tr>
                        <td width="7%">
                        </td>
                        <td width="10%">
                            轻微
                        </td>
                        <td width="1%">
                            |
                        </td>
                        <td width="10%">
                            中等
                        </td>
                        <td width="1%">
                            |
                        </td>
                        <td width="10%">
                            明显
                        </td>
                        <td width="1%">
                            |
                        </td>
                        <td width="10%">
                            非常明显
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                        <td>
                        </td>
                        <td>
                        </td>
                        <td>
                        </td>
                        <td>
                        </td>
                        <td>
                        </td>
                        <td>
                        </td>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td style="border-right: 1px solid #000;">
                            内向
                        </td>
                        <td colspan="7" style="text-align: left;">
                            <span class="boder">
                                <img src="../images/span-bg2.gif" style="border: 1px solor #000;"></span>
                        </td>
                    </tr>
                    <tr>
                        <td style="border-right: 1px solid #000;">
                        </td>
                        <td>
                        </td>
                        <td>
                        </td>
                        <td>
                        </td>
                        <td>
                        </td>
                        <td>
                        </td>
                        <td>
                        </td>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td style="border-right: 1px solid #000;">
                            实感
                        </td>
                        <td colspan="7" style="text-align: left;">
                            <span class="boder">
                                <img src="../images/span-bg2.gif" style="border: 1px solor #000;"></span>
                        </td>
                    </tr>
                    <tr>
                        <td style="border-right: 1px solid #000;">
                        </td>
                        <td>
                        </td>
                        <td>
                        </td>
                        <td>
                        </td>
                        <td>
                        </td>
                        <td>
                        </td>
                        <td>
                        </td>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td style="border-right: 1px solid #000;">
                            思考
                        </td>
                        <td colspan="7" style="text-align: left;">
                            <span class="boder">
                                <img src="../images/span-bg2.gif" style="border: 1px solor #000;"></span>
                        </td>
                    </tr>
                    <tr>
                        <td style="border-right: 1px solid #000;">
                        </td>
                        <td>
                        </td>
                        <td>
                        </td>
                        <td>
                        </td>
                        <td>
                        </td>
                        <td>
                        </td>
                        <td>
                        </td>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td style="border-right: 1px solid #000;">
                            判断
                        </td>
                        <td colspan="7" style="text-align: left;">
                            <span class="boder">
                                <img src="../images/span-bg2.gif" style="border: 1px solor #000;"></span>
                        </td>
                    </tr>
                </tbody>
            </table>
            <script type="text/javascript">
                var rg = "<%=reGeLeiXing %>";
                var rgAr = rg.split("");
                var vlAr = "<%=valList %>".split(",");

                var rgName = "";
                var rgValue = 0;
                for (var i = 0; i < 4; i++) {
                    switch (rgAr[i]) {
                        case "E":
                            rgName = "外向";
                            rgValue = vlAr[i];
                            break;
                        case "I":
                            rgName = "内向";
                            rgValue = vlAr[i];
                            break;
                        case "S":
                            rgName = "实感";
                            rgValue = vlAr[i];
                            break;
                        case "N":
                            rgName = "直觉";
                            rgValue = vlAr[i];
                            break;
                        case "T":
                            rgName = "思考";
                            rgValue = vlAr[i];
                            break;
                        case "F":
                            rgName = "情感";
                            rgValue = vlAr[i];
                            break;
                        case "J":
                            rgName = "判断";
                            rgValue = vlAr[i];
                            break;
                        case "P":
                            rgName = "知觉";
                            rgValue = vlAr[i];
                            break;
                    }

                    //计算长度
                    var widt = 290 / 100 * rgValue * 10 + 50;
                    //设置相关数据



                    $(".tab4 tr:even").eq(i + 1).find("td").eq(0).text(rgName).next().find("img").css({ "width": widt + "px", height: "28px" });

                }

            </script>
        </div>
        <p>
            上图反应了您所倾向的性格的明显程度，分为轻微、中等、明显、非常明显四个程度等级。如果您的明显程度越高，本报告结果与您的符合程度也相应越好。</p>
    </div>
    <div class="contants">
        <div class="tit3 tit5">
            16种职业性格类型表</div>
        <div class="tab1">
            <p>
                十六种性格类型表</p>
            <table width="90%" align="center" cellpadding="10">
                <tr>
                    <td>
                        ISTJ
                        <br />
                        <p class="fr">
                            内倾、感觉、思维、判断</p>
                    </td>
                    <td>
                        ISFJ
                        <br />
                        <p class="fr">
                            内倾、感觉、情感、判断</p>
                    </td>
                </tr>
                <tr>
                    <td>
                        ISTP
                        <br />
                        <p class="fr">
                            内倾、感觉、思维、知觉</p>
                    </td>
                    <td>
                        ISFP
                        <br />
                        <p class="fr">
                            内倾、感觉、情感、知觉</p>
                    </td>
                </tr>
                <tr>
                    <td>
                        INFJ
                        <br />
                        <p class="fr">
                            内倾、直觉、情感、判断</p>
                    </td>
                    <td>
                        INTJ
                        <br />
                        <p class="fr">
                            内倾、直觉、思维、判断</p>
                    </td>
                </tr>
                <tr>
                    <td>
                        INFP
                        <br />
                        <p class="fr">
                            内倾、直觉、情感、知觉</p>
                    </td>
                    <td>
                        INTP
                        <br />
                        <p class="fr">
                            内倾、直觉、思维、知觉</p>
                    </td>
                </tr>
                <tr>
                    <td>
                        ESTP
                        <br />
                        <p class="fr">
                            外倾、感觉、思维、知觉</p>
                    </td>
                    <td>
                        ESFP
                        <br />
                        <p class="fr">
                            外倾、感觉、情感、知觉</p>
                    </td>
                </tr>
                <tr>
                    <td>
                        ESTJ
                        <br />
                        <p class="fr">
                            外倾、感觉、思维、判断</p>
                    </td>
                    <td>
                        ESFJ
                        <br />
                        <p class="fr">
                            外倾、感觉、情感、判断</p>
                    </td>
                </tr>
                <tr>
                    <td>
                        ENFP
                        <br />
                        <p class="fr">
                            外倾、直觉、情感、知觉</p>
                    </td>
                    <td>
                        ENTP
                        <br />
                        <p class="fr">
                            外倾、直觉、思维、知觉</p>
                    </td>
                </tr>
                <tr>
                    <td>
                        ENFJ
                        <br />
                        <p class="fr">
                            外倾、直觉、情感、判断</p>
                    </td>
                    <td>
                        ENTJ
                        <br />
                        <p class="fr">
                            外倾、直觉、思维、判断</p>
                    </td>
                </tr>
            </table>
        </div>
    </div>
    <div id="loadings">
    </div>
    <script type="text/javascript">
        var rg = "<%=reGeLeiXing %>";
        function loading() {
            var isMember = "<%=isMember %>";
            var ulrs = (isMember == "False" ? "innerpage/" + rg + ".html" : "innermemberpage/" + rg + ".aspx");
            $("#loadings").load(ulrs);

        }
        loading(); //加载数据
    
    </script>
    <!--#include file="/commonfile/baogao_detail.html"-->
</body>
</html>
