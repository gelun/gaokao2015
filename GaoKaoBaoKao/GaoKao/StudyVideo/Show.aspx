<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Show.aspx.cs" Inherits="GaoKao.StudyVideo.Show" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>高考学习视频_格伦高考网</title>
    <script src="/js/jquery.js" type="text/javascript"></script>
    <link href="/css/style.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="/js/fancybox/jquery.mousewheel-3.0.4.pack.js"></script>
    <script type="text/javascript" src="/js/fancybox/jquery.fancybox-1.3.4.pack.js"></script>
    <link rel="stylesheet" type="text/css" href="/js/fancybox/jquery.fancybox-1.3.4.css"
        media="screen" />
    <script src="/js/highcharts.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <gk:Schoolbanner ID="SchoolBanner1" BannerWord="学习视频" runat="server" />
    <gk:Crumb ID="Crumb1" NavString=" <span>&gt;</span> <a href='/tuijian/default.aspx'>报考智能规划系统</a> <span>&gt;</span> <a href='List.aspx'>学习视频</a>"
        runat="server" />
    <div class="content" style="background: #fff;">
        <div class="contentbody">
            <div class="cxTit" style="margin-top: 20px;">
                <div class="cxTitL" style="font-size: 30px;">
                    <%=strTitle %></div>
            </div>
            <%--<div class="sp2word"><%=strContent %></div>--%>
            <div class="spbox">
                <div class="spimg">
                    <%=strVideo %></div>
            </div>
        </div>
    </div>
    <gk:Footer ID="Footer1" runat="server" />
    </form>
</body>
</html>
