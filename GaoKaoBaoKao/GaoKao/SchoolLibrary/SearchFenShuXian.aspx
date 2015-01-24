<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SearchFenShuXian.aspx.cs"
    Inherits="GaoKao.SchoolLibrary.SearchFenShuXian" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>录取分数线_高考录取分数线_高考录取信息查询_高考录取率_格伦高考网</title>
    <meta name="keywords" content="录取分数线,高考录取分数线,高考录取信息查询,高考录取率,格伦高考网" />
    <meta name="description" content="录取分数线,高考录取分数线,高考录取信息查询,高考录取率,格伦高考网" />
    <script src="/js/jquery.js" type="text/javascript"></script>
    <link href="/css/style.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="/js/highcharts.js"></script>
    <style type="text/css">
        .sdbox .sdbtn
        {
            margin-top: 20px;
        }
    </style>
    <script type="text/javascript">
        $(function () {

            var kelei = $("#hidKeLei").val();
            $(".klsellist").find("option[value='" + kelei + "']").attr("selected", true);
            if (kelei != "-1") {
                $(".klsellist").attr("disabled", "disabled");
            }

            $("#cb_SetUpFenShuXian").live("click", function () {
                $("#div_fenshuxian").toggle();
            });

        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <gk:Schoolbanner ID="SchoolBanner1" runat="server" BannerWord="格伦高考报考院校库" />
    <gk:Crumb ID="Crumb1" runat="server" />
    <div class="cen_cen">
        <div class="shengfen" style="border-top: none; margin-top: 20px;">
            <div class="c1" style="float: left">
                院校所在地：</div>
            <div class="c2" style=" display:none;float: left; <%=intYuanXiaoDi == 0 ? "": "background: none; color: #393939; line-height: 30px;" %>">
                <a href="/chafenshuxian-0-<%=intWenLi %>-<%=intYear %>-<%=intShengYuanDi %>-<%=intCurrentPageNum %>.shtml"
                    style="<%=intYuanXiaoDi == 0 ? "color:#fff;": "color:#393939;" %>">全部</a>
            </div>
            <div class="c3" style="float: left">
                <ul class="uld">
                    <li><a href="/chafenshuxian-1-<%=intWenLi %>-<%=intYear %>-<%=intShengYuanDi %>-<%=intCurrentPageNum %>.shtml"
                        class="<%=intYuanXiaoDi == 1 ? "on" : "" %>">北京</a></li>
                    <li><a href="/chafenshuxian-2-<%=intWenLi %>-<%=intYear %>-<%=intShengYuanDi %>-<%=intCurrentPageNum %>.shtml"
                        class="<%=intYuanXiaoDi == 2 ? "on" : "" %>">天津</a></li>
                    <li><a href="/chafenshuxian-3-<%=intWenLi %>-<%=intYear %>-<%=intShengYuanDi %>-<%=intCurrentPageNum %>.shtml"
                        class="<%=intYuanXiaoDi == 3 ? "on" : "" %>">河北</a></li>
                    <li><a href="/chafenshuxian-4-<%=intWenLi %>-<%=intYear %>-<%=intShengYuanDi %>-<%=intCurrentPageNum %>.shtml"
                        class="<%=intYuanXiaoDi == 4 ? "on" : "" %>">山西</a></li>
                    <li><a href="/chafenshuxian-5-<%=intWenLi %>-<%=intYear %>-<%=intShengYuanDi %>-<%=intCurrentPageNum %>.shtml"
                        class="<%=intYuanXiaoDi == 5 ? "on" : "" %>">内蒙古</a></li>
                    <li><a href="/chafenshuxian-6-<%=intWenLi %>-<%=intYear %>-<%=intShengYuanDi %>-<%=intCurrentPageNum %>.shtml"
                        class="<%=intYuanXiaoDi == 6 ? "on" : "" %>">辽宁</a></li>
                    <li><a href="/chafenshuxian-7-<%=intWenLi %>-<%=intYear %>-<%=intShengYuanDi %>-<%=intCurrentPageNum %>.shtml"
                        class="<%=intYuanXiaoDi == 7 ? "on" : "" %>">吉林</a></li>
                    <li><a href="/chafenshuxian-8-<%=intWenLi %>-<%=intYear %>-<%=intShengYuanDi %>-<%=intCurrentPageNum %>.shtml"
                        class="<%=intYuanXiaoDi == 8 ? "on" : "" %>">黑龙江</a></li>
                    <li><a href="/chafenshuxian-9-<%=intWenLi %>-<%=intYear %>-<%=intShengYuanDi %>-<%=intCurrentPageNum %>.shtml"
                        class="<%=intYuanXiaoDi == 9 ? "on" : "" %>">上海</a></li>
                    <li><a href="/chafenshuxian-10-<%=intWenLi %>-<%=intYear %>-<%=intShengYuanDi %>-<%=intCurrentPageNum %>.shtml"
                        class="<%=intYuanXiaoDi == 10 ? "on" : "" %>">江苏</a></li>
                    <li><a href="/chafenshuxian-11-<%=intWenLi %>-<%=intYear %>-<%=intShengYuanDi %>-<%=intCurrentPageNum %>.shtml"
                        class="<%=intYuanXiaoDi == 11 ? "on" : "" %>">浙江</a></li>
                    <li><a href="/chafenshuxian-12-<%=intWenLi %>-<%=intYear %>-<%=intShengYuanDi %>-<%=intCurrentPageNum %>.shtml"
                        class="<%=intYuanXiaoDi == 12 ? "on" : "" %>">安徽</a></li>
                    <li><a href="/chafenshuxian-13-<%=intWenLi %>-<%=intYear %>-<%=intShengYuanDi %>-<%=intCurrentPageNum %>.shtml"
                        class="<%=intYuanXiaoDi == 13 ? "on" : "" %>">福建</a></li>
                    <li><a href="/chafenshuxian-14-<%=intWenLi %>-<%=intYear %>-<%=intShengYuanDi %>-<%=intCurrentPageNum %>.shtml"
                        class="<%=intYuanXiaoDi == 14 ? "on" : "" %>">江西</a></li>
                    <li><a href="/chafenshuxian-15-<%=intWenLi %>-<%=intYear %>-<%=intShengYuanDi %>-<%=intCurrentPageNum %>.shtml"
                        class="<%=intYuanXiaoDi == 15 ? "on" : "" %>">山东</a></li>
                    <li><a href="/chafenshuxian-16-<%=intWenLi %>-<%=intYear %>-<%=intShengYuanDi %>-<%=intCurrentPageNum %>.shtml"
                        class="<%=intYuanXiaoDi == 16 ? "on" : "" %>">河南</a></li>
                    <li><a href="/chafenshuxian-17-<%=intWenLi %>-<%=intYear %>-<%=intShengYuanDi %>-<%=intCurrentPageNum %>.shtml"
                        class="<%=intYuanXiaoDi == 17 ? "on" : "" %>">湖北</a></li>
                    <li><a href="/chafenshuxian-18-<%=intWenLi %>-<%=intYear %>-<%=intShengYuanDi %>-<%=intCurrentPageNum %>.shtml"
                        class="<%=intYuanXiaoDi == 18 ? "on" : "" %>">湖南</a></li>
                    <li><a href="/chafenshuxian-19-<%=intWenLi %>-<%=intYear %>-<%=intShengYuanDi %>-<%=intCurrentPageNum %>.shtml"
                        class="<%=intYuanXiaoDi == 19 ? "on" : "" %>">广东</a></li>
                    <li><a href="/chafenshuxian-20-<%=intWenLi %>-<%=intYear %>-<%=intShengYuanDi %>-<%=intCurrentPageNum %>.shtml"
                        class="<%=intYuanXiaoDi == 20 ? "on" : "" %>">广西</a></li>
                    <li><a href="/chafenshuxian-21-<%=intWenLi %>-<%=intYear %>-<%=intShengYuanDi %>-<%=intCurrentPageNum %>.shtml"
                        class="<%=intYuanXiaoDi == 21 ? "on" : "" %>">海南</a></li>
                    <li><a href="/chafenshuxian-22-<%=intWenLi %>-<%=intYear %>-<%=intShengYuanDi %>-<%=intCurrentPageNum %>.shtml"
                        class="<%=intYuanXiaoDi == 22 ? "on" : "" %>">重庆</a></li>
                    <li><a href="/chafenshuxian-23-<%=intWenLi %>-<%=intYear %>-<%=intShengYuanDi %>-<%=intCurrentPageNum %>.shtml"
                        class="<%=intYuanXiaoDi == 23 ? "on" : "" %>">西川</a></li>
                    <li><a href="/chafenshuxian-24-<%=intWenLi %>-<%=intYear %>-<%=intShengYuanDi %>-<%=intCurrentPageNum %>.shtml"
                        class="<%=intYuanXiaoDi == 24 ? "on" : "" %>">贵州</a></li>
                    <li><a href="/chafenshuxian-25-<%=intWenLi %>-<%=intYear %>-<%=intShengYuanDi %>-<%=intCurrentPageNum %>.shtml"
                        class="<%=intYuanXiaoDi == 25 ? "on" : "" %>">云南</a></li>
                    <li><a href="/chafenshuxian-26-<%=intWenLi %>-<%=intYear %>-<%=intShengYuanDi %>-<%=intCurrentPageNum %>.shtml"
                        class="<%=intYuanXiaoDi == 26 ? "on" : "" %>">西藏</a></li>
                    <li><a href="/chafenshuxian-27-<%=intWenLi %>-<%=intYear %>-<%=intShengYuanDi %>-<%=intCurrentPageNum %>.shtml"
                        class="<%=intYuanXiaoDi == 27 ? "on" : "" %>">陕西</a></li>
                    <li><a href="/chafenshuxian-28-<%=intWenLi %>-<%=intYear %>-<%=intShengYuanDi %>-<%=intCurrentPageNum %>.shtml"
                        class="<%=intYuanXiaoDi == 28 ? "on" : "" %>">甘肃</a></li>
                    <li><a href="/chafenshuxian-29-<%=intWenLi %>-<%=intYear %>-<%=intShengYuanDi %>-<%=intCurrentPageNum %>.shtml"
                        class="<%=intYuanXiaoDi == 29 ? "on" : "" %>">青海</a></li>
                    <li><a href="/chafenshuxian-30-<%=intWenLi %>-<%=intYear %>-<%=intShengYuanDi %>-<%=intCurrentPageNum %>.shtml"
                        class="<%=intYuanXiaoDi == 30 ? "on" : "" %>">宁夏</a></li>
                    <li><a href="/chafenshuxian-31-<%=intWenLi %>-<%=intYear %>-<%=intShengYuanDi %>-<%=intCurrentPageNum %>.shtml"
                        class="<%=intYuanXiaoDi == 31 ? "on" : "" %>">新疆</a></li>
                    <li><a href="/chafenshuxian-32-<%=intWenLi %>-<%=intYear %>-<%=intShengYuanDi %>-<%=intCurrentPageNum %>.shtml"
                        class="<%=intYuanXiaoDi == 32 ? "on" : "" %>">港澳台</a></li>
                </ul>
            </div>
        </div>
        <div class="shengfen" style="clear: both; border-bottom: 1px solid #fff">
            <div class="c1" style="float: left">
                考生类别：</div>
            <div class="c2" style=" display:none;float: left; <%=intWenLi == 0 ? "": "background: none; color: #393939; line-height: 30px;" %>">
                <a href="/chafenshuxian-<%=intYuanXiaoDi %>-0-<%=intYear %>-<%=intShengYuanDi %>-<%=intCurrentPageNum %>.shtml"
                    style="<%=intWenLi == 0 ? "color:#fff;": "color:#393939;" %>">全部</a>
            </div>
            <div class="c3" style="float: left">
                <ul class="uld">
                    <li><a href="/chafenshuxian-<%=intYuanXiaoDi %>-1-<%=intYear %>-<%=intShengYuanDi %>-<%=intCurrentPageNum %>.shtml"
                        class="<%=intWenLi == 1 ? "on" : "" %>">文科</a></li>
                    <li><a href="/chafenshuxian-<%=intYuanXiaoDi %>-5-<%=intYear %>-<%=intShengYuanDi %>-<%=intCurrentPageNum %>.shtml"
                        class="<%=intWenLi == 5 ? "on" : "" %>">理科</a></li>
                </ul>
            </div>
        </div>
        <div class="shengfen" style="border-top: 1px solid #dddddd; border-bottom: 1px solid #fff;
            clear: both">
            <div class="c1" style="float: left">
                录取年份：</div>
            <div class="c2" style=" display:none;float: left; <%=intYear == 0 ? "": "background: none; color: #393939; line-height: 30px;" %>">
                <a href="/chafenshuxian-<%=intYuanXiaoDi %>-<%=intWenLi %>-0-<%=intShengYuanDi %>-<%=intCurrentPageNum %>.shtml"
                    style="<%=intYear == 0 ? "color:#fff;": "color:#393939;" %>">全部</a>
            </div>
            <div class="c3" style="float: left">
                <ul class="uld">
                    <li><a href="/chafenshuxian-<%=intYuanXiaoDi %>-<%=intWenLi %>-2011-<%=intShengYuanDi %>-<%=intCurrentPageNum %>.shtml"
                        class="<%=intYear == 2011 ? "on" : "" %>">2011</a></li>
                    <li><a href="/chafenshuxian-<%=intYuanXiaoDi %>-<%=intWenLi %>-2012-<%=intShengYuanDi %>-<%=intCurrentPageNum %>.shtml"
                        class="<%=intYear == 2012 ? "on" : "" %>">2012</a></li>
                    <li><a href="/chafenshuxian-<%=intYuanXiaoDi %>-<%=intWenLi %>-2013-<%=intShengYuanDi %>-<%=intCurrentPageNum %>.shtml"
                        class="<%=intYear == 2013 ? "on" : "" %>">2013</a></li>
                    <li><a href="/chafenshuxian-<%=intYuanXiaoDi %>-<%=intWenLi %>-2014-<%=intShengYuanDi %>-<%=intCurrentPageNum %>.shtml"
                        class="<%=intYear == 2014 ? "on" : "" %>">2014</a></li>
                </ul>
            </div>
        </div>
        <div class="shengfen" style="clear: both;">
            <div class="c1" style="float: left">
                生源地：</div>
            <div class="c2" style=" display:none;float: left; <%=intShengYuanDi == 0 ? "": "background: none; color: #393939; line-height: 30px;" %>">
                <a href="/chafenshuxian-<%=intYuanXiaoDi %>-<%=intWenLi %>-<%=intYear %>-0-<%=intCurrentPageNum %>.shtml"
                    style="<%=intShengYuanDi == 0 ? "color:#fff;": "color:#393939;" %>">全部</a>
            </div>
            <div class="c3" style="float: left">
                <ul class="uld">
                    <li><a href="/chafenshuxian-<%=intYuanXiaoDi %>-<%=intWenLi %>-<%=intYear %>-1-<%=intCurrentPageNum %>.shtml"
                        class="<%=intShengYuanDi == 1 ? "on" : "" %>">北京</a></li>
                    <li><a href="/chafenshuxian-<%=intYuanXiaoDi %>-<%=intWenLi %>-<%=intYear %>-2-<%=intCurrentPageNum %>.shtml"
                        class="<%=intShengYuanDi == 2 ? "on" : "" %>">天津</a></li>
                    <li><a href="/chafenshuxian-<%=intYuanXiaoDi %>-<%=intWenLi %>-<%=intYear %>-3-<%=intCurrentPageNum %>.shtml"
                        class="<%=intShengYuanDi == 3 ? "on" : "" %>">河北</a></li>
                    <li><a href="/chafenshuxian-<%=intYuanXiaoDi %>-<%=intWenLi %>-<%=intYear %>-4-<%=intCurrentPageNum %>.shtml"
                        class="<%=intShengYuanDi == 4 ? "on" : "" %>">山西</a></li>
                    <li><a href="/chafenshuxian-<%=intYuanXiaoDi %>-<%=intWenLi %>-<%=intYear %>-5-<%=intCurrentPageNum %>.shtml"
                        class="<%=intShengYuanDi == 5 ? "on" : "" %>">内蒙古</a></li>
                    <li><a href="/chafenshuxian-<%=intYuanXiaoDi %>-<%=intWenLi %>-<%=intYear %>-6-<%=intCurrentPageNum %>.shtml"
                        class="<%=intShengYuanDi == 6 ? "on" : "" %>">辽宁</a></li>
                    <li><a href="/chafenshuxian-<%=intYuanXiaoDi %>-<%=intWenLi %>-<%=intYear %>-7-<%=intCurrentPageNum %>.shtml"
                        class="<%=intShengYuanDi == 7 ? "on" : "" %>">吉林</a></li>
                    <li><a href="/chafenshuxian-<%=intYuanXiaoDi %>-<%=intWenLi %>-<%=intYear %>-8-<%=intCurrentPageNum %>.shtml"
                        class="<%=intShengYuanDi == 8 ? "on" : "" %>">黑龙江</a></li>
                    <li><a href="/chafenshuxian-<%=intYuanXiaoDi %>-<%=intWenLi %>-<%=intYear %>-9-<%=intCurrentPageNum %>.shtml"
                        class="<%=intShengYuanDi == 9 ? "on" : "" %>">上海</a></li>
                    <li><a href="/chafenshuxian-<%=intYuanXiaoDi %>-<%=intWenLi %>-<%=intYear %>-10-<%=intCurrentPageNum %>.shtml"
                        class="<%=intShengYuanDi == 10 ? "on" : "" %>">江苏</a></li>
                    <li><a href="/chafenshuxian-<%=intYuanXiaoDi %>-<%=intWenLi %>-<%=intYear %>-11-<%=intCurrentPageNum %>.shtml"
                        class="<%=intShengYuanDi == 11 ? "on" : "" %>">浙江</a></li>
                    <li><a href="/chafenshuxian-<%=intYuanXiaoDi %>-<%=intWenLi %>-<%=intYear %>-12-<%=intCurrentPageNum %>.shtml"
                        class="<%=intShengYuanDi == 12 ? "on" : "" %>">安徽</a></li>
                    <li><a href="/chafenshuxian-<%=intYuanXiaoDi %>-<%=intWenLi %>-<%=intYear %>-13-<%=intCurrentPageNum %>.shtml"
                        class="<%=intShengYuanDi == 13 ? "on" : "" %>">福建</a></li>
                    <li><a href="/chafenshuxian-<%=intYuanXiaoDi %>-<%=intWenLi %>-<%=intYear %>-14-<%=intCurrentPageNum %>.shtml"
                        class="<%=intShengYuanDi == 14 ? "on" : "" %>">江西</a></li>
                    <li><a href="/chafenshuxian-<%=intYuanXiaoDi %>-<%=intWenLi %>-<%=intYear %>-15-<%=intCurrentPageNum %>.shtml"
                        class="<%=intShengYuanDi == 15 ? "on" : "" %>">山东</a></li>
                    <li><a href="/chafenshuxian-<%=intYuanXiaoDi %>-<%=intWenLi %>-<%=intYear %>-16-<%=intCurrentPageNum %>.shtml"
                        class="<%=intShengYuanDi == 16 ? "on" : "" %>">河南</a></li>
                    <li><a href="/chafenshuxian-<%=intYuanXiaoDi %>-<%=intWenLi %>-<%=intYear %>-17-<%=intCurrentPageNum %>.shtml"
                        class="<%=intShengYuanDi == 17 ? "on" : "" %>">湖北</a></li>
                    <li><a href="/chafenshuxian-<%=intYuanXiaoDi %>-<%=intWenLi %>-<%=intYear %>-18-<%=intCurrentPageNum %>.shtml"
                        class="<%=intShengYuanDi == 18 ? "on" : "" %>">湖南</a></li>
                    <li><a href="/chafenshuxian-<%=intYuanXiaoDi %>-<%=intWenLi %>-<%=intYear %>-19-<%=intCurrentPageNum %>.shtml"
                        class="<%=intShengYuanDi == 19 ? "on" : "" %>">广东</a></li>
                    <li><a href="/chafenshuxian-<%=intYuanXiaoDi %>-<%=intWenLi %>-<%=intYear %>-20-<%=intCurrentPageNum %>.shtml"
                        class="<%=intShengYuanDi == 20 ? "on" : "" %>">广西</a></li>
                    <li><a href="/chafenshuxian-<%=intYuanXiaoDi %>-<%=intWenLi %>-<%=intYear %>-21-<%=intCurrentPageNum %>.shtml"
                        class="<%=intShengYuanDi == 21 ? "on" : "" %>">海南</a></li>
                    <li><a href="/chafenshuxian-<%=intYuanXiaoDi %>-<%=intWenLi %>-<%=intYear %>-22-<%=intCurrentPageNum %>.shtml"
                        class="<%=intShengYuanDi == 22 ? "on" : "" %>">重庆</a></li>
                    <li><a href="/chafenshuxian-<%=intYuanXiaoDi %>-<%=intWenLi %>-<%=intYear %>-23-<%=intCurrentPageNum %>.shtml"
                        class="<%=intShengYuanDi == 23 ? "on" : "" %>">西川</a></li>
                    <li><a href="/chafenshuxian-<%=intYuanXiaoDi %>-<%=intWenLi %>-<%=intYear %>-24-<%=intCurrentPageNum %>.shtml"
                        class="<%=intShengYuanDi == 24 ? "on" : "" %>">贵州</a></li>
                    <li><a href="/chafenshuxian-<%=intYuanXiaoDi %>-<%=intWenLi %>-<%=intYear %>-25-<%=intCurrentPageNum %>.shtml"
                        class="<%=intShengYuanDi == 25 ? "on" : "" %>">云南</a></li>
                    <li><a href="/chafenshuxian-<%=intYuanXiaoDi %>-<%=intWenLi %>-<%=intYear %>-26-<%=intCurrentPageNum %>.shtml"
                        class="<%=intShengYuanDi == 26 ? "on" : "" %>">西藏</a></li>
                    <li><a href="/chafenshuxian-<%=intYuanXiaoDi %>-<%=intWenLi %>-<%=intYear %>-27-<%=intCurrentPageNum %>.shtml"
                        class="<%=intShengYuanDi == 27 ? "on" : "" %>">陕西</a></li>
                    <li><a href="/chafenshuxian-<%=intYuanXiaoDi %>-<%=intWenLi %>-<%=intYear %>-28-<%=intCurrentPageNum %>.shtml"
                        class="<%=intShengYuanDi == 28 ? "on" : "" %>">甘肃</a></li>
                    <li><a href="/chafenshuxian-<%=intYuanXiaoDi %>-<%=intWenLi %>-<%=intYear %>-29-<%=intCurrentPageNum %>.shtml"
                        class="<%=intShengYuanDi == 29 ? "on" : "" %>">青海</a></li>
                    <li><a href="/chafenshuxian-<%=intYuanXiaoDi %>-<%=intWenLi %>-<%=intYear %>-30-<%=intCurrentPageNum %>.shtml"
                        class="<%=intShengYuanDi == 30 ? "on" : "" %>">宁夏</a></li>
                    <li><a href="/chafenshuxian-<%=intYuanXiaoDi %>-<%=intWenLi %>-<%=intYear %>-31-<%=intCurrentPageNum %>.shtml"
                        class="<%=intShengYuanDi == 31 ? "on" : "" %>">新疆</a></li>
                    <li><a href="/chafenshuxian-<%=intYuanXiaoDi %>-<%=intWenLi %>-<%=intYear %>-32-<%=intCurrentPageNum %>.shtml"
                        class="<%=intShengYuanDi == 32 ? "on" : "" %>">港澳台</a></li>
                </ul>
            </div>
        </div>
    </div>
    <table width="1200" cellspacing="1" class="tabd">
        <tr style="background: #f7f7f7; color: #393939; font-size: 16px;">
            <td width="75">
                序号
            </td>
            <td width="390">
                院校名称
            </td>
            <td width="115">
                所在地
            </td>
            <td width="109">
                批次
            </td>
            <td width="140">
                高校录取平均分
            </td>
            <td width="130">
                省控线
            </td>
            <td width="120">
                线差
            </td>
            <td width="130">
                详情
            </td>
        </tr>
        <asp:Repeater ID="rptList" runat="server">
            <ItemTemplate>
                <tr>
                    <td>
                        <%#Container.ItemIndex+1 %>
                    </td>
                    <td>
                        <a target="_blank" href="http://gaokao.gelunjiaoyu.com/daxue-jianjie-<%#Eval("SchoolId") %>.shtml">
                            <%#Eval("SchoolName")%></a>
                    </td>
                    <td>
                         <%#Eval("SProvinceName")%>
                    </td>
                    <td>
                        <%#DAL.Common.GetPiCiName(Basic.TypeConverter.StrToInt(Eval("PiCi").ToString()), Basic.TypeConverter.StrToInt(Eval("ProvinceId").ToString()))%>
                    </td>
                    <td>
                        <%#Eval("PingJunFen") %>
                    </td>
                    <td>
                        <%#Eval("PiCiXian")%>
                    </td>
                    <td>
                        <%#Eval("PingJunXianCha")%>
                    </td>
                    <td>
                        <a target="_blank" href="http://gaokao.gelunjiaoyu.com/daxue-fenshuxian-<%#Eval("SchoolId") %>.shtml">查看</a>
                    </td>
                </tr>
            </ItemTemplate>
        </asp:Repeater>
    </table>
    <div class="fanye">
        <%=strPage %>
    </div>
    <div style="width: 100%; margin: 20px 0; border-bottom: 1px solid #dddddd;">
    </div>
    <gk:Footer ID="Footer1" runat="server" />
    </form>
</body>
</html>
