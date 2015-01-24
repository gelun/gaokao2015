<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProfessionalSearch.aspx.cs"
    Inherits="GaoKao.ProfessionalLibrary.ProfessionalSearch" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title><%=strProfessionalName%>专业_高考报考专业库_格伦高考网</title>
    <meta name="keywords" content="<%=strProfessionalName%>,专业查询,高考报考,格伦高考网" />
    <script src="/js/jquery.js" type="text/javascript"></script>
    <link href="/css/style.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <gk:ProfessionalBanner ID="ProfessionalBanner1" runat="server" BannerWord="格伦高考报考专业库" />
    <gk:Crumb ID="Crumb1" runat="server" />
    <div class="content" style="background: #fff;">
        <div class="contentbody">
            <div class="cxTit" style="margin-top: 20px;">
                <div class="cxTitL" style="font-size: 30px;">
                    “<%=strProfessionalName %>”专业搜索结果</div>
            </div>
            <div class="lqdb">
                <ul>
                    <li><a href="javascript:void(0);">专科</a></li>
                    <li class="cur"><a href="javascript:void(0);">本科</a></li>
                </ul>
            </div>
            <script type="text/javascript">

                $(function () {
                    $("#keyword").val("<%=strProfessionalName %>");
                    //初始化列表数据
                    Show();

                    //点击切换 专本科
                    $(".lqdb li").click(function () {
                        var index = $(this).index();
                        if (index == 0) {
                            ListShow(2);
                        } else {
                            ListShow(1);
                        }
                    });
                });
                //根据层次 展示对应的数据
                function ListShow(cengci) {
                    if (cengci == 1) {
                        $(".cxtable tr[k='1']").show()
                        $(".cxtable tr[k='2']").hide();

                        $(".lqdb li:eq(1)").addClass("cur").siblings().removeClass("cur");
                    } else if (cengci == 2) {
                        $(".cxtable tr[k='2']").show()
                        $(".cxtable tr[k='1']").hide();

                        $(".lqdb li:eq(0)").addClass("cur").siblings().removeClass("cur");
                    }
                }


                function Show() {
                    var benkecount = $(".cxtable tr[k='1']").length;
                    var zhuankecount = $(".cxtable tr[k='2']").length;

                    if (benkecount == 0 && zhuankecount > 0) {
                        $(".lqdb li:eq(0)").addClass("cur").siblings().removeClass("cur");
                        $(".cxtable tr[k='2']").show()
                        $(".cxtable tr[k='1']").hide();
                    } else {
                        $(".cxtable tr[k='1']").show()
                        $(".cxtable tr[k='2']").hide();

                        $(".lqdb li:eq(1)").addClass("cur").siblings().removeClass("cur");
                    }
                }
            </script>
            <div class="cxtable">
                <table width="100%" border="1">
                    <tr>
                        <th width="20%">
                            专业名称
                        </th>
                        <th width="20%">
                            专业代码
                        </th>
                        <th width="20%">
                            专业种类
                        </th>
                        <th width="20%">
                            专业介绍
                        </th>
                        <th width="20%">
                            开设院校
                        </th>
                    </tr>
                    <asp:Repeater ID="rptList" runat="server">
                        <ItemTemplate>
                            <tr<%#Eval("IsBen") == "1" ? " style=\" display:none;\"" : "" %> k="<%#Eval("IsBen") %>">
                                <td>
                                    <a href="/zhuanye-jianjie-<%#Eval("Id") %>.shtml" target="_blank"><%#Eval("ProfessionalName")%></a>
                                </td>
                                <td>
                                    <%#Eval("Code")%>
                                </td>
                                <td>
                                    <%#Eval("ZhuanYeLeiName")%>
                                </td>
                                <td>
                                    <a href="/zhuanye-jianjie-<%#Eval("Id") %>.shtml" target="_blank">查看</a>
                                </td>
                                <td>
                                    <a href="/zhuanye-daxue-<%#Eval("Id") %>.shtml" target="_blank">查看</a>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </table>
            </div>
        </div>
    </div>
    <gk:Footer ID="Footer1" runat="server" />
    </form>
</body>
</html>
