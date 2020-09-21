<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="JMalFunctionVsRepairReportsRepairControl.ascx.cs" Inherits="WebOilManagement.FormsReports.JMalFunctionVsRepairReportsRepairControl" %>

<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<%@ Register src="~/WebControllers/MainControls/Date/JDateControl.ascx" tagname="JDateControl" tagprefix="uc1" %>
<%@ Register Src="~/WebControllers/MainControls/Grid/JGridViewControl.ascx" TagPrefix="uc1" TagName="JGridViewControl" %>
<%@ Register src="~/WebControllers/MainControls/CustomListSelector/JCustomListSelectorControl.ascx" tagname="JCustomListSelectorControl" tagprefix="uc2" %>


<telerik:RadAjaxManagerProxy runat="server" ID="AjaxManagerProxy_Control">
    <AjaxSettings>
        <telerik:AjaxSetting AjaxControlID="cmbOilZone">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="cmbArea" />
                <telerik:AjaxUpdatedControl ControlID="cmbSupplier" />
            </UpdatedControls>
        </telerik:AjaxSetting>
    </AjaxSettings>
</telerik:RadAjaxManagerProxy>


<p>
    فرم گزارش گیری از خرابی ها و تعمیرات انجام شده</p>

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
            <telerik:RadComboBox runat="server" ID="cmbArea" Filter="Contains" AutoPostBack="true" OnSelectedIndexChanged="cmbArea_SelectedIndexChanged" ></telerik:RadComboBox>
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
        <td>نوع استفاده : </td>
        <td>
            <asp:RadioButtonList ID="rbtnUseType" runat="server" OnSelectedIndexChanged="rbtnUseType_SelectedIndexChanged">
                <asp:ListItem Selected="True" Value="0">هیچکدام</asp:ListItem>
                <asp:ListItem Value="1">سرویس</asp:ListItem>
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
    </table>

<table style="width: 100%; height: auto; margin-top: 15px">
    <tr>
        <td style="width: 100%; height: auto; overflow: auto">
            <uc1:JGridViewControl ID="grdManagerPortalReports" runat="server" />
        </td>
    </tr>
</table>


