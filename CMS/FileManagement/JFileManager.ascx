<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="JFileManager.ascx.cs" Inherits="CMS.FileManagement.JFileManager" %>
<%@ Register Assembly="CMSClassLibrary" Namespace="CMSClassLibrary.Controls" TagPrefix="JJson" %>

<table>
    <tr>
        <td>
            <JJson:JFileTree runat="server" ID="FManagerTool" />
        </td>
    </tr>
</table>
