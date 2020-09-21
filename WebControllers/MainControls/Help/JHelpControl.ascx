<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="JHelpControl.ascx.cs" Inherits="WebControllers.MainControls.Help.JHelpControl" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<div class="FormContent">
    <asp:Label runat="server" ID="lblHelp" Width="100%"></asp:Label>
    <telerik:RadEditor runat="server" ID="txtHelp" ToolTip="" Width="100%" Height="100%"></telerik:RadEditor>
</div>
<div class="FormButtons" runat="server" id="divButtons">
    <telerik:RadButton runat="server" ID="btnSave" Text="ذخیره" AutoPostBack="true" Width="100px" Height="35px" OnClick="btnSave_Click" ValidationGroup="Area" />
</div>
