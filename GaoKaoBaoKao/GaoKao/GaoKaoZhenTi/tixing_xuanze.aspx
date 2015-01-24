<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="tixing_xuanze.aspx.cs"
    Inherits="GaoKao.GaoKaoZhenTi.tixing_xuanze" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>题型练习</title>
    <link href="css/more2.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="/js/jquery.js"></script>
    <script src="js/aui-artDialog-5c965d5/lib/sea.js"></script>
    <script src="js/dialogs.js" type="text/javascript"></script>
    <script src="/js/jquery.easing.1.3.js" type="text/javascript"></script>
    <script src="/GaoKaoZhenTi/js/daohang.js" type="text/javascript"></script>
    <script src="/aui-artDialog-5c965d5/lib/sea.js"></script>
    <script src="/js/dialogs.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {

            $(".conR .boxone .options").click(function () {
                //当前点击的索引
                var index = $(".conR .boxone .options").index(this);

                //获取选中项
                var val = $("input:radio[name=\"content" + index + "\"]:checked").val();

                //如果选择了选项，改变答题卡颜色，同时记录下来题号和答案
                if (val != undefined) {
                    //改变答题卡颜色
                    $(".content .conR .pagewrap li").eq(index).html("<span>" + (index + 1) + "</span>");

                    //记录下来题号和答案
                    //原来就已经有的值
                    var yjl = $("#hid").val();
                    //本次的值
                    var bc = val + ",";
                    $("#hid").val(yjl + bc);
                }
            });
        });

        function jiaojuan() {
            var yjl = $("#hid").val();
            if (yjl == "") {
                artDialog11("您还没有做题！", "确定", "取消", "0", window.location.href);

                return;
            }
            var studentid = "<%=intStudentId %>";
            var zubie = "<%=strZuBie %>";
            var typeid = "<%=intTypeId %>";
            var subjectid = "<%=intSubjectId %>";

            $.ajax({
                url: "ashx/jiaojuan.ashx",
                type: "post",
                dataType: "html",
                data: { yjl: yjl, studentid: studentid, zubie: zubie },
                success: function (msg) {
                    if (msg == "success") {

                        alertResult("交卷成功！");
                        //计时暂停
                        clearTimeout(t);
                        setTimeout(function () {
                            //跳转页面
                            location.href = "tixing_jiaojuan.aspx?subjectid=" + subjectid + "&typeid=" + typeid + "&zubie=" + zubie;
                        }, 1000);
                    } else {
                        artDialog11("交卷失败！", "确定", "取消", "0", window.location.href);
                    }
                }
            });
        }
    </script>
    <script type="text/javascript">
        //暂停，休息一下
        function pause() {
            $("#dialog").css("display", "block");
        }
    </script>
    <script type="text/javascript">

        /////////////////////////计时
        var h = 0;
        var m = 0;
        var s = 0;
        var t
        function time() {
            //最终的计时展示
            var result = "";
            //小时
            if (h.toString().length == 1) {
                result += "0" + h.toString();
            } else {
                result += h.toString();
            }
            result += ":";
            //分钟
            if (m.toString().length == 1) {
                result += "0" + m.toString();
            } else {
                result += m.toString();
            }
            result += ":";
            //秒
            if (s.toString().length == 1) {
                result += "0" + s.toString();
            } else {
                result += s.toString();
            }
            $("#shijian").text(result);

            if (s < 59) {
                s = s + 1;
            }
            else if (s == 59) {
                s = 0;

                if (m < 59) {
                    m += 1;
                } else if (m == 59) {
                    m = 0;
                    if (h < 23) {
                        h += 1;
                    } else {
                        h = 0;
                        m = 0;
                        s = 0;
                    }
                }
            }
            t = setTimeout("time()", 1000);
        }
    </script>
    <script type="text/javascript">
        $(function () {
            $("#kszt").click(function () {
                var sr = $(this).children("img").attr("src");
                if (sr == "images/zt.jpg") {
                    pause();
                    $(".content").css("overflow", "hidden");

                    //计时也暂停
                    clearTimeout(t);
                } else if (sr == "images/ks.jpg") {
                    time();
                    $(this).children("img").attr("src", "images/zt.jpg");
                }
            });
        });
    </script>
</head>
<body>
    <input type="hidden" id="hid" />
    <gk:Schoolbanner ID="SchoolBanner1" BannerWord="格伦高考报考系统" runat="server" />
    <div id="Messagewrap1">
        <div id="Messagewrap">
            <div class="now">
                您当前所在的位置：<a href="/">首页</a> >> <a href="/gaokaozhenti/index.aspx">高考真题</a>
                >> <a href="/gaokaozhenti/index.aspx">题型练习</a> >> 选择题</div>
            <h1>
                题型练习<span><%=strSubjectName%></span><i>时间 <font id="shijian">00:00:00</font></i>
            </h1>
            <div class="content">
                <div id="Toolbar" class="conL">
                    <ul>
                        <li><a href="javascript:void(0);" id="kszt">
                            <img src="images/ks.jpg" width="124" height="42" /></a></li>
                        <li><a href="javascript:jiaojuan();">
                            <img src="images/jiaojuan.jpg" width="124" height="42" /></a></li>
                    </ul>
                </div>
                <div class="conR">
                    <div class="conrwrap">
                        <asp:Repeater ID="rpt_List" runat="server">
                            <ItemTemplate>
                                <div class="boxone" id="shiti<%#Container.ItemIndex+1 %>">
                                    <div class="subject">
                                        试题<%#Container.ItemIndex+1 %>：</div>
                                    <div class="choose">
                                        <%#Eval("content") %>
                                    </div>
                                    <div class="options">
                                        <p>
                                            <input name="content<%#Container.ItemIndex %>" type="radio" value="<%#Eval("id") %>:A" />
                                            A.</p>
                                        <p>
                                            <input name="content<%#Container.ItemIndex %>" type="radio" value="<%#Eval("id") %>:B" />
                                            B.</p>
                                        <p>
                                            <input name="content<%#Container.ItemIndex %>" type="radio" value="<%#Eval("id") %>:C" />
                                            C.</p>
                                        <p>
                                            <input name="content<%#Container.ItemIndex %>" type="radio" value="<%#Eval("id") %>:D" />
                                            D.</p>
                                    </div>
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>
                    <div class="sheet">
                        <img src="images/dtk.jpg" width="130" height="38" /></div>
                    <div class="pagewrap">
                        <ul>
                            <%=strDaTiKa %>
                        </ul>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!--#include file="../includefiles/footer.html" -->
    <div id="dialog" style="width: 100%; height: 100%; display: none;">
        <div id="schoolalert" style="width: 700px; height: 583px; position: absolute; left: 50%;
            top: 50%; margin-left: -280px; margin-top: -291px; z-index: 991; border: 0;">
            <iframe name="xiuxi" id="xiuxi" src="xiuxi.html" width="700" height="583" style="overflow-x: hidden;
                border: 0;"></iframe>
        </div>
        <%--    <div id="closeDialog" style="position: absolute; display: block; background: #000; cursor:pointer;
            left: 0px; top: 0px; width: 100%; height: 100%; opacity: 0.7; /*设置透明度为70%，非ie浏览器用*/ filter: alpha(opacity=70);
            z-index: 990;">
            &nbsp;
        </div>--%>
        <div style="clear: both;">
        </div>
    </div>
    <script type="text/javascript">
        $(function () {
            //点击灰色半透明区域  关闭弹框
            $("#closeDialog").click(function () {
                closeDialog();
            });
        });



        //显示弹框
        function ShowDialog() {
            $("#dialog").show();
        }
        //关闭弹窗
        function closeDialog() {
            $("#dialog").hide();

        }


    </script>
</body>
</html>
