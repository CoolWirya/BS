<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="JDeleteSendBoxNewUpdateControl.ascx.cs" Inherits="AndroidWebManagement.Forms.JDeleteSendBoxNewUpdateControl" %>

<div class="BigTitle">حذف پیام</div>
<table style="width: 100%">
    <tr class="Table_RowC">
        <td style="width: 100%">پیام مورد نظر شما با موفقیت حذف شد</td>
    </tr>
</table>
<div class="FormButtons">
    <telerik:radbutton runat="server" id="btnClose" text="بازگشت" onclientclicked="CloseDialog" autopostback="false" width="100px" height="35px" />
</div>
