<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Art.aspx.cs" Inherits="GaoKao.Art.GouMai.Art" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="yikaocss/style.css" rel="stylesheet" type="text/css" />
    <link href="yikaocss/gouka.css" rel="stylesheet" type="text/css" />
    <script src="yikaojs/jquery1.js" type="text/javascript"></script>
    <script src="yikaojs/ProJson.js" type="text/javascript"></script>
    <script src="yikaojs/DistrictJson.js" type="text/javascript"></script>
    <script src="yikaojs/CityJson.js" type="text/javascript"></script>
    <script src="yikaojs/TypeJson.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {
            $.each(province, function (k, p) {
                var option = "<option value='" + p.ProvinceID + "'>" + p.ProvinceName + "</option>";
                $("#ddl_sheng").append(option);
            });

            $("#ddlYKType").change(function () {

                $("#HidYKZYTypeId").val("");
                $("#HidYKZYType").val("");

                var selValue = $(this).val();
                $("#ddlZhuaYeType option:gt(0)").remove();
                $.each(Type, function (k, p) {
                    if (p.TypePId == selValue) {
                        var option = "<option value='" + p.TypeId + "'>" + p.TypeName + "</option>";
                        $("#ddlZhuaYeType").append(option);
                    }
                });
            });

            $("#ddlZhuaYeType").change(function () {

                $("#HidYKZYTypeId").val($(this).val());
                $("#HidYKZYType").val($("#ddlZhuaYeType option[value='" + $(this).val() + "']").text());
            });

            $("#ddl_sheng").change(function () {

                $("#hidProvince").val($(this).val());
                $("#hidProvinceName").val($("#ddl_sheng option[value='" + $(this).val() + "']").text());
                $("#hidCity").val("");
                $("#hidCityName").val("");
                $("#hidCounty").val("");
                $("#hidCountyName").val("");

                var selValue = $(this).val();
                $("#ddl_shi option:gt(0)").remove();
                $("#ddl_xianqu option:gt(0)").remove();
                $.each(city, function (k, p) {
                    if (p.ProvinceID == selValue) {
                        var option = "<option value='" + p.CityID + "'>" + p.CityName + "</option>";
                        $("#ddl_shi").append(option);
                    }
                });
            });
            $("#ddl_shi").change(function () {
                $("#hidCity").val($(this).val());
                $("#hidCityName").val($("#ddl_shi option[value='" + $(this).val() + "']").text());

                $("#hidCounty").val("");
                $("#hidCountyName").val("");

                var selValue = $(this).val();
                $("#ddl_xianqu option:gt(0)").remove();
                $.each(District, function (k, p) {
                    if (p.CityID == selValue) {
                        var option = "<option value='" + p.DistrictId + "'>" + p.DistrictName + "</option>";
                        $("#ddl_xianqu").append(option);
                    }
                });
            });
            $("#ddl_xianqu").change(function () {
                $("#hidCounty").val($(this).val());
                $("#hidCountyName").val($("#ddl_xianqu option[value='" + $(this).val() + "']").text());
            });
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <gk:Schoolbanner ID="SchoolBanner1" runat="server" BannerWord="格伦高考报考" />
    <gk:Crumb ID="Crumb1" runat="server" NavString=" <span>&gt;</span> <a href='/art/goumai/index.aspx'>格伦艺术高考VIP卡</a>" />
    <div style="border-bottom: 1px solid #c8c8c8; width: 100%;">
    </div>
    <div class="bt_t">
        艺考信息采集表</div>
    <div class="biaoge">
        <table width="431" height="553" class="biaogg" cellspacing="1" style="float: left">
            <tr>
                <td align="right">
                    姓名：
                </td>
                <td>
                    <asp:TextBox ID="tbName" runat="server" class="t15"></asp:TextBox><span style="color: Red">*</span>
                </td>
            </tr>
            <tr>
                <td align="right">
                    性别：
                </td>
                <td>
                    <asp:DropDownList ID="ddlSex" class="t155" runat="server">
                        <asp:ListItem Value="0">男</asp:ListItem>
                        <asp:ListItem Value="1">女</asp:ListItem>
                    </asp:DropDownList>
                    <span style="color: Red">*</span>
                </td>
            </tr>
            <tr>
                <td align="right">
                    出生年月：
                </td>
                <td>
                    <asp:TextBox ID="tbChuSheng" runat="server" class="t15"></asp:TextBox><span style="color: Red">*</span>
                </td>
            </tr>
            <tr>
                <td align="right">
                    毕业学校：
                </td>
                <td>
                    <asp:TextBox ID="tbBiYeXueXiao" runat="server" class="t15"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="right">
                    学生QQ：
                </td>
                <td>
                    <asp:TextBox ID="tbQq" runat="server" class="t15"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="right">
                    加分认可范围：
                </td>
                <td>
                    <asp:DropDownList ID="ddlJFRKFW" class="t16" runat="server">
                        <asp:ListItem Value="0">省内</asp:ListItem>
                        <asp:ListItem Value="1">省外</asp:ListItem>
                    </asp:DropDownList>
                    分值：
                    <asp:TextBox ID="tbFenZhi" runat="server" class="t18" Style="width: 95px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="right">
                    体验专业受限情况：
                </td>
                <td>
                    <asp:TextBox ID="tbTiJian" runat="server" class="t15"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="right">
                    艺考类型：
                </td>
                <td>
                    <asp:HiddenField ID="HidYKZYTypeId" runat="server" />
                    <asp:HiddenField ID="HidYKZYType" runat="server" />
                    <asp:DropDownList ID="ddlYKType" class="t17" runat="server">
                        <asp:ListItem Value="0">请选择省份</asp:ListItem>
                        <asp:ListItem Value="3">河北省</asp:ListItem>
                        <asp:ListItem Value="15">河南省</asp:ListItem>
                        <asp:ListItem Value="4">山西省</asp:ListItem>
                        <asp:ListItem Value="16">山东省</asp:ListItem>
                    </asp:DropDownList>
                    <asp:DropDownList ID="ddlZhuaYeType" class="t17" Width="152px" runat="server">
                        <asp:ListItem Value="0">请选择艺术</asp:ListItem>
                    </asp:DropDownList>
                    <span style="color: Red">*</span>
                </td>
            </tr>
            <tr>
                <td align="right">
                    意向地区：
                </td>
                <td>
                    <asp:TextBox ID="tbYXDQ" runat="server" class="t15"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="right">
                    院校类别：
                </td>
                <td>
                    <asp:DropDownList ID="ddlYuanXiaoType" class="t155" runat="server">
                        <asp:ListItem Value="0">31所独立设置本科</asp:ListItem>
                        <asp:ListItem Value="1">13所参照设置本科</asp:ListItem>
                        <asp:ListItem Value="2">其他校考院校</asp:ListItem>
                        <asp:ListItem Value="3">其他联考成绩</asp:ListItem>
                    </asp:DropDownList>
                    <span style="color: Red">*</span>
                </td>
            </tr>
            <tr>
                <td align="right">
                    联考成绩：
                </td>
                <td>
                    <asp:TextBox ID="tbLianKaoChengJi" runat="server" class="t15"></asp:TextBox>
                </td>
            </tr>
        </table>
        <table width="431" height="553" class="biaogg" cellspacing="1" style="float: left;
            margin-left: 131px;">
            <tr>
                <td align="right">
                    生源地：
                </td>
                <td>
                    <asp:DropDownList ID="ddl_sheng" runat="server" class="t18" placeholder="学校所在省份">
                        <asp:ListItem Value="0" Text="请选择省份"></asp:ListItem>
                    </asp:DropDownList>
                    <asp:DropDownList ID="ddl_shi" runat="server" placeholder="学校所在城市" class="t18">
                        <asp:ListItem Value="0" Text="请选择城市"></asp:ListItem>
                    </asp:DropDownList>
                    <asp:DropDownList ID="ddl_xianqu" runat="server" placeholder="学校所在县区" class="t18">
                        <asp:ListItem Value="0" Text="请选择县区"></asp:ListItem>
                    </asp:DropDownList>
                    <span style="color: Red">*</span>
                    <asp:HiddenField ID="hidProvince" runat="server" />
                    <asp:HiddenField ID="hidCity" runat="server" />
                    <asp:HiddenField ID="hidCounty" runat="server" />
                    <asp:HiddenField ID="hidProvinceName" runat="server" />
                    <asp:HiddenField ID="hidCityName" runat="server" />
                    <asp:HiddenField ID="hidCountyName" runat="server" />
                </td>
            </tr>
            <tr>
                <td align="right">
                    联系电话(考生):
                </td>
                <td>
                    <asp:TextBox ID="tbKaoShengPhone" runat="server" class="t15"></asp:TextBox><span
                        style="color: Red">*</span>
                </td>
            </tr>
            <tr>
                <td align="right">
                    联系电话(家长):
                </td>
                <td>
                    <asp:TextBox ID="tbJiaZhangPhone" runat="server" class="t15"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="right">
                    E-mail：
                </td>
                <td>
                    <asp:TextBox ID="tbEmail" runat="server" class="t15"></asp:TextBox><span style="color: Red">*</span>
                </td>
            </tr>
            <tr>
                <td align="right">
                    报考类别：
                </td>
                <td>
                    <asp:DropDownList ID="ddlBaoKaoType" class="t155" runat="server">
                        <asp:ListItem Value="0">艺术文</asp:ListItem>
                        <asp:ListItem Value="1">艺术理</asp:ListItem>
                    </asp:DropDownList>
                    <span style="color: Red">*</span>
                </td>
            </tr>
            <tr>
                <td align="right">
                    是否兼报文理：
                </td>
                <td>
                    <asp:DropDownList ID="ddlIsJianBao" class="t155" runat="server">
                        <asp:ListItem Value="1">是</asp:ListItem>
                        <asp:ListItem Value="0">否</asp:ListItem>
                    </asp:DropDownList>
                    <span style="color: Red">*</span>
                </td>
            </tr>
            <tr>
                <td align="right">
                    个人成绩优势：
                </td>
                <td>
                    <asp:DropDownList ID="ddlChengJiYS" class="t155" runat="server">
                        <asp:ListItem Value="0">文化课优势</asp:ListItem>
                        <asp:ListItem Value="1">专业优势</asp:ListItem>
                        <asp:ListItem Value="2">专业文化均衡</asp:ListItem>
                    </asp:DropDownList>
                    <span style="color: Red">*</span>
                </td>
            </tr>
            <tr>
                <td align="right">
                    考生类别：
                </td>
                <td>
                    <asp:DropDownList ID="ddlKaoShengType" class="t155" runat="server">
                        <asp:ListItem Value="0">应届</asp:ListItem>
                        <asp:ListItem Value="1">往届</asp:ListItem>
                    </asp:DropDownList>
                    <span style="color: Red">*</span>
                </td>
            </tr>
            <tr>
                <td align="right">
                    意向专业：
                </td>
                <td>
                    <asp:TextBox ID="tbYXZhuanYe" runat="server" class="t15"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="right">
                    意向院校：
                </td>
                <td>
                    <asp:TextBox ID="tbYXYuanXiao" runat="server" class="t15" placeholder="可填写多个院校"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="right">
                    办学类型：
                </td>
                <td>
                    <asp:DropDownList ID="ddlBanXueType" class="t155" runat="server">
                        <asp:ListItem Value="0">公办</asp:ListItem>
                        <asp:ListItem Value="1">民办</asp:ListItem>
                        <asp:ListItem Value="2">独立院校</asp:ListItem>
                        <asp:ListItem Value="3">专科</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
        </table>
        <table width="991" cellspacing="1" style="clear: both; margin: 0 auto; color: #444444;
            font-size: 16px">
            <tr>
                <td align="right" width="145" style="padding-bottom: 140px;">
                    校考情况：
                </td>
                <td>
                    <textarea name="txtXiaoKao" placeholder="请填写校考院校及成绩" style="height: 143px; width: 825px;
                        border: 1px solid #bfbfbf; color: #999999; font-size: 12px;"></textarea>
                </td>
            </tr>
            <tr height="30">
            </tr>
            <tr>
                <td align="right" style="padding-bottom: 140px;">
                    其他特殊报考说明：
                </td>
                <td>
                    <textarea name="txtMeto" style="height: 143px; width: 825px; border: 1px solid #bfbfbf;"></textarea>
                </td>
            </tr>
        </table>
        <table width="1050" cellspacing="1" class="tadd">
            <tr>
                <td width="170" align="right">
                    预估成绩：
                </td>
                <td>
                    语文&nbsp;&nbsp;
                    <asp:TextBox ID="tbYGYuWen" runat="server" class="y11" />
                </td>
                <td>
                    数学 &nbsp;&nbsp;<asp:TextBox ID="tbYGShuXue" runat="server" class="y11" />
                </td>
                <td>
                    英语&nbsp;&nbsp;
                    <asp:TextBox ID="tbYGYingYu" runat="server" class="y11" />
                </td>
                <td>
                    文(理)综 &nbsp;&nbsp;<asp:TextBox ID="tbYGZongHe" runat="server" class="y11" />
                    总 分&nbsp;&nbsp;
                    <asp:TextBox ID="tbYGZongFen" runat="server" class="y11" />
                </td>
            </tr>
            <tr>
                <td style="text-align: right;">
                    高考成绩：<br />
                    (出分后填写)
                </td>
                <td>
                    语文&nbsp;&nbsp;
                    <asp:TextBox ID="tbGKYuWen" runat="server" class="y11" />
                </td>
                <td>
                    数学&nbsp;&nbsp;
                    <asp:TextBox ID="tbGKShuXue" runat="server" class="y11" />
                </td>
                <td>
                    英语 &nbsp;&nbsp;<asp:TextBox ID="tbGKuYingYu" runat="server" class="y11" />
                </td>
                <td>
                    文(理)综 &nbsp;&nbsp;<asp:TextBox ID="tbGKZongHe" runat="server" class="y11" />
                    总 分&nbsp;&nbsp;
                    <asp:TextBox ID="tbGKZongFen" runat="server" class="y11" />
                </td>
            </tr>
        </table>
        <div style="text-align: center">
            <asp:Button ID="btnGoTo" class="anniu_11" runat="server" Text="提交" OnClick="btnGoTo_Click" />
        </div>
    </div>
    <div style="width: 100%; border-bottom: 1px solid #c8c8c8">
    </div>
    <gk:Footer ID="Footer1" runat="server" />
    </form>
</body>
</html>
