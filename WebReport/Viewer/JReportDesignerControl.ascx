<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="JReportDesignerControl.ascx.cs" Inherits="WebReport.Viewer.JReportDesigner" %>
<%@ Register Assembly="Stimulsoft.Report.WebDesign" Namespace="Stimulsoft.Report.Web" TagPrefix="cc1" %>
<%--comment--%>
<cc1:StiWebDesigner ID="StiWebDesigner1" runat="server" OnSaveReport="StiWebDesigner1_SaveReport"  />

<asp:HiddenField runat="server" ID="hfReportCode" />
