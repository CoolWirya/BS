<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="JHokmeKarUpdateControl.ascx.cs" Inherits="WebBusManagement.FormsManagement.JHokmeKarUpdateControl" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register Src="~/WebControllers/MainControls/Date/JDateControl.ascx" TagPrefix="uc1" TagName="JDateControl" %>

<%@ Register Src="~/WebControllers/MainControls/CustomListSelector/JCustomListSelectorControl.ascx" TagPrefix="uc3" TagName="JCustomListSelectorControl" %>


<div class="BigTitle">حکم کار رانندگان</div>
<table style="width: 500px">
    <tr class="Table_RowB">
        <td style="width: 150px">راننده:</td>
        <td>
            <uc3:JCustomListSelectorControl runat="server" id="JSearchPersonControl" />
        </td>
    </tr>
    <tr class="Table_RowC">
        <td style="width: 150px">تاریخ:</td>
        <td>
            <uc1:JDateControl runat="server" id="txtStartDate" />
        </td>
    </tr>
    <tr class="Table_RowB">
        <td style="width: 150px">نحوه همکاری:</td>
        <td>
            <telerik:RadComboBox runat="server" ID="txtDriverWorkType" Width="90%"></telerik:RadComboBox>
        </td>
    </tr>
    <tr class="Table_RowC">
        <td style="width: 150px">عنوان شغلی:</td>
        <td>
            <telerik:RadComboBox runat="server" ID="txtOnvaneShoghli" Width="90%"></telerik:RadComboBox>
        </td>
    </tr>
    <tr class="Table_RowB">
        <td style="width: 150px">وضعیت همکاری:</td>
        <td>
            <telerik:RadComboBox runat="server" ID="txtDriverWorkStatus" Width="90%"></telerik:RadComboBox>
        </td>
    </tr>
    <tr class="Table_RowC">
        <td style="width: 150px">منطقه:</td>
        <td>
            <telerik:RadComboBox runat="server" ID="cmbZone" Width="90%"></telerik:RadComboBox>
        </td>
    </tr>
    <tr class="Table_RowB">
        <td style="width: 150px">مسیر:</td>
        <td>
            <telerik:RadComboBox runat="server" ID="cmbLine" Width="90%" Filter="Contains"></telerik:RadComboBox>
        </td>
    </tr>
    <tr class="Table_RowC">
        <td style="width: 150px">اتوبوس:</td>
        <td>
            <telerik:RadComboBox runat="server" ID="cmbBus" Width="85%" Filter="Contains"></telerik:RadComboBox>
        </td>
    </tr>
    <tr class="Table_RowB">
        <td style="width: 150px">تعداد سرویس:</td>
        <td>
            <telerik:RadTextBox runat="server" ID="txtNumOfService" Width="50px" MaxLength="5"></telerik:RadTextBox>
        </td>
    </tr>
    <tr class="Table_RowC">
        <td style="width: 150px">تعداد سرویس روز تعطیل:</td>
        <td>
            <telerik:RadTextBox runat="server" ID="txtNumOfHolidayService" Width="50px" MaxLength="5"></telerik:RadTextBox>
        </td>
    </tr>
    <tr class="Table_RowB">
        <td style="width: 150px">سری:</td>
        <td>
            <telerik:RadTextBox runat="server" ID="txtSeri" Width="50px" MaxLength="5"></telerik:RadTextBox>
        </td>
    </tr>
    <tr class="Table_RowC">
        <td style="width: 150px">فعالیت:</td>
        <td>
            <telerik:RadComboBox runat="server" ID="txtFaaliyat" Width="90%"></telerik:RadComboBox>
        </td>
    </tr>
    <tr class="Table_RowB">
        <td style="width: 150px">فعالیت از تاریخ:</td>
        <td>
            <uc1:JDateControl runat="server" id="txtFaliyatFromDate" />
        </td>
    </tr>
    <tr class="Table_RowC">
        <td style="width: 150px">فعالیت تا تاریخ:</td>
        <td>
            <uc1:JDateControl runat="server" id="txtFaliyatToDate" />
        </td>
    </tr>
    <tr class="Table_RowB">
        <td style="width: 150px">وضعیت:</td>
        <td>
            <telerik:RadComboBox runat="server" ID="cmbStatus" Width="100%" Filter="Contains">
                <Items>
                    <telerik:RadComboBoxItem Value="1" Text="فعال" Selected="true" />
                    <telerik:RadComboBoxItem Value="0" Text="غیر فعال" />
                </Items>
            </telerik:RadComboBox>
        </td>
    </tr>
</table>
<div class="FormButtons">
    <telerik:RadButton runat="server" ID="btnSave" Text="ذخیره" AutoPostBack="true" Width="100px" Height="35px" OnClick="btnSave_Click" OnClientClicked="LockButton" />
    <telerik:RadButton runat="server" ID="btnClose" Text="بازگشت" OnClientClicked="CloseDialog" AutoPostBack="false" Width="100px" Height="35px" />
    <telerik:RadButton runat="server" ID="btnDelete" Text="حذف" AutoPostBack="true" Width="100px" Height="35px" OnClick="btnDelete_Click" CssClass="floatLeft" OnClientClicking="OnClientClicking" />
</div>
