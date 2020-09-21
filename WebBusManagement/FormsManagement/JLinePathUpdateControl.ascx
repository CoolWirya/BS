<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="JLinePathUpdateControl.ascx.cs" Inherits="WebBusManagement.FormsManagement.JLinePathUpdateControl" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register Src="~/WebControllers/MainControls/OpenLayersMap/OpenLayersMap.ascx" TagPrefix="uc1" TagName="OpenLayersMap" %>

<div class="BigTitle">مسیر خط</div>
<div style="width: 100%; height: 80%">
    <uc1:openlayersmap runat="server" id="OpenLayersMapLinePath" />
</div>
<div style="clear: both; height: 10px"></div>
<div class="FormButtons" style="z-index:2001">
    <telerik:RadButton runat="server" ID="btnSave" Text="ذخیره" AutoPostBack="true" Width="100px" Height="35px" OnClientClicked="SaveUserMarkers" OnClick="btnSave_Click"/>
    <telerik:RadButton runat="server" ID="btnClose" Text="بازگشت" OnClientClicked="CloseDialog" AutoPostBack="false" Width="100px" Height="35px" />
    <telerik:RadButton runat="server" ID="btnDelete" Text="حذف" AutoPostBack="true" Width="100px" Height="35px" OnClick="btnDelete_Click" CssClass="floatLeft" OnClientClicking="OnClientClicking" />
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
