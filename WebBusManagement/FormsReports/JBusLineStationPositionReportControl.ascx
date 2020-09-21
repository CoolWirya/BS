<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="JBusLineStationPositionReportControl.ascx.cs" Inherits="WebBusManagement.FormsReports.JBusLineStationPositionReportControl" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register Src="~/WebControllers/MainControls/Date/JDateControl.ascx" TagPrefix="uc1" TagName="JDateControl" %>

<div class="BigTitle">گزارش موقعیت اتوبوس ها در خطوط</div>
<table style="width: 500px">
    <tr class="Table_RowC">
        <td style="width: 150px">خط:</td>
        <td>
            <telerik:RadComboBox runat="server" ID="cmbLine" Width="100%" Filter="Contains">
            </telerik:RadComboBox>
        </td>
    </tr>
</table>

<div style="clear: both; height: 15px;"></div>
<input type="button" id="btnSave" title="مشاهده گزارش" value="مشاهده گزارش" style="width: 100px; height: 30px" onclick="GetReport(true)" />
<input type="button" id="btnClose" title="بازگشت" value="بازگشت" style="width: 100px; height: 30px" onclick="CloseDialog()" />
<div style="clear: both; height: 15px;"></div>

<div style="width: 100%; height: 32px">
    <div id="SearchLoading" style="z-index: 120; float: left; width: 100%; height: 32px; display: none">
        <center>
                    <img src="../Images/loading_s128.png" style='width:128px;height:128px'/>
                </center>
    </div>
</div>


<div style="clear: both; height: 50px"></div>
<div style="width: 3000px; height: auto; margin-right: auto; margin-left: auto" id="HtmlMainDiv">
    <%--<%=StrCalender %>--%>
</div>



<input type="hidden" name="stationPassCalenderReportControl" id="stationPassCalenderReportControl" value="0" runat="server" />
<script type="text/javascript">




    function GetReport(showLoading) {
        if (showLoading) {
            $("#SearchLoading").css('display', 'block');
        }
        var paramStr = new Array();
        paramStr[0] = $("#<%=cmbLine.ClientID %>").val().toString().split('-')[0];
        paramStr[1] = $("#<%=cmbLine.ClientID %>").val().toString().split('-')[1];
        var data = "{actionString:'" + $("#<%=stationPassCalenderReportControl.ClientID %>").val() + "',param:" + JSON.stringify(paramStr) + "}";
        ResultAjaxRequet = $.ajax({
            url: "../WebControllers/WebService/Action.asmx/RunAction",
            contentType: "application/json",
            cache: false,
            type: "POST",
            data: data,
            async: true,
            error: function (err) {

            },
            success: function (data) {
                $("#SearchLoading").css('display', 'none');
                $("#HtmlMainDiv").html("");
                $("#HtmlMainDiv").html(data.d.toString());
              //  timerMy();
            }
        });
    }

    //var counter = 0;
    //function timerMy() {
    //    GetReport(false);
    //}

    function SetStationNameText(text) {
        $("#StationNameHtmlDiv").html("ایستگاه" + " " + text.toString());
    }
    function ClearStationNameText() {
        $("#StationNameHtmlDiv").html("");
    }

    //  window.setInterval(GetReport(), 30000);

    <%=StrScipt%>

</script>

