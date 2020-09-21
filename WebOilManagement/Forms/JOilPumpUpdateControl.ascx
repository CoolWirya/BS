<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="JOilPumpUpdateControl.ascx.cs" Inherits="WebOilManagement.Forms.JOilPumpUpdateControl" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>

<div class="FormContent">
    <div class="BigTitle">پمپ</div>
    <table>
        <tr>
            <td class="Table_RowB">شماره پمپ:</td>
            <td class="Table_RowC">
                <telerik:RadNumericTextBox runat="server" Type="Number" NumberFormat-DecimalDigits="0" NumberFormat-GroupSeparator="" MinValue="0" MaxValue="2147483647" ID="txtNumber" Width="100%"></telerik:RadNumericTextBox>
            </td>
        </tr>
        <tr>
            <td class="Table_RowB">نوع پمپ:</td>
            <td class="Table_RowC">
                <telerik:RadComboBox runat="server" ID="cmbPump" Filter="Contains" OnSelectedIndexChanged="cmbPump_SelectedIndexChanged" AutoPostBack="true"></telerik:RadComboBox>
            </td>
        </tr>
        <tr>
            <td class="Table_RowB">جایگاه:</td>
            <td class="Table_RowC">
                <telerik:RadComboBox runat="server" ID="cmbGasStation" Filter="Contains"></telerik:RadComboBox>
            </td>
        </tr>
        <tr>
            <td class="Table_RowB">جایگاه:</td>
            <td class="Table_RowC">
               
            </td>
        </tr>
         <tr>
            <td class="Table_RowB"></td>
            <td class="Table_RowC">
               
            </td>
        </tr>
    </table>
    <asp:Panel ID="pnlNozzel" runat="server" GroupingText="لیست نازل ها" >
        <asp:ImageButton runat="server"  ID="btnJOilNozzle" OnClick="btnJOilNozzle_Click" ImageUrl="~\Images\Controls\menu_add.png" />
    <telerik:RadGrid runat="server" ID="rgNozzel" AutoGenerateColumns="true" Width="100%" >
        <MasterTableView >

        </MasterTableView>
    </telerik:RadGrid>
        </asp:Panel>
</div>
<div class="FormButtons">
    <telerik:RadButton runat="server" ID="btnSave" Text="ذخیره" AutoPostBack="true" Width="100px" Height="35px" OnClick="btnSave_Click" />
    <telerik:RadButton runat="server" ID="btnClose" Text="بازگشت" OnClientClicked="CloseDialog" AutoPostBack="false" Width="100px" Height="35px" />
    <telerik:RadButton runat="server" ID="btnDelete" Text="حذف" AutoPostBack="true" Width="100px" Height="35px" OnClick="btnDelete_Click" CssClass="floatLeft" OnClientClicking="OnClientClicking" />
</div>
