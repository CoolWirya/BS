<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="JBusTransactionReportControl.ascx.cs" Inherits="WebBusManagement.FormsReports.JBusTransactionReportControl" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register Src="~/WebControllers/MainControls/Date/JDateControl.ascx" TagPrefix="uc1" TagName="JDateControl" %>
<%@ Register Src="~/WebControllers/MainControls/Persons/JSearchPersonControl.ascx" TagPrefix="uc1" TagName="JSearchPersonControl" %>
<%@ Register Assembly="WebControllers" Namespace="WebControllers.MainControls.Grid" TagPrefix="cc1" %>


<telerik:RadAjaxManagerProxy runat="server" ID="AjaxManagerProxy_Control">
    <AjaxSettings>
        <telerik:AjaxSetting AjaxControlID="cmbZone">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="cmbLine" />
                <telerik:AjaxUpdatedControl ControlID="cmbBus" />
            </UpdatedControls>
        </telerik:AjaxSetting>
    </AjaxSettings>
</telerik:RadAjaxManagerProxy>
<telerik:RadAjaxManagerProxy runat="server" ID="AjaxManagerProxy_Control1">
    <AjaxSettings>
        <telerik:AjaxSetting AjaxControlID="cmbLine">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="cmbZone" />
                <telerik:AjaxUpdatedControl ControlID="cmbBus" />
            </UpdatedControls>
        </telerik:AjaxSetting>
    </AjaxSettings>
</telerik:RadAjaxManagerProxy>
<telerik:RadAjaxManagerProxy runat="server" ID="AjaxManagerProxy_Control2">
    <AjaxSettings>
        <telerik:AjaxSetting AjaxControlID="cmbBus">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="cmbZone" />
                <telerik:AjaxUpdatedControl ControlID="cmbLine" />
            </UpdatedControls>
        </telerik:AjaxSetting>
    </AjaxSettings>
</telerik:RadAjaxManagerProxy>


<div class="BigTitle">گزارش تراکنش های اتوبوس</div>
<table style="width: 500px">
    <tr class="Table_RowB">
        <td style="width: 150px">ناوگان:</td>
        <td>
            <telerik:RadComboBox runat="server" ID="cmbFleets" Width="100%" Filter="Contains"></telerik:RadComboBox>
        </td>
    </tr>
    <tr class="Table_RowB">
        <td style="width: 150px">منطقه:</td>
        <td>
            <telerik:RadComboBox runat="server" ID="cmbZone" Width="100%" Filter="Contains" AutoPostBack="true"
                OnSelectedIndexChanged="cmbZone_SelectedIndexChanged">
            </telerik:RadComboBox>
        </td>
    </tr>
    <tr class="Table_RowC">
        <td style="width: 150px">خط:</td>
        <td>
            <telerik:RadComboBox runat="server" ID="cmbLine" Width="100%" Filter="Contains" AutoPostBack="true"
                OnSelectedIndexChanged="cmbLine_SelectedIndexChanged">
            </telerik:RadComboBox>
        </td>
    </tr>
    <tr class="Table_RowB">
        <td style="width: 150px">اتوبوس:</td>
        <td>
            <telerik:RadComboBox runat="server" ID="cmbBus" Width="100%" Filter="Contains" AutoPostBack="true"
                OnSelectedIndexChanged="cmbBus_SelectedIndexChanged">
            </telerik:RadComboBox>
        </td>
    </tr>
    <tr class="Table_RowC">
        <td style="width: 150px">راننده:</td>
        <td>
            <uc1:JSearchPersonControl runat="server" id="JSearchPersonControl1" />
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
        <td style="direction: ltr">
            <asp:RangeValidator ID="RangeValidator3" runat="server" ErrorMessage="00 تا 23" ControlToValidate="txtStartTimeHour" MinimumValue="00"
                MaximumValue="23" ValidationGroup="Report" Display="Dynamic"></asp:RangeValidator>
            <telerik:RadTextBox runat="server" ID="txtStartTimeHour" Width="40px" MaxLength="2" EmptyMessage="ساعت"></telerik:RadTextBox>
            :
                    <telerik:RadTextBox runat="server" ID="txtStartTimeMinute" Width="40px" MaxLength="2" EmptyMessage="دقیقه"></telerik:RadTextBox>
            <asp:RangeValidator ID="RangeValidator4" runat="server" ErrorMessage="00 تا 59" ControlToValidate="txtStartTimeMinute" MinimumValue="00"
                MaximumValue="59" ValidationGroup="Report" Display="Dynamic"></asp:RangeValidator>
            :
                    <telerik:RadTextBox runat="server" ID="txtStartTimeSecond" Width="40px" MaxLength="2" EmptyMessage="ثانیه"></telerik:RadTextBox>
            <asp:RangeValidator ID="RangeValidator5" runat="server" ErrorMessage="00 تا 59" ControlToValidate="txtStartTimeSecond" MinimumValue="00"
                MaximumValue="59" ValidationGroup="Report" Display="Dynamic"></asp:RangeValidator>
        </td>
    </tr>
    <tr class="Table_RowC">
        <td style="width: 150px">تا ساعت:</td>
        <td style="direction: ltr">
            <asp:RangeValidator ID="RangeValidator1" runat="server" ErrorMessage="00 تا 23" ControlToValidate="txtFinishTimeHour" MinimumValue="00"
                MaximumValue="23" ValidationGroup="Report" Display="Dynamic"></asp:RangeValidator>
            <telerik:RadTextBox runat="server" ID="txtFinishTimeHour" Width="40px" MaxLength="2" EmptyMessage="ساعت"></telerik:RadTextBox>
            :
                    <telerik:RadTextBox runat="server" ID="txtFinishTimeMinute" Width="40px" MaxLength="2" EmptyMessage="دقیقه"></telerik:RadTextBox>
            <asp:RangeValidator ID="RangeValidator2" runat="server" ErrorMessage="00 تا 59" ControlToValidate="txtFinishTimeMinute" MinimumValue="00"
                MaximumValue="59" ValidationGroup="Report" Display="Dynamic"></asp:RangeValidator>
            :
                    <telerik:RadTextBox runat="server" ID="txtFinishTimeSecond" Width="40px" MaxLength="2" EmptyMessage="ثانیه"></telerik:RadTextBox>
            <asp:RangeValidator ID="RangeValidator6" runat="server" ErrorMessage="00 تا 59" ControlToValidate="txtFinishTimeSecond" MinimumValue="00"
                MaximumValue="59" ValidationGroup="Report" Display="Dynamic"></asp:RangeValidator>
        </td>
    </tr>
    <tr class="Table_RowB">
        <td style="width: 150px">نوع کارت:</td>
        <td>
            <telerik:RadComboBox runat="server" ID="cmbCardType" Width="100%" Filter="Contains">
              <%--  <Items>
                    <telerik:RadComboBoxItem Value="-1" Text="همه" Selected="true" />
                    <telerik:RadComboBoxItem Value="0" Text="0" />
                    <telerik:RadComboBoxItem Value="1" Text="1" />
                    <telerik:RadComboBoxItem Value="2" Text="2" />
                    <telerik:RadComboBoxItem Value="3" Text="3" />
                    <telerik:RadComboBoxItem Value="4" Text="4" />
                    <telerik:RadComboBoxItem Value="5" Text="5" />
                    <telerik:RadComboBoxItem Value="6" Text="6" />
                    <telerik:RadComboBoxItem Value="7" Text="7" />
                    <telerik:RadComboBoxItem Value="8" Text="8" />
                    <telerik:RadComboBoxItem Value="9" Text="9" />
                </Items>--%>
            </telerik:RadComboBox>
        </td>
    </tr>
    <tr class="Table_RowC">
        <td style="width: 150px">نوع روز:</td>
        <td>
            <telerik:RadComboBox runat="server" ID="cmbDayType" Width="100%" Filter="Contains">
                <Items>
                    <telerik:RadComboBoxItem Value="-1" Text="همه ی روزها" Selected="true" />
                    <telerik:RadComboBoxItem Value="0" Text="روزهای عادی" />
                    <telerik:RadComboBoxItem Value="1" Text="روزهای تعطیل" />
                </Items>
            </telerik:RadComboBox>
        </td>
    </tr>
    <tr class="Table_RowC">
        <td style="width: 150px">شماره کارت مسافر:</td>
        <td>
            <telerik:RadTextBox runat="server" ID="txtPassCard" Width="100%" InputType="Number">
            </telerik:RadTextBox>
        </td>
    </tr>
    
      <%--<tr class="Table_RowC">
                <td style="width: 150px">نوع کارت :</td>
                <td>
                    <asp:CheckBox ID="ChkCityPay" runat="server" Text=" City Pay_ بانک شهر" />
                    <asp:CheckBox ID="ChkCityWay" runat="server" Text="City Way_ بانک شهر  " />
                     <asp:CheckBox ID="ChkTabriz" runat="server" Text="کارت تبریز" />
                </td>
      </tr>--%>
      
</table>
<telerik:RadButton runat="server" ID="btnSave" Text="مشاهده گزارش" AutoPostBack="true" Width="100px" Height="35px" ValidationGroup="Report" OnClick="btnSave_Click" />
<telerik:RadButton runat="server" ID="btnClose" Text="بازگشت" OnClientClicked="CloseDialog" AutoPostBack="false" Width="100px" Height="35px" />
<table style="width: 100%; height: auto; margin-top: 15px">
    <tr>
        <td style="width: 100%; height: auto; overflow: auto"><cc1:JGridView runat="server" id="RadGridReport"></cc1:JGridView>
            
        </td>
    </tr>
</table>
