<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="JInsertBusOfflineFileUpdateControl.ascx.cs" Inherits="WebBusManagement.FormsMaintenance.JInsertBusOfflineFileUpdateControl" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register Src="~/WebControllers/MainControls/Date/JDateControl.ascx" TagPrefix="uc1" TagName="JDateControl" %>
<%@ Register Src="~/WebControllers/MainControls/Persons/JSearchPersonControl.ascx" TagPrefix="uc1" TagName="JSearchPersonControl" %>

<div class="BigTitle">درج فایل های آفلاین اتوبوس ها</div>
<table style="width: 500px">
    <tr class="Table_RowB">
        <td style="width: 150px">تاریخ:</td>
        <td>
            <uc1:JDateControl runat="server" id="txtDate" />
        </td>
    </tr>
    <tr class="Table_RowC">
        <td style="width: 150px">شخص ثبت کننده:</td>
        <td>
            <uc1:JSearchPersonControl runat="server" id="JSearchPersonControl" />
        </td>
    </tr>
    <tr class="Table_RowB">
        <td style="width: 150px">شماره اتوبوس:</td>
        <td>
            <telerik:RadComboBox runat="server" ID="cmbBus" Width="100%" Filter="Contains"></telerik:RadComboBox>
        </td>
    </tr>
    <tr class="Table_RowC">
        <td style="width: 150px">توضیحات:</td>
        <td>
            <telerik:RadTextBox runat="server" ID="txtDiscription" TextMode="MultiLine" Width="96%"></telerik:RadTextBox>
        </td>
    </tr>
    <tr class="Table_RowB">
        <td style="width: 150px">فایل:</td>
        <td>
            <asp:FileUpload ID="FileUpload" runat="server" />
            <br />
            <asp:RegularExpressionValidator ID="regexValidator" runat="server"
                ControlToValidate="FileUpload"
                ValidationGroup="BusFile"
                ErrorMessage="پسوند فایل شما باید  یا INI.BIN یا .DB باشد"
                ValidationExpression="(.*\.([Ii][Nn][Ii])|.*\.([Bb][Ii][Nn])|.*\.([Dd][Bb])$)"
                Display="Dynamic">
            </asp:RegularExpressionValidator>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1"
                runat="server" ErrorMessage="لطفا فایل مورد نظر ار انتخاب کنید"
                ControlToValidate="FileUpload"
                ValidationGroup="BusFile"
                Display="Dynamic"></asp:RequiredFieldValidator>
        </td>
    </tr>
</table>
<telerik:RadButton runat="server" ID="btnSave" Text="ذخیره" AutoPostBack="true" Width="100px" OnClick="btnSave_Click" Height="35px" ValidationGroup="BusFile" />
<telerik:RadButton runat="server" ID="btnClose" Text="بازگشت" OnClientClicked="CloseDialog" AutoPostBack="false" Width="100px" Height="35px" />
