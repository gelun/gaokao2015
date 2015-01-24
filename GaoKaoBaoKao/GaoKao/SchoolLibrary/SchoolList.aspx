<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SchoolList.aspx.cs" Inherits="GaoKao.SchoolLibrary.SchoolList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>格伦高考报考院校库_格伦高考网</title>
    <meta name="keywords" content="院校库,格伦高考报考院校库,格伦高考网" />
    <script type="text/javascript" src="/js/jquery.js"></script>
    <link href="/css/style.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="/js/jquery.js"></script>
	<link rel="stylesheet" href="/css/jquery.tip.css" type="text/css" />
	<script type="text/javascript" src="/js/jquery.poshytip.js"></script>
    <script type="text/javascript">
        function del(k, v) {
            $(".yxtjR a[k='" + k + "'][v='" + v + "']").remove();
            if (k == "0" && v == "0") {
                $("#hidSchoolName").val("");
            } else {
                $("input[k='" + k + "'][value=" + v + "]").attr("checked", false);
            }

            yxtjshow(); //已选条件 栏  显示或者隐藏

            //加载列表数据
            getSchoolList(1);
        }
    </script>
    <script type="text/javascript">
        $(function () {
            yxtjshow();
            duibiLan(0); //对比栏内容加载

            getSchoolList(1);

            // 单个属性全选  ： 1 院校特色  2 院校层次  3 院校性质  4 院校隶属   5 院校类型   6 院校省份
            $(".che").click(function () {
                var val = $(this).val();
                var k = $(this).attr("k");
                var t = $(this).attr("t");


                if (val > 0) {//设定 checkbox 的选择 与否

                    //点击的是非全选按钮
                    if ($(this).attr("checked") == "checked") {

                        //判定是否全部都选择了
                        var b = true;
                        if (k == 2 || k == 3 || k == 4) {
                            for (var i = 2; i <= 4; i++) {
                                $("input[k='" + i + "']").each(function () {
                                    if ($(this).val() > 0 && $(this).attr("checked") == false) {
                                        b = false;
                                    }
                                });
                            }
                        } else {
                            $("input[k='" + $(this).attr("k") + "']").each(function () {
                                if ($(this).val() > 0 && $(this).attr("checked") == false) {
                                    b = false;
                                }
                            });
                        }
                        if (b == true) {
                            if (k == 3 || k == 4) {
                                $("input[k='2'][value=0]").attr("checked", true);
                            } else {
                                $("input[k='" + $(this).attr("k") + "'][value=0]").attr("checked", true);
                            }
                        }

                        //已选条件 那一栏 处理
                        $(".yxtjR").append("<a href=\"javascript:del(" + k + "," + val + ");\" k=\"" + k + "\" v=\"" + val + "\">" + t + "<span>X</span></a>");
                    } else {
                        //取消全选

                        if (k == 3 || k == 4) {
                            $("input[k='2'][value=0]").attr("checked", false);
                        } else {
                            $("input[k='" + $(this).attr("k") + "'][value=0]").attr("checked", false);
                        }

                        //已选条件 那一栏 处理
                        $(".yxtjR a[k='" + k + "'][v='" + val + "']").remove();
                        $("input[k='" + k + "'][value=" + val + "]").attr("checked", false);
                    }
                    yxtjshow();
                } else {
                    //点击的是全选按钮
                    if ($(this).attr("checked") == "checked") {
                        if (k == 2) {
                            $("input[k='2']").attr("checked", true);
                            $("input[k='3']").attr("checked", true);
                            $("input[k='4']").attr("checked", true);
                        } else {
                            $("input[k='" + $(this).attr("k") + "']").attr("checked", true);
                        }
                    } else {
                        if (k == 2) {
                            $("input[k='2']").attr("checked", false);
                            $("input[k='3']").attr("checked", false);
                            $("input[k='4']").attr("checked", false);
                        } else {
                            $("input[k='" + $(this).attr("k") + "']").attr("checked", false);
                        }
                    }

                    yxtjshow();
                }

                //加载列表数据
                getSchoolList(1);
            });
        });

        function getSchoolList(intCurrentPage) {
            $.ajax({
                url: "/SchoolLibrary/getSchoolPage.ashx",
                type: "post",
                dataType: "html",
                data: { schoolname: $("#hidSchoolName").val(), tese: getCheckList(1), cengci: getCheckList(2), xingzhi: getCheckList(3), belong: getCheckList(4), leixing: getCheckList(5), province: getCheckList(6), p: intCurrentPage },
                success: function (pagehtml) {

                    $(".page").html(pagehtml);

                    getList(intCurrentPage);

                }
            });
        }

        function getList(intCurrentPage) {
            $.ajax({
                url: "/SchoolLibrary/getSchoolList.ashx",
                type: "post",
                dataType: "html",
                data: { schoolname: $("#hidSchoolName").val(), tese: getCheckList(1), cengci: getCheckList(2), xingzhi: getCheckList(3), belong: getCheckList(4), leixing: getCheckList(5), province: getCheckList(6), p: intCurrentPage },
                success: function (html) {

                    $("#lists").html(html);

                    $('.demo-follow-cursor').poshytip({
                        followCursor: false,
                        slide: false
                    });

                    /**  点击对比   **/
                    $(".gx").click(function () {
                        var schooliddb = $(this).attr("sid");
                        if ($(this).attr("checked") == "checked") {
                            var duibischool = getCookie("duibischool");

                            //1写入cookie
                            if (duibischool == null || duibischool == "") {
                                SetCookie("duibischool", "," + schooliddb + ",");
                            } else {

                                if (duibischool.split(",").length - 2 >= 5) {
                                    $('.duibi').show(200);
                                    alert("对比栏已满，若想加入对比栏，请先删除对比栏中的部分栏目");
                                    return false;
                                }
                                else {
                                    SetCookie("duibischool", duibischool + schooliddb + ",");
                                }
                            }
                            //2在对比栏中展示
                            duibiLan(schooliddb);
                            //3显示对比栏
                           // $('.duibi').show(200);
                        } else {
                            //1从cookie中取消
                            cancelDuiBi(schooliddb);

                            //2在对比栏中展示的时候，取消该院校
                            //duibiLan(schooliddb);
                            //3显示对比栏
                            $('.duibi').show(200);
                        }
                    });
                    /**点击对比结束**/
                }
            });
        }

        function yxtjshow() {
            var yxz = $.trim($(".yxtjR").html());
            if (yxz == "") {
                $(".yxtj").css("display", "none");
            } else {
                $(".yxtj").css("display", "block");
            }
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

        //取消对比
        function cancelDuiBi(schooliddb) {
            //1删除掉cookie中对应的schoolid
            SetCookie("duibischool", getCookie("duibischool").replace("," + schooliddb + ",", ","));
            //2去除掉选中项
            $(".gx[sid='" + schooliddb + "']").attr("checked", false);
            //3去除掉对比栏中的本栏目
            $(".dbdx[sid='" + schooliddb + "']").remove();

        }

        //写入cookie
        function SetCookie(name, value)//两个参数，一个是cookie的名子，一个是值
        {
            var exp = new Date();
            exp.setTime(exp.getTime() + 4 * 60 * 60 * 1000); //4小时
            document.cookie = name + "=" + value + ";expires=" + exp.toGMTString() + ";path=/;";
        }
        //获取cookie
        function getCookie(name)//取cookies函数        
        {
            var arr = document.cookie.match(new RegExp("(^| )" + name + "=([^;]*)(;|$)"));
            if (arr != null) return unescape(arr[2]); return null;
        }
        //删除cookie
        function delCookie(name)//删除cookie
        {
            var exp = new Date();
            exp.setTime(exp.getTime() - 1);
            var cval = getCookie(name);
            if (cval != null) document.cookie = name + "=" + cval + ";expires=" + exp.toGMTString() + ";path=/;";

            //清除对比栏中的院校
            $(".db").siblings().remove();
            //清除被选中的院校
            $(".gx").attr("checked", false);
        }

        //展示对比栏
        function duibiLan(schooolid) {
            $.ajax({
                url: "/SchoolLibrary/getDuiBiLan.ashx",
                type: "post",
                dataType: "html",
                data: { schoolid: schooolid },
                success: function (html) {
                    $("#duibigo").before(html);
                }
            });
            if (schooolid == "" || schooolid == "0") {
                $('.duibi').hide(200);
            } else {
                $('.duibi').show(200);
            }
        }

        $(function () {

            $('.demo-follow-cursor').poshytip({
                followCursor: false,
                slide: false
            });

        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <gk:Schoolbanner ID="SchoolBanner1" runat="server" BannerWord="格伦高考报考院校库" />
    <gk:Crumb ID="Crumb1" runat="server" NavString=" <span>&gt;</span> 高考报考院校库" />
    <div class="content" style="background: #fff;">
        <div class="contentbody">
            <div class="yxkL" style="width: 1200px;">
                <div class="tiaojian">
                    <asp:HiddenField ID="hidSchoolName" runat="server" />
                    <div class="yxtj" style="display: none;">
                        <div class="yxtjL">
                            已选条件：</div>
                        <div class="yxtjR">
                            <asp:Literal ID="ltlSchoolName" runat="server"></asp:Literal>
                        </div>
                        <div style="clear: both;">
                        </div>
                    </div>
                    <div class="xuanze">
                        <div class="xzbox">
                            <div class="xzboxL">
                                院校特色：</div>
                            <div class="xzboxR xzboxR2">
                                <ul>
                                    <li>
                                        <input type="checkbox" name="" class="che" k="1" value="1" t="211院校" /><a class="demo-follow-cursor" title="211院校，即面向21世纪，在全国范围内重点建设100所左右的高等学校和一批重点学科，简称“211”...<a target='_blank' href='http://gaokao.gelunjiaoyu.com/yx211.shtml' style='color: #1d8cff;text-decoration: underline;'>更多</a>" style="text-decoration: none;color: #000;">211院校</a></li>
                                    <li>
                                        <input type="checkbox" name="" class="che" k="1" value="2" t="985院校" /><a class="demo-follow-cursor" title="985院校是我国政府为建设若干所世界一流大学和一批国际知名的高水平研究型大学而实施的高等教育建设工程...<a target='_blank' href='http://gaokao.gelunjiaoyu.com/yx985.shtml' style='color: #1d8cff;text-decoration: underline;'>更多</a>" style="text-decoration: none;color: #000;">985院校</a></li>
                                    <li>
                                        <input type="checkbox" name="" class="che" k="1" value="3" t="研究生院" /><a class="demo-follow-cursor" title="研究生院是指在承担研究生培养任务的单位中，负责组织实施研究生教育工作的内设部门；②专门承担研究生培养任务的独立机构...<a target='_blank' href='http://gaokao.gelunjiaoyu.com/yxyjs.shtml' style='color: #1d8cff;text-decoration: underline;'>更多</a>" style="text-decoration: none;color: #000;">研究生院</a></li>
                                    <li>
                                        <input type="checkbox" name="" class="che" k="1" value="4" t="自主招生" /><a class="demo-follow-cursor" title="自主招生指符合条件的应届高中毕业生，由本人提出申请，经所在中学和自主招生学校评审后确定名额，高考以后最终确定是否录取...<a target='_blank' href='http://gaokao.gelunjiaoyu.com/yxzzzs.shtml' style='color: #1d8cff;text-decoration: underline;'>更多</a>" style="text-decoration: none;color: #000;">自主招生</a></li>
                                    <li>
                                        <input type="checkbox" name="" class="che" k="1" value="5" t="国防生" /><a class="demo-follow-cursor" title="国防生是指根据部队建设需要，由军队（武警部队）从应届高中毕业生中招收的和从在校大学生中选拔培养的后备军（警）官...<a target='_blank' href='http://gaokao.gelunjiaoyu.com/yxgfs.shtml' style='color: #1d8cff;text-decoration: underline;'>更多</a>" style="text-decoration: none;color: #000;">国防生</a></li>
                                    <li>
                                        <input type="checkbox" name="" class="che" k="1" value="6" t="农村专项" /><a class="demo-follow-cursor" title="农村专项是一项新的普通高校招生政策，又称贫困地区定向招生专项计划...<a target='_blank' href='http://gaokao.gelunjiaoyu.com/yxnczx.shtml' style='color: #1d8cff;text-decoration: underline;'>更多</a>" style="text-decoration: none;color: #000;">农村专项</a></li>
                                    <li>
                                        <input type="checkbox" name="" class="che" k="1" value="7" t="小211工程" /><a class="demo-follow-cursor" title="小211工程是为振兴中西部高等教育，计划重点支持建设中西部高校的发展建设...<a target='_blank' href='http://gaokao.gelunjiaoyu.com/yxx211.shtml' style='color: #1d8cff;text-decoration: underline;'>更多</a>" style="text-decoration: none;color: #000;">小211工程</a></li>
                                    <li>
                                        <input type="checkbox" name="" class="che" k="1" value="8" t="卓越计划" /><a class="demo-follow-cursor" title="卓越计划是贯彻落实《国家中长期教育改革和发展规划纲要》和《国家中长期人才发展规划纲要》的重大改革项目...<a target='_blank' href='http://gaokao.gelunjiaoyu.com/yxzyjh.shtml' style='color: #1d8cff;text-decoration: underline;'>更多</a>" style="text-decoration: none;color: #000;">卓越计划</a></li>
                                    <li>
                                        <input type="checkbox" name="" class="che" k="1" value="9" t="艺术生" /><a class="demo-follow-cursor" title="艺术生是按照所学习的专业特点划分的部分学生人群...<a target='_blank' href='http://gaokao.gelunjiaoyu.com/yxyss.shtml' style='color: #1d8cff;text-decoration: underline;'>更多</a>" style="text-decoration: none;color: #000;">艺术生</a></li>
                                    <li>
                                        <input type="checkbox" name="" class="che" k="1" value="10" t="高水平运动员" /><a class="demo-follow-cursor" title="参加高水平运动员测试的考生应参加其户口所在地省级高校招生委员会办公室（以下简称省级招办）统一组织的高考报名...<a target='_blank' href='http://gaokao.gelunjiaoyu.com/yxydy.shtml' style='color: #1d8cff;text-decoration: underline;'>更多</a>" style="text-decoration: none;color: #000;">高水平运动员</a></li>
                                </ul>
                            </div>
                        </div>
                        <div class="xzbox">
                            <div class="xzboxL">
                                院校层次：</div>
                            <div class="xzboxR">
                                <ul class="cheul">
                                    <li>
                                        <input type="checkbox" name="" class="che" k="2" value="1" t="本科" />
                                        本科 </li>
                                    <li>
                                        <input type="checkbox" name="" class="che" k="2" value="2" t="专科" />
                                        专科 </li>
                                    <li>
                                        <input type="checkbox" name="" class="che" k="3" value="1" t="公办" />
                                        公办 </li>
                                    <li>
                                        <input type="checkbox" name="" class="che" k="3" value="2" t="民办" />
                                        民办 </li>
                                    <li style="width: 90px;">
                                        <input type="checkbox" name="" class="che" k="3" value="3" t="独立院校" />
                                        独立院校 </li>
                                    <li style="width: 110px;">
                                        <input type="checkbox" name="" class="che" k="4" value="1" t="教育部直属" /><a class="demo-follow-cursor" title="我国高校主管部门,可以分为国家教委所属院校、中央各部委所属院校和各省、市属地方院校...<a target='_blank' href='http://gaokao.gelunjiaoyu.com/yxgxzg.shtml' style='color: #1d8cff;text-decoration: underline;'>更多</a>" style="text-decoration: none;color: #000;">教育部直属</a></li>
                                    <li style="width: 110px;">
                                        <input type="checkbox" name="" class="che" k="4" value="2" t="中央部委直属" /><a class="demo-follow-cursor" title="我国高校主管部门,可以分为国家教委所属院校、中央各部委所属院校和各省、市属地方院校...<a target='_blank' href='http://gaokao.gelunjiaoyu.com/yxgxzg.shtml' style='color: #1d8cff;text-decoration: underline;'>更多</a>" style="text-decoration: none;color: #000;">中央部委直属</a></li>
                                    <li style="width: 110px;">
                                        <input type="checkbox" name="" class="che" k="4" value="3" t="其他部委隶属" /><a class="demo-follow-cursor" title="我国高校主管部门,可以分为国家教委所属院校、中央各部委所属院校和各省、市属地方院校...<a target='_blank' href='http://gaokao.gelunjiaoyu.com/yxgxzg.shtml' style='color: #1d8cff;text-decoration: underline;'>更多</a>" style="text-decoration: none;color: #000;">其他部委隶属</a></li>
                                </ul>
                            </div>
                        </div>
                        <div class="xzbox">
                            <div class="xzboxL">
                                院校类型：</div>
                            <div class="xzboxR xzboxR2">
                                <ul class="cheul">
                                    <li>
                                        <input type="checkbox" name="" class="che" k="5" value="1" t="综合类" />综合类</li>
                                    <li>
                                        <input type="checkbox" name="" class="che" k="5" value="2" t="理工类" />理工类</li>
                                    <li>
                                        <input type="checkbox" name="" class="che" k="5" value="3" t="农林类" />农林类</li>
                                    <li>
                                        <input type="checkbox" name="" class="che" k="5" value="4" t="医药类" />医药类</li>
                                    <li>
                                        <input type="checkbox" name="" class="che" k="5" value="5" t="师范类" />师范类</li>
                                    <li>
                                        <input type="checkbox" name="" class="che" k="5" value="6" t="语言类" />语言类</li>
                                    <li>
                                        <input type="checkbox" name="" class="che" k="5" value="7" t="财经类" />财经类</li>
                                    <li>
                                        <input type="checkbox" name="" class="che" k="5" value="8" t="政法类" />政法类</li>
                                    <li>
                                        <input type="checkbox" name="" class="che" k="5" value="9" t="体育类" />体育类</li>
                                    <li>
                                        <input type="checkbox" name="" class="che" k="5" value="10" t="艺术类" />艺术类</li>
                                    <li>
                                        <input type="checkbox" name="" class="che" k="5" value="11" t="民族类" />民族类</li>
                                    <li>
                                        <input type="checkbox" name="" class="che" k="5" value="12" t="军事类" />军事类</li>
                                    <li style="width: 110px;">
                                        <input type="checkbox" name="" class="che" k="5" value="13" t="其他院校类型" />其他院校类型</li>
                                </ul>
                            </div>
                        </div>
                        <div class="xzbox xzboxlast">
                            <div class="xzboxL">
                                院校省份：</div>
                            <div class="xzboxR xzboxR2">
                                <ul class="cheul">
                                    <li>
                                        <input type="checkbox" name="" class="che" k="6" value="1" t="北京" />北京</li>
                                    <li>
                                        <input type="checkbox" name="" class="che" k="6" value="2" t="天津" />天津</li>
                                    <li>
                                        <input type="checkbox" name="" class="che" k="6" value="3" t="河北" />河北</li>
                                    <li>
                                        <input type="checkbox" name="" class="che" k="6" value="4" t="山西" />山西</li>
                                    <li>
                                        <input type="checkbox" name="" class="che" k="6" value="5" t="内蒙古" />内蒙古</li>
                                    <li>
                                        <input type="checkbox" name="" class="che" k="6" value="6" t="辽宁" />辽宁</li>
                                    <li>
                                        <input type="checkbox" name="" class="che" k="6" value="7" t="吉林" />吉林</li>
                                    <li>
                                        <input type="checkbox" name="" class="che" k="6" value="8" t="黑龙江" />黑龙江</li>
                                    <li>
                                        <input type="checkbox" name="" class="che" k="6" value="9" t="上海" />上海</li>
                                    <li>
                                        <input type="checkbox" name="" class="che" k="6" value="10" t="江苏" />江苏</li>
                                    <li>
                                        <input type="checkbox" name="" class="che" k="6" value="11" t="浙江" />浙江</li>
                                    <li>
                                        <input type="checkbox" name="" class="che" k="6" value="12" t="安徽" />安徽</li>
                                    <li>
                                        <input type="checkbox" name="" class="che" k="6" value="13" t="福建" />福建</li>
                                    <li>
                                        <input type="checkbox" name="" class="che" k="6" value="14" t="江西" />江西</li>
                                    <li>
                                        <input type="checkbox" name="" class="che" k="6" value="15" t="山东" />山东</li>
                                    <li>
                                        <input type="checkbox" name="" class="che" k="6" value="16" t="河南" />河南</li>
                                    <li>
                                        <input type="checkbox" name="" class="che" k="6" value="17" t="湖北" />湖北</li>
                                    <li>
                                        <input type="checkbox" name="" class="che" k="6" value="18" t="湖南" />湖南</li>
                                    <li>
                                        <input type="checkbox" name="" class="che" k="6" value="19" t="广东" />广东</li>
                                    <li>
                                        <input type="checkbox" name="" class="che" k="6" value="20" t="广西" />广西</li>
                                    <li>
                                        <input type="checkbox" name="" class="che" k="6" value="21" t="海南" />海南</li>
                                    <li>
                                        <input type="checkbox" name="" class="che" k="6" value="22" t="重庆" />重庆</li>
                                    <li>
                                        <input type="checkbox" name="" class="che" k="6" value="23" t="四川" />四川</li>
                                    <li>
                                        <input type="checkbox" name="" class="che" k="6" value="24" t="贵州" />贵州</li>
                                    <li>
                                        <input type="checkbox" name="" class="che" k="6" value="25" t="云南" />云南</li>
                                    <li>
                                        <input type="checkbox" name="" class="che" k="6" value="26" t="西藏" />西藏</li>
                                    <li>
                                        <input type="checkbox" name="" class="che" k="6" value="27" t="陕西" />陕西</li>
                                    <li>
                                        <input type="checkbox" name="" class="che" k="6" value="28" t="甘肃" />甘肃</li>
                                    <li>
                                        <input type="checkbox" name="" class="che" k="6" value="29" t="青海" />青海</li>
                                    <li>
                                        <input type="checkbox" name="" class="che" k="6" value="30" t="宁夏" />宁夏</li>
                                    <li>
                                        <input type="checkbox" name="" class="che" k="6" value="31" t="新疆" />新疆</li>
                                    <li>
                                        <input type="checkbox" name="" class="che" k="6" value="32" t="港澳台" />港澳台</li>
                                </ul>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="yxtable" name="header_5">
                    <a name="header_5"></a>
                    <table id="lists" width="100%" border="1">
                    </table>
                    <div class="page">
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="content">
    
    <div class="duibi" style="position: fixed;bottom: 0px;margin:0px auto; margin-left:113px; z-index: 99;
        width: 1200px; background-color: #fff; display: none;">
        <div class="duibiTit">
            <ul>
                <li class="cur2"><a href="javascript:void(0);">对比栏</a></li>
            </ul>
            <div id="yincangduibi" style="float: right;">
                <a href="javascript:;" style="color: #005aa0; width: 90px; text-align: right; position: absolute;
                    right: 0; top: 0; padding-right: 22px; height: 30px; line-height: 30px; clear: both">
                    隐藏</a>
            </div>
            <script type="text/javascript">
                $(function () {
                    $("#yincangduibi").click(function () {
                        $('.duibi').hide(200);
                    });
                });
            </script>
        </div>
        <div class="duibicon">
            <div class="duibibox">
                <div class="dbdx db" id="duibigo">
                    <div class="tjdb">
                        <div class="dbbtn">
                            <a target="_blank" href="daxue-duibi.shtml">对比</a></div>
                        <div class="qk">
                            <a href="javascript:delCookie('duibischool');">清空对比栏</a></div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    </div>
    <gk:Footer ID="Footer1" runat="server" />
    </form>
</body>
</html>
