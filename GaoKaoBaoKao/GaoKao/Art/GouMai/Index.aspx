<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="GaoKao.Art.GouMai.Index" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>格伦高考报考卡-艺术高考VIP_格伦高考报考卡_报考卡使用方法_报考卡用户特权_格伦高考网 </title>
    <meta name="KeyWords" content="购买高考报考卡-艺术高考VIP,格伦高考报考卡,报考卡使用方法,报考卡用户特权,格伦高考网" />
    <link href="/css/style.css" rel="stylesheet" type="text/css" />
    <link href="/css/ys_gouka.css" rel="stylesheet" type="text/css" />
    <script src="/js/jquery.js" type="text/javascript"></script>
</head>
<body>
    <form runat="server" id="form1">
    <gk:Schoolbanner ID="SchoolBanner1" runat="server" BannerWord="格伦高考报考" />
    <div class="lll">
        <gk:Crumb ID="Crumb1" runat="server" NavString=" <span>&gt;</span> 格伦艺术高考VIP卡" />
        <div style="width: 1200px; margin: 0 auto">
            <div class="buyCard-cardDetail">
                <div class="basecf">
                    <div class="album" id="album">
                        <div class="album1" id="album1">
                            <div class="img12">
                                <img src="../../images/gk/t1.png"></div>
                            <div class="img2" id="img2" style="border: 3px solid #ff7700;">
                                <img src="../../images/gk/d61.jpg"></div>
                            <div class="img3" id="img3">
                                <img src="../../images/gk/q33.jpg"></div>
                            <div class="img4" id="img4" style="">
                                <img src="../../images/gk/q44.jpg"></div>
                            <div class="img5" id="img5">
                                <img src="../../images/gk/q55.jpg"></div>
                        </div>
                        <script type="text/javascript" language="javascript">
                            $(document).ready(function () {

                                $("#album1 div").hover(function () {

                                    if ($("#album1 div").index(this) == 0) {
                                        //第一个位置是展示大图的，所以不需要做任何处理
                                    } else {
                                        $("#album1 div:eq(0)").find("img").attr("src", "../../images/gk/t" + $(this).index() + ".png");
                                        $(this).css("border", "3px solid #ff7700").siblings().css("border", "");
                                    }
                                })


                            });
							
                        </script>
                        <div class="summary1">
                            <div class="img" style="font-size: 30px; color: #595959; font-weight: bold; margin-top: 25px;">
                                格伦高考报考卡——"艺术高考VIP"（电子虚拟卡）</div>
                            <div class="summary1_con">
                                <p class="z1">
                                    <span>价&nbsp;&nbsp;&nbsp;&nbsp;格</span>&nbsp;&nbsp;&nbsp;<b>4600.00</b>元/张</p>
                                <p class="z2">
                                    <span>有效期至</span>&nbsp;&nbsp;&nbsp;2015年9月30日</p>
                                <p class="z3">
                                    <span>适用考生</span>&nbsp;&nbsp;&nbsp;体育、艺术类考生</p>
                                <p class="z4">
                                    <span>适用批次</span>&nbsp;&nbsp;&nbsp;艺术类</p>
                                <p class="z5">
                                    <span>付款支持</span>&nbsp;&nbsp;&nbsp;<img src="../../images/gk/zhifufangshi-1.jpg">
                                    <img src="../../images/gk/zhifufangshi-2.jpg"></p>
                                <a href="dingdan.aspx">
                                    <input type="button" value="立即购买" class="z6"></a>
                                <ul>
                                    <li>1、购买艺术生VIP服务的用户，可获赠高考智能填报系统卡1张，辅导学习和文化知识。</li>
                                    <li>2、付款成功后一个工作日，报考专家会与考生取得联系，开始提供服务，请保持手机畅通，便于联系。</li>
                                </ul>
                            </div>
                        </div>
                        <div style="clear: both;">
                        </div>
                    </div>
                </div>
            </div>
            <div class="tianjian">
                <div style="font-size: 30px; color: #393939; border-left: 3px solid #ff8c00; padding-left: 20px;
                    line-height: 27px;">
                    艺考一对一专家服务</div>
                <div class="biankuang">
                    <ul>
                        <li><a href="" title="">校考院校定位：一对一精准分析校考学校</a></li>
                        <li><a href="" title="">考前制定报考预案：预估文化课成绩和专业成绩，提前制定报考预案</a></li>
                        <li><a href="" title="">出分后报考建议方案：根据文化课成绩或统考、校考成绩确定报考方案</a></li>
                        <li><a href="" title="">全程跟踪指导：全程跟踪，多批次填报、帮你轻松度过艺考年</a></li>
                    </ul>
                </div>
            </div>
        </div>
    </div>
    <gk:Footer ID="Footer1" runat="server" />
    </form>
</body>
</html>
