<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ShowMarker.ascx.cs" Inherits="WebAVL.Forms.ShowMarker" %>

<%@ Register Assembly="AVL" Namespace="AVL.Controls.Map" TagPrefix="cc1" %>
<div style="width: 99%; height: 100%">
    <cc1:Map ID="Googlemap" runat="server"
        Width="100%" Height="100%"
        Zoom="15"
        Interval="1000"
        ImageSize="64,64,32,64"
         MarkerWithLabelAddress="../WebAVL/Script/m.js"></cc1:Map>
</div>