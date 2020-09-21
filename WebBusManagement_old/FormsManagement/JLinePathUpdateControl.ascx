<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="JLinePathUpdateControl.ascx.cs" Inherits="WebBusManagement.FormsManagement.JLinePathUpdateControl" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register Src="~/WebControllers/MainControls/OpenLayersMap/OpenLayersMap.ascx" TagPrefix="uc1" TagName="OpenLayersMap" %>

<div class="BigTitle">مسیر خط</div>
<div style="width: 100%; height: 80%">
    <uc1:openlayersmap runat="server" id="OpenLayersMapLinePath" />
</div>
<div style="clear: both; height: 10px"></div>
<telerik:RadButton runat="server" ID="btnSave" Text="ذخیره" AutoPostBack="true" Width="100px" Height="35px" OnClick="btnSave_Click"/>
<telerik:RadButton runat="server" ID="btnClose" Text="بازگشت" OnClientClicked="CloseDialog" AutoPostBack="false" Width="100px" Height="35px" />
