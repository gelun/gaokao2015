document.onkeydown = function (event) {
    e = event ? event : (window.event ? window.event : null);
    if (e.keyCode == 13) {
        //按下回车键  执行的方法 
        Valid();
    }
}
$(function () {
    $("#loginsys").click(function () {
        Valid(); //验证表单数据
    });
});

function submitform() {
    var bank = $("#txt1").val();
    var password = $("#pawd").val();
    $.ajax({
        url: "Persional/loginin.ashx",
        type: "get",
        data: { bank: bank, password: password },
        success: function (data) {
            if (data != "") {
                var dataObj = eval("(" + data + ")"); //转换为json对象
                var ObjHtml = "";
                ObjHtml += "<li>学生姓名：" + dataObj.studentname + "</li>"
                                        + "<li>当前帐号：" + dataObj.bank + "</li>"
                                        + "<li>会员等级：" + dataObj.levelname + "</li>"
                                        + "<li>所在省份：" + dataObj.province + "</li>";

                switch (dataObj.status) {
                    case "0": alert("账号或者密码错误");
                        break;
                    case "1": //需要先去完善个人信息
                        location.href = "Persional/LetterForParent.aspx";
                        break;
                    case "2": alert("账号已经过期或者已经被关闭使用");
                        break;
                    case "3":
                        //正常的高考卡用户
                        $(".login:eq(0)").find(".xinxi ul").html(ObjHtml);
                        $(".login:eq(1)").hide();
                        $(".login:eq(0)").show();
                        break;
                    case "4":
                        //注册用户或者会员卡用户
                        $(".login:eq(0)").find(".xinxi ul").html(ObjHtml);
                        $(".login:eq(1)").hide();
                        $(".login:eq(0)").show();
                        break;
                    default: alert("账号或者密码错误");
                        break;
                }
            } else {
                alert("账号或者密码错误");
            }
        }
    });
}

function Valid() {
    var bank = $("#txt1").val();
    var password = $("#pawd").val();
    var code = $("#yzm").val();

    if (bank == "" || bank == "帐号") {
        alert("请输入账号");
        return false;
    }

    if (password == "" || password == "请输入密码") {
        alert("请输入密码");
        return false;
    }

    if (code == "" || code == "验证码") {
        alert("请输入验证码");
        return false;
    } else {
        //验证验证码是否正确
        $.ajax({
            url: "Persional/ValidCode.ashx",
            type: "get",
            data: { code: code },
            success: function (msg) {
                if (msg != "1") {
                    alert(msg);
                    //更新验证码
                    $("#codeimg").attr("src", "VerifyCode.aspx?v=login&'+Math.random();");
                    return false;
                } else {
                    submitform(); //验证通过，执行提交代码
                    return true;
                }
            }
        });
    }
}
