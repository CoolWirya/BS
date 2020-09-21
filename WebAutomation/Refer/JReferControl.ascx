<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="JReferControl.ascx.cs" Inherits="WebAutomation.Refer.JReferControl" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register Src="~/WebControllers/ArchiveDocument/JArchiveControl.ascx" TagPrefix="uc1" TagName="JArchiveControl" %>


<div class="FormContent">
    <table style="width: 100%; height: 100%" runat="server" id="mainTable">
        <tr>
            <td style="vertical-align: top">
                <telerik:RadTabStrip runat="server" ID="RadTabStrip1"
                    SelectedIndex="0" MultiPageID="RadMultiPage1" Enabled="false" Width="100%">
                    <Tabs>
                        <telerik:RadTab Text="ارجاع" Visible="true">
                        </telerik:RadTab>
                       <%-- <telerik:RadTab Text="ضمائم ارجاع" Visible="true">
                        </telerik:RadTab>--%>
                    </Tabs>
                </telerik:RadTabStrip>
                <asp:HiddenField ID="hfReferCode" runat="server" />
                <telerik:RadMultiPage runat="server" ID="RadMultiPage1" SelectedIndex="0"
                    Width="100%">
                    <telerik:RadPageView runat="server" ID="RadPageView1">
                        <div style="padding: 5px">
                            گروه گیرندگان:
                <telerik:RadComboBox runat="server" ID="cmbNextNodes" EmptyMessage="انتخاب گروه گیرندگان" DataTextField="Name" DataValueField="Code" Width="300px" OnSelectedIndexChanged="cmbNextNodes_SelectedIndexChanged" AutoPostBack="true" />
                        </div>
                        <telerik:RadGrid runat="server" ID="grdReceivers" AutoGenerateColumns="false">
                            <MasterTableView>
                                <NoRecordsTemplate>
                                    <div class="noGridRecords">موردی جهت ارجاع یافت نشد.</div>
                                </NoRecordsTemplate>
                                <Columns>
                                    <telerik:GridTemplateColumn UniqueName="colSel" HeaderText="انتخاب" ItemStyle-Width="30" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle">
                                        <ItemTemplate>
                                            <asp:HiddenField runat="server" ID="hidPostCode" Value='<%# Eval("Code") %>' />
                                            <telerik:RadButton runat="server" ID="btnSelect" ButtonType="ToggleButton" ToggleType="CustomToggle" Text="SS" AutoPostBack="false" Width="32" Height="32">
                                                <ToggleStates>
                                                    <telerik:RadButtonToggleState ImageUrl="~/Images/Controls/unchecked_s32.png" Selected="true" />
                                                    <telerik:RadButtonToggleState ImageUrl="~/Images/Controls/checked_s32.png" />
                                                </ToggleStates>
                                            </telerik:RadButton>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridBoundColumn UniqueName="colRec" HeaderText="نام گیرنده" DataField="Full_Title"></telerik:GridBoundColumn>
                                    <telerik:GridTemplateColumn HeaderText="متن ارجاع">
                                        <ItemTemplate>
                                            <telerik:RadTextBox runat="server" ID="txtReferText" Width="100%" TextMode="MultiLine" Height="40" />
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                </Columns>
                            </MasterTableView>
                        </telerik:RadGrid>
                    </telerik:RadPageView>
                 <%--   <telerik:RadPageView runat="server" ID="RadPageView2">
                       <%-- <uc1:jarchivecontrol runat="server" id="JArchiveControl" />--
                    </telerik:RadPageView>--%>
                </telerik:RadMultiPage>
            </td>
        </tr>
    </table>
</div>
<div class="FormButtons">
    <telerik:RadButton runat="server" ID="btnSave" Text="ارجاع" AutoPostBack="true" Width="100px" OnClick="btnSave_Click" Height="35px" ValidationGroup="Bus" />
    <telerik:RadButton runat="server" ID="btnClose" Text="بازگشت" OnClientClicked="CloseDialog" AutoPostBack="false" Width="100px" Height="35px" />
</div>
