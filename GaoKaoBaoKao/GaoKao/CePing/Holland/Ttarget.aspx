<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Ttarget.aspx.cs" Inherits="GaoKao.CePing.Holland.Ttarget" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
    <title>学习力测评</title>
    <link href="../css/Test.css" type="text/css" rel="Stylesheet" rev="Stylesheet" />
    <script src="/js/jquery.js" type="text/javascript"></script>
    <script src="/js/highcharts.js" type="text/javascript"></script>
    <script src="/js/highcharts-more.js" type="text/javascript"></script>
    <script src="/js/exporting.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {
            $('#container').highcharts({
                chart: {
                    polar: true,
                    type: 'line'
                },
                title: {
                    text: '职业兴趣测评结果',
                    x: -80
                },
                pane: {
                    size: '80%'
                },
                xAxis: {
                    categories: ['现实', '研究', '艺术', '社会',
                    '企业', '常规'],
                    tickmarkPlacement: 'on',
                    lineWidth: 0
                },
                yAxis: {
                    gridLineInterpolation: 'polygon',
                    lineWidth: 0,
                    min: 0
                },
                tooltip: {
                    shared: false,
                    //pointFormat: '&lt;span style="color:{series.color}"&gt;{series.name}: &lt;/span&gt;&lt;b&gt;{point.y:,.0f}&lt;/b&gt;&lt;br/&gt;'
                    pointFormat: '得分：{point.y:,.0f}'
                },
                legend: {
                    align: 'right',
                    verticalAlign: 'top',
                    y: 70,
                    layout: 'vertical'
                },
                series: [{
                    name: '职业兴趣',
                    data: [<%=intReality %>,<%=intStudy %>,  <%=intArt %>,<%=intSociety %>,  <%=intBusiness %>, <%=intTradition %>],
                    pointPlacement: 'on'
                }
                ]
            });
        });
        setTimeout("shengchengtu()", 1000);
        function shengchengtu() {
            $.ajax({
                url: $("#form1").attr("action"),    // 提交的页面
                data: { ty: "ht", container: $("#container").html() },       // 从表单中获取数据
                type: "post",                        // 设置请求类型为"GET"，默认为"GET"
                beforeSend: function ()             // 设置表单提交前方法
                {
                    //提交前的动作
                },
                error: function (data, status, e) {
                    // 异常提示 
                },
                success: function (data) {

                }
            });
        }
    </script>
</head>
<body>
    <form runat="server" id="form1">
    <div class="box fb">
        <img src="../images/box_top.png"></div>
    <div class="box box_c">
        <div class="bc bc_c">
            <div class="bccl">
                <asp:Literal ID="ltr_Over" runat="server" Visible="false"></asp:Literal>
            </div>
        </div>
    </div>
    <div class="box">
        <img src="../images/box_bottom.png" />
    </div>
    <div id="container" style="min-width: 400px; max-width: 600px; height: 400px; margin: 0 auto;
        display: none;">
    </div>
    </form>
</body>
</html>
