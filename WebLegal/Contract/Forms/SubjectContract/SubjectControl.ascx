<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SubjectControl.ascx.cs" Inherits="WebLegal.Contract.Forms.SubjectContract.SubjectControl" %>
<%@ Register Assembly="JJson" Namespace="JJson.Controls" TagPrefix="JJson" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register Src="~/WebControllers/MainControls/Grid/JGridViewControl.ascx" TagPrefix="uc1" TagName="JGridViewControl" %>
<%--<%@ Register Src="~/WebControllers/MainControls/Date/JDateControl.ascx" TagPrefix="uc1" TagName="JDateControl" %>--%>
<%@ Register Src="~/WebControllers/ArchiveDocument/JArchiveControl.ascx" TagPrefix="uc1" TagName="JArchiveControl" %>
<%@ Register Src="~/WebFinance/Asset/JAssetSearchControl.ascx" TagPrefix="uc1" TagName="JAssetSearchControl" %>

<asp:Label ID="lblCode" runat="server" />
<asp:HiddenField runat="server" ID="hdnFinanceCode" />
<asp:HiddenField runat="server" ID="hdnNoFinance" />
<asp:HiddenField runat="server" ID="hdnSearchGroundResultClassName" />
<asp:HiddenField runat="server" ID="hdnSearchGroundResultCode" />
<asp:HiddenField runat="server" ID="hdnSearchGroundFinanceCode" />
<div id="JAssetSearchControl_Div" runat="server" style="display: none;">
	<uc1:JAssetSearchControl runat="server" id="JAssetSearchControl" />
</div>
<asp:TextBox runat="server" ID="hdnPersonId" />
<JJson:JDialog ID="JDialog1" runat="server">
</JJson:JDialog>
<telerik:RadTabStrip ID="JTabSubject" runat="server">
	<Tabs>
		<telerik:RadTab Text="موضوع قرارداد" PageViewID="JrtSubject"></telerik:RadTab>
	</Tabs>
	<Tabs>
		<telerik:RadTab Text="تصاویر" PageViewID="JrtSubJectPic"></telerik:RadTab>
	</Tabs>
</telerik:RadTabStrip>
<telerik:RadMultiPage runat="server" ID="RadMultiPage2" SelectedIndex="0" RenderSelectedPageOnly="true" Width="100%">
	<telerik:RadPageView runat="server" ID="JrtSubject">
		<table>
			<tr>
				<td>شماره قرارداد :</td>
				<td>
					<JJson:JNumericTextBox ID="txtContractNumber" runat="server"></JJson:JNumericTextBox></td>
				<td></td>
				<td>تاریخ قرارداد :</td>
				<td>
					<JJson:JPersianDatePicker runat="server" ID="txtDate"></JJson:JPersianDatePicker>
				</td>
				<td></td>
				<td>
					<asp:Label Text="تاریخ شروع قرارداد :" ID="lbldateStart" runat="server" />
				</td>
				<td>
					<JJson:JPersianDatePicker runat="server" ID="txtdateStart"></JJson:JPersianDatePicker>
				</td>
			</tr>
			<tr>
				<td>نوع متن قرارداد :</td>
				<td colspan="5">
					<asp:DropDownList ID="cmbSubject" runat="server"></asp:DropDownList></td>
				<td>
					<asp:Label Text="تاریخ اتمام قرارداد :" ID="lbldateEnd" runat="server" /></td>
				<td>
					<JJson:JPersianDatePicker runat="server" ID="txtdateEnd"></JJson:JPersianDatePicker>
				</td>
			</tr>
			<tr>
				<td>محل انجام :</td>
				<td colspan="5">
					<asp:DropDownList ID="cmbLocation" runat="server"></asp:DropDownList></td>
				<td>
					<asp:Label Text="تاریخ تحویل :" ID="lbldateDaliver" runat="server" /></td>
				<td>
					<JJson:JPersianDatePicker runat="server" ID="txtDateDeliver"></JJson:JPersianDatePicker>
				</td>
			</tr>
			<tr>
				<td>مشخصات موضوع قرارداد :</td>
			</tr>
			<tr>
				<td></td>
				<td>
					<%--<asp:Button ID="btnSearchGround" runat="server" Text="دارایی" />--%>
					<JJson:JJsonButton ID="btnSearchGround" runat="server" Text="دارایی" Event="click" />
					<asp:Label ID="lblMaxCount" runat="server" Text="--"></asp:Label>
					<JJson:JJsonTextBox ID="txtMaxCount" runat="server" Width="90px" Event="textchange"></JJson:JJsonTextBox>
				</td>
			</tr>
			<tr>
				<td></td>
				<td colspan="7">
					<JJson:JJsonTextBox ID="txtbSubjectComment" TextMode="MultiLine" runat="server" Width="550px" Event="textchange"></JJson:JJsonTextBox></td>
			</tr>
			<tr>
				<td>اطلاعات تکمیلی قرارداد :</td>
			</tr>
			<tr>
				<td></td>
				<td colspan="7">
					<JJson:JJsonTextBox ID="txtInfo" TextMode="MultiLine" runat="server" Width="550px" Event="textchange"></JJson:JJsonTextBox></td>
			</tr>
			<tr>
				<td>تعداد نسخه های قرارداد :</td>
				<td>
					<JJson:JJsonNumericTextBox ID="txtCopycount" runat="server" Event="textchange"></JJson:JJsonNumericTextBox></td>
				<td></td>
				<td>عنوان قرارداد :</td>
				<td colspan="4">
					<JJson:JJsonTextBox ID="txtContractTitle" runat="server" Event="textchange"></JJson:JJsonTextBox></td>
			</tr>
		</table>
	</telerik:RadPageView>
	<telerik:RadPageView runat="server" ID="JrtSubJectPic">
		<uc1:JArchiveControl runat="server" id="archiveControl" />
	</telerik:RadPageView>
</telerik:RadMultiPage>
<asp:Button ID="btnNext" runat="server" Text="بعدی" />
<asp:Button ID="btnBack" runat="server" Text="قبلی" />
<asp:Button ID="btnCancel" runat="server" Text="انصراف" OnClick="btnCancel_Click" />