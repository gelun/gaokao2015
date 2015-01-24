<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="zhineng3_ZheJiang.aspx.cs" Inherits="GaoKao.TuiJian.zhineng3_ZheJiang" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>格伦高考网_高考资源网_高考报考_高考时间_高考作文_高考倒计时_格伦教育网</title>
    <meta name="keywords" content="高考,高考网,高考资源网,高考报考,高考时间,高考作文,高考倒计时" />
    <meta name="description" content="格伦高考网是格伦教育下设八大项目之一,将高考报考与生涯教育完美结合。并为考生提供专业的高考报考卡,从学业规划等角度出发,引导学生更有针对性地填报志愿,为广大高中生和家长提供全面精准的指导。" />
    <script src="/js/jquery.js" type="text/javascript"></script>
    <link href="/css/style.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="/js/fancybox/jquery.mousewheel-3.0.4.pack.js"></script>
    <script type="text/javascript" src="/js/fancybox/jquery.fancybox-1.3.4.pack.js"></script>
    <link rel="stylesheet" type="text/css" href="/js/fancybox/jquery.fancybox-1.3.4.css" media="screen" />
</head>
<body>
    <form id="form1" runat="server">
    <gk:Schoolbanner ID="SchoolBanner1" BannerWord="格伦高考报考智能规划" runat="server" />
    <gk:Crumb ID="Crumb1" NavString=" > <a href='/tuijian/default.aspx'>报考系统</a> > 报考智能规划" runat="server" />
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
                    <li>1、确定批次</li>
                    <li class="lccurf">2、选择院校</li>
                    <li class="lccur" style="background-image: none;">3、选择专业</li>
                </ul>
            </div>
            <script type="text/javascript">
                $(function () {
                    $(".pingxingTit").click(function () {
                        var content = $(this).next(); //内容
                        var pxright = $(this).find(".pxright"); //收缩  展示

                        if (content.css("display") == "none") {//隐藏
                            content.slideDown(100).parent().siblings().find(".pingxingbox").slideUp(100); //内容的隐藏域展示

                            pxright.removeClass('zhanshi').addClass('shouqi'); //
                            pxright.find("a").text('收缩');
                            $(this).parent().siblings().find(".pingxingTit").find(".pxright").removeClass('shouqi').addClass('zhanshi'); //
                            $(this).parent().siblings().find(".pingxingTit").find(".pxright").find("a").text('展示');
                        } else {
                            //                            $(this).find(".pxright");
                            pxright.removeClass('shouqi').addClass('zhanshi'); //
                            pxright.find("a").text('展示');
                            content.slideUp(100); 
                        }
                    });


                    $(".fb").fancybox({
                        'width': '95%',
                        'height': '95%',
                        'autoScale': false,
                        'transitionIn': 'none',
                        'transitionOut': 'none',
                        'type': 'iframe'
                    });
                });
			
            </script>
            <asp:Repeater ID="rptList" runat="server" OnItemDataBound="rptList_ItemDataBound">
                <ItemTemplate>
                    <div class="pingxing">
                        <div class="pingxingTit" style="cursor: pointer;">
                            <div class="px">
                                <%#this.GetZhiYuanMing(Container.ItemIndex) %></div>
                            <div class="daxue">
                                <%#Eval("SchoolName") %></div>
                            <div class="pxright <%#Container.ItemIndex==0 ? "shouqi" : "zhanshi" %>">
                                <a href="javascript:void(0);">
                                    <%#Container.ItemIndex == 0 ? "收缩" : "展示"%></a></div>
                        </div>
                        <div class="pingxingbox" <%#Container.ItemIndex == 0 ? "" : " style=\"display:none;\""%>>
                            <div class="pxjy">
                                此院校风险为 “冲一冲”，本志愿建议填报风险为 “冲一冲”层次以下院校</div>
                            <p>
                                以下展示的是该院校<%=provinceConfig.LatestBenKeYear%>年录取专业信息，请参考，真实填报时，请参考本年度招生计划。</p>
                            <div class="pxtable">
                                <table width="100%" border="1">
                                    <tr sid='<%#Eval("Id") %>'>
                                        <th width="15%">
                                            &nbsp;
                                        </th>
                                        <th width="14%">
                                            专业名称
                                        </th>
                                        <%if (userinfo.ProvinceId != 11)
                                          { %>
                                        <th width="14%">
                                            录取最高分
                                        </th>
                                        <th width="14%">
                                            录取最低分
                                        </th>
                                        <th width="14%">
                                            录取平均分
                                        </th>
                                        <%}
                                          else
                                          { %>
                                          
                                        <th width="42%">
                                            录取平均分
                                        </th>
                                        <%} %>
                                        <th width="14%">
                                            录取人数
                                        </th>
                                        <th width="15%">
                                            &nbsp;
                                        </th>
                                    </tr>
                                    <asp:Repeater ID="rptList" runat="server">
                                        <ItemTemplate>
                                            <tr>
                                                <td>
                                                    <a href="/TuiJian/data_zy.aspx?schoolid=<%#Eval("SchoolId") %>&pici=<%=provincePiCi.PiCi %>&zyid=<%#Eval("ZhuanYeId") %>"  class="fb">历年分数线</a>
                                                </td>
                                                <td zyid="<%#Eval("ZhuanYeId") %>">
                                                    <%#Eval("ZhuanYeName")%>
                                                    <%if (userinfo.ProvinceId == 10)
                                                      { %>
                                                      <%#Eval("BeiZhu")%>
                                                    <%} %>
                                                </td>
                                                
                                        <%if (userinfo.ProvinceId != 11)
                                          { %>
                                                <td>
                                                    <%#Eval("ZuiGaoFen")%>
                                                </td>
                                                <td>
                                                    <%#Eval("ZuiDiFen")%>
                                                </td>
                                                <%} %>
                                                <td>
                                                    <%#Eval("PingJunFen")%>
                                                </td>
                                                <td>
                                                    <%#Eval("LuQuRenShu")%>
                                                </td>
                                                <td>
                                                    <div class="gouxuan">
                                                        <input class="gx" type="checkbox" sid='<%#Eval("SchoolId") %>' zyid="<%#Eval("ZhuanYeId") %>"><span>选报</span></div>
                                                </td>
                                            </tr>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </table>
                            </div>
                            <div class="jiantou">
                            </div>
                            <div class="xzzy">
                                <div class="xzzyTit">
                                    已选择专业</div>
                                <div class="xzzybox" sid='<%#Eval("Id") %>'>
                                    <ul>
                                    </ul>
                                </div>
                                <div class="xzzybtm">
                                    <input type="checkbox" checked="checked" class="xytj" sid='<%#Eval("Id") %>' />允许调剂
                                </div>
                            </div>
                            <div style="clear: both;">
                            </div>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
            <script type="text/javascript">
                $(function () {
                    $(".xzzy .xzzybox ul li").live("click", function () {
                        var sid = $(this).attr("sid"); //学校id
                        if ($(this).hasClass("on")) {
                            //已经被选中过了
                        } else {
                            //设置为选中状态
                            var text = "<img src=\"../images/2015zntb/lijtB.jpg\" onclick='downzhuanye(this)' /><img src=\"../images/2015zntb/lijtT.jpg\" onclick='upzhuanye(this)' />"
                            + "<span onclick=\"delzhuanye(this);\"><a href=\"javascript:;\">x</a></span>";


                            $(this).addClass("on").siblings().removeClass("on");
                            $(this).siblings().each(function () {
                                if ($(this).attr("zyname") != $.trim($(this).text())) {
                                    $(this).text($(this).attr("zyname"));
                                }
                            });
                            $(this).html($(this).text() + text);
                        }
                    });
                });

                // 向上移动
                function upzhuanye(obth) {
                    var _li = $(obth).parent();
                    var _ul = $(obth).parent().parent();
                    var len = _ul.find("li").length;

                    var idx = _ul.find("li").index(_li);
                    // alert(len + " " + idx);
                    if (idx == 0) {
                        alert("已经是第一个了");
                        return false;
                    } else {
                        //1 调整页面左侧的顺序]
                        _li.insertBefore(_li.prev());
                        //2 调整页面底部的顺序
                        var _td = $(".zyb3Table tr[sid=" + _li.attr("sid") + "] td[zyid=" + _li.attr("zyid") + "]");
                        _td.insertBefore(_td.prev());
                    }
                }
                // 向下移动
                function downzhuanye(obth) {
                    var _li = $(obth).parent();
                    var _ul = $(obth).parent().parent();
                    var len = _ul.find("li").length;

                    var idx = _ul.find("li").index(_li);
                    if (idx == (len - 1)) {
                        alert("已经是最后一个了");
                        return false;
                    } else {
                        var sid = _li.attr("sid");
                        var zyid = _li.attr("zyid");

                        // 1 调整页面左侧的顺序
                        _li.insertAfter(_li.next());
                        // 2 调整页面底部的顺序
                        var _td = $(".zyb3Table tr[sid=" + sid + "] td[zyid=" + zyid + "]");

                        _td.insertAfter(_td.next());
                    }
                }

                // 删除
                function delzhuanye(obth) {
                    var _li = $(obth).parent();
                    var sid = _li.attr("sid");
                    var zyid = _li.attr("zyid");

                    //1 删除页面左侧的数据
                    $("input[type='checkbox'][sid=" + sid + "][zyid=" + zyid + "]").attr("checked", false);

                    var _li = $(obth).parent().remove();

                    //2 删除页面底部的数据
                    var _td = $(".zyb3Table tr[sid=" + sid + "] td[zyid=" + zyid + "]");
                    _td.text("");
                    _td.removeAttr("zyid", "");
                    _td.insertBefore($(".zyb3Table tr[sid=" + sid + "] td:last"));
                }

            </script>
            <script type="text/javascript">
                $(function () {
                    ///////////////////////////////////////////   选报专业   //////////////////////////////////////
                    $(".gx").live("click", function () {
                        var idx = $(".gx").index(this); //索引号
                        var schoolid = $(this).parent().parent().parent().parent().find("tr:eq(0)").attr("sid");
                        var zhuanyeid = $(this).parent().parent().parent().find("td:eq(1)").attr("zyid"); //专业id
                        var zhuanyename = $.trim($(this).parent().parent().parent().find("td:eq(1)").text()); //专业名称


                        if ($(".gx").eq(idx).attr("checked") == "checked") { //选报

                            var len = $(".xzzybox[sid=" + schoolid + "] ul li").length;
                            if (len < <%=intZhiYuanCount %>) {
                                //1 添加到  志愿左侧 "已选择专业"
                                $(".xzzybox[sid=" + schoolid + "] ul").append("<li sid=" + schoolid + " zyid=" + zhuanyeid + " zyname=" + zhuanyename + ">" + zhuanyename + "</li>");
                                //2 添加到  页面底部  填报院校专业表格中
                                //(1)通过左侧的个数，判定在底部表格中应该添加到第几列
                                var _td = $(".zyb3Table tr[sid=" + schoolid + "] td:eq(" + (len + 2) + ")");
                                _td.text(zhuanyename);
                                _td.attr("zyid", zhuanyeid);
                            }
                            else {
                                alert("本志愿已经达到允许填报专业的上限");
                                return false;
                            }
                        } else {//取消选报
                            $(".xzzybox[sid=" + schoolid + "] ul li[sid=\"" + schoolid + "\"][zyid=" + zhuanyeid + "]").remove();
                            var _td = $(".zyb3Table tr[sid=" + schoolid + "] td[zyid=" + zhuanyeid + "]");
                            _td.text("");
                            _td.removeAttr("zyid", "");

                            _td.insertBefore($(".zyb3Table tr[sid=" + schoolid + "] td:last"));
                        }

                        //如果当前选中院校是隐藏的，将其展示
                        if ($(".ckbody").css("display") == "none") {
                            Up(); //
                        }

                    });
                    ///////////////////////////////////////////   选报专业   //////////////////////////////////////

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
                    }
                }
            </script>
            <div class="zybpc" style="margin-top: 30px;">
                <h3>
                    特别提示：</h3>
                <p class="zybp">
                    为解决同一高校专业间因学费标准差别较大带来的专业生源不均问题，为提高投档的有效性，有针对性地提供考生分类选报志愿，部分高校招生按学费标准将本校较高学费专业单独列出为一类，集中排列在本校普通类专业之后。类似情况还有，少数高校将护理学类专业、医学类专业单独列出为一类。考生根据自己成绩和家庭经济状况选报高校相应类别的专业，在同一高校志愿栏只能选择其中一类专业，不能跨类选择专业，同意专业调剂的只在所报专业类内进行；考生需报同一高校不同类别专业的，需占用另外的高校志愿栏。也就是说，如考生愿意报考同一所院校普通类、高收费类和护理类（医学类）专业，应填写三个院校志愿。</p>
                <p class="zybp" style="color: #ff5800;">
                    本系统在报考风险推荐时，是按照院校的招生代码进行风险推荐提示，未按照不同类别进行细分。请各考生根据各省考试院公布的最新招生计划，根据每个专业的录取情况进行有针对性的选报。</p>
            </div>
        </div>
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
            <div class="zyb3Table" style="width: 1200px;">
                <table border="1" width="95%">
                    <tbody>
                        <asp:Literal ID="ltlZhiYuanList" runat="server"></asp:Literal>
                    </tbody>
                </table>
                <div class="btn_div">
                    <asp:Button ID="btnSave" runat="server" Text="确定，保存" class="zybbtn" OnClick="btnSave_Click"
                        OnClientClick="javascript:return save();" />
                </div>
                <%-- <div class="zybbtn" onclick="save();">
                    <a href="javascript:;">确定，下一步</a></div>--%>
                <asp:HiddenField ID="hidZhiYuan" runat="server" />
                <script type="text/javascript">
                    function save() {//////////保存志愿

                        var b = false;

                        var list = ""; //{pczyid:11,schoolid:11,,schoolname:清华,zyid:11,zyname:fsdf,zyid:11,zyname:fsdf,tj:1}
                        $(".zyb3Table tr:gt(0)").each(function () {
                            var schoolid = $(this).attr("sid"); //学校id
                            var schoolname = $(this).attr("sn"); //学校名称
                            var pczyid = $(this).attr("pczyid"); //志愿id

                            if (pczyid > 0 && schoolid > 0 && schoolname != "") {

                                var xbzylist = "";
                                //拼接选报的专业
                                var xuanbaozhuanyecount = 0;
                                $(this).find("td:gt(0)").each(function () {

                                    var zhuanyeid = $(this).attr("zyid"); //专业id
                                    var zhuanyename = $.trim($(this).text()); //专业名称

                                    if (zhuanyeid > 0 && zhuanyename != "") {
                                        xuanbaozhuanyecount += 1;
                                        b = true;
                                        xbzylist += ",zyid:" + zhuanyeid + ",zyname:" + zhuanyename;
                                    }
                                });
                                if (xbzylist != "") {

                                    list += "{";
                                    list += "pczyid:" + pczyid;
                                    list += ",schoolid:" + schoolid; //学校id
                                    list += ",schoolname:" + schoolname; //学校名称

                                    list += xbzylist; //所报专业

                                    //是否选择了本院校全部的专业
                                    var schoolzhuanyecount = $(".gx[sid=" + schoolid + "]").length;
                                    if (xuanbaozhuanyecount == schoolzhuanyecount) {
                                        list += ",isallmajor:1";
                                    } else {
                                        list += ",isallmajor:0";
                                    }

                                    //是否调剂
                                    var tj = $(this).find("td:last").find("input[type='checkbox']").attr("checked");
                                    if (tj == "checked") {
                                        list += ",tj:1";
                                    } else {
                                        list += ",tj:0";
                                    }

                                    list += "},";

                                }
                            }
                        });


                        if (b == true) {
                            $("#hidZhiYuan").val(list);
                            return true;
                        } else {
                            alert("请选报专业");
                            return false;
                        }
                    }


                    $(function () {
                        $(".xytj").live("click", function () {
                            var sid = $(this).attr("sid");
                            if ($(this).attr("checked") == "checked") {
                                $(".xytj[sid='" + sid + "']").attr("checked", true);
                            } else {
                                $(".xytj[sid='" + sid + "']").attr("checked", false);
                            }
                        });
                    });
                </script>
            </div>
        </div>
    </div>
    <gk:Footer ID="Footer1" runat="server" />
    </form>
</body>
</html>
