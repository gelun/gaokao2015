<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="sjcx.aspx.cs" Inherits="GaoKao.ChaXun.sjcx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>高考报考数据查询_报考智能规划系统_格伦高考网</title>
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
</head>
<body>
    <form id="form1" runat="server">
    <gk:Schoolbanner ID="SchoolBanner1" BannerWord="格伦高考报考数据查询" runat="server" />
    <gk:Crumb ID="Crumb1" NavString=" <span>&gt;</span> <a href='/tuijian/default.aspx'>报考智能规划系统</a> <span>&gt;</span> <a href='sjcx.aspx'>高考报考数据查询</a>"
        runat="server" />
    <div class="content" style="background: #fff;">
        <div class="contentbody">
            <div class="cxTit" style="margin-top: 20px;">
                <div class="cxTitL">
                    录取数据查询</div>
            </div>
            <div class="sjcxbox">
                <ul>
                    <li style="margin-left: 0;"><a href="skx.aspx">历年省控线</a></li>
                    <li><a id="cwc" href="#gjfscwc">根据分数查位次</a></li>
                    <li><a id="cfs" href="#gjwccfs">根据位次查分数</a></li>
                    <li><a id="yxlqfs" href="#cxyxlqfs">查询院校录取分数</a></li>
                    <li><a id="yxzylqfs" href="#cxyxzylqfs">查询专业录取分数</a></li>
                </ul>
            </div>
            <%if (!(userinfo.ProvinceId == 10 || userinfo.ProvinceId == 11))
              { %>
            <div class="cxTit" style="margin-top: 20px;">
                <div class="cxTitL">
                    考生录取去向查询</div>
            </div>
            <div class="sjcxbox qxcx">
                <ul>
                    <li style="margin-left: 0;"><a id="yxqx" href="#yxqxcx">院校录取去向查询</a></li>
                    <li><a id="zyqx" href="#zyqxcx">专业录取去向查询</a></li>
                </ul>
            </div>
            <%} %>
            <div class="cxTit" style="margin-top: 20px;">
                <div class="cxTitL">
                    录取数据对比查询</div>
            </div>
            <div class="sjcxbox dbcx">
                <ul>
                    <li style="margin-left: 0;"><a href="yxdb.aspx">院校对比查询</a></li>
                    <li><a href="zydb.aspx">专业对比查询</a></li>
                </ul>
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
                    location.href = "/chaxun/cwc.aspx?fs=" + txtValue;
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
                    location.href = "/chaxun/cfs.aspx?wc=" + txtValue;
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
                    location.href = "/chaxun/zylq.aspx?cc=" + $("#ddl_zylqcc").val() + "&pc=" + $("#ddl_zylqpc").val() + "&nf=" + $("#ddl_zylqnf").val() + "&yx=" + txtValue;
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
                    location.href = "/chaxun/yxlq.aspx?cc=" + $("#ddl_yxlqcc").val() + "&pc=" + $("#ddl_yxlqpc").val() + "&yx=" + txtValue;
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
                        location.href = "/chaxun/yxqx.aspx?lx=0&cc=" + $("#ddl_yxqxcc").val() + "&pc=" + $("#ddl_yxqxpc").val() + "&nf=" + $("#ddl_yxqxnf").val() + "&fs1=" + txtValue1 + "&fs2=" + txtValue2;
                    }
                    else if (yxqxlx == "1") {
                        var txtValue = $("#txt_yxqxxc").val();
                        if (txtValue == "") {
                            alert("请输入线差，然后点击查询。");
                            return;
                        }
                        location.href = "/chaxun/yxqx.aspx?lx=1&cc=" + $("#ddl_yxqxcc").val() + "&pc=" + $("#ddl_yxqxpc").val() + "&nf=" + $("#ddl_yxqxnf").val() + "&xc=" + txtValue;
                    }
                    else if (yxqxlx == "2") {
                        var txtValue = $("#txt_yxqxwc").val();
                        if (txtValue == "") {
                            alert("请输入位次，然后点击查询。");
                            return;
                        }
                        location.href = "/chaxun/yxqx.aspx?lx=2&cc=" + $("#ddl_yxqxcc").val() + "&pc=" + $("#ddl_yxqxpc").val() + "&nf=" + $("#ddl_yxqxnf").val() + "&wc=" + txtValue;
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
                        location.href = "/chaxun/zyqx.aspx?lx=0&cc=" + $("#ddl_zyqxcc").val() + "&pc=" + $("#ddl_zyqxpc").val() + "&nf=" + $("#ddl_zyqxnf").val() + "&fs1=" + txtValue1 + "&fs2=" + txtValue2;
                    }
                    else if (zyqxlx == "1") {
                        var txtValue = $("#txt_zyqxxc").val();
                        if (txtValue == "") {
                            alert("请输入线差，然后点击查询。");
                            return;
                        }
                        location.href = "/chaxun/zyqx.aspx?lx=1&cc=" + $("#ddl_zyqxcc").val() + "&pc=" + $("#ddl_zyqxpc").val() + "&nf=" + $("#ddl_zyqxnf").val() + "&xc=" + txtValue;
                    }
                    else if (zyqxlx == "2") {
                        var txtValue = $("#txt_zyqxwc").val();
                        if (txtValue == "") {
                            alert("请输入位次，然后点击查询。");
                            return;
                        }
                        location.href = "/chaxun/zyqx.aspx?lx=2&cc=" + $("#ddl_zyqxcc").val() + "&pc=" + $("#ddl_zyqxpc").val() + "&nf=" + $("#ddl_zyqxnf").val() + "&wc=" + txtValue;
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
</body>
</html>
