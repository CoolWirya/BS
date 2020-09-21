<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="JLineUpdateControl.ascx.cs" Inherits="WebBusManagement.FormsManagement.JLineUpdateControl" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register Src="~/WebControllers/MainControls/Date/JDateControl.ascx" TagPrefix="uc1" TagName="JDateControl" %>
<%@ Register Src="~/WebControllers/MainControls/OpenLayersMap/OpenLayersMap.ascx" TagPrefix="uc1" TagName="OpenLayersMap" %>

<asp:HiddenField ID="hdCheckPriorityGo" Value="" runat="server" />
<asp:HiddenField ID="hdCheckPriorityBack" Value="" runat="server" />
<div class="BigTitle">خطوط</div>
<div class="FormContent" style="top: 40px; margin-bottom: 45px">
    <telerik:RadTabStrip runat="server" ID="RadTabStrip1"
        SelectedIndex="0" MultiPageID="RadMultiPage1" Width="100%">
        <Tabs>
            <telerik:RadTab Text="خط">
            </telerik:RadTab>
            <telerik:RadTab Text="مسیر">
            </telerik:RadTab>
            <telerik:RadTab Text="مبلغ">
            </telerik:RadTab>
        </Tabs>
    </telerik:RadTabStrip>
    <telerik:RadMultiPage runat="server" ID="RadMultiPage1" SelectedIndex="0"
        Width="700px">
        <telerik:RadPageView runat="server" ID="RadPageView1">
            <table style="width: 500px">
                <tr class="Table_RowB">
                    <td style="width: 150px">نام خط:</td>
                    <td>
                        <telerik:RadTextBox runat="server" ID="txtLineName" Width="96%"></telerik:RadTextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorTxtName" runat="server" Display="Dynamic" ControlToValidate="txtLineName" ValidationGroup="Line" ErrorMessage="*"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr class="Table_RowC">
                    <td style="width: 150px">شماره خط:</td>
                    <td>
                        <telerik:RadNumericTextBox ID="txtLineNumber" runat="server" Width="96%"></telerik:RadNumericTextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidatortxtLineNumber" runat="server" Display="Dynamic" ControlToValidate="txtLineNumber" ValidationGroup="Line" ErrorMessage="*"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr class="Table_RowB">
                    <td style="width: 150px">منطقه:</td>
                    <td>
                        <telerik:RadComboBox runat="server" ID="cmbZoneName" Width="96%"></telerik:RadComboBox>
                    </td>
                </tr>
                <tr class="Table_RowC">
                    <td style="width: 150px">ناوگان:</td>
                    <td>
                        <telerik:RadComboBox runat="server" ID="cmbFleetName" Width="96%"></telerik:RadComboBox>
                    </td>
                </tr>
                <tr class="Table_RowB">
                    <td style="width: 150px">نوع خط:</td>
                    <td>
                        <telerik:RadComboBox runat="server" ID="cmbLineType" Width="96%"></telerik:RadComboBox>
                    </td>
                </tr>
                <%--<tr class="Table_RowC">
                <td style="width: 150px">تعداد سرویس در روز:</td>
                <td>
                    <telerik:RadTextBox runat="server" ID="txt_NumOfServicePerDay" Width="96%"></telerik:RadTextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" Display="Dynamic" ControlToValidate="txt_NumOfServicePerDay" ValidationGroup="Line" ErrorMessage="*"></asp:RequiredFieldValidator>
                    <asp:CompareValidator ID="CompareValidator1" runat="server" Display="Dynamic" ErrorMessage="لطفا عدد وارد کنید" ControlToValidate="txt_NumOfServicePerDay" Type="Double" ValidationGroup="Line"></asp:CompareValidator>
                </td>
            </tr>--%>
                <tr class="Table_RowB">
                    <td style="width: 150px">زمان انجام هر سرویس به دقیقه:</td>
                    <td>
                        <telerik:RadNumericTextBox ID="txt_TimeOfService" NumberFormat-GroupSeparator="" NumberFormat-AllowRounding="false" runat="server" Width="96%"></telerik:RadNumericTextBox>
                        <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" Display="Dynamic" ControlToValidate="txt_TimeOfService" ValidationGroup="Line" ErrorMessage="*"></asp:RequiredFieldValidator>--%>
                    </td>
                </tr>
                <tr class="Table_RowC">
                    <td style="width: 150px">مسافت به کیلومتر:</td>
                    <td>
                        <telerik:RadNumericTextBox ID="txtDistance" NumberFormat-GroupSeparator="" NumberFormat-AllowRounding="false" runat="server" Width="96%"></telerik:RadNumericTextBox>
                    </td>
                </tr>
                <tr class="Table_RowC">
                    <td style="width: 150px">فعال:</td>
                    <td>
                        <asp:CheckBox ID="chkStatus" runat="server" Text="فعال" />
                    </td>
                </tr>
                <tr class="Table_RowB">
                    <td style="width: 150px">چرخشی:</td>
                    <td>
                        <asp:CheckBox ID="chkRotate" runat="server" Text="چرخشی" />
                    </td>
                </tr>
                <tr class="Table_RowC">
                    <td style="width: 150px">متوسط تعداد تراکنش روزانه اتوبوس در این خط:</td>
                    <td>
                        <telerik:RadTextBox runat="server" ID="txtTransactionCount" Width="96%"></telerik:RadTextBox>
                    </td>
                </tr>
                <tr class="Table_RowB">
                    <td style="width: 150px">رسم مسیرها:</td>
                    <td>
                        <asp:CheckBox ID="chkIsDrawn" runat="server" Text="تایید" />
                    </td>
                </tr>
                <tr class="Table_RowC">
                    <td style="width: 150px">رنگ ایستگاه:</td>
                    <td>
                        <telerik:RadColorPicker  runat="server" ID="ColorPicker" Width="96%" NoColorText="بدون رنگ" Localization-HexInputTitle="کد هگز"></telerik:RadColorPicker>
                    </td>
                </tr>
            </table>
        </telerik:RadPageView>
        <telerik:RadPageView runat="server" ID="RadPageView2">
            <table style="width: 100%; height: auto">
                <tr>
                    <td style="width: 50%; height: auto; vertical-align:top">
                        <div style="float: right; width: 100%; height: 20px">مسیر رفت</div>
                        <div style="clear: both; height: 5px"></div>
                        <div style="float: right; width: 100%; height: auto">
                            <telerik:RadComboBox runat="server" ID="cmbStationGo" Width="60%" Filter="Contains"></telerik:RadComboBox>
                            <telerik:RadButton runat="server" ID="BtnInsertStationGo" Text="درج" AutoPostBack="true" Width="70px" Height="20px" OnClick="BtnInsertStationGo_Click" />
                        </div>
                        <div style="clear: both; height: 5px"></div>
                        <div style="float: right; width: 100%; height: auto">
                            <label class="lbl_upper">لیست ایستگاه های مسیر رفت</label>
                            <telerik:RadListBox runat="server" ID="lstStationGo" Width="80%" Height="300px" EnableDragAndDrop="true" AllowTransfer="true"
                                Localization-MoveDown="مرتب سازی به پایین" Localization-MoveUp="مرتب سازی به بالا"
                                Localization-Delete="حذف از لیست"
                                AllowReorder="true" AllowDelete="true" OnClientSelectedIndexChanged="GoStationChanged" OnClientDeleted="GoStationDeleted">
                                <ButtonSettings AreaHeight="30" Position="Bottom" />
                            </telerik:RadListBox>
                        </div>
                        <div style="clear: both; padding-top: 5px;">
                            <asp:CheckBox ID="cbGoCheckPriority" style="visibility:hidden" Text="آیا مسیر رفت بیش از یکبار از مجاورت این ایستگاه می گذرد؟" runat="server"/>
                        </div>
                    </td>
                    <td style="width: 50%; height: auto; vertical-align:top">
                        <div style="float: right; width: 100%; height: 20px">مسیر برگشت</div>
                        <div style="clear: both; height: 5px"></div>
                        <div style="float: right; width: 100%; height: auto">
                            <telerik:RadComboBox runat="server" ID="cmbStationBack" Width="60%" Filter="Contains"></telerik:RadComboBox>
                            <telerik:RadButton runat="server" ID="BtnInsertStationBack" Text="درج" AutoPostBack="true" Width="70px" Height="20px" OnClick="BtnInsertStationBack_Click" />
                        </div>
                        <div style="clear: both; height: 5px"></div>
                        <div style="float: right; width: 100%; height: auto">
                            <label class="lbl_upper">لیست ایستگاه های مسیر برگشت</label>
                            <telerik:RadListBox runat="server" ID="lstStationBack" Width="80%" Height="300px" EnableDragAndDrop="true" AllowTransfer="true"
                                Localization-MoveDown="مرتب سازی به پایین" Localization-MoveUp="مرتب سازی به بالا"
                                Localization-Delete="حذف از لیست"
                                AllowReorder="true" AllowDelete="true" OnClientSelectedIndexChanged="BackStationChanged" OnClientDeleted="BackStationDeleted">
                                <ButtonSettings AreaHeight="30" Position="Bottom" />
                            </telerik:RadListBox>
                        </div>
                        <div style="clear: both; padding-top: 5px;">
                            <asp:CheckBox ID="cbBackCheckPriority" style="visibility:hidden" Text="آیا مسیر برگشت بیش از یکبار از مجاورت این ایستگاه می گذرد؟" runat="server"/>
                        </div>
                    </td>
                </tr>
            </table>
        </telerik:RadPageView>
        <telerik:RadPageView runat="server" ID="RadPageView3">
            <table style="width: 500px">
                <tr class="Table_RowB">
                    <td style="width: 150px">مبلغ:</td>
                    <td>
                        <telerik:RadTextBox runat="server" ID="txtPrice" Width="96%"></telerik:RadTextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Display="Dynamic" ControlToValidate="txtPrice" ValidationGroup="LinePrice" ErrorMessage="*"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr class="Table_RowC">
                    <td style="width: 150px">تاریخ شروع:</td>
                    <td>
                        <uc1:JDateControl runat="server" id="txtStartDate" />
                    </td>
                </tr>
                <tr class="Table_RowB">
                    <td style="width: 150px">تاریخ پایان:</td>
                    <td>
                        <uc1:JDateControl runat="server" id="txtFinishDate" />
                    </td>
                </tr>
                <tr class="Table_RowC">
                    <td style="width: 150px">ساعت شروع:</td>
                    <td style="direction: ltr">
                        <asp:RangeValidator ID="RangeValidator3" runat="server" ErrorMessage="00 تا 23" ControlToValidate="txtStartTimeHour" MinimumValue="00"
                            MaximumValue="23" ValidationGroup="LinePrice" Display="Dynamic"></asp:RangeValidator>
                        <telerik:RadTextBox runat="server" ID="txtStartTimeHour" Width="40px" MaxLength="2" EmptyMessage="ساعت"></telerik:RadTextBox>
                        :
                    <telerik:RadTextBox runat="server" ID="txtStartTimeMinute" Width="40px" MaxLength="2" EmptyMessage="دقیقه"></telerik:RadTextBox>
                        <asp:RangeValidator ID="RangeValidator4" runat="server" ErrorMessage="00 تا 59" ControlToValidate="txtStartTimeMinute" MinimumValue="00"
                            MaximumValue="59" ValidationGroup="LinePrice" Display="Dynamic"></asp:RangeValidator>
                    </td>
                </tr>
                <tr class="Table_RowB">
                    <td style="width: 150px">ساعت پایان:</td>
                    <td style="direction: ltr">
                        <asp:RangeValidator ID="RangeValidator1" runat="server" ErrorMessage="00 تا 23" ControlToValidate="txtFinishTimeHour" MinimumValue="00"
                            MaximumValue="23" ValidationGroup="LinePrice" Display="Dynamic"></asp:RangeValidator>
                        <telerik:RadTextBox runat="server" ID="txtFinishTimeHour" Width="40px" MaxLength="2" EmptyMessage="ساعت"></telerik:RadTextBox>
                        :
                    <telerik:RadTextBox runat="server" ID="txtFinishTimeMinute" Width="40px" MaxLength="2" EmptyMessage="دقیقه"></telerik:RadTextBox>
                        <asp:RangeValidator ID="RangeValidator2" runat="server" ErrorMessage="00 تا 59" ControlToValidate="txtFinishTimeMinute" MinimumValue="00"
                            MaximumValue="59" ValidationGroup="LinePrice" Display="Dynamic"></asp:RangeValidator>
                    </td>
                </tr>
            </table>
            <%--    <telerik:RadAjaxManagerProxy runat="server" ID="AjaxManagerProxy_Control">
            <AjaxSettings>
                <telerik:AjaxSetting AjaxControlID="BtnPriceSave">
                    <UpdatedControls>
                        <telerik:AjaxUpdatedControl ControlID="GridViewPrice" />
                    </UpdatedControls>
                </telerik:AjaxSetting>
            </AjaxSettings>
        </telerik:RadAjaxManagerProxy>--%>
            <telerik:RadButton runat="server" ID="BtnPriceSave" Text="ذخیره مبلغ" AutoPostBack="true" Width="100px" Height="35px" OnClick="BtnPriceSave_Click" ValidationGroup="LinePrice" />
            <div style="clear: both; height: 5px"></div>
            <asp:GridView ID="GridViewPrice" runat="server" Width="100%" HorizontalAlign="Center"
                RowStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" RowStyle-ForeColor="Black"
                OnSelectedIndexChanged="GridViewPrice_SelectedIndexChanged" EnableModelValidation="True">
                <Columns>
                    <asp:ButtonField CommandName="Select" HeaderText="انتخاب" ShowHeader="True" Text="انتخاب"
                        ButtonType="Link" />
                </Columns>
                <RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Center" />
                <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#F7F7F7" />
            </asp:GridView>
            <div style="clear: both; height: 5px"></div>
            <telerik:RadButton runat="server" ID="btnDelPrice" Text="حذف مبلغ" Visible="false" AutoPostBack="true" Width="100px" Height="35px" OnClick="btnDelPrice_Click" />
            <input type="hidden" runat="server" id="GridViewPriceSelectedRowId" name="GridViewPriceSelectedRowId" value="0" />
        </telerik:RadPageView>
    </telerik:RadMultiPage>
    <%--<div id="Div_LineMap" style="float: right; width: 700px; height: 1px; text-align: right; visibility: hidden">
    <uc1:openlayersmap runat="server" id="OpenLayersMapLinePath" />
</div>--%>
</div>
<div class="FormButtons">
    <telerik:RadButton runat="server" ID="btnSave" Text="ذخیره" AutoPostBack="true" Width="100px" Height="35px" OnClick="btnSave_Click" OnClientClicked="btnSave_ClientClick" ValidationGroup="Line" />
    <telerik:RadButton runat="server" ID="btnClose" Text="بازگشت" OnClientClicked="CloseDialog" AutoPostBack="false" Width="100px" Height="35px" />
    <telerik:RadButton runat="server" ID="btnDelete" Text="حذف" AutoPostBack="true" Width="100px" Height="35px" OnClick="btnDelete_Click" CssClass="floatLeft" OnClientClicking="OnClientClicking" />
</div>

<script type="text/javascript">
    var goStation = '';
    var GoStations = new Array();
    var backStation = '';
    var BackStations = new Array();
    $(document).ready(function () {
        var strGoStations = document.getElementById('<%=hdCheckPriorityGo.ClientID%>').value.toString();
        var strBackStations = document.getElementById('<%=hdCheckPriorityBack.ClientID%>').value.toString();
        if (strGoStations.length > 0)
            GoStations = strGoStations.split(',');
        if (strBackStations.length > 0)
            BackStations = strBackStations.split(',');
        var cbGo = document.getElementById('<%=cbGoCheckPriority.ClientID%>');
        var cbBack = document.getElementById('<%=cbBackCheckPriority.ClientID%>');
        cbGo.onchange = function ()
        {
            if (cbGo.checked)
                GoStations.push(goStation);
            else
                delete GoStations[GoStations.indexOf(goStation)];
        }
        cbBack.onchange = function () {
            if (cbBack.checked)
                BackStations.push(backStation);
            else
                delete BackStations[BackStations.indexOf(backStation)];
        }
    });
    function btnSave_ClientClick()
    {
        document.getElementById('<%=hdCheckPriorityGo.ClientID%>').value = '';
        document.getElementById('<%=hdCheckPriorityBack.ClientID%>').value = '';
        for (var i = 0; i < GoStations.length; i++)
            if (parseInt(GoStations[i]) != NaN)
                document.getElementById('<%=hdCheckPriorityGo.ClientID%>').value += ',' + GoStations[i];
        for (var i = 0; i < BackStations.length; i++)
            if (parseInt(BackStations[i]) != NaN)
                document.getElementById('<%=hdCheckPriorityBack.ClientID%>').value += ',' + BackStations[i];
        if (GoStations.length > 0)
            document.getElementById('<%=hdCheckPriorityGo.ClientID%>').value = document.getElementById('<%=hdCheckPriorityGo.ClientID%>').value.substr(1);
        if (BackStations.length > 0)
            document.getElementById('<%=hdCheckPriorityBack.ClientID%>').value = document.getElementById('<%=hdCheckPriorityBack.ClientID%>').value.substr(1);

    }
    function GoStationChanged(sender, e)
    {
        goStation = e.get_item().get_value().toString();
        var cbGo = document.getElementById('<%=cbGoCheckPriority.ClientID%>');
        if (GoStations.indexOf(goStation) != -1)
            cbGo.checked = true;
        else
            cbGo.checked = false;
        $(cbGo.parentNode).css('visibility', 'visible');
    }
    function GoStationDeleted(sender, e)
    {
        var cbGo = document.getElementById('<%=cbGoCheckPriority.ClientID%>');
        $(cbGo.parentNode).css('visibility', 'hidden');
        goStation = 0;
    }
    function BackStationChanged(sender, e)
    {
        backStation = e.get_item().get_value().toString();
        var cbBack = document.getElementById('<%=cbBackCheckPriority.ClientID%>');
        if (BackStations.indexOf(backStation) != -1)
            cbBack.checked = true;
        else
            cbBack.checked = false;
        $(cbBack.parentNode).css('visibility', 'visible');
    }
    function BackStationDeleted(sender, e)
    {
        var cbBack = document.getElementById('<%=cbBackCheckPriority.ClientID%>');
        $(cbBack.parentNode).css('visibility', 'hidden');
        backStation = 0;
    }
    //$("#Div_LineMap").css('height', '1px');
    //function OnClientTabSelected(sender, eventArgs) {
    //    var tab = eventArgs.get_tab();
    //    if (tab.get_text() == "مسیر خط") {
    //        $("#Div_LineMap").css('visibility', 'visible');
    //        $("#Div_LineMap").css('height', '280px');
    //        $("#Div_LineMap").fadeIn();
    //    }
    //    else {
    //        $("#Div_LineMap").css('visibility', 'hidden');
    //        $("#Div_LineMap").css('height', '1px');
    //        $("#Div_LineMap").css('display', 'none');
    //    }
    //}
</script>

