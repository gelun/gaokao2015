﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SchoolLuQuGuiZe.aspx.cs"
    Inherits="GaoKao.SchoolLibrary.SchoolLuQuGuiZe" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title><%=strSchoolName%>录取规则_高考报考院校库_格伦高考网</title>
    <meta name="keywords" content="<%=strSchoolName%>录取规则,<%=strSchoolName%>院校录取规则,<%=strSchoolName%>专业录取规则" />
    <script src="/js/jquery.js" type="text/javascript"></script>
    <link href="/css/style.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <gk:Schoolbanner ID="SchoolBanner1" runat="server" BannerWord="格伦高考报考院校库" />
    <gk:Crumb ID="Crumb1" runat="server"  />
    <div class="content">
        <div class="contentbody">
            <gk:SchoolLeft ID="SchoolLeft1" runat="server" Index="5" />
            <div class="contentR">
                <gk:SchoolBase ID="SchoolBase1" runat="server" />
                <div class="conRbox">
                    <div class="zszcbox">
                        <div class="conRword">
                            <asp:Literal ID="ltlContent" runat="server"></asp:Literal>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <gk:Footer ID="Footer1" runat="server" />
    </form>
</body>
</html>
