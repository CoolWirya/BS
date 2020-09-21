<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="JTicketCardUpdateControl.ascx.cs" Inherits="WebBusManagement.FormsManagement.JTicketCardUpdateControl" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register Src="~/WebControllers/MainControls/Persons/JSearchPersonControl.ascx" TagPrefix="uc1" TagName="JSearchPersonControl" %>

<div class="BigTitle">کارت بلیط</div>
<table style="width: 500px">
    <tr class="Table_RowB">
        <td style="width: 150px">شماره RFID:</td>
        <td>
            <telerik:RadTextBox runat="server" ID="txtRFIDNumber" Width="100%"></telerik:RadTextBox>
            <asp:CompareValidator ID="CompareValidatortxtLineNumber" runat="server" Display="Dynamic" ErrorMessage="لطفا عدد وارد کنید" 
                ControlToValidate="txtRFIDNumber" Type="Double" ValidationGroup="Cards"></asp:CompareValidator>
        </td>
    </tr>
    <tr class="Table_RowB">
        <td style="width: 150px">شماره سریال کارت:</td>
        <td>
            <telerik:RadTextBox runat="server" ID="txtSerialNumber" Width="100%" MaxLength="9"></telerik:RadTextBox>
            <asp:CompareValidator ID="CompareValidator1" runat="server" Display="Dynamic" ErrorMessage="لطفا عدد وارد کنید" 
                ControlToValidate="txtRFIDNumber" Type="Double" ValidationGroup="Cards"></asp:CompareValidator>
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
                <Items>
                    <telerik:RadComboBoxItem Text="0" Value="0"/>
                    <telerik:RadComboBoxItem Text="1" Value="1"/>
                    <telerik:RadComboBoxItem Text="2" Value="2"/>
                    <telerik:RadComboBoxItem Text="3" Value="3"/>
                    <telerik:RadComboBoxItem Text="4" Value="4"/>
                    <telerik:RadComboBoxItem Text="5" Value="5"/>
                    <telerik:RadComboBoxItem Text="6" Value="6"/>
                    <telerik:RadComboBoxItem Text="7" Value="7"/>
                    <telerik:RadComboBoxItem Text="8" Value="8"/>
                    <telerik:RadComboBoxItem Text="9" Value="9"/>
                </Items>
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
<telerik:RadButton runat="server" ID="btnSave" Text="ذخیره" AutoPostBack="true" Width="100px" Height="35px" OnClick="btnSave_Click" ValidationGroup="Cards"/>
<telerik:RadButton runat="server" ID="btnClose" Text="بازگشت" OnClientClicked="CloseDialog" AutoPostBack="false" Width="100px" Height="35px" />