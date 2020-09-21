<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SearchUnitControl.ascx.cs" Inherits="WebRealEstate.Building.UnitBuild.SearchUnitControl" %>
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
<%@ Register Src="~/WebControllers/MainControls/Grid/JGridViewControl.ascx" TagPrefix="uc5" TagName="JGridViewControl" %>
<table>
    <tr>
        <td>
نام مجتمع / بازار :
        </td>
        <td>
            <asp:DropDownList ID="DDLMojName" runat="server"></asp:DropDownList>
        </td>
        <td>

        </td>
        <td>

        </td>
    </tr>
    <tr>
        <td>
            نوع واحد :
        </td>
        <td>
            <asp:DropDownList ID="DDLKindVahed" runat="server"></asp:DropDownList>
        </td>
        <td>

        </td>
        <td>

        </td>
    </tr>
    <tr>
        <td>
            طبقه :
        </td>
        <td>
            <asp:DropDownList ID="DDLFloor" runat="server"></asp:DropDownList>
        </td>
        <td>

        </td>
        <td>

        </td>
    </tr>
    <tr>
        <td>
            شماره شناسایی :
        </td>
        <td>
            <asp:TextBox ID="txtIDNUM" runat="server"></asp:TextBox>
        </td>
        <td>

        </td>
        <td>

        </td>
    </tr>
    <tr>
        <td>
            شماره واحد :
        </td>
        <td>
            <asp:TextBox ID="txtNumVahed" runat="server"></asp:TextBox>
        </td>
        <td>

        </td>
        <td>
            <asp:Button ID="btnSearch" runat="server" Text="Search" />
        </td>
    </tr>
    <tr>
        <td>
            <telerik:RadGrid ID="grid1" runat="server"></telerik:RadGrid>
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
            <asp:Button ID="btnOK" runat="server" Text="OK" />
        </td>
        <td>

        </td>
        <td>

        </td>
        <td>
            <asp:Button ID="btnEdit" runat="server" Text="Edit" />
        </td>
    </tr>
</table>