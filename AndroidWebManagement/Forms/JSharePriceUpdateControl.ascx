<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="JSharePriceUpdateControl.ascx.cs" Inherits="AndroidWebManagement.Forms.JSharePriceUpdateControl" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register Src="~/WebControllers/MainControls/Date/JDateControl.ascx" TagPrefix="uc1" TagName="JDateControl" %>

<div class="BigTitle">قیمت روز سهام</div>
<table style="width: 500px">
    <tr class="Table_RowC">
        <td style="width: 150px">قیمت:</td>
        <td>
            <telerik:radtextbox runat="server" id="txtPrice" width="100%"></telerik:radtextbox>
        </td>
    </tr>
    <tr class="Table_RowC">
        <td style="width: 150px">تاریخ تغییر:</td>
        <td>
            <uc1:jdatecontrol runat="server" id="txtChangeDate" />
        </td>
    </tr>
</table>
<div class="FormButtons">
    <telerik:radbutton runat="server" id="btnSave" text="ذخیره" autopostback="true" width="100px" height="35px" onclick="btnSave_Click" />
    <telerik:radbutton runat="server" id="btnClose" text="بازگشت" onclientclicked="CloseDialog" autopostback="false" width="100px" height="35px" />
    <telerik:radbutton runat="server" id="btnDelete" text="حذف" autopostback="true" width="100px" height="35px" onclick="btnDelete_Click" cssclass="floatLeft" onclientclicking="OnClientClicking" />
</div>
