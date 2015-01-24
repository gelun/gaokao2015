<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SchoolZhaoBanFangTan.aspx.cs"
    Inherits="GaoKao.SchoolLibrary.SchoolZhaoBanFangTan" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title><%=strSchoolName%>招生办访谈_高考报考院校库_格伦高考网</title>
    <meta name="keywords" content="<%=strSchoolName%>招生办,<%=strSchoolName%>招生办访谈,<%=strSchoolName%>招生办主任" />
    <script src="/js/jquery.js" type="text/javascript"></script>
    <link href="/css/style.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <gk:Schoolbanner ID="SchoolBanner1" runat="server" BannerWord="格伦高考报考院校库" />
    <gk:Crumb ID="Crumb1" runat="server" />
    <div class="content">
        <div class="contentbody">
            <gk:SchoolLeft ID="SchoolLeft1" runat="server" Index="6" />
            <div class="contentR">
                <gk:SchoolBase ID="SchoolBase1" runat="server" />
                <div class="conRbox" style="padding-bottom: 250px;">
                    <asp:Repeater ID="rptList" runat="server">
                        <ItemTemplate>
                            <div class="ftbox" <%#(Container.ItemIndex+1)%4 == 1 ? "style=\"margin-left: 0;\"" : "" %>>
                                <div class="ftimg touming">
                                <a href="daxue-fangtandetail-<%#Eval("Id") %>.shtml" title="<%#Eval("ShortTitle") %>">
                                    <img src="/HouTaiGuanLi<%#Eval("Icon") %>" alt="<%#Eval("ShortTitle") %>" width="230" height="195" /></a></div>
                                <div class="ftword_bg">
                                </div>
                                <div class="ftword <%#Eval("IsNew").ToString() == "1" ? "ftnew" : "" %>">
                                    <a href="daxue-fangtandetail-<%#Eval("Id") %>.shtml" title="<%#Eval("ShortTitle") %>">
                                        <%#Eval("ShortTitle") %></a></div>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
            </div>
        </div>
    </div>
    <gk:Footer ID="Footer1" runat="server" />
    </form>
</body>
</html>
