<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="JInsertBusFailureUpdateControl.ascx.cs" Inherits="WebBusManagement.FormsMaintenance.JInsertBusFailureUpdateControl" %>
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
            <asp:RangeValidator ID="RangeValidator3" runat="server" ErrorMessage="00 تا 23" ControlToValidate="txtStartTimeHour" MinimumValue="00"
                MaximumValue="23" Display="Dynamic"></asp:RangeValidator>
            <telerik:RadTextBox runat="server" ID="txtStartTimeHour" Width="40px" MaxLength="2" EmptyMessage="ساعت" ReadOnly="true"></telerik:RadTextBox>
            :
                    <telerik:RadTextBox runat="server" ID="txtStartTimeMinute" Width="40px" MaxLength="2" EmptyMessage="دقیقه" ReadOnly="true"></telerik:RadTextBox>
            <asp:RangeValidator ID="RangeValidator4" runat="server" ErrorMessage="00 تا 59" ControlToValidate="txtStartTimeMinute" MinimumValue="00"
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
            <asp:RangeValidator ID="RangeValidator1" runat="server" ErrorMessage="00 تا 23" ControlToValidate="txtEndTimeHour" MinimumValue="00"
                MaximumValue="23" Display="Dynamic"></asp:RangeValidator>
            <telerik:RadTextBox runat="server" ID="txtEndTimeHour" Width="40px" MaxLength="2" EmptyMessage="ساعت" ReadOnly="true"></telerik:RadTextBox>
            :
                    <telerik:RadTextBox runat="server" ID="txtEndTimeMinute" Width="40px" MaxLength="2" EmptyMessage="دقیقه" ReadOnly="true"></telerik:RadTextBox>
            <asp:RangeValidator ID="RangeValidator2" runat="server" ErrorMessage="00 تا 59" ControlToValidate="txtEndTimeMinute" MinimumValue="00"
                MaximumValue="59" Display="Dynamic"></asp:RangeValidator>
        </td>
    </tr>
    <tr class="Table_RowB">
        <td style="width: 150px">اتوبوس:</td>
        <td>
            <telerik:RadComboBox runat="server" ID="cmbBus" Width="100%" Filter="Contains"></telerik:RadComboBox>
        </td>
    </tr>
    <tr class="Table_RowC">
        <td style="width: 150px">دلیل عدم فعالیت:</td>
        <td>
            <telerik:RadComboBox runat="server" ID="cmbBusFailureType" Width="100%"></telerik:RadComboBox>
        </td>
    </tr>
    <tr class="Table_RowB">
        <td style="width: 150px">توضیحات:</td>
        <td>
            <telerik:RadTextBox runat="server" ID="txtDiscription" TextMode="MultiLine" Width="96%"></telerik:RadTextBox></td>
    </tr>
</table>
<telerik:RadButton runat="server" ID="btnSave" Text="ذخیره" AutoPostBack="true" Width="100px" Height="35px" OnClick="btnSave_Click" />
<telerik:RadButton runat="server" ID="btnClose" Text="بازگشت" OnClientClicked="CloseDialog" AutoPostBack="false" Width="100px" Height="35px" />
