<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="data_zy.aspx.cs" Inherits="GaoKao.TuiJian.data_zy" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="/css/style.css" rel="stylesheet" type="text/css" />
    <script src="/js/jquery.js" type="text/javascript"></script>
    <script src="/js/highcharts.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="cxtable" style="width:85%">
    <div class="cxtableTit" style="width:85%"><%=strPageTitle%></div>

    <div class="lqdb" style="margin-top: 30px;">
        <ul id="zylq_tab">
                <li class="current"><a href="javascript:void(0);">历年录取数据</a></li>
                <li><a href="javascript:void(0);">录取位次对比图</a></li>
                <li><a href="javascript:void(0);">录取线差对比图</a></li>
                <li><a href="javascript:void(0);">录取分数对比图</a></li>
        </ul>
    </div>
    <script type="text/javascript">
        $(function () {
            var indx = 0;
            $("#zylq_tab  li").click(function () {
                indx = $("#zylq_tab  li").index(this) - 0;

                $(this).addClass("current").siblings().removeClass("current");
                $(".tab .Link_sj").eq(indx).show().siblings().hide();
            });
        });
    </script>

    <div class="tab" style="clear: both;">
    <%=strHighCharts%>

        <asp:Repeater ID="rpt_List" runat="server">
            <HeaderTemplate>
                <div class="Link_sj">
                    <table width="100%" border="1">
                        <tr>
                            <th>
                                年份
                            </th>
                            <%
                                  if (userinfo.ProvinceId == 10 || userinfo.ProvinceId == 11)
                                  { %>
                            <th>
                                专业
                            </th>
                            <%} %>
                            <%if (userinfo.ProvinceId != 11)
                              { %>
                            <th>
                                最高分
                            </th>
                            <th>
                                最低分
                            </th>
                            <%} %>
                            <th>
                                平均分
                            </th>
                            <th>
                                平均线差
                            </th>
                            <%if (userinfo.ProvinceId != 10 && userinfo.ProvinceId != 11)
                              { %>
                            <th>
                                最大位次
                            </th>
                            <th>
                                最小位次
                            </th>
                            <th>
                                平均位次
                            </th>
                            <%}%>
                            <th>
                                录取人数
                            </th>
                            <th>
                                批次
                            </th>
                            <th>
                                批次线
                            </th>
                            <th>
                                备注
                            </th>
                        </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td class="white">
                        <%#Eval("DataYear") %>
                    </td>
                    <%if (userinfo.ProvinceId == 10 || userinfo.ProvinceId == 11)
                      { %>
                    <td class="white">
                        <%#Eval("ZhuanYeMingCheng") %>
                        <%#Eval("BeiZhu") %>
                    </td>
                    <%} %>
                    
                    <%if (userinfo.ProvinceId != 11)
                      { %>
                    <td class="white">
                        <%#Eval("zyZuiGaoFen") %>
                    </td>
                    <td class="white">
                        <%#Eval("zyZuiDiFen") %>
                    </td>
                    <%} %>
                    <td class="white">
                        <%#Eval("zyPingJunFen") %>
                    </td>
                    <td class="white">
                        <%#Eval("zyPingJunXianCha")%>
                    </td>
                    <%if (userinfo.ProvinceId != 10 && userinfo.ProvinceId != 11)
                      { %>
                    <td class="white">
                        <%#Eval("zyZuiDaWeiCi") %>
                    </td>
                    <td class="white">
                        <%#Eval("zyZuiXiaoWeiCi") %>
                    </td>
                    <td class="white">
                        <%#Eval("zyPingJunWeiCi") %>
                    </td>
                    <%} %>
                    <td class="white">                        
                        <%#Eval("ZYLuQuShu").ToString() == "0" ? "-" : Eval("ZYLuQuShu")%>
                    </td>
                    <td class="white">
                        <%#DAL.Common.GetPiCiName(Basic.TypeConverter.StrToInt(Eval("PiCi").ToString()), Basic.TypeConverter.StrToInt(Eval("ProvinceId").ToString()))%>
                        <%#Eval("PcLeiBie").ToString() == "0" ? "" : (Eval("PcLeiBie").ToString() == "1" ? "A类" : (Eval("PcLeiBie").ToString() == "2" ? "B类" : "C类"))%>
                    </td>
                    <td class="white">
                        <%#Eval("ZyPiCiXian")%>
                    </td>
                    <td class="white">
                        <%#Eval("ZhuanYeBeiZhu")%>
                    </td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                </table> </div>
            </FooterTemplate>
        </asp:Repeater>

        
        <div class="Link_sj" style="display: none;">
            <div id="weicicontainer" style="width: 80%;">
            </div>
        </div>
        <div class="Link_sj" style="display: none;">
            <div id="xianchacontainer" style="width:80%;">
            </div>
        </div>
        <div class="Link_sj" style="display: none;">
            <div id="fenshucontainer" style="width: 80%;">
            </div>
        </div>
        </div>
    </div>
    </form>
</body>
</html>
