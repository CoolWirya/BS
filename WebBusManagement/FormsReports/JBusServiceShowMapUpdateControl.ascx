<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="JBusServiceShowMapUpdateControl.ascx.cs" Inherits="WebBusManagement.FormsReports.JBusServiceShowMapUpdateControl" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register Assembly="WebControllers" Namespace="WebControllers.MainControls.Grid" TagPrefix="cc1" %>
<%@ Register Src="~/WebControllers/MainControls/OpenLayersMap/OpenLayersMap.ascx" TagPrefix="uc1" TagName="OpenLayersMap" %>
<script type="text/javascript">
    $(document).ready(function () {
        GetRadWindow().maximize();
    });
</script>
<div class="BigTitle">نمایش مسیر سرویس روی نقشه</div>
<table style="width: 90%">
    <tr class="Table_RowB">
        <td style="width: 300px">نقشه مسیر:</td>
        <td>
            <div id="Div_StationMap" style="float: right; width: 100%; height: 400px;">
                <uc1:openlayersmap runat="server" id="OpenLayersMapStations" />
            </div>
        </td>
    </tr>
<%--    <tr class="Table_RowC">
        <td style="width: 300px">نوع مسیر:</td>
        <td>
            <telerik:RadComboBox ID="cmbDataBase" runat="server" Width="30%">
                <Items>
                    <telerik:RadComboBoxItem Value="1" Text="مسیر رفت"/>
                    <telerik:RadComboBoxItem Value="2" Text="مسیر برگشت"/>
                </Items>
            </telerik:RadComboBox>
        </td>
    </tr>--%>
    <tr class="Table_RowB">
        <td style="width: 300px">عملیات:</td>
        <td>
            <telerik:RadButton runat="server" ID="btnSaveGo" Text="ذخیره به عنوان مسیر رفت" AutoPostBack="true" Width="140px" Height="35px" OnClick="btnSaveGo_Click" />
            <telerik:RadButton runat="server" ID="btnSaveBack" Text="ذخیره به عنوان مسیر برگشت" AutoPostBack="true" Width="140px" Height="35px" OnClick="btnSaveBack_Click" />
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
                if (data.d.length > 1)
                {
                    var CenterLong = (data.d[2 * Math.round(1 * (data.d.length / 2) / 4) + 1].substr(7).split('{!~!}')[0] + data.d[2 * Math.round(3 * (data.d.length / 2) / 4) + 1].substr(7).split('{!~!}')[0]);
                    var CenterLat = (data.d[2 * Math.round(1 * (data.d.length / 2) / 4) + 1].substr(7).split('{!~!}')[1] + data.d[2 * Math.round(3 * (data.d.length / 2) / 4) + 1].substr(7).split('{!~!}')[1]);
                    SetMarkerAndloadItNoDelete(data.d);
                    MapSetCenterWithZoom(CenterLong, CenterLat, 14);
                }
            }
        });
    }

</script>

