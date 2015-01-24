<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm2.aspx.cs" Inherits="GaoKao.WebForm2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="content-type" content="text/html; charset=utf-8" />
    <title></title>
    <script type="text/javascript" src="http://atth.eduu.com/jQuery.js"></script>
    <script type="text/javascript">
        function Focus(focusBox, focusPic, focusTxt, focusNum, focusOn) {
            $(focusPic).children('li').eq(0).show();
            $(focusTxt).children().eq(0).show();
            var len = $(focusNum).children().length;
            var index = 0;
            //鏁板瓧绱㈠紩鏄剧ず鍥剧墖
            $(focusNum).children().mouseover(function () {
                index = $(focusNum).children().index(this);
                showImg(index);
            });
            //榧犳爣缁忚繃鍥剧墖鍖哄煙鍋滄鎾斁
            $(focusBox).hover(function () {
                if (palyImg) {
                    clearInterval(palyImg);
                }
            }, function () {
                palyImg = setInterval(function () {
                    showImg(index);
                    index++;
                    if (index == len) { index = 0 }
                }, 5000);
            });
            //鑷姩鎾斁
            var palyImg = setInterval(function () {
                showImg(index);
                index++;
                if (index == len) { index = 0 }
            }, 5000);
            function showImg(i) {
                $(focusPic).children('li').eq(i).stop(true, true).fadeIn().siblings('li').fadeOut();
                $(focusTxt).children().eq(i).stop(true, true).fadeIn().siblings().fadeOut();
                $(focusNum).children().eq(i).addClass(focusOn).siblings().removeClass(focusOn);
            }
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="chenggong1">
        <div class="dui1">
            付款成功！</div>
        <div class="dui2">
            您购买的"艺术高考VIP"报考卡附赠的高考智能填报系统卡，"卡号、密码"发送到您的联系手机：150****1234，请注意查收短信！</div>
        <table width="420" height="100" cellspacing="1" style="text-align: center" class="tabd">
            <tbody>
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
                <tr>
                    <td style="color: #ff8c00">
                        GKBK201551141
                    </td>
                    <td style="color: #ff8c00;">
                        123456
                    </td>
                    <td>
                        <a href="" title="" style="color: #ff8c00;">完善信息&gt;&gt;</a>
                    </td>
                </tr>
            </tbody>
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
    </form>
</body>
</html>
