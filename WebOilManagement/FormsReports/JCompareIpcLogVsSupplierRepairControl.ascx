<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="JCompareIpcLogVsSupplierRepairControl.ascx.cs" Inherits="WebOilManagement.FormsReports.JCompareIpcLogVsSupplierRepairControl" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<%@ Register src="~/WebControllers/MainControls/Date/JDateControl.ascx" tagname="JDateControl" tagprefix="uc1" %>
<%@ Register Src="~/WebControllers/MainControls/Grid/JGridViewControl.ascx" TagPrefix="uc1" TagName="JGridViewControl" %>
<%@ Register src="~/WebControllers/MainControls/CustomListSelector/JCustomListSelectorControl.ascx" tagname="JCustomListSelectorControl" tagprefix="uc2" %>

<p>
    مقایسه گزارش تعمیرات پیمانکار با IPC Log</p>

<table>
    <tr class="Table_RowB">
        <td>نام منطقه :</td>
        <td>
            <telerik:RadComboBox runat="server" ID="cmbOilZone" AutoPostBack="true" Width="100%" OnSelectedIndexChanged="cmbOilZone_SelectedIndexChanged">
            </telerik:RadComboBox>
        </td>
    </tr>
    <tr class="Table_RowC">
        <td>نام ناحیه :</td>
        <td>
            <telerik:RadComboBox runat="server" ID="cmbArea" AutoPostBack="true" Filter="Contains" OnSelectedIndexChanged="cmbArea_SelectedIndexChanged" ></telerik:RadComboBox>
        </td>
    </tr>
    <tr class="Table_RowB">
        <td>نام جایگاه :</td>
        <td>
            <telerik:RadComboBox runat="server" ID="cmbStationName" Filter="Contains"></telerik:RadComboBox>
        </td>
    </tr>
    <tr class="Table_RowC">
        <td>زمان وقوع خرابی :</td>
        <td>
            <uc1:JDateControl runat="server" id="dcFailurDate" />
        </td>
    </tr>
    <tr class="Table_RowB">
        <td>زمان رفع خرابی :</td>
        <td>
            <uc1:JDateControl runat="server" id="dcFixingBrokenDate" />
        </td>
    </tr>
    <tr class="Table_RowC">
        <td>دلیل عدم رفع خرابی :</td>
        <td>
            <telerik:RadComboBox runat="server" ID="cmbEliminateDownTimeDue" AutoPostBack="true" Width="100%">
            </telerik:RadComboBox>
        </td>
    </tr>
    <tr class="Table_RowB">
        <td>نحوه اعلام خرابی :</td>
        <td>
            <asp:TextBox ID="TxHowMalFunction" runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr class="Table_RowC">
        <td>قطعه معیوب :</td>
        <td>
            <uc2:JCustomListSelectorControl runat="server" id="jclDefectiveItem" />
        </td>
    </tr>
    <tr class="Table_RowB">
        <td>نوع استفاده :</td>
        <td>
            <asp:RadioButtonList ID="rbtnUseType" runat="server" OnSelectedIndexChanged="rbtnUseType_SelectedIndexChanged">
                <asp:ListItem Value="1" Selected="True">سرویس</asp:ListItem>
                <asp:ListItem Value="2">تعویض</asp:ListItem>
            </asp:RadioButtonList>
        </td>
    </tr>
    <tr>
        <td>
            <telerik:RadButton runat="server" ID="btnGenerateReport" Text="مشاهده گزارش" AutoPostBack="true" Width="100px" Height="35px" OnClick="btnGenerateReport_Click" />
            <telerik:RadButton runat="server" ID="btnClose" Text="بازگشت" OnClientClicked="CloseDialog" AutoPostBack="false" Width="100px" Height="35px" />
        </td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td>



            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    </table>

<table style="width: 100%; height: auto; margin-top: 15px">
    <tr>
        <td style="width: 100%; height: auto; overflow: auto">
            <uc1:jgridviewcontrol ID="grdManagerPortalReports" runat="server" />
        </td>
    </tr>
</table>
