<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="JenviromentSerchFormControl.ascx.cs" Inherits="WebRealEstate.Building.Environment.JenviromentSerchFormControl" %>
<%@ Register Assembly="JJson" Namespace="JJson.Controls" TagPrefix="JJson" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register Src="~/WebControllers/MainControls/Grid/JGridViewControl.ascx" TagPrefix="uc1" TagName="JGridViewControl" %>

<table> 
    <tr>
        <td>واقع در بازار :</td>
        <td>
            <asp:DropDownList ID="DropDownList1" runat="server"></asp:DropDownList></td>
        <td></td>
        <td>نوع :</td>
        <td>
            <asp:DropDownList ID="DropDownList2" runat="server"></asp:DropDownList></td>
    </tr>
    <tr>
        <td>طبقه :</td>
        <td>
            <asp:DropDownList ID="DropDownList3" runat="server"></asp:DropDownList></td>
        <td></td>
        <td>درب :</td>
        <td>
            <asp:DropDownList ID="DropDownList4" runat="server"></asp:DropDownList></td>
    </tr>
    <tr>
        <td>وضعیت :</td>
        <td>
            <asp:DropDownList ID="DropDownList5" runat="server"></asp:DropDownList></td>
        <td></td>
        <td></td>
        <td></td>
    </tr>
    <tr>

        <td>
            <uc1:jgridviewcontrol runat="server" id="JGridViewControl" />
        </td>
        
    </tr>
    <tr>
        <td>
            <JJson:JJsonButton ID="JJsonButton1" runat="server" Event="click"  text="جستجو"/></td>
        <td></td>
        <td></td>
        <td></td>
        <td>
            <JJson:JJsonButton ID="JJsonButton2" runat="server" Event="click"  Text="انتخاب"/></td>
    </tr>
</table>