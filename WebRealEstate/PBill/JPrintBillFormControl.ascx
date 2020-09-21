<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="JPrintBillFormControl.ascx.cs" Inherits="WebRealEstate.PBill.JPrintBillFormControl" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AggregateFormControl.ascx.cs" Inherits="WebRealEstate.Building.UnitBuild.Aggregate.AggregateFormControl" %>
<%@ Register Assembly="JJson" Namespace="JJson.Controls" TagPrefix="JJson" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register Src="~/WebControllers/MainControls/Grid/JGridViewControl.ascx" TagPrefix="uc1" TagName="JGridViewControl" %>
<%@ Register Src="~/WebControllers/MainControls/Date/JDateControl.ascx" TagPrefix="uc1" TagName="JDateControl" %>
<%@ Register Src="~/WebControllers/MainControls/Persons/JSearchPersonControl.ascx" TagPrefix="uc1" TagName="JSearchPersonControl" %>
<%@ Register Src="~/WebControllers/MainControls/Grid/JGridViewControl.ascx" TagPrefix="uc1" TagName="JGridViewControl" %>
<%@ Register Src="~/WebControllers/MainControls/Date/JDateControl.ascx" TagPrefix="uc1" TagName="JDateControl" %>
<%@ Register Src="~/WebControllers/MainControls/Grid/JGridViewControl.ascx" TagPrefix="uc1" TagName="JGridViewControl" %>
<%@ Register Src="~/WebControllers/MainControls/Date/JDateControl.ascx" TagPrefix="uc2" TagName="JDateControl" %>


<table>
    <tr>
        <td>
            <telerik:RadTabStrip ID="RadTabStrip1" runat="server" OnTabClick="RadTabStrip1_TabClick">
                <Tabs>
                    <telerik:RadTab Text="صدور قبض شارژ" PageViewID="rpvU1"></telerik:RadTab>
                </Tabs>
                <Tabs>
                    <telerik:RadTab Text="اطلاعات شارژ واحدهای اداری" PageViewID="rpvU2"></telerik:RadTab>
                </Tabs>
                <Tabs>
                    <telerik:RadTab Text="قبض های صادر شده" PageViewID="rpvU3"></telerik:RadTab>
                </Tabs>
                <Tabs>
                    <telerik:RadTab Text="تنظیمات" PageViewID="rpvU4"></telerik:RadTab>
                </Tabs>
            </telerik:RadTabStrip>
            <telerik:RadMultiPage runat="server" ID="RadMultiPage1" SelectedIndex="0" RenderSelectedPageOnly="true" Width="100%">
                <telerik:RadPageView runat="server" ID="rpvU1">
                    <table>
                        <tr>
                            <td>
                                <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                            </td>
                            <td></td>
                            <td></td>
                            <td></td>
                        </tr>
                        <tr>
                            <td>آخرین مهلت پرداخت :
                            </td>
                            <td>
                                <uc2:jdatecontrol runat="server" id="JDLastPay" />
                            </td>
                            <td></td>
                            <td></td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Button ID="btnEnterManager" runat="server" Text="ورود به قسمت مدیریت چاپ" />
                            </td>
                            <td></td>
                            <td></td>
                            <td></td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Button ID="btnSodoorGhabz" runat="server" Text="صدور قبض شارژ" />
                            </td>
                            <td></td>
                            <td></td>
                            <td></td>
                        </tr>
                    </table>
                </telerik:RadPageView>
                <telerik:RadPageView runat="server" ID="rpvU2">
                    <table>
                        <tr>
                            <td>
                                <asp:Button ID="btnUpdateMali" runat="server" Text="به روز رسانی اطلاعات مالی" />
                            </td>
                        </tr>
                    </table>
                </telerik:RadPageView>
                <telerik:RadPageView runat="server" ID="rpvU3">
                    <table>
                        <tr>
                            <td>عملیات بر روی قبض های صادر شده:
                            </td>
                            <td></td>
                            <td></td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Button ID="btnPrintGhabz" runat="server" Text="چاپ قبوض صادر شده" />
                            </td>
                            <td>
                                <asp:Button ID="btnDelAllGhabz" runat="server" Text="حذف قبوض" />
                            </td>
                            <td>
                                <asp:Button ID="btnDelPriceZero" runat="server" Text="حذف قبض های مبلغ صفر" />
                            </td>
                        </tr>
                    </table>

                </telerik:RadPageView>
                <telerik:RadPageView runat="server" ID="rpvU4">
                    <table>
                        <tr>
                            <td>
                                <asp:CheckBox ID="chkBoxBedehi" runat="server" Text="کسر بدهی جاری" />
                            </td>
                            <td>

                            </td>
                            <td></td>
                        </tr>
                        <tr>
                        <td>
 <asp:CheckBox ID="JchkBoxGhabz" runat="server" Text="عدم صدور قبض برای غرفه هایی که حق شارژ تعیین نگردیده است" />
                        </td>
                        <td>

                        </td>
                        <td>

                        </td>
                        
                        </tr>
                        <tr>
                            <td>
آدرس فایل اکسل بدهی ها
                        </td>
                        <td>
                            <asp:TextBox ID="txtAddExcel" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            <asp:Button ID="btnSrch" runat="server" Text="جستجو" />
                        </td>
                        </tr>
                    </table>
                </telerik:RadPageView>
            </telerik:RadMultiPage>
        </td>
    </tr>
    <tr>
        <td>انتخاب عملیات</td>
        <td></td>
        <td></td>
        <td></td>
        <td></td>
        <td></td>
        <td></td>
        <td></td>
        <td></td>

    </tr>
    <tr>
        <td>مجتمع</td>
        <td>
            <asp:DropDownList ID="DDLMojtamae" runat="server"></asp:DropDownList></td>
        <td>سال</td>
        <td>
            <asp:DropDownList ID="DDLYear" runat="server"></asp:DropDownList></td>
        <td>ماه</td>
        <td>
            <asp:DropDownList ID="DDLMonth" runat="server"></asp:DropDownList></td>
        <td> از شماره :</td>
        <td>
            <asp:DropDownList ID="DDLFromNum" runat="server"></asp:DropDownList></td>
        <td></td>

    </tr>
    <tr>
        <td></td>
        <td></td>
        <td></td>
        <td></td>
        <td></td>
        <td></td>
        <td>تا شماره :</td>
        <td>
            <asp:DropDownList ID="JDDLtoNum" runat="server"></asp:DropDownList></td>
        <td>
            <asp:Button ID="btnSearch" runat="server" Text="جستجو" /></td>

    </tr>

</table>
