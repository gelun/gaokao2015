<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ZhiYe.aspx.cs" Inherits="GaoKao.ZhiYe.ZhiYe" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title><%=strZhiYeName%>_<%=strErJiZhiYeName%>_<%=strYiJiZhiYeName%>_高考职业库_格伦高考网</title>
    <meta name="keywords" content="<%=strZhiYeName%>,<%=strErJiZhiYeName%>,<%=strYiJiZhiYeName%>,高考职业库,格伦高考网" />
    <script src="/js/jquery.js" type="text/javascript"></script>
    <link href="/css/style.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <gk:Schoolbanner ID="SchoolBanner1" BannerWord="格伦高考报考职业库" runat="server" />
    <gk:Crumb ID="Crumb1" runat="server" />
    <div class="content" style="background: #fff;">
        <div class="contentbody">
            <div class="zhiyekuL">
                <div class="zhiyekuTit" style="border-bottom: 1px solid #e9e9e9;">
                    <asp:Literal ID="ltlZhiYeName" runat="server"></asp:Literal></div>
                <div class="zylist">
                    <div class="zylistL">
                        所属行业：</div>
                    <div class="zylistR">
                        <ul>
                            <li>
                                <asp:Literal ID="ltlHangYe" runat="server"></asp:Literal></li>
                        </ul>
                    </div>
                    <div class="zylistL">
                        相关专业：</div>
                    <div class="zylistR">
                        <asp:Literal ID="ltlNoXinXi" runat="server"></asp:Literal>
                        <asp:Repeater ID="rptList" runat="server">
                            <HeaderTemplate>
                                <ul>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <li><a href="/zhuanye-jianjie-<%#Eval("ProfessionalId") %>.shtml"
                                    title="<%#Eval("ProfessionalName") %>">
                                    <%#Eval("ProfessionalName")%></a></li>
                            </ItemTemplate>
                            <FooterTemplate>
                                </ul>
                            </FooterTemplate>
                        </asp:Repeater>
                    </div>
                </div>
                <div class="zyword">
                    <asp:Literal ID="ltlIntro" runat="server"></asp:Literal>
                </div>
            </div>
            <div class="zhiyekuR">
                <div class="zhiyekuRbox">
                    <div class="zhiyekuRboxTit">
                        热门职业</div>
                    <div class="zhiyekuRul">
                        <ul>
                            <asp:Repeater ID="rptReMenZhiYe" runat="server">
                                <ItemTemplate>
                                    <li><a href="zhiye-jianjie-<%#Eval("Id") %>.shtml" title="<%#Eval("ZhiYeName") %>">
                                        <%#Eval("ZhiYeName") %></a></li>
                                </ItemTemplate>
                            </asp:Repeater>
                        </ul>
                    </div>
                </div>
                <div class="zhiyekuRbox">
                    <div class="zhiyekuRboxTit">
                        热门行业</div>
                    <div class="zhiyekuRul">
                        <ul>
                            <asp:Repeater ID="rptReMenHangYe" runat="server">
                                <ItemTemplate>
                                    <li><a href="zhiye-list-<%#Eval("Id") %>.shtml" title="<%#Eval("ZhiYeName") %>">
                                        <%#Eval("ZhiYeName") %></a></li>
                                </ItemTemplate>
                            </asp:Repeater>
                        </ul>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <gk:Footer ID="Footer1" runat="server" />
    </form>
</body>
</html>
