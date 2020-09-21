<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="JRTPISFileDownloadUpdateControl.ascx.cs" Inherits="WebBusManagement.FormsManagement.JRTPISFileDownloadUpdateControl" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>

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
    <table>
        <tr class="Table_RowB">
            <td style="width: 120px">تصویر:</td>
            <td>
                    <div id="changeBtn">
                        <telerik:RadAsyncUpload ID="upldPhoto" runat="server"
                            MaxFileInputsCount="1" MultipleFileSelection="Disabled" OnFileUploaded="uplFile_FileUploaded" HideFileInput="true" Width="80" OnClientFileSelected="EnableAlwaysShowUpload">
                        </telerik:RadAsyncUpload>
                        <telerik:RadButton runat="server" ID="btnChangeImage" Text="ذخیره" OnClientClick="updatePictureAndInfo(); return false;"></telerik:RadButton>
                    </div>
            </td>
        </tr>
    </table> 
<div class="FormButtons">
    <telerik:RadButton runat="server" ID="btnSave" Text="ذخیره" AutoPostBack="true" Width="100px" Height="35px" OnClick="btnSave_Click" />
    <telerik:RadButton runat="server" ID="btnClose" Text="بازگشت" OnClientClicked="CloseDialog" AutoPostBack="false" Width="100px" Height="35px" OnClick="btnClose_Click" />
</div>
