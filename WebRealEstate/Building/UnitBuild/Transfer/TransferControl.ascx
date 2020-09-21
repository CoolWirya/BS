<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TransferControl.ascx.cs" Inherits="WebRealEstate.Building.UnitBuild.Transfer.TransferControl1" %>
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
<%@ Register Src="~/WebControllers/MainControls/Date/JDateControl.ascx" TagPrefix="uc2" TagName="JDateControl" %>
<%@ Register Src="~/WebControllers/MainControls/Grid/JGridViewControl.ascx" TagPrefix="uc3" TagName="JGridViewControl" %>
<%@ Register Src="~/WebControllers/MainControls/Grid/JGridViewControl.ascx" TagPrefix="uc4" TagName="JGridViewControl" %>

<table>
    <tr>
        <td>
            <uc4:jgridviewcontrol runat="server" id="JGridViewControl" />
        </td>
        <td></td>
        <td></td>
        <td></td>
        <td></td>

    </tr>
    <tr>
        <td>
            <asp:Button ID="btnNewReq" runat="server" Text="درخواست جدید" /></td>
        <td><asp:Button ID="btnEditReq" runat="server" Text="ویرایش درخواست" /></td>
        <td><asp:Button ID="btnDelReq" runat="server" Text="حذف درخواست" /></td>
        <td><asp:Button ID="btnExit" runat="server" Text="خروج" /></td>
        <td><asp:Button ID="btnHistory" runat="server" Text="تاریخچه" /></td>

    </tr>
    <tr>
   <td>
            <asp:Button ID="btnAccReq" runat="server" Text="تایید درخواست" /></td>
        <td><asp:Button ID="btnEdit" runat="server" Text="ویرایش" /></td>
        <td><asp:Button ID="btnReq" runat="server" Text=" درخواست" /></td>
        <td><asp:Button ID="btnExit2" runat="server" Text="خروج" /></td>
    </tr>
</table>