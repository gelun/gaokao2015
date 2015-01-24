<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DingDan.aspx.cs" Inherits="GaoKao.Art.GouMai.DingDan" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>填写订单-高考志愿填报智能模拟系统-报考卡在线购买 </title>
    <link href="/css/style.css" rel="stylesheet" type="text/css" />
    <link href="/css/style_gouka.css" rel="stylesheet" type="text/css" />
    <script src="/js/jquery.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {
            function submit() {
                var name = $.trim($(".t1:eq(0)").val());
                var mobile = $.trim($(".t1:eq(1)").val());
                var province = $(".t1:eq(2) option[selected]").text();
                if (name == "") {
                    alert("请填写姓名");
                    return false;
                }
                if (mobile == "") {
                    alert("手机号码不能为空");
                    return false;
                } else {
                    var ref = /^1[3|5|8][0-9]\d{8}$/;
                    if (ref.test(mobile) == false) {
                        alert("手机号码格式不正确");
                        return false;
                    }
                }
                $.ajax({
                    url: "/Art/baoming.ashx",
                    type: "get",
                    dataType: "html",
                    data: { name: name, mobile: mobile, province: province },
                    success: function (data) {
                        if (data == "ok") {
                            alert("提交成功");
                            window.location.href = "http://gaokao.gelunjiaoyu.com/art/goumai/index.aspx";
                        } else {
                            alert("提交失败");
                            return false;
                        }
                    }
                });
            }
            //初次加载页面时，需要计算总价格
            //商品单价
            var danjia = $("#lblDanJia").text();
            //总金额
            var counts = $("#txtCount").val();
            var total = (Number(counts * danjia)).toFixed(2);

            $("#lblTotalJinE1").text(total);
            $("#lblTotalJinE2").text(total);


            //购卡数量增加或减少，或者手动去更改购卡数量的时候，需要更新商品总金额

            //购买卡的数量的增减
            //1.增加购买卡的数量
            $("#btnPlus").click(function () {
                var CardCount = $("#txtCount").val();
                if (CardCount < 5) {
                    $("#txtCount").val(((CardCount * 1) + 1));

                    //商品数量
                    var counts = $("#txtCount").val();
                    //总金额
                    var total = (Number(counts * danjia)).toFixed(2);
                    $("#lblTotalJinE1").text(total);
                    $("#lblTotalJinE2").text(total);
                } else {
                    alert("超出了最大购买量");
                }
            });
            //2.减少购买卡的数量
            $("#btnMinus").click(function () {
                var CardCount = $("#txtCount").val();
                if (CardCount <= 1) {
                    alert("目前已经是只有1张了，不能再减少了");
                } else {
                    $("#txtCount").val(((CardCount * 1) - 1));

                    //商品数量
                    var counts = $("#txtCount").val();
                    //总金额
                    var total = (Number(counts * danjia)).toFixed(2);
                    $("#lblTotalJinE1").text(total);
                    $("#lblTotalJinE2").text(total);
                }
            });

            //如果是直接操作卡的数量，手动填写的话，需要判断填写的值的格式
            $("#txtCount").keyup(function () {
                var CardCount = $(this).val();
                if (CardCount == "") {
                    $("#lblTotalJinE1").text("0.00");
                    $("#lblTotalJinE2").text("0.00");
                    $("#txtCount").blur(function () {
                        var CardCount = $("#txtCount").val();
                        if (CardCount == "") {
                            alert("购卡数量必须大于0");
                            $("#txtCount").val(1);
                            //商品数量
                            var counts = $(this).val();
                            //总金额
                            var total = (Number(counts * danjia)).toFixed(2);
                            $("#lblTotalJinE1").text(total);
                            $("#lblTotalJinE2").text(total);
                        }
                    });
                }
                else {
                    var reg = new RegExp("^[1-9]\\d*$");
                    //验证填写的值是否符合要求
                    if (reg.test(CardCount) == false) {
                        alert("购卡数量必须为大于0的阿拉伯数字");
                        $("#txtCount").val(1);
                        //商品数量
                        var counts = $(this).val();
                        //总金额
                        var total = (Number(counts * danjia)).toFixed(2);
                        $("#lblTotalJinE1").text(total);
                        $("#lblTotalJinE2").text(total);

                    } else {

                        //商品数量
                        var counts = $(this).val();
                        //总金额
                        var total = (Number(counts * danjia)).toFixed(2);
                        $("#lblTotalJinE1").text(total);
                        $("#lblTotalJinE2").text(total);
                    }
                }
            });

        });

    </script>
</head>
<body>
    <form id="form1" runat="server">
    <gk:Schoolbanner ID="SchoolBanner1" runat="server" BannerWord="格伦高考报考" />
    <gk:Crumb ID="Crumb1" runat="server" NavString=" <span>&gt;</span> <a href='gouka.aspx'>购买高考卡</a> <span>&gt;</span> 订单" />
    <div style=" border-bottom:1px solid #c8c8c8; width:100%;">
    <div class="xgys" >
        <div class="h2">
            填写订单</div>
        <div class="txtd">
            <img src="/images/gk/dd1.jpg"></div>
        <div class="shengfen">
            <asp:HiddenField ID="hiddProvinceName" runat="server" />
            使用省份：河北、河南、山东、山西</div>
        <div class="xx">
            填写联系信息<span> 请正确填写，如购买或激活报考卡有任何问题，您可能需要提供以下信息进行核对</span></div>
        <div class="bg">
            <div class="lianxiren">
                <b>*</b> <em>联系人姓名</em>:
                <asp:TextBox ID="txtCellName" runat="server" class="t1"></asp:TextBox>
            </div>
            <div class="lianxiren">
                &nbsp;&nbsp;<b>*</b> <em>联系手机</em>:
                <asp:TextBox ID="txtCellMobile" runat="server" class="t2"></asp:TextBox><span>&nbsp;&nbsp;付款后，您购买的报考卡"卡号、密码"会发送至该联系手机</span></div>
        </div>
        <div class="hedui">
            <div class="hedui_cen">
                <div class="hd">
                    核对订单详情</div>
                <div class="mingcheng">
                    <table width="1094" height="170" class="tabb">
                        <tr class="tr1">
                            <td width="173" class="tdd1">
                                名称
                            </td>
                            <td width="173" class="tdd2">
                                面值
                            </td>
                            <td width="173" class="tdd2">
                                数量
                            </td>
                            <td width="173" class="tdd3">
                                小计
                            </td>
                        </tr>
                        <tr class="tr2">
                            <td class="tdd1">
                                格伦高考报考网—"报考卡"
                            </td>
                            <td class="tdd2">
                                ¥
                                <asp:Label ID="lblDanJia" runat="server" Text="4600"></asp:Label>
                            </td>
                            <td>
                                <div class="mum">
                                    <div class="w1" id="btnMinus">
                                        <a href="javascript:void(0);" title="">-</a></div>
                                    <asp:TextBox ID="txtCount" runat="server" Text="1" CssClass="w2" style=" height:26px; padding:0 6px; line-height:26px"></asp:TextBox>
                                    <div class="w1" id="btnPlus">
                                        <a href="javascript:void(0);" title="">+</a></div>
                                </div>
                            </td>
                            <td class="tdd3">
                                ¥
                                <asp:Label ID="lblTotalJinE1" runat="server" Style="font-weight: normal; color: #393939;
                                    font-size: 14px;"></asp:Label>
                            </td>
                        </tr>
                        <tr class="tr3">
                            <td colspan="4" class="tdd3">
                                订单总额：<span>¥
                                    <asp:Label ID="lblTotalJinE2" runat="server"></asp:Label></span>
                            </td>
                        </tr>
                    </table>
                </div>
                <div class="sheet pay">
                    <dl class="cf">
                        <h2>
                            选择付款方式</h2>
                        <dt class="dt1"><span>*</span> 付款方式</dt>
                        <dd id="J-tabs-payway">
                            <label class="s1">
                                <span>
                                    <asp:RadioButton ID="rbtZhiFuBao" runat="server" GroupName="zhifu" /></span><img alt="支付宝"
                                        src="/images/zfb.jpg" height="40" width="92"></label>
                            <label class="s2">
                                <span>
                                    <asp:RadioButton ID="rbtYinLian" runat="server" GroupName="zhifu" /></span><img alt="银联" src="/images/yl.jpg"
                                        height="40" width="92"></label>
                        </dd>
                    </dl>
                </div>
                <div class="Ljgm">
                    <asp:ImageButton ID="imgSave" runat="server" ImageUrl="/images/ljgm.gif" Width="153"
                        Height="43" OnClick="imgSave_Click" />
                </div>
            </div>
        </div>
    </div>
    </div>
    <gk:Footer ID="Footer1" runat="server" />
    </form>
</body>
</html>
