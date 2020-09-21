<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="JCountersUpdateControl.ascx.cs" Inherits="WebBusManagement.FormsManagement.JCountersUpdateControl" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register Src="~/WebControllers/MainControls/Date/JDateControl.ascx" TagPrefix="uc1" TagName="JDateControl" %>
<%@ Register Src="~/WebControllers/MainControls/CustomListSelector/JCustomListSelectorControl.ascx" TagPrefix="uc1" TagName="JCustomListSelectorControl" %>
<%@ Register Src="~/WebControllers/MainControls/Persons/JSearchPersonControl.ascx" TagPrefix="uc1" TagName="JSearchPersonControl" %>
<%@ Register Src="~/WebControllers/MainControls/OpenLayersMap/OpenLayersMap.ascx" TagPrefix="uc1" TagName="OpenLayersMap" %>

<div class="BigTitle">باجه های فروش بلیط</div>
<telerik:RadTabStrip runat="server" ID="RadTabStrip1"
    SelectedIndex="0" MultiPageID="RadMultiPage1" Width="100%" OnClientTabSelected="OnClientTabSelected">
    <Tabs>
        <telerik:RadTab Text="اطلاعات باجه">
        </telerik:RadTab>
        <telerik:RadTab Text="باجه دارها">
        </telerik:RadTab>
        <telerik:RadTab Text="دستگاه">
        </telerik:RadTab>
        <telerik:RadTab Text="نقشه">
        </telerik:RadTab>
    </Tabs>
</telerik:RadTabStrip>
<telerik:RadMultiPage runat="server" ID="RadMultiPage1" SelectedIndex="0"
    Width="700px">
    <telerik:RadPageView runat="server" ID="RadPageView1">
        <table style="width: 500px">
            <tr class="Table_RowB">
                <td style="width: 150px">نوع باجه:</td>
                <td>
                    <telerik:RadComboBox runat="server" ID="cmbCountersType" Width="100%"></telerik:RadComboBox>
                </td>
            </tr>
            <tr class="Table_RowC">
                <td style="width: 150px">ایستگاه:</td>
                <td>
                    <telerik:RadComboBox runat="server" ID="cmbStation" Width="100%" Filter="Contains"></telerik:RadComboBox>
                </td>
            </tr>
            <tr class="Table_RowB">
                <td style="width: 150px">آدرس:</td>
                <td>
                    <telerik:RadTextBox runat="server" ID="txtAddress" TextMode="MultiLine" Width="96%"></telerik:RadTextBox>
                </td>
            </tr>
            <tr class="Table_RowC">
                <td style="width: 150px">تلفن:</td>
                <td>
                    <telerik:RadTextBox runat="server" ID="txtTel" Width="96%"></telerik:RadTextBox>
                </td>
            </tr>
            <tr class="Table_RowB">
                <td style="width: 150px">طول جغرافیای:</td>
                <td>
                    <telerik:RadTextBox runat="server" ID="txtLat" Width="96%"></telerik:RadTextBox>
                </td>
            </tr>
            <tr class="Table_RowC">
                <td style="width: 150px">عرض جغرافیایی:</td>
                <td>
                    <telerik:RadTextBox runat="server" ID="txtLon" Width="96%"></telerik:RadTextBox>
                </td>
            </tr>
        </table>
    </telerik:RadPageView>
    <telerik:RadPageView runat="server" ID="RadPageView2">
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
        <%--<telerik:RadAjaxManagerProxy runat="server" ID="AjaxManagerProxy_Control">
            <AjaxSettings>
                <telerik:AjaxSetting AjaxControlID="BtnCountersPersonSave">
                    <UpdatedControls>
                        <telerik:AjaxUpdatedControl ControlID="GridViewCountersPerson" />
                    </UpdatedControls>
                </telerik:AjaxSetting>
            </AjaxSettings>
        </telerik:RadAjaxManagerProxy>--%>
        <telerik:RadButton runat="server" ID="BtnCountersPersonSave" Text="ذخیره باجه دار" AutoPostBack="true" Width="100px" Height="35px" OnClick="BtnCountersPersonSave_Click" ValidationGroup="CountersPerson" />
        <div style="clear: both; height: 5px"></div>
        <asp:GridView ID="GridViewCountersPerson" runat="server" Width="100%" HorizontalAlign="Center"
            RowStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" RowStyle-ForeColor="Black"
            OnSelectedIndexChanged="GridViewCountersPerson_SelectedIndexChanged" EnableModelValidation="True">
            <Columns>
                <asp:ButtonField CommandName="Select" HeaderText="انتخاب" ShowHeader="True" Text="انتخاب"
                    ButtonType="Link" />
            </Columns>
            <RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#F7F7F7" />
        </asp:GridView>
        <div style="clear: both; height: 5px"></div>
        <telerik:RadButton runat="server" ID="btnDelCountersPerson" Text="حذف باجه دار" Visible="false" AutoPostBack="true" Width="100px" Height="35px" OnClick="btnDelCountersPerson_Click" />
        <input type="hidden" runat="server" id="GridViewCountersPersonSelectedRowId" name="GridViewCountersPersonSelectedRowId" value="0" />
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
      <%--  <telerik:RadAjaxManagerProxy runat="server" ID="RadAjaxManagerProxy1">
            <AjaxSettings>
                <telerik:AjaxSetting AjaxControlID="BtnSellerTicketDeviceSave">
                    <UpdatedControls>
                        <telerik:AjaxUpdatedControl ControlID="GridViewSellerTicketDevice" />
                    </UpdatedControls>
                </telerik:AjaxSetting>
            </AjaxSettings>
        </telerik:RadAjaxManagerProxy>--%>
        <telerik:RadButton runat="server" ID="BtnSellerTicketDeviceSave" Text="ذخیره دستگاه" AutoPostBack="true" Width="100px" Height="35px" OnClick="BtnSellerTicketDeviceSave_Click" ValidationGroup="BusDevice" />
        <div style="clear: both; height: 5px"></div>
        <asp:GridView ID="GridViewSellerTicketDevice" runat="server" Width="100%" HorizontalAlign="Center"
            RowStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" RowStyle-ForeColor="Black"
            OnSelectedIndexChanged="GridViewSellerTicketDevice_SelectedIndexChanged" EnableModelValidation="True">
            <Columns>
                <asp:ButtonField CommandName="Select" HeaderText="انتخاب" ShowHeader="True" Text="انتخاب"
                    ButtonType="Link" />
            </Columns>
            <RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#F7F7F7" />
        </asp:GridView>
        <div style="clear: both; height: 5px"></div>
        <telerik:RadButton runat="server" ID="btnDelSellerTicketDevice" Text="حذف دستگاه" Visible="false" AutoPostBack="true" Width="100px" Height="35px" OnClick="btnDelSellerTicketDevice_Click" ValidationGroup="BusDevice" />
        <input type="hidden" runat="server" id="GridViewSellerTicketDeviceSelectedRowId" name="GridViewSellerTicketDeviceSelectedRowId" value="0" />
    </telerik:RadPageView>
    <telerik:RadPageView runat="server" ID="RadPageView3">
    </telerik:RadPageView>
</telerik:RadMultiPage>
<div id="Div_CountersMap" style="float: right; width: 700px; height: 280px; text-align: right; visibility: hidden">
    <uc1:openlayersmap runat="server" id="OpenLayersMapCounters" />
</div>
<div style="clear: both; height: 10px"></div>
<telerik:RadButton runat="server" ID="btnSave" Text="ذخیره" AutoPostBack="true" Width="100px" Height="35px" OnClick="btnSave_Click" />
<telerik:RadButton runat="server" ID="btnClose" Text="بازگشت" OnClientClicked="CloseDialog" AutoPostBack="false" Width="100px" Height="35px" />
<script type="text/javascript">
    $("#Div_CountersMap").css('height', '1px');
    function OnClientTabSelected(sender, eventArgs) {
        var tab = eventArgs.get_tab();
        if (tab.get_text() == "نقشه") {
            $("#Div_CountersMap").css('visibility', 'visible');
            $("#Div_CountersMap").css('height', '280px');
            $("#Div_CountersMap").fadeIn();
        }
        else {
            $("#Div_CountersMap").css('visibility', 'hidden');
            $("#Div_CountersMap").css('height', '1px');
            $("#Div_CountersMap").css('display', 'none');
        }
    }
</script>
