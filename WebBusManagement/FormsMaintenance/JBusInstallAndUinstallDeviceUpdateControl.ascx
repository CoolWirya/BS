<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="JBusInstallAndUinstallDeviceUpdateControl.ascx.cs" Inherits="WebBusManagement.FormsMaintenance.JBusInstallAndUinstallDeviceUpdateControl" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register Src="~/WebControllers/MainControls/Date/JDateControl.ascx" TagPrefix="uc1" TagName="JDateControl" %>
<%@ Register Src="~/WebControllers/MainControls/Persons/JSearchPersonControl.ascx" TagPrefix="uc2" TagName="JSearchPersonControl" %>
<%@ Register Src="~/WebControllers/MainControls/CustomListSelector/JCustomListSelectorControl.ascx" TagPrefix="uc3" TagName="JCustomListSelectorControl" %>

<div class="BigTitle">ثبت نصب و فک دستگاه</div>
<table style="width: 500px">
    <tr class="Table_RowB">
        <td style="width: 150px">تاریخ:</td>
        <td>
            <uc1:JDateControl runat="server" id="txtDate" />
        </td>
    </tr>
    <tr class="Table_RowC">
        <td style="width: 150px">اتوبوس:</td>
        <td>
            <telerik:RadComboBox runat="server" ID="cmbBus" Width="100%" Filter="Contains"></telerik:RadComboBox>
        </td>
    </tr>
    <tr class="Table_RowB">
        <td style="width: 150px">دستگاه:</td>
        <td>
            <uc3:JCustomListSelectorControl runat="server" id="JCustomListSelectorControlDevice" />
        </td>
    </tr>
    <tr class="Table_RowC">
        <td style="width: 150px">نصاب:</td>
        <td>
            <uc2:JSearchPersonControl runat="server" id="JSearchPersonControlInstaller" />
        </td>
    </tr>
    <tr class="Table_RowB">
        <td style="width: 150px">نوع عملیات:</td>
        <td>
            <telerik:RadComboBox runat="server" ID="cmbType" Width="100%">
                <Items>
                    <telerik:RadComboBoxItem Text="نصب" Value="0" Selected="true" />
                    <telerik:RadComboBoxItem Text="فک" Value="1" />
                </Items>
            </telerik:RadComboBox>
        </td>
    </tr>
    <tr class="Table_RowB">
        <td style="width: 150px">دلیل فک یا نصب:</td>
        <td>
            <telerik:RadComboBox runat="server" ID="cmbBusFailureType" Width="100%"></telerik:RadComboBox>
        </td>
    </tr>
    <tr class="Table_RowC">
        <td style="width: 150px">توضیحات:</td>
        <td>
            <telerik:RadTextBox runat="server" ID="txtDiscription" TextMode="MultiLine" Width="96%"></telerik:RadTextBox></td>
    </tr>
</table>
<telerik:RadButton runat="server" ID="btnSave" Text="ذخیره" AutoPostBack="true" Width="100px" Height="35px" OnClick="btnSave_Click" />
<telerik:RadButton runat="server" ID="btnClose" Text="بازگشت" OnClientClicked="CloseDialog" AutoPostBack="false" Width="100px" Height="35px" />
