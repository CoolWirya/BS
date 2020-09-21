<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="JReceiptOfGoodsUpdateControl.ascx.cs" Inherits="WebWarehouseManagement.Forms.JReceiptOfGoodsUpdateControl" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register Src="~/WebControllers/MainControls/Date/JDateControl.ascx" TagPrefix="uc1" TagName="JDateControl" %>
<%@ Register Src="~/WebControllers/MainControls/Persons/JSearchPersonControl.ascx" TagPrefix="uc1" TagName="JSearchPersonControl" %>
<%@ Register Src="~/WebControllers/MainControls/CustomListSelector/JCustomListSelectorControl.ascx" TagPrefix="uc1" TagName="JCustomListSelectorControl" %>
<%--<telerik:RadAjaxManagerProxy runat="server" ID="AjaxManagerProxy_Control">
    <AjaxSettings>
        <telerik:AjaxSetting AjaxControlID="btnAddGood">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="grdGoodsOfReceipt" />
            </UpdatedControls>
        </telerik:AjaxSetting>
       <telerik:AjaxSetting AjaxControlID="RadTabStrip1">
            <UpdatedControls>
          
                <telerik:AjaxUpdatedControl ControlID="RadMultiPage1" />
                <telerik:AjaxUpdatedControl ControlID="RadTabStrip1" />
                <telerik:AjaxUpdatedControl ControlID="pnlInformationOfReceipt" />
                <telerik:AjaxUpdatedControl ControlID="pnlGoodsOfReceipt" />
                <telerik:AjaxUpdatedControl ControlID="pnlReceiptFromBills" />
            </UpdatedControls>
        </telerik:AjaxSetting>
    </AjaxSettings>
</telerik:RadAjaxManagerProxy>--%>
<asp:UpdatePanel ID="updMain" runat="server" ><ContentTemplate>
<asp:HiddenField ID="hfCode" Value="0" runat="server" />
<div class="FormContent">
    <div class="BigTitle">رسید ورود کالا</div>
    <telerik:RadTabStrip runat="server" ID="RadTabStrip1"
        SelectedIndex="0" MultiPageID="RadMultiPage1" Width="100%" OnTabClick="RadTabStrip1_TabClick">
        <Tabs>
            <telerik:RadTab Text="مشخصات رسید" PageViewID="rpvInformationOfReceipt" Value="rpvInformationOfReceipt">
            </telerik:RadTab>
            <telerik:RadTab Text="کالاهای رسید" PageViewID="rpvGoodsOfReceipt" Value="rpvGoodsOfReceipt">
            </telerik:RadTab>
           <%-- <telerik:RadTab Text="رسید اتوماتیک" PageViewID="rpvReceiptFromBills" Value="rpvReceiptFromBills">
            </telerik:RadTab>--%>
        </Tabs>
    </telerik:RadTabStrip>
    <telerik:RadMultiPage runat="server" ID="RadMultiPage1" SelectedIndex="0" RenderSelectedPageOnly="true"
        Width="700px">

        <telerik:RadPageView runat="server" ID="rpvInformationOfReceipt">
            <asp:Panel ID="pnlInformationOfReceipt" runat="server">

                <table>
                    <tr>
                        <td class="Table_RowB">تاریخ ثبت:</td>
                        <td class="Table_RowC">
                            <uc1:JDateControl runat="server" id="dteRegisterDate" />
                        </td>
                    </tr>
                    <tr>
                        <td class="Table_RowB">تاریخ ورود به انبار:</td>
                        <td class="Table_RowC">
                            <uc1:JDateControl runat="server" id="dteReceiptDate" />
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
                            <telerik:RadComboBox runat="server" ID="cmbWarehouse"></telerik:RadComboBox>
                        </td>
                    </tr>
                </table>

            </asp:Panel>
        </telerik:RadPageView>

        <telerik:RadPageView runat="server" ID="rpvGoodsOfReceipt" >
            <asp:Panel ID="pnlGoodsOfReceipt" runat="server">

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
                            موجودی در انبار :<asp:Label runat="server" ID="lblTotal"></asp:Label>
                            <asp:ImageButton runat="server" ID="btnJGoodsUpdateControl" OnClick="btnJGoodsUpdateControl_Click" ImageUrl="~\Images\Controls\menu_add.png" />
                        </td>
                    </tr>
                    <%--    <tr>
                    <td class="Table_RowB">بر اساس</td>
                    <td class="Table_RowC">
                        <asp:RadioButtonList AutoPostBack="true" runat="server" ID="rblBased" OnSelectedIndexChanged="rblBased_SelectedIndexChanged">
                            <asp:ListItem Selected="True" Text="تعداد" Value="1"></asp:ListItem>
                            <asp:ListItem Selected="True" Text="شماره سریال" Value="2"></asp:ListItem>

                        </asp:RadioButtonList>--%>
                    <%--    <asp:RadioButton AutoPostBack="false" Text="تعداد" Checked="true" runat="server" ID="rbCount" GroupName="rblBased" />
                        <asp:RadioButton AutoPostBack="false" Text="شماره سریال" runat="server" ID="rbSerial" GroupName="rblBased" />--%>
                    <%--  </td>
                </tr>--%>
                    <tr>
                        <td class="Table_RowB">تعداد:</td>
                        <td class="Table_RowC">
                            <telerik:RadNumericTextBox runat="server" Type="Number" NumberFormat-DecimalDigits="0" NumberFormat-GroupSeparator="" MinValue="1"
                                MaxValue="2147483647" ID="txtGoodsCount" CssClass="txtGoodsCount" Width="70px" ReadOnly="false">
                            </telerik:RadNumericTextBox>
                            <%--   <JJson:JJsonTextBox ID="txtGoodsCount" runat="server" Event="textchange"></JJson:JJsonTextBox>--%>
                        </td>
                    </tr>
                    <%--<tr>
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

                <telerik:RadButton runat="server" ID="btnAddGood" Text="افزودن"  AutoPostBack="true" OnClick="btnAddGood_Click" Width="50px"></telerik:RadButton>
                <telerik:RadButton runat="server" ID="btnDeleteGood" Text="حذف" OnClick="btnDeleteGood_Click" AutoPostBack="true" Width="50px"></telerik:RadButton>
                <telerik:RadGrid runat="server" ID="grdGoodsOfRec" AutoGenerateColumns="false" 
                            AllowSorting="true"
        GroupingEnabled="true"
        EnableHeaderContextMenu="true"
        Width="99%"
        AllowPaging="true"
        OnNeedDataSource="grdGoodsOfRec_NeedDataSource"
      
        EnableHeaderContextAggregatesMenu="true"
        GridLines="None"
        AllowCustomPaging="true"
        ShowGroupPanel="false"
        GroupPanel-Width="99%"
        ShowDesignTimeSmartTagMessage="true"
        ShowFooter="true"
                    >
                    <MasterTableView DataKeyNames="Code">
                        <Columns>
                            <telerik:GridBoundColumn HeaderText="Code" UniqueName="Code" DataField="Code" Visible="false"></telerik:GridBoundColumn>
                            <telerik:GridTemplateColumn ItemStyle-Width="30px" UniqueName="chbSelect">
                                <ItemTemplate>
                                    <asp:CheckBox ID="chbSelect" runat="server" />
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridBoundColumn HeaderText="شرح" DataField="Description"></telerik:GridBoundColumn>
                            <telerik:GridBoundColumn HeaderText="تعداد" DataField="Number" ItemStyle-Width="70px"></telerik:GridBoundColumn>
                           <%-- <telerik:GridBoundColumn HeaderText="سریـال" DataField="Serial" ItemStyle-Width="70px"></telerik:GridBoundColumn>--%>
                            <telerik:GridBoundColumn HeaderText="تاریخ ثبت" DataField="RegisterDate" ItemStyle-Width="70px"></telerik:GridBoundColumn>
                        </Columns>
                    </MasterTableView>
                </telerik:RadGrid>


            </asp:Panel>
        </telerik:RadPageView>

      <%--  <telerik:RadPageView runat="server" ID="rpvReceiptFromBills">
            <asp:Panel ID="pnlReceiptFromBills" runat="server">

                <telerik:RadGrid runat="server" ID="rgBills" AutoGenerateColumns="false" 
               
        AllowSorting="true"
        GroupingEnabled="true"
        EnableHeaderContextMenu="true"
        Width="99%"
        AllowPaging="true"
        OnNeedDataSource="rgBills_NeedDataSource"
      
        EnableHeaderContextAggregatesMenu="true"
        GridLines="None"
        AllowCustomPaging="true"
        ShowGroupPanel="false"
        GroupPanel-Width="99%"
        ShowDesignTimeSmartTagMessage="true"
        ShowFooter="true"
                    >
                    <MasterTableView DataKeyNames="Code">
                        <Columns>
                            <telerik:GridBoundColumn HeaderText="Code" UniqueName="Code" DataField="Code" Visible="false"></telerik:GridBoundColumn>
                            <telerik:GridTemplateColumn ItemStyle-Width="30px" UniqueName="chbSelect">
                                <ItemTemplate>
                                    <asp:CheckBox ID="chbSelect" runat="server" />
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridBoundColumn HeaderText="نام انبار" DataField="WarehouseName"></telerik:GridBoundColumn>
                            <telerik:GridBoundColumn HeaderText="تاریخ ثبت" DataField="BillDate" ItemStyle-Width="70px"></telerik:GridBoundColumn>--%>
                            <%--  <telerik:GridBoundColumn HeaderText="تعداد" DataField="Number" ItemStyle-Width="70px"></telerik:GridBoundColumn>
                        <telerik:GridBoundColumn HeaderText="سریـال" DataField="Serial" ItemStyle-Width="70px"></telerik:GridBoundColumn>
                        <telerik:GridBoundColumn HeaderText="تاریخ ثبت" DataField="RegisterDate" ItemStyle-Width="70px"></telerik:GridBoundColumn>--%>
                      <%--  </Columns>
                    </MasterTableView>
                </telerik:RadGrid>
                <telerik:RadButton runat="server" ID="btnAutomatic" Text="درج حواله اتوماتیک" ValidationGroup="Goods" OnClick="btnAutomatic_Click" Width="150px"></telerik:RadButton>
            </asp:Panel>
        </telerik:RadPageView>
                           --%>
    </telerik:RadMultiPage>


     <asp:Label ID="lblError" runat="server" ForeColor="Red" ></asp:Label>
</div>
   </ContentTemplate><Triggers ><asp:PostBackTrigger ControlID="JCustomListSelectorControlWarGoods" /> </Triggers></asp:UpdatePanel>

<div class="FormButtons">
    <telerik:RadButton runat="server" ID="btnSave" Text="ذخیره" AutoPostBack="true" Width="100px" Height="35px" OnClick="btnSave_Click" ValidationGroup="Line" />
    <telerik:RadButton runat="server" ID="btnClose" Text="بازگشت" OnClientClicked="CloseDialog" AutoPostBack="false" Width="100px" Height="35px" />
</div>
