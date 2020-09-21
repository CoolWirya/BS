<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="JHardDiskReplacementReportControl.ascx.cs" 
    Inherits="WebOilManagement.FormsReports.JHardDiskReplacementReportControl" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<%@ Register src="~/WebControllers/MainControls/Date/JDateControl.ascx" tagname="JDateControl" tagprefix="uc1" %>
<%@ Register Src="~/WebControllers/MainControls/Grid/JGridViewControl.ascx" TagPrefix="uc1" TagName="JGridViewControl" %>

<table >
    <tr class="Table_RowB">
        <td>نامه منطقه :</td>
        <td>
            <telerik:RadComboBox runat="server" ID="cmbOilZone" AutoPostBack="true" OnSelectedIndexChanged="cmbOilZone_SelectedIndexChanged"
                Width="100%">
            </telerik:RadComboBox>
        </td>
    </tr>
    <tr class="Table_RowC">
        <td>نام ناحیه :</td>
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
        <td>زمان وقوع خرابی :</td>
        <td>
            <uc1:JDateControl runat="server" id="FailurDate" />
        </td>
    </tr>
    <tr class="Table_RowB">
        <td>زمان رفع خرابی :</td>
        <td>
            <uc1:JDateControl runat="server" id="FixBugDate" />
        </td>
    </tr>
    <tr>
        <td>
            <telerik:RadButton runat="server" ID="btnGenerateReport" Text="مشاهده گزارش" AutoPostBack="true" Width="100px" Height="35px" OnClick="btnGenerateReport_Click" />
            <telerik:RadButton runat="server" ID="btnClose" Text="بازگشت" OnClientClicked="CloseDialog" AutoPostBack="false" Width="100px" Height="35px" />
        </td>
        <td>&nbsp;</td>
    </tr>
</table>
<table style="width: 100%; height: auto; margin-top: 15px">
    <tr>
        <td style="width: 100%; height: auto; overflow: auto">
            <uc1:jgridviewcontrol runat="server" id="grdManagerPortalReports" />
        </td>
    </tr>
</table>
