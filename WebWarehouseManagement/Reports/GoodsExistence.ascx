<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="GoodsExistence.ascx.cs" Inherits="WebWarehouseManagement.GoodsExistence" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register Src="~/WebControllers/MainControls/Persons/JSearchPersonControl.ascx" TagPrefix="uc1" TagName="JSearchPersonControl" %>
<%@ Register Src="~/WebControllers/MainControls/Grid/JGridViewControl.ascx" TagPrefix="uc1" TagName="JGridViewControl" %>
<%@ Register Src="~/WebControllers/MainControls/CustomListSelector/JCustomListSelectorControl.ascx" TagPrefix="uc1" TagName="JCustomListSelectorControl" %>


<telerik:RadAjaxManagerProxy runat="server" ID="AjaxManagerProxy_Control">
    <AjaxSettings>
        <telerik:AjaxSetting AjaxControlID="btnSave_Click">
        </telerik:AjaxSetting>
        <telerik:AjaxSetting AjaxControlID="CmbWarTypesOfGoods" ></telerik:AjaxSetting>
    </AjaxSettings>
</telerik:RadAjaxManagerProxy>
<div class="FormContent">
    <div class="BigTitle">گزارش موجودی کالا در انبار</div>
    <table>
        <tr>
            <td class="Table_RowB">نوع کالا:</td>
            <td class="Table_RowC">
                <telerik:RadComboBox runat="server" ID="CmbWarTypesOfGoods" Width="80%" EnableViewState="true" OnSelectedIndexChanged="cmbTypesOfGoods_SelectedIndexChanged" AutoPostBack="true" Filter="Contains"></telerik:RadComboBox>

            </td>
        </tr>

        <tr>
            <td class="Table_RowB">کالا :</td>
            <td class="Table_RowC">

                <uc1:JCustomListSelectorControl runat="server" id="JCustomListSelectorControlWarGoods" />

            </td>
        </tr>

        <tr>
            <td class="Table_RowB">سازنده :</td>
            <td class="Table_RowC">
                <uc1:JSearchPersonControl runat="server" id="personCode" />
            </td>
        </tr>

        <tr>
            <td class="Table_RowB">انبار:</td>
            <td class="Table_RowC">
                <telerik:RadComboBox runat="server" ID="cmbWarehouse"  Width="80%" Filter="Contains"></telerik:RadComboBox>
            </td>
        </tr>

    </table>
    <br />
     <telerik:RadButton runat="server" ID="btnSave" Text="تهیه گزارش " AutoPostBack="true"   OnClick="btnSave_Click" ValidationGroup="Save" />
    <br />
   <br />
   <uc1:JGridViewControl runat="server" id="JGridViewControl1" />
</div>


