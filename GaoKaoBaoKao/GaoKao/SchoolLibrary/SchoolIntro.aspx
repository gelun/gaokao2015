<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SchoolIntro.aspx.cs" Inherits="GaoKao.SchoolLibrary.SchoolIntro" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title><%=strSchoolName%>_<%=strSchoolEnName%>_格伦高考网</title>
    <meta name="keywords" content="<%=strSchoolName%>,<%=strSchoolEnName %>,高考,格伦高考网" />
    <link href="/css/style.css" rel="stylesheet" type="text/css" />
    <script src="/js/jquery.js" type="text/javascript"></script>
    <script type="text/javascript" charset="utf-8" src="http://map.qq.com/api/js?v=2.exp&key=d84d6d83e0e51e481e50454ccbe8986b"></script>
    <script src="/js/jquery.expander.min.js" type="text/javascript"></script>
    <script src="/js/uni_intro.js" type="text/javascript"></script>
    <script type="text/javascript">        // 3D地图功能
        var map = function (pano, heading, pitch, zoom) {
            if (pano == 0 && heading == 0 && pitch == 0 && zoom == 0)
                return false;

            pano_container = document.getElementById('PanoCtn'); //街景容器
            pano = new qq.maps.Panorama(pano_container, {
                pano: pano, //场景ID
                pov: {	//视角
                    heading: heading, //偏航角
                    pitch: pitch		//俯仰角
                },
                zoom: zoom		//缩放
            })
        }

        // 切换表格
        $.fn.tab = function (options) {
            var defaults = {
                mapId: 'PanoCtn'
            };
            var opts = $.extend(defaults, options);

            $(this).find('li').mouseover(function () {

                if ($(this).hasClass('current'))
                    return false;

                $('#PanoCtn').html('');
                map($(this).attr('pano'),
			parseInt($(this).attr('heading')),
			parseInt($(this).attr('pitch')),
			parseInt($(this).attr('zoom')));
                $(this).addClass('current').siblings().removeClass('current');
            });
        }

        $(function () {

            // 校区切换
            $('#mapTab').tab();
            // 默认校区地图
            var defaultObj = $('#mapTab').find('.current');

            map(defaultObj.attr('pano'),
		parseInt(defaultObj.attr('heading')),
		parseInt(defaultObj.attr('pitch')),
		parseInt(defaultObj.attr('zoom')));
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <gk:Schoolbanner ID="SchoolBanner1" runat="server" BannerWord="格伦高考报考院校库" />
    <gk:Crumb ID="Crumb1" runat="server" />
    <div class="content">
        <div class="contentbody">
            <gk:SchoolLeft ID="SchoolLeft1" runat="server" Index="0" />
            <div class="contentR">
                <gk:SchoolBase ID="SchoolBase1" runat="server" />
                <div class="conRbox">
                    <div class="conRword">
                        <asp:Literal ID="ltlSchoolIntro" runat="server"></asp:Literal>
                    </div>
                    <%if (strHasCampus != "no")
                      {%>
                    <div class="qjdt">
                        <div class="qjdtTit">
                            <div class="dtTitlft">
                                全景地图</div>
                            <div class="dtTitrit">
                                <ul id="mapTab">
                                    <asp:Literal ID="ltlCampus" runat="server"></asp:Literal>
                                </ul>
                            </div>
                        </div>
                        <div class="dtcon">
                            <ul>
                                <li>
                                    <div class="overallView" id="PanoCtn" style="height: 400px;">
                                    </div>
                                </li>
                            </ul>
                        </div>
                    </div>
                    <%} %>
                    <asp:Literal ID="ltlSchoolList" runat="server"></asp:Literal>
                </div>
            </div>
        </div>
    </div>
    <gk:Footer ID="Footer1" runat="server" />
    </form>
</body>
</html>
