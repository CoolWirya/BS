<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="JCallCenterPerformanceReportControl.ascx.cs" 
    Inherits="WebOilManagement.FormsReports.JCallCenterPerformanceReportControl" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register Src="~/WebControllers/MainControls/Date/JDateControl.ascx" TagPrefix="uc1" TagName="JDateControl" %>
<%@ Register Src="~/WebControllers/MainControls/Grid/JGridViewControl.ascx" TagPrefix="uc1" TagName="JGridViewControl" %>
<%@ Register Src="~/WebControllers/MainControls/CustomListSelector/JCustomListSelectorControl.ascx" TagPrefix="uc2" TagName="JCustomListSelectorControl" %>

<telerik:RadAjaxManagerProxy runat="server" ID="AjaxManagerProxy_Control">
    <AjaxSettings>
       
    </AjaxSettings>
</telerik:RadAjaxManagerProxy>


<div class="BigTitle">گزارش عملکرد CALL CENTER</div>
<table style="width: 500px">
   <tr class="Table_RowB">
        <td>لیست کاربران:</td>
        <td>
            <uc2:JCustomListSelectorControl runat="server" id="JLstCtrUsers" />
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
            <uc1:JGridViewControl runat="server" id="grdCallCenterPerformance" />
        </td>
    </tr>
</table>
