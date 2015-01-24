<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ChengJiEdit2_ZheJiang.aspx.cs"
    Inherits="GaoKao.Persional.ChengJiEdit2_ZheJiang" %>

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
            $("#ddlKeLei").find("option[value='" + kelei + "']").attr("selected", true);
            if (kelei != "-1") {
                $("#ddlKeLei").attr("disabled", "disabled");
            }

            //总分二 总分一
            $(".text_1").blur(function () {
                var yuwen = $("#txtYuWen").val(); //语文 
                var shuxue = $("#txtShuXue").val(); //数学 
                var yingyu = $("#txtYingYu").val(); //英语 
                var zonghe = $("#txtZongHe").val(); //综合 
                var zixuan = $("#txtZiXuan").val(); //自选 
                var jishu = $("#txtJiShu").val(); //技术
                if (yuwen * 1 >= 0 && shuxue * 1 >= 0 && yingyu * 1 >= 0) {
                    if (zonghe * 1 > 0) {
                        var zf2 = yuwen * 1 + shuxue * 1 + yingyu * 1 + zonghe * 1;
                        $("#lbZongFen2").text(zf2); //总分2
                        $("#hidZongFen2").val(zf2); 
                        if (zixuan * 1 > 0) {
                            var zf1 = yuwen * 1 + shuxue * 1 + yingyu * 1 + zonghe * 1 + zixuan * 1;
                            $("#lbZongFen1").text(zf1); //总分1
                            $("#hidZongFen1").val(zf1);
                        }
                    }
                    if (jishu * 1 > 0) {
                        var zf3 = yuwen * 1 + shuxue * 1 + yingyu * 1 + jishu * 1;
                        $("#lbZongFen3").text(zf3); //总分3
                        $("#hidZongFen3").val(zf3);
                    }
                }
            });
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <gk:Schoolbanner ID="SchoolBanner1" runat="server" />
    <gk:Crumb ID="Crumb1" runat="server" />
    <div class="content" style="background: #fff;">
        <asp:HiddenField ID="hidZongFen1" runat="server" />
        <asp:HiddenField ID="hidZongFen2" runat="server" />
        <asp:HiddenField ID="hidZongFen3" runat="server" />
        <div class="contentbody">
            <gk:UserCenterLeft ID="UserCenterLeft1" runat="server" />
            <div class="xiugaiR">
                <asp:HiddenField ID="hidKeLei" runat="server" />
                <div class="xiugaiRtit" style="border-bottom: 0;">
                    用户成绩设定</div>
                <div class="sdul">
                    <ul>
                        <li><a href="ChengJiEdit.aspx">用户成绩</a></li>
                        <li class="cur"><a href="ChengJiEdit2.aspx">修改平时成绩</a></li>
                        <li><a href="ChengJiEdit3.aspx">设置高考成绩</a></li>
                    </ul>
                </div>
                <div class="sdbox">
                    <div class="dsa">
                        <table width="270" height="173" cellspacing="1" class="tatata" style="float: left">
                            <tbody>
                                <tr>
                                    <td width="50" align="right">
                                        科类：
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddlKeLei" runat="server" Style="width: 205px; color: #393939; background-color:#B9B9B9;"
                                            class="text_1">
                                            <asp:ListItem Value="1">文史</asp:ListItem>
                                            <asp:ListItem Value="5">理工</asp:ListItem>
                                            <asp:ListItem Value="-1">不分科</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        语文：
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtYuWen" runat="server" class="text_1"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        数学：
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtShuXue" runat="server" class="text_1"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        外语：
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtYingYu" runat="server" class="text_1"></asp:TextBox>
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                        <table width="357" height="135" cellspacing="1" style="float: right; margin-top: 41px;">
                            <tbody>
                                <tr>
                                    <td align="right">
                                        综合：
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtZongHe" runat="server" class="text_1"></asp:TextBox>
                                    </td>
                                    <td style="font-size: 13px; color: #7c7c7c">
                                        I/II必选
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        自选模块:
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtZiXuan" runat="server" class="text_1"></asp:TextBox>
                                    </td>
                                    <td style="font-size: 13px; color: #7c7c7c">
                                        I类必填
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        技术:
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtJiShu" runat="server" class="text_1"></asp:TextBox>
                                    </td>
                                    <td style="font-size: 13px; color: #7c7c7c">
                                        III类必填
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </div>
                    <div class="liebiao" style="clear: both">
                        <ul>
                            <li><em>总分1:</em><asp:Label ID="lbZongFen1" runat="server"></asp:Label></li>
                            <li><em>总分2:</em><asp:Label ID="lbZongFen2" runat="server"></asp:Label></li>
                            <li><em>总分3:</em><asp:Label ID="lbZongFen3" runat="server"></asp:Label></li>
                        </ul>
                    </div>
                    <div class="dasd">
                        <asp:Button ID="Button1" runat="server" Text="修改成绩" OnClick="Button1_Click" class="sdbtn"
                            Style="color: #fff; font-size: 18px; cursor: pointer;" />
                    </div>
                </div>
            </div>
        </div>
    </div>
    <gk:Footer ID="Footer1" runat="server" />
    </form>
</body>
</html>
