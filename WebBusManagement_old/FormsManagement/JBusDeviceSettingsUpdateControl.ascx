<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="JBusDeviceSettingsUpdateControl.ascx.cs" Inherits="WebBusManagement.FormsManagement.JBusDeviceSettingsUpdateControl" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register Src="~/WebControllers/MainControls/Grid/JGridViewControl.ascx" TagPrefix="uc1" TagName="JGridViewControl" %>
<%@ Register Src="~/WebControllers/MainControls/Date/JDateControl.ascx" TagPrefix="uc1" TagName="JDateControl" %>

<div class="BigTitle">تنظیمات اتوبوس</div>
<table style="width: 500px">
    <tr class="Table_RowB">
        <td style="width: 150px">اتوبوس:</td>
        <td>
            <telerik:RadComboBox runat="server" ID="cmbBus" Width="100%" Filter="Contains"></telerik:RadComboBox>
        </td>
    </tr>
    <tr class="Table_RowC">
        <td style="width: 150px">رمز عبور دستگاه:</td>
        <td>
            <telerik:RadTextBox runat="server" ID="txtDevicePassword" Width="100%"></telerik:RadTextBox>
        </td>
    </tr>
</table>
<telerik:RadButton runat="server" ID="btnSave" Text="بررسی اتوبوس" AutoPostBack="true" Width="100px" Height="35px" OnClick="btnSave_Click" ValidationGroup="Settings" />
<telerik:RadButton runat="server" ID="btnClose" Text="بازگشت" OnClientClicked="CloseDialog" AutoPostBack="false" Width="100px" Height="35px" />
<table style="width: 100%; height: auto; margin-top: 15px">
    <tr>
        <td style="width: 100%; height: auto; overflow: auto">
            <uc1:JGridViewControl runat="server" id="RadGridReport" />
        </td>
    </tr>
</table>
<telerik:RadTabStrip runat="server" ID="RadTabStrip1"
    SelectedIndex="0" MultiPageID="RadMultiPage1" Width="100%" TabIndex="10">
    <Tabs>
        <telerik:RadTab Text="ارسال شارژ">
        </telerik:RadTab>
        <telerik:RadTab Text="ارسال دستور">
        </telerik:RadTab>
        <telerik:RadTab Text="تغییر وضعیت رله">
        </telerik:RadTab>
        <telerik:RadTab Text="تغییرات متفرقه">
        </telerik:RadTab>
        <telerik:RadTab Text="تنظیم مرکز">
        </telerik:RadTab>
        <telerik:RadTab Text="تنظیم پارمترهای ارسال">
        </telerik:RadTab>
        <telerik:RadTab Text="تنظیم پارمترهای دریافت">
        </telerik:RadTab>
        <telerik:RadTab Text="تنظیم خط و نرخ های کرایه">
        </telerik:RadTab>
    </Tabs>
</telerik:RadTabStrip>
<telerik:RadMultiPage runat="server" ID="RadMultiPage1" SelectedIndex="0"
    Width="700px">
    <telerik:RadPageView runat="server" ID="RadPageView1">
        <table style="width: 500px; margin-top: 15px; margin-bottom: 15px">
            <tr class="Table_RowB">
                <td style="width: 150px">رمز شارژ:</td>
                <td>
                    <telerik:RadTextBox runat="server" ID="txtChargePassword" Width="100%"></telerik:RadTextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidatortxtBusCode" runat="server" Display="Dynamic"
                        ControlToValidate="txtChargePassword" ValidationGroup="SimCharge" ErrorMessage="*"></asp:RequiredFieldValidator>
                </td>
            </tr>
        </table>
        <telerik:RadButton runat="server" ID="btnSendCharge" Text="ارسال شارژ" AutoPostBack="true" Width="100px" Height="35px"
            ValidationGroup="SimCharge" />
    </telerik:RadPageView>
    <telerik:RadPageView runat="server" ID="RadPageView2">
        <table style="width: 500px; margin-top: 15px; margin-bottom: 15px">
            <tr class="Table_RowB">
                <td style="width: 150px">دستور:</td>
                <td>
                    <telerik:RadTextBox runat="server" ID="txtCommand" Width="100%"></telerik:RadTextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Display="Dynamic"
                        ControlToValidate="txtCommand" ValidationGroup="Command" ErrorMessage="*"></asp:RequiredFieldValidator>
                </td>
            </tr>
        </table>
        <telerik:RadButton runat="server" ID="btnSendCommand" Text="ارسال دستور" AutoPostBack="true" Width="100px" Height="35px"
            ValidationGroup="Command" />
    </telerik:RadPageView>
    <telerik:RadPageView runat="server" ID="RadPageView3">
        <table style="width: 500px; margin-top: 15px; margin-bottom: 15px">
            <tr class="Table_RowB">
                <td style="width: 150px">رله یک:</td>
                <td>
                    <telerik:RadComboBox runat="server" ID="cmbRele1" Width="100%">
                        <Items>
                            <telerik:RadComboBoxItem Text="روشن" Value="1" />
                            <telerik:RadComboBoxItem Text="خاموش" Value="2" />
                        </Items>
                    </telerik:RadComboBox>
                </td>
            </tr>
            <tr class="Table_RowC">
                <td style="width: 150px">رله دو:</td>
                <td>
                    <telerik:RadComboBox runat="server" ID="cmbRele2" Width="100%">
                        <Items>
                            <telerik:RadComboBoxItem Text="روشن" Value="1" />
                            <telerik:RadComboBoxItem Text="خاموش" Value="2" />
                        </Items>
                    </telerik:RadComboBox>
                </td>
            </tr>
        </table>
        <telerik:RadButton runat="server" ID="btnChangeReleStatus" Text="تغییر وضعیت رله" AutoPostBack="true" Width="100px" Height="35px" />
    </telerik:RadPageView>
    <telerik:RadPageView runat="server" ID="RadPageView4">
        <div style="margin-top: 15px">
            <telerik:RadButton runat="server" ID="BtnClearMemory" Text="پاک کردن حافظه" AutoPostBack="true" Width="100px" Height="35px" />
            <telerik:RadButton runat="server" ID="BtnResetFactory" Text="تنظیمات کارخانه" AutoPostBack="true" Width="100px" Height="35px" />
            <telerik:RadButton runat="server" ID="BtnReset" Text="ریست دستگاه" AutoPostBack="true" Width="100px" Height="35px" />
        </div>
    </telerik:RadPageView>
    <telerik:RadPageView runat="server" ID="RadPageView5">
        <table style="width: 500px; margin-top: 15px; margin-bottom: 15px">
            <tr class="Table_RowB">
                <td style="width: 150px">شماره مرکز:</td>
                <td>
                    <telerik:RadTextBox runat="server" ID="txtNumberCenter" Width="100%"></telerik:RadTextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" Display="Dynamic"
                        ControlToValidate="txtNumberCenter" ValidationGroup="NumberCenter" ErrorMessage="*"></asp:RequiredFieldValidator>
                </td>
            </tr>
        </table>
        <telerik:RadButton runat="server" ID="btnSendNumberCenter" Text="تغییر شماره مرکز" AutoPostBack="true" Width="100px" Height="35px"
            ValidationGroup="NumberCenter" />
    </telerik:RadPageView>
    <telerik:RadPageView runat="server" ID="RadPageView6">
        <table style="width: 500px; margin-top: 15px; margin-bottom: 15px">
            <tr class="Table_RowB">
                <td style="width: 150px">بازه زمانی ارسال بسته به ثانیه:</td>
                <td>
                    <telerik:RadTextBox runat="server" ID="txtSendTime" Width="100%"></telerik:RadTextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" Display="Dynamic"
                        ControlToValidate="txtSendTime" ValidationGroup="SendParametr" ErrorMessage="*"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr class="Table_RowC">
                <td style="width: 150px">بازه زمانی ارسال بسته های آفلاین:</td>
                <td>
                    <telerik:RadTextBox runat="server" ID="txtSendTimeOflinePak" Width="100%"></telerik:RadTextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" Display="Dynamic"
                        ControlToValidate="txtSendTimeOflinePak" ValidationGroup="SendParametr" ErrorMessage="*"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr class="Table_RowB">
                <td style="width: 150px">تاریخ شروع:</td>
                <td>
                    <uc1:JDateControl runat="server" id="txtSendTimeStartDate" />
                </td>
            </tr>
            <tr class="Table_RowC">
                <td style="width: 150px">تاریخ پایان:</td>
                <td>
                    <uc1:JDateControl runat="server" id="txtSendTimeEndDate" />
                </td>
            </tr>
            <tr class="Table_RowB">
                <td style="width: 150px">زمان شروع:</td>
                <td>
                    <telerik:RadTextBox runat="server" ID="txtStartTime" Width="100%"></telerik:RadTextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" Display="Dynamic"
                        ControlToValidate="txtStartTime" ValidationGroup="SendParametr" ErrorMessage="*"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr class="Table_RowC">
                <td style="width: 150px">زمان پایان:</td>
                <td>
                    <telerik:RadTextBox runat="server" ID="txtEndTime" Width="100%"></telerik:RadTextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" Display="Dynamic"
                        ControlToValidate="txtEndTime" ValidationGroup="SendParametr" ErrorMessage="*"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr class="Table_RowB">
                <td style="width: 150px">روزهای فعال:</td>
                <td>
                    <telerik:RadTextBox runat="server" ID="txtActiveDates" Width="100%"></telerik:RadTextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" Display="Dynamic"
                        ControlToValidate="txtActiveDates" ValidationGroup="SendParametr" ErrorMessage="*"></asp:RequiredFieldValidator>
                </td>
            </tr>
        </table>
        <telerik:RadButton runat="server" ID="btnSendParametr" Text="ثبت پارامترهای ارسال" AutoPostBack="true" Width="100px" Height="35px"
            ValidationGroup="SendParametr" />
    </telerik:RadPageView>
    <telerik:RadPageView runat="server" ID="RadPageView7">
        <table style="width: 500px; margin-top: 15px; margin-bottom: 15px">
            <tr class="Table_RowB">
                <td style="width: 150px">سرعت حرکت:</td>
                <td>
                    <telerik:RadTextBox runat="server" ID="txtSpeed" Width="100%"></telerik:RadTextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" Display="Dynamic"
                        ControlToValidate="txtSpeed" ValidationGroup="ReciveParametr" ErrorMessage="*"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr class="Table_RowC">
                <td style="width: 150px">ساعت شروع:</td>
                <td>
                    <telerik:RadTextBox runat="server" ID="txtReciveParametrStartTime" Width="100%"></telerik:RadTextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" Display="Dynamic"
                        ControlToValidate="txtReciveParametrStartTime" ValidationGroup="ReciveParametr" ErrorMessage="*"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr class="Table_RowB">
                <td style="width: 150px">ساعت پایان:</td>
                <td>
                    <telerik:RadTextBox runat="server" ID="txtReciveParametrEndTime" Width="100%"></telerik:RadTextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" Display="Dynamic"
                        ControlToValidate="txtReciveParametrEndTime" ValidationGroup="ReciveParametr" ErrorMessage="*"></asp:RequiredFieldValidator>
                </td>
            </tr>
        </table>
        <telerik:RadButton runat="server" ID="RadButton1" Text="ثبت پارامترهای دریافت" AutoPostBack="true" Width="100px" Height="35px"
            ValidationGroup="ReciveParametr" />
    </telerik:RadPageView>
    <telerik:RadPageView runat="server" ID="RadPageView8">
        <table style="width: 500px; margin-top: 15px; margin-bottom: 15px">
            <tr class="Table_RowB">
                <td style="width: 150px">شماره اتوبوس:</td>
                <td>
                    <telerik:RadTextBox runat="server" ID="txtBusNumber" Width="100%"></telerik:RadTextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" Display="Dynamic"
                        ControlToValidate="txtBusNumber" ValidationGroup="LineSettings" ErrorMessage="*"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr class="Table_RowC">
                <td style="width: 150px">شماره خط:</td>
                <td>
                    <telerik:RadTextBox runat="server" ID="txtLineNumber" Width="100%"></telerik:RadTextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" Display="Dynamic"
                        ControlToValidate="txtLineNumber" ValidationGroup="LineSettings" ErrorMessage="*"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr class="Table_RowB">
                <td style="width: 150px">نرخ کرایه نوع صفر:</td>
                <td>
                    <telerik:RadTextBox runat="server" ID="txtCardType0Price" Width="100%"></telerik:RadTextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" Display="Dynamic"
                        ControlToValidate="txtCardType0Price" ValidationGroup="LineSettings" ErrorMessage="*"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr class="Table_RowC">
                <td style="width: 150px">نرخ کرایه نوع یک:</td>
                <td>
                    <telerik:RadTextBox runat="server" ID="txtCardType1Price" Width="100%"></telerik:RadTextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator17" runat="server" Display="Dynamic"
                        ControlToValidate="txtCardType1Price" ValidationGroup="LineSettings" ErrorMessage="*"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr class="Table_RowB">
                <td style="width: 150px">نرخ کرایه نوع دو:</td>
                <td>
                    <telerik:RadTextBox runat="server" ID="txtCardType2Price" Width="100%"></telerik:RadTextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" Display="Dynamic"
                        ControlToValidate="txtCardType2Price" ValidationGroup="LineSettings" ErrorMessage="*"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr class="Table_RowC">
                <td style="width: 150px">نرخ کرایه نوع سه:</td>
                <td>
                    <telerik:RadTextBox runat="server" ID="txtCardType3Price" Width="100%"></telerik:RadTextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" Display="Dynamic"
                        ControlToValidate="txtCardType3Price" ValidationGroup="LineSettings" ErrorMessage="*"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr class="Table_RowB">
                <td style="width: 150px">نرخ کرایه نوع چهار:</td>
                <td>
                    <telerik:RadTextBox runat="server" ID="txtCardType4Price" Width="100%"></telerik:RadTextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" Display="Dynamic"
                        ControlToValidate="txtCardType4Price" ValidationGroup="LineSettings" ErrorMessage="*"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr class="Table_RowC">
                <td style="width: 150px">نرخ کرایه نوع پنج:</td>
                <td>
                    <telerik:RadTextBox runat="server" ID="txtCardType5Price" Width="100%"></telerik:RadTextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator18" runat="server" Display="Dynamic"
                        ControlToValidate="txtCardType5Price" ValidationGroup="LineSettings" ErrorMessage="*"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr class="Table_RowB">
                <td style="width: 150px">نرخ کرایه نوع شش:</td>
                <td>
                    <telerik:RadTextBox runat="server" ID="txtCardType6Price" Width="100%"></telerik:RadTextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator19" runat="server" Display="Dynamic"
                        ControlToValidate="txtCardType6Price" ValidationGroup="LineSettings" ErrorMessage="*"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr class="Table_RowC">
                <td style="width: 150px">نرخ کرایه نوع هفت:</td>
                <td>
                    <telerik:RadTextBox runat="server" ID="txtCardType7Price" Width="100%"></telerik:RadTextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator20" runat="server" Display="Dynamic"
                        ControlToValidate="txtCardType7Price" ValidationGroup="LineSettings" ErrorMessage="*"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr class="Table_RowB">
                <td style="width: 150px">نرخ کرایه نوع هشت:</td>
                <td>
                    <telerik:RadTextBox runat="server" ID="txtCardType8Price" Width="100%"></telerik:RadTextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator21" runat="server" Display="Dynamic"
                        ControlToValidate="txtCardType8Price" ValidationGroup="LineSettings" ErrorMessage="*"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr class="Table_RowC">
                <td style="width: 150px">نرخ کرایه نوع نه:</td>
                <td>
                    <telerik:RadTextBox runat="server" ID="txtCardType9Price" Width="100%"></telerik:RadTextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator22" runat="server" Display="Dynamic"
                        ControlToValidate="txtCardType9Price" ValidationGroup="LineSettings" ErrorMessage="*"></asp:RequiredFieldValidator>
                </td>
            </tr>
        </table>
        <telerik:RadButton runat="server" ID="btnSendLinePrice" Text="ثبت تغییرات" AutoPostBack="true" Width="100px" Height="35px"
            ValidationGroup="LineSettings" />
    </telerik:RadPageView>
</telerik:RadMultiPage>
