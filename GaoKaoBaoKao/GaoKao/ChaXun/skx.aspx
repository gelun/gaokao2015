<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="skx.aspx.cs" Inherits="GaoKao.ChaXun.skx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>格伦高考网_高考资源网_高考报考_高考时间_高考作文_高考倒计时_格伦教育网</title>
    <meta name="keywords" content="高考,高考网,高考资源网,高考报考,高考时间,高考作文,高考倒计时" />
    <meta name="description" content="格伦高考网是格伦教育下设八大项目之一,将高考报考与生涯教育完美结合。并为考生提供专业的高考报考卡,从学业规划等角度出发,引导学生更有针对性地填报志愿,为广大高中生和家长提供全面精准的指导。" />
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
    <gk:Schoolbanner ID="SchoolBanner1" BannerWord="历年省控线" runat="server" />
    <gk:Crumb ID="Crumb1" NavString=" <span>&gt;</span> <a href='/tuijian/default.aspx'>报考智能规划系统</a> <span>&gt;</span> <a href='sjcx.aspx'>高考报考数据查询</a> <span>&gt;</span> 历年省控线"
        runat="server" />
    <div class="content" style="background: #fff;">
        <div class="contentbody">
            <div class="cxTit" style="margin-top: 30px;">
                <div class="cxTitL">
                    历年省控线<span><%=userinfo.ProvinceName %>
                        <%=userinfo.KeLeiMingCheng%></span></div>
            </div>
            <div class="cxtable" style="border-top: 1px solid #ccc;">
                <div class="cxtableTit">
                    <span>
                        <%=userinfo.ProvinceName %>
                        <%=userinfo.KeLeiMingCheng%></span> 近年批次控制分数线</div>
                <table width="100%" border="1">
                    <tr>
                        <%if (userinfo.ProvinceId == 11)
                          { %>
                        <th width="24%">
                            年份
                        </th>
                        <th width="24%">
                            一批次
                        </th>
                        <th width="26%">
                            二批次
                        </th>
                        <th width="26%">
                            三批次
                        </th>
                        <%}
                          else
                          { %>
                        <th width="16%">
                            年份
                        </th>
                        <th width="16%">
                            一本
                        </th>
                        <th width="17%">
                            二本
                        </th>
                        <th width="17%">
                            三本
                        </th>
                        <th width="17%">
                            专科1
                        </th>
                        <th width="17%">
                            专科2
                        </th>
                        <%} %>
                    </tr>
                    <asp:Repeater ID="rpt_List" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td>
                                    <%#Eval("DataYear")%>
                                </td>
                                <td>
                                    <%# Eval("PcFirst").Equals(0) ? '-' : Eval("PcFirst")%>
                                </td>
                                <td>
                                    <%# Eval("PcSecond").Equals(0) ? '-' : Eval("PcSecond")%>
                                </td>
                                <%if (userinfo.ProvinceId == 11)
                                  { %>
                                <td>
                                    <%# Eval("PcThird").Equals(0) ? Eval("ZkFirst") : Eval("PcThird")%>
                                </td>
                                <%}
                                  else
                                  { %>
                                <td>
                                    <%# Eval("PcThird").Equals(0) ? '-' : Eval("PcThird")%>
                                </td>
                                <td>
                                    <%# Eval("ZkFirst").Equals(0) ? '-' : Eval("ZkFirst") %>
                                </td>
                                <td>
                                    <%# Eval("ZkSecond").Equals(0) ? '-' : Eval("ZkSecond")%>
                                </td>
                                <%} %>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </table>
            </div>
            <div class="cxTit">
                <div class="cxTitL">
                    对比图</div>
            </div>
            <%=strHighCharts %>
            <div class="tjt" id="duibitu">
            </div>
        </div>
    </div>
    <gk:Footer ID="Footer1" runat="server" />
    </form>
</body>
</html>
