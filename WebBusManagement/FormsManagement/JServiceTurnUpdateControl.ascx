<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="JServiceTurnUpdateControl.ascx.cs" Inherits="WebBusManagement.FormsManagement.JServiceTurnUpdateControl" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register Src="~/WebControllers/MainControls/Date/JDateControl.ascx" TagPrefix="uc1" TagName="JDateControl" %>

<div class="BigTitle">نوبت سرویس</div>
<div style="width: 250px;">
    <table style="width: 100%">
        <tr class="Table_RowB">
            <td style="width: 100px">اتوبوس:</td>
            <td>
                <telerik:RadComboBox runat="server" ID="cmbBus" Width="100%" Filter="Contains">
                </telerik:RadComboBox>
            </td>
        </tr>
        <tr class="Table_RowC">
            <td style="width: 100px">از تاریخ:</td>
            <td>
                <uc1:JDateControl runat="server" id="txtFromDate" />
            </td>
        </tr>
        <tr class="Table_RowB">
            <td style="width: 100px">تا تاریخ:</td>
            <td>
                <uc1:JDateControl runat="server" id="txtToDate" />
            </td>
        </tr>
        <tr class="Table_RowC">
            <td style="width: 100px">نوبت اول:</td>
            <td>
                <telerik:RadComboBox runat="server" ID="cmbDay1" Width="60px"></telerik:RadComboBox>
            </td>
        </tr>
        <tr class="Table_RowB">
            <td style="width: 100px">نوبت دوم:</td>
            <td>
                <telerik:RadComboBox runat="server" ID="cmbDay2" Width="60px" Filter="Contains"></telerik:RadComboBox>
            </td>
        </tr>
    </table>
</div>
<div class="FormButtons">
    <telerik:RadButton runat="server" ID="btnSave" Text="ذخیره" AutoPostBack="true" Width="100px" Height="35px" OnClick="btnSave_Click"/>
    <telerik:RadButton runat="server" ID="btnClose" Text="بازگشت" OnClientClicked="CloseDialog" AutoPostBack="false" Width="100px" Height="35px" />
</div>