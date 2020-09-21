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

<div class="FormContent">
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
                    <uc1:jdatecontrol runat="server" id="txtCloseDocumentDate" />
                </div>
                <div class="HeightSpace10"></div>
                <div style="width: 100%; height: auto; text-align: right">
                    تاریخ کارکردهای رسیده : 
                </div>
                <div class="HeightSpace10"></div>
                <div style="width: 100%; height: auto; text-align: center">
                    <asp:CheckBox ID="ckhAllDateSelect" Checked="false" OnCheckedChanged="ckhAllDateSelect_CheckedChanged" AutoPostBack="true" Text="همه ی تاریخ ها" runat="server" />
                    <asp:CheckBoxList ID="ChklReciveDate" runat="server"></asp:CheckBoxList>
                    <telerik:radtreeview id="DateTreeView" runat="server" checkboxes="True" width="205px"
                        tristatecheckboxes="true" checkchildnodes="true">
                </telerik:radtreeview>
                </div>
                <div class="HeightSpace90"></div>
                <div style="width: 100%; height: auto; text-align: center">
                    <telerik:radbutton runat="server" id="btnShowOutput" text="مشاهده ی خروجی" cssclass="ZIndexLow" autopostback="true" width="90%" height="35px" onclick="btnShowOutput_Click" />
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
                <telerik:radtextbox runat="server" id="txtDocumentDiscription" width="80%"></telerik:radtextbox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorTxtName" runat="server" Display="Dynamic"
                        ControlToValidate="txtDocumentDiscription" ValidationGroup="Documnet" ErrorMessage="*"></asp:RequiredFieldValidator>
                </div>
                <div style="width: 20%; height: auto; text-align: right; float: right">
                    شماره سند :
                <telerik:radtextbox runat="server" id="txtDocumentCode" width="30px"></telerik:radtextbox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Display="Dynamic"
                        ControlToValidate="txtDocumentCode" ValidationGroup="Documnet" ErrorMessage="*"></asp:RequiredFieldValidator>
                    <asp:CompareValidator ID="CompareValidator1" runat="server" Display="Dynamic" ErrorMessage="لطفا عدد وارد کنید" ValidationGroup="Documnet" ControlToValidate="txtDocumentCode"
                        Type="Double"></asp:CompareValidator>
                </div>
                <div class="HeightSpace10"></div>
                <div style="width: 100%; height: auto; text-align: right; overflow: auto">
                    <telerik:radgrid id="RadGridTransactionDetail" runat="server" autogeneratecolumns="true" onprerender="RadGridTransactionDetail_PreRender" onneeddatasource="RadGridTransactionDetail_NeedDataSource" onload="RadGridTransactionDetail_Load">
                    <MasterTableView>
                        <Columns>
                            <telerik:GridTemplateColumn HeaderText="ارسال به بانک" UniqueName="SendToBank">
                                <ItemTemplate>
                                    <asp:CheckBox runat="server" ID="chbSelect" Checked="true" />
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                        </Columns>
                    </MasterTableView>
                </telerik:radgrid>
                </div>
                <div class="HeightSpace10"></div>
            </td>
        </tr>
    </table>
</div>
<div class="HeightSpace10"></div>
<div class="HeightSpace10"></div>
<div class="FormButtons">
    <telerik:radbutton runat="server" id="btnSaveCloseTransaction" text="بستن تراکنشهای انتخاب شده" autopostback="true"
        width="150px" height="35px" validationgroup="Documnet" onclick="btnSaveCloseTransaction_Click" />
    <telerik:radbutton runat="server" id="btnClose" text="بازگشت" onclientclicked="CloseDialog" autopostback="false" width="100px" height="35px" />
</div>
