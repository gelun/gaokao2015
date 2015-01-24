<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="zsd_jiaojuan.aspx.cs" Inherits="GaoKao.GaoKaoZhenTi.zsd_jiaojuan" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>查看解析</title>
    <link href="css/more2.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="/js/jquery.js"></script>
    <script src="js/aui-artDialog-5c965d5/lib/sea.js"></script>
    <script src="js/dialogs.js" type="text/javascript"></script>
    <script src="/js/jquery.easing.1.3.js" type="text/javascript"></script>
    <script src="/GaoKaoZhenTi/js/daohang.js" type="text/javascript"></script>
    <script type="text/javascript">
        function jiexi() {
            var zubie = "<%=strZuBie %>";
            var typeid = "<%=intTypeId %>";
            var subjectid = "<%=intSubjectId %>";
            location.href = "zsd_chakanjiexi.aspx?subjectid=" + subjectid + "&zsdid=" + typeid + "&zubie=" + zubie;
        }
    </script>
</head>
<body>
    <gk:Schoolbanner ID="SchoolBanner1" BannerWord="格伦高考报考系统" runat="server" />
    <div id="Messagewrap1">
        <div id="Messagewrap">
            <div class="now">
                您当前所在的位置：<a href="/">首页</a> >> <a href="/gaokaozhenti/index.aspx">高考真题</a>
                >> <a href="/gaokaozhenti/index.aspx">知识点练习</a> >> <span>
                    <%=strTypeName%></span></div>
            <h1>
                知识点练习<span><%=strSubjectName%></span></h1>
            <div class="content">
                <div id="Toolbar" class="conL">
                    <ul>
                        <li><a href="javascript:void(0);">
                            <img src="images/btn_ckjg.jpg" width="124" height="42" /></a></li>
                        <li><a href="javascript:jiexi();">
                            <img src="images/btn_ckjx.jpg" width="124" height="42" /></a></li>
                    </ul>
                </div>
                <div class="conR">
                    <div class="conrwrap">
                        <div class="boxone">
                            <div class="subject2">
                                本次练习题<strong>10</strong>道，您答对了<strong><%=intRightCount %></strong>道。</div>
                        </div>
                        <div class="pagewrap2">
                            <ul>
                                <asp:Literal ID="ltlLi" runat="server"></asp:Literal>
                            </ul>
                        </div>
                        <div class="judge">
                            <p>
                                未答<span><img src="images/icon_wd.jpg" width="14" height="14" /></span></p>
                            <p>
                                答对<span><img src="images/icon_dd.jpg" width="14" height="14" /></span></p>
                            <p>
                                答错<span><img src="images/icon_dc.jpg" width="14" height="14" /></span></p>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!--#include file="../includefiles/footer.html" -->
</body>
</html>
