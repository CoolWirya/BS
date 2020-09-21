<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="JGoodsUpdateControl.ascx.cs" Inherits="WebWarehouseManagement.Forms.JGoodsUpdateControl" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register Src="~/WebControllers/MainControls/Persons/JSearchPersonControl.ascx" TagPrefix="uc1" TagName="JSearchPersonControl" %>
<telerik:RadAjaxManagerProxy runat="server" ID="AjaxManagerProxy_Control">
    <AjaxSettings>
        <telerik:AjaxSetting AjaxControlID="btnSave_Click">
           
        </telerik:AjaxSetting>
        
    </AjaxSettings>
</telerik:RadAjaxManagerProxy>
<div class="FormContent">
    <div class="BigTitle">کالا</div>
    <table>
        <tr>
            <td class="Table_RowB">نوع کالا :</td>
            <td class="Table_RowC">
                <telerik:RadComboBox runat="server" ID="cmbTypesOfGoods" EnableViewState="true"  OnSelectedIndexChanged="cmbTypesOfGoods_SelectedIndexChanged" AutoPostBack="true"></telerik:RadComboBox>
            </td>
        </tr>
       <%-- <tr>
            <td class="Table_RowB">سریال :</td>
            <td class="Table_RowC">
                <telerik:RadNumericTextBox  runat="server" Type="Number" NumberFormat-DecimalDigits="0" NumberFormat-GroupSeparator=""
                    MinValue="0" MaxValue="2147483647" ID="txtSerial" Enabled="false"></telerik:RadNumericTextBox>
                  <asp:RequiredFieldValidator ID="rfvSerial" runat="server" ErrorMessage="*" Font-Size="10" Text="*" 
                      ControlToValidate="txtSerial" Enabled="false" ValidationGroup="Save"></asp:RequiredFieldValidator>
            </td>
        </tr>--%>
        <tr>
            <td class="Table_RowB" >مدل :</td>
            <td class="Table_RowC">
                <telerik:RadTextBox runat="server" ID="txtModel"></telerik:RadTextBox>
                 
            </td>
        </tr>
        <tr>
         <%--   <td class="Table_RowB">سازنده :</td>
            <td class="Table_RowC">
                <telerik:RadComboBox runat="server" ID="cmbManufacturers" Filter="Contains"></telerik:RadComboBox>
            </td>--%>
            <!-- با نظر شخص مهندس زرین تغییر کرد-->
            <tr>
            <td class="Table_RowB">سازنده :</td>
            <td class="Table_RowC">
                 <uc1:JSearchPersonControl runat="server" id="personCode" />
            </td>
        </tr>
        </tr>
        <tr>
            <td class="Table_RowB">سال ساخت :</td>
            <td class="Table_RowC">
                <telerik:RadNumericTextBox runat="server" Type="Number"  NumberFormat-DecimalDigits="0"  NumberFormat-GroupSeparator=""
                    MinValue="0" MaxValue="9999" ID="txtBuildYear" ></telerik:RadNumericTextBox>
               <%--  <asp:RequiredFieldValidator ID="rfvBuildYear" runat="server" ErrorMessage="*" Font-Size="10" Text="*" 
                      ControlToValidate="txtBuildYear" ValidationGroup="Save"></asp:RequiredFieldValidator>--%>
            </td>
        </tr>
        <tr>
            <td class="Table_RowB">شرح :</td>
            <td class="Table_RowC">
               <telerik:RadTextBox runat="server" ID="txtName" TextMode="MultiLine"></telerik:RadTextBox>
   <%--              <asp:RequiredFieldValidator ID="rfvName" runat="server" ErrorMessage="*" Font-Size="10" Text="*" 
                      ControlToValidate="txtName" ValidationGroup="Save"></asp:RequiredFieldValidator>--%>
            </td>
        </tr>
        <%--<tr>
            <td class="Table_RowB">انبار:</td>
            <td class="Table_RowC">
                <telerik:RadComboBox runat="server" ID="cmbWarehouse" Filter="Contains"></telerik:RadComboBox>
            </td>
        </tr>--%>
       <%-- <tr>
            <td class="Table_RowB">وضعیت کالا:</td>
            <td class="Table_RowC">
                <telerik:RadComboBox runat="server" ID="cmbStatusOfGoods" Filter="Contains"></telerik:RadComboBox>
            </td>
        </tr>--%>
    </table>
</div>
<div class="FormButtons">
    <telerik:RadButton runat="server" ID="btnSave" Text="ذخیره"  AutoPostBack="true" Width="100px" Height="35px" OnClick="btnSave_Click" ValidationGroup="Save" />
    <telerik:RadButton runat="server" ID="btnClose" Text="بازگشت" OnClientClicked="CloseDialog" AutoPostBack="false" Width="100px" Height="35px" />
</div>
