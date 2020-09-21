<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ItemReportUpdate.ascx.cs" Inherits="WebProjectManagement.Forms.ItemReportUpdate" %>

<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register Src="~/WebControllers/MainControls/Date/JDateControl.ascx" TagPrefix="uc1" TagName="JDateControl" %>

<script type="text/javascript">
    <%--$(document).ready(function () {
        $('#<%= btnSave.ClientID %>').click(function () {            
            $.ajax({
                type: 'POST',
                url: 'Services/ProjectManagementService.asmx/SaveItemReport',
                data: " {" +
						 "'code': '<%= Request["Code"].ToString()%>'" +
						 ",'itemCode':'<%= Request["ItemCode"].ToString()%>'" +
						 ",'improvementPercentage':'" + $('#<%= drdImprovementPercent.ClientID %>').val() + "'" +
						 ",'reportDesciption': '" + $('#<%= txtReportDescription.ClientID %>').val() + "'" +
						 ",'userCode': '<%= WebClassLibrary.SessionManager.Current.MainFrame.CurrentUserCode.ToString() %>'" +
						 "}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (msg) {
                    alert('عملیات موفق');
                    GetRadWindow().close();
                    //GetRadWindow().BrowserWindow.RefreshGrid();
                    //CloseDialog(null);
                },
                error: function (xhr, status, error) {
                    alert(JSON.parse(xhr.responseText).Message);
                }
            });
            return false;
        });
    });--%>
</script>
<table>    
    <tr>
        <td class="Table_RowB">نام پروژه</td>
        <td class="Table_RowC"><telerik:RadLabel runat="server" ID="txtProjectName"></telerik:RadLabel></td>
    </tr >
    <tr>
        <td class="Table_RowB">آیتم های سرشاخه</td>
        <td class="Table_RowC"><telerik:RadLabel runat="server" ID="txtParentNodes"></telerik:RadLabel></td>
    </tr>
    <tr>
        <td class="Table_RowB">نام آیتم</td>
        <td class="Table_RowC"><telerik:RadLabel runat="server" ID="txtName"></telerik:RadLabel></td>
    </tr>
    <tr>
        <td class="Table_RowB">درصد پیشرفت این آیتم</td>
        <td class="Table_RowC">
            <telerik:RadTextBox runat="server" ID="txtImprovementPercent" ></telerik:RadTextBox>
        </td>
    </tr>
    <tr>
        <td class="Table_RowB">تاریخ</td>
        <td class="Table_RowC">
            <uc1:JDateControl runat="server" id="date" />
        </td>
    </tr>
    <tr>
        <td class="Table_RowB">توضیحات </td>
        <td class="Table_RowC"><telerik:RadTextBox runat="server" ID="txtReportDescription" TextMode="MultiLine" MaxLength="250" Width="100%" Height="150px"></telerik:RadTextBox></td>
    </tr>
    <tr>
        <td class="Table_RowB">آپلود تصویر </td>
        <td class="Table_RowC">
            <telerik:RadUpload runat="server" ID="uploadPhoto"  AllowedFileExtensions=".jpg,.png,.gif,jpeg,.tiff" 
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
                 OnClick="btnSave_Click" Width="100px" Height="35px" ValidationGroup="Line"/>
        </td>
        <td class="Table_RowC"><telerik:RadButton runat="server" ID="btnClose" Text="بازگشت" OnClientClicked="CloseDialog" AutoPostBack="false" Width="100px" Height="35px" /></td>
    </tr>
</table>