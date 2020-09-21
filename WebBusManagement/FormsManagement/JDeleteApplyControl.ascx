<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="JDeleteApplyControl.ascx.cs" Inherits="WebBusManagement.FormsManagement.JDeleteApplyControl" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<div class="BigTitle">تایید سند حسابداری / واقعه</div>
<table style="width:100%">
    <tr class="Table_RowB">
        <td>
            <center>تایید سند/واقعه با موفقیت انجام شد</center>
        </td>
    </tr>
</table>
<div class="FormButtons">
  <telerik:RadButton runat="server" ID="btnClose" Text="بازگشت" OnClientClicked="CloseDialog" AutoPostBack="false" Width="100px" Height="35px" />
</div>

