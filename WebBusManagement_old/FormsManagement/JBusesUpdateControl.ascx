<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="JBusesUpdateControl.ascx.cs" Inherits="WebBusManagement.FormsManagement.JBusesUpdateControl" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register Src="~/WebControllers/MainControls/CustomListSelector/JCustomListSelectorControl.ascx" TagPrefix="uc1" TagName="JCustomListSelectorControl" %>
<%@ Register Src="~/WebControllers/Property/JPropertyViewControl.ascx" TagPrefix="uc1" TagName="JPropertyViewControl" %>
<%@ Register Src="~/WebControllers/MainControls/Date/JDateControl.ascx" TagPrefix="uc1" TagName="JDateControl" %>
<%@ Register Src="~/WebControllers/MainControls/Persons/JSearchPersonControl.ascx" TagPrefix="uc1" TagName="JSearchPersonControl" %>
<%@ Register Src="~/WebControllers/ArchiveDocument/JArchiveControl.ascx" TagPrefix="uc1" TagName="JArchiveControl" %>

<div class="BigTitle">اتوبوس</div>
<telerik:RadTabStrip runat="server" ID="RadTabStrip1"
    SelectedIndex="0" MultiPageID="RadMultiPage1" Width="100%">
    <Tabs>
        <telerik:RadTab Text="اتوبوس" PageViewID="rpvBus">
        </telerik:RadTab>
        <telerik:RadTab Text="مالک" PageViewID="rpvOwner">
        </telerik:RadTab>
        <telerik:RadTab Text="دستگاه" PageViewID="rpvDevice">
        </telerik:RadTab>
        <telerik:RadTab Text="تصویر" PageViewID="rpvArchive">
        </telerik:RadTab>
    </Tabs>
</telerik:RadTabStrip>
<telerik:RadMultiPage runat="server" ID="RadMultiPage1" SelectedIndex="0"
    Width="700px">
    <telerik:RadPageView runat="server" ID="rpvBus">
        <table style="width: 500px">
            <tr class="Table_RowB">
                <td style="width: 150px">انتخاب اتومبیل:</td>
                <td>
                    <uc1:jcustomlistselectorcontrol runat="server" id="JCustomListSelectorControl" />
                </td>
            </tr>
            <tr class="Table_RowC">
                <td style="width: 150px">شماره اتوبوس:</td>
                <td>
                    <telerik:RadTextBox runat="server" ID="txtBusCode" Width="96%"></telerik:RadTextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidatortxtBusCode" runat="server" Display="Dynamic" ControlToValidate="txtBusCode" ValidationGroup="Bus" ErrorMessage="*"></asp:RequiredFieldValidator>
                    <asp:CompareValidator ID="CompareValidatortxtBusCode" runat="server" ErrorMessage="لطفا عدد وارد کنید" Display="Dynamic" ControlToValidate="txtBusCode" Type="Double" ValidationGroup="Bus"></asp:CompareValidator>
                </td>
            </tr>
            <tr class="Table_RowB">
                <td style="width: 150px">ناوگان:</td>
                <td>
                    <telerik:RadComboBox runat="server" ID="cmbFleet" Width="100%"></telerik:RadComboBox>
                </td>
            </tr>
            <tr class="Table_RowC">
                <td style="width: 150px">فعال:</td>
                <td>
                    <asp:CheckBox ID="chkBusStatus" runat="server" Text="فعال" />
                </td>
            </tr>
           <%-- <tr class="Table_RowB">
                <td style="width: 150px">ویژگی ها:</td>
                <td>
                    <uc1:jpropertyviewcontrol runat="server" id="JPropertyViewControl" />
                </td>
            </tr>--%>
        </table>
    </telerik:RadPageView>
    <telerik:RadPageView runat="server" ID="rpvOwner">
        <table style="width: 500px">
            <tr class="Table_RowB">
                <td style="width: 150px">شخص:</td>
                <td>
                    <uc1:JSearchPersonControl runat="server" id="JSearchPersonControl" />
                </td>
            </tr>
            <tr class="Table_RowC">
                <td style="width: 150px">تاریخ شروع:</td>
                <td>
                    <uc1:JDateControl runat="server" id="txtStartDate" />
                </td>
            </tr>
            <tr class="Table_RowB">
                <td style="width: 150px">تاریخ پایان:</td>
                <td>
                    <uc1:JDateControl runat="server" id="txtFinishDate" />
                </td>
            </tr>
            <tr class="Table_RowC">
                <td style="width: 150px">فعال:</td>
                <td>
                    <asp:CheckBox ID="chkStatus" runat="server" Text="فعال" />
                </td>
            </tr>
        </table>
       <%-- <telerik:RadAjaxManagerProxy runat="server" ID="AjaxManagerProxy_Control">
            <AjaxSettings>
                <telerik:AjaxSetting AjaxControlID="BtnBusPersonSave">
                    <UpdatedControls>
                        <telerik:AjaxUpdatedControl ControlID="GridViewBusPerson" />
                    </UpdatedControls>
                </telerik:AjaxSetting>
            </AjaxSettings>
        </telerik:RadAjaxManagerProxy>--%>
        <telerik:RadButton runat="server" ID="BtnBusPersonSave" Text="ذخیره مالک" AutoPostBack="true" Width="100px" Height="35px" OnClick="BtnBusPersonSave_Click" ValidationGroup="BusPerson" />
        <div style="clear: both; height: 5px"></div>
        <asp:GridView ID="GridViewBusPerson" runat="server" Width="100%" HorizontalAlign="Center"
            RowStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" RowStyle-ForeColor="Black"
            OnSelectedIndexChanged="GridViewBusPerson_SelectedIndexChanged" EnableModelValidation="True">
            <Columns>
                <asp:ButtonField CommandName="Select" HeaderText="انتخاب" ShowHeader="True" Text="انتخاب"
                    ButtonType="Link" />
            </Columns>
            <RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#F7F7F7" />
        </asp:GridView>
        <div style="clear: both; height: 5px"></div>
        <telerik:RadButton runat="server" ID="btnDelBusPerson" Text="حذف مالک" Visible="false" AutoPostBack="true" Width="100px" Height="35px" OnClick="btnDelBusPerson_Click" ValidationGroup="BusPerson" />
        <input type="hidden" runat="server" id="GridViewBusPersonSelectedRowId" name="GridViewBusPersonSelectedRowId" value="0" />
    </telerik:RadPageView>
    <telerik:RadPageView runat="server" ID="rpvDevice">
        <table style="width: 500px">
            <tr class="Table_RowB">
                <td style="width: 150px">دستگاه:</td>
                <td>
                    <uc1:jcustomlistselectorcontrol runat="server" id="JCustomListSelectorControlDevice" />
                </td>
            </tr>
            <tr class="Table_RowC">
                <td style="width: 150px">نصاب:</td>
                <td>
                    <uc1:JSearchPersonControl runat="server" id="JSearchPersonControlInstaller" />
                </td>
            </tr>
            <tr class="Table_RowC">
                <td style="width: 150px">تاریخ شروع:</td>
                <td>
                    <uc1:JDateControl runat="server" id="txtDeviceStartDate" />
                </td>
            </tr>
            <tr class="Table_RowB">
                <td style="width: 150px">تاریخ پایان:</td>
                <td>
                    <uc1:JDateControl runat="server" id="txtDeviceFinishDate" />
                </td>
            </tr>
        </table>
        <telerik:RadButton runat="server" ID="BtnBusDeviceSave" Text="ذخیره دستگاه" AutoPostBack="true" Width="100px" Height="35px" OnClick="BtnBusDeviceSave_Click" ValidationGroup="BusDevice" />
        <div style="clear: both; height: 5px"></div>
        <asp:GridView ID="GridViewBusDevice" runat="server" Width="100%" HorizontalAlign="Center"
            RowStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" RowStyle-ForeColor="Black"
            OnSelectedIndexChanged="GridViewBusDevice_SelectedIndexChanged" EnableModelValidation="True">
            <Columns>
                <asp:ButtonField CommandName="Select" HeaderText="انتخاب" ShowHeader="True" Text="انتخاب"
                    ButtonType="Link" />
            </Columns>
            <RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#F7F7F7" />
        </asp:GridView>
        <div style="clear: both; height: 5px"></div>
        <telerik:RadButton runat="server" ID="btnDelBusDevice" Text="حذف دستگاه" Visible="false" AutoPostBack="true" Width="100px" Height="35px" OnClick="btnDelBusDevice_Click" ValidationGroup="BusDevice" />
        <input type="hidden" runat="server" id="GridViewBusDeviceSelectedRowId" name="GridViewBusDeviceSelectedRowId" value="0" />
    </telerik:RadPageView>
    <telerik:RadPageView runat="server" ID="rpvArchive">
        <uc1:JArchiveControl runat="server" id="jArchiveControl" />
    </telerik:RadPageView>
</telerik:RadMultiPage>
<telerik:RadButton runat="server" ID="btnSave" Text="ذخیره" AutoPostBack="true" Width="100px" OnClick="btnSave_Click" Height="35px" ValidationGroup="Bus" />
<telerik:RadButton runat="server" ID="btnClose" Text="بازگشت" OnClientClicked="CloseDialog" AutoPostBack="false" Width="100px" Height="35px" />
