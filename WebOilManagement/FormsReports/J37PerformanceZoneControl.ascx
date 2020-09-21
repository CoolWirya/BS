<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="J37PerformanceZoneControl.ascx.cs" 
    Inherits="WebOilManagement.FormsReports.J37PerformanceZoneControl" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register Src="~/WebControllers/MainControls/Date/JDateControl.ascx" TagPrefix="uc1" TagName="JDateControl" %>
<%@ Register Src="~/WebControllers/MainControls/Grid/JGridViewControl.ascx" TagPrefix="uc1" TagName="JGridViewControl" %>


<telerik:RadAjaxManagerProxy runat="server" ID="AjaxManagerProxy_Control">
    <AjaxSettings>
        <telerik:AjaxSetting AjaxControlID="cmbOilZone">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="cmbArea" />
                <telerik:AjaxUpdatedControl ControlID="cmbSupplier" />
            </UpdatedControls>
        </telerik:AjaxSetting>
     
    </AjaxSettings>
</telerik:RadAjaxManagerProxy>


<div class="BigTitle">گزارش عملکرد مناطق 37 گانه</div>
<table style="width: 500px">
    <tr class="Table_RowB">
        <td style="width: 150px">منطقه:</td>
        <td >
            <telerik:RadComboBox runat="server" ID="cmbOilZone" AutoPostBack="true" OnSelectedIndexChanged="cmbOilZone_SelectedIndexChanged"
                 Width="100%"></telerik:RadComboBox>
        </td>
    </tr>
    <tr class="Table_RowC">
        <td >ناحیه:</td>
        <td >
            <telerik:RadComboBox runat="server" ID="cmbArea" Filter="Contains"></telerik:RadComboBox>
        </td>
    </tr>
    <tr class="Table_RowB">
        <td >پیمانکار:</td>
        <td >
            <telerik:RadComboBox runat="server" ID="cmbSupplier" Filter="Contains"></telerik:RadComboBox>
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
</table>



<telerik:RadButton runat="server" ID="btnGenerateReport" Text="مشاهده گزارش" AutoPostBack="true" Width="100px" Height="35px" OnClick="btnGenerateReport_Click" />
<telerik:RadButton runat="server" ID="btnClose" Text="بازگشت" OnClientClicked="CloseDialog" AutoPostBack="false" Width="100px" Height="35px" />
<table style="width: 100%; height: auto; margin-top: 15px">
    <tr>
        <td style="width: 100%; height: auto; overflow: auto">
            <div id="ContentZone_Div" runat="server" style="height: 100%; width: 100%; overflow: auto">
                 <uc1:jgridviewcontrol runat="server" id="grd37PerformanceZone" />
           </div>
           
        </td>
    </tr>
</table>
