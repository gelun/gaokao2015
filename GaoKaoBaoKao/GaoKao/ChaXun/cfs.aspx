<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="cfs.aspx.cs" Inherits="GaoKao.ChaXun.cfs" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>高考报考数据查询_格伦高考网</title>
    <script src="/js/jquery.js" type="text/javascript"></script>
    <link href="/css/style.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="/js/fancybox/jquery.mousewheel-3.0.4.pack.js"></script>
    <script type="text/javascript" src="/js/fancybox/jquery.fancybox-1.3.4.pack.js"></script>
    <link rel="stylesheet" type="text/css" href="/js/fancybox/jquery.fancybox-1.3.4.css" media="screen" />
    <script src="/js/highcharts.js"></script>
 </head>
<body>
    <form id="form1" runat="server">
    <gk:Schoolbanner ID="SchoolBanner1" BannerWord="根据位次查分数" runat="server" />
    <gk:Crumb ID="Crumb1" NavString=" <span>&gt;</span> <a href='/tuijian/default.aspx'>报考智能规划系统</a> <span>&gt;</span> <a href='sjcx.aspx'>高考报考数据查询</a> <span>&gt;</span> 根据位次查分数" runat="server" />
    
<div class="content" style="background:#fff;">
	<div class="contentbody">
    	<div class="cxTit" style="margin-top:30px;">
        	<div class="cxTitL">根据位次查分数<span><%=userinfo.ProvinceName %> <%=userinfo.KeLeiMingCheng%></span></div>
            <div class="cxTitR">位次<input type="text" style="width:90px;" class="cxtext" id="txt_wc" /><a href="#" id="btn_cfs">查分数</a>
            </div>
        </div>
        <script type="text/javascript">
            $(function () {

                //根据位次查分数
                $("#btn_cfs").live("click", function () {
                    var txtValue = $("#txt_wc").val();

                    if (txtValue == "") {
                        alert("请输入分数，然后点击查询位次。");
                        return;
                    }
                    location.href = "cfs.aspx?wc=" + txtValue;
                });

            });
    </script>
        
        <div class="cxtable" style="border-top:1px solid #ccc;">
        	<div class="cxtableTit"><span><%=glWeiCi%>位次</span>在<span><%=userinfo.ProvinceName %> <%=userinfo.KeLeiMingCheng%></span>历年对应的高考分数</div>
            
            
            <table width="100%" border="1">
              <tr>
                <th width="14%">省份</th>
                <th width="14%">科类</th>
                <th width="14%">年份</th>
                <th width="14%">分数</th>
                <th width="14%">位次</th>
                <th width="15%">累计人数</th>
                <th width="15%">本省同分人数</th>
              </tr>
              
                <asp:Repeater ID="rpt_List" runat="server">
                <ItemTemplate>
                  <tr>
                    <td><%=userinfo.ProvinceName %></td>
                    <td><%=userinfo.KeLeiMingCheng%></td>
                    <td><%#Eval("DataYear")%></td>
                    <td><%#Eval("FenShu")%></td>
                    <td><%#Eval("WeiCi")%><%# Eval("IsKaoShiYuan").Equals("0") ? "" : "*"%></td>
                    <td><%#Eval("LeiJiRenShu")%></td>
                    <td><%#Eval("RenShu")%></td>
                  </tr>
                </ItemTemplate>
                </asp:Repeater>
            </table>

            
            
            
			<div class="cxtableBtm">
                带*位次为格伦教育根据录取数据统计出来的位次，比原始数据偏小，非考试院公布数据<br />
                位次概念有两种，本网站以同分人员，位次相同的概念进行展示和描述
            </div>
        </div>
        
        <div class="cxTit">
        	<div class="cxTitL">统计分析图</div>
        </div>
        
        <%=strHighCharts %>
        <div class="tjt" id="duibitu"></div>
        
        
    </div>
</div>

    <gk:Footer ID="Footer1" runat="server" />
    </form>
</body>
</html>
