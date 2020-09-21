<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="JOilSealFormUpdateControl.ascx.cs" Inherits="WebOilManagement.Forms.JOilSealFormUpdateControl" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register Src="~/WebControllers/MainControls/Persons/JSearchPersonControl.ascx" TagPrefix="uc1" TagName="JSearchPersonControl" %>
<%@ Register Src="~/WebControllers/MainControls/Date/JDateControl.ascx" TagPrefix="uc1" TagName="JDateControl" %>
<%@ Register Src="~/WebControllers/MainControls/CustomListSelector/JCustomListSelectorControl.ascx" TagPrefix="uc1" TagName="JCustomListSelectorControl" %>


<telerik:RadAjaxManagerProxy runat="server" ID="AjaxManagerProxy_Control">
    <AjaxSettings>
        <telerik:AjaxSetting AjaxControlID="btnAddDetail">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="grdSeal" />
                <telerik:AjaxUpdatedControl ControlID="cmbSeal" />
            </UpdatedControls>
        </telerik:AjaxSetting>
        <telerik:AjaxSetting AjaxControlID="btnDeleteDetail">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="grdSeal" />
                <telerik:AjaxUpdatedControl ControlID="cmbSeal" />
            </UpdatedControls>
        </telerik:AjaxSetting>
    </AjaxSettings>
</telerik:RadAjaxManagerProxy>

<telerik:RadCodeBlock runat="server" ID="RadCodeBlock1" EnableViewState="false">
    <script type="text/javascript">
        var _evt;
        function RowClick(sender, eventArgs) {
            var evt = eventArgs.get_domEvent();

            if (evt.target.tagName == "INPUT" || evt.target.tagName == "A") {
                return;
            }

            var index = eventArgs.get_itemIndexHierarchical();
            document.getElementById("radGridClickedRowIndex").value = index;
        }

        

    </script>
</telerik:RadCodeBlock>
<input type="hidden" id="radGridClickedRowIndex" name="radGridClickedRowIndex" />

<div class="FormContent">
    <div class="BigTitle">فرم نصب و فک پلمپ</div>
    <telerik:RadTabStrip runat="server" ID="RadTabStrip1"
        SelectedIndex="0" MultiPageID="RadMultiPage1" Width="100%" OnTabClick="RadTabStrip1_TabClick">
        <Tabs>
            <telerik:RadTab Text="فرم پلمپ" PageViewID="rpvSealForm">
            </telerik:RadTab>
            <telerik:RadTab Text="کالاها" PageViewID="rpvSealDetails">
            </telerik:RadTab>
        </Tabs>
    </telerik:RadTabStrip>
    <telerik:RadMultiPage runat="server" ID="RadMultiPage1" SelectedIndex="0" 
        Width="700px">
        <telerik:RadPageView runat="server" ID="rpvSealForm">
            <table>
                <tr>
                    <td class="Table_RowB">جایگاه:</td>
                    <td class="Table_RowC">
                        <telerik:RadComboBox runat="server" ID="cmbGasStation" Filter="Contains"></telerik:RadComboBox>
                    </td>
                </tr>
                <tr>
                    <td class="Table_RowB">شماره فرم پلمپ :</td>
                    <td class="Table_RowC">
                        <telerik:RadNumericTextBox runat="server" Type="Number" NumberFormat-DecimalDigits="0" NumberFormat-GroupSeparator=""
                    MinValue="0" MaxValue="2147483647" ID="txtFormSealCode" Width="100%"></telerik:RadNumericTextBox>
                    </td>
                </tr>
                <tr>
                    <td class="Table_RowB">سریال فرم پلمپ فک شده:</td>
                    <td class="Table_RowC">
                        <telerik:RadNumericTextBox runat="server" Type="Number" NumberFormat-DecimalDigits="0" NumberFormat-GroupSeparator=""
                    MinValue="0" MaxValue="2147483647" ID="txtUnSerial" Width="100%"></telerik:RadNumericTextBox>
                    </td>
                </tr>
                
                 <tr>
                    <td class="Table_RowB">سریال فرم پلمپ نصب شده:</td>
                    <td class="Table_RowC">
                        <telerik:RadNumericTextBox runat="server" Type="Number" NumberFormat-DecimalDigits="0" NumberFormat-GroupSeparator=""
                    MinValue="0" MaxValue="2147483647" ID="txtInSerial" Width="100%"></telerik:RadNumericTextBox>
                    </td>
                </tr>
                <tr>
                    <td class="Table_RowB">تاریخ انجام:</td>
                    <td class="Table_RowC">
                        <uc1:jdatecontrol runat="server" id="dteAction" />
                    </td>
                </tr>
                <tr>
                    <td class="Table_RowB">مسئول تیم فنی:</td>
                    <td class="Table_RowC">
                      <%--  <uc1:jsearchpersoncontrol runat="server" id="personTechnicalTeamResponsible" />--%>
                        <uc1:JCustomListSelectorControl runat="server" id="personTechnicalTeamResponsible" />
                    </td>
                </tr>
                <tr>
                    <td class="Table_RowB">مسئول جایگاه:</td>
                    <td class="Table_RowC">
                        <uc1:jsearchpersoncontrol runat="server" id="personGasStationManager" />
                    </td>
                </tr>
            </table>
        </telerik:RadPageView>
        <telerik:RadPageView runat="server" ID="rpvSealDetails">
            <table>
                <tr>
                    <td class="Table_RowB">نازل:</td>
                    <td class="Table_RowC">
                        <telerik:RadComboBox runat="server" ID="cmbNozzle" Filter="Contains"></telerik:RadComboBox>
                    </td>
                </tr>
                <tr>
                    <td class="Table_RowB">پلمپ:</td>
                    <td class="Table_RowC">
                        <telerik:RadComboBox runat="server" ID="cmbSeal" Filter="Contains"></telerik:RadComboBox>
                    </td>
                </tr>
                <tr>
                    <td class="Table_RowB">محل نصب پلمپ:</td>
                    <td class="Table_RowC">
                        <telerik:RadComboBox runat="server" ID="cmbPlaceSealed" Filter="Contains"></telerik:RadComboBox>
                    </td>
                </tr>

                <tr>
                    <td class="Table_RowB">وضعیت:</td>
                    <td class="Table_RowC">
                        <telerik:RadComboBox runat="server" ID="cmbSealStatus" Filter="Contains"></telerik:RadComboBox>
                    </td>
                </tr>
            </table>
            <telerik:RadButton runat="server" ID="btnAddDetail" OnClick="btnAddDetail_Click" Text="افزودن"></telerik:RadButton>
            <telerik:RadButton runat="server" ID="btnDeleteDetail" OnClick="btnDeleteDetail_Click" Text="حذف"></telerik:RadButton>
            <telerik:RadGrid runat="server" ID="grdSeal" AutoGenerateColumns="true">
                <ClientSettings>
                    <ClientEvents OnRowClick="RowClick" />
                    <Selecting AllowRowSelect="true"></Selecting>
                </ClientSettings>
            </telerik:RadGrid>
        </telerik:RadPageView>
    </telerik:RadMultiPage>
</div>
<div class="FormButtons">
    <telerik:RadButton runat="server" ID="btnSave" Text="ذخیره" AutoPostBack="true" Width="100px" Height="35px" OnClick="btnSave_Click" ValidationGroup="Seal" />
    <telerik:RadButton runat="server" ID="btnClose" Text="بازگشت" OnClientClicked="CloseDialog" AutoPostBack="false" Width="100px" Height="35px" />
    <telerik:RadButton runat="server" ID="btnDelete" Text="حذف" AutoPostBack="true" Width="100px" Height="35px" OnClick="btnDelete_Click" CssClass="floatLeft" OnClientClicking="OnClientClicking" />
</div>
