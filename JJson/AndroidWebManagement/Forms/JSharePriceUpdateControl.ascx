<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="JSharePriceUpdateControl.ascx.cs" Inherits="AndroidWebManagement.Forms.JSharePriceUpdateControl" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register Src="~/WebControllers/MainControls/Date/JDateControl.ascx" TagPrefix="uc1" TagName="JDateControl" %>

<div class="BigTitle">قیمت روز سهام</div>
<table style="width: 500px">
    <tr class="Table_RowC">
        <td style="width: 150px">قیمت:</td>
        <td>
            <telerik:RadTextBox runat="server" ID="txtPrice" Width="100%"></telerik:RadTextBox></td>
    </tr>
    <tr class="Table_RowC">
        <td style="width: 150px">تاریخ تغییر:</td>
        <td>
            <uc1:jdatecontrol runat="server" id="txtChangeDate" />
        </td>
    </tr>
</table>
<div class="FormButtons">
    <telerik:RadButton runat="server" ID="btnSave" Text="ذخیره" AutoPostBack="true" Width="100px" Height="35px" OnClick="btnSave_Click" />
    <telerik:RadButton runat="server" ID="btnClose" Text="بازگشت" OnClientClicked="CloseDialog" AutoPostBack="false" Width="100px" Height="35px" />
</div>
