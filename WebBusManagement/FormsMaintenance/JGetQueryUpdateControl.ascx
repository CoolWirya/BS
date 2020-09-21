<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="JGetQueryUpdateControl.ascx.cs" Inherits="WebBusManagement.FormsMaintenance.JGetQueryUpdateControl" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register Assembly="WebControllers" Namespace="WebControllers.MainControls.Grid" TagPrefix="cc1" %>
<%@ Register Src="~/WebControllers/MainControls/Date/JDateControl.ascx" TagPrefix="uc1" TagName="JDateControl" %>

<telerik:RadAjaxManagerProxy runat="server" ID="AjaxManagerProxy_Control">
    <AjaxSettings>
        <telerik:AjaxSetting AjaxControlID="cmbZone">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="cmbLine" />
                <telerik:AjaxUpdatedControl ControlID="cmbBus" />
            </UpdatedControls>
        </telerik:AjaxSetting>
    </AjaxSettings>
</telerik:RadAjaxManagerProxy>
<telerik:RadAjaxManagerProxy runat="server" ID="AjaxManagerProxy_Control1">
    <AjaxSettings>
        <telerik:AjaxSetting AjaxControlID="cmbLine">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="cmbZone" />
                <telerik:AjaxUpdatedControl ControlID="cmbBus" />
            </UpdatedControls>
        </telerik:AjaxSetting>
    </AjaxSettings>
</telerik:RadAjaxManagerProxy>
<telerik:RadAjaxManagerProxy runat="server" ID="AjaxManagerProxy_Control2">
    <AjaxSettings>
        <telerik:AjaxSetting AjaxControlID="cmbBus">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="cmbZone" />
                <telerik:AjaxUpdatedControl ControlID="cmbLine" />
            </UpdatedControls>
        </telerik:AjaxSetting>
    </AjaxSettings>
</telerik:RadAjaxManagerProxy>

<div class="BigTitle">ورود کوئری</div>
<table style="width: 500px">
    <tr class="Table_RowB">
        <td style="width: 150px">منطقه:</td>
        <td>
            <telerik:RadComboBox runat="server" ID="cmbZone" Width="100%" Filter="Contains" AutoPostBack="true"
                OnSelectedIndexChanged="cmbZone_SelectedIndexChanged">
            </telerik:RadComboBox>
        </td>
    </tr>
    <tr class="Table_RowC">
        <td style="width: 150px">خط:</td>
        <td>
            <telerik:RadComboBox runat="server" ID="cmbLine" Width="100%" Filter="Contains" AutoPostBack="true"
                OnSelectedIndexChanged="cmbLine_SelectedIndexChanged">
            </telerik:RadComboBox>
        </td>
    </tr>
    <tr class="Table_RowB">
        <td style="width: 150px">اتوبوس:</td>
        <td>
            <telerik:RadComboBox runat="server" ID="cmbBus" Width="100%" Filter="Contains" AutoPostBack="true"
                OnSelectedIndexChanged="cmbBus_SelectedIndexChanged">
            </telerik:RadComboBox>
        </td>
    </tr>
    <tr class="Table_RowC">
        <td style="width: 150px">کوئری:</td>
        <td>
            <telerik:RadComboBox ID="cmbQuery" runat="server" Width="100%">
                <Items>
                </Items>
            </telerik:RadComboBox>
        </td>
    </tr>
    <tr class="Table_RowB">
        <td style="width: 150px">دیتابیس:</td>
        <td>
            <telerik:RadComboBox ID="cmbDataBase" runat="server" Width="100%">
                <Items>
                    <telerik:RadComboBoxItem Value="Local_Eticket_Sqlite" Text="Local_Eticket_Sqlite"/>
                    <telerik:RadComboBoxItem Value="Local_Avl_Sqlite" Text="Local_Avl_Sqlite"/>
                    <telerik:RadComboBoxItem Value="Local_Send_Sqlite" Text="Local_Send_Sqlite"/>
                    <telerik:RadComboBoxItem Value="Local_Bus_Sqlite" Text="Local_Bus_Sqlite"/>
                </Items>
            </telerik:RadComboBox>
        </td>
    </tr>
</table>
<telerik:RadButton runat="server" ID="btnSave" Text="ثبت تنظیمات" AutoPostBack="true" Width="100px" Height="35px" OnClick="btnSave_Click" ValidationGroup="Settings" />
<telerik:RadButton runat="server" ID="btnClose" Text="بازگشت" OnClientClicked="CloseDialog" AutoPostBack="false" Width="100px" Height="35px" OnClick="btnClose_Click" />

<br />
<table style="width: 100%; height: auto; margin-top: 15px">
    <tr>
        <td style="width: 100%; height: auto; overflow: auto"><cc1:JGridView runat="server" id="RadGridReport"></cc1:JGridView>
            <telerik:RadGrid runat="server" ID="RadGridReport1" OnPreRender="RadGridReport1_PreRender" AllowPaging="true" PageSize="15" AllowMultiRowSelection="false">
                
            </telerik:RadGrid>
        </td>
    </tr>
</table>
