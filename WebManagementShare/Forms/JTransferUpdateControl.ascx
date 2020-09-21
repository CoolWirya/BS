<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="JTransferUpdateControl.ascx.cs" Inherits="WebManagementShare.Forms.JTransferUpdateControl" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register Src="~/WebControllers/MainControls/Date/JDateControl.ascx" TagPrefix="uc1" TagName="JDateControl" %>
<%@ Register Src="~/WebControllers/MainControls/Persons/JShareSearchPersonControl.ascx" TagPrefix="uc1" TagName="JSearchPersonControl" %>
<%@ Register Src="~/WebControllers/ArchiveDocument/JArchiveControl.ascx" TagPrefix="uc1" TagName="JArchiveControl" %>
<%@ Register Src="~/WebControllers/Property/JPropertyViewControl.ascx" TagPrefix="uc1" TagName="JPropertyViewControl" %>
<script type="text/javascript">
    $(document).ready(function () {
        GetRadWindow().maximize();
        $('#GridContainer').width(0.95*$('#<%=rpvTransactors.ClientID%>').width());

    });
</script>
<div class="BigTitle">انتقال سهام</div>
<div class="FormContent" style="top: 40px;">
    <telerik:RadTabStrip runat="server" ID="rtabTransfer" OnTabClick="rtabTransfer_TabClick"
        SelectedIndex="0" MultiPageID="rpageTransfer" Width="100%">
        <Tabs>
            <telerik:RadTab Text="طرفین انتقال" Value="rpvTransactors">
            </telerik:RadTab>
            <telerik:RadTab Text="ویژگی ها">
            </telerik:RadTab>
            <telerik:RadTab Text="آرشیو" Value="rpvArchive">
            </telerik:RadTab>
        </Tabs>
    </telerik:RadTabStrip>
    <telerik:RadMultiPage runat="server" ID="rpageTransfer" SelectedIndex="0" Width="95%" on>
        <telerik:RadPageView runat="server" ID="rpvTransactors">
            <asp:Panel runat="server" GroupingText="برگه های انتخاب شده">  
                <div id="GridContainer" style="overflow-x:scroll;">   
            <telerik:RadGrid runat="server" ID="RadGridReport1" OnPreRender="RadGridReport1_PreRender" AllowPaging="true" PageSize="15" AllowMultiRowSelection="false">
            </telerik:RadGrid>
                </div>
            </asp:Panel>
            <asp:Panel runat="server" GroupingText="سهامدار فعلی" style="float:right; width:50%">
                <uc1:JSearchPersonControl runat="server" id="personSeller" isReadOnly="true" /> 
            </asp:Panel>
            <asp:Panel runat="server" GroupingText="سهامدار جدید" style="float:right; width:50%; margin-bottom: 4px;">
                <uc1:JSearchPersonControl runat="server" id="personBuyer"/> 
            </asp:Panel>
            <div style="border: 2px groove threedface;margin:5px 2px 45px 2px; clear:both">
                <table style="width:80%">
                    <tr class="Table_RowC">
                        <td>
                            <label>تعداد سهم فروش:</label>
                        </td>
                        <td>
                            <telerik:RadTextBox ID="txtSellShare" runat="server"></telerik:RadTextBox>
                        </td>
                    </tr>
                    <tr class="Table_RowB">
                        <td style="width:20%">
                            <label>تاریخ انتقال:</label>
                        </td>
                        <td style="width:20%">
                            <uc1:JDateControl runat="server" id="txtDate" />
                        </td>
                        <td style="width: 10%">ساعت:</td>
                        <td style="direction: ltr; width:50%">
                            <asp:RangeValidator ID="RangeValidator1" runat="server" ErrorMessage="00 تا 23" ControlToValidate="txtTimeHour" MinimumValue="00"
                                MaximumValue="23" ValidationGroup="Report" Display="Dynamic"></asp:RangeValidator>
                            <telerik:RadTextBox runat="server" ID="txtTimeHour" Width="40px" MaxLength="2" EmptyMessage="ساعت"></telerik:RadTextBox>
                            :
                            <telerik:RadTextBox runat="server" ID="txtTimeMinute" Width="40px" MaxLength="2" EmptyMessage="دقیقه"></telerik:RadTextBox>
                            <asp:RangeValidator ID="RangeValidator2" runat="server" ErrorMessage="00 تا 59" ControlToValidate="txtTimeMinute" MinimumValue="00"
                                MaximumValue="59" ValidationGroup="Report" Display="Dynamic"></asp:RangeValidator>
                        </td>
                    </tr>
                </table> 
                <table style="width:80%">
                    <tr class="Table_RowC">
                        <td style="width:20%">
                            <label>شماره دفتر:</label>
                       </td>
                        <td style="width:30%">
                            <telerik:RadTextBox ID="txtShNote" runat="server"></telerik:RadTextBox>
                        </td>
                        <td style="width:20%">
                            <label>شماره ردیف:</label>
                       </td>
                        <td style="width:30%">
                            <telerik:RadNumericTextBox ID="txtShIndex" runat="server" NumberFormat-GroupSeparator="" NumberFormat-AllowRounding="false" NumberFormat-DecimalDigits="0"></telerik:RadNumericTextBox>
                        </td>
                    </tr>
                    <tr class="Table_RowB">
                        <td>
                            <label>مالیات:</label>
                       </td>
                        <td>
                            <telerik:RadTextBox ID="txtTax" runat="server" Text="0"></telerik:RadTextBox>
                        </td>
                        <td>
                            <label>قیمت کل:</label>
                       </td>
                        <td>
                            <telerik:RadNumericTextBox ID="txtPrice" runat="server" NumberFormat-GroupSeparator="" NumberFormat-AllowRounding="false" NumberFormat-DecimalDigits="0"></telerik:RadNumericTextBox>
                        </td>
                    </tr>
                    <tr class="Table_RowC">
                        <td>
                            <label>انتقال به صورت مصالحه:</label>
                       </td>
                        <td>
                            <telerik:RadComboBox ID="cmbMosalehe" runat="server">
                                <Items>
                                    <telerik:RadComboBoxItem Text="بله" Value="true"/>
                                    <telerik:RadComboBoxItem Text="خیر" Value="false" Selected="true"/>
                                </Items>
                            </telerik:RadComboBox>
                        </td>
                        <td>
                            <label>انتقال وکالت:</label>
                       </td>
                        <td>
                            <telerik:RadComboBox ID="cmbAgent" runat="server">
                                <Items>
                                    <telerik:RadComboBoxItem Text="بله" Value="true"/>
                                    <telerik:RadComboBoxItem Text="خیر" Value="false" Selected="true"/>
                                </Items>
                            </telerik:RadComboBox>
                        </td>
                    </tr>
                </table>
            </div>
        </telerik:RadPageView>
        <telerik:RadPageView runat="server" ID="rpvArchive">
            <uc1:JArchiveControl runat="server" id="jArchiveControl" />
        </telerik:RadPageView>
        <telerik:RadPageView runat="server" ID="RadPageView3">
            <uc1:JPropertyViewControl runat="server" id="jPropertyViewControl" />
        </telerik:RadPageView>
    </telerik:RadMultiPage>
    <%--<div id="Div_LineMap" style="float: right; width: 700px; height: 1px; text-align: right; visibility: hidden">
    <uc1:openlayersmap runat="server" id="OpenLayersMapLinePath" />
</div>--%>
</div>
<div style="clear: both; height: 10px"></div>
<div class="FormButtons">
    <telerik:RadButton runat="server" ID="btnSave" Text="ثبت انتقال" AutoPostBack="true" Width="100px" Height="35px" OnClick="btnSave_Click" ValidationGroup="Line" />
    <telerik:RadButton runat="server" ID="btnClose" Text="بازگشت" OnClientClicked="CloseDialog" AutoPostBack="false" Width="100px" Height="35px" />
</div>