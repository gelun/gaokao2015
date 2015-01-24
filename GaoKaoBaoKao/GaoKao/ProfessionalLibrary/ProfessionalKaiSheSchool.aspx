<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProfessionalKaiSheSchool.aspx.cs"
    Inherits="GaoKao.ProfessionalLibrary.ProfessionalKaiSheSchool" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>
        <%=strProfessionalName%>专业开设院校_高考报考专业库_格伦高考网</title>
    <meta name="keywords" content="<%=strProfessionalName%>,开设院校,高考报考,格伦高考网" />
    <script src="/js/jquery.js" type="text/javascript"></script>
    <link href="/css/style.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <gk:ProfessionalBanner ID="ProfessionalBanner1" runat="server" BannerWord="格伦高考报考专业库" />
    <gk:Crumb ID="Crumb1" runat="server" />
    <div class="zycontent">
        <div class="zycontentbody">
            <gk:ProfessionalLeft ID="ProfessionalLeft1" runat="server" Index="2" />
            <div class="zyconR">
                <gk:ProfessionalBase ID="ProfessionalBase1" runat="server" />
                <div class="conRbox">
                    <div class="conRtit">
                        开设院校</div>
                    <div class="kemu">
                        <div class="kemutit">
                            华北地区<span>（包括北京、天津、河北、山西、内蒙古）</span></div>
                        <div class="kemuul">
                            <ul>
                                <asp:Repeater ID="Repeater4" runat="server">
                                    <ItemTemplate>
                                        <li p="<%#Eval("SchoolProvinceId") %>"><a href="/daxue-jianjie-<%#Eval("SchoolId") %>.shtml"
                                            title="<%#Eval("YuanXiaoMingCheng") %>">
                                            <%#Eval("YuanXiaoMingCheng")%></a></li>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </ul>
                        </div>
                    </div>
                    <div class="kemu">
                        <div class="kemutit">
                            华东地区<span>（包括山东、江苏、安徽、浙江、福建、上海）</span></div>
                        <div class="kemuul">
                            <ul>
                                <asp:Repeater ID="Repeater1" runat="server">
                                    <ItemTemplate>
                                        <li p="<%#Eval("SchoolProvinceId") %>"><a href="/daxue-jianjie-<%#Eval("SchoolId") %>.shtml"
                                            title="<%#Eval("YuanXiaoMingCheng") %>">
                                            <%#Eval("YuanXiaoMingCheng")%></a></li>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </ul>
                        </div>
                    </div>
                    <div class="kemu">
                        <div class="kemutit">
                            华中地区<span>（包括湖北、湖南、河南、江西）</span></div>
                        <div class="kemuul">
                            <ul>
                                <asp:Repeater ID="Repeater3" runat="server">
                                    <ItemTemplate>
                                        <li p="<%#Eval("SchoolProvinceId") %>"><a href="/daxue-jianjie-<%#Eval("SchoolId") %>.shtml"
                                            title="<%#Eval("YuanXiaoMingCheng") %>">
                                            <%#Eval("YuanXiaoMingCheng")%></a></li>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </ul>
                        </div>
                    </div>
                    <div class="kemu">
                        <div class="kemutit">
                            东北地区<span>（包括辽宁、吉林、黑龙江）</span></div>
                        <div class="kemuul">
                            <ul>
                                <asp:Repeater ID="Repeater7" runat="server">
                                    <ItemTemplate>
                                        <li p="<%#Eval("SchoolProvinceId") %>"><a href="/daxue-jianjie-<%#Eval("SchoolId") %>.shtml"
                                            title="<%#Eval("YuanXiaoMingCheng") %>">
                                            <%#Eval("YuanXiaoMingCheng")%></a></li>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </ul>
                        </div>
                    </div>
                    <div class="kemu">
                        <div class="kemutit">
                            西南地区<span>（包括四川、云南、贵州、西藏、重庆）</span></div>
                        <div class="kemuul">
                            <ul>
                                <asp:Repeater ID="Repeater5" runat="server">
                                    <ItemTemplate>
                                        <li p="<%#Eval("SchoolProvinceId") %>"><a href="/daxue-jianjie-<%#Eval("SchoolId") %>.shtml"
                                            title="<%#Eval("YuanXiaoMingCheng") %>">
                                            <%#Eval("YuanXiaoMingCheng")%></a></li>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </ul>
                        </div>
                    </div>
                    <div class="kemu">
                        <div class="kemutit">
                            华南地区<span>（包括广东、广西、海南）</span></div>
                        <div class="kemuul">
                            <ul>
                                <asp:Repeater ID="Repeater2" runat="server">
                                    <ItemTemplate>
                                        <li p="<%#Eval("SchoolProvinceId") %>"><a href="/daxue-jianjie-<%#Eval("SchoolId") %>.shtml"
                                            title="<%#Eval("YuanXiaoMingCheng") %>">
                                            <%#Eval("YuanXiaoMingCheng")%></a></li>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </ul>
                        </div>
                    </div>
                    <div class="kemu">
                        <div class="kemutit">
                            西北地区<span>（包括宁夏、新疆、青海、陕西、甘肃）</span></div>
                        <div class="kemuul">
                            <ul>
                                <asp:Repeater ID="Repeater6" runat="server">
                                    <ItemTemplate>
                                        <li p="<%#Eval("SchoolProvinceId") %>"><a href="/daxue-jianjie-<%#Eval("SchoolId") %>.shtml"
                                            title="<%#Eval("YuanXiaoMingCheng") %>">
                                            <%#Eval("YuanXiaoMingCheng")%></a></li>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </ul>
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
