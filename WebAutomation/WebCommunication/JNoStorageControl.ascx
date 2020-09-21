<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="JNoStorageControl.ascx.cs" Inherits="WebAutomation.WebCommunication.JNoStorageControl" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<script type="text/javascript">
	$(document).ready(function () {
		$('#<%=this.Parent.ClientID%>').attr('owner', '630N');
		getData(0);
		function setTabStatus(tabNum, status) {
			var pv = $find("<%=NoStorageRadMultiPage.ClientID %>").findPageViewByID(tabNum == 0 ? "<%=GetNumberRadTab.ClientID%>" : "<%=ReserveNumberRadTab.ClientID%>");
			pv.set_selected(status);
		}
		function getData(tabNum) {
			$.ajax({
				type: 'POST',
				url: 'Services/WebAutomationService.asmx/GetData',
				data: '{'
						+ '"className":"' + '<%= Request["ClassName"]!=null?Request["ClassName"].ToString():null%>' + '"'
						+ ',"objectCode":"' + '<%= Request["ObjectCode"]!=null?Request["ObjectCode"].ToString():null%>' + '"'
						+ '}',
				contentType: "application/json; charset=utf-8",
				dataType: "json",
				success: function (msg) {
					var xmlDoc = $.parseXML(msg.d);
					var xml = $(xmlDoc);
					var dt = xml.find("datatable");
					var listItems = [];
					$.each(dt, function () {
						listItems.push('<option value="' +
						$(this).find("Code").text() + '">' + $(this).find("Number").text()
						+ '</option>');
					});
					$('#<%= ReserveListListBox.ClientID%>').empty();
					$('#<%= ReservedListListBox.ClientID%>').empty();
					$('#<%= ReserveListListBox.ClientID%>').append(listItems.join(''));
					$('#<%= ReservedListListBox.ClientID%>').append(listItems.join(''));
					setTabStatus(tabNum, true);
				},
			    error: function (xhr, status, error) {
			        var err = eval("(" + xhr.responseText + ")");
			        alert(err.Message);
				}
			});
		}

		setInterval(function () {
			$.ajax({
				type: 'POST',
				url: 'Services/WebAutomationService.asmx/GetLastNumberText',
				data: '{'
						+ '"className":"' + '<%= Request["ClassName"]!=null?Request["ClassName"].ToString():null%>' + '"'
						+ ',"objectCode":"' + '<%= Request["ObjectCode"]!=null?Request["ObjectCode"].ToString():null%>' + '"'
						+ '}',
				contentType: "application/json; charset=utf-8",
				dataType: "json",
				success: function (msg) {
					$('#<%= LastNumberLabel.ClientID%>').html(msg.d);
				},
			    error: function (xhr, status, error) {
			        var err = eval("(" + xhr.responseText + ")");
			        alert(err.Message);
				}
			});
		}, 1000);
		setInterval(function () {
			$.ajax({
				type: 'POST',
				url: 'Services/WebAutomationService.asmx/GetReservedNumbersText',
				data: '{'
						+ '"className":"' + '<%= Request["ClassName"]!=null?Request["ClassName"].ToString():null%>' + '"'
						+ ',"objectCode":"' + '<%= Request["ObjectCode"]!=null?Request["ObjectCode"].ToString():null%>' + '"'
						+ ',"reserveNumber":"' + $('#<%= ReserveTextBox.ClientID%>').val() + '"'
						+ '}',
				contentType: "application/json; charset=utf-8",
				dataType: "json",
				success: function (msg) {
					$('#<%= ReservedNumbersLabel.ClientID%>').html(msg.d);
				},
			    error: function (xhr, status, error) {
			        var err = eval("(" + xhr.responseText + ")");
			        alert(err.Message);
				}
			});
		}, 1000);
		<%--$('#<%= OkButton.ClientID%>').click(function () {
			
		});--%>
		$('#<%= GetNumberButton.ClientID%>').unbind('click').click(function () {
			if ($('#<%= NumberTextBox.ClientID%>').val() != "")
				return false;
			$.ajax({
				type: 'POST',
				url: 'Services/WebAutomationService.asmx/GetNumber',
				data: '{'
						+ '"className":"' + '<%= Request["ClassName"]!=null?Request["ClassName"].ToString():null%>' + '"'
						+ ',"objectCode":"' + '<%= Request["ObjectCode"]!=null?Request["ObjectCode"].ToString():null%>' + '"'
						+ '}',
				contentType: "application/json; charset=utf-8",
				dataType: "json",
				success: function (msg) {
					$('#<%= NumberTextBox.ClientID%>').val(msg.d);
					$('#<%=this.Parent.ClientID%>').val(msg.d);
					getData(0);
				},
			    error: function (xhr, status, error) {
			        var err = eval("(" + xhr.responseText + ")");
			        alert(err.Message);
				}
			});
			return false;
		});

		$('#<%= ReserveButton.ClientID%>').click(function () {
			$.ajax({
				type: 'POST',
				url: 'Services/WebAutomationService.asmx/Reserve',
				data: '{'
						+ '"className":"' + '<%= Request["ClassName"]!=null?Request["ClassName"].ToString():null%>' + '"'
						+ ',"objectCode":"' + '<%= Request["ObjectCode"]!=null?Request["ObjectCode"].ToString():null%>' + '"'
						+ ',"reserveNumber":"' + $('#<%= ReserveTextBox.ClientID%>').val() + '"'
						+ '}',
				contentType: "application/json; charset=utf-8",
				dataType: "json",
				success: function (msg) {
					getData(1);
				},
				error: function (xhr, status, error) {
				    var err = eval("(" + xhr.responseText + ")");
				    alert(err.Message);
				}
			});
			return false;
		});

		$('#<%= DeleteReserveButton.ClientID%>').click(function () {
			$.ajax({
				type: 'POST',
				url: 'Services/WebAutomationService.asmx/DeleteReservedNumber',
				data: '{'
						+ '"className":"' + '<%= Request["ClassName"]!=null?Request["ClassName"].ToString():null%>' + '"'
						+ ',"objectCode":"' + '<%= Request["ObjectCode"]!=null?Request["ObjectCode"].ToString():null%>' + '"'
						+ ',"number":"' + $('#<%= ReserveListListBox.ClientID%>').find('option:selected').text() + '"'
						+ '}',
				contentType: "application/json; charset=utf-8",
				dataType: "json",
				success: function (msg) {
					getData(1);
				},
				error: function (xhr, status, error) {
				    var err = eval("(" + xhr.responseText + ")");
				    alert(err.Message);
				}
			});
			return false;
		});

		$('#<%= ReservedListListBox.ClientID%>').on('change', function () {
			$('#<%= NumberTextBox.ClientID%>').val($(this).find('option:selected').text());
			$('#<%=this.Parent.ClientID%>').val($(this).find('option:selected').text());
		});
	});
</script>
<asp:HiddenField runat="server" ID="ClassNameHiddenField" />
<asp:HiddenField runat="server" ID="ObjectCodeHiddenField" />
<asp:HiddenField runat="server" ID="SecretariatCodeHiddenField" />
<asp:HiddenField runat="server" ID="SelectedValue" />
<div class="FormContent">
	<div class="BigTitle">مدیریت اندیکاتور</div>
	<table dir="rtl">
		<tr>
			<td>

				<telerik:RadTabStrip runat="server" ID="NoStorageRadTabStrip" MultiPageID="NoStorageRadMultiPage" Width="500px">
					<Tabs>
						<telerik:RadTab Text="دریافت شماره" Value="GetNumber" PageViewID="GetNumberRadTab" Selected="true">
						</telerik:RadTab>
						<telerik:RadTab Text="رزرو شماره" Value="ReserveNumber" PageViewID="ReserveNumberRadTab">
						</telerik:RadTab>
					</Tabs>
				</telerik:RadTabStrip>
				<telerik:RadMultiPage runat="server" ID="NoStorageRadMultiPage">
					<telerik:RadPageView runat="server" ID="GetNumberRadTab">
						<table>
							<tr>
								<td class="Table_RowB" style="vertical-align: top">
									<table>
										<tr>
											<td class="Table_RowC">
												<asp:TextBox runat="server" ID="NumberTextBox" Enabled="false" />
											</td>
										</tr>
										<tr>
											<td class="Table_RowC">
												<asp:Button Text="دریافت شماره" ID="GetNumberButton" runat="server" />
											</td>
										</tr>
										<tr>
											<td class="Table_RowC">
												<asp:Label Text="آخرین شماره()" ForeColor="Red" ID="LastNumberLabel" runat="server" />
											</td>
										</tr>
									</table>
								</td>
								<td class="Table_RowC" style="height: 250px; width: 50%">
									<asp:ListBox runat="server" ID="ReservedListListBox" Width="100%" Height="100%"></asp:ListBox>
								</td>
							</tr>
						</table>
					</telerik:RadPageView>
					<telerik:RadPageView runat="server" ID="ReserveNumberRadTab">
						<table>
							<tr>
								<td class="Table_RowC" style="height: 250px; width: 50%">
									<asp:ListBox runat="server" ID="ReserveListListBox" Width="100%" Height="100%"></asp:ListBox>
								</td>
								<td class="Table_RowB" style="vertical-align: top">
									<table>
										<tr>
											<td class="Table_RowC">
												<asp:Label Text="از شماره ... تا شماره:" ID="ReservedNumbersLabel" runat="server" />
											</td>
										</tr>
										<tr>
											<td class="Table_RowC">
												<asp:TextBox runat="server" ID="ReserveTextBox" Enabled="true" />
											</td>
										</tr>
										<tr>
											<td class="Table_RowC">
												<asp:Button Text="رزرو شماره--->" ID="ReserveButton" runat="server" />
											</td>
										</tr>
										<tr>
											<td class="Table_RowC">
												<asp:Button Text="حذف شماره رزرو شده" ID="DeleteReserveButton" runat="server" />
											</td>
										</tr>
									</table>
								</td>
							</tr>
						</table>
					</telerik:RadPageView>
				</telerik:RadMultiPage>

			</td>
		</tr>
	</table>
</div>

<%--<div class="FormButtons">
	<telerik:RadButton runat="server" ID="OkButton" Text="تایید" AutoPostBack="false" Width="100px" Height="35px" ValidationGroup="Line" />
	<telerik:RadButton runat="server" ID="CloseButton" Text="بازگشت" OnClientClicked="CloseDialog" AutoPostBack="false" Width="100px" Height="35px" />
</div>--%>
