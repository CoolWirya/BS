﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="JZonesTransactionAndIncomeReportControl.ascx.cs" Inherits="WebBusManagement.FormsReports.JZonesTransactionAndIncomeReportControl" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register Src="~/WebControllers/MainControls/Date/JDateControl.ascx" TagPrefix="uc1" TagName="JDateControl" %>
<%@ Register Src="~/WebControllers/MainControls/Persons/JSearchPersonControl.ascx" TagPrefix="uc1" TagName="JSearchPersonControl" %>
<%@ Register Src="~/WebControllers/MainControls/Grid/JGridViewControl.ascx" TagPrefix="uc1" TagName="JGridViewControl" %>

<div class="BigTitle">گزارش تراکنش و درآمد مناطق</div>
<table style="width: 500px">
    <tr class="Table_RowB">
        <td style="width: 150px">منطقه:</td>
        <td>
            <telerik:RadComboBox runat="server" ID="cmbZone" Width="100%" Filter="Contains"></telerik:RadComboBox>
        </td>
    </tr>
    <tr class="Table_RowC">
        <td style="width: 150px">از تاریخ:</td>
        <td>
            <uc1:JDateControl runat="server" id="txtFromDate"/>
        </td>
    </tr>
    <tr class="Table_RowB">
        <td style="width: 150px">تا تاریخ:</td>
        <td>
            <uc1:JDateControl runat="server" id="txtToDate" />
        </td>
    </tr>
</table>
<telerik:RadButton runat="server" ID="btnSave" Text="مشاهده گزارش" AutoPostBack="true" Width="100px" Height="35px" OnClick="btnSave_Click"/>
<telerik:RadButton runat="server" ID="btnClose" Text="بازگشت" OnClientClicked="CloseDialog" AutoPostBack="false" Width="100px" Height="35px" />
<table style="width: 100%; height: auto; margin-top: 15px">
    <tr>
        <td style="width: 100%; height: auto; overflow: auto">
            <uc1:JGridViewControl runat="server" id="RadGridReport" />
        </td>
    </tr>
</table>