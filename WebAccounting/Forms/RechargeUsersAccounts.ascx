<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="RechargeUsersAccounts.ascx.cs" Inherits="WebAccounting.Forms.RechargeUsersAccounts" %>

<%@ Register Src="~/WebControllers/MainControls/Date/JDateControl.ascx" TagPrefix="uc1" TagName="JDateControl" %>
<%@ Register Src="~/WebAVL/Controls/Search/JSearchDevice.ascx" TagPrefix="cc1" TagName="JSearchDevice" %>

<style>
    tr {
        height: auto;
    }
</style>
<table border="1" style="border-style: solid; border: medium; border-color: black; margin-right: 10px; height: 25%">

    <tr>
        <td>نام کاربری :
        </td>
        <td class="Table_RowC" style="text-align: center">
            <cc1:JSearchDevice runat="server" ID="searchDevice"  OnClientClick="return false;" AutoPostBack="false"></cc1:JSearchDevice>
        </td>
    </tr>
    <tr>
        <td>مبلغ:
        </td>
        <td class="Table_RowB" style="text-align: center; color: brown"><b>

            <asp:TextBox ID="txtAmount" runat="server" Style="text-align: left; direction: ltr"></asp:TextBox> ریال 
        </td>
    </tr>
    <tr>
        <td>مبلغ پرتال :
        </td>
        <td class="Table_RowC" style="text-align: center; color: brown"><b>

            <asp:TextBox ID="txtPortalPrice" runat="server" Style="text-align: left; direction: ltr"></asp:TextBox> ریال 
        </td>
    </tr>
    <tr>
        <td>تاریخ :
        </td>
        <td class="Table_RowB" style="text-align: center">
            <uc1:JDateControl ID="clrFromDate" runat="server" CssClass="textbox"></uc1:JDateControl>
        </td>
    </tr>
    <tr>
        <td>تاریخ سند:
        </td>
        <td class="Table_RowB" style="text-align: center">
            <uc1:JDateControl ID="documentDate" runat="server" CssClass="textbox"></uc1:JDateControl>
        </td>
    </tr>
    <tr>
        <td>نام بانک :
        </td>
        <td class="Table_RowB" style="text-align: center">
            <asp:TextBox ID="txtBankName" runat="server" Style="text-align: left; direction: ltr"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>شعبه :
        </td>
        <td class="Table_RowB" style="text-align: center">
            <asp:TextBox ID="txtBranchName" runat="server" Style="text-align: left; direction: ltr"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td colspan="2" class="Table_RowB" style="text-align: center; vertical-align: central; height: 30px">
            <asp:Button runat="server" ID="btnSubmit" Width="120px" Height="30px" Text="پرداخت" OnClick="btnSubmit_Click" Style="text-align: center; font-weight: bold; vertical-align: central"></asp:Button>
        </td>
    </tr>
</table>
