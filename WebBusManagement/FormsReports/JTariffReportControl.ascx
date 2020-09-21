<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="JTariffReportControl.ascx.cs" Inherits="WebBusManagement.FormsReports.JTariffReportControl" %>
<%@ Register Assembly="WebControllers" Namespace="WebControllers.MainControls.Grid" TagPrefix="cc1" %>

<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register Src="~/WebControllers/MainControls/Date/JDateControl.ascx" TagPrefix="uc1" TagName="JDateControl" %>
<%@ Register Src="~/WebControllers/MainControls/Persons/JSearchPersonControl.ascx" TagPrefix="uc1" TagName="JSearchPersonControl" %>
<%--<%@ Register Assembly="WebControllers" Namespace="WebControllers.MainControls.Grid" TagPrefix="cc1" %>--%>
<div class="BigTitle">گزارش تعرفه ها</div>
<table style="width: 500px">
    <tr class="Table_RowB">
        <td style="width: 150px">منطقه:</td>
        <td>
            <telerik:RadComboBox runat="server" ID="cmbZone" Width="100%" Filter="Contains"></telerik:RadComboBox>
        </td>
    </tr>
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
    <tr class="Table_RowC">
        <td style="width: 150px">وضعیت:</td>
        <td>
            <telerik:RadComboBox runat="server" ID="rblStatus" Width="100%">
                <Items>
                    <telerik:RadComboBoxItem Value="2" Text="همه" />
                    <telerik:RadComboBoxItem Value="1" Text="تایید شده" />
                    <telerik:RadComboBoxItem Value="0" Text="تایید نشده" />
                </Items>
            </telerik:RadComboBox>
        </td>
    </tr>
     <tr class="Table_RowB">
        <td style="width: 150px">وضعیت خطا:</td>
        <td>
           <telerik:RadComboBox runat="server" ID="rblShowFaulty" Width="100%">
                <Items>
                    <telerik:RadComboBoxItem Value="2" Text="همه" Selected="true"/>
                    <telerik:RadComboBoxItem Value="1" Text="بدون خطا"/>
                    <telerik:RadComboBoxItem Value="0" Text="با خطا" />
                </Items>
            </telerik:RadComboBox>
        </td>
    </tr>
    <tr class="Table_RowC">
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
</table>
<telerik:RadButton runat="server" ID="btnSave" Text="مشاهده گزارش" AutoPostBack="true" Width="100px" Height="35px" OnClick="btnSave_Click" OnClientClicked="LockButton" />
<telerik:RadButton runat="server" ID="btnClose" Text="بازگشت" OnClientClicked="CloseDialog" AutoPostBack="false" Width="100px" Height="35px" />
<table style="width: 100%; height: auto; margin-top: 15px">
    <tr>
        <td style="width: 95%;  height: auto; overflow: auto ; overflow-y: scroll; overflow-x:scroll;">
            <cc1:JGridView runat="server" id="RadGridReport">
            </cc1:JGridView>
        </td>
    </tr>
</table>
