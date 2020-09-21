<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="JOnlineMap.ascx.cs" Inherits="WebBusManagement.OnlineMap.JOnlineMap" %>
<%@ Register Src="~/WebControllers/MainControls/OpenLayersMap/OpenLayersMap.ascx" TagPrefix="Map" TagName="OpenLayersMap" %>

<div runat="server" id="divMap"></div>
Start
<Map:openlayersmap runat="server" id="OpenLayersMap" />
End