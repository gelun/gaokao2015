<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SchoolDuiBi.aspx.cs" Inherits="GaoKao.SchoolLibrary.SchoolDuiBi" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>高考院校对比_格伦高考网</title>
    <meta name="keywords" content="高考院校对比,格伦高考报考,格伦高考报考网" />
    <script src="/js/jquery.js" type="text/javascript"></script>
    <link href="/css/style.css" rel="stylesheet" type="text/css" />
    
</head>
<body>
    <gk:Schoolbanner ID="SchoolBanner1" runat="server" BannerWord="格伦高考报考院校库" />
    <gk:Crumb ID="Crumb1" runat="server" NavString=" <span>&gt;</span> <a href='/daxue.shtml' title='高考报考院校库'>高考报考院校库</a> <span>&gt;</span> 院校对比" />
    <div class="content" style="background: #fff;">
        <div class="contentbody">
            <table width="1200" border="1" class="dbtable">
                <tr>
                    <td width="180">
                        &nbsp;
                    </td>
                    <asp:Literal ID="ltlLogoList" runat="server"></asp:Literal>
                </tr>
                <tr>
                    <td class="tdlft">
                        学校名称
                    </td>
                    <asp:Literal ID="ltlSchoolNameList" runat="server"></asp:Literal>
                </tr>
                <tr>
                    <td class="tdlft">
                        学校标签
                    </td>
                    
                    <asp:Literal ID="ltlBiaoQianList" runat="server"></asp:Literal>
                </tr>
                <tr>
                    <td class="tdlft">
                        创建时间
                    </td>
                    <asp:Literal ID="ltlFoundTimeList" runat="server"></asp:Literal>
                </tr>
                <tr>
                    <td class="tdlft">
                        学校类型
                    </td>
                    <asp:Literal ID="ltlLeiXingList" runat="server"></asp:Literal>
                </tr>
                <tr>
                    <td class="tdlft">
                        博士点个数
                    </td>
                    <asp:Literal ID="ltlBoShiDianList" runat="server"></asp:Literal>
                </tr>
                <tr>
                    <td class="tdlft">
                        硕士点个数
                    </td>
                    <asp:Literal ID="ltlShuoShiDianList" runat="server"></asp:Literal>
                </tr>
                <tr>
                    <td class="tdlft">
                        重点学科数量
                    </td>
                    <asp:Literal ID="ltlZhongDianXueKeList" runat="server"></asp:Literal>
                </tr>
                <tr>
                    <td class="tdlft">
                        武书连<br />
                        大学排行名次
                    </td>
                    <asp:Literal ID="ltlWuShuLianList" runat="server"></asp:Literal>
                </tr>
                <tr>
                    <td class="tdlft">
                        校友会网<br />
                        大学排行名次
                    </td>
                    <asp:Literal ID="ltlXiaoYouHuiList" runat="server"></asp:Literal>
                </tr>
                <tr>
                    <td class="tdlft">
                        国家重点专业
                    </td>
                    <asp:Literal ID="ltlZhongDianZhuanYeList" runat="server"></asp:Literal>
                </tr>
                <tr>
                    <td class="tdlft">
                        特色专业
                    </td>
                    <asp:Literal ID="ltlTeSeZhuanYeList" runat="server"></asp:Literal>
                </tr>
            </table>
        </div>
    </div>
    <gk:Footer ID="Footer1" runat="server" />
</body>
</html>
