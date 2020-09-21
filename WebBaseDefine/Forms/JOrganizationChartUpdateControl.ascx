<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="JOrganizationChartUpdateControl.ascx.cs" Inherits="WebBaseDefine.Forms.JOrganizationChartUpdateControl" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register Src="~/WebControllers/MainControls/CustomListSelector/JCustomListSelectorControl.ascx" TagPrefix="uc1" TagName="JCustomListSelectorControl" %>


<div class="FormContent">
    <div class="BigTitle">پست سازمانی</div>
    <table>
        <tr>
            <td class="Table_RowB">کاربر:</td>
            <td class="Table_RowC" style="width:300px">
                <telerik:RadComboBox runat="server" ID="cmbUsers" Width="200px" Filter="Contains"></telerik:RadComboBox>
            </td>
        </tr>
        <tr>
            <td class="Table_RowB">سمت:</td>
            <td class="Table_RowC">
                <telerik:RadComboBox runat="server" ID="cmbPosts" Width="200px" Filter="Contains"></telerik:RadComboBox>
            </td>
        </tr>
        <tr>
            <td class="Table_RowB">شغل:</td>
            <td class="Table_RowC">
                <telerik:RadComboBox runat="server" ID="cmbJobs" Width="200px" Filter="Contains"></telerik:RadComboBox>
            </td>
        </tr>
        <tr>
            <td class="Table_RowB"></td>
            <td class="Table_RowC">
                <telerik:RadComboBox runat="server" ID="cmbUnit">
                    <Items>
                        <telerik:RadComboBoxItem Text="واحد" Value="1" />
                        <telerik:RadComboBoxItem Text="غیر واحد" Value="0" />
                    </Items>
                </telerik:RadComboBox>
            </td>
        </tr>
        <tr>
            <td class="Table_RowB">دبیرخانه:</td>
            <td class="Table_RowC">
                <telerik:RadComboBox runat="server" ID="cmbSecretariat" Width="200px" Filter="Contains"></telerik:RadComboBox>
            </td>
        </tr>
    </table>
</div>
<div class="FormButtons">
    <telerik:RadButton runat="server" ID="btnSave" Text="ذخیره" AutoPostBack="true" Width="100px" Height="35px" OnClick="btnSave_Click" ValidationGroup="Line" />
    <telerik:RadButton runat="server" ID="btnClose" Text="بازگشت" OnClientClicked="CloseDialog" AutoPostBack="false" Width="100px" Height="35px" />
</div>

