<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="GaoKao.TuiJian._default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>格伦高考网_高考资源网_高考报考_高考时间_高考作文_高考倒计时_格伦教育网</title>
    <meta name="keywords" content="高考,高考网,高考资源网,高考报考,高考时间,高考作文,高考倒计时" />
    <meta name="description" content="格伦高考网是格伦教育下设八大项目之一,将高考报考与生涯教育完美结合。并为考生提供专业的高考报考卡,从学业规划等角度出发,引导学生更有针对性地填报志愿,为广大高中生和家长提供全面精准的指导。" />
    <script src="/js/jquery.js" type="text/javascript"></script>
    <link href="../css/style.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="/js/fancybox/jquery.mousewheel-3.0.4.pack.js"></script>
    <script type="text/javascript" src="/js/fancybox/jquery.fancybox-1.3.4.pack.js"></script>
    <link rel="stylesheet" type="text/css" href="/js/fancybox/jquery.fancybox-1.3.4.css"
        media="screen" />
    <script type="text/javascript">
        $(document).ready(function () {

            $("#cwc").fancybox({
                'overlayColor': '#000',
                'overlayOpacity': 0.5,
                'transitionIn': 'elastic',
                'transitionOut': 'elastic'
            });
            $("#cfs").fancybox({
                'overlayColor': '#000',
                'overlayOpacity': 0.5,
                'transitionIn': 'elastic',
                'transitionOut': 'elastic'
            });

            $("#yxlqfs").fancybox({
                'overlayColor': '#000',
                'overlayOpacity': 0.5,
                'transitionIn': 'elastic',
                'transitionOut': 'elastic'
            });
            $("#yxzylqfs").fancybox({
                'overlayColor': '#000',
                'overlayOpacity': 0.5,
                'transitionIn': 'elastic',
                'transitionOut': 'elastic'
            });

            $("#yxqx").fancybox({
                'overlayColor': '#000',
                'overlayOpacity': 0.5,
                'transitionIn': 'elastic',
                'transitionOut': 'elastic'
            });
            $("#zyqx").fancybox({
                'overlayColor': '#000',
                'overlayOpacity': 0.5,
                'transitionIn': 'elastic',
                'transitionOut': 'elastic'
            });

        });
    </script>
    <script type="text/javascript">
        $(function () {
            var bYKStudentXinXi = "<%=bYKStudentXinXi %>";
            if (bYKStudentXinXi == "1") {
                $(".gnmk2").find("a").attr("href", "/art/GouMai/Art.aspx?kh=<%=Bank %>");
            }
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <gk:Schoolbanner ID="SchoolBanner1" BannerWord="格伦高考报考系统" runat="server" />
    <gk:Crumb ID="Crumb1" NavString=" > 高考报考系统" runat="server" />
    <div class="content" style="background: #fff;">
        <div class="bkxt">
            <div class="bkxtbox">
                <div class="bkxtL">
                    <div class="viptx <%=strGender %>">
                    </div>
                    <div class="vipxx">
                        <div class="vipname">
                            <%=userinfo.StudentName %></asp:Literal></div>
                        <div class="vipmid">
                            <ul>
                                <li>
                                    <asp:Literal ID="lit_ProvinceName" runat="server"></asp:Literal></li>
                                <li class="split">|</li>
                                <li>
                                    <asp:Literal ID="lit_KeLeiMingCheng" runat="server"></asp:Literal></li>
                                <li><strong>
                                    <asp:Literal ID="lit_LevelName" runat="server"></asp:Literal></strong>用户</li>
                                <li class="split">|</li>
                                <li>
                                    <asp:Literal ID="lit_NianJi" runat="server"></asp:Literal></li>
                                <li class="yxq">有效期：<asp:Literal ID="lit_GKYear" runat="server"></asp:Literal>-09-01</li>
                            </ul>
                        </div>
                        <div class="vipbtn">
                            <ul>
                                <li style="margin-left: 0;"><a href="/Persional/GRZL.aspx">个人资料修改</a></li>
                                <li><a href="/Persional/ChengJiEdit.aspx">成绩修改</a></li>
                                <li style="display:none;"><a href="/Persional/BindCard.aspx">报考卡绑定</a></li>
                                <li><a href="/logout.aspx">退出登录</a></li>
                                <li class="yonghu"><a href="/help/help4.shtml">用户权限</a></li>
                                <%--<li class="yonghu"><a href="#">用户升级</a></li>--%>
                            </ul>
                        </div>
                    </div>
                </div>
                <div class="bkxtR">
                    <a href="/help/help2.shtml"><span>系统</span>使用帮助</a></div>
            </div>
        </div>
        <script type="text/javascript">
            $(function () {

                var status = "1";
                if (status == "2") {

                    //录取分数查询
                    $(".gnmk3 a").attr("href", "javascript:void(0);");
                    var mk3html = "<li><a href=\"javascript:void(0);\">历年省控线</a></li>"
                    	+ "<li><a href=\"javascript:void(0);\">按学校查询</a></li>"
                    	+ "<li><a href=\"javascript:void(0);\">按专业查询</a></li>"
                    	+ "<li><a href=\"javascript:void(0);\">根据分数查位次</a></li>"
                    	+ "<li><a href=\"javascript:void(0);\">根据位次查分数</a></li>";
                    $(".gnmk3 .bkxtconR .bkxtconRul ul").html(mk3html);
                }
            });
        </script>
        <div class="contentbody" style="clear: both;">
            <div class="bkxtcon no-mar gnmk1">
                <div class="bkxtconL">
                    <a href="zhineng1.aspx">报考智能推荐</a></div>
                <div class="bkxtconR">
                    <div class="bkxtconRword">
                        依托不断更新的强大历史数据,结合考生自身的筛选，由系统智能地为您推荐合适的学校及专业，为考生填报志愿做参考。</div>
                    <div class="bkxtconRul">
                        <ul>
                            <li><a href="zhineng1.aspx">报考智能推荐</a></li>
                        </ul>
                    </div>
                </div>
            </div>
            <div class="bkxtcon gnmk5">
                <div class="bkxtconL">
                    <a href="javascript:void(0);">报考知识库</a></div>
                <div class="bkxtconR">
                    <div class="bkxtconRword">
                        通过院校库，专业库，专家讲座，让你对高考毫无头绪，到报考有一定的了解，各种高考报考知识普及。为高考报考助一臂之力。</div>
                    <div class="bkxtconRul">
                        <ul>
                            <li><a href="/daxue.shtml">院校库</a></li>
                            <li><a href="/zhuanye.shtml">专业库</a></li>
                            <li><a href="/2015bksp.shtml">志愿讲堂</a></li>
                            <li><a href="/pxzy/2015pxzy.shtml">平行志愿</a></li>
                            <li><a href="/zhiye.shtml">职业库</a></li>
                            <%--<li><a href="#">专家讲座</a></li>--%>
                        </ul>
                    </div>
                </div>
            </div>
            <div class="bkxtcon no-mar gnmk3">
                <div class="bkxtconL">
                    <a href="../ChaXun/sjcx.aspx">录取分数查询</a></div>
                <div class="bkxtconR">
                    <div class="bkxtconRword">
                        全网最全数据作为支持，历年省控线，位次查询，学校查询等查询功能，让你报考条理更清晰。全面考量，为报考增加成功率，对报考更加有把握。</div>
                    <div class="bkxtconRul">
                        <ul>
                            <li><a href="/ChaXun/skx.aspx">历年省控线</a></li>
                            <li><a id="yxlqfs" href="#cxyxlqfs">按学校查询</a></li>
                            <li><a id="yxzylqfs" href="#cxyxzylqfs">按专业查询</a></li>
                            <li><a id="cwc" href="#gjfscwc">根据分数查位次</a></li>
                            <li><a id="cfs" href="#gjwccfs">根据位次查分数</a></li>
                        </ul>
                    </div>
                </div>
            </div>
            <div class="bkxtcon gnmk4">
                <div class="bkxtconL">
                    <a href="../ChaXun/sjcx.aspx">去向及对比查询</a></div>
                <div class="bkxtconR">
                    <div class="bkxtconRword">
                        直接通过分数进行同分数去向查询、同位次去向查询、同线差去向查询，不单从分数进行分析，更加全面，更具参考性。</div>
                    <div class="bkxtconRul">
                        <ul>
                            <%if (!(userinfo.ProvinceId == 10 || userinfo.ProvinceId == 11))
                              { %>
                            <li><a id="yxqx" href="#yxqxcx">按考生院校去向查询</a></li>
                            <li><a id="zyqx" href="#zyqxcx">按考生专业去向查询</a></li>
                            <%} %>
                            <li><a href="/ChaXun/yxdb.aspx">院校录取分数对比</a></li>
                            <li><a href="/ChaXun/zydb.aspx">专业录取分数对比</a></li>
                        </ul>
                    </div>
                </div>
            </div>
            <div class="bkxtcon no-mar gnmk6">
                <div class="bkxtconL">
                    <a href="/2015zycp.shtml">专业选择测评</a></div>
                <div class="bkxtconR">
                    <div class="bkxtconRword">
                        通过测查个人的性格、兴趣、能力、价值观特点，寻找相匹配的学业方向与职业方向，并形成报告。</div>
                    <div class="bkxtconRul">
                        <ul>
                            <li><a href="/ceping/ceping1.aspx">性格测试</a></li>
                            <li><a href="/ceping/ceping2.aspx">职业能力</a></li>
                            <li><a href="/ceping/ceping3.aspx">霍兰德兴趣</a></li>
                            <li><a href="/ceping/ceping4.aspx">职业价值观</a></li>
                            <li><a target="_blank" href="/ceping/wenli/default.aspx">文理分科</a></li>
                        </ul>
                    </div>
                </div>
            </div>
            <div class="bkxtcon gnmk2">
                <div class="bkxtconL">
                    <a href="/bkydy.shtml" target="_blank">一对一报考指导</a></div>
                <div class="bkxtconR">
                    <div class="bkxtconRword">
                        一对一服务是多年报考经验的资深报考专家根据考生综合情况进行分析，制定适合专属报考方案的同时，帮您完成职业规划。</div>
                    <div class="bkxtconRul">
                        <ul>
                            <li><a href="/bkydy.shtml#bd">一对一指导报考</a></li>
                        </ul>
                    </div>
                </div>
            </div>
            <div class="bkxtcon no-mar gnmk7">
                <div class="bkxtconL">
                    <a href="javascript:void(0);">高考知识点</a></div>
                <div class="bkxtconR">
                    <div class="bkxtconRword">
                        依靠高考大纲，通过知识点检测，了解薄弱环节，深入讲解各知识点，独家知识点检测与讲解，为高考报考助一臂之力。</div>
                    <div class="bkxtconRul">
                        <ul>
                            <li><a href="/ZhiShiDian/ZhiShiDianCPList.aspx">知识点检测</a></li>
                            <li><a href="/ZhiShiDian/zhishidianjiexi.aspx">知识点讲解</a></li>
                            <li><a href="/StudyVideo/List.aspx">视频课程</a></li>
                            <li><a href="/gaokaozhenti/index.aspx">真题练习</a></li>
                            <li><a href="/gaokaozhenti/cuotiben.aspx">错题本</a></li>
                        </ul>
                    </div>
                </div>
            </div>
            <div class="bkxtcon gnmk8">
                <div class="bkxtconL">
                    <a href="javascript:void(0);">学习与备考</a></div>
                <div class="bkxtconR">
                    <div class="bkxtconRword">
                        历年高考真题全面汇总，满分作文分析，学习方法分析，在这里你能找到全网最全的复习资料，一站式复习让你考试无忧。</div>
                    <div class="bkxtconRul">
                        <ul>
                            <li><a href="/jdkt.shtml">高考真题</a></li>
                            <li><a href="/gkzw/lnzw.shtml">高考作文</a></li>
                            <li><a href="/fxbk/jyjq-1.shtml">学习方法</a></li>
                            <li><a href="/fxbk/fxbk-1.shtml">各地试题</a></li>
                            <li><a href="/gkzw/gkzw.shtml">作文指导</a></li>
                        </ul>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!----以下为弹窗部分------->
    <div style="display: none;">
        <div class="cxdialog" id="gjfscwc">
            <div class="dialogTit">
                根据分数查位次</div>
            <div class="dialogsel" id="">
                <div class="selL">
                    分数</div>
                <div class="selR">
                    <input type="text" value="" name="input_fs" id="txt_fs" /></div>
            </div>
            <div class="dialogbtn">
                <a href="#" id="btn_cwc">查位次</a></div>
        </div>
        <div class="cxdialog" id="gjwccfs">
            <div class="dialogTit">
                根据位次查分数</div>
            <div class="dialogsel" id="Div1">
                <div class="selL">
                    位次</div>
                <div class="selR">
                    <input type="text" value="" name="txt_wc" id="txt_wc" /></div>
            </div>
            <div class="dialogbtn">
                <a href="#" id="btn_cfs">查分数</a></div>
        </div>
        <script type="text/javascript">
            //1点击按钮根据分数查位次
            $("#btn_cwc").live("click", function () {
                cwc();
            });
            //2回车根据分数查位次
            $('#gjfscwc').keydown(function (e) {
                if (e.keyCode == 13) {
                    cwc();
                }
            });
            //3根据分数查位次
            function cwc() {
                var txtValue = $("#txt_fs").val();

                if (txtValue == "") {
                    alert("请输入分数，然后点击查询位次。");
                    return;
                } else {
                    location.href = "../chaxun/cwc.aspx?fs=" + txtValue;
                }
            }


            //1点击按钮根据位次查分数
            $("#btn_cfs").live("click", function () {
                cfs();
            });

            //2回车根据位次查分数
            $('#gjwccfs').keydown(function (e) {
                if (e.keyCode == 13) {
                    cfs();
                }
            });
            //3根据位次查分数
            function cfs() {
                var txtValue = $("#txt_wc").val();

                if (txtValue == "") {
                    alert("请输入位次，然后点击查询分数。");
                    return;
                } else {
                    location.href = "../chaxun/cfs.aspx?wc=" + txtValue;
                }
            }

        </script>
    </div>
    <div style="display: none;">
        <div class="cxdialog" id="cxyxlqfs">
            <div class="dialogTit">
                查询院校录取分数</div>
            <div class="dialogsel">
                <div class="selL">
                    层次</div>
                <div class="selR">
                    <select class="sel" id="ddl_yxlqcc">
                        <option value="1">本科</option>
                    </select></div>
            </div>
            <div class="dialogsel">
                <div class="selL">
                    批次</div>
                <div class="selR">
                    <select class="sel" id="ddl_yxlqpc">
                        <option value="1">第一批</option>
                        <option value="2">第二批</option>
                        <option value="3">第三批</option>
                    </select></div>
            </div>
            <div class="dialogsel">
                <div class="selL">
                    院校</div>
                <div class="selR">
                    <input type="text" value="" id="txt_yxlqyx" class="aaa" /></div>
            </div>
            <div class="dialogbtn">
                <a href="#" id="btn_yxlq">提&nbsp;&nbsp;交</a></div>
        </div>
        <div class="cxdialog" id="cxyxzylqfs">
            <div class="dialogTit">
                查询院校专业录取分数</div>
            <div class="dialogsel">
                <div class="selL">
                    层次</div>
                <div class="selR">
                    <select class="sel" id="ddl_zylqcc">
                        <option value="1">本科</option>
                    </select></div>
            </div>
            <div class="dialogsel">
                <div class="selL">
                    批次</div>
                <div class="selR">
                    <select class="sel" id="ddl_zylqpc">
                        <option value="1">第一批</option>
                        <option value="2">第二批</option>
                        <option value="3">第三批</option>
                    </select></div>
            </div>
            <div class="dialogsel">
                <div class="selL">
                    年份</div>
                <div class="selR">
                    <select class="sel" id="ddl_zylqnf">
                        <option value="2013">2013年</option>
                        <option value="2012">2012年</option>
                        <option value="2011">2011年</option>
                        <option value="2010">2010年</option>
                    </select></div>
            </div>
            <div class="dialogsel" id="">
                <div class="selL">
                    院校</div>
                <div class="selR">
                    <input type="text" value="" id="txt_zylqyx" class="aaa" /></div>
            </div>
            <div class="dialogbtn">
                <a href="#" id="btn_zylq">提&nbsp;&nbsp;交</a></div>
        </div>
        <script type="text/javascript">

            //1点击按钮查询院校专业录取分数
            $("#btn_zylq").live("click", function () {
                zylq();
            });
            //2回车查询院校专业录取分数
            $('#cxyxzylqfs').keydown(function (e) {
                if (e.keyCode == 13) {
                    zylq();
                }
            });
            //3查询院校专业录取分数
            function zylq() {
                var txtValue = $("#txt_zylqyx").val();

                if (txtValue == "") {
                    alert("请输入院校名称，然后点击查询。");
                    return;
                } else {
                    location.href = "../chaxun/zylq.aspx?cc=" + $("#ddl_zylqcc").val() + "&pc=" + $("#ddl_zylqpc").val() + "&nf=" + $("#ddl_zylqnf").val() + "&yx=" + txtValue;
                }
            }

            //1点击按钮查询院校录取分数
            $("#btn_yxlq").live("click", function () {
                yxlq();
            });
            //2回车根据位次查分数
            $('#cxyxlqfs').keydown(function (e) {
                if (e.keyCode == 13) {
                    yxlq();
                }
            });
            //3根据位次查分数
            function yxlq() {
                var txtValue = $("#txt_yxlqyx").val();

                if (txtValue == "") {
                    alert("请输入院校名称，然后点击查询。");
                    return;
                } else {
                    location.href = "../chaxun/yxlq.aspx?cc=" + $("#ddl_yxlqcc").val() + "&pc=" + $("#ddl_yxlqpc").val() + "&yx=" + txtValue;
                }
            }
        </script>
        <!---------->
    </div>
    <div style="display: none;">
        <script type="text/javascript">
            $(function () {
                //顶端切换的处理
                //考生院校录取去向查询
                $("#yxqx").click(function () {
                    $("#yxlq_tab li:eq(0)").addClass("current").siblings().removeClass("current");
                    Tab('yxtabdiv', 0);
                });
                $("#yxlq_tab li").click(function () {
                    $(this).addClass("current").siblings().removeClass("current");
                    var index = $(this).index();
                    Tab('yxtabdiv', index);
                });

                //考生专业录取去向查询
                $("#zyqx").click(function () {
                    $("#zylqul li:eq(0)").addClass("current").siblings().removeClass("current");
                    Tab('zytabdiv', 0);
                });
                $("#zylqul li").click(function () {
                    $(this).addClass("current").siblings().removeClass("current");
                    var index = $(this).index();
                    Tab('zytabdiv', index);
                });

                /*切换*/
                function Tab(classname, index) {
                    switch (index) {
                        case 0:
                            $("." + classname + ":eq(0)").show();
                            $("." + classname + ":gt(0)").hide();
                            break;
                        case 1:
                            $("." + classname + ":eq(1)").show();
                            $("." + classname + ":eq(0)").hide();
                            $("." + classname + ":eq(2)").hide();
                            break;
                        case 2:
                            $("." + classname + ":eq(2)").show();
                            $("." + classname + ":lt(2)").hide();
                            break;
                        default:
                            break;
                    }
                    $("#txt_" + classname).val(index);
                }

                //////////提交按钮的处理

                //////////提交按钮的处理
                //1点击查询考生院校录取去向查询
                $("#btn_yxqx").live("click", function () {
                    yxqxcx();
                });

                //2回车考生院校录取去向查询
                $('#yxqxcx').keydown(function (e) {
                    if (e.keyCode == 13) {
                        yxqxcx();
                    }
                });
                //3考生院校录取去向查询
                function yxqxcx() {
                    var yxqxlx = $("#txt_yxtabdiv").val();
                    if (yxqxlx == "0") {
                        var txtValue1 = $("#txt_yxqxfs1").val();
                        var txtValue2 = $("#txt_yxqxfs2").val();
                        if (txtValue1 == "" || txtValue1 == "") {
                            alert("请输入分数区间，然后点击查询。");
                            return;
                        }
                        location.href = "../chaxun/yxqx.aspx?lx=0&cc=" + $("#ddl_yxqxcc").val() + "&pc=" + $("#ddl_yxqxpc").val() + "&nf=" + $("#ddl_yxqxnf").val() + "&fs1=" + txtValue1 + "&fs2=" + txtValue2;
                    }
                    else if (yxqxlx == "1") {
                        var txtValue = $("#txt_yxqxxc").val();
                        if (txtValue == "") {
                            alert("请输入线差，然后点击查询。");
                            return;
                        }
                        location.href = "../chaxun/yxqx.aspx?lx=1&cc=" + $("#ddl_yxqxcc").val() + "&pc=" + $("#ddl_yxqxpc").val() + "&nf=" + $("#ddl_yxqxnf").val() + "&xc=" + txtValue;
                    }
                    else if (yxqxlx == "2") {
                        var txtValue = $("#txt_yxqxwc").val();
                        if (txtValue == "") {
                            alert("请输入位次，然后点击查询。");
                            return;
                        }
                        location.href = "../chaxun/yxqx.aspx?lx=2&cc=" + $("#ddl_yxqxcc").val() + "&pc=" + $("#ddl_yxqxpc").val() + "&nf=" + $("#ddl_yxqxnf").val() + "&wc=" + txtValue;
                    }
                }

                //1点击按钮考生专业录取去向查询
                $("#btn_zyqx").live("click", function () {
                    zyqxcx();
                });
                //2回车考生专业录取去向查询
                $('#zyqxcx').keydown(function (e) {
                    if (e.keyCode == 13) {
                        zyqxcx();
                    }
                });
                //3考生专业录取去向查询
                function zyqxcx() {
                    var zyqxlx = $("#txt_zytabdiv").val();
                    if (zyqxlx == "0") {
                        var txtValue1 = $("#txt_zyqxfs1").val();
                        var txtValue2 = $("#txt_zyqxfs2").val();
                        if (txtValue1 == "" || txtValue1 == "") {
                            alert("请输入分数区间，然后点击查询。");
                            return;
                        }
                        location.href = "../chaxun/zyqx.aspx?lx=0&cc=" + $("#ddl_zyqxcc").val() + "&pc=" + $("#ddl_zyqxpc").val() + "&nf=" + $("#ddl_zyqxnf").val() + "&fs1=" + txtValue1 + "&fs2=" + txtValue2;
                    }
                    else if (zyqxlx == "1") {
                        var txtValue = $("#txt_zyqxxc").val();
                        if (txtValue == "") {
                            alert("请输入线差，然后点击查询。");
                            return;
                        }
                        location.href = "../chaxun/zyqx.aspx?lx=1&cc=" + $("#ddl_zyqxcc").val() + "&pc=" + $("#ddl_zyqxpc").val() + "&nf=" + $("#ddl_zyqxnf").val() + "&xc=" + txtValue;
                    }
                    else if (zyqxlx == "2") {
                        var txtValue = $("#txt_zyqxwc").val();
                        if (txtValue == "") {
                            alert("请输入位次，然后点击查询。");
                            return;
                        }
                        location.href = "../chaxun/zyqx.aspx?lx=2&cc=" + $("#ddl_zyqxcc").val() + "&pc=" + $("#ddl_zyqxpc").val() + "&nf=" + $("#ddl_zyqxnf").val() + "&wc=" + txtValue;
                    }
                }
            });
        </script>
        <div class="cxdialog" id="yxqxcx">
            <div class="dialogTitTab">
                考生院校录取去向查询</div>
            <div class="dialogul">
                <ul id="yxlq_tab">
                    <li class="current">按分数查询</li>
                    <li>按线差查询</li>
                    <li>按位次查询</li>
                </ul>
            </div>
            <div class="dialogsel">
                <div class="selL">
                    层次</div>
                <div class="selR">
                    <input type="text" class="qujian" value="" id="txt_yxtabdiv" style="display: none;" />
                    <select class="sel" id="ddl_yxqxcc">
                        <option value="1">本科</option>
                    </select></div>
            </div>
            <div class="dialogsel">
                <div class="selL">
                    年份</div>
                <div class="selR">
                    <select class="sel" id="ddl_yxqxnf">
                        <option value="2013">2013年</option>
                        <option value="2012">2012年</option>
                        <option value="2011">2011年</option>
                        <option value="2010">2010年</option>
                    </select></div>
            </div>
            <div class="dialogsel">
                <div class="selL">
                    批次</div>
                <div class="selR">
                    <select class="sel" id="ddl_yxqxpc">
                        <option value="1">第一批</option>
                        <option value="2">第二批</option>
                        <option value="3">第三批</option>
                    </select></div>
            </div>
            <div class="dialogsel yxtabdiv">
                <div class="selL">
                    分数区间</div>
                <div class="selR">
                    <input type="text" class="qujian" value="" id="txt_yxqxfs1" /><span>到</span><input
                        type="text" class="qujian" value="" id="txt_yxqxfs2" /></div>
            </div>
            <div class="dialogsel yxtabdiv" style="display: none;">
                <div class="selL">
                    线差</div>
                <div class="selR">
                    <input type="text" value="" id="txt_yxqxxc" /></div>
            </div>
            <div class="dialogsel yxtabdiv" style="display: none;">
                <div class="selL">
                    位次</div>
                <div class="selR">
                    <input type="text" value="" id="txt_yxqxwc" /></div>
            </div>
            <div class="dialogbtn">
                <a href="#" id="btn_yxqx">提&nbsp;&nbsp;交</a></div>
        </div>
        <div class="cxdialog" id="zyqxcx">
            <div class="dialogTitTab">
                考生专业录取去向查询</div>
            <div class="dialogul">
                <ul id="zylqul">
                    <li class="current">按分数查询</li>
                    <li>按线差查询</li>
                    <li>按位次查询</li>
                </ul>
            </div>
            <div class="dialogsel">
                <div class="selL">
                    层次</div>
                <div class="selR">
                    <input type="text" class="qujian" value="" id="txt_zytabdiv" style="display: none;" />
                    <select class="sel" id="ddl_zyqxcc">
                        <option value="1">本科</option>
                    </select></div>
            </div>
            <div class="dialogsel">
                <div class="selL">
                    年份</div>
                <div class="selR">
                    <select class="sel" id="ddl_zyqxnf">
                        <option value="2013">2013年</option>
                        <option value="2012">2012年</option>
                        <option value="2011">2011年</option>
                        <option value="2010">2010年</option>
                    </select></div>
            </div>
            <div class="dialogsel">
                <div class="selL">
                    批次</div>
                <div class="selR">
                    <select class="sel" id="ddl_zyqxpc">
                        <option value="1">第一批</option>
                        <option value="2">第二批</option>
                        <option value="3">第三批</option>
                    </select></div>
            </div>
            <div class="dialogsel zytabdiv" id="tzylq1">
                <div class="selL">
                    分数区间</div>
                <div class="selR">
                    <input type="text" class="qujian" value="" id="txt_zyqxfs1" /><span>到</span><input
                        type="text" class="qujian" value="" id="txt_zyqxfs2" /></div>
            </div>
            <div class="dialogsel zytabdiv" id="tzylq2" style="display: none;">
                <div class="selL">
                    线差</div>
                <div class="selR">
                    <input type="text" value="" id="txt_zyqxxc" /></div>
            </div>
            <div class="dialogsel zytabdiv" id="tzylq3" style="display: none;">
                <div class="selL">
                    位次</div>
                <div class="selR">
                    <input type="text" value="" id="txt_zyqxwc" /></div>
            </div>
            <div class="dialogbtn">
                <a href="#" id="btn_zyqx">提&nbsp;&nbsp;交</a></div>
        </div>
    </div>
    <!----以上为弹窗部分------->
    <gk:Footer ID="Footer1" runat="server" />
    </form>
    <script type="text/javascript">
        $('#btn_yxlq').keydown(function (e) {
            if (e.keyCode == 13) {
                var txtValue = $("#txt_yxlqyx").val();

                if (txtValue == "") {
                    alert("请输入院校名称，然后点击查询。");
                    return false;
                } else {
                    location.href = "../chaxun/yxlq.aspx?cc=" + $("#ddl_yxlqcc").val() + "&pc=" + $("#ddl_yxlqpc").val() + "&yx=" + txtValue;
                }
            }
        });
    </script>
</body>
</html>
