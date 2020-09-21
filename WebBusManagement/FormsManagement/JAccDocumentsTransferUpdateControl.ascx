<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="JAccDocumentsTransferUpdateControl.ascx.cs" Inherits="WebBusManagement.FormsManagement.JAccDocumentsTransferUpdateControl" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register Src="~/WebControllers/MainControls/Date/JDateControl.ascx" TagPrefix="uc1" TagName="JDateControl" %>

<div class="BigTitle">انتقال سند</div>
<div style="top:40px; margin-bottom: 45px">
    <table style="width: 500px">
        <tr class="Table_RowB">
            <td style="width: 100px">نام مالک:</td>
            <td>
            <telerik:RadComboBox runat="server" ID="cmbOwner" Width="250px" Filter="Contains">
            </telerik:RadComboBox>
            </td>
        </tr>
        <tr class="Table_Rowc">
            <td style="width: 150px">از تاریخ:</td>
            <td>
                <uc1:JDateControl runat="server" id="txtFromDate" />
            </td>
        </tr>
        <tr class="Table_RowB">
            <td style="width: 150px">به تاریخ:</td>
            <td>
                <uc1:JDateControl runat="server" id="txtToDate" />
            </td>
        </tr>
    </table>
</div>
<div class="FormButtons">
    <telerik:RadButton runat="server" ID="btnSave" Text="تایید" AutoPostBack="true" Width="100px" Height="35px" OnClick="btnSave_Click" OnClientClicked="btnSave_ClientClick" ValidationGroup="Line" />
</div>
