<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="JBusSendTicketCountRateReportControl.ascx.cs" Inherits="WebBusManagement.FormsMaintenance.JBusSendTicketCountRateReportControl" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register Assembly="WebControllers" Namespace="WebControllers.MainControls.Grid" TagPrefix="cc1" %>
<%@ Register Src="~/WebControllers/MainControls/Date/JDateControl.ascx" TagPrefix="uc1" TagName="JDateControl" %>

<div class="BigTitle">گزارش تعداد بلیط ارسالی اتوبوس ها</div>
<table style="width: 500px">
    <tr class="Table_RowC">
        <td style="width: 150px">تعداد بلیط:</td>
        <td>
            <telerik:RadComboBox runat="server" ID="cmbMode" Width="30%">
                <Items>
                    <telerik:RadComboBoxItem Text="کمتر از" Value="0" />
                    <telerik:RadComboBoxItem Text="بیشتر از" Value="1" />
                    <telerik:RadComboBoxItem Text="برابر با" Value="2" />
                </Items>
            </telerik:RadComboBox>

            <telerik:RadTextBox runat="server" ID="txtTicketCount" Width="70px" Text="100"></telerik:RadTextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*"
                ControlToValidate="txtTicketCount" ValidationGroup="Report" Display="Dynamic"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr class="Table_RowB">
        <td style="width: 150px">از تاریخ:</td>
        <td>
            <uc1:JDateControl runat="server" id="txtFromDate" />
        </td>
    </tr>
    <tr class="Table_RowC">
        <td style="width: 150px">تا تاریخ:</td>
        <td>
            <uc1:JDateControl runat="server" id="txtToDate" />
        </td>
    </tr>
</table>
<telerik:RadButton runat="server" ID="btnSave" Text="مشاهده گزارش" AutoPostBack="true" Width="100px" Height="35px" OnClick="btnSave_Click" ValidationGroup="Report"/>
<telerik:RadButton runat="server" ID="btnClose" Text="بازگشت" OnClientClicked="CloseDialog" AutoPostBack="false" Width="100px" Height="35px" />
<table style="width: 100%; height: auto; margin-top: 15px">
    <tr>
        <td style="width: 100%; height: auto; overflow: auto"><cc1:JGridView runat="server" id="RadGridReport"></cc1:JGridView>
            
        </td>
    </tr>
</table>
