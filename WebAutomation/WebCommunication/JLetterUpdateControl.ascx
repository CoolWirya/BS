<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="JLetterUpdateControl.ascx.cs" Inherits="WebAutomation.WebCommunication.JLetterUpdateControl" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register Src="~/WebControllers/MainControls/Date/JDateControl.ascx" TagPrefix="uc1" TagName="JDateControl" %>
<%@ Register Src="~/WebControllers/MainControls/Persons/JSearchPersonControl.ascx" TagPrefix="uc1" TagName="JSearchPersonControl" %>
<%@ Register Src="~/WebControllers/ArchiveDocument/JArchiveControl.ascx" TagPrefix="uc1" TagName="JArchiveControl" %>
<%@ Register Src="~/WebAutomation/Refer/JReferViewControl.ascx" TagPrefix="uc1" TagName="JReferViewControl" %>



<style>
    .RadTextBox {
        width: 300px;
    }

    .RadComboBox {
        width: 300px;
    }
</style>
<div class="FormContent">
    <div class="BigTitle">نامه های داخلی</div>
    <telerik:RadTabStrip runat="server" ID="rtabLetter" SelectedIndex="0"  OnTabClick="rtabLetter_TabClick" MultiPageID="rpageLetter" Width="500px">
        <Tabs>
            <telerik:RadTab Text="اطلاعات نامه" Value="rpvLetterInfo" PageViewID="rpvLetterInfo">
            </telerik:RadTab>
            <telerik:RadTab Text="ضمائم" PageViewID="rpvArchive">
            </telerik:RadTab>
            <telerik:RadTab Text="ارجاعات" PageViewID="rpvRefer" Value="Refer">
            </telerik:RadTab>

        </Tabs>
    </telerik:RadTabStrip>
    <telerik:RadMultiPage runat="server" ID="rpageLetter" SelectedIndex="0" Width="700px">
        <telerik:RadPageView runat="server" ID="rpvLetterInfo">
            <table style="width: 700px">
                <tr class="Table_RowB">
                    <td style="width: 150px">شماره نامه:</td>
                    <td>
                        <telerik:RadTextBox Width="300px" runat="server" Enabled="false" ID="txtLetterNo" ReadOnly="true"></telerik:RadTextBox>
                    </td>
                </tr>
                <tr class="Table_RowC">
                    <td style="width: 150px">پاسخ / پیرو:</td>
                    <td>
                        <input type="hidden" runat="server" id="LetterState" name="LetterState" value="0" />
                        <input type="hidden" runat="server" id="ParentCode" name="ParentCode" value="0" />
                        <input type="hidden" runat="server" id="hfClassName" name="hfClassName" value="0" />
                        <input type="hidden" runat="server" id="hfCode" name="hfCode" value="0" />
                          <input type="hidden" runat="server" id="hfReferCode" name="hfReferCode" value="0" />
                        <input type="hidden" runat="server" id="hfCurrentPage" name="hfCurrentPage" value="0" />
                        <telerik:RadTextBox Width="300px" runat="server" Enabled="false" ReadOnly="true" ID="txtParent"></telerik:RadTextBox>
                    </td>
                </tr>
                <tr class="Table_RowB">
                    <td style="width: 150px">سال:</td>
                    <td>
                        <telerik:RadTextBox Width="300px" runat="server" ID="txtYear"></telerik:RadTextBox>
                    </td>
                </tr>

                <tr class="Table_RowC">
                    <td style="width: 150px">فرستنده:</td>
                    <td>
                        <telerik:RadComboBox Width="300px" runat="server" ID="cmbSender" DataValueField="code" AutoPostBack="true" OnSelectedIndexChanged="cmbSender_SelectedIndexChanged" Filter="Contains" DataTextField="Full_Title_Slim"></telerik:RadComboBox>
                    </td>
                </tr>
                <tr class="Table_RowB">
                    <td style="width: 150px">گیرنده:</td>
                    <td>
                        <telerik:RadComboBox Width="300px" runat="server" ID="cmbReciever"  DataValueField="code" DataTextField="Full_Title_Slim" Filter="Contains"></telerik:RadComboBox>
                    </td>
                </tr>
                <tr class="Table_RowC">
                    <td style="width: 150px">موضوع:</td>
                    <td>
                        <telerik:RadTextBox Width="300px" runat="server" ID="txtSubject"></telerik:RadTextBox>

                    </td>
                </tr>
                <tr class="Table_RowB">
                    <td style="width: 150px">فوریت:</td>
                    <td>
                        <telerik:RadComboBox Width="300px" runat="server" ID="cmbUrgency" Filter="Contains" DataValueField="value" DataTextField="FarsiName"></telerik:RadComboBox>
                    </td>
                </tr>
                <tr class="Table_RowC">
                    <td colspan="2">
                        <asp:Panel ID="pnlCopyReceiver" GroupingText="رونوشت نامه" runat="server" Width="99%">
                            <telerik:RadAjaxPanel runat="server" ID="jxpnlCopyReceiver">
                                <table style="width: 100%">
                                    <tr class="Table_RowB">
                                        <td style="width: 135px">گیرنده:</td>
                                        <td>
                                            <telerik:RadComboBox Width="300px" runat="server" Filter="Contains" EnableViewState="true" ViewStateMode="Enabled" DataValueField="code" DataTextField="Full_Title_Slim" ID="cmbCopyReceiver"></telerik:RadComboBox>
                                        </td>
                                    </tr>
                                    <tr class="Table_RowC">
                                        <td style="width: 135px">توضیحات:</td>
                                        <td>
                                            <telerik:RadTextBox Width="300px" runat="server" ID="txtReason"></telerik:RadTextBox>
                                        </td>
                                    </tr>

                                    <tr class="Table_RowB">

                                        <td>
                                            <telerik:RadButton runat="server" ID="btnAddCopyReceiver" Text="افزودن" AutoPostBack="true" Width="100px" Height="35px" OnClick="btnAddCopyReceiver_Click" />
                                        </td>

                                    </tr>
                                    <tr class="Table_RowC">
                                        <td colspan="2">
                                            <telerik:RadGrid EnableViewState="false" runat="server" ID="grvCopies" OnLoad="grvCopies_Load" ViewStateMode="Enabled"
                                                AutoGenerateColumns="false" AllowFilteringByColumn="false" Width="100%"
                                                OnSelectedIndexChanged="grvCopies_SelectedIndexChanged" ActiveItemStyle-Width="100%"
                                                AllowSorting="True" GridLines="None" OnNeedDataSource="grvCopies_NeedDataSource"
                                                OnDeleteCommand="grvCopies_DeleteCommand">
                                                <ClientSettings>
                                                    <Selecting AllowRowSelect="true"></Selecting>

                                                </ClientSettings>
                                                <MasterTableView DataKeyNames="Code">
                                                    <Columns>
                                                        <telerik:GridBoundColumn Visible="false" DataField="Code" HeaderText="کد"></telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="receiver_full_title" HeaderText="گیرنده"></telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="copy_reason" HeaderText="توضیحات"></telerik:GridBoundColumn>
                                                        <telerik:GridButtonColumn ButtonType="ImageButton" ImageUrl="~\Images\Controls\menu_delete.png" CommandName="delete" ConfirmText="آیا این گیرنده حذف شود"></telerik:GridButtonColumn>
                                                    </Columns>
                                                </MasterTableView>
                                            </telerik:RadGrid>

                                            <input type="hidden" runat="server" id="GridViewCopiesSelectedRowId" name="GridViewCopiesRowId" value="0" />

                                        </td>
                                    </tr>



                                </table>
                            </telerik:RadAjaxPanel>
                        </asp:Panel>
                    </td>
                </tr>
                <tr class="Table_RowB">
                    <td colspan="2">

                        <asp:Panel ID="pnlSignStatus" GroupingText="وضعیت نامه" runat="server" Width="99%">
                            <table style="width: 100%">
                                <tr class="Table_RowB">
                                    <td style="width: 180px">
                                        <asp:Label ID="lblSignStatus" Text="نامه هنوز امضا نشده است." runat="server"></asp:Label>
                                    </td>
                                    <td>
                                        <telerik:RadButton runat="server" ID="btnSign" Text="امضا نامه" AutoPostBack="true" Width="100px" Height="35px" OnClick="btnSign_Click" />
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                    </td>
                </tr>
                <tr class="Table_RowC">
                    <td colspan="2" dir="ltr">
                        <telerik:RadEditor runat="server" EditModes="All" ID="txtContent" ToolTip="تایپ نامه"></telerik:RadEditor>
                    </td>
                </tr>
            </table>
        </telerik:RadPageView>
        <telerik:RadPageView runat="server" ID="rpvArchive">
            <uc1:JArchiveControl runat="server" id="JArchiveControl" />
        </telerik:RadPageView>
        <telerik:RadPageView runat="server" ID="rpvRefer">
            <uc1:JReferViewControl runat="server" id="JReferViewControl" />
        </telerik:RadPageView>

    </telerik:RadMultiPage>
</div>
<div class="FormButtons">
    <telerik:RadButton runat="server" ID="btnSave" Text="ذخیره" AutoPostBack="true" Width="100px" Height="35px" OnClick="btnSave_Click" ValidationGroup="District" />
    <telerik:RadButton runat="server" ID="btnClose" Text="بازگشت" OnClientClicked="CloseDialog" AutoPostBack="false" Width="100px" Height="35px" />
    <telerik:RadButton runat="server" ID="btnReference" Text="ارجاع" OnClick="btnReference_Click" AutoPostBack="true" Width="100px" Height="35px" />
       <telerik:RadButton runat="server" ID="btnReturn"    Text ="بازگشت از ارجاع"  OnClick="btnReturn_Click"     AutoPostBack="true" Width="100px" Height="35px" />
    <telerik:RadButton runat="server" ID="btnParent" Text="عطف / پیرو" OnClick="btnParent_Click" AutoPostBack="true" Width="100px" Height="35px" />
<%--     <telerik:RadButton runat="server" ID="btnPrint"     Text="چاپ"   OnClick="btnPrint_Click"    AutoPostBack="true" Width="100px" Height="35px" />--%>
</div>
<telerik:RadCodeBlock ID="RadCodeBlock1" runat="server">
    <script type="text/javascript">
        function ReferSuccess() {
            CloseDialog(null);
        }
    </script>
</telerik:RadCodeBlock>
