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
            //数字索引显示图片
            $(focusNum).children().mouseover(function () {
                index = $(focusNum).children().index(this);
                showImg(index);
            });
            //鼠标经过图片区域停止播放
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
            //自动播放
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
            ����ɹ���</div>
        <div class="dui2">
            �������"�����߿�VIP"�����������ĸ߿������ϵͳ����"���š�����"���͵�������ϵ�ֻ���150****1234����ע����ն��ţ�</div>
        <table width="420" height="100" cellspacing="1" style="text-align: center" class="tabd">
            <tbody>
                <tr style="background: #fffdf6">
                    <td width="140">
                        ��������ܿ�
                    </td>
                    <td width="140">
                        ԭʼ����
                    </td>
                    <td width="140">
                        ������Ϣ
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
                        <a href="" title="" style="color: #ff8c00;">������Ϣ&gt;&gt;</a>
                    </td>
                </tr>
            </tbody>
        </table>
        <div class="dui2" style="margin-top: 18px; color: #ff8c00;">
            ����������д��Ϣ������д����Ϣ����Ϊ���տ�һ��һר�ҷ��񡱵���Ҫ����</div>
        <div class="dui2">
            �߿������ϵͳ����¼��ַ��<a href="http://gaokao.gelunjiaoyu.com">http://gaokao.gelunjiaoyu.com</a></div>
        <div class="dui3" style="margin-top: 0px;">
            �˿��ɹ�һλ����ʹ�ã���Ч������ʹ�ô�����ʱ�����ƣ�����������������ʧ��һ���۳����Ų��˻���<br>
            �������⣬���µ�400-8032-868
        </div>
    </div>
    </form>
</body>
</html>
