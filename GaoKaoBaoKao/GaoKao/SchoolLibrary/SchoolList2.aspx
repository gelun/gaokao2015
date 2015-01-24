<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SchoolList2.aspx.cs" Inherits="GaoKao.SchoolLibrary.SchoolList2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>格伦高考网_高考资源网_高考报考_高考时间_高考作文_高考倒计时_格伦教育网</title>
    <meta name="keywords" content="高考,高考网,高考资源网,高考报考,高考时间,高考作文,高考倒计时" />
    <meta name="description" content="格伦高考网是格伦教育下设八大项目之一,将高考报考与生涯教育完美结合。并为考生提供专业的高考报考卡,从学业规划等角度出发,引导学生更有针对性地填报志愿,为广大高中生和家长提供全面精准的指导。" />
    <script src="/js/jquery.js" type="text/javascript"></script>
    <link href="../css/style.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        $(function () {
            $(".che").attr("checked", true);

            getSchoolList(1);

            // 单个属性全选  ： 1 院校特色  2 院校层次  3 院校性质  4 院校隶属   5 院校类型   6 院校省份
            $(".che").click(function () {
                var val = $(this).val();

                //设定 checkbox 的选择 与否
                if (val > 0) {
                    //点击的是非全选按钮
                    if ($(this).attr("checked") == "checked") {

                        //判定是否全部都选择了
                        var b = true;
                        $("input[k='" + $(this).attr("k") + "']").each(function () {
                            if ($(this).val() > 0 && $(this).attr("checked") == false) {
                                b = false;
                            }
                        });
                        if (b == true) {

                            $("input[k='" + $(this).attr("k") + "'][value=0]").attr("checked", true);
                        }
                    } else {

                        //取消全选
                        $("input[k='" + $(this).attr("k") + "'][value=0]").attr("checked", false);
                    }
                } else {
                    //点击的是全选按钮
                    if ($(this).attr("checked") == "checked") {
                        $("input[k='" + $(this).attr("k") + "']").attr("checked", true);
                    } else {
                        $("input[k='" + $(this).attr("k") + "']").attr("checked", false);
                    }
                }

                //加载列表数据
                getSchoolList(1);
            });
        });

        function getSchoolList(intCurrentPage) {
            $.ajax({
                url: "getSchoolPage.ashx",
                type: "post",
                dataType: "html",
                data: { tese: getCheckList(1), cengci: getCheckList(2), xingzhi: getCheckList(3), belong: getCheckList(4), leixing: getCheckList(5), province: getCheckList(6), p: intCurrentPage },
                success: function (pagehtml) {

                    $(".page").html(pagehtml);

                    getList(intCurrentPage);

                }
            });
        }

        function getList(intCurrentPage) {
            $.ajax({
                url: "getSchoolList.ashx",
                type: "post",
                dataType: "html",
                data: { tese: getCheckList(1), cengci: getCheckList(2), xingzhi: getCheckList(3), belong: getCheckList(4), leixing: getCheckList(5), province: getCheckList(6), p: intCurrentPage },
                success: function (html) {

                    $("#lists").html(html);

                }
            });
        }

        function getCheckList(k) {
            var list = "";
            //没有全选，只要被选中的那些项
            $("input[k='" + k + "'][value>0]").each(function () {
                if ($(this).val() > 0 && $(this).attr("checked") == "checked") {
                    list += $(this).val() + ",";
                }
            });
            return list;
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <gk:Nav ID="nav1" runat="server" />
    <gk:Schoolbanner ID="SchoolBanner1" runat="server" />
    <gk:Crumb ID="Crumb1" runat="server" />
    <div class="content" style="background: #fff;">
        <div class="contentbody">
            <div class="yxkL">
                <div class="tiaojian">
                    <div class="yxtj">
                        <div class="yxtjL">
                            已选条件：</div>
                        <div class="yxtjR">
                            <a href="#">教育部直属<span>X</span></a><a href="#">财经<span>X</span></a></div>
                    </div>
                    <div class="xuanze">
                        <div class="xzbox">
                            <div class="xzboxL">
                                院校特色：</div>
                            <div class="qx">
                                <input type="checkbox" name="" class="che" cb="tese" k="1" value="0" />全选</div>
                            <div class="xzboxR">
                                <ul>
                                    <li>
                                        <input type="checkbox" name="" class="che" k="1" value="1" />211院校</li>
                                    <li>
                                        <input type="checkbox" name="" class="che" k="1" value="2" />985院校</li>
                                    <li>
                                        <input type="checkbox" name="" class="che" k="1" value="3" />研究生院</li>
                                    <li>
                                        <input type="checkbox" name="" class="che" k="1" value="4" />自主招生</li>
                                    <li>
                                        <input type="checkbox" name="" class="che" k="1" value="5" />国防生</li>
                                    <li>
                                        <input type="checkbox" name="" class="che" k="1" value="6" />农村专项</li>
                                    <li>
                                        <input type="checkbox" name="" class="che" k="1" value="7" />小211工程</li>
                                    <li>
                                        <input type="checkbox" name="" class="che" k="1" value="8" />卓越计划</li>
                                    <li>
                                        <input type="checkbox" name="" class="che" k="1" value="9" />艺术生</li>
                                    <li>
                                        <input type="checkbox" name="" class="che" k="1" value="10" />高水平运动员</li>
                                </ul>
                            </div>
                        </div>
                        <div class="xzbox">
                            <div class="xzboxL">
                                院校层次：</div>
                            <div class="qx">
                                <input type="checkbox" name="" class="che" cb="tese" k="2" value="0" />全选</div>
                            <div class="xzboxR">
                                <ul class="cheul">
                                    <li>
                                        <input type="checkbox" name="" class="che" k="2" value="1" />本科</li>
                                    <li>
                                        <input type="checkbox" name="" class="che" k="2" value="2" />专科</li>
                                </ul>
                            </div>
                        </div>
                        <div class="xzbox">
                            <div class="xzboxL">
                                院校性质：</div>
                            <div class="qx">
                                <input type="checkbox" name="" class="che" cb="tese" k="3" value="0" />全选</div>
                            <div class="xzboxR">
                                <ul class="cheul">
                                    <li>
                                        <input type="checkbox" name="" class="che" k="3" value="1" />公办</li>
                                    <li>
                                        <input type="checkbox" name="" class="che" k="3" value="2" />民办</li>
                                    <li style="width: 90px;">
                                        <input type="checkbox" name="" class="che" k="3" value="3" />独立院校</li>
                                </ul>
                            </div>
                        </div>
                        <div class="xzbox">
                            <div class="xzboxL">
                                院校隶属：</div>
                            <div class="qx">
                                <input type="checkbox" name="" class="che" cb="tese" k="4" value="0" />全选</div>
                            <div class="xzboxR">
                                <ul class="cheul">
                                    <li>
                                        <input type="checkbox" name="" class="che" k="4" value="1" />教育部</li>
                                    <li style="width: 110px;">
                                        <input type="checkbox" name="" class="che" k="4" value="2" />中央部委直属</li>
                                    <li>
                                        <input type="checkbox" name="" class="che" k="4" value="3" />其他</li>
                                </ul>
                            </div>
                        </div>
                        <div class="xzbox">
                            <div class="xzboxL">
                                院校类型：</div>
                            <div class="qx">
                                <input type="checkbox" name="" class="che" cb="tese" k="5" value="0" />全选</div>
                            <div class="xzboxR">
                                <ul class="cheul">
                                    <li>
                                        <input type="checkbox" name="" class="che" k="5" value="1" />综合类</li>
                                    <li>
                                        <input type="checkbox" name="" class="che" k="5" value="2" />理工类</li>
                                    <li>
                                        <input type="checkbox" name="" class="che" k="5" value="3" />农林类</li>
                                    <li>
                                        <input type="checkbox" name="" class="che" k="5" value="4" />医药类</li>
                                    <li>
                                        <input type="checkbox" name="" class="che" k="5" value="5" />师范类</li>
                                    <li>
                                        <input type="checkbox" name="" class="che" k="5" value="6" />语言类</li>
                                    <li>
                                        <input type="checkbox" name="" class="che" k="5" value="7" />财经类</li>
                                    <li>
                                        <input type="checkbox" name="" class="che" k="5" value="8" />政法类</li>
                                    <li>
                                        <input type="checkbox" name="" class="che" k="5" value="9" />体育类</li>
                                    <li>
                                        <input type="checkbox" name="" class="che" k="5" value="10" />艺术类</li>
                                    <li>
                                        <input type="checkbox" name="" class="che" k="5" value="11" />民族类</li>
                                    <li>
                                        <input type="checkbox" name="" class="che" k="5" value="12" />军事类</li>
                                    <li>
                                        <input type="checkbox" name="" class="che" k="5" value="13" />其他</li>
                                </ul>
                            </div>
                        </div>
                        <div class="xzbox">
                            <div class="xzboxL">
                                院校省份：</div>
                            <div class="qx">
                                <input type="checkbox" name="" class="che" cb="tese" k="6" value="0" />全选</div>
                            <div class="xzboxR">
                                <ul class="cheul">
                                    <li>
                                        <input type="checkbox" name="" class="che" k="6" value="1" />北京</li>
                                    <li>
                                        <input type="checkbox" name="" class="che" k="6" value="2" />天津</li>
                                    <li>
                                        <input type="checkbox" name="" class="che" k="6" value="3" />河北</li>
                                    <li>
                                        <input type="checkbox" name="" class="che" k="6" value="4" />山西</li>
                                    <li>
                                        <input type="checkbox" name="" class="che" k="6" value="5" />内蒙古</li>
                                    <li>
                                        <input type="checkbox" name="" class="che" k="6" value="6" />辽宁</li>
                                    <li>
                                        <input type="checkbox" name="" class="che" k="6" value="7" />吉林</li>
                                    <li>
                                        <input type="checkbox" name="" class="che" k="6" value="8" />黑龙江</li>
                                    <li>
                                        <input type="checkbox" name="" class="che" k="6" value="9" />上海</li>
                                    <li>
                                        <input type="checkbox" name="" class="che" k="6" value="10" />江苏</li>
                                    <li>
                                        <input type="checkbox" name="" class="che" k="6" value="11" />浙江</li>
                                    <li>
                                        <input type="checkbox" name="" class="che" k="6" value="12" />安徽</li>
                                    <li>
                                        <input type="checkbox" name="" class="che" k="6" value="13" />福建</li>
                                    <li>
                                        <input type="checkbox" name="" class="che" k="6" value="14" />江西</li>
                                    <li>
                                        <input type="checkbox" name="" class="che" k="6" value="15" />山东</li>
                                    <li>
                                        <input type="checkbox" name="" class="che" k="6" value="16" />河南</li>
                                    <li>
                                        <input type="checkbox" name="" class="che" k="6" value="17" />湖北</li>
                                    <li>
                                        <input type="checkbox" name="" class="che" k="6" value="18" />湖南</li>
                                    <li>
                                        <input type="checkbox" name="" class="che" k="6" value="19" />广东</li>
                                    <li>
                                        <input type="checkbox" name="" class="che" k="6" value="20" />广西</li>
                                    <li>
                                        <input type="checkbox" name="" class="che" k="6" value="21" />海南</li>
                                    <li>
                                        <input type="checkbox" name="" class="che" k="6" value="22" />重庆</li>
                                    <li>
                                        <input type="checkbox" name="" class="che" k="6" value="23" />四川</li>
                                    <li>
                                        <input type="checkbox" name="" class="che" k="6" value="24" />贵州</li>
                                    <li>
                                        <input type="checkbox" name="" class="che" k="6" value="25" />云南</li>
                                    <li>
                                        <input type="checkbox" name="" class="che" k="6" value="26" />西藏</li>
                                    <li>
                                        <input type="checkbox" name="" class="che" k="6" value="27" />陕西</li>
                                    <li>
                                        <input type="checkbox" name="" class="che" k="6" value="28" />甘肃</li>
                                    <li>
                                        <input type="checkbox" name="" class="che" k="6" value="29" />青海</li>
                                    <li>
                                        <input type="checkbox" name="" class="che" k="6" value="30" />宁夏</li>
                                    <li>
                                        <input type="checkbox" name="" class="che" k="6" value="31" />新疆</li>
                                    <li>
                                        <input type="checkbox" name="" class="che" k="6" value="32" />港澳台</li>
                                </ul>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="yxtable" name="header_5">
                    <a name="header_5"></a>
                    <table id="lists" width="915" border="1">
                    </table>
                    <div class="page">
                    </div>
                </div>
            </div>
            <div class="yxkR">
                <div class="tool">
                    <div class="toolTit">
                        高考小工具</div>
                    <div class="toolbox">
                        <div class="toolboxL" id="tool1">
                            院校信息</div>
                        <div class="toolboxR">
                            <a href="#">全国高校名单</a><a href="#">本科院校</a><a href="#">958工程</a><a href="#">211工程</a><a
                                href="#">民办高校</a><a href="#">中外合作办学</a><a href="#">海外院校库</a></div>
                    </div>
                    <div class="toolbox">
                        <div class="toolboxL" id="tool2">
                            专业信息</div>
                        <div class="toolboxR">
                            <a href="#">全国高校名单</a><a href="#">本科院校</a><a href="#">958工程</a><a href="#">211工程</a><a
                                href="#">民办高校</a><a href="#">中外合作办学</a><a href="#">海外院校库</a></div>
                    </div>
                    <div class="toolbox" style="border-bottom: 0;">
                        <div class="toolboxL" id="tool3">
                            实用信息</div>
                        <div class="toolboxR">
                            <a href="#">全国高校名单</a><a href="#">本科院校</a><a href="#">958工程</a><a href="#">211工程</a><a
                                href="#">民办高校</a><a href="#">中外合作办学</a><a href="#">海外院校库</a></div>
                    </div>
                </div>
                <div class="tool">
                    <div class="toolTit">
                        热门高校排行榜</div>
                    <div class="paimingul">
                        <ul>
                            <li><strong style="background: #f18d14;">1</strong><span>34566</span><a href="#">北京理工大学</a></li>
                            <li><strong style="background: #f18d14;">2</strong><span>34566</span><a href="#">北京大学</a></li>
                            <li><strong style="background: #f18d14;">3</strong><span>34566</span><a href="#">中国人民大学</a></li>
                            <li><strong>4</strong><span>34566</span><a href="#">北京理工大学</a></li>
                            <li><strong>5</strong><span>34566</span><a href="#">北京大学</a></li>
                            <li><strong>6</strong><span>34566</span><a href="#">北京人民大学</a></li>
                            <li><strong>7</strong><span>34566</span><a href="#">北京理工大学</a></li>
                            <li><strong>8</strong><span>34566</span><a href="#">北京大学</a></li>
                            <li><strong>9</strong><span>34566</span><a href="#">北京人民大学</a></li>
                            <li><strong>10</strong><span>34566</span><a href="#">北京理工大学</a></li>
                        </ul>
                    </div>
                    <script type="text/javascript">
                        //跨域（可跨所有域名）
                        $(function () {
                            $.getJSON("paihangbang.ashx?callback=?", { lg: "10" }, function (data) {
                                if (data != null) {
                                    var html = "";
                                    for (var i = 0; i < data.length; i++) {
                                        if (i < 3) {
                                            html += "<li><strong style=\"background: #f18d14;\">" + (i + 1) + "</strong><span>" + data[i].ClickNum + "</span><a href=\"SchoolIntro.aspx?schoolid=" + data[i].SchoolId + "\">" + data[i].SchoolName + "</a></li>"
                                        } else {
                                            html += "<li><strong>" + (i + 1) + "</strong><span>" + data[i].ClickNum + "</span><a href=\"SchoolIntro.aspx?schoolid=" + data[i].SchoolId + "\">" + data[i].SchoolName + "</a></li>";
                                        }
                                    }
                                    $(".paimingul ul").html(html);
                                }
                            });
                        });
                    </script>
                </div>
            </div>
        </div>
    </div>
    <gk:Footer ID="Footer1" runat="server" />
    </form>
</body>
</html>
