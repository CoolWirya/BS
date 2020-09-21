<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ReisterSubuserUpdate.ascx.cs" Inherits="WebAVL.Forms.ReisterSubuserUpdate" %>

<table>
    <tr>
        <td>
            نام کاربری
        </td>
        <td>
            <asp:TextBox ID="txtUsername" runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>
            شماره همراه
        </td>
        <td>
            <asp:TextBox ID="txtMobile" runat="server"></asp:TextBox>
        </td>
    </tr>
</table>
<asp:Button ID="btnSubmit" runat="server" Text="ثبت" OnClick="btnSubmit_Click" /><br />
<strong>شما می توانید به کاربر دیگر اجازه دهید تا اشیایی که شما اجازه می دهید را ببیند. برای این کار مراحل زیر را انجام دهید.</strong>
<ul>
    <li>کاربر در پرتال ثبت نام می کند.</li>
    <li>شماره تماس و نام کاربر کاربر را در فرم بالا ثبت کنید.</li>
    <li>سپس به قسمت رهگیری-ثبت کاربر رفته.</li>
    <li>بر روی کاربر دوبار کلیک کنید.</li>
    <li>در صفحه ی ظاهر شده اشیایی را که کاربر اجازه رویت دارد را انتخاب کنید و دکمه اختصاص را بزنید.</li>
</ul>