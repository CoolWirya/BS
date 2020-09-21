<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="JDateControl.ascx.cs" Inherits="WebControllers.MainControls.Date.JDateControl" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="PersianDateControls 2.0" Namespace="PersianDateControls" TagPrefix="pdc" %>

<%--<telerik:radajaxmanagerproxy runat="server" id="radProcJBusPerformanceReport">
    <AjaxSettings>
        <telerik:AjaxSetting AjaxControlID="PersianDateTextBox1">
            <UpdatedControls>
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:radajaxmanagerproxy>--%>
<div style="z-index: 300">
    <asp:UpdatePanel ID="Upd1" runat="server">
        <ContentTemplate>
            <div style="visibility: hidden" runat="server" id="dtScriptManager"></div>
            <pdc:PersianDateTextBox runat="server" ID="PersianDateTextBox1" Width="100%"></pdc:PersianDateTextBox>
        </ContentTemplate>
    </asp:UpdatePanel>
</div>
