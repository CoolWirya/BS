<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="JSearchPersonControl.ascx.cs" Inherits="WebControllers.MainControls.JSearchPersonControl" %>
<%@ Register Assembly="JJson" Namespace="JJson.Controls" TagPrefix="JJson" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<script src="WebControllers/FormManager/Js/jquery-1.8.2.js"></script>
<script src="WebControllers/FormManager/js/jquery-ui-1.8.24.js"></script>
<script src="WebControllers/FormManager/js/jquery-ui-1.8.24.min.js"></script>
<script type="text/javascript">
    //qqq
    //$(document).ready(function () {
    //    $(".personCode").keyup(function () {
    //        if ($(this).val().trim() == "") {
    //            $(".personName").val("");
    //            return;
    //        }
    //        $.ajax({
    //            type: 'POST',
    //            url: 'WebControllers/MainControls/CustomListSelector/JCustomListSelectorService.asmx/GetPersonByCode',
    //            data: '{'
    //                    + '"code":"' + $(this).val() + '"'
    //                    + '}',
    //            contentType: "application/json; charset=utf-8",
    //            dataType: "json",
    //            success: function (msg) {
    //                if (msg.d.trim() != "undefined") {
    //                    //alert(msg.d);
    //                    $(".personName").val(msg.d);
    //                }
    //                else {
    //                    $(".personName").val("کد نامعتبر است");
    //                }
    //            },
    //            error: function (msg) {
    //                alert("خطا در برقراری ارتباط");
    //            }
    //        });
    //    });
    //});
</script>

<telerik:RadAjaxManagerProxy runat="server" ID="AjaxManagerProxy_Control">
    <AjaxSettings>
        <telerik:AjaxSetting AjaxControlID="txtPersonCode">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="txtPersonName" />
                <telerik:AjaxUpdatedControl ControlID="txtPersonCode" />
                <telerik:AjaxUpdatedControl ControlID="lblName" />
                <telerik:AjaxUpdatedControl ControlID="lblLastName" />
                <telerik:AjaxUpdatedControl ControlID="lblBrthDate" />
                <telerik:AjaxUpdatedControl ControlID="lblIDNo" />
                <telerik:AjaxUpdatedControl ControlID="lblFatherName" />
                <telerik:AjaxUpdatedControl ControlID="lblNationalNo" />
            </UpdatedControls>
        </telerik:AjaxSetting>
    </AjaxSettings>
</telerik:RadAjaxManagerProxy>
<telerik:RadCodeBlock runat="server">
    <script type="text/javascript">
        function CallShowMenu_<%=txtPersonCode.ClientID %>() {
            ShowMenu('<%=(new WebClassLibrary.JActionsInfo("PersonList", WebClassLibrary.JDomains.JActionEvents.MouseClick, "WebControllers.MainControls.JPersonLists.GetPersonWindow",null,null)).ActionToString() %>{!::!}<%=txtPersonCode.ClientID %>{!::!}<%=txtPersonName.ClientID %>');
        }
    </script>
</telerik:RadCodeBlock>
<table>
    <tr>
        <td style="width: 70px">
            <%--<telerik:RadNumericTextBox runat="server" Type="Number" NumberFormat-DecimalDigits="0" NumberFormat-GroupSeparator="" MinValue="0" MaxValue="2147483647" AutoPostBack="true" ID="txtPersonCode" OnTextChanged="txtPersonCode_TextChanged" Width="70px" ReadOnly="false"></telerik:RadNumericTextBox>--%>
            <%--<telerik:RadNumericTextBox runat="server" Type="Number" NumberFormat-DecimalDigits="0" NumberFormat-GroupSeparator="" MinValue="0" MaxValue="2147483647" AutoPostBack="false" ID="txtPersonCode" CssClass="personCode" Width="70px" ReadOnly="false"></telerik:RadNumericTextBox>--%>
            <JJson:JJsonNumericTextBox ID="txtPersonCode" CssClass ="personCode" Width="70px" runat="server" Event="textchange"></JJson:JJsonNumericTextBox>
        </td>
        <td style="width: 200px">
            <telerik:RadTextBox runat="server" ID="txtPersonName" TabIndex="-1" CssClass="personName" Width="200px" ReadOnly="true"></telerik:RadTextBox>
        </td>
        <td style="width: 50px">
            <telerik:RadButton runat="server" ID="btnSearch" Text="..." TabIndex="-1" AutoPostBack="false"></telerik:RadButton>
        </td>
    </tr>
</table>
<asp:Panel ID="pnlDetails" runat="server" GroupingText="مشخصات شخص حقیقی" Visible="false">
    <table style="width: 100%">
        <tr class="Table_RowB">
            <td style="width: 20%">نام:</td>
            <td style="width: 30%">
                <asp:Label ID="lblName" runat="server" /></td>
            <td style="width: 20%">نام خانوادگی:</td>
            <td style="width: 30%">
                <asp:Label ID="lblLastName" runat="server" /></td>
        </tr>
        <tr class="Table_RowC">
            <td style="width: 20%">تاریخ تولد:</td>
            <td style="width: 30%">
                <asp:Label ID="lblBrthDate" runat="server" /></td>
            <td style="width: 20%">شماره شناسنامه:</td>
            <td style="width: 30%">
                <asp:Label ID="lblIDNo" runat="server" /></td>
        </tr>
        <tr class="Table_RowB">
            <td style="width: 20%">نام پدر:</td>
            <td style="width: 30%">
                <asp:Label ID="lblFatherName" runat="server" /></td>
            <td style="width: 20%">شماره ملی:</td>
            <td style="width: 30%">
                <asp:Label ID="lblNationalNo" runat="server" /></td>
        </tr>
    </table>
</asp:Panel>
