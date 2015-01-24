<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="zydb.aspx.cs" Inherits="GaoKao.ChaXun.zydb" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>专业对比查询_格伦高考网</title>
    <link href="/css/style.css" rel="stylesheet" type="text/css" />
    <script src="/js/jquery.js" type="text/javascript"></script>
    <script type="text/javascript" src="/js/fancybox/jquery.mousewheel-3.0.4.pack.js"></script>
    <script type="text/javascript" src="/js/fancybox/jquery.fancybox-1.3.4.pack.js"></script>
    <link rel="stylesheet" type="text/css" href="/js/fancybox/jquery.fancybox-1.3.4.css"
        media="screen" />
    <script src="/js/highcharts.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <gk:Schoolbanner ID="SchoolBanner1" BannerWord="专业对比" runat="server" />
    <gk:Crumb ID="Crumb1" NavString=" <span>&gt;</span> <a href='/tuijian/default.aspx'>报考智能规划系统</a> <span>&gt;</span> <a href='sjcx.aspx'>高考报考数据查询</a> <span>&gt;</span> 专业对比"
        runat="server" />
    <div class="content" style="background: #fff;">
        <div class="contentbody">
            <div class="cxTit" style="margin-top: 30px;">
                <div class="cxTitL">
                    专业录取分数对比查询</div>
            </div>
            <div class="lqdb">
                <ul id="yxdb_tab">
                    <li class="cur"><a href="javascript:;">提档分</a></li>
                    <li><a href="javascript:;">平均分</a></li>
                    <li><a href="javascript:;">批次线差</a></li>
                </ul>
                <input type="hidden" id="cxlb" value="0" />
            </div>
            <script type="text/javascript">
                $(function () {

                    //页面初始化
                    $("#yxdb_tab li:eq(0)").addClass("current").siblings().removeClass("current");
                    getShuJu("0", $("#hidList").val()); //获取数据


                    //顶端切换的处理  考生院校对比
                    $("#yxdb_tab li").click(function () {
                        $(this).addClass("current").siblings().removeClass("current");
                        $("#cxlb").val($(this).index());
                        var cxbl = $("#cxlb").val(); //0提档分、1平均分、2批次线差
                        getShuJu(cxbl, $("#hidList").val()); //获取数据

                    });
                });
            </script>
            <script type="text/javascript">
            $(function () {
                    //页面初始化
                    for (var i = 0; i < 5; i++) {
                        getSchool(1,1,i);
                    }

                    //**********根据省份等信息加载专业列表  begin ***********//
                    function getSchool(yxsfid,pcsl,indexOftdinput) {
                        $.ajax({
                                url: "../ashx/FenShengYuanXiaoLuQu.ashx",
                                type: "get",
                                dataType: "text",
                                data: { yxsfid: yxsfid, sfid: <%=userinfo.ProvinceId %>, pc:  pcsl, kl: <%=userinfo.KeLei %> },
                                success: function (data, textStatus) {
                                    if (data != "") {
                                        $(".cxtable table tr:first td:eq(" + (indexOftdinput+1) + ") .fsxyear:eq(3)").html("<option value=\"0\" k=\"\">--请选择--</option>"+data);
                                    }
                                }
                        });
                    }
                    //**********根据省份等信息加载专业列表  end ***********//


                    //**********根据省份等信息加载院校列表  begin ***********//
                    function getZhuanYe(yxsfid,pcsl,lqyx,indexOftdinput) {
                        $.ajax({
                                url: "../ashx/FenShengZhuanYeLuQu.ashx",
                                type: "get",
                                dataType: "text",
                                data: { yxsfid: yxsfid, sfid: <%=userinfo.ProvinceId %>, pc:  pcsl,lqyx:lqyx, kl: <%=userinfo.KeLei %>,dy:<%=provinceConfig.LatestBenKeZhuanYeYear %> },
                                success: function (data, textStatus) {
                                    if (data != "") {
                                        $(".cxtable table tr:first td:eq(" + (indexOftdinput+1) + ") .fsxyear:eq(4)").html("<option value=\"0\" k=\"\">--请选择--</option>"+data);
                                    }
                                }
                        });
                    }

                    //**********根据省份等信息加载院校列表  end ***********//
                    

                    //**********添加对比  end ***********//
                    //点击添加对比
                    $(".tdinput .cxanniu .cxbtn").click(function () {
                        //获取索引，用来判定，当前操作的是哪一个
                        var indexOfcxbtn = $(this).parent().parent().index();
                        duibiadd(indexOfcxbtn);
                    });
                    //**********添加对比  end ***********//


                    //**********更改选项是，同步更新院校数据  begin ***********//
                    $(".tdinput .fsxyear").live("change",function () {
                        //获取索引，用来判定，当前操作的是哪一个
                        var indexOftd = $(this).parent().parent().index();//获取当前td的索引
                        
                            //层次
                            var cengci=$(".cxtable table tr:first td:eq(" + indexOftd + ") .fsxyear:eq(0)").val();
                          //  alert(cengci);
                            //批次
                            var pcsl=$(".cxtable table tr:first td:eq(" + indexOftd + ") .fsxyear:eq(1)").val();
                           // alert(pcsl);
                            //省份
                            var yxsfid=$(".cxtable table tr:first td:eq(" + indexOftd + ") .fsxyear:eq(2)").val();
                            
                        //获取每一个td中的下拉框的索引，如果是3，说明当前选项是院校名称，这时候去获取专业列表，
                        var indexOffsxyear = $(".cxtable table tr:first td:eq(" + indexOftd + ") .fsxyear").index(this);
                        if (indexOffsxyear<3) {
                            //通过ajax获取院校列表信息
                           getSchool(yxsfid,pcsl,(indexOftd-1));
                        }
                        else if(indexOffsxyear==3){
                        //说明当前选项是院校，这时候需要去调取专业列表
                        
                            //省份
                            var lqyx=$(".cxtable table tr:first td:eq(" + indexOftd + ") .fsxyear:eq(3)").val();
                           getZhuanYe(yxsfid,pcsl,lqyx,(indexOftd-1));
                        }
                    });
                    //**********更改选项是，同步更新院校数据  end ***********//

                    //************取消院校   begin ***********//
                    $(".duibidx .yichu").click(function () {
                        // 1 隐藏院校信息的div，显示筛选条件
                        var _duibidx = $(this).parent().parent();
                        _duibidx.css("display", "none").siblings().css("display", "block");
                        // 2 给当前  td  添加 class='tdinput'
                        _duibidx.parent().addClass("tdinput");

                        // 3 将隐藏域中的该值去掉
                        var indexOfyichu=$(this).parent().parent().parent().index();
                       // alert(indexOfyichu);
                        var schid=_duibidx.attr("s");//获取学校id
                        var zhuanyeid=_duibidx.attr("zyid");//获取专业id
                        var list = $("#hidList").val(); //当前展示的院校id列表   逗号分隔
                        list = list.replace(',' + indexOfyichu + ":" + schid +":"+zhuanyeid+ ',', ',');
                        if(list == ","){
                            list = "";
                        }
                        
                        $("#hidList").val(list);


                        var cxbl = $("#cxlb").val(); //0提档分、1平均分、2批次线差
                        getShuJu(cxbl, list);//获取数据
                    });
                    //************取消院校   end ***********//
                
                //*****************************点击添加对比按钮之后，地区的方法 begin ***********//
                function duibiadd(indexOfcxbtn) {
    
                    //1 获取院校id 并判定是否选择了院校
                    var schoolid = $(".cxtable table tr:first td:eq(" + indexOfcxbtn + ") .fsxyear:eq(3)").val();
                    if (schoolid == 0) {
                        alert("请选择院校");
                        return false;
                    }else{
                        //2 获取专业id 并判定是否选择了专业
                        var professionalid = $(".cxtable table tr:first td:eq(" + indexOfcxbtn + ") .fsxyear:eq(4)").val();
                        if (professionalid == 0) {
                            alert("请选择专业");
                            return false;
                        }else{
                            //3 将当前id添加到隐藏域
                            var sl= indexOfcxbtn + ":" + schoolid + ":" + professionalid + ',';
                            var list = $("#hidList").val();
                            if (list == "") {
                                list = ',' + sl;
                            } else {
                                if (list.indexOf(":" + schoolid + ":" + professionalid + ',') != -1) {
                                    alert('已经添加过该专业了');
                                    return false;
                                }else {
                                    list = list + sl;
                                }
                            }
                        }


                        //4 如果一切正常，此时再获取学校的名称和logo
                        var schoolname = $(".cxtable table tr:first td:eq(" + indexOfcxbtn + ") .fsxyear:eq(3) > option[value='" + schoolid + "']").text();
                        var logo = $(".cxtable table tr:first td:eq(" + indexOfcxbtn + ") .fsxyear:eq(3) > option[value='" + schoolid + "']").attr("k");
                        var professionalname = $(".cxtable table tr:first td:eq(" + indexOfcxbtn + ") .fsxyear:eq(4) > option[value='" + professionalid + "']").text();
                        
                        //5 将院校信息赋值到对比栏中
                        var _duibidx = $(".cxtable table tr:first td:eq(" + indexOfcxbtn + ") .duibidx");
                        _duibidx.attr({"s":schoolid,"zyid":professionalid});
                        //院校图片
                        _duibidx.find("img").attr({ "src": "../logo/" + logo + "", "alt": "" + schoolname + "" });
                        //院校a标签
                        _duibidx.find("a:lt(2)").attr({ "href": "/daxue-jianjie-" + schoolid + ".shtml", "title": "" + schoolname + "" });
                        _duibidx.find("a:eq(1)").text(schoolname);
                        //专业a标签
                        _duibidx.find("a:eq(2)").attr({ "href": "/zhuanye-jianjie-" + professionalid + ".shtml", "title": "" + professionalname + "" });
                        _duibidx.find("a:eq(2)").text(professionalname);

                        //6 显示院校，隐藏筛选条件
                        _duibidx.css("display", "block").siblings().css("display", "none");
                        //7 给当前  td  移除 class='tdinput'
                        _duibidx.parent().removeClass("tdinput");
                        //8 获取当前显示的是哪个分数（0提档分、1平均分，还是 2批次线差），然后调取对应的数据
                        var cxbl=$("#cxlb").val();//0提档分、1平均分、2批次线差
                        getShuJu(cxbl,list);
                        
                        //9 将本院校添加到隐藏域中
                        $("#hidList").val(list);
                    }
                }

                //*****************************点击添加对比按钮之后，地区的方法  end ***********//
                });


                    function getShuJu(cxbl,list) {
                        $.ajax({
                            url: "../ashx/fszydb.ashx",
                            type: "get",
                            dataType: "text",
                            data: { cxbl: cxbl, sidlist:list,sfid: <%=userinfo.ProvinceId %>, kl: <%=userinfo.KeLei %> },
                            success: function (data, textStatus) {
                                if (data != "") {
                                    $("#addTr").html(data);
                                }
                            }
                        });
                    }
            </script>
            <input id="hidList" type="text" style="display: none;" />
            <div class="cxtable">
                <table width="100%" border="1">
                    <tr>
                        <td width="10%">
                            &nbsp;
                        </td>
                        <td width="18%" class="tdinput">
                            <div>
                                录取层次
                                <select class="fsxyear lqcc">
                                    <option value="1">本科</option>
                                    <option value="2">专科</option>
                                </select></div>
                            <div>
                                录取批次
                                <select class="fsxyear lqpc">
                                    <option value="1">第一批</option>
                                    <option value="2">第二批</option>
                                    <option value="3">第三批</option>
                                </select></div>
                            <div>
                                院校省份
                                <select class="fsxyear yxsf">
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
                            </div>
                            <div>
                                院校名称
                                <select class="fsxyear" name="yxmc">
                                    <option value="0">待选择</option>
                                </select></div>
                            <div>
                                专业名称
                                <select class="fsxyear" name="zymc">
                                    <option value="0">待选择</option>
                                </select></div>
                            <div class="cxanniu">
                                <input type="button" class="cxbtn" value="添加对比" /></div>
                            <div class="duibidx" style="display: none;" s="0">
                                <dl>
                                    <dt><a target="_blank" href="daxue-jianjie-583.shtml" title="复旦大学">
                                        <img src="../images/2015zntb/dxlogo.jpg" alt="复旦大学" width="77" height="77" /></a></dt>
                                    <dd>
                                        <a target="_blank" href="" title="大学">大学</a></dd>
                                    <dd>
                                        <a target="_blank" href="" title="专业">专业</a></dd>
                                    <dd class="yichu">
                                        <a href="javascript:;">[移除]</a></dd>
                                </dl>
                            </div>
                        </td>
                        <td width="18%" class="tdinput">
                            <div>
                                录取层次
                                <select class="fsxyear lqcc">
                                    <option value="1">本科</option>
                                    <option value="2">专科</option>
                                </select></div>
                            <div>
                                录取批次
                                <select class="fsxyear lqpc">
                                    <option value="1">第一批</option>
                                    <option value="2">第二批</option>
                                    <option value="3">第三批</option>
                                </select></div>
                            <div>
                                院校省份
                                <select class="fsxyear yxsf">
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
                            </div>
                            <div>
                                院校名称
                                <select class="fsxyear" name="yxmc">
                                    <option value="0">待选择</option>
                                </select></div>
                            <div>
                                专业名称
                                <select class="fsxyear" name="zymc">
                                    <option value="0">待选择</option>
                                </select></div>
                            <div class="cxanniu">
                                <input type="button" class="cxbtn" value="添加对比" /></div>
                            <div class="duibidx" style="display: none;" s="0">
                                <dl>
                                    <dt><a target="_blank" href="daxue-jianjie-583.shtml" title="复旦大学">
                                        <img src="../images/2015zntb/dxlogo.jpg" alt="复旦大学" width="77" height="77" /></a></dt>
                                    <dd>
                                    <dd>
                                        <a target="_blank" href="" title="大学">大学</a></dd>
                                    <dd>
                                        <a target="_blank" href="" title="专业">专业</a></dd>
                                    <dd class="yichu">
                                        <a href="javascript:;">[移除]</a></dd>
                                </dl>
                            </div>
                        </td>
                        <td width="18%" class="tdinput">
                            <div>
                                录取层次
                                <select class="fsxyear lqcc">
                                    <option value="1">本科</option>
                                    <option value="2">专科</option>
                                </select></div>
                            <div>
                                录取批次
                                <select class="fsxyear lqpc">
                                    <option value="1">第一批</option>
                                    <option value="2">第二批</option>
                                    <option value="3">第三批</option>
                                </select></div>
                            <div>
                                院校省份
                                <select class="fsxyear yxsf">
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
                            </div>
                            <div>
                                院校名称
                                <select class="fsxyear" name="yxmc">
                                    <option value="0">待选择</option>
                                </select></div>
                            <div>
                                专业名称
                                <select class="fsxyear" name="zymc">
                                    <option value="0">待选择</option>
                                </select></div>
                            <div class="cxanniu">
                                <input type="button" class="cxbtn" value="添加对比" /></div>
                            <div class="duibidx" style="display: none;" s="0">
                                <dl>
                                    <dt><a target="_blank" href="daxue-jianjie-583.shtml" title="复旦大学">
                                        <img src="../images/2015zntb/dxlogo.jpg" alt="复旦大学" width="77" height="77" /></a></dt>
                                    <dd>
                                        <a target="_blank" href="" title="大学">大学</a></dd>
                                    <dd>
                                        <a target="_blank" href="" title="专业">专业</a></dd>
                                    <dd class="yichu">
                                        <a href="javascript:;">[移除]</a></dd>
                                </dl>
                            </div>
                        </td>
                        <td width="18%" class="tdinput">
                            <div>
                                录取层次
                                <select class="fsxyear lqcc">
                                    <option value="1">本科</option>
                                    <option value="2">专科</option>
                                </select></div>
                            <div>
                                录取批次
                                <select class="fsxyear lqpc">
                                    <option value="1">第一批</option>
                                    <option value="2">第二批</option>
                                    <option value="3">第三批</option>
                                </select></div>
                            <div>
                                院校省份
                                <select class="fsxyear yxsf">
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
                            </div>
                            <div>
                                院校名称
                                <select class="fsxyear" name="yxmc">
                                    <option value="0">待选择</option>
                                </select></div>
                            <div>
                                专业名称
                                <select class="fsxyear" name="zymc">
                                    <option value="0">待选择</option>
                                </select></div>
                            <div class="cxanniu">
                                <input type="button" class="cxbtn" value="添加对比" /></div>
                            <div class="duibidx" style="display: none;" s="0">
                                <dl>
                                    <dt><a target="_blank" href="daxue-jianjie-583.shtml" title="复旦大学">
                                        <img src="../images/2015zntb/dxlogo.jpg" alt="复旦大学" width="77" height="77" /></a></dt>
                                    <dd>
                                        <a target="_blank" href="" title="大学">大学</a></dd>
                                    <dd>
                                        <a target="_blank" href="" title="专业">专业</a></dd>
                                    <dd class="yichu">
                                        <a href="javascript:;">[移除]</a></dd>
                                </dl>
                            </div>
                        </td>
                        <td width="18%" class="tdinput">
                            <div>
                                录取层次
                                <select class="fsxyear lqcc">
                                    <option value="1">本科</option>
                                    <option value="2">专科</option>
                                </select></div>
                            <div>
                                录取批次
                                <select class="fsxyear lqpc">
                                    <option value="1">第一批</option>
                                    <option value="2">第二批</option>
                                    <option value="3">第三批</option>
                                </select></div>
                            <div>
                                院校省份
                                <select class="fsxyear yxsf">
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
                            </div>
                            <div>
                                院校名称
                                <select class="fsxyear" name="yxmc">
                                    <option value="0">待选择</option>
                                </select></div>
                            <div>
                                专业名称
                                <select class="fsxyear" name="zymc">
                                    <option value="0">待选择</option>
                                </select></div>
                            <div class="cxanniu">
                                <input type="button" class="cxbtn" value="添加对比" /></div>
                            <div class="duibidx" style="display: none;" s="0">
                                <dl>
                                    <dt><a target="_blank" href="daxue-jianjie-583.shtml" title="复旦大学">
                                        <img src="../images/2015zntb/dxlogo.jpg" alt="复旦大学" width="77" height="77" /></a></dt>
                                    <dd>
                                        <a target="_blank" href="" title="大学">大学</a></dd>
                                    <dd>
                                        <a target="_blank" href="" title="专业">专业</a></dd>
                                    <dd class="yichu">
                                        <a href="javascript:;">[移除]</a></dd>
                                </dl>
                            </div>
                        </td>
                    </tr>
                    <tbody id="addTr">
                    </tbody>
                </table>
            </div>
            <div class="tjt" id="duibitupian">
            </div>
        </div>
    </div>
    <gk:Footer ID="Footer1" runat="server" />
    </form>
</body>
</html>
