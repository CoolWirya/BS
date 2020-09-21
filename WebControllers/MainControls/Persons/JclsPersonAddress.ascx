<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="JclsPersonAddress.ascx.cs" Inherits="WebControllers.MainControls.Persons.JclsPersonAddress" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<style type="text/css">
   
</style>
<telerik:RadAjaxManagerProxy runat="server" ID="RadAjaxManagerProxy1">
    <AjaxSettings>
        <telerik:AjaxSetting AjaxControlID="btnSave">
            <UpdatedControls>
                <%-- <telerik:AjaxUpdatedControl ControlID="PnlMain" />
                  <telerik:AjaxUpdatedControl ControlID="cmbState" />
                <telerik:AjaxUpdatedControl ControlID="cmbCity" />
                <telerik:AjaxUpdatedControl ControlID="txtPostalCode" />
                <telerik:AjaxUpdatedControl ControlID="txtTel" />
                <telerik:AjaxUpdatedControl ControlID="txtFax" />
                <telerik:AjaxUpdatedControl ControlID="txtMobile" />
                <telerik:AjaxUpdatedControl ControlID="txtEmail" />
                <telerik:AjaxUpdatedControl ControlID="txtWebSite" />
                <telerik:AjaxUpdatedControl ControlID="txtAddress" />--%>
            </UpdatedControls>
        </telerik:AjaxSetting>
        <telerik:AjaxSetting AjaxControlID="cmbState">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="cmbCity" />
            </UpdatedControls>
        </telerik:AjaxSetting>
        <telerik:AjaxSetting AjaxControlID="grvAddrress">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="grvAddrress" />
            </UpdatedControls>
        </telerik:AjaxSetting>
    </AjaxSettings>
</telerik:RadAjaxManagerProxy>
<telerik:RadCodeBlock runat="server" ID="RadCodeBlock1" EnableViewState="false">
    <script type="text/javascript">
        var _evt;
        function RowDblClick(sender, eventArgs) {
            var evt = eventArgs.get_domEvent();

            if (evt.target.tagName == "INPUT" || evt.target.tagName == "A") {
                return;
            }

            var index = eventArgs.get_itemIndexHierarchical();
            document.getElementById("radGridClickedRowIndex").value = index;

            
            CallShowMenu2(vv);
        }
        function RowClick(sender, eventArgs) {
            var evt = eventArgs.get_domEvent();

            if (evt.target.tagName == "INPUT" || evt.target.tagName == "A") {
                return;
            }

            var index = eventArgs.get_itemIndexHierarchical();
            document.getElementById("radGridClickedRowIndex").value = index;
        }
        function RowContextMenu(sender, eventArgs) {
           

            var evt = eventArgs.get_domEvent();

            if (evt.target.tagName == "INPUT" || evt.target.tagName == "A") {
                return;
            }

            var index = eventArgs.get_itemIndexHierarchical();
            document.getElementById("radGridClickedRowIndex").value = index;
            document.getElementById("EventType").value = 'GridRowRightClick';

            sender.get_masterTableView().selectItem(sender.get_masterTableView().get_dataItems()[index].get_element(), true);

            var ajaxManager = $find("<%=RadAjaxManager.GetCurrent(Page).ClientID %>");
            ajaxManager.ajaxRequest('');
            _evt = evt;
        }

        function onResponseEnd(sender, eventArgs) {
            if (document.getElementById("EventType").value == 'GridRowRightClick') {
               
                _evt.cancelBubble = true;
                _evt.returnValue = false;

                if (_evt.stopPropagation) {
                    _evt.stopPropagation();
                    _evt.preventDefault();
                }
            }
            if (document.getElementById("EventType").value == 'RefreshGrid') {
                var masterTable = $find("<%= grvAddrress.ClientID %>").get_masterTableView();
                masterTable.rebind();
            }
            document.getElementById("EventType").value = 'none';
        }

        function onRequestStart(sender, eventArgs) {
        }

        function RefreshGrid() {
            document.getElementById("EventType").value = 'RefreshGrid';
            var ajaxManager = $find("<%=RadAjaxManager.GetCurrent(Page).ClientID %>");
            ajaxManager.ajaxRequest('');
        }
        function CallShowMenu(sender, eventArgs) {
            var button = eventArgs.get_item();

            var grid = $find("<%=grvAddrress.ClientID %>");
            var MasterTable = grid.get_masterTableView();
            var selectedRows = MasterTable.get_selectedItems();
            var param = '';
            if (selectedRows.length > 0) {
                var cell = MasterTable.getCellByColumnUniqueName(selectedRows[0], "Code")
                param = '{!::!}' + cell.innerHTML;
            }
            ShowMenu(button.get_value() + param);
        }
        function CallShowMenu2(v) {
            var grid = $find("<%=grvAddrress.ClientID %>");
            var MasterTable = grid.get_masterTableView();
            var selectedRows = MasterTable.get_selectedItems();
            var param = '';
            if (selectedRows.length > 0) {
                var cell = MasterTable.getCellByColumnUniqueName(selectedRows[0], "Code")
                param = '{!::!}' + cell.innerHTML;
            }
            ShowMenu(v + param);
        }

       
        

    </script>
</telerik:RadCodeBlock>
<asp:Panel ID="PnlMain" runat="server">
    <table cellpadding="0" cellspacing="0" style="width: 800px;">

        <tr class="Table_RowC">
            <td style="width: 150px">استان :</td>
            <td>
                <telerik:RadComboBox Width="300px" runat="server" DataValueField="Code" Filter="Contains" DataTextField="name" AllowCustomText="true"
                    ID="cmbState" AutoPostBack="True" OnSelectedIndexChanged="cmbState_SelectedIndexChanged" ViewStateMode="Enabled" EnableViewState="true">
                </telerik:RadComboBox>

            </td>
        </tr>
        <tr class="Table_RowB">
            <td style="width: 150px">شهر :</td>
            <td>
                <telerik:RadComboBox Width="300px" AllowCustomText="true" runat="server" Filter="Contains" DataValueField="Code"
                    DataTextField="name" ID="cmbCity" ViewStateMode="Enabled" EnableViewState="true" ValidationGroup="">
                </telerik:RadComboBox>
            </td>
        </tr>
        <tr class="Table_RowC">
            <td style="width: 150px">کد پستی :</td>
            <td>
                <telerik:RadNumericTextBox Width="300px" runat="server" ID="txtPostalCode" Type="Number" NumberFormat-GroupSeparator="" NumberFormat-DecimalDigits="0"></telerik:RadNumericTextBox></td>
        </tr>
        <tr>
            <td style="width: 150px">تلفن :</td>
            <td>
                <telerik:RadNumericTextBox Width="300px" runat="server" ID="txtTel" Type="Number" NumberFormat-GroupSeparator="" NumberFormat-DecimalDigits="0"></telerik:RadNumericTextBox>

            </td>
        </tr>
        <tr class="Table_RowC">
            <td style="width: 150px">فاکس :</td>
            <td>
                <telerik:RadNumericTextBox Width="300px" runat="server" ID="txtFax" NumberFormat-GroupSeparator=""  Type="Number" NumberFormat-DecimalDigits="0"></telerik:RadNumericTextBox></td>
        </tr>
        <tr class="Table_RowB">
            <td style="width: 150px">موبایل :</td>
            <td>
                <telerik:RadNumericTextBox Width="300px" runat="server" ID="txtMobile" NumberFormat-GroupSeparator="" Type="Number" NumberFormat-DecimalDigits="0"></telerik:RadNumericTextBox></td>
        </tr>
        <tr class="Table_RowC">
            <td style="width: 150px">ایمیل :</td>
            <td>
                <telerik:RadTextBox runat="server" ID="txtEmail" Type="Number"></telerik:RadTextBox>

            </td>
        </tr>
        <tr class="Table_RowB">
            <td style="width: 150px">وب سایت :</td>
            <td>
                <telerik:RadTextBox Type="Number" Width="300px" runat="server" ID="txtWebSite"></telerik:RadTextBox>
            </td>
        </tr>
        <tr class="Table_RowC">
            <td style="width: 150px">آدرس :</td>
            <td rowspan="2">
                <telerik:RadTextBox Width="300px" runat="server" ID="txtAddress" TextMode="MultiLine"></telerik:RadTextBox>

            </td>
        </tr>
        <tr class="Table_RowB">
            <td style="width: 150px"></td>
        </tr>
        <tr class="Table_RowC">
            <td colspan="2">
                <telerik:RadButton runat="server" ID="btnSave" Text="ذخیره" ValidationGroup="SAVE" CausesValidation="true" OnClick="btnSave_Click"></telerik:RadButton>
            </td>
        </tr>
        <tr class="Table_RowB">
            <td colspan="2" dir="rtl">

                <telerik:RadGrid ID="grvAddrress"
                    runat="server"
                    AllowSorting="true"
                    GroupingEnabled="true"
                    EnableHeaderContextMenu="true"
                    Width="99%"
                    AllowPaging="true"
                    OnNeedDataSource="grvAddrress_NeedDataSource"
                    OnSelectedIndexChanged="grvAddrress_SelectedIndexChanged"
                    OnPageIndexChanged="grvAddrress_PageIndexChanged"
                    EnableHeaderContextAggregatesMenu="true"
                    GridLines="None"
                    AllowCustomPaging="false"
                    ShowGroupPanel="false"
                    GroupPanel-Width="99%"
                    ShowDesignTimeSmartTagMessage="true"
                    OnPageSizeChanged="grvAddrress_PageSizeChanged"
                    OnPreRender="grvAddrress_PreRender"
                    OnLoad="grvAddrress_Load"
                    ShowFooter="true"
                    OnDeleteCommand="grvAddrress_DeleteCommand" AutoGenerateColumns="false"  >
                    <MasterTableView DataKeyNames="Code"  >
                        <Columns >
                            <telerik:GridBoundColumn HeaderText="Code"    DataField="Code" Display="false" UniqueName="Code" />
                            <telerik:GridBoundColumn HeaderText="State_Name" DataField="State_Name"  UniqueName="State_Name"/>
                            <telerik:GridBoundColumn HeaderText="City_Name" DataField="City_Name" UniqueName="City_Name" />
                            <telerik:GridBoundColumn HeaderText="PostalCode" DataField="PostalCode"  UniqueName="PostalCode"/>
                            <telerik:GridBoundColumn HeaderText="Tel" DataField="Tel"  UniqueName="Tel"/>
                            <telerik:GridBoundColumn HeaderText="Fax" DataField="Fax"  UniqueName="Fax"/>
                            <telerik:GridBoundColumn HeaderText="Mobile" DataField="Mobile"  UniqueName="Mobile"/>
                            <telerik:GridBoundColumn HeaderText="Email" DataField="Email"  UniqueName="Email"/>
                            <telerik:GridBoundColumn HeaderText="WebSite" DataField="WebSite" UniqueName="WebSite" />
                          
                            <telerik:GridButtonColumn ButtonType="ImageButton" ImageUrl="~\Images\Controls\menu_delete.png" CommandName="delete" ConfirmText="آیا مایل به حذف هستید ؟" ConfirmTitle="حذف"></telerik:GridButtonColumn>
                        </Columns>
                        <NoRecordsTemplate >هیچ آدرسی موجود نمی باشد</NoRecordsTemplate>
                        
                    </MasterTableView>
                    <ClientSettings  Selecting-AllowRowSelect="true" Selecting-UseClientSelectColumnOnly="false" >
                        <Selecting EnableDragToSelectRows="true" />
                    </ClientSettings>
                    
                    <PagerStyle Mode="NextPrevAndNumeric" PageSizeControlType="RadComboBox"></PagerStyle>
                </telerik:RadGrid>
                <asp:HiddenField runat="server" EnableViewState="true" ID="hfClassName" />
                <asp:HiddenField runat="server" EnableViewState="true" ID="hfObjectCode" />
                <asp:HiddenField runat="server" EnableViewState="true" ID="hfCode" />
                <asp:HiddenField runat="server" EnableViewState="true" ID="hfAddressType" />
                <br />
            </td>
        </tr>
    </table>
</asp:Panel>
