<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SchoolYouShiZhuanYe.aspx.cs"
    Inherits="GaoKao.SchoolLibrary.SchoolYouShiZhuanYe" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title><%=strPageTitle %>优势专业_高考报考院校库_格伦高考网</title>
    <meta name="keywords" content="<%=strPageTitle %>优势专业,<%=strPageTitle%>国家重点专业,<%=strPageTitle%>重点专业" />
    <script src="/js/jquery.js" type="text/javascript"></script>
    <link href="/css/style.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <gk:Schoolbanner ID="SchoolBanner1" runat="server" BannerWord="格伦高考报考院校库" />
    <gk:Crumb ID="Crumb1" runat="server" />
    <div class="content">
        <div class="contentbody">
            <gk:SchoolLeft ID="SchoolLeft1" runat="server" Index="2" />
            <div class="contentR">
                <gk:SchoolBase ID="SchoolBase1" runat="server" />
                <div class="conRbox">
                    <asp:Repeater ID="rpTeSetList" runat="server">
                        <HeaderTemplate>
                            <div class="conRtit">优势专业</div>
                            <div class="kemu">
                                <div class="kemutit">
                                    特色专业</div>
                                <div class="kemuul">
                                    <ul>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <li><a href="daxue-zhuanyejieshao-<%#Eval("SchoolProfessionalId") %>.shtml" title="<%#Eval("ProfessionalName")%>">
                                <%#Eval("ProfessionalName")%></a></li>
                        </ItemTemplate>
                        <FooterTemplate>
                            </ul> </div> </div>
                        </FooterTemplate>
                    </asp:Repeater>
                    <div class="conRtit">
                        重点专业</div>
                    <asp:Repeater ID="rptYiJiList" runat="server">
                        <HeaderTemplate>
                            <div class="kemu">
                                <div class="kemutit">
                                    一级重点学科</div>
                                <div class="kemuul">
                                    <ul>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <li><a target="_blank" href="daxue-zhuanyejieshao-<%#Eval("SchoolProfessionalId") %>.shtml">
                                <%#Eval("ProfessionalName")%></a></li>
                        </ItemTemplate>
                        <FooterTemplate>
                            </ul> </div> </div>
                        </FooterTemplate>
                    </asp:Repeater>
                    <asp:Repeater ID="rptErJiList" runat="server">
                        <HeaderTemplate>
                            <div class="kemu">
                                <div class="kemutit">
                                    二级重点学科</div>
                                <div class="kemuul">
                                    <ul>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <li><a target="_blank" href="daxue-zhuanyejieshao-<%#Eval("SchoolProfessionalId") %>.shtml">
                                <%#Eval("ProfessionalName")%></a></li>
                        </ItemTemplate>
                        <FooterTemplate>
                            </ul> </div> </div>
                        </FooterTemplate>
                    </asp:Repeater>
                </div>
            </div>
        </div>
    </div>
    <gk:Footer ID="Footer1" runat="server" />
    </form>
</body>
</html>
