<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="JFormDefineControl.ascx.cs" Inherits="WebControllers.FormManager.JFormDefineControl" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>

<table>
    <tr>
        <td colspan="2">نام فرم:
            <br />
            <asp:TextBox runat="server" ID="txtFormName" Width="275px" />
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ErrorMessage="نام فرم الزامی است" ValidationGroup="formName" Display="Dynamic" ControlToValidate="txtFormName" runat="server" ForeColor="Red" />
        </td>
    </tr>
    <tr>
        <td>افراد قابل ارجاع
            <br />
            <div style="width: 200px; height: 300px; overflow-y: auto">
                <asp:CheckBoxList runat="server" ID="clbPosts">
                </asp:CheckBoxList>
            </div>
        </td>
        <td>SQL Query
            <br />
            <asp:TextBox runat="server" ID="txtQuery" TextMode="MultiLine" Height="300px" Width="281px" />
        </td>
    </tr>
    <tr>
        <td>
            <asp:CheckBox Text="امکان ثبت چندین رکورد بصورت همزمان" ID="cbxMultiple" runat="server" />
        </td>
    </tr>
    <tr>
        <td>
            <telerik:RadButton runat="server" ID="btnSave" Text="ثبت و ادامه" AutoPostBack="true" Width="100px" Height="35px" OnClick="btnSave_Click" ValidationGroup="formName" />
            <telerik:RadButton runat="server" ID="btnClose" Text="بستن" AutoPostBack="false" OnClientClicked="CloseDialog" Width="100px" Height="35px" />
        </td>
    </tr>
</table>
