<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ItemReports.ascx.cs" Inherits="WebProjectManagement.Forms.ItemReports" %>

<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<link href="~/WebControllers/MainControls/JqueryChart/jquery.jqplot.min.css" rel="stylesheet" />

<telerik:RadComboBox runat="server" ID="cmbProjects" OnSelectedIndexChanged="cmbProjects_SelectedIndexChanged" AutoPostBack="true"></telerik:RadComboBox>
<telerik:RadComboBox runat="server" ID="cmbItems"></telerik:RadComboBox>
<telerik:RadButton runat="server" ID="btnSave" Text="مشاهده گزارش" AutoPostBack="true" Width="100px" Height="35px" OnClick="btnSave_Click" />
<telerik:RadButton runat="server" ID="btnClose" Text="بازگشت" OnClientClicked="CloseDialog" AutoPostBack="false" Width="100px" Height="35px" />

<telerik:RadHtmlChart runat="server" ID="RadHtmlChartCOL" Transitions="true" Width="1200px" Height="550px"></telerik:RadHtmlChart>

<telerik:RadHtmlChart runat="server" ID="RadHtmlChartPIE" Transitions="true" Width="1200px" Height="700px"></telerik:RadHtmlChart>

<asp:Panel runat="server" ID="pnlImages">

</asp:Panel>