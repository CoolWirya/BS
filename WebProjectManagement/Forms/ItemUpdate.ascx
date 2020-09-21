<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ItemUpdate.ascx.cs" Inherits="WebProjectManagement.Forms.ItemUpdate" %>

<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>

<script type="text/javascript">
    //string code,string name,string parentCode,string weight, string projectCode, string description
    $(document).ready(function () {
        $('#<%= btnSave.ClientID %>').click(function () {
            $.ajax({
                type: 'POST',
                url: 'Services/ProjectManagementService.asmx/SaveItem',
                data: " {" +
						 "'code': '<%= Request["ItemCode"].ToString()%>'" +
						 ",'name':'" + $('#<%= txtName.ClientID%>').val() + "'" +
						 ",'parentCode':'<%= Request["ParentCode"].ToString() %>'" +
						 ",'weight': '" + $('#<%= txtWeight.ClientID %>').val() + "'" +
						 ",'projectCode': '<%= Request["ProjectCode"].ToString() %>'" +
						 ",'description':'" + $('#<%= txtDescription.ClientID %>').val() + "'" +
						 "}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (msg) {
                    console.log(msg.d);
                    if (msg.d.toString().indexOf("!-") > -1) {
                        alert(msg.d.toString().substr(2));
                    } else {
                        //  GetRadWindow().BrowserWindow.RefreshGrid(); 
                        //CloseDialog(null);
                        var oWnd = GetRadWindow();
                        oWnd.close();
                        top.location.href = top.location.href;
                    }

                },
                error: function (xhr, status, error) {
                    alert(JSON.parse(xhr.responseText).Message);
                }
            });
            return false;
        });
    });
</script>
<table>    
    <tr>
        <td class="Table_RowB">نام پروژه</td>
        <td class="Table_RowC"><telerik:RadLabel runat="server" ID="txtProjectName"></telerik:RadLabel></td>
    </tr>
    <tr>
        <td class="Table_RowB">آیتم های سرشاخه</td>
        <td class="Table_RowC"><telerik:RadLabel runat="server" ID="txtParentNodes"></telerik:RadLabel></td>
    </tr>
    <tr>
        <td class="Table_RowB">نام</td>
        <td class="Table_RowC"><telerik:RadTextBox runat="server" ID="txtName"></telerik:RadTextBox></td>
    </tr>
    <tr>
        <td class="Table_RowB">درصد وزن</td>
            <td class="Table_RowC">
                <telerik:RadTextBox runat="server" ID="txtWeight"></telerik:RadTextBox>
            </td>
    </tr>
    <tr>
        <td class="Table_RowB">توضیحات پروژه</td>
        <td class="Table_RowC"><telerik:RadTextBox runat="server" ID="txtDescription" TextMode="MultiLine" MaxLength="250" Width="100%" Height="150px"></telerik:RadTextBox></td>
    </tr>
    <tr>
        <td class="Table_RowB"><telerik:RadButton runat="server" ID="btnSave" Text="ذخیره" AutoPostBack="false" Width="100px" Height="35px" ValidationGroup="Line"/></td>
        <td class="Table_RowC"><telerik:RadButton runat="server" ID="btnClose" Text="بازگشت" OnClientClicked="CloseDialog" AutoPostBack="false" Width="100px" Height="35px" /></td>
    </tr>
</table>
