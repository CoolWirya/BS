<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="addDeviceToGroup.ascx.cs" Inherits="WebAVL.Forms.addDeviceToGroup" %>


<%@ Register Assembly="AVL" Namespace="AVL.Controls.Search" TagPrefix="cc1" %>
<%@ Register Src="~/WebAVL/Controls/Search/JSearchDevice.ascx" TagPrefix="cc1" TagName="JSearchDevice" %>



<script type="text/javascript">
    $(document).ready(function () {
        function sendmsg(msg, imei, gpid, msgtype) {
            $.ajax({
                type: 'POST',
                url: 'Services/WebBaseDefineService.asmx/SetMessage',
                data: " {" +
						 "'message': '" + msg + "'  " +
						 ",'imei':'" + imei + "'" +
						 ",'gpID':'" + gpid + "'" +
						 ",'msgtype': '" + msgtype + "'" +
						 "}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (msg) {
                    alert('عملیات موفق');
                    GetRadWindow().close();
                    //GetRadWindow().BrowserWindow.RefreshGrid();
                    //CloseDialog(null);
                },
                error: function (xhr, status, error) {
                    alert(JSON.parse(xhr.responseText).Message);
                }
            });
            return false;
        }
    });
</script>
<asp:Label ID="h3" runat="server" Text="یک دستگاه را انتخاب کنید و سپس گرفتن کد را کلیک کنید. کد تولید شده را با فرد مورد نظر به اشتراک بگذارید و در صورت تمایل به گروه دستگاه مورد نظر ملحق می شود."></asp:Label>
<table dir="rtl">
    <tr>
        <td><span>دستگاه مدیر</span>
        <td>
        <td>
              <cc1:JSearchDevice runat="server" ID="searchDevice"  OnClientClick="return false;" AutoPostBack="false"></cc1:JSearchDevice>
                  
        </td>
    </tr>
    <tr>
        <td>کد : </td>
        <td>
            <asp:Label ID="txtMessage" runat="server"></asp:Label>
        </td>
    </tr>
    <tr>
        <td colspan="2">
            <asp:Button ID="btnSend" runat="server" Text="گرفتن کد" OnClick="btnSend_Click" CssClass="Nothing" />
        </td>
    </tr>
</table>
