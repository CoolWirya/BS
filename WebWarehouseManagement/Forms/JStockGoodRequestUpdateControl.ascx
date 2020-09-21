<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="JStockGoodRequestUpdateControl.ascx.cs" Inherits="WebWarehouseManagement.Forms.JStockGoodRequestUpdateControl" %>
<%@ Register Assembly="JJson" Namespace="JJson.Controls" TagPrefix="JJson" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register Src="~/WebControllers/MainControls/Date/JDateControl.ascx" TagPrefix="uc1" TagName="JDateControl" %>


<div>
    
    <table>
                <tr>
                    <td class="Table_RowB">تاریخ درخواست:</td>
                    <td class="Table_RowC">
                        <uc1:JDateControl runat="server" id="dteRegisterDate" />
                    </td>
                </tr>
                <tr>
                    <td class="Table_RowB">درخواست دهنده کالا :</td>
                    <td class="Table_RowC">
                        <asp:Label ID="lblGoodRequestUser" runat="server" Text="GoodRequestUser"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="Table_RowB">نام انبار:</td>
                    <td class="Table_RowC">
                        <asp:Label ID="lblWarName" runat="server" Text="WarName"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="Table_RowB">نام کالا :</td>
                    <td class="Table_RowC">
                        <asp:DropDownList ID="ddlGoods" runat="server" AutoPostBack="True" Height="21px" OnSelectedIndexChanged="ddlGoods_SelectedIndexChanged" Width="120px">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="Table_RowB">تعداد کالا :</td>
                    <td class="Table_RowC">
                        <asp:TextBox ID="txtGoodCount" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="Table_RowB">&nbsp;</td>
                    <td class="Table_RowC">
                        &nbsp;</td>
                </tr>
            </table>
    <br />
    <asp:Button ID="btnClose" runat="server" OnClick="btnClose_Click" Text="برگشت" />
</div>