<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="JCustomListSelectorControl.ascx.cs" Inherits="WebControllers.MainControls.JCustomListSelectorControl" %>
<%@ Register Assembly="JJson" Namespace="JJson.Controls" TagPrefix="JJson" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<script src="../../FormManager/Js/jquery-1.8.2.js"></script>
<script src="../../FormManager/js/jquery-ui-1.8.24.js"></script>
<script src="../../FormManager/js/jquery-ui-1.8.24.min.js"></script>
<script type="text/javascript">
    $(document).ready(function () {
        //$(".btnSearch").click(function () {
        //    var uid = $(".hdnUid input:first").val();
        //    var codeElementId = $(".txtCode").val();
        //    var titleElementId = $(".txtTitle").val();
        //    var sql = $(".hfd input:first").val();
        //    var searchFields = $(".hfdfields input:first").val();
        //    var title = "جستجو";
        //    $.ajax({
        //        type: 'POST',
        //        url: 'WebControllers/MainControls/CustomListSelector/JCustomListSelectorService.asmx/ShowListViewControl',
        //        data: '{'
        //                + '"queryStringValue":"' + uid + '", '
        //                + '"codeElementId":"' + codeElementId + '", '
        //                + '"titleElementId":"' + titleElementId + '", '
        //                + '"sql":"' + sql + '", '
        //                + '"searchFields":"' + searchFields + '", '
        //                + '"title":"' + title + '"'
        //                + '}',
        //        contentType: "application/json; charset=utf-8",
        //        dataType: "json",
        //        success: function (msg) {
        //            if (msg.d) {
        //                alert("Successfully");
        //                //alert(msg.d);
        //            }
        //        },
        //        error: function (msg) {
        //            alert(msg.responseText);
        //        }
        //    });
        //});
        //$(".txtCode").on("input", function () {//keyup(function () {
        //    if ($(this).val().trim() == "") {
        //        $(".txtTitle").val("");
        //        return;
        //    }
        //    //alert($(".hfd input:first").val());
        //    $.ajax({
        //        type: 'POST',
        //        url: 'WebControllers/MainControls/CustomListSelector/JCustomListSelectorService.asmx/GetTitleByCode',
        //        data: '{'
        //                + '"code":"' + $(this).val() + '", '
        //                + '"sql":"' + $(".hfd input:first").val() + '"'
        //                + '}',
        //        contentType: "application/json; charset=utf-8",
        //        dataType: "json",
        //        success: function (msg) {
        //            if (msg.d.trim() != "undefined") {
        //                //alert(msg.d);
        //                $(".txtTitle").val(msg.d);
        //            }
        //            else {
        //                $(".txtTitle").val("کد نامعتبر است");
        //            }
        //        },
        //        error: function (msg) {
        //            alert("خطا در برقراری ارتباط");
        //        }
        //    });
        //});
    });
</script>

<telerik:RadAjaxManagerProxy runat="server" ID="AjaxManagerProxy_Control">
    <AjaxSettings>
        <telerik:AjaxSetting AjaxControlID="txtCode">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="txtTitle" />
                <telerik:AjaxUpdatedControl ControlID="txtCode" />
            </UpdatedControls>
        </telerik:AjaxSetting>

        <telerik:AjaxSetting AjaxControlID="txtTitle">
        </telerik:AjaxSetting>

        <telerik:AjaxSetting AjaxControlID="btnSearch">
        </telerik:AjaxSetting>

        <telerik:AjaxSetting AjaxControlID="btnUnSelect">
        </telerik:AjaxSetting>
    </AjaxSettings>
</telerik:RadAjaxManagerProxy>
<table>
    <tr>
        <td style="width: 70px">

            <%--<telerik:RadNumericTextBox runat="server" Type="Number" NumberFormat-DecimalDigits="0" NumberFormat-GroupSeparator="" MinValue="0" MaxValue="2147483647" ID="txtCode" AutoPostBack="true" CssClass="txtCode" OnTextChanged="txtCode_TextChanged" Width="70px" ReadOnly="false"></telerik:RadNumericTextBox>--%>
            <%--<telerik:RadNumericTextBox runat="server" Type="Number" NumberFormat-DecimalDigits="0" NumberFormat-GroupSeparator="" MinValue="0" MaxValue="2147483647" ID="txtCode" AutoPostBack="false" CssClass="txtCode" Width="70px" ReadOnly="false"></telerik:RadNumericTextBox>--%>
            <JJson:JJsonNumericTextBox ID="txtCode" runat="server" Width="70px" Event="textchange"></JJson:JJsonNumericTextBox>
        </td>
        <td style="width: 200px">
            <telerik:RadTextBox TabIndex="-1" runat="server" ID="txtTitle" CssClass="txtTitle" Width="200px" ReadOnly="true"></telerik:RadTextBox>
        </td>
        <td style="width: 50px">
            <div class="hfdfields">
                <asp:HiddenField runat="server" ID="hfdfields" />
            </div>
            <div class="hfd">
                <asp:HiddenField runat="server" ID="hfd" />
            </div>
            <div class="hdnUid">
                <asp:HiddenField runat="server" ID="hdnUid" />
            </div>
            <telerik:RadButton runat="server" TabIndex="-1" ID="btnSearch" Text="..." OnClick="btnSearch_Click"></telerik:RadButton>
            <%--<telerik:RadButton runat="server" CssClass="btnSearch" AutoPostBack="false" ID="btnSearch" Text="..."></telerik:RadButton>--%>
        </td>
        <td>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Enabled="false" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtTitle"></asp:RequiredFieldValidator></td>
        </td>
    </tr>
</table>
<%--<telerik:RadButton runat="server" ID="btnUnSelect" Text="عدم انتخاب" OnClick="btnUnSelect_Click"></telerik:RadButton>--%>
