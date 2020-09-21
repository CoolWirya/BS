<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="JStoresFlowReportControl.ascx.cs" Inherits="WebOilManagement.FormsReports.JStoresFlowReportControl" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>

<%@ Register Src="~/WebControllers/MainControls/Grid/JGridViewControl.ascx" TagPrefix="uc1" TagName="JGridViewControl" %>
<%@ Register src="~/WebControllers/MainControls/CustomListSelector/JCustomListSelectorControl.ascx" tagname="JCustomListSelectorControl" tagprefix="uc2" %>
<%@ Register src="~/WebControllers/MainControls/Date/JDateControl.ascx" tagname="JDateControl" tagprefix="uc1" %>

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

<p>
    گزارش گیري از تجهیزات در گردش بین انبارها</p>

<table>
    <tr class="Table_RowB">
        <td>منطقه :</td>
        <td>
            <telerik:RadComboBox runat="server" ID="cmbOilZone" AutoPostBack="true" OnSelectedIndexChanged="cmbOilZone_SelectedIndexChanged"
                Width="100%">
            </telerik:RadComboBox>
        </td>
    </tr>
    <tr class="Table_RowC">
        <td>ناحیه :</td>
        <td>
            <telerik:RadComboBox runat="server" ID="cmbArea" AutoPostBack="true" Filter="Contains" OnSelectedIndexChanged="cmbArea_SelectedIndexChanged" ></telerik:RadComboBox>
        </td>
    </tr>
    <tr class="Table_RowB">
        <td>نام پیمانکار :</td>
        <td>
            <telerik:RadComboBox runat="server" ID="cmbSupplier" Filter="Contains"></telerik:RadComboBox>
        </td>
    </tr>
    <tr class="Table_RowC">
        <td>از تاریخ :</td>
        <td>
            <uc1:JDateControl runat="server" id="AsDate" />
        </td>
    </tr>
    <tr class="Table_RowB">
        <td>تا تاریخ :</td>
        <td>
            <uc1:JDateControl runat="server" id="ToDate" />
        </td>
    </tr>
    </table>

<telerik:RadButton runat="server" ID="btnGenerateReport" Text="مشاهده گزارش" AutoPostBack="true" Width="100px" Height="35px" OnClick="btnGenerateReport_Click" />
<telerik:RadButton runat="server" ID="btnClose" Text="بازگشت" OnClientClicked="CloseDialog" AutoPostBack="false" Width="100px" Height="35px" />

<table style="width: 100%; height: auto; margin-top: 15px">
    <tr>
        <td style="width: 100%; height: auto; overflow: auto">
            <uc1:JGridViewControl ID="grdManagerPortalReports" runat="server" />
        </td>
    </tr>
</table>
