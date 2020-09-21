<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ReportContractFromControl.ascx.cs" Inherits="WebRealEstate.Building.Report.ReportContractFromControl" %>
<%@ Register Assembly="JJson" Namespace="JJson.Controls" TagPrefix="JJson" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register Src="~/WebControllers/MainControls/Grid/JGridViewControl.ascx" TagPrefix="uc1" TagName="JGridViewControl" %>
<%@ Register Src="~/WebControllers/MainControls/Date/JDateControl.ascx" TagPrefix="uc1" TagName="JDateControl" %>
<%@ Register Src="~/WebControllers/MainControls/Date/JDateControl.ascx" TagPrefix="uc1" TagName="JDateControl" %>
<%@ Register Src="~/WebControllers/MainControls/Date/JDateControl.ascx" TagPrefix="uc1" TagName="JDateControl" %>
<%@ Register Src="~/WebControllers/MainControls/Date/JDateControl.ascx" TagPrefix="uc1" TagName="JDateControl" %>
<%@ Register Src="~/WebControllers/MainControls/Persons/JSearchPersonControl.ascx" TagPrefix="uc1" TagName="JSearchPersonControl" %>
<%@ Register Src="~/WebControllers/MainControls/Grid/JGridViewControl.ascx" TagPrefix="uc1" TagName="JGridViewControl" %>







<table>
    <tr>
        <td>
            <telerik:RadTabStrip ID="RadTabStrip1" runat="server" OnTabClick="RadTabStrip1_TabClick">
                <Tabs>
                    <telerik:RadTab Text="قرارداد" PageViewID="rpvU1"></telerik:RadTab>
                </Tabs>
                <Tabs>
                    <telerik:RadTab Text="مالک" PageViewID="rpvU2"></telerik:RadTab>
                </Tabs>
                <Tabs>
                    <telerik:RadTab Text="طرف قرارداد" PageViewID="rpvU3"></telerik:RadTab>
                </Tabs>
                <Tabs>
                    <telerik:RadTab Text="واحد تجاری" PageViewID="rpvU4"></telerik:RadTab>
                </Tabs>
            </telerik:RadTabStrip>
            <telerik:RadMultiPage runat="server" ID="RadMultiPage1" SelectedIndex="0" RenderSelectedPageOnly="true" Width="100%">
                <telerik:RadPageView runat="server" ID="rpvU1">
                    <table>
                        <tr>
                            <td>شماره قرارداد :</td>
                            <td>
                                <JJson:JJsonNumericTextBox ID="JJsonNumericTextBox1" runat="server" Event="textchange"></JJson:JJsonNumericTextBox></td>
                            <td> الی</td>
                            <td>
                                <JJson:JJsonNumericTextBox ID="JJsonNumericTextBox2" runat="server" Event="textchange"></JJson:JJsonNumericTextBox></td>
                            <td>تاریخ شروع قرارداد :</td>
                            <td>
                                <uc1:jdatecontrol runat="server" id="JDateControl1" /> </td>
                            <td>الی </td>
                            <td>
                                <uc1:jdatecontrol runat="server" id="JDateControl2" /> </td>
                            <td>وضعیت قرداد</td>
                            <td></td>
                        </tr>
                        <tr>
                            <td>نوع قرارداد :</td>
                            <td>
                                <asp:DropDownList ID="DropDownList1" runat="server"></asp:DropDownList></td>
                            <td>تاریخ اتمام قرارداد</td>
                            <td>
                                <uc1:jdatecontrol runat="server" id="JDateControl" />
                            </td>
                            <td>الی</td>
                            <td>
                                <uc1:jdatecontrol runat="server" id="JDateControl3" />
                            </td>
                            <td></td>
                            <td></td>
                            <td></td>
                            <td>
                                <asp:CheckBoxList ID="CheckBoxList1" runat="server"></asp:CheckBoxList></td>
                        </tr>
                        <tr>
                            <td>
                                <asp:CheckBox ID="CheckBox1" runat="server" /></td>
                            <td></td>
                            <td></td>
                            <td></td>
                            <td></td>
                            <td></td>
                            <td></td>
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
                                <uc1:jsearchpersoncontrol runat="server" id="JSearchPersonControl" />
                            </td>
                            <td>
                                نوع مالکیت :
                            </td>
                            <td>
                                نوع دارایی :
                            </td>
                            </tr>
                        <tr>
                            <td>
     
                            </td>
                            <td>
                                <asp:CheckBoxList ID="CheckBoxList2" runat="server"></asp:CheckBoxList>
                            </td>
                            <td>
                                <asp:CheckBoxList ID="CheckBoxList3" runat="server"></asp:CheckBoxList>
                            </td>
                            </tr>
                        </tr>
                    </table>
                </telerik:RadPageView>
                <telerik:RadPageView runat="server" ID="rpvU3">
                    <table>
                        <tr>
                            <td>
                                <uc1:jsearchpersoncontrol runat="server" id="JSearchPersonControl1" />
                            </td>
                            <td>
                                طرف قرارداد :
                            </td>

                            </tr>
                        <tr>
                            <td>
     
                            </td>
                            <td>
                                <asp:CheckBoxList ID="CheckBoxList4" runat="server"></asp:CheckBoxList>
                            </td>

                            </tr>
                        </tr>
                    </table>
                </telerik:RadPageView>
                <telerik:RadPageView runat="server" ID="rpvU4">
                    <table>
                        <tr>
                         <td>نام مجتمع/بازار :</td>
                            <td>
                                <asp:DropDownList ID="DropDownList2" runat="server"></asp:DropDownList></td>
                            <td></td>
                            <td>متراژ :</td>
                            <td>
                                <JJson:JJsonTextBox ID="JJsonTextBox1" runat="server" Event="textchange"></JJson:JJsonTextBox></td>
                            <td>الی</td>
                            <td>
                                <JJson:JJsonTextBox ID="JJsonTextBox2" runat="server" Event="textchange"></JJson:JJsonTextBox></td>
                        </tr>
                        <tr>
                         <td>طبقه :</td>
                            <td>
                                <asp:DropDownList ID="DropDownList3" runat="server"></asp:DropDownList></td>
                            <td></td>
                            <td>متراژ بالکن : </td>
                            <td>
                                <JJson:JJsonTextBox ID="JJsonTextBox3" runat="server" Event="textchange"></JJson:JJsonTextBox></td>
                            <td>الی</td>
                            <td>
                                <JJson:JJsonTextBox ID="JJsonTextBox4" runat="server" Event="textchange"></JJson:JJsonTextBox></td> 
                        </tr>
                        <tr>
                            <td>شماره شناسایی :</td>
                            <td>
                                <JJson:JJsonTextBox ID="JJsonTextBox5" runat="server" Event="textchange"></JJson:JJsonTextBox></td>
                            <td></td>
                            <td></td>
                            <td></td>
                            <td></td>
                            <td></td>
                        </tr>
                        <tr>
                            <td>شماره واحد :</td>
                            <td>
                                <JJson:JJsonTextBox ID="JJsonTextBox6" runat="server" Event="textchange"></JJson:JJsonTextBox></td>
                            <td></td>
                            <td></td>
                            <td></td>
                            <td></td>
                            <td></td>
                        </tr>
                        <tr>
                            <td>پلاک ثبتی :</td>
                            <td>
                                <JJson:JJsonTextBox ID="JJsonTextBox7" runat="server" Event="textchange"></JJson:JJsonTextBox></td>
                            <td></td>
                            <td></td>
                            <td></td>
                            <td></td>
                            <td></td>
                        </tr>
                    </table>
                </telerik:RadPageView>
            </telerik:RadMultiPage>
        </td>
    </tr>
    <tr>
        <td>
            <telerik:RadTabStrip ID="RadTabStrip2" runat="server" OnTabClick="RadTabStrip1_TabClick">
                <Tabs>
                    <telerik:RadTab Text="همه قراردادها" PageViewID="rpvD1"></telerik:RadTab>
                </Tabs>
                <Tabs>
                    <telerik:RadTab Text="قراردادهای فعال" PageViewID="rpvD2"></telerik:RadTab>
                </Tabs>
                <Tabs>
                    <telerik:RadTab Text="طرفین قرارداد" PageViewID="rpvD3"></telerik:RadTab>
                </Tabs>
                <Tabs>
                    <telerik:RadTab Text="واحد تجاری" PageViewID="rpvD4"></telerik:RadTab>
                </Tabs>
            </telerik:RadTabStrip>
            <telerik:RadMultiPage runat="server" ID="RadMultiPage2" SelectedIndex="0" RenderSelectedPageOnly="true" Width="100%">
                <telerik:RadPageView runat="server" ID="rpvD1">
                    <div>
                        <uc1:jgridviewcontrol runat="server" id="JGridViewControl" />
                    </div>
                </telerik:RadPageView>
                <telerik:RadPageView runat="server" ID="rpvD2">
                    <div><uc1:jgridviewcontrol runat="server" id="JGridViewControl1" />
                    </div>
                </telerik:RadPageView>
                <telerik:RadPageView runat="server" ID="rpvD3">
                    <div><uc1:jgridviewcontrol runat="server" id="JGridViewControl2" />
                    </div>
                </telerik:RadPageView>
                <telerik:RadPageView runat="server" ID="rpvD4">
                    <div><uc1:jgridviewcontrol runat="server" id="JGridViewControl3" />
                    </div>
                </telerik:RadPageView>
            </telerik:RadMultiPage>
        </td>
    </tr>
    <tr>
        <td>
            <JJson:JJsonButton ID="JJsonButton1" runat="server" Event="click" Text="گزارش" /></td>
        <td>
            <JJson:JJsonButton ID="JJsonButton2" runat="server" Event="click" Text="چاپ" /></td>
        <td>
            <JJson:JJsonButton ID="JJsonButton3" runat="server" Event="click" Text="Clear" /></td>
    </tr>
</table>
