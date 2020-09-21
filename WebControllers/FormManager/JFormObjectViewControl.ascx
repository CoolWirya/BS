<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="JFormObjectViewControl.ascx.cs" Inherits="WebControllers.FormManager.JFormObjectViewControl" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register Src="~/WebControllers/Property/JPropertyViewControl.ascx" TagPrefix="uc1" TagName="JPropertyViewControl" %>
<%@ Register Src="~/WebAutomation/Refer/JReferViewControl.ascx" TagPrefix="uc1" TagName="JReferViewControl" %>k
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

<telerik:RadTabStrip runat="server" ID="RadTabStrip1"
    SelectedIndex="0" MultiPageID="RadMultiPage1" Width="100%">
    <Tabs>
        <telerik:RadTab Text="اطلاعات" PageViewID="rpvInfo">
        </telerik:RadTab>
        <telerik:RadTab Text="ارجاعات" PageViewID="rpvRefer">
        </telerik:RadTab>
    </Tabs>
</telerik:RadTabStrip>
<telerik:RadMultiPage runat="server" ID="RadMultiPage1" SelectedIndex="0"
    Width="100%">
    <telerik:RadPageView runat="server" ID="rpvInfo">
        <div runat="server" id="divNewProperty" style="display: none">
            <div>
                <telerik:RadButton runat="server" ID="btnSaveProperty" AutoPostBack="true" Image-ImageUrl="~/Images/Controls/Save.png" Width="32" Height="32" Text="ذخیره" OnClick="btnSaveProperty_Click"></telerik:RadButton>
                <telerik:RadButton runat="server" ID="btnBack" OnClientClicked="ShowProperties" AutoPostBack="false" Image-ImageUrl="~/Images/Controls/Return.png" Width="32" Height="32" Text="بازگشت"></telerik:RadButton>
            </div>
            <uc1:JPropertyViewControl runat="server" ID="jPropertyViewControl1" />

        </div>
        <div runat="server" id="divProperties">
            <div>
                <telerik:RadButton runat="server" ID="btnAdd" OnClientClicked="ShowNewProperty" AutoPostBack="false" Image-ImageUrl="~/Images/Controls/toolbar_add.png" Width="32" Height="32" Text="جدید"></telerik:RadButton>
                <telerik:RadButton runat="server" ID="btnDelete" AutoPostBack="false" Image-ImageUrl="~/Images/Controls/toolbar_delete.png" Width="32" Height="32" Text="حذف انتخاب شده ها"></telerik:RadButton>
            </div>

        </div>
    </telerik:RadPageView>
    <telerik:RadPageView runat="server" ID="rpvRefer">
        <uc1:JReferViewControl runat="server" id="jReferViewControl" />
    </telerik:RadPageView>
</telerik:RadMultiPage>
<telerik:RadButton runat="server" ID="btnRefer" Text="ارجاع" AutoPostBack="true" Width="100px" Height="35px" OnClick="btnRefer_Click" />
<telerik:RadButton runat="server" ID="btnSave" Text="ذخیره" AutoPostBack="true" Width="100px" Height="35px" OnClick="btnSave_Click" />
<telerik:RadButton runat="server" ID="btnClose" Text="بازگشت" OnClientClicked="CloseDialog" AutoPostBack="false" Width="100px" Height="35px" />