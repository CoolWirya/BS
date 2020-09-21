<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="JLegalPersonUpdateControl.ascx.cs" Inherits="WebBaseDefine.Forms.JLegalPersonUpdateControl" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register Src="~/WebControllers/MainControls/Date/JDateControl.ascx" TagPrefix="uc1" TagName="JDateControl" %>
<%@ Register Src="~/WebControllers/ArchiveDocument/JArchiveControl.ascx" TagPrefix="uc1" TagName="JArchiveControl" %>
<%@ Register Src="~/WebControllers/Property/JPropertyViewControl.ascx" TagPrefix="uc1" TagName="JPropertyViewControl" %>
<%@ Register Assembly="WebControllers" Namespace="WebControllers.MainControls.Grid" TagPrefix="cc1" %>

<style type="text/css">
    .KeyCol {
        width: 100px;
    }
</style>
<div class="FormContent">
    <div>
        <table style="width: 100%">
            <tr>
                <td class="KeyCol Table_RowC">کد:</td>
                <td class="Table_RowC">
                    <telerik:RadTextBox runat="server" ID="txtCode" ReadOnly="true"></telerik:RadTextBox></td>
                <td class="KeyCol Table_RowB">محل ثبت:</td>
                <td class="Table_RowB">
                    <telerik:RadComboBox ID="cmbRegisterPlace" runat="server" Filter="Contains"></telerik:RadComboBox>
                </td>
            </tr>
            <tr>
                <td class="KeyCol Table_RowB">نام موسسه:</td>
                <td class="Table_RowB">
                    <telerik:RadTextBox ID="txtInstituteName" runat="server"></telerik:RadTextBox></td>
                <td class="KeyCol Table_RowC">موضوع:</td>
                <td class="Table_RowC">
                    <telerik:RadTextBox runat="server" ID="txtSubject"></telerik:RadTextBox>
                </td>
            </tr>
            <tr>
                <td class="KeyCol Table_RowC">شماره ثبت:</td>
                <td class="Table_RowC">
                    <telerik:RadTextBox ID="txtRegisterNumber" runat="server"></telerik:RadTextBox></td>
                <td class="KeyCol Table_RowB">نوع:</td>
                <td class="Table_RowB">
                    <telerik:RadComboBox runat="server" ID="cmbType" Filter="Contains"></telerik:RadComboBox>
                </td>
            </tr>
            <tr>
                <td class="KeyCol Table_RowB">کد اقتصادی:</td>
                <td class="Table_RowB">
                    <telerik:RadTextBox ID="txtCommercialCode" runat="server"></telerik:RadTextBox></td>
                <td class="KeyCol Table_RowC">تاریخ ثبت:</td>
                <td class="Table_RowC">
                    <uc1:JDateControl runat="server" id="txtRegisterDate" />
                </td>
            </tr>
            <tr>
                <td class="KeyCol Table_RowC">سایر توضیحات:</td>
                <td class="Table_RowC">
                    <telerik:RadTextBox ID="txtDescription" runat="server" TextMode="MultiLine" Rows="3"></telerik:RadTextBox></td>
                <td class="KeyCol Table_RowB">کد تفصیلی:</td>
                <td class="Table_RowB">
                    <telerik:RadTextBox ID="txtTafsiliCode" runat="server"></telerik:RadTextBox></td>
                </td>
            </tr>
            <tr>
                <td class="KeyCol Table_RowB">شماره سهامدار:</td>
                <td class="Table_RowB">
                    <telerik:RadTextBox ID="txtShareHolderCode" TextMode="MultiLine" Rows="3" runat="server"></telerik:RadTextBox></td>
                <td class="KeyCol Table_RowC">شناسه ملی:</td>
                <td class="Table_RowC">
                    <telerik:RadTextBox ID="txtNationalCode" runat="server"></telerik:RadTextBox></td>
            </tr>
        </table>
        وضعیت موسسه/شرکت:
            <table style="width: 100%">
                <tr>
                    <td class="Table_RowC">
                        <asp:RadioButton ID="rbnCompanyStateActive" runat="server" GroupName="A" Text="فعال" /></td>
                    <td class="Table_RowC">
                        <asp:RadioButton ID="rbnCompanyStateInactive" runat="server" GroupName="A" Text="غیرفعال" /></td>
                    <td class="Table_RowB">
                        <asp:RadioButton ID="rbnCompanyStateBankrupt" runat="server" GroupName="A" Text="ورشکسته" /></td>
                    <td class="Table_RowB">
                        <asp:RadioButton ID="rbnCompanyStateDissolved" runat="server" GroupName="A" Text="منحل شده" /></td>
                </tr>
            </table>
    </div>
    <telerik:RadTabStrip runat="server" ID="RadTabStrip1"
        SelectedIndex="0" MultiPageID="RadMultiPage1" Width="100%">
        <Tabs>
            <telerik:RadTab Text="اقامتگاه">
            </telerik:RadTab>
            <telerik:RadTab Text="صاحبان امضاء مجاز">
            </telerik:RadTab>
            <telerik:RadTab Text="تصاویر">
            </telerik:RadTab>
            <telerik:RadTab Text="دارائی ها">
            </telerik:RadTab>
            <telerik:RadTab Text="سابقه قراردادها">
            </telerik:RadTab>
            <telerik:RadTab Text="ویژگی های شخص">
            </telerik:RadTab>
        </Tabs>
    </telerik:RadTabStrip>
    <p></p>
    <telerik:RadMultiPage runat="server" ID="RadMultiPage1" SelectedIndex="0"
        Width="700px">
        <telerik:RadPageView runat="server" ID="RadPageView1">
            آدرس:&nbsp;
        <telerik:RadTextBox runat="server" ID="txtHomeAddress" TextMode="MultiLine" Rows="2" Columns="45"></telerik:RadTextBox>
            <table>
                <tr>
                    <td class="KeyCol Table_RowB">شهر:</td>
                    <td class="Table_RowB">
                        <telerik:RadComboBox runat="server" ID="cmbHomeCity" Filter="Contains"></telerik:RadComboBox>
                    </td>
                    <td class="KeyCol Table_RowC">کد پستی</td>
                    <td class="Table_RowC">
                        <telerik:RadTextBox ID="txtHomePostalCode" runat="server"></telerik:RadTextBox></td>
                </tr>
                <tr>
                    <td class="KeyCol Table_RowB">تلفن:</td>
                    <td class="Table_RowB">
                        <telerik:RadTextBox ID="txtHomeTel" runat="server"></telerik:RadTextBox></td>
                    <td class="KeyCol Table_RowC">فکس:</td>
                    <td class="Table_RowC">
                        <telerik:RadTextBox ID="txtHomeFax" runat="server"></telerik:RadTextBox></td>
                </tr>
                <tr>
                    <td class="KeyCol Table_RowB">سایت:</td>
                    <td class="Table_RowB">
                        <telerik:RadTextBox ID="txtHomeWebsite" runat="server"></telerik:RadTextBox></td>
                    <td class="KeyCol Table_RowC">ایمیل:</td>
                    <td class="Table_RowC">
                        <telerik:RadTextBox ID="txtHomeEmail" runat="server"></telerik:RadTextBox></td>
                </tr>
            </table>
        </telerik:RadPageView>
        <telerik:RadPageView runat="server" ID="RadPageView2">
            <telerik:RadGrid runat="server" ID="dgrOwnersSignatures" />
            <telerik:RadButton runat="server" ID="btnAddSignature" Text="افزودن" OnClick="btnAddSignature_Click"></telerik:RadButton>
            <telerik:RadButton runat="server" ID="btnEditSignature" Text="ویرایش" OnClick="btnEditSignature_Click"></telerik:RadButton>
            <telerik:RadButton runat="server" ID="btnDeleteSignature" Text="حذف" OnClick="btnDeleteSignature_Click"></telerik:RadButton>
        </telerik:RadPageView>
        <telerik:RadPageView runat="server" ID="RadPageView3">
            <uc1:JArchiveControl runat="server" id="jArchiveControl" />
        </telerik:RadPageView>
        <telerik:RadPageView runat="server" ID="RadPageView4">
            <telerik:RadGrid runat="server" ID="dgrAssets" />
        </telerik:RadPageView>
        <telerik:RadPageView runat="server" ID="RadPageView5">
            <telerik:RadGrid runat="server" ID="dgrContract" />
        </telerik:RadPageView>
        <telerik:RadPageView runat="server" ID="RadPageView6">
            <uc1:JPropertyViewControl runat="server" id="jPropertyViewControl" />
        </telerik:RadPageView>
    </telerik:RadMultiPage>
</div>
<div style="position: fixed; bottom: 0px; height: 45px; width: 100%; vertical-align: middle; padding-top: 5px; padding-right: 5px" class="Table_RowD">
    <telerik:RadButton runat="server" ID="btnSave" Text="ذخیره" AutoPostBack="true" Width="100px" Height="35px" OnClick="btnSave_Click" ValidationGroup="Line" />
    <telerik:RadButton runat="server" ID="btnClose" Text="بازگشت" OnClientClicked="CloseDialog" AutoPostBack="false" Width="100px" Height="35px" />
</div>
