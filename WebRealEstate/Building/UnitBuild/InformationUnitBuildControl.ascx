<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="InformationUnitBuildControl.ascx.cs" Inherits="WebRealEstate.Building.UnitBuild.InformationUnitBuildControl" %>
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
            عنوان :
        </td>
        <td>
            <asp:DropDownList ID="DDLTitle" runat="server"></asp:DropDownList>
        </td>
        <td>
            تلفن :
        </td>
        <td>
            <asp:TextBox ID="txtTel" runat="server"></asp:TextBox>
        </td>
        <td>
            <asp:CheckBox ID="chkBox" runat="server" />
        </td>
        <td>

        </td>
        <td>

        </td>

    </tr>
    <tr>
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
            <asp:Button ID="btnAdd" runat="server" Text="اضافه" />

        </td>
        <td>
            <asp:Button ID="btnDel" runat="server" Text="حذف" />

        </td>

    </tr>
    <tr>
        <td>
            <uc5:jgridviewcontrol runat="server" id="JGridViewControl" />
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
            <asp:Button ID="btnAgree" runat="server" Text="تایید" />
        </td>
        <td>
            <asp:Button ID="btnSave" runat="server" Text="ذخیره" />
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
            <asp:Button ID="btnExit" runat="server" Text="خروج" />
        </td>

    </tr>
</table>