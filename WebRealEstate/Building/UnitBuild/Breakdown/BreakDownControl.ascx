<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BreakDownControl.ascx.cs" Inherits="WebRealEstate.Building.UnitBuild.Breakdown.BreakDownControl" %>

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
        <td>تاریخ تفکیک:</td>
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
                    <telerik:RadTab Text="اعیان تفکیک شده" PageViewID="rpvD1"></telerik:RadTab>
                </Tabs>
                <Tabs>
                    <telerik:RadTab Text="اعیان های جدید" PageViewID="rpvD2"></telerik:RadTab>
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
                            <td>نام مجتمع/بازار: </td>
                            <td>
                                <asp:Label ID="lblMojtamae" runat="server" Text=""></asp:Label></td>
                            <td></td>
                            <td>متراژ (تقریبی) :</td>
                            <td>
                                <asp:Label ID="lblMetraj" runat="server" Text=""></asp:Label></td>
                            <td></td>
                        </tr>
                        <tr>
                            <td>طبقه: </td>
                            <td>
                                <asp:Label ID="lblFloor" runat="server" Text=""></asp:Label></td>
                            <td></td>
                            <td>متراژ :</td>
                            <td>
                                <asp:Label ID="lblMetraj2" runat="server" Text=""></asp:Label></td>
                            <td></td>
                        </tr>
                        <tr>
                            <td>پلاک ثبتی : </td>
                            <td>
                                <asp:Label ID="lblSavePelak" runat="server" Text=""></asp:Label></td>
                            <td></td>
                            <td>متراژ بالکن :</td>
                            <td>
                                <asp:Label ID="lblMetrajBal" runat="server" Text=""></asp:Label></td>
                            <td></td>
                        </tr>
                        <tr>
                            <td>شماره شناسایی : </td>
                            <td>
                                <asp:Label ID="lblIDNum" runat="server" Text=""></asp:Label></td>
                            <td></td>
                            <td>اجاره اولیه :</td>
                            <td>
                                <asp:Label ID="lblFirstEjare" runat="server" Text=""></asp:Label></td>
                            <td></td>
                        </tr>
                        <tr></tr>
                        <td>شماره واحد : </td>
                        <td>
                            <asp:Label ID="lblNumVahed" runat="server" Text=""></asp:Label></td>
                        <td></td>
                        <td>تاریخ تحویل :</td>
                        <td>
                            <asp:Label ID="lblDateTahvil" runat="server" Text=""></asp:Label></td>
                        <td></td>
                        <tr>
                            <td>
                                <JJson:JJsonButton ID="JJsonButton4" runat="server" Event="click" text="جستجوی اعیان"/></td>
                            <td></td>
                            <td></td>
                            <td></td>
                            <td></td>
                            <td></td>
                        </tr>
                    </table>
                </telerik:RadPageView>
                <telerik:RadPageView runat="server" ID="rpvD2">
                    <table>
                       <tr>
                           <td>
لیست اعیان های جدید :
                           </td>
                           <td>

                            </td>
                           <td>

                            </td>
                           <td>

                            </td>
                       </tr>
                        <tr>
                            <td>
                                <asp:ListBox ID="ListBox1" runat="server"></asp:ListBox>
                            </td>
                            <td>

                            </td>
                            <td>

                            </td>
                            <td>

                            </td>
                        </tr>
                        <tr>
                            <td>
                                <JJson:JJsonButton ID="JJsonAdd" runat="server" Event="click" text="اضافه"/>
                            </td>
                            <td>
                                <JJson:JJsonButton ID="JJsonEdit" runat="server" Event="click" text="ویرایش"/>
                            </td>
                            <td>
                                مجموع مساحت ها :
                            </td>
                            <td>
                                <asp:Label ID="lblMajmoo" runat="server" Text="..."></asp:Label>
                            </td>
                        </tr>
                    </table>
                </telerik:RadPageView>
                <telerik:RadPageView runat="server" ID="rpvD3">
                 <table>
                     <tr>
                         <td>
                             <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
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
            <JJson:JJsonButton ID="JJsonAcc" runat="server" Event="click" Text="تایید" /></td>
        <td>
            <JJson:JJsonButton ID="JJsonSave" runat="server" Event="click" Text="ذخیره" /></td>
        <td></td>
        <td>
            <JJson:JJsonButton ID="JJsonExit" runat="server" Event="click" Text="خروج" /></td>
    </tr>
</table>
