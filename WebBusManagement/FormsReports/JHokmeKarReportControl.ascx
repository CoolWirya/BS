<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="JHokmeKarReportControl.ascx.cs" Inherits="WebBusManagement.FormsReports.JHokmeKarReportControl" %>

<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register Src="~/WebControllers/MainControls/Date/JDateControl.ascx" TagPrefix="uc1" TagName="JDateControl" %>
<%@ Register Src="~/WebControllers/MainControls/Persons/JSearchPersonControl.ascx" TagPrefix="uc1" TagName="JSearchPersonControl" %>
<%@ Register Assembly="WebControllers" Namespace="WebControllers.MainControls.Grid" TagPrefix="cc1" %>

<div class="BigTitle">گزارش حکم کار رانندگان</div>
<table style="width: 500px">
     <tr class="Table_RowC">
        <td style="width: 150px">خط:</td>
        <td>
            <telerik:RadComboBox runat="server" ID="cmbLine" Width="100%" Filter="Contains">
            </telerik:RadComboBox>
        </td>
    </tr>
    <tr class="Table_RowB">
        <td style="width: 150px">اتوبوس:</td>
        <td>
            <telerik:RadComboBox runat="server" ID="cmbBus" Width="100%" Filter="Contains">
            </telerik:RadComboBox>
        </td>
    </tr>
    <tr class="Table_RowC">
        <td style="width: 150px">راننده:</td>
        <td>
            <uc1:JSearchPersonControl runat="server" id="JSearchPersonControl" />
        </td>
    </tr>
    <tr class="Table_RowB">
        <td style="width: 150px">از تاریخ:</td>
        <td>
            <uc1:JDateControl runat="server" id="txtFromDate" />
        </td>
    </tr>
    <tr class="Table_RowB">
        <td style="width: 150px">تا تاریخ:</td>
        <td>
            <uc1:JDateControl runat="server" id="txtToDate" />
        </td>
    </tr>
    <tr class="Table_RowC">
        <td style="width: 150px">وضعیت:</td>
        <td style="height: 50px; float: right">
            <telerik:RadButton  runat="server" ID="RadHokmState" ButtonType="StandardButton" ToggleType="CustomToggle" GroupName="HokmState" AutoPostBack="false" Checked="true" Width="100%">
                <ToggleStates>
                    <telerik:RadButtonToggleState Text="همه"  Value="0" Selected="true" Width="100px" PrimaryIconCssClass="rbToggleCheckbox"></telerik:RadButtonToggleState>
                    <telerik:RadButtonToggleState Text="فقط فعال"  Value="1" Width="100px" PrimaryIconCssClass="rbToggleCheckboxFilled"></telerik:RadButtonToggleState>
                    <telerik:RadButtonToggleState Text="فقط غیر فعال" Value="2" Width="100px" PrimaryIconCssClass="rbToggleCheckboxChecked"></telerik:RadButtonToggleState>
                </ToggleStates>
            </telerik:RadButton>
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
