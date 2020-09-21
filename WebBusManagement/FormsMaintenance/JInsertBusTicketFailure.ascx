<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="JInsertBusTicketFailure.ascx.cs" Inherits="WebBusManagement.FormsMaintenance.JInsertBusTicketFailure" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register Src="~/WebControllers/MainControls/Date/JDateControl.ascx" TagPrefix="uc1" TagName="JDateControl" %>

<div class="BigTitle">ثبت دلیل عدم فعالیت اتوبوس ها</div>
<table style="width: 500px">
    <tr class="Table_RowB">
        <td style="width: 150px">از تاریخ:</td>
        <td>
            <uc1:jdatecontrol runat="server" id="txtFromDate" />
        </td>
    </tr>
    <tr class="Table_RowC">
        <td style="width: 150px">از ساعت:</td>
        <td>
            <asp:RangeValidator ID="RangeValidator5" runat="server" ErrorMessage="00 تا 23" ControlToValidate="txtStartTimeHour" MinimumValue="00"
                MaximumValue="23" Display="Dynamic"></asp:RangeValidator>
            <telerik:RadTextBox runat="server" ID="txtStartTimeHour" Width="40px" MaxLength="2" EmptyMessage="ساعت" ReadOnly="false"></telerik:RadTextBox>
            :
                    <telerik:RadTextBox runat="server" ID="txtStartTimeMinute" Width="40px" MaxLength="2" EmptyMessage="دقیقه" ReadOnly="false"></telerik:RadTextBox>
            <asp:RangeValidator ID="RangeValidator6" runat="server" ErrorMessage="00 تا 59" ControlToValidate="txtStartTimeMinute" MinimumValue="00"
                MaximumValue="59" Display="Dynamic"></asp:RangeValidator>
        </td>
    </tr>
    <tr class="Table_RowB">
        <td style="width: 150px">تا تاریخ:</td>
        <td>
            <uc1:jdatecontrol runat="server" id="txtToDate" />
        </td>
    </tr>
    <tr class="Table_RowC">
        <td style="width: 150px">تا ساعت:</td>
        <td>
            <asp:RangeValidator ID="RangeValidator7" runat="server" ErrorMessage="00 تا 23" ControlToValidate="txtEndTimeHour" MinimumValue="00"
                MaximumValue="23" Display="Dynamic"></asp:RangeValidator>
            <telerik:RadTextBox runat="server" ID="txtEndTimeHour" Width="40px" MaxLength="2" EmptyMessage="ساعت" ReadOnly="false"></telerik:RadTextBox>
            :
                    <telerik:RadTextBox runat="server" ID="txtEndTimeMinute" Width="40px" MaxLength="2" EmptyMessage="دقیقه" ReadOnly="false"></telerik:RadTextBox>
            <asp:RangeValidator ID="RangeValidator8" runat="server" ErrorMessage="00 تا 59" ControlToValidate="txtEndTimeMinute" MinimumValue="00"
                MaximumValue="59" Display="Dynamic"></asp:RangeValidator>
        </td>
    </tr>
    <tr class="Table_RowB">
        <td style="width: 150px">از اتوبوس:</td>
        <td>
            <telerik:RadComboBox runat="server" ID="cmbBus" Width="100%" Filter="Contains"></telerik:RadComboBox>
        </td>
    </tr>
    <tr class="Table_RowB">
        <td style="width: 150px">تعداد:</td>
        <td>
            <telerik:RadTextBox runat="server" ID="txtNumberLimit" Width="100%">
            </telerik:RadTextBox>
        </td>
    </tr>
    <tr class="Table_RowB">
        <td style="width: 150px">تاریخ:</td>
        <td>
            <uc1:jdatecontrol runat="server" id="txtToDateTo" />
        </td>
    </tr>
    <tr class="Table_RowC">
        <td style="width: 150px">از ساعت:</td>
        <td>
            <asp:RangeValidator ID="RangeValidator9" runat="server" ErrorMessage="00 تا 23" ControlToValidate="txtStartTimeHour" MinimumValue="00"
                MaximumValue="23" Display="Dynamic"></asp:RangeValidator>
            <telerik:RadTextBox runat="server" ID="txtStartTimeHourTO" Width="40px" MaxLength="2" EmptyMessage="ساعت" ReadOnly="false"></telerik:RadTextBox>
            :
                    <telerik:RadTextBox runat="server" ID="txtStartTimeMinuteTO" Width="40px" MaxLength="2" EmptyMessage="دقیقه" ReadOnly="false"></telerik:RadTextBox>
            <asp:RangeValidator ID="RangeValidator10" runat="server" ErrorMessage="00 تا 59" ControlToValidate="txtStartTimeMinute" MinimumValue="00"
                MaximumValue="59" Display="Dynamic"></asp:RangeValidator>
        </td>
    </tr>
    <tr class="Table_RowB">
        <td style="width: 150px">به اتوبوس:</td>
        <td>
            <telerik:RadComboBox runat="server" ID="cmbBusTo" Width="100%" Filter="Contains"></telerik:RadComboBox>
        </td>
    </tr>
</table>
<telerik:RadButton runat="server" ID="RadButton1" Text="ذخیره" AutoPostBack="true" Width="100px" Height="35px" OnClick="btnSave_Click" />
<telerik:RadButton runat="server" ID="RadButton2" Text="بازگشت" OnClientClicked="CloseDialog" AutoPostBack="false" Width="100px" Height="35px" />
