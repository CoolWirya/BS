<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="JMalFunctionsCountReportsControl.ascx.cs"
    Inherits="WebOilManagement.FormsReports.JMalFunctionsCountReportsControl" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register Src="~/WebControllers/MainControls/Date/JDateControl.ascx" TagPrefix="uc1" TagName="JDateControl" %>
<%@ Register Src="~/WebControllers/MainControls/Grid/JGridViewControl.ascx" TagPrefix="uc1" TagName="JGridViewControl" %>
<%@ Register Src="~/WebControllers/MainControls/CustomListSelector/JCustomListSelectorControl.ascx" TagPrefix="uc2" TagName="JCustomListSelectorControl" %>



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


<div class="BigTitle">گزارش کل تیکت های ثبت شده </div>
<table style="width: 500px">
    <tr class="Table_RowB">
        <td style="width: 150px">منطقه:</td>
        <td>
            <telerik:RadComboBox runat="server" ID="cmbOilZone" AutoPostBack="true" OnSelectedIndexChanged="cmbOilZone_SelectedIndexChanged"
                Width="100%">
            </telerik:RadComboBox>
        </td>
    </tr>
    <tr class="Table_RowC">
        <td>ناحیه:</td>
        <td>
            <telerik:RadComboBox runat="server" ID="cmbArea" Filter="Contains"></telerik:RadComboBox>
        </td>
    </tr>
    <tr class="Table_RowB">
        <td>پیمانکار:</td>
        <td>
            <telerik:RadComboBox runat="server" ID="cmbSupplier" Filter="Contains"></telerik:RadComboBox>
        </td>
    </tr>
    <tr class="Table_RowC">
        <td>نوع خرابی:</td>
        <td>
            <uc2:JCustomListSelectorControl runat="server" id="JCustomListSelectorControlDamage" />
        </td>
    </tr>
    <tr class="Table_RowB">
        <td>لیست کاربران:</td>
        <td>
            <uc2:JCustomListSelectorControl runat="server" id="JLstCtrUsers" />
        </td>
    </tr>
    <tr class="Table_RowC">
        <td>رفع نواقص؟:</td>
        <td>
            <asp:RadioButtonList ID="rbFixDefects" runat="server" AutoPostBack="true" OnSelectedIndexChanged="rbFixDefects_SelectedIndexChanged">
                <asp:ListItem Selected="False" Text="گزارش اشتباه" Value="2"></asp:ListItem>
                <asp:ListItem Selected="True" Text="بلی" Value="1"></asp:ListItem>
                <asp:ListItem Selected="False" Text="خیر" Value="0"></asp:ListItem>
            </asp:RadioButtonList>
        </td>
    </tr>
    <tr class="Table_RowB">
        <td>دلایل عدم رفع نوافص:</td>
        <td>
            <telerik:RadComboBox runat="server" ID="cmbDontFixDefects" Enabled="false" Width="100%"></telerik:RadComboBox>
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
