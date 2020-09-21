<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="JBusInfractionShowMapUpdateControl.ascx.cs" Inherits="WebBusManagement.FormsReports.JBusInfractionShowMapUpdateControl" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register Assembly="WebControllers" Namespace="WebControllers.MainControls.Grid" TagPrefix="cc1" %>
<%@ Register Src="~/WebControllers/MainControls/OpenLayersMap/OpenLayersMap.ascx" TagPrefix="uc1" TagName="OpenLayersMap" %>



<script type="text/javascript">
    $(document).ready(function () {
        GetRadWindow().maximize();
    });
</script>
<div class="BigTitle">نمایش مسیر تخلف روی نقشه</div>
<table style="width: 90%">
    <tr class="Table_RowB">
        <td style="width: 300px">نقشه مسیر:</td>
        <td>
            <div id="Div_StationMap" style="float: right; width: 100%; height: 400px;">
                <uc1:openlayersmap runat="server" id="OpenLayersMapStations" />
            </div>
        </td>
    </tr>
    <tr class="Table_RowB">
        <td style="width: 300px">عملیات:</td>
        <td>
            <telerik:RadButton runat="server" ID="btnClose" Text="بازگشت" OnClientClicked="CloseDialog" AutoPostBack="false" Width="100px" Height="35px" />
        </td>
    </tr>
    <tr class="Table_RowC">
        <td style="width: 300px">ایستگاه ها:</td>
        <td>
            <cc1:JGridView runat="server" ID="RadGridReport"></cc1:JGridView>
        </td>
    </tr>
</table>

<input type="hidden" runat="server" id="PathMapStationAc" />
<input type="hidden" runat="server" id="BusServiceCode" />


<script type="text/javascript">
    GetStation();
    function GetStation() {
        var paramStr = new Array();
        paramStr[0] = $("#<%=BusServiceCode.ClientID %>").val();
        var data = "{actionString:'" + $("#<%=PathMapStationAc.ClientID %>").val() + "',param:" + JSON.stringify(paramStr) + "}";
        ResultAjaxRequet = $.ajax({
            url: "../WebBusManagement/WebService/Action.asmx/RunAction",
            contentType: "application/json",
            cache: false,
            type: "POST",
            data: data,
            async: true,
            error: function (err) {

            },
            success: function (data) {
                if (data.d.length > 1) {
                    var CenterLong = (data.d[2 * Math.round(1 * (data.d.length / 2) / 4) + 1].substr(7).split('{!~!}')[0] + data.d[2 * Math.round(3 * (data.d.length / 2) / 4) + 1].substr(7).split('{!~!}')[0]);
                    var CenterLat = (data.d[2 * Math.round(1 * (data.d.length / 2) / 4) + 1].substr(7).split('{!~!}')[1] + data.d[2 * Math.round(3 * (data.d.length / 2) / 4) + 1].substr(7).split('{!~!}')[1]);
                    SetMarkerAndloadItNoDelete(data.d, true, true);
                    MapSetCenterWithZoom(CenterLong, CenterLat, 14);

                }
            }
        });
    }





</script>

