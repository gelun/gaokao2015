<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ReSetPwd.aspx.cs" Inherits="GaoKao.Persional.ReSetPwd" %>

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
        function validate() {
           // $(function () {
                var pwd = $("#txtNewPwd").val();
                var pwd2 = $("#txtNewPwd2").val();
                if (pwd != pwd2) {
                    alert("两次输入的新密码不一致");
                    return false;
                } else {
                    return true;
                }
          //  });
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <gk:Schoolbanner ID="SchoolBanner1" runat="server" />
    <gk:Crumb ID="Crumb1" runat="server" NavString=" <span>&gt;</span> 高考报考卡密码修改" />
    <div class="content" style="background: #fff;">
        <div class="contentbody">
            <gk:UserCenterLeft ID="UserCenterLeft1" runat="server" />
            <div class="xiugaiR">
                <div class="xiugaiRtit">
                    高考报考卡密码修改</div>
                <div class="grxxtab" style="padding-top: 20px;">
                    <span>旧密码：</span>
                    <div class="grxxtabR">
                        <asp:TextBox ID="txtOldPwd" runat="server" TextMode="Password" class="text1" MaxLength="11"></asp:TextBox>
                    </div>
                </div>
                <div class="grxxtab">
                    <span>新密码：</span>
                    <div class="grxxtabR">
                        <asp:TextBox ID="txtNewPwd" runat="server" TextMode="Password" class="text1" MaxLength="11"></asp:TextBox>
                    </div>
                </div>
                <div class="grxxtab">
                    <span>确认新密码：</span>
                    <div class="grxxtabR">
                        <asp:TextBox ID="txtNewPwd2" runat="server" TextMode="Password" class="text1" MaxLength="11"></asp:TextBox>
                    </div>
                </div>
                <div class="grxxtab" style="padding-left: 300px; padding-top: 30px;">
                    <asp:Button ID="goSave" runat="server" class="tjbutton" Text="提交" OnClick="goSave_Click" OnClientClick="javascript:return validate();" />
                </div>
            </div>
        </div>
    </div>
    <gk:Footer ID="Footer1" runat="server" />
    </form>
</body>
</html>
