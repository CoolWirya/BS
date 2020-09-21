<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="JAccDocumentsEditCommentUpdateControl.ascx.cs" Inherits="WebBusManagement.FormsManagement.JAccDocumentsEditCommentUpdateControl" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>

<div class="FormContent">
    <div class="BigTitle">ویرایش شرح سند</div>
    <table style="width: 100%; height: auto; margin-top: 15px">
        <tr>
            <td style="width: 100%; height: auto; overflow: auto">
                <telerik:RadTextBox RenderMode="Lightweight"  ID="RadTextBox1" LabelWidth="95px"
                    Label="عنوان سند:" EmptyMessage="عنوان جدید سند"
                    runat="server" AutoPostBack="False" InvalidStyleDuration="100" Width="100%">
                </telerik:RadTextBox>            </td>
        </tr>
    </table>
</div>
<div class="FormButtons">
    <telerik:RadButton runat="server" ID="btnSave" Text="تایید" AutoPostBack="true" OnClick="btnSave_Click" Width="100px" Height="35px" />
    <telerik:RadButton runat="server" ID="btnClose" Text="بازگشت" OnClientClicked="CloseDialog" AutoPostBack="false" Width="100px" Height="35px" />
</div>