<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ContractPriceControl.ascx.cs" Inherits="WebLegal.Contract.Forms.ContractPriceControl" %>
<%@ Register Assembly="JJson" Namespace="JJson.Controls" TagPrefix="JJson" %>
<%@ Register Src="http://localhost:8099/WebControllers/MainControls/Date/JDateControl.ascx" TagPrefix="uc1" TagName="JDateControl" %>

<table>
    <tr>
        <td>
            مبلغ کل قرارداد :
        </td>
        <td>
            <asp:TextBox ID="txtPrice" runat="server"></asp:TextBox>
        </td>
        <td>

        </td>
        <td>
            تعداد اقساط :
        </td>
        <td>
            <asp:TextBox ID="txtCountPayment" runat="server"></asp:TextBox>
        </td>
        <td>

        </td>
    </tr>
    <tr>
        <td>
            مبلغ نقدی :
        </td>
        <td>
            <asp:TextBox ID="txtRealPrice" runat="server"></asp:TextBox>
        </td>
        <td>

        </td>
        <td>
            تاریخ شروع اقساط :
        </td>
        <td>
            <uc1:jdatecontrol runat="server" id="txtStartPayment" />
        </td>
        <td>

        </td>
    </tr>
    <tr>
        <td>
            تاریخ مبلغ نقدی :
        </td>
        <td>
            <uc1:jdatecontrol runat="server" id="txtDatePrice" />
        </td>
        <td>
            
        </td>
        <td>
           تاریخ اتمام اقساط :
        </td>
        <td>
             <uc1:jdatecontrol runat="server" id="txtEndPayment" />
        </td>
        <td>

        </td>
    </tr>
    <tr>
        <td>
            پرداختی تا کنون :
        </td>
        <td>
            <asp:TextBox ID="txtCostUpToNow" runat="server"></asp:TextBox>
        </td>
        <td>

        </td>
        <td>
            مبلغ پایانی :
        </td>
        <td>
             <asp:TextBox ID="txtEndPrice" runat="server"></asp:TextBox>
        </td>
        <td>

        </td>
    </tr>
    <tr>
        <td>
            مبلغ اقساطی :
        </td>
        <td>
             <asp:TextBox ID="txtInstallmentPrice" runat="server"></asp:TextBox>
        </td>
        <td>

        </td>
        <td>
            حق استنکاف :
        </td>
        <td>
             <asp:TextBox ID="txtEstenkafRight" runat="server"></asp:TextBox>
        </td>
        <td>

        </td>
    </tr>
    <tr>
        <td>
            مبلغ الباقی :
        </td>
        <td>
             <asp:TextBox ID="txtRemain" runat="server"></asp:TextBox>
        </td>
        <td>

        </td>
        <td>
            حق فسخ :
        </td>
        <td>
             <asp:TextBox ID="txtPriceCancel" runat="server"></asp:TextBox>
        </td>
        <td>

        </td>
    </tr>
    <tr>
        <td>
            <JJson:JJsonButton ID="btnNext" runat="server" Event="click" />
        </td>
        <td>
            <JJson:JJsonButton ID="btnBack" runat="server" Event="click" />
        </td>
        <td>
            تعداد چک برگشتی برای فسخ قرارداد :
        </td>
        <td>
            <asp:TextBox ID="txtReturnChCount" runat="server"></asp:TextBox>
        </td>
        <td>

        </td>
        <td>
            <JJson:JJsonButton ID="btnCancel" runat="server" Event="click" />
        </td>
    </tr>
</table>
