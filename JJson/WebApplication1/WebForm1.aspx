<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="WebApplication1.WebForm1" %>

<%@ Register Assembly="JJson" Namespace="JJson" TagPrefix="JJson" %>

<%@ Register Assembly="JJson" Namespace="JJson.Controls" TagPrefix="cc1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<title></title>
	<script src="jquery-1.7.1.js"></script>
	<script src="jquery-ui-1.8.20.js"></script>
	<script src="jquery-ui-1.8.20.min.js"></script>
	<script type="text/javascript">
		//function CheckInteger(ss) {
		//	alert("ok");
		//	return ss;
		//};
		$(document).ready(function () {
			function getRowItemByName(arr, name) {
				for (var i = 0; i < arr.length; i++) {
					var field = arr[i].split(":");
					if (field[0].toLowerCase() == name.toLowerCase())
						return field[1];
				}
			}
			$(".ss").on("input", function () {
				$.ajax({
					type: 'POST',
					url: 'test.asmx/getDT',
					data: '{'
							+ '"code":"' + $(this).val() + '" '
							+ '}',
					contentType: "application/json; charset=utf-8",
					dataType: "json",
					success: function (msg) {
						var res = eval('(' + msg.d + ')'); for (var i = 0; i < res.length; i++) { $(".ddl").append($('<option></option>').val(res[i]["col1"]).html(res[i]["col3"])); }
						//$(msg.d).map(function () {
						//	alert(this.col1 + "\t\t" + this.col3);
						//});
					},
					error: function (msg) {
						//alert("خطا در برقراری ارتباط");
						alert(msg.responseText);
					}
				});
			});
		});
	</script>
</head>
<body>
	<form id="form1" runat="server">
		<div>
			<cc1:JJsonTextBox ID="jjtb" runat="server" Event="textchange"></cc1:JJsonTextBox>
			<asp:TextBox runat="server" ID="test" CssClass="ss" />
			<asp:DropDownList runat="server" ID="ddl" CssClass="ddl">
			</asp:DropDownList>
			<cc1:JJsonDropDownList ID="ddl2" runat="server" Event="change"></cc1:JJsonDropDownList>

			<cc1:JJsonButton ID="jjb" runat="server" Event="click" />


		</div>
	</form>
</body>
</html>
