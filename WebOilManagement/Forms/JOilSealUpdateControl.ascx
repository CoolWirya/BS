<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="JOilSealUpdateControl.ascx.cs" Inherits="WebOilManagement.Forms.JSealUpdateControl" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>

<div class="FormContent">
    <div class="BigTitle">پلمپ</div>
    <table>
        <tr>
            <td class="Table_RowB">شماره سریال:</td>
            <td class="Table_RowC">
                <telerik:RadNumericTextBox runat="server" Type="Number" NumberFormat-DecimalDigits="0" NumberFormat-GroupSeparator=""
                    MinValue="0" MaxValue="2147483647" ID="txtSerialNumber" Width="90%">
                </telerik:RadNumericTextBox>
                <asp:RequiredFieldValidator ID="rfvSerialNumber" runat="server" ErrorMessage="*"
                            ControlToValidate="txtSerialNumber" ValidationGroup="Seal" Display="Dynamic"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="Table_RowB">نوع پلمپ:</td>
            <td class="Table_RowC">
                <asp:RadioButtonList ID="rdStatus" runat="server"></asp:RadioButtonList>
            </td>
        </tr>
    </table>
</div>
<div class="FormButtons">
    <telerik:RadButton runat="server" ID="btnSave" Text="ذخیره" AutoPostBack="true" Width="100px" Height="35px" OnClick="btnSave_Click" ValidationGroup="Seal" />
    <telerik:RadButton runat="server" ID="btnClose" Text="بازگشت" OnClientClicked="CloseDialog" AutoPostBack="false" Width="100px" Height="35px" />
    <telerik:RadButton runat="server" ID="btnDelete" Text="حذف" AutoPostBack="true" Width="100px" Height="35px" OnClick="btnDelete_Click" CssClass="floatLeft"
        OnClientClicking="OnClientClicking" />
</div>
