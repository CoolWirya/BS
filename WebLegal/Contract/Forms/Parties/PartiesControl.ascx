<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PartiesControl.ascx.cs" Inherits="WebLegal.Contract.Forms.Parties.PartiesControl" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register Src="~/WebControllers/MainControls/Grid/JGridViewControl.ascx" TagPrefix="uc1" TagName="JGridViewControl" %>

<table>
    <tr>
        <td>
            <telerik:RadTabStrip ID="JTabParties" runat="server" OnTabClick="JTabParties_TabClick">
                <Tabs>
                    <telerik:RadTab Text="فروشندگان" PageViewID="JrtSeller"></telerik:RadTab>
                </Tabs>
                <Tabs>
                    <telerik:RadTab Text="خریداران" PageViewID="JrtBuyer"></telerik:RadTab>
                </Tabs>
                <Tabs>
                    <telerik:RadTab Text="شهود" PageViewID="JrtProof"></telerik:RadTab>
                </Tabs>
            </telerik:RadTabStrip>
            <telerik:RadMultiPage runat="server" ID="RadMultiPage2" SelectedIndex="0" RenderSelectedPageOnly="true" Width="100%">
                <telerik:RadPageView runat="server" ID="JrtSeller">
                    <table>
                        <tr>
                            <td>اشخاص حقیقی/حقوقی</td>
                            <td></td>
                            <td></td>
                            <td></td>
                            <td></td>
                            <td></td>
                            <td></td>
                        </tr>
                        <tr>
                            <td>
                                <uc1:jgridviewcontrol runat="server" id="JgrdT1Parties" />
                            </td>
                            <td></td>
                            <td></td>
                            <td></td>
                            <td></td>
                            <td></td>
                            <td></td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Button ID="JbtnAdd" runat="server" Text="اضافه" /></td>
                            <td>
                                <asp:Button ID="JbtnDel" runat="server" Text="حذف" />
                            </td>
                            <td></td>
                            <td>جمع سهام :</td>
                            <td>
                                <asp:Label ID="JlblSumSaham" runat="server" Text="0"></asp:Label></td>
                            <td>جمع سهام فروش :</td>
                            <td>
                                <asp:Label ID="JlblSumSSaham" runat="server" Text="0"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>وکیل :</td>
                            <td></td>
                            <td></td>
                            <td></td>
                            <td></td>
                            <td></td>
                            <td></td>
                        </tr>
                        <tr>
                            <td>
                                <uc1:jgridviewcontrol runat="server" id="JgrdVakil" />
                            </td>
                            <td></td>
                            <td></td>
                            <td></td>
                            <td></td>
                            <td></td>
                            <td></td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Button ID="JbtnAddVakil" runat="server" Text="اضافه" /></td>
                            <td>
                                <asp:Button ID="JbtnDelVakil" runat="server" Text="حذف" />
                            </td>
                            <td></td>
                            <td></td>
                            <td></td>
                            <td></td>
                            <td></td>
                        </tr>
                    </table>
                </telerik:RadPageView>
                <telerik:RadPageView runat="server" ID="JrtBuyer">
                    <table>
                        <tr>
                            <td>اشخاص حقیقی/حقوقی</td>
                            <td></td>
                            <td></td>
                            <td></td>
                            <td></td>
                            <td></td>
                            <td></td>
                        </tr>
                        <tr>
                            <td>
                                <uc1:jgridviewcontrol runat="server" id="JgrdT2Parties" />
                            </td>
                            <td></td>
                            <td></td>
                            <td></td>
                            <td></td>
                            <td></td>
                            <td></td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Button ID="JbtnAddT2" runat="server" Text="اضافه" /></td>
                            <td>
                                <asp:Button ID="JbtnDelT2" runat="server" Text="حذف" />
                            </td>
                            <td></td>
                            <td>جمع سهام :</td>
                            <td>
                                <asp:Label ID="JlblSumSahamT2" runat="server" Text="0"></asp:Label></td>
                        </tr>
                        <tr>
                            <td>وکیل :</td>
                            <td></td>
                            <td></td>
                            <td></td>
                            <td></td>
                            <td></td>
                            <td></td>
                        </tr>
                        <tr>
                            <td>
                                <uc1:jgridviewcontrol runat="server" id="JgrdT2Vakil" />
                            </td>
                            <td></td>
                            <td></td>
                            <td></td>
                            <td></td>
                            <td></td>
                            <td></td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Button ID="JbtnAddT2Vakil" runat="server" Text="اضافه" /></td>
                            <td>
                                <asp:Button ID="JbtnDelT2Vakil" runat="server" Text="حذف" />
                            </td>
                            <td></td>
                            <td></td>
                            <td></td>
                            <td></td>
                            <td></td>
                        </tr>
                    </table>
                </telerik:RadPageView>
                <telerik:RadPageView runat="server" ID="JrtProof">
                    <table>
                        <tr>
                            <td>شهود</td>
                            <td></td>
                            <td></td>
                            <td></td>
                        </tr>
                        <tr>
                            <td>
                                <telerik:RadGrid ID="JgrdProof" runat="server"></telerik:RadGrid>
                            </td>
                            <td></td>
                            <td></td>
                            <td></td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Button ID="JbtnAddP" runat="server" Text="اضافه" /></td>
                            <td>
                                <asp:Button ID="JbtnDelP" runat="server" Text="حذف" />
                            </td>
                            <td></td>
                            <td></td>
                        </tr>
                    </table>
                </telerik:RadPageView>
            </telerik:RadMultiPage>
        </td>
        <td></td>
        <td></td>
        <td></td>
    </tr>
    <tr>
        <td>
            <asp:Button ID="JbtnNext" runat="server" Text="بعدی" />
        </td>
        <td>
            <asp:Button ID="JbtnPre" runat="server" Text="قبلی" />
        </td>
        <td></td>
        <td>
            <asp:Button ID="JbtnCancel" runat="server" Text="انصراف" />
        </td>
    </tr>
</table>
