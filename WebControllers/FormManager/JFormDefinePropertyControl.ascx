<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="JFormDefinePropertyControl.ascx.cs" Inherits="WebControllers.FormManager.JFormDefinePropertyControl" %>
<%@ Register Assembly="JJson" Namespace="JJson.Controls" TagPrefix="JJson" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%--<%@ Register Src="~/FormManager/test.ascx" TagPrefix="uc1" TagName="JFormPropertyControl" %>--%>
<script src="js/jquery-1.8.2.min.js"></script>
<script src="js/jquery-ui-1.8.24.js"></script>
<script src="js/jquery-ui-1.8.24.min.js"></script>
<script type="text/javascript">
	$(document).ready(function () {
		$("#jfpcDiv").dialog({
			autoOpen: false,
			modal: true,
			show: {
				effect: "blind",
				duration: 300
			},
			hide: {
				effect: "blind",
				duration: 300
			},
			width: 800,
			height: 600
		});
		$("#jfpcDiv").parent().appendTo($("form:first"));
		//function myFunction() {
		//    alert("begin");
		//    $("#jfpcDiv").dialog("open");
		//    alert("end");
		//    return false;
		//}
		//alert("loaded");
		//$("#PopupButton2").click(function (event) {
		//control_Forms_btnInsert_input
		var dlg = null;
		$("#<%= btnInsert.ClientID%>").click(function (event) {
			//event.preventDefault();
			$("#<%=txbTitle.ClientID%>").val("");
			$("#<%=txbOrder.ClientID%>").val("");
			$("#<%=hdnPostEditList.ClientID%>").val("");
			$("#<%=hdnPostViewList.ClientID%>").val("")
			$("#<%=clbPostViewList.ClientID%> :checkbox").each(function () {
				$(this).removeAttr("checked");
			});
			$("#<%=clbPostViewList.ClientID%> :checkbox").each(function () {
				$(this).removeAttr("checked");
			});

			$("#jfpcDiv").dialog("open");
			//dlg.parent().appendTo($("form:first"));
		});
		$("#<%= btnPopupClose.ClientID %>").click(function (event) {
			//event.preventDefault();
			$("#jfpcDiv").dialog("close");
			//dlg = nul;
		});
		$("#<%= chkAllView.ClientID %>").change(function () {
			if ($(this).attr("checked"))
				$("#<%=clbPostViewList.ClientID%> :checkbox").attr("disabled", "disabled");
			else
				$("#<%=clbPostViewList.ClientID%> :checkbox").removeAttr("disabled");
		});
		$("#<%= chkAllEdit.ClientID %>").change(function () {
			if ($(this).attr("checked"))
				$("#<%=clbPostEditList.ClientID%> :checkbox").attr("disabled", "disabled");
			else
				$("#<%=clbPostEditList.ClientID%> :checkbox").removeAttr("disabled");
		});
		$("#<%= btnSave.ClientID %>").click(function () {
			var grd = $("#<%= gridView.ClientID%> tbody");
			var vPosts = "";
			var ePosts = "";
			$("#<%=clbPostViewList.ClientID%> :checked").each(function () {
    			vPosts += $(this).val() + ",";
    		});
    		if (vPosts.length > 0)
    			vPosts = vPosts.substr(0, vPosts.length - 1);
    		$("#<%=clbPostEditList.ClientID%> :checked").each(function () {
        		ePosts += $(this).val() + ",";
        	});
        	if (ePosts.length > 0)
        		ePosts = ePosts.substr(0, ePosts.length - 1);
        	$("#<%= hdnPostViewList.ClientID%>").val(vPosts);
            $("#<%= hdnPostEditList.ClientID%>").val(ePosts);
		});
	});
</script>
<telerik:RadCodeBlock runat="server" ID="RadCodeBlock1" EnableViewState="false">
	<script type="text/javascript">
		var _evt;
		function RowDblClick(sender, eventArgs) {
			var evt = eventArgs.get_domEvent();

			if (evt.target.tagName == "INPUT" || evt.target.tagName == "A") {
				return;
			}

			var index = eventArgs.get_itemIndexHierarchical();

			//__doPostBack('gridviewDblClicked', index);
			$("#<%=hdnCode.ClientID%>").val($('#<%=gridView.ClientID%> tbody tr:eq(' + (index) + ') td:eq(0)').html().replace(/&nbsp;/gi, ''));
			$("#<%=txbTitle.ClientID%>").val($('#<%=gridView.ClientID%> tbody tr:eq(' + (index) + ') td:eq(1)').html());
			$("#<%=txbDataType.ClientID%>").val($('#<%=gridView.ClientID%> tbody tr:eq(' + (index) + ') td:eq(4)').html());
			$("#<%=txbListType.ClientID%>").val($('#<%=gridView.ClientID%> tbody tr:eq(' + (index) + ') td:eq(5)').html());
			$("#<%=txbOrder.ClientID%>").val($('#<%=gridView.ClientID%> tbody tr:eq(' + (index) + ') td:eq(7)').html());
			var ePosts = $('#<%=gridView.ClientID%> tbody tr:eq(' + (index) + ') td:eq(11)').html() + '';
			var vPosts = $('#<%=gridView.ClientID%> tbody tr:eq(' + (index) + ') td:eq(10)').html() + '';
			$("#<%=hdnPostEditList.ClientID%>").val(ePosts);
			$("#<%=hdnPostViewList.ClientID%>").val(vPosts);
			var ePostsArray = ePosts.replace(/&nbsp;/gi, '').split(",");
			$("#<%=clbPostViewList.ClientID%> :checkbox").each(function () {
				for (var i = 0; i < ePostsArray.length; i++)
					if ($(this).val == ePostsArray[i])
						$(this).attr("checked", "checked");
			});
			var vPostsArray = vPosts.replace(/&nbsp;/gi, '').trim().split(",");
			$("#<%=clbPostViewList.ClientID%> :checkbox").each(function () {
        		for (var i = 0; i < vPostsArray.length; i++)
        			if ($(this).val == vPostsArray[i])
        				$(this).attr("checked", "checked");
        	});
        	$("#jfpcDiv").dialog("open");
			//dlg.parent().appendTo($("form:first"));
		}
		function RowClick(sender, eventArgs) {
			var evt = eventArgs.get_domEvent();

			if (evt.target.tagName == "INPUT" || evt.target.tagName == "A") {
				return;
			}

			var index = eventArgs.get_itemIndexHierarchical();
			$("#<%=hdnCode.ClientID%>").val($('#<%=gridView.ClientID%> tbody tr:eq(' + (index) + ') td:eq(0)').html().replace(/&nbsp;/gi, ''));
			//document.getElementById("radGridClickedRowIndex").value = index;
		};
		//function setDisplay(el,val) {
		//    document.getElementById(el).style.display = val;
		//}
	</script>
</telerik:RadCodeBlock>
<%--<JJson:JJsonButton ID="txtCode" Text="dialog" runat="server" Event="click" />--%>
<telerik:RadButton runat="server" ID="btnInsert" CssClass="insert" Text="درج" AutoPostBack="false" Width="100px" Height="35px" />
<telerik:RadButton runat="server" ID="btnDelete" Text="حذف" AutoPostBack="true" Width="100px" Height="35px" OnClick="btnDelete_Click" />
<telerik:RadGrid runat="server" ID="gridView" PageSize="10" AllowPaging="true">
	<ClientSettings ReorderColumnsOnClient="true" Selecting-AllowRowSelect="true"
		AllowColumnsReorder="true" ColumnsReorderMethod="Reorder" AllowColumnHide="true" AllowRowHide="true" AllowGroupExpandCollapse="true">
		<ClientEvents OnRowDblClick="RowDblClick" OnRowClick="RowClick" />
		<Resizing AllowColumnResize="true" ResizeGridOnColumnResize="true" AllowResizeToFit="true" EnableRealTimeResize="true" ClipCellContentOnResize="true" />
	</ClientSettings>
</telerik:RadGrid>
<br />
<div style="display: none" id="jfpcDiv">
	<%--<uc1:JFormPropertyControl runat="server" ID="JFormPropertyControl" />--%>
	<table>
		<tr>
			<td>
				<div>
					عنوان
                <br />
					<asp:TextBox runat="server" ID="txbTitle" />
					<asp:HiddenField runat="server" ID="hdnCode" />
				</div>
				<div>
					<table>
						<tr>
							<td>نوع فیلد
                            <br />
								<asp:DropDownList runat="server" ID="txbDataType">
								</asp:DropDownList>
							</td>
							<td>نوع مقداردهی
                            <br />
								<asp:DropDownList runat="server" ID="txbListType">
								</asp:DropDownList>
							</td>
							<td>ترتیب
                            <br />
								<asp:TextBox runat="server" ID="txbOrder" />
							</td>
						</tr>
					</table>
				</div>
				<div>
					<table>
						<tr>
							<td>
								<asp:CheckBox Text="مشاهده برای همه" runat="server" ID="chkAllView" Checked="true" />
							</td>
							<td>
								<asp:CheckBox ID="chkAllEdit" Text="ویرایش برای همه" runat="server" Checked="true" />
							</td>
						</tr>
						<tr>
							<td>
								<div style="width: 200px; height: 300px; overflow-y: auto">
									<asp:CheckBoxList runat="server" ID="clbPostViewList" Enabled="false">
									</asp:CheckBoxList>
									<asp:HiddenField runat="server" ID="hdnPostViewList" />
								</div>
							</td>
							<td>
								<div style="width: 200px; height: 300px; overflow-y: auto">
									<asp:CheckBoxList runat="server" ID="clbPostEditList" Enabled="false">
									</asp:CheckBoxList>
									<asp:HiddenField runat="server" ID="hdnPostEditList" />
								</div>
							</td>
						</tr>
					</table>
				</div>
			</td>
			<td>لیست مقادیر
            <br />
				<asp:TextBox runat="server" ID="txbListValue" TextMode="MultiLine" Height="393px" Width="228px" />
			</td>

		</tr>
	</table>
	<telerik:RadButton runat="server" ID="btnSave" Text="ذخیره" AutoPostBack="true" Width="100px" Height="35px" OnClick="btnSave_Click" />
	<telerik:RadButton runat="server" ID="btnPopupClose" Text="بستن" AutoPostBack="false" Width="100px" Height="35px" />
</div>
<telerik:RadButton runat="server" ID="btnOk" Text="تایید" AutoPostBack="true" Width="100px" Height="35px" OnClick="btnOk_Click" />
<telerik:RadButton runat="server" ID="btnClose" Text="بستن" AutoPostBack="true" Width="100px" Height="35px" OnClick="btnClose_Click" />
