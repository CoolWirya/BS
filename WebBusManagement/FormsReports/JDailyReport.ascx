<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="JDailyReport.ascx.cs" Inherits="WebBusManagement.FormsReports.JDailyReport" %>

<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register Src="~/WebControllers/MainControls/Date/JDateControl.ascx" TagPrefix="uc1" TagName="JDateControl" %>
<%@ Register Assembly="WebControllers" Namespace="WebControllers.MainControls.Grid" TagPrefix="cc1" %>
<div class="BigTitle">گزارش پرینت روزانه</div>
<table style="width: 500px">
    <tr class="Table_RowB">
        <td style="width: 150px">شماره اتوبوس:</td>
        <td>
            <telerik:RadComboBox runat="server" ID="cmbBus" Width="100%" Filter="Contains">
            </telerik:RadComboBox>
        </td>
    </tr>
    <tr class="Table_RowC">
        <td style="width: 150px">انتخاب روز:</td>
        <td>
			<uc1:JDateControl runat="server" id="dteControlDay" />
        </td>
    </tr>
    <tr class="Table_RowB">
        <td style="width: 150px">وضعیت:</td>
        <td>
            <telerik:RadComboBox runat="server" ID="cmbstate" Width="100%" Filter="Contains">
                <Items>
                    <telerik:RadComboBoxItem Value="1" Text="موفق" Selected="true" />
                    <telerik:RadComboBoxItem Value="0" Text="ناموفق" />
                </Items>
            </telerik:RadComboBox>
        </td>
    </tr>
</table>

<telerik:RadButton runat="server" ID="btnSave" Text="مشاهده گزارش" AutoPostBack="true" Width="100px" Height="35px" OnClick="btnSave_Click" />
<telerik:RadButton runat="server" ID="btnClose" Text="بازگشت" OnClientClicked="CloseDialog" AutoPostBack="false" Width="100px" Height="35px" />

<table style="width: 100%; height: auto; margin-top: 15px">
    <tr>
        <td style="width: 100%; height: auto; overflow: auto"><cc1:JGridView runat="server" id="RadGridReport"></cc1:JGridView>
            
        </td>
    </tr>
</table>