<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FruitSenior.aspx.cs" Inherits="GaoKao.CePing.WenLi.FruitSenior" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>文理分科初级测评报告</title>
    <link href="../css/style.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../js/jquery-1.4.2.min.js"></script>
    <script type="text/javascript" src="../js/reportForms/highcharts.js"></script>
    <script type="text/javascript" src="../js/reportForms/exporting.js"></script>
      
    <script type="text/javascript">

        var chart;
        $(document).ready(function () {
            $("#xingqu").hide();

            /**************************************/

            chart = new Highcharts.Chart({
                chart: {
                    renderTo: 'container',
                    defaultSeriesType: 'column',
                    margin: [50, 50, 100, 80]
                },
                title: {
                    text: '职业兴趣统计结果'
                },
                xAxis: {
                    categories: [
							'R型',
							'I型',
							'A型',
							'S型',
							'E型',
							'C型'
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
                        text: '分数值'
                    }
                },
                legend: {
                    enabled: false
                },
                tooltip: {
                    formatter: function () {
                        return '<b>' + this.x + '</b><br/>' + Highcharts.numberFormat(this.y, 1);
                    }
                },
                series: [{
                    name: 'Population',
                    data: [<%=lb_Reality.Text %>,<%=lb_Study.Text %>, <%=lb_Art.Text %>, <%=lb_Society.Text %>, <%=lb_Business.Text %>, <%=lb_Tradition.Text %>],
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
                }],colors: [
                   '#2f7ed8', 
                   '#0d233a', 
                   '#8bbc21', 
                   'red', 
                   '#1aadce', 
                   '#492970'
                  
                ]
            });


        });
    </script>
    
        <script type="text/javascript">
            window.moveTo(-4, -4);
            window.resizeTo(window.screen.availWidth + 9, window.screen.availHeight + 9);
    </script>
</head>
<body>
    <div class="mbtitu hightu1">
        文理分科</div>
    <div class="hightu2">
        高级测评报告</div>
    <div class="mbtitu3">
    </div>
    <div class="contants">
        <div class="tit1 tit4">
            文理分科高级测评报告</div>
    </div>
    <div class="contants">
        <div class="tit3 tit5">
            简介</div>
        <p>
            　　文理分科是高中生活中的一次重大选择，是今后人生道路的分水岭。文理分科将影响到大学的专业选择，专业选择又与未来的职业有着紧密的联系。因此，在选择文理分科时，每一位学生和家长都要保持理性，一定要仔细深入地想一想，自己将来到底想做什么，对什么感兴趣，结合自己的学科优势，理智的做出选择。</p>
        <h2>
            首先要正确认识文理科特点：</h2>
        <p>
            文科侧重以论理和表达为能力的形象思维，在学习上注重以记忆、归纳、整理、比较等特点。文科对应的高等院校相对较少，从就业角度看，文科主要培养以社会为对象的事务型人才，主要从事外交、法律、媒体传播、金融财会、社会服务等行业。</p>
        <p>
            理科侧重以推理和研究为能力的逻辑思维，在学习上注重以记忆、理解、推理、计算为特点。理科对应的高等院校较多，社会需求也相对较多，从就业角度看，理科培养以技术为对象的科技研究、生产型人才，可从事的职业类型相对宽泛。</p>
        <h2>
            其次，要正确认识自身的特点：</h2>
        <p>
            一方面你要考虑自己真正喜欢什么科目？是物理、化学、生物？还是历史、地理、政治？如果文理水平差不多，你的潜力在哪？</p>
        <p>
            另一方面，选择文理分科除了要考虑自身成绩和对科目的兴趣外，还有一个非常重要的因素——你将来想从事、适合从事什么样的职业？</p>
        <p>
            您可通过 《文理分科高级测评报告》 来通过对您职业兴趣及倾向的具体分析，来获得更加细致具体的分析和建议。
        </p>
        <p>
            “格伦高中文理分科高级测评系统”以霍兰德职业兴趣理论为基础，结合能力倾向测验进行综合测评，帮助你了解自己的专业兴趣和能力倾向，根据你的不同特点，在365个职业和545个专业中匹配出适合的职业和专业，以此为依据，给你提供文理分科参考，从而帮助你做出正确的第一步职业生涯决策，为以后的顺利就业奠定良好的基础。
        </p>
    </div>
    <div class="contants">
        <div class="tit3 tit5">
            阅读建议</div>
        <p>
            ·测验结果只是为您提供参考，文理分科时，您还需要考虑其他方面的因素，如各科成绩、家庭经济状况、升学和就业的现状和趋势等；</p>
        <p>
            ·花点时间与您身边的人，如家人、老师和职业指导或咨询专家讨论一下你个门功课的优势，未来的职业发展打断等，确定你的思维特点和发展方向；</p>
        <p>
            ·请认真阅读每一个环节测验结果的具体解释，并结合自己的实际情况，深入思考，测评结果对于今后就业方向也有很强的指导意义。</p>
    </div>
   <div class="contants">
      <h2>霍兰德的职业兴趣理论</h2>
      <p>
       霍兰德的职业兴趣理论，其核心是按照不同的职业特点和个性特征将人分为六类：实践型、研究型、艺术型、社会型、管理型、常规型，这六种类型的人具有不同的典型特征。每种类型的人对相应职业类型感兴趣，当我们就业择业的时候，我们的兴趣与职业环境的匹配是形成职业满意度、成就感的基础。 
      </p>
      <p>
      　　本测试以霍兰德职业兴趣（ Holland Vocational Interest Theory ）理论为基础， 从你想、喜欢干什么(兴趣)和你擅长干什么(能力)两个方面测查个体的职业倾向， 同时在题目内容设计方面结合了当代中国大学生的实际情况。通过本测试，可以帮助测试者较为准确地了解自身的个体特点和职业特点之间的匹配关系，同时为测评者在进行专业选择和职业选择时，提供客观的参考依据。 
      </p>

      <h3>测试结果</h3>
       <h2>
            得分说明：</h2>
        <p>
            您在某种职业类型中的总分越高，表明您越适合从事该职业环境的相关工作，得分最高的项就是最适合您的职业类型；反之，您在某个类型的得分越低，表明您越不适合从事该类型的职业。您在择业时应尽量避免选择得分最低的职业类型，因为该职业类型的工作于您的自我兴趣相差很远，可能会不利于您在工作中获得快乐和满足感并作出成绩；如果您有两种（或以上）的职业类型的得分很高且相同，表明那两种（或以上）职业类型都比较符合您。</p>
        <h2>
            结果统计图：</h2>
        <p class="mbti_tu4">
            <div id="container" style="width: 800px; height: 400px; margin: 0 auto">
            </div>
        </p>
   </div>

   <div class="contants">
     <p>
            <strong class="fontred">社会型-S：</strong>（得分：
            <asp:Label ID="lb_Society" runat="server">0</asp:Label>）</p>
        <p>
            乐于助人和与人打交道，乐于处理人际关系。喜欢从事对他人进行传授、培训、帮助等方面的服务工作。愿意发挥自己的感染力和说服力引导别人。通常他们有社会责任心，热情、善于合作、善良、耐心，重视社会义务和社会道德。</p>
        <p>
            <strong class="fontred">实际型-R：</strong>（得分：<asp:Label ID="lb_Reality" runat="server">0</asp:Label>
            ）</p>
        <p>
            喜欢使用工具或机械从事操作等动手性质的工作，动手能力强，通常喜欢亲自体验或实践理论和方法甚于与其他人讨论，一般不具有出众的交际能力，喜欢从事户外工作。</p>
        <p>
            <strong class="fontred">艺术型-A：</strong>（得分：<asp:Label ID="lb_Art" runat="server">0</asp:Label>
            ）</p>
        <p>
            <span>热爱艺术，富于 想象力</a>、拥有很强的艺术创造力。乐于创造新颖、与众不同的成果，渴望表现个性，展现自己。做事理想化，追求完美。擅于用艺术形式来表现自己和表现社会。进行艺术创作或创新时，不喜欢受约束和限制。
                <p>
                    <strong class="fontred">常规型-C：</strong>（得分：<asp:Label ID="lb_Tradition" runat="server">0</asp:Label>
                    ）</p>
                <p>
                    尊重权威和规章制度，喜欢有秩序的、安稳的生活。惯于按照计划和指导做事，按部就班，细心有条理。不习惯自己对事情作判断和决策，较少发挥想象力。没有强烈的野心，不喜欢冒险。</p>
                <p>
                    <strong class="fontred">研究型-I：</strong>（得分：<asp:Label ID="lb_Study" runat="server">0</asp:Label>
                    ）</p>
                <p>
                    喜欢理论研究，潜心于专业领域的创新和应用；喜欢探索未知领域，擅长使用逻辑分析和推理解决难题。不喜欢官僚式的管理行为过多地影响研究工作。</p>
                <p>
                    <strong class="fontred">企业型-E：</strong>（得分：<asp:Label ID="lb_Business" runat="server">0</asp:Label>
                    ）</p>
                <p>
                    对其所能支配的各种资源能够进行有效的计划、组织、领导和控制。喜欢影响别人、敢于挑战，自信、有胆略、有抱负，沟通能力出色，擅长说服他人，追求声望、经济成就和社会地位。</p>
                
                <h2>职业兴趣类型间的内在关系</h2>
                
                
                   <p>
                        从上图中可以看出各个职业类型之间存在不同程度的关系。一般来说，两个类型靠的越近，它们之间的关系就越密切，这两种类型的个体之间的共同点就越多。如实践型和研究型的人就都不太偏好人际交往，这两种职业环境中也都较少机会与人接触。 
                   </p>
                      <p>
                        反之，两个类型离的越远，关系也就越少，通常在六边形上处于对角位置的类型之间即为相对关系，如实践型和社会型、研究型和企业型、艺术型和事务型等，一般来说，相对关系的人格类型共同点很少，因此，一个人同时对处于相对关系的两种职业都很感兴趣的情况十分少见。 
                   </p>
                      <p>
                        　　兴趣是成功的重要推动力，对于面临就业大学生来说，如果能够选择到与自己兴趣爱好相符合的职业，将可以使自己在工作中找到快乐和满足感，也更容易获得成功。职业心理学的研究表明，一个人对某种工作有兴趣，能发挥他全部才能的 80%-90% ，并且能长时间保持高效率而不感到疲劳；如果对某种工作不感兴趣，则他的才能只能发挥 20%-30% ，并且容易疲劳。所以，大学生在择业的时候，应该尽量选择与自身兴趣相匹配的职业类型和职业环境。
                   </p>
                      <p>
                        然而 , 在实际的职业选择中，除了应该优先选择那些与自身的职业类型相匹配的职业环境外，我们还要考虑一些别的因素：
                   </p>
                      <p>
                        首先，因为个体本身常是多种职业兴趣类型的综合体，单一职业倾向显著突出的情况往往并不多见，因此人们在具体择业的时候，除了得分最高的职业类型外，得分第二高的职业类型中的相关工作，有时同样也可以予以考虑。  
                   </p>
                     <p>
                        其次，由于兴趣的可行性差异，有些人的职业兴趣脱离客观条件，过于浪漫，往往想得好，做不到；有些人职业兴趣建立在切实可行的基础之上如结合自己所学的专业、社会的职业需求等，最后心想事成，获得成功。所以，大学生在择业时，除了要考虑与自己职业兴趣外还要兼顾考虑获得职业成功的现实可能性。
                   </p>
                   

                <p>
                    喜欢使用工具或机械从事操作等动手性质的工作，动手能力强，通常喜欢亲自体验或实践理论和方法甚于与其他人讨论，一般不具有出众的交际能力，喜欢从事户外工作。</p>
   </div>
   <div class="contants">
    <h2>您适合的专业：</h2>
    <p>根据测试结果，最适合您的职业兴趣类型组合为：</p>
    <div class="tab1">
    	<p>职业兴趣适合专业类型对照表</p>
        <table width="80%" cellpadding="4" align="center" class="tab3">
        	<tr>
            	<th colspan="2" class="style1">职业兴趣对应专业类型</th>
            </tr>
        	<tr>
            	<th width="20%">R(实际型)</th>
                <td>工业技术；农学；管理学；生物工程与技术；医学；文学；其他专业技术。</td>
            </tr>
            <tr>
            	<th>I(调查型)</th>
                <td>理学；生物工程与技术；医学；军事；文学；其他专业技术。</td>
            </tr>
            <tr>
            	<th>A(艺术型)</th>
                <td>艺术；管理学；文学；其他专业技术。</td>
            </tr><tr>
            	<th>S(社会型)</th>
                <td>哲学；文学；经济学；法学；教育；医学；其他专业技术。</td>
            </tr>
            <tr>
            	<th>E(企业型)</th>
                <td>经济学；管理学；电子信息工程；大众传播学；法学；军事；其他专业技术</td>
            </tr>
            <tr>
            	<th>C(常规型)</th>
                <td>电子信息工程；理学；工业技术；文学；管理学；其他专业技术。</td>
            </tr>
        </table>

        <script type="text/javascript">
            $(function () {
                var ly = "<%=ly %>";

                var lyAr = ly.split("");
                for (var i = 0; i < 2; i++) {
                    $(".tab3  th:contains('" + lyAr[i] + "')").parent().css({ "color": "red", "font-width": "blod" });
                }
            });
        </script>
       
    </div>
    <p>其中，适合文科和理科的分别为：</p>
    <div class="tab1">
    	<p>职业兴趣适合专业类型对照表</p>
         <table  width="80%" cellpadding="4" align="center" class="tab3">
            <tr>
            	<th colspan="2">专业类型对应文理分科</th>
            </tr>
            <tr>
            	<th>文科</th>
                <td>哲学；法学；教育（文）；文学；军事（文）；管理学；艺术；大众传播学；其他专业技术。</td>
            </tr>
            <tr>
            	<th>理科</th>
                <td>经济学；教育（理）；理学；工业技术；农学；医学；军事（理）；电子信息工程；生物工程与技术；其他专业技术。</td>
            </tr>
        </table>
    </div>


    <div class="contants">
        <div class="tit3 tit5">
            格伦建议：文科/理科</div>
        <p>
            您在测试中表现出了对<span class="fontred wl">文科/理科</span>的一定倾向，如图：</p>
        <div class="depart">
    	<div class="departone">文科:<span ><img src="../images/departone.gif"  class="wenke"  style=" border:1px solid #000;"/></span></div>
    	<div class="departtwo">理科:<span><img src="../images/departtwo.gif"  class="like" style=" border:1px solid #000;"/></span></div>
    </div>
        <p>
            因此我们为推荐您选择<span class="fontred wl"> </span>，但要更加准确具体分析和选择分科，还要结合更多更具体的自身情况进行综合考虑。</p>
        
        <script type="text/javascript">
            //分析
            function analyse() {
                var wenk = <%=WenKe %>;
                var lik =<%=LiKe %>;
                //绘制视图
                 $(".wenke").css({"width":wenk+"px","height":"22px"});
                   $(".like").css({"width":lik+"px","height":"22px"});

                if (wenk > lik) {
                    //选择文科
                    $(".wl").text("文科");
                }
                else {
                    //选择理科
                     $(".wl").text("理科");
                }
            }
            analyse();
        </script>

        </div>
        <h3>
            结束语</h3>
        <p>
            一个人的文理倾向，没有好坏之分。每个人的兴趣，一般都有最适合他的职业。我们要想在学习和工作中获得成功，很重要的一点，就是在选择工作的时候，尽量从事最适合我们的工作。</p>
       <div style=" display:none;">
           <p>
               因此，<a href="../Holland/about.aspx"><strong>职业兴趣及倾向 </strong></a>是决定文理分科非常重要的因素。</p>
           <p>
               您可通过 <strong>《文理分科高级测评报告》</strong> 来通过对您职业兴趣及倾向的具体分析，来获得更加细致具体的分析和建议。</p>
           <p>
               获得方式：1、您需要完成<strong><a href="../Holland/about.aspx">《格伦职业兴趣测评》</a></strong>获得<strong><a
                   href="../Holland/Fruit.aspx">《职业兴趣初级测评报告》</a></strong>；
           </p>
           <p>
               2、之后，您可返回用户界面，进入“我的测评报告”页面，并选择生成<strong>《格伦文理分科高级测评报告》</strong>；
           </p>
       </div>
        <p>
            最后，希望大家通过本测试，能够更好的了解自己的职业倾向，从而在文理分科的选择、未来的专业选择和择业过程中能够做出更加理性的判断，期望你能在未来的职业生涯中获得最大的成功！
        </p>
    </div>
      <script type="text/javascript">
          function sss() {
              window.moveTo(-4, -4);
              window.resizeTo(screen.availWidth + 9, screen.availHeight + 9);
          }

          sss();
    </script>
</body>
</html>

