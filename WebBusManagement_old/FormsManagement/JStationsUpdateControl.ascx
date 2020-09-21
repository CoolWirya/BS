<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="JStationsUpdateControl.ascx.cs" Inherits="WebBusManagement.FormsManagement.JStationsUpdateControl" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register Src="~/WebControllers/Property/JPropertyViewControl.ascx" TagPrefix="uc1" TagName="JPropertyViewControl" %>
<%@ Register Src="~/WebControllers/MainControls/OpenLayersMap/OpenLayersMap.ascx" TagPrefix="uc1" TagName="OpenLayersMap" %>

<div class="BigTitle">ایستگاه</div>
<telerik:RadTabStrip runat="server" ID="RadTabStrip1"
    SelectedIndex="0" MultiPageID="RadMultiPage1" Width="100%" OnClientTabSelected="OnClientTabSelected">
    <Tabs>
        <telerik:RadTab Text="ایستگاه">
        </telerik:RadTab>
        <telerik:RadTab Text="نقشه">
        </telerik:RadTab>
    </Tabs>
</telerik:RadTabStrip>
<telerik:RadMultiPage runat="server" ID="RadMultiPage1" SelectedIndex="0"
    Width="700px">
    <telerik:RadPageView runat="server" ID="RadPageView1">
        <table style="width: 500px">
            <tr class="Table_RowB">
                <td style="width: 150px">نام:</td>
                <td>
                    <telerik:RadTextBox runat="server" ID="txtName" Width="96%"></telerik:RadTextBox>
                </td>
            </tr>
            <tr class="Table_RowC">
                <td style="width: 150px">منطقه:</td>
                <td>
                    <telerik:RadComboBox runat="server" ID="cmbZoneCode" Width="100%"></telerik:RadComboBox>
                </td>
            </tr>
            <tr class="Table_RowB">
                <td style="width: 150px">آدرس:</td>
                <td>
                    <telerik:RadTextBox runat="server" ID="txtAddress" Width="96%" TextMode="MultiLine"></telerik:RadTextBox>
                </td>
            </tr>
            <tr class="Table_RowC">
                <td style="width: 150px">نوع ایستگاه:</td>
                <td>
                    <telerik:RadComboBox runat="server" ID="cmbStationType" Width="100%"></telerik:RadComboBox>
                </td>
            </tr>
            <tr class="Table_RowB">
                <td style="width: 150px">طول جغرافیایی:</td>
                <td>
                    <telerik:RadTextBox runat="server" ID="txtLng" Width="96%"></telerik:RadTextBox>
                </td>
            </tr>
            <tr class="Table_RowC">
                <td style="width: 150px">عرض جغرافیایی:</td>
                <td>

                    <telerik:RadTextBox runat="server" ID="txtLat" Width="96%"></telerik:RadTextBox>
                </td>
            </tr>
            <tr class="Table_RowC">
                <td style="width: 150px"></td>
                <td>
                    <input runat="server" type="checkbox" id="chkIsTerminal" name="chkIsTerminal" />پایانه
                </td>
            </tr>
            <tr class="Table_RowB">
                <td style="width: 150px">ویژگی ها:</td>
                <td>
                    <uc1:jpropertyviewcontrol runat="server" id="JPropertyViewControl" />
                </td>
            </tr>
        </table>
    </telerik:RadPageView>
    <telerik:RadPageView runat="server" ID="RadPageView2">
    </telerik:RadPageView>
</telerik:RadMultiPage>
<div id="Div_StationMap" style="float: right; width: 700px; height: 280px; text-align: right; visibility: hidden">
    <uc1:openlayersmap runat="server" id="OpenLayersMapStations" />
</div>
<div style="clear: both; height: 10px"></div>
<telerik:RadButton runat="server" ID="btnSave" Text="ذخیره" AutoPostBack="true" Width="100px" Height="35px" OnClick="btnSave_Click" />
<telerik:RadButton runat="server" ID="btnClose" Text="بازگشت" OnClientClicked="CloseDialog" AutoPostBack="false" Width="100px" Height="35px" />

<script type="text/javascript">
    $("#Div_StationMap").css('height', '1px');
    function OnClientTabSelected(sender, eventArgs) {
        var tab = eventArgs.get_tab();
        if (tab.get_text() == "نقشه") {
            $("#Div_StationMap").css('visibility', 'visible');
            $("#Div_StationMap").css('height', '280px');
            $("#Div_StationMap").fadeIn();
        }
        else {
            $("#Div_StationMap").css('visibility', 'hidden');
            $("#Div_StationMap").css('height', '1px');
            $("#Div_StationMap").css('display', 'none');
        }
    }
</script>
