<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="JNewLandsControl.ascx.cs" Inherits="WebEstate.Land.Land.JNewLandsControl" %>
<%@ Register Assembly="JJson" Namespace="JJson.Controls" TagPrefix="JJson" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register Src="~/WebControllers/ArchiveDocument/JArchiveControl.ascx" TagPrefix="uc1" TagName="JArchiveControl" %>

<span>کد اراضی: </span>
<asp:Label ID="lblCode" runat="server" />
<telerik:RadTabStrip runat="server" ID="RadTabStrip1" SelectedIndex="0" MultiPageID="RadMultiPage1" Width="100%">
	<Tabs>
		<telerik:RadTab Text="مشخصات" PageViewID="rpvSpecifications" />
		<telerik:RadTab Text="تصاویر و فایلهای مرتبط" PageViewID="rpvAttachments" />
	</Tabs>
</telerik:RadTabStrip>
<telerik:RadMultiPage runat="server" ID="RadMultiPage1" SelectedIndex="0" RenderSelectedPageOnly="true" Width="100%">
	<telerik:RadPageView runat="server" ID="rpvSpecifications">
		<table>
			<tr>
				<td>مساحت تقریبی:
				</td>
				<td>
					<JJson:JNumericTextBox ID="numArea" runat="server"></JJson:JNumericTextBox>
				</td>
				<td>متر مربع
				</td>
			</tr>
			<tr>
				<td>پلاک ثبتی:
				</td>
				<td>
					<asp:TextBox runat="server" ID="txtPlaque" />
				</td>
				<td></td>
			</tr>
			<tr>
				<td>بخش:
				</td>
				<td>
					<asp:TextBox runat="server" ID="txtSection" />
				</td>
				<td></td>
			</tr>
			<tr>
				<td>موسوم به:
				</td>
				<td>
					<asp:TextBox runat="server" ID="txtName" />
				</td>
				<td></td>
			</tr>
		</table>
		<%--<JJson:JJsonButton ID="btnOK" Text="تایید" runat="server" Event="click" />--%>
		<JJson:JJsonButton ID="btnOK" Text="ذخیره" runat="server" Event="click" />
		<asp:Button Text="خروج" runat="server" ID="btnExit" OnClick="btnExit_Click" />
	</telerik:RadPageView>
	<telerik:RadPageView runat="server" ID="rpvAttachments">
		<uc1:JArchiveControl runat="server" id="archiveControl" />
	</telerik:RadPageView>
</telerik:RadMultiPage>
