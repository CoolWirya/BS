﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="JBusTimeStopsAtTheStation.ascx.cs" Inherits="WebBusManagement.FormsReports.JBusTimeStopsAtTheStations" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register Src="~/WebControllers/MainControls/Date/JDateControl.ascx" TagPrefix="uc1" TagName="JDateControl" %>
<%@ Register Src="~/WebControllers/MainControls/Persons/JSearchPersonControl.ascx" TagPrefix="uc1" TagName="JSearchPersonControl" %>
<%@ Register Assembly="WebControllers" Namespace="WebControllers.MainControls.Grid" TagPrefix="cc1" %>

<telerik:RadAjaxManagerProxy runat="server" ID="AjaxManagerProxy_Control">
    <AjaxSettings>
        <telerik:AjaxSetting AjaxControlID="cmbZone">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="cmbLine" />
                <telerik:AjaxUpdatedControl ControlID="cmbBus" />
            </UpdatedControls>
        </telerik:AjaxSetting>
    </AjaxSettings>
</telerik:RadAjaxManagerProxy>
<telerik:RadAjaxManagerProxy runat="server" ID="AjaxManagerProxy_Control1">
    <AjaxSettings>
        <telerik:AjaxSetting AjaxControlID="cmbLine">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="cmbZone" />
                <telerik:AjaxUpdatedControl ControlID="cmbBus" />
            </UpdatedControls>
        </telerik:AjaxSetting>
    </AjaxSettings>
</telerik:RadAjaxManagerProxy>
<telerik:RadAjaxManagerProxy runat="server" ID="AjaxManagerProxy_Control2">
    <AjaxSettings>
        <telerik:AjaxSetting AjaxControlID="cmbBus">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="cmbZone" />
                <telerik:AjaxUpdatedControl ControlID="cmbLine" />
            </UpdatedControls>
        </telerik:AjaxSetting>
    </AjaxSettings>
</telerik:RadAjaxManagerProxy>

<div class="BigTitle">گزارش میزان توقف اتوبوس در ایستگاه های مبدا و مقصد </div>
<table style="width: 500px">
    <tr class="Table_RowB">
        <td style="width: 150px">ناوگان:</td>
        <td>
            <telerik:RadComboBox runat="server" ID="cmbFleets" Width="100%" Filter="Contains"></telerik:RadComboBox>
        </td>
    </tr>
    <tr class="Table_RowB">
        <td style="width: 150px">منطقه:</td>
        <td>
            <telerik:RadComboBox runat="server" ID="cmbZone" Width="100%" Filter="Contains" 
                OnSelectedIndexChanged="cmbZone_SelectedIndexChanged">
            </telerik:RadComboBox>
        </td>
    </tr>
    <tr class="Table_RowC">
        <td style="width: 150px">خط:</td>
        <td>
            <telerik:RadComboBox runat="server" ID="cmbLine" Width="100%" Filter="Contains"
                OnSelectedIndexChanged="cmbLine_SelectedIndexChanged">
            </telerik:RadComboBox>
        </td>
    </tr>
    <tr class="Table_RowB">
        <td style="width: 150px">اتوبوس:</td>
        <td>
            <telerik:RadComboBox runat="server" ID="cmbBus" Width="100%" Filter="Contains" 
                OnSelectedIndexChanged="cmbBus_SelectedIndexChanged">
            </telerik:RadComboBox>
        </td>
    </tr>
    <tr class="Table_RowB">
        <td style="width: 150px">حداقل زمان توقف(دقیقه):</td>
        <td>
            <telerik:RadTextBox runat="server" ID="RadMinStop" Width="100%" AutoPostBack="true" Text="15">
            </telerik:RadTextBox>
        </td>
    </tr>
    <tr class="Table_RowC">
        <td style="width: 150px">مالک:</td>
        <td>
            <uc1:JSearchPersonControl runat="server" id="JSearchPersonControl" />
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

<telerik:RadButton runat="server" ID="btnSave" Text="مشاهده گزارش" AutoPostBack="true" Width="100px" Height="35px" OnClick="btnSave_Click" />
<telerik:RadButton runat="server" ID="btnClose" Text="بازگشت" OnClientClicked="CloseDialog" AutoPostBack="false" Width="100px" Height="35px" />
<table style="width: 100%; height: auto; margin-top: 15px">
    <tr>
        <td style="width: 100%; height: auto; overflow: auto"><cc1:JGridView runat="server" id="RadGridReport"></cc1:JGridView>
           
        </td>
    </tr>
</table>
