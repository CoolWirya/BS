<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="JFleetUpdateControl.ascx.cs" Inherits="WebBusManagement.FormsManagement.JFleetUpdateControl" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register Src="~/WebControllers/MainControls/Date/JDateControl.ascx" TagPrefix="uc1" TagName="JDateControl" %>


<div class="BigTitle">ناوگان</div>
<table style="width: 500px">
    <tr class="Table_RowB">
        <td style="width: 150px">نام:</td>
        <td>
            <telerik:RadTextBox runat="server" ID="txtName" Width="100%"></telerik:RadTextBox></td>
    </tr>
    <tr class="Table_RowC">
        <td style="width: 150px">نوع ناوگان:</td>
        <td>
            <telerik:RadComboBox runat="server" ID="cmbFleetType" Width="100%"></telerik:RadComboBox>
        </td>
    </tr>
    <tr class="Table_RowB">
        <td style="width: 150px">تاریخ شروع به کار:</td>
        <td>
            <uc1:JDateControl runat="server" id="JDateControl_A" />
        </td>
    </tr>
    <tr class="Table_RowC">
        <td style="width: 150px">تاریخ پایان کار:</td>
        <td>
            <uc1:JDateControl runat="server" id="JDateControl_B" />
        </td>
    </tr>
</table>
<div class="FormButtons">
    <telerik:RadButton runat="server" ID="btnSave" Text="ذخیره" AutoPostBack="true" Width="100px" Height="35px" OnClick="btnSave_Click" />
    <telerik:RadButton runat="server" ID="btnClose" Text="بازگشت" OnClientClicked="CloseDialog" AutoPostBack="false" Width="100px" Height="35px" />
     <telerik:RadButton runat="server" ID="btnDelete" Text="حذف" AutoPostBack="true" Width="100px" Height="35px" OnClick="btnDelete_Click" CssClass="floatLeft" OnClientClicking="OnClientClicking" />
</div>
