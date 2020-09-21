<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="JPaymentsUpdateControl.ascx.cs" Inherits="WebBusManagement.FormsManagement.JPaymentsUpdateControl" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register Src="~/WebControllers/MainControls/Date/JDateControl.ascx" TagPrefix="uc1" TagName="JDateControl" %>
<%--<table style="width: 100%; height: auto; margin-top: 15px">--%>

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
<div class="FormContent" style="margin-bottom: 40px;">
    <div class="BigTitle">پرداختها</div>
    <table style="width: 100%; height: auto">
        <tr class="Table_RowB">
            <td style="width: 150px">تاریخ پرداخت</td>
            <td>
                <uc1:jdatecontrol runat="server" id="txtPaymentDate" />
            </td>
        </tr>
        <tr class="Table_RowC">
            <td>شرح پرداخت</td>
            <td>
                <telerik:radtextbox runat="server" id="txtPaymentDiscription" width="90%"></telerik:radtextbox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidatorTxtName" runat="server" Display="Dynamic"
                    ControlToValidate="txtPaymentDiscription" ValidationGroup="Payment" ErrorMessage="*"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr class="Table_RowB">
            <td>اعمال در لیست سیاه</td>
            <td>
                <telerik:RadComboBox runat="server" ID="cmbUpdateBlackList" Width="150px">
                    <Items>
                        <telerik:RadComboBoxItem Value="1" Text="بلی" Selected="true" />
                        <telerik:RadComboBoxItem Value="0" Text="خیر" />
                    </Items>
                </telerik:RadComboBox>
            </td>
        </tr>
        <tr class="Table_RowC">
            <td>کسر اقساط</td>
            <td>
                <telerik:RadComboBox runat="server" ID="cmbPayInstallments" Width="150px">
                    <Items>
                        <telerik:RadComboBoxItem Value="1" Text="بلی" Selected="true" />
                        <telerik:RadComboBoxItem Value="0" Text="خیر" />
                    </Items>
                </telerik:RadComboBox>
            </td>
        </tr>
        <tr class="Table_RowB">
            <td colspan="2">
                <telerik:radgrid id="RadGridPaymentDetail" runat="server" autogeneratecolumns="true"
                    onprerender="RadGridPaymentDetail_PreRender">
                <MasterTableView>
                    <Columns>
                        <telerik:GridTemplateColumn HeaderText="پرداخت شود ؟" UniqueName="PaymnetStatus">
                            <ItemTemplate>
                                <asp:CheckBox runat="server" ID="chbSelect" Checked="true"/>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                    </Columns>
                </MasterTableView>
            </telerik:radgrid>
            </td>
        </tr>
    </table>
</div>
<div class="HeightSpace10"></div>
<div class="HeightSpace10"></div>
<div class="FormButtons">
    <telerik:radbutton runat="server" id="btnSavePayment" text="ثبت پرداخت ها" autopostback="true"
        width="150px" height="35px" validationgroup="Payment" onclick="btnSavePayment_Click" OnClientClicked="LockButton" />
    <telerik:radbutton runat="server" id="btnGetFile" text="دریافت فایل" autopostback="true"
        width="150px" height="35px" onclick="btnGetFile_Click" enabled="false" />
    <telerik:radbutton runat="server" id="btnClose" text="بازگشت" onclientclicked="CloseDialog" autopostback="false" width="100px" height="35px" />
</div>
<input type="hidden" id="ConfirmHideField" name="ConfirmHideField" value="0" />
<input type="hidden" id="GetFileConfirmHideField" name="GetFileConfirmHideField" value="0" />
<input type="hidden" runat="server" id="txt_PaymentCodeInput" />