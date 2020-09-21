<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="JBusPassingStationShowPointUpdateControl.ascx.cs" Inherits="WebBusManagement.FormsReports.JBusPassingStationShowPointUpdateControl" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register Src="~/WebControllers/MainControls/OpenLayersMap/OpenLayersMap.ascx" TagPrefix="uc1" TagName="OpenLayersMap" %>

<div class="BigTitle">نمایش نقطه عبور از ایستگاه</div>
<div style="float:right;width:300px;height:300px;padding-right:5px;font-size:16px"><%=StrInfo %></div>
<div id="Div_StationMap" style="float: left; width: 500px; height: 320px;">
    <uc1:openlayersmap runat="server" id="OpenLayersMapStations" />
</div>
<div style="clear: both; height: 1px"></div>
<div class="FormButtons">
    <telerik:RadButton runat="server" ID="btnClose" Text="بازگشت" OnClientClicked="CloseDialog" AutoPostBack="false" Width="100px" Height="35px" />
</div>
<input type="hidden" runat="server" id="PathMapStationAc" />
<input type="hidden" runat="server" id="LineCode" />
<script type="text/javascript">
    GetStation();
    function GetStation() {
        var paramStr = new Array();
        paramStr[0] = $("#<%=LineCode.ClientID%>").val();
        var data = "{actionString:'" + $("#<%=PathMapStationAc.ClientID %>").val() + "',param:" + JSON.stringify(paramStr) + "}";
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
                SetMarkerAndloadIt(data.d);
            }
        });
    }
</script>
