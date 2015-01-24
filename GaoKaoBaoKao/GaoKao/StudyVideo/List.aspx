<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="GaoKao.StudyVideo.List" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>高考学习视频_格伦高考网</title>
    <script src="/js/jquery.js" type="text/javascript"></script>
    <link href="/css/style.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="/js/fancybox/jquery.mousewheel-3.0.4.pack.js"></script>
    <script type="text/javascript" src="/js/fancybox/jquery.fancybox-1.3.4.pack.js"></script>
    <link rel="stylesheet" type="text/css" href="/js/fancybox/jquery.fancybox-1.3.4.css"
        media="screen" />
    <script src="/js/highcharts.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <gk:Schoolbanner ID="SchoolBanner1" BannerWord="学习视频" runat="server" />
    <gk:Crumb ID="Crumb1" NavString=" <span>&gt;</span> <a href='/tuijian/default.aspx'>报考智能规划系统</a> <span>&gt;</span> <a href='List.aspx'>学习视频</a>"
        runat="server" />
   
<div class="content" style="background:#fff;">
<div class="contentbody">
    	<div class="cxTit" style="margin-top:20px;">
        	<div class="cxTitL" style="font-size:30px;">学习视频汇总</div>
        </div>
        
       
        <div class="sphz">
        	<div class="sphzL">
            	<div class="spnavTit">全部课程</div>
            	<ul>
                        <li><a href="List.aspx?xk=2" <%=(xk==2)?" class=\"current\"":"" %>>语文</a></li>
                        <li><a href="List.aspx?xk=3" <%=(xk==3)?" class=\"current\"":"" %>>数学</a></li>
                        <li><a href="List.aspx?xk=4" <%=(xk==4)?" class=\"current\"":"" %>>英语</a></li>
                        <li><a href="List.aspx?xk=8" <%=(xk==8)?" class=\"current\"":"" %>>政治</a></li>
                        <li><a href="List.aspx?xk=9" <%=(xk==9)?" class=\"current\"":"" %>>历史</a></li>
                        <li><a href="List.aspx?xk=10" <%=(xk==10)?" class=\"current\"":"" %>>地理</a></li>
                        <li><a href="List.aspx?xk=5" <%=(xk==5)?" class=\"current\"":"" %>>物理</a></li>
                        <li><a href="List.aspx?xk=6" <%=(xk==6)?" class=\"current\"":"" %>>化学</a></li>
                        <li><a href="List.aspx?xk=7" <%=(xk==7)?" class=\"current\"":"" %>>生物</a></li>
                    </ul>
                </div>
                
         	<div class="xg_list">
            	<ul>
                	
                      <asp:Repeater ID="rp_List" runat="server">
                        <ItemTemplate>
                           <li><a href="show.aspx?xk=<%=xk %>&id=<%#Eval("Id").ToString() %>">
                                        <span><%#Basic.Utils.StrToDateStr(Eval("AddTime").ToString())%></span>■ <%#Eval("Title") %></a></li>
                        </ItemTemplate>
                    </asp:Repeater>    
                	
                </ul>
            </div>
                  
                    <div class="page">
                        <%=strPage %></div>
            </div>
        </div>
    </div>
    <gk:Footer ID="Footer1" runat="server" />
    </form>
</body>
</html>
