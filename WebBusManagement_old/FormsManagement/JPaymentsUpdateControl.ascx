<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="JPaymentsUpdateControl.ascx.cs" Inherits="WebBusManagement.FormsManagement.JPaymentsUpdateControl" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register Src="~/WebControllers/MainControls/Date/JDateControl.ascx" TagPrefix="uc1" TagName="JDateControl" %>
<%@ Register Src="~/WebControllers/MainControls/Grid/JGridViewControl.ascx" TagPrefix="uc1" TagName="JGridViewControl" %>

<style>
    .HeightSpace05 {
        clear: both;
        height: 10px;
    }

    .HeightSpace10 {
        clear: both;
        height: 10px;
    }
</style>
<div class="BigTitle">پرداختها</div>
<table style="width: 100%; height: auto">
    <tr class="Table_RowB">
        <td style="width: 100px">تاریخ پرداخت</td>
        <td>
            <uc1:JDateControl runat="server" id="txtPaymentDate" />
        </td>
    </tr>
    <tr class="Table_RowC">
        <td>شرح پرداخت</td>
        <td>
            <telerik:RadTextBox runat="server" ID="txtPaymentDiscription" Width="90%"></telerik:RadTextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidatorTxtName" runat="server" Display="Dynamic"
                ControlToValidate="txtPaymentDiscription" ValidationGroup="Payment" ErrorMessage="*"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr class="Table_RowB">
        <td colspan="2">
            <telerik:RadGrid ID="RadGridPaymentDetail" runat="server" AutoGenerateColumns="true" 
                OnPreRender="RadGridPaymentDetail_PreRender">
                <MasterTableView>
                    <Columns>
                        <telerik:GridTemplateColumn HeaderText="پرداخت شود ؟" UniqueName="PaymnetStatus">
                            <ItemTemplate>
                                <asp:CheckBox runat="server" ID="chbSelect"/>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                    </Columns>
                </MasterTableView>
            </telerik:RadGrid>
        </td>
    </tr>
</table>
<div class="HeightSpace10"></div>
<div class="HeightSpace10"></div>
<telerik:RadButton runat="server" ID="btnSavePayment" Text="ثبت پرداخت ها" AutoPostBack="true"
    Width="150px" Height="35px" ValidationGroup="Payment" OnClick="btnSavePayment_Click" />
<telerik:RadButton runat="server" ID="btnGetFile" Text="دریافت فایل" AutoPostBack="true"
    Width="150px" Height="35px" OnClick="btnGetFile_Click" Enabled="false"/>
<telerik:RadButton runat="server" ID="btnClose" Text="بازگشت" OnClientClicked="CloseDialog" AutoPostBack="false" Width="100px" Height="35px" />
<input type="hidden" id="ConfirmHideField" name="ConfirmHideField" value="0" />
<input type="hidden" id="GetFileConfirmHideField" name="GetFileConfirmHideField" value="0" />
