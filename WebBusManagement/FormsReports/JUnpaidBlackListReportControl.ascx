<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="JUnpaidBlackListReportControl.ascx.cs" Inherits="WebBusManagement.FormsReports.JUnpaidBlackListReportControl" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>

<div class="BigTitle">لیست سیاه عدم پرداخت</div>
<table style="width: 500px">
    <tr class="Table_RowB">
        <td style="width: 150px">راننده</td>
        <td>
            <telerik:RadComboBox runat="server" ID="cmbPerson" Width="100%" Filter="Contains">
            </telerik:RadComboBox>
        </td>
    </tr>
</table>
<div class="FormButtons">
<telerik:RadButton runat="server" ID="btnSave" Text="ذخیره" AutoPostBack="true" Width="100px" Height="35px" OnClick="btnSave_Click" />
<telerik:RadButton runat="server" ID="btnClose" Text="بازگشت" OnClientClicked="CloseDialog" AutoPostBack="false" Width="100px" Height="35px" OnClick="btnClose_Click" />
<telerik:RadButton runat="server" ID="btnDelete" Text="حذف" AutoPostBack="true" Width="100px" Height="35px" OnClick="btnDelete_Click" />
</div>
