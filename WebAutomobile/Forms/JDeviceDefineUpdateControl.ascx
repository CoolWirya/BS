<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="JDeviceDefineUpdateControl.ascx.cs" Inherits="WebAutomobile.Forms.JDeviceDefineUpdateControl" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>

<div class="BigTitle">دستگاه</div>
<table style="width: 500px">
    <tr class="Table_RowB">
        <td style="width: 150px">نوع دستگاه:</td>
        <td>
            <telerik:RadComboBox runat="server" ID="cmbDeviceType" Width="100%"></telerik:RadComboBox>
        </td>
    </tr>
    <tr class="Table_RowC">
        <td style="width: 150px">IMEI:</td>
        <td>
            <telerik:RadTextBox runat="server" ID="txtIMEI" Width="100%"></telerik:RadTextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidatortxtIMEI" runat="server" 
                Display="Dynamic" ControlToValidate="txtIMEI" ValidationGroup="Device" ErrorMessage="*"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr class="Table_RowB">
        <td style="width: 150px">شماره سریال:</td>
        <td>
            <telerik:RadTextBox runat="server" ID="txtID" Width="100%"></telerik:RadTextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                Display="Dynamic" ControlToValidate="txtID" ValidationGroup="Device" ErrorMessage="*"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr class="Table_RowC">
        <td style="width: 150px">شماره سیمکارت:</td>
        <td>
            <telerik:RadTextBox runat="server" ID="txtSimCardNumber" Width="100%"></telerik:RadTextBox>
               <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                Display="Dynamic" ControlToValidate="txtSimCardNumber" ValidationGroup="Device" ErrorMessage="*"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr class="Table_RowB">
        <td style="width: 150px">Mac:</td>
        <td>
            <telerik:RadTextBox runat="server" ID="txtMacNumber" Width="100%"></telerik:RadTextBox>
                 <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                Display="Dynamic" ControlToValidate="txtMacNumber" ValidationGroup="Device" ErrorMessage="*"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr class="Table_RowC">
        <td style="width: 150px">بارکد:</td>
        <td>
            <telerik:RadTextBox runat="server" ID="txtBarCode" Width="100%"></telerik:RadTextBox>
        </td>
    </tr>
     <tr class="Table_RowB">
        <td style="width: 150px">مدل:</td>
        <td>
            <telerik:RadTextBox runat="server" ID="txtModel" Width="100%"></telerik:RadTextBox>
        </td>
    </tr>
</table>
<div class="FormButtons">
    <telerik:RadButton runat="server" ID="btnSave" Text="ذخیره" AutoPostBack="true" Width="100px" Height="35px" OnClick="btnSave_Click" ValidationGroup="Device" />
    <telerik:RadButton runat="server" ID="btnClose" Text="بازگشت" OnClientClicked="CloseDialog" AutoPostBack="false" Width="100px" Height="35px" />
    <telerik:RadButton runat="server" ID="btnDelete" Text="حذف" AutoPostBack="true" Width="100px" Height="35px" OnClick="btnDelete_Click" CssClass="floatLeft" OnClientClicking="OnClientClicking" />
</div>
