<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="JFormListControl.ascx.cs" Inherits="WebControllers.FormManager.JFormListControl" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<telerik:RadCodeBlock runat="server" ID="RadCodeBlock1" EnableViewState="false">
 
    <style>
        .GridButton {
            height:40px; 
            margin-left:2px;
            border-left: 1px black solid; 
            padding-left:3px;
            background: #d5d0d0 right center no-repeat;
            text-align:left;
        }
            .GridButton:active {
            border-left: 1px #d5d0d0 initial; 
            border-right: 1px black solid; 
            }
    </style>
	<script type="text/javascript">
		var _evt;
		function RowDblClick(sender, eventArgs) {
			var evt = eventArgs.get_domEvent();

			if (evt.target.tagName == "INPUT" || evt.target.tagName == "A") {
				return;
			}

			var index = eventArgs.get_itemIndexHierarchical();
			//document.getElementById("radGridClickedRowIndex").value = index;
			__doPostBack('gridviewDblClicked', index);
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
          <%-- <script type="text/javascript">
               $(function () {
                   document.getElementById('<%=btnAddFormObject.ClientID %>').style.visibility = "hidden";
     });


</script>--%>

    <script type="text/javascript">
window.onload = function() {            
    document.getElementById('postreply').style.display = 'none';
        
            $("#gridView").hide();
        
    }</script>
</telerik:RadCodeBlock>
<asp:HiddenField runat="server" ID="hidSelectedRowCode" />
<asp:HiddenField runat="server" ID="hidSelectedRowObjectCode" />
<div runat="server" id="rightDiv" style="width: 500px;"><br />
	<div runat="server" id="divForms" style="width:300px">
		قالب فرم ها(یک فرم انتخاب کنید)
	</div>
<%--	<div runat="server" id="div1" class="menu">
		<telerik:RadGrid runat="server" ID="SqlGrid" Enabled="false">
		</telerik:RadGrid>
	</div>--%>
</div>
<div runat="server" id="divFormObjects" style="width: 500px">
	<asp:HiddenField runat="server" ID="hidSelectedForm" />
	آخرین فرم  ایجاد شده:<p id ="Objlabel" runat="server" ></p> <br />
    <br />
		<asp:Button runat="server" ID="btnAddFormObject" Text="جدید" OnClick="btnAddFormObject_Click" CssClass="GridButton"
            style="width:70px; background-image: url(../images/Controls/toolbar_add.png);" />
		<asp:Button runat="server" ID="btnEditFormObject" Text="ویرایش" OnClick="btnEditFormObject_Click" CssClass="GridButton"
            style="width:75px; background-image: url(../images/Controls/toolbar_edit.png);" />
	<telerik:RadGrid runat="server" ID="gridView" PageSize="10" AllowPaging="true">
		<ClientSettings ReorderColumnsOnClient="true" Selecting-AllowRowSelect="true"
			AllowColumnsReorder="true" ColumnsReorderMethod="Reorder" AllowColumnHide="true" AllowRowHide="true" AllowGroupExpandCollapse="true">
			<ClientEvents OnRowDblClick="RowDblClick" OnRowClick="RowClick" />
			<Resizing AllowColumnResize="true" ResizeGridOnColumnResize="true" AllowResizeToFit="true" EnableRealTimeResize="true" ClipCellContentOnResize="true" />
		</ClientSettings>
	</telerik:RadGrid>




    <%--<telerik:RadButton runat="server" ID="btnEdit" Text="ویرایش" AutoPostBack="true" Width="100px" Height="35px"/>--%>

</div>
