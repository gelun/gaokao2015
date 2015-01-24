<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="GaoKao.Register" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>格伦高考网_高考资源网_高考报考_高考时间_高考作文_高考倒计时_格伦教育网</title>
    <meta name="keywords" content="高考,高考网,高考资源网,高考报考,高考时间,高考作文,高考倒计时" />
    <meta name="description" content="格伦高考网是格伦教育下设八大项目之一,将高考报考与生涯教育完美结合。并为考生提供专业的高考报考卡,从学业规划等角度出发,引导学生更有针对性地填报志愿,为广大高中生和家长提供全面精准的指导。" />
    <script src="js/jquery.js" type="text/javascript"></script>
    <%--<script src="js/register.placeholder.js" type="text/javascript"></script>--%>
    <script src="js/jquery.placeholder.js" type="text/javascript"></script>
    <script src="js/register.js" type="text/javascript"></script>
    <link href="css/style.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <gk:Nav ID="nav1" runat="server" />
    <div class="reg">
        <div class="regbox">
            <div class="reg_L">
                <img src="images/2015zntb/reg_img.jpg" width="526" height="420" /></div>
            <div class="reg_R">
                <div class="reg_Tit">
                    用户注册</div>
                <div class="reg_text">
                    <input type="text" id="txt1" class="regtext" placeholder="帐号" /></div>
                <div class="reg_text">
                    <input type="password"
                        class="regtext" value="" id="pawd" name="" placeholder="密码" /></div>
                <div class="reg_text">
                    <input type="password"
                        id="repawd" class="regtext" name="" value="" placeholder="确认密码" /></div>
                <div class="reg_text">
                    <input type="text" id="yzm" class="regyzm" placeholder="验证码" /><img src="VerifyCode.aspx?v=login&'+Math.random();"
                        id="codeimg" style="cursor: pointer;" onclick="this.src='/VerifyCode.aspx?v=login&'+Math.random();"
                        alt="看不清楚,点击刷新" /></div>
                <div class="regbtn">
                    <a href="javascript:;">我要注册</a></div>
            </div>
        </div>
    </div>
    <gk:Footer ID="Footer1" runat="server" />
    </form>
</body>
</html>
