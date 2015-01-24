<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="yxlq.aspx.cs" Inherits="GaoKao.ChaXun.yxlq" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>院校录取去向查询_格伦高考网</title>
    <script src="/js/jquery.js" type="text/javascript"></script>
    <link href="/css/style.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="/js/fancybox/jquery.mousewheel-3.0.4.pack.js"></script>
    <script type="text/javascript" src="/js/fancybox/jquery.fancybox-1.3.4.pack.js"></script>
    <link rel="stylesheet" type="text/css" href="/js/fancybox/jquery.fancybox-1.3.4.css" media="screen" />
    <script src="/js/highcharts.js"></script>
 </head>
<body>
    <form id="form1" runat="server">
    
    <gk:Schoolbanner ID="SchoolBanner1" BannerWord="院校录取去向查询" runat="server" />
    <gk:Crumb ID="Crumb1" NavString=" <span>&gt;</span> <a href='/tuijian/default.aspx'>报考智能规划系统</a> <span>&gt;</span> <a href='sjcx.aspx'>高考报考数据查询</a> <span>&gt;</span> 院校录取去向查询" runat="server" />
    
    <div class="content" style="background:#fff;">
	<div class="contentbody">
    	<div class="cxTit" style="margin-top:30px;">
        	<div class="cxTitL">查询院校录取分数<span><%=userinfo.ProvinceName %> <%=userinfo.KeLeiMingCheng%></span></div>
            <div class="cxTitR">
                 <select class="sel" id="ddl_yxlqcc">
                        <option value="1">本科</option>
                    </select>
                    <select class="sel" id="ddl_yxlqpc">
                        <option value="1">第一批</option>
                        <option value="2">第二批</option>
                        <option value="3">第三批</option>
                    </select>
                    <input type="text" placeholder="请输入院校名称" id="txt_yxlqyx" class="cxtext" />
                    <a href="#" id="btn_yxlq">查询院校录取分数</a>
            </div>
        </div>
        
        <script type="text/javascript">
            $(function () {
                //查询院校录取分数
                $("#btn_yxlq").live("click", function () {
                    var txtValue = $("#txt_yxlqyx").val();

                    if (txtValue == "") {
                        alert("请输入院校名称，然后点击查询。");
                        return;
                    }
                    location.href = "yxlq.aspx?cc=" + $("#ddl_yxlqcc").val() + "&pc=" + $("#ddl_yxlqpc").val() + "&yx=" + txtValue;
                });

            });
        </script>
        
        <div class="cxtable" style="border-top:1px solid #ccc;">
        	<div class="cxtableTit"><span><%=SchoolName %>（<%=userinfo.KeLeiMingCheng%>） <%=CengCiMingCheng%><%=PiCiMingCheng%></span>在<%=userinfo.ProvinceName %>招生分数</div>
            
            <table width="100%" border="1">
              <tr>
                <th width="12%">年份</th>
                <th width="12%">录取最高分</th>
                <th width="12%">录取最小位次</th>
                <th width="13%">录取平均分</th>
                <th width="13%">录取批次线</th>
                <th width="13%">录取平均线差</th>
                <th width="13%">录取平均位次</th>
                <th width="12%">录取人数</th>
              </tr>
              
                <asp:Repeater ID="rpt_List" runat="server">
                <ItemTemplate>
                  <tr>
                    <td><%#Eval("DataYear")%></td>
                    <td><%#Eval("ZuiGaoFen")%></td>
                    <td><%#Eval("ZuiXiaoWeiCi")%></td>
                    <td><%#Eval("PingJunFen")%></td>
                    <td><%#Eval("PiCiXian")%></td>
                    <td><%#Eval("PingJunXianCha")%></td>
                    <td><%#Eval("PingJunWeiCi")%></td>
                    <td><%#Eval("LuQuShu")%></td>
                  </tr>
                </ItemTemplate>
                </asp:Repeater>
              
            </table>
			<div class="cxtableBtm">带*位次为格伦教育根据录取数据统计出来的位次，非考试院公布数据</div>
        </div>
        
        <div class="cxTit">
        	<div class="cxTitL">统计分析图</div>
        </div>
        
        <%=strHighCharts %>
        <div class="tjt" id="duibitu">
        </div>
        
        
    </div>
</div>

    <gk:Footer ID="Footer1" runat="server" />
    </form>
</body>
</html>