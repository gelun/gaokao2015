using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Data;

namespace Basic
{
    /// <summary>
    /// HighCharts处理类
    /// </summary>
    public class HighCharts
    {

        //line,column,pie
        //xAxis  'Jan', 'Feb', 'Mar', 'Apr', 'May', 'Jun', 'Jul', 'Aug', 'Sep', 'Oct', 'Nov', 'Dec'
        //{name: 'Tokyo',data: [7.0, 6.9, 9.5, 14.5, 18.4, 21.5, 25.2, 26.5, 23.3, 18.3, 13.9, 9.6]}
        public static string CreatHighCharts(string ShowAreaIdName, string strType, string strTitle, string xAxisList, string yTitle, string seriesData)
        {
            StringBuilder strOut = new StringBuilder();
            strOut.Append("<script>\r\n");
            strOut.Append("$(function () {\r\n");
            strOut.Append("    $('#" + ShowAreaIdName + "').highcharts({\r\n");
            strOut.Append("        chart: {type: '" + strType + "'},\r\n");
            strOut.Append("        credits:{enabled:false},\r\n");
            strOut.Append("        title: {text: '" + strTitle + "'},\r\n");
            strOut.Append("        xAxis: {categories: [" + xAxisList + "]},\r\n");
            strOut.Append("        yAxis: {title: {text: '" + yTitle + "'}},\r\n");
            //strOut.Append("        tooltip: {enabled: true,formatter: function() {return '<b>'+this.series.name+'</b><br/>'+this.x +': '+ this.y;}},\r\n");
            strOut.Append("        plotOptions: {line: {dataLabels: {enabled: true},enableMouseTracking: false}},\r\n");
            strOut.Append("        series: [\r\n");
            strOut.Append(seriesData);
            //strOut.Append("        	{name: 'Tokyo',data: [7.0, 6.9, 9.5, 14.5, 18.4, 21.5, 25.2, 26.5, 23.3, 18.3, 13.9, 9.6]}, \r\n");
            //strOut.Append("         {name: 'London',data: [3.9, 4.2, 5.7, 8.5, 11.9, 15.2, 17.0, 16.6, 14.2, 10.3, 6.6, 4.8]}\r\n");
            strOut.Append("        ]\r\n");
            strOut.Append("    });\r\n");
            strOut.Append("});\r\n");
            strOut.Append("</script>\r\n");

            return strOut.ToString();
        }

        //seriesDataList以|为分割线进行
        public static string CreatHighChartsFromDT(string ShowAreaIdName, string strType, string strTitle, string yTitle, string seriesDataNameList, DataTable dt)
        {
            if (dt.Rows.Count == 0)
                return "";

            //把Table第一列列出来，拼接成字符串
            StringBuilder xAxisList = new StringBuilder();
            for (int k = 0; k < dt.Rows.Count; k++)
            {
                xAxisList.Append("'" + dt.Rows[k][0].ToString() + "'");
                xAxisList.Append(",");
            }
            xAxisList.Remove(xAxisList.Length - 1, 1);

            StringBuilder seriesData = new StringBuilder();
            //下面进行yTitle的处理
            string[] seriesDataNameArr = seriesDataNameList.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
            for (int j = 1; j < dt.Columns.Count; j++)
            {
                seriesData.Append("{name: '" + seriesDataNameArr[j - 1] + "',data: [");
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string strValue = dt.Rows[i][j].ToString();
                    if (strValue == "0")
                        seriesData.Append("null,");
                    else
                        seriesData.Append(dt.Rows[i][j].ToString() + ",");
                }
                seriesData.Remove(seriesData.Length - 1, 1);
                seriesData.Append("]},");
            }
            seriesData.Remove(seriesData.Length - 1, 1);

            return CreatHighCharts(ShowAreaIdName, strType, strTitle, xAxisList.ToString(), yTitle, seriesData.ToString());
        }

        //浙江
        public static string CreatHighChartsFromZheJiangDT(string ShowAreaIdName, string strType, string strTitle, string yTitle, string seriesDataNameList, DataTable dt)
        {
            if (dt.Rows.Count == 0)
                return "";

            //把Table第一列列出来，拼接成字符串
            StringBuilder xAxisList = new StringBuilder();
            for (int k = 0; k < dt.Rows.Count; k++)
            {
                xAxisList.Append("'" + dt.Rows[k][0].ToString() + "'");
                xAxisList.Append(",");
            }
            xAxisList.Remove(xAxisList.Length - 1, 1);

            StringBuilder seriesData = new StringBuilder();
            //下面进行yTitle的处理
            string[] seriesDataNameArr = seriesDataNameList.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
            for (int j = 1; j < dt.Columns.Count - 2; j++)
            {
                seriesData.Append("{name: '" + seriesDataNameArr[j - 1] + "',data: [");
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string strValue = dt.Rows[i][j].ToString();
                    if (strValue == "0")
                        seriesData.Append("null,");
                    else
                        seriesData.Append(dt.Rows[i][j].ToString() + ",");
                }
                seriesData.Remove(seriesData.Length - 1, 1);
                seriesData.Append("]},");
            }
            seriesData.Remove(seriesData.Length - 1, 1);

            return CreatHighCharts(ShowAreaIdName, strType, strTitle, xAxisList.ToString(), yTitle, seriesData.ToString());
        }


        public static string CreatHighChartsPie3D(string ShowAreaIdName, string strTitle, string strAltTitle, string seriesData)
        {
            StringBuilder strOut = new StringBuilder();
            strOut.Append("<script>\r\n");
            strOut.Append("$(function () {\r\n");
            strOut.Append("$('#" + ShowAreaIdName + "').highcharts({\r\n");
            strOut.Append("chart: {plotBackgroundColor: null,plotBorderWidth: null,plotShadow: false},\r\n");
            strOut.Append("        credits:{enabled:false},\r\n");
            strOut.Append("title: {text: '" + strTitle + "'},\r\n");
            strOut.Append("tooltip: {pointFormat: '{series.name}: <b>{point.percentage:.2f}%</b>'},\r\n");
            strOut.Append("plotOptions: {\r\n");
            strOut.Append("pie: {allowPointSelect: true,cursor: 'pointer',dataLabels: {enabled: true,color: '#000000',connectorColor: '#000000',format: '<b>{point.name}</b>: {point.percentage:.0f}'}}\r\n");
            strOut.Append("},\r\n");
            strOut.Append("series: [{\r\n");
            strOut.Append("type: 'pie',name: '" + strAltTitle + "',\r\n");
            strOut.Append("data: [\r\n");

            strOut.Append(seriesData);

            strOut.Append("]\r\n");
            strOut.Append("}]\r\n");
            strOut.Append("});\r\n");
            strOut.Append("});\r\n");
            strOut.Append("</script>\r\n");

            return strOut.ToString();
        }

        //
        public static string CreatHighChartsPie3DFromDT(string ShowAreaIdName, string strTitle, string strAltTitle, DataTable dt)
        {
            if (dt.Rows.Count == 0)
                return "";

            StringBuilder seriesData = new StringBuilder();
            for (int j = 0; j < dt.Rows.Count; j++)
            {
                seriesData.Append("['" + dt.Rows[j][0].ToString() + "',");
                seriesData.Append(dt.Rows[j][1].ToString());
                seriesData.Append("],");
            }
            seriesData.Remove(seriesData.Length - 1, 1);

            return CreatHighChartsPie3D(ShowAreaIdName, strTitle, strAltTitle, seriesData.ToString());
        }


    }

}
