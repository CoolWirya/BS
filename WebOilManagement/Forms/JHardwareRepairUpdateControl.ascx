<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="JHardwareRepairUpdateControl.ascx.cs" Inherits="WebOilManagement.Forms.JHardwareRepairUpdateControl" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register Src="~/WebControllers/MainControls/CustomListSelector/JCustomListSelectorControl.ascx" TagPrefix="uc1" TagName="JCustomListSelectorControl" %>
<%@ Register Src="~/WebControllers/ArchiveDocument/JArchiveControl.ascx" TagPrefix="uc2" TagName="JArchiveControl" %>
<%@ Register Src="~/WebControllers/MainControls/Grid/JGridViewControl.ascx" TagPrefix="uc1" TagName="JGridViewControl" %>

<telerik:RadCodeBlock runat="server" ID="RadCodeBlock1" EnableViewState="false">
    <script type="text/javascript">
        function RefreshGrid() {

        }
    </script>
</telerik:RadCodeBlock>
<telerik:RadAjaxManagerProxy runat="server" ID="AjaxManagerProxy_Control">
    <AjaxSettings>
        <telerik:AjaxSetting AjaxControlID="RadMultiPage1"></telerik:AjaxSetting>
        <telerik:AjaxSetting AjaxControlID="RadTabStrip1"></telerik:AjaxSetting>
        <telerik:AjaxSetting AjaxControlID="grdHardwareRepair"></telerik:AjaxSetting>
    </AjaxSettings>
</telerik:RadAjaxManagerProxy>
<div class="FormContent">
    <div class="BigTitle">رفع خرابی سخت افزاری</div>
    <table style="width: 100%; height: auto; margin-top: 15px">
        <tr>
            <td>
                <telerik:RadTabStrip runat="server" ID="RadTabStrip1"
                    SelectedIndex="0" MultiPageID="RadMultiPage1" Width="100%">
                    <Tabs>
                        <telerik:RadTab Text="رفع خرابی سخت افزاری">
                        </telerik:RadTab>
                        <%--<telerik:RadTab Text="ارجاعات">
            </telerik:RadTab>--%>
                        <telerik:RadTab Text="ضمائم">
                        </telerik:RadTab>
                        <%--  <telerik:RadTab Text="بستن پیش از رفع خطا">
            </telerik:RadTab>--%>
                    </Tabs>
                </telerik:RadTabStrip>
                <telerik:RadMultiPage runat="server" ID="RadMultiPage1" SelectedIndex="0"
                    Width="700px">
                    <telerik:RadPageView runat="server" ID="rpvMain">
                        <table>
                            <tr>
                                <td class="Table_RowB">خرابی مربوط به دفتر جایگاه</td>
                                <td class="Table_RowC">
                                    <asp:CheckBox ID="chbIsOfficeDamage" runat="server" Checked="false" AutoPostBack="true" />
                                </td>
                            </tr>
                            <tr>
                                <td class="Table_RowB">کد واقعی خرابی:</td>
                                <td class="Table_RowC">
                                    <uc1:jcustomlistselectorcontrol runat="server" id="JCustomListSelectorControlRealTableDamageCode" />
                                </td>
                            </tr>
                            <tr>
                                <td class="Table_RowB">شماره PT:</td>
                                <td class="Table_RowC">
                                    <uc1:jcustomlistselectorcontrol runat="server" id="JCustomListSelectorControlPTCode" />
                                </td>
                            </tr>
                            <tr>
                                <td class="Table_RowB">قطعه معیوب:</td>
                                <td class="Table_RowC">
                                    <uc1:JCustomListSelectorControl runat="server" id="JCSWarGoodCrashCode" />
                                    <asp:ImageButton runat="server"  ID="btnJCSWarGoodCrash" OnClick="btnJCSWarGoodCrash_Click" ImageUrl="~\Images\Controls\menu_add.png" />
                                </td>
                            </tr>
                            <tr>
                                <td class="Table_RowB">عملیات:</td>
                                <td class="Table_RowC">
                                    <asp:RadioButtonList ID="rbIsServiced" runat="server" AutoPostBack="true"
                                         OnSelectedIndexChanged="rbIsServiced_SelectedIndexChanged">
                                        <asp:ListItem Selected="True" Text="هیچکدام" Value="0"></asp:ListItem>
                                        <asp:ListItem Selected="False" Text="سرویس" Value="1"></asp:ListItem>
                                        <asp:ListItem Selected="False" Text="تعویض" Value="2"></asp:ListItem>
                                        <asp:ListItem Selected="False" Text="عدم وجود قطعه" Value="3"></asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                            </tr>
                            <tr>
                                <td class="Table_RowB">هارد دیسک</td>
                                <td class="Table_RowC">
                                    <asp:CheckBox ID="chbHard" runat="server" Checked="false"  />
                                </td>
                            </tr>
                            <tr>
                                <td class="Table_RowB">مودم</td>
                                <td class="Table_RowC">
                                    <asp:CheckBox ID="chbModem" runat="server" Checked="false"  />
                                </td>
                            </tr>
                            <tr>
                                <td class="Table_RowB">قطعه تعویض:</td>
                                <td class="Table_RowC" runat="server" id="tdWarGoodReplaceCode">
                                    <uc1:JCustomListSelectorControl runat="server" id="JCSWarGoodReplaceCode" />
                                    <asp:ImageButton runat="server"  ID="btnJCSWarGoodReplace" OnClick="btnJCSWarGoodReplace_Click" ImageUrl="~\Images\Controls\menu_add.png" />
                                </td>
                            </tr>
                            <tr>
                                <td class="Table_RowB">کد فرم پلمپ:</td>
                                <td class="Table_RowC">
                                    <uc1:jcustomlistselectorcontrol runat="server" id="JCustomListSelectorControlFormSealCode" />
                                    <asp:ImageButton runat="server" ID="btnJOilSealFormUpdateControl" OnClick="btnJOilSealFormUpdateControl_Click" ImageUrl="~\Images\Controls\menu_add.png" />
                                </td>
                            </tr>
                           <%--  <tr>
            <td class="Table_RowB">شمارنده توتالایزر قبل از فک:</td>
            <td class="Table_RowC">
                <telerik:RadTextBox runat="server" ID="txtNumbersOfMechanicallyBeforeRemoveTheSeal" Width="90%"></telerik:RadTextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*"
                    ControlToValidate="txtNumbersOfMechanicallyBeforeRemoveTheSeal" ValidationGroup="HardwareRepair" Display="Dynamic"></asp:RequiredFieldValidator>
                <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="لطفا عدد وارد کنید" Display="Dynamic"
                    ValidationGroup="HardwareRepair" ControlToValidate="txtNumbersOfMechanicallyBeforeRemoveTheSeal" Type="Double"></asp:CompareValidator>
            </td>
        </tr>
        <tr>
            <td class="Table_RowB">شمارنده توتالایزر بعد از فک:</td>
            <td class="Table_RowC">
                <telerik:RadTextBox runat="server" ID="txtNumbersOfMechanicallyAfterRemoveTheSeal" Width="90%"></telerik:RadTextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*"
                    ControlToValidate="txtNumbersOfMechanicallyAfterRemoveTheSeal" ValidationGroup="HardwareRepair" Display="Dynamic"></asp:RequiredFieldValidator>
                <asp:CompareValidator ID="CompareValidator2" runat="server" ErrorMessage="لطفا عدد وارد کنید" Display="Dynamic"
                    ValidationGroup="HardwareRepair" ControlToValidate="txtNumbersOfMechanicallyAfterRemoveTheSeal" Type="Double"></asp:CompareValidator>
            </td>
        </tr> --%>
                            <tr>
                                <td class="Table_RowB">تخلیه اطلاعات انجام شده؟:</td>
                                <td class="Table_RowC">
                                    <asp:RadioButtonList ID="rbDischargeInformation" runat="server">
                                     <asp:ListItem Selected="True"  Text="بلــی" Value="1"></asp:ListItem>
                                     <asp:ListItem Selected="False" Text="خیــر" Value="0"></asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                            </tr>
                             <tr>
                                <td class="Table_RowB">پیکربندی انجام شد</td>
                                <td class="Table_RowC">
                                    <asp:CheckBox ID="chbIsFormated" runat="server" Checked="false"  />
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2" style="width: 100%; height: auto; overflow: auto">
                                    <uc1:JGridViewControl runat="server" id="grdHardwareRepair" />
                                </td>
                            </tr>
                        </table>
                    </telerik:RadPageView>
                    <telerik:RadPageView runat="server" ID="rpvArchive">
                        <uc2:JArchiveControl runat="server" id="JArchiveControl" />
                    </telerik:RadPageView>
                </telerik:RadMultiPage>
            </td>
        </tr>
    </table>
</div>
<div class="FormButtons">
    <telerik:RadButton runat="server" ID="btnSave" Text="ذخیره" AutoPostBack="true" Width="100px" Height="35px" OnClick="btnSave_Click" ValidationGroup="HardwareRepair" />
    <telerik:RadButton runat="server" ID="btnClose" Text="بازگشت" AutoPostBack="true" Width="100px" Height="35px" OnClick="btnClose_Click" />
</div>
