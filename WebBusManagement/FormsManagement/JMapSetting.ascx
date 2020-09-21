<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="JMapSetting.ascx.cs" Inherits="WebBusManagement.FormsManagement.JMapSetting" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>

    <script type="text/javascript">
        function updatePictureAndInfo(Argument) {
            __doPostBack('upldPhoto', Argument);
        }
    </script>
<style>
    .tsButton {
        border: 1px solid #7e7e7e; 
        background-color: #c6c6c6;
        background-image: none;
        font-family: 'Segoe UI',Arial,Helvetica,sans-serif; 
        font-size: 12px; 
        padding: 2px 10px;
        cursor: pointer; 
        vertical-align: text-top; 
        text-align: center;
        text-decoration: none;
    }
    .tsButton:hover {
        background-color: #ffd699;
        border-color: #ff9900;
        color: #995900;
    }
    .tsButton:focus {
        outline: none;
    }
    .Table_RowB td, .Table_RowC td {
        padding-right: 10px;
    }
</style>

<div class="BigTitle">تنظیمات نقشه</div>
<div style="top:40px; margin-bottom: 50px; width: 525px">
    <table style="width: 100%">
        <tr class="Table_RowB">
            <td style="width: 150px">مارکر عمومی:</td>
            <td style="width: 200px">
                <telerik:RadBinaryImage runat="server" ID="DefaultMarkerImage" ImageUrl="~/Images/Controls/van.png" ResizeMode="Fit" Width="60" Height="60" />
                <div id="changeBtn1">
                    <telerik:RadAsyncUpload ID="upldDefaultMarker" runat="server" AllowedFileExtensions=".jpg,.png,.gif,jpeg,.tiff"
                        MaxFileInputsCount="1" MultipleFileSelection="Disabled" OnFileUploaded="upldPhoto_FileUploaded" HideFileInput="true" Width="80">
                    </telerik:RadAsyncUpload>
                    <asp:Button Text="ذخیره" runat="server" CssClass="tsButton" OnClientClick="updatePictureAndInfo('DefaultMarker'); return false;" />
                </div>
            </td>
        </tr>
        <tr class="Table_RowC">
            <td style="width: 150px">عدم رعایت فاصله:</td>
            <td style="width: 200px">
                <telerik:RadBinaryImage runat="server" ID="NearNextBusImage" ImageUrl="~/Images/Controls/van.png" ResizeMode="Fit" Width="60" Height="60" />
                <div id="changeBtn2">
                    <telerik:RadAsyncUpload ID="upldNearNextBus" runat="server" AllowedFileExtensions=".jpg,.png,.gif,jpeg,.tiff"
                        MaxFileInputsCount="1" MultipleFileSelection="Disabled" OnFileUploaded="upldPhoto_FileUploaded" HideFileInput="true" Width="80">
                    </telerik:RadAsyncUpload>
                    <asp:Button Text="ذخیره" runat="server" CssClass="tsButton" OnClientClick="updatePictureAndInfo('NearNextBus'); return false;" />
                </div>
            </td>
            <td style="width: 75px">رنگ:</td>
            <td style="width: 150px">
                <telerik:RadColorPicker  runat="server" ID="cpNearNextBus" Width="96%" NoColorText="بدون رنگ" Localization-HexInputTitle="کد هگز">
                </telerik:RadColorPicker>
            </td>
        </tr>
        <tr class="Table_RowB">
            <td style="width: 150px">خروج از مسیر:</td>
            <td style="width: 200px">
                <telerik:RadBinaryImage runat="server" ID="OutLineImage" ImageUrl="~/Images/Controls/van.png" ResizeMode="Fit" Width="60" Height="60" />
                <div id="changeBtn3">
                    <telerik:RadAsyncUpload ID="upldOutLine" runat="server" AllowedFileExtensions=".jpg,.png,.gif,jpeg,.tiff"
                        MaxFileInputsCount="1" MultipleFileSelection="Disabled" OnFileUploaded="upldPhoto_FileUploaded" HideFileInput="true" Width="80">
                    </telerik:RadAsyncUpload>
                    <asp:Button Text="ذخیره" runat="server" CssClass="tsButton" OnClientClick="updatePictureAndInfo('OutLine'); return false;" />
                </div>
            </td>
            <td style="width: 75px">رنگ:</td>
            <td style="width: 150px">
                <telerik:RadColorPicker  runat="server" ID="cpOutLine" Width="96%" NoColorText="بدون رنگ" Localization-HexInputTitle="کد هگز">
                </telerik:RadColorPicker>
            </td>
        </tr>
        <tr class="Table_RowC">
            <td style="width: 150px">عدم استفاده از کارت حضور و غیاب:</td>
            <td style="width: 200px">
                <telerik:RadBinaryImage runat="server" ID="UnknownDriverImage" ImageUrl="~/Images/Controls/van.png" ResizeMode="Fit" Width="60" Height="60" />
                <div id="changeBtn4">
                    <telerik:RadAsyncUpload ID="upldUnknownDriver" runat="server" AllowedFileExtensions=".jpg,.png,.gif,jpeg,.tiff"
                        MaxFileInputsCount="1" MultipleFileSelection="Disabled" OnFileUploaded="upldPhoto_FileUploaded" HideFileInput="true" Width="80">
                    </telerik:RadAsyncUpload>
                    <asp:Button Text="ذخیره" runat="server" CssClass="tsButton" OnClientClick="updatePictureAndInfo('UnknownDriver'); return false;" />
                </div>
            </td>
            <td style="width: 75px">رنگ:</td>
            <td style="width: 150px">
                <telerik:RadColorPicker  runat="server" ID="cpUnknownDriver" Width="96%" NoColorText="بدون رنگ" Localization-HexInputTitle="کد هگز">
                </telerik:RadColorPicker>
            </td>
        </tr>
        <tr class="Table_RowB">
            <td style="width: 150px">سرعت غیرمجاز:</td>
            <td style="width: 200px">
                <telerik:RadBinaryImage runat="server" ID="OverspeedImage" ImageUrl="~/Images/Controls/van.png" ResizeMode="Fit" Width="60" Height="60" />
                <div id="changeBtn5">
                    <telerik:RadAsyncUpload ID="upldOverspeed" runat="server" AllowedFileExtensions=".jpg,.png,.gif,jpeg,.tiff"
                        MaxFileInputsCount="1" MultipleFileSelection="Disabled" OnFileUploaded="upldPhoto_FileUploaded" HideFileInput="true" Width="80">
                    </telerik:RadAsyncUpload>
                    <asp:Button Text="ذخیره" runat="server" CssClass="tsButton" OnClientClick="updatePictureAndInfo('Overspeed'); return false;" />
                </div>
            </td>
            <td style="width: 75px">رنگ:</td>
            <td style="width: 150px">
                <telerik:RadColorPicker  runat="server" ID="cpOverspeed" Width="96%" NoColorText="بدون رنگ" Localization-HexInputTitle="کد هگز">
                </telerik:RadColorPicker>
            </td>
        </tr>
        <tr class="Table_RowC">
            <td style="width: 150px">توقف طولانی مدت:</td>
            <td style="width: 200px">
                <telerik:RadBinaryImage runat="server" ID="LongStopImage" ImageUrl="~/Images/Controls/van.png" ResizeMode="Fit" Width="60" Height="60" />
                <div id="changeBtn6">
                    <telerik:RadAsyncUpload ID="upldLongStop" runat="server" AllowedFileExtensions=".jpg,.png,.gif,jpeg,.tiff"
                        MaxFileInputsCount="1" MultipleFileSelection="Disabled" OnFileUploaded="upldPhoto_FileUploaded" HideFileInput="true" Width="80">
                    </telerik:RadAsyncUpload>
                    <asp:Button Text="ذخیره" runat="server" CssClass="tsButton" OnClientClick="updatePictureAndInfo('LongStop'); return false;" />
                </div>
            </td>
            <td style="width: 75px">رنگ:</td>
            <td style="width: 150px">
                <telerik:RadColorPicker  runat="server" ID="cpLongStop" Width="96%" NoColorText="بدون رنگ" Localization-HexInputTitle="کد هگز">
                </telerik:RadColorPicker>
            </td>
        </tr>
    </table>
</div>
<div class="FormButtons">
    <telerik:RadButton runat="server" ID="btnSave" Text="ذخیره" AutoPostBack="true" Width="100px" Height="35px" OnClick="btnSave_Click"/>
    <telerik:RadButton runat="server" ID="btnClose" Text="بازگشت" AutoPostBack="false" Width="100px" Height="35px" OnClientClicked="CloseDialog" />
</div>