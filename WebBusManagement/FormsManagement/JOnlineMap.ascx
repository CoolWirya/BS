<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="JOnlineMap.ascx.cs" Inherits="WebBusManagement.FormsManagement.JOnlineMap" %>
<%@ Register Src="~/WebControllers/MainControls/OpenLayersMap/OpenLayersMap.ascx" TagPrefix="uc1" TagName="OpenLayersMap" %>

<style>
    .HeightSpace05 {
        clear: both;
        height: 10px;
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
<div id="OpenControlPanel" style="width: 40px; height: 100px; position: absolute; top: 40px; right: 0px; cursor: pointer; z-index: 998"
    onclick="FuncOpenControlPanel();">
    <img src="<%= ResolveClientUrl("~/WebBusManagement/Images/OpenControlPanel.png") %>"
        style="width: 40px; height: 100px" alt="باز کردن منوی تنظیمات" title="باز کردن منوی تنظیمات" />
</div>
<div id="Mnu_ControlPanel" class="trasparentBackground" style="width: 25%; height: 100%; position: absolute; top: 0px; right: 0px; z-index: 999; color: white; display: none">
    <div class="HeightSpace20"></div>
    <div id="BussesMenuTop" style="float: right; width: 33%; height: 20px; text-align: center; cursor: pointer"
        onclick="SelectTab('BussesMenuTop','BussesMenuBot','SettingMenuTop','SettingMenuBot','DetailMenuTop','DetailMenuBot');">
        اتوبوس ها
    </div>
    <div id="SettingMenuTop" style="float: right; width: 33%; height: 20px; text-align: center; cursor: pointer"
        onclick="SelectTab('SettingMenuTop','SettingMenuBot','BussesMenuTop','BussesMenuBot','DetailMenuTop','DetailMenuBot');">
        لایه ها
    </div>
    <div id="DetailMenuTop" style="float: right; width: 34%; height: 20px; text-align: center; cursor: pointer"
        onclick="SelectTab('DetailMenuTop','DetailMenuBot','BussesMenuTop','BussesMenuBot','SettingMenuTop','SettingMenuBot');">
        جزئیات
    </div>

    <div style="position: absolute; top: 40px; left: 0px; cursor: pointer" onclick="FuncCloseControlPanel();">
        <img src="<%= ResolveClientUrl("~/WebBusManagement/Images/CloseControlPanel.png") %>"
            style="width: 40px; height: 100px" alt="بستن منوی تنظیمات" title="بستن منوی تنظیمات" />
    </div>
    <div class="HeightSpace30"></div>

    <div id="BussesMenuBot" style="width: 100%; height: auto; overflow: auto">
        <div style="width: 100%; height: 10px; text-align: right">
            لیست اتوبوس ها : 
        </div>
        <div class="HeightSpace10"></div>
        <div class="HeightSpace10"></div>
        <div style="width: 100%; height: 10px; text-align: right; opacity: 1">
            منطقه : 
            <%=ZonesCmbStr %>
        </div>
        <div class="HeightSpace10"></div>
        <div class="HeightSpace10"></div>
        <div style="width: 100%; height: 10px; text-align: right; opacity: 1">
            خـــــطـ : 
            <%=LinesCmbStr %>
        </div>
        <div class="HeightSpace10"></div>
        <div class="HeightSpace10"></div>
        <div style="width: 100%; height: 10px; text-align: right; opacity: 1">
            جستجو : 
        <input type="text" id="SearchKeyWord" name="SearchKeyWord" style="opacity: 0.6" />
        </div>
        <div class="HeightSpace10"></div>
        <div style="width: 100%; height: 32px">
            <div id="SearchLoading" style="z-index: 120; float: left; width: 100%; height: 32px; display: none">
                <center>
                    <img src="../Images/WhiteLoading_s128.png" style='width:32px;height:32px'/>
                </center>
            </div>
        </div>
        <div class="HeightSpace10"></div>
        <div style="width: 100%; height: 100%; text-align: right; opacity: 1;">
            <input type="checkbox" id="ckhAllBusSelect" checked="checked" />همه ی اتوبوس ها
            <div class="HeightSpace30"></div>
            <div id="Div_CheckBoxListStr" style="position: absolute; bottom: 0px; top: 210px; width: 100%; overflow-y: scroll;margin-top:20px">
                <%=CheckBoxListStr %>
            </div>
        </div>
    </div>

    <div id="SettingMenuBot" style="width: 85%; height: auto; padding-right: 5px; overflow: auto; display: none">
        <%--<div style="width: 100%; height: auto; text-align: right">
            <input type="checkbox" id="chkBusesOnBattery" onchange="SetMapSettingOtherParam();" />فقط نمایش اتوبوس هایی که بر روی باطری هستند
        </div>
        <div class="HeightSpace15"></div>--%>
        <div style="width: 100%; height: auto; text-align: right">
            <input type="checkbox" id="ckhBusesUnder1000Toman" onchange="SetMapSettingOtherParam();" />فقط نمایش اتوبوس هایی که شارژشان زیر 1000 تومان می باشد
        </div>
        <div class="HeightSpace15"></div>
        <div style="width: 100%; height: auto; text-align: right">
            <input type="checkbox" id="chkBusesNoAvlTransactionInOneHourAgo" onchange="SetMapSettingOtherParam();" />نمایش اتوبوس هایی که در بیش از 24 ساعت اخیر تراکنش نداشته اند
        </div>
        <div class="HeightSpace15"></div>
        <div style="width: 100%; height: auto; text-align: right">
            <input type="checkbox" id="chkShowStation" onchange="SetMapSettingOtherParam();" />نمایش ایستگاه ها
        </div>
        <div class="HeightSpace15"></div>
        <div style="width: 100%; height: auto; text-align: right">
            <input type="checkbox" id="chkOverStopTime" onchange="$('#chkOneRetardation').attr('checked', false);
            $('#chkXMeterRetardation').attr('checked', false);SetMapSettingOtherParam();" />فقط نمایش اتوبوس هایی که ابتدای روز بیش از حد مجاز توقف داشته اند
        </div>
        <div class="HeightSpace15"></div>
        <div style="width: 100%; height: auto; text-align: right">
            <input type="checkbox" id="chkOneRetardation" onchange="$('#chkOverStopTime').attr('checked', false);
            $('#chkXMeterRetardation').attr('checked', false);SetMapSettingOtherParam();" />فقط نمایش اتوبوس هایی که حداقل یک تخلف از مسیر از ابتدای روز داشته اند
        </div>
        <div class="HeightSpace15"></div>
        <div style="width: 100%; height: auto; text-align: right">
            <input type="checkbox" id="chkXMeterRetardation" onchange="$('#chkOverStopTime').attr('checked', false);
            $('#chkOneRetardation').attr('checked', false);SetMapSettingOtherParam();" />فقط نمایش اتوبوس هایی که بیش از 
            <input type="text" id="XMeter" value="100" style="width: 30px" maxlength="4" onchange="SetMapSettingOtherParam();"
                onkeypress='return event.charCode >= 48 && event.charCode <= 57' />
            متر فاصله از خط دارند
        </div>
    </div>

    <div id="DetailMenuBot" style="width: 98%; height: 89%; padding-right: 5px; overflow-y: auto; display: none; z-index: 999">
        <img src="<%= ResolveClientUrl("~/WebBusManagement/Images/sync-icon-small.png") %>"
            style="cursor: pointer; width: 32px; height: 32px" onclick="GetLastAvlTransaction();"
            title="به روز رسانی لیست آخرین تراکنش ها" alt="به روز رسانی لیست آخرین تراکنش ها" />
        <table style="width: 92%; height: auto; border: 1px solid #fff" dir="rtl">
            <tr>
                <td style="text-align: center; border: 1px solid #fff">ردیف</td>
                <td style="text-align: center; border: 1px solid #fff">منطقه</td>
                <td style="text-align: center; border: 1px solid #fff">خط</td>
                <td style="text-align: center; border: 1px solid #fff">اتوبوس</td>
                <td style="text-align: center; border: 1px solid #fff">تاریخ</td>
            </tr>
            <%=LastAvlTransactionStr %>
        </table>
    </div>
</div>

<div id="Div_Script" style="display: none">
    <script type="text/javascript">

        SetAddMarkerMode('Simple');
        SetServiceParam('All');

        var ChkBusCount;
        var CkhBusCode = new Array();
        <%=CheckBoxBusCodeArray%>
        <%=CheckBoxListScript%>
        //alert(ChkBusCount);

        $("#ckhAllBusSelect").click(function () {
            if ($("#ckhAllBusSelect").is(":checked")) {
                for (i = 0; i < ChkBusCount; i++) {
                    $("#ckhBus" + CkhBusCode[i]).attr("disabled", true);
                    $("#ckhBus" + CkhBusCode[i]).attr("checked", true);
                }
                CreateStrServiceParamFromCkhBus();
            }
            else {
                for (i = 0; i < ChkBusCount; i++) {
                    $("#ckhBus" + CkhBusCode[i]).attr("disabled", false);
                }
                CreateStrServiceParamFromCkhBus();
            }
        });

        var StrServiceParamFromCkhBus = "";
        var BusCounterForTimerInterval = 0;
        function CreateStrServiceParamFromCkhBus() {
            StrServiceParamFromCkhBus = "";
            for (i = 0; i < ChkBusCount; i++) {
                if ($("#ckhBus" + CkhBusCode[i]).is(":checked")) {
                    StrServiceParamFromCkhBus += "," + CkhBusCode[i];
                    BusCounterForTimerInterval++;
                }
            }
            //alert("ChkBusCount : ", ChkBusCount);
            //alert("BusCounterForTimerInterval : ", BusCounterForTimerInterval);
            if (ChkBusCount == parseInt(BusCounterForTimerInterval) + 1) {
                SetServiceParam('All');
            }
            else {
                SetServiceParam(StrServiceParamFromCkhBus);
            }
            //if (BusCounterForTimerInterval == 1) {
            //BusCounterForTimerInterval = 0;
            //SetNewTimerInterval(6000, true);
            //SetAddMarkerMode('Animate');
            //}
            //else {
            //BusCounterForTimerInterval = 0;
            //SetNewTimerInterval(800, false);
            //SetAddMarkerMode('Simple');
            //}
        }

        //CreateStrServiceParamFromCkhBus();
    </script>
</div>
<input type="hidden" runat="server" id="OnlineMapActionString" />
<input type="hidden" runat="server" id="OnlineMapLastAvlActionString" />
<script type="text/javascript">
    function FuncOpenControlPanel() {
        $("#Mnu_ControlPanel").fadeIn();
        $("#OpenControlPanel").fadeOut();
    }

    function FuncCloseControlPanel() {
        $("#Mnu_ControlPanel").fadeOut();
        $("#OpenControlPanel").fadeIn();
    }

    SelectTab('BussesMenuTop', 'BussesMenuBot', 'SettingMenuTop', 'SettingMenuBot', 'DetailMenuTop', 'DetailMenuBot');
    function SelectTab(STabId, SDivId, OTabId, ODivId, OTabId2, ODivId2) {
        $("#" + STabId).css('border-bottom-style', 'none');
        $("#" + STabId).css('height', '20px');
        $("#" + STabId).css('background-color', '#d32338');

        $("#" + OTabId).css('border-bottom', 'solid 1px #d32338');
        $("#" + OTabId).css('height', '19px');
        $("#" + OTabId).css('background-color', 'transparent');

        $("#" + OTabId2).css('border-bottom', 'solid 1px #d32338');
        $("#" + OTabId2).css('height', '19px');
        $("#" + OTabId2).css('background-color', 'transparent');

        $("#" + ODivId).css('display', 'none');
        $("#" + ODivId2).css('display', 'none');
        $("#" + SDivId).fadeIn();
    }

    function SetMapSettingOtherParam() {
        var StrParam = "";
        //if ($("#chkBusesOnBattery").is(":checked")) {
        //    StrParam += "," + "BusesOnBattery";
        //}
        if ($("#ckhBusesUnder1000Toman").is(":checked")) {
            StrParam += "," + "BusesUnder1000Toman";
        }
        if ($("#chkShowStation").is(":checked")) {
            StrParam += "," + "ShowStation";
        }
        if ($("#chkOverStopTime").is(":checked")) {
            StrParam += "," + "OverStopTime";
        }
        if ($("#chkOneRetardation").is(":checked")) {
            StrParam += "," + "OneRetardation";
        }
        if ($("#chkXMeterRetardation").is(":checked")) {
            if ($("#XMeter").val() != "" && $("#XMeter").val() != null) {
                StrParam += "," + "XMeterRetardation:" + $("#XMeter").val();
            }
            else {
                StrParam += "," + "XMeterRetardation:0";
            }
        }
        if ($("#chkBusesNoAvlTransactionInOneHourAgo").is(":checked")) {
            StrParam += "," + "BusesNoAvlTransactionInOneHourAgo";
        }
        SetOtherParam(StrParam);
    }

    var ResultAjaxRequet = null;
    $("#SearchKeyWord").keyup(function () {
        var myLength = $("#SearchKeyWord").val().length;
        if (parseInt(myLength) > 2) {
            CallWsLoadBus($("#SearchKeyWord").val());
        }
        else if ($("#SearchKeyWord").val() == "" || $("#SearchKeyWord").val() == null) {
            SetServiceParam('All');
            CallWsLoadBus("");
        }
    });

    function CallWsLoadBus(SKeyWord) {
        var paramStr = new Array();
        paramStr[0] = SKeyWord;
        paramStr[1] = $("#ZonesCmb").val();
        paramStr[2] = $("#LinesCmb").val();
        if (ResultAjaxRequet != null) {
            ResultAjaxRequet.abort();
        }
        $("#SearchLoading").fadeIn();
        var data = "{actionString:'" + $("#<%=OnlineMapActionString.ClientID %>").val() + "',param:" + JSON.stringify(paramStr) + "}";
        ResultAjaxRequet = $.ajax({
            url: "../WebControllers/WebService/Action.asmx/RunAction",
            contentType: "application/json",
            cache: false,
            type: "POST",
            data: data,
            async: true,
            error: function (err) {

            },
            success: function (data) {
                $("#SearchLoading").fadeOut();
                $("#Div_CheckBoxListStr").html(data.d[1].toString());
                $("#Div_Script").html(data.d[0].toString() + " " + data.d[2].toString());
                CreateStrServiceParamFromCkhBus();
            }
        });
    }

    window.setInterval(function () {
        GetLastAvlTransaction();
    }, 60 * 1000);
    //window.setInterval(GetLastAvlTransaction, 50000);
    var GetLastAvlTransactionISFinished = false;
    function GetLastAvlTransaction() {
        if (GetLastAvlTransactionISFinished == false) {
            $("#DetailMenuBot").html("<img src='../Images/WhiteLoading_s128.png' style='width:32px;height:32px' title='در حال بارگزاری' alt='در حال بارگزاری'/>");
            GetLastAvlTransactionISFinished = true;
            var paramStr = new Array();
            paramStr[0] = "";
            var data = "{actionString:'" + $("#<%=OnlineMapLastAvlActionString.ClientID %>").val() + "',param:" + JSON.stringify(paramStr) + "}";
            ResultAjaxRequet = $.ajax({
                url: "../WebControllers/WebService/Action.asmx/RunAction",
                contentType: "application/json",
                cache: false,
                type: "POST",
                data: data,
                async: true,
                error: function (err) {
                    GetLastAvlTransactionISFinished = false;
                },
                success: function (data) {
                    $("#DetailMenuBot").html("<img src='<%= ResolveClientUrl("~/WebBusManagement/Images/sync-icon-small.png") %>' " +
                                             "style='cursor: pointer;width:32px;height:32px' onclick='GetLastAvlTransaction();' " +
                                             "title='به روز رسانی جزئیات' alt='به روز رسانی جزئیات'/>" +
                        "<table style='width: 92%; height: auto; border: 1px solid #fff' dir='rtl'>" +
                        "<tr><td style='text-align: center; border: 1px solid #fff'>ردیف</td>" +
                        "<td style='text-align: center; border: 1px solid #fff'>منطقه</td>" +
                        "<td style='text-align: center; border: 1px solid #fff'>خط</td>" +
                        "<td style='text-align: center; border: 1px solid #fff'>اتوبوس</td>" +
                        "<td style='text-align: center; border: 1px solid #fff'>تاریخ</td></tr>" +
                        data.d[0].toString() +
                        "</table>");
                    GetLastAvlTransactionISFinished = false;
                }

            });
            }
        }

</script>
