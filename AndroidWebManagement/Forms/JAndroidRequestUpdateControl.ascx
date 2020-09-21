<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="JAndroidRequestUpdateControl.ascx.cs" Inherits="AndroidWebManagement.Forms.JAndroidRequestUpdateControl" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>

<div class="BigTitle">درخواست های خرید آپارتمان و زمین</div>
<table style="width: 500px">
    <tr class="Table_RowB">
        <td style="width: 150px">درخواست کننده:</td>
        <td>
            <telerik:RadTextBox runat="server" ID="txtPersonName" Width="100%" Enabled="false"></telerik:RadTextBox></td>
    </tr>
    <tr class="Table_RowC">
        <td style="width: 150px">نوع درخواست:</td>
        <td>
            <telerik:RadTextBox runat="server" ID="txtRequestType" Width="100%" Enabled="false"></telerik:RadTextBox></td>
    </tr>
    <tr class="Table_RowB">
        <td style="width: 150px">تاریخ درخواست:</td>
        <td>
            <telerik:RadTextBox runat="server" ID="txtRequestDate" Width="100%" Enabled="false"></telerik:RadTextBox></td>
    </tr>
    <tr class="Table_RowC">
        <td style="width: 150px">مورد درخواست:</td>
        <td>
            <telerik:RadTextBox runat="server" ID="txtRequestObject" Width="100%" Enabled="false"></telerik:RadTextBox></td>
    </tr>
    <tr class="Table_RowB">
        <td style="width: 150px">وضعیت:</td>
        <td>
            <telerik:RadComboBox runat="server" ID="cmbStatus" Width="100%">
                <Items>
                    <telerik:RadComboBoxItem Value="0" Text="در انتظار پاسخ" Selected="true"/>
                    <telerik:RadComboBoxItem Value="1" Text="پذیرفته شده"/>
                    <telerik:RadComboBoxItem Value="2" Text="رد شده"/>
                </Items>
            </telerik:RadComboBox>
        </td>
    </tr>
</table>
<div class="FormButtons">
    <telerik:RadButton runat="server" ID="btnSave1" Text="ذخیره" AutoPostBack="true" Width="100px" Height="35px" OnClick="btnSave1_Click" />
    <telerik:RadButton runat="server" ID="btnClose1" Text="بازگشت" OnClientClicked="CloseDialog" AutoPostBack="false" Width="100px" Height="35px" />
</div>
