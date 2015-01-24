<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Fruit.aspx.cs" Inherits="GaoKao.CePing.Disc.Fruit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>DISC初级测评报告</title>
    <link href="../css/style.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../js/jquery-1.4.2.min.js"></script>
    	<script type="text/javascript" src="../js/reportForms/highcharts.js"></script>
		
	
		<script type="text/javascript" src="../js/reportForms/exporting.js"></script>

        <script type="text/javascript">
            window.moveTo(-4, -4);
            window.resizeTo(window.screen.availWidth + 9, window.screen.availHeight + 9);
    </script>
</head>
<body>
    <div class="mbtitu hightu1">
        DISC</div>
    <div class="hightu2">
        测评报告</div>
    <div class="mbtitu3">
    </div>
    <div class="contants">
        <div class="tit1 tit4">
            DISC测评报告</div>
    </div>
    <div class="contants">
        <div class="tit3 tit5">
            报告阅读说明</div>
        <p>
            本报告对测评者的人格倾向进行了探测。人格倾向指的是在遗传与环境共同作用之下，测评者所表现出来的一种稳定的行为习惯体系。这个行为体系从长期来看是会变化的。但是从一段时间(一般至少6个月)来看，是比较稳定的。因此，测评者需要带着对自己负责的态度，首先把握自己的当前状态，然后规划下一步的积极行动方向。</p>
        <p>
            基于测评者完成的测评题目，而测知测评者最可能具有的稳定行为倾向。报告所给测评者提供的说明，完全依据测评者回答的题目总结归纳而出。这些结果，只是给测评者一个参考，让测评者从一个新的角度来思考自己。因此，报告不是用来限制测评者的选择，而是辅助测评者做出更有针对性的选择。这里的选择，可以是测评者的职业方向，可以是测评者人际互动的心理状态，也可以是测评者在团队中的角色定位。</p>
        <p>
            这里要特别说明的一点是：人的行为倾向没有“好”与“差”之分，但针对不同的岗位需求，却有“适合”与“不适合”的区别。因此，测评者需要根据自己的行为倾向，来分析自己最适合的空间与领域，与目前所从事的事情、学习的内容进行综合分析。
        </p>
        <p>
            要知道，习惯化的行为倾向也性格的内涵之一。而性格是测评者与环境互动过程中，长此以往形成的一种“最佳”生存模式。这种模式具有很强的稳定性，因为它们是伴随着人的成长而稳定发展起来的。因此，不要想象轻易地就去改变它们。但测评者却可以通过对报告有效利用，扬长避短，更好的发挥个人潜力。</p>
        <p>
            行为倾向只是一种可能性，要清楚自己最适合做什么，还需要好好考虑自己的能力。而在自己行为倾向上训练能力时，效率最高。因此，该报告可以指导测评者下一步需要努力的方向。</p>
        <p>
            最后需要强调一点：人的心理特征是极其复杂的，测评只能通过一定的理论与方法对测评者的心理特征，在一定的信心(信度与效度：75%-95%)水平进行推测。因此，所有的测评都达不到100%准确，因此需要测评者根据自己的现实情况做出恰当的分析与取舍。</p>
    </div>
    <div class="contants">
        <div class="tit3 tit5">
            DISC说明</div>
        <p>
            该测评是基于测谎仪的发明者，美国心理学家威廉马斯顿博士（Dr.William Moulton Marston）于20年代所研究的人格成果。它是全世界研究人类行为的重要成果。马斯顿博士的研究认为:
            我们能辨认可观察的正常人类行为可分为四大类 , 尤其是行事风格类似者会展现类似的行为，并成为一个人处理事情的方式。这四类为支配型 (Dominance)、影响型(Influence)、稳健型
            (Steadiness) 、服从型 (Compliance)</p>
        <p class="mbti_tu4">
            <img src="../images/disctu1.png" /></p>
        <p>
            DOMINANCE(支配型)：注重通过克服困难，得到成果以塑造环境。</p>
        <p>
            INFLUENCE(影响型)：注重通过影响及说服他人以塑造环境。</p>
        <p>
            STEADINESS(稳健型)：注重与他人合作以完成任务。</p>
        <p>
            CONSCIENTIOUSNESS(服从型)：注重在现存环境中确保质素及准确性。</p>
    </div>
    <div class="loading">
    </div>
    <script type="text/javascript">
        function loadings() {
            var rg = "<%=rg %>";
            var rgAr = rg.split("");
            for (var i = 0; i < rgAr.length; i++) {

                $(".loading").append("<div></div>");
                $(".loading div:last").load("innerpage/" + rgAr[i] + ".aspx");
            }

        }
        loadings();
    </script>
    <div class="contants">
        <h4>
            在不同类型上司手下价值最大化</h4>
        <p>
            <strong>对D型（支配型）上司</strong></p>
        <p>
            被测者的主管重视结果，雷厉风行。被测者的报告很可能让他觉得太冗长，难有耐心，或者没时间看完。被测者在写报告时，应该力求简短，把结果以主旨的形式先表明，内容再放在说明中条目分明地描述。让主管自由选择是否要仔细看完被测者的报告还是简要的知道要点就行。稍微乐观一些，虽然说考虑事情应该从悲观的立场来想最差的结果，可是一味的悲观会让企业与个人失去追求目标的动机，安于现状，结果是被社会淘汰了。被测者也不要光埋头苦干，光练不说是傻把式，有时候需要让主管知道被测者的努力。口头报告时也要注意不讲太多细节，直接传达事实、表示结果与决定就行了。这样会让主管觉得被测者是很细心很能干的部属，也愿意把更多的工作交给被测者做，虽然大部分都是日常的琐事。
        </p>
        <p>
            <strong>对I型（影响型）上司</strong></p>
        <p>
            被测者们的组合是最让人担心的。主管谈事情热情奔放时，被测者常会不自主的浇盆冷水。主管在描绘美好远景时，被测者又提出现状难以克服之处；主管好不容易鼓舞起大家的士气时，因为被测者一句现实严峻的话完全抹杀了。好像被测者跟主管处处相左，处处跟他作对一样。很快，主管对被测者会有其他的看法。首先被测者应该先了解主管是比较乐观的人，被测者悲观的意见对他确实会有一定的帮助，但是必须要找正确时机表达。而且必须有事实作根据，不要相当然地悲观。推理不要牵强附会。私下对他提出可能没考虑清楚的地方，对主管有很大的帮助，而且不会让主管觉得被测者在鸡蛋里挑骨头，不给面子。不要太安静，常主动找主管聊聊，会让主管对被测者印象深刻，主动的交流，学习主管的做法与观念，对被测者自我的发展有很大的帮助，因为社会随时在变化，主管是少数几位能跟得上潮流的人；而这点却是被测者最缺乏之处。
        </p>
        <p>
            <strong>对S型（稳健型）上司</strong></p>
        <p>
            被测者的上司是个喜欢团体活动的人。所以被测者也要适度的加入他的团体。首先，仔细观察那个团体影响他最多，最容易让他有家的感觉，是篮球队、还是桥牌社、还是其他各式各样他喜欢的活动，被测者不妨也加进去。逐渐地让他对被测者产生信任感。在他的专业上寻求他的指导，即使被测者已经会了，多听一次也无妨。让主管觉得能帮助被测者，他会很高兴，因为被测者的主管有一个友善、助人的心，愿意带着属下成长。表现出被测者对细节的注意程度，但是要带着正面意义，让主管觉得被测者除了人品不错之外，还有很好的工作能力。但是需要避免的是太过专注在细节，因为主管也是一样，被测者们两位的组合，完全是慢郎中团队。对变化多端的商品社会不太好适应。所以，不要让主管和自己落入细节的窠臼中，让被测者的数字能力表现在主管的眼中，让工作能有些许的创新与变化，让主管对被测者的信任与日俱增。
        </p>
        <p>
            <strong>对C型（服从型）上司</strong></p>
        <p>
            主管的特点跟被测者是一模一样的，所以被测者只要想想被测者会比较器重什么样的人就能够顺利跟主管打好关系。被测者们都有一个特点，希望跟别人保持一定距离，尊重对方的自由空间。有正事才交谈，不喜欢家长里短的说是非。但是也有相同的弱点，被测者们在谈事情时，会有严重的时间浪费，主要就是都容易分心，找不到重点。所以，要特别注意在开会前，先把自己要说的重点画出来。撰写报告时，找被测者喜欢的方式来写，被测者主管一定会认可。但是他的经验比被测者多，被测者需要多用请教与建议的语气，尊重主管。这样做的话，不需要太久，被测者的主管会把被测者当成不可或缺的重要助手的。
        </p>
        <asp:Panel ID="Panel1" runat="server">
            <div class="contants">
                <div class="tit1 tit4">
                    DISC高级测评报告</div>
            </div>
            <div class="contants">
                <div class="tit3 tit5">
                    报告阅读说明</div>
                <h4>
                <asp:Label  ID="lab_01" runat="server"></asp:Label>
                   </h4>
                <p class="mbti_tu4">
                  <div id="container"  style=" width:500px;"></div></p>


                <script type="text/javascript">

                        var chart;
                        $(document).ready(function () {
                            chart = new Highcharts.Chart({
                                chart: {
                                    renderTo: 'container',
                                    defaultSeriesType: 'column',
                                    margin: [50, 50, 100, 80]
                                },
                                title: {
                                    text: '测评结果'
                                },
                                xAxis: {
                                    categories: [
							'D',
							'S',
							'I',
							'C'
						],
                                    labels: {
                                        rotation: -45,
                                        align: 'right',
                                        style: {
                                            font: 'normal 13px Verdana, sans-serif'
                                        }
                                    }
                                },
                                yAxis: {
                                    min: 0,
                                    title: {
                                        text: '分数'
                                    }
                                },
                                legend: {
                                    enabled: false
                                },
                                tooltip: {
                                    formatter: function () {
                                        return '<b>' + this.x + '</b><br/>' +
								  + Highcharts.numberFormat(this.y, 1) ;
                                    }
                                },
                                series: [{
                                    name: 'Population',
                                    data: [<%=G1 %>,<%=G2 %>,<%=G3 %>,<%=G4 %>], //dsic
                                    dataLabels: {
                                        enabled: true,
                                        rotation: -90,
                                        color: '#FFFFFF',
                                        align: 'right',
                                        x: -3,
                                        y: 10,
                                        formatter: function () {
                                            return this.y;
                                        },
                                        style: {
                                            font: 'normal 13px Verdana, sans-serif'
                                        }
                                    }
                                }]
                            });


                        });
				
                </script>
		
                <div class="tab1">
                    <p>
                        综合特质</p>
                    <table width="80%" align="center" cellpDadding="4" class="tab3">
                        <tr>
                            <th width="5%">
                            </th>
                            <th width="25%">
                                高
                            </th>
                            <th width="25%">
                                中
                            </th>
                            <th width="25%">
                                低
                            </th>
                        </tr>
                        <tr>
                            <th>
                                D
                            </th>
                            <td>
                                在艰难的环境中，您的支配与独断个性会浮现。
                            </td>
                            <td>
                                有一定主见个和支配欲望，但不会独断专行。
                            </td>
                            <td>
                                支配度低代表您会听取他人意见，不喜欢支配他人。
                            </td>
                        </tr>
                        <tr>
                            <th>
                                I
                            </th>
                            <td>
                                在公共关系工作中，会展现出非凡的人际交往能力。
                            </td>
                            <td>
                            </td>
                            <td>
                                影响度低表示您的个性务实、理性。
                            </td>
                        </tr>
                        <tr>
                            <th>
                                S
                            </th>
                            <td>
                                压力较大的情况下，会展现出较冷静、放松（且不独断）的态度。
                            </td>
                            <td>
                                喜欢稳定不变的状态，但当机会来临时，会把握时机突破自我。
                            </td>
                            <td>
                                稳健性较低说明您喜欢变化的环境，有创新突破的潜力。
                            </td>
                        </tr>
                        <tr>
                            <th>
                                C
                            </th>
                            <td>
                                不愿多谈私事或个人的想法、感觉，服从规章制度和领导的指挥。
                            </td>
                            <td>
                            </td>
                            <td>
                                服从性较低说明您不拘泥于传统的规则，能够变通行事。
                            </td>
                        </tr>
                    </table>
                </div>
                <div class="tab1">
                    <p>
                        人际关系
                    </p>
                    <table width="80%" align="center" cellpadding="4" class="tab3">
                        <tr>
                            <th width="5%">
                            </th>
                            <th width="25%">
                                高
                            </th>
                            <th width="25%">
                                中
                            </th>
                            <th width="25%">
                                低
                            </th>
                        </tr>
                        <tr>
                            <th>
                                D
                            </th>
                            <td>
                                若情况开始恶化，他们主动提供建议的几率会大幅提升，但人际间的沟通意愿会相对降低。
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <th>
                                I
                            </th>
                            <td>
                                重视交际，维护人际关系，害怕关系被破坏。
                            </td>
                            <td>
                                进行、但并不会刻意的增加交际活动，对人际关系并不一定那么看重。
                            </td>
                            <td>
                                重视交际。
                            </td>
                        </tr>
                        <tr>
                            <th>
                                S
                            </th>
                            <td>
                                容易相处。
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <th>
                                C
                            </th>
                            <td>
                                会被动地接受他人的批评或建议，而非主动直接地发表意见。
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                        </tr>
                    </table>
                </div>
                <div class="tab1">
                    <p>
                        共通才能
                    </p>
                    <table width="80%" align="center" cellpadding="4" class="tab3">
                        <tr>
                            <th width="5%">
                            </th>
                            <th width="25%">
                                高
                            </th>
                            <th width="25%">
                                中
                            </th>
                            <th width="25%">
                                低
                            </th>
                        </tr>
                        <tr>
                            <th>
                                D
                            </th>
                            <td>
                                重视效果及效率，很清楚自己的人生目标为何，有必要时愿意等待。
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <th>
                                I
                            </th>
                            <td>
                                擅长处理公共关系，在外联业务、谈判等需要广泛交际的工作上，以及需要特殊关系协助的事务上极具才能。
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <th>
                                S
                            </th>
                            <td>
                                耐心极好，擅长完成需要极大耐心的专业化工作，且忠诚可靠。
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <th>
                                C
                            </th>
                            <td>
                                善于处理复杂的系统，工作完成质量很高，谨慎且有耐心的个性能够大大的降低工作的风险性。
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                        </tr>
                    </table>
                </div>
                <div class="tab1">
                    <p>
                        激励因子</p>
                    <table width="80%" align="center" cellpadding="4" class="tab3">
                        <tr>
                            <td colspan="3">
                                各因子的表现方式会视情况而定
                            </td>
                        </tr>
                        <tr>
                            <th width="5%">
                            </th>
                            <th width="25%">
                                高
                            </th>
                            <th width="50%">
                                他们需要和渴望的是
                            </th>
                        </tr>
                        <tr>
                            <th>
                                D
                            </th>
                            <td>
                                能够拓展其能力的艰巨任务； 得到竞争的机会，适度的施加压力；
                            </td>
                            <td>
                                <p>
                                    自由和权威</p>
                                <p>
                                    权力</p>
                                <p>
                                    物质奖励
                                </p>
                                <p>
                                    发展的机会</p>
                                <p>
                                    多样化</p>
                                <p>
                                    创新</p>
                            </td>
                        </tr>
                        <tr>
                            <th>
                                I
                            </th>
                            <td>
                                在公司内外的成就得到公司的认可和冠以荣誉； 得到精神上的鼓励与支持； 获得同事、客户以及公众的认可；
                            </td>
                            <td>
                                <p>
                                    知名度</p>
                                <p>
                                    威望和头衔</p>
                                <p>
                                    团体活动</p>
                                <p>
                                    友好的关系</p>
                                <p>
                                    人，更多的人</p>
                                <p>
                                    适宜的工作环境</p>
                            </td>
                        </tr>
                        <tr>
                            <th>
                                S
                            </th>
                            <td>
                                一个稳定，熟悉的工作环境； 负责需要耐心并能按照他们自己的节奏完成的专业化工作； 给他们时间来准备以迎接变化；
                            </td>
                            <td>
                                <p>
                                    欣赏</p>
                                <p>
                                    真诚</p>
                                <p>
                                    组织</p>
                                <p>
                                    认可其忠诚的服务</p>
                                <p>
                                    安全的环境</p>
                                <p>
                                    专业化
                                </p>
                            </td>
                        </tr>
                        <tr>
                            <th>
                                C
                            </th>
                            <td>
                                在一个完善的制度下工作； 明确界定工作目标和要求； 需要进行逻辑分析才能达到的高标准工作；
                            </td>
                            <td>
                                <p>
                                    秩序井然的环境</p>
                                <p>
                                    个人的关注</p>
                                <p>
                                    不要为了 变化而变化</p>
                                <p>
                                    团队参与</p>
                                <p>
                                    肯定</p>
                                <p>
                                    所有的实事</p>
                            </td>
                        </tr>
                    </table>
                </div>
        </asp:Panel>
        <h3>
            后记</h3>
        <p>
            人是极为复杂的，迄今为止，尚没有哪一种理论能够完全的描述一个人。本测评也只是基于一个理论，从一个角度对人的行为倾向的洞察。通过报告，相信被测者对自己的行为特征会有更多一点的理解，能够从一个结构化的层面思考自己的行为倾向。从而结合自己的现实状况，比如自己的经验、能力、爱好，最终对自己的生涯决策做出一个更合理的选择。</p>
        <p>
            测评需要探测的是被测者当前所扮演的角色的人格、行为倾向。如果被测者完成测评的时候以一个“其他人”的身份来进行，那么其结果可能就会受到影响。而完成测评过程中“扮演其他人”有可能是不由自主的事情。因此对于测评的报告，被测者需要细致分析、分辨。更重要的是，被测者需要根据测评所提供的框架结合现实，来更清晰定位和了解自己。</p>
        <p>
            如果测评报告与被测者的实际特征有一些出入，那么还有以下可能性：</p>
        <p>
            ◆回想一下自己的答题状态，是否有心情不佳。
        </p>
        <p>
            ◆看看报告是自己“期望成为”的样子，还是现在真实的样子。</p>
        <p>
            ◆从周围人的角度来审视一下自己。</p>
    </div>
</body>
</html>
