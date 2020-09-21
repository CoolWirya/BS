<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="JAfterReviewingUpdateControl.ascx.cs" Inherits="WebOilManagement.Forms.JAfterReviewingUpdateControl" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register Src="~/WebControllers/MainControls/Date/JDateControl.ascx" TagPrefix="uc1" TagName="JDateControl" %>
<%@ Register Src="~/WebControllers/MainControls/CustomListSelector/JCustomListSelectorControl.ascx" TagPrefix="uc2" TagName="JCustomListSelectorControl" %>
<%@ Register Src="~/WebControllers/MainControls/Persons/JSearchPersonControl.ascx" TagPrefix="uc3" TagName="JSearchPersonControl" %>

<%--<telerik:RadAjaxManagerProxy runat="server" ID="AjaxManagerProxy_Control">
    <AjaxSettings>
        <telerik:AjaxSetting AjaxControlID="rbFixDefects">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="cmbDontFixDefects" />
                <telerik:AjaxUpdatedControl ControlID="txtDontFixDefectsComment" />
            </UpdatedControls>
        </telerik:AjaxSetting>
         <telerik:AjaxSetting AjaxControlID="cmbDontFixDefects">
            <UpdatedControls>
                
            </UpdatedControls>
        </telerik:AjaxSetting>
        <telerik:AjaxSetting AjaxControlID="txtDontFixDefectsComment">
            <UpdatedControls>
                
            </UpdatedControls>
        </telerik:AjaxSetting>
    </AjaxSettings>
</telerik:RadAjaxManagerProxy>--%>
<div class="FormContent">
    <div class="BigTitle">بازرسی نهایی</div>
    <table>
        <tr>
            <td class="Table_RowB">رفع نواقص؟:</td>
            <td class="Table_RowC">
                <asp:RadioButtonList ID="rbFixDefects" runat="server" AutoPostBack="true" OnSelectedIndexChanged="rbFixDefects_SelectedIndexChanged">
                    <asp:ListItem Selected="False" Text="گزارش اشتباه" Value="2"></asp:ListItem>
                    <asp:ListItem Selected="True" Text="بلی" Value="1"></asp:ListItem>
                    <asp:ListItem Selected="False" Text="خیر" Value="0"></asp:ListItem>
                </asp:RadioButtonList>
            </td>
        </tr>
        <tr>
            <td class="Table_RowB">دلایل عدم رفع نوافص:</td>
            <td class="Table_RowC">
                <telerik:RadComboBox runat="server" ID="cmbDontFixDefects" Enabled="false" Width="100%"></telerik:RadComboBox>
            </td>
        </tr>
        <tr>
            <td class="Table_RowB">توضیحات عدم رفع نوافص:</td>
            <td class="Table_RowC">
                <telerik:RadTextBox runat="server" ID="txtDontFixDefectsComment" Enabled="false" Width="90%"></telerik:RadTextBox>
                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator1"  Enabled="false"  runat="server" ErrorMessage="*"
                    ControlToValidate="txtDontFixDefectsComment" ValidationGroup="AfterReviewing" Display="Dynamic"></asp:RequiredFieldValidator>--%>
            </td>
        </tr>

        <tr>
            <td class="Table_RowB">پرسنل فنی پشتیبان:</td>
            <td class="Table_RowC">
                <%--  <uc1:jsearchpersoncontrol runat="server" id="personTechnicalTeamResponsible" />--%>
                <uc2:JCustomListSelectorControl runat="server" id="RepresentativeSupplierCode" />
            </td>
        </tr>
        <tr>
            <td class="Table_RowB">تاریخ ورود:</td>
            <td class="Table_RowC">
                <uc1:JDateControl runat="server" id="txtInputDateTime" />
            </td>
        </tr>
        <tr>
            <td class="Table_RowB">تاریخ خروج:</td>
            <td class="Table_RowC">
                <uc1:JDateControl runat="server" id="txtOutPutDateTime" />
            </td>
        </tr>
        <%--<tr>
            <td class="Table_RowB">مدیر جایگاه:</td>
            <td class="Table_RowC">
                <uc3:JSearchPersonControl runat="server" id="GasStationManagerCode" />
            </td>
        </tr>--%>
        <tr>
            <td class="Table_RowB">تاریخ تایید مدیر:</td>
            <td class="Table_RowC">
                <uc1:JDateControl runat="server" id="txtGasStationManagerConfirmation" />
            </td>
        </tr>
        <tr>
            <td class="Table_RowB">ساعت تایید مدیر:</td>
            <td class="Table_RowC">
                <telerik:RadTextBox runat="server" ID="txtTimeMinute" Width="40px" MaxLength="2" EmptyMessage="دقیقه"></telerik:RadTextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="*"
                    ControlToValidate="txtTimeMinute" ValidationGroup="AfterReviewing" Display="Dynamic"></asp:RequiredFieldValidator>
                :
                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="*"
                    ControlToValidate="txtTimeHour" ValidationGroup="AfterReviewing" Display="Dynamic"></asp:RequiredFieldValidator>
                <telerik:RadTextBox runat="server" ID="txtTimeHour" Width="40px" MaxLength="2" EmptyMessage="ساعت"></telerik:RadTextBox>
            </td>
        </tr>
    </table>
</div>
<div class="FormButtons">
    <telerik:RadButton runat="server" ID="btnRefer" Text="ارجاع" Font-Bold="true" AutoPostBack="true" Width="100px" Height="35px" OnClick="btnRefer_Click" ValidationGroup="AfterReviewing" />
    <telerik:RadButton runat="server" ID="btnSave" Text="ذخیره" AutoPostBack="true" Width="100px" Height="35px" OnClick="btnSave_Click" ValidationGroup="AfterReviewing" />
    <telerik:RadButton runat="server" ID="btnClose" Text="بازگشت" AutoPostBack="true" Width="100px" Height="35px" OnClick="btnClose_Click" />
</div>
<telerik:RadCodeBlock ID="RadCodeBlock1" runat="server">
    <script type="text/javascript">
        function ReferSuccess() {
            CloseDialog(null);
        }
    </script>
</telerik:RadCodeBlock>

