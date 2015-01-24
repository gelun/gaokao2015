<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="cuotiben.aspx.cs" Inherits="GaoKao.GaoKaoZhenTi.cuotiben" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>错题本</title>
    <link href="css/more2.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="/js/jquery.js"></script>
    <script src="js/aui-artDialog-5c965d5/lib/sea.js"></script>
    <script src="js/dialogs.js" type="text/javascript"></script>
    <script type="text/javascript">
        //点击删除
        function del(cuotibenId) {
            alertIsDel(cuotibenId);
        }
        //调用弹出窗口
        function alertIsDel(cuotibenId) {
            seajs.use(['jquery', '/gaokaozhenti/js/aui-artDialog-5c965d5/src/dialog'], function ($, dialog) {
                var d = dialog({
                    content: '确定删除该题目吗？',
                    okValue: '确定',
                    ok: function () {
                        d.close().remove();
                        deletetm(cuotibenId);
                        return false;
                    },
                    cancelValue: '取消',
                    cancel: function () { }
                });
                d.show();
            });
        }
        //一般处理程序中进行删除
        function deletetm(cuotibenId) {
            var studentid = "<%=intStudentId %>";
            $.ajax({
                url: "ashx/cuotibendel.ashx",
                type: "post",
                dataType: "html",
                data: { cuotibenId: cuotibenId, studentid: studentid },
                success: function (msg) {
                    if (msg == "success") {
                        alertResult("删除成功");
                        setTimeout(function () {
                            location.reload();
                        }, 1000);
                    } else {
                        alertResult("删除失败");
                    }
                }
            });
        }
    </script>
    <script type="text/javascript">
        //查看解析
        function jiexi(v) {
            var src = $(".boxone .answers .rit a[k=" + v + "]").find("img").attr("src");
            //alert(index);
            if (src == "images/ycjx.jpg") {
                //隐藏解析
                $("#jx" + v).css("display", "none");
                //  $(".boxone .answers .rit a[k=" + v + "]").parent().parent().next().css("display", "none");
                //改变图片路径
                $(".boxone .answers .rit a[k=" + v + "]").find("img").attr("src", "images/xsjx.jpg");
            } else {
                //显示解析
                $("#jx" + v).css("display", "block");
                // $(".boxone .answers .rit a[k=" + v + "]").parent().parent().next().css("display", "block");
                //改变图片路径
                $(".boxone .answers .rit a[k=" + v + "]").find("img").attr("src", "images/ycjx.jpg");
            }
        }
        
    </script>
</head>
<body>
    <gk:Schoolbanner ID="SchoolBanner1" runat="server" BannerWord="格伦高考报考系统" />
    <!--Messagewrap begin-->
    <div id="Messagewrap1">
        <div id="Messagewrap">
            <div class="now">
                您当前所在的位置：<a href="/">首页</a> >> <a href="/gaokaozhenti/index.aspx">高考真题</a>
                >> <span>错题本</span></div>
            <h1>
                <span>错题本</span></h1>
            <div class="content">
                <div class="conL">
                    <div class="ctb">
                        <a href="javascript:void(0);">
                            <img src="images/btn_ctb.jpg" width="123" height="41" /></a></div>
                </div>
                <div class="conR">
                    <div class="conrwrap">
                        <asp:Repeater ID="rpt_List" runat="server">
                            <ItemTemplate>
                                <div class="boxone">
                                    <div class="subject">
                                        试题<%#Container.ItemIndex+1 %>：</div>
                                    <div class="choose">
                                        <%#Eval("content") %>
                                    </div>
                                    <div class="answers">
                                        <div class="lft">
                                            正确答案是<strong>
                                                <%#Eval("objective_answer")%>
                                            </strong>，您的答案是&nbsp;<strong style="color: #1b1b1b; font-size: 16px;"><%#Eval("cuotibenAnswer") %></strong></div>
                                        <div class="rit">
                                            <a href="javascript:void(0);" onclick="javascript:del(<%#Eval("cuotibenId") %>);"
                                                v="<%#Eval("cuotibenId") %>">
                                                <img src="images/scct.jpg" width="91" height="32" /></a> <a href="javascript:void(0);"
                                                    k="<%#Eval("id") %>" onclick="javascript:jiexi(<%#Eval("id") %>);">
                                                    <img src="images/ycjx.jpg" width="104" height="31" /></a></div>
                                    </div>
                                    <div class="jx" id="jx<%#Eval("id") %>">
                                        <div class="sj">
                                            <img src="images/sj.jpg" width="14" height="10" /></div>
                                        <div class="con">
                                            <strong>解析：</strong>
                                            <%#Eval("answer")%>
                                        </div>
                                    </div>
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>
                    <div class="pagewrap">
                        <%=strHtml%>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!--Messagewrap end-->
    <!--#include file="../includefiles/footer.html" -->
</body>
</html>
