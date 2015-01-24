<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ChengJiEdit.aspx.cs" Inherits="GaoKao.Persional.ChengJiEdit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>格伦高考网_高考资源网_高考报考_高考时间_高考作文_高考倒计时_格伦教育网</title>
    <meta name="keywords" content="高考,高考网,高考资源网,高考报考,高考时间,高考作文,高考倒计时" />
    <meta name="description" content="格伦高考网是格伦教育下设八大项目之一,将高考报考与生涯教育完美结合。并为考生提供专业的高考报考卡,从学业规划等角度出发,引导学生更有针对性地填报志愿,为广大高中生和家长提供全面精准的指导。" />
    <script src="/js/jquery.js" type="text/javascript"></script>
    <link href="/css/style.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .sdbox .sdbtn
        {
            margin-top: 20px;
        }
    </style>
    <script type="text/javascript">
        $(function () {

            var kelei = $("#hidKeLei").val();
            if (kelei == "-1") {
                $(".klsellist").attr("disabled", "disabled");
            }

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
                <asp:HiddenField ID="hidKeLei" runat="server" />
                <div class="xiugaiRtit" style="border-bottom: 0;">
                    用户成绩设定</div>
                <div class="sdul">
                    <ul>
                        <li class="cur"><a href="ChengJiEdit.aspx">用户成绩</a></li>
                        <li><a href="ChengJiEdit2.aspx">修改平时成绩</a></li>
                        <li><a href="ChengJiEdit3.aspx">设置高考成绩</a></li>
                    </ul>
                </div>
                <div class="sdbox">
                    <asp:Literal ID="ltlTiXing1" runat="server"></asp:Literal>
                    <div class="sdbtn">
                        <a href="/tuijian/default.aspx">确认</a></div>
                </div>
            </div>
        </div>
    </div>
    <gk:Footer ID="Footer1" runat="server" />
    </form>
</body>
</html>
