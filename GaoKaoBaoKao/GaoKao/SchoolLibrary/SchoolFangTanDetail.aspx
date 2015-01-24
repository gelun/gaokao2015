<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SchoolFangTanDetail.aspx.cs"
    Inherits="GaoKao.SchoolLibrary.SchoolFangTanDetail" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>招办访谈_<%=strPageTitle %>_格伦高考网</title>
    <meta name="keywords" content="<%=strPageTitle%>,招办访谈,高考报考,格伦高考网" />
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
                <div class="conRbox">
                    <div class="biaoti">
                        <asp:Literal ID="ltlTitle" runat="server"></asp:Literal></div>
                    <div class="conRword">
                        <asp:Literal ID="ltlContent" runat="server"></asp:Literal>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <gk:Footer ID="Footer1" runat="server" />
    </form>
</body>
</html>
