<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="zhineng2_ZheJiang.aspx.cs"
    Inherits="GaoKao.TuiJian.zhineng2_ZheJiang" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>报考智能推荐_格伦高考网</title>
    <script src="../js/jquery.js" type="text/javascript"></script>
    <script src="../js/jquery.cookie.js" type="text/javascript"></script>
    <link href="../css/style.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="/js/fancybox/jquery.mousewheel-3.0.4.pack.js"></script>
    <script type="text/javascript" src="/js/fancybox/jquery.fancybox-1.3.4.pack.js"></script>
    <link rel="stylesheet" type="text/css" href="/js/fancybox/jquery.fancybox-1.3.4.css"
        media="screen" />
    <script type="text/javascript">
        $(document).ready(function () {
            //************选择专业的时候，弹出对应的弹出框  begin  ************//
            $("#zysx").fancybox({
                'overlayColor': '#000',
                'overlayOpacity': 0.5,
                'transitionIn': 'elastic',
                'transitionOut': 'elastic'
            });
            //************选择专业的时候，弹出对应的弹出框  end  ************//
            $(".fb").live("click", function () {
                $.fancybox({
                    'width': '95%',
                    'height': '95%',
                    'autoScale': true,
                    'href': $(this).attr('href'),
                    'transitionIn': 'none',
                    'transitionOut': 'none',
                    'type': 'iframe'
                });
                return false;
            });
        })

    </script>
    <script type="text/javascript">

        function pageshow() {
            yxtjshow(); //已选条件的展示与否的处理
            getList(); //ajax获取院校列表数据
        }
        //************ 删除已选项  begin  ************//
        function del(k, v) {
            $(".yxtjR a[k='" + k + "'][v='" + v + "']").remove();

            if (k == 7) {//删除的是院校
                //删除隐藏域中的该院校
                var hidSchool = $("#hidSchoolName").val();
                hidSchool = hidSchool.replace(("," + v + ","), ",");
                if (hidSchool == ",") {
                    hidSchool = "";
                }
                $("#hidSchoolName").val(hidSchool);
            } else if (k == 8) {//删除专业
                //删除隐藏域中的该专业
                var hidZhuanYe = $("#hidZhuanYe").val();
                hidZhuanYe = hidZhuanYe.replace(("," + v + ","), ",");
                if (hidZhuanYe == ",") {
                    hidZhuanYe = "";
                }
                $("#hidZhuanYe").val(hidZhuanYe);
                $("#ProfessionalSelect option[value='" + v + "']").remove();
            } else {
                $("input[k='" + k + "'][value=" + v + "]").attr("checked", false); //取消选中项
            }
            pageshow(); //页面数据处理
        }
        //************ 删除已选项  end  ************//
    </script>
    <script type="text/javascript">
        $(function () {
            //页面加载时候
            pageshow(); //页面数据处理



            //**************************************** 点击筛选条件的时候触发的事件  begin **********************************//

            // 单个属性全选  ： 1 院校特色  2 院校层次  3 院校性质  4 院校隶属   5 院校类型   6 院校省份   7 报考风险
            $(".che").live("click",function () {
            

                    var k = $(this).attr("k"); //k 表示 1 院校特色  2 院校层次  3 院校性质  4 院校隶属   5 院校类型   6 院校省份   7 报考风险
                    var val = $(this).val(); //value值
                    var t = $(this).attr("t"); //展示的文本

                    //没有全选按钮  所有的value值都是  大于 0  的；如果不大于0  说明 页面是有问题的
                    if (val > 0) {//设定 checkbox 的选择 与否
                        if ($(this).attr("checked") == "checked") {//选中当前项
                            //已选条件 那一栏 处理
                            $(".yxtjR").append("<a href=\"javascript:del(" + k + "," + val + ");\" k=\"" + k + "\" v=\"" + val + "\">" + t + "<span>X</span></a>");
                        } else {//取消选中项

                            //已选条件 那一栏 处理
                            $(".yxtjR a[k='" + k + "'][v='" + val + "']").remove();
                        }
                    } else {
                        alert("error");
                        return false;
                    }

                    pageshow(); //页面数据处理 
            });
            //**************************************** 点击筛选条件的时候触发的事件  end **********************************//

            //**************************************** 选择院校  begin **********************************//
            $("#yxsx").click(function () {
                var yxyx = $("#yxmc").val();
                if (yxyx != "") {
                    var hidSchool = $("#hidSchoolName").val();
                    if (hidSchool == "") {
                        hidSchool = "," + yxyx + ",";
                    } else {
                        if (hidSchool.indexOf("," + yxyx + ",") != -1) {//已存在
                            //已存在就不用搭理他了
                            alert("已经选择过该院校了");
                            return false;
                        } else {//未存在
                            hidSchool = hidSchool + yxyx + ",";
                        }
                    }

                    // 1 添加到隐藏域 hidSchoolName 中
                    $("#hidSchoolName").val(hidSchool);
                    
                    // 2 添加到已选择条件中去
                    $(".yxtjR").append("<a href=\"javascript:del(7,'" + yxyx + "');\" k=\"7\" v=\"" + yxyx + "\">" + yxyx + "<span>X</span></a>");

                    // 3 已选条件 栏  显示或者隐藏

                    pageshow(); //页面数据处理

                    // 4 去除文本框中的数据
                    $("#yxmc").val("");

                } else {
                    alert("请输入院校名称");
                    return false;
                }
            });
            //**************************************** 选择院校  end **********************************//



        });


        //******************** 已选条件的展示与否的处理  begin **************//
        function yxtjshow() {
            var yxz = $.trim($(".yxtjR").html());
            if (yxz == "") {
                $(".yxtj").css("display", "none");
            } else {
                $(".yxtj").css("display", "block");
            }
        }
        //******************** 已选条件的展示与否的处理  begin **************//


        //******************** ajax获取院校列表  begin **************//
        function getList() {
            $.ajax({
                url: "GetSchoolList_ZheJiang.ashx",
                type: "post",
                dataType: "html",
                data: { fenshu:<%=ZongFen %>,weici:<%=infoProvinceWeiCi.WeiCi %>,StudentId:<%=userinfo.StudentId %>,StudentKeLei:<%=userinfo.KeLei %>,StudentPiCi:<%=provincePiCi.PiCi %>,StudentPcLeiBie:<%=provincePiCi.PcLeiBie %>,schoolname: $("#hidSchoolName").val(),zhuanye:$("#hidZhuanYe").val(), tese: getCheckList(1), cengci: getCheckList(2), xingzhi: getCheckList(3), belong: getCheckList(4), leixing: getCheckList(5), province: getCheckList(6),fengxian:getCheckList(9), p: 1 },
                success: function (html) {
                    $("#lists").html(html);


                    var len = $(".chuangkou .ckbody table tr").length;
                    if (len > 1) {
                           
                        for (var i = 1; i < len; i++) {
                            var SchoolId = $(".chuangkou .ckbody table tr:eq(" + i + ")").attr("sid");
                            $(".gx[sid="+SchoolId+"]").attr("checked",true);
                        }
                    }

                    var tjc=0;

                    $(".che[k='9']").each(function () {
                        if ($(this).attr("checked") == "checked"){
                            tjc+=1;
                            $("#lists tr[tuijian='"+$(this).val()+"']").show();
                        }else {
                            $("#lists tr[tuijian='"+$(this).val()+"']").hide();
                        }
                    });

                    if (tjc==0) {
                        $("#lists tr").show();
                    }


                }
            });
        }
        //******************** ajax获取院校列表  begin **************//


        //******************** 获取筛选条件（院校特色、省份、类型、层次、风险等）中被选中的项  begin **************//
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
        //******************** 获取筛选条件（院校特色、省份、类型、层次、风险等）中被选中的项  end **************//

    </script>
</head>
<body>
    <form id="form1" runat="server">
    <gk:Schoolbanner ID="SchoolBanner1" BannerWord="格伦高考报考智能规划" runat="server" />
    <gk:Crumb ID="Crumb1" NavString=" <span>&gt;</span> <a href='/tuijian/default.aspx'>报考系统</a> <span>&gt;</span> 报考智能规划"
        runat="server" />
    <div class="content" style="background: #fff;">
        <div class="contentbody">
            <div class="cxTit" style="margin-top: 20px;">
                <div class="cxTitL">
                    报考智能规划系统</div>
            </div>
            <div class="zyblist">
                <ul>
                    <li>您的高考成绩</li>
                    <li>科类：<span><%=userinfo.KeLeiMingCheng %></span></li>
                    <li>总分：<span><%=ZongFen %></span></li>
                    <li>累计人数：<span><%=infoProvinceWeiCi.LeiJiRenShu %></span></li>
                    <li>同分人数：<span><%=infoProvinceWeiCi.RenShu %></span></li>
                    <li>省份：<span><%=userinfo.ProvinceName %></span></li>
                    <li>预计<%=DAL.Common.GetPiCiName(provincePiCi.PiCi, userinfo.ProvinceId) %>录取</li>
                    <li class="xiugai"><a href="/Persional/ChengJiEdit2.aspx">修改成绩</a></li>
                </ul>
            </div>
            <div class="zyblc">
                <ul>
                    <li class="lccurf">1、确定批次</li>
                    <li class="lccur">2、选择院校</li>
                    <li style="background-image: none;">3、选择专业</li>
                </ul>
            </div>
            <div class="tiaojian">
                <asp:HiddenField ID="hidSchoolName" runat="server" />
                <asp:HiddenField ID="hidZhuanYe" runat="server" />
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
                                    <input type="checkbox" name="" class="che" k="1" value="1" t="211院校" />211院校</li>
                                <li>
                                    <input type="checkbox" name="" class="che" k="1" value="2" t="985院校" />985院校</li>
                                <li>
                                    <input type="checkbox" name="" class="che" k="1" value="3" t="研究生院" />研究生院</li>
                                <li>
                                    <input type="checkbox" name="" class="che" k="1" value="4" t="自主招生" />自主招生</li>
                                <li>
                                    <input type="checkbox" name="" class="che" k="1" value="5" t="国防生" />国防生</li>
                                <li>
                                    <input type="checkbox" name="" class="che" k="1" value="6" t="农村专项" />农村专项</li>
                                <li>
                                    <input type="checkbox" name="" class="che" k="1" value="7" t="小211工程" />小211工程</li>
                                <li>
                                    <input type="checkbox" name="" class="che" k="1" value="8" t="卓越计划" />卓越计划</li>
                                <li>
                                    <input type="checkbox" name="" class="che" k="1" value="9" t="艺术生" />艺术生</li>
                                <li>
                                    <input type="checkbox" name="" class="che" k="1" value="10" t="高水平运动员" />高水平运动员</li>
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
                                    <input type="checkbox" name="" class="che" k="4" value="1" t="教育部直属" />教育部直属</li>
                                <li style="width: 110px;">
                                    <input type="checkbox" name="" class="che" k="4" value="2" t="中央部委直属" />中央部委直属</li>
                                <li style="width: 110px;">
                                    <input type="checkbox" name="" class="che" k="4" value="3" t="其他部委隶属" />其他部委隶属</li>
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
                                <li style="width: 86px;">
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
                    <div class="xzbox">
                        <div class="xzboxL">
                            指定院校：</div>
                        <div class="zdyx">
                            <input name="yxmc" id="yxmc" class="cxtext" placeholder="请输入院校名称" />
                            <strong><a id="yxsx" href="javascript:;">我要选择</a></strong></div>
                        <script type="text/javascript">
                            jQuery(function ($) {
                                $.getAutoComplete('/SchoolLibrary/autocomplete_School.ashx', 'yxmc');
                            });
                        </script>
                    </div>
                    <div class="xzbox">
                        <div class="xzboxL">
                            指定专业：</div>
                        <div class="zdyx">
                            <strong><a id="zysx" href="#zysxdiv">我要选择</a></strong></div>
                    </div>
                    <div class="xzbox" style="border-bottom: 0;">
                        <div class="xzboxL">
                            报考风险：</div>
                        <div class="xzboxR" style="width: 1050px;">
                            <ul class="cheul">
                                <li style="width: 210px;">
                                    <input type="checkbox" name="" class="che" k="9" value="1" t="有风险" />有风险（几乎无录取的可能）</li>
                                <li style="width: 210px;">
                                    <input type="checkbox" name="" class="che" k="9" value="2" t="冲一冲" />冲一冲（录取概率约15%）</li>
                                <li style="width: 210px;">
                                    <input type="checkbox" name="" class="che" k="9" value="3" t="稳一稳" />稳一稳（录取概率约60%）</li>
                                <li style="width: 210px;">
                                    <input type="checkbox" name="" class="che" k="9" value="4" t="保一保" />保一保（录取概率约80%）</li>
                                <li style="width: 210px;">
                                    <input type="checkbox" name="" class="che" k="9" value="5" t="垫一垫" />垫一垫（录取概率约90%）</li>
                            </ul>
                        </div>
                    </div>
                </div>
            </div>
            <div class="bkjy" style="width: 1183px; margin-left: 0;">
                <h3>
                    报考建议：</h3>
                <asp:Literal ID="lit_Suggestion" runat="server"></asp:Literal>
            </div>
            <div class="zybpc" style="width: 1200px; padding: 0;">
                <div class="zybpcTable">
                    <table id="lists" width="100%" border="1">
                    </table>
                </div>
                <input id="yxbzhs" type="hidden" value="0" />
                <script type="text/javascript">
                    ///////////////////////////////////////////   选报院校   //////////////////////////////////////
                    $(function () {
                        $(".gx").live("click", function () {
                        
                            var idx = $(".gx").index(this); //索引号
                            var schoolid = $(this).parent().parent().parent().find("td:eq(1)").attr("sid"); //学校id
                            var schoolname = $(this).parent().parent().parent().find("td:eq(1)").attr("sn"); //学校名称
                            var tuijian = $.trim($(this).parent().parent().parent().find("td:eq(7)").html()); //报考推荐
                            
                            if ($(".gx").eq(idx).attr("checked") == "checked") { //选报
                                
                                var len = $("#yxbzhs").val();
                            
                                if (len >= <%=intZhiYuanCount %>) {
                                    alert("已经达到了最大志愿数");
                                    return false;
                                } else {
                                   var yxbzhs= $("#yxbzhs").val()*1+1;
                                   $("#yxbzhs").val(yxbzhs);

                                   var _tr=$(".chuangkou .ckbody table tr:eq("+yxbzhs+")");
                                   var _td1=_tr.find("td:eq(1)");
                                   var _td2=_tr.find("td:eq(2)");
                                   var _td3=_tr.find("td:eq(3)");

                                   _tr.attr("sid",schoolid);
                                   _td1.attr("sid", schoolid);
                                   _td1.attr("sn",schoolname);
                                   _td1.html(schoolname + "<span onclick=\"DelSchool(this," + schoolid + ");\"><a href=\"javascript:;\">x</a></span><img src=\"/images/2015zntb/jtT.jpg\" class=\"up\" onclick=\"SelectUp(this);\"><img src=\"/images/2015zntb/jtB.jpg\" class=\"down\" onclick=\"SelectDown(this);\">");

                                   _td2.html(tuijian);

                                    //$(".chuangkou .ckbody table").append("<tr sid=\"" + schoolid + "\"><td>" + zhiyuanming + "</td><td sid=\"" + schoolid + "\" sn=\"" + schoolname + "\">" + schoolname + "<span onclick=\"DelSchool(this," + schoolid + ");\"><a href=\"javascript:;\">x</a></span><img src=\"/images/2015zntb/jtT.jpg\" class=\"up\" onclick=\"SelectUp(this);\"><img src=\"/images/2015zntb/jtB.jpg\" class=\"down\" onclick=\"SelectDown(this);\"></td><td>" + tuijian + "</td><td></td></tr>");    
                                    
                                }
                            } else {//取消选报
                                var _tr=$(".chuangkou .ckbody table tr[sid=\"" + schoolid + "\"]");//将要被删除的行
                               
                                delzhiyuan(_tr);
                            }

                            //如果当前选中院校是隐藏的，将其展示
                            if ($(".ckbody").css("display") == "none") {
                                Up(); //
                            }
                        });

                    });
                    // 向上移动
                    function SelectUp(obth) {
                        var len = $(".up").length;
                        var idx = $(".up").index(obth);
                        if (idx == 0) {
                            alert("已经是第一个了");
                            return false;
                        } else {
                            var insertOjb = $(obth).parent().parent();
                            var obj = insertOjb.index();
                            $(".chuangkou .ckbody table tr:eq(" + (obj - 1) + ")").insertAfter(insertOjb);

                            //志愿名称的处理
                            var t1 = $(obth).parent().prev().text(); //当前元素的志愿名称
                            var t2 = $(obth).parent().parent().next().find("td:eq(0)").text(); //下面的那个元素
                            $(obth).parent().prev().text(t2);
                            $(obth).parent().parent().next().find("td:eq(0)").text(t1);
                            
                            //推荐风险程度的处理
                            var fxcd1 = $(obth).parent().next().next().html(); //当前元素的推荐风险程度
                            var fxcd2 = $(obth).parent().parent().next().find("td:last").html(); //下面的那个元素
                            $(obth).parent().next().next().html(fxcd2);
                            $(obth).parent().parent().next().find("td:last").html(fxcd1);
                        }
                    }

                    //向下移动
                    function SelectDown(obth) {
                        var len = $(".down").length;
                        var idx = $(".down").index(obth);

                        if (idx == len - 1) {
                            alert("已经是最后一个了");
                            return false;
                        } else {
                            var insertOjb = $(obth).parent().parent();
                            var obj = insertOjb.index();
                            $(".chuangkou .ckbody table tr:eq(" + (obj) + ")").insertAfter(insertOjb.next());

                            //志愿名称的处理
                            var t1 = $(obth).parent().prev().text(); //当前元素的志愿名称
                            var t2 = $(obth).parent().parent().prev().find("td:eq(0)").text(); //下面的那个元素
                            $(obth).parent().prev().text(t2);
                            $(obth).parent().parent().prev().find("td:eq(0)").text(t1);

                            //推荐风险程度的处理
                            var fxcd1 = $(obth).parent().next().next().html(); //当前元素的推荐风险程度
                            var fxcd2 = $(obth).parent().parent().prev().find("td:last").html(); //下面的那个元素
                            $(obth).parent().next().next().html(fxcd2);
                            $(obth).parent().parent().prev().find("td:last").html(fxcd1);
                        }
                    }
                    //删除已选择院校
                    function DelSchool(obth, schoolid) {
                        var _tr = $(obth).parent().parent();
                        delzhiyuan(_tr);

                        $(".gx[sid='" + schoolid + "']").attr("checked", false);
                    }

                    //删除已选择志愿院校
                    function delzhiyuan(_tr) {
                        _tr.removeAttr("sid");
//                        _tr.find("td:gt(0)").each(function (index) {//循环清空数据
//                             $(this).text("");
//                        });
                        _tr.find("td:eq(1)").text("");
                        _tr.find("td:eq(2)").text("");
                        _tr.find("td:eq(1)").removeAttr("sid").removeAttr("sn");
                        
                        if(_tr.index() < <%=intZhiYuanCount %>)
                        {
                            var _lasttr=$(".chuangkou .ckbody table tr:last");//最后一行

                            //删除之前，获取每个志愿的名称
                            var arr=new Array(<%=intZhiYuanCount %>);
                            var arrSug=new Array(<%=intZhiYuanCount %>);
                            for (var i = 0; i < arr.length; i++) {
                                arr[i]=$(".chuangkou .ckbody table tr:eq("+(i+1)+")").find("td:eq(0)").text();//每一行的志愿名称
                                arrSug[i]=$(".chuangkou .ckbody table tr:eq("+(i+1)+")").find("td:eq(3)").html();//每一行的建议志愿
                            }

                            //将被删除行插入到最后一行之后
                            _tr.insertAfter(_lasttr);
                                
                            for (var i = 0; i < arr.length; i++) {
                                $(".chuangkou .ckbody table tr:eq("+(i+1)+")").find("td:eq(0)").text(arr[i]);//每一行的志愿名称
                                $(".chuangkou .ckbody table tr:eq("+(i+1)+")").find("td:eq(3)").html(arrSug[i]);//每一行的志愿名称
                            }
                        }

                        var yxbzhs= $("#yxbzhs").val();
                        if (yxbzhs>0) {
                            $("#yxbzhs").val((yxbzhs*1-1));
                        }
                    }

                    //确认提交
                    function goNext() {
                        var len =  $("#yxbzhs").val();
                        if (len <= 0) {
                            alert("请至少选择一所院校");
                            return false;
                        } else {
                            var SchoolIdList = "";
                            for (var i = 1; i <= len; i++) {
                                SchoolIdList += $(".chuangkou .ckbody table tr:eq(" + i + ")").attr("sid") + ",";
                            }
                            if (SchoolIdList != "") {
                                $("#yxbzhs").val("0");//页面即将跳转，清除隐藏域中的值
                                location.href = "zhineng3.aspx?pcid=<%=ProvincePiCiId %>&schoollist=" + SchoolIdList;
                            } else {
                                alert("请至少选择一所院校");
                                return false;
                            }
                        }
                    }
                </script>
            </div>
            <div class="zybpc">
                <h3>
                    特别提示：</h3>
                <p class="zybp">
                    为解决同一高校专业间因学费标准差别较大带来的专业生源不均问题，为提高投档的有效性，有针对性地提供考生分类选报志愿，部分高校招生按学费标准将本校较高学费专业单独列出为一类，集中排列在本校普通类专业之后。类似情况还有，少数高校将护理学类专业、医学类专业单独列出为一类。考生根据自己成绩和家庭经济状况选报高校相应类别的专业，在同一高校志愿栏只能选择其中一类专业，不能跨类选择专业，同意专业调剂的只在所报专业类内进行；考生需报同一高校不同类别专业的，需占用另外的高校志愿栏。也就是说，如考生愿意报考同一所院校普通类、高收费类和护理类（医学类）专业，应填写三个院校志愿。</p>
                <p class="zybp" style="color: #ff5800;">
                    本系统在报考风险推荐时，是按照院校的招生代码进行风险推荐提示，未按照不同类别进行细分。请各考生根据各省考试院公布的最新招生计划，根据每个专业的录取情况进行有针对性的选报。</p>
            </div>
        </div>
    </div>
    <!---专业的筛选--->
    <div style="display: none;">
        <div class="shaixuan" id="zysxdiv">
            <h3>
                按学科门类筛选：</h3>
            <div class="sxul">
                <ul>
                    <li class="cur" v="0"><a href="javascript:;" v="0">全选</a></li>
                    <li v="1"><a href="javascript:;" v="1">哲学</a></li>
                    <li v="6"><a href="javascript:;" v="6">经济学</a></li>
                    <li v="21"><a href="javascript:;" v="21">法学</a></li>
                    <li v="41"><a href="javascript:;" v="41">教育学</a></li>
                    <li v="57"><a href="javascript:;" v="57">文学</a></li>
                    <li v="133"><a href="javascript:;" v="133">历史学</a></li>
                    <li v="139"><a href="javascript:;" v="139">理学</a></li>
                    <li v="180"><a href="javascript:;" v="180">工学</a></li>
                    <li v="316"><a href="javascript:;" v="316">农学</a></li>
                    <li v="342"><a href="javascript:;" v="342">医学</a></li>
                    <li v="380"><a href="javascript:;" v="380">管理学</a></li>
                    <li v="422"><a href="javascript:;" v="422">艺术学</a></li>
                </ul>
            </div>
            <h3>
                按名称筛选：</h3>
            <div class="sxul">
                <input type="text" class="sxultext" placeholder="请输入专业名字" />
                <input id="selZhuanYe" type="button" value="查询" />
            </div>
            <div class="sxdaxue">
                <div class="sxdaxueTit">
                    共 <span>20</span> 个专业</div>
                <div class="sxdxbox">
                    <div class="sxdxboxL">
                        <select id="LeftProfessionalList" size="4" name="leftListBox" multiple="multiple"
                            class="bigSborder" style="height: 225px; width: 100%;">
                        </select>
                    </div>
                    <div class="sxdxboxC">
                        <ul>
                            <li>>>></li>
                            <li><<<</li>
                            <li>清空</li>
                        </ul>
                    </div>
                    <div class="sxdxboxL">
                        <select id="ProfessionalSelect" size="4" name="leftListBox" multiple="multiple" class="bigSborder"
                            style="height: 225px; width: 100%;">
                        </select>
                    </div>
                </div>
                <div class="ctrl">
                    按住ctrl可进行多选</div>
            </div>
            <div class="sxbtn">
                <a href="javascript:;">提交</a></div>
        </div>
        <script type="text/javascript">

            //**************************根据条件获取获取专业列表  begin  ******************//
            function getProfessional(xkml, zyn) {
                $.ajax({
                    url: "getProfessionalList.ashx",
                    type: "get",
                    data: { xkml: xkml, zyn: zyn },
                    success: function (data) {
                        if (data != "") {
                            var dataObj = eval("(" + data + ")"); //转换为json对象 

                            var zycount = dataObj.zhuanye.length;
                            $(".sxdaxue .sxdaxueTit span").text(zycount);

                            var ObjHtml = "";
                            $.each(dataObj.zhuanye, function (idx, item) {
                                ObjHtml += "<option value=\"" + item.Id + "\">" + item.ProfessionalName + "</option>";
                            });

                            $("#LeftProfessionalList").html(ObjHtml);
                        }
                    }
                });
            }
            //**************************根据条件获取获取专业列表  end  ******************//


            $(function () {
                //********点击选择专业按钮时加载专业数据 begin *********//
                $("#zysx").click(function () {
                    getProfessional(0, '');

                    //加载已经选中过的专业
                    var hidZhuanYe = $("#hidZhuanYe").val();
                    if (hidZhuanYe != "") {
                        var arr = new Array();
                        arr = hidZhuanYe.split(',');
                        for (var i = 0; i < arr.length; i++) {
                            if (arr[i] != "") {
                                $("#ProfessionalSelect").append("<option value=\"" + arr[i] + "\">" + $(".yxtjR a[k='8'][v='" + arr[i] + "']").text().replace("X", "") + "</option>");
                            }
                        }
                    }
                });
                //*******点击选择专业按钮时加载专业数据 end ***********//


                //*******点击学科门类时加载专业数据 begin *********//
                $("#zysxdiv .sxul:eq(0) li").click(function () {
                    $(this).addClass("cur").siblings().removeClass("cur");

                    var xkml = $(this).attr("v"); //学科门类
                    var sxultext = $(".sxultext").val(); //专业名称

                    getProfessional(xkml, sxultext);
                });
                //*******点击学科门类时加载专业数据 end *********//


                //*******点击按专业查询时加载专业数据 begin *********//
                $("#selZhuanYe").click(function () {
                    var xkml = $("#zysxdiv .sxul:eq(0) li[class='cur']").attr("v"); //学科门类
                    var sxultext = $(".sxultext").val(); //专业名称
                    getProfessional(xkml, sxultext);
                });
                //*******点击按专业查询时加载专业数据 end *********//



                //**************************************** 专业左右调动及清空  begin **********************************//
                $(".sxdxboxC li").click(function () {
                    var index = $(this).index();
                    switch (index) {
                        case 0: //从左向右
                            var checklist = $("#LeftProfessionalList").val();
                            for (var i = 0; i < checklist.length; i++) {

                                if ($("#ProfessionalSelect option[value='" + checklist[i] + "']").text() == "") {
                                    var text = $("#LeftProfessionalList option[value='" + checklist[i] + "']").text();
                                    $("#LeftProfessionalList option[value='" + checklist[i] + "']").remove();
                                    $("#ProfessionalSelect").append("<option value=\"" + checklist[i] + "\">" + text + "</option>");
                                } else {
                                    alert("已选择过该专业");
                                    return false;
                                }
                            }
                            break;
                        case 1: //从右向左
                            var checklist = $("#ProfessionalSelect").val();
                            for (var i = 0; i < checklist.length; i++) {
                                var text = $("#ProfessionalSelect option[value='" + checklist[i] + "']").text();
                                $("#ProfessionalSelect option[value='" + checklist[i] + "']").remove();
                                $("#LeftProfessionalList option:eq(0)").before("<option value=\"" + checklist[i] + "\">" + text + "</option>");
                            }
                            break;
                        case 2: //清空
                            $("#ProfessionalSelect option").remove();
                            break;
                    }

                });
                //**************************************** 专业左右调动及清空  end **********************************//



                //******************点击提交按钮  begin  ****************//
                $(".sxbtn").click(function () {
                    var zyList = "";
                    var yxtjrlist = "";
                    $("#ProfessionalSelect option").each(function () {
                        if ($(this) != null) {
                            zyList += $(this).val() + ",";

                            //写入已选择条件栏中
                            yxtjrlist += "<a href=\"javascript:del(8,'" + $(this).val() + "');\" k=\"8\" v=\"" + $(this).val() + "\">" + $(this).text() + "<span>X</span></a>";
                        }
                    });
                    if (zyList != "") {
                        zyList = "," + zyList;

                        $(".yxtjR a[k='8']").remove();
                        $(".yxtjR").append(yxtjrlist);
                    }

                    $("#hidZhuanYe").val(zyList);
                    if ($("#hidZhuanYe").val() == "") {
                        alert('请至少选择一个专业')
                        return false;
                    } else {
                        //正常处理

                        // 1 页面数据处理
                        pageshow();
                        // 2 去除文本框中的数据、学科门类恢复默认情况
                        $("#zysxdiv .sxul:eq(0) li:eq(0)").addClass("cur").siblings().removeClass("cur");
                        $(".sxultext").val("");
                        // 3 清除右侧
                        $("#ProfessionalSelect option").remove();

                        // 4 隐藏掉选中专业的这个弹出层
                        $.fancybox.close();


                    }
                });
                //******************点击提交按钮  end  ****************//
            });
        </script>
    </div>
    <div class="chuangkou">
        <script type="text/javascript">
            $(function () {
                //向下关闭
                $('.close').click(function () {
                    Down();
                });
                //向上展示
                $('.open').click(function () {
                    Up();
                });
            });

            function Up() {
                $('.ckbody').slideDown(80);
                $('.open').slideUp(80);
                $('.close').slideDown(80);
            }

            function Down() {
                $('.ckbody').slideUp(80);
                $('.open').slideDown(80);
                $('.close').slideUp(80);
            }
        </script>
        <div class="ckul">
            <ul>
                <li class="close" style="display: none;"><a href="javascript:void(0);">向下关闭</a></li>
                <li class="open"><a href="javascript:void(0);">向上展示</a></li>
            </ul>
        </div>
        <div class="ckbody" style="display: none;">
            <div class="zyb3Table">
                <table border="1" width="95%">
                    <tbody>
                        <tr>
                            <th width="16%">
                                志愿
                            </th>
                            <th width="30%">
                                院校名称
                            </th>
                            <th width="22%">
                                风险程度
                            </th>
                            <th width="22%">
                                推荐风险程度
                            </th>
                        </tr>
                        <asp:Literal ID="ltlZhiYuanList" runat="server"></asp:Literal>
                    </tbody>
                </table>
                <div class="zybbtn" onclick="goNext();">
                    <a href="javascript:;">确定，下一步</a></div>
            </div>
        </div>
    </div>
    <gk:Footer ID="Footer1" runat="server" />
    </form>
</body>
</html>
