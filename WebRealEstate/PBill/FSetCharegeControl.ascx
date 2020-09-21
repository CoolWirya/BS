<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FSetCharegeControl.ascx.cs" Inherits="WebRealEstate.PBill.FSetCharegeControl" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AggregateFormControl.ascx.cs" Inherits="WebRealEstate.Building.UnitBuild.Aggregate.AggregateFormControl" %>
<%@ Register Assembly="JJson" Namespace="JJson.Controls" TagPrefix="JJson" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register Src="~/WebControllers/MainControls/Grid/JGridViewControl.ascx" TagPrefix="uc1" TagName="JGridViewControl" %>
<%@ Register Src="~/WebControllers/MainControls/Date/JDateControl.ascx" TagPrefix="uc1" TagName="JDateControl" %>
<%@ Register Src="~/WebControllers/MainControls/Date/JDateControl.ascx" TagPrefix="uc1" TagName="JDateControl" %>
<%@ Register Src="~/WebControllers/MainControls/Date/JDateControl.ascx" TagPrefix="uc1" TagName="JDateControl" %>
<%@ Register Src="~/WebControllers/MainControls/Date/JDateControl.ascx" TagPrefix="uc1" TagName="JDateControl" %>
<%@ Register Src="~/WebControllers/MainControls/Persons/JSearchPersonControl.ascx" TagPrefix="uc1" TagName="JSearchPersonControl" %>
<%@ Register Src="~/WebControllers/MainControls/Grid/JGridViewControl.ascx" TagPrefix="uc1" TagName="JGridViewControl" %>
<%@ Register Src="~/WebControllers/MainControls/Date/JDateControl.ascx" TagPrefix="uc1" TagName="JDateControl" %>
<%@ Register Src="~/WebControllers/MainControls/Grid/JGridViewControl.ascx" TagPrefix="uc1" TagName="JGridViewControl" %>
<%@ Register Src="~/WebControllers/MainControls/Grid/JGridViewControl.ascx" TagPrefix="uc2" TagName="JGridViewControl" %>

<table>
        <tr>
        <td>
            تاریخچه صدور قبض
        </td>
        <td>

        </td>
        <td>

        </td>
        <td>

        </td>
        <td>

        </td>
        <td>

        </td>
        <td>

        </td>
    </tr>
    <tr>
        <td>
            <uc2:jgridviewcontrol runat="server" id="JGridSodoor" />
        </td>
        <td>

        </td>
        <td>

        </td>
        <td>

        </td>
        <td>

        </td>
        <td>

        </td>
        <td>

        </td>
    </tr>
    <tr>
        <td>
اطلاعات پایه صدور قبض
        </td>
        <td>

        </td>
        <td>

        </td>
        <td>

        </td>
        <td>

        </td>
        <td>

        </td>
        <td>

        </td>
    </tr>
    <tr>
        <td>
            مبلغ شارژ اصلی
        </td>
        <td>
            <asp:TextBox ID="txtBasePriceCharge" runat="server"></asp:TextBox>
        </td>
        <td>

        </td>
        <td>
            شارژ سالانه :
        </td>
        <td>
            <JJson:JNumericTextBox ID="JNtxtYearlyCharge" runat="server"></JJson:JNumericTextBox>
        </td>
        <td>
            کد تفصیلی :
        </td>
        <td>
            <JJson:JNumericTextBox ID="JNtxtTCode" runat="server"></JJson:JNumericTextBox>
        </td>
    </tr>
    <tr>
        <td>
            شارژ قابل پرداخت :
        </td>
        <td>
            <asp:TextBox ID="txtPayCharge" runat="server"></asp:TextBox>
        </td>
        <td>

        </td>
        <td>
            بدهی قبلی (شارژ) :
        </td>
        <td>
            <JJson:JNumericTextBox ID="JNtxtBedehi" runat="server"></JJson:JNumericTextBox>
        </td>
        <td>
            یارانه :
        </td>
        <td>
            <JJson:JNumericTextBox ID="JNtxtYarane" runat="server"></JJson:JNumericTextBox>
        </td>
    </tr>
    <tr>
        <td>
            توضیحات :
        </td>
        <td>
            <asp:TextBox ID="txtDsc" runat="server"></asp:TextBox>
        </td>
        <td>

        </td>
        <td>

        </td>
        <td>

        </td>
        <td>

        </td>
        <td>
            <asp:Button ID="btnChng" runat="server" Text="تغییر" />
        </td>
    </tr>

</table>
