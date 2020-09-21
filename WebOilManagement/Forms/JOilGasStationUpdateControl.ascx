<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="JOilGasStationUpdateControl.ascx.cs" Inherits="WebOilManagement.Forms.JOilGasStationUpdateControl" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register Src="~/WebControllers/MainControls/Persons/JSearchPersonControl.ascx" TagPrefix="uc1" TagName="JSearchPersonControl" %>
<%@ Register Src="~/WebControllers/MainControls/Persons/JclsPersonAddress.ascx" TagPrefix="uc2" TagName="JclsPersonAddress" %>

<telerik:RadAjaxManagerProxy runat="server" ID="rampJOilGasStation">
    <AjaxSettings>
        <telerik:AjaxSetting AjaxControlID="rtabJOilGasStation">
            <UpdatedControls>
            <%--    <telerik:AjaxUpdatedControl ControlID="rpageJOilGasStation" />
                <telerik:AjaxUpdatedControl ControlID="rtabJOilGasStation" />--%>
               
            </UpdatedControls>
        </telerik:AjaxSetting>

    </AjaxSettings>
     <AjaxSettings>
        <telerik:AjaxSetting AjaxControlID="cmbZone">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="cmbArea" />
               
            </UpdatedControls>
        </telerik:AjaxSetting>

         <telerik:AjaxSetting AjaxControlID="Save">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="rpageJOilGasStation" />
               
            </UpdatedControls>
        </telerik:AjaxSetting>

    </AjaxSettings>
</telerik:RadAjaxManagerProxy>

<div class="FormContent">
    <div class="BigTitle">جایگاه سوخت</div>
    <telerik:RadTabStrip runat="server" ID="rtabJOilGasStation" SelectedIndex="0" OnTabClick="rtabJOilGasStation_TabClick" MultiPageID="rpageJOilGasStation" Width="500px">
        <Tabs>
            <telerik:RadTab Text="جایگاه سوخت" Value="rpvOilGasStation" PageViewID="rpvOilGasStation">
            </telerik:RadTab>
            <telerik:RadTab Text="آدرس" Value="rpvJClsPerssonAddress" PageViewID="rpvJClsPerssonAddress">
            </telerik:RadTab>
        </Tabs>
    </telerik:RadTabStrip>
    <telerik:RadMultiPage runat="server" ID="rpageJOilGasStation" SelectedIndex="0" Width="700px">
        <telerik:RadPageView runat="server" ID="rpvOilGasStation">


            <asp:HiddenField runat="server" ID="hfCode" />
            <table>
                <tr>
                    <td class="Table_RowB">نام جایگاه:</td>
                    <td class="Table_RowC">
                        <telerik:RadTextBox runat="server" ValidateRequestMode="Enabled" ID="txtName" Width="95%"></telerik:RadTextBox>
                        <asp:RequiredFieldValidator ID="rfvName" runat="server" ErrorMessage="*" Font-Size="10" Text="*" ControlToValidate="txtName" ValidationGroup="Save"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="Table_RowB">مکان محل عرضه:</td>
                    <td class="Table_RowC">
                        <telerik:RadComboBox runat="server" ID="cmbPlaceOfSupply" Filter="Contains"></telerik:RadComboBox>
                    </td>
                </tr>
                <tr>
                    <td class="Table_RowB">نوع محل عرضه:</td>
                    <td class="Table_RowC">
                        <telerik:RadComboBox runat="server" ID="cmbTypeOfSupply" Filter="Contains"></telerik:RadComboBox>
                    </td>
                </tr>
                <tr>
                    <td class="Table_RowB">شماره جایگاه:</td>
                    <td class="Table_RowC">
                        <telerik:RadNumericTextBox runat="server" Type="Number" NumberFormat-DecimalDigits="0" ID="txtStationNumber" Width="95%"></telerik:RadNumericTextBox>
                        <asp:RequiredFieldValidator ID="rfvStationNumber" runat="server" ErrorMessage="*" Font-Size="10" Text="*" ControlToValidate="txtStationNumber" ValidationGroup="Save"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                 <tr>
                    <td class="Table_RowB">منطقه:</td>
                    <td class="Table_RowC">
                        <telerik:RadComboBox runat="server" ID="cmbZone" AutoPostBack="true" OnSelectedIndexChanged="cmbZone_SelectedIndexChanged" Filter="Contains"></telerik:RadComboBox>
                    </td>
                </tr>

                <tr>
                    <td class="Table_RowB">ناحیه:</td>
                    <td class="Table_RowC">
                        <telerik:RadComboBox runat="server" ID="cmbArea" Filter="Contains"></telerik:RadComboBox>
                    </td>
                </tr>
                <tr>
                    <td class="Table_RowB">مساحت:</td>
                    <td class="Table_RowC">
                        <telerik:RadNumericTextBox runat="server" Type="Number" NumberFormat-DecimalDigits="0" ID="txtArea" Width="95%">
                        </telerik:RadNumericTextBox>
                        <asp:RequiredFieldValidator ID="rfvArea" runat="server" ErrorMessage="*" Font-Size="10" Text="*" ControlToValidate="txtArea" ValidationGroup="Save"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="Table_RowB">مالک:</td>
                    <td class="Table_RowC">
                        <uc1:jsearchpersoncontrol runat="server" id="personOwner" />
                    </td>
                </tr>
                <tr>
                    <td class="Table_RowB">اپراتور:</td>
                    <td class="Table_RowC">
                        <uc1:jsearchpersoncontrol runat="server" id="personOperator" />
                    </td>
                </tr>
                <tr>
            <td class="Table_RowB">نوع مخزن:</td>
            <td class="Table_RowC">
                <telerik:RadComboBox runat="server" ID="cmbTypeOfFuelTank" Filter="Contains"></telerik:RadComboBox>
            </td>
        </tr>
        
        <tr>
            <td class="Table_RowB">نوع محصول مخزن:</td>
            <td class="Table_RowC">
                <telerik:RadComboBox runat="server" ID="cmbTypeOfProduct" Filter="Contains"></telerik:RadComboBox>
            </td>
        </tr>
                <%--<tr>
                    <td class="Table_RowB">آدرس:</td>
                    <td class="Table_RowC">
                        <telerik:RadTextBox runat="server" ID="txtAddress" Width="95%"></telerik:RadTextBox>
                        <asp:RequiredFieldValidator ID="rfvAddress" runat="server" ErrorMessage="*" Font-Size="10" Text="*" ControlToValidate="txtAddress" ValidationGroup="Save"></asp:RequiredFieldValidator>
                    </td>
                </tr>--%>
                <tr>
                    <td class="Table_RowB">طول جغرافیایی:</td>
                    <td class="Table_RowC">
                        <telerik:RadNumericTextBox runat="server" Type="Number" NumberFormat-DecimalDigits="0" ID="txtLat" Width="95%"></telerik:RadNumericTextBox>
                        <asp:RequiredFieldValidator ID="rfvLat" runat="server" ErrorMessage="*" Font-Size="10" Text="*" ControlToValidate="txtLat" ValidationGroup="Save"></asp:RequiredFieldValidator>

                    </td>
                </tr>
                <tr>
                    <td class="Table_RowB">عرض جغرافیایی:</td>
                    <td class="Table_RowC">
                        <telerik:RadNumericTextBox runat="server" Type="Number" NumberFormat-DecimalDigits="0" runat="server" ID="txtLon" Width="95%"></telerik:RadNumericTextBox>
                        <asp:RequiredFieldValidator ID="rfvLon" runat="server" ErrorMessage="*" Font-Size="10" Text="*" ControlToValidate="txtLon" ValidationGroup="Save"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="Table_RowB">ارتفاع جغرافیایی:</td>
                    <td class="Table_RowC">
                        <telerik:RadNumericTextBox runat="server" Type="Number" NumberFormat-DecimalDigits="0" ID="txtAlt" Width="95%"></telerik:RadNumericTextBox>
                        <asp:RequiredFieldValidator ID="rfvAlt" runat="server" ErrorMessage="*" Font-Size="10" Text="*" ControlToValidate="txtAlt" ValidationGroup="Save"></asp:RequiredFieldValidator>
                    </td>
                </tr>

            </table>

        </telerik:RadPageView>
        <telerik:RadPageView runat="server" ID="rpvJClsPerssonAddress">
            <uc2:JclsPersonAddress runat="server" id="JclsPersonAddress" />
        </telerik:RadPageView>
    </telerik:RadMultiPage>
</div>

<div class="FormButtons">
    <telerik:RadButton runat="server" ID="btnSave" Text="ذخیره" AutoPostBack="true" CausesValidation="true" ValidationGroup="Save" Width="100px" Height="35px" OnClick="btnSave_Click" />
    <telerik:RadButton runat="server" ID="btnClose" Text="بازگشت" OnClientClicked="CloseDialog" AutoPostBack="false" Width="100px" Height="35px" />
    <telerik:RadButton runat="server" ID="btnDelete" Text="حذف" AutoPostBack="true" Width="100px" Height="35px" OnClick="btnDelete_Click" CssClass="floatLeft" OnClientClicking="OnClientClicking" />
</div>
