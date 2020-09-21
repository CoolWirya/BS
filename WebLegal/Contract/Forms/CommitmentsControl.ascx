<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CommitmentsControl.ascx.cs" Inherits="WebLegal.Contract.Forms.CommitmentsControl" %>
<%@ Register Assembly="JJson" Namespace="JJson.Controls" TagPrefix="JJson" %>
<table>
    <tr>
        <td>
            تبصره تعهدات :
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
            <JJson:JJsonTextBox ID="JtxtGuarantee" runat="server" Event="textchange"></JJson:JJsonTextBox>
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
            تبصره شروط :
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
            <JJson:JJsonTextBox ID="JtxtCondition" runat="server" Event="textchange"></JJson:JJsonTextBox>
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
            <asp:Button ID="JbtnNext" runat="server" Text="بعدی" />
        </td>
        <td>
             <asp:Button ID="JbtnPre" runat="server" Text="قبلی" />
        </td>
        <td>

        </td>
        <td>
             <asp:Button ID="JbtnCancel" runat="server" Text="انصراف" />
        </td>
    </tr>
</table>
