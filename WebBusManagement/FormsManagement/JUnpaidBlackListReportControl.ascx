<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="JUnpaidBlackListReportControl.ascx.cs" Inherits="WebBusManagement.FormsManagement.JUnpaidBlackListReportControl" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register Src="~/WebControllers/MainControls/Date/JDateControl.ascx" TagPrefix="uc1" TagName="JDateControl" %>

<div class="BigTitle">لیست سیاه عدم پرداخت</div>
<table style="width: 500px">
    <tr class="Table_RowB">
        <td style="width: 150px">مالک</td>
        <td>
            <telerik:RadComboBox runat="server" ID="cmbBusOwner" Width="100%" Filter="Contains">
            </telerik:RadComboBox>
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
    <tr class="Table_RowB">
        <td style="width: 150px">پرداخت مبلغ بلاک شده</td>
        <td>
            <asp:CheckBox ID="payBlock" runat="server" />
        </td>
    </tr>
</table>
<div class="FormButtons">
<telerik:RadButton runat="server" ID="btnSave" Text="ذخیره" AutoPostBack="true" Width="100px" Height="35px" OnClick="btnSave_Click" />
<telerik:RadButton runat="server" ID="btnClose" Text="بازگشت" OnClientClicked="CloseDialog" AutoPostBack="false" Width="100px" Height="35px" OnClick="btnClose_Click" />
<telerik:RadButton runat="server" ID="btnDelete" Text="حذف" AutoPostBack="true" Width="100px" Height="35px" OnClick="btnDelete_Click" />
</div>
