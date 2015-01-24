<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ProfessionalBanner.ascx.cs"
    Inherits="GaoKao.UserControl.ProfessionalBanner" %>
<div class="bannerbg">
    <gk:Nav ID="nav1" runat="server" />
    <div class="banner">
        <div class="bannerword"><asp:Literal ID="lit_BannerWord" runat="server"></asp:Literal></div>
        <div class="bannerssk">
            <input type="text" name="keyword" id="keyword" value="输入专业名称" class="ssk" />
            <input name="" type="button" class="ssbtn">
        </div>
    </div>
</div>
<script type="text/javascript">
    $('.banner').keydown(function (e) {
        if (e.keyCode == 13) {
            ProfessionalSearch();
        }
    });
    $(function () {
        $(".ssbtn").click(function () {
            ProfessionalSearch();
        });
    });
    function ProfessionalSearch() {
        $(function () {

            var keyword_value = $('#keyword').val();
            if (keyword_value == "" || keyword_value == "输入专业名称")
                alert("请输入要搜索的专业名称");
            else {
                location.href = "/zhuanye-search-" + $.trim(keyword_value) + ".shtml";
            }
        });
    }

    $(function () {

        $('#keyword').focus(function () {
            var keyword_value = $('#keyword').val();
            if (keyword_value == "输入专业名称") {
                $(this).val('');
            }
        })

        //邮箱地址输入框失去焦点
        $('#keyword').blur(function () {
            var keyword_value = $('#keyword').val();
            if (keyword_value == "")
                $(this).val('输入专业名称');
            {
            }
        })
    });
</script>
<script type="text/javascript" src="/js/jquery.autocomplete.js"></script>
<link href="/js/jquery.autocomplete.css" rel="stylesheet" type="text/css" />
<script type="text/javascript">
    jQuery(function ($) {
        $.getAutoComplete('/ProfessionalLibrary/autocomplete_Professional.ashx','keyword');
    });
</script>
