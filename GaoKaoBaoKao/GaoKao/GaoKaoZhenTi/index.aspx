<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="GaoKao.GaoKaoZhenTi.index" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>历年高考真题模拟练习</title>
    <link href="css/more2.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="/js/jquery.js"></script>
    <script src="js/aui-artDialog-5c965d5/lib/sea.js"></script>
    <script src="js/dialogs.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {
            var hidkm = $("#hidkm").val();
            loadMessage(hidkm);

            //默认语文被选中
            $("#kemu").val(hidkm);
            //点击选择科目
            $("#kemu").change(function () {
                var kemuid = $(this).val();
                $("#hidkm").val(kemuid);
                loadMessage(kemuid);
                var kemuname = $("#kemu option[value='" + kemuid + "']").text();
                $("#ztmntitle").text("真题模拟（当前选择 " + kemuname + "）");
            });


            //根据科目加载页面知识点和题型的信息、省份信息
            function loadMessage(kemuid) {
                //加载页面知识点和题型的信息
                $.ajax({
                    url: "ashx/loadzhishidian.ashx",
                    type: "post",
                    dataType: "html",
                    data: { kemu: kemuid },
                    success: function (data) {

                        var arr = new Array();
                        arr = data.split('|||');
                        if (arr.length == 1) {
                            $(".practice .list").eq(0).html(arr[0]);
                        } else {
                            if (arr.length > 1) {
                                $(".practice .list").eq(0).html(arr[0]);
                                $(".practice .list").eq(1).html(arr[1]);
                            }
                        }

                        // alert($(".practice .list").eq(0).height());
                    }
                });
                //加载省份
                $.ajax({
                    url: "ashx/area_province.ashx",
                    type: "post",
                    dataType: "html",
                    data: { kemu: kemuid },
                    success: function (data) {
                        $("#area_province").html(data);
                    }
                });
            }
        });
    </script>
</head>
<body>
    <form runat="server" id="form1">
    <gk:Schoolbanner ID="SchoolBanner1" BannerWord="格伦高考报考系统" runat="server" />
    <div id="Messagewrap1">
        <div id="Messagewrap">
            <div class="now">
                您当前所在的位置：<a href="/">首页</a> >> <span>高考真题</span></div>
            <div class="top">
                <h1>
                    格伦高考真题</h1>
                <div class="rit">
                    <input type="hidden" id="hidkm" value="1" />
                    <select name="" id="kemu">
                        <option value="1">语文</option>
                        <option value="2">数学</option>
                        <option value="3">英语</option>
                        <option value="4">物理</option>
                        <option value="5">化学</option>
                        <option value="6">生物</option>
                        <option value="7">地理</option>
                        <option value="8">历史</option>
                        <option value="9">政治</option>
                    </select>
                </div>
            </div>
            <div class="practice">
                <div class="boxL">
                    <div class="tit">
                        知识点练习(每组10题)</div>
                    <div class="list">
                    </div>
                    <div class="bot" style="display: none;">
                        <a href="#">
                            <img src="images/jt.gif" width="9" height="6" /></a></div>
                </div>
                <div class="boxC">
                    <div class="tit">
                        题型练习(每组10题)</div>
                    <div class="list">
                        <ul>
                        </ul>
                    </div>
                    <div class="bot" style="display: none;">
                        <a href="#">
                            <img src="images/jt.gif" width="9" height="6" /></a></div>
                </div>
                <div class="boxR">
                    <div class="tit" id="ztmntitle">
                        真题模拟（当前选择 语文）</div>
                    <div class="test">
                        <div class="testL">
                            <select name="" id="year">
                                <option value="0">选择年份</option>
                                <option value="2013">2013年</option>
                                <option value="2012">2012年</option>
                                <option value="2011">2011年</option>
                                <option value="2010">2010年</option>
                                <option value="2009">2009年</option>
                            </select>
                            <select name="" id="area_province">
                                <option value="0">选择省份</option>
                            </select>
                        </div>
                        <div class="testR">
                            <a id="start1" href="javascript:start();">开始做题</a></div>
                    </div>
                </div>
                <a href="cuotiben.aspx">
                    <div class="ctb">
                        <div class="tit">
                            我的错题本</div>
                        <p>
                            全面记录高中阶段所学知识点错题做好自我查漏补缺。</p>
                    </div>
                </a>
            </div>
        </div>
    </div>
    <!--#include file="../includefiles/footer.html" -->
    </form>
    <script type="text/javascript">
        function start() {
            var year = $("#year").val();
            if (year == 0) {

                artDialog11("请选择年份！", "确定", "取消", "0", window.location.href);

                return;
            }

            var province = $("#area_province").val();
            if (province == 0) {
                artDialog11("请选择省份！", "确定", "取消", "0", window.location.href);

                return;
            }

            var subjectid = $("#kemu").val();

            $.ajax({
                url: "ashx/shitilist.ashx",
                type: "post",
                dataType: "html",
                data: { sid: subjectid, y: year, p: province },
                success: function (data) {
                    if (data == "success") {
                        //window.open("shiti_list.aspx?year=" + year + "&provinceid=" + province + "&subjectid=" + subjectid, 'newwindow', '');
                        window.location.href = "shiti_list.aspx?year=" + year + "&provinceid=" + province + "&subjectid=" + subjectid;
                    } else {
                        artDialog11("该试卷不存在！", "确定", "取消", "0", "");
                    }
                }
            });
        }
    </script>
</body>
</html>
