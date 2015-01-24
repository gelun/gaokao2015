<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Schoolbanner.ascx.cs"
    Inherits="GaoKao.UserControl.Schoolbanner" %>
<div class="bannerbg">
    <gk:Nav ID="nav1" runat="server" />
    <div class="banner">
        <div class="bannerword">
            <asp:Literal ID="lit_BannerWord" runat="server"></asp:Literal></div>
        <div class="bannerssk">
            <input type="text" name="keyword" id="keyword" placeholder="输入院校名称" class="ssk" />
            <input name="" type="button" class="ssbtn" id="searchschool">
        </div>
    </div>
</div>
<script type="text/javascript">
    $('.bannerssk').keydown(function (e) {
        if (e.keyCode == 13) {
            searchschool();
        }
    });

    $(function () {
        $("#searchschool").click(function () {
            searchschool();
        });
    });

    function searchschool() {
        var sname = $.trim($("#keyword").val());
        if (sname == "") {
            alert("请输入你要搜索的院校名称");
            return false;
        } else {
            location.href = "/daxue-" + sname + ".shtml";
        }
    }

</script>
<script type="text/javascript" src="/js/jquery.autocomplete.js"></script>
<link href="/js/jquery.autocomplete.css" rel="stylesheet" type="text/css" />
<script type="text/javascript">
    jQuery(function ($) {
        $.getAutoComplete('/SchoolLibrary/autocomplete_School.ashx', 'keyword');
    });
</script>
