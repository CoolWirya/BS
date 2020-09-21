<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="JStationPassCalenderReportControl.ascx.cs" Inherits="WebBusManagement.FormsReports.JStationPassCalenderReportControl" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register Src="~/WebControllers/MainControls/Date/JDateControl.ascx" TagPrefix="uc1" TagName="JDateControl" %>
<%@ Register Assembly="WebControllers" Namespace="WebControllers.MainControls.Grid" TagPrefix="cc1" %>

<div class="BigTitle">گزارش تقویم تراکم در هر ایستگاه</div>
<table style="width: 500px">
    <tr class="Table_RowC">
        <td style="width: 150px">خط:</td>
        <td>
            <telerik:RadComboBox runat="server" ID="cmbLine" Width="100%" Filter="Contains">
            </telerik:RadComboBox>
        </td>
    </tr>
    <tr class="Table_RowC">
        <td style="width: 150px">مسیر:</td>
        <td>
            <telerik:RadComboBox runat="server" ID="cmbPathType" Width="100%" Filter="Contains">
                <Items>
                    <telerik:RadComboBoxItem Text="رفت" Value="0" Checked="true" />
                    <telerik:RadComboBoxItem Text="برگشت" Value="1" />
                </Items>
            </telerik:RadComboBox>
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
    <tr class="Table_RowB">
        <td style="width: 150px">از ساعت:</td>
        <td>
            <telerik:RadTextBox runat="server" id="txtHourOf" InputType="Number" Text="04" Width="40px" />:
            <telerik:RadTextBox runat="server" id="txtMinuteOf" InputType="Number" Text="00" Width="40px"/>
        </td>
    </tr>
    <tr class="Table_RowC">
        <td style="width: 150px">تا ساعت:</td>
        <td>
            <telerik:RadTextBox runat="server" id="txtHourTo" InputType="Number" Text="23" Width="40px"/>:
            <telerik:RadTextBox runat="server" id="txtMinuteTo" InputType="Number" Text="00" Width="40px"/>
        </td>
    </tr>
    <tr class="Table_RowC">
        <td style="width: 150px">بازه(دقیقه):</td>
        <td>
            <telerik:RadTextBox runat="server" id="txtTimeInterval" InputType="Number" Text="30" />
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
