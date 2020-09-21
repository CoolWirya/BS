<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="JMainConfigurationControl.ascx.cs" Inherits="WebControllers.MainControls.Configuration.JMainConfigurationControl" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>

<telerik:RadCodeBlock runat="server">
    <script type="text/javascript">
        $(function () {
            $('tr').click(function () {
                $('tr').removeClass("Table_RowD");
                $(this).addClass("Table_RowD");
                if (this.id == "trInformation") {
                    ShowMenu('<%=(new WebClassLibrary.JActionsInfo("config", WebClassLibrary.JDomains.JActionEvents.MouseClick, "WebControllers.MainControls.Configuration.JConfiguration._Information",null,null)).ActionToString() %>');
                }
                else if (this.id == "trChangePassword") {
                    ShowMenu('<%=(new WebClassLibrary.JActionsInfo("config", WebClassLibrary.JDomains.JActionEvents.MouseClick, "WebControllers.MainControls.Configuration.JConfiguration._ChangePassword",null,null)).ActionToString() %>');
                }
                else if (this.id == "trSettings") {
                    ShowMenu('<%=(new WebClassLibrary.JActionsInfo("config", WebClassLibrary.JDomains.JActionEvents.MouseClick, "WebControllers.MainControls.Configuration.JConfiguration._Settings",null,null)).ActionToString() %>');
                }
            });
        });
    </script>
</telerik:RadCodeBlock>

<table class="CustomTable" style="width:100%">
    <tr id="trInformation">
        <td style="width:80px;text-align:center"><img src="../WebControllers/MainControls/Configuration/Images/Information.png" /></td>
        <td>مشخصات کاربر</td>
    </tr>
    <tr id="trChangePassword">
        <td style="width:80px;text-align:center"><img src="../WebControllers/MainControls/Configuration/Images/ChangePassword.png" /></td>
        <td>تغییر کلمه عبور</td>
    </tr>
    <tr id="trSettings">
        <td style="width:80px;text-align:center"><img src="../WebControllers/MainControls/Configuration/Images/Settings.png" /></td>
        <td>تنظیمات</td>
    </tr>
</table>