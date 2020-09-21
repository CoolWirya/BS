<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SignupControl.ascx.cs" Inherits="WebControllers.MainControls.Signup.SignupControl" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>

<style type="text/css">
    body
    {
        background-image: url('images/bg.jpg');
    }
</style>
<telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server">
    <table style="width: 100%">
        <tr>
            <td></td>
            <td style="width: 700px;background-color:#dfe9f5">
                <p class="MediumTitle Shaddow">ثبت نام</p>
                <div style="width: 100%">
                    <telerik:RadTabStrip runat="server" ID="RadTabStrip1"
                        SelectedIndex="0" MultiPageID="RadMultiPage1" Enabled="false" Width="100%">
                        <Tabs>
                            <telerik:RadTab Text="مرحله 1 - شروع" Visible="true">
                            </telerik:RadTab>
                            <telerik:RadTab Text="مرحله 2 - تکمیل اطلاعات با استفاده از کد سهامداری" Visible="false">
                            </telerik:RadTab>
                            <telerik:RadTab Text="مرحله 2 - تکمیل اطلاعات" Visible="false">
                            </telerik:RadTab>
                            <telerik:RadTab Text="مرحله 3 - پایان" Visible="false">
                            </telerik:RadTab>
                        </Tabs>
                    </telerik:RadTabStrip>
                    <div style="text-align: justify; width: 100%; background-color: #fbfdff; padding-top: 20px">
                        <telerik:RadMultiPage runat="server" ID="RadMultiPage1" SelectedIndex="0"
                            Width="700px">
                            <telerik:RadPageView runat="server" ID="RadPageView1">
                                <asp:Label ID="Label1" runat="server" Text="آیا در شرکت طراحان سامانه ایده پویا کد سهامداری دارید؟"></asp:Label><br />
                                <br />
                                <asp:RadioButton ID="rbnShareCodeYes" GroupName="A" runat="server" Text="کد سهامداری دارم" /><br />
                                <br />
                                <asp:RadioButton ID="rbnShareCodeNo" GroupName="A" runat="server" Text="کد سهامداری ندارم" /><br />
                                <br />
                                <div style="text-align: center; margin-top: 30px">
                                    <telerik:RadButton ID="btnNext1" runat="server" Text="ادامه" OnClick="btnNext1_Click" Width="130" Height="50" />
                                </div>
                            </telerik:RadPageView>
                            <telerik:RadPageView runat="server" ID="RadPageView2">
                                <table style="width: 100%">
                                    <tr>
                                        <td style="width: 200px">کد سهامداری:</td>
                                        <td>
                                            <telerik:RadTextBox runat="server" ID="txtShareCode" ValidateRequestMode="Enabled" InputType="Number"></telerik:RadTextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 200px">کد ملی:</td>
                                        <td>
                                            <telerik:RadTextBox runat="server" ID="txtCodeMelli" InputType="Number"></telerik:RadTextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 200px">شماره موبایل:</td>
                                        <td>
                                            <telerik:RadTextBox runat="server" ID="txtMobile"></telerik:RadTextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 200px">نام کاربری انتخابی:</td>
                                        <td>
                                            <telerik:RadTextBox runat="server" ID="txtUsername"></telerik:RadTextBox>
                                        </td>
                                    </tr>
                                </table>
                                <div style="text-align: center; margin-top: 30px">
                                    <telerik:RadButton ID="btnNext2" runat="server" Text="تکمیل ثبت نام" OnClick="btnNext2_Click" Width="130" Height="50" />
                                </div>
                            </telerik:RadPageView>
                            <telerik:RadPageView runat="server" ID="RadPageView3">
                                <table style="width: 100%">
                                    <tr>
                                        <td style="width: 200px">نام:</td>
                                        <td>
                                            <telerik:RadTextBox runat="server" ID="txtNoFirstName"></telerik:RadTextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 200px">نام خانوادگی:</td>
                                        <td>
                                            <telerik:RadTextBox runat="server" ID="txtNoLastName"></telerik:RadTextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 200px">نام پدر:</td>
                                        <td>
                                            <telerik:RadTextBox runat="server" ID="txtFatherName"></telerik:RadTextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 200px">کد ملی:</td>
                                        <td>
                                            <telerik:RadTextBox runat="server" ID="txt"></telerik:RadTextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 200px">شماره شناسنامه:</td>
                                        <td>
                                            <telerik:RadTextBox runat="server" ID="RadTextBox8"></telerik:RadTextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 200px">شماره ثابت:</td>
                                        <td>
                                            <telerik:RadTextBox runat="server" ID="RadTextBox3"></telerik:RadTextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 200px">شماره موبایل:</td>
                                        <td>
                                            <telerik:RadTextBox runat="server" ID="RadTextBox6"></telerik:RadTextBox>
                                            (در ورود )
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 200px">نام کاربری انتخابی:</td>
                                        <td>
                                            <telerik:RadTextBox runat="server" ID="RadTextBox7"></telerik:RadTextBox>
                                        </td>
                                    </tr>
                                </table>
                                <div style="text-align: center; margin-top: 30px">
                                    <telerik:RadButton ID="btnNext3" runat="server" Text="تکمیل ثبت نام" OnClick="btnNext3_Click" Width="130" Height="50" />
                                </div>
                            </telerik:RadPageView>
                            <telerik:RadPageView runat="server" ID="RadPageView4">
                                مراحل ثبت نام با موفقیت به پایان رسید. <br />
                                کلمه عبور جهت ورود به سایت به تلفن همراه شما فرستاده شد.<br />
                            </telerik:RadPageView>
                        </telerik:RadMultiPage>
                    </div>
                </div>

            </td>
            <td></td>
        </tr>
    </table>
</telerik:RadAjaxPanel>

