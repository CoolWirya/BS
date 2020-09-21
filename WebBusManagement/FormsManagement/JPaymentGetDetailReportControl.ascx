<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="JPaymentGetDetailReportControl.ascx.cs" Inherits="WebBusManagement.FormsManagement.JPaymentGetDetailReportControl" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register Assembly="WebControllers" Namespace="WebControllers.MainControls.Grid" TagPrefix="cc1" %>

<div class="FormContent">
    <div class="BigTitle">مشاهده جزئیات سند پرداختی</div>
    <table style="width: 100%; height: auto; margin-top: 15px">
        <tr>
            <td style="width: 100%; height: auto; overflow: auto"><cc1:JGridView runat="server" id="RadGridReport"></cc1:JGridView>
                
            </td>
        </tr>
      <%--  <tr>
            <td style="width: 100%; height: auto; overflow: auto; text-align: center">
                مجموع سند
            </td>
        </tr>
        <tr>
            <td style="width: 100%; height: auto; overflow: auto"><cc1:JGridView runat="server" id="RadGridReport"></cc1:JGridView>
                <uc1:JGridViewControl runat="server" id="RadGridReportTotal" />
            </td>
        </tr>--%>
    </table>
</div>
<div class="FormButtons">
    <telerik:RadButton runat="server" ID="btnClose" Text="بازگشت" OnClientClicked="CloseDialog" AutoPostBack="false" Width="100px" Height="35px" />
    <telerik:RadButton runat="server" ID="btnDelete" Text="حذف سند و جزئیات" AutoPostBack="true" Width="120px" Height="35px" OnClick="btnDelete_Click" CssClass="floatLeft" OnClientClicking="OnClientClicking" />
</div>
