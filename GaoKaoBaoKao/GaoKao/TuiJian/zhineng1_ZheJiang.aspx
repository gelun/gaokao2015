<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="zhineng1_ZheJiang.aspx.cs" Inherits="GaoKao.TuiJian.zhineng1_ZheJiang" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>格伦高考智能推荐系统</title>
    <meta name="keywords" content="高考,高考网,高考资源网,高考报考,高考时间,高考作文,高考倒计时" />
    <meta name="description" content="格伦高考网是格伦教育下设八大项目之一,将高考报考与生涯教育完美结合。并为考生提供专业的高考报考卡,从学业规划等角度出发,引导学生更有针对性地填报志愿,为广大高中生和家长提供全面精准的指导。" />
    <script src="/js/jquery.js" type="text/javascript"></script>
    <link href="../css/style.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="/js/fancybox/jquery.mousewheel-3.0.4.pack.js"></script>
    <script type="text/javascript" src="/js/fancybox/jquery.fancybox-1.3.4.pack.js"></script>
    <link rel="stylesheet" type="text/css" href="/js/fancybox/jquery.fancybox-1.3.4.css"
        media="screen" />
    <script src="/js/highcharts.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <gk:Schoolbanner ID="SchoolBanner1" BannerWord="格伦高考报考智能规划" runat="server" />
    <gk:Crumb ID="Crumb1" NavString=" > <a href='/tuijian/default.aspx'>报考系统</a> > 报考智能规划"
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
                    <li>总分1：<span><%=history_zhejiang.ZongFen1%></span></li>
                    <li>总分2：<span><%=history_zhejiang.ZongFen2%></span></li>
                    <li>总分3：<span><%=history_zhejiang.ZongFen3%></span></li>
                    <li>省份：<span><%=userinfo.ProvinceName %></span></li>
                    <li>预计<%=DAL.Common.GetPiCiName(showtishipici, userinfo.ProvinceId)%>录取</li>
                    <li class="xiugai"><a href="/Persional/ChengJiEdit2.aspx">修改成绩</a></li>
                </ul>
            </div>
            <div class="zyblc">
                <ul>
                    <li class="lccur">1、确定批次</li>
                    <li>2、选择院校</li>
                    <li style="background-image: none;">3、选择专业</li>
                </ul>
            </div>
            <div class="bkts" style="display:none;">
                <div class="bktsTit">
                    报考提示</div>
                <div class="bktspm">
                    <div class="pmT">
                        <p>
                            2014年<%=userinfo.ProvinceName %><%=userinfo.KeLeiMingCheng %></p>
                        <img src="../images/2015zntb/line_bg.jpg" width="103" height="4" />
                        <h3>
                            <%=studentChengJi.PiCiMingCheng %>控制线<br />
                            <span>
                                <%=studentChengJi.PiCiXian%></span>分</h3>
                    </div>
                    <div class="pmB">
                        超过<%=studentChengJi.PiCiMingCheng %>线<br />
                        <span>
                            <%=studentChengJi.XianCha%></span>分</div>
                </div>
                <%=strHighCharts%>
                <div class="dbt">
                    <dl>
                        <dt id="duibitu1"></dt>
                        <dd>
                            历年分数线对比</dd>
                    </dl>
                </div>
                <div class="dbt">
                    <dl>
                        <dt id="duibitu2"></dt>
                        <dd>
                            历年同分对应位次对比</dd>
                    </dl>
                </div>
            </div>
            <div class="bkjy">
                <h3>
                    报考建议：</h3>
                <asp:Literal ID="lit_Suggesiton" runat="server"></asp:Literal>
            </div>
            <asp:Repeater ID="rpt_PiCiList" runat="server" OnItemDataBound="rpt_PiCiList_ItemDataBound">
                <ItemTemplate>
                    <asp:Literal ID="lit_PcId" Text='<%#Eval("Id")%>' runat="server" Visible="false"></asp:Literal>
                    <asp:Literal ID="lit_CkFsx" Text='<%#Eval("CkFsx")%>' runat="server" Visible="false"></asp:Literal>
                    <asp:Panel ID="Panel1" runat="server">
                        <div class="zybpc">
                            <div class="pcTit">
                                <%#Eval("PcName")%><%#Eval("PiCi").Equals(showtishipici) ? "<span>重点填报</span>" : ""%></div>
                            <div class="zybpcL">
                                <ul>
                                    <asp:Literal ID="lit_LatestPiCiXianList" runat="server"></asp:Literal>
                                </ul>
                            </div>
                            <div class="zybpcR">
                                <a href='zhineng2.aspx?pcid=<%#Eval("Id")%>'>选择请点击</a>
                            </div>
                        </div>
                    </asp:Panel>
                    <asp:Panel ID="Panel2" runat="server">
                        <div class="zybpc">
                            <div class="pcTit">
                                <%#Eval("PcName")%><%#Eval("PiCi").Equals(showtishipici) ? "<span>重点填报</span>" : ""%>
                                <asp:Literal ID="lit_LatestPiCiXian" runat="server"></asp:Literal>
                                <div class="rtReSel">
                                    <a href='zhineng2.aspx?pcid=<%#Eval("Id")%>'>重新选报</a></div>
                            </div>
                            <div class="zybpcTable">
                                <table border="1" width="100%">
                                    <asp:Literal ID="lit_ProvinceZhiYuan" runat="server"></asp:Literal>
                                </table>
                            </div>
                        </div>
                    </asp:Panel>
                </ItemTemplate>
            </asp:Repeater>
            <div class="zybpc">
                <h3>
                    重要提示：</h3>
                <p>
                    1、本系统提供高考志愿填报智能模拟功能，不等同于实际的网上填报志愿，仅作志愿填报参考；</p>
                <p>
                    2、本系统协助考生筛选学校并科学填报志愿，但我们不对实际录取结果提供担保；</p>
                <p>
                    3、您可以按系统的重点填报提示选择适合自己的批次模拟，也可直接选择自己关注的批次模拟；</p>
                <p>
                    4、志愿填报智能模拟系统使用指南。</p>
            </div>
        </div>
    </div>
    <gk:Footer ID="Footer1" runat="server" />
    </form>
</body>
</html>
