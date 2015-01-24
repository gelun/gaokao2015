<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProfessionalList.aspx.cs"
    Inherits="GaoKao.ProfessionalLibrary.ProfessionalList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>格伦高考专业库_格伦高考网</title>
    <meta name="keywords" content="格伦高考专业库,高考报考,格伦高考网" />
    <script src="/js/jquery.js" type="text/javascript"></script>
    <link href="/css/style.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <gk:ProfessionalBanner ID="ProfessionalBanner1" runat="server" BannerWord="格伦高考报考专业库" />
    <gk:Crumb ID="Crumb1" runat="server" NavString=" <span>&gt;</span> 高考报考专业库" />
    <div class="content" style="background: #fff;">
        <div class="contentbody">
            <div class="zykword">
                2012年9月，教育部颁布了《普通高等学校本科专业目录(2012年)》，新目录的学科门类与国务院学位委员会、教育部2011年印发的《学位授予和人才培养学科目录(2011年)》的学科门类基本一致，分设12个学科门类，新增了艺术学学科门类，未设军事学学科门类，其代码11预留。专业类由修订前的73个增加到92个；专业由修订前的635种调减到506种。新目录分为基本专业(352种)和特设专业(154种)，并确定了62种专业为国家控制布点专业。特设专业和国家控制布点专业分别在专业代码后加“T”和“K”表示，以示区分。基本专业是学科基础比较成熟、社会需求相对稳定、布点数量相对较多、继承性较好的专业；特设专业是针对不同高校的办学特色，或适应近年来人才培养特殊需求设置的专业。国家控制布点专业，包含两部分，一部分是指涉及国家安全、特殊行业的专业由国家控制布点（比如麻醉学、法医学、民族学、宗教学、社会学、古典文学、人体运动训练、外交学等，还有一些小语种专业），由于这些专业社会需求量较少，国家要控制布点设置，不需要多数院校设置。另一部分是指该类专业在全国普通高校设置过多,因此不再审批新的设置,对已设置学校,严格监控其教学质量,并逐步加以关停,以达到一个合理的设置规模。</div>
            <div class="zykcon">
                <div class="zyknav">
                    <ul id="zykul">
                        <li class="zyknavcur1"><a href="javascript:void(0);">本&nbsp;科</a>
                            <!--#include file="../commonfile/ProfessionalBenKe.html"-->
                        </li>
                        <li><a href="javascript:void(0);">专&nbsp;科</a>
                            <!--#include file="../commonfile/ProfessionalZhuanKe.html"-->
                        </li>
                    </ul>
					<div style="clear:both;"></div>
                    <script type="text/javascript">
                        $(function () {
                            //页面初始化
                            getProfessionalList($(".zyknavcur1").find(".xuanzhong2").find(".xuanzhong3").find("a").attr("v"));

                            //层次
                            $("#zykul li a").click(function () {
                                $(this).parent().addClass("zyknavcur1").siblings().removeClass("zyknavcur1");
                                $(this).parent().siblings().children("ul").hide();
                                $(this).parent().children("ul").show(); //.siblings().attr("display", "none");


                                var v = $(this).parent().find(".xuanzhong2").find(".xuanzhong3").find("a").attr("v");
                                getProfessionalList(v);

                            });

                            //学科门类
                            $("#zykul li ul li a").click(function () {

                                $(this).parent().addClass("xuanzhong2").siblings().removeClass("xuanzhong2");

                                var v = $(this).parent().find(".xuanzhong3").find("a").attr("v");
                                getProfessionalList(v);

                            });
                            //专业类
                            $("#zykul li ul li ul li a").click(function () {
                                $(this).parent().addClass("xuanzhong3").siblings().removeClass("xuanzhong3");
                            });

                        });

                        //获取专业列表
                        function getProfessionalList(ProfessionalParentId) {
                            if (ProfessionalParentId > 0) {

                                $.ajax({
                                    url: "/ProfessionalLibrary/GetProfessionalList.ashx",
                                    type:"get",
                                    dataType: "html",
                                    data: { zylid: ProfessionalParentId },
                                    success: function (data) {
                                        if (data != "error") {
                                            //删除旧数据
                                            $("#ProfessionalList tr:gt(0)").remove();
                                            //添加新数据
                                            $("#ProfessionalList tr:eq(0)").after(data);
                                        } else {
                                            alert("获取数据失败");
                                            return false;
                                        }
                                    }
                                });
                            }
                        }
                    </script>
                </div>
                <div class="zyktable" style="float: right; width: 672px; padding: 10px 10px 0 30px;
                    text-align: center;">
                    <table width="100%" border="1" id="ProfessionalList">
                        <tbody>
                            <tr>
                                <th>
                                    专业名称
                                </th>
                                <th>
                                    开设院校
                                </th>
                                <th>
                                    历年就业
                                </th>
                                <th>
                                    相关职业
                                </th>
                            </tr>
                        </tbody>
                    </table>
                </div>
            </div>
        </div>
    </div>
    <gk:Footer ID="Footer1" runat="server" />
    </form>
</body>
</html>
