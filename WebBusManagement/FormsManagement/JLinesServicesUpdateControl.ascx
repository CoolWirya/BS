<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="JLinesServicesUpdateControl.ascx.cs" Inherits="WebBusManagement.FormsManagement.JLinesServicesUpdateControl" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register Src="~/WebControllers/MainControls/Date/JDateControl.ascx" TagPrefix="uc1" TagName="JDateControl" %>

<div class="BigTitle">ثبت سرویس های خطوط</div>
<table style="width: 500px">
    <tr class="Table_RowC">
        <td style="width: 150px">شیفت:</td>
        <td>
            <telerik:RadComboBox runat="server" ID="cmbShift" Width="90%"></telerik:RadComboBox>
        </td>
    </tr>
    <tr class="Table_RowC">
        <td style="width: 150px">تعداد سرویس:</td>
        <td>
            <telerik:RadNumericTextBox runat="server" ID="ntb_NumOfServicePerDay" NumberFormat-DecimalDigits="0" 
                NumberFormat-AllowRounding="false" NumberFormat-GroupSeparator="" Width="96%"></telerik:RadNumericTextBox>
        </td>
    </tr>
</table>
<table style="width: 100%">
    <tr>
        <td>
            <asp:GridView ID="RadGridReport" runat="server" Width="100%" HorizontalAlign="Center"
                RowStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" RowStyle-ForeColor="Black"
                OnSelectedIndexChanged="RadGridReport_SelectedIndexChanged" EnableModelValidation="True" AllowPaging="True">
                <Columns>
                    <asp:ButtonField CommandName="Select" HeaderText="انتخاب" ShowHeader="True" Text="انتخاب"
                        ButtonType="Link" />
                </Columns>
                <RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Center" />
                <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#F7F7F7" />
            </asp:GridView>
        </td>
    </tr>
    <tr>
        <td>
            <telerik:RadButton runat="server" ID="btnDelService" Text="حذف" AutoPostBack="true" Width="100px" Height="35px" OnClick="btnDelService_Click" Visible="false" />
        </td>
    </tr>
</table>
<input type="hidden" name="EditCode" id="EditCode" runat="server" value="0" />
<div class="FormButtons">
    <telerik:RadButton runat="server" ID="btnSave" Text="ذخیره" AutoPostBack="true" Width="100px" Height="35px" OnClick="btnSave_Click" />
    <telerik:RadButton runat="server" ID="btnClose" Text="بازگشت" OnClientClicked="CloseDialog" AutoPostBack="false" Width="100px" Height="35px" />
</div>

