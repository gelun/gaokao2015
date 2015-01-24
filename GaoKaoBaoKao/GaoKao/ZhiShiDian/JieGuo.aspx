<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="JieGuo.aspx.cs" Inherits="GaoKao.CePing.ZhiShiDian.JieGuo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>格伦高考网_高考资源网_高考报考_高考时间_高考作文_高考倒计时_格伦教育网</title>
    <meta name="keywords" content="高考,高考网,高考资源网,高考报考,高考时间,高考作文,高考倒计时" />
    <meta name="description" content="格伦高考网是格伦教育下设八大项目之一,将高考报考与生涯教育完美结合。并为考生提供专业的高考报考卡,从学业规划等角度出发,引导学生更有针对性地填报志愿,为广大高中生和家长提供全面精准的指导。" />
    <link href="/css/style.css" rel="stylesheet" type="text/css" />
    <script src="../../js/jquery.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {
            //点击题号进行切换
            $(".datiNav ul li").click(function () {
                var _index = $(this).index();
                //第几题
                $("#curtihao").text((_index + 1));
                //题号
                $(".tihao ul li:eq(" + _index + ")").addClass("cur").siblings().removeClass("cur");
                //试题
                $(".timubox:eq(" + _index + ")").show().siblings().hide();
            });
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <gk:Schoolbanner ID="SchoolBanner1" runat="server" BannerWord="格伦高考报考系统" />
    <gk:Crumb ID="Crumb1" runat="server" NavString=" <span>&gt;</span> 知识点检测" />
    <div class="content" style="background: #fff;">
        <div class="contentbody">
            <div class="zdjgTit">
                知识点检测结果</div>
            <div class="zdjgdf">
                本次诊断<%--得分<strong>47分</strong>--%>答对 <span>
                    <%=intRightCount %></span> 道题，答错 <span>
                        <%=intWrongCount %></span> 道题，未答 <span>
                            <%=intWeiDaCount%></span> 道题<%--，用时 <span>15</span>分钟--%></div>
            <div class="zdjgtitle">
                知识点检测结果</div>
            <div class="zdjgtable">
                <p>
                    此次测试，共测试<asp:Literal ID="ltlZhiShiDianCount" runat="server"></asp:Literal>个知识点，分别如下：</p>
                <table width="100%" border="1">
                    <tr>
                        <th width="14%">
                            序号
                        </th>
                        <th width="28%">
                            知识点
                        </th>
                        <th width="14%">
                            掌握程度
                        </th>
                        <th width="30%">
                            知识点学习
                        </th>
                        <th width="14%">
                            巩固练习
                        </th>
                    </tr>
                    <asp:Repeater ID="rptZhiShiDianList" runat="server" OnItemDataBound="rptZhiShiDianList_ItemDataBound">
                        <ItemTemplate>
                            <tr>
                                <td>
                                    <%#Container.ItemIndex+1 %>
                                </td>
                                <td class="tdleft">
                                    <%#Eval("name") %>
                                </td>
                                <td>
                                    <asp:Literal ID="ltlZhangWo" runat="server"></asp:Literal>
                                </td>
                                <td>
                                    <asp:Repeater ID="rptList" runat="server">
                                        <HeaderTemplate>
                                            <ul>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <li style="text-align: left; padding-left: 70px;">
                                                <%#Eval("Title")%>(<a target="_blank" href="zhishidianjiexi.aspx?id=<%#Eval("Id") %>">进入学习</a>)</li>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            </ul></FooterTemplate>
                                    </asp:Repeater>
                                </td>
                                <td>
                                    <a href="/GaoKaoZhenTi/JiChuGongGu.aspx?id=<%#Eval("Id") %>" target="_blank">巩固练习</a>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </table>
            </div>
            <div class="zdjgtitle">
                知识点检测结果</div>
            <div class="zdjgbox">
                <div class="tihao">
                    <ul>
                        <asp:Literal ID="ltlTiMu" runat="server"></asp:Literal>
                    </ul>
                </div>
                <div class="timu">
                    题目：<span id="curtihao">1</span>/<%=TiMuList %>&nbsp;</div>
                <asp:Repeater ID="rptList" runat="server" OnItemDataBound="rptList_OnItemDataBound">
                    <ItemTemplate>
                        <div class="timubox" <%#(Container.ItemIndex+1) == 1 ? "style='display:block;'" : "style='display:none;'"%>>
                            <%#Eval("content") %>
                            <div class="daan">
                                <div class="daanL">
                                    <ul>
                                        <li class="zhengque">正确答案：<%#Eval("objective_answer") %></li>
                                        <li>您的答案：<%#Eval("your_answer") %></li>
                                    </ul>
                                </div>
                                <div class="daanR">
                                    <asp:Literal ID="ltlDifficulty" runat="server" Text='<%#Eval("difficulty") %>' Visible="false"></asp:Literal>
                                    <asp:Literal ID="ltlDifficult" runat="server"></asp:Literal>
                                </div>
                            </div>
                            <div class="shoucang">
                                <ul>
                                    <li class="scgt" style="display: none;"><a href="javascript:;">收藏该题</a></li>
                                    <li class="jrctb"><a target="_blank" href="/gaokaozhenti/cuotiben.aspx">错题本</a></li>
                                </ul>
                            </div>
                            <div class="jiexi">
                                <h3>
                                    题目解析</h3>
                                <p>
                                    <%#Eval("answer") %></p>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
                <script type="text/javascript">
                    $(function () {
                        //点击题号进行切换
                        $(".zdjgbox .tihao ul li").click(function () {
                            if ($(this).hasClass("cur")) {
                                //当前题目 不做任何处理
                            } else {
                                if ($(this).text() != "") {

                                    var _index = $(this).index();
                                    //第几题
                                    $("#curtihao").text((_index + 1));
                                    //题号
                                    $(".zdjgbox .tihao ul li:eq(" + _index + ")").addClass("cur").siblings().removeClass("cur");
                                    //试题
                                    $(".timubox").each(function (index) {
                                        if (index == _index) {
                                            $(".timubox:eq(" + _index + ")").show();
                                        } else {
                                            $(".timubox:eq(" + index + ")").hide();
                                        }
                                    });
                                }
                            }
                        });
                    });
                </script>
            </div>
        </div>
    </div>
    <gk:Footer ID="Footer1" runat="server" />
    </form>
</body>
</html>
