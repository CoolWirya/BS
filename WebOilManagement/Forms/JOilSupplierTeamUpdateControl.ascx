<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="JOilSupplierTeamUpdateControl.ascx.cs" Inherits="WebOilManagement.Forms.JOilSupplierTeamUpdateControl" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register Src="~/WebBaseDefine/Forms/JOrganizationChartControl.ascx" TagPrefix="uc1" TagName="JOrganizationChartControl" %>

<div class="FormContent">
    <div class="BigTitle">ثبت و نگهداری اطلاعات تیم های پشتیبانی پیمانکار
    </div>
    <uc1:JOrganizationChartControl runat="server" id="JOrganizationChartControl" />
</div>
<div class="FormButtons">
    <%--<telerik:RadButton runat="server" ID="btnSave" Text="ذخیره" AutoPostBack="true" Width="100px" Height="35px" OnClick="btnSave_Click" />--%>
    <telerik:RadButton runat="server" ID="btnClose" Text="بازگشت" OnClientClicked="CloseDialog" AutoPostBack="false" Width="100px" Height="35px" />
</div>
