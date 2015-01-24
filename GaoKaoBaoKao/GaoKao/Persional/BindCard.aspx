<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BindCard.aspx.cs" Inherits="GaoKao.Persional.BindCard" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>格伦高考网_高考资源网_高考报考_高考时间_高考作文_高考倒计时_格伦教育网</title>
    <meta name="keywords" content="高考,高考网,高考资源网,高考报考,高考时间,高考作文,高考倒计时" />
    <meta name="description" content="格伦高考网是格伦教育下设八大项目之一,将高考报考与生涯教育完美结合。并为考生提供专业的高考报考卡,从学业规划等角度出发,引导学生更有针对性地填报志愿,为广大高中生和家长提供全面精准的指导。" />
    <script src="/js/jquery.js" type="text/javascript"></script>
    <link href="/css/style.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        $(function () {
            $(".bkkbutton").click(function () {
                var kahao = $("#txtKaHao").val();
                var mima = $("#txtPwd").val();
                if (kahao == "") {
                    alert("请填写卡号");
                    return false;
                }
                if (mima == "") {
                    alert("请填写密码");
                    return false;
                }

                $.ajax({
                    url: $("#form1").attr("action"),    // 提交的页面
                    data: { ty: "bind", kahao: kahao, mima: mima },       // 从表单中获取数据
                    type: "GET",                        // 设置请求类型为"GET"，默认为"GET"
                    beforeSend: function ()             // 设置表单提交前方法
                    {
                        //提交前的动作
                    },
                    error: function (data, status, e) {
                        // 异常提示 
                    },
                    success: function (data) {
                        alert(data);
                    }
                });
            });
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
    
    <gk:Schoolbanner ID="SchoolBanner1" runat="server" />
    <gk:Crumb ID="Crumb1" runat="server" />
    <div class="content" style="background: #fff;">
        <div class="contentbody">
            <gk:UserCenterLeft ID="UserCenterLeft1" runat="server" />
            <div class="xiugaiR">
                <div class="xiugaiRtit">
                    绑定高考报考卡</div>
                <div class="bkk">
                    <div class="grxxtab">
                        <span>卡号：</span>
                        <div class="grxxtabR">
                            <input id="txtKaHao" type="text" class="text1" name="" />
                        </div>
                    </div>
                    <div class="grxxtab">
                        <span>密码：</span>
                        <div class="grxxtabR">
                            <input id="txtPwd" type="text" class="text1" name="" />
                        </div>
                    </div>
                    <div class="bkkbtn">
                        <input type="button" class="bkkbutton" value="提交绑定" />
                    </div>
                </div>
            </div>
        </div>
    </div>
    <gk:Footer ID="Footer1" runat="server" />
    </form>
</body>
</html>
