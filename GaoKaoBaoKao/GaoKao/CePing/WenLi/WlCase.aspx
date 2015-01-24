<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WlCase.aspx.cs" Inherits="GaoKao.CePing.WenLi.WlCase" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>文理分科</title>
    <script type="text/javascript" src="../js/jquery-1.4.2.min.js"></script>
    <script type="text/javascript" src="../js/reportForms/highcharts.js"></script>
    <script type="text/javascript" src="../js/reportForms/exporting.js"></script>

    <script type="text/javascript">
        var chart;
        $(document).ready(function () {
            chart = new Highcharts.Chart({
                chart: {
                    renderTo: 'container',
                    plotBackgroundColor: null,
                    plotBorderWidth: null,
                    plotShadow: false
                },
                title: {
                    text: '文理分科分值对比'
                },
                tooltip: {
                    formatter: function () {
                        return '<b>' + this.point.name + '</b>: ' + this.percentage.toString().substring(0,4) + ' %';
                    }
                },
                plotOptions: {
                    pie: {
                        allowPointSelect: true,
                        cursor: 'pointer',
                        dataLabels: {
                            enabled: false
                        },
                        showInLegend: true
                    }
                },
                series: [{
                    type: 'pie',
                    name: 'Browser share',
                    data: [
						
							{
							    name: '文科类',
							    y: <%=WenKe %>,
							    sliced: true,
							    selected: true
							},
							['理科类', <%=LiKe %>],
						
						]
                }]
            });
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
      <div id="container" style="width: 800px; height: 400px; margin: 0 auto"></div>
    </div>
    </form>
</body>
</html>
