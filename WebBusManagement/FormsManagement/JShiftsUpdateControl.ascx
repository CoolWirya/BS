<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="JShiftsUpdateControl.ascx.cs" Inherits="WebBusManagement.FormsManagement.JShiftsUpdateControl" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register Src="~/WebControllers/MainControls/Date/JDateControl.ascx" TagPrefix="uc1" TagName="JDateControl" %>

<div class="BigTitle">شیفت ها</div>
<table style="width: 500px">
    <tr class="Table_RowB">
        <td style="width: 150px">عنوان شیفت:</td>
        <td>
            <telerik:RadTextBox runat="server" ID="txtTitle" Width="100%"></telerik:RadTextBox></td>
    </tr>
    <tr class="Table_RowC">
        <td style="width: 150px">از تاریخ:</td>
        <td>
            <uc1:JDateControl runat="server" id="txtFromDate" />
        </td>
    </tr>
    <tr class="Table_RowB">
        <td style="width: 150px">تا تاریخ:</td>
        <td>
            <uc1:JDateControl runat="server" id="txtToDate" />
        </td>
    </tr>
    <tr class="Table_RowC">
        <td style="width: 150px">از ساعت:</td>
        <td style="direction: ltr">
            <asp:RangeValidator ID="RangeValidator1" runat="server" ErrorMessage="00 تا 23" ControlToValidate="txtStartTimeHour" MinimumValue="00"
                MaximumValue="23" ValidationGroup="Report" Display="Dynamic" Type="Integer"></asp:RangeValidator>
            <telerik:radtextbox runat="server" id="txtStartTimeHour" width="40px" maxlength="2" emptymessage="ساعت"></telerik:radtextbox>
            :
                    <telerik:radtextbox runat="server" id="txtStartTimeMinute" width="40px" maxlength="2" emptymessage="دقیقه"></telerik:radtextbox>
            <asp:RangeValidator ID="RangeValidator2" runat="server" ErrorMessage="00 تا 59" ControlToValidate="txtStartTimeMinute" MinimumValue="00"
                MaximumValue="59" ValidationGroup="Report" Display="Dynamic" Type="Integer"></asp:RangeValidator>
            :
                    <telerik:radtextbox runat="server" id="txtStartTimeSecond" width="40px" maxlength="2" emptymessage="ثانیه"></telerik:radtextbox>
            <asp:RangeValidator ID="RangeValidator5" runat="server" ErrorMessage="00 تا 59" ControlToValidate="txtStartTimeSecond" MinimumValue="00"
                MaximumValue="59" ValidationGroup="Report" Display="Dynamic" Type="Integer"></asp:RangeValidator>
        </td>
    </tr>
    <tr class="Table_RowB">
        <td style="width: 150px">تا ساعت:</td>
        <td style="direction: ltr">
            <asp:RangeValidator ID="RangeValidator3" runat="server" ErrorMessage="00 تا 23" ControlToValidate="txtEndTimeHour" MinimumValue="00"
                MaximumValue="23" ValidationGroup="Report" Display="Dynamic" Type="Integer"></asp:RangeValidator>
            <telerik:radtextbox runat="server" id="txtEndTimeHour" width="40px" maxlength="2" emptymessage="ساعت"></telerik:radtextbox>
            :
                    <telerik:radtextbox runat="server" id="txtEndTimeMinute" width="40px" maxlength="2" emptymessage="دقیقه"></telerik:radtextbox>
            <asp:RangeValidator ID="RangeValidator4" runat="server" ErrorMessage="00 تا 59" ControlToValidate="txtEndTimeMinute" MinimumValue="00"
                MaximumValue="59" ValidationGroup="Report" Display="Dynamic" Type="Integer"></asp:RangeValidator>
            :
                    <telerik:radtextbox runat="server" id="txtEndTimeSecond" width="40px" maxlength="2" emptymessage="ثانیه"></telerik:radtextbox>
            <asp:RangeValidator ID="RangeValidator6" runat="server" ErrorMessage="00 تا 59" ControlToValidate="txtEndTimeSecond" MinimumValue="00"
                MaximumValue="59" ValidationGroup="Report" Display="Dynamic" Type="Integer"></asp:RangeValidator>
        </td>
    </tr>
</table>
<div class="FormButtons">
    <telerik:RadButton runat="server" ID="btnSave" Text="ذخیره" AutoPostBack="true" Width="100px" Height="35px" OnClick="btnSave_Click" />
    <telerik:RadButton runat="server" ID="btnClose" Text="بازگشت" OnClientClicked="CloseDialog" AutoPostBack="false" Width="100px" Height="35px" />
     <telerik:RadButton runat="server" ID="btnDelete" Text="حذف" AutoPostBack="true" Width="100px" Height="35px" OnClick="btnDelete_Click" CssClass="floatLeft" OnClientClicking="OnClientClicking" />
</div>
