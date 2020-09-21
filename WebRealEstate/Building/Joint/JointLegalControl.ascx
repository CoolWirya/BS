<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="JointLegalControl.ascx.cs" Inherits="WebRealEstate.Building.Joint.JointLegalControl" %>
<%@ Register Assembly="JJson" Namespace="JJson.Controls" TagPrefix="JJson" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<style type="text/css">
    .auto-style1 {
        width: 234px;
    }
    .auto-style2 {
        height: 30px;
    }
    .auto-style3 {
        width: 234px;
        height: 30px;
    }
</style>
<table>
<tr>
    <td>نوع کاربری (تبلیغاتی، تجاری، هردو)</td>
    <td>
        <asp:DropDownList ID="JCmbBxUserKind" runat="server"></asp:DropDownList></td>
    <td class="auto-style1"></td>
</tr>
<tr>
    <td class="auto-style2">نحوه پرداخت اجاره (اجاره کامل، تهاتر، هردو)</td>
    <td class="auto-style2"><asp:DropDownList ID="JCmbBxRentalPay" runat="server"></asp:DropDownList></td>
    <td class="auto-style3"></td>
</tr>
<tr>
    <td> :مبلغ اجاره واقعی</td>
    <td>
        <JJson:JJsonTextBox ID="JJsonRentalPrice" runat="server" Event="textchange"></JJson:JJsonTextBox></td>
    <td> نحوه تسویه ( درصد فروش - خدمات)</td>
    <td><asp:DropDownList ID="JCmbBxKindPay" runat="server"></asp:DropDownList></td>
</tr>
<tr>
    <td>
     <telerik:RadGrid ID="gridView" runat="server"></telerik:RadGrid>     
    </td>
    <td></td>
</tr>
    </table>