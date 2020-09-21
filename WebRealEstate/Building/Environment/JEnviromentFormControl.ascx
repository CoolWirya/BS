<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="JEnviromentFormControl.ascx.cs" Inherits="WebRealEstate.Building.EnvironmentSetPrimaryowener.JEnviromentFormControl" %>
<%@ Register Assembly="JJson" Namespace="JJson.Controls" TagPrefix="JJson" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<table>
    <tr>
        <td>شماره محیط :</td>
        <td>
            <JJson:JNumericTextBox ID="JNumericTextBox1" runat="server"></JJson:JNumericTextBox></td>
        <td></td>
        <td>نام محیط :</td>
        <td>
            <JJson:JJsonTextBox ID="JJsonTextBox1" runat="server" Event="textchange"></JJson:JJsonTextBox></td>
    </tr>
    <tr>
        <td>عنوان محیط :</td>
        <td>
            <asp:DropDownList ID="DropDownList1" runat="server"></asp:DropDownList></td>
        <td></td>
        <td>مجتمع :</td>
        <td>
            <asp:DropDownList ID="DropDownList2" runat="server"></asp:DropDownList></td>
    </tr>
    <tr>
        <td>مساحت :</td>
        <td>
            <JJson:JJsonNumericTextBox ID="JJsonNumericTextBox1" runat="server" Event="textchange"></JJson:JJsonNumericTextBox></td>
        <td></td>
        <td>قیمت شارژ پایه :</td>
        <td><telerik:RadNumericTextBox ID="txtBaseCharge"></telerik:RadNumericTextBox></td>
    </tr>
    <tr>
        <td>وضعیت :</td>
        <td>
            <JJson:JJsonTextBox ID="JJsonTextBox2" runat="server" Event="textchange"></JJson:JJsonTextBox></td>
        <td></td>
        <td>قیمت پایه :</td>
        <td><telerik:RadNumericTextBox ID="txtBasePrice"></telerik:RadNumericTextBox></td>
    </tr>
    <tr>
        <td>طبقه :</td>
        <td>
            <asp:DropDownList ID="DropDownList3" runat="server"></asp:DropDownList></td>
        <td></td>
        <td>موقعیت :</td>
        <td>
            <asp:DropDownList ID="DropDownList4" runat="server"></asp:DropDownList></td>
    </tr>
    <tr>
        <td>کد ملی :</td>
        <td>
            <JJson:JJsonNumericTextBox ID="JJsonNumericTextBox2" runat="server" Event="textchange"></JJson:JJsonNumericTextBox></td>
        <td></td>
        <td></td>
        <td></td>
    </tr>
    <tr>
        <td>آدرس کامل :</td>
        <td>
            <JJson:JJsonTextBox ID="JJsonTextBox3" runat="server" Event="textchange"></JJson:JJsonTextBox></td>
        <td></td>
        <td></td>
        <td></td>
    </tr>
    <tr>
        <td></td>
        <td></td>
        <td></td>
        <td></td>
        <td></td>
    </tr>
    <tr>
        <td></td>
        <td></td>
        <td>
            <JJson:JJsonButton ID="JJsonButton1" runat="server" Event="click"  Text="خروج"/></td>
        <td>
            <JJson:JJsonButton ID="JJsonButton2" runat="server" Event="click"  Text="ثبت قرارداد"/></td>
        <td>
            <JJson:JJsonButton ID="JJsonButton3" runat="server" Event="click"  Text="ثبت"/></td>
    </tr>
</table>
