<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SchoolKaiSheZhuanYe.aspx.cs"
    Inherits="GaoKao.SchoolLibrary.SchoolKaiSheZhuanYe" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title><%=strPageTitle %>开设专业_高考报考院校库_格伦高考网</title>
    <meta name="keywords" content="<%=strPageTitle%>,<%=strPageTitle %>开设专业,高考报考,格伦高考网" />
    <script src="/js/jquery.js" type="text/javascript"></script>
    <link href="/css/style.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <gk:Schoolbanner ID="SchoolBanner1" runat="server" BannerWord="格伦高考报考院校库" />
    <gk:Crumb ID="Crumb1" runat="server" />
    <div class="content">
        <div class="contentbody">
            <gk:SchoolLeft ID="SchoolLeft1" runat="server" Index="1" />
            <div class="contentR">
                <gk:SchoolBase ID="SchoolBase1" runat="server" />
                <div class="conRbox">
                    <asp:Repeater ID="rptBenKeList" runat="server" OnItemDataBound="rptBenKeList_ItemDataBound">
                        <HeaderTemplate>
                            <div class="conRtit">
                                本科专业</div>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <div class="kemu">
                                <div class="kemutit">
                                    <%#Eval("DisciplinesName")%>（<%#Eval("ProfessionalCount")%>个）</div>
                                <div class="kemuul">
                                    <ul>
                                        <asp:Repeater ID="rptList" runat="server">
                                            <ItemTemplate>
                                                <li><a href="daxue-zhuanyejieshao-<%#Eval("SchoolProfessionalId") %>.shtml" title="<%#Eval("ProfessionalName")%>">
                                                    <%#Eval("ProfessionalName")%></a></li>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </ul>
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                    <asp:Repeater ID="rptZhuanKeList" runat="server" OnItemDataBound="rptZhuanKeList_ItemDataBound">
                        <HeaderTemplate>
                            <div class="conRtit">
                                专科专业</div>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <div class="kemu">
                                <div class="kemutit">
                                    <%#Eval("DisciplinesName")%>（<%#Eval("ProfessionalCount")%>个）</div>
                                <div class="kemuul">
                                    <ul>
                                        <asp:Repeater ID="rptList" runat="server">
                                            <ItemTemplate>
                                                <li><a href="daxue-zhuanyejieshao-<%#Eval("SchoolProfessionalId") %>.shtml" title="<%#Eval("ProfessionalName")%>">
                                                    <%#Eval("ProfessionalName")%></a></li>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </ul>
                                </div>
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
