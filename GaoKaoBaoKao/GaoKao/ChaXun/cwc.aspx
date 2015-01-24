<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="cwc.aspx.cs" Inherits="GaoKao.ChaXun.cwc" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>根据分数查位次_报考智能规划系统_格伦高考网</title>
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
    <gk:Schoolbanner ID="SchoolBanner1" BannerWord="根据分数查位次" runat="server" />
    <gk:Crumb ID="Crumb1" NavString=" <span>&gt;</span> <a href='/tuijian/default.aspx'>报考智能规划系统</a> <span>&gt;</span> <a href='sjcx.aspx'>高考报考数据查询</a> <span>&gt;</span> 根据位次查分数"
        runat="server" />
    <div class="content" style="background: #fff;">
        <div class="contentbody">
            <div class="cxTit" style="margin-top: 30px;">
                <div class="cxTitL">
                    根据分数查位次<span><%=userinfo.ProvinceName %>
                        <%=userinfo.KeLeiMingCheng%></span></div>
                <div class="cxTitR">
                    分数<input type="text" value="" id="txt_fs" style="width: 90px;" class="cxtext" /><a
                        href="#" id="btn_cwc">查位次</a>
                </div>
            </div>
            <script type="text/javascript">
                $(function () {
                    //根据分数查位次
                    $("#btn_cwc").live("click", function () {
                        var txtValue = $("#txt_fs").val();

                        if (txtValue == "") {
                            alert("请输入分数，然后点击查询位次。");
                            return;
                        }
                        location.href = "cwc.aspx?fs=" + txtValue;
                    });

                });
            </script>
            <div class="cxtable" style="border-top: 1px solid #ccc;">
                <div class="cxtableTit">
                    <span>
                        <%=glFenShu%>分</span>在<span><%=userinfo.ProvinceName %>
                            <%=userinfo.KeLeiMingCheng%></span>考生中所处的排名</div>
                <table width="100%" border="1">
                    <tr>
                        <th width="14%">
                            省份
                        </th>
                        <th width="14%">
                            科类
                        </th>
                        <th width="14%">
                            年份
                        </th>
                        <th width="14%">
                            分数
                        </th>
                        <th width="14%">
                            位次
                        </th>
                        <th width="15%">
                            累计人数
                        </th>
                        <th width="15%">
                            同分人数
                        </th>
                    </tr>
                    <asp:Repeater ID="rpt_List" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td>
                                    <%=userinfo.ProvinceName %>
                                </td>
                                <td>
                                    <%=userinfo.KeLeiMingCheng%>
                                </td>
                                <td>
                                    <%#Eval("DataYear")%>
                                </td>
                                <td>
                                    <%=glFenShu%>
                                </td>
                                <td>
                                    <%#Eval("WeiCi")%><%# Eval("IsKaoShiYuan").Equals("0") ? "" : "*"%>
                                </td>
                                <td>
                                    <%#Eval("LeiJiRenShu")%>
                                </td>
                                <td>
                                    <%#Eval("RenShu")%>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </table>
                <div class="cxtableBtm">
                    带*位次为格伦教育根据录取数据统计出来的位次，非考试院公布数据</div>
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
