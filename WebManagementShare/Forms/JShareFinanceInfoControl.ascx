<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="JShareFinanceInfoControl.ascx.cs" Inherits="WebManagementShare.Forms.JShareFinanceInfoControl" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register Src="~/WebControllers/MainControls/Grid/JGridViewControl.ascx" TagPrefix="uc1" TagName="JGridViewControl" %>

<div class="BigTitle">اطلاعات مالی</div>
<div class="FormContent">
    <table style="width: 100%; padding-top: 50px">
        <tr>
            <td>
                <telerik:RadGrid ID="RadGridPaymentDetail" runat="server" AutoGenerateColumns="true" OnPreRender="RadGridPaymentDetail_PreRender">
                </telerik:RadGrid>
            </td>
        </tr>
    </table>
</div>
