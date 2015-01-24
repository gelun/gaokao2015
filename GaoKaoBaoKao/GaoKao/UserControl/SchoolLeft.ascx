<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SchoolLeft.ascx.cs"
    Inherits="GaoKao.UserControl.SchoolLeft" %>
<div class="contentL">
    <div class="dxlogo">
        <img id="SchoolLogo" runat="server" src="../logo/default.png" width="121" height="121" /></div>
    <div class="navleft">
        <ul>
            <li><a href="daxue-jianjie-<%=intSchoolId %>.shtml">学校简介</a></li>
            <li><a href="daxue-zhuanye-<%=intSchoolId %>.shtml">开设专业</a></li>
            <li><a href="daxue-youshi-<%=intSchoolId %>.shtml">优势专业</a></li>
            <li><a href="daxue-fenshuxian-<%=intSchoolId %>.shtml">历年分数线</a></li>
            <li><a href="daxue-zhangcheng-<%=intSchoolId %>.shtml">招生章程</a></li>
            <li><a href="daxue-guize-<%=intSchoolId %>.shtml">录取规则</a></li>
            <li><a href="daxue-fangtan-<%=intSchoolId %>.shtml">招办访谈</a></li>
        </ul>
    </div>
</div>
<script type="text/javascript">
    var index = "<%=Index %>";
    if (index != "") {
        $(".navleft li:eq(" + index + ")").addClass("navcur").siblings().removeClass("navcur");
    }
</script>
