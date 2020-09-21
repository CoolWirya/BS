<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="JBillOfGoodsUpdateControl.ascx.cs" Inherits="WebWarehouseManagement.Forms.JBillOfGoodsUpdateControl" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register Src="~/WebControllers/MainControls/Date/JDateControl.ascx" TagPrefix="uc1" TagName="JDateControl" %>
<%@ Register Src="~/WebControllers/MainControls/Persons/JSearchPersonControl.ascx" TagPrefix="uc1" TagName="JSearchPersonControl" %>
<%@ Register Src="~/WebControllers/MainControls/CustomListSelector/JCustomListSelectorControl.ascx" TagPrefix="uc1" TagName="JCustomListSelectorControl" %>


<%--<telerik:RadAjaxManagerProxy runat="server" ID="AjaxManagerProxy_Control">
    <AjaxSettings>
        <telerik:AjaxSetting AjaxControlID="RadTabStrip1">
            <UpdatedControls>
            </UpdatedControls>
        </telerik:AjaxSetting>
        <telerik:AjaxSetting AjaxControlID="RadMultiPage1"></telerik:AjaxSetting>

        <telerik:AjaxSetting AjaxControlID="cmbWarehouse">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="cmbAimWearCode" />
            </UpdatedControls>
        </telerik:AjaxSetting>

    </AjaxSettings>
</telerik:RadAjaxManagerProxy>--%>
<asp:UpdatePanel ID="updMain" runat="server" ><ContentTemplate>
<asp:HiddenField ID="hfCode" runat="server" />

<div class="FormContent">
    <div class="BigTitle">برگه خروج کالا</div>
    <telerik:RadTabStrip runat="server" ID="RadTabStrip1"
        SelectedIndex="0" MultiPageID="RadMultiPage1" Width="100%">
        <Tabs>
            <telerik:RadTab Text="مشخصات برگه" PageViewID="rpvInformationOfReceipt">
            </telerik:RadTab>
            <telerik:RadTab Text="کالاها" PageViewID="rpvGoodsOfReceipt">
            </telerik:RadTab>
        </Tabs>
    </telerik:RadTabStrip>
    <telerik:RadMultiPage runat="server" ID="RadMultiPage1" SelectedIndex="0"
        Width="700px">
        <telerik:RadPageView runat="server" ID="rpvInformationOfReceipt">
            <table>
                <tr>
                    <td class="Table_RowB">تاریخ ثبت:</td>
                    <td class="Table_RowC">
                        <uc1:JDateControl runat="server" id="dteRegisterDate" />
                    </td>
                </tr>
                <tr>
                    <td class="Table_RowB">تاریخ خروج از انبار:</td>
                    <td class="Table_RowC">
                        <uc1:JDateControl runat="server" id="dteBillDate" />
                    </td>
                </tr>
                <tr>
                    <td class="Table_RowB">تحویل دهنده:</td>
                    <td class="Table_RowC">
                        <uc1:JSearchPersonControl runat="server" id="personDeliver" />
                    </td>
                </tr>
                <tr>
                    <td class="Table_RowB">تحویل گیرنده:</td>
                    <td class="Table_RowC">
                        <uc1:JSearchPersonControl runat="server" id="personTransferee" />
                    </td>
                </tr>
                <tr>
                    <td class="Table_RowB">انبار:</td>
                    <td class="Table_RowC">
                        <asp:DropDownList runat="server" AutoPostBack="true" ID="cmbWarehouse" DataValueField="Code" DataTextField="Name" OnSelectedIndexChanged="cmbWarehouse_SelectedIndexChanged" CssClass="cmbWarehouse">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="Table_RowB">انبار مقصد:</td>
                    <td class="Table_RowC">
                        <asp:DropDownList runat="server" ID="cmbAimWearCode" DataValueField="Code" DataTextField="Name" CssClass="cmbWarehouse">
                        </asp:DropDownList>
                    </td>
                </tr>
            </table>
        </telerik:RadPageView>
        <telerik:RadPageView runat="server" ID="rpvGoodsOfReceipt">
            <table>
                <tr>
                    <td class="Table_RowB">نوع کالا:</td>
                    <td class="Table_RowC">
                        <telerik:RadComboBox runat="server" ID="CmbWarTypesOfGoods" EnableViewState="true" OnSelectedIndexChanged="CmbWarTypesOfGoods_SelectedIndexChanged" AutoPostBack="true"></telerik:RadComboBox>

                    </td>
                </tr>
                <tr>
                    <td class="Table_RowB">کالا :</td>
                    <td class="Table_RowC">
                        
                        <uc1:JCustomListSelectorControl runat="server" id="JCustomListSelectorControlWarGoods" />
                      <%--  موجودی در انبار :--%>
                        <asp:Label runat="server" ID="lblTotal"></asp:Label>
                   <%--     <asp:ImageButton runat="server" ID="btnJGoodsUpdateControl" OnClick="btnJGoodsUpdateControl_Click" ImageUrl="~\Images\Controls\menu_add.png" />--%>
                    </td>
                </tr>

                <%-- <tr>
                    <td class="Table_RowB">بر اساس</td>
                    <td class="Table_RowC">
                        <asp:RadioButtonList AutoPostBack="true" runat="server" ID="rblBased" OnSelectedIndexChanged="rblBased_SelectedIndexChanged">
                            <asp:ListItem Selected="True" Text="تعداد" Value="1"></asp:ListItem>
                            <asp:ListItem Selected="True" Text="شماره سریال" Value="2"></asp:ListItem>

                        </asp:RadioButtonList>
                            <asp:RadioButton AutoPostBack="false" Text="تعداد" Checked="true" runat="server" ID="rbCount" GroupName="rblBased" />
                        <asp:RadioButton AutoPostBack="false" Text="شماره سریال" runat="server" ID="rbSerial" GroupName="rblBased" />
                    </td>
                </tr>--%>
                <tr>
                    <td class="Table_RowB">تعداد:</td>
                    <td class="Table_RowC">
                        <telerik:RadNumericTextBox runat="server" Type="Number" NumberFormat-DecimalDigits="0" NumberFormat-GroupSeparator="" MinValue="1" 
                            MaxValue="2147483647"  ID="txtGoodsCount" CssClass="txtGoodsCount" Width="70px" ReadOnly="false">
                        </telerik:RadNumericTextBox>
                        <%--   <JJson:JJsonTextBox ID="txtGoodsCount" runat="server" Event="textchange"></JJson:JJsonTextBox>--%>
                    </td>
                </tr>
               <%-- <tr>
                    <td class="Table_RowB">سریال:</td>
                    <td class="Table_RowC">

                        <telerik:RadNumericTextBox runat="server" Type="Number" NumberFormat-DecimalDigits="0" NumberFormat-GroupSeparator="" MinValue="0"
                            MaxValue="2147483647" AutoPostBack="true" ID="txtFromSerial" CssClass="txtFromSerial" Width="70px" ReadOnly="false">
                        </telerik:RadNumericTextBox>
                    </td>
                </tr>--%>
                <%-- <tr>
                    <td class="Table_RowB">تا سریال:</td>
                    <td class="Table_RowC">
                        <telerik:RadTextBox runat="server" ID="txtToSerial" AutoPostBack="false" CssClass="txtToSerial"></telerik:RadTextBox>
                    </td>
                </tr>--%>
            </table>
            <telerik:RadButton runat="server" ID="btnAddGood" AutoPostBack="true"  Text="افزودن" OnClick="btnAddGood_Click" Width="50px"></telerik:RadButton>
            <telerik:RadButton runat="server" ID="btnDeleteGood" AutoPostBack="true"  Text="حذف" OnClick="btnDeleteGood_Click" Width="50px"></telerik:RadButton>
            <telerik:RadGrid runat="server"
                ID="grdGoodsOfBill" AutoGenerateColumns="false"
                Width="400px"
                AllowSorting="true"
                GroupingEnabled="true"
                EnableHeaderContextMenu="true"
                AllowPaging="true"
                EnableHeaderContextAggregatesMenu="true"
                GridLines="None"
                AllowCustomPaging="true"
                ShowGroupPanel="false"
                GroupPanel-Width="99%"
                ShowDesignTimeSmartTagMessage="true"
                ShowFooter="true">
                <MasterTableView DataKeyNames="BillOfGoodsCode" SkinID="Default" ShowHeader="true" ShowHeadersWhenNoRecords="true">
                    <Columns>
                        <telerik:GridBoundColumn HeaderText="Code" UniqueName="Code" DataField="Code" Visible="false"></telerik:GridBoundColumn>
                        <telerik:GridTemplateColumn ItemStyle-Width="30px" UniqueName="chbSelect">
                            <ItemTemplate>
                                <asp:CheckBox ID="chbSelect" runat="server" />
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                         <telerik:GridBoundColumn HeaderText="GoodsCode" DataField="GoodsCode" Display="false"></telerik:GridBoundColumn>
                         <telerik:GridBoundColumn HeaderText="Code" DataField="Code" Display="false"></telerik:GridBoundColumn>
                        <telerik:GridBoundColumn HeaderText="شرح" DataField="Description"></telerik:GridBoundColumn>
                        <telerik:GridBoundColumn HeaderText="تعداد" DataField="Number" ItemStyle-Width="70px"></telerik:GridBoundColumn>
                        <%--<telerik:GridBoundColumn HeaderText="سریـال" DataField="Serial" ItemStyle-Width="70px"></telerik:GridBoundColumn>--%>
                        <telerik:GridBoundColumn HeaderText="تاریخ ثبت" DataField="RegisterDate" ItemStyle-Width="70px"></telerik:GridBoundColumn>
                    </Columns>

                </MasterTableView>
            </telerik:RadGrid>
        </telerik:RadPageView>
    </telerik:RadMultiPage>

     <asp:Label ID="lblError" runat="server" ForeColor="Red" ></asp:Label>
</div>
   
    </ContentTemplate><Triggers ><asp:PostBackTrigger ControlID="JCustomListSelectorControlWarGoods" /> </Triggers></asp:UpdatePanel>

<div class="FormButtons">
    <telerik:RadButton runat="server" ID="btnSave" Text="ذخیره" AutoPostBack="true" Width="100px" Height="35px" OnClick="btnSave_Click" ValidationGroup="Line" />
    <telerik:RadButton runat="server" ID="btnClose" Text="بازگشت" OnClientClicked="CloseDialog" AutoPostBack="false" Width="100px" Height="35px" />
    <telerik:RadButton runat="server" ID="btnSendStatus" Text="ارسال کالا" OnClick="btnSendStatus_Click" AutoPostBack="true" Width="100px" Height="35px" Enabled="false" />
    
</div>
