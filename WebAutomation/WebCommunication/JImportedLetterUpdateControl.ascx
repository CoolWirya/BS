<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="JImportedLetterUpdateControl.ascx.cs" Inherits="WebAutomation.WebCommunication.JImportedLetterUpdateControl" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register Src="~/WebControllers/MainControls/Date/JDateControl.ascx" TagPrefix="uc1" TagName="JDateControl" %>
<%@ Register Src="~/WebControllers/MainControls/Persons/JSearchPersonControl.ascx" TagPrefix="uc1" TagName="JSearchPersonControl" %>
<%@ Register Src="~/WebControllers/ArchiveDocument/JArchiveControl.ascx" TagPrefix="uc1" TagName="JArchiveControl" %>
<%@ Register Src="~/WebAutomation/Refer/JReferViewControl.ascx" TagPrefix="uc1" TagName="JReferViewControl" %>


<%--<telerik:RadAjaxManagerProxy runat="server" ID="RadAjaxManagerProxy1">
    <AjaxSettings>
        <telerik:AjaxSetting AjaxControlID="rtabImportedLetter">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="rpageImportedLetter" />
                <telerik:AjaxUpdatedControl ControlID="rtabImportedLetter" />
            </UpdatedControls>
        </telerik:AjaxSetting>

    </AjaxSettings>
</telerik:RadAjaxManagerProxy>--%>
<script type="text/javascript">
	$(document).ready(function () {
		$('#<%=LetterImageLink.ClientID%>').click(function () {
			$('#<%=LetterImageDiv.ClientID%>').slideToggle(300);
			return false;
		});
	});
</script>
<div class="FormContent">
	<div class="BigTitle">نامه های وارده</div>
	<telerik:RadTabStrip runat="server" ID="rtabImportedLetter" OnTabClick="rtabExportedLetter_TabClick" MultiPageID="rpageImportedLetter" Width="500px">
		<Tabs>
			<telerik:RadTab Text="اطلاعات نامه" Value="Info" PageViewID="rpvLetterInfo">
			</telerik:RadTab>
			<telerik:RadTab Text="ضمائم" PageViewID="rpvArchive">
			</telerik:RadTab>
			<telerik:RadTab Text="ارجاعات" PageViewID="rpvRefer">
			</telerik:RadTab>
		</Tabs>
	</telerik:RadTabStrip>
	<telerik:RadMultiPage runat="server" ID="rpageImportedLetter" SelectedIndex="0" Width="700px">
		<telerik:RadPageView runat="server" ID="rpvLetterInfo">
			<table style="width: 700px">

				<tr class="Table_RowB">
					<td style="width: 150px">سال:</td>
					<td>
						<telerik:RadTextBox runat="server" ID="txtYear"></telerik:RadTextBox>
						<input type="hidden" runat="server" id="LetterState" name="LetterState" value="0" />
						<input type="hidden" runat="server" id="hfCode" name="hfCode" value="0" />
						<input type="hidden" runat="server" id="hfReferCode" name="hfReferCode" value="0" />
						<input type="hidden" runat="server" id="hfCurrentPage" name="hfCurrentPage" value="0" />
					</td>
				</tr>
				<tr class="Table_RowB">
					<td style="width: 150px">شماره نامه دبیرخانه:</td>
					<td>
						<telerik:RadTextBox runat="server" ID="txtLetterNo" ReadOnly="true"></telerik:RadTextBox>
					</td>
				</tr>
				<tr class="Table_RowB">
					<td style="width: 150px">شماره نامه وارده:</td>
					<td>
						<telerik:RadTextBox runat="server" ID="txtIncoming_no" ReadOnly="true"></telerik:RadTextBox>
					</td>
				</tr>
				<tr class="Table_RowC">
					<td style="width: 150px">تاریخ نامه وارده:</td>
					<td>
						<uc1:JDateControl runat="server" id="incoming_date" />
					</td>
				</tr>
				<tr class="Table_RowC">
					<td style="width: 150px">فرستنده:</td>
					<td>
						<telerik:RadTextBox runat="server" ID="txtSender"></telerik:RadTextBox>

					</td>
				</tr>
				<tr class="Table_RowC">
					<td style="width: 150px">گیرنده:</td>
					<td>
						<telerik:RadComboBox runat="server" ID="cmbReciever" DataValueField="code" Filter="Contains" OnSelectedIndexChanged="cmbReciever_SelectedIndexChanged" DataTextField="Full_Title_Slim"></telerik:RadComboBox>

					</td>
				</tr>
				<tr class="Table_RowC">
					<td style="width: 150px">موضوع:</td>
					<td>
						<telerik:RadTextBox runat="server" ID="txtSubject"></telerik:RadTextBox>

					</td>
				</tr>
				<tr class="Table_RowC">
					<td style="width: 150px">امضاء کننده:</td>
					<td>
						<telerik:RadTextBox runat="server" ID="incoming_signature_person"></telerik:RadTextBox>

					</td>
				</tr>
				<tr class="Table_RowC">
					<td style="width: 150px">فوریت:</td>
					<td>
						<telerik:RadComboBox runat="server" ID="cmbUrgency" Filter="Contains" DataValueField="value" DataTextField="FarsiName"></telerik:RadComboBox>
					</td>
				</tr>
				<tr class="Table_RowC">
					<td style="width: 150px; vertical-align: top">
						<asp:LinkButton ID="LetterImageLink" runat="server">تصویر نامه</asp:LinkButton></td>
					<td></td>
				</tr>
			</table>
			<div id="LetterImageDiv" runat="server" style="display: none">
				<asp:Image Width="640px" Height="480px" ID="LetterImage" runat="server" />
			</div>
		</telerik:RadPageView>
		<telerik:RadPageView runat="server" ID="rpvArchive">
			<uc1:JArchiveControl runat="server" id="JArchiveControl" />
		</telerik:RadPageView>
		<telerik:RadPageView runat="server" ID="rpvRefer">
			<uc1:JReferViewControl runat="server" id="JReferViewControl" />
		</telerik:RadPageView>
	</telerik:RadMultiPage>
</div>
<div class="FormButtons">
	<telerik:RadButton runat="server" ID="btnSave" Text="ذخیره" AutoPostBack="true" Width="100px" Height="35px" OnClick="btnSave_Click" ValidationGroup="District" />
	<telerik:RadButton runat="server" ID="btnClose" Text="بازگشت" OnClientClicked="CloseDialog" AutoPostBack="false" Width="100px" Height="35px" />
	<telerik:RadButton runat="server" ID="btnReference" Text="ارجاع" OnClick="btnReference_Click" AutoPostBack="true" Width="100px" Height="35px" />
	<telerik:RadButton runat="server" ID="btnReturn" Text="بازگشت از ارجاع" OnClick="btnReturn_Click" AutoPostBack="true" Width="100px" Height="35px" />
	<telerik:RadButton runat="server" ID="btnParent" Text="عطف / پیرو" OnClick="btnParent_Click" AutoPostBack="true" Width="100px" Height="35px" />
	<%-- <telerik:RadButton runat="server" ID="btnPrint"     Text="چاپ"   OnClick="btnPrint_Click"    AutoPostBack="true" Width="100px" Height="35px" />--%>
</div>
<telerik:RadCodeBlock ID="RadCodeBlock1" runat="server">
	<script type="text/javascript">
		function ReferSuccess() {
			CloseDialog(null);
		}
	</script>
</telerik:RadCodeBlock>
