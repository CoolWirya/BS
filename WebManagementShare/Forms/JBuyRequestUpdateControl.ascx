<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="JBuyRequestUpdateControl.ascx.cs" Inherits="WebManagementShare.Forms.JBuyRequestUpdateControl" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>

<div class="BigTitle">درخواست های خرید</div>
<table style="width: 500px">
    <tr class="Table_RowC">
        <td style="width: 150px">تعداد سهام:</td>
        <td>
            <telerik:RadTextBox runat="server" ID="txtSharesCount" Width="100%"></telerik:RadTextBox></td>
    </tr>
</table>
<div class="FormButtons">
    <telerik:RadButton runat="server" ID="btnSave1" Text="ذخیره" AutoPostBack="true" Width="100px" Height="35px" OnClick="btnSave_Click" />
    <telerik:RadButton runat="server" ID="btnClose1" Text="بازگشت" OnClientClicked="CloseDialog" AutoPostBack="false" Width="100px" Height="35px" />
    <input type="button" title="web service" name="web service" onclick="Request()"/>
</div>

<script type="text/javascript">
    function Request() {
        var data = "{pGuid:'1'}";
        MapRequestIsRun = $.ajax({
            url: "../WebManagementShare/WebServices/AndroidWebService.asmx/GetPersonInfo",
            contentType: "application/json",
            cache: false,
            type: "POST",
            data: data,
            async: false,
            error: function (err) {
            },
            success: function (data) {
                
            }
        });
    }
</script>
