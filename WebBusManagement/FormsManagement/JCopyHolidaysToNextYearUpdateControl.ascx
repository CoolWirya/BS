<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="JCopyHolidaysToNextYearUpdateControl.ascx.cs" Inherits="WebBusManagement.FormsManagement.JCopyHolidaysToNextYearUpdateControl" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<div class="BigTitle">تعریف روزهای تعطیل</div>
<table style="width: 500px">
     <tr class="Table_RowB">
        <td style="width: 150px">از سال:</td>
        <td>
           <telerik:RadComboBox runat="server" ID="rblFromYear" Width="100%">
                <Items>
                    <telerik:RadComboBoxItem Value="1394" Text="1394" Selected="true"/>
                    <telerik:RadComboBoxItem Value="1395" Text="1395"/>
                    <telerik:RadComboBoxItem Value="1396" Text="1396"/>
                    <telerik:RadComboBoxItem Value="1397" Text="1397"/>
                    <telerik:RadComboBoxItem Value="1398" Text="1398"/>
                    <telerik:RadComboBoxItem Value="1399" Text="1399"/>
                </Items>
            </telerik:RadComboBox>
        </td>
    </tr>
     <tr class="Table_RowC">
        <td style="width: 150px">به سال:</td>
        <td>
           <telerik:RadComboBox runat="server" ID="rblToYear" Width="100%">
                <Items>
                    <telerik:RadComboBoxItem Value="1395" Text="1395" Selected="true"/>
                    <telerik:RadComboBoxItem Value="1396" Text="1396"/>
                    <telerik:RadComboBoxItem Value="1397" Text="1397"/>
                    <telerik:RadComboBoxItem Value="1398" Text="1398"/>
                    <telerik:RadComboBoxItem Value="1399" Text="1399"/>
                </Items>
            </telerik:RadComboBox>
        </td>
    </tr>
     <tr class="Table_RowC">
        <td style="width: 150px">اختلاف روز سال شمسی به قمری:</td>
        <td>
            <telerik:RadNumericTextBox runat="server" ID="ntbShiftDays" Width="100%" NumberFormat-DecimalDigits="0"></telerik:RadNumericTextBox>
        </td>
    </tr>
</table>
<div class="FormButtons">
    <telerik:RadButton runat="server" ID="btnSave" Text="ذخیره" AutoPostBack="true" Width="100px" OnClick="btnSave_Click" Height="35px" />
</div>
