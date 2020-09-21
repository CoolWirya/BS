<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="JRTPISReportControl.ascx.cs" Inherits="WebBusManagement.FormsReports.JRTPISReportControl" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register Src="~/WebControllers/MainControls/Date/JDateControl.ascx" TagPrefix="uc1" TagName="JDateControl" %>
<%@ Register Assembly="WebControllers" Namespace="WebControllers.MainControls.Grid" TagPrefix="cc1" %>

<telerik:RadAjaxManagerProxy runat="server" ID="AjaxManagerProxy_Control">
    <AjaxSettings>
        <telerik:AjaxSetting AjaxControlID="cmbZone">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="cmbLine" />
                <telerik:AjaxUpdatedControl ControlID="cmbStation" />
            </UpdatedControls>
        </telerik:AjaxSetting>
    </AjaxSettings>
</telerik:RadAjaxManagerProxy>
<telerik:RadAjaxManagerProxy runat="server" ID="AjaxManagerProxy_Control1">
    <AjaxSettings>
        <telerik:AjaxSetting AjaxControlID="cmbLine">
            <UpdatedControls>
<%--                <telerik:AjaxUpdatedControl ControlID="cmbZone" />--%>
                <telerik:AjaxUpdatedControl ControlID="cmbStation" />
            </UpdatedControls>
        </telerik:AjaxSetting>
    </AjaxSettings>
</telerik:RadAjaxManagerProxy>
<%--<telerik:RadAjaxManagerProxy runat="server" ID="AjaxManagerProxy_Control2">
    <AjaxSettings>
        <telerik:AjaxSetting AjaxControlID="cmbStation">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="cmbZone" />
                <telerik:AjaxUpdatedControl ControlID="cmbLine" />
            </UpdatedControls>
        </telerik:AjaxSetting>
    </AjaxSettings>
</telerik:RadAjaxManagerProxy>--%>

<div class="BigTitle">مشاهده خروجی RTPIS(تابلو مجازی)</div>
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
            <telerik:RadComboBox runat="server" ID="cmbZone" Width="100%" Filter="Contains" AutoPostBack="true"
                OnSelectedIndexChanged="cmbZone_SelectedIndexChanged">
            </telerik:RadComboBox>
        </td>
    </tr>
    <tr class="Table_RowC">
        <td style="width: 150px">خط:</td>
        <td>
            <telerik:RadComboBox runat="server" ID="cmbLine" Width="100%" Filter="Contains" AutoPostBack="true"
                OnSelectedIndexChanged="cmbLine_SelectedIndexChanged">
            </telerik:RadComboBox>
        </td>
    </tr>
    <tr class="Table_RowC">
        <td style="width: 150px">مسیر:</td>
        <td>
            <telerik:RadComboBox runat="server" ID="cmbPathType" Width="100%" Filter="Contains">
                <Items>
                    <telerik:RadComboBoxItem Text="رفت" Value="0" Checked="true" />
                    <telerik:RadComboBoxItem Text="برگشت" Value="1" />
                </Items>
            </telerik:RadComboBox>
        </td>
    </tr>
    <tr class="Table_RowB">
        <td style="width: 150px">ایستگاه:</td>
        <td>
            <telerik:RadComboBox runat="server" ID="cmbStation" Width="100%" Filter="Contains">
            </telerik:RadComboBox>
        </td>
    </tr>
</table>
<telerik:RadButton runat="server" ID="btnSave" Text="مشاهده گزارش" AutoPostBack="true" Width="100px" Height="35px" OnClick="btnSave_Click" />
<telerik:RadButton runat="server" ID="btnClose" Text="بازگشت" OnClientClicked="CloseDialog" AutoPostBack="false" Width="100px" Height="35px" />
<table style="width: 100%; height: auto; margin-top: 15px">
    <tr>
        <td style="width: 100%; height: auto; overflow: auto"><cc1:JGridView runat="server" id="RadGridReport" Width="100%"></cc1:JGridView>
            
        </td>
    </tr>
</table>
