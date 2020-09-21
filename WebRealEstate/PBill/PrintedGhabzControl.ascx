<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PrintedGhabzControl.ascx.cs" Inherits="WebRealEstate.PBill.PrintedGhabzControl" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AggregateFormControl.ascx.cs" Inherits="WebRealEstate.Building.UnitBuild.Aggregate.AggregateFormControl" %>
<%@ Register Assembly="JJson" Namespace="JJson.Controls" TagPrefix="JJson" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register Src="~/WebControllers/MainControls/Grid/JGridViewControl.ascx" TagPrefix="uc1" TagName="JGridViewControl" %>
<%@ Register Src="~/WebControllers/MainControls/Date/JDateControl.ascx" TagPrefix="uc1" TagName="JDateControl" %>
<%@ Register Src="~/WebControllers/MainControls/Persons/JSearchPersonControl.ascx" TagPrefix="uc1" TagName="JSearchPersonControl" %>
<%@ Register Src="~/WebControllers/MainControls/Grid/JGridViewControl.ascx" TagPrefix="uc1" TagName="JGridViewControl" %>
<%@ Register Src="~/WebControllers/MainControls/Date/JDateControl.ascx" TagPrefix="uc1" TagName="JDateControl" %>
<%@ Register Src="~/WebControllers/MainControls/Grid/JGridViewControl.ascx" TagPrefix="uc1" TagName="JGridViewControl" %>
<%@ Register Src="~/WebControllers/MainControls/Date/JDateControl.ascx" TagPrefix="uc2" TagName="JDateControl" %>
<%@ Register Src="~/WebControllers/MainControls/Date/JDateControl.ascx" TagPrefix="uc3" TagName="JDateControl" %>

<table>
    <tr>
        <td>کد قبض</td>
        <td>
            <asp:TextBox ID="txtCodeGhabz" runat="server"></asp:TextBox></td>
        <td></td>
        <td>مجتمع</td>
        <td>
            <asp:DropDownList ID="DDLMojtamae" runat="server"></asp:DropDownList></td>
        <td></td>
    </tr>
    <tr>
        <td></td>
        <td></td>
        <td></td>
        <td></td>
        <td>کد :</td>
        <td>
            <asp:TextBox ID="txtCode" runat="server"></asp:TextBox></td>
    </tr>
    <tr>
        <td>ماه </td>
        <td>
            <asp:TextBox ID="txtMonth" runat="server"></asp:TextBox></td>
        <td></td>
        <td>شماره واحد :</td>
        <td>
            <asp:TextBox ID="txtNumVahed" runat="server"></asp:TextBox></td>
        <td></td>
    </tr>
    <tr>
        <td>مهلت پرداخت :</td>
        <td>
            <uc3:jdatecontrol runat="server" id="JDMohlatPay" />
        </td>
        <td></td>
        <td>یارانه :</td>
        <td>
            <asp:TextBox ID="txtYarane" runat="server"></asp:TextBox></td>
        <td></td>
    </tr>
    <tr>
        <td>مبلغ قابل پرداخت :</td>
        <td>
            <asp:TextBox ID="txtPay" runat="server"></asp:TextBox></td>
        <td></td>
        <td>بدهی قبلی :</td>
        <td>
            <asp:TextBox ID="txtBedehi" runat="server"></asp:TextBox></td>
        <td></td>
    </tr>
    <tr>
        <td>
            <asp:Button ID="btnReg" runat="server" Text="ثبت" /></td>
        <td> <asp:Button ID="btnApply" runat="server" Text="اعمال" /></td>
        <td></td>
        <td></td>
        <td></td>
        <td> <asp:Button ID="btnExit" runat="server" Text="خروج" /></td>
    </tr>
</table>