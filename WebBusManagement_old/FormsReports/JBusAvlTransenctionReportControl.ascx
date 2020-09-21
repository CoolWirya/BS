<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="JBusAvlTransenctionReportControl.ascx.cs" Inherits="WebBusManagement.FormsReports.JBusAvlTransenctionReportControl" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register Src="~/WebControllers/MainControls/Date/JDateControl.ascx" TagPrefix="uc1" TagName="JDateControl" %>
<%@ Register Src="~/WebControllers/MainControls/OpenLayersMap/OpenLayersMap.ascx" TagPrefix="uc2" TagName="OpenLayersMap" %>

<div class="BigTitle">گزارش تراکنش های AVL اتوبوس</div>
<table style="width: 500px">
    <tr class="Table_RowB">
        <td style="width: 150px">اتوبوس:</td>
        <td>
            <telerik:RadComboBox runat="server" ID="cmbBus" Width="100%" Filter="Contains">
            </telerik:RadComboBox>
        </td>
    </tr>
    <tr class="Table_RowC">
        <td style="width: 150px">از تاریخ:</td>
        <td>
            <uc1:JDateControl runat="server" id="txtFromDate" />
        </td>
    </tr>
    <tr class="Table_RowB">
        <td style="width: 150px">از ساعت:</td>
        <td style="direction: ltr">
            <asp:RangeValidator ID="RangeValidator3" runat="server" ErrorMessage="00 تا 23" ControlToValidate="txtStartTimeHour" MinimumValue="00"
                MaximumValue="23" ValidationGroup="Report" Display="Dynamic"></asp:RangeValidator>
            <telerik:RadTextBox runat="server" ID="txtStartTimeHour" Width="40px" MaxLength="2" EmptyMessage="ساعت"></telerik:RadTextBox>
            :
                    <telerik:RadTextBox runat="server" ID="txtStartTimeMinute" Width="40px" MaxLength="2" EmptyMessage="دقیقه"></telerik:RadTextBox>
            <asp:RangeValidator ID="RangeValidator4" runat="server" ErrorMessage="00 تا 59" ControlToValidate="txtStartTimeMinute" MinimumValue="00"
                MaximumValue="59" ValidationGroup="Report" Display="Dynamic"></asp:RangeValidator>
        </td>
    </tr>
    <tr class="Table_RowC">
        <td style="width: 150px">تا تاریخ:</td>
        <td>
            <uc1:JDateControl runat="server" id="txtToDate" />
        </td>
    </tr>
    <tr class="Table_RowB">
        <td style="width: 150px">تا ساعت:</td>
        <td style="direction: ltr">
            <asp:RangeValidator ID="RangeValidator1" runat="server" ErrorMessage="00 تا 23" ControlToValidate="txtFinishTimeHour" MinimumValue="00"
                MaximumValue="23" ValidationGroup="Report" Display="Dynamic"></asp:RangeValidator>
            <telerik:RadTextBox runat="server" ID="txtFinishTimeHour" Width="40px" MaxLength="2" EmptyMessage="ساعت"></telerik:RadTextBox>
            :
                    <telerik:RadTextBox runat="server" ID="txtFinishTimeMinute" Width="40px" MaxLength="2" EmptyMessage="دقیقه"></telerik:RadTextBox>
            <asp:RangeValidator ID="RangeValidator2" runat="server" ErrorMessage="00 تا 59" ControlToValidate="txtFinishTimeMinute" MinimumValue="00"
                MaximumValue="59" ValidationGroup="Report" Display="Dynamic"></asp:RangeValidator>
        </td>
    </tr>
</table>
<telerik:RadButton runat="server" ID="btnSave" Text="مشاهده گزارش" AutoPostBack="true" Width="100px" Height="35px" ValidationGroup="Report" OnClick="btnSave_Click" />
<telerik:RadButton runat="server" ID="btnClose" Text="بازگشت" OnClientClicked="CloseDialog" AutoPostBack="false" Width="100px" Height="35px" />
<center>
        <div id="Div_AvlTMap" style="width: 700px; height: 300px;display:none">
            <uc2:openlayersmap runat="server" id="OpenLayersMapAvlT" />
            <center>
                <a onclick="CloseMap();">بستن نقشه</a>
            </center>
        </div>
    </center>
<table style="width: 100%; height: auto; margin-top: 15px">
    <tr>
        <td style="width: 100%; height: auto; overflow: auto">
            <telerik:RadGrid runat="server" ID="RadGridReport1" OnPreRender="RadGridReport1_PreRender" AllowPaging="true" PageSize="5" AllowMultiRowSelection="false">
                <ClientSettings EnablePostBackOnRowClick="false">
                    <Selecting AllowRowSelect="true" />
                    <ClientEvents OnRowSelected="GetPointAndShowOnMap" />
                </ClientSettings>
                <SelectedItemStyle BackColor="Yellow" BorderColor="YellowGreen" BorderStyle="Dashed"
                    BorderWidth="1px" />
            </telerik:RadGrid>
        </td>
    </tr>
</table>

<script type="text/javascript">
    function GetPointAndShowOnMap(sender, eventArgs) {
        var grid = $find("<%=RadGridReport1.ClientID %>");
        if (grid != null) {
            var MasterTable = grid.get_masterTableView();
            var row = MasterTable.get_dataItems()[eventArgs.get_itemIndexHierarchical()];
            //var selectedRows = MasterTable.get_selectedItems();
            var Lat = null;
            var Lan = null;
            if (row != null) {
                Lat = MasterTable.getCellByColumnUniqueName(row, "Latitude");
                Lan = MasterTable.getCellByColumnUniqueName(row, "Longitude");
            }
            if (Lat != null && Lan != null) {
                //alert(Lan.innerHTML.toString() + " " + Lat.innerHTML.toString());
                $("#Div_AvlTMap").css('display', 'block');
                RemoveMarkers();
                MapSetCenter(Lan.innerHTML.toString(), Lat.innerHTML.toString());
                AddMarker(Lan.innerHTML.toString(), Lat.innerHTML.toString(), 'MarkerAvlTransaction', '', '../WebBusManagement/Images/bus_s64.png', 48, 32, 0, 0, true);
            }
            else {
                $("#Div_AvlTMap").css('display', 'none');
            }
        }
    }

    function CloseMap() {
        $("#Div_AvlTMap").css('display', 'none');
    }
</script>
