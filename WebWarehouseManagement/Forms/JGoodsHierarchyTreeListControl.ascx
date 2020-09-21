<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="JGoodsHierarchyTreeListControl.ascx.cs" Inherits="WebWarehouseManagement.Forms.JGoodsHierarchyTreeListControl" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>

<telerik:RadCodeBlock ID="RadCodeBlock1" runat="server">
    <script type="text/javascript">
        function RefreshGrid() {
            window.location = document.URL;
        }
    </script>
</telerik:RadCodeBlock>
<div style="width: 100%">
    <telerik:RadToolBar runat="server" ID="tbrActions" OnButtonClick="tbrActions_ButtonClick" Width="100%">
        <Items>
            <telerik:RadToolBarButton ImageUrl="~/Images/Controls/toolbar_edit.png" Text="ویرایش دسته بندی" Value="EditNode"></telerik:RadToolBarButton>
            <telerik:RadToolBarButton IsSeparator="true"></telerik:RadToolBarButton>
            <telerik:RadToolBarButton ImageUrl="~/Images/Controls/toolbar_add.png" Text="افزودن زیرمجموعه" Value="AddSubNode"></telerik:RadToolBarButton>
            <telerik:RadToolBarButton ImageUrl="~/Images/Controls/toolbar_add.png" Text="افزودن دسته بندی اصلی" Value="AddMainNode"></telerik:RadToolBarButton>
            <telerik:RadToolBarButton IsSeparator="true"></telerik:RadToolBarButton>
            <telerik:RadToolBarButton IsSeparator="true"></telerik:RadToolBarButton>
            <telerik:RadToolBarButton IsSeparator="true"></telerik:RadToolBarButton>
            <telerik:RadToolBarDropDown ImageUrl="~/Images/Controls/toolbar_delete.png" Text="حذف">
                <Buttons>
                    <telerik:RadToolBarButton Text="حذف دسته بندی و انتقال زیرمجموعه ها به رده بالاتر" Value="DeleteNodeAndMove"></telerik:RadToolBarButton>
                    <telerik:RadToolBarButton IsSeparator="true"></telerik:RadToolBarButton>
                    <telerik:RadToolBarButton IsSeparator="true"></telerik:RadToolBarButton>
                    <telerik:RadToolBarButton Text="حذف دسته بندی و زیرمجموعه ها" Value="DeleteNodeFully"></telerik:RadToolBarButton>
                </Buttons>
            </telerik:RadToolBarDropDown>
        </Items>
    </telerik:RadToolBar>
</div>
<div style="width: 100%; position: fixed; top: 70px; bottom: 0px; overflow: scroll">
    <telerik:RadTreeView runat="server" ID="trvHirearchy" EnableDragAndDropBetweenNodes="true" EnableDragAndDrop="true" OnNodeDrop="trvHirearchy_NodeDrop" CheckChildNodes="true">
        <WebServiceSettings Path="~/WebWarehouseManagement/wmWarehouseManagement.aspx" Method="LoadGoodsHierarchyNodes" />
    </telerik:RadTreeView>
</div>
