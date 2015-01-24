<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ProfessionalBase.ascx.cs"
    Inherits="GaoKao.UserControl.ProfessionalBase" %>
<div class="zytop">
    <div class="zytopTit">
        <asp:Literal ID="ltlProfessionalName" runat="server"></asp:Literal>
        <span>
            <asp:Literal ID="ltlCengCi" runat="server"></asp:Literal></span></div>
    <div class="zytopul">
        <ul>
            <li>专业代码：<span><asp:Literal ID="ltlProfessionalCode" runat="server"></asp:Literal></span></li>
            <li>学科门类：<span><asp:Literal ID="ltlXueKeMenLei" runat="server"></asp:Literal></span></li>
            <li>专业类：<span><asp:Literal ID="ltlZhuanYeLei" runat="server"></asp:Literal></span></li>
            <%if (info.IsBen == 1)
              {
            %>
            <li>授予学位：<span><asp:Literal ID="ltlRemark" runat="server"></asp:Literal></span></li>
            <%
              } %>
        </ul>
    </div>
</div>
