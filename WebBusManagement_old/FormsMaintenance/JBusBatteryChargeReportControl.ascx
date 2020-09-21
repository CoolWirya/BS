<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="JBusBatteryChargeReportControl.ascx.cs" Inherits="WebBusManagement.FormsMaintenance.JBusBatteryChargeReportControl" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register Src="~/WebControllers/MainControls/Grid/JGridViewControl.ascx" TagPrefix="uc1" TagName="JGridViewControl" %>

<div class="BigTitle">گزارش وضعیت شارژ باتری دستگاه ها</div>
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

            <telerik:RadTextBox runat="server" ID="txtCharge" Width="50px" Text="10" MaxLength="5"></telerik:RadTextBox>درصد
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*"
                ControlToValidate="txtCharge" ValidationGroup="Report" Display="Dynamic"></asp:RequiredFieldValidator>
            <asp:RangeValidator ID="RangeValidator1" runat="server" ErrorMessage="0 تا 100" ControlToValidate="txtCharge" MinimumValue="0"
                MaximumValue="100" ValidationGroup="Report" Display="Dynamic"></asp:RangeValidator>
        </td>
    </tr>
</table>
<telerik:RadButton runat="server" ID="btnSave" Text="مشاهده گزارش" AutoPostBack="true" Width="100px" Height="35px" OnClick="btnSave_Click" />
<telerik:RadButton runat="server" ID="btnClose" Text="بازگشت" OnClientClicked="CloseDialog" AutoPostBack="false" Width="100px" Height="35px" />
<table style="width: 100%; height: auto; margin-top: 15px">
    <tr>
        <td style="width: 100%; height: auto; overflow: auto">
            <uc1:JGridViewControl runat="server" id="RadGridReport" />
        </td>
    </tr>
</table>
