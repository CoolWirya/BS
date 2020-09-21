<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="JGroundUpdateControl.ascx.cs" Inherits="AndroidWebManagement.Forms.JGroundUpdateControl" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>

<div class="BigTitle">زمین</div>
<table style="width: 500px">
    <tr class="Table_RowB">
        <td style="width: 150px">متراژ:</td>
        <td>
            <telerik:radtextbox runat="server" id="txtMetarj" width="100%"></telerik:radtextbox>
        </td>
    </tr>
    <tr class="Table_RowB">
        <td style="width: 150px">ابعاد:</td>
        <td>
            <telerik:radtextbox runat="server" id="txtAbad" width="100%"></telerik:radtextbox>
        </td>
    </tr>
    <tr class="Table_RowB">
        <td style="width: 150px">موقعیت جغرافیایی:</td>
        <td>
            <telerik:radtextbox runat="server" id="txtMogheyatJoghrafi" width="100%"></telerik:radtextbox>
        </td>
    </tr>
    <tr class="Table_RowB">
        <td style="width: 150px">موقعیت مکانی:</td>
        <td>
            <telerik:radtextbox runat="server" id="txtMogheyatMakani" width="100%"></telerik:radtextbox>
        </td>
    </tr>
    <tr class="Table_RowB">
        <td style="width: 150px">آدرس:</td>
        <td>
            <telerik:radtextbox runat="server" id="txtAddress" width="100%" textmode="MultiLine"></telerik:radtextbox>
        </td>
    </tr>
    <tr class="Table_RowB">
        <td style="width: 150px">سند:</td>
        <td>
            <telerik:radtextbox runat="server" id="txtSanad" width="100%"></telerik:radtextbox>
        </td>
    </tr>
    <tr class="Table_RowC">
        <td style="width: 150px">تعداد شرکا:</td>
        <td>
            <telerik:radtextbox runat="server" id="txtTedadeShoraka" width="100%"></telerik:radtextbox>
        </td>
    </tr>
       <tr class="Table_RowC">
        <td style="width: 150px">توضیحات:</td>
        <td>
            <telerik:radtextbox runat="server" id="txtTozihat" width="100%" textmode="MultiLine"></telerik:radtextbox>
        </td>
    </tr>
    <tr class="Table_RowB">
        <td style="width: 150px">قیمت:</td>
        <td>
            <telerik:radtextbox runat="server" id="txtGheymat" width="100%"></telerik:radtextbox>
        </td>
    </tr>
</table>
<div class="FormButtons">
    <telerik:radbutton runat="server" id="btnSave" text="ذخیره" autopostback="true" width="100px" height="35px" onclick="btnSave_Click" />
    <telerik:radbutton runat="server" id="btnClose" text="بازگشت" onclientclicked="CloseDialog" autopostback="false" width="100px" height="35px" />
    <telerik:radbutton runat="server" id="btnDelete" text="حذف" autopostback="true" width="100px" height="35px" onclick="btnDelete_Click" cssclass="floatLeft" onclientclicking="OnClientClicking" />
</div>
