<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="JClassListControl.ascx.cs" Inherits="WebBaseDefine.Forms.JClassListControl" %>
<%@ Register Assembly="WebControllers" Namespace="WebControllers.MainControls.Grid" TagPrefix="cc1" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<asp:DropDownList runat="server" ID="ProjectsDropDownList" Height="24px" Width="400px" AutoPostBack="true" OnSelectedIndexChanged="ProjectsDropDownList_SelectedIndexChanged" >
</asp:DropDownList>
<br />
<br />
<cc1:JGridView runat="server" id="RadGridReport">
</cc1:JGridView>
