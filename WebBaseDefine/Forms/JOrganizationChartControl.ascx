<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="JOrganizationChartControl.ascx.cs" Inherits="WebBaseDefine.Forms.JOrganizationChartControl" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>

<telerik:RadCodeBlock runat="server">
    <script type="text/javascript">
        function RefreshGrid() {
            window.location = document.URL;
        }
    </script>
</telerik:RadCodeBlock>
<div style="width: 100%">
    <telerik:RadToolBar runat="server" ID="tbrActions" OnButtonClick="tbrActions_ButtonClick" Width="100%">
        <Items>
            <telerik:RadToolBarButton ImageUrl="~/Images/Controls/toolbar_edit.png" Text="ویرایش پست" Value="EditNode"></telerik:RadToolBarButton>
            <telerik:RadToolBarButton IsSeparator="true"></telerik:RadToolBarButton>
            <telerik:RadToolBarButton ImageUrl="~/Images/Controls/toolbar_add.png" Text="افزودن زیرمجموعه" Value="AddSubNode" ></telerik:RadToolBarButton>
            <telerik:RadToolBarButton ImageUrl="~/Images/Controls/toolbar_add.png" Text="افزودن پست اصلی" Value="AddMainNode" ></telerik:RadToolBarButton>
            <telerik:RadToolBarButton IsSeparator="true"></telerik:RadToolBarButton>
            <telerik:RadToolBarButton IsSeparator="true"></telerik:RadToolBarButton>
            <telerik:RadToolBarButton IsSeparator="true"></telerik:RadToolBarButton>
            <telerik:RadToolBarDropDown ImageUrl="~/Images/Controls/toolbar_delete.png" Text="حذف">
                <Buttons>
                    <telerik:RadToolBarButton Text="حذف پست سازمانی و انتقال زیرمجموعه ها به رده بالاتر" Value="DeleteNodeAndMove"></telerik:RadToolBarButton>
                    <telerik:RadToolBarButton IsSeparator="true"></telerik:RadToolBarButton>
                    <telerik:RadToolBarButton IsSeparator="true"></telerik:RadToolBarButton>
                    <telerik:RadToolBarButton Text="حذف پست سازمانی و زیرمجموعه ها" Value="DeleteNodeFully"></telerik:RadToolBarButton>
                </Buttons>
            </telerik:RadToolBarDropDown>
        </Items>
    </telerik:RadToolBar>
</div>
<div style="width: 100%; position: fixed; top: 70px; bottom: 0px; overflow: scroll">
    <telerik:RadTreeView runat="server" ID="trvOrg" EnableDragAndDropBetweenNodes="true" EnableDragAndDrop="true" OnNodeDrop="trvOrg_NodeDrop">
        <WebServiceSettings Path="~/WebBaseDefine/Forms/OrganizationChart.aspx" Method="LoadNodes" />
    </telerik:RadTreeView>
</div>
