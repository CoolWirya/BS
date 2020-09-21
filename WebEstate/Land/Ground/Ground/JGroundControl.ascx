<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="JGroundControl.ascx.cs" Inherits="WebEstate.Land.Ground.Ground.JGroundControl" %>
<%@ Register Assembly="JJson" Namespace="JJson.Controls" TagPrefix="JJson" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register Src="~/WebControllers/ArchiveDocument/JArchiveControl.ascx" TagPrefix="uc1" TagName="JArchiveControl" %>
<%@ Register Src="~/WebControllers/MainControls/Persons/JPersonListControl.ascx" TagPrefix="uc1" TagName="JPersonListControl" %>

<script type="text/javascript">
	$(document).ready(function () {
		//alert($(".hdn").val());
		var buttonsConfig = [
		{
			text: "انتخاب",
			click: function () {
				var index = Number($("#<%=(JPersonListControl as WebControllers.MainControls.JPersonListControl).FindControl("hdnRowId").ClientID%>").val()) + 1;
				//alert(index);
				var personId = $("#addPrimaryOwnerDiv tbody tr:eq(" + index + ") td:eq(0)").html();
				//alert(personId);
				$("#<%=hdnPersonId.ClientID%>").val(personId);
				$("#addPrimaryOwnerDiv").dialog("close");
				$("#addPrimaryOwnerDiv_GetSahm").dialog("open");
			}
		},
		{
			text: "بستن",
			click: function () {
				$("#addPrimaryOwnerDiv").dialog("close");
			}
		}
		];
		$("#addPrimaryOwnerDiv").dialog({
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
			width: 600,
			height: 500,
			buttons: buttonsConfig
		});
		$("#addPrimaryOwnerDiv").parent().appendTo($("form:first"));
		$("#addPrimaryOwnerDiv_GetSahm").dialog({
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
			width: 300,
			height: 150,
		});
		$("#addPrimaryOwnerDiv_GetSahm").parent().appendTo($("form:first"));
		$("#<%=btnAddPrimaryOwner.ClientID%>").click(function () {
			$("#addPrimaryOwnerDiv").dialog("open");
			return false;
		});
		//$(".hdn").on("input", function () { alert('selected'); });
		//$("tr td tbody tr td").mouseenter(function () {
		//	var iColIndex = $(this).closest("tr td").prevAll("tr td").length;
		//	var iRowIndex = $(this).closest("tr").prevAll("tr").length;
		//	alert(iRowIndex + ' : ' + iColIndex);
		//});
	});
</script>
<asp:Label Text="" ID="lblCode" runat="server" />
<telerik:RadTabStrip runat="server" ID="RadTabStrip1" SelectedIndex="0" MultiPageID="RadMultiPage1" Width="100%" OnTabClick="RadTabStrip1_TabClick">
	<Tabs>
		<telerik:RadTab Text="کلیات" PageViewID="rpvTotals" />
		<telerik:RadTab Text="مالکین اولیه" PageViewID="rpvPrimaryOwners" />
		<telerik:RadTab Text="فایلهای مربوطه" PageViewID="rpvAttachments" />
		<telerik:RadTab Text="توضیحات" PageViewID="rpvDescription" />
		<telerik:RadTab Text="مالکین فعلی" PageViewID="rpvOwners" />
		<%--<telerik:RadTab Text="سابقه قراردادها" PageViewID="rpvContractsHistory" />--%>
		<%--<telerik:RadTab Text="کروکی" PageViewID="rpvPlan" />--%>
	</Tabs>
</telerik:RadTabStrip>
<telerik:RadMultiPage runat="server" ID="RadMultiPage1" SelectedIndex="0" RenderSelectedPageOnly="true" Width="100%">
	<telerik:RadPageView runat="server" ID="rpvTotals">
		<table>
			<tr>
				<td>اراضی:
				</td>
				<td>
					<%--<asp:DropDownList runat="server" ID="cmbLand"></asp:DropDownList>--%>
					<JJson:JJsonDropDownList runat="server" Event="change" ID="cmbLand"></JJson:JJsonDropDownList>
				</td>
				<td>بخش:
				</td>
				<td>
					<asp:TextBox runat="server" ID="txtSection" Enabled="false" />
				</td>
			</tr>
			<tr>
				<td>پلاک اصلی:
				</td>
				<td colspan="3">
					<asp:TextBox runat="server" ID="txtMainAve" Width="400px" />
				</td>
			</tr>
			<tr>
				<td>پلاک فرعی:
				</td>
				<td colspan="3">
					<asp:TextBox runat="server" ID="txtSubAve" Width="400px" />
				</td>
			</tr>
			<tr>
				<td>شماره بلوک:
				</td>
				<td>
					<JJson:JJsonNumericTextBox runat="server" ID="txtBlockNum"></JJson:JJsonNumericTextBox>
				</td>
				<td>کاربری:
				</td>
				<td>
					<asp:DropDownList runat="server" ID="cmbUsage"></asp:DropDownList>
				</td>
			</tr>
			<tr>
				<td>شماره قطعه:
				</td>
				<td>
					<JJson:JJsonNumericTextBox runat="server" ID="txtPartNum"></JJson:JJsonNumericTextBox>
				</td>
				<td>مساحت:
				</td>
				<td>
					<JJson:JJsonNumericTextBox runat="server" ID="txtArea"></JJson:JJsonNumericTextBox>
				</td>
			</tr>
			<tr>
				<td>نوع سند:
				</td>
				<td>
					<asp:DropDownList runat="server" ID="cmbDocumentType"></asp:DropDownList>
				</td>
				<td>نوع ملک:
				</td>
				<td>
					<asp:DropDownList runat="server" ID="cmbEstateType"></asp:DropDownList>
				</td>
			</tr>
			<tr>
				<td>ارزش زمین:
				</td>
				<td>
					<JJson:JJsonNumericTextBox runat="server" ID="txtCost"></JJson:JJsonNumericTextBox>
				</td>
				<td>شماره سند:
				</td>
				<td>
					<JJson:JJsonNumericTextBox runat="server" ID="txtNumDocument"></JJson:JJsonNumericTextBox>
				</td>
			</tr>
		</table>
		<asp:CheckBox Text="حق ریشه دارد" ID="chkRightRoot" runat="server" />
	</telerik:RadPageView>
	<telerik:RadPageView runat="server" ID="rpvPrimaryOwners">
		<telerik:RadGrid runat="server" ID="gvPrimaryOwners"></telerik:RadGrid>
		<%--<JJson:JJsonButton ID="btnAddPrimaryOwner" Text="اضافه" runat="server" Event="click" />--%>
		<asp:Button Text="اضافه" ID="btnAddPrimaryOwner" runat="server" />
		<%--<asp:TextBox runat="server" ID="hdnPersonId" />--%>
		<div id="addPrimaryOwnerDiv" style="display: none">
			<uc1:JPersonListControl runat="server" ShowSelectionButton="false" id="JPersonListControl" cssclass="jplc" />
		</div>
		<div id="addPrimaryOwnerDiv_GetSahm" style="display: none">
			<asp:HiddenField runat="server" ID="hdnPersonId" />
			<span>میزان سهم:</span>
			<JJson:JNumericTextBox runat="server" ID="txtSahm"></JJson:JNumericTextBox>
			<br />
			<JJson:JJsonButton ID="btnAddPrimaryOwner_Sahm" Text="ثبت" runat="server" Event="click" />
		</div>
		<JJson:JJsonButton ID="btnRemovePrimaryOwner" Text="حذف" runat="server" Event="click" />
	</telerik:RadPageView>
	<telerik:RadPageView runat="server" ID="rpvAttachments">
		<uc1:JArchiveControl runat="server" id="archiveControl" />
	</telerik:RadPageView>
	<telerik:RadPageView runat="server" ID="rpvDescription">
		<telerik:RadEditor runat="server" ID="edtDescriptionEditor"></telerik:RadEditor>
	</telerik:RadPageView>
	<telerik:RadPageView runat="server" ID="rpvOwners">
		<telerik:RadGrid runat="server" ID="gvOwnersMainContract"></telerik:RadGrid>
		<telerik:RadGrid runat="server" ID="gvOwnersRentalContract"></telerik:RadGrid>
	</telerik:RadPageView>
	<%--<telerik:RadPageView runat="server" ID="rpvContractsHistory">
		<telerik:RadGrid runat="server" ID="gvContractDefinition"></telerik:RadGrid>
		<telerik:RadGrid runat="server" ID="gvContractDetail"></telerik:RadGrid>
	</telerik:RadPageView>--%>
	<%--<telerik:RadPageView runat="server" ID="rpvPlan">
	</telerik:RadPageView>--%>
</telerik:RadMultiPage>
<%--<JJson:JJsonButton ID="btnNew" Text="New" runat="server" Event="click" />--%>
<JJson:JJsonButton ID="btnOk" Text="OK" runat="server" Event="click" />
<%--<JJson:JJsonButton ID="btnContract" Text="ثبت قرارداد" runat="server" Event="click" />--%>
<JJson:JJsonButton ID="btnRefresh" Text="بروز رسانی" runat="server" Event="click" />
<JJson:JJsonButton ID="btnPrint" Text="چاپ" runat="server" Event="click" />
<JJson:JJsonButton ID="btnExit" runat="server" Event="click" Text="خروج" />