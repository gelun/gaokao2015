<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SchoolBase.ascx.cs"
    Inherits="GaoKao.UserControl.SchoolBase" %>
<div class="dxxx">
    <div class="dxlft">
        <div class="dxtit">
            <asp:Literal ID="ltlSchoolName" runat="server"></asp:Literal>
            <div><asp:Literal ID="ltlSchoolEnName" runat="server"></asp:Literal></div></div>
        <div class="dxbq">
            <asp:Literal ID="ltlYouShi" runat="server"></asp:Literal>
            <p>
                招生电话：<asp:Literal ID="ltlZhaoShengTel" runat="server"></asp:Literal></p>
        </div>
        <div class="dxbtm">
            <ul>
                <li><span>院校类型：</span><asp:Literal ID="ltlYuanXiaoLeiXing" runat="server"></asp:Literal></li>
                <li><span>所在省市：</span><asp:Literal ID="ltlShengShi" runat="server"></asp:Literal></li>
                <li><span>隶属于：</span><asp:Literal ID="ltlBelongName" runat="server"></asp:Literal></li>
                <li><span>创建时间：</span><asp:Literal ID="ltlFoundingTime" runat="server"></asp:Literal></li>
                <li><span>重点学科：</span><asp:Literal ID="ltlZhongDianXueKe" runat="server"></asp:Literal></li>
                <li><span>学校院士：</span><asp:Literal ID="ltlYuanShi" runat="server"></asp:Literal></li>
                <li><span>博士点：</span><asp:Literal ID="ltlBoShiDian" runat="server"></asp:Literal></li>
                <li><span>硕士点：</span><asp:Literal ID="ltlShuoShiDian" runat="server"></asp:Literal></li>
            </ul>
        </div>
    </div>
    <div class="dxrit">
        <asp:Literal ID="ltlSchoolWebSite" runat="server"></asp:Literal>
    </div>
</div>
