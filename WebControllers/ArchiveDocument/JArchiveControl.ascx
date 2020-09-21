<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="JArchiveControl.ascx.cs" Inherits="WebControllers.ArchiveDocument.JArchiveControl" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>

<telerik:RadCodeBlock runat="server" ID="RadCodeBlock1">
    <script type="text/javascript">
        var _evt;
        function RowClick(sender, eventArgs) {
            var evt = eventArgs.get_domEvent();

            if (evt.target.tagName == "INPUT" || evt.target.tagName == "A") {
                return;
            }

            var index = eventArgs.get_itemIndexHierarchical();
            document.getElementById("radGridClickedRowIndex").value = index;
        }
    </script>
</telerik:RadCodeBlock>
<input type="hidden" id="radGridClickedRowIndex" name="radGridClickedRowIndex" />
<input type="hidden" runat="server" id="hfObjectCode" name="hfObjectCode" />
<input type="hidden" runat="server"  id="hfClassName" name="hfClassName" />
<input type="hidden" runat="server"  id="hfDataBaseClassName"  name="hfDataBaseClassName" />
<input type="hidden" runat="server"  id="hfDataBaseObjectCode" name="hfDataBaseObjectCode" />
<telerik:RadProgressManager runat="server" ID="RadProgressManager1" />

<asp:Panel runat="server" ID="pnlUpload" CssClass="qsf-demo-canvas scroll">
    <table>
        <tr style="vertical-align: middle">
            <td style="width: 100px" class="Table_RowC">توضیحات:</td>
            <td style="width: 200px" class="Table_RowB">
                <telerik:RadTextBox runat="server" ID="txtDescription" EmptyMessage="نام فایل - اجباری" EmptyMessageStyle-BorderStyle="NotSet" ValidateRequestMode="Enabled"></telerik:RadTextBox></td>
            <td style="width: 100px" class="Table_RowC">
                <telerik:RadAsyncUpload runat="server" ID="AsyncUpload_Archive" MultipleFileSelection="Disabled" MaxFileSize="5120000" HideFileInput="True" Localization-Select="انتخاب فایل" ManualUpload="False" RenderMode="Lightweight" />
            </td>
        </tr>
        <tr>
            <td style="width: 100px" class="Table_RowB scroll" colspan="3" >
                <telerik:RadButton runat="server" ID="btnUpload" Text="ذخیره" OnClick="btnUpload_Click"></telerik:RadButton>
            </td>
        </tr>
    </table>
    <telerik:RadProgressArea runat="server" ID="RadProgressArea1" />
</asp:Panel>

<%--<asp:UpdatePanel runat="server" ID="updGrid">
    <ContentTemplate>--%>

        <telerik:RadGrid runat="server" ID="dgrArchivedFiles" OnItemCommand="dgrArchivedFiles_ItemCommand" AutoGenerateColumns="false" OnPreRender="dgrArchivedFiles_PreRender">
            <ClientSettings>
                <ClientEvents OnRowClick="RowClick" />
                <Selecting AllowRowSelect="true"></Selecting>

            </ClientSettings>
            <MasterTableView runat="server" DataKeyNames="ArchiveCode,Code" CssClass="scroll">
                <NoRecordsTemplate>
                    <div dir="rtl" style="text-align: right;">فایلی جهت نمایش وجود ندارد</div>
                </NoRecordsTemplate>
                <Columns>
                    <telerik:GridBoundColumn DataField="Code" Display="false" />
                    <telerik:GridBoundColumn DataField="FileIcon" />
                    <telerik:GridBoundColumn DataField="ArchiveCode" />
                    <telerik:GridBoundColumn DataField="ArchiveTime" />
                    <telerik:GridBoundColumn DataField="FileExtension" />
                    <telerik:GridBoundColumn DataField="size" />
                    <telerik:GridBoundColumn DataField="ArchiveDesc" />
                    <telerik:GridBoundColumn DataField="ArchiveDate" />


                    <telerik:GridButtonColumn ButtonType="ImageButton" ImageUrl="~\Images\Controls\download_s24.png" CommandName="download"></telerik:GridButtonColumn>
                    <telerik:GridButtonColumn ButtonType="ImageButton" ImageUrl="~\Images\Controls\menu_delete.png" CommandName="delete" ConfirmText="آیا مایل به حذف هستید ؟" ConfirmTitle="حذف">
                    </telerik:GridButtonColumn>

                </Columns>
            </MasterTableView>
        </telerik:RadGrid>

    <%--</ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger  ControlID="dgrArchivedFiles" />
    </Triggers>
</asp:UpdatePanel>--%>
<div style="width: 100%; height: 35px; display: none;" class="Table_RowB">
    <span style="float: right">
        <telerik:RadButton runat="server" ID="btnDownloadFile" Text="دریافت" OnClick="btnDownloadFile_Click" Height="35px" Width="75px" />
    </span>
    <span style="float: left">
        <telerik:RadButton runat="server" ID="btnDeleteFile" Text="حذف" OnClick="btnDeleteFile_Click" Height="35px" Width="75px" />
    </span>
</div>
