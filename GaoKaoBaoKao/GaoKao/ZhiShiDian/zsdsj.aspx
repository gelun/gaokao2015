<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="zsdsj.aspx.cs" Inherits="GaoKao.CePing.ZhiShiDian.zsdsj" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>格伦高考网_高考资源网_高考报考_高考时间_高考作文_高考倒计时_格伦教育网</title>
    <meta name="keywords" content="高考,高考网,高考资源网,高考报考,高考时间,高考作文,高考倒计时" />
    <meta name="description" content="格伦高考网是格伦教育下设八大项目之一,将高考报考与生涯教育完美结合。并为考生提供专业的高考报考卡,从学业规划等角度出发,引导学生更有针对性地填报志愿,为广大高中生和家长提供全面精准的指导。" />
    <link href="/css/style.css" rel="stylesheet" type="text/css" />
    <script src="../../js/jquery.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
    <gk:Schoolbanner ID="SchoolBanner1" runat="server" BannerWord="格伦高考报考系统" />
    <gk:Crumb ID="Crumb1" runat="server" NavString=" <span>&gt;</span> 知识点检测 <span>&gt;</span> 高中知识点" />
    <div class="content" style="background: #fff;">
        <div class="contentbody">
            <div class="zdjgtitle">
                知识点检测</div>
            <div class="zdshijian">
                诊断时间：<span><asp:Literal ID="ltlTime" runat="server"></asp:Literal>分钟</span></div>
            <div class="dati">
                <div class="datiNav">
                    <ul>
                        <asp:Literal ID="ltlTiMu" runat="server"></asp:Literal>
                        <%-- <li class="daguo"><a href="#">1</a></li>
                        <li class="cur"><a href="#">2</a></li>
                        <li style="width: 78px; border-right: 0;"><a href="#">15</a></li>--%>
                    </ul>
                </div>
                <div class="timu" style="float: left;">
                    题目：<span id="curtihao">1</span>/<%=TiMuList %>;&nbsp;&nbsp;&nbsp;&nbsp&nbsp;分值：5分&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;题型：单选题</div>
                <asp:Repeater ID="rptList" runat="server" OnItemDataBound="rptList_OnItemDataBound">
                    <ItemTemplate>
                        <div class="datibox" gid="<%#Eval("gid") %>" <%#(Container.ItemIndex+1) == 1 ? "style='display:block;'" : "style='display:none;'"%>>
                            <div class="dati_ti">
                                <%#Eval("content") %>
                            </div>
                            <div class="xzdaan">
                                <ul gid="<%#Eval("gid") %>">
                                    <li style="margin-right: 0;">选择答案：</li>
                                    <li>
                                        <input type="radio" class="rad" name="rd<%#Container.ItemIndex %>" value="A" /><span>A</span></li>
                                    <li>
                                        <input type="radio" class="rad" name="rd<%#Container.ItemIndex %>" value="B" /><span>B</span></li>
                                    <li>
                                        <input type="radio" class="rad" name="rd<%#Container.ItemIndex %>" value="C" /><span>C</span></li>
                                    <li>
                                        <input type="radio" class="rad" name="rd<%#Container.ItemIndex %>" value="D" /><span>D</span></li>
                                </ul>
                            </div>
                            <div class="xiayiti">
                                <ul>
                                    <li class="xyt"><a href="javascript:;">
                                        <asp:Literal ID="ltlNextTiMu" runat="server"></asp:Literal></a></li>
                                    <li class="jiaojuan"><a href="javascript:;">提交试卷</a></li>
                                </ul>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
                <script type="text/javascript">
                    $(function () {
                        //点击题号进行切换
                        $(".dati .datiNav ul li").click(function () {
                            //                            if ($(this).hasClass("daguo") || $(this).hasClass("cur")) {
                            //                                //已经做过的题目或者当前题目 不做任何处理
                            //                            } else {
                            //                                var _index = $(this).index();
                            //                                //第几题
                            //                                $("#curtihao").text((_index + 1));
                            //                                //题号
                            //                                $(".dati .datiNav ul li:eq(" + _index + ")").addClass("cur").siblings().removeClass("cur");
                            //                                //试题
                            //                                $(".dati .datibox").each(function (index) {
                            //                                    if (index == _index) {
                            //                                        $(".dati .datibox:eq(" + _index + ")").show();
                            //                                    } else {
                            //                                        $(".dati .datibox:eq(" + index + ")").hide();
                            //                                    }
                            //                                });
                            //                            }
                        });
                        //点击下一题
                        $(".datibox .xiayiti .xyt").click(function () {
                            var _lastindex = "<%=TiMuList %>";
                            //索引
                            var _tmindex = $(".datibox .xiayiti .xyt").index(this);
                            if ((_tmindex + 1) * 1 < _lastindex * 1) {
                                var result = $("input[type='radio'][name='rd" + _tmindex + "']:checked").val();
                                if (result == null) {
                                    alert("请选择答案!");
                                    return false;
                                }
                                else {
                                    //第几题
                                    $("#curtihao").text((_tmindex + 1));
                                    //题号
                                    $(".dati .datiNav ul li:eq(" + _tmindex + ")").addClass("daguo")
                                    $(".dati .datiNav ul li:eq(" + (_tmindex + 1) + ")").addClass("cur").siblings().removeClass("cur");
                                    //试题
                                    $(".dati .datibox").each(function (index) {

                                        if (index < _lastindex) {
                                            if (index == (_tmindex + 1)) {
                                                $(".dati .datibox:eq(" + (_tmindex + 1) + ")").show();
                                            } else {
                                                $(".dati .datibox:eq(" + index + ")").hide();
                                            }
                                        } else {
                                            //最后一题
                                        }
                                    });
                                }
                            }
                        });
                        //点击交卷
                        $(".jiaojuan").click(function () {
                            //拼接用户选择的结果
                            var _lastindex = "<%=TiMuList %>";
                            var list = "";
                            for (var i = 0; i < (_lastindex * 1); i++) {
                                var _rd = $("input[type='radio'][name='rd" + i + "']:checked");
                                var gid = _rd.parent().parent().attr("gid");
                                var result = _rd.val();
                                if (result == null) {
                                    gid = $("input[type='radio'][name='rd" + i + "']").parent().parent().attr("gid");
                                    list = list + gid + ":0,";
                                } else {
                                    list = list + gid + ":" + result + ",";
                                }
                            }
                            //
                            window.location.href = "JieGuo.aspx?kl=<%=intKL %>&zsdlist=<%=strList %>&stlist=" + list;
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
