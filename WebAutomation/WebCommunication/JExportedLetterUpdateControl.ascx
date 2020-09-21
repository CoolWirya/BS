<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="JExportedLetterUpdateControl.ascx.cs" Inherits="WebAutomation.WebCommunication.JExportedLetterUpdateControl" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register Src="~/WebControllers/MainControls/Date/JDateControl.ascx" TagPrefix="uc1" TagName="JDateControl" %>
<%@ Register Src="~/WebControllers/MainControls/Persons/JSearchPersonControl.ascx" TagPrefix="uc1" TagName="JSearchPersonControl" %>
<%@ Register Src="~/WebControllers/ArchiveDocument/JArchiveControl.ascx" TagPrefix="uc1" TagName="JArchiveControl" %>
<%@ Register Src="~/WebAutomation/Refer/JReferViewControl.ascx" TagPrefix="uc1" TagName="JReferViewControl" %>
<%@ Register Src="JNoStorageControl.ascx" TagName="JNoStorageControl" TagPrefix="uc1" %>
<script type="text/javascript">
    function OnClientSelectedIndexChanged(sender, eventArgs) {
        var selected_item = eventArgs.get_item();
        var PostCode = parseInt(selected_item.get_value());
        if (PostCode == NaN) return;
        SenderChanged(PostCode);
    }

    function SenderChanged(PostCode)
    {
        ShowWarining('در  حال بارگذاری ...', false, 3);
        $.ajax({
            type: 'POST',
            url: 'Services/WebAutomationService.asmx/GetCopyReceiversList',
            data: '{'
                    + '"PostCode":' + PostCode + '}',
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (msg) {
                ////  ---------------------- Fill CopyReceivers ComboBox --------------------------
                //var combo = document.getElementById("<%= cmbCopyReceiver.ClientID %>");
                var combo = $find("<%= cmbCopyReceiver.ClientID %>");
                var xmlDoc = $.parseXML(msg.d.CopyReceivers);
                var xml = $(xmlDoc);
                var dt = xml.find("datatable");
                //combo.innerHTML = "";
                combo.clearSelection();
                combo.clearItems();
                $.each(dt, function () {
                    var comboItem = new Telerik.Web.UI.RadComboBoxItem();
                    comboItem.set_text($(this).find("Full_Title_Slim").text());
                    comboItem.set_value($(this).find("Code").text());
                    combo.trackChanges();
                    combo.get_items().add(comboItem);
                    //var option = document.createElement("option");
                    //option.text = $(this).find("Full_Title_Slim").text();
                    //option.value = $(this).find("code").text();
                    //combo.add(option);
                });
                //comboItem.select();
                combo.commitChanges();
                
                ////  ---------------------- Set lblSignStatus & btnSign --------------------------
                var lblSignStatus = document.getElementById("<%= lblSignStatus.ClientID %>");
                var btnSign = document.getElementById("<%= btnSign.ClientID %>");
                if (msg.d.SignStatus == 1)
                    lblSignStatus.innerText = "نامه هنوز امضا نشده است.";
                else
                    lblSignStatus.innerText = "فرستنده حق امضاء ندارد.";
                if (msg.d.CanSign)
                    $(btnSign).css("display", "inline-block");
                else
                    $(btnSign).css("display", "none");
            },
            error: function (xhr, status, error) {
                var err = eval("(" + xhr.responseText + ")");
                alert(err.Message);
            }
        });
    }

    $(document).ready(function () {
        ////  ---------------------- Set Form For First Sender --------------------------
        var PostCode = parseInt("<%=cmbSender.SelectedValue %>");
        if (PostCode != NaN) SenderChanged(PostCode);

        ////  ----------------------  --------------------------
		$('#<%=NoStorageDialogDiv.ClientID%>').find("*").css("position", "static");
		$('#<%=NoStorageDialogDiv.ClientID%>').find("*").css("overflow", "hidden");
		var dialog = $('#<%=NoStorageDialogDiv.ClientID%>').dialog({
			resizable: false,
			width: 400,
			height: 400,
			modal: true,
			autoOpen: false,
			buttons: {
				"تائید": function () {
					$('#<%=txtLetterNo.ClientID%>').val($('#<%=JNoStorageControl1.Parent.ClientID%>').val());
					$('#<%=JNoStorageControl1.ClientID%>').find("NumberTextBox").val('');
					//__doPostBack(uniqueID, '');
					//setTimeout('__doPostBack(\'' + uniqueID + '\',\'\')', 0);
					//$(this).dialog("close");
					<%=this.Page.ClientScript.GetPostBackEventReference(new PostBackOptions(this.btnSign))%>;
				},
				"بستن": function () {
					$(this).dialog("close");
					//return false;
				}
			}
		});
		//dialog.parent().appendTo($("form:first"));
		//function openDialog(uniqueID) {
		$('#<%= btnSign.ClientID%>').click(function () {
			//return dialog.dialog("open");
			//return false;
			<%--__doPostBack('#<%= btnSign.ClientID %>', 'OnClick');--%>
			<%--setTimeout('__doPostBack(\'<%= btnSign.ClientID %>\',\'OnClick\')', 0);--%>
			dialog.dialog("open");
			return false;
		}
		);
	});
</script>
<div class="FormContent">
	<div class="BigTitle">نامه های صادره</div>
	<telerik:RadTabStrip runat="server" ID="rtabExportedLetter" SelectedIndex="0" OnTabClick="rtabExportedLetter_TabClick" MultiPageID="rpageExportedLetter" Width="500px">
		<Tabs>
			<telerik:RadTab Text="اطلاعات نامه" Value="rpvLetterInfo" PageViewID="rpvLetterInfo">
			</telerik:RadTab>
			<telerik:RadTab Text="ضمائم" Value="Archive" PageViewID="rpvArchive">
			</telerik:RadTab>
			<telerik:RadTab Text="ارجاعات" Value="Refer" PageViewID="rpvRefer">
			</telerik:RadTab>
			<telerik:RadTab Text="ارسال و تحویل" Value="Delivery" PageViewID="rpvSendDelivery">
			</telerik:RadTab>
		</Tabs>
	</telerik:RadTabStrip>
	<telerik:RadMultiPage runat="server" ID="rpageExportedLetter" SelectedIndex="0" Width="700px">
		<telerik:RadPageView runat="server" ID="rpvLetterInfo">

			<table style="width: 700px">
				<tr class="Table_RowB">
					<td style="width: 150px">پاسخ / پیرو:</td>
					<td>
						<input type="hidden" runat="server" id="LetterState" name="LetterState" value="0" />
						<input type="hidden" runat="server" id="ParentCode" name="ParentCode" value="0" />
						<input type="hidden" runat="server" id="hfCode" name="hfCode" value="0" />
						<input type="hidden" runat="server" id="hfReferCode" name="hfReferCode" value="0" />
						<input type="hidden" runat="server" id="hfCurrentPage" name="hfCurrentPage" value="0" />
						<telerik:RadTextBox Width="300px" runat="server" ReadOnly="true" ID="txtParent"></telerik:RadTextBox>
					</td>
				</tr>
				<tr class="Table_RowC">
					<td style="width: 150px">سال:</td>
					<td>
						<telerik:RadTextBox Width="300px" runat="server" ID="txtYear"></telerik:RadTextBox>
					</td>
				</tr>
				<tr class="Table_RowB">
					<td style="width: 150px">شماره نامه:</td>
					<td>
						<telerik:RadTextBox Width="300px" runat="server" ID="txtLetterNo" ReadOnly="true"></telerik:RadTextBox>
					</td>
				</tr>
				<tr class="Table_RowC">
					<td style="width: 150px">فرستنده:</td>
					<td>
						<telerik:RadComboBox Width="300px" runat="server" ID="cmbSender" Filter="Contains" DataValueField="code" OnClientSelectedIndexChanged="OnClientSelectedIndexChanged"
							DataTextField="Full_Title_Slim">
						</telerik:RadComboBox><%--AutoPostBack="true" OnSelectedIndexChanged="cmbSender_SelectedIndexChanged"--%>
					</td>
				</tr>
				<tr class="Table_RowB">
					<td style="width: 150px">گیرنده:</td>
					<td>
						<telerik:RadTextBox Width="300px" runat="server" ID="txtReciever"></telerik:RadTextBox>
					</td>
				</tr>
				<tr class="Table_RowC">
					<td style="width: 150px">موضوع:</td>
					<td>
						<telerik:RadTextBox Width="300px" runat="server" ID="txtSubject"></telerik:RadTextBox>

					</td>
				</tr>
				<tr class="Table_RowB">
					<td style="width: 150px">فوریت:</td>
					<td>
						<telerik:RadComboBox Width="300px" runat="server" Filter="Contains" ID="cmbUrgency" DataValueField="value" DataTextField="FarsiName"></telerik:RadComboBox>
					</td>
				</tr>
				<tr class="Table_RowC">
					<td colspan="2">
						<asp:Panel ID="pnlCopyReceiver" GroupingText="رونوشت نامه" runat="server" Width="99%">
							<telerik:RadAjaxPanel runat="server" ID="jxpnlCopyReceiver">   

								<table style="width: 100%">
									<tr class="Table_RowB">
										<td style="width: 135px">گیرنده:</td>
										<td>
											<telerik:RadComboBox Width="300px" runat="server" Filter="Contains" DataValueField="code" DataTextField="Full_Title_Slim" ID="cmbCopyReceiver"></telerik:RadComboBox>
                                            <%--<asp:DropDownList runat="server" ID="cmbCopyReceiver" Width="300px">
                                            </asp:DropDownList>--%>
                                            <%--<select id="cmbCopyReceiver" runat="server">
                                                <option></option>
                                            </select>--%>
										</td>
									</tr>
									<tr class="Table_RowC">
										<td style="width: 135px">توضیحات:</td>
										<td>
											<telerik:RadTextBox Width="300px" runat="server" ID="txtReason" CssClass="RadComboBox RadComboBox_Default RadComboBox_rtl RadComboBox_Default_rtl"></telerik:RadTextBox>
										</td>
									</tr>

									<tr class="Table_RowB">

										<td>
											<telerik:RadButton runat="server" ID="btnAddCopyReceiver" Text="افزودن" AutoPostBack="true" Width="100px" Height="35px" OnClick="btnAddCopyReceiver_Click" />
										</td>

									</tr>
									<tr class="Table_RowC">
										<td colspan="2">
											<telerik:RadGrid EnableViewState="false" runat="server" ID="grvCopies" OnLoad="grvCopies_Load"
												AutoGenerateColumns="false" AllowFilteringByColumn="false" Width="100%"
												OnSelectedIndexChanged="grvCopies_SelectedIndexChanged" ActiveItemStyle-Width="100%"
												AllowSorting="True" GridLines="None" OnNeedDataSource="grvCopies_NeedDataSource"
												OnDeleteCommand="grvCopies_DeleteCommand">
												<ClientSettings>
													<Selecting AllowRowSelect="true"></Selecting>

												</ClientSettings>
												<MasterTableView DataKeyNames="Code">
													<Columns>
														<telerik:GridBoundColumn Visible="false" DataField="Code" HeaderText="کد"></telerik:GridBoundColumn>
														<telerik:GridBoundColumn DataField="receiver_full_title" HeaderText="گیرنده"></telerik:GridBoundColumn>
														<telerik:GridBoundColumn DataField="copy_reason" HeaderText="توضیحات"></telerik:GridBoundColumn>
														<telerik:GridButtonColumn ButtonType="ImageButton" ImageUrl="~\Images\Controls\menu_delete.png" CommandName="delete" ConfirmText="آیا این گیرنده حذف شود"></telerik:GridButtonColumn>
													</Columns>
												</MasterTableView>
											</telerik:RadGrid>

											<input type="hidden" runat="server" id="GridViewCopiesSelectedRowId" name="GridViewCopiesRowId" value="0" />

										</td>
									</tr>

								</table>
							</telerik:RadAjaxPanel>
						</asp:Panel>
					</td>
				</tr>
				<tr class="Table_RowB">
					<td colspan="2">

						<asp:Panel ID="pnlSignStatus" GroupingText="وضعیت نامه" runat="server" Width="99%">
							<table style="width: 100%">
								<tr class="Table_RowB">
									<td style="width: 180px">
										<asp:Label ID="lblSignStatus" Text="نامه هنوز امضا نشده است." runat="server"></asp:Label>
									</td>
									<td>
										<%--<telerik:RadButton runat="server" ID="btnSign" Text="امضا نامه" AutoPostBack="false" Width="100px" Height="35px" OnClientClicked="javascript:return openDialog(this.name);" OnClick="btnSign_Click" />--%>
										<asp:Button runat="server" ID="btnSign" Text="امضا نامه" Width="100px" Height="35px" OnClick="btnSign_Click" />
										<%--<asp:Button runat="server" ID="SignHiddenButton" Text="text" OnClick="btnSign_Click" Style="display: none" />--%>
									</td>
								</tr>
							</table>
						</asp:Panel>
					</td>
				</tr>
				<tr class="Table_RowC">
					<td colspan="2" dir="ltr">
						<telerik:RadEditor runat="server" EditModes="All" ID="txtContent" ToolTip="تایپ نامه"></telerik:RadEditor>
					</td>
				</tr>
			</table>
		</telerik:RadPageView>
		<telerik:RadPageView runat="server" ID="rpvArchive">
			<uc1:JArchiveControl runat="server" id="JArchiveControl" />
		</telerik:RadPageView>
		<telerik:RadPageView runat="server" ID="rpvRefer">
			<uc1:JReferViewControl runat="server" id="JReferViewControl" />
		</telerik:RadPageView>
		<telerik:RadPageView runat="server" ID="rpvSendDelivery">
			<asp:Panel ID="pnlDelivery" GroupingText="ارسال و تحویل نامه" runat="server" Width="99%">
				<table style="width: 100%">
					<tr class="Table_RowB">
						<td style="width: 150px">نوع ارسال
						</td>
						<td>
							<telerik:RadComboBox Width="300px" runat="server" ID="cmbDeliveryType" Filter="Contains" DataValueField="value" DataTextField="FarsiName"></telerik:RadComboBox>
						</td>
					</tr>
					<tr class="Table_RowC">
						<td style="width: 150px">تاریخ ارسال
						</td>
						<td>
							<uc1:JDateControl runat="server" id="dteDelivery" />
						</td>
					</tr>
					<tr class="Table_RowC">
						<td style="width: 150px">تحویل گیرنده 
						</td>
						<td>
							<telerik:RadTextBox Width="300px" runat="server" ID="txtDeliveryPerson"></telerik:RadTextBox>
						</td>
					</tr>
				</table>
			</asp:Panel>
		</telerik:RadPageView>
	</telerik:RadMultiPage>
</div>
<div id="NoStorageDialogDiv" runat="server" style="display: none; overflow-y: scroll">
	<uc1:JNoStorageControl ID="JNoStorageControl1" runat="server" owner="630N" />
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
