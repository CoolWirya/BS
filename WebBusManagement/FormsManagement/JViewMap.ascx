<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="JViewMap.ascx.cs" Inherits="WebBusManagement.FormsManagement.JViewMap" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register Src="~/WebControllers/MainControls/OpenLayersMap/OpenLayersMap.ascx" TagPrefix="uc1" TagName="OpenLayersMap" %>
<%@ Register Src="~/WebControllers/MainControls/Date/JDateControl.ascx" TagPrefix="uc2" TagName="JDateControl" %>
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

<div style="width: 100%; height: 100%;z-index: 5999 !important;">
   <uc1:openlayersmap runat="server" id="OpenLayersMap" />
</div>
<div id="OpenControlPanel" style="width: 40px; height: 100px; position: absolute; top: 40px; right: 0px; cursor: pointer; z-index: 5999; display: none"
    onclick="FuncOpenControlPanel();">
    <img src="<%= ResolveClientUrl("~/WebBusManagement/Images/OpenControlPanel.png") %>"
        style="width: 40px; height: 100px" alt="باز کردن منوی تنظیمات" title="باز کردن منوی تنظیمات" />
</div>
<span id="Mnu_ControlPanel" class="trasparentBackground" style="width: 20%; height: 100%; position: absolute; top: 0px; right: 0px; z-index: 5999; color: white; display: inline">
    <div class="HeightSpace20"></div>
    <div id="PathShowMenuTop" style="float: right; width: 70%; height: 20px; text-align: center; cursor: pointer"
        onclick="SelectTab('PathShowMenuTop');">
        نمایش و شبیه سازی مسیر
    </div>
    <div id="HelpMenuTop" style="float: right; width: 30%; height: 20px; text-align: center; cursor: pointer"
        onclick="SelectTab('HelpMenuTop');">
        راهنما
    </div>

    <div style="position: absolute; top: 40px; left: 0px; cursor: pointer" onclick="FuncCloseControlPanel();">
        <img src="<%= ResolveClientUrl("~/WebBusManagement/Images/CloseControlPanel.png") %>"
            style="width: 40px; height: 100px" alt="بستن منوی تنظیمات" title="بستن منوی تنظیمات" />
    </div>
    <div class="HeightSpace10"></div>

    <%--Path Div--%>
    <div id="PathShowMenuBot" style="width: 100%; height: 100%; overflow: auto">
        <div style="width: 96%; height: auto; text-align: right; padding-right: 5px">
            تنظیمات مسیر : 
        </div>
        <div class="HeightSpace10"></div>
        <div style="width: 96%; height: auto; text-align: right; opacity: 1; padding-right: 5px; direction: rtl">
            اتوبوس :
        <telerik:RadComboBox runat="server" ID="cmbBus" Width="50%" Filter="Contains"></telerik:RadComboBox>
            <div class="HeightSpace10"></div>
            تاریخ :
        <div class="HeightSpace05"></div>
            <uc2:JDateControl runat="server" id="txtFromDate" />
            <div class="HeightSpace10"></div>
            از ساعت :
        <div class="HeightSpace05"></div>
            <telerik:RadTextBox runat="server" ID="txtStartTimeMinute" Width="40px" MaxLength="2" EmptyMessage="دقیقه" Text="00"></telerik:RadTextBox>
            :
        <telerik:RadTextBox runat="server" ID="txtStartTimeHour" Width="40px" MaxLength="2" EmptyMessage="ساعت" Text="07"></telerik:RadTextBox>
            <div class="HeightSpace10"></div>
            تا ساعت :
        <div class="HeightSpace05"></div>
            <telerik:RadTextBox runat="server" ID="txtFinishTimeMinute" Width="40px" MaxLength="2" EmptyMessage="دقیقه" Text="00"></telerik:RadTextBox>
            :
        <telerik:RadTextBox runat="server" ID="txtFinishTimeHour" Width="40px" MaxLength="2" EmptyMessage="ساعت" Text="08"></telerik:RadTextBox>
            <div class="HeightSpace10"></div>
            میزان دقت : 
        <telerik:RadComboBox runat="server" ID="cmbAccuracy" Width="30%">
            <Items>
                <telerik:RadComboBoxItem Text="1" Value="1" />
                <telerik:RadComboBoxItem Text="2" Value="2" />
                <telerik:RadComboBoxItem Text="3" Value="3" />
                <telerik:RadComboBoxItem Text="4" Value="4" />
                <telerik:RadComboBoxItem Text="5" Value="5" />
            </Items>
        </telerik:RadComboBox>
            <div class="HeightSpace10"></div>
            <input type="radio" id="rbColorBySpeed" name="ColorDraw" checked="checked" value="رنگبندی مسیر بر اساس سرعت" />رنگبندی مسیر بر اساس سرعت
            <div class="HeightSpace0"></div>
            <input type="radio" id="rbColorByHour" name="ColorDraw" value="رنگبندی مسیر بر اساس ساعت" />رنگبندی مسیر بر اساس ساعت
            <div class="HeightSpace10"></div>
            <center>
            <input type="button" id="BtnGetInfo" value="مشاهده مسیر" onclick="GetBusMarker('Path');"/>
        </center>

            <div class="HeightSpace10"></div>
            <div style="width: 96%; height: auto; text-align: right; padding-right: 5px">
                تنظیمات شبیه سازی :
            </div>
            <div class="HeightSpace10"></div>
            <div style="width: 96%; height: auto; text-align: right; padding-right: 5px">
                سرعت : 
                <telerik:RadComboBox runat="server" ID="cmbSimulationSpeed" Width="30%">
                    <Items>
                        <telerik:RadComboBoxItem Text="1X" Value="1" />
                        <telerik:RadComboBoxItem Text="2X" Value="2" />
                        <telerik:RadComboBoxItem Text="5X" Value="5" />
                        <telerik:RadComboBoxItem Text="10X" Value="10" />
                        <telerik:RadComboBoxItem Text="20X" Value="20" />
                        <%-- <telerik:RadComboBoxItem Text="50X" Value="50" />
                        <telerik:RadComboBoxItem Text="100X" Value="100" />--%>
                    </Items>
                </telerik:RadComboBox>
            </div>
            <div class="HeightSpace10"></div>
            <div style="width: 96%; height: 32px; text-align: right; padding-right: 5px; text-align: center">
                <img id="Play_Icon" src="../WebBusManagement/Images/Play_Icon.png" style="width: 32px; height: 32px; cursor: pointer"
                    alt="شروع شبیه سازی" title="شروع شبیه سازی" onmouseover="$('#Play_Icon').css('opacity','0.6');"
                    onmouseout="$('#Play_Icon').css('opacity','1.0');" onclick="GetBusMarker('Simulation');" />
                <img id="Pause_Icon" src="../WebBusManagement/Images/Pause_Icon.png" style="width: 32px; height: 32px; cursor: pointer; margin-left: 5px; margin-right: 5px"
                    alt="توقف شبیه سازی" title="توقف شبیه سازی" onclick="PauseSimulation();" />
                <img id="PlayAfterPause_Icon" src="../WebBusManagement/Images/Play_AfterPause.png" style="width: 32px; height: 32px; cursor: pointer; margin-left: 5px; margin-right: 5px; opacity: 0.6"
                    alt="ادامه شبیه سازی" title="ادامه شبیه سازی" onclick="PlayAfterPauseSimulation();" />
                <img id="Stop_Icon" src="../WebBusManagement/Images/Stop_Icon.png" style="width: 32px; height: 32px; cursor: pointer"
                    alt="لغو شبیه سازی" title="لغو شبیه سازی" onmouseover="$('#Stop_Icon').css('opacity','0.6');"
                    onmouseout="$('#Stop_Icon').css('opacity','1.0');" onclick="StopSimulation();" />
            </div>
            <div class="HeightSpace10"></div>
            <div id="NumberOfTransactionCount" style="width: 96%; height: auto; text-align: right; padding-right: 5px; direction: rtl"></div>
            <div style="clear: both; height: 1px"></div>
            <div id="NumberOfPointSimulation" style="width: 96%; height: auto; text-align: right; padding-right: 5px; direction: rtl; color: white"></div>
        </div>
    </div>

    <%--Help Div--%>
    <div id="HelpMenuBot" style="width: 100%; height: 100%; overflow: auto">
        <div style="width: 96%; height: auto; text-align: right; padding-right: 5px">
            رنگبندی مسیر بر اساس سرعت :
        </div>
        <div class="HeightSpace15"></div>
        <div style="width: 96%; height: auto; text-align: center; padding-right: 5px">توقف</div>
        <div style="width: 40%; height: 30px; margin-right: 30%; background-color: #000; opacity: 0.6">
        </div>
        <div class="HeightSpace15"></div>
        <div style="width: 96%; height: auto; text-align: center; padding-right: 5px">سرعت مجاز</div>
        <div style="width: 40%; height: 30px; margin-right: 30%; background-color: #00ff00; opacity: 0.6">
        </div>
        <div class="HeightSpace15"></div>
        <div style="width: 96%; height: auto; text-align: center; padding-right: 5px">سرعت غیر مجاز</div>
        <div style="width: 40%; height: 30px; margin-right: 30%; background-color: #ff0000; opacity: 0.6">
        </div>
        <div class="HeightSpace30"></div>
        <div style="width: 96%; height: auto; text-align: right; padding-right: 5px">
            رنگبندی مسیر بر اساس ساعت :
        </div>
        <div style="float: right; width: 47%; height: auto;">
            <div class="HeightSpace20"></div>
            <div style="width: 100%; height: auto; text-align: center; padding-right: 5px">0 تا 4 صبح</div>
            <div style="width: 80%; height: 30px; margin-right: 10%; background-color: #0000ff; opacity: 0.6">
            </div>
            <div class="HeightSpace10"></div>
            <div style="width: 100%; height: auto; text-align: center; padding-right: 5px">4 تا 8 صبح</div>
            <div style="width: 80%; height: 30px; margin-right: 10%; background-color: #663399; opacity: 0.6">
            </div>
            <div class="HeightSpace10"></div>
            <div style="width: 100%; height: auto; text-align: center; padding-right: 5px">8 تا 12 ظهر</div>
            <div style="width: 80%; height: 30px; margin-right: 10%; background-color: #fda250; opacity: 0.6">
            </div>
        </div>
        <div style="float: right; width: 1%; height: auto;"></div>
        <div style="float: right; width: 47%; height: auto;">
            <div class="HeightSpace20"></div>
            <div style="width: 100%; height: auto; text-align: center; padding-right: 5px">12 تا 16 عصر</div>
            <div style="width: 80%; height: 30px; margin-right: 10%; background-color: #FFA500; opacity: 0.6">
            </div>
            <div class="HeightSpace10"></div>
            <div style="width: 100%; height: auto; text-align: center; padding-right: 5px">16 تا 20 شب</div>
            <div style="width: 80%; height: 30px; margin-right: 10%; background-color: #9f4b00; opacity: 0.6">
            </div>
            <div class="HeightSpace10"></div>
            <div style="width: 100%; height: auto; text-align: center; padding-right: 5px">20 تا 24 شب</div>
            <div style="width: 80%; height: 30px; margin-right: 10%; background-color: #000; opacity: 0.6">
            </div>
        </div>
    </div>
</span>

<input type="hidden" runat="server" id="ViewMapActionString" />

<input type="hidden" runat="server" id="PathMapStationAc" />
<input type="hidden" runat="server" id="LineCode" />

<script type="text/javascript">

    function GetStation() {
        var paramStr = new Array();
        paramStr[0] = cmbBus.val();
        var data = "{actionString:'" + $("#<%=PathMapStationAc.ClientID %>").val() + "',param:" + JSON.stringify(paramStr) + "}";
        return $.ajax({
            url: "Services/WebBaseDefineService.asmx/RunAction",
            contentType: "application/json",
            cache: false,
            type: "POST",
            data: data,
            async: true,
            error: function (err) {

            }
        });
    }

    function FuncOpenControlPanel() {
        $("#Mnu_ControlPanel").fadeIn();
        $("#OpenControlPanel").fadeOut();
    }

    function FuncCloseControlPanel() {
        $("#Mnu_ControlPanel").fadeOut();
        $("#OpenControlPanel").fadeIn();
    }

    SelectTab('PathShowMenuTop');
    function SelectTab(STabId) {

        if (STabId == "PathShowMenuTop") {
            $("#PathShowMenuTop").css('border-bottom-style', 'none');
            $("#PathShowMenuTop").css('height', '20px');
            $("#PathShowMenuTop").css('background-color', '#d32338');

            $("#HelpMenuTop").css('border-bottom', 'solid 1px #d32338');
            $("#HelpMenuTop").css('height', '19px');
            $("#HelpMenuTop").css('background-color', 'transparent');

            $("#SimulationMenuBot").css('display', 'none');
            $("#HelpMenuBot").css('display', 'none');
            $("#PathShowMenuBot").fadeIn();
        }
        else if (STabId == "HelpMenuTop") {
            $("#HelpMenuTop").css('border-bottom-style', 'none');
            $("#HelpMenuTop").css('height', '20px');
            $("#HelpMenuTop").css('background-color', '#d32338');

            $("#PathShowMenuTop").css('border-bottom', 'solid 1px #d32338');
            $("#PathShowMenuTop").css('height', '19px');
            $("#PathShowMenuTop").css('background-color', 'transparent');

            $("#PathShowMenuBot").css('display', 'none');
            $("#SimulationMenuBot").css('display', 'none');
            $("#HelpMenuBot").fadeIn();
        }

    }

    var ViewMapActionString = $("#" + "<%=ViewMapActionString.ClientID%>");
    var cmbBus = $("#" + "<%=cmbBus.ClientID%>");
    //var txtFromDate = $("#" + "<%=txtFromDate.ClientID%>");
    var txtFromDate = $("#control_ViewMap_txtFromDate_PersianDateTextBox1");
    var txtStartTimeHour = $("#" + "<%=txtStartTimeHour.ClientID%>");
    var txtStartTimeMinute = $("#" + "<%=txtStartTimeMinute.ClientID%>");
    var txtFinishTimeHour = $("#" + "<%=txtFinishTimeHour.ClientID%>");
    var txtFinishTimeMinute = $("#" + "<%=txtFinishTimeMinute.ClientID%>");
    var cmbAccuracy = $("#" + "<%=cmbAccuracy.ClientID%>");
    var cmbSimulationSpeed = $("#" + "<%=cmbSimulationSpeed.ClientID%>");
    //var rbColorByHour = $("#rbColorByHour");
    //var rbColorBySpeed = $("#rbColorBySpeed");

    function ValidateSubmit() {
        var Res = false;
        if (txtFromDate.val() == "" || txtFromDate.val() == null) {
            Res = true;
            alert('لطفا تاریخ را انتخاب کنید');
        }
        else if (txtStartTimeHour.val() == "" || txtStartTimeHour.val() == null) {
            Res = true;
            alert('لطفا ساعت شروع را وارد کنید');
        }
        else if (txtStartTimeMinute.val() == "" || txtStartTimeMinute.val() == null) {
            Res = true;
            alert('لطفا دقیقه شروع را وارد کنید');
        }
        else if (txtFinishTimeHour.val() == "" || txtFinishTimeHour.val() == null) {
            Res = true;
            alert('لطفا ساعت پایان را وارد کنید');
        }
        else if (txtFinishTimeMinute.val() == "" || txtFinishTimeMinute.val() == null) {
            Res = true;
            alert('لطفا دقیقه پایان را وارد کنید');
        }
        else if (parseInt(txtStartTimeHour.val()) < 0 || parseInt(txtStartTimeHour.val()) > 23) {
            Res = true;
            alert('لطفا ساعت شروع را به درستی وارد کنید');
        }
        else if (parseInt(txtFinishTimeHour.val()) < 0 || parseInt(txtFinishTimeHour.val()) > 23) {
            Res = true;
            alert('لطفا ساعت پایان را به درستی وارد کنید');
        }
        else if (parseInt(txtStartTimeMinute.val()) < 0 || parseInt(txtStartTimeMinute.val()) > 59) {
            Res = true;
            alert('لطفا دقیقه پایان را به درستی وارد کنید');
        }
        else if (parseInt(txtFinishTimeMinute.val()) < 0 || parseInt(txtFinishTimeMinute.val()) > 59) {
            Res = true;
            alert('لطفا دقیقه پایان را به درستی وارد کنید');
        }
        else if ($.isNumeric(txtStartTimeHour.val()) == false) {
            Res = true;
            alert('لطفا ساعت شروع را به درستی وارد کنید');
        }
        else if ($.isNumeric(txtStartTimeMinute.val()) == false) {
            Res = true;
            alert('لطفا دقیقه شروع را به درستی وارد کنید');
        }
        else if ($.isNumeric(txtFinishTimeHour.val()) == false) {
            Res = true;
            alert('لطفا ساعت پایان را به درستی وارد کنید');
        }
        else if ($.isNumeric(txtFinishTimeMinute.val()) == false) {
            Res = true;
            alert('لطفا دقیقه پایان را به درستی وارد کنید');
        }
        return Res;
    }


    var SimulationPathInterval;
    var TimerPause;
    function GetBusMarker(RunKey) {
        RemovePopups();
        RemoveAllLine();
        RemoveMarkers();
        $.when(GetStation()).done(
            function (data) {
                SetMarkerAndloadIt(data.d);
                if (ValidateSubmit() == false) {
                    $("#NumberOfTransactionCount").html("<br /><br /><center><img src='Images/WhiteLoading_s128.png' style='width:64px;height:64px'/></center>");
                    var param = new Array();
                    param[0] = cmbBus.val();
                    param[1] = txtFromDate.val();
                    param[2] = txtStartTimeHour.val() + ":" + txtStartTimeMinute.val() + ":00";
                    param[3] = txtFinishTimeHour.val() + ":" + txtFinishTimeMinute.val() + ":00";
                    param[4] = cmbAccuracy.val();
                    if ($("#rbColorByHour").is(":checked")) {
                        param[5] = "ColorByHour";
                    }
                    else if ($("#rbColorBySpeed").is(":checked")) {
                        param[5] = "ColorBySpeed";
                    }
                    param[6] = 1;
                    var data = "{actionString:'" + ViewMapActionString.val() + "',param:" + JSON.stringify(param) + "}";
                    $.ajax({
                        url: "Services/WebBaseDefineService.asmx/RunAction",
                        contentType: "application/json",
                        cache: false,
                        type: "POST",
                        data: data,
                        async: true,
                        error: function (err) {

                        },
                        success: function (data) {
                            if (data.d[2] != "0") {
                                if (parseInt(data.d[2].toString()) > 0) {
                                    $("#NumberOfTransactionCount").html("<br />" + "اتوبوس : " + cmbBus.val() + "<div style='clear:both;height:3px'></div>"
                                        + "تعداد تراکنش های دریافت شده : " + data.d[2].toString() + "<div style='clear:both;height:3px'></div>"
                                        + "کد پرسنلی راننده : " + data.d[4].toString() + "<div style='clear:both;height:3px'></div>"
                                        + "نام راننده : " + data.d[5].toString() + "<div style='clear:both;height:3px'></div>"
                                        + "منطقه : " + data.d[7].toString() + "<div style='clear:both;height:3px'></div>"
                                        + "خط : " + data.d[6].toString());
                                    if (RunKey == "Path") {
                                        var MaxMarkersNumber = parseInt(data.d[0].toString());
                                        var PartsCount = parseInt(data.d[1].toString());
                                        AddBusMarkers(param, PartsCount, MaxMarkersNumber);
                                    }
                                    else if (RunKey == "Simulation") {
                                        var MarkerCounter = 0;
                                        var LineColorCounter = 0;
                                        var SimulationMarkers = data.d[2];
                                        var PrevMarker = new Array();
                                        var SimulationLineColor = data.d[7];
                                        var SimulationLine = new Array();
                                        var SimulationDrawLine = "False";
                                        var SimulationRemoveMarker = "True";
                                        var DifferenceBetweenTime = new Array();
                                        DifferenceBetweenTime = data.d[8];
                                        var TimerCounter = 0;
                                        TimerPause = false;
                                        SimulationPathInterval = setInterval(function () {
                                            if (TimerPause == false) {
                                                TimerCounter++;
                                                if (TimerCounter >= parseInt(parseInt(DifferenceBetweenTime[LineColorCounter]) / parseInt(cmbSimulationSpeed.val()))) {
                                                    TimerCounter = 0;
                                                    if (MarkerCounter < SimulationMarkers.length) {
                                                        if (SimulationMarkers[MarkerCounter] == "Marker") {
                                                            if (SimulationDrawLine == "True") {
                                                                PrevMarker = SimulationMarkers[MarkerCounter - 1].toString().split("{!~!}");
                                                                SimulationLine[0] = "Null";
                                                                SimulationLine[1] = "Null";
                                                                SimulationLine[2] = PrevMarker[0];
                                                                SimulationLine[3] = PrevMarker[1];
                                                                SimulationLine[4] = "SimulationLine_" + MarkerCounter;
                                                                SimulationLine[5] = "";
                                                                SimulationLine[6] = SimulationLineColor[LineColorCounter];
                                                                SimulationLine[7] = "0.6";
                                                                SimulationLine[8] = "6";
                                                            }
                                                            LineColorCounter++;
                                                            MapSetCenter(SimulationMarkers[MarkerCounter + 1].split("{!~!}")[0], SimulationMarkers[MarkerCounter + 1].split("{!~!}")[1]);
                                                            AddOneMarkerAndDrawLine(SimulationRemoveMarker, SimulationMarkers[MarkerCounter + 1], SimulationDrawLine, SimulationLine);
                                                            $("#NumberOfPointSimulation").html("در حال رسم نقطه ی " + "<b style='font-weight:bold;color:#00ff00'>" +
                                                                LineColorCounter + "</b>" + " " + "از " + "<b style='font-weight:bold;color:#00ff00'>" + SimulationMarkers.length / 2 + "</b>"
                                                                + " " + "نقطه");
                                                        }
                                                        MarkerCounter++;
                                                        SimulationRemoveMarker = "False";
                                                        SimulationDrawLine = "True";
                                                    }
                                                    else {
                                                        clearInterval(SimulationPathInterval);
                                                        $("#NumberOfPointSimulation").html("");
                                                    }
                                                }
                                            }
                                        }, 500);
                                    }
                                }
                                else {
                                    $("#NumberOfTransactionCount").html("");
                                    $("#NumberOfPointSimulation").html("");
                                    alert("اطلاعاتی موجود نمی باشد");
                                }
                            }
                            else {
                                $("#NumberOfTransactionCount").html("");
                                $("#NumberOfPointSimulation").html("");
                                alert("اطلاعاتی موجود نمی باشد");
                            }
                        }

                    });
                }
            });
    }

    function AddBusMarkers(param, PartsCount, MaxMarkersNumber) {
        if (param[6] <= PartsCount) {
            var data = "{actionString:'" + ViewMapActionString.val() + "',param:" + JSON.stringify(param) + "}";
            $.ajax({
                url: "Services/WebBaseDefineService.asmx/RunAction",
                contentType: "application/json",
                cache: false,
                type: "POST",
                data: data,
                async: true,
                error: function (err) {

                },
                success: function (result) {
                    SetMarkersAppend(result.d[3], "True", result.d[8], "True", (param[6] - 1) * MaxMarkersNumber);
                    param[6] = param[6] + 1;
                    AddBusMarkers(param, PartsCount, MaxMarkersNumber);
                }
            });
        }
    }

    function PauseSimulation() {
        if (TimerPause == false) {
            TimerPause = true;
            $("#Pause_Icon").css('opacity', '0.6');
            $("#PlayAfterPause_Icon").css('opacity', '1.0');
            $("#NumberOfPointSimulation").html($("#NumberOfPointSimulation").html() + " " + "<b style='color:red'>متوقف</b>");
        }
    }

    function PlayAfterPauseSimulation() {
        if (TimerPause == true) {
            TimerPause = false;
            $("#PlayAfterPause_Icon").css('opacity', '0.6');
            $("#Pause_Icon").css('opacity', '1.0');
        }
    }

    function StopSimulation() {
        clearInterval(SimulationPathInterval);
        RemoveMarkers();
        RemoveAllLine();
        $("#NumberOfTransactionCount").html("");
        $("#NumberOfPointSimulation").html("");
    }

</script>
