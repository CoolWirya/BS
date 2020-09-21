<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="JTicketCardUpdateControl.ascx.cs" Inherits="WebBusManagement.FormsManagement.JTicketCardUpdateControl" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register Src="~/WebControllers/MainControls/Persons/JSearchPersonControl.ascx" TagPrefix="uc1" TagName="JSearchPersonControl" %>

<div class="BigTitle">کارت بلیط</div>
<table style="width: 500px">
    <tr class="Table_RowB">
        <td style="width: 150px">شماره RFID:</td>
        <td>
            <telerik:RadNumericTextBox ID="txtRFIDNumber" NumberFormat-DecimalDigits="0" 
                NumberFormat-GroupSeparator="" NumberFormat-AllowRounding="false" runat="server" Width="100%"></telerik:RadNumericTextBox>
<%--            <telerik:RadTextBox runat="server" ID="txtRFIDNumber" Width="100%"></telerik:RadTextBox>
            <asp:CompareValidator ID="CompareValidatortxtLineNumber" runat="server" Display="Dynamic" ErrorMessage="لطفا عدد وارد کنید"
                ControlToValidate="txtRFIDNumber" Type="Double" ValidationGroup="Cards"></asp:CompareValidator>--%>
        </td>
    </tr>
    <tr class="Table_RowB">
        <td style="width: 150px">شماره سریال کارت:</td>
        <td>
            <telerik:RadNumericTextBox ID="txtSerialNumber" MaxLength="9" NumberFormat-DecimalDigits="0" 
                NumberFormat-GroupSeparator="" NumberFormat-AllowRounding="false" runat="server" Width="100%"></telerik:RadNumericTextBox>
<%--            <telerik:RadNumericTextBox runat="server" ID="txtSerialNumber" Width="100%" MaxLength="9"></telerik:RadNumericTextBox>
            <asp:CompareValidator ID="CompareValidator1" runat="server" Display="Dynamic" ErrorMessage="لطفا عدد وارد کنید"
                ControlToValidate="txtRFIDNumber" Type="Double" ValidationGroup="Cards"></asp:CompareValidator>--%>
        </td>
    </tr>
    <tr class="Table_RowC">
        <td style="width: 150px">وضعیت:</td>
        <td>
            <asp:CheckBox ID="chkStatus" runat="server" Text="فعال" />
        </td>
    </tr>
    <tr class="Table_RowB">
        <td style="width: 150px">توضیحات:</td>
        <td>
            <telerik:RadTextBox runat="server" ID="txtDiscription" Width="100%" TextMode="MultiLine"></telerik:RadTextBox>
        </td>
    </tr>
    <tr class="Table_RowC">
        <td style="width: 150px">نوع کارت:</td>
        <td>
            <telerik:RadComboBox runat="server" ID="cmbCardType" Width="100%">
              
            </telerik:RadComboBox>
        </td>
    </tr>
    <tr class="Table_RowB">
        <td style="width: 150px">شخص:</td>
        <td>
            <uc1:JSearchPersonControl runat="server" id="JSearchPersonControl" />
        </td>
    </tr>
</table>
<div class="FormButtons">
    <telerik:RadButton runat="server" ID="btnSave" Text="ذخیره" AutoPostBack="true" Width="100px" Height="35px" OnClick="btnSave_Click" />
    <telerik:RadButton runat="server" ID="btnClose" Text="بازگشت" OnClientClicked="CloseDialog" AutoPostBack="false" Width="100px" Height="35px" />
    <telerik:RadButton runat="server" ID="btnDelete" Text="حذف" AutoPostBack="true" Width="100px" Height="35px" OnClick="btnDelete_Click" CssClass="floatLeft" OnClientClicking="OnClientClicking" />
</div>
