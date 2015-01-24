<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DingDan.aspx.cs" Inherits="GaoKao.GaoKaoCard.DingDan" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>填写订单-高考志愿填报智能模拟系统-报考卡在线购买 </title>
    <link href="/css/style.css" rel="stylesheet" type="text/css" />
    <link href="/css/style_gouka.css" rel="stylesheet" type="text/css" />
    <script src="/js/jquery.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {

            //初次加载页面时，需要计算总价格
            getDJQ();

            //购卡数量增加或减少，或者手动去更改购卡数量的时候，需要更新商品总金额

            //购买卡的数量的增减
            //1.增加购买卡的数量
            $("#btnPlus").click(function () {
                var CardCount = $("#txtCount").val();
                if (CardCount < 5) {
                    $("#txtCount").val(((CardCount * 1) + 1));
                    getDJQ();
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
                    getDJQ();
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
                            getDJQ();
                        }
                    });
                }
                else {
                    var reg = new RegExp("^[1-9]\\d*$");
                    //验证填写的值是否符合要求
                    if (reg.test(CardCount) == false) {
                        alert("购卡数量必须为大于0的阿拉伯数字");
                        $("#txtCount").val(1);
                        getDJQ();
                    } else {
                        getDJQ();
                    }
                }
            });
            //输入代金券
            $(".tete").keyup(function () {
                getDJQ();
            });
            $(".tete").mousedown(function () {
                getDJQ();
            });
            function getDJQ() {
                var bm = $(".tete").val();
                $.ajax({
                    url: $("#form1").attr("action"),    // 提交的页面
                    data: { ty: "djq", bm: bm },       // 从表单中获取数据
                    type: "GET",                        // 设置请求类型为"GET"，默认为"GET"
                    success: function (data) {
                        if (data == "yes") {
                            //验证通过
                            var _danjia = $("#lblDanJia").text();
                            var _counts = $("#txtCount").val();
                            var _totle1 = (Number(_counts * _danjia)).toFixed(2);
                            var _totle2 = (Number(_counts * _danjia - 30)).toFixed(2);
                            $("#lblTotalJinE1").text(_totle1);
                            $("#lblTotalJinE2").text(_totle2);
                            $(".tete").next().text("-¥30.00");
                        } else {
                            //
                            var _danjia = $("#lblDanJia").text();
                            var _counts = $("#txtCount").val();
                            var _totle = (Number(_counts * _danjia)).toFixed(2);
                            $("#lblTotalJinE1").text(_totle);
                            $("#lblTotalJinE2").text(_totle);
                            $(".tete").next().text("-¥0.00");
                        }
                    }
                });
            }
        });

    </script>
    <style type="text/css">
        .xianshi
        {
            height: 124px;
            width: 125px;
            border: 1px solid #dddddd;
            position: absolute;
            top: 46px;
            z-index: 999;
            background: #fff;
            text-align: center;
            padding-top: 10px;
        }
        .z1
        {
            display: block;
            position: absolute;
            left: 52px;
            top: -50px;
            width: 0;
            height: 0;
            border-style: solid;
            border-width: 10px;
            border-color: transparent transparent #dddddd transparent;
        }
        .z2
        {
            display: block;
            position: absolute;
            left: 53px;
            top: -18px;
            width: 0;
            height: 0;
            border-style: solid;
            border-width: 9px;
            border-color: transparent transparent #fff transparent;
        }
        .sda
        {
            font-size: 14px;
            color: #595959;
            margin-right: 15px;
        }
        .tete
        {
            height: 29px;
            width: 142px;
            border: 1px solid #dddddd;
            margin: 0 10px;
        }
        
        .hddh
        {
            height: 18px;
            color: #ff7900;
            font-size: 14px;
            padding-top: 11px;
            margin-left: 25px;
            position: relative;
        }
        
        .hddh .yn2
        {
            float: left;
            background: url(/images/jia.jpg) no-repeat left center;
            padding-left: 30px;
            cursor: pointer;
            height: 22px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <gk:Schoolbanner ID="SchoolBanner1" runat="server" BannerWord="格伦高考报考" />
    <gk:Crumb ID="Crumb1" runat="server" NavString=" <span>&gt;</span> <a href='gouka.aspx'>购买高考卡</a> <span>&gt;</span> 订单" />
    <div style="border-bottom: 1px solid #c8c8c8; width: 100%;">
        <div class="xgys">
            <div class="h2">
                填写订单</div>
            <div class="txtd">
                <img src="/images/dd1.jpg"></div>
            <div class="shengfen">
                <asp:HiddenField ID="hiddProvinceName" runat="server" />
                使用省份：除江苏、浙江外所有省份</div>
            <div class="xx">
                填写联系信息<span> 请正确填写，如购买或激活报考卡有任何问题，您可能需要提供以下信息进行核对</span></div>
            <div class="bg">
                <div class="lianxiren">
                    <b>*</b> <em>联系人姓名</em>:
                    <asp:TextBox ID="txtCellName" runat="server" class="t1"></asp:TextBox>
                </div>
                <div class="lianxiren">
                    &nbsp;&nbsp;<b>*</b> <em>联系手机</em>:
                    <asp:TextBox ID="txtCellMobile" runat="server" class="t2"></asp:TextBox><span>&nbsp;付款后，您购买的报考卡"卡号、密码"会发送至该联系手机</span></div>
            </div>
            <div class="hedui">
                <div class="hedui_cen">
                    <div class="hd">
                        核对订单详情</div>
                    <script type="text/javascript">
                        $(function () {
                            //获取代金券
                            $("#yn2").click(function () {
                                $("#xianshi").toggle();
                                return false;
                            })
                            $(document).click(function () {
                                $("#xianshi").hide();
                            });
                        })
                    </script>
                    <div class="hddh">
                        <div class="yn2" id="yn2">
                            获取代金券</div>
                        <div class="xianshi" id="xianshi" style="display: none">
                            <div class="jiantou1">
                                <div class="z1">
                                </div>
                                <div class="z2">
                                </div>
                            </div>
                            <dl>
                                <dt>
                                    <img src="/images/yangshi.jpg"></dt>
                                <dd style="color: #393939">
                                    高考报考微信</dd>
                            </dl>
                        </div>
                    </div>
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
                                    <asp:Label ID="lblDanJia" runat="server" Text="288"></asp:Label>
                                </td>
                                <td>
                                    <div class="mum">
                                        <div class="w1" id="btnMinus">
                                            <a href="javascript:void(0);" title="">-</a></div>
                                        <asp:TextBox ID="txtCount" runat="server" Text="1" CssClass="w2" Style="height: 26px;
                                            padding: 0 6px; line-height: 26px"></asp:TextBox>
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
                            <tr class="tr3" id="daijq">
                                <td colspan="4" class="tdd4" style="text-align: right; line-height: 40px;">
                                    <div class="sda">
                                        <input type="checkbox" checked="checked" style="margin: 0 2px 0 0; display:none;" />
                                        <span>使用高考报考30元代金券</span>
                                        <asp:TextBox ID="txtDaiJinQuan" runat="server" placeholder="请输入编码" class="tete" style="height: 26px; padding: 0 6px;
                                            line-height: 26px;"></asp:TextBox>
                                        <span style="font-size: 20px;">-¥0.00</span>
                                    </div>
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
                                        <asp:RadioButton ID="rbtZhiFuBao" runat="server" GroupName="zhifu" /></span><img
                                            alt="支付宝" src="/images/zfb.jpg" height="40" width="92"></label>
                                <label class="s2">
                                    <span>
                                        <asp:RadioButton ID="rbtYinLian" runat="server" GroupName="zhifu" /></span><img alt="银联"
                                            src="/images/yl.jpg" height="40" width="92"></label>
                            </dd>
                        </dl>
                    </div>
                    <div class="Ljgm" style="padding:0;">
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
