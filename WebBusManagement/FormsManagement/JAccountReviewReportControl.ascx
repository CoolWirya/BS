<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="JAccountReviewReportControl.ascx.cs" Inherits="WebBusManagement.FormsManagement.JAccountReviewReportControl" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register Src="~/WebControllers/MainControls/Date/JDateControl.ascx" TagPrefix="uc1" TagName="JDateControl" %>
<%@ Register Assembly="WebControllers" Namespace="WebControllers.MainControls.Grid" TagPrefix="cc1" %>

<div class="BigTitle">گزارش مرور حساب ها</div>
<table style="width: 500px">
    <tr class="Table_RowC">
        <td style="width: 150px">تفضیلی 1:</td>
        <td>
            <telerik:RadComboBox runat="server" ID="cmbTafsili1" Width="100%" Filter="Contains">
            </telerik:RadComboBox>
        </td>
    </tr>
    <%-- <tr class="Table_RowB">
        <td style="width: 150px">تفضیلی 2:</td>
        <td>
            <telerik:RadComboBox runat="server" ID="cmbTafsili2" Width="100%" Filter="Contains">
            </telerik:RadComboBox>
        </td>
    </tr>--%>


   <%-- <tr class="Table_RowB">
        <td style="width: 150px">بر اساس:</td>
        <td>
            <telerik:RadComboBox runat="server" ID="cmbReportType" Width="100%" Filter="Contains">
                <Items>
                    <telerik:RadComboBoxItem Value="0" Text="همه موارد" Selected="true" />
                    <telerik:RadComboBoxItem Value="1" Text="کارکرد" />
                    <telerik:RadComboBoxItem Value="2" Text="پرداختی" />
                </Items>
            </telerik:RadComboBox>
        </td>
    </tr>--%>


    <tr class="Table_RowB">
        <td style="width: 150px">کارکرد:</td>
        <td>
            <table style="width: 350px">
                <tr class="Table_RowC">
                    <td style="width: 100px">از تاریخ:</td>
                    <td>
                        <uc1:JDateControl runat="server" id="txtFromDate" />
                    </td>
                </tr>
                <tr class="Table_RowB">
                    <td style="width: 100px">تا تاریخ:</td>
                    <td>
                        <uc1:JDateControl runat="server" id="txtToDate" />
                    </td>
                </tr>
            </table>
        </td>
    </tr>
    <tr class="Table_RowC">
        <td style="width: 150px">پرداخت:</td>
        <td>
            <table style="width: 350px">
                <tr class="Table_RowC">
                    <td style="width: 100px">از شماره:</td>
                    <td>
                        <telerik:RadTextBox runat="server" id="txtFromCode" InputType="Number" Width="90px"/>
                    </td>
                </tr>
                <tr class="Table_RowB">
                    <td style="width: 100px">تا شماره:</td>
                    <td>
                        <telerik:RadTextBox runat="server" id="txtToCode" InputType="Number" Width="90px"/>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
    <tr class="Table_RowB">
        <td style="width: 150px">نوع گزارش:</td>
        <td>
            <telerik:RadComboBox runat="server" ID="cmbReportType" Width="100%" Filter="Contains">
                <Items>
                    <telerik:RadComboBoxItem Text="جزئی" Value="0" Selected="true" />
                    <telerik:RadComboBoxItem Text="ماهانه" Value="1" />
                </Items>
            </telerik:RadComboBox>
        </td>
    </tr>
    <tr class="Table_RowC">
        <td style="width: 150px">نمایش پیشینه:</td>
        <td>
            <telerik:RadComboBox runat="server" ID="cmbShowHistory" Width="100%" Filter="Contains">
                <Items>
                    <telerik:RadComboBoxItem Text="خیر" Value="0" />
                    <telerik:RadComboBoxItem Text="بله" Value="1" Selected="true" />
                </Items>
            </telerik:RadComboBox>
        </td>
    </tr>
    <tr class="Table_RowB">
        <td style="width: 150px">کارکرد / پرداخت:</td>
        <td>
            <telerik:RadComboBox runat="server" ID="cmbBedBes" Width="100%" Filter="Contains">
                <Items>
                    <telerik:RadComboBoxItem Text="همه" Value="0" Selected="true" />
                    <telerik:RadComboBoxItem Text="کارکرد" Value="1" />
                    <telerik:RadComboBoxItem Text="پرداخت" Value="2" />
                </Items>
            </telerik:RadComboBox>
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
