<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="JHandyLoadReportsControl.ascx.cs" Inherits="WebOilManagement.FormsReports.JHandyLoadReportsControl" %>

<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<%@ Register Src="~/WebControllers/MainControls/Date/JDateControl.ascx" TagPrefix="uc1" TagName="JDateControl" %>
<%@ Register Src="~/WebControllers/MainControls/Grid/JGridViewControl.ascx" TagPrefix="uc1" TagName="JGridViewControl" %>

<%@ Register assembly="JJson" namespace="JJson.Controls" tagprefix="JJson" %>


<div>
    <p>
    گزارش آمار بارگزاری دستی RPM</p>


</div>

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
            <telerik:RadComboBox runat="server" ID="cmbArea" Filter="Contains" AutoPostBack="true" OnSelectedIndexChanged="cmbArea_SelectedIndexChanged"></telerik:RadComboBox>
        </td>
    </tr>
    <tr class="Table_RowB">
        <td>نام جایگاه :</td>
        <td>
            <telerik:RadComboBox runat="server" ID="cmbStationName" Filter="Contains"></telerik:RadComboBox>
        </td>
    </tr>
    <tr class="Table_RowC">
        <td class="auto-style4">تاریخ نصب RPM :</td>
        <td class="auto-style4">
            <uc1:JDateControl runat="server" id="RPMDate" />
        </td>
    </tr>
</table>

<telerik:RadButton runat="server" ID="btnGenerateReport" Text="مشاهده گزارش" AutoPostBack="true" Width="100px" Height="35px" OnClick="btnGenerateReport_Click" />
<telerik:RadButton runat="server" ID="btnClose" Text="بازگشت" OnClientClicked="CloseDialog" AutoPostBack="false" Width="100px" Height="35px" />

<table style="width: 100%; height: auto; margin-top: 15px">
    <tr>
        <td style="width: 100%; height: auto; overflow: auto">
            <uc1:jgridviewcontrol runat="server" id="grdManagerPortalReports" />
        </td>
    </tr>
</table>




