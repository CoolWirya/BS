<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WebOilFailure_GS_Nozzle_Control.ascx.cs" Inherits="WebControllers.MainControls.CustomListSelector.WebOilFailure_GS_Nozzle_Control" %>
<%@ Register Src="~/MainControls/CustomListSelector/JCustomListSelectorControl.ascx" TagPrefix="uc1" TagName="JCustomListSelectorControl" %>
<script src="../../FormManager/Js/jquery-1.8.2.js"></script>
<script src="../../FormManager/js/jquery-ui-1.8.24.js"></script>
<script src="../../FormManager/js/jquery-ui-1.8.24.min.js"></script>
<script type="text/javascript">
    $(document).ready(function () {
        $("#<%=jgs.FindControl("txtCode").ClientID%>").keyup(function () {
            //if ($(this).val().trim() == "") {
            //    $(".txtTitle").val("");
            //    return;
            //}
            //$.ajax({
            //    type: 'POST',
            //    url: 'WebControllers/MainControls/CustomListSelector/JCustomListSelectorService.asmx/GetTitleByCode',
            //    data: '{'
            //            + '"code":"' + $(this).val() + '", '
            //            + '"sql":"' + $(".hfd input:first").val() + '"'
            //            + '}',
            //    contentType: "application/json; charset=utf-8",
            //    dataType: "json",
            //    success: function (msg) {
            //        if (msg.d.trim() != "undefined") {
            //            //alert(msg.d);
            //            $(".txtTitle").val(msg.d);
            //        }
            //        else {
            //            $(".txtTitle").val("کد نامعتبر است");
            //        }
            //    },
            //    error: function (msg) {
            //        alert("خطا در برقراری ارتباط");
            //    }
            //});
            alert("ok");
        });
    });
</script>
<uc1:JCustomListSelectorControl runat="server" ID="jgs" />
<uc1:JCustomListSelectorControl runat="server" ID="jnozzle" />
<div class="hfdGS">
    <asp:HiddenField runat="server" ID="hfdGS" />
</div>
<div class="hfdNozzle">
    <asp:HiddenField runat="server" ID="hfdNozzle" />
</div>