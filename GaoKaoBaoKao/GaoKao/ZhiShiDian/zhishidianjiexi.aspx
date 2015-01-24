<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="zhishidianjiexi.aspx.cs"
    Inherits="GaoKao.CePing.ZhiShiDian.zhishidianjiexi" %>

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
    <gk:Crumb ID="Crumb1" runat="server" NavString=" <span>&gt;</span> 知识点讲解" />
    <div class="content" style="background: #fff;">
        <div class="contentbody">
            <div class="cxTit" style="margin-top: 20px;">
                <div class="cxTitL" style="font-size: 30px;">
                    高中知识点</div>
            </div>
            <div class="xuekelist">
                <ul>
                    <li>学&nbsp;&nbsp;&nbsp;&nbsp;科：</li>
                    <li class="cur2"><a href="zhishidianjiexi.aspx?id=3954">语文</a></li>
                    <li><a href="zhishidianjiexi.aspx?id=4034">数学</a></li>
                    <li><a href="zhishidianjiexi.aspx?id=3984">英语</a></li>
                    <li><a href="zhishidianjiexi.aspx?id=4137">物理</a></li>
                    <li><a href="zhishidianjiexi.aspx?id=4221">化学</a></li>
                    <li><a href="zhishidianjiexi.aspx?id=4281">生物</a></li>
                    <li><a href="zhishidianjiexi.aspx?id=4386">历史</a></li>
                    <li><a href="zhishidianjiexi.aspx?id=4518">地理</a></li>
                    <li><a href="zhishidianjiexi.aspx?id=4623">政治</a></li>
                </ul>
            </div>
            <div class="zhishidian">
                <div class="zsdL">
                    <div class="zsdTit">
                        <span>
                            <img src="/images/zsd_jt.jpg" /></span>高中<asp:Literal ID="ltlKeMuTitle" runat="server"></asp:Literal>知识点</div>
                    <div class="zsdul">
                        <asp:Literal ID="ltlLeftZhiShiDianList" runat="server"></asp:Literal>
                    </div>
                    <script type="text/javascript">
                        $(function () {
                            $('span.zk').click(function () {
                                $(this).parent().children('ul').slideToggle(150);
                                $(this).toggleClass('main');
                            });
                            $('.zktitle').click(function () {
                                $(this).parent().children('ul').slideToggle(150);
                                $(this).toggleClass('main');
                            });
                        });
                    </script>
                </div>
                <div class="zsdR">
                    <div class="zsdTit">
                        知识点介绍</div>
                    <div class="zsdRbox">
                        <h3>
                            知识点总结</h3>
                        <asp:Literal ID="ltlZongJie" runat="server"></asp:Literal>
                    </div>
                    <div class="zsdRbox">
                        <h3>
                            常见考法</h3>
                        <asp:Literal ID="ltlKaoFa" runat="server"></asp:Literal>
                    </div>
                    <div class="zsdRbox" style="border-bottom: 0;">
                        <h3>
                            误区提醒</h3>
                        <asp:Literal ID="ltlWuQuTiXing" runat="server"></asp:Literal>
                    </div>
                    <script type="text/javascript">
                        $(function () {
                            var linkid = "<%=LinkId %>";
                            if (linkid == "13") {
                                $(".zsdRbox:eq(0)").css("border-bottom", "0");
                                $(".zsdRbox:gt(0)").hide();
                            }
                        });
                    </script>
                </div>
            </div>
        </div>
    </div>
    <gk:Footer ID="Footer1" runat="server" />
    </form>
</body>
</html>
