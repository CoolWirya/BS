<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="JSoftwareRepairUpdateControl.ascx.cs" Inherits="WebOilManagement.Forms.JSoftwareRepairUpdateControl" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register Src="~/WebControllers/MainControls/Date/JDateControl.ascx" TagPrefix="uc1" TagName="JDateControl" %>
<%@ Register Src="~/WebControllers/MainControls/CustomListSelector/JCustomListSelectorControl.ascx" TagPrefix="uc2" TagName="JCustomListSelectorControl" %>

<div class="FormContent">
    <div class="BigTitle">رفع خرابی نرم افزاری</div>
    <table>
        <tr>
            <td class="Table_RowB">دلیل اینشیال:</td>
            <td class="Table_RowC">
                <telerik:RadComboBox runat="server" ID="cmbInitialReasons" Width="100%"></telerik:RadComboBox>
            </td>
        </tr>
        <tr>
            <td class="Table_RowB">توضیحات دلیل اینشیال:</td>
            <td class="Table_RowC">
                <telerik:RadTextBox runat="server" ID="txtInitialReasonsComment" Width="90%"></telerik:RadTextBox>
              <%--  <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*"
                    ControlToValidate="txtInitialReasonsComment" ValidationGroup="SoftwareRepair" Display="Dynamic"></asp:RequiredFieldValidator>--%>
            </td>
        </tr>
        <tr>
            <td class="Table_RowB">دلیل اینشیال دوباره:</td>
            <td class="Table_RowC">
                <telerik:RadComboBox runat="server" ID="cmbInitialAgain" Width="100%"></telerik:RadComboBox>
            </td>
        </tr>
        <tr>
            <td class="Table_RowB">توضیحات دلیل اینشیال دوباره:</td>
            <td class="Table_RowC">
                <telerik:RadTextBox runat="server" ID="txtInitialAgainComment" Width="90%"></telerik:RadTextBox>
               <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*"
                    ControlToValidate="txtInitialAgainComment" ValidationGroup="SoftwareRepair" Display="Dynamic"></asp:RequiredFieldValidator>--%>
            </td>
        </tr>
        <tr>
            <td class="Table_RowB">کد RPM جدید:</td>
            <td class="Table_RowC">
                <uc2:jcustomlistselectorcontrol runat="server" id="JCustomListSelectorControlRPMCode" />
            </td>
        </tr>
        <tr>
            <td class="Table_RowB">جدول سهمیه:</td>
            <td class="Table_RowC">
                <telerik:RadTextBox runat="server" ID="txtTableQuotas" Width="90%"></telerik:RadTextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*"
                    ControlToValidate="txtTableQuotas" ValidationGroup="SoftwareRepair" Display="Dynamic"></asp:RequiredFieldValidator>
                <%--<asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="لطفا عدد وارد کنید" Display="Dynamic" 
                    ValidationGroup="SoftwareRepair" ControlToValidate="txtTableQuotas" Type="Double"></asp:CompareValidator>--%>
            </td>
        </tr>
        <tr>
            <td class="Table_RowB">جدول قیمت:</td>
            <td class="Table_RowC">
                <telerik:RadTextBox runat="server" ID="txtTablePrices" Width="90%"></telerik:RadTextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="*"
                    ControlToValidate="txtTablePrices" ValidationGroup="SoftwareRepair" Display="Dynamic"></asp:RequiredFieldValidator>
               <%-- <asp:CompareValidator ID="CompareValidator2" runat="server" ErrorMessage="لطفا عدد وارد کنید" Display="Dynamic" 
                    ValidationGroup="SoftwareRepair" ControlToValidate="txtTablePrices" Type="Double"></asp:CompareValidator>--%>
            </td>
        </tr>
        <tr>
            <td class="Table_RowB">ورژن PT:</td>
            <td class="Table_RowC">
                <telerik:RadTextBox runat="server" ID="txtPtVersion" Width="90%"></telerik:RadTextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="*"
                    ControlToValidate="txtPtVersion" ValidationGroup="SoftwareRepair" Display="Dynamic"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="Table_RowB">نرم افزار GS و داشبورد؟:</td>
            <td class="Table_RowC">
                <asp:RadioButtonList ID="rbGSSoftwareANDDashboard" runat="server">
                    <asp:ListItem Selected="True" Text="بلی" Value="1"></asp:ListItem>
                    <asp:ListItem Selected="False" Text="خیر" Value="0"></asp:ListItem>
                </asp:RadioButtonList>
            </td>
        </tr>
        <tr>
            <td class="Table_RowB">توضیحات نرم افزار GS و داشبورد:</td>
            <td class="Table_RowC">
                <telerik:RadTextBox runat="server" ID="txtGSSoftwareANDDashboardComment" Width="90%"></telerik:RadTextBox>
               <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="*"
                    ControlToValidate="txtGSSoftwareANDDashboardComment" ValidationGroup="SoftwareRepair" Display="Dynamic"></asp:RequiredFieldValidator>--%>
            </td>
        </tr>
        <tr>
            <td class="Table_RowB">ارتباط با مرکز داده؟:</td>
            <td class="Table_RowC">
                <asp:RadioButtonList ID="rbRelationshipStatusDataCenter" runat="server">
                    <asp:ListItem Selected="True" Text="بلی" Value="1"></asp:ListItem>
                    <asp:ListItem Selected="False" Text="خیر" Value="0"></asp:ListItem>
                </asp:RadioButtonList>
            </td>
        </tr>
        <tr>
            <td class="Table_RowB">آخرین تاریخ اتصال:</td>
            <td class="Table_RowC">
               <uc1:JDateControl runat="server" id="txtLastTimeConnectingPooler" />
            </td>
        </tr>
        <tr>
            <td class="Table_RowB">آخرین ساعت اتصال:</td>
            <td class="Table_RowC">
                <telerik:RadTextBox runat="server" ID="txtTimeMinute" Width="40px" MaxLength="2" EmptyMessage="دقیقه"></telerik:RadTextBox>
                <asp:RangeValidator ID="RangeValidator4" runat="server" ErrorMessage="00 تا 59" ControlToValidate="txtTimeMinute" MinimumValue="00"
                    MaximumValue="59" ValidationGroup="Malfunction" Display="Dynamic"></asp:RangeValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="*"
                    ControlToValidate="txtTimeMinute" ValidationGroup="Malfunction" Display="Dynamic"></asp:RequiredFieldValidator>
                :
                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="*"
                    ControlToValidate="txtTimeHour" ValidationGroup="Malfunction" Display="Dynamic"></asp:RequiredFieldValidator>
                <asp:RangeValidator ID="RangeValidator3" runat="server" ErrorMessage="00 تا 23" ControlToValidate="txtTimeHour" MinimumValue="00"
                    MaximumValue="23" ValidationGroup="Malfunction" Display="Dynamic"></asp:RangeValidator>
                <telerik:RadTextBox runat="server" ID="txtTimeHour" Width="40px" MaxLength="2" EmptyMessage="ساعت"></telerik:RadTextBox>
            </td>
        </tr>
    </table>
</div>
<div class="FormButtons">
    <telerik:RadButton runat="server" ID="btnSave" Text="ذخیره" AutoPostBack="true" Width="100px" Height="35px" OnClick="btnSave_Click" ValidationGroup="SoftwareRepair" />
    <telerik:RadButton runat="server" ID="btnClose" Text="بازگشت"  AutoPostBack="true" Width="100px" Height="35px" OnClick="btnClose_Click" />
</div>
