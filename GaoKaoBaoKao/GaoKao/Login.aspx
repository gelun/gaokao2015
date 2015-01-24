<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="GaoKao.Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>用户登录_格伦高考网</title>
    <script src="js/jquery.js" type="text/javascript"></script>
    <script src="js/login.placeholder.js" type="text/javascript"></script>
    <script src="js/login.js" type="text/javascript"></script>
    <link href="css/style.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        $(function () {
            var strStatus = "<%=Status %>";
            var strStudentName = "<%=StudentName %>";
            var strBank = "<%=Bank %>";
            var strLevel = "<%=Level %>";
            var strLevelName = "<%=LevelName %>";
            var strProvinceName = "<%=ProvinceName %>";

            switch (strStatus) {
                case "1": //需要先去完善个人信息
                    location.href = "Persional/LetterForParent.aspx";
                    break;
                case "3":
                    //正常的高考卡用户
                    var ObjHtml = "<li>学生姓名：" + strStudentName + "</li>"
                                    + "<li>当前帐号：" + strBank + "</li>"
                                    + "<li>会员等级：" + strLevelName + "</li>"
                                    + "<li>所在省份：" + strProvinceName + "</li>";
                    $(".login:eq(0)").find(".xinxi ul").html(ObjHtml);
                    $(".login:eq(1)").hide();
                    $(".login:eq(0)").show();
                    break;
                case "4":
                    //注册用户或者会员卡用户
                    var ObjHtml = "<li>学生姓名：" + strStudentName + "</li>"
                                    + "<li>当前帐号：" + strBank + "</li>"
                                    + "<li>会员等级：" + strLevelName + "</li>"
                                    + "<li>所在省份：" + strProvinceName + "</li>";
                    $(".login:eq(0)").find(".xinxi ul").html(ObjHtml);
                    $(".login:eq(1)").hide();
                    $(".login:eq(0)").show();
                    break;
                default:
                    break;
            }

        });

    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="indexcon">
        <gk:Nav ID="nav1" runat="server" />
        <div class="conbox">
            <div class="conword">精准填报<br />&nbsp;&nbsp;&nbsp;&nbsp;直通中国2500所大学！</div>
            <div class="login" style="display: none;">
                <div class="loginTit">
                    用户信息</div>
                <div class="welcome">
                    欢迎使用格伦高考报考系统</div>
                <div class="xinxi">
                    <ul>
                        <li>学生姓名：张三</li>
                        <li>当前帐号：1234567</li>
                        <li>会员等级：用户</li>
                        <li>所在省份：山东</li>
                    </ul>
                </div>
                <div class="btn"><a href="tuijian/default.aspx"><img src="images/2015zntb/dlxt.png" /></a></div>
                    
                <div class="sysm">
                    <div class="zhmm">
                        <ul>
                            <li class="zh3"><a href="/help/list.shtml">使用说明</a></li>
                            <li class="zh2"><a href="/help/help2.shtml">系统演练</a></li>
                            <li class="zh4"><a href="logout.aspx">退出登录</a></li>
                        </ul>
                    </div>
                </div>
            </div>
            <div class="login">
                <div class="loginTit">
                    格伦高考报考系统</div>
                <div class="inputbox">
                    <input type="text" id="txt1" value="帐号" />
                    <input type="text" id="txt2" value="密码"  />
                    <input type="password" id="pawd" value="" style="display:none;"  />
                </div>
                <div class="yzm">
                    <input type="text" id="yzm" value="验证码" size="4" />
                    <img src="VerifyCode.aspx" id="codeimg" style="cursor: pointer;" onclick="this.src='VerifyCode.aspx?v=login&'+Math.random();"
                        alt="看不清楚,点击刷新" />
                    <div class="wjmm">
                        <a href="#">忘记登录密码</a></div>
                </div>
                <div class="deng">
                    <input type="button" value="登录" name="" id="loginsys" />
                </div>
                <div class="zhmm">
                    <ul>
                        <li class="zh1"></li>
                            <li class="zh2"><a href="/help/help2.shtml">系统演练</a></li>
                    </ul>
                </div>
                <div class="btn">
                    <a href="/GaoKaoCard/GouKa.aspx">
                        <img src="images/2015zntb/gm.png" /></a></div>
            </div>
        </div>
    </div>
    <gk:Footer ID="Footer1" runat="server" />
    </form>
</body>
</html>
