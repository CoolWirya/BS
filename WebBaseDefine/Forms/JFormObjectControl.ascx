<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="JFormObjectControl.ascx.cs" Inherits="WebBaseDefine.Forms.JFormObjectControl" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register Src="~/WebControllers/Property/JPropertyViewControl.ascx" TagPrefix="uc1" TagName="JPropertyViewControl" %>
<%@ Register Src="~/WebAutomation/Refer/JReferViewControl.ascx" TagPrefix="uc11" TagName="JReferViewControl" %>


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

 
<script type="text/javascript">
    var UserControllerName = 'JFormObjectControl';
    var pClassName = 'WebBaseDefine_JWebBaseDefine_RealPerson';
    var FormCode = 1;
    var ObjCode=0;
    function InsertProp(ObjCode) {
        ShowWarining('در  حال بارگذاری ...', false, 3);
        return $.ajax({
            type: 'POST',
            url: '/Services/UserControllerActionService.asmx/InsertDataToFormController',
            data: '{"pCode":' + ObjCode + ', "UserControllerName":"' + UserControllerName + '","pClassName":"' + pClassName + '","FormCode":' + FormCode + '}',
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            error: function () {
                //var err = eval("(" + xhr.responseText + ")");
                alert(0);
            }
        });
    }

    function fun1() {
        var ObjCode = 1;
        //bale aghaye mohandes.mamnoonam k vaghtetoono dar ekhtiar bande gharar dadin.
        //mitoonam y soal auobosrani beporsam?
        //
        $.when(InsertProp(ObjCode)).done(function (result) {
            if (result.d) {
                alert(result.d);
                // result.d is a boolean
                //or true or false return?  equal to your c# function return value
                //fun1 bezaram to Click btn?
            }
        });
    }
    </script>

<script type="text/javascript">

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
    Width="100%">
    <telerik:RadPageView runat="server" ID="rpvInfo">
        <div runat="server" id="divNewProperty" style="display: block">
            <div>
                <telerik:RadButton runat="server" ID="btnSaveProperty" AutoPostBack="true" Image-ImageUrl="~/Images/Controls/Save.png" Width="32" Height="32" Text="ذخیره" OnClick="btnSaveProperty_Click"></telerik:RadButton>
                <telerik:RadButton runat="server" ID="btnBack" OnClientClicked="ShowProperties" AutoPostBack="false" Image-ImageUrl="~/Images/Controls/Return.png" Width="32" Height="32" Text="بازگشت"></telerik:RadButton>
            </div>
            <telerik:RadGrid runat="server" AutoGenerateColumns="true" ID="gridView2" OnItemDataBound="gridView2_ItemDataBound"  OnItemCommand="gridView2_ItemCommand" ></telerik:RadGrid>
            <asp:GridView runat="server" AutoGenerateColumns="true" OnRowDataBound="gridView_RowDataBound" OnRowCommand="gridView_RowCommand" ID="gridView" OnRowDeleting="gridView_RowDeleting" ></asp:GridView>
            <uc1:JPropertyViewControl runat="server" ID="jPropertyViewControl1" />
        </div>


        <div runat="server" id="divProperties">
            <div>
                <telerik:RadButton runat="server" ID="btnAdd" OnClientClicked="ShowNewProperty" AutoPostBack="false" Image-ImageUrl="~/Images/Controls/toolbar_add.png" Width="32" Height="32" Text="جدید"></telerik:RadButton>
                <telerik:RadButton runat="server" ID="btnDelete" AutoPostBack="false" Image-ImageUrl="~/Images/Controls/toolbar_delete.png" Width="32" Height="32" Text="حذف انتخاب شده ها"></telerik:RadButton>
            </div>
        </div>

        <div>

        </div>
    </telerik:RadPageView>
    <telerik:RadPageView runat="server" ID="rpvRefer">
        <uc11:JReferViewControl runat="server" id="jReferViewControl" />
    </telerik:RadPageView>
</telerik:RadMultiPage>
<telerik:RadButton runat="server" ID="btnRefer" Text="ارجاع" AutoPostBack="true" Width="100px" Height="35px" OnClick="btnRefer_Click" />
<telerik:RadButton runat="server" ID="btnSave" Text="ذخیره" AutoPostBack="true" Width="100px" Height="35px" onclientclick="return false;" onclick="btnSaveProperty_Click"  /> 
<input id="Button1" type="button" value="button" onclick="fun1()" />
<%--<telerik:RadButton runat="server" ID="btnClose" Text="بازگشت" OnClientClicked="CloseDialog" AutoPostBack="false" Width="100px" Height="35px" />--%>
<telerik:RadButton runat="server" ID="btnClose" Text="بازگشت" Width="100px" Height="35px" OnClick="btnClose_Click" />
