<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="JAccDocumentsEditUpdateControl.ascx.cs" Inherits="WebBusManagement.FormsManagement.JAccDocumentsEditUpdateControl" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>

<div class="FormContent">
    <div class="BigTitle">ویرایش جزئیات سند</div>
    <table style="width: 100%; height: auto; margin-top: 15px">
        <tr>
            <td style="width: 100%; height: auto; overflow: auto">
                <telerik:radgrid id="RadGridPaymentDetail" runat="server" autogeneratecolumns="true"
                    onprerender="RadGridPaymentDetail_PreRender">
                <MasterTableView>
                    <Columns>
                        <telerik:GridTemplateColumn HeaderText="حذف شود ؟" UniqueName="DeleteStatus">
                            <ItemTemplate>
                                <asp:CheckBox runat="server" ID="chbSelect" Checked="false"/>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                    </Columns>
                </MasterTableView>
            </telerik:radgrid>
            </td>
        </tr>
    </table>
</div>
<div class="FormButtons">
    <telerik:RadButton runat="server" ID="btnSave" Text="حذف" AutoPostBack="true" OnClick="btnSave_Click" Width="100px" Height="35px" />
    <telerik:RadButton runat="server" ID="btnClose" Text="بازگشت" OnClientClicked="CloseDialog" AutoPostBack="false" Width="100px" Height="35px" />
</div>