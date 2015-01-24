<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UserCenterLeft.ascx.cs"
    Inherits="GaoKao.UserControl.UserCenterLeft" %>
<div class="xiugaiL">
    <div class="yhxx">
        <div class="yhxxL <%=strGender %>">
        </div>
        <div class="yhxxR">
            <h3>
                <%=userinfo.StudentName %></h3>
            <ul>
                <li>
                    <asp:Literal ID="lit_ProvinceName" runat="server"></asp:Literal><span>|</span></li>
                <li>
                    <asp:Literal ID="lit_KeLeiMingCheng" runat="server"></asp:Literal></li>
                <li><strong>
                    <asp:Literal ID="lit_LevelName" runat="server"></asp:Literal></strong>用户<span>|</span></li>
                <li>
                    <asp:Literal ID="lit_NianJi" runat="server"></asp:Literal></li>
                <li>有效期：<asp:Literal ID="lit_GKYear" runat="server"></asp:Literal>-09-01</li>
            </ul>
        </div>
    </div>
    <div class="xgzlbtn">
        <ul>
            <li><a href="/Persional/GRZL.aspx">个人资料修改</a></li>
            <li><a href="/Persional/ChengJiEdit.aspx">成绩修改</a></li>
            <li style="display: none;"><a href="#">报考卡绑定</a></li>
            <li style="display: none;"><a href="#">用户升级</a></li>
        </ul>
    </div>
    <div class="xgzlul">
        <ul>
            <li class="cur"><a href="/tuijian/default.aspx">首页</a></li>
            <li><a href="/tuijian/zhineng1.aspx">报考智能推荐</a></li>
            <li><a href="/chaxun/sjcx.aspx">录取数据查询</a></li>
            <li><a href="/ceping/default.aspx">专业选择测评</a></li>
            <li><a href="/tuijian/ydy.aspx">一对一报考指导</a></li>
            <li><a href="/tuijian/default.aspx">报考知识库</a></li>
            <li><a href="/tuijian/default.aspx">学习与备考</a></li>
        </ul>
    </div>
</div>
