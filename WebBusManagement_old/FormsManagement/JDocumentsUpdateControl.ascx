<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="JDocumentsUpdateControl.ascx.cs" Inherits="WebBusManagement.FormsManagement.JDocumentsUpdateControl" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register Src="~/WebControllers/MainControls/Date/JDateControl.ascx" TagPrefix="uc1" TagName="JDateControl" %>


<style>
    .HeightSpace05 {
        clear: both;
        height: 10px;
    }

    .HeightSpace10 {
        clear: both;
        height: 10px;
    }

    .HeightSpace90 {
        clear: both;
        height: 90px;
    }

    .ZIndexLow {
        position: relative;
        z-index: 10;
    }
</style>

<div class="BigTitle">اسناد</div>
<table style="width: 100%; height: auto; min-height: 500px">
    <tr class="Table_RowB">
        <td style="width: 220px; height: auto; vertical-align: top">
            <div class="HeightSpace10"></div>
            <div style="width: 100%; height: auto; text-align: right">
                تاریخ بستن سند :
            </div>
            <div class="HeightSpace05"></div>
            <div style="width: 100%; height: auto; text-align: right">
                <uc1:JDateControl runat="server" id="txtCloseDocumentDate" />
            </div>
            <div class="HeightSpace10"></div>
            <div style="width: 100%; height: auto; text-align: right">
                تاریخ کارکردهای رسیده : 
            </div>
            <div class="HeightSpace10"></div>
            <div style="width: 100%; height: auto; text-align: center">
                <asp:CheckBox ID="ckhAllDateSelect" Checked="false" OnCheckedChanged="ckhAllDateSelect_CheckedChanged" AutoPostBack="true" Text="همه ی تاریخ ها" runat="server" />
                <asp:CheckBoxList ID="ChklReciveDate" runat="server"></asp:CheckBoxList>
                <telerik:RadTreeView ID="DateTreeView" runat="server" CheckBoxes="True" Width="205px"
                    TriStateCheckBoxes="true" CheckChildNodes="true">
                </telerik:RadTreeView>
            </div>
            <div class="HeightSpace90"></div>
            <div style="width: 100%; height: auto; text-align: center">
                <telerik:RadButton runat="server" ID="btnShowOutput" Text="مشاهده ی خروجی" CssClass="ZIndexLow" AutoPostBack="true" Width="90%" Height="35px" OnClick="btnShowOutput_Click" />
            </div>
            <div class="HeightSpace10"></div>
            <div class="HeightSpace10"></div>
            <div class="HeightSpace10"></div>
            <div class="HeightSpace10"></div>
            <div class="HeightSpace10"></div>
        </td>
        <td style="height: auto; vertical-align: top">
            <div class="HeightSpace10"></div>
            <div style="width: 80%; height: auto; text-align: right; float: right">
                شرح :
                <telerik:RadTextBox runat="server" ID="txtDocumentDiscription" Width="80%"></telerik:RadTextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidatorTxtName" runat="server" Display="Dynamic"
                    ControlToValidate="txtDocumentDiscription" ValidationGroup="Documnet" ErrorMessage="*"></asp:RequiredFieldValidator>
            </div>
            <div style="width: 20%; height: auto; text-align: right; float: right">
                شماره سند :
                <telerik:RadTextBox runat="server" ID="txtDocumentCode" Width="30px"></telerik:RadTextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Display="Dynamic"
                    ControlToValidate="txtDocumentCode" ValidationGroup="Documnet" ErrorMessage="*"></asp:RequiredFieldValidator>
                <asp:CompareValidator ID="CompareValidator1" runat="server" Display="Dynamic" ErrorMessage="لطفا عدد وارد کنید" ValidationGroup="Documnet" ControlToValidate="txtDocumentCode"
                    Type="Double"></asp:CompareValidator>
            </div>
            <div class="HeightSpace10"></div>
            <div style="width: 100%; height: auto; text-align: right; overflow: auto">
                <telerik:RadGrid ID="RadGridTransactionDetail" runat="server" AutoGenerateColumns="true" OnPreRender="RadGridTransactionDetail_PreRender" OnNeedDataSource="RadGridTransactionDetail_NeedDataSource" OnLoad="RadGridTransactionDetail_Load">
                    <MasterTableView>
                        <Columns>
                            <telerik:GridTemplateColumn HeaderText="ارسال به بانک" UniqueName="SendToBank">
                                <ItemTemplate>
                                    <asp:CheckBox runat="server" ID="chbSelect" Checked="true" />
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                        </Columns>
                    </MasterTableView>
                </telerik:RadGrid>
            </div>
            <div class="HeightSpace10"></div>
        </td>
    </tr>
</table>
<div class="HeightSpace10"></div>
<div class="HeightSpace10"></div>
<telerik:RadButton runat="server" ID="btnSaveCloseTransaction" Text="بستن تراکنشهای انتخاب شده" AutoPostBack="true"
    Width="150px" Height="35px" ValidationGroup="Documnet" OnClick="btnSaveCloseTransaction_Click" />
<telerik:RadButton runat="server" ID="btnClose" Text="بازگشت" OnClientClicked="CloseDialog" AutoPostBack="false" Width="100px" Height="35px" />
