<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GouKa.aspx.cs" Inherits="GaoKao.GaoKaoCard.GouKa" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>购买高考报考卡_格伦高考报考卡_报考卡使用方法_报考卡用户特权_格伦高考网</title>
    <meta name="KeyWords" content="购买高考报考卡,格伦高考报考卡,报考卡使用方法,报考卡用户特权,格伦高考网" />
    <meta name="Description" content="格伦教育高考网隆重推出最新一代高考报考卡,功能报考:志愿智能模拟、专业倾向测试、按分查询院校、按名次查询院校、按分数线查询专业、院校对比、专业对比等" />
    <link href="/css/style.css" rel="stylesheet" type="text/css" />
    <link href="/css/style_gouka.css" rel="stylesheet" type="text/css" />
    <script src="/js/jquery.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
    <gk:Schoolbanner ID="SchoolBanner1" runat="server" BannerWord="格伦高考报考" />
    <div class="lll">
        <gk:Crumb ID="Crumb1" runat="server" NavString=" <span>&gt;</span> 购买高考卡" />
        <div style="border-bottom: 1px solid #c8c8c8; width: 1200px; margin: 0 auto">
            <div class="buyCard-cardDetail">
                <div class="basecf">
                    <div class="album" id="album">
                        <div class="album1" id="album1">
                            <div class="img12">
                                <img src="/images/d1.jpg"></div>
                            <div class="img2" id="img2" style="border: 3px solid #ff7700;">
                                <img src="/images/d6.jpg"></div>
                            <div class="img3" id="img3">
                                <img src="/images/q3.jpg"></div>
                            <div class="img4" id="img4" style="">
                                <img src="/images/q4.jpg"></div>
                            <div class="img5" id="img5">
                                <img src="/images/q5.jpg"></div>
                        </div>
                        <script type="text/javascript" language="javascript">
                            $(document).ready(function () {
                                $("#album1 div").hover(function () {
                                    if ($("#album1 div").index(this)==0) {
                                    //第一个位置是展示大图的，所以不需要做任何处理
                                    } else {
                                        $("#album1 div:eq(0)").find("img").attr("src", "/images/d" + $(this).index() + ".jpg");
                                        $(this).css("border", "3px solid #ff7700").siblings().css("border", "");
                                    }
                                })
                            });
                        </script>
                        <div class="summary1">
                            <div class="img">
                                <img src="/images/gaokaobaokaoka.jpg"></div>
                            <div class="summary1_con">
                                <p class="z1">
                                    <span>价&nbsp;&nbsp;&nbsp;&nbsp;格</span>&nbsp;&nbsp;&nbsp;<b>288.00</b>元/张</p>
                                <p class="z2">
                                    <span>有效期至</span>&nbsp;&nbsp;&nbsp;2015年8月31日</p>
                                <p class="z3">
                                    <span>适用考生</span>&nbsp;&nbsp;&nbsp;普通类文理科考生（体育、艺术类考生除外）</p>
                                <p class="z4">
                                    <span>适用批次</span>&nbsp;&nbsp;&nbsp;普通类非提前批次</p>
                                <p class="z5">
                                    <span>付款支持</span>&nbsp;&nbsp;&nbsp;<img src="/images/zhifufangshi-1.jpg">
                                    <img src="/images/zhifufangshi-2.jpg"></p>
                                <a href="dingdan.aspx">
                                    <input type="button" value="立即购买" class="z6"></a>
                                <ul>
                                    <li>1、每张卡可供1位考生使用，有效期内无使用次数和时间限制；</li>
                                    <li>2、在线购买的为电子卡，将通过短信形式发送"卡号和密码"</li>
                                    <li>3、本卡不记名、不挂失，一经售出，概不退换。</li>
                                </ul>
                            </div>
                        </div>
                        <div style="clear: both;">
                        </div>
                    </div>
                </div>
            </div>
            <div class="yhqx1">
                用户权限</div>
            <div class="yhqx">
                <table width="1200" border="0">
                    <tbody>
                        <tr>
                            <th width="21%">
                                功能模块
                            </th>
                            <th width="33%">
                                功能
                            </th>
                            <th width="22%">
                                注册用户
                            </th>
                            <th width="24%">
                                智能规划卡用户
                            </th>
                        </tr>
                        <tr>
                            <th>
                                报考智能推荐
                            </th>
                            <td class="tdLft">
                                智能推荐
                            </td>
                            <td>
                                <img src="/images/cha.jpg">
                            </td>
                            <td>
                                <img src="/images/gou.jpg">
                            </td>
                        </tr>
                        <tr>
                            <th rowspan="4">
                                录取分数查询
                            </th>
                            <td class="tdLft">
                                历年省控线
                            </td>
                            <td>
                                <img src="/images/gou.jpg">
                            </td>
                            <td>
                                <img src="/images/gou.jpg">
                            </td>
                        </tr>
                        <tr>
                            <td class="tdLft">
                                位次查询
                            </td>
                            <td>
                                <img src="/images/gou.jpg">
                            </td>
                            <td>
                                <img src="/images/gou.jpg">
                            </td>
                        </tr>
                        <tr>
                            <td class="tdLft">
                                按学校查询
                            </td>
                            <td>
                                <img src="/images/gou.jpg">
                            </td>
                            <td>
                                <img src="/images/gou.jpg">
                            </td>
                        </tr>
                        <tr>
                            <td class="tdLft">
                                按专业查询
                            </td>
                            <td>
                                <img src="/images/gou.jpg">
                            </td>
                            <td>
                                <img src="/images/gou.jpg">
                            </td>
                        </tr>
                        <tr>
                            <th rowspan="2">
                                录取去向查询
                            </th>
                            <td class="tdLft">
                                同分去向查询
                            </td>
                            <td>
                                <img src="/images/cha.jpg">
                            </td>
                            <td>
                                <img src="/images/gou.jpg">
                            </td>
                        </tr>
                        <tr>
                            <td class="tdLft">
                                同位次去向查询
                            </td>
                            <td>
                                <img src="/images/cha.jpg">
                            </td>
                            <td>
                                <img src="/images/gou.jpg">
                            </td>
                        </tr>
                        <tr>
                            <th rowspan="2">
                                录取对比查询
                            </th>
                            <td class="tdLft">
                                院校录取对比
                            </td>
                            <td>
                                <img src="/images/cha.jpg">
                            </td>
                            <td>
                                <img src="/images/gou.jpg">
                            </td>
                        </tr>
                        <tr>
                            <td class="tdLft">
                                专业录取对比
                            </td>
                            <td>
                                <img src="/images/cha.jpg">
                            </td>
                            <td>
                                <img src="/images/gou.jpg">
                            </td>
                        </tr>
                        <tr>
                            <th rowspan="3">
                                专业选择评测
                            </th>
                            <td class="tdLft">
                                专业选择评测
                            </td>
                            <td>
                                <img src="/images/cha.jpg">
                            </td>
                            <td>
                                <img src="/images/gou.jpg">
                            </td>
                        </tr>
                        <tr>
                            <td class="tdLft">
                                应试心理评测
                            </td>
                            <td>
                                <img src="/images/cha.jpg">
                            </td>
                            <td>
                                <img src="/images/gou.jpg">
                            </td>
                        </tr>
                        <tr>
                            <td class="tdLft">
                                文理分科评测
                            </td>
                            <td>
                                <img src="/images/cha.jpg">
                            </td>
                            <td>
                                <img src="/images/gou.jpg">
                            </td>
                        </tr>
                        <tr>
                            <th>
                                &nbsp;
                            </th>
                            <td class="tdLft">
                                院校库
                            </td>
                            <td>
                                <img src="/images/gou.jpg">
                            </td>
                            <td>
                                <img src="/images/gou.jpg">
                            </td>
                        </tr>
                    </tbody>
                </table>
            </div>
        </div>
        <gk:Footer ID="Footer1" runat="server" />
    </div>
    </form>
</body>
</html>
