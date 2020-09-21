<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="JTableDamagesUpdateControl.ascx.cs" Inherits="WebOilManagement.Forms.JTableDamagesUpdateControl" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>

<div class="FormContent">
    <div class="BigTitle">جدول خرابی</div>
    <table>
         <tr>
            <td class="Table_RowB">شماره خرابی:</td>
            <td class="Table_RowC">
             <telerik:RadNumericTextBox runat="server" Type="Number" NumberFormat-DecimalDigits="0" NumberFormat-GroupSeparator="" MinValue="0" MaxValue="2147483647"
                  AutoPostBack="false" ID="txtFailureNumber"  Width="70px" ReadOnly="false"></telerik:RadNumericTextBox>
                <asp:RequiredFieldValidator ID="rfvFailureNumber" runat="server" ErrorMessage="*"
                    ControlToValidate="txtFailureNumber" ValidationGroup="TableDamage" Display="Dynamic"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="Table_RowB">نام خرابی:</td>
            <td class="Table_RowC">
                <telerik:RadTextBox ID="txtDamageName" runat="server" Width="90%"></telerik:RadTextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*"
                    ControlToValidate="txtDamageName" ValidationGroup="TableDamage" Display="Dynamic"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="Table_RowB">نوع خرابی:</td>
            <td class="Table_RowC">
                <telerik:RadComboBox ID="cmbFailureType" runat="server" Width="90%"></telerik:RadComboBox>
            </td>
        </tr>
        <tr>
            <td class="Table_RowB">زمان مورد نیاز جهت رفع خرابی به دقیقه:</td>
            <td class="Table_RowC">
                <telerik:RadTextBox ID="txtTimeRequiredToRepair" runat="server" Width="90%"></telerik:RadTextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*"
                    ControlToValidate="txtTimeRequiredToRepair" ValidationGroup="TableDamage" Display="Dynamic"></asp:RequiredFieldValidator>
                <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="لطفا عدد وارد کنید" 
                    Display="Dynamic" ControlToValidate="txtTimeRequiredToRepair" Type="Double" ValidationGroup="TableDamage"></asp:CompareValidator>
            </td>
        </tr>
        <tr>
            <td class="Table_RowB">تخصص:</td>
            <td class="Table_RowC">
                <telerik:RadTextBox ID="txtExpertiseRequired" runat="server" Width="90%"></telerik:RadTextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*"
                    ControlToValidate="txtExpertiseRequired" ValidationGroup="TableDamage" Display="Dynamic"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="Table_RowB">فوریت:</td>
            <td class="Table_RowC">
                <telerik:RadComboBox ID="cmbUrgencies" runat="server" Width="90%"></telerik:RadComboBox>
            </td>
        </tr>
    </table>
</div>
<div class="FormButtons">
    <telerik:RadButton runat="server" ID="btnSave" Text="ذخیره" AutoPostBack="true" Width="100px" Height="35px" OnClick="btnSave_Click" ValidationGroup="TableDamage" />
    <telerik:RadButton runat="server" ID="btnClose" Text="بازگشت" OnClientClicked="CloseDialog" AutoPostBack="false" Width="100px" Height="35px" />
    <telerik:RadButton runat="server" ID="btnDelete" Text="حذف" AutoPostBack="true" Width="100px" Height="35px" OnClick="btnDelete_Click" CssClass="floatLeft" OnClientClicking="OnClientClicking" />
</div>
