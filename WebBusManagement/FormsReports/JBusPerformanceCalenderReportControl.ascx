<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="JBusPerformanceCalenderReportControl.ascx.cs" Inherits="WebBusManagement.FormsReports.JBusPerformanceCalenderReportControl" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register Src="~/WebControllers/MainControls/Date/JDateControl.ascx" TagPrefix="uc1" TagName="JDateControl" %>
<div class="BigTitle">گزارش تقویم کارکرد تفصیلی اتوبوس</div>
<table style="width: 500px">
    <tr class="Table_RowB">
        <td style="width: 150px">اتوبوس:</td>
        <td>
            <telerik:RadComboBox runat="server" ID="cmbBus" Width="100%" Filter="Contains">
            </telerik:RadComboBox>
        </td>
    </tr>
    <tr class="Table_RowC">
        <td style="width: 150px">سال:</td>
        <td>
            <telerik:RadComboBox runat="server" ID="cmbYears" Width="100%" Filter="Contains">
            </telerik:RadComboBox>
        </td>
    </tr>
    <tr class="Table_RowB">
        <td style="width: 150px">ماه:</td>
        <td>
            <telerik:RadComboBox runat="server" ID="cmbMount" Width="100%" Filter="Contains">
                <Items>
                    <telerik:RadComboBoxItem Value="1" Text="فروردین" Selected="true" />
                    <telerik:RadComboBoxItem Value="2" Text="اردیبهشت" />
                    <telerik:RadComboBoxItem Value="3" Text="خرداد" />
                    <telerik:RadComboBoxItem Value="4" Text="تیر" />
                    <telerik:RadComboBoxItem Value="5" Text="مرداد" />
                    <telerik:RadComboBoxItem Value="6" Text="شهریور" />
                    <telerik:RadComboBoxItem Value="7" Text="مهر" />
                    <telerik:RadComboBoxItem Value="8" Text="آبان" />
                    <telerik:RadComboBoxItem Value="9" Text="آذر" />
                    <telerik:RadComboBoxItem Value="10" Text="دی" />
                    <telerik:RadComboBoxItem Value="11" Text="بهمن" />
                    <telerik:RadComboBoxItem Value="12" Text="اسفند" />
                </Items>
            </telerik:RadComboBox>
        </td>
    </tr>
</table>
<telerik:RadButton runat="server" ID="btnSave" Text="مشاهده گزارش" AutoPostBack="true" Width="100px" Height="35px" OnClick="btnSave_Click" />
<telerik:RadButton runat="server" ID="btnClose" Text="بازگشت" OnClientClicked="CloseDialog" AutoPostBack="false" Width="100px" Height="35px" />
<table style="width: 100%">
    <tr>
        <td style="width:100%;height:20px;text-align:center">
        </td>
    </tr>
</table>
<div style="width: 1000px; height: auto; margin-right: auto; margin-left: auto">
    <div style="float:right;width:100px;height:20px;background-color:#9b9797;color:white;text-align:center">
        بدون تراکنش
    </div>
    <div style="float:right;width:100px;height:20px;background-color:#ca8383;color:white;text-align:center">
        تایید نشده
    </div>
    <div style="float:right;width:100px;height:20px;background-color:#0094ff;color:white;text-align:center">
        پرداخت نشده
    </div>
    <div style="float:right;width:100px;height:20px;background-color:#ffd800;color:black;text-align:center">
        بدون پرینت
    </div>
    <div style="float:right;width:100px;height:20px;background-color:#3aa807;color:white;text-align:center">
        کامل
    </div>
    <div style="float:right;width:100px;height:20px;background-color:#15d42b;color:black;text-align:center">
        تایید شده با پرینت
    </div>
    <div style="float:right;width:100px;height:20px;background-color:#00ff21;color:black;text-align:center">
        برابر با پرینت
    </div>
    <div style="float:right;width:100px;height:20px;background-color:#ff0000;color:white;text-align:center">
        بیشتر از پرینت
    </div>
    <div style="float:right;width:100px;height:20px;background-color:#60f6c3;color:black;text-align:center">
        کمتر از پرینت
    </div>
    <div style="float:right;width:100px;height:20px;background-color:#75cf7a;color:white;text-align:center">
        عدم ارسال درب ها
    </div>
</div>
<div style="clear:both;height:5px"></div>
<div style="width: 860px; height: auto; margin-right: auto; margin-left: auto">
    <div style='float:right;background-color:yellow;color:black;width:122px;height:15px;text-align:center'>
        شنبه
    </div>
     <div style='float:right;background-color:yellow;color:black;width:122px;height:15px;text-align:center'>
        یکشنبه
    </div>
     <div style='float:right;background-color:yellow;color:black;width:122px;height:15px;text-align:center'>
        دوشنبه
    </div>
     <div style='float:right;background-color:yellow;color:black;width:122px;height:15px;text-align:center'>
        سه شنبه
    </div>
     <div style='float:right;background-color:yellow;color:black;width:122px;height:15px;text-align:center'>
        چهارشنبه
    </div>
     <div style='float:right;background-color:yellow;color:black;width:122px;height:15px;text-align:center'>
        پنجشنبه
    </div>
     <div style='float:right;background-color:yellow;color:black;width:123px;height:15px;text-align:center'>
        جمعه
    </div>
</div>
<div style="width:860px;height:auto;margin-right:auto;margin-left:auto">
    <%=StrCalender %>
</div>
