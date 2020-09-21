﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="JTariffHokmeKarBaseDefineUpdateControl.ascx.cs" Inherits="WebBusManagement.FormsManagement.JTariffHokmeKarBaseDefineUpdateControl" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register Src="~/WebControllers/MainControls/Date/JDateControl.ascx" TagPrefix="uc1" TagName="JDateControl" %>

<div class="BigTitle">تعاریف پایه تعرفه بر اساس حکم کار</div>
<table style="width: 500px">
    <tr class="Table_RowB">
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
        <td style="width: 150px">منطقه:</td>
        <td>
            <telerik:RadComboBox runat="server" ID="cmbZone" Width="90%"></telerik:RadComboBox>
        </td>
    </tr>
      <tr class="Table_RowB">
        <td style="width: 150px">خط:</td>
        <td>
            <telerik:RadComboBox runat="server" ID="cmbLine" Width="90%"></telerik:RadComboBox>
        </td>
    </tr>
    <tr class="Table_RowC">
        <td style="width: 150px">سری:</td>
        <td>
            <telerik:RadComboBox runat="server" ID="cmbSeri" Width="90%"></telerik:RadComboBox>
        </td>
    </tr>
    <tr class="Table_RowB">
        <td style="width: 150px">شیفت:</td>
        <td>
            <telerik:RadComboBox runat="server" ID="cmbShift" Width="90%"></telerik:RadComboBox>
        </td>
    </tr>
    <tr class="Table_RowC">
        <td style="width: 150px">دوره زمانی:</td>
        <td>
            <telerik:RadTextBox runat="server" ID="txtDatePeriod" InputType="Number" Width="90%" Text="0"></telerik:RadTextBox>
        </td>
    </tr>
</table>
<div class="FormButtons">
    <telerik:RadButton runat="server" ID="btnSave" Text="ذخیره" AutoPostBack="true" Width="100px" OnClick="btnSave_Click" OnClientClicked="LockButton" Height="35px" />
    <telerik:RadButton runat="server" ID="btnClose" Text="بازگشت" OnClientClicked="CloseDialog" AutoPostBack="false" Width="100px" Height="35px" />
    <telerik:RadButton runat="server" ID="btnDelete" Text="حذف" AutoPostBack="true" Width="100px" Height="35px" OnClick="btnDelete_Click" CssClass="floatLeft" OnClientClicking="OnClientClicking" />
</div>