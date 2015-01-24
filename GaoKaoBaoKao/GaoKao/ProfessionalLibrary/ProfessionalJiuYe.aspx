<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProfessionalJiuYe.aspx.cs"
    Inherits="GaoKao.ProfessionalLibrary.ProfessionalJiuYe" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>历年就业率_<%=strProfessionalName%>_格伦高考网</title>
    <meta name="keywords" content="<%=strProfessionalName%>,历年就业率,高考报考,格伦高考网" />
    <script src="/js/jquery.js" type="text/javascript"></script>
    <link href="/css/style.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <gk:ProfessionalBanner ID="ProfessionalBanner1" runat="server" BannerWord="格伦高考报考专业库" />
    <gk:Crumb ID="Crumb1" runat="server" />
    <div class="zycontent">
        <div class="zycontentbody">
            <gk:ProfessionalLeft ID="ProfessionalLeft1" runat="server" Index="1" />
            <div class="zyconR">
                <gk:ProfessionalBase ID="ProfessionalBase1" runat="server" />
                <div class="conRbox">
                    <div class="conRtit">
                        历年就业率</div>
                    <div class="ksyxTab">
                        <div class="ksyxbox">
                            <table width="100%" border="1">
                                <tr>
                                    <th>
                                        年份
                                    </th>
                                    <th>
                                        毕业生规模
                                    </th>
                                    <th>
                                        就业率区间
                                    </th>
                                    <th>
                                        “211”就业率区间
                                    </th>
                                </tr>
                                <asp:Repeater ID="rptList" runat="server">
                                <ItemTemplate>
                                <tr>
                                    <td>
                                        <%#Eval("Year")%>
                                    </td>
                                    <td>
                                        <%#Eval("BiYeShengGuiMo")%>
                                    </td>
                                    <td>
                                        <%#Eval("JiuYeLvA")%>
                                    </td>
                                    <td>
                                        <%#Eval("JiuYeLvA211")%>
                                    </td>
                                </tr>
                                </ItemTemplate>
                                </asp:Repeater>
                            </table>
                        </div>
                        <div class="conRtit conRtit2">
                            就业率说明</div>
                        <div class="ksyxbox">
                            <table width="100%" border="1">
                                <tr>
                                    <th>
                                        字母
                                    </th>
                                    <td>
                                        A+
                                    </td>
                                    <td>
                                        A-
                                    </td>
                                    <td>
                                        B+
                                    </td>
                                    <td>
                                        B-
                                    </td>
                                    <td>
                                        C+
                                    </td>
                                    <td>
                                        C-
                                    </td>
                                    <td>
                                        D+
                                    </td>
                                    <td>
                                        D-
                                    </td>
                                    <td>
                                        E+
                                    </td>
                                    <td>
                                        E-
                                    </td>
                                </tr>
                                <tr>
                                    <th>
                                        就业率
                                    </th>
                                    <td>
                                        ≥95%
                                    </td>
                                    <td>
                                        ≥90%
                                    </td>
                                    <td>
                                        ≥85%
                                    </td>
                                    <td>
                                        ≥80%
                                    </td>
                                    <td>
                                        ≥75%
                                    </td>
                                    <td>
                                        ≥70%
                                    </td>
                                    <td>
                                        ≥65%
                                    </td>
                                    <td>
                                        ≥60%
                                    </td>
                                    <td>
                                        ≥55%
                                    </td>
                                    <td>
                                        ≥50%
                                    </td>
                                </tr>
                            </table>
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
