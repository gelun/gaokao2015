<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ReturnUrl.aspx.cs" Inherits="GaoKao.Art.GouMai.ReturnUrl" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>购买艺考VIP卡_报考卡使用方法_报考卡用户特权_格伦高考网 </title>
    <link href="/css/style.css" rel="stylesheet" type="text/css" />
    <link href="/css/ys_gouka.css" rel="stylesheet" type="text/css" />
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
                    window.location.href = "Index.aspx";
                }
                setTimeout(times, 1000);
            }

            if (result != "success") {
                $("#zhifuchenggong").hide();
                $("#zhifushibai").show();
                setTimeout(times, 1000);
            }
            else {
                $("#zhifuchenggong").show();
                $("#zhifushibai").hide();
            }
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <gk:Schoolbanner ID="SchoolBanner1" runat="server" BannerWord="格伦高考报考" />
    <gk:Crumb ID="Crumb1" runat="server" NavString=" <span>&gt;</span> <a href='gouka.aspx'>购买艺术高考VIP卡</a> <span>&gt;</span> 支付结果" />
    <div id="zhifuchenggong" style="border-bottom: 1px solid #c8c8c8; width: 100%;">
        <div class="chenggong1">
            <div class="dui1">
                付款成功！</div>
            <div class="dui2">
                您购买的"艺术高考VIP"报考卡附赠的高考智能填报系统卡，"卡号、密码"发送到您的联系手机：<%=strMobile %>，请注意查收短信！</div>
            <table width="420" height="100" cellspacing="1" style="text-align: center" class="tabd">
                <tr style="background: #fffdf6">
                    <td width="140">
                        智能填报智能卡
                    </td>
                    <td width="140">
                        原始密码
                    </td>
                    <td width="140">
                        完善信息
                    </td>
                </tr>
                <%=strCardList %>
            </table>
            <div class="dui2" style="margin-top: 18px; color: #ff8c00;">
                请您认真填写信息，您填写的信息将作为“艺考一对一专家服务”的重要依据</div>
            <div class="dui2">
                高考智能填报系统卡登录网址：<a href="http://gaokao.gelunjiaoyu.com">http://gaokao.gelunjiaoyu.com</a></div>
            <div class="dui3" style="margin-top: 0px;">
                此卡可供一位考生使用，有效期内无使用次数和时间限制；本卡不记名、不挂失，一经售出，概不退换！<br>
                如有问题，可致电400-8032-868
            </div>
        </div>
    </div>
    <div id="zhifushibai" style="border-bottom: 1px solid #c8c8c8; width: 100%;">
        <div class="chenggong">
            <div id="fksb">
                <div class="cuo">
                    <span>付款失败</span></div>
                <p>
                    <span id="sytimes" style="color: Red;">5</span> 秒后系统将自动为您跳转到购买艺考VIP卡页面</p>
            </div>
        </div>
    </div>
    <gk:Footer ID="Footer1" runat="server" />
    </form>
</body>
</html>
