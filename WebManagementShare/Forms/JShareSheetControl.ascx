<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="JShareSheetControl.ascx.cs" Inherits="WebManagementShare.Forms.JShareSheet" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register Src="~/WebControllers/MainControls/Grid/JGridViewControl.ascx" TagPrefix="uc1" TagName="JGridViewControl" %>

<div class="BigTitle">اطلاعات دارائی</div>
<div class="FormContent">
    <table style="width: 100%; padding-top: 50px">
        <tr>
            <td>
                <uc1:JGridViewControl runat="server" ID="RadGridAsset" />
            </td>
        </tr>
    </table>
</div>
