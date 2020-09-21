<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="JNewsUpdateControl.ascx.cs" Inherits="AndroidWebManagement.Forms.JNewsUpdateControl" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>

<div class="BigTitle">اخبار</div>
<table style="width: 500px">
    <tr class="Table_RowB">
        <td style="width: 150px">عنوان:</td>
        <td>
            <telerik:RadTextBox runat="server" ID="txtTitle" Width="100%"></telerik:RadTextBox></td>
    </tr>
    <tr class="Table_RowC">
        <td style="width: 150px">شرح:</td>
        <td>
            <telerik:RadTextBox runat="server" ID="txtBody" Width="100%" TextMode="MultiLine"></telerik:RadTextBox></td>
    </tr>
    <tr class="Table_RowB">
        <td style="width: 150px">عکس:</td>
        <td>
            <asp:FileUpload ID="FileUpload" runat="server" />
           <%-- <br />
            <asp:RegularExpressionValidator ID="regexValidator" runat="server"
                ControlToValidate="FileUpload"
                ValidationGroup="BusFile"
                ErrorMessage="پسوند فایل شما باید .JPG باشد"
                ValidationExpression="(.*\.([Jj][Pp][Gg])$)"
                Display="Dynamic">
            </asp:RegularExpressionValidator>--%>
          <%--  <asp:RequiredFieldValidator ID="RequiredFieldValidator1"
                runat="server" ErrorMessage="لطفا فایل مورد نظر ار انتخاب کنید"
                ControlToValidate="FileUpload"
                ValidationGroup="BusFile"
                Display="Dynamic"></asp:RequiredFieldValidator>--%>
        </td>
    </tr>
    <tr class="Table_RowC">
        <td style="width: 150px"></td>
        <td>
            <center>
                <%=PicStr %>
            </center>
        </td>
    </tr>
</table>
<div class="FormButtons">
    <telerik:RadButton runat="server" ID="btnSave" Text="ذخیره" AutoPostBack="true" Width="100px" Height="35px" OnClick="btnSave_Click" />
    <telerik:RadButton runat="server" ID="btnClose" Text="بازگشت" OnClientClicked="CloseDialog" AutoPostBack="false" Width="100px" Height="35px" />
    <telerik:RadButton runat="server" ID="btnDelete" Text="حذف" AutoPostBack="true" Width="100px" Height="35px" OnClick="btnDelete_Click" CssClass="floatLeft" OnClientClicking="OnClientClicking" />
</div>
