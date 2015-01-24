<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GeRenXinXi.aspx.cs" Inherits="GaoKao.Persional.GeRenXinXi" %>

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
            var ProvinceId = "<%=ProvinceId %>";
            if (ProvinceId != "0") {
                //说明省份已经存在了
                $("#ddlProvince").attr("disabled", "disabled");
                getSelList("citylist", ProvinceId, "sel2", "城市");
            }

            //点击提交按钮式，对表单的必填数据进行验证 
            $(".tjbutton").click(function () {
                //省份验证
                var province = $("#ddlProvince").val();
                if (province == 0) {
                    alert("请选择省份");
                    return false;
                }

                //高考分科
                var kelei = $("input[name='kelei']:checked").val();
                if (kelei == undefined) {
                    alert("请选择高考分科");
                    return false;
                }
                //学生姓名
                var studentname = $.trim($("#txtTrueName").val());
                if (studentname == "") {
                    alert("请填写学生姓名");
                    return false;
                }
                //手机号码验证
                var mobile = $("#txtMobile").val(); //学生手机号码
                var fmobile = $("#txtFMobile").val(); //父亲手机号
                var mmobile = $("#txtMMobile").val(); //母亲手机号
                var bzrmobile=$("#txtBanZhuRenMobile").val();//班主任手机号码

                if (mobile == "" && fmobile == "" && mmobile == "") {
                    alert("学生手机号码、父亲手机号码和母亲手机号码至少填写一个");
                    return false;
                } else {
                    var mobilereg = /^1[0-9]{10}$/;
                    if (mobile != "" && !mobilereg.test(mobile)) {
                        alert("输入的学生手机号码格式不正确");
                        return false;
                    }
                    if (fmobile != "" && !mobilereg.test(fmobile)) {
                        alert("输入的父亲手机号码格式不正确");
                        return false;
                    }
                    if (mmobile != "" && !mobilereg.test(mmobile)) {
                        alert("输入的母亲手机号码格式不正确");
                        return false;
                    }
                    if (bzrmobile != "" && !mobilereg.test(bzrmobile)) {
                        alert("输入的班主任手机号码格式不正确");
                        return false;
                    }
                }

                //将select中选中的数据写入隐藏域
                $("#hidCityId").val($("#sel2").val());
                $("#hidCountyId").val($("#sel3").val());
                $("#hidKeLei").val(kelei);
            });


            //点击省份时，根据省份id加载对应的数据
            $("#ddlProvince").click(function () {
                var proid = $("#ddlProvince").val();
                getSelList("citylist", proid, "sel2", "城市");
            });
            //点击城市时，根据省份id加载对应的数据
            $("#sel2").click(function () {
                var proid = $("#sel2").val();
                if (proid != 0) {
                    getSelList("districtlist", proid, "sel3", "县/区");
                }
            });
        });

        function getSelList(ty, proid, id, mrz) {
            $.ajax({
                url: $("#form1").attr("action"),    // 提交的页面
                data: { ty: ty, proid: proid },       // 从表单中获取数据
                type: "GET",                        // 设置请求类型为"GET"，默认为"GET"
                beforeSend: function ()             // 设置表单提交前方法
                {
                    //提交前的动作
                },
                error: function (data, status, e) {
                    // 异常提示 
                },
                success: function (data) {
                    if (data != "") {
                        var obj = eval(data);
                        var optionHTML = "";

                        for (var i = 0; i < obj.length; i++) {
                            optionHTML += "<option  value=\"" + obj[i].id + "\">" + obj[i].name + "</option>\n";
                        }
                        optionHTML = "<option  value=\"0\">--" + mrz + "--</option>\n" + optionHTML;
                        $("#" + id + "").html(optionHTML);

                    } else {
                        var optionHTML = "<option  value=\"0\">--" + mrz + "--</option>";
                        $("#" + id + "").html(optionHTML);
                    }
                }
            });
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    
    <gk:Schoolbanner ID="SchoolBanner1" runat="server" />
    <gk:Crumb ID="Crumb1" runat="server" NavString=" <span>&gt;</span> 完善个人信息" />
    <div class="content" style="background: #fff;">
        <div class="contentbody" style="border-bottom: 2px solid #bfbfbf; padding-bottom: 20px;">
            <div class="grxxTit">
                报考信息</div>
            <asp:HiddenField ID="hidCityId" runat="server" />
            <asp:HiddenField ID="hidCountyId" runat="server" />
            <asp:HiddenField ID="hidKeLei" runat="server" />
            <div class="grxxtab">
                <span>所在地区：</span>
                <div class="grxxtabR">
                    <asp:DropDownList ID="ddlProvince" runat="server" class="selecttab" Width="100px">
                        <asp:ListItem Value="0">--省份--</asp:ListItem>
                        <asp:ListItem Value="1">北京市</asp:ListItem>
                        <asp:ListItem Value="2">天津市</asp:ListItem>
                        <asp:ListItem Value="3">河北省</asp:ListItem>
                        <asp:ListItem Value="4">山西省</asp:ListItem>
                        <asp:ListItem Value="5">内蒙古自治区</asp:ListItem>
                        <asp:ListItem Value="6">辽宁省</asp:ListItem>
                        <asp:ListItem Value="7">吉林省</asp:ListItem>
                        <asp:ListItem Value="8">黑龙江省</asp:ListItem>
                        <asp:ListItem Value="9">上海市</asp:ListItem>
                        <asp:ListItem Value="10">江苏省</asp:ListItem>
                        <asp:ListItem Value="11">浙江省</asp:ListItem>
                        <asp:ListItem Value="12">安徽省</asp:ListItem>
                        <asp:ListItem Value="13">福建省</asp:ListItem>
                        <asp:ListItem Value="14">江西省</asp:ListItem>
                        <asp:ListItem Value="15">山东省</asp:ListItem>
                        <asp:ListItem Value="16">河南省</asp:ListItem>
                        <asp:ListItem Value="17">湖北省</asp:ListItem>
                        <asp:ListItem Value="18">湖南省</asp:ListItem>
                        <asp:ListItem Value="19">广东省</asp:ListItem>
                        <asp:ListItem Value="20">广西壮族自治区</asp:ListItem>
                        <asp:ListItem Value="21">海南省</asp:ListItem>
                        <asp:ListItem Value="22">重庆市</asp:ListItem>
                        <asp:ListItem Value="23">四川省</asp:ListItem>
                        <asp:ListItem Value="24">贵州省</asp:ListItem>
                        <asp:ListItem Value="25">云南省</asp:ListItem>
                        <asp:ListItem Value="26">西藏自治区</asp:ListItem>
                        <asp:ListItem Value="27">陕西省</asp:ListItem>
                        <asp:ListItem Value="28">甘肃省</asp:ListItem>
                        <asp:ListItem Value="29">青海省</asp:ListItem>
                        <asp:ListItem Value="30">宁夏回族自治区</asp:ListItem>
                        <asp:ListItem Value="31">新疆维吾尔自治区</asp:ListItem>
                        <asp:ListItem Value="32">香港特别行政区</asp:ListItem>
                        <asp:ListItem Value="33">澳门特别行政区</asp:ListItem>
                        <asp:ListItem Value="34">台湾省</asp:ListItem>
                    </asp:DropDownList>
                    <select name="" class="selecttab" id="sel2">
                        <option value="0">--城市--</option>
                    </select>
                    <select name="" class="selecttab" id="sel3">
                        <option value="0">--县/区--</option>
                    </select>
                </div>
            </div>
            <div class="grxxtab">
                <span>高考分科：</span>
                <div class="grxxtabR">
                    <input type="radio" name="kelei" class="rad" value="5" /><strong>理工</strong>
                    <input type="radio" name="kelei" class="rad" value="1" /><strong>文史</strong>
                    <input type="radio" name="kelei" class="rad" value="-1" /><strong>未分科</strong>
                </div>
            </div>
            <div class="grxxtab">
                <span>高考时间：</span>
                <div class="grxxtabR">
                    <asp:DropDownList ID="ddlGKYear" runat="server" class="selecttab selsex" Style="width: 86px;">
                        <asp:ListItem Value="2015">2015年6月</asp:ListItem>
                        <asp:ListItem Value="2016">2016年6月</asp:ListItem>
                        <asp:ListItem Value="2017">2017年6月</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
            <div class="grxxTit">
                个人联系方式</div>
            <div class="grxxtab">
                <span>真实姓名：</span>
                <div class="grxxtabR">
                    <asp:TextBox ID="txtTrueName" runat="server" class="text1" MaxLength="6"></asp:TextBox>
                </div>
            </div>
            <div class="grxxtab">
                <span>性别：</span>
                <div class="grxxtabR">
                    <asp:DropDownList ID="ddlSex" runat="server" class="selecttab selsex">
                        <asp:ListItem Value="0">男</asp:ListItem>
                        <asp:ListItem Value="1">女</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
            <div class="grxxtab">
                <span>学生手机：</span>
                <div class="grxxtabR">
                    <asp:TextBox ID="txtMobile" runat="server" class="text1" MaxLength="11"></asp:TextBox>
                    <b>手机号码是参加讲座和活动的唯一凭证</b>
                </div>
            </div>
            <div class="grxxtab">
                <span>父亲手机：</span>
                <div class="grxxtabR">
                    <asp:TextBox ID="txtFMobile" runat="server" class="text1" MaxLength="11"></asp:TextBox>
                </div>
            </div>
            <div class="grxxtab">
                <span>母亲手机：</span>
                <div class="grxxtabR">
                    <asp:TextBox ID="txtMMobile" runat="server" class="text1" MaxLength="11"></asp:TextBox>
                </div>
            </div>
        </div>
        <div class="contentbody" style="padding-bottom: 10px;">
            <div class="grxxTit">
                就读学校信息</div>
            <div class="grxxtab">
                <span>就读中学：</span>
                <div class="grxxtabR">
                    <asp:TextBox ID="txtSchoolName" runat="server" class="text1" MaxLength="40"></asp:TextBox>
                </div>
            </div>
            <div class="grxxtab">
                <span>就读班级：</span>
                <div class="grxxtabR">
                    <asp:TextBox ID="txtBanJi" runat="server" class="text1" MaxLength="40"></asp:TextBox>
                </div>
            </div>
            <div class="grxxtab">
                <span>班主任姓名：</span>
                <div class="grxxtabR">
                    <asp:TextBox ID="txtBanZhuRen" runat="server" class="text1" MaxLength="6"></asp:TextBox>
                </div>
            </div>
            <div class="grxxtab">
                <span>班主任手机：</span>
                <div class="grxxtabR">
                    <asp:TextBox ID="txtBanZhuRenMobile" runat="server" class="text1" MaxLength="11"></asp:TextBox>
                </div>
            </div>
            <div class="grxxtab" style="padding-left: 300px; padding-top: 30px;">
                <asp:Button ID="goSave" runat="server" class="tjbutton" Text="提交" OnClick="goSave_Click" />
            </div>
        </div>
    </div>
    <gk:Footer ID="Footer1" runat="server" />
    </form>
</body>
</html>
