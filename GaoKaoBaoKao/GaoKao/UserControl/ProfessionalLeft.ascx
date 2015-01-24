<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ProfessionalLeft.ascx.cs"
    Inherits="GaoKao.UserControl.ProfessionalLeft" %>
<div class="zyconL">
    <div class="zyconLTit">
        <asp:Literal ID="ltlXueKeMenLei" runat="server"></asp:Literal></div>
    <div class="zyconLnav">
        <ul>
            <li style="border-top: 0;"><a href="zhuanye-jianjie-<%=ProfessionalId %>.shtml">
                专业简介</a></li>
            <%if (HasJiuYeLv == "yes")
              {
            %>
            <li class="navcur"><a href="zhuanye-jiuye-<%=ProfessionalId %>.shtml">
                历年就业</a></li><%
              } %>
            <li><a href="zhuanye-daxue-<%=ProfessionalId %>.shtml">开设院校</a></li>
            <%--<li><a href="zhuanye-paiming-<%=ProfessionalId %>.shtml">专业排名</a></li>
            <li><a href="zhuanye-bianxi-<%=ProfessionalId %>.shtml">专业辨析</a></li>--%>
            <li><a href="zhuanye-zhiye-<%=ProfessionalId %>.shtml">相关职业</a></li>
        </ul>
    </div>
</div>
<script type="text/javascript">
    var index = "<%=Index %>";
    var HasJiuYeLv = "<%=HasJiuYeLv %>";
    if (index == "") {
        index == 0;
    }

    if (HasJiuYeLv == "no") {
        if (index > 0) {
            index = index - 1;
        }
    }

    $(".zyconLnav li:eq(" + index + ")").addClass("navcur").siblings().removeClass("navcur");
</script>
