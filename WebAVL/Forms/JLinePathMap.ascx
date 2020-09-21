<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="JLinePathMap.ascx.cs" Inherits="WebAVL.Forms.JLinePathMap" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register Src="~/WebControllers/MainControls/OpenLayersMap/OpenLayersMap.ascx" TagPrefix="uc1" TagName="OpenLayersMap" %>
<%@ Register Src="~/WebControllers/MainControls/Date/JDateControl.ascx" TagPrefix="uc1" TagName="JDateControl" %>

<style>
    .HeightSpace0 {
        clear: both;
        height: 0px;
    }

    .HeightSpace05 {
        clear: both;
        height: 05px;
    }

    .HeightSpace10 {
        clear: both;
        height: 10px;
    }

    .HeightSpace15 {
        clear: both;
        height: 15px;
    }

    .HeightSpace20 {
        clear: both;
        height: 20px;
    }

    .HeightSpace30 {
        clear: both;
        height: 30px;
    }

    .trasparentBackground {
        background: rgba(8, 19, 137, 0.70);
    }
</style>

<div style="width: 100%; height: 100%">
    <uc1:openlayersmap runat="server" id="OpenLayersMap" />
</div>
<div id="OpenControlPanel" style="width: 40px; height: 100px; position: absolute; top: 40px; right: 0px; cursor: pointer; z-index: 998; display: none"
    onclick="FuncOpenControlPanel();">
    <img src="<%= ResolveClientUrl("~/WebBusManagement/Images/OpenControlPanel.png") %>"
        style="width: 40px; height: 100px" alt="باز کردن منوی تنظیمات" title="باز کردن منوی تنظیمات" />
</div>
<div id="Mnu_ControlPanel" class="trasparentBackground" style="width: 20%; height: 100%; position: absolute; top: 0px; right: 0px; z-index: 999; color: white; display: block">
    <div class="HeightSpace20"></div>

    <div style="position: absolute; top: 40px; left: 0px; cursor: pointer" onclick="FuncCloseControlPanel();">
        <img src="<%= ResolveClientUrl("~/WebBusManagement/Images/CloseControlPanel.png") %>"
            style="width: 40px; height: 100px" alt="بستن منوی تنظیمات" title="بستن منوی تنظیمات" />
    </div>
    <div class="HeightSpace10"></div>

    <%--Path Div--%>
    <div id="PathShowMenuBot" style="width: 100%; height: 100%; overflow: auto">
        <div class="HeightSpace10"></div>
        <div style="width: 96%; height: auto; text-align: right; opacity: 1; padding-right: 5px; direction: rtl">
            خط :
            <telerik:RadComboBox runat="server" ID="cmbLines" Width="50%" Filter="Contains"></telerik:RadComboBox>
            <div class="HeightSpace10"></div>
            <input type="radio" id="StationGo" name="StatinList" value="SGO" checked="checked"/>مسیر رفت
            <input type="radio" id="StationBack" name="StatinList" value="SBack" />مسیر برگشت
            <input type="radio" id="StationCircular" name="StatinList" value="SCircular" />مسیر گردشی
            <div class="HeightSpace10"></div>
            <center>
                <input type="button" id="BtnGetInfo" value="مشاهده مسیر خط" onclick="GetLineMarker();"/>
            </center>

        </div>
        <div id="NumberOfTransactionCount" style="width: 96%; height: auto; text-align: right; padding-right: 5px; direction: rtl"></div>

    </div>

    <input type="hidden" runat="server" id="LineMapActionString" />
    <script type="text/javascript">
        function FuncOpenControlPanel() {
            $("#Mnu_ControlPanel").fadeIn();
            $("#OpenControlPanel").fadeOut();
        }

        function FuncCloseControlPanel() {
            $("#Mnu_ControlPanel").fadeOut();
            $("#OpenControlPanel").fadeIn();
        }

        var LineMapActionString = $("#" + "<%=LineMapActionString.ClientID%>");
        var cmbLines = $("#" + "<%=cmbLines.ClientID%>");

        var StattionType;
        function GetLineMarker() {
            $("#NumberOfTransactionCount").html("<br /><br /><center><img src='Images/WhiteLoading_s128.png' style='width:64px;height:64px'/></center>");
            if ($("#StationGo").is(":checked")) {
                StattionType = "0";
            }
            else if ($("#StationBack").is(":checked")) {
                StattionType = "1";
            }
            else {
                StattionType = "2";
            }
            var param = new Array();
            param[0] = cmbLines.val();
            param[1] = StattionType;
            var data = "{actionString:'" + LineMapActionString.val() + "',param:" + JSON.stringify(param) + "}";
            $.ajax({
                url: "../WebControllers/WebService/Action.asmx/RunAction",
                contentType: "application/json",
                cache: false,
                type: "POST",
                data: data,
                async: true,
                error: function (err) {
                    $("#NumberOfTransactionCount").html("");
                },
                success: function (data) {
                    if (data.d[0] != "0") {
                        SetMarkers(data.d[1], "True", data.d[2]);
                        $("#NumberOfTransactionCount").html("");
                    }
                    else {
                        $("#NumberOfTransactionCount").html("");
                        alert('برای این خط مسیری تعریف نشده است');
                    }
                }
            });
        }

    </script>
