<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="JStationsUpdateControl.ascx.cs" Inherits="WebBusManagement.FormsManagement.JStationsUpdateControl" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register Src="~/WebControllers/Property/JPropertyViewControl.ascx" TagPrefix="uc1" TagName="JPropertyViewControl" %>
<%@ Register Src="~/WebControllers/MainControls/OpenLayersMap/OpenLayersMap.ascx" TagPrefix="uc1" TagName="OpenLayersMap" %>

<telerik:RadCodeBlock>
    <script type="text/javascript">
        var alwaysShowUpload = false;
        function updatePictureAndInfo() {
            __doPostBack('upldPhoto', 'RadButton1Args');
            alwaysShowUpload = false;
        }

        function EnableAlwaysShowUpload() {
            alwaysShowUpload = true;
        }
    </script>
</telerik:RadCodeBlock>

<style>
    #imgDirection {
        position:absolute;
        top:143px;
        right:126px;
        z-index:301;
    }
</style>
<div class="BigTitle">ایستگاه</div> 
<%--<telerik:RadTabStrip runat="server" ID="RadTabStrip1"
    SelectedIndex="0" MultiPageID="RadMultiPage1" Width="100%" OnClientTabSelected="OnClientTabSelected">
    <Tabs>
        <telerik:RadTab Text="ایستگاه">
        </telerik:RadTab>
        <telerik:RadTab Text="نقشه">
        </telerik:RadTab>
    </Tabs>
</telerik:RadTabStrip>
<telerik:RadMultiPage runat="server" ID="RadMultiPage1" SelectedIndex="0"
    Width="700px">
    <telerik:RadPageView runat="server" ID="RadPageView1">--%>
<div class="FormContent" style="top:40px; margin-bottom: 55px">
    <div style="width: 300px; float: right">  
    <table>
        <tr class="Table_RowB">
            <td style="width: 120px">کد اصلی:</td>
            <td>
                <telerik:RadTextBox runat="server" ID="txtMainCode" Width="96%"></telerik:RadTextBox>
            </td>
        </tr>
        <tr class="Table_RowC">
            <td style="width: 120px">نام:</td>
            <td>
                <telerik:RadTextBox runat="server" ID="txtName" Width="96%"></telerik:RadTextBox>
            </td>
        </tr>
        <tr class="Table_RowB">
            <td style="width: 120px">منطقه:</td>
            <td>
                <telerik:RadComboBox runat="server" ID="cmbZoneCode" Width="96%"></telerik:RadComboBox>
            </td>
        </tr>
        <tr class="Table_RowC">
            <td style="width: 120px">آدرس:</td>
            <td>
                <telerik:RadTextBox runat="server" ID="txtAddress" Width="96%" TextMode="MultiLine"></telerik:RadTextBox>
            </td>
        </tr>
        <tr class="Table_RowB">
            <td style="width: 120px">نوع ایستگاه:</td>
            <td>
                <telerik:RadComboBox runat="server" ID="cmbStationType" Width="96%"></telerik:RadComboBox>
            </td>
        </tr>
        <tr class="Table_RowC">
            <td style="width: 120px">طول جغرافیایی:</td>
            <td>
                <telerik:RadTextBox runat="server" ID="txtLng" Width="96%" style="direction:ltr; text-align:left"></telerik:RadTextBox>
            </td>
        </tr>
        <tr class="Table_RowB">
            <td style="width: 120px">عرض جغرافیایی:</td>
            <td>
                <telerik:RadTextBox runat="server" ID="txtLat" Width="96%" style="direction:ltr; text-align:left"></telerik:RadTextBox>
            </td>
        </tr>
        <tr class="Table_RowC">
            <td style="width: 120px"></td>
            <td>
                <input runat="server" type="checkbox" id="chkIsTerminal" name="chkIsTerminal" />پایانه
            </td>
        </tr>
        <tr class="Table_RowB">
            <td style="width: 120px">ویژگی ها:</td>
            <td>
                <uc1:jpropertyviewcontrol runat="server" id="JPropertyViewControl" />
            </td>
        </tr>
        <tr class="Table_RowC">
            <td style="width: 120px;">زاویه:
                <img src="/Images/circle_thumb.jpg" alt="Angles" style="float:left;border-radius: 10px;" 
                    onmouseover="document.getElementById('imgDirection').style.display = '';" 
                    onmouseout="document.getElementById('imgDirection').style.display = 'none';"/>
            </td>
            <td>
                <telerik:RadTextBox runat="server" ID="txtAngle" Width="96%"></telerik:RadTextBox>
            </td>
        </tr>
        <tr class="Table_RowB">
            <td style="width: 120px">تصویر:</td>
            <td>
                <div style="height: 203px;"><%-- onmouseover="$('#changeBtn').show();" onmouseout="if(alwaysShowUpload==false)$('#changeBtn').hide();"--%>
                    <telerik:RadBinaryImage runat="server" ID="imgStation" ImageUrl="~/Images/Controls/NoStation.png" ResizeMode="Crop" Width="150" Height="150" />
                    <div id="changeBtn"><%-- style="display: none;"--%>
                        <telerik:RadButton style="float:left" runat="server" ID="btnChangeImage" Text="ذخیره" OnClientClick="updatePictureAndInfo(); return false;"></telerik:RadButton>
                        <telerik:RadAsyncUpload style="float:right;max-width:110px; overflow-x:hidden" ID="upldPhoto" runat="server" AllowedFileExtensions=".jpg,.png,.gif,jpeg,.tiff"
                            MaxFileInputsCount="1" MultipleFileSelection="Disabled" OnFileUploaded="upldPhoto_FileUploaded" HideFileInput="true" Width="80" OnClientFileSelected="EnableAlwaysShowUpload">
                        </telerik:RadAsyncUpload>
                    </div>
                </div>
            </td>
        </tr>
        <tr class="Table_RowC">
            <td style="width: 120px">شعاع:</td>
            <td>
                <telerik:RadTextBox runat="server" ID="txtRadius" Width="96%"></telerik:RadTextBox>
            </td>
        </tr>
        <tr class="Table_RowB">
            <td style="width: 120px">IMEI:</td>
            <td>
            <telerik:RadTextBox ID="txtIMEI" runat="server" Width="96%"></telerik:RadTextBox>
            </td>
        </tr>
        <tr class="Table_RowC">
            <td style="width: 120px">حداقل سرعت:</td>
            <td>
                <telerik:RadTextBox runat="server" ID="txtMinSpeed" Width="96%"></telerik:RadTextBox>
            </td>
        </tr>
    </table> 
    <img id="imgDirection" style="display:none;" src="/Images/circle.jpg" alt="Direction"/>
    </div>
    <%--    </telerik:RadPageView>
    <telerik:RadPageView runat="server" ID="RadPageView2">
    </telerik:RadPageView>
</telerik:RadMultiPage>--%>
    <%--<div style="clear: both; height: 10px"></div>--%>
    <div id="Div_StationMap" style="float: right; width: 410px; height: 320px; padding-top:5px; margin-right:5px">
        <uc1:openlayersmap runat="server" id="OpenLayersMapStations" />
    </div>
    <div style="clear: both; height: 1px"></div>
    <telerik:RadButton runat="server" ID="btnSaveFromMap" Text="ذخیره نقطه از نقشه" AutoPostBack="true" Width="200px" Height="35px" OnClick="btnSaveFromMap_Click" />
    <telerik:RadButton runat="server" ID="btnSetAngle" Text="به روز رسانی زاویه" AutoPostBack="true" Width="200px" Height="35px" OnClick="btnSetAngle_Click" />
    <telerik:RadButton runat="server" ID="btnSetAngleFinal" Text="به روز رسانی ثانویه زاویه" AutoPostBack="true" Width="200px" Height="35px" OnClick="btnSetAngleFinal_Click" />
    <div style="clear: both; height: 1px"></div>
    <input type="hidden" id="LatV" name="LatV" runat="server"/>
    <input type="hidden" id="LngV" name="LngV" runat="server"/>
    <input type="hidden" runat="server" id="PathMapStationAc" />
</div>
<div class="FormButtons">
    <telerik:RadButton runat="server" ID="btnSave" Text="ذخیره" AutoPostBack="true" Width="100px" Height="35px" OnClick="btnSave_Click" />
    <telerik:RadButton runat="server" ID="btnClose" Text="بازگشت" OnClientClicked="CloseDialog" AutoPostBack="false" Width="100px" Height="35px" />
    <telerik:RadButton runat="server" ID="btnDelete" Text="حذف" AutoPostBack="true" Width="100px" Height="35px" OnClick="btnDelete_Click" CssClass="floatLeft" OnClientClicking="OnClientClicking" />
</div>
<script type="text/javascript">
    //$("#Div_StationMap").css('height', '1px');
    //function OnClientTabSelected(sender, eventArgs) {
    //    var tab = eventArgs.get_tab();
    //    if (tab.get_text() == "نقشه") {
    //        $("#Div_StationMap").css('visibility', 'visible');
    //        $("#Div_StationMap").css('height', '280px');
    //        $("#Div_StationMap").fadeIn();
    //    }
    //    else {
    //        $("#Div_StationMap").css('visibility', 'hidden');
    //        $("#Div_StationMap").css('height', '1px');
    //        $("#Div_StationMap").css('display', 'none');
    //    }
    //}
    GetStation();
    function GetStation() {
        var paramStr = new Array();
        paramStr[0] = $("#<%=LatV.ClientID %>").val();
        paramStr[1] = $("#<%=LngV.ClientID %>").val();
        var data = "{actionString:'" + $("#<%=PathMapStationAc.ClientID %>").val() + "',param:" + JSON.stringify(paramStr) + "}";
        ResultAjaxRequet = $.ajax({
            url: "../WebBusManagement/WebService/Action.asmx/RunAction",
            contentType: "application/json",
            cache: false,
            type: "POST",
            data: data,
            async: true,
            error: function (err) {

            },
            success: function (data) {
                SetMarkerAndloadItNoDelete(data.d);
                MapSetCenterWithZoom(paramStr[1], paramStr[0], 13);
            }
        });
    }

    <%=SetCenterStationMapScript%>

</script>
