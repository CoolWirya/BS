<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="JBusGetReportFromConsoleUpdateControl.ascx.cs" Inherits="WebBusManagement.FormsMaintenance.JBusGetReportFromConsoleUpdateControl" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register Src="~/WebControllers/MainControls/Date/JDateControl.ascx" TagPrefix="uc1" TagName="JDateControl" %>
<%@ Register Src="~/WebControllers/MainControls/Persons/JSearchPersonControl.ascx" TagPrefix="uc2" TagName="JSearchPersonControl" %>

<div class="BigTitle">دریافت پرینت از کنسول</div>
<table style="width: 500px">
    <tr class="Table_RowB">
        <td style="width: 150px">اتوبوس:</td>
        <td>
            <telerik:RadComboBox runat="server" ID="cmbBus" Width="100%" Filter="Contains"></telerik:RadComboBox>
        </td>
    </tr>
    <tr class="Table_RowB">
        <td style="width: 150px">از تاریخ:</td>
        <td>
            <uc1:JDateControl runat="server" id="txtFromDate" />
        </td>
    </tr>
    <tr class="Table_RowC">
        <td style="width: 150px">تا تاریخ:</td>
        <td>
            <uc1:JDateControl runat="server" id="txtToDate" />
        </td>
    </tr>
    <tr class="Table_RowB">
        <td style="width: 150px">ارسال تراکنش:</td>
        <td>
            <asp:RadioButtonList ID="RbSendTransaction" runat="server">
                <Items>
                    <asp:ListItem Enabled="true" Selected="True" Text="دریافت پرینت" Value="0"></asp:ListItem>
                    <asp:ListItem Enabled="true" Text="ارسال تراکنش" Value="1"></asp:ListItem>
                </Items>
            </asp:RadioButtonList>
        </td>
    </tr>
</table>
<telerik:RadButton runat="server" ID="btnSave" Text="ذخیره" AutoPostBack="true" Width="100px" Height="35px" OnClick="btnSave_Click" />
<telerik:RadButton runat="server" ID="btnClose" Text="بازگشت" OnClientClicked="CloseDialog" AutoPostBack="false" Width="100px" Height="35px" />
