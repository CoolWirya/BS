<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="JPicGalleryCategoryUpdateControl.ascx.cs" Inherits="AndroidWebManagement.Forms.JPicGalleryCategoryUpdateControl" %>

<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>

<div class="BigTitle">دسته بندی گالری تصاویر</div>
<table style="width: 500px">
    <tr class="Table_RowB">
        <td style="width: 150px">عنوان:</td>
        <td>
            <telerik:radtextbox runat="server" id="txtTitle" width="100%"></telerik:radtextbox>
        </td>
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
    <telerik:radbutton runat="server" id="btnSave" text="ذخیره" autopostback="true" width="100px" height="35px" onclick="btnSave_Click" />
    <telerik:radbutton runat="server" id="btnClose" text="بازگشت" onclientclicked="CloseDialog" autopostback="false" width="100px" height="35px" />
    <telerik:radbutton runat="server" id="btnDelete" text="حذف" autopostback="true" width="100px" height="35px" onclick="btnDelete_Click" cssclass="floatLeft" onclientclicking="OnClientClicking" />
</div>
