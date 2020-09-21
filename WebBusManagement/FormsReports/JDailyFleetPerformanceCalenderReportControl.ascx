<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="JDailyFleetPerformanceCalenderReportControl.ascx.cs" Inherits="WebBusManagement.FormsReports.JDailyFleetPerformanceCalenderReportControl" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register Src="~/WebControllers/MainControls/Date/JDateControl.ascx" TagPrefix="uc1" TagName="JDateControl" %>

<div class="BigTitle">گزارش تقویم کارکرد کل</div>
<table style="width: 500px">
    <tr class="Table_RowC">
        <td style="width: 150px">ناوگان:</td>
        <td>
            <telerik:RadComboBox runat="server" ID="cmbFleets" Width="100%" Filter="Contains">
            </telerik:RadComboBox>
        </td>
    </tr>
    <tr class="Table_RowB">
        <td style="width: 150px">منطقه:</td>
        <td>
            <telerik:RadComboBox runat="server" ID="cmbZone" Width="100%" Filter="Contains">
            </telerik:RadComboBox>
        </td>
    </tr>
    <tr class="Table_RowC">
        <td style="width: 150px">خط:</td>
        <td>
            <telerik:RadComboBox runat="server" ID="cmbLine" Width="100%" Filter="Contains">
            </telerik:RadComboBox>
        </td>
    </tr>
    <tr class="Table_RowB">
        <td style="width: 150px">مالک:</td>
        <td>
            <telerik:RadComboBox runat="server" ID="cmbBusOwner" Width="100%" Filter="Contains"></telerik:RadComboBox>
        </td>
    </tr>
    <tr class="Table_RowC">
        <td>
            <asp:RadioButton ID="rdbYearMonth" runat="server" Text="انتخاب ماه" AutoPostBack="true" OnCheckedChanged="rdbYearMonth_CheckedChanged" Checked="True" />
        <td>
            <asp:RadioButton ID="rdbCustomDate" runat="server" Text="تاریخ دلخواه" AutoPostBack="true" OnCheckedChanged="rdbYearMonth_CheckedChanged" />
        <td>
    </tr>
</table>

<asp:Panel ID="pnlCustomDateTime" runat="server" Visible="False">
    <table style="width: 500px">
        <tr class="Table_RowB">
            <td style="width: 150px">از تاریخ :</td>
            <td>
                <uc1:JDateControl runat="server" id="dteControlFrom" />
            </td>
        </tr>
        <tr class="Table_RowC">
            <td style="width: 150px">تا تاریخ :</td>
            <td>
                <uc1:JDateControl runat="server" id="dteControlTo" />
            </td>
        </tr>
    </table>
</asp:Panel>
<asp:Panel ID="pnlYearMonth" runat="server">
    <table style="width: 500px">
        <tr class="Table_RowB">
            <td style="width: 150px">سال:</td>
            <td>
                <telerik:RadComboBox runat="server" ID="cmbYears" Width="100%" Filter="Contains">
                </telerik:RadComboBox>
            </td>
        </tr>
        <tr class="Table_RowC">
            <td style="width: 150px">ماه:</td>
            <td>
                <telerik:RadComboBox runat="server" ID="cmbMount" Width="100%" Filter="Contains">
                    <Items>
                        <telerik:RadComboBoxItem Value="1" Text="01-فروردین" Selected="true" />
                        <telerik:RadComboBoxItem Value="2" Text="02-اردیبهشت" />
                        <telerik:RadComboBoxItem Value="3" Text="03-خرداد" />
                        <telerik:RadComboBoxItem Value="4" Text="04-تیر" />
                        <telerik:RadComboBoxItem Value="5" Text="05-مرداد" />
                        <telerik:RadComboBoxItem Value="6" Text="06-شهریور" />
                        <telerik:RadComboBoxItem Value="7" Text="07-مهر" />
                        <telerik:RadComboBoxItem Value="8" Text="08-آبان" />
                        <telerik:RadComboBoxItem Value="9" Text="09-آذر" />
                        <telerik:RadComboBoxItem Value="10" Text="10-دی" />
                        <telerik:RadComboBoxItem Value="11" Text="11-بهمن" />
                        <telerik:RadComboBoxItem Value="12" Text="12-اسفند" />
                    </Items>
                </telerik:RadComboBox>
            </td>
        </tr>
    </table>
</asp:Panel>

<div style="clear: both; height: 15px;"></div>
<input type="button" id="btnSave" title="مشاهده گزارش" value="مشاهده گزارش" style="width: 100px; height: 30px" onclick="GetReport()" />
<%--<telerik:RadButton runat="server" ID="btnSave" Text="مشاهده گزارش" AutoPostBack="false" Width="100px" Height="35px" OnClientClicked="GetReport()" />--%>
<%--OnClick="btnSave_Click"--%>
<%--<telerik:RadButton runat="server" ID="btnClose" Text="بازگشت" OnClientClicked="CloseDialog" AutoPostBack="false" Width="100px" Height="35px" />--%>
<input type="button" id="btnClose" title="بازگشت" value="بازگشت" style="width: 100px; height: 30px" onclick="CloseDialog()" />
<div style="clear: both; height: 15px;"></div>
<div style="width: 100%; height: 32px">
    <div id="SearchLoading" style="z-index: 120; float: left; width: 100%; height: 32px; display: none">
        <center>
                    <img src="../Images/loading_s128.png" style='width:128px;height:128px'/>
                </center>
    </div>
</div>
<table style="width: 100%">
    <tr>
        <td style="width: 100%; height: 20px; text-align: center"></td>
    </tr>
</table>
<div style="width: 1000px; height: auto; margin-right: auto; margin-left: auto">
    <div style="float: right; width: 100px; height: 20px; background-color: #9b9797; color: white; text-align: center">
        بدون تراکنش
    </div>
    <div style="float: right; width: 100px; height: 20px; background-color: #ca8383; color: white; text-align: center">
        تایید نشده
    </div>
    <div style="float: right; width: 100px; height: 20px; background-color: #0094ff; color: white; text-align: center">
        پرداخت نشده
    </div>
    <div style="float: right; width: 100px; height: 20px; background-color: #ffd800; color: black; text-align: center">
        بدون پرینت
    </div>
    <div style="float: right; width: 100px; height: 20px; background-color: #3aa807; color: white; text-align: center">
        کامل
    </div>
    <div style="float: right; width: 100px; height: 20px; background-color: #15d42b; color: black; text-align: center">
        تایید شده با پرینت
    </div>
    <div style="float: right; width: 100px; height: 20px; background-color: #00ff21; color: black; text-align: center">
        برابر با پرینت
    </div>
    <div style="float: right; width: 100px; height: 20px; background-color: #ff0000; color: white; text-align: center">
        بیشتر از پرینت
    </div>
    <div style="float: right; width: 100px; height: 20px; background-color: #60f6c3; color: black; text-align: center">
        کمتر از پرینت
    </div>
    <div style="float: right; width: 100px; height: 20px; background-color: #75cf7a; color: white; text-align: center">
        عدم ارسال درب ها
    </div>
</div>

<div style="clear:both;height:5px"></div>
<div style="width: 860px; height: auto; margin-right: auto; margin-left: auto">
    <div style='float:right;background-color:yellow;color:black;width:122px;height:15px;text-align:center'>
        شنبه
    </div>
     <div style='float:right;background-color:yellow;color:black;width:122px;height:15px;text-align:center'>
        یکشنبه
    </div>
     <div style='float:right;background-color:yellow;color:black;width:122px;height:15px;text-align:center'>
        دوشنبه
    </div>
     <div style='float:right;background-color:yellow;color:black;width:122px;height:15px;text-align:center'>
        سه شنبه
    </div>
     <div style='float:right;background-color:yellow;color:black;width:122px;height:15px;text-align:center'>
        چهارشنبه
    </div>
     <div style='float:right;background-color:yellow;color:black;width:122px;height:15px;text-align:center'>
        پنجشنبه
    </div>
     <div style='float:right;background-color:yellow;color:black;width:123px;height:15px;text-align:center'>
        جمعه
    </div>
</div>

<div style="clear: both; height: 5px"></div>
<div style="width: 860px; height: auto; margin-right: auto; margin-left: auto" id="HtmlMainDiv">
    
</div>
<input type="hidden" runat="server" id="AllBusPerformanceCalender" />
<input type="hidden" id="DateH" />
<input type="hidden" id="BusNumberH" />
<input type="hidden" id="IsSentH" />


<input type="hidden" runat="server" id="AllBusPerformanceCalenderGetReport" />

<div id="dialog-confirm" title="ثبت درخواست">
    <p><span class="ui-icon ui-icon-alert" style="float: right; text-align: right; direction: rtl; margin: 0 7px 20px 0;"></span>لطفا نوع درخواست خود را انتخاب کنید</p>
</div>

<script type="text/javascript">



    function SetParam(DateH, BusNumberH, IsSentH) {
        $("#DateH").val(DateH);
        $("#BusNumberH").val(BusNumberH);
        $("#IsSentH").val(IsSentH);
        //  $(function () {
        $("#dialog-confirm").dialog({
            resizable: false,
            height: 140,
            modal: true,
            buttons: {
                "درخواست پرینت": function () {
                    InsertPrintRequest(0);
                },
                "درخواست ارسال": function () {
                    InsertPrintRequest(1);
                }
            }
        });
        // });
    }

    function InsertPrintRequest(ISSent) {
        var paramStr = new Array();
        paramStr[0] = $("#DateH").val();
        paramStr[1] = $("#BusNumberH").val();
        paramStr[2] = ISSent;
        var data = "{actionString:'" + $("#<%=AllBusPerformanceCalender.ClientID %>").val() + "',param:" + JSON.stringify(paramStr) + "}";
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
                if (data.d == "1") {
                    alert('درخواست شما با موفقیت ثبت شد');
                }
                else {
                    alert('خطا در ثبت درخواست');
                }
            }
        });
    }

    //int Year = 0, int Mount = 0, int Zone = 0, int Line = 0, int OwnerCode = 0 , DateTime From , DateTime To , int rdTransactionType , bool rdbYearMonth
    var FinalHtml;
    var NumOfDay;
    var Buses;
    var Rafid = 1;
    var BusesIArray = new Array();
    var NumOfDayArray = new Array();
    var BgColor = "";
    var fColor = "";
    var SumFlag = 0;
    var FtCount = 0;
    var ColumnSum = new Array(31);
    var FinalAllColumnSum = 0;
    function GetReport() {
        $("#SearchLoading").css('display', 'block');
        var paramStr = new Array();
        paramStr[0] = $("#<%=cmbYears.ClientID %>").val();
        paramStr[1] = $("#<%=cmbMount.ClientID %>").val().toString().split('-')[0];
        paramStr[2] = $("#<%=cmbZone.ClientID %>").val().toString().split('-')[0];
        if (parseInt($("#<%=cmbLine.ClientID %>").val().toString().split('-')[0]) == 0) {
            paramStr[3] = 0;
        }
        else {
            paramStr[3] = $("#<%=cmbLine.ClientID %>").val().toString().split('-')[1]
        }
        paramStr[4] = $("#<%=cmbBusOwner.ClientID %>").val().toString().split('-')[0];
        paramStr[5] = "0";
        paramStr[6] = "0";
        paramStr[7] = "0";
        if ($("#<%=rdbYearMonth.ClientID %>").is(":checked")) {
            paramStr[8] = 'true'
        }
        else {
            paramStr[8] = 'false'
        }
        paramStr[9] = $("#<%=cmbFleets.ClientID %>").val().toString().split('-')[0];
        var ShowForNumber = parseInt(0);
        var data = "{actionString:'" + $("#<%=AllBusPerformanceCalenderGetReport.ClientID %>").val() + "',param:" + JSON.stringify(paramStr) + "}";
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
                $("#SearchLoading").css('display', 'none');
                $("#HtmlMainDiv").html("");
                <%--FinalHtml = "";
                Buses = null;
                Rafid = 1;
                BusesIArray = null;
                NumOfDayArray = null;
                BgColor = "";
                fColor = "";
                SumFlag = 0;
                FtCount = 0;
                //ColumnSum = null;
                FinalAllColumnSum = 0;
                FinalHtml += "<div style='float:right;background-color:Yellow;color:Black;width:42px;height:20px;text-align:center;border : 1px solid black ; border-left:none'>ردیف</div>";
                FinalHtml += "<div style='float:right;background-color:Yellow;color:Black;width:42px;height:20px;text-align:center;border : 1px solid black ; border-left:none'>خط</div>";
                FinalHtml += "<div style='float:right;background-color:Yellow;color:Black;width:42px;height:20px;text-align:center;border : 1px solid black ; border-left:none'>اتوبوس</div>";
                if (parseInt($("#<%=cmbMount.ClientID %>").val().toString().split('-')[0]) <= 6) { NumOfDay = 31; } else { NumOfDay = 30; }
                for (var DayN = 1; DayN <= NumOfDay; DayN++) {
                    ColumnSum[DayN - 1] = 0;
                    FinalHtml += "<div style='float:right;background-color:Yellow;color:Black;width:42px;height:20px;text-align:center;border : 1px solid black; border-left:none'>" + DayN + "</div>";
                }
                FinalHtml += "<div style='float:right;background-color:Yellow;color:Black;width:42px;height:20px;text-align:center;border : 1px solid black ; border-left:none'>مجموع</div>";
                FinalHtml += "<div style='clear:both'></div>";

                Buses = data.d.toString().split('{###}');
                for (var i = 1 ; i < Buses.length ; i++) {
                    BusesIArray = Buses[i].toString().split('{-}');
                    FinalHtml += "<div style='float:right;background-color:Yellow;color:Black;width:42px;height:20px;text-align:center;border : 1px solid black ; border-left:none'>" + Rafid + "</div>";
                    FinalHtml += "<div style='float:right;background-color:Yellow;color:Black;width:42px;height:20px;text-align:center;border : 1px solid black ; border-left:none'>" + BusesIArray[1] + "</div>";
                    FinalHtml += "<div style='float:right;background-color:Yellow;color:Black;width:42px;height:20px;text-align:center;border : 1px solid black ; border-left:none'>" + BusesIArray[0] + "</div>";
                    if (BusesIArray.length > 2) {
                        NumOfDayArray = BusesIArray[2].toString().split('[#]');
                        for (var j = 0 ; j < NumOfDayArray.length - 1 ; j++) {
                            if (ShowForNumber == 2) {
                                FtCount = NumOfDayArray[j].toString().split(',')[0];
                            }
                            else if (ShowForNumber == 1) {
                                FtCount = NumOfDayArray[j].toString().split(',')[2];
                            }
                            else if (ShowForNumber == 3) {
                                FtCount = NumOfDayArray[j].toString().split(',')[3];
                            }
                            ColumnSum[j] = parseInt(ColumnSum[j]) + parseInt(FtCount);
                            if (NumOfDayArray[j].toString().split(',')[0] == 0) {
                                FtCount = GetBusFailureCode(NumOfDayArray[j].toString().split(',')[7]);
                            }
                            BgColor = GetCellBaclColor(NumOfDayArray[j].toString().split(',')[0], NumOfDayArray[j].toString().split(',')[1],
                                NumOfDayArray[j].toString().split(',')[2], NumOfDayArray[j].toString().split(',')[3],
                                NumOfDayArray[j].toString().split(',')[4], NumOfDayArray[j].toString().split(',')[5]);
                            fColor = GetCellForeColor(BgColor);
                            FinalHtml += "<div " + GetOnClickStr(BgColor, NumOfDayArray[j].toString().split(',')[8], BusesIArray[0], 0) + " style='float:right;background-color:" + BgColor + ";color:" + fColor + ";width:42px;height:20px;text-align:center;border : 1px solid black ; border-left:none;cursor:pointer'>" + FtCount + "</div>";
                            if (parseInt(NumOfDayArray[j].toString().split(',')[0]) > 0) {
                                SumFlag = j;
                            }
                        }
                        FinalHtml += "<div style='float:right;background-color:Yellow;color:Black;width:42px;height:20px;text-align:center;border : 1px solid black ; border-left:none'>" + NumOfDayArray[SumFlag].toString().split(',')[6] + "</div>";
                        FinalHtml += "<div style='clear:both'></div>";
                    }
                    Rafid = parseInt(Rafid) + 1;
                }

                FinalHtml += "<div style='float:right;background-color:Yellow;color:Black;width:128px;height:20px;text-align:center;border : 1px solid black ; border-left:none'>مجموع</div>";
                for (var SI = 0 ; SI < NumOfDay ; SI++) {
                    FinalHtml += "<div style='float:right;background-color:yellow;color:black;width:42px;height:20px;text-align:center;border : 1px solid black ; border-left:none;font-size:11px'>" + ColumnSum[SI] + "</div>";
                    FinalAllColumnSum = parseInt(FinalAllColumnSum) + parseInt(ColumnSum[SI]);
                }
                FinalHtml += "<div style='float:right;background-color:Yellow;color:Black;width:42px;height:20px;text-align:center;border : 1px solid black ; border-left:none;font-size:11px'>" + FinalAllColumnSum + "</div>";--%>

                $("#HtmlMainDiv").html(data.d);
            }
        });
    }

    function GetBusFailureCode(FCode) {
        if (FCode == "81180194")
            return "1";
        else if (FCode == "81180195")
            return "2";
        else if (FCode == "81180196")
            return "3";
        else if (FCode == "81180197")
            return "4";
        else if (FCode == "81180198")
            return "5";
        else if (FCode == "81180199")
            return "6";
        else if (FCode == "81180200")
            return "7";
        else
            return "0";
    }

    function GetCellForeColor(BgColor) {
        if (BgColor == "#ffd800" | BgColor == "#15d42b" | BgColor == "#00ff21" | BgColor == "#ff0000" | BgColor == "#60f6c3") {
            return "Black";
        }
        else {
            return "white";
        }
    }

    function GetOnClickStr(BgColor, Date, BusNumber, ISSENT) {
        if (BgColor == "#9b9797" | BgColor == "#ca8383" | BgColor == "#ffd800" | BgColor == "#15d42b" | BgColor == "#ff0000" | BgColor == "#60f6c3" | BgColor == "#75cf7a") {
            return 'onclick="SetParam(' + Date + ',' + BusNumber + ',' + ISSENT + ');"';
        }
        else {
            return 'onclick="alert(' + "نیازی به ثبت درخواست برای این روز نیست" + ');"';
        }
    }

    function GetCellBaclColor(TCount, TaeedTCount, ApplyTCount, PaymnetTCount, FrontDoor, BackDoor) {
        var AllTicketDoor;
        AllTicketDoor = parseInt(FrontDoor) + parseInt(BackDoor);
        if ((ApplyTCount > 0) & (TCount > 0) & (TCount - ApplyTCount) >= -5 & (TCount - ApplyTCount) <= 5) {
            return "#3aa807";
        }
        else if ((TCount > 0) & (ApplyTCount > 0) & (AllTicketDoor == TCount) & (TCount > ApplyTCount)) {
            return "#3aa807";
        }
        else if (TCount == 0) {
            return "#9b9797";
        }
        else if (ApplyTCount == 0) {
            return "#ffd800";
        }
        else if ((TCount == TaeedTCount) & (TCount == ApplyTCount) & (TCount < PaymnetTCount)) {
            return "#0094ff";
        }
        else if ((TCount == TaeedTCount) & (TCount == ApplyTCount) & (TCount == PaymnetTCount)) {
            return "#3aa807";
        }
        else if ((TCount == TaeedTCount) & (TCount == ApplyTCount)) {
            return "#15d42b";
        }
        else if (TCount == ApplyTCount) {
            return "#00ff21";
        }
        else if (TCount > ApplyTCount) {
            return "#ff0000";
        }
        else if (TCount < ApplyTCount) {
            return "#60f6c3";
        }
        else if ((TaeedTCount == 0) | (TaeedTCount < TCount)) {
            return "#ca8383";
        }
    }

</script>

