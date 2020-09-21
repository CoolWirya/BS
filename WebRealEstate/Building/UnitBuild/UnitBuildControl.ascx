<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UnitBuildControl.ascx.cs" Inherits="WebRealEstate.Building.UnitBuild.UnitBuildControl" %>
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
<%@ Register Src="~/WebControllers/MainControls/Date/JDateControl.ascx" TagPrefix="uc2" TagName="JDateControl" %>
<%@ Register Src="~/WebControllers/MainControls/Date/JDateControl.ascx" TagPrefix="uc2" TagName="JDateControl" %>
<%@ Register Src="~/WebControllers/MainControls/Date/JDateControl.ascx" TagPrefix="uc2" TagName="JDateControl" %>
<%@ Register Src="~/WebControllers/MainControls/Date/JDateControl.ascx" TagPrefix="uc2" TagName="JDateControl" %>




<table>
    <tr>
        <td>
            <telerik:RadTabStrip ID="RadTabStrip2" runat="server" OnTabClick="RadTabStrip1_TabClick">
                <Tabs>
                    <telerik:RadTab Text="مشخصات" PageViewID="rpvD1"></telerik:RadTab>
                </Tabs>
                <Tabs>
                    <telerik:RadTab Text="مالکین اولیه" PageViewID="rpvD2"></telerik:RadTab>
                </Tabs>
                <Tabs>
                    <telerik:RadTab Text="توضیحات" PageViewID="rpvD3"></telerik:RadTab>
                </Tabs>
                <Tabs>
                    <telerik:RadTab Text="ویژگی ها" PageViewID="rpvD4"></telerik:RadTab>
                </Tabs>
                <Tabs>
                    <telerik:RadTab Text="تصاویر" PageViewID="rpvD5"></telerik:RadTab>
                </Tabs>
                <Tabs>
                    <telerik:RadTab Text="مالکین" PageViewID="rpvD6"></telerik:RadTab>
                </Tabs>
                <Tabs>
                    <telerik:RadTab Text="زمین" PageViewID="rpvD7"></telerik:RadTab>
                </Tabs>
                <Tabs>
                    <telerik:RadTab Text="سابقه قراردادها" PageViewID="rpvD8"></telerik:RadTab>
                </Tabs>
            </telerik:RadTabStrip>
            <telerik:RadMultiPage runat="server" ID="RadMultiPage2" SelectedIndex="0" RenderSelectedPageOnly="true" Width="100%">
                <telerik:RadPageView runat="server" ID="rpvD1">
                    <table>
                        <tr>
                            <td>
                                نام مجتمع / بازار :
                            </td>
                            <td>
                                <asp:DropDownList ID="DDLMojtamae" runat="server"></asp:DropDownList>
                            </td>
                            <td>

                            </td>
                            <td>
                                <asp:Button ID="btnSrch" runat="server" Text="Search" />
                            </td>
                            <td>

                            </td>
                        </tr>
                        <tr>
                            <td>
                                طبقه :
                            </td>
                            <td>
                                <asp:DropDownList ID="DDLFloor" runat="server"></asp:DropDownList>
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
                                نوع واحد :
                            </td>
                            <td>
                                <asp:DropDownList ID="DDLKindVahed" runat="server"></asp:DropDownList>
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
                                پلاک ثبتی :
                            </td>
                            <td>
                                <asp:TextBox ID="txtPelak" runat="server"></asp:TextBox>
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
شماره شناسایی :
                            </td>
                            <td>
                                <asp:TextBox ID="txtIDNum" runat="server"></asp:TextBox>
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
                                شماره واحد :
                            </td>
                            <td>
                                <asp:TextBox ID="txtNumVahed" runat="server"></asp:TextBox>
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
                                کاربری :
                            </td>
                            <td>
                                <asp:DropDownList ID="DDLUsage" runat="server"></asp:DropDownList>
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

                            </td>
                            <td>

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

                            </td>
                            <td>

                            </td>
                            <td>

                            </td>
                            <td>
                                فاز :
                            </td>
                            <td>
                                <asp:DropDownList ID="DDlFaz" runat="server"></asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                متراژ (تقریبی) :
                            </td>
                            <td>
                                <asp:TextBox ID="txtMetraj" runat="server"></asp:TextBox>
                            </td>
                            <td>
                                مترمربع
                            </td>
                            <td>

                            </td>
                            <td>

                            </td>
                        </tr>
                        <tr>
                            <td>
                                متراژ :
                            </td>
                            <td>
                                <asp:TextBox ID="txtMetraj2" runat="server"></asp:TextBox>
                            </td>
                            <td>
                                مترمربع
                            </td>
                            <td>

                            </td>
                            <td>

                            </td>
                        </tr>
                        <tr>
                            <td>
                                متراژ بالکن :
                            </td>
                            <td>
                                <asp:TextBox ID="txtMetrajBal" runat="server"></asp:TextBox>
                            </td>
                            <td>
                                مترمربع
                            </td>
                            <td>

                            </td>
                            <td>

                            </td>
                        </tr>
                        <tr>
                            <td>
                                شغل :
                            </td>
                            <td>
                                <asp:DropDownList ID="DDLJob" runat="server"></asp:DropDownList>
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
                                اجاره اولیه :
                            </td>
                            <td>
                                <asp:TextBox ID="txtEjare" runat="server"></asp:TextBox>
                            </td>
                            <td>
                                ریال
                            </td>
                            <td>

                            </td>
                            <td>

                            </td>
                        </tr>
                        <tr>
                            <td>
                                قیمت هر متر مربع در زمان واگذاری :
                            </td>
                            <td>
                                <asp:TextBox ID="txtPrice" runat="server"></asp:TextBox>
                            </td>
                            <td>
                                ریال
                            </td>
                            <td>

                            </td>
                            <td>

                            </td>
                        </tr>
                        <tr>
                            <td>تاریخ تحویل :

                            </td>
                            <td>
                                <uc2:jdatecontrol runat="server" id="JDateTahvil" />
                            </td>
                            <td>

                            </td>
                            <td>

                            </td>
                            <td>

                            </td>
                        </tr>
                        <tr>
                            <td>کد تفصیلی شرکت :

                            </td>
                            <td>
                                <asp:TextBox ID="TextBox9" runat="server"></asp:TextBox>
                            </td>
                            <td>

                            </td>
                            <td>

                            </td>
                            <td>

                            </td>
                        </tr>
                        <tr>
                            <td>کد تفصیلی بازار :

                            </td>
                            <td>
                                <asp:TextBox ID="txtTafsiliCode" runat="server"></asp:TextBox>
                            </td>
                            <td>

                            </td>
                            <td>

                            </td>
                            <td>

                            </td>
                        </tr>
                   </table>
                </telerik:RadPageView>
                <telerik:RadPageView runat="server" ID="rpvD2">
                    <table>
                        <tr>
                            <td>
                                <telerik:RadGrid ID="gridT2" runat="server"></telerik:RadGrid>
                            </td>
                            <td>

                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Button ID="btnAdd" runat="server" Text="اضافه" />
                            </td>
                            <td>
                                <asp:Button ID="btnDel" runat="server" Text="حذف" />
                            </td>
                        </tr>
                   </table>
                </telerik:RadPageView>
                <telerik:RadPageView runat="server" ID="rpvD3">
                    <table>
                        <tr>
                            <td>
                                <asp:TextBox ID="TextBox11" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                   </table>
                </telerik:RadPageView>
                <telerik:RadPageView runat="server" ID="rpvD4">
                    <table>
                        <tr>
                            <td>
                                <asp:TextBox ID="TextBox12" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                   </table>
                </telerik:RadPageView>
                <telerik:RadPageView runat="server" ID="rpvD5">
                    <table>
                        <tr>
                            <td>

                            </td>
                        </tr>
                   </table>
                </telerik:RadPageView>
                <telerik:RadPageView runat="server" ID="rpvD6">
                    <table>
                        <tr>
                            <td>
                                مالکین قطعی
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <telerik:RadGrid ID="gridT6" runat="server"></telerik:RadGrid>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                مالکین سرقفلی
                            </td>
                        </tr>
                        <tr>
                            <td>
                                 <telerik:RadGrid ID="RadGridMalekin" runat="server"></telerik:RadGrid>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                مستاجرین
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <telerik:RadGrid ID="RadGridMostajer" runat="server"></telerik:RadGrid>
                            </td>
                        </tr>
                   </table>
                </telerik:RadPageView>
                <telerik:RadPageView runat="server" ID="rpvD7">
                    <table>
                        <tr>
                            <td>کد زمین :</td>
                            <td>
                                <asp:TextBox ID="txtCodeZamin" runat="server"></asp:TextBox></td>
                            <td>
                                <asp:Button ID="btnSearch" runat="server" Text="جستجو" /></td>
                            <td></td>
                            <td></td>
                            <td></td>
                            <td></td>
                        </tr>
                        <tr>
                            <td>اراضی :</td>
                            <td>
                                <asp:Label ID="lblArazi" runat="server" Text=""></asp:Label></td>
                            <td></td>
                            <td></td>
                            <td>شماره قطعه :</td>
                            <td>
                                <asp:Label ID="lblNumGhete" runat="server" Text=""></asp:Label></td>
                            <td></td>
                        </tr>
                        <tr>
                            <td>پلاک اصلی :</td>
                            <td>
                                <asp:Label ID="lblPelak" runat="server" Text=""></asp:Label></td>
                            <td></td>
                            <td></td>
                            <td>بخش :</td>
                            <td>
                                <asp:Label ID="lblBakhsh" runat="server" Text=""></asp:Label></td>
                            <td></td>
                        </tr>
                        <tr>
                            <td>پلاک فرعی :</td>
                            <td>
                                <asp:Label ID="lblPelakFari" runat="server" Text=""></asp:Label></td>
                            <td></td>
                            <td></td>
                            <td>کاربری :</td>
                            <td>
                                <asp:Label ID="lblUsage" runat="server" Text=""></asp:Label></td>
                            <td></td>
                        </tr>
                        <tr>
                            <td>شماره بلوک :</td>
                            <td>
                                <asp:Label ID="lblNumBlock" runat="server" Text=""></asp:Label></td>
                            <td></td>
                            <td></td>
                            <td>مساحت :</td>
                            <td>
                                <asp:Label ID="lblMasahat" runat="server" Text=""></asp:Label></td>
                            <td></td>
                        </tr>
                        <tr>
                            <td>شمال ها :</td>
                            <td>
                                <asp:Label ID="lblNorth" runat="server" Text=""></asp:Label></td>
                            <td></td>
                            <td></td>
                            <td></td>
                            <td></td>
                            <td></td>
                        </tr>
                        <tr>
                            <td>جنوب ها :</td>
                            <td><asp:Label ID="lblSouth" runat="server" Text=""></asp:Label></td>
                            <td></td>
                            <td></td>
                            <td></td>
                            <td></td>
                            <td></td>
                        </tr>
                        <tr>
                            <td>شرق ها :</td>
                            <td><asp:Label ID="lblEast" runat="server" Text=""></asp:Label></td>
                            <td></td>
                            <td></td>
                            <td></td>
                            <td></td>
                            <td></td>
                        </tr>
                        <tr>
                            <td>غرب ها :</td>
                            <td><asp:Label ID="lblWest" runat="server" Text=""></asp:Label></td>
                            <td></td>
                            <td></td>
                            <td></td>
                            <td></td>
                            <td></td>
                        </tr>
                   </table>
                </telerik:RadPageView>
                <telerik:RadPageView runat="server" ID="rpvD8">
                    <table>
                        <tr>
                            <td>
        <telerik:RadTabStrip ID="RadTabStrip3" runat="server" OnTabClick="RadTabStrip3_TabClick">
                <Tabs>
                    <telerik:RadTab Text="قراردادهای انتقال سرقفلی و اجاره" PageViewID="rpvDD1"></telerik:RadTab>
                </Tabs>
                <Tabs>
                    <telerik:RadTab Text="قراردادهای انتقال قطعی و صلح سرقفلی" PageViewID="rpvDD2"></telerik:RadTab>
                </Tabs>
                <Tabs>
                    <telerik:RadTab Text="سایر قراردادها" PageViewID="rpvDD3"></telerik:RadTab>
                </Tabs>
         </telerik:RadTabStrip>
            <telerik:RadMultiPage runat="server" ID="RadMultiPage3" SelectedIndex="0" RenderSelectedPageOnly="true" Width="100%">
                <telerik:RadPageView runat="server" ID="rpvDD1">
                    <table>
                        <tr>
                            <td>
                                انتقال سرقفلی 
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <uc2:jdatecontrol runat="server" id="JDateEnteghal" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                اجاره
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <uc2:jdatecontrol runat="server" id="JDateEjare" />
                            </td>
                        </tr>
                   </table>
                </telerik:RadPageView>
                <telerik:RadPageView runat="server" ID="rpvDD2">
                    <table>
                        <tr>
                            <td>
                                انتقال قطعی 
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <uc2:jdatecontrol runat="server" id="JDateEnteghalGhati" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                 اجاره و صلح سرقفلی
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <uc2:jdatecontrol runat="server" id="JDateControl4" />
                            </td>
                        </tr>
                   </table>
                </telerik:RadPageView>
                <telerik:RadPageView runat="server" ID="rpvDD3">
                    <table>
                        <tr>
                            <td>
                                <uc2:jdatecontrol runat="server" id="JDateControl5" />
                            </td>
                        </tr>
                   </table>
                </telerik:RadPageView>
                </telerik:RadMultiPage>
                            </td>
                        </tr>
                   </table>
                </telerik:RadPageView>
                </telerik:RadMultiPage>
        </td>
        <td>

        </td>
        <td>

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
            <asp:Button ID="btnOK" runat="server" Text="OK" />
        </td>
        <td>
            <asp:Button ID="btnNew" runat="server" Text="NEW" />
        </td>
        <td>
            <asp:Button ID="btnRegCon" runat="server" Text="ثبت قرارداد" />
        </td>
        <td>
            <asp:Button ID="btnUpdate" runat="server" Text="بروز رسانی" />
        </td>
        <td>

        </td>
        <td>
            <asp:Button ID="btnExit" runat="server" Text="خروج" />
        </td>
    </tr>
    </table>
