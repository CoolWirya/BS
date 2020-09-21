<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="JEmailControl.ascx.cs" Inherits="WebAutomation.WebCommunication.JEmailControl" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register Src="~/WebControllers/MainControls/Persons/JSearchPersonControl.ascx" TagPrefix="uc2" TagName="JSearchPersonControl" %>
<%@ Register Src="~/WebAutomation/Refer/JReferViewControl.ascx" TagPrefix="uc1" TagName="JReferViewControl" %>
<%@ Register Src="~/WebControllers/ArchiveDocument/JArchiveControl.ascx" TagPrefix="uc1" TagName="JArchiveControl" %>

<script type="text/javascript">
	$(document).ready(function () {
		var isExisted = false;
		function isalreadyExist(email) {
			isExisted = false;
			var vals = $('#<%=EmailReceivers.ClientID%> tr').not($('#<%=EmailReceivers.ClientID%> tr:first-child'));
			$(vals).each(function () {
				if ($(this).children('td:eq(0)').html() == email) {
					isExisted = true;
				}
			});
		};
		$('#<%=OkButton.ClientID%>').click(function () {
			var code = 0;
			$.ajax({
				type: 'POST',
				url: 'WebAutomation/Services/JService.asmx/SaveEmail',
				data: '{'
						+ '"code":"' + $('#<%= EmailCodeHiddenField.ClientID%>').val() + '"'
						+ ',"text":"' + $telerik.findEditor('#<%= EmailTextEditor.ClientID%>').get_html(true) + '"'
						+ ',"parentCode":"' + $('#<%= ParentCodeHiddenField.ClientID%>').val() + '"'
						+ ',"senderCode":"' + $('#<%= ParentCodeHiddenField.ClientID%>').val() + '"'
						+ ',"subject":"' + $('#<%= SubjectTextBox.ClientID%>').val() + '"'
						+ ',"recievers":"' + $('#<%= rcvsHiddenField.ClientID%>').val() + '"'
						+ '}',
				contentType: "application/json; charset=utf-8",
				dataType: "json",
				success: function (msg) {
					code = Number(msg.d);
				},
				error: function (err) {
					alert("خطا در اجرا");
				}
			});
			$('#<%= EmailCodeHiddenField.ClientID%>').val(code);
			return code > 0;
		});
		function getDataForPerson(personCode) {
			$.ajax({
				type: 'POST',
				url: 'WebAutomation/Services/JService.asmx/FillEmailListWithPerson',
				data: '{'
						+ '"personCode":"' + personCode + '"'
						+ '}',
				contentType: "application/json; charset=utf-8",
				dataType: "json",
				success: function (msg) {
					addReciever(msg.d);
				},
				error: function (err) {
					alert("خطا در اجرا");
				}
			});
		};
		$('#<%=EmailReceivers.ClientID%> tr').css({ "background-color": "White", "color": "Black" });
		$('#<%=EmailReceivers.ClientID%> tr').mouseover(function () {
			$(this).css({ cursor: "hand", cursor: "pointer" });
		});
		$('#<%=EmailReceivers.ClientID%> tr').mouseout(function () {
			$(this).css({ cursor: "hand", cursor: "pointer" });
		});
		$('#<%=EmailReceivers.ClientID%> tr').click(function () {
			$('#<%=EmailReceivers.ClientID%> tr').each(function () {
				$(this).css({ "background-color": "White", "color": "Black" });
			});
			$(this).css({ "background-color": "Black", "color": "White" });
			$('#<%=SelectedReceiverHiddenField.ClientID%>').val($(this).children('td:eq(0)').html());
		});
		function addReciever(email) {
			isalreadyExist(email);
			if (!isExisted) {
				var row = $('#<%=EmailReceivers.ClientID%> tr:last-child').clone(true);
				if ($("td", row).eq(0).html().replace(/&nbsp;/g, '') == '')
					$('#<%= EmailReceivers.ClientID%> tr:last-child').remove();
				$("td", row).eq(0).html(email);
				$('#<%=EmailReceivers.ClientID%>').append(row);
				row = $('#<%=EmailReceivers.ClientID%> tr:last-child').clone(true);
				$('#<%= rcvsHiddenField.ClientID%>').val($('#<%= rcvsHiddenField.ClientID%>').val() + ";" + email);
			}
			else
				alert("این آدرس قبلا درج شده است");
		}
		function getDataForUnknownPerson(email) {
			addReciever(email);
		};
		$("#ListDiv").dialog({
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
			width: 400,
			height: 300
		});
		$("#ListDiv").parent().appendTo($("form:first"));
		$("#<%= ListButton.ClientID%>").click(function (event) {
		});
		$("#<%= ListCloseButton.ClientID %>").click(function (event) {
			$("#ListDiv").dialog("close");
		});
		$("#<%= ListSelectButton.ClientID %>").click(function (event) {
			$("#ListDiv").dialog("close");
		});
		$("#OtherDiv").dialog({
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
			width: 400,
			height: 300
		});
		$("#OtherDiv").parent().appendTo($("form:first"));
		$("#<%= OtherButton.ClientID%>").click(function (event) {
			$("#OtherDiv").dialog("open");
		});
		$("#<%= OtherCloseButton.ClientID %>").click(function (event) {
			$("#OtherDiv").dialog("close");
		});
		$("#<%= OtherSelectButton.ClientID %>").click(function (event) {
			$("#OtherDiv").dialog("close");
			getDataForUnknownPerson($('#<%= UnknownPersonTextBox.ClientID%>').val());
		});

		$("#<%= DeleteButton.ClientID %>").click(function (event) {
			var rcv = $('#<%= SelectedReceiverHiddenField.ClientID%>').val();
			var row = $('#<%=EmailReceivers.ClientID%> tr').filter(function () {
				return $(this).children('td:eq(0)').html() == rcv;
			});
			row.remove();
			$('#<%= rcvsHiddenField.ClientID%>').val($('#<%= rcvsHiddenField.ClientID%>').val().replace(rcv + '', ''));
		});
	});
</script>
<div class="FormContent">
	<div class="BigTitle">فرم Email</div>
	<asp:HiddenField runat="server" ID="EmailCodeHiddenField" />
	<asp:HiddenField runat="server" ID="ParentCodeHiddenField" />
	<asp:HiddenField runat="server" ID="SelectedPersonHiddenField" />
	<asp:HiddenField runat="server" ID="SelectedReceiverHiddenField" />
	<asp:HiddenField runat="server" ID="rcvsHiddenField" />
	<telerik:RadTabStrip runat="server" ID="rtabLetter" SelectedIndex="2" MultiPageID="rpageLetter" Width="500px">
		<Tabs>
			<telerik:RadTab Text="اطلاعات Email" Value="Info" PageViewID="rpvEmailInfo" Selected="True">
			</telerik:RadTab>
			<telerik:RadTab Text="ضمائم" PageViewID="rpvArchive">
			</telerik:RadTab>
			<telerik:RadTab Text="ارجاعات" Value="Refer" PageViewID="rpvRefer">
			</telerik:RadTab>
		</Tabs>
	</telerik:RadTabStrip>
	<telerik:RadMultiPage runat="server" ID="rpageLetter" SelectedIndex="0">
		<telerik:RadPageView runat="server" ID="rpvEmailInfo">
			<table>
				<tr>
					<td class="Table_RowB" style="vertical-align: top">
						<table>
							<tr>
								<td>
									<telerik:RadButton runat="server" ID="ListButton" Text="لیست" AutoPostBack="false" Width="100px" Height="35px" />
									<telerik:RadButton runat="server" ID="OtherButton" Text="دستی" AutoPostBack="false" Width="100px" Height="35px" />
									<telerik:RadButton runat="server" ID="DeleteButton" Text="حذف" AutoPostBack="false" Width="100px" Height="35px" />
								</td>
							</tr>
							<tr>
								<td>
									<asp:DropDownList runat="server" ID="SendersDropDownList">
									</asp:DropDownList>

									<%--<asp:ListBox runat="server" ID="EmailReceivers" Height="293px" Width="304px">
											<asp:ListItem Text="item0" Value="item0" />
										</asp:ListBox>--%>
									<%--<telerik:RadListBox runat="server" ID="EmailReceivers" Height="293px" Width="304px"></telerik:RadListBox>--%>
									<%--<table id="EmailReceivers" style="background-color: white; width: 300px; height: 300px; vertical-align: top">
											
									</table>--%>
									<%--<div style="height: 300px; overflow-y: auto; background-color: white; width: 300px; vertical-align: top" id="EmailReceivers" runat="server" class="EmailReceivers">
											<ul>

										</ul>
									</div>--%>
									<div style="height: 300px; overflow-y: auto">
										<asp:GridView runat="server" ID="EmailReceivers" AutoGenerateColumns="False">
											<Columns>
												<asp:TemplateField HeaderText="گیرندگان" HeaderStyle-Width="200px">
													<ItemTemplate>
														<asp:Label Text="" runat="server" />
													</ItemTemplate>
												</asp:TemplateField>
											</Columns>
										</asp:GridView>
									</div>
									<asp:TextBox runat="server" ID="SubjectTextBox" />
								</td>
							</tr>
						</table>
					</td>
				</tr>
				<tr>
					<td>
						<telerik:RadEditor runat="server" EditModes="All" ID="EmailTextEditor" ToolTip="تایپ نامه"></telerik:RadEditor>
					</td>
				</tr>
				<tr>
					<td>
						<asp:Label Text="status" runat="server" ID="StatusLabel" />
					</td>
				</tr>
			</table>
		</telerik:RadPageView>
		<telerik:RadPageView runat="server" ID="rpvArchive">
			<uc1:JArchiveControl runat="server" id="JArchiveControl" />
		</telerik:RadPageView>
		<telerik:RadPageView runat="server" ID="rpvRefer">
			<uc1:jreferviewcontrol runat="server" id="JReferViewControl" />
		</telerik:RadPageView>
	</telerik:RadMultiPage>
</div>
<div class="FormButtons">
	<telerik:RadButton runat="server" ID="OkButton" Text="تایید" AutoPostBack="false" Width="100px" Height="35px" ValidationGroup="Line" OnClick="OkButton_Click" />
	<telerik:RadButton runat="server" ID="ReferButton" Text="ارجاع" AutoPostBack="true" Width="100px" Height="35px" ValidationGroup="Line" OnClick="ReferButton_Click" />
	<telerik:RadButton runat="server" ID="CloseButton" Text="بازگشت" OnClientClicked="CloseDialog" AutoPostBack="false" Width="100px" Height="35px" />
</div>
<div style="display: none" id="ListDiv">
	<%--<uc1:JSearchPersonControl runat="server" id="jSearchPersonControl1" />--%>
	<div runat="server" id="InnerDiv"></div>
	<br />
	<telerik:RadButton runat="server" ID="ListSelectButton" Text="انتخاب" AutoPostBack="false" Width="100px" Height="35px" ValidationGroup="Line" />
	<telerik:RadButton runat="server" ID="ListCloseButton" Text="بستن" AutoPostBack="false" Width="100px" Height="35px" />
</div>
<div style="display: none" id="OtherDiv">
	<asp:TextBox ID="UnknownPersonTextBox" runat="server" />
	<br />
	<telerik:RadButton runat="server" ID="OtherSelectButton" Text="ثبت" AutoPostBack="false" Width="100px" Height="35px" ValidationGroup="Line" />
	<telerik:RadButton runat="server" ID="OtherCloseButton" Text="بستن" AutoPostBack="false" Width="100px" Height="35px" />
</div>
