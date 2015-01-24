<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="data_yx.aspx.cs" Inherits="GaoKao.TuiJian.data_yx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
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
                            <%if (userinfo.ProvinceId == 10){ %>
                            <th>代码及院校</th>
                    <%} %>
                            <th>
                                最高分
                            </th>
                            <th>
                                最低分
                            </th>
                            <th>
                                平均分
                            </th>
                            <th>
                                平均线差
                            </th>
                            <%if (userinfo.ProvinceId != 10)
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
                            <%} %>
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
                    <%if (userinfo.ProvinceId == 10){ %>
                    <td class="white">
                        <%#Eval("YuanXiaoDaiMa") %>
                        <%#Eval("YuanXiaoMingCheng") %>
                    </td>
                    <%} %>
                    <td class="white">
                        <%#Eval("ZuiGaoFen") %>
                    </td>
                    <td class="white">
                        <%#Eval("ZuiDiFen") %>
                    </td>
                    <td class="white">
                        <%#Eval("PingJunFen") %>
                    </td>
                    <td class="white">
                        <%#Eval("PingJunXianCha")%>
                    </td>
                    <%if (userinfo.ProvinceId != 10)
                      { %>
                    <td class="white">
                        <%#Eval("ZuiDaWeiCi") %>
                    </td>
                    <td class="white">
                        <%#Eval("ZuiXiaoWeiCi")%>
                    </td>
                    <td class="white">
                        <%#Eval("PingJunWeiCi")%>
                    </td>
                    <%} %>
                    <td class="white">
                        <%#Eval("LuQuShu").ToString() == "0" ? "-" : Eval("LuQuShu")%>
                    </td>
                    <td class="white">
                        <%#DAL.Common.GetPiCiName(Basic.TypeConverter.StrToInt(Eval("PiCi").ToString()), Basic.TypeConverter.StrToInt(Eval("ProvinceId").ToString()))%>
                        <%#Eval("PcLeiBie").ToString() == "0" ? "" : (Eval("PcLeiBie").ToString() == "1" ? "A类" : (Eval("PcLeiBie").ToString() == "2" ? "B类" : "C类"))%>
                    </td>
                    <td class="white">
                        <%#Eval("PiCiXian")%>
                    </td>
                    <td class="white">
                        <%#Eval("YuanXiaoBeiZhu")%>
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
