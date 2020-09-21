<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="JMalfunctionUpdateControl.ascx.cs" Inherits="WebOilManagement.Forms.JMalfunctionUpdateControl" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register Src="~/WebControllers/MainControls/CustomListSelector/JCustomListSelectorControl.ascx" TagPrefix="uc1" TagName="JCustomListSelectorControl" %>
<%@ Register Src="~/WebControllers/MainControls/Persons/JSearchPersonControl.ascx" TagPrefix="uc2" TagName="JSearchPersonControl" %>
<%@ Register Src="~/WebControllers/MainControls/Date/JDateControl.ascx" TagPrefix="uc3" TagName="JDateControl" %>
<%@ Register Src="~/WebAutomation/Refer/JReferViewControl.ascx" TagPrefix="uc1" TagName="JReferViewControl" %>
<%@ Register Src="~/WebControllers/ArchiveDocument/JArchiveControl.ascx" TagPrefix="uc1" TagName="JArchiveControl" %>

<%--<%@ Register Src="~/WebControllers/MainControls/CustomListSelector/WebOilFailure_GS_Nozzle_Control.ascx" TagPrefix="uc5" TagName="WebOilFailure_GS_Nozzle_Control" %>--%>
<script src="../../FormManager/Js/jquery-1.8.2.js"></script>
<script src="../../FormManager/js/jquery-ui-1.8.24.js"></script>
<script src="../../FormManager/js/jquery-ui-1.8.24.min.js"></script>
<script type="text/javascript">
    $(document).ready(function () {
        $(".txtNozzleCode").attr("disabled", "disabled");
        $(".txtGasStationCode").keyup(function () {
            if ($(this).val().trim() == "") {
                $(".txtGasStationTitle").val("");
                return;
            }
            $.ajax({
                type: 'POST',
                url: 'WebControllers/MainControls/CustomListSelector/JCustomListSelectorService.asmx/GetGasStationByCode',
                data: '{'
                        + '"code":"' + $(this).val() + '" '
                        + '}',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (msg) {
                    if (msg.d.trim() != "undefined") {
                        //alert(msg.d);
                        $(".txtGasStationTitle").val(msg.d.split("|")[0]);
                        $(".hdnGS input:first").val(msg.d.split("|")[1]);
                        $(".txtNozzleCode").removeAttr("disabled");
                        //alert(msg.d.split("|")[1]);
                    }
                    else {
                        $(".txtGasStationTitle").val("کد نامعتبر است");
                        $(".txtNozzleCode").attr("disabled", "disabled");
                    }
                },
                error: function (msg) {
                    alert("خطا در برقراری ارتباط");
                    $(".txtNozzleCode").attr("disabled", "disabled");
                }
            });
        });
        //$(".chbIsOfficeDamage2").(function (e) {
        //    alert($(this).val());
        //});

        $(".chbIsOfficeDamage2").change(function () {

            if ($(this).is(":checked")) {
                $(".txtNozzleTitle").val("0");
                $(".txtNozzleCode").val("0");
                $(".hdnNozzleCode").val("0");
                $(".txtNozzleCode").attr("readonly", "readonly");
                $(".txtNozzleTitle").attr("readonly", "readonly");

            }
            else {
                $(".txtNozzleCode").removeAttr("readonly");
                $(".txtNozzleTitle").removeAttr("readonly");

            }
        });

        $("#btnRefer").click(function () {
            GetRadWindow();
            BrowserWindow.RefreshGrid();
            CloseDialog(null);
        });



        $(".txtNozzleCode").keyup(function () {
            if ($(this).val().trim() == "") {
                $(".txtNozzleTitle").val("");
                return;
            }
            $.ajax({
                type: 'POST',
                url: 'WebControllers/MainControls/CustomListSelector/JCustomListSelectorService.asmx/GetNozzleByGasStationCode',
                data: '{'
                        + '"nozzleCode":"' + $(this).val() + '", '
                        + '"gsCode":"' + $(".hdnGS input:first").val() + '" '
                        + '}',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (msg) {
                    if (msg.d.trim() != "undefined") {
                        //alert(msg.d);
                        $(".txtNozzleTitle").val(msg.d);
                        //$(".hdnNozzle input:first").val(msg.d.split("|")[1]);
                    }
                    else {
                        $(".txtNozzleTitle").val("کد نامعتبر است");
                    }
                },
                error: function (msg) {
                    alert("خطا در برقراری ارتباط");
                }
            });
        });
    });
</script>



<div class="FormContent">
    <div class="BigTitle">فرم اعلام خرابی</div>
     <asp:UpdatePanel ID="UpdatePanel1" runat="server"><ContentTemplate>
    <telerik:RadTabStrip runat="server" ID="RadTabStrip1"
        SelectedIndex="0" MultiPageID="RadMultiPage1" Width="100%">
        <Tabs>
            <telerik:RadTab Text="اطلاعات">
            </telerik:RadTab>
            <telerik:RadTab Text="ارجاعات">
            </telerik:RadTab>
            <telerik:RadTab Text="ضمائم">
            </telerik:RadTab>
            <%--  <telerik:RadTab Text="بستن پیش از رفع خطا">
            </telerik:RadTab>--%>
        </Tabs>
    </telerik:RadTabStrip>
    <telerik:RadMultiPage runat="server" ID="RadMultiPage1" SelectedIndex="0"
        Width="700px">
       
        <telerik:RadPageView runat="server" ID="rpvMain">
            <table class="CustomTable">
                <tr>
                    <td class="Table_RowB">خرابی مربوط به دفتر جایگاه</td>
                    <td>
                        <input id="chbIsOfficeDamage2" class="chbIsOfficeDamage2" runat="server" type="checkbox" /></td>
                </tr>
                <tr>
                    <td class="Table_RowB">جایگاه:</td>
                    <td>
                        <table>
                            <tr>
                                <td class="Table_RowB">
                                    <telerik:RadNumericTextBox runat="server" Type="Number" NumberFormat-DecimalDigits="0" NumberFormat-GroupSeparator="" MinValue="0"
                                        MaxValue="2147483647" AutoPostBack="false" ID="txtGasStationCode" CssClass="txtGasStationCode" Width="70px" ReadOnly="false">
                                    </telerik:RadNumericTextBox></td>
                                <td class="Table_RowB">
                                    <telerik:RadTextBox runat="server" ID="txtGasStationTitle" CssClass="txtGasStationTitle" Width="200px" ReadOnly="true"></telerik:RadTextBox><div class="hdnGS">
                                        <asp:HiddenField runat="server" ID="hdnGSCode" />
                                    </div>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td class="Table_RowC">نازل:</td>
                    <td>
                        <table>
                            <tr>
                                <td class="Table_RowC">
                                    <telerik:RadNumericTextBox runat="server" Type="Number" NumberFormat-DecimalDigits="0" NumberFormat-GroupSeparator="" MinValue="0" MaxValue="2147483647" AutoPostBack="false" ID="txtNozzleCode" CssClass="txtNozzleCode" Width="70px" ReadOnly="false"></telerik:RadNumericTextBox></td>
                                <td class="Table_RowC">
                                    <telerik:RadTextBox runat="server" ID="txtNozzleTitle" CssClass="txtNozzleTitle" Width="200px" ReadOnly="true"></telerik:RadTextBox><div class="hdnNozzle">
                                        <asp:HiddenField runat="server" ID="hdnNozzleCode" />
                                    </div>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td class="Table_RowB">اعلام کننده خرابی:</td>
                    <td>
                        <uc2:JSearchPersonControl runat="server" id="JSearchPersonControl" />
                    </td>
                </tr>
                <tr>
                    <td class="Table_RowC">ساعت اعلام خرابی:</td>
                    <td>
                        <telerik:RadNumericTextBox runat="server" Type="Number" NumberFormat-DecimalDigits="0" NumberFormat-GroupSeparator="" MinValue="0" MaxLength="2" EmptyMessage="دقیقه"
                            MaxValue="59" AutoPostBack="false" ID="txtTimeMinute" Width="40px" ReadOnly="false" ValidationGroup="Malfunction">
                        </telerik:RadNumericTextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*"
                            ControlToValidate="txtTimeMinute" ValidationGroup="Malfunction" Display="Dynamic"></asp:RequiredFieldValidator>:
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*"
                            ControlToValidate="txtTimeHour" ValidationGroup="Malfunction" Display="Dynamic"></asp:RequiredFieldValidator><telerik:RadNumericTextBox runat="server" Type="Number" NumberFormat-DecimalDigits="0" NumberFormat-GroupSeparator="" MinValue="0" MaxLength="2" EmptyMessage="ساعت"
                                MaxValue="24" AutoPostBack="false" ID="txtTimeHour" Width="40px" ReadOnly="false" ValidationGroup="Malfunction">
                            </telerik:RadNumericTextBox></td>
                </tr>
                <tr>
                    <td class="Table_RowB">نوع خرابی:</td>
                    <td>
                       
                        <uc1:jcustomlistselectorcontrol runat="server" id="JCustomListSelectorControlDamage" />
                            
                    </td>
                </tr>
                <tr>
                    <td class="Table_RowC">توضیحات:</td>
                    <td>
                        <telerik:RadTextBox runat="server" ID="txtDiscription" Width="90%"></telerik:RadTextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*"
                            ControlToValidate="txtDiscription" ValidationGroup="Malfunction" Display="Dynamic"></asp:RequiredFieldValidator></td>
                </tr>
                <tr>
                    <td class="Table_RowB">وضعیت:</td>
                    <td>
                        <telerik:RadComboBox ID="cmbStatusMalfunction" runat="server" Width="90%"></telerik:RadComboBox>
                    </td>
                </tr>
                <tr>
                    <td class="Table_RowC">نوع اعلام خرابی:</td>
                    <td>
                        <telerik:RadComboBox ID="cmbTypeOfMulfunction" runat="server" Width="90%"></telerik:RadComboBox>
                    </td>
                </tr>
            </table>
            <table class="CustomTable" style="width: 500px">
                <tr>
                    <td class="Table_RowB">زمان واقعی خرابی:</td>
                    <td>
                        <uc3:JDateControl runat="Server" ID="dteRealMalfunction" />
                        <br />
                        <telerik:RadTextBox runat="server" ID="txtRealMalfunctionMinute" Width="40px" MaxLength="2" EmptyMessage="دقیقه"></telerik:RadTextBox>:
                        <telerik:RadTextBox runat="server" ID="txtRealMalfunctionHour" Width="40px" MaxLength="2" EmptyMessage="ساعت"></telerik:RadTextBox></td>
                </tr>
                <tr>
                    <td class="Table_RowC">موضوع خرابی واقعی:</td>
                    <td>
                        <telerik:RadTextBox runat="server" ID="txtRealMalfunctionDescription" TextMode="MultiLine" Width="90%"></telerik:RadTextBox></td>
                </tr>
            </table>
        </telerik:RadPageView>
        <telerik:RadPageView runat="server" ID="RadPageView2">
            <uc1:JReferViewControl runat="server" id="jReferViewControl" />
        </telerik:RadPageView>

        <telerik:RadPageView runat="server" ID="rpvArchive">
            <uc1:JArchiveControl runat="server" id="JArchiveControl" />
        </telerik:RadPageView>

        <%--        <telerik:RadPageView runat="server" ID="pvCloseBeforeSolved">
            <table class="CustomTable">--%>

        <%--<tr>
                    <td class="Table_RowC">تاریخ بستن تیکت پیش از رفع :</td>
                    <td>
                         <uc3:JDateControl runat="Server" ID="JDateNotSolved" />
                    </td>
                </tr>
                
                <tr>
                    <td class="Table_RowC">ساعت بستن تیکت پیش از رفع :</td>
                    <td>
                        <telerik:RadTextBox runat="server" ID="txtMinNotSolvedTime" Width="40px" MaxLength="2" EmptyMessage="دقیقه"></telerik:RadTextBox>
                        <asp:RangeValidator ID="RangeValidator1" runat="server" ErrorMessage="00 تا 59" ControlToValidate="txtTimeMinute" MinimumValue="00"
                            MaximumValue="59" ValidationGroup="Malfunction" Display="Dynamic"></asp:RangeValidator>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="*"
                            ControlToValidate="txtTimeMinute" ValidationGroup="Malfunction" Display="Dynamic"></asp:RequiredFieldValidator>
                        :
                <asp:RequiredFieldValidator ID="rfvHourNotSolvedTime" runat="server" ErrorMessage="*"
                    ControlToValidate="txtHourNotSolvedTime" ValidationGroup="Malfunction" Display="Dynamic"></asp:RequiredFieldValidator>
                        <asp:RangeValidator ID="rngHourNotSolvedTime" runat="server" ErrorMessage="00 تا 23" ControlToValidate="txtHourNotSolvedTime" MinimumValue="00"
                            MaximumValue="23" ValidationGroup="Closed" Display="Dynamic"></asp:RangeValidator>
                        <telerik:RadTextBox runat="server" ID="txtHourNotSolvedTime" Width="40px" MaxLength="2" EmptyMessage="ساعت"></telerik:RadTextBox>
                    </td>
                </tr>--%>
        <%-- <tr>
                    <td class="Table_RowC">توضیحات بستن تیکت پیش از رفع :</td>
                    <td>
                        <telerik:RadTextBox runat="server" ID="txtNotSolvedDescription" ValidationGroup="ClosedNotSolved" Width="98%" TextMode="MultiLine" CausesValidation="true"></telerik:RadTextBox>
                        <asp:RequiredFieldValidator ID="rfvNotSolvedDescription" runat="server" ErrorMessage="*"
                            ControlToValidate="txtNotSolvedDescription" ValidationGroup="ClosedNotSolved" Display="Dynamic"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="Table_RowB">بستن تیکت قبل از رفع :</td>
                    <td>
                        <asp:CheckBox runat="server" AutoPostBack="true" Text="" ID="chbClosedNotSolved"
                            OnCheckedChanged="chbClosedNotSolved_CheckedChanged" />
                        <asp:Label runat="server" ID="lblClosedNotSolved" Font-Size="8pt" ForeColor="Red" Font-Names="Tahoma" Font-Bold="True" Font-Italic="False" Font-Underline="True"></asp:Label>
                        <asp:Label runat="server" ID="lblNotSolvedDate" Font-Size="8pt" ForeColor="Green" Font-Names="Tahoma" Font-Bold="True" Font-Italic="False"></asp:Label>

                    </td>
                </tr>

            </table>
        </telerik:RadPageView>--%>
           
    </telerik:RadMultiPage>

          </ContentTemplate>
         <Triggers>
             <asp:PostBackTrigger ControlID="JCustomListSelectorControlDamage" />
             <asp:PostBackTrigger ControlID="dteRealMalfunction" />
         </Triggers>
            </asp:UpdatePanel>
   
</div>
<div class="FormButtons">
    <asp:UpdatePanel ID="uPnlButtons" runat="server"><ContentTemplate>
    <table>
        <tr>
            <td>
                <telerik:RadButton runat="server" ID="btnRefer" Text="ارجاع" CssClass="btnRefer" Font-Bold="true" AutoPostBack="true" OnClick="btnRefer_Click" Width="100px" Height="35px" ValidationGroup="ReferedMalfunction" />
            </td>
            <td>
                <telerik:RadButton runat="server" ID="btnSave" Text="ذخیره" AutoPostBack="true" Width="100px" Height="35px" OnClick="btnSave_Click" ValidationGroup="ReferedMalfunction" />
            </td>
            <td>
                <telerik:RadButton runat="server" ID="btnSoftware" Text="تعمیرات نرم افزاری" AutoPostBack="true" Width="100px" Height="35px" OnClick="btnSoftware_Click" />

            </td>
            <td>
                <telerik:RadButton runat="server" ID="btnHardware" Text="تعمیرات سخت افزاری" AutoPostBack="true" Width="100px" Height="35px" OnClick="btnHardware_Click" />

            </td>

            <td>
                <telerik:RadButton runat="server" ID="btnAfterReviewing" Text="گزارش پیمانکار" AutoPostBack="true" Width="100px" Height="35px" OnClick="btnAfterReviewing_Click" />

            </td>
            <td>
                <telerik:RadButton runat="server" ID="btnHelpDesk" Text="Help Desk" AutoPostBack="true" Width="100px" Height="35px" OnClick="btnHelpDesk_Click" />

            </td>
            <td>
                <telerik:RadButton runat="server" ID="btnClose" Text="بازگشت" OnClientClicked="CloseDialog" AutoPostBack="false" Width="100px" Height="35px" />

            </td>
            <td>
                <telerik:RadButton runat="server" ID="btnDelete" Text="حذف" AutoPostBack="true" Width="100px" Height="35px" OnClick="btnDelete_Click" CssClass="floatLeft" OnClientClicking="OnClientClicking" />

            </td>


        </tr>

    </table>
        </ContentTemplate>
         <Triggers>
             <asp:PostBackTrigger ControlID="btnRefer" />
         </Triggers>
    </asp:UpdatePanel>



</div>

<telerik:RadCodeBlock ID="RadCodeBlock1" runat="server">
    <script type="text/javascript">
        function ReferSuccess() {
            CloseDialog(null);
        }


    </script>
</telerik:RadCodeBlock>
