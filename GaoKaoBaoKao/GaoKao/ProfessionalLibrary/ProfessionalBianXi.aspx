<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProfessionalBianXi.aspx.cs"
    Inherits="GaoKao.ProfessionalLibrary.ProfessionalBianXi" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title><%=strProfessionalName%>专业辨析_高考报考专业库_格伦高考网</title>
    <meta name="keywords" content="<%=strProfessionalName%>,专业辨析,高考报考,格伦高考网" />
    <script src="/js/jquery.js" type="text/javascript"></script>
    <link href="/css/style.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <gk:ProfessionalBanner ID="ProfessionalBanner1" runat="server" BannerWord="格伦高考报考专业库" />
    <gk:Crumb ID="Crumb1" runat="server" />
    <div class="zycontent">
        <div class="zycontentbody">
            <gk:ProfessionalLeft ID="ProfessionalLeft1" runat="server" Index="4" />
            <div class="zyconR">
                <gk:ProfessionalBase ID="ProfessionalBase1" runat="server" />
                <div class="conRbox">
                    <div class="conRtit">
                        专业辨析</div>
                    <div class="conRword">
                        <asp:Repeater ID="rptList" runat="server">
                            <ItemTemplate>
                                <h3>
                                    <%#Eval("Title") %></h3>
                                <p>
                                    <%#Eval("Summary") %>
                                    <span><a href="zhuanye-zhiye-<%=intProfessionalId %>-<%#Eval("Id") %>.shtml" title="<%#Eval("Title") %>">
                                        [查看详情]</a></span></p>
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <gk:Footer ID="Footer1" runat="server" />
    </form>
</body>
</html>
