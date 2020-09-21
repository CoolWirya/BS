<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="JOilSupplierUpdateControl.ascx.cs" Inherits="WebOilManagement.Forms.JOilSupplierUpdateControl" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register Src="~/WebControllers/MainControls/Date/JDateControl.ascx" TagPrefix="uc1" TagName="JDateControl" %>
<%@ Register Src="~/WebControllers/MainControls/Persons/JSearchPersonControl.ascx" TagPrefix="uc1" TagName="JSearchPersonControl" %>

<div class="FormContent">
    <div class="BigTitle">پیمانکار</div>
    <table>
        <tr>
            <td class="Table_RowB">شخص:</td>
            <td class="Table_RowC">
                <uc1:JSearchPersonControl runat="server" id="personSupplier" />
            </td>
        </tr>
        <tr>
            <td class="Table_RowB">تاریخ شروع قرارداد:</td>
            <td class="Table_RowC">
                <uc1:JDateControl runat="server" id="dteStartDate" />
            </td>
        </tr>
        <tr>
            <td class="Table_RowB">تاریخ پایان قرارداد:</td>
            <td class="Table_RowC">
                <uc1:JDateControl runat="server" id="dteEndDate" />
            </td>
        </tr>
    </table>
</div>
<div class="FormButtons">
    <telerik:RadButton runat="server" ID="btnSave" Text="ذخیره" AutoPostBack="true" Width="100px" Height="35px" OnClick="btnSave_Click" />
    <telerik:RadButton runat="server" ID="btnClose" Text="بازگشت" OnClientClicked="CloseDialog" AutoPostBack="false" Width="100px" Height="35px" />
    <telerik:RadButton runat="server" ID="btnDelete" Text="حذف" AutoPostBack="true" Width="100px" Height="35px" OnClick="btnDelete_Click" CssClass="floatLeft" OnClientClicking="OnClientClicking" />
</div>
