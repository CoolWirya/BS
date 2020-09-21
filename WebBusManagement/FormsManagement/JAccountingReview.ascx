<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="JAccountingReview.ascx.cs" Inherits="WebBusManagement.FormsManagement.JAccountingReview" %>

<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register Src="~/WebControllers/MainControls/Date/JDateControl.ascx" TagPrefix="uc1" TagName="JDateControl" %>
<%@ Register Assembly="WebControllers" Namespace="WebControllers.MainControls.Grid" TagPrefix="cc1" %>
<div class="BigTitle">مرور حساب ها</div>
<table style="width: 500px">
    <tr class="Table_RowB">
        <td style="width: 150px">گروه :</td>
        <td>
			<asp:CheckBoxList ID="chblGroup" runat="server"></asp:CheckBoxList>
        </td>
    </tr>
    <tr class="Table_RowC">
        <td style="width: 150px">کل :</td>
        <td>
			<asp:CheckBoxList ID="chblKol" runat="server"></asp:CheckBoxList>
        </td>
    </tr>
    <tr class="Table_RowB">
        <td style="width: 150px">معین :</td>
        <td>
			<asp:CheckBoxList ID="chblMoin" runat="server"></asp:CheckBoxList>
        </td>
    </tr>
    <tr class="Table_RowC">
        <td style="width: 150px">تفضیلی 1 :</td>
        <td>
            <telerik:RadComboBox runat="server" ID="cmbTafzili1" Width="100%" Filter="Contains">
            </telerik:RadComboBox>
        </td>
    </tr>
    <tr class="Table_RowB">
        <td style="width: 150px">تفضیلی 2 :</td>
        <td>
            <telerik:RadComboBox runat="server" ID="cmbTafzili2" Width="100%" Filter="Contains">
            </telerik:RadComboBox>
        </td>
    </tr>
    <tr class="Table_RowC">
        <td style="width: 150px">از تاریخ :</td>
        <td>
			<uc1:JDateControl runat="server" id="dteControlFrom" />
        </td>
    </tr>
    <tr class="Table_RowB">
        <td style="width: 150px">تا تاریخ :</td>
        <td>
			<uc1:JDateControl runat="server" id="dteControlTo" />
        </td>
    </tr>
</table>

<telerik:RadButton runat="server" ID="btnSave" Text="مشاهده گزارش" AutoPostBack="true" Width="100px" Height="35px" />
<telerik:RadButton runat="server" ID="btnClose" Text="بازگشت" OnClientClicked="CloseDialog" AutoPostBack="false" Width="100px" Height="35px" />

<table style="width: 100%; height: auto; margin-top: 15px">
    <tr>
        <td style="width: 100%; height: auto; overflow: auto"><cc1:JGridView runat="server" id="RadGridReport"></cc1:JGridView>
            <cc1:JGridView runat="server" id="RadGridReport">
        </td>
    </tr>
</table>