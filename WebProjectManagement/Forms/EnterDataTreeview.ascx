<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="EnterDataTreeview.ascx.cs" Inherits="WebProjectManagement.Forms.EnterDataTreeview" %>



<style>
    .treeviewPart1 {
        color: blue;
    }

    .treeviewPart2 {
        color: red;
    }

    .treeviewPart3 {
        color: green;
    }
    
    .RadTreeView_rtl .rtMinus {
    background-position: -11px -11px;
}
    .RadTreeView_rtl .rtPlus {
    background-position: -11px 0px;
}
    .rtMid,.rtTop,.rtBot{

    margin-right: 10px;
}

</style>

<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register Src="~/WebControllers/MainControls/Date/JDateControl.ascx" TagPrefix="uc1" TagName="JDateControl" %>
<input type="button" onclick="window.location.href = window.location.href" value="بروزرسانی" />
<div style="width: 50%; float: right; height: 100%; top: 70px; bottom: 0px; overflow: scroll">

    <telerik:RadTreeView runat="server" ID="trvOrg" Font-Size="Larger" OnNodeClick="trvOrg_NodeClick">
        <WebServiceSettings Path="WebProjectManagement/Forms/Services.aspx" Method="LoadNodes" />
    </telerik:RadTreeView>
</div>
<div style="width: 50%; float: left;">
    <asp:Panel runat="server" ID="pnlEnterData" Visible="false">
        <table style="width: 100%;">
            <tr>
                <td class="Table_RowB">نام پروژه</td>
                <td class="Table_RowC">
                    <telerik:RadLabel runat="server" ID="txtProjectName"></telerik:RadLabel>
                </td>
            </tr>
            <tr>
                <td class="Table_RowB">آیتم های سرشاخه</td>
                <td class="Table_RowC">
                    <telerik:RadLabel runat="server" ID="txtParentNodes"></telerik:RadLabel>
                </td>
            </tr>
            <tr>
                <td class="Table_RowB">نام آیتم</td>
                <td class="Table_RowC">
                    <telerik:RadLabel runat="server" ID="txtName"></telerik:RadLabel>
                </td>
            </tr>
            <tr>
                <td class="Table_RowB">درصد پیشرفت این آیتم<telerik:RadLabel runat="server" ID="txtAllowedPercentage"></telerik:RadLabel>
                </td>
                <td class="Table_RowC">
                    <telerik:RadTextBox runat="server" ID="txtImprovementPercent"></telerik:RadTextBox>
                </td>
            </tr>
            <%--<% if (ClassLibrary.JPermission.CheckPermission("WebProjectManagement.Forms.EnterDataTreeView.DateControl"))
                { %>
            <tr>
                <td class="Table_RowB">تاریخ</td>
                <td class="Table_RowC">
                    <uc1:JDateControl runat="server" id="date" />
                </td>
            </tr>
            <% } %>--%>
            <tr>
                <td class="Table_RowB">توضیحات </td>
                <td class="Table_RowC">
                    <telerik:RadTextBox runat="server" ID="txtReportDescription" TextMode="MultiLine" MaxLength="250" Width="100%" Height="150px"></telerik:RadTextBox></td>
            </tr>
            <tr>
                <td class="Table_RowB">آپلود تصویر </td>
                <td class="Table_RowC">
                    <telerik:RadUpload runat="server" ID="uploadPhoto" AllowedFileExtensions=".jpg,.png,.gif,jpeg,.tiff"
                        MultipleFileSelection="Enabled" HideFileInput="true"
                        Width="80" />
                </td>
            </tr>
            <tr>
                <td class="Table_RowB">تصاویر </td>
                <td class="Table_RowC">
                    <asp:Panel runat="server" ID="pnlImages"></asp:Panel>
                </td>
            </tr>
            <tr>
                <td class="Table_RowB">
                    <telerik:RadButton runat="server" ID="btnSave" Text="ذخیره"
                        OnClick="btnSave_Click" Width="100px" Height="35px" ValidationGroup="Line" />
                </td>
                <td class="Table_RowC">
                    <telerik:RadButton runat="server" ID="btnClose" Text="بازگشت" OnClientClicked="CloseDialog" AutoPostBack="false" Width="100px" Height="35px" />
                </td>
            </tr>
        </table>
    </asp:Panel>
</div>




