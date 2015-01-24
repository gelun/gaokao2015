<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ZhiShiDianCPList.aspx.cs"
    Inherits="GaoKao.CePing.ZhiShiDian.ZhiShiDianCPList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>格伦高考网_高考资源网_高考报考_高考时间_高考作文_高考倒计时_格伦教育网</title>
    <meta name="keywords" content="高考,高考网,高考资源网,高考报考,高考时间,高考作文,高考倒计时" />
    <meta name="description" content="格伦高考网是格伦教育下设八大项目之一,将高考报考与生涯教育完美结合。并为考生提供专业的高考报考卡,从学业规划等角度出发,引导学生更有针对性地填报志愿,为广大高中生和家长提供全面精准的指导。" />
    <link href="/css/style.css" rel="stylesheet" type="text/css" />
    <script src="../../js/jquery.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {
            //页面加载
            getZhiShiDianList(0);

            //点击切换科目时，调取对应的知识点列表
            $(".gzzsdL ul li").click(function () {
                $(this).addClass("cur").siblings().removeClass("cur"); //切换选中科目
                $(".gzzsdR ul li").remove(); //删除右侧被选中的知识点
                getZhiShiDianList($(this).index()); //展示该对应的知识点
            });
            //异步调取知识点
            function getZhiShiDianList(index) {
                $.ajax({
                    url: $("#form1").attr("action"),    // 提交的页面
                    data: { ty: "zsd", index: index },       // 从表单中获取数据
                    type: "GET",                        // 设置请求类型为"GET"，默认为"GET"
                    beforeSend: function ()             // 设置表单提交前方法
                    {
                        //提交前的动作
                    },
                    error: function (data, status, e) {
                        // 异常提示 
                    },
                    success: function (data) {
                        $(".gzzsdC ul").html(data);
                    }
                });
            }

            //
            $("input[type='checkbox']").live("click", function () {
                var k = $(this).attr("k");
                var v = $(this).attr("v");
                var $ul = $(".gzzsdR ul");
                var $LiHtml = $("<li k='" + k + "' v='" + v + "'>" + v + "</li>");

                if ($(this).attr("checked") == "checked") {
                    if ($ul.find("li").length < 3) {
                        $ul.append($LiHtml);
                    } else {
                        alert('最多允许选择三个知识点');
                        return false;
                    }
                } else {
                    $(".gzzsdR ul li").remove("li[k='" + k + "'][v='" + v + "']");
                }
            });

            //被选择内容
            $(".gzzsdR ul li").live("click", function () {
                if ($(this).hasClass("xz")) {
                    $(this).removeClass("xz");
                } else {
                    $(this).addClass("xz");
                }
            });

            //移除
            $(".yichu").click(function () {
                var bxz = "";
                $(".gzzsdR ul li[class='xz']").each(function () {
                    var k = $(this).attr("k");
                    var v = $(this).attr("v");
                    $(".gzzsdR ul li").remove("li[k='" + k + "'][v='" + v + "']");
                    $("input[type='checkbox'][k='" + k + "'][v='" + v + "']").attr("checked", false);

                    bxz = "has";
                });
                if (bxz == "") {
                    alert("请点击选中要删除的项");
                    return false;
                }
            });

            //下一步
            $(".xiayibu").click(function () {
                var zsdlist = ",";
                $(".gzzsdR ul li").each(function () {
                    var k = $(this).attr("k");
                    zsdlist += k + ",";
                });
                if (zsdlist != ",") {
                    window.location.href = "zsdsj.aspx?kl=" + $(".gzzsdL ul li[class='cur']").index() + "&zsdlist=" + zsdlist;
                } else {
                    alert("请选择知识点");
                    return false;
                }
            });
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <gk:Schoolbanner ID="SchoolBanner1" runat="server" BannerWord="格伦高考报考系统" />
    <gk:Crumb ID="Crumb1" runat="server" NavString=" <span>&gt;</span> 知识点检测 <span>&gt;</span> 高中知识点" />
    <div class="content" style="background: #fff;">
        <div class="contentbody">
            <div class="cxTit" style="margin-top: 20px;">
                <div class="cxTitL" style="font-size: 30px;">
                    高中知识点</div>
            </div>
            <div class="gzzsd">
                <div class="gzzsdL">
                    <h3>
                        学&nbsp;&nbsp;科</h3>
                    <ul>
                        <li class="cur"><a href="javascript:;">语&nbsp;&nbsp;文</a></li>
                        <li><a href="javascript:;">数&nbsp;&nbsp;学</a></li>
                        <li><a href="javascript:;">英&nbsp;&nbsp;语</a></li>
                        <li><a href="javascript:;">物&nbsp;&nbsp;理</a></li>
                        <li><a href="javascript:;">化&nbsp;&nbsp;学</a></li>
                        <li><a href="javascript:;">生&nbsp;&nbsp;物</a></li>
                        <li><a href="javascript:;">地&nbsp;&nbsp;理</a></li>
                        <li><a href="javascript:;">历&nbsp;&nbsp;史</a></li>
                        <li><a href="javascript:;">政&nbsp;&nbsp;治</a></li>
                    </ul>
                </div>
                <div class="gzzsdC">
                    <h3 class="mulu">
                        <span>
                            <img src="/images/zsd_jt.jpg"></span>目录</h3>
                    <ul>
                        <li>
                            <input type="checkbox" class="rad" k="1" v='语言基础知识' />语言基础知识</li>
                        <li>
                            <input type="checkbox" class="rad" k="2" v='语言表达和运用' />语言表达和运用</li>
                        <li>
                            <input type="checkbox" class="rad" k="3" v='文言文阅读' />文言文阅读</li>
                        <li>
                            <input type="checkbox" class="rad" k="4" v='古代诗歌鉴赏' />古代诗歌鉴赏</li>
                        <li>
                            <input type="checkbox" class="rad" k="5" v='现代文阅读' />现代文阅读</li>
                        <li>
                            <input type="checkbox" class="rad" k="6" v='文学常识和名句名篇' />文学常识和名句名篇</li>
                    </ul>
                </div>
                <div class="gzzsdR">
                    <h3 class="mulu">
                        已选择内容</h3>
                    <ul>
                    </ul>
                    <div class="yichu">
                        <a href="javascript:;">移除所选</a></div>
                </div>
            </div>
            <div class="xiayibu">
                <a href="javascript:;">下一步</a></div>
        </div>
    </div>
    <gk:Footer ID="Footer1" runat="server" />
    </form>
</body>
</html>
