<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="JBusGetEqualizationFile.ascx.cs" 
    Inherits="WebBusManagement.FormsReports.JBusGetEqualizationFile" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register Src="~/WebControllers/MainControls/Date/JDateControl.ascx" TagPrefix="uc1" TagName="JDateControl" %>
<%@ Register Assembly="WebControllers" Namespace="WebControllers.MainControls.Grid" TagPrefix="cc1" %>
 
<telerik:RadAjaxManagerProxy runat="server" ID="AjaxManagerProxy_Control2">
    <AjaxSettings>
        <telerik:AjaxSetting AjaxControlID="cmbBus">
            </telerik:AjaxSetting>
    </AjaxSettings>
</telerik:RadAjaxManagerProxy>

<div class="BigTitle">دریافت فایل تسویه</div>
<table style="width: 500px">
<tr class="Table_RowB">
        <td style="width: 75px">اتوبوس:</td>
        <td>
            <telerik:RadComboBox runat="server" ID="cmbBus" Width="50%" Filter="Contains" AutoPostBack="true"
                OnSelectedIndexChanged="cmbBus_SelectedIndexChanged">
            </telerik:RadComboBox>
        </td>
    </tr>
  <tr class="Table_RowB">
        <td style="width: 50px">از تاریخ:</td>
        <td>
            <uc1:JDateControl runat="server" id="txtFromDate" />
        </td>
    </tr>
    <tr class="Table_RowC">
        <td style="width: 50px">تا تاریخ:</td>
        <td>
            <uc1:JDateControl runat="server" id="txtToDate" />
        </td>
    </tr>
    <table style="width: 100%; height: auto; margin-top: 15px">
    <tr>
        <td style="width: 100%; height: auto; overflow: auto"><cc1:JGridView runat="server" id="RadGridReport"></cc1:JGridView>
            
        </td>
    </tr>
</table>
<%---<telerik:RadButton runat="server" ID="btnSave" Text="مشاهده گزارش" AutoPostBack="true" Width="100px" Height="35px" OnClick="btnSave_Click" />--%>
<%--<telerik:RadButton runat="server" ID="btnClose" Text="بازگشت" OnClientClicked="CloseDialog" AutoPostBack="false" Width="100px" Height="35px" />--%>
<<%--div style="width: 100%; height: 100%; text-align: center;direction:rtl">
    <center>
    <img src="../Images/download-icon.gif" />
        <br />
        در حال دریافت فایل . . .
        </center>
</div>--%>
