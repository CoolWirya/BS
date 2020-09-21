<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TemplateItemList.ascx.cs" Inherits="WebProjectManagement.Forms.TemplateItemList" %>

<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>


<style>
    .treeviewPart1{
        color: blue;
    }
    .treeviewPart2{
        color: red;
    }
    .treeviewPart3{
        color:  green;
    }
</style>

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
            <telerik:RadToolBarButton ImageUrl="~/Images/Controls/toolbar_add.png" Text="افزودن آیتم اصلی" Value="AddMainNode" ></telerik:RadToolBarButton>
            <telerik:RadToolBarButton IsSeparator="true"></telerik:RadToolBarButton>
            <telerik:RadToolBarButton ImageUrl="~/Images/Controls/toolbar_add.png" Text="افزودن آیتم" Value="AddSubNode" ></telerik:RadToolBarButton>
            <telerik:RadToolBarButton IsSeparator="true"></telerik:RadToolBarButton>
            <telerik:RadToolBarButton ImageUrl="~/Images/Controls/toolbar_edit.png" Text="ویرایش آیتم" Value="EditNode"></telerik:RadToolBarButton>
            <telerik:RadToolBarButton IsSeparator="true"></telerik:RadToolBarButton>
            <telerik:RadToolBarDropDown ImageUrl="~/Images/Controls/toolbar_delete.png" Text="حذف">
                <Buttons>
                    <telerik:RadToolBarButton Text="حذف آیتم و انتقال زیرمجموعه ها به رده بالاتر" Value="DeleteNodeAndMove"></telerik:RadToolBarButton>
                    <telerik:RadToolBarButton IsSeparator="true"></telerik:RadToolBarButton>
                    <telerik:RadToolBarButton Text="حذف آیتم و زیرمجموعه ها" Value="DeleteNodeFully"></telerik:RadToolBarButton>
                </Buttons>
            </telerik:RadToolBarDropDown>
        </Items>
    </telerik:RadToolBar>
</div>
<div style="width: 100%; position: fixed; top: 70px; bottom: 0px; overflow: scroll">
    <telerik:RadTreeView runat="server" ID="trvOrg"  Font-Size="Larger">
        <WebServiceSettings Path="WebProjectManagement/Forms/Services.aspx" Method="LoadTemplateNodes"    />
    </telerik:RadTreeView>
</div>
<style>
    .pnlprompt{
        position: absolute;
    background-color: #ddd;
    margin: auto;
    top: 10%;
    left: 50%;
    border: solid;
    padding: 20px;
    }
</style>
<asp:Panel runat="server" ID="pnlPromptDeleteFully" CssClass="pnlprompt"></asp:Panel>
<asp:Panel runat="server" ID="pnlPromptDeleteAndMove" CssClass="pnlprompt"></asp:Panel>


    <script type="text/javascript">

        function OnClienClosedTheWindow(sender, args) {
            window.location.href = window.location.href;
        }
        function RefreshGrid() {
            window.location = document.URL;
        }
    </script>