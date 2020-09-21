<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="JWebForms.ascx.cs" Inherits="WebControllers.FormManager.JWebForms" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>

<telerik:RadCodeBlock runat="server" ID="RadCodeBlock1" EnableViewState="false">
    <script type="text/javascript">
        var _evt;
        function RowDblClick(sender, eventArgs) {
            var evt = eventArgs.get_domEvent();

            if (evt.target.tagName ==  "INPUT" || evt.target.tagName == "A") {
                return;
            }

            var index = eventArgs.get_itemIndexHierarchical();
            //document.getElementById("radGridClickedRowIndex").value = index;
            document.getElementById("<%=btnEdit.ClientID%>").click();
            //__doPostBack('gridviewDblClicked', '');
        }
        function RowClick(sender, eventArgs) {
            var evt = eventArgs.get_domEvent();

            if (evt.target.tagName == "INPUT" || evt.target.tagName == "A") {
                return;
            }

            var index = eventArgs.get_itemIndexHierarchical();
            //document.getElementById("radGridClickedRowIndex").value = index;
        }

    </script>
</telerik:RadCodeBlock>
<%--<input type="text" runat="server" id="radGridClickedRowIndex" name="radGridClickedRowIndex" />--%>
<%--<asp:TextBox runat="server" ID="radGridClickedRowIndex" />--%>
<telerik:RadGrid runat="server" ID="gridView" PageSize="10" AllowPaging="true" OnPageIndexChanged="gridView1_PageIndexChanged">
    <ClientSettings ReorderColumnsOnClient="true" Selecting-AllowRowSelect="true"
        AllowColumnsReorder="true" ColumnsReorderMethod="Reorder" AllowColumnHide="true" AllowRowHide="true" AllowGroupExpandCollapse="true">
        <ClientEvents OnRowDblClick="RowDblClick" OnRowClick="RowClick" />
        <Resizing AllowColumnResize="true" ResizeGridOnColumnResize="true" AllowResizeToFit="true" EnableRealTimeResize="true" ClipCellContentOnResize="true" />
    </ClientSettings>
</telerik:RadGrid>
<br />
<telerik:RadButton runat="server" ID="btnNew" Text="فرم جدید" AutoPostBack="true" Width="100px" Height="35px" OnClick="btnNew_Click" />
<telerik:RadButton runat="server" ID="btnEdit" Text="ویرایش" AutoPostBack="true" Width="100px" Height="35px" OnClick="btnEdit_Click" />
<telerik:RadButton runat="server" ID="btnDelete" Text="حذف" AutoPostBack="true" Width="100px" Height="35px" OnClick="btnDelete_Click" />
<telerik:RadButton runat="server" ID="btnClose" Text="بستن" OnClientClicked="CloseDialog" AutoPostBack="false" Width="100px" Height="35px" />
