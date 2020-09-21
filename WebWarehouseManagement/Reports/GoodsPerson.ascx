<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="GoodsPerson.ascx.cs" Inherits="WebWarehouseManagement.GoodsPerson" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register Src="~/WebControllers/MainControls/Persons/JSearchPersonControl.ascx" TagPrefix="uc1" TagName="JSearchPersonControl" %>
<%@ Register Src="~/WebControllers/MainControls/Grid/JGridViewControl.ascx" TagPrefix="uc1" TagName="JGridViewControl" %>
<%@ Register Src="~/WebControllers/MainControls/CustomListSelector/JCustomListSelectorControl.ascx" TagPrefix="uc1" TagName="JCustomListSelectorControl" %>


<telerik:RadAjaxManagerProxy runat="server" ID="AjaxManagerProxy_Control">
    <AjaxSettings>
        <telerik:AjaxSetting AjaxControlID="btnSave_Click">
        </telerik:AjaxSetting>
        <telerik:AjaxSetting AjaxControlID="CmbWarTypesOfGoods"></telerik:AjaxSetting>
        <telerik:AjaxSetting AjaxControlID="RbReportKind"></telerik:AjaxSetting>
        <telerik:AjaxSetting AjaxControlID="TD_Type"></telerik:AjaxSetting>
        <telerik:AjaxSetting AjaxControlID="TD_Goods"></telerik:AjaxSetting>
         <telerik:AjaxSetting AjaxControlID="TD_Person"></telerik:AjaxSetting>
    </AjaxSettings>
</telerik:RadAjaxManagerProxy>
<div class="FormContent">
    <div class="BigTitle">گزارش تولید کنندگان کالا</div>
    <table>
        <tr>
            <td class="Table_RowB">به تفکیک:</td>
            <td class="Table_RowC">
                <asp:RadioButtonList runat="server" ID="RbReportKind" Width="80%" EnableViewState="true"   OnSelectedIndexChanged="RbReportKind_SelectedIndexChanged" AutoPostBack="true">
                    <asp:ListItem Selected="True" Enabled="true" Text="کالا" Value="1"></asp:ListItem>
                    <asp:ListItem Selected="False" Enabled="true" Text="سازنده" Value="2"></asp:ListItem>
                </asp:RadioButtonList>

            </td>
        </tr>
        <tr runat="server" id="TD_Type">
            <td class="Table_RowB">نوع کالا:</td>
            <td class="Table_RowC">
                <telerik:RadComboBox runat="server" ID="CmbWarTypesOfGoods" Width="80%" EnableViewState="true" OnSelectedIndexChanged="cmbTypesOfGoods_SelectedIndexChanged" AutoPostBack="true" Filter="Contains">
                </telerik:RadComboBox>

            </td>
        </tr>

        <tr runat="server" id="TD_Goods">
            <td class="Table_RowB">کالا :</td>
            <td class="Table_RowC">

                <uc1:JCustomListSelectorControl runat="server" id="JCustomListSelectorControlWarGoods" />

            </td>
        </tr>

        <tr runat="server" id="TD_Person" visible="false">
            <td class="Table_RowB">سازنده :</td>
            <td class="Table_RowC">
                <uc1:JSearchPersonControl runat="server" id="personCode" />
            </td>
        </tr>



    </table>
    <br />
    <telerik:RadButton runat="server" ID="btnSave" Text="تهیه گزارش " AutoPostBack="true" OnClick="btnSave_Click" ValidationGroup="Save" />
    <br />
    <br />
    <uc1:JGridViewControl runat="server" id="JGridViewControl1" />
</div>


