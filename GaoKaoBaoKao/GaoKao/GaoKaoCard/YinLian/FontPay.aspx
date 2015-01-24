<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FontPay.aspx.cs" Inherits="GaoKao.GaoKaoCard.YinLian.FontPay" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>购买高考报考卡_格伦高考报考卡_报考卡使用方法_报考卡用户特权_格伦高考网</title>
    <meta name="KeyWords" content="购买高考报考卡,格伦高考报考卡,报考卡使用方法,报考卡用户特权,格伦高考网" />
    <meta name="Description" content="格伦教育高考网隆重推出最新一代高考报考卡,功能报考:志愿智能模拟、专业倾向测试、按分查询院校、按名次查询院校、按分数线查询专业、院校对比、专业对比等" />
    <link href="/css/style.css" rel="stylesheet" type="text/css" />
    <link href="/css/style_gouka.css" rel="stylesheet" type="text/css" />
    <script src="/js/jquery.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {
            var result = '<%=strResult %>';
            function times() {
                var time = parseInt($.trim($("#sytimes").text()));
                $("#sytimes").text(time);
                if (time > 1) {
                    time = time - 1;
                    $("#sytimes").text(time);
                } else {
                    window.location.href = "/";
                }
                setTimeout(times, 1000);
            }

            if (result != "1") {
                $("#fkcg").hide();
                $("#fksb").show();
                setTimeout(times, 1000);
            }
            else {
                $("#fkcg").show();
                $("#fksb").hide();
            }
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <gk:Schoolbanner ID="SchoolBanner1" runat="server" BannerWord="格伦高考报考" />
    <gk:Crumb ID="Crumb1" runat="server" NavString=" <span>&gt;</span> 购买高考卡" />
    <div style="border-bottom: 1px solid #c8c8c8; width: 100%;">
        <div class="chenggong">
            <div id="fkcg">
                <div class="dui">
                    <span>付款成功</span></div>
                <%=strCardList %>
            </div>
            <div id="fksb">
                <div class="cuo">
                    <span>付款失败</span></div>
                <p>
                    <span id="sytimes" style="color: Red;">5</span> 秒后系统将自动为您跳转到购买高考高考卡页面</p>
            </div>
        </div>
    </div>
    <gk:Footer ID="Footer1" runat="server" />
    </form>
</body>
</html>
