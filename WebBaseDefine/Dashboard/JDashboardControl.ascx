<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="JDashboardControl.ascx.cs" Inherits="WebBaseDefine.Dashboard.JDashboardControl" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<link href="http://localhost:5024/WebControllers/MainControls/JqueryChart/jquery.jqplot.min.css" rel="stylesheet" />
<script src="/WebControllers/MainControls/JqueryChart/jquery.min.js" type="text/javascript"></script>
<script src="/WebControllers/MainControls/JqueryChart/jquery.jqplot.min.js" type="text/javascript"></script>
<script src="/WebControllers/MainControls/JqueryChart/syntaxhighlighter/scripts/shCore.min.js" type="text/javascript"></script>
<script src="/WebControllers/MainControls/JqueryChart/syntaxhighlighter/scripts/shBrushJScript.min.js" type="text/javascript"></script>
<script src="/WebControllers/MainControls/JqueryChart/syntaxhighlighter/scripts/shBrushXml.min.js" type="text/javascript"></script>
<script src="/WebControllers/MainControls/JqueryChart/plugins/jqplot.barRenderer.js"></script>
<script src="/WebControllers/MainControls/JqueryChart/plugins/jqplot.barRenderer.min.js" type="text/javascript"></script>
<script src="/WebControllers/MainControls/JqueryChart/plugins/jqplot.pointLabels.js"></script>
<script src="/WebControllers/MainControls/JqueryChart/plugins/jqplot.pointLabels.min.js" type="text/javascript"></script>
<script src="/WebControllers/MainControls/JqueryChart/plugins/jqplot.highlighter.min.js" type="text/javascript"></script>
<script src="/WebControllers/MainControls/JqueryChart/plugins/jqplot.cursor.min.js" type="text/javascript"></script>
<script src="/WebControllers/MainControls/JqueryChart/plugins/jqplot.categoryAxisRenderer.min.js" type="text/javascript"></script>
<script src="/WebControllers/MainControls/JqueryChart/plugins/jqplot.logAxisRenderer.min.js" type="text/javascript"></script>
<script src="/WebControllers/MainControls/JqueryChart/plugins/jqplot.canvasTextRenderer.js"></script>
<script src="/WebControllers/MainControls/JqueryChart/plugins/jqplot.canvasTextRenderer.min.js" type="text/javascript"></script>
<script src="/WebControllers/MainControls/JqueryChart/plugins/jqplot.canvasAxisLabelRenderer.min.js" type="text/javascript"></script>
<script src="/WebControllers/MainControls/JqueryChart/plugins/jqplot.canvasAxisTickRenderer.js"></script>
<script src="/WebControllers/MainControls/JqueryChart/plugins/plugins/jqplot.canvasAxisTickRenderer.min.js" type="text/javascript"></script>
<script src="/WebControllers/MainControls/JqueryChart/plugins/jqplot.dateAxisRenderer.js"></script>
<script src="/WebControllers/MainControls/JqueryChart/plugins/jqplot.dateAxisRenderer.min.js;" type="text/javascript"></script>
<script src="/WebControllers/MainControls/JqueryChart/plugins/jqplot.categoryAxisRenderer.js"></script>
<script src="/WebControllers/MainControls/JqueryChart/plugins/jqplot.categoryAxisRenderer.min.js" type="text/javascript"></script>
<script src="/WebControllers/MainControls/JqueryChart/plugins/jqplot.pieRenderer.min.js" type="text/javascript"></script>
<style>
    body {
        overflow: hidden;
        width: 100%;
        height: 100%;
    }

    h1 {
        display: block;
        font-size: 1em;
        font-weight: bold;
    }

    .content {
        width: 95%;
        height: 90%;
        display: inline;
        position: relative;
        overflow: visible;
        padding: 0;
        margin: 0;
    }

    .col-1 {
        float: left;
        width: 40%;
        left:5%;
    }

    .col-2 {
        float: right;
        width: 40%;
    }

    .row {
        width: 95%;
        clear: both;
        height: 43%;
    }

    .row-2 {
        padding-top: 4%;
    }
    .jqplot-table-legend {
        width:100px;
    }
    .jqplot-table-legend .jqplot-table-legend-swatch{
        width:0.7px;
    }
</style>

<div class="BigTitle">داشبورد</div>
<script type="text/javascript">

    $(document).ready(function () {
        function getChartType(chartType) {
            switch (chartType) {
                case "Bar": return $.jqplot.BarRenderer;
                case "Line": return $.jqplot.LineRenderer;
                case "Point": return $.jqplot.PointRenderer;
                case "Pie": return $.jqplot.PieRenderer;
                default: return $.jqplot.BarRenderer;
            }
        }

        $.jqplot.config.enablePlugins = true;
        var plots = [undefined, undefined, undefined, undefined];
        initializeChart(1);
        initializeChart(2);
        initializeChart(3);
        initializeChart(4);
        function initializeChart(chartId) {
            $.ajax({
                type: 'POST',
                async: true,
                url: '/Services/Dashboard/ChartsWebServices.asmx/GetChart',
                data: '{"chartId":"' + chartId + '"}',
                contentType: 'application/json; charset=utf-8',
                dataType: 'json',
                success: function (response) {
                    var xmlDoc = $.parseXML(response.d);
                    var xml = $(xmlDoc);
                    var dt = xml.find("datatable");
                    var settings = xml.find("ChartSettings");
                    var data = [], axisLabels = [];
                    var chartType = 'Bar';
                    var refreshInterval = 60000;
                    var xMemberField = null;
                    var yMemberFields = null;
                    var legendLabels = null;
                    var title = null;
                    $.each(settings, function (i, item) {
                        chartType = $(this).find('ChartType').text().toString();
                        refreshInterval = Number.parseInt($(this).find('RefreshInterval').text());
                        xMemberField = $(this).find('XMemberField').text().toString();
                        yMemberFields = $(this).find('YMemberFields').text().toString().split(',');
                        legendLabels = $(this).find('LegendLabels').text().toString().split(',');
                        title = $(this).find('Title').text().toString();
                    });
                    var max = Number.MIN_VALUE;
                    var min = Number.MAX_VALUE;
                    for (var k = 0; k < yMemberFields.length; k++) {
                        var val = [];
                        $.each(dt, function (i, item) {
                            if (k == 0)
                                axisLabels.push($(this).find(xMemberField).text().replace('T00:00:00+04:30', ''));
                            var tempVal = Number.parseInt($(this).find(yMemberFields[k]).text());
                            val.push(tempVal);
                            if (tempVal > max)
                                max = tempVal;
                            if (tempVal < min)
                                min = tempVal;
                        });
                        //var val = Number.parseInt($(this).find('TransactionCount').text());

                        //if (chartType == "Pie") {
                        //    var lab = $(this).find('dateeventdate').text().replace('T00:00:00+04:30', '');
                        //    data.push([lab, val]);
                        //    console.log([lab, val]);
                        //}
                        //else
                        data.push(val);
                        val = null;
                    };
                    max = (Number.parseInt(max.toString()[0]) + 1) * Math.pow(10, max.toString().length - 1);
                    if (min >= 0)
                        min = 0;
                    else {
                        var tempMin = Math.abs(Number.parseInt(min));
                        min = (Number.parseInt(tempMin.toString()[0]) + 1) * Math.pow(10, tempMin.toString().length - 1) * -1;
                    }

                    if (!plots[chartId - 1]) {
                        var plot1 = $.jqplot('Chartdiv' + chartId, data, {
                            // Only animate if we're not using excanvas (not in IE 7 or IE 8)..
                            title: {
                                text: '<h1>' + title + '</h1>',
                            },
                            animate: !$.jqplot.use_excanvas,
                            seriesDefaults: {
                                renderer: getChartType(chartType),
                                pointLabels: { show: true },
                                showLine: chartType != 'Point',
                                markerOptions: { size: 5, style: "." },
                                rendererOptions: {
                                    showDataLabels: true
                                }
                            },
                            axes: {
                                xaxis: {
                                    renderer: $.jqplot.CategoryAxisRenderer,
                                    //tickRenderer: $.jqplot.CanvasAxisTickRenderer,
                                    ticks: axisLabels,
                                    tickOptions: {
                                        angle: 0,
                                        //labelPosition: 'middle',
                                    },
                                },
                                yaxis: {
                                    max: max
                                    , min: min
                                },

                            },
                            highlighter: { show: false },
                            legend: {
                                show: (chartType == 'Pie' || data.length > 1),
                                labels: (chartType == 'Pie' ? axisLabels : legendLabels),
                                location: 'sw',
                                marginTop: '100px',
                                placement: 'outside',
                                
                            }
                        });
                        plots[chartId - 1] = plot1;
                    }
                    else {
                        var newData = [];
                        for (var i = 0; i < data.length; i++) {
                            newData.push([i + 1, data[i]]);
                        }
                        plots[chartId - 1].series[0].data = newData;
                        //plots[chartId - 1].axes.xaxis.ticks = axisLabels;
                        plots[chartId - 1].replot();
                    }
                    setInterval(refreshChart, refreshInterval, [chartId]);
                },
                failure: function (response) {
                    alert(response.d);
                },
                error: function (response) {
                    alert(response.d);
                }
            });
        }

        function refreshChart(chartId) {
            console.log("refreshChart: " + chartId);
            $.ajax({
                type: 'POST',
                async: true,
                url: '/Services/Dashboard/ChartsWebServices.asmx/GetChart',
                data: '{"chartId":"' + chartId + '"}',
                contentType: 'application/json; charset=utf-8',
                dataType: 'json',
                success: function (response) {
                    var xmlDoc = $.parseXML(response.d);
                    var xml = $(xmlDoc);
                    var dt = xml.find("datatable");
                    var settings = xml.find("ChartSettings");
                    var data = [], axisLabels = [];
                    var chartType = 'Bar';
                    //$.each(settings, function (i, item) {
                    //    chartType = $(this).find('ChartType').text().toString();
                    //});
                    //var max = 0;
                    //$.each(dt, function (i, item) {
                    //    axisLabels.push($(this).find('dateeventdate').text().replace('T00:00:00+04:30', ''));
                    //    var val = Number.parseInt($(this).find('TransactionCount').text());
                    //    //if (chartType == "Pie") {
                    //    //    var lab = $(this).find('dateeventdate').text().replace('T00:00:00+04:30', '');
                    //    //    data.push([lab, val]);
                    //    //    console.log([lab, val]);
                    //    //}
                    //    //else
                    //    data.push(val);
                    //    if (val > max)
                    //        max = val;
                    //});
                    var xMemberField = null;
                    var yMemberFields = null;
                    var legendLabels = null;
                    var title = null;
                    $.each(settings, function (i, item) {
                        chartType = $(this).find('ChartType').text().toString();
                        xMemberField = $(this).find('XMemberField').text().toString();
                        yMemberFields = $(this).find('YMemberFields').text().toString().split(',');
                        legendLabels = $(this).find('LegendLabels').text().toString().split(',');
                        title = $(this).find('Title').text().toString();
                    });
                    var max = Number.MIN_VALUE;
                    var min = Number.MAX_VALUE;
                    var val = [];

                    for (var k = 0; k < yMemberFields.length; k++) {
                        val = [];
                        $.each(dt, function (i, item) {
                            if (k == 0)
                                axisLabels.push($(this).find(xMemberField).text().replace('T00:00:00+04:30', ''));
                            var tempVal = Number.parseInt($(this).find(yMemberFields[k]).text());
                            val.push(tempVal);
                            if (tempVal > max)
                                max = tempVal;
                            if (tempVal < min)
                                min = tempVal;
                        });
                        //var val = Number.parseInt($(this).find('TransactionCount').text());

                        //if (chartType == "Pie") {
                        //    var lab = $(this).find('dateeventdate').text().replace('T00:00:00+04:30', '');
                        //    data.push([lab, val]);
                        //    console.log([lab, val]);
                        //}
                        //else
                        data.push(val);
                        val = null;
                    };
                    max = (Number.parseInt(max.toString()[0]) + 1) * Math.pow(10, max.toString().length - 1);
                    if (min >= 0)
                        min = 0;
                    else {
                        var tempMin = Math.abs(Number.parseInt(min));
                        min = (Number.parseInt(tempMin.toString()[0]) + 1) * Math.pow(10, tempMin.toString().length - 1) * -1;
                    }
                    if (!plots[chartId - 1]) {
                        var plot1 = $.jqplot('Chartdiv' + chartId, data, {
                            // Only animate if we're not using excanvas (not in IE 7 or IE 8)..
                            title: {
                                text: title,
                            },
                            animate: !$.jqplot.use_excanvas,

                            seriesDefaults: {
                                renderer: getChartType(chartType),
                                pointLabels: { show: true },
                                showLine: chartType != 'Point',
                                markerOptions: { size: 5, style: "." },
                                rendererOptions: {
                                    showDataLabels: true
                                }
                            },
                            axes: {
                                xaxis: {
                                    renderer: $.jqplot.CategoryAxisRenderer,
                                    //tickRenderer: $.jqplot.CanvasAxisTickRenderer,
                                    ticks: axisLabels,
                                    tickOptions: {
                                        angle: 0,
                                        //labelPosition: 'middle',
                                    },
                                },
                                yaxis: {
                                    max: max
                                    , min: min
                                },
                            },
                            highlighter: { show: false },
                            legend: {
                                show: (chartType == 'Pie' || data.length > 1),
                                labels: (chartType == 'Pie' ? axisLabels : legendLabels),
                                location: 'sw',
                                marginTop: '100px',
                                placement: 'outside'
                             
                            },
                           
                        });
                        plots[chartId - 1] = plot1;
                    }
                    else {
                        var newData = [];
                        for (var i = 0; i < data.length; i++) {
                            newData = [];
                            for (var j = 0; j < data[i].length; j++) {
                                newData.push([j + 1, data[i][j]]);
                            }
                            plots[chartId - 1].series[i].data = newData;
                            newData = null;
                        }
                        //plots[chartId - 1].axes.xaxis.ticks = axisLabels;
                        plots[chartId - 1].replot();
                    }

                },
                failure: function (response) {
                    alert(response.d);
                },
                error: function (response) {
                    alert(response.d);
                }
            });
        }
        //setInterval(initializeChart, 5000, [1]);
        //setInterval(initializeChart, 5000, [2]);
        //setInterval(initializeChart, 5000, [3]);
        //setInterval(initializeChart, 5000, [4]);


    });
</script>
<%--<div class="content">
    <div class="chartDivParent DivTR">
        <div class="chartDiv" id="Chartdiv1"></div>
    </div>
    <div class="chartDivParent DivTL">
        <div class="chartDiv" id="Chartdiv2"></div>
    </div>
    <div class="chartDivParent DivBR">
        <div class="chartDiv" id="Chartdiv3"></div>
    </div>
    <div class="chartDivParent DivBL">
        <div class="chartDiv" id="Chartdiv4"></div>
    </div>
</div>--%>
<div class="content">
    <div class="row row-1">
        <div class="col-1" id="Chartdiv1"></div>
        <div class="col-2" id="Chartdiv2"></div>
    </div>
    <div class="row row-2">
        <div class="col-1" id="Chartdiv3"></div>
        <div class="col-2" id="Chartdiv4"></div>
    </div>
</div>
