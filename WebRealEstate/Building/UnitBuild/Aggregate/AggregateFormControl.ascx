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



<table>
    <tr>
        <td>تاریخ تجمیع :</td>
        <td>
            <uc1:jdatecontrol runat="server" id="JDateControl" />
        </td>
        <td></td>
        <td></td>
    </tr>
    <tr>
        <td>
            <telerik:RadTabStrip ID="RadTabStrip2" runat="server" OnTabClick="RadTabStrip1_TabClick">
                <Tabs>
                    <telerik:RadTab Text="لیست اعیان" PageViewID="rpvD1"></telerik:RadTab>
                </Tabs>
                <Tabs>
                    <telerik:RadTab Text="اعیان تجمیع شده" PageViewID="rpvD2"></telerik:RadTab>
                </Tabs>
                <Tabs>
                    <telerik:RadTab Text="توضیحات" PageViewID="rpvD3"></telerik:RadTab>
                </Tabs>
                <Tabs>
                    <telerik:RadTab Text="فایل های مرتبط" PageViewID="rpvD4"></telerik:RadTab>
                </Tabs>
            </telerik:RadTabStrip>
            <telerik:RadMultiPage runat="server" ID="RadMultiPage2" SelectedIndex="0" RenderSelectedPageOnly="true" Width="100%">
                <telerik:RadPageView runat="server" ID="rpvD1">
                    <table>
                        <tr>
                            <td>لیست اعیان هایی که قرار است تجمیع شوند :
                            </td>
                            <td></td>
                        </tr>
                        <tr>
                            <td>
                                <uc1:jgridviewcontrol runat="server" id="JGridViewControl" />

                            </td>
                            <td></td>
                        </tr>
                        <tr>
                            <td>
                                <JJson:JJsonButton ID="JbtnAdd" runat="server" Event="click" Text="اضافه" />
                            </td>
                            <td>
                                <JJson:JJsonButton ID="JbtnDel" runat="server" Event="click" Text="حذف" />
                            </td>
                        </tr>
                    </table>
                </telerik:RadPageView>
                <telerik:RadPageView runat="server" ID="rpvD2">
                    <table>
                        <tr>
                            <td>نام مجتمع/بازار: </td>
                            <td>
                                <asp:Label ID="JlblBazar" runat="server" Text="Label"></asp:Label></td>
                            <td></td>
                            <td>متراژ (تقریبی) :</td>
                            <td>
                                <asp:Label ID="JlblMetraj" runat="server" Text="Label"></asp:Label></td>
                            <td></td>
                        </tr>
                        <tr>
                            <td>طبقه: </td>
                            <td>
                                <asp:Label ID="JlblFloor" runat="server" Text="Label"></asp:Label></td>
                            <td></td>
                            <td>متراژ :</td>
                            <td>
                                <asp:Label ID="JlblMetraj2" runat="server" Text="Label"></asp:Label></td>
                            <td></td>
                        </tr>
                        <tr>
                            <td>پلاک ثبتی : </td>
                            <td>
                                <asp:Label ID="JlblPelak" runat="server" Text="Label"></asp:Label></td>
                            <td></td>
                            <td>متراژ بالکن :</td>
                            <td>
                                <asp:Label ID="JlblMetraj3" runat="server" Text="Label"></asp:Label></td>
                            <td></td>
                        </tr>
                        <tr>
                            <td>شماره شناسایی : </td>
                            <td>
                                <asp:Label ID="JlblIDNum" runat="server" Text="Label"></asp:Label></td>
                            <td></td>
                            <td>اجاره اولیه :</td>
                            <td>
                                <asp:Label ID="JlblEjare" runat="server" Text="Label"></asp:Label></td>
                            <td></td>
                        </tr>
                        <tr></tr>
                        <td>شماره واحد : </td>
                        <td>
                            <asp:Label ID="JlblNumVahed" runat="server" Text="Label"></asp:Label></td>
                        <td></td>
                        <td>تاریخ تحویل :</td>
                        <td>
                            <asp:Label ID="JlblDateTahvil" runat="server" Text="Label"></asp:Label></td>
                        <td></td>
                        <tr>
                            <td>
                                <JJson:JJsonButton ID="JbtnIntAyan" runat="server" Event="click" text="تعریف اعیان"/></td>
                            <td></td>
                            <td></td>
                            <td></td>
                            <td></td>
                            <td></td>
                        </tr>
                    </table>
                </telerik:RadPageView>
                <telerik:RadPageView runat="server" ID="rpvD3">
                 <table>
                     <tr>
                         <td>
                             <asp:TextBox ID="JtxtTozihat" runat="server"></asp:TextBox>
                         </td>
                     </tr>
                 </table>
                </telerik:RadPageView>
                <telerik:RadPageView runat="server" ID="rpvD4">
                    <div>
                        <uc1:jgridviewcontrol runat="server" id="JGridViewControl3" />
                    </div>
                </telerik:RadPageView>
            </telerik:RadMultiPage>
        </td>
    </tr>
    <tr>
        <td>
            <JJson:JJsonButton ID="JbtnTayid" runat="server" Event="click" Text="تایید" /></td>
        <td>
            <JJson:JJsonButton ID="JbtnSave" runat="server" Event="click" Text="ذخیره" /></td>
        <td></td>
        <td>
            <JJson:JJsonButton ID="JbtnExit" runat="server" Event="click" Text="خروج" /></td>
    </tr>
</table>
