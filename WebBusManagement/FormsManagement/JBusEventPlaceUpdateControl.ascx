<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="JBusEventPlaceUpdateControl.ascx.cs" Inherits="WebBusManagement.FormsManagement.JBusEventPlaceUpdateControl" %>


<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register Src="~/WebControllers/MainControls/OpenLayersMap/OpenLayersMap.ascx" TagPrefix="uc1" TagName="OpenLayersMap" %>

<div class="BigTitle">مکان های وقایع</div>
<div class="FormContent" style="top: 40px">
    <table style="width: 400px; float: right">
        <tr class="Table_RowA">
            <td style="width: 150px">جزئیات واقعه:</td>
            <td>
                <telerik:RadComboBox runat="server" ID="cmbBusEvent" Width="100%" Filter="Contains"></telerik:RadComboBox>
            </td>
        </tr>
        <tr class="Table_RowB">
            <td style="width: 150px">نام مکان واقعه:</td>
            <td>
                <telerik:RadTextBox runat="server" ID="txtTitle" Width="100%"></telerik:RadTextBox></td>
        </tr>
        <tr class="Table_RowA">
            <td style="width: 150px">طول جغرافیایی:</td>
            <td>
                <telerik:RadTextBox runat="server" ID="txtLongitude" Width="100%"></telerik:RadTextBox></td>
        </tr>
        <tr class="Table_RowB">
            <td style="width: 150px">عرض جغرافیایی:</td>
            <td>
                <telerik:RadTextBox runat="server" ID="txtLatitude" Width="100%"></telerik:RadTextBox></td>
        </tr>
        <tr class="Table_RowA">
            <td style="width: 150px">شعاع محدوده:</td>
            <td>
                <telerik:RadTextBox runat="server" ID="txtRadius" Width="100%" InputType="Number"></telerik:RadTextBox>
            </td>
        </tr>
    </table>
    <div id="Div_StationMap" style="float: left; width: 400px; height: 320px;">
        <uc1:openlayersmap runat="server" id="OpenLayersMapStations" />
    </div>
    <div style="clear: both; height: 1px"></div>
    <telerik:RadButton runat="server" ID="btnSaveFromMap" Text="ذخیره نقطه از نقشه" AutoPostBack="true" Width="200px" Height="35px" OnClick="btnSaveFromMap_Click" />
    <div style="clear: both; height: 1px"></div>
</div>
<input type="hidden" id="LatV" name="LatV" runat="server"/>
<input type="hidden" id="LngV" name="LngV" runat="server"/>
<input type="hidden" runat="server" id="PathMapStationAc" />
<div class="FormButtons">
    <telerik:RadButton runat="server" ID="btnSave" Text="ذخیره" AutoPostBack="true" Width="100px" Height="35px" OnClick="btnSave_Click" />
    <telerik:RadButton runat="server" ID="btnClose" Text="بازگشت" OnClientClicked="CloseDialog" AutoPostBack="false" Width="100px" Height="35px" />
    <telerik:RadButton runat="server" ID="btnDelete" Text="حذف" AutoPostBack="true" Width="100px" Height="35px" OnClick="btnDelete_Click" CssClass="floatLeft" OnClientClicking="OnClientClicking" />
</div>

<script type="text/javascript">
   
   

</script>