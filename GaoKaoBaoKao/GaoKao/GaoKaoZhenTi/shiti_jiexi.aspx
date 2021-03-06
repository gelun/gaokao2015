﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="shiti_jiexi.aspx.cs" Inherits="GaoKao.GaoKaoZhenTi.shiti_jiexi" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>试卷解析</title>
    <link href="css/more2.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="/js/jquery.js"></script>
    <script src="js/aui-artDialog-5c965d5/lib/sea.js"></script>
    <script src="js/dialogs.js" type="text/javascript"></script>
    <script type="text/javascript">
        function jiexi(v) {
            var src = $(".boxone .answers .rit a[k=" + v + "]").find("img").attr("src");
            //alert(index);
            if (src == "images/ycjx.jpg") {
                //隐藏解析
                $("#jx" + v).css("display", "none");
                // $(".boxone .answers .rit a[k=" + v + "]").parent().parent().next().css("display", "none");
                //改变图片路径
                $(".boxone .answers .rit a[k=" + v + "]").find("img").attr("src", "images/xsjx.jpg");
            } else {
                //显示解析
                $("#jx" + v).css("display", "block");
                //$(".boxone .answers .rit a[k=" + v + "]").parent().parent().next().css("display", "block");
                //改变图片路径
                $(".boxone .answers .rit a[k=" + v + "]").find("img").attr("src", "images/ycjx.jpg");
            }
        }
    </script>
</head>
<body>
    <gk:Schoolbanner ID="SchoolBanner1" BannerWord="格伦高考报考系统" runat="server" />
    <div id="Messagewrap1">
        <!--Messagewrap begin-->
        <div id="Messagewrap">
            <div class="now">
                您当前所在的位置：<a href="/">首页</a> >> <a href="/gaokaozhenti/index.aspx">高考真题</a>
                >> <a href="/gaokaozhenti/index.aspx">真题模拟</a> >> <span>
                    <asp:Literal ID="ltlShiJuanName" runat="server"></asp:Literal></span> >> <span>查看解析</span></div>
            <h1>
                真题模拟<span><%=strSubjectName%></span></h1>
            <div class="content">
                <div class="conL">
                    <ul>
                        <li><a href="javascript:void(0);">
                            <img src="images/btn_ckjx.jpg" width="124" height="42" /></a></li>
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
                                    <div class="answers">
                                        <div class="rit">
                                            <a href="javascript:void(0);" k="<%#Eval("Id2") %>" onclick="javascript:jiexi(<%#Eval("Id2") %>);">
                                                <img src="images/ycjx.jpg" width="104" height="31" /></a></div>
                                    </div>
                                    <div class="jx" id="jx<%#Eval("Id2") %>">
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
                    <%--  <div class="sheet">
                    <img src="images/dtk.jpg" width="130" height="38" /></div>
                <div class="pagewrap">
                    <ul>
                        <li><a href="#">1</a></li>
                        <li><a href="#">2</a></li>
                        <li><a href="#">3</a></li>
                        <li><a href="#">4</a></li>
                        <li><a href="#">5</a></li>
                        <li><span>6</span></li>
                        <li><a href="#">7</a></li>
                        <li><a href="#">8</a></li>
                        <li><a href="#">9</a></li>
                        <li><a href="#">10</a></li>
                    </ul>
                </div>--%>
                </div>
            </div>
        </div>
        <!--Messagewrap end-->
    </div>
    <!--#include file="../includefiles/footer.html" -->
</body>
</html>
