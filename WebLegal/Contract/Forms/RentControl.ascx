<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="RentControl.ascx.cs" Inherits="WebLegal.Contract.Forms.RentControl" %>
<%@ Register Assembly="JJson" Namespace="JJson.Controls" TagPrefix="JJson" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register Src="http://localhost:8099/WebControllers/MainControls/Date/JDateControl.ascx" TagPrefix="uc1" TagName="JDateControl" %>

<table>
    <tr>
        <td>
            <telerik:RadTabStrip ID="RadTabStrip1" runat="server" OnTabClick="RadTabStrip1_TabClick">
                <Tabs>
                    <telerik:RadTab Text="اطلاعات اجاره" PageViewID="Tab1"></telerik:RadTab>
                </Tabs>
                <Tabs>
                    <telerik:RadTab Text="پرداخت هزینه ها" PageViewID="Tab2"></telerik:RadTab>
                </Tabs>
                 </telerik:RadTabStrip>
            <telerik:RadMultiPage runat="server" ID="RadMultiPage1" SelectedIndex="0" RenderSelectedPageOnly="true" Width="100%">
                <telerik:RadPageView runat="server" ID="Tab1">
                    <table>
                        <tr>
                            <td>
                                مدت اجاره :
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
                                از تاریخ :
                            </td>
                            <td>
                                <uc1:jdatecontrol runat="server" id="txtStartDate" />
                            </td>
                            <td>

                            </td>
                            <td>
                                الی تاریخ :
                            </td>
                            <td>
                                 <uc1:jdatecontrol runat="server" id="txtEndDate" />
                            </td>
                            <td>

                            </td>
                        </tr>
                        <tr>
                            <td>
                                مدت قرارداد به ماه :
                            </td>
                            <td>
                                <JJson:JJsonTextBox ID="txtMonth" runat="server" Event="textchange"></JJson:JJsonTextBox>
                            </td>
                            <td>

                            </td>
                            <td>
                                مدت قرارداد به روز :
                            </td>
                            <td>
                                 <JJson:JJsonTextBox ID="txtDays" runat="server" Event="textchange"></JJson:JJsonTextBox>
                            </td>
                            <td>

                            </td>
                        </tr>
                        <tr>
                            <td>
                                اجاره بهاء :
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
                                
                            </td>
                            <td>
                                شغل :
                                
                            </td>
                            <td>
                                <asp:DropDownList ID="cmbJobs" runat="server"></asp:DropDownList>
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
                                اجاره ماهیانه :
                            </td>
                            <td>
                                <JJson:JJsonTextBox ID="txtPrice" runat="server" Event="textchange"></JJson:JJsonTextBox>
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

                            </td>
                            <td>
                                مبلغ قرض الحسنه :
                            </td>
                            <td>
                                <JJson:JJsonTextBox ID="txtGh" runat="server" Event="textchange"></JJson:JJsonTextBox>
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

                            </td>
                            <td>
                                مبلغ شارژ ماهانه :
                            </td>
                            <td>
                                <JJson:JJsonTextBox ID="txtSharj" runat="server" Event="textchange"></JJson:JJsonTextBox>
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

                            </td>
                            <td>
                                مبلغ حق التحریر :
                            </td>
                            <td>
                                <JJson:JJsonTextBox ID="txtTahrirPrice" runat="server" Event="textchange"></JJson:JJsonTextBox>
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

                            </td>
                            <td>
                                جریمه بابت اجرت المثل از طرف مستاجر:
                            </td>
                            <td>
                                 <JJson:JJsonTextBox ID="txtFineT2" runat="server" Event="textchange"></JJson:JJsonTextBox>
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

                            </td>
                            <td>
                                جریمه بابت اجرت المثل از طرف موجر:
                            </td>
                            <td>
                                <JJson:JJsonTextBox ID="txtFineT1" runat="server" Event="textchange"></JJson:JJsonTextBox>
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
                                توضیحات قرارداد اجاره :
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
                                <asp:TextBox ID="txtDesc" runat="server"></asp:TextBox>
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
                    </table>
                    </telerik:RadPageView>
                <telerik:RadPageView runat="server" ID="Tab2">
                    <table>
                        <tr>
                            <td>
                                حق شارژ بر عهده :
                            </td>
                            <td>

                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:RadioButton ID="rbBuyer" runat="server"  Text="مستاجر"/>
                            </td>
                            <td>

                            </td>
                        </tr>
                        <tr>
                            <td>
                                 <asp:RadioButton ID="rbSeller" runat="server"  Text="موجر"/>
                            </td>
                            <td>

                            </td>
                        </tr>
                        <tr>
                            <td>
                                 <asp:RadioButton ID="rbBoth" runat="server"  Text="دو طرف"/>
                            </td>
                            <td>

                            </td>
                        </tr>
                        <tr>
                            <td>

                            </td>
                            <td>

                            </td>
                        </tr>
                        <tr>
                            <td>
                                حق التحریر بر عهده :
                            </td>
                            <td>

                            </td>
                        </tr>
                        <tr>
                            <td>
                                 <asp:RadioButton ID="rbTahrirBuyer" runat="server"  Text="مستاجر"/>
                            </td>
                            <td>

                            </td>
                        </tr>
                        <tr>
                            <td>
                                 <asp:RadioButton ID="rbTahrirSeller" runat="server"  Text="موجر"/>
                            </td>
                            <td>

                            </td>
                        </tr>
                        <tr>
                            <td>
                                 <asp:RadioButton ID="rbTahrirBoth" runat="server"  Text="دو طرف"/>
                            </td>
                            <td>

                            </td>
                        </tr>
                        <tr>
                            <td>
                                حق مالیات بر مستغلات بر عهده :
                            </td>
                            <td>

                            </td>
                        </tr>
                        <tr>
                            <td>
                                 <asp:RadioButton ID="rbTaxBuyer" runat="server"  Text="مستاجر"/>
                            </td>
                            <td>

                            </td>
                        </tr>
                        <tr>
                            <td>
                                 <asp:RadioButton ID="rbTaxSeller" runat="server"  Text="موجر"/>
                            </td>
                            <td>

                            </td>
                        </tr>
                        <tr>
                            <td>
                                 <asp:RadioButton ID="rbTaxBoth" runat="server"  Text="دو طرف"/>
                            </td>
                            <td>

                            </td>
                        </tr>
                        <tr>
                            <td>
                                حق مالیات بر درآمد بر عهده :
                            </td>
                            <td>

                            </td>
                        </tr>
                        <tr>
                            <td>
                                 <asp:RadioButton ID="rbIncomeBuyer" runat="server"  Text="مستاجر"/>
                            </td>
                            <td>

                            </td>
                        </tr>
                        <tr>
                            <td>
                                 <asp:RadioButton ID="rbIncomeSeller" runat="server"  Text="موجر"/>
                            </td>
                            <td>

                            </td>
                        </tr>
                        <tr>
                            <td>
                                 <asp:RadioButton ID="rbIncomeBoth" runat="server"  Text="دو طرف"/>
                            </td>
                            <td>

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
    </tr>
    <tr>
        <td>
            <JJson:JJsonButton ID="btnNext" runat="server" Event="click" text="بعدی"/>
        </td>
        <td>
              <JJson:JJsonButton ID="btnBack" runat="server" Event="click" text="قبلی"/>
        </td>
        <td>

        </td>
        <td>
              <JJson:JJsonButton ID="btnCancel" runat="server" Event="click" text="انصراف"/>
        </td>
    </tr>
</table>
