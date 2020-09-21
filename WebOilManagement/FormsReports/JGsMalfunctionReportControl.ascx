<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="JGsMalfunctionReportControl.ascx.cs" Inherits="WebOilManagement.FormsReports.JGsMalfunctionReportControl" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<%@ Register src="~/WebControllers/MainControls/CustomListSelector/JCustomListSelectorControl.ascx" tagname="JCustomListSelectorControl" tagprefix="uc2" %>
<%@ Register Src="~/WebControllers/MainControls/Grid/JGridViewControl.ascx" TagPrefix="uc1" TagName="JGridViewControl" %>
<%@ Register src="~/WebControllers/MainControls/Date/JDateControl.ascx" tagname="JDateControl" tagprefix="uc1" %>

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
    گزارش خرابی های هر جایگاه</p>
<table style="width: 500px">
    <tr class="Table_RowB">
        <td style="width: 150px">منطقه :</td>
        <td>
            <telerik:RadComboBox runat="server" ID="cmbOilZone" AutoPostBack="true" Width="100%" OnSelectedIndexChanged="cmbOilZone_SelectedIndexChanged" >
            </telerik:RadComboBox>
        </td>
    </tr>
    <tr class="Table_RowC">
        <td>&nbsp;ناحیه :</td>
        <td>
            <telerik:RadComboBox runat="server" ID="cmbArea" Filter="Contains" AutoPostBack="true"  OnSelectedIndexChanged="cmbArea_SelectedIndexChanged" ></telerik:RadComboBox>
        </td>
    </tr>
    <tr class="Table_RowB">
        <td>نام جایگاه :</td>
        <td>
            <telerik:RadComboBox runat="server" ID="cmbStationName" Filter="Contains"></telerik:RadComboBox>
        </td>
    </tr>
    <tr class="Table_RowC">
        <td>نوع استفاده :</td>
        <td>
            <asp:RadioButtonList ID="rbtnUseType" runat="server">
                <asp:ListItem Value="0" Selected="True">هیچکدام</asp:ListItem>
                <asp:ListItem Value="1">سرویس</asp:ListItem>
                <asp:ListItem Value="2">تعویض</asp:ListItem>
            </asp:RadioButtonList>
        </td>
    </tr>
    <tr class="Table_RowB">
        <td>از تاریخ :</td>
        <td>
            <uc1:JDateControl runat="server" id="AsDate" />
        </td>
    </tr>
    <tr class="Table_RowC">
        <td>تا تاریخ :</td>
        <td>
            <uc1:JDateControl runat="server" id="ToDate" />
        </td>
    </tr>
</table>


<telerik:RadButton runat="server" ID="btnGenerateReport" Text="مشاهده گزارش" AutoPostBack="true" Width="100px" Height="35px" OnClick="btnGenerateReport_Click" />
<telerik:RadButton runat="server" ID="btnClose" Text="بازگشت" OnClientClicked="CloseDialog" AutoPostBack="false" Width="100px" Height="35px" />
<table style="width: 100%; height: auto; margin-top: 15px">
    <tr>
        <td style="width: 100%; height: auto; overflow: auto">
            <uc1:JGridViewControl runat="server" id="grdManagerPortalReports" />
        </td>
    </tr>
</table>





