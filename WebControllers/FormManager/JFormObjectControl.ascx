<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="JFormObjectControl.ascx.cs" Inherits="WebControllers.FormManager.JFormObjectControl" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register Src="~/WebControllers/Property/JPropertyViewControl.ascx" TagPrefix="uc1" TagName="JPropertyViewControl" %>
<%@ Register Src="~/WebAutomation/Refer/JReferViewControl.ascx" TagPrefix="uc1" TagName="JReferViewControl" %>


<script type="text/javascript">
    function ShowNewProperty() {
        document.getElementById("<%=divNewProperty.ClientID %>").style.display = 'block';
        document.getElementById("<%=divProperties.ClientID %>").style.display = 'none';
    }

    function ShowProperties() {
        document.getElementById("<%=divNewProperty.ClientID %>").style.display = 'none';
        document.getElementById("<%=divProperties.ClientID %>").style.display = 'block';
    }
</script>

  


<telerik:RadTabStrip runat="server" ID="RadTabStrip1" OnTabClick="RadTabStrip1_TabClick"
    SelectedIndex="0" MultiPageID="RadMultiPage1" Width="100%">
    <Tabs>
        <telerik:RadTab Text="اطلاعات" PageViewID="rpvInfo">
        </telerik:RadTab>
        <telerik:RadTab Text="ارجاعات" PageViewID="rpvRefer">
        </telerik:RadTab>
    </Tabs>
</telerik:RadTabStrip>
<telerik:RadMultiPage runat="server" ID="RadMultiPage1" SelectedIndex="0" RenderSelectedPageOnly="true"
    Width="100%" Height="270">
    <telerik:RadPageView runat="server" ID="rpvInfo">
	    <div runat="server" id="div1" class="menu" style="float:right; max-height:250px; overflow-y:auto;">
		    <telerik:RadGrid runat="server" ID="SqlGrid" Enabled="false">
		    </telerik:RadGrid>
	    </div>
        <div runat="server" id="divNewProperty" style="float:right">
            <div runat="server" visible="false">
                <telerik:RadButton runat="server" ID="btnSaveProperty" AutoPostBack="true" Image-ImageUrl="~/Images/Controls/Save.png" Width="32" Height="32" Text="ذخیره" OnClick="btnSaveProperty_Click"></telerik:RadButton>
                <telerik:RadButton runat="server" ID="btnBack" OnClientClicked="ShowProperties" AutoPostBack="false" Image-ImageUrl="~/Images/Controls/Return.png" Width="32" Height="32" Text="بازگشت"></telerik:RadButton>
            </div>
            <telerik:RadGrid runat="server" AutoGenerateColumns="true" ID="gridView2" OnItemDataBound="gridView2_ItemDataBound" OnItemCommand="gridView2_ItemCommand"></telerik:RadGrid>
            <asp:GridView runat="server" AutoGenerateColumns="true" OnRowDataBound="gridView_RowDataBound" OnRowCommand="gridView_RowCommand" ID="gridView" OnRowDeleting="gridView_RowDeleting" ></asp:GridView>
            <uc1:JPropertyViewControl runat="server" ID="jPropertyViewControl1"/>
            <div runat="server" id="divProperties" visible="false">
                <div>
                    <telerik:RadButton runat="server" ID="btnAdd" OnClientClicked="ShowNewProperty" AutoPostBack="false" Image-ImageUrl="~/Images/Controls/toolbar_add.png" Width="32" Height="32" Text="جدید"></telerik:RadButton>
                    <telerik:RadButton runat="server" ID="btnDelete" AutoPostBack="false" Image-ImageUrl="~/Images/Controls/toolbar_delete.png" Width="32" Height="32" Text="حذف انتخاب شده ها"></telerik:RadButton>
                </div>
            </div>
        </div>
    </telerik:RadPageView>
    <telerik:RadPageView runat="server" ID="rpvRefer">
        <uc1:JReferViewControl runat="server" id="jReferViewControl" />
    </telerik:RadPageView>
</telerik:RadMultiPage>
<telerik:RadButton runat="server" ID="btnRefer" Text="ارجاع" AutoPostBack="true" Width="100px" Height="35px" OnClick="btnRefer_Click" />
<telerik:RadButton runat="server" ID="btnSave" Text="ذخیره" AutoPostBack="true" Width="100px" Height="35px" OnClick="btnSave_Click" />
    <telerik:RadButton runat="server" ID="btnPrint" Text="چاپ" AutoPostBack="true" Width="100px" Height="35px" OnClick="btnPrintClick"  OnClientClicked="LockButton" />

<%--<telerik:RadButton runat="server" ID="btnSaveProperties" Text="ذخیره" AutoPostBack="true" Width="100px" Height="35px" OnClick="btnSaveProperty_Click" />--%>
<%--<telerik:RadButton runat="server" ID="btnClose" Text="بازگشت" OnClientClicked="CloseDialog" AutoPostBack="false" Width="100px" Height="35px" />--%>
<telerik:RadButton runat="server" ID="btnClose" Text="بازگشت" Width="100px" Height="35px" OnClick="btnClose_Click" />
