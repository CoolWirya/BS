<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="JConsulHistoryReportControl.ascx.cs" Inherits="WebBusMaintenance.Forms.JConsulHistoryReportControl" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register Src="~/WebControllers/MainControls/Grid/JGridViewControl.ascx" TagPrefix="uc1" TagName="JGridViewControl" %>
<%@ Register Src="~/WebControllers/MainControls/Date/JDateControl.ascx" TagPrefix="uc1" TagName="JDateControl" %>

<div class="BigTitle">گزارش تاریخچه ی کنسول ها</div>
<table style="width: 500px">
    <tr class="Table_RowB">
        <td style="width: 150px">IMEI کنسول:</td>
        <td>
            <telerik:RadTextBox runat="server" ID="txtIMEI" MaxLength="15"></telerik:RadTextBox>
            <asp:RangeValidator ID="RangeValidator3" runat="server" ErrorMessage="مقدار صحیح وارد کنید" ControlToValidate="txtIMEI" MinimumValue="0"
                MaximumValue="999999999999999" ValidationGroup="Report" Display="Dynamic"></asp:RangeValidator>
        </td>
    </tr>
    <tr class="Table_RowC">
        <td style="width: 150px">اتوبوس:</td>
        <td>
            <telerik:RadComboBox runat="server" ID="cmbBus" Width="100%" Filter="Contains"></telerik:RadComboBox>
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
<telerik:RadButton runat="server" ID="btnSave" Text="مشاهده گزارش" AutoPostBack="true" Width="100px" Height="35px" OnClick="btnSave_Click" ValidationGroup="Report"/>
<telerik:RadButton runat="server" ID="btnClose" Text="بازگشت" OnClientClicked="CloseDialog" AutoPostBack="false" Width="100px" Height="35px" />
<table style="width: 100%; height: auto; margin-top: 15px">
    <tr>
        <td style="width: 100%; height: auto; overflow: auto">
            <uc1:JGridViewControl runat="server" id="RadGridReport" />
        </td>
    </tr>
</table>

