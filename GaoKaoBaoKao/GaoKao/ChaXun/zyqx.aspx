<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="zyqx.aspx.cs" Inherits="GaoKao.ChaXun.zyqx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>考生专业录取去向查询_格伦教育网</title>    
    <script src="/js/jquery.js" type="text/javascript"></script>
    <link href="/css/style.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="/js/fancybox/jquery.mousewheel-3.0.4.pack.js"></script>
    <script type="text/javascript" src="/js/fancybox/jquery.fancybox-1.3.4.pack.js"></script>
    <link rel="stylesheet" type="text/css" href="/js/fancybox/jquery.fancybox-1.3.4.css" media="screen" />
    <script src="/js/highcharts.js"></script>
 </head>
<body>
    <form id="form1" runat="server">
    
    <gk:Schoolbanner ID="SchoolBanner1" BannerWord="专业去向查询" runat="server" />
    <gk:Crumb ID="Crumb1" NavString=" <span>&gt;</span> <a href='/tuijian/default.aspx'>报考智能规划系统</a> <span>&gt;</span> <a href='sjcx.aspx'>高考报考数据查询</a> <span>&gt;</span> 专业去向查询" runat="server" />
    
<div class="content" style="background:#fff;">
	<div class="contentbody">
    	<div class="cxTit" style="margin-top:20px;">
        	<div class="cxTitL">考生专业录取去向查询<span><%=userinfo.ProvinceName %> <%=userinfo.KeLeiMingCheng%></span></div>
        </div>
        
        <div class="lqdb" style="margin-top:30px;">
        	<ul id="zylq_tab">
            	<li class="current"><a href="#">按分数查询</a></li>
                <li><a href="#">按线差查询</a></li>
                <li><a href="#">按位次查询</a></li>
            </ul>

            
            <div class="cxTitR" style="margin-top:0;">
                 
                    <input type="text" class="qujian" value=""  id="txt_zytabdiv" style="display:none;" />
                    <select class="sel" id="ddl_zyqxcc">
                        <option value="1">本科</option>
                    </select>
                    <select class="sel" id="ddl_zyqxnf">
                        <option value="2013">2013年</option>
                        <option value="2012">2012年</option>
                        <option value="2011">2011年</option>
                        <option value="2010">2010年</option>
                    </select>
                    
                    <select class="sel" id="ddl_zyqxpc">
                        <option value="1">第一批</option>
                        <option value="2">第二批</option>
                        <option value="3">第三批</option>
                    </select>
                    
                    <span class="zytabdiv">
                    <input type="text" value="" placeholder="分数"  id="txt_zyqxfs1"  class="cxtext" style="width:60px;"/><span>到</span><input type="text"
                        value="" placeholder="分数"  id="txt_zyqxfs2"  class="cxtext" style="width:60px;"/>
                    </span>
                    <span class="zytabdiv" style="display: none;"><input type="text" value=""  id="txt_zyqxxc" placeholder="线差" style="width:90px;" class="cxtext" /></span>
                    <span class="zytabdiv" style="display: none;"><input type="text" value="" id="txt_zyqxwc" placeholder="位次" style="width:90px;" class="cxtext" /></span>
                    <a href="#" id="btn_zyqx">专业去向查询</a>
            </div>

        </div>
        
        <div class="cxtable">
        <div class="cxtableTit"><span><%=DataYear %>年</span> <%=userinfo.ProvinceName %><%=userinfo.KeLeiMingCheng%>考生<span><%=strTypeTitle %></span>在<%=CengCiMingCheng%><%=PiCiMingCheng%>去向查询</div>
        
        
        <script type="text/javascript">
            $(function () {
                //顶端切换的处理
                $("#zylq_tab li:eq(<%= gl_Lx%>)").addClass("current").siblings().removeClass("current");
                Tab('zytabdiv', <%= gl_Lx%>);

                //考生专业录取去向查询
                $("#zylq_tab li").click(function () {
                    $(this).addClass("current").siblings().removeClass("current");
                    var index = $(this).index();
                    Tab('zytabdiv', index);
                });

                /*切换*/
                function Tab(classname, index) {
                    switch (index) {
                        case 0:
                            $("." + classname + ":eq(0)").show();
                            $("." + classname + ":gt(0)").hide();
                            break;
                        case 1:
                            $("." + classname + ":eq(1)").show();
                            $("." + classname + ":eq(0)").hide();
                            $("." + classname + ":eq(2)").hide();
                            break;
                        case 2:
                            $("." + classname + ":eq(2)").show();
                            $("." + classname + ":lt(2)").hide();
                            break;
                        default:
                            break;
                    }
                    $("#txt_" + classname).val(index);
                }

                //////////提交按钮的处理
                //考生专业录取去向查询
                $("#btn_zyqx").live("click", function () {
                    var zyqxlx = $("#txt_zytabdiv").val();
                    if (zyqxlx == "0") {
                        var txtValue1 = $("#txt_zyqxfs1").val();
                        var txtValue2 = $("#txt_zyqxfs2").val();
                        if (txtValue1 == "" || txtValue1 == "") {
                            alert("请输入分数区间，然后点击查询。");
                            return;
                        }
                        location.href = "zyqx.aspx?lx=0&cc=" + $("#ddl_zyqxcc").val() + "&pc=" + $("#ddl_zyqxpc").val() + "&nf=" + $("#ddl_zyqxnf").val() + "&fs1=" + txtValue1 + "&fs2=" + txtValue2;
                    }
                    else if (zyqxlx == "1") {
                        var txtValue = $("#txt_zyqxxc").val();
                        if (txtValue == "") {
                            alert("请输入线差，然后点击查询。");
                            return;
                        }
                        location.href = "zyqx.aspx?lx=1&cc=" + $("#ddl_zyqxcc").val() + "&pc=" + $("#ddl_zyqxpc").val() + "&nf=" + $("#ddl_zyqxnf").val() + "&xc=" + txtValue;
                    }
                    else if (zyqxlx == "2") {
                        var txtValue = $("#txt_zyqxwc").val();
                        if (txtValue == "") {
                            alert("请输入位次，然后点击查询。");
                            return;
                        }
                        location.href = "zyqx.aspx?lx=2&cc=" + $("#ddl_zyqxcc").val() + "&pc=" + $("#ddl_zyqxpc").val() + "&nf=" + $("#ddl_zyqxnf").val() + "&wc=" + txtValue;
                    }
                });
            });
        </script>
        <div class="cxTit" style="height:30px; line-height:30px; margin-bottom:5px;">
        </div>
        
        <%=strHighCharts %>
        <div class="tjt" style="height:460px;">
        	<div class="tjtL" style="margin-left:0;">
                <div class="tjthalf" id="dqtjt"></div><span>按地区统计</span>
            </div>
            <div class="tjtL">
                <div class="tjthalf" id="yxtjt"></div><span>按专业统计</span>
            </div>
        </div>
        
        
        <div class="cxTit">
        	<div class="cxTitL">录取数据展示</div>
        </div>
        <table width="100%" border="1">
          <tr>
            <th width="18%">院校名称</th>
            <th width="18%">专业名称</th>
            <th width="10%">院校省份</th>
            <th width="9%">分数</th>
            <th width="9%">位次</th>
            <th width="9%">批次线</th>
            <th width="9%">线差</th>
            <th width="9%">院校录取总数</th>
            <th width="9%">此区间总人数</th>
          </tr>
          <asp:Repeater ID="rpt_List" runat="server" OnItemDataBound="rpt_List_ItemDataBound" >
                <ItemTemplate>
                  <tr>
                    <td><%#Eval("YuanXiaoMingCheng")%></td>
                    <td><%#Eval("ZhuanYeMingCheng")%></td>
                    <td><%#Eval("SchoolProvinceName")%></td>
                    <td><%#Eval("FenShu")%></td>
                    <td><%#Eval("WeiCi")%></td>
                    <td><%#Eval("PiCiXian")%></td>
                    <td><%#Eval("PiCiXianCha")%></td>
                    <td><asp:Literal ID="lit_SchoolId" Text='<%#Eval("SchoolId")%>' runat="server" Visible="false"></asp:Literal><asp:Literal ID="lit_ZongRenShu" runat="server"></asp:Literal></td>
                    <td><asp:Literal ID="lit_QuJianZongRenShu" runat="server"></asp:Literal></td>
                  </tr>
                </ItemTemplate>
                </asp:Repeater>
        </table>
        <div class="cxtableBtm">带*位次为格伦教育根据录取数据统计出来的位次，非考试院公布数据</div>
        

        </div>
        
        
    </div>
</div>


    <gk:Footer ID="Footer1" runat="server" />
    </form>
</body>
</html>
