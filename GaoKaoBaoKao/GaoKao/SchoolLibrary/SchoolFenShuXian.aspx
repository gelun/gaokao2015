<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SchoolFenShuXian.aspx.cs"
    Inherits="GaoKao.SchoolLibrary.SchoolFenShuXian" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title><%=strPageTitle %>录取分数线_高考报考院校库_格伦高考网</title>
    <meta name="keywords" content="<%=strPageTitle%>录取分数线,<%=strPageTitle%>专业录取分数线" />
    <script src="/js/jquery.js" type="text/javascript"></script>
    <link href="/css/style.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="/js/highcharts.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <gk:Schoolbanner ID="SchoolBanner1" runat="server" BannerWord="格伦高考报考院校库" />
    <gk:Crumb ID="Crumb1" runat="server" />
    <div class="content">
        <div class="contentbody">
            <gk:SchoolLeft ID="SchoolLeft1" runat="server" Index="3" />
            <div class="contentR">
                <gk:SchoolBase ID="SchoolBase1" runat="server" />
                <div class="conRbox">
                    <script type="text/javascript">
                        $(function () {
                            $(".dtTitrit ul li").click(function () {
                                var index = $(".dtTitrit ul li").index(this);
                                $(this).addClass("current").siblings().removeClass("current");

                                //alert($(".tabs .tabscon").eq(index).html());
                                if (index == 0) {
                                    getFenShuXian();
                                    $(".lqfsx:eq(0)").show();
                                    $(".lqfsx:eq(1)").hide();
                                    $(".lqfsx:eq(2)").show();
                                    $(".lqfsx:eq(3)").hide();
                                } else {
                                    getZYFenShuXian();
                                    $(".lqfsx:eq(0)").hide();
                                    $(".lqfsx:eq(1)").show();
                                    $(".lqfsx:eq(2)").hide();
                                    $(".lqfsx:eq(3)").show();
                                }
                            });

                            getFenShuXian();
                            $(".lqfsx:eq(0)").show();
                            $(".lqfsx:eq(1)").hide();
                            $(".lqfsx:eq(2)").show();
                            $(".lqfsx:eq(3)").hide();

                            $(".yxlqfsx1").change(function () {
                                getFenShuXian();
                            });

                            $(".zylqfsx1").change(function () {
                                getZYFenShuXian();
                            })


                        });

                    </script>
                    <div class="dtTitrit zszcTit">
                        <ul>
                            <li class="current"><a href="javascript:void(0);">院校分数线</a></li>
                            <li><a href="javascript:void(0);">专业分数线</a></li>
                        </ul>
                    </div>
                    <div class="fsxcon">
                        <div class="fsxbox lqfsx" id="yxfsx_pic">
                        </div>
                        <div class="fsxbox lqfsx" id="zyfsx_pic">
                        </div>
                    </div>
                    <div class="lqfsx">
                        <div class="fsxTit">
                            <div class="fsxTitword">
                                录取分数线</div>
                            <div class="fsxTitright">
                                选择生源地：
                                <select class="fsxyear yxlqfsx1">
                                    <option value="1">北京市</option>
                                    <option value="2">天津市</option>
                                    <option value="3">河北省</option>
                                    <option value="4">山西省</option>
                                    <option value="5">内蒙古自治区</option>
                                    <option value="6">辽宁省</option>
                                    <option value="7">吉林省</option>
                                    <option value="8">黑龙江省</option>
                                    <option value="9">上海市</option>
                                    <option value="10">江苏省</option>
                                    <option value="11">浙江省</option>
                                    <option value="12">安徽省</option>
                                    <option value="13">福建省</option>
                                    <option value="14">江西省</option>
                                    <option value="15">山东省</option>
                                    <option value="16">河南省</option>
                                    <option value="17">湖北省</option>
                                    <option value="18">湖南省</option>
                                    <option value="19">广东省</option>
                                    <option value="20">广西壮族自治区</option>
                                    <option value="21">海南省</option>
                                    <option value="22">重庆市</option>
                                    <option value="23">四川省</option>
                                    <option value="24">贵州省</option>
                                    <option value="25">云南省</option>
                                    <option value="26">西藏自治区</option>
                                    <option value="27">陕西省</option>
                                    <option value="28">甘肃省</option>
                                    <option value="29">青海省</option>
                                    <option value="30">宁夏回族自治区</option>
                                    <option value="31">新疆维吾尔自治区</option>
                                    <option value="32">香港特别行政区</option>
                                    <option value="33">澳门特别行政区</option>
                                    <option value="34">台湾省</option>
                                </select>
                                选择科属：
                                <select class="fsxyear yxlqfsx1">
                                    <option value="1">文史</option>
                                    <option value="5">理工</option>
                                </select>
                              <%--  录取批次：
                                <select class="fsxyear yxlqfsx1">
                                    <option value="1">本科一批</option>
                                    <option value="2">本科二批</option>
                                    <option value="3">本科三批</option>
                                </select>--%>
                            </div>
                        </div>
                        <div class="fsxtable">

                        </div>
                        <script type="text/javascript">

                            function getFenShuXian() {
                                var provinceid = $(".yxlqfsx1:eq(0)").val();
                                var kelei = $(".yxlqfsx1:eq(1)").val();
                              //  var pici = $(".yxlqfsx1:eq(2)").val();
                                var schoolid = "<%=intSchoolId %>";

                                $(".fsxtable").html("<table id=\"yxfsxtable\" width=\"970\" border=\"1\"><tbody><tr><th width=\"138\">年份</th><th width=\"138\">最高分</th><th width=\"138\">最低分</th><th width=\"139\">平均分</th><th width=\"139\">省控线</th><th width=\"139\">线差</th><th width=\"139\">录取批次</th></tr><tr><td colspan=\"7\"><img src=\"images/loading.gif\"></td></tr></tbody></table>");

                                $.ajax({
                                    url: "/SchoolLibrary/getFenShuXian.ashx",
                                    type: "post",
                                    dataType: "html",
                                    data: { provinceid: provinceid, kelei: kelei, schoolid: schoolid },
                                    success: function (data) {
                                        if (data != "error") {
                                            //$("#yxfsxtable tr:gt(0)").remove();
                                            $(".fsxtable").html(data);
                                            //$(".fsxtable").append(data);
                                        } else {
                                            alert("获取数据失败");
                                        }
                                    }
                                });
                            }
                        </script>
                    </div>
                    <div class="lqfsx" style="display: none;">
                        <div class="fsxTit">
                            <div class="fsxTitword">
                                录取分数线</div>
                            <div class="fsxTitright">
                                选择年份：
                                <select class="fsxyear zylqfsx1">
                                    <option value="2013">2013</option>
                                    <option value="2012">2012</option>
                                    <option value="2011">2011</option>
                                    <option value="2010">2010</option>
                                </select>
                                选择生源地：
                                <select class="fsxyear zylqfsx1">
                                    <option value="1">北京市</option>
                                    <option value="2">天津市</option>
                                    <option value="3">河北省</option>
                                    <option value="4">山西省</option>
                                    <option value="5">内蒙古自治区</option>
                                    <option value="6">辽宁省</option>
                                    <option value="7">吉林省</option>
                                    <option value="8">黑龙江省</option>
                                    <option value="9">上海市</option>
                                    <option value="10">江苏省</option>
                                    <option value="11">浙江省</option>
                                    <option value="12">安徽省</option>
                                    <option value="13">福建省</option>
                                    <option value="14">江西省</option>
                                    <option value="15">山东省</option>
                                    <option value="16">河南省</option>
                                    <option value="17">湖北省</option>
                                    <option value="18">湖南省</option>
                                    <option value="19">广东省</option>
                                    <option value="20">广西壮族自治区</option>
                                    <option value="21">海南省</option>
                                    <option value="22">重庆市</option>
                                    <option value="23">四川省</option>
                                    <option value="24">贵州省</option>
                                    <option value="25">云南省</option>
                                    <option value="26">西藏自治区</option>
                                    <option value="27">陕西省</option>
                                    <option value="28">甘肃省</option>
                                    <option value="29">青海省</option>
                                    <option value="30">宁夏回族自治区</option>
                                    <option value="31">新疆维吾尔自治区</option>
                                    <option value="32">香港特别行政区</option>
                                    <option value="33">澳门特别行政区</option>
                                    <option value="34">台湾省</option>
                                </select>
                                选择科属：
                                <select class="fsxyear zylqfsx1">
                                    <option value="1">文史</option>
                                    <option value="5">理工</option>
                                </select>
                             <%--   录取批次：
                                <select class="fsxyear zylqfsx1">
                                    <option value="1">本科一批</option>
                                    <option value="2">本科二批</option>
                                    <option value="3">本科三批</option>
                                </select>--%>
                            </div>
                        </div>
                        <div class="fsxtable">
                        </div>
                        <script type="text/javascript">
                            function getZYFenShuXian() {

                            $(".fsxtable").html("<table id=\"yxfsxtable\" width=\"970\" border=\"1\"><tbody><tr><th width=\"100\">年份</th><th width=\"177\">专业名称</th><th width=\"138\">最高分</th><th width=\"138\">最低分</th><th width=\"139\">平均分</th><th width=\"139\">省控线</th><th width=\"139\">录取批次</th></tr><tr><td colspan=\"7\"><img src=\"images/loading.gif\"></td></tr></tbody></table>");

                                var year = $(".zylqfsx1:eq(0)").val();
                                var provinceid = $(".zylqfsx1:eq(1)").val();
                                var kelei = $(".zylqfsx1:eq(2)").val();
                             //   var pici = $(".zylqfsx1:eq(3)").val();
                                var schoolid = "<%=intSchoolId %>";

                                $.ajax({
                                    url: "/SchoolLibrary/getZYFenShuXian.ashx",
                                    type: "post",
                                    dataType: "html",
                                    data: { provinceid: provinceid, kelei: kelei, schoolid: schoolid, year: year },
                                    success: function (data) {
                                        if (data != "error") {
//                                            $("#zyfsxtable tr:gt(0)").remove();
//                                            $("#zyfsxtable").append(data);
                                            $(".fsxtable").html(data);
                                        } else {
                                            alert("获取数据失败");
                                        }
                                    }
                                });
                            }
                        </script>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <gk:Footer ID="Footer1" runat="server" />
    </form>
</body>
</html>
