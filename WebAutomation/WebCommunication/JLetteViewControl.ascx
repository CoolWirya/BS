<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="JLetteViewControl.ascx.cs" Inherits="WebAutomation.WebCommunication.JLetterViewControl" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register Src="~/WebControllers/MainControls/Date/JDateControl.ascx" TagPrefix="uc1" TagName="JDateControl" %>
<%@ Register Src="~/WebControllers/MainControls/Persons/JSearchPersonControl.ascx" TagPrefix="uc1" TagName="JSearchPersonControl" %>
<%@ Register Src="~/WebControllers/ArchiveDocument/JArchiveControl.ascx" TagPrefix="uc1" TagName="JArchiveControl" %>
<%@ Register Src="~/WebAutomation/Refer/JReferViewControl.ascx" TagPrefix="uc1" TagName="JReferViewControl" %>
<link href="Style/Letter.css" rel="stylesheet" />



<div class="FormContent">
    <div class="BigTitle"></div>
    <telerik:RadTabStrip runat="server" ID="rtabLetter" SelectedIndex="2" OnTabClick="rtabLetter_TabClick" MultiPageID="rpageLetter" Width="500px">
        <Tabs>
            <telerik:RadTab Text="اطلاعات نامه" Value="Info" PageViewID="rpvLetterInfo">
            </telerik:RadTab>
            <telerik:RadTab Text="ضمائم" Value="Archive" PageViewID="rpvArchive">
            </telerik:RadTab>
            <telerik:RadTab Text="ارجاعات" Value="Refer" PageViewID="rpvRefer" Selected="True">
            </telerik:RadTab>
            <telerik:RadTab Text="ارسال و تحویل" Value="Delivery" PageViewID="rpvSendDelivery">
            </telerik:RadTab>
        </Tabs>
    </telerik:RadTabStrip>
    <telerik:RadMultiPage runat="server" ID="rpageLetter" SelectedIndex="2" Width="700px">
        <telerik:RadPageView runat="server" ID="rpvLetterInfo">
            <table style="width: 700px; padding-right: 7px;">
<%--                <tr class="Table_RowB">
                    <td style="width: 150px">پاسخ / پیرو:</td>
                    <td>
                        <input type="hidden" runat="server" id="LetterState" name="LetterState" value="0" />
                        <input type="hidden" runat="server" id="ParentCode" name="ParentCode" value="0" />
                        <input type="hidden" runat="server" id="hfClassName" name="hfClassName" value="0" />
                        <input type="hidden" runat="server" id="hfCode" name="hfCode" value="0" />
                        <input type="hidden" runat="server" id="hfReferCode" name="hfReferCode" value="0" />
                        <input type="hidden" runat="server" id="hfTitle" name="hfTitle" value="نامه" />
                       <input type="hidden" runat="server" id="hfCurrentPage" name="hfCurrentPage" value="0" />
                        <asp:Label Width="300px" runat="server" ID="txtParent"></asp:Label>
                    </td>
                </tr>
                <tr class="Table_RowC">
                    <td style="width: 150px">سال:</td>
                    <td>
                        <asp:Label Width="300px" runat="server" ID="txtYear"></asp:Label>
                    </td>
                </tr>
                <tr class="Table_RowB">
                    <td style="width: 150px">شماره نامه:</td>
                    <td>
                        <asp:Label Width="300px" runat="server" ID="txtLetterNo"></asp:Label>
                    </td>
                </tr>
                <tr class="Table_RowC">
                    <td style="width: 150px">فرستنده:</td>
                    <td>
                        <asp:Label Width="300px" runat="server" ID="cmbSender" Filter="Contains" AutoPostBack="true" DataValueField="code" OnSelectedIndexChanged="cmbSender_SelectedIndexChanged"
                            DataTextField="Full_Title_Slim">
                        </asp:Label>
                    </td>
                </tr>
                <tr class="Table_RowB">
                    <td style="width: 150px">گیرنده:</td>
                    <td>
                        <asp:Label Width="300px" runat="server" ID="txtReciever"></asp:Label>
                    </td>
                </tr>
                <tr class="Table_RowC">
                    <td style="width: 150px">موضوع:</td>
                    <td>
                        <asp:Label Width="300px" runat="server" ID="txtSubject"></asp:Label>

                    </td>
                </tr>
                <tr class="Table_RowB">
                    <td style="width: 150px">فوریت:</td>
                    <td>
                        <asp:Label Width="300px" runat="server" Filter="Contains" ID="cmbUrgency" DataValueField="value" DataTextField="FarsiName"></asp:Label>
                    </td>
                </tr>--%>
                <tr <%--class="Table_RowB"--%>>
                    <td colspan="2" dir="rtl" style="margin-right:20px;">
                        <%--<asp:Panel ID="pnlContent" Direction="RightToLeft" GroupingText="متن نامه" runat="server" Width="99%">--%>
                            <ul style="list-style-type:none; line-height: 18px; padding-right:0px">
                                <li class="parent">
                                    <span>پاسخ / پیرو:</span>
                                    <input type="hidden" runat="server" id="LetterState" name="LetterState" value="0" />
                                    <input type="hidden" runat="server" id="ParentCode" name="ParentCode" value="0" />
                                    <input type="hidden" runat="server" id="hfClassName" name="hfClassName" value="0" />
                                    <input type="hidden" runat="server" id="hfCode" name="hfCode" value="0" />
                                    <input type="hidden" runat="server" id="hfReferCode" name="hfReferCode" value="0" />
                                    <input type="hidden" runat="server" id="hfTitle" name="hfTitle" value="نامه" />
                                   <input type="hidden" runat="server" id="hfCurrentPage" name="hfCurrentPage" value="0" />
                                    <asp:Label runat="server" ID="txtParent"></asp:Label>
                                </li>
                                <li class="year">
                                    <span>سال:</span>
                                    <asp:Label runat="server" ID="txtYear"></asp:Label>
                                </li>
                                <li class="subject header_footer">
                                    <span>موضوع:</span>
                                    <asp:Label Width="300px" runat="server" ID="txtSubject"></asp:Label>
                                </li>
                                <li class="from header_footer">
                                    <span>از:</span>
                                    <asp:Label runat="server" ID="cmbSender" Filter="Contains" AutoPostBack="true" DataValueField="code" OnSelectedIndexChanged="cmbSender_SelectedIndexChanged"
                                        DataTextField="Full_Title_Slim">
                                    </asp:Label>
                                </li>
                                <li class="to header_footer">
                                    <span>به:</span>
                                    <asp:Label runat="server" ID="txtReciever"></asp:Label>
                                </li>
                                <li class="number header_footer">
                                    <span>شماره نامه:</span>
                                    <asp:Label runat="server" ID="txtLetterNo"></asp:Label>
                                </li>
                                <li class="urgency ltr">
                                    <span>فوریت:</span>
                                    <asp:Label runat="server" Filter="Contains" ID="cmbUrgency" DataValueField="value" DataTextField="FarsiName"></asp:Label>
                                </li>
                                <li class="content ">
                                    <asp:Label runat="server" ID="txtContent"></asp:Label>
                                </li>
                                <li  class="copies">رونوشت:</li>
                                <li>
                                    <div id="dv_Copies" class="copies" runat="server">
                                    </div>
                                </li>
                                <li class="references page">ارجاعات:</li>
                                <li>
                                    <div id="dv_ReferenceTree" class="reference_tree ltr page" runat="server">
                                    </div>
                                </li>
                            </ul>
                        <%--</asp:Panel>--%>
                    </td>
                </tr>
<%--                <tr>
                    <td>
                        <asp:Label runat="server" ID="txtContent"></asp:Label>
                    </td> 
                </tr>--%>
<%--                <tr class="Table_RowC">
                    <td colspan="2">
                        <asp:Panel ID="pnlCopyReceiver" GroupingText="رونوشت نامه" runat="server" Width="99%">
                            <telerik:RadAjaxPanel runat="server" ID="jxpnlCopyReceiver">
                                <table style="width: 100%">
                                    <tr class="Table_RowC">
                                        <td colspan="2">
                                            <telerik:RadGrid EnableViewState="false" runat="server" ID="grvCopies" OnLoad="grvCopies_Load"
                                                AutoGenerateColumns="false" AllowFilteringByColumn="false" Width="100%"
                                                OnSelectedIndexChanged="grvCopies_SelectedIndexChanged" ActiveItemStyle-Width="100%"
                                                AllowSorting="True" GridLines="None" OnNeedDataSource="grvCopies_NeedDataSource">
                                                <ClientSettings>
                                                    <Selecting AllowRowSelect="true"></Selecting>

                                                </ClientSettings>
                                                <MasterTableView DataKeyNames="Code">
                                                    <Columns>
                                                        <telerik:GridBoundColumn Visible="false" DataField="Code" HeaderText="کد"></telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="receiver_full_title" HeaderText="گیرنده"></telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn DataField="copy_reason" HeaderText="توضیحات"></telerik:GridBoundColumn>
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
                                    <td></td>
                                </tr>
                            </table>
                        </asp:Panel>
                    </td>
                </tr>--%>

            </table>
        </telerik:RadPageView>
        <telerik:RadPageView runat="server" ID="rpvArchive" CssClass="scroll">
            <uc1:JArchiveControl runat="server" id="JArchiveControl" />
        </telerik:RadPageView>
        <telerik:RadPageView runat="server" ID="rpvRefer">
            <uc1:JReferViewControl runat="server" id="JReferViewControl" />
        </telerik:RadPageView>
        <telerik:RadPageView runat="server" ID="rpvSendDelivery">
            <asp:Panel ID="pnlDelivery" GroupingText="ارسال و تحویل نامه" runat="server" Width="99%">
                <table style="width: 100%">
                    <tr class="Table_RowB">
                        <td style="width: 150px">نوع ارسال
                        </td>
                        <td>
                            <asp:Label Width="300px" runat="server" ID="cmbDeliveryType" Filter="Contains" DataValueField="value" DataTextField="FarsiName"></asp:Label>
                        </td>
                    </tr>
                    <tr class="Table_RowC">
                        <td style="width: 150px">تاریخ ارسال
                        </td>
                        <td>
                            <%--<uc1:JDateControl runat="server" id="dteDelivery" />--%>
                            <asp:Label runat="server" ID="dteDelivery"></asp:Label>
                        </td>
                    </tr>
                    <tr class="Table_RowC">
                        <td style="width: 150px">تحویل گیرنده 
                        </td>
                        <td>
                            <asp:Label Width="300px" runat="server" ID="txtDeliveryPerson"></asp:Label>
                        </td>
                    </tr>
                </table>
            </asp:Panel>
        </telerik:RadPageView>
    </telerik:RadMultiPage>
</div>
<div class="FormButtons">
    <telerik:RadButton runat="server" ID="btnClose" Text="بازگشت" OnClientClicked="CloseDialog" AutoPostBack="false" Width="100px" Height="35px" />
    <telerik:RadButton runat="server" ID="btnReference" Text="ارجاع"              OnClick="btnReference_Click"  AutoPostBack="true" Width="100px" Height="35px" />
    <telerik:RadButton runat="server" ID="btnReturn"    Text ="بازگشت از ارجاع"  OnClick="btnReturn_Click"     AutoPostBack="true" Width="100px" Height="35px" />
    <telerik:RadButton runat="server" ID="btnParent" Text="عطف / پیرو" OnClick="btnParent_Click" AutoPostBack="true" Width="100px" Height="35px" />
  <%--   <telerik:RadButton runat="server" ID="btnPrint"     Text="چاپ"   OnClick="btnPrint_Click"    AutoPostBack="true" Width="100px" Height="35px" />--%>
</div>
<telerik:RadCodeBlock ID="RadCodeBlock1" runat="server">
    <script type="text/javascript">
        function ReferSuccess() {
            CloseDialog(null);
        }
    </script>
</telerik:RadCodeBlock>
