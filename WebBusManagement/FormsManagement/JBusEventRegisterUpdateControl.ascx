<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="JBusEventRegisterUpdateControl.ascx.cs" Inherits="WebBusManagement.FormsManagement.JBusEventRegisterUpdateControl" %>


<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register Src="~/WebControllers/MainControls/Date/JDateControl.ascx" TagPrefix="uc1" TagName="JDateControl" %>
<%@ Register Src="~/WebControllers/MainControls/Persons/JSearchPersonControl.ascx" TagPrefix="uc1" TagName="JSearchPersonControl" %>

<telerik:RadAjaxManagerProxy runat="server" ID="AjaxManagerProxy_Control">
    <AjaxSettings>
        <telerik:AjaxSetting AjaxControlID="BtnInsertTarrif">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="lstTarrif" />
            </UpdatedControls>
        </telerik:AjaxSetting>
    </AjaxSettings>
</telerik:RadAjaxManagerProxy>
<telerik:RadAjaxManagerProxy runat="server" ID="AjaxManagerProxy_Control2">
    <AjaxSettings>
        <telerik:AjaxSetting AjaxControlID="btnLoadTarrif">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="cmbTarrif" />
            </UpdatedControls>
        </telerik:AjaxSetting>
    </AjaxSettings>
</telerik:RadAjaxManagerProxy>
<div class="BigTitle">ثبت وقایع</div>
<table style="width: 650px">
    <tr class="Table_RowB">
        <td style="width: 150px">اتوبوس:</td>
        <td>
            <telerik:RadComboBox runat="server" ID="cmbBus" Width="100%" Filter="Contains">
            </telerik:RadComboBox>
        </td>
    </tr>
    <tr class="Table_RowC">
        <td style="width: 150px">راننده:</td>
        <td>
            <uc1:JSearchPersonControl runat="server" id="JSearchPersonControlDriver" />
        </td>
    </tr>
    <tr class="Table_RowB">
        <td style="width: 150px">واقعه:</td>
        <td>
            <telerik:RadComboBox runat="server" ID="cmbBusEvent" Width="100%" Filter="Contains"></telerik:RadComboBox>
        </td>
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

            <asp:RangeValidator ID="RangeValidator3" runat="server" ErrorMessage="00 تا 23" ControlToValidate="txtStartTimeHour" MinimumValue="00"
                MaximumValue="23" ValidationGroup="LinePrice" Display="Dynamic" Type="Integer"></asp:RangeValidator>
            <telerik:RadTextBox runat="server" ID="txtStartTimeHour" Width="40px" MaxLength="2" EmptyMessage="ساعت"></telerik:RadTextBox>
            :
                    <telerik:RadTextBox runat="server" ID="txtStartTimeMinute" Width="40px" MaxLength="2" EmptyMessage="دقیقه"></telerik:RadTextBox>
            <asp:RangeValidator ID="RangeValidator4" runat="server" ErrorMessage="00 تا 59" ControlToValidate="txtStartTimeMinute" MinimumValue="00"
                MaximumValue="59" ValidationGroup="LinePrice" Display="Dynamic" Type="Integer"></asp:RangeValidator>
        </td>
    </tr>
    <tr class="Table_RowB">
        <td style="width: 150px">تا ساعت:</td>
        <td style="direction: ltr">
            <asp:RangeValidator ID="RangeValidator1" runat="server" ErrorMessage="00 تا 23" ControlToValidate="txtFinishTimeHour" MinimumValue="00"
                MaximumValue="23" ValidationGroup="LinePrice" Display="Dynamic" Type="Integer"></asp:RangeValidator>
            <telerik:RadTextBox runat="server" ID="txtFinishTimeHour" Width="40px" MaxLength="2" EmptyMessage="ساعت"></telerik:RadTextBox>
            :
                    <telerik:RadTextBox runat="server" ID="txtFinishTimeMinute" Width="40px" MaxLength="2" EmptyMessage="دقیقه"></telerik:RadTextBox>
            <asp:RangeValidator ID="RangeValidator2" runat="server" ErrorMessage="00 تا 59" ControlToValidate="txtFinishTimeMinute" MinimumValue="00"
                MaximumValue="59" ValidationGroup="LinePrice" Display="Dynamic" Type="Integer"></asp:RangeValidator>

        </td>
    </tr>
    <tr class="Table_RowC">
        <td style="width: 150px">وضعیت:</td>
        <td>
            <telerik:RadComboBox runat="server" ID="cmbStatus" Width="100%" Filter="Contains">
                <Items>
                    <telerik:RadComboBoxItem Value="1" Text="تایید شده" Selected="true" />
                    <telerik:RadComboBoxItem Value="0" Text="تایید نشده" />
                </Items>
            </telerik:RadComboBox>
        </td>
    </tr>
    <tr class="Table_RowB">
        <td style="width: 150px">تعرفه های مرتبط:</td>
        <td>
            <div style="float: right; width: 100%; height: auto">
                <telerik:RadComboBox runat="server" ID="cmbTarrif" Width="100%" Filter="Contains"></telerik:RadComboBox>
                <telerik:RadButton runat="server" ID="btnLoadTarrif" Text="بارگذاری تعرفه ها" AutoPostBack="true" Width="70px" Height="20px" OnClick="btnLoadTarrif_Click" />
                <telerik:RadButton runat="server" ID="BtnInsertTarrif" Text="درج" AutoPostBack="true" Width="70px" Height="20px" OnClick="BtnInsertTarrif_Click" />
            </div>
            <div style="clear: both; height: 5px"></div>
            <div style="float: right; width: 100%; height: auto">
                <telerik:RadListBox runat="server" ID="lstTarrif" Width="70%" EnableDragAndDrop="true" AllowTransfer="true"
                    EmptyMessage="لیست تعرفه های مرتبط" Localization-MoveDown="مرتب سازی به پایین" Localization-MoveUp="مرتب سازی به بالا"
                    Localization-Delete="حذف از لیست"
                    AllowReorder="true" AllowDelete="true">
                </telerik:RadListBox>
            </div>
        </td>
    </tr>
    <tr class="Table_RowC">
        <td style="width: 150px">تغییر وضعیت تعرفه:</td>
        <td>
            <telerik:RadComboBox runat="server" ID="cmdStateTarrif" Width="100%" Filter="Contains">
            </telerik:RadComboBox>
        </td>
    </tr>
</table>
<div class="FormButtons">
    <telerik:RadButton runat="server" ID="btnSave" Text="ذخیره" AutoPostBack="true" Width="100px" Height="35px" OnClick="btnSave_Click" ValidationGroup="LinePrice" />
    <telerik:RadButton runat="server" ID="btnClose" Text="بازگشت" OnClientClicked="CloseDialog" AutoPostBack="false" Width="100px" Height="35px" />
    <telerik:RadButton runat="server" ID="btnDelete" Text="حذف" AutoPostBack="true" Width="100px" Height="35px" OnClick="btnDelete_Click" CssClass="floatLeft" OnClientClicking="OnClientClicking" />
</div>
