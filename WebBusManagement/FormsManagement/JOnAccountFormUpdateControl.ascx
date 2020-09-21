<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="JOnAccountFormUpdateControl.ascx.cs" Inherits="WebBusManagement.FormsManagement.JOnAccountFormUpdateControl" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register Src="~/WebControllers/MainControls/Persons/JSearchPersonControl.ascx" TagPrefix="uc1" TagName="JSearchPersonControl" %>
<%@ Register Src="~/WebControllers/MainControls/Date/JDateControl.ascx" TagPrefix="uc1" TagName="JDateControl" %>

<div class="BigTitle">فرم علی الحساب</div>
<table style="width: 500px">
    <tr class="Table_RowB">
        <td style="width: 150px">نام شخص:</td>
        <td>
           <uc1:JSearchPersonControl runat="server" id="JSearchPersonControl" />
        </td>
    </tr>
    <tr class="Table_RowC">
        <td style="width: 150px">اتوبوس:</td>
        <td>
            <telerik:RadComboBox runat="server" ID="cmbBus" Width="100%" Filter="Contains">
            </telerik:RadComboBox>
        </td>
    </tr>
    <tr class="Table_RowB">
        <td style="width: 150px">نوع عملیات:</td>
        <td>
            <telerik:RadComboBox runat="server" ID="cmbActionType" Width="100%">
                <Items>
                    <telerik:RadComboBoxItem Value="1" Text="پرداخت" Selected="true" />
                    <telerik:RadComboBoxItem Value="2" Text="دریافت" />
                </Items>
            </telerik:RadComboBox>
        </td>
    </tr>
    <tr class="Table_RowC">
        <td style="width: 150px">توضیحات:</td>
        <td>
            <telerik:RadTextBox runat="server" ID="txtDescription" Width="96%" TextMode="MultiLine"></telerik:RadTextBox>
        </td>
    </tr>
    <tr class="Table_RowB">
        <td style="width: 150px">مبلغ به ریال:</td>
        <td>
            <telerik:RadTextBox runat="server" ID="txtPrice" Width="96%"></telerik:RadTextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidatortxtAddress" runat="server" 
                Display="Dynamic" ControlToValidate="txtPrice" ValidationGroup="OneAcc" ErrorMessage="*"></asp:RequiredFieldValidator>
        </td>
    </tr>
</table>
<div class="FormButtons">
    <telerik:RadButton runat="server" ID="btnSave" Text="ذخیره" AutoPostBack="true" Width="100px" Height="35px" OnClick="btnSave_Click" ValidationGroup="OneAcc" />
    <telerik:RadButton runat="server" ID="btnClose" Text="بازگشت" OnClientClicked="CloseDialog" AutoPostBack="false" Width="100px" Height="35px" />
</div>
