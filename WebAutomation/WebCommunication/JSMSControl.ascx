<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="JSMSControl.ascx.cs" Inherits="WebAutomation.WebCommunication.JSMSControl" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register Src="~/WebControllers/MainControls/Persons/JSearchPersonControl.ascx" TagPrefix="uc2" TagName="JSearchPersonControl" %>
<%@ Register Src="~/WebAutomation/Refer/JReferViewControl.ascx" TagPrefix="uc1" TagName="JReferViewControl" %>

<%--<script src="/Scripts/SMSGroupSection.js"></script>--%>
<script type="text/javascript">
	$(document).ready(function () {
		function updateInformation() {
			var c = $("#<%= SMSTextTextBox.ClientID%>");
			var s = c.val();
			$("#<%= CharCountLabel.ClientID%>").html(s.length);
			$("#<%= SMSCountLabel.ClientID%>").html(s.length <= 70 ? 1 : Math.ceil(s.length / 67));
			$("#<%= ReceiversSMSCountLabel.ClientID%>").html(Number($("#<%= SMSCountLabel.ClientID%>").html()) * Number($('#<%=ReceiversGridView.ClientID%> tr').length) - 1);
			$("#<%= PostSpaceLabel.ClientID%>").html(s.length - s.replace(/\s*$/, "").length);
			$("#<%= PreSpaceLabel.ClientID%>").html(s.length - s.replace(/^\s*/, "").length);
		};
		//function fillGrid(res, gridId, fields) {
		//	var xmlDoc = $.parseXML(res);
		//	var xml = $(xmlDoc);
		//	var dt = xml.find("datatable");
		//	var row = $('#' + gridId + ' tr:last-child').clone(true);
		//	//alert(row);
		//	//alert(gridId);
		//	//alert($("td", row).eq(0).html());
		//	if ($("td", row).eq(0).html().replace(/&nbsp;/g, '') == '')
		//		$('#' + gridId + ' tr:last-child').remove();
		//	//$('#' + gridId + ' tr').not($('#' + gridId + ' tr:first-child')).remove();
		//	$.each(dt, function () {
		//		for (var i = 0; i < fields.length; i++) {
		//			//alert(fields[i]);
		//			//alert($(this).find(fields[i]).text());
		//			$("td", row).eq(i).html($(this).find(fields[i]).text());
		//		}
		//		//$("td", row).eq(1).html($(this).find("PersonCode").text());
		//		//$("td", row).eq(2).html($(this).find("PersonName").text());
		//		//$("td", row).eq(3).html($(this).find("Mobile").text());
		//		//$("td", row).eq(4).html($(this).find("Status").text());
		//		$('#' + gridId).append(row);
		//		row = $('#' + gridId + ' tr:last-child').clone(true);
		//	});
		//};

		//Request["Code"]!=null?Request["Code"].ToString():null
		function getDataForGroup(groupCode) {
			$.ajax({
				type: 'POST',
				url: 'WebAutomation/Services/JService.asmx/FillSMSGridWithGroup',
				data: '{'
						+ '"code":"' + $('#<%=SMSCodeHiddenField.ClientID %>').val() + '"'
						+ ',"text":"' + $('#<%= SMSTextTextBox.ClientID%>').val() + '"'
						+ ',"groupCode":"' + groupCode + '"'
						+ '}',
				contentType: "application/json; charset=utf-8",
				dataType: "json",
				success: function (msg) {
					//var i = 0;
					$('#<%=SMSCodeHiddenField.ClientID %>').val(msg.d.split('?!?')[0]);
					fillGrid(msg.d.split('?!?')[1], '<%=ReceiversGridView.ClientID%>', new Array('Code', 'PersonCode', 'PersonName', 'Mobile', 'Status'));
					updateInformation();
				},
				error: function (err) {
					alert("خطا در اجرا");
				}
			});
			};
		function getDataForPerson(personCode) {
			$.ajax({
				type: 'POST',
				url: 'WebAutomation/Services/JService.asmx/FillSMSGridWithPerson',
				data: '{'
						+ '"code":"' + '<%= Request["Code"]!=null?Request["Code"].ToString():null%>' + '"'
						+ ',"text":"' + $('#<%= SMSTextTextBox.ClientID%>').val() + '"'
						+ ',"personCode":"' + personCode + '"'
						+ '}',
				contentType: "application/json; charset=utf-8",
				dataType: "json",
				success: function (msg) {
					//var i = 0;
					$('#<%=SMSCodeHiddenField.ClientID %>').val(msg.d.split('?!?')[0]);
					fillGrid(msg.d.split('?!?')[1], '<%=ReceiversGridView.ClientID%>', new Array('Code', 'PersonCode', 'PersonName', 'Mobile', 'Status'));
					updateInformation();
				},
				error: function (err) {
					alert("خطا در اجرا");
				}
			});
			};
		function getDataForUnknownPerson(mobile) {
			$.ajax({
				type: 'POST',
				url: 'WebAutomation/Services/JService.asmx/AddUnknownPerson',
				data: '{'
						+ '"code":"' + '<%= Request["Code"]!=null?Request["Code"].ToString():null%>' + '"'
						+ ',"text":"' + $('#<%= SMSTextTextBox.ClientID%>').val() + '"'
						+ ',"mobile":"' + mobile + '"'
						+ '}',
				contentType: "application/json; charset=utf-8",
				dataType: "json",
				success: function (msg) {
					//var i = 0;
					$('#<%=SMSCodeHiddenField.ClientID %>').val(msg.d.split('?!?')[0]);
					fillGrid(msg.d.split('?!?')[1], '<%=ReceiversGridView.ClientID%>', new Array('Code', 'PersonCode', 'PersonName', 'Mobile', 'Status'));
					updateInformation();
				},
				error: function (err) {
					alert("خطا در اجرا");
				}
			});
			};
		$('#<%=GroupGridView.ClientID%> tr').css({ "background-color": "White", "color": "Black" });
		$('#<%=GroupGridView.ClientID%> tr').mouseover(function () {
			$(this).css({ cursor: "hand", cursor: "pointer" });
		});
		$('#<%=GroupGridView.ClientID%> tr').mouseout(function () {
			$(this).css({ cursor: "hand", cursor: "pointer" });
		});
		$('#<%=GroupGridView.ClientID%> tr').click(function () {
			$('#<%=GroupGridView.ClientID%> tr').each(function () {
				$(this).css({ "background-color": "White", "color": "Black" });
			});
			$(this).css({ "background-color": "Black", "color": "White" });
			$('#<%=SelectedGroupHiddenField.ClientID%>').val($(this).children('td:eq(0)').html());
		});
		$('#<%=GroupGridView.ClientID%> tr').dblclick(function () {
			$('#<%=GroupGridView.ClientID%> tr').each(function () {
				$(this).css({ "background-color": "White", "color": "Black" });
			});
			$('#<%=SelectedGroupHiddenField.ClientID%>').val($(this).children('td:eq(0)').html());
			$("#GroupDiv").dialog("close");
			getDataForGroup($(this).children('td:eq(0)').html());
		});
		$("#GroupDiv").dialog({
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
		$("#GroupDiv").parent().appendTo($("form:first"));
		$("#<%= GroupButton.ClientID%>").click(function (event) {
			$("#GroupDiv").dialog("open");
		});
		$("#<%= GroupCloseButton.ClientID %>").click(function (event) {
			$("#GroupDiv").dialog("close");
		});
		$("#<%= GroupSelectButton.ClientID %>").click(function (event) {
			$("#GroupDiv").dialog("close");
			getDataForGroup($('#<%=SelectedGroupHiddenField.ClientID%>').val());
		});
		$('#<%=ReceiversGridView.ClientID%> tr').css({ "background-color": "White", "color": "Black" });
		$('#<%=ReceiversGridView.ClientID%> tr').mouseover(function () {
			$(this).css({ cursor: "hand", cursor: "pointer" });
		});
		$('#<%=ReceiversGridView.ClientID%> tr').mouseout(function () {
			$(this).css({ cursor: "hand", cursor: "pointer" });
		});
		$('#<%=ReceiversGridView.ClientID%> tr').click(function () {
			$('#<%=ReceiversGridView.ClientID%> tr').each(function () {
				$(this).css({ "background-color": "White", "color": "Black" });
			});
			$(this).css({ "background-color": "Black", "color": "White" });
			$('#<%=SelectedReceiverHiddenField.ClientID%>').val($(this).children('td:eq(0)').html());
		});
		$("#PersonDiv").dialog({
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
		$("#PersonDiv").parent().appendTo($("form:first"));
		$("#<%= PersonButton.ClientID%>").click(function (event) {
		});
		$("#<%= PersonCloseButton.ClientID %>").click(function (event) {
			$("#PersonDiv").dialog("close");
		});
		$("#<%= PersonSelectButton.ClientID %>").click(function (event) {
			$("#PersonDiv").dialog("close");
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
			getDataForUnknownPerson($('#<%= UnknownPersonMobileTextBox.ClientID%>').val());
		});

		$("#SentSMSDiv").dialog({
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
		$("#SentSMSDiv").parent().appendTo($("form:first"));
		$("#<%= SentSMSButton.ClientID%>").click(function (event) {
			$("#SentSMSDiv").dialog("open");
		});
		$("#<%= SentSMSCloseButton.ClientID %>").click(function (event) {
			$("#SentSMSDiv").dialog("close");
		});
		$("#<%= SMSTextTextBox.ClientID%>").on("input", function () {
			updateInformation();
		});
		$("#<%= DeleteButton.ClientID %>").click(function (event) {
			var receiverCode = $('#<%= SelectedReceiverHiddenField.ClientID%>').val();
			$.ajax({
				type: 'POST',
				url: 'WebAutomation/Services/JService.asmx/RemoveReceiver',
				data: '{'
						+ '"code":"' + receiverCode + '"'
						+ '}',
				contentType: "application/json; charset=utf-8",
				dataType: "json",
				success: function (msg) {
					var row = $('#<%=ReceiversGridView.ClientID%> tr').filter(function () {
						return $(this).children('td:eq(0)').html() == receiverCode;
					});
					row.remove();
					updateInformation();
				},
				error: function (err) {
					alert("خطا در اجرا");
				}
			});
		});
	});
</script>
<div class="FormContent">
	<div class="BigTitle">فرم SMS</div>
	<asp:HiddenField runat="server" ID="SMSCodeHiddenField" />
	<asp:HiddenField runat="server" ID="SelectedGroupHiddenField" />
	<asp:HiddenField runat="server" ID="SelectedReceiverHiddenField" />
	<telerik:RadTabStrip runat="server" ID="rtabLetter" SelectedIndex="2" OnTabClick="rtabLetter_TabClick" MultiPageID="rpageLetter" Width="500px">
		<Tabs>
			<telerik:RadTab Text="اطلاعات SMS" Value="Info" PageViewID="rpvSMSInfo" Selected="True">
			</telerik:RadTab>
			<telerik:RadTab Text="ارجاعات" Value="Refer" PageViewID="rpvRefer">
			</telerik:RadTab>
		</Tabs>
	</telerik:RadTabStrip>
	<telerik:RadMultiPage runat="server" ID="rpageLetter" SelectedIndex="0">
		<telerik:RadPageView runat="server" ID="rpvSMSInfo">
			<table>
				<tr>
					<td class="Table_RowB" style="vertical-align: top">
						<table>
							<tr>
								<td>
									<telerik:RadButton runat="server" ID="GroupButton" Text="گروه" AutoPostBack="false" Width="100px" Height="35px" />
									<telerik:RadButton runat="server" ID="PersonButton" Text="شخص" AutoPostBack="false" Width="100px" Height="35px" />
									<telerik:RadButton runat="server" ID="OtherButton" Text="ناشناس" AutoPostBack="false" Width="100px" Height="35px" />
									<telerik:RadButton runat="server" ID="SentSMSButton" Text="SMS های گذشته" AutoPostBack="false" Width="100px" Height="35px" />
									<telerik:RadButton runat="server" ID="DeleteButton" Text="حذف" AutoPostBack="false" Width="100px" Height="35px" />
								</td>
							</tr>
							<tr>
								<td>
									<div style="height: 300px; overflow-y: auto">
										<asp:GridView runat="server" ID="ReceiversGridView" AutoGenerateColumns="False">
											<Columns>
												<asp:BoundField DataField="code" HeaderText="کد" HeaderStyle-HorizontalAlign="Center">
													<ItemStyle HorizontalAlign="Center" Width="100px" />
												</asp:BoundField>
												<asp:BoundField DataField="personcode" HeaderText="کد شخص" HeaderStyle-HorizontalAlign="Center">
													<ItemStyle HorizontalAlign="Center" Width="100px" />
												</asp:BoundField>
												<asp:BoundField DataField="personname" HeaderText="نام شخص" HeaderStyle-HorizontalAlign="Center">
													<ItemStyle HorizontalAlign="Center" Width="150px" />
												</asp:BoundField>
												<asp:BoundField DataField="mobile" HeaderText="موبایل" HeaderStyle-HorizontalAlign="Center">
													<ItemStyle HorizontalAlign="Center" Width="100px" />
												</asp:BoundField>
												<asp:BoundField DataField="status" HeaderText="وضعیت" HeaderStyle-HorizontalAlign="Center">
													<ItemStyle HorizontalAlign="Center" Width="100px" />
												</asp:BoundField>
											</Columns>
										</asp:GridView>
									</div>
								</td>
							</tr>
						</table>
					</td>
					<td class="Table_RowC">
						<asp:TextBox runat="server" ID="SMSTextTextBox" TextMode="MultiLine" Height="251px" Width="388px" />
						<table>
							<tr>
								<td>تعداد کاراکتر:</td>
								<td>
									<asp:Label Text="0" ID="CharCountLabel" runat="server" />
								</td>
								<td></td>
							</tr>
							<tr>
								<td>تعداد SMS ها:</td>
								<td>
									<asp:Label Text="1" ID="SMSCountLabel" runat="server" />
								</td>
								<td>عدد</td>
							</tr>
							<tr>
								<td>تعداد SMS ها در گیرندگان:</td>
								<td>
									<asp:Label Text="0" ID="ReceiversSMSCountLabel" runat="server" />
								</td>
								<td>عدد</td>
							</tr>
							<tr>
								<td>تعداد فاصله ها قبل از متن:</td>
								<td>
									<asp:Label Text="0" ID="PreSpaceLabel" runat="server" />
								</td>
								<td>عدد</td>
							</tr>
							<tr>
								<td>تعداد فاصله ها بعد از متن:</td>
								<td>
									<asp:Label Text="0" ID="PostSpaceLabel" runat="server" />
								</td>
								<td>عدد</td>
							</tr>
							<tr>
								<td>تعداد SMS های ارسال شده امروز:</td>
								<td>
									<asp:Label Text="0" ID="TodaySentCountLabel" runat="server" />
								</td>
								<td>عدد</td>
							</tr>
							<tr>
								<td>تعداد SMS های ارسال شده این ماه:</td>
								<td>
									<asp:Label Text="0" ID="ThisMonthSentCountLabel" runat="server" />
								</td>
								<td>عدد</td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
			<asp:GridView runat="server" ID="RefersTextGridView"></asp:GridView>
		</telerik:RadPageView>
		<telerik:RadPageView runat="server" ID="rpvRefer">
			<uc1:jreferviewcontrol runat="server" id="JReferViewControl" />
		</telerik:RadPageView>
	</telerik:RadMultiPage>
</div>
<div class="FormButtons">
	<telerik:RadButton runat="server" ID="OkButton" Text="تایید" AutoPostBack="false" Width="100px" Height="35px" ValidationGroup="Line" />
	<telerik:RadButton runat="server" ID="ReferButton" Text="ارجاع" AutoPostBack="true" Width="100px" Height="35px" ValidationGroup="Line" OnClick="ReferButton_Click" />
	<telerik:RadButton runat="server" ID="CloseButton" Text="بازگشت" OnClientClicked="CloseDialog" AutoPostBack="false" Width="100px" Height="35px" />
</div>
<div style="display: none" id="GroupDiv">
	<div style="overflow-y: auto; height: 200px">
		<asp:GridView runat="server" ID="GroupGridView"></asp:GridView>
	</div>
	<telerik:RadButton runat="server" ID="GroupSelectButton" Text="انتخاب" AutoPostBack="false" Width="100px" Height="35px" ValidationGroup="Line" />
	<telerik:RadButton runat="server" ID="GroupCloseButton" Text="بستن" AutoPostBack="false" Width="100px" Height="35px" />
</div>
<div style="display: none" id="PersonDiv">
	<%--<uc1:JSearchPersonControl runat="server" id="jSearchPersonControl1" />--%>
	<div runat="server" id="InnerDiv"></div>
	<br />
	<telerik:RadButton runat="server" ID="PersonSelectButton" Text="انتخاب" AutoPostBack="false" Width="100px" Height="35px" ValidationGroup="Line" />
	<telerik:RadButton runat="server" ID="PersonCloseButton" Text="بستن" AutoPostBack="false" Width="100px" Height="35px" />
</div>
<div style="display: none" id="OtherDiv">
	<asp:TextBox ID="UnknownPersonMobileTextBox" runat="server" />
	<br />
	<telerik:RadButton runat="server" ID="OtherSelectButton" Text="ثبت" AutoPostBack="false" Width="100px" Height="35px" ValidationGroup="Line" />
	<telerik:RadButton runat="server" ID="OtherCloseButton" Text="بستن" AutoPostBack="false" Width="100px" Height="35px" />
</div>
<div style="display: none" id="SentSMSDiv">
	<br />
	<telerik:RadButton runat="server" ID="SentSMSSelectButton" Text="انتخاب" AutoPostBack="false" Width="100px" Height="35px" ValidationGroup="Line" />
	<telerik:RadButton runat="server" ID="SentSMSCloseButton" Text="بستن" AutoPostBack="false" Width="100px" Height="35px" />
</div>
