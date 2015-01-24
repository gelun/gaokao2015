<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Fruit.aspx.cs" Inherits="GaoKao.CePing.GLGKZYXZ.Holland.Fruit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>职业兴趣</title>
    <link href="../Rports/cssstyle.css" rel="stylesheet" type="text/css" />
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
    <style type="text/css">
        img
        {
            margin: 0px;
            border: 0px;
            padding: 0px;
        }
        </style>
        
        <script type="text/javascript">
            window.moveTo(-4, -4);
            window.resizeTo(window.screen.availWidth + 9, window.screen.availHeight + 9);
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div style="display: none;">
        <div class="daoyu">
            <script type="text/javascript">
                $(function () {
                    //设置职业兴趣分数条长度
                    $("#table1 tr td span").each(function () {
                        var fen = $(this).text();
                        var zfen = fen * 100 / 20;

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
        职业兴趣</div>
    <div class="hightu2">
        测评报告</div>
    <div class="mbtitu3">
    </div>
    <div class="contants">
        <div class="tit1 tit4">
            职业兴趣初级测评报告</div>
    </div>
    <div class="contants">
        <div class="tit3 tit5">
            简介</div>
        <p>
            霍兰德的职业兴趣理论，其核心是按照不同的职业特点和个性特征将人分为六类：实践型、研究型、艺术型、社会型、管理型、常规型，这六种类型的人具有不同的典型特征。每种类型的人对相应职业类型感兴趣，当我们就业择业的时候，我们的兴趣与职业环境的匹配是形成职业满意度、成就感的基础。</p>
        <p>
            本测试以霍兰德职业兴趣（ Holland Vocational Interest Theory ）理论为基础， 从你想、喜欢干什么(兴趣)和你擅长干什么(能力)两个方面测查个体的职业倾向， 同时在题目内容设计方面结合了当代中国大学生的实际情况。通过本测试，可以帮助测试者较为准确地了解自身的个体特点和职业特点之间的匹配关系，同时为测评者在进行专业选择和职业选择时，提供客观的参考依据。</p>
    </div>
    <div class="contants">
        <div class="tit3 tit5">
            测试结果</div>
         <div class="tab1"> 您的类型： <%=lb_HollandName.Text %></p></div>
         <br />
         <br />
      

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
                
                <p>
                    喜欢使用工具或机械从事操作等动手性质的工作，动手能力强，通常喜欢亲自体验或实践理论和方法甚于与其他人讨论，一般不具有出众的交际能力，喜欢从事户外工作。</p>
    </div>
    </form>
    <div class="contants">
        <div class="tit3 tit5">
            职业兴趣类型与其相对应的职业</div>
        <p>
            <strong class="fontred">R(实际型)：</strong></p>
        <p>
            土木工程师，农场主，操作X光的技师，工程师，飞机机械师，鱼类和野生动物专家，自动化技师，机械工(车工,钳工等)，电工，无线电报务员，火车司机，长途公共汽车司机，机械制图员，修理机器和电器师。</p>
        <p>
            <strong class="fontred">I(调查型)：</strong></p>
        <p>
            气象学者，生物学者，天文学家，药剂师，动物学者，化学家，科学报刊编辑，地质学者，植物学者，物理学者，数学家，实验员，科研人员，科技作者。</p>
        <p>
            <strong class="fontred">A(艺术型)：</strong></p>
        <p>
            室内装饰专家，图书管理专家，摄影师，音乐教师，作家，演员，记者，诗人，作曲家，编剧，雕刻家，漫画家。</p>
        <p>
            <strong class="fontred">S(社会型)：</strong></p>
        <p>
            社会学者，导游，福利机构工作者，咨询人员，社会工作者，社会科学教师，学校领导，精神病工作者，公共保健护士。</p>
        <p>
            <strong class="fontred">E(企业型)：</strong></p>
        <p>
            推销员，进货员，商品批发员，旅馆经理，饭店经理，广告宣传员，调度员，律师，政治家，零售商。</p>
        <p>
            <strong class="fontred">C(常规型)：</strong></p>
        <p>
            记帐员，会计，银行出纳员，法庭速记员，成本估算员，税务员，核算员，打字员，办公室职员，统计员，计算机操作员，秘书。</p>
    </div>
    <asp:Panel  ID="diji" runat="server">    <div class="contants">
      <p>通过<strong class="fontblue">《职业兴趣高级测评报告》</strong>可以更加深入的分析，能够获得与职业兴趣相对应的具体职业信息以及更多建议。
        希望大家通过本测试，能够更好的了解自己的职业兴趣倾向，从而在专业选择和择业过程中能够进行有意识的加以选择，期望你能在未来的职业生涯中获得最大的成功！</p>  </div>
    </asp:Panel>

    <asp:Panel ID="panel1" Visible="false" runat="server">
        <div class="contants">
            <div class="tit3 tit5">
                职业兴趣与职业详细匹配对照表</div>
            <p>
                首先根据你的职业兴趣代号，在下表中找出相应的职业，例如你的职业兴趣代号是 RIA，那么牙科技术人员、陶工等是适合你兴趣的职业。</p>
            <p>
                然后寻找与你职业兴趣代号相近的职业，如你的职业兴趣代号是RIA，那么，其他由这三个字母组合成 的编号(如IRA、IAR、ARI等)对应的职业，也较适合你的兴趣。</p>
       
            <h2>
                对照表：</h2>
            <div class="tab1">

                 <table width="90%" align="center" cellpadding="10"  id="duizhaobiao">
                    <tr>
                       <td colspan="3">
                           你的职业兴趣类型：<span class="youSy"><%=lb_Holland.Text%></span>
                       </td>
                    </tr>
                    <tr style="background: #b7dee8;">
                        <th width="10%">
                            主要职业兴趣类型
                        </th>
                        <th width="30%">
                            职业兴趣匹配
                        </th>
                        <th width="60%">
                            对应适合的职业
                        </th>
                    </tr>
             
                    <tr>
                        <td rowspan="13" valign="center" width="74" style="background: #b7dee8;">
                                现实型为主的职业以R开头
                        </td>
                        <td  align="center">
                                RIA
                        </td>
                        <td >
                        
                                牙科技术员、陶工、建筑设计员、模型工、细木工、制作链条人员。
                        </td>
                    </tr>
                    <tr>
                        <td align="center">
                        
                                RIS
                        </td>
                        <td >
                        
                                厨师、林务员、跳水员、潜水员、染色员、电器修理、眼镜制作、电工、纺织机器装配工、服务员、装玻璃工人、发电厂工人、焊接工。
                        </td>
                    </tr>
                    <tr>
                        <td align="center">
                        
                                RIE
                        </td>
                        <td >
                        
                            
                                建筑和桥梁工程、环境工程、航空工程、公路工程、电力工程、信号工程、电话工程、一般机械工程、自动工程、矿业工程、海洋工程、交通工程技术人&nbsp;员、制图员、家政经济人员、计量员、农民、农场工人、农业机械操作、清洁工、无线电修理、汽车修理、手表修理、管工、线路装配工、工具仓库管理员。
                        </td>
                    </tr>
                    <tr>
                        <td align="center">
                        
                                RIC
                        </td>
                        <td >
                        
                            
                                船上工作人员、接待员、杂志保管员、牙医助手、制帽工、磨坊工、石匠、机器制造、机车(火车头)制造、农业机器装配、汽车装配工、缝纫机装配工、&nbsp;钟表装配和检验、电动器具装配、鞋匠、锁匠、货物检验员、电梯机修工、托儿所所长、钢琴调音员、装配工、印刷工、建筑钢铁工作、卡车司机。
                        </td>
                    </tr>
                    <tr>
                        <td align="center">
                        
                                RAI
                        </td>
                        <td >
                        
                                手工雕刻、玻璃雕刻、制作模型人员、家具木工、制作皮革品、手工绣花、手工钩针纺织、排字工作、印刷工作、图画雕刻、装订工。
                        </td>
                    </tr>
                    <tr>
                        <td align="center">
                        
                                RSE
                        </td>
                        <td >
                        
                            
                                消防员、交通巡警、警察、门卫、理发师、房间清洁工、屠夫、锻工、开凿工人、管道安装工、出租汽车驾驶员、货物搬运工、送报员、勘探员、娱乐场所的服务员、起卸机操作工、灭害虫者、电梯操作工、厨房助手。
                        </td>
                    </tr>
                    <tr>
                        <td align="center">
                        
                                RSI
                        </td>
                        <td >
                        
                                纺织工、编织工、农业学校教师、某些职业课程教师(诸如艺术、商业、技术、工艺课程)、雨衣上胶工。
                        </td>
                    </tr>
                    <tr>
                        <td align="center">
                        
                                REC
                        </td>
                        <td >
                        
                                抄水表员、保姆、实验室动物饲养员、动物管理员。
                        </td>
                    </tr>
                    <tr>
                        <td align="center">
                        
                                REI
                        </td>
                        <td >
                        
                            
                                轮船船长、航海领航员、大副、试管实验员。
                        </td>
                    </tr>
                    <tr>
                        <td align="center">
                        
                                RES
                        </td>
                        <td>
                              旅馆服务员、家畜饲养员、渔民、渔网修补工、水手长、收割机操作工、搬运行李工人、公园服务员、救生员、登山导游、火车工程技术员、建筑工作、铺轨工人。
                        </td>
                    </tr>
                    <tr>
                        <td align="center">
                        
                                RCI
                        </td>
                        <td >
                        
                            
                                测量员、勘测员、仪表操作者、农业工程技术、化学工程技师、民用工程技师、石油工程技师、资料室管理员、探矿工、煅烧工、烧窖工、矿工、保养工、&nbsp;磨床工、取样工、样品检验员、纺纱工、炮手、漂洗工、电焊工、锯木工、刨床工、制帽工、手工缝纫工、油漆工、染色工、按摩工、木匠、农民建筑工作、电影放&nbsp;映员、勘测员助手。
                        </td>
                    </tr>
                    <tr>
                        <td align="center">
                        
                                RCS
                        </td>
                        <td >
                        
                                公共汽车驾驶员、一等水手、游泳池服务员、裁缝、建筑工作、石匠、烟囱修建工、混凝土工、电话修理工、爆炸手、邮递员、矿工、裱糊工人、纺纱工。
                        </td>
                    </tr>
                    <tr>
                        <td align="center">
                        
                                RCE
                        </td>
                        <td >
                        
                                打井工、吊车驾驶员、农场工人、邮件分类员、铲车司机、拖拉机司机。
                        </td>
                    </tr>
                    <tr>
                        <td rowspan="13" valign="center" width="74" style="background: #b7dee8;">
                        
                                调研型为主的职业以I开头
                        
                            
                        
                        </td>
                        <td align="center">
                        
                                IAS
                        </td>
                        <td >
                        
                                普通经济学家、农场经济学家、财政经济学家、国际贸易经济学家、实验心理学家、工程心理学家、心理学家、哲学家、内科医生、数学家。
                        </td>
                    </tr>
                    <tr>
                        <td align="center">
                        
                                IAR
                        </td>
                        <td >
                        
                                人类学家、天文学家、化学家、物理学家、医学病理、动物标本剥制者、化石修复者、艺术品管理者。
                        </td>
                    </tr>
                    <tr>
                        <td align="center">
                        
                                ISE
                        </td>
                        <td >
                        
                                营养学家、饮食顾问、火灾检查员、邮政服务检查员。
                        </td>
                    </tr>
                    <tr>
                        <td align="center">
                        
                                ISC
                        </td>
                        <td >
                        
                                侦察员、电视播音室修理员、电视修理服务员、验尸室人员、编目录者、医学实验定技师、调查研究者。
                        </td>
                    </tr>
                    <tr>
                        <td align="center">
                        
                                ISR
                        </td>
                        <td >
                        
                                水生生物学者，昆虫学者、微生物学家、配镜师、矫正视力者、细菌学家、牙科医生、骨科医生。
                        </td>
                    </tr>
                    <tr>
                        <td align="center">
                        
                                ISA
                        </td>
                        <td >
                        
                            
                                实验心理学家、普通心理学家、发展心理学家、教育心理学家、社会心理学家、临床心理学家、目标学家、皮肤病学家、精神病学家、妇产科医师、眼科医生、五官科医生、医学实验室技术专家、民航医务人员、护士。
                        
                            
                        
                        </td>
                    </tr>
                    <tr>
                        <td align="center">
                        
                                IES
                        </td>
                        <td >
                        
                                细菌学家、生理学家、化学专家、地质专家、地理物理学专家、纺织技术专家、医院药剂师、工业药剂师、药房营业员。
                        </td>
                    </tr>
                    <tr>
                        <td align="center">
                        
                                IEC
                        </td>
                        <td >
                        
                                档案保管员、保险统计员。
                        </td>
                    </tr>
                    <tr>
                        <td align="center">
                        
                                ICR
                        </td>
                        <td >
                        
                                质量检验技术员、地质学技师、工程师、法官、图书馆技术辅导员、计算机操作员、医院听诊员、家禽检查员。
                        </td>
                    </tr>
                    <tr>
                        <td align="center">
                        
                                IRA
                        </td>
                        <td >
                        
                            
                                地理学家、地质学家、声学物理学家、矿物学家、古生物学家、石油学家、地震学家、声学物理学家、原子和分子物理学家、电学和磁学物理学家、气象学家、设计审核员、人口统计学家、数学统计学家、外科医生、城市规划家、气象员。
                        </td>
                    </tr>
                    <tr>
                        <td align="center">
                        
                                IRS
                        </td>
                        <td >
                        
                            
                                流体物理学家、物理海洋学家、等离子体物理学家、农业科学家、动物学家、食品科学家、园艺学家、植物学家、细菌学家、解剖学家、动物病理学家、作&nbsp;物病理学家、药物学家、生物化学家、生物物理学家、细胞生物学家、临床化学家、遗传学家、分子生物学家、质量控制工程师、地理学家、兽医、放射性治疗技师。
                        </td>
                    </tr>
                    <tr>
                        <td align="center">
                        
                                IRE
                        </td>
                        <td >
                        
                            
                                化验员、化学工程师、纺织工程师、食品技师、渔业技术专家、材料和测试工程师、电气工程师、土木工程师、航空工程师、行政官员、冶金专家、原子核工程师、陶瓷工程师、地质工程师、电力工程量、口腔科医生、牙科医生。
                        </td>
                    </tr>
                    <tr>
                        <td align="center">
                        
                                IRC
                        </td>
                        <td >
                        
                            
                                飞机领航员、飞行员、物理实验室技师、文献检查员、农业技术专家、动植物技术专家、生物技师、油管检查员、工商业规划者、矿藏安全检查员、纺织品检验员、照相机修理者、工程技术员、编计算程序者、工具设计者、仪器维修工。
                        </td>
                    </tr>
                    <tr>
                        <td rowspan="12" valign="center" width="74" style="background: #b7dee8;">
                        
                                常规型为主的职业以C开头
                        </td>
                        <td align="center">
                        
                                CRI
                        </td>
                        <td >
                        
                                簿记员、会计、记时员、铸造机操作工、打字员、按键操作工、复印机操作工。
                        </td>
                    </tr>
                    <tr>
                        <td align="center">
                        
                                CRS
                        </td>
                        <td >
                        
                                仓库保管员、档案管理员、缝纫工、讲述员、收款人。
                        </td>
                    </tr>
                    <tr>
                        <td align="center">
                        
                                CRE
                        </td>
                        <td >
                        
                                标价员、实验室工作者、广告管理员、自动打字机操作员、电动机装配工、缝纫机操作工。
                        </td>
                    </tr>
                    <tr>
                        <td align="center">
                        
                                CIS
                        </td>
                        <td >
                        
                                记账员、顾客服务员、报刊发行员、土地测量员、保险公司职员、会计师、估价员、邮政检查员、外贸检查员。
                        </td>
                    </tr>
                    <tr>
                        <td align="center">
                        
                                CIE
                        </td>
                        <td >
                        
                                打字员、统计员、支票记录员、订货员、校对员、办公室工作人员。
                        </td>
                    </tr>
                    <tr>
                        <td align="center">
                        
                                CIR
                        </td>
                        <td >
                        
                                校对员、工程职员、海底电报员、检修计划员、发扳员。
                        </td>
                    </tr>
                    <tr>
                        <td align="center">
                        
                                CSE
                        </td>
                        <td >
                        
                                接待员、通讯员、电话接线员、卖票员、旅馆服务员、私人职员、商学教师、旅游办事员。
                        
                            
                        
                        </td>
                    </tr>
                    <tr>
                        <td align="center">
                        
                                CSR
                        </td>
                        <td >
                        
                                运货代理商、铁路职员、交通检查员、办公室通信员、薄记员、出纳员、银行财务职员。
                        </td>
                    </tr>
                    <tr>
                        <td align="center">
                        
                                CSA
                        </td>
                        <td >
                        
                                秘书、图书管理员、办公室办事员。
                        </td>
                    </tr>
                    <tr>
                        <td align="center">
                        
                                CER
                        </td>
                        <td >
                        
                                邮递员、数据处理员、办公室办事员。
                        </td>
                    </tr>
                    <tr>
                        <td align="center">
                        
                                CEI
                        </td>
                        <td >
                        
                                推销员、经济分析家。
                        </td>
                    </tr>
                    <tr>
                        <td align="center">
                        
                                CES
                        </td>
                        <td >
                        
                                银行会计、记账员、法人秘书、速记员、法院报告人。
                        </td>
                    </tr>
                    <tr>
                        <td rowspan="14" valign="center" width="74" style="background: #b7dee8;">
                        
                                企业型为主的职业以E开头
                        </td>
                        <td align="center">
                        
                                ECI
                        </td>
                        <td >
                        
                                银行行长、审计员、信用管理员、地产管理员、商业管理员。
                        </td>
                    </tr>
                    <tr>
                        <td align="center">
                        
                                ECS
                        </td>
                        <td >
                        
                                信用办事员、保险人员、各类进货员、海关服务经理、售货员，购买员、会计。
                        </td>
                    </tr>
                    <tr>
                        <td align="center">
                        
                                ERI
                        </td>
                        <td >
                        
                                建筑物管理员、工业工程师、农场管理员、护士长、农业经营管理人员。
                        </td>
                    </tr>
                    <tr>
                        <td align="center">
                        
                                ERS
                        </td>
                        <td >
                        
                                仓库管理员、房屋管理员、货栈监督管理员。
                        </td>
                    </tr>
                    <tr>
                        <td align="center">
                        
                                ERC
                        </td>
                        <td >
                        
                                邮政局长、渔船船长、机械操作领班、木工领班、瓦工领班、驾驶员领班。
                        </td>
                    </tr>
                    <tr>
                        <td align="center">
                        
                                EIR
                        </td>
                        <td >
                        
                                科学、技术和有关周期出版物的管理员。
                        </td>
                    </tr>
                    <tr>
                        <td align="center">
                        
                                EIC
                        </td>
                        <td >
                        
                                专利代理人、鉴定人、运输服务检查员、安全检查员、废品收购人员。
                        </td>
                    </tr>
                    <tr>
                        <td align="center">
                        
                                EIS
                        </td>
                        <td >
                        
                                警官、侦察员、交通检验员、安全咨询员、合同管理者、商人。
                        </td>
                    </tr>
                    <tr>
                        <td align="center">
                        
                                EAS
                        </td>
                        <td >
                        
                                法官、律师、公证人。
                        </td>
                    </tr>
                    <tr>
                        <td align="center">
                        
                                EAR
                        </td>
                        <td >
                        
                                展览室管理员、舞台管理员、播音员、训兽员。
                        </td>
                    </tr>
                    <tr>
                        <td align="center">
                        
                                ESC
                        </td>
                        <td >
                        
                                理发师、裁判员、政府行政管理员、财政管理员、I程管理员、职业病防治、售货员、商业经理、办公室主任、人事负责人、调度员。
                        </td>
                    </tr>
                    <tr>
                        <td align="center">
                        
                                ESR
                        </td>
                        <td >
                        
                                家具售货员、书店售货员、公共汽车的驾驶员、日用品售货员、护士长、自然科学和工程的行政领导。
                        </td>
                    </tr>
                    <tr>
                        <td align="center">
                        
                                ESI
                        </td>
                        <td >
                        
                                博物馆管理员、图书馆管理员、古迹管理员、饮食业经理、地区安全服务管理员、技术服务咨询者、超级市场管理员、零售商品店店员、批发商、出租汽车服务站调度。
                        </td>
                    </tr>
                    <tr>
                        <td align="center">
                        
                                ESA
                        </td>
                        <td >
                        
                                博物馆馆长、报刊管理员、音乐器材售货员、广告商售画营业员、导游、(轮船或班机上的)事务长、飞机上的服务员、船员、法官、律师。
                        </td>
                    </tr>
                    <tr>
                        <td rowspan="8" valign="center" width="74" style="background: #b7dee8;">
                        
                                艺术性为主的职业以A开头
                        </td>
                        <td align="center">
                        
                                ASE
                        </td>
                        <td >
                        
                                戏剧导演、舞蹈教师、广告撰稿人，报刊、专栏作者、记者、演员、英语翻译。
                        </td>
                    </tr>
                    <tr>
                        <td align="center">
                        
                                ASI
                        </td>
                        <td >
                        
                                音乐教师、乐器教师、美术教师、管弦乐指挥，合唱队指挥、歌星、演奏家、哲学家、作家、广告经理、时装模特。
                        </td>
                    </tr>
                    <tr>
                        <td align="center">
                        
                                AER
                        </td>
                        <td >
                        
                                新闻摄影师、电视摄影师、艺术指导、录音指导、丑角演员、魔术师、木偶戏演员、骑士、跳水员。
                        </td>
                    </tr>
                    <tr>
                        <td align="center">
                        
                                AEI
                        </td>
                        <td >
                        
                                音乐指挥、舞台指导、电影导演。
                        </td>
                    </tr>
                    <tr>
                        <td align="center">
                        
                                AES
                        </td>
                        <td >
                        
                                流行歌手、舞蹈演员、电影导演、广播节目主持人、舞蹈教师、口技表演者、喜剧演员、模特。
                        </td>
                    </tr>
                    <tr>
                        <td align="center">
                        
                                AIS
                        </td>
                        <td >
                        
                                画家、剧作家、编辑、评论家、时装艺术大师、新闻摄影师、男演员、文学作者。
                        </td>
                    </tr>
                    <tr>
                        <td align="center">
                        
                                AIE
                        </td>
                        <td >
                        
                                花匠、皮衣设计师、工业产品设计师、剪影艺术家、复制雕刻品大师。
                        </td>
                    </tr>
                    <tr>
                        <td align="center">
                        
                                AIR
                        </td>
                        <td >
                        
                                建筑师、画家、摄影师、绘图员、环境美化工、雕刻家、包装设计师、陶器设计师、绣花工、漫画工。
                        </td>
                    </tr>
                    <tr>
                        <td rowspan="12" valign="center" width="74" style="background: #b7dee8;">
                        
                                社会型为主的职业以S开头
                        </td>
                        <td align="center">
                        
                                SEC
                        </td>
                        <td >
                        
                                社会活动家、退伍军人服务官员、工商会事务代表、教育咨询者、宿舍管理员、旅馆经理、饮食服务管理员。
                        </td>
                    </tr>
                    <tr>
                        <td align="center">
                        
                                SER
                        </td>
                        <td >
                        
                                体育教练、游泳指导。
                        </td>
                    </tr>
                    <tr>
                        <td align="center">
                        
                                SEI
                        </td>
                        <td >
                        
                                大学校长、学院院长、医院行政管理员、历史学家、家政经济学家、职业学校教师、资料员。
                        </td>
                    </tr>
                    <tr>
                        <td align="center">
                        
                                SEA
                        </td>
                        <td >
                        
                                娱乐活动管理员、国外服务办事员、社会服务助理、一般咨询者、宗教教育工作者。
                        </td>
                    </tr>
                    <tr>
                        <td align="center">
                        
                                SCE
                        </td>
                        <td >
                        
                                部长助理、福利机构职员、生产协调人、环境卫生管理人员、戏院经理、餐馆经理、售票员。
                        </td>
                    </tr>
                    <tr>
                        <td align="center">
                        
                                SRI
                        </td>
                        <td >
                        
                                外科医师助手、医院服务员。
                        </td>
                    </tr>
                    <tr>
                        <td align="center">
                        
                                SRE
                        </td>
                        <td >
                        
                                体育教师、职业病治疗者、体育教练、专业运动员、房管员、儿童家庭教师、警察、引座员、传达员、保姆。
                        </td>
                    </tr>
                    <tr>
                        <td align="center">
                        
                                SRC
                        </td>
                        <td >
                        
                                护理员、护理助理、医院勤杂工、理发师、学校儿童服务人员。
                        </td>
                    </tr>
                    <tr>
                        <td align="center">
                        
                                SIA
                        </td>
                        <td >
                        
                            
                                社会学家、心理咨询者、学校心理学家、政治科学家、大学或学院的系主任、大学或学院的教育学教师、大学农业教师、大学工程和建筑课程的教师、大学法律教师、大学数学、医学、物理、社会科学和生命科学的教师、研究生助教、成人教育教师。
                        </td>
                    </tr>
                    <tr>
                        <td align="center">
                        
                                SIE
                        </td>
                        <td >
                        
                                营养学家、饮食学家、海关检查员、安全检查员、税务稽查员、校长。
                        </td>
                    </tr>
                    <tr>
                        <td align="center">
                        
                                SIC
                        </td>
                        <td  >
                        
                                描图员、兽医助手、诊所助理、体检检查员、监督缓刑犯的工作者、娱乐指导者、咨询人员、社会科学教师。
                        </td>
                    </tr>
                    <tr>
                        <td align="center" >
                        
                                SIR
                        </td>
                        <td >
                        
                                理疗员、救护队工作人员、手足病医生、职业病治疗助手。
                        </td>
                    </tr>
                </table>

                <script type="text/javascript">
                    $(function () {
                        var lx = $(".youSy").text();
                        var lxAr = lx.split("-");
                        var LAr = new Array();

                        LAr.push(lxAr[0] + lxAr[1] + lxAr[2]);
                        LAr.push(lxAr[0] + lxAr[2] + lxAr[1]);
                        LAr.push(lxAr[1] + lxAr[0] + lxAr[2]);
                        LAr.push(lxAr[1] + lxAr[2] + lxAr[0]);
                        LAr.push(lxAr[2] + lxAr[0] + lxAr[1]);
                        LAr.push(lxAr[2] + lxAr[1] + lxAr[0]);

                        for (var i = 0; i < 6; i++) {
                            $("#duizhaobiao  td:contains('" + LAr[i] + "')").parent().css({ "font-weight": "bold" ,"color":"red"});
                        }




                    });

                 
                </script>

            </div>
        </div>
    </asp:Panel>
    <div class="contants" >
        <div class="tit3 tit5">
            结束语</div>
        <p>
            一个人的职业倾向和职业兴趣，一般来说没有绝对的好坏之分。每个人的兴趣，一般都有最适合他的职业。我们要想在学习和工作中获得成功，很重要的一点，就是在选择工作的时候，尽量从事最适合我们的工作。</p>
        <p>
           实际上，我们在报专业或毕业找工作，以及今后打算考虑跳槽转行的时候，首先应该对我们自身的职业倾向进行全面深入的了解。这次测试的目的，就是为了帮助你更加准确全面的了解你的职业倾向特点，为你在规划自己的学业生涯和未来职业生涯时提供一个有益的参考。同时拓宽你在职业选择方面的思路，为你的择业提供其它的备选方案。</p>
        <p>
           另外，每个人的职业兴趣都是非常相对复杂的，同时人们答题时，难免受到当时的答题环境、心情等各种因素的影响。如果你觉得最终的测试结果与你的实际情况不是很符合，可能有如下几种原因：</p>
        <p>
            <strong class="fontred">1、请回忆你做答时候的情形, 你是根据自己的第一反应做出的回答吗？</strong></p>
        <p>
            <strong class="fontred">2、你是否受到自己应该选择什么或者别人希望你选择什么的影响？</strong></p>
        <p>
            <strong class="fontred">3、你答题的时候心情是不是比较放松？</strong></p>
        <p>
            <strong class="fontred">4、你是否对绝大多数题都进行了认真做答？</strong></p>
        <p>
            <strong class="fontred">5、你答题的时候有没有受到干扰？ </strong></p>
        <p>
            　　最后，希望大家通过本测试，能够更好的了解自己的职业倾向，从而在专业选择和择业过程中能够进行有意识的加以选择，期望你能在未来的职业生涯中获得最大的成功！</p>
        <br />
        <br />
        <br />
    </div>
    <!--#include file="/commonfile/baogao_detail.html"-->
</body>
</html>
