<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Controls.aspx.cs" Inherits="WebERP.Controls" EnableViewState="True" Buffer="true" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <meta name="referrer" content="no-referrer"> <!-- don't send HTTP referer for privacy purpose and to use Google Maps Geocoding API without key -->
<%--    <script src="WebControllers/MainControls/OpenLayersMap/OpenLayers.js"></script>--%>
    <link href="Style/MainStyleSheet.css" rel="stylesheet" />
    <link href="Style/PersianDateStyle.css" rel="stylesheet" />
    <link href="Style/persianDatePicker-default.css" rel="stylesheet" />
    <link href="Style/Slider.css" rel="stylesheet" />
    <link href="Style/jquery-ui.css" rel="stylesheet" />
    <link href="Style/jquery.ui.all.css" rel="stylesheet" />
    <link href="Style/jquery.ui.dialog.css" rel="stylesheet" />
    <link href="Style/jquery.ui.theme.css" rel="stylesheet" />
    <link href="Style/elRTE/elrte-inner.css" rel="stylesheet" />
    <link href="Style/elRTE/elrte.full.css" rel="stylesheet" />
    <link href="Style/elRTE/elrte.min.css" rel="stylesheet" />
    <link href="Style/elRTE/jquery-ui-1.8.13.custom.css" rel="stylesheet" />
    <script src="Script/elRTE/jquery-1.6.1.min.js"></script>
    <script src="Script/jquery-1.8.2.js"></script>
    <script src="Script/C630N.js"></script>
    <script src="Script/JQueryUploader.js"></script>
    <script src="Script/persianDatepicker.js"></script>
    <script src="Script/jquery-ui-1.8.24.js"></script>
    <script src="Script/jquery-ui-1.8.24.min.js"></script>
    <script src="Script/JSlider.js"></script>
    <script src="Script/create.js"></script>

    <script src="Script/elRTE/jquery-ui-1.8.13.custom.min.js"></script>
    <script src="Script/elRTE/elrte.min.js"></script>

    
    <script type="text/javascript">
        $(document).ready(function () {
        });
    </script>

    <style type="text/css">
        html {
            overflow: hidden !important;
        }
    </style>

</head>
<body style="overflow: hidden">
    <%-- onload="waitPreloadPage();">--%>
    <form id="form1" runat="server" style="overflow: hidden">
        <%--        <a  id="a_print" href="#" data-reveal-id="dv-reveal-modal"></a>
            <div id="dv-reveal-modal" class="reveal-modal">
                <a href='#' class='close-reveal-modal'>×</a>
                <div id="dv_print">
            </div>
        </div>--%>
        <div id="dv-MasterMessage" class="dv-warining " style="display: none;">
            <div id="dv-MessageWarningText">
                <div class="master-msg-ico"></div>
                <span id="sp-global-txt"></span>
                <a class="a-remove-warning">×</a>
            </div>
        </div>
        <telerik:RadCodeBlock runat="server" ID="rcb1">
            <script type="text/javascript">

                var IsButtonClicked = false;
                function LockButton(button, args)
                {
                    if (IsButtonClicked)
                        button.set_enabled(false);
                    IsButtonClicked = true;

                }

                function ASPSnippetsPager(a, b) {
                    var c = '<a style = "cursor:pointer" class="page" page = "{1}">{0}</a>';
                    var d = "<span>{0}</span>";
                    var e, f, g;
                    f = 0;
                    var g = 5;
                    var h = Math.ceil(b.RecordCount / b.PageSize);
                    if (b.PageIndex > h) {
                        b.PageIndex = h
                    }
                    //a.html(sumFieldsRow);
                    var i = "";
                    if (h > 1) {
                        f = h > g ? g : h;
                        e = b.PageIndex > 1 && b.PageIndex + g - 1 < g ? b.PageIndex : 1;
                        if (b.PageIndex > g % 2) {
                            if (b.PageIndex == 2)
                                f = 5;
                            else
                                f = b.PageIndex + 2
                        }
                        else {
                            f = g - b.PageIndex + 1
                        }
                        if (f - (g - 1) > e) {
                            e = f - (g - 1)
                        }
                        if (f > h) {
                            f = h;
                            e = f - g + 1 > 0 ? f - g + 1 : 1
                        }
                        var j = (b.PageIndex - 1) * b.PageSize + 1;
                        var k = j + b.PageSize - 1;
                        if (k > b.RecordCount) {
                            k = b.RecordCount
                        }
                        //i = "<b>Records " + (j == 0 ? 1 : j) + " - " + k + " of " + b.RecordCount + "</b> ";
                        if (f > 0) {
                            i += "<br />";
                            //if (b.PageIndex > 1) {
                            i += c.replace("{0}", "<<").replace("{1}", "1");
                            i += c.replace("{0}", "<").replace("{1}", b.PageIndex > 1 ? b.PageIndex - 1 : 1)
                            //}
                            for (var l = e; l <= f; l++) {
                                if (l == b.PageIndex) {
                                    i += d.replace("{0}", l)
                                }
                                else {
                                    i += c.replace("{0}", l).replace("{1}", l)
                                }
                            }
                            //if (b.PageIndex < h) {
                            i += c.replace("{0}", ">").replace("{1}", b.PageIndex < h ? b.PageIndex + 1 : h);
                            i += c.replace("{0}", ">>").replace("{1}", h)
                            i += "<br /><br />";
                        }
                        i += "<span class=\"pageInfo\"> نمایش رکوردهای <b>" + (j == 0 ? 1 : j) + "</b> تا <b>" + k + "</b> از مجموع <b>" + b.RecordCount + "</b> رکورد </span>";
                        i += "<span style=\"background-color:white;border:none;color:black;width:150px;text-align:left;\">تعداد رکورد در صفحه:</span>";
                        //}
                    }
                    if (h > 1)
                        a.html(i);
                    else
                        a.html("<span  page = \"1\" class=\"page pageInfo\"> نمایش رکوردهای <b>1</b> تا <b>" + b.RecordCount + "</b> از مجموع <b>" + b.RecordCount + "</b> رکورد </span>" + "<span style=\"background-color:transparent;border:none;color:black;width:150px;text-align:left;\">تعداد رکورد در صفحه:</span>");
                    try {
                        a[0].disabled = false
                    }
                    catch (m) { }
                }

                function FillListControl(controlId, data, keyField, textField) {
                    var xmlDoc = $.parseXML(data.d);
                    var xml = $(xmlDoc);
                    var dt = xml.find("datatable");
                    var listItems = [];
                    $.each(dt, function () {
                        listItems.push('<option value="' +
						$(this).find(keyField).text() + '">' + $(this).find(textField).text()
						+ '</option>');
                    });
                    $('#' + controlId).empty();
                    $('#' + controlId).append(listItems.join(''));
                }

                function fillGrid(res, gridId, gridParentId, fields, filterItem_Fields, filterItem_Vals) {
                    //alert(res);
                    var xmlDoc = $.parseXML(res);
                    var xml = $(xmlDoc);
                    var dt = xml.find("datatable");
                    //alert(dt);
                    var filterRowIndex = $('#' + gridId + ' tr.filterRow').index();
                    var pageLastRowIndex = $('#' + gridId + ' tr.sumfields:first').index() - 1;
                    var row = null;
                    if (pageLastRowIndex > 1)
                        row = $('#' + gridId + ' tr').eq(pageLastRowIndex).clone(true);
                    else
                        row = $('#' + gridId + ' tr:last-child').clone(true);
                    row.removeClass("filterRow");
                    //alert($("td", row).eq(0).html());
                    if ($("td", row).eq(0).html().replace(/&nbsp;/g, '') == '')
                        if (filterRowIndex >= 0)
                            $('#' + gridId + ' tr:last-child').not($('#' + gridId + ' tr:eq(' + filterRowIndex + ')')).remove();
                        else
                            $('#' + gridId + ' tr:last-child').remove();
                    if (filterRowIndex >= 0)
                        $('#' + gridId + ' tr').not($('#' + gridId + ' tr:first-child')).not($('#' + gridId + ' tr:eq(' + filterRowIndex + ')')).remove();
                    else
                        $('#' + gridId + ' tr').not($('#' + gridId + ' tr:first-child')).remove();
                    var rowNum = 1;
                    if (filterRowIndex < 0) {
                        var filterBoxText = "<input type=\"text\" style=\"height:20px;width:100%;\"; id=\"" + gridParentId + "_{0}_filterBox\" value=\"{2}\" oninput=\"" + gridParentId + "_onInput_FilterBox('{1}',this.id)\" onkeypress=\"" + gridParentId + "_KeypressEvent(event)\" />";
                        var filterRow = row.clone(true);
                        filterRow.addClass("filterRow");
                        $("td", filterRow).eq(0).html('<input type="button" style="width:80px; height:25px; background-color:#cdcdcd;" id="' + gridParentId + '_execFilter" value="اعمال فیلتر" onclick="' + gridParentId + '_onInput_ExecFilter(); return false;" />' + '<input type="button" style="width:80px; height:25px; background-color:#cdcdcd;" id="' + gridParentId + '_removeFilter" value="حذف فیلتر" onclick="' + gridParentId + '_onInput_RemoveFilter();return false;" />');
                        for (var i = 1; i < fields.length; i++)
                            $("td", filterRow).eq(i).html(filterBoxText.replace('{0}', fields[i]).replace('{1}', fields[i]).replace('{2}', filterItem_Fields.indexOf(fields[i]) >= 0 ? filterItem_Vals[filterItem_Fields.indexOf(fields[i])] : ''));
                        $('#' + gridId).append(filterRow);
                    }
                    var moneyColumns = [];
                    eval("moneyColumns = " + gridParentId + "_moneyColumns.map(function(value) {return value.toLowerCase();})");
                    $.each(dt, function () {
                        //if (rowNum++ == 0) {

                        //}
                        for (var i = 0; i < fields.length; i++) {
                            var CellText = '';
                            if (isNaN(parseInt(fields[i])))
                                CellText = $(this).find(fields[i]).text();
                            else
                                CellText = $(this).find('col-' + fields[i]).text();
                            if (moneyColumns.indexOf(fields[i]) >= 0)
                                CellText = CellText.replace(/\B(?=(\d{3})+(?!\d))/g, ",");
                            $("td", row).eq(i).html(CellText);
                        }
                        //$("td", row).eq(1).html($(this).find("PersonCode").text());
                        //$("td", row).eq(2).html($(this).find("PersonName").text());
                        //$("td", row).eq(3).html($(this).find("Mobile").text());
                        //$("td", row).eq(4).html($(this).find("Status").text());
                        row.removeClass("evenRow");
                        row.removeClass("oddRow");
                        var rowColor = $(this).find("c630n_bg_color").text();
                        if (rowColor == "default" || rowColor == '')
                            row.addClass(rowNum % 2 == 0 ? "evenRow" : "oddRow");
                        else
                            row.css("background-color", rowColor);
                        rowNum++;
                        $('#' + gridId).append(row);
                        row = $('#' + gridId + ' tr:last-child').clone(true);
                    });
                    sumFieldsRow += "<table cellspacing='0' cellpading='0' border='0' style='padding: 0px; margin: 0px; border-width: 0px;'><tr><td style='text-align:right;' dir='rtl'>جمع:</td></tr><tr><td style='text-align:left; '>{page_sum}</td></tr>"
						+ "<tr><td style='text-align:right;' dir='rtl'>جمع-کل:</td></tr><tr><td style='text-align:left; '>{total_sum}</td></tr>"
						+ "<tr><td style='text-align:right;' dir='rtl'>تاریخ:</td></tr><tr><td style='text-align:left; '>{date}</td></tr>"
						+ "<tr><td style='text-align:right;' dir='rtl'>ساعت:</td></tr><tr><td style='text-align:left; '>{time}</td></tr></table>";
                    var sumFieldsDT = xml.find("sumfields");
                    for (var i = 0; i < fields.length; i++) {
                        $("td", row).eq(i).html('');
                    }
                    var sumCount = 0;
                    $.each(sumFieldsDT, function () {
                        var idx = fields.indexOf($(this).find("field").text().toLowerCase());
                        console.log(idx);
                        //alert($(this).find("field").text() + "\t\t\t" + idx);
                        var page_sum = $(this).find("page_sum").text();
                        var total_sum = $(this).find("total_sum").text();
                        if (moneyColumns.indexOf($(this).find("field").text()) >= 0)
                        {
                            page_sum = page_sum.replace(/\B(?=(\d{3})+(?!\d))/g, ",");
                            total_sum = total_sum.replace(/\B(?=(\d{3})+(?!\d))/g, ",");
                        }
                        var sum_temp = sumFieldsRow.replace("{page_sum}", page_sum);
                        sum_temp = sum_temp.replace("{total_sum}", total_sum);
                        sum_temp = sum_temp.replace("{date}", $(this).find("date").text());
                        sum_temp = sum_temp.replace("{time}", $(this).find("time").text());
                        //$(sum_temp + ' tr').addClass("sumfields");
                        $(row).addClass("sumfields");
                        $("td", row).eq(sumCount++ * 8 + idx).html(sum_temp.replace("undefined", ""));
                    });
                    if (sumCount > 0)
                        $('#' + gridId).append(row);
                    //row = $('#' + gridId + ' tr:last-child').clone(true);
                    //if ($('#' + gridId).height() > $('#ContentZone').height() - 170 - 60)
                    //    $('#' + gridId).parent().css("max-height", $('#ContentZone').height() - 170);
                    //else {
                    //    $('.Pager').parent().css("position", "fixed");
                    //    $('.Pager').parent().css("top", $('#ContentZone').height() - 90);
                    //    //$('#' + gridId).parent().find('[id*=_PageSizeTextBox]').css("position", "fixed");
                    //    //$('#' + gridId).parent().find('[id*=_PageSizeTextBox]').css("top", $('#ContentZone').height() - 90);
                    //}
                    $('#' + gridId).parent().css("max-width", $('#ContentZone').width());
                    $('#' + gridId).parent().parent().css("max-width", $('#ContentZone').width() - 40);
                    var sumFieldsRow = "";//$('#' + gridId + ' tr:last-child').clone(true);
                    //<td colspan=" + fields.length + ">
                    ////$('#' + gridId).append(sumFieldsRow);
                    //$("#" + gridId + "_sumfields").remove();
                    //$('#' + gridId).parent().append(sumFieldsRow);
                };
                function OnClientClicking(sender, args) {
                    var callBackFunction = Function.createDelegate(sender, function (argument) {
                        if (argument) {
                            this.click();
                        }
                    });
                    var text = "از حذف این آیتم مطمئن هستید؟";
                    radconfirm(text, callBackFunction, 300, 100, null, "حذف");
                    args.set_cancel(true);
                }

                function GetRadWindow() {
                    var oWindow = null;
                    if (window.radWindow) oWindow = window.radWindow;
                    else if (window.frameElement.radWindow) oWindow = window.frameElement.radWindow;
                    return oWindow;
                }

                function CloseDialog(button) {
                    GetRadWindow().close();
                }

                function ShowMenu(menuItem) {
                    var data = JSON.stringify({ "menuItem": menuItem });
                    var ResultAjaxRequet = $.ajax({
                        url: "../Controls.aspx/MenuItemClick",
                        contentType: "application/json",
                        cache: true,
                        type: "POST",
                        data: data,
                        async: true,
                        error: function (err) {
                            alert('ERR');
                        },
                        success: function (data) {
                            if (data.d != null && data.d.toString().trim().length != 0) {
                                var oManager = GetRadWindowManager();
                                oManager.closeAll();
                                var r = data.d.toString().split(":|:");
                                oWindow = radopen(r[0], r[1]);
                                oWindow.set_title(r[1]);
                                oWindow.set_visibleStatusbar(false);
                                if (r[2] == "isRestricted=true") oWindow.set_restrictionZoneID('<%=ContentZone.ClientID %>');
                                oWindow.set_destroyOnClose(true);
                                oWindow.set_animation(Telerik.Web.UI.WindowAnimation.Fade);
                                oWindow.setActive(true);
                                oWindow.set_showContentDuringLoad(true);

                                if (r[4] != '') {
                                    oWindow.set_width(r[4]);
                                    oWindow.set_height(r[5]);
                                }
                                else
                                    oWindow.maximize();
                                oWindow.center();
                            }
                        }
                    });
                }
                $(document).ready(function () {
                    //for table row
                    $(".CustomTable tr:even").attr('class', 'Table_RowB');
                    $(".CustomTable tr:odd").attr('class', 'Table_RowC');
                    $('.a-remove-warning').live('click', function (e) {
                        $('#dv-MasterMessage').hide();
                    });

                });
                function ShowWarining(msg, bConstant, kind, small_container) {
                    var my_dv = $('#dv-MasterMessage');
                    $('.master-msg-ico').removeClass("warning-ico error-ico loading-ico success-ico");

                    if (small_container)
                        $('#dv-MasterMessage').css({'width': '350px', 'right': '30px'});
                    else
                        $('#dv-MasterMessage').css({ 'width': '480px', 'right': '25%' });

                    if (kind == 1)// error
                    {
                        $('.master-msg-ico').addClass('error-ico');
                    }
                    if (kind == 2)// warning
                    {
                        $('.master-msg-ico').addClass('warning-ico');
                    }
                    if (kind == 3)// loading
                    {
                        $('.master-msg-ico').addClass('loading-ico');
                    }
                    if (kind == 4)// success
                    {
                        $('.master-msg-ico').addClass('success-ico');
                    }

                    //warning-ico

                    my_dv.show();
                    $('#sp-global-txt').html('');
                    $('#sp-global-txt').html(msg);
                    if (!bConstant)
                        window.setTimeout(function () { my_dv.fadeOut(1000) }, 8000);
                }
                function HideWarining() {
                    $('#dv-MasterMessage').hide();
                    $('#sp-global-txt').text('');
                    $('.master-msg-ico').removeClass("warning-ico error-ico loading-ico success-ico");
                }
            </script>
        </telerik:RadCodeBlock>
        <telerik:RadWindowManager runat="server" ID="winMgr" Style="z-index: 20000" Modal="true" DestroyOnClose="true" />
        <div class="modalDiv" id="messageDiv" style="display: none">
            <div id="messageBoxDiv" style="background-color: #FFF; border: 1px solid #808080; position: relative; display: inline-block">
                <img id="messageImg" src="" style="z-index: 300; float: left" />
                <div id="messageTextDiv" style="text-align: right"></div>
                <div style="background-color: #EEE; bottom: 0; position: absolute; width: 96%; text-align: center; padding: 5px">
                    <input type="button" value="OK" style="width: 50px" onclick="document.getElementById('messageDiv').style.display = 'none';" />
                </div>
            </div>
        </div>
        <div id="ContentZone" runat="server" style="height: 100%; width: 100%; overflow: auto">
            <%--<cc1:JGridView runat="server" id="RadGridReport"></cc1:JGridView>--%>
            <%--<telerik:RadFormDecorator ID="QsfFromDecorator" runat="server" DecoratedControls="All" EnableRoundedCorners="false" Skin="Windows7" />--%>
            <telerik:RadScriptManager runat="server" ID="RadScriptManager1" />
            <telerik:RadSkinManager ID="QsfSkinManager" runat="server" Skin="Windows7" ShowChooser="false" />
            <telerik:RadAjaxManager ID="AjaxManagerProxy1" runat="server" DefaultLoadingPanelID="AxajLoadingPanel">
            </telerik:RadAjaxManager>
            <telerik:RadAjaxLoadingPanel runat="server" ID="AxajLoadingPanel" />
            <asp:HiddenField ID="hSUID" runat="server" />
            <div id="dialogDiv" style="display: none"></div>
        </div>
    </form>
</body>
</html>
