<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="JShowNewsControl.ascx.cs" Inherits="WebManagementShare.Forms.JShowNewsControl" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>

<div class="BigTitle">نمایش خبر</div>
<div class="FormContent">
    <table style="width: 100%; padding-top: 50px">
        <tr>
            <td style="margin-right: 40px; margin-left: 40px; font-size: 20px" class="FontYekan">
                <%=StrNews %>
            </td>
        </tr>
    </table>
</div>

<div class="FormButtons">
    <telerik:RadButton runat="server" ID="btnClose" Text="بازگشت" OnClientClicked="CloseDialog" AutoPostBack="false" Width="100px" Height="35px" />
</div>

