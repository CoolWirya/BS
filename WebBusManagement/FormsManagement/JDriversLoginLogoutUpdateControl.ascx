<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="JDriversLoginLogoutUpdateControl.ascx.cs" Inherits="WebBusManagement.FormsManagement.JDriversLoginLogoutUpdateControl" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register Src="~/WebControllers/MainControls/Date/JDateControl.ascx" TagPrefix="uc1" TagName="JDateControl" %>
<%@ Register Src="~/WebControllers/MainControls/Persons/JSearchPersonControl.ascx" TagPrefix="uc1" TagName="JSearchPersonControl" %>
<div class="BigTitle">ورود و خروج راننده</div>
<table style="width: 500px">
    <tr class="Table_RowB">
        <td style="width: 150px">تاریخ:</td>
        <td>
            <uc1:JDateControl runat="server" id="txtDate" />
        </td>
    </tr>
    <tr class="Table_RowC">
        <td style="width: 150px">راننده:</td>
        <td>
            <uc1:JSearchPersonControl runat="server" id="JSearchPersonControl" />
        </td>
    </tr>
    <tr class="Table_RowB">
        <td style="width: 150px">شماره اتوبوس:</td>
        <td>
            <telerik:RadComboBox runat="server" ID="cmbBus" Width="100%" Filter="Contains"></telerik:RadComboBox>
        </td>
    </tr>
    <tr class="Table_RowC">
        <td style="width: 150px">ساعت ورود:</td>
        <td style="direction: ltr">
            <asp:RangeValidator ID="RangeValidator3" runat="server" ErrorMessage="00 تا 23" ControlToValidate="txtStartTimeHour" MinimumValue="0"
                MaximumValue="23" ValidationGroup="LinePrice" Display="Dynamic" Type="Integer"></asp:RangeValidator>
            <telerik:RadTextBox runat="server" ID="txtStartTimeHour" Width="40px" MaxLength="2" EmptyMessage="ساعت"></telerik:RadTextBox>
            :
                    <telerik:RadTextBox runat="server" ID="txtStartTimeMinute" Width="40px" MaxLength="2" EmptyMessage="دقیقه"></telerik:RadTextBox>
            <asp:RangeValidator ID="RangeValidator4" runat="server" ErrorMessage="00 تا 59" ControlToValidate="txtStartTimeMinute" MinimumValue="0"
                MaximumValue="59" ValidationGroup="LinePrice" Display="Dynamic" Type="Integer"></asp:RangeValidator>
        </td>
    </tr>
    <tr class="Table_RowB">
        <td style="width: 150px">ساعت خروج:</td>
        <td style="direction: ltr">
            <asp:RangeValidator ID="RangeValidator1" runat="server" ErrorMessage="00 تا 23" ControlToValidate="txtFinishTimeHour" MinimumValue="0"
                MaximumValue="23" ValidationGroup="LinePrice" Display="Dynamic" Type="Integer"></asp:RangeValidator>
            <telerik:RadTextBox runat="server" ID="txtFinishTimeHour" Width="40px" MaxLength="2" EmptyMessage="ساعت"></telerik:RadTextBox>
            :
                    <telerik:RadTextBox runat="server" ID="txtFinishTimeMinute" Width="40px" MaxLength="2" EmptyMessage="دقیقه"></telerik:RadTextBox>
            <asp:RangeValidator ID="RangeValidator2" runat="server" ErrorMessage="00 تا 59" ControlToValidate="txtFinishTimeMinute" MinimumValue="0"
                MaximumValue="59" ValidationGroup="LinePrice" Display="Dynamic" Type="Integer"></asp:RangeValidator>
        </td>
    </tr>
</table>
<div class="FormButtons">
    <telerik:RadButton runat="server" ID="btnSave" Text="ذخیره" AutoPostBack="true" Width="100px" OnClick="btnSave_Click" Height="35px" ValidationGroup="LinePrice" />
    <telerik:RadButton runat="server" ID="btnClose" Text="بازگشت" OnClientClicked="CloseDialog" AutoPostBack="false" Width="100px" Height="35px" />
    <telerik:RadButton runat="server" ID="btnDelete" Text="حذف" AutoPostBack="true" Width="100px" Height="35px" OnClick="btnDelete_Click" CssClass="floatLeft" OnClientClicking="OnClientClicking" />
</div>


