<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="JStockGoodRequestControl.ascx.cs" Inherits="WebWarehouseManagement.Forms.JStockGoodRequestControl" %>
<%@ Register Assembly="JJson" Namespace="JJson.Controls" TagPrefix="JJson" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register Src="~/WebControllers/MainControls/Date/JDateControl.ascx" TagPrefix="uc1" TagName="JDateControl" %>

<div>

    <table class="auto-style1">
        <tr>
            <td>نام درخواست دهنده :</td>
            <td>
                <asp:Label ID="lblUser" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
    </table>

    <telerik:radtabstrip runat="server" id="RadTabStrip1"
        selectedindex="0" multipageid="RadMultiPage1" width="100%">
        <Tabs>
            <telerik:RadTab Text="کالاهای درخواست" PageViewID="rpvInformationOfReceipt" Selected="True">
            </telerik:RadTab>
            <telerik:RadTab Text="مشخصات درخواست" PageViewID="rpvGoodsOfReceipt">
            </telerik:RadTab>
        </Tabs>
    </telerik:radtabstrip>
    <telerik:radmultipage runat="server" id="RadMultiPage1" selectedindex="1"
        width="700px">
        <telerik:RadPageView runat="server" ID="rpvInformationOfGoodRequest" Selected="True">
            <table>
                <tr>
                    <td class="Table_RowB">تاریخ درخواست:</td>
                    <td class="Table_RowC">
                        <uc1:JDateControl runat="server" id="dteRegisterDate" />
                    </td>
                </tr>
                <tr>
                    <td class="Table_RowB">کد انبار:</td>
                    <td class="Table_RowC">
                        <JJson:JJsonNumericTextBox ID="txtStockCode" runat="server" Event="textchange"></JJson:JJsonNumericTextBox> 
                        <asp:TextBox runat="server" ID="txtStockName" ReadOnly="true" /></td>
                </tr>
                <tr>
                    <td class="Table_RowB">&nbsp;</td>
                    <td class="Table_RowC">
                        <telerik:RadButton ID="btnBack" runat="server" OnClick="btnBack_Click" Text="برگشت" ValidationGroup="Goods" Width="50px"></telerik:RadButton>
                        <telerik:RadButton ID="btnReferGood" runat="server" OnClick="btnReferGood_Click" Text="ذخیره" Width="50px"></telerik:RadButton>
                    </td>
                </tr>
            </table>
        </telerik:RadPageView>
        <telerik:RadPageView runat="server" ID="rpvGoodsOfRequestDetails">
            <table class="auto-style1">
                <tr>
                    <td>نام کالا :</td>
                    <td>
                        <JJson:JJsonNumericTextBox ID="txtGoodCode" runat="server" Event="textchange"></JJson:JJsonNumericTextBox>
                        <asp:TextBox ID="txtGoodName" runat="server" ReadOnly="true" />
                    </td>
                </tr>
                <tr>
                    <td>تعداد :</td>
                    <td>
                        <JJson:JJsonNumericTextBox ID="txtCount" runat="server" Event="textchange"></JJson:JJsonNumericTextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <telerik:RadButton ID="btnAddGoodRequestDetails" runat="server" OnClick="btnAddGoodRequestDetails_Click" Text="افزودن" ValidationGroup="Goods" Width="50px">
                        </telerik:RadButton>
                    </td>
                    <td>
                        <telerik:RadButton ID="btnReferGoodRequestDetails" runat="server" Text="ارجاع" Width="50px" OnClick="btnReferGoodRequestDetails_Click">
                        </telerik:RadButton>
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
            </table>
            <telerik:RadGrid runat="server" ID="grdGoodsOfRequestDetails" Width="400px" CellSpacing="0" GridLines="None">
                <MasterTableView>
                    <CommandItemSettings ExportToPdfText="Export to PDF" />
                    <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column"></RowIndicatorColumn>
                    <ExpandCollapseColumn Created="True" FilterControlAltText="Filter ExpandColumn column" Visible="True"></ExpandCollapseColumn>
                    <EditFormSettings>
                        <EditColumn FilterControlAltText="Filter EditCommandColumn column"></EditColumn>
                    </EditFormSettings>
                    <PagerStyle PageSizeControlType="RadComboBox" />
                </MasterTableView><PagerStyle PageSizeControlType="RadComboBox" />
                <FilterMenu EnableImageSprites="False"></FilterMenu>
            </telerik:RadGrid></telerik:RadPageView>
    </telerik:radmultipage>
</div>


