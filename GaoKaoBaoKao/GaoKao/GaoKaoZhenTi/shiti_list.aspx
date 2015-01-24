<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="shiti_list.aspx.cs" Inherits="GaoKao.GaoKaoZhenTi.shiti_list" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>真题模拟</title>
    <link href="css/more2.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="/js/jquery.js"></script>
    <script src="js/aui-artDialog-5c965d5/lib/sea.js"></script>
    <script src="js/dialogs.js" type="text/javascript"></script>
    <script src="/js/daohang.js" type="text/javascript"></script>
    <script src="/aui-artDialog-5c965d5/lib/sea.js"></script>
    <script src="/js/dialogs.js" type="text/javascript"></script>
    <script type="text/javascript">
        //我要交卷
        function jiaojuan() {
            var yjl = $("#hid").val();
            if (yjl == "") {
                artDialog11("您还没有做题！", "确定", "取消", "0", window.location.href);

                return;
            }

            var year = "<%=intYear %>";
            var provinceid = "<%=intProvinceId %>";
            var subjectid = "<%=intSubjectId %>";
            //计时暂停
            clearTimeout(t);
            //                        //跳转页面
            location.href = "shiti_jiexi.aspx?year=" + year + "&provinceid=" + provinceid + "&subjectid=" + subjectid;

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
    <gk:Schoolbanner ID="SchoolBanner1" BannerWord="格伦高考报考系统" runat="server" />
    <div id="Messagewrap1">
        <div id="Messagewrap">
            <div class="now">
                您当前所在的位置：<a href="/">首页</a> >> <a href="/gaokaozhenti/index.aspx">高考真题</a>
                >> <a href="/gaokaozhenti/index.aspx">真题模拟</a> >> <span>
                    <asp:Literal ID="ltlShiJuanName" runat="server"></asp:Literal></span></div>
            <h1>
                真题模拟<span><%=strSubjectName%></span><i>时间 <font id="shijian">00:00:00</font></i></h1>
            <div class="content">
                <div id="Toolbar" class="conL">
                    <ul>
                        <li><a href="javascript:void(0);" id="kszt">
                            <img src="images/ks.jpg" width="124" height="42" /></a></li>
                        <li><a href="javascript:jiaojuan();">
                            <img src="images/jiaojuanbingchakanjiexi.jpg" width="124" height="42" /></a></li>
                    </ul>
                </div>
                <div class="conR">
                    <div class="conrwrap">
                        <asp:Repeater ID="rpt_List" runat="server">
                            <ItemTemplate>
                                <div class="boxone">
                                    <div class="subject">
                                        试题<%#Container.ItemIndex+1 %>：</div>
                                    <div class="choose">
                                        <%#Eval("WenTi")%>
                                    </div>
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>
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
