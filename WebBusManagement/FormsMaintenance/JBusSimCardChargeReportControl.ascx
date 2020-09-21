<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="JBusSimCardChargeReportControl.ascx.cs" Inherits="WebBusManagement.FormsMaintenance.JBusSimCardChargeReportControl" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register Assembly="WebControllers" Namespace="WebControllers.MainControls.Grid" TagPrefix="cc1" %>

<div class="BigTitle">گزارش وضعیت شارژ سیم کارت ها</div>
<table style="width: 500px">
    <tr class="Table_RowB">
        <td style="width: 150px">میزان شارژ:</td>
        <td>
            <telerik:RadComboBox runat="server" ID="cmbMode" Width="30%">
                <Items>
                    <telerik:RadComboBoxItem Text="کمتر از" Value="0" />
                    <telerik:RadComboBoxItem Text="بیشتر از" Value="1" />
                    <telerik:RadComboBoxItem Text="برابر با" Value="2" />
                </Items>
            </telerik:RadComboBox>

            <telerik:RadTextBox runat="server" ID="txtCharge" Width="70px" Text="10000" MaxLength="5"></telerik:RadTextBox>ریال
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*"
                ControlToValidate="txtCharge" ValidationGroup="Report" Display="Dynamic"></asp:RequiredFieldValidator>
            <asp:RangeValidator ID="RangeValidator1" runat="server" ErrorMessage="0 تا 10000000" ControlToValidate="txtCharge" MinimumValue="0"
                MaximumValue="10000000" ValidationGroup="Report" Display="Dynamic"></asp:RangeValidator>
        </td>
    </tr>
</table>
<telerik:RadButton runat="server" ID="btnSave" Text="مشاهده گزارش" AutoPostBack="true" Width="100px" Height="35px" OnClick="btnSave_Click" />
<telerik:RadButton runat="server" ID="btnClose" Text="بازگشت" OnClientClicked="CloseDialog" AutoPostBack="false" Width="100px" Height="35px" />
<table style="width: 100%; height: auto; margin-top: 15px">
    <tr>
        <td style="width: 100%; height: auto; overflow: auto"><cc1:JGridView runat="server" id="RadGridReport"></cc1:JGridView>
            
        </td>
    </tr>
</table>
