document.onkeydown = function (event) {
    e = event ? event : (window.event ? window.event : null);
    if (e.keyCode == 13) {
        //按下回车键  执行的方法 
        Reg();
    }
}

$(function () {
    //加载页面时，重置一次验证码
    $("#codeimg").attr("src", "VerifyCode.aspx");
    $(".regbtn").click(function () {
        Reg();
    });
});

function Reg() {
    var bank = $("#txt1").val();
    var pwd = $("#pawd").val();
    var repwd = $("#repawd").val();
    var code = $("#yzm").val();

    if (bank == "" || bank == "帐号") {
        alert("请输入账号");
        return false;
    }

    if (pwd == "" || pwd == "密码") {
        alert("请输入密码");
        return false;
    }
    if (repwd == "" || repwd == "确认密码") {
        alert("请再次输入密码");
        return false;
    }

    if (pwd != repwd) {
        alert("两次输入的密码不一致");
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
                    save(bank, pwd); //验证通过，执行提交代码
                    return true;
                }
            }
        });
    }
}

function save(bank, password) {
    $.ajax({
        url: "Persional/register.ashx",
        type: "post",
        data: { bank: bank, password: password },
        success: function (data) {
            alert(data);
            if (data == "注册成功") {
                location.href = "login.aspx";
            }
        }
    });
}