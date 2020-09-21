<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TransferConfirmControl.ascx.cs" Inherits="WebRealEstate.Building.UnitBuild.Transfer.TransferControl" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AggregateFormControl.ascx.cs" Inherits="WebRealEstate.Building.UnitBuild.Aggregate.AggregateFormControl" %>
<%@ Register Assembly="JJson" Namespace="JJson.Controls" TagPrefix="JJson" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register Src="~/WebControllers/MainControls/Grid/JGridViewControl.ascx" TagPrefix="uc1" TagName="JGridViewControl" %>
<%@ Register Src="~/WebControllers/MainControls/Date/JDateControl.ascx" TagPrefix="uc1" TagName="JDateControl" %>
<%@ Register Src="~/WebControllers/MainControls/Date/JDateControl.ascx" TagPrefix="uc1" TagName="JDateControl" %>
<%@ Register Src="~/WebControllers/MainControls/Date/JDateControl.ascx" TagPrefix="uc1" TagName="JDateControl" %>
<%@ Register Src="~/WebControllers/MainControls/Date/JDateControl.ascx" TagPrefix="uc1" TagName="JDateControl" %>
<%@ Register Src="~/WebControllers/MainControls/Persons/JSearchPersonControl.ascx" TagPrefix="uc1" TagName="JSearchPersonControl" %>
<%@ Register Src="~/WebControllers/MainControls/Grid/JGridViewControl.ascx" TagPrefix="uc1" TagName="JGridViewControl" %>
<%@ Register Src="~/WebControllers/MainControls/Date/JDateControl.ascx" TagPrefix="uc1" TagName="JDateControl" %>
<%@ Register Src="~/WebControllers/MainControls/Grid/JGridViewControl.ascx" TagPrefix="uc1" TagName="JGridViewControl" %>
<%@ Register Src="~/WebControllers/MainControls/Grid/JGridViewControl.ascx" TagPrefix="uc2" TagName="JGridViewControl" %>
<%@ Register Src="~/WebControllers/MainControls/Date/JDateControl.ascx" TagPrefix="uc2" TagName="JDateControl" %>
<%@ Register Src="~/WebControllers/MainControls/Grid/JGridViewControl.ascx" TagPrefix="uc3" TagName="JGridViewControl" %>


<table>
    <tr>
        <td>
            <telerik:RadTabStrip ID="RadTabStrip2" runat="server" OnTabClick="RadTabStrip1_TabClick">
                <Tabs>
                    <telerik:RadTab Text="تایید" PageViewID="rpvD1"></telerik:RadTab>
                </Tabs>
                <Tabs>
                    <telerik:RadTab Text="طرفین" PageViewID="rpvD2"></telerik:RadTab>
                </Tabs>
                <Tabs>
                    <telerik:RadTab Text="تصاویر" PageViewID="rpvD3"></telerik:RadTab>
                </Tabs>
            </telerik:RadTabStrip>
            <telerik:RadMultiPage runat="server" ID="RadMultiPage2" SelectedIndex="0" RenderSelectedPageOnly="true" Width="100%">
                <telerik:RadPageView runat="server" ID="rpvD1">
                    <table>
                        <tr><td>
                            تاریخ :
</td>
                            <td>
                                <uc2:JDateControl runat="server" id="JDateControl" />
                            </td>
                            <td>
                                شماره :
                            </td>
                            <td>
                                <asp:TextBox ID="txtNum" runat="server"></asp:TextBox>
                            </td>
                            <td>
                                مبلغ حق انتقال :
                            </td>
                            <td>
                                <asp:TextBox ID="txtPriceEnteghal" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:CheckBox ID="chkBoxManager" runat="server"  Text="مدیر عامل"/>
                            </td>
                            <td>
                                <asp:CheckBox ID="chkBoxMMali" runat="server"  Text="مدیر امور مالی"/>
                            </td>
                            <td>
                                
                            </td>
                            <td>

                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:CheckBox ID="chkBoxMoavenat" runat="server"  Text="معاونت املاک و مستغلات"/>
                            </td>
                            <td>
                                <asp:CheckBox ID="chkBoxSellerSign" runat="server"  Text="امضا فروشنده"/>
                            </td>
                            <td>
                                
                            </td>
                            <td>

                            </td>
                        </tr>
                        <tr>
                            <td>
                                اطلاعات زمین 
                            </td>
                       
                            <td>
                                
                            </td>
                            <td>

                            </td>
                            
                        </tr>
                        <tr>
                            <td>
                                پلاک اصلی :
                            </td>
                            <td>
                                <asp:TextBox ID="txtMainPelak" runat="server"></asp:TextBox>
                            </td>
                            <td>

                            </td>
                            <td>

                            </td>
                        </tr>
                        <tr>
                            <td>
                                پلاک فرعی :
                            </td>
                            <td>
                                <asp:TextBox ID="txtSlavePelak" runat="server"></asp:TextBox>
                            </td>
                            <td>

                            </td>
                            <td>

                            </td>
                        </tr>
                        <tr>
                            <td>
                                شماره بلوک :
                            </td>
                            <td>
                                <asp:TextBox ID="txtNumBlock" runat="server"></asp:TextBox>
                            </td>
                            <td>
                                کاربری :
                            </td>
                            <td>
                                 <asp:TextBox ID="txtUsage" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                             <td>
                                 شماره قطعه :
                             </td>
                            <td>
                                 <asp:TextBox ID="txtNumGhete" runat="server"></asp:TextBox>
                             </td>
                            <td>
                                مساحت :
                             </td>
                            <td>
                                 <asp:TextBox ID="txtMasahat" runat="server"></asp:TextBox>
                             </td>
                        </tr>
                    </table>
                </telerik:RadPageView>
                <telerik:RadPageView runat="server" ID="rpvD2">
                    <table>
                        <tr>
                            <td>
                                فروشنده :
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <uc3:jgridviewcontrol runat="server" id="JGridSeller" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                خریدار :
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <uc3:jgridviewcontrol runat="server" id="JGridCus" />
                            </td>
                        </tr>
                        </table>
                        </telerik:RadPageView>
                <telerik:RadPageView runat="server" ID="rpvD3">
                    <table>
                        </table>
                        </telerik:RadPageView>
            </telerik:RadMultiPage>
        </td>
        <td></td>
        <td></td>
        <td></td>
        <td></td>
    </tr>
    <tr>
        <td>
            <asp:Button ID="btnAgree" runat="server" Text="تایید" /></td>
        <td><asp:Button ID="btnSave" runat="server" Text="ذخیره" /></td>
        <td>
            <asp:Button ID="btnPrint" runat="server" Text="چاپ" />
        </td>
        <td></td>
        <td><asp:Button ID="btnExit" runat="server" Text="خروج" /></td>
    </tr>
</table>
