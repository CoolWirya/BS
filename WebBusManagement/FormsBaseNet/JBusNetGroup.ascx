<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="JBusNetGroup.ascx.cs" Inherits="WebBusManagement.FormsBaseNet.JBusNetGroup" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>

<%@ Register Assembly="WebControllers" Namespace="WebControllers.MainControls.Grid" TagPrefix="cc1" %>

<%@ Register Src="~/WebControllers/MainControls/CustomListSelector/JCustomListSelectorControl.ascx" TagPrefix="uc1"  TagName="JCustomListSelectorControl" %>

<%@ Register Src="~/WebControllers/Property/JPropertyViewControl.ascx" TagPrefix="uc1" TagName="JPropertyViewControl" %>
<%@ Register Src="~/WebControllers/MainControls/Date/JDateControl.ascx" TagPrefix="uc1" TagName="JDateControl" %>
<%@ Register Src="~/WebControllers/MainControls/Persons/JSearchPersonControl.ascx" TagPrefix="uc1" TagName="JSearchPersonControl" %>
<%@ Register Src="~/WebControllers/ArchiveDocument/JArchiveControl.ascx" TagPrefix="uc1" TagName="JArchiveControl" %>

<style type="text/css">
    .KeyCol {
        width: 100px;
    }
</style>




<div id="control_Lines_RadPageView1">
		<input type="hidden" id="hidEditCode" name="hidEditCode" value="0" runat="server" /> 
            <table style="width: 1000px">
                <tbody><tr class="Table_RowB">
                    <tr class="Table_RowB">
                <td style="width: 150px">شخص:</td>
                <td>
                   
                </td>
            </tr>
                   


                    <td style="width: 350px">نام گروه:</td>
                    <td>
                       
                          
                             <telerik:RadTextBox runat="server" ID="txtnameGroup"></telerik:RadTextBox>
                   
                        <span id="control_Lines_RequiredFieldValidatorTxtName" style="display:none;">*</span>
                    </td>
                </tr>
                
                    <%--  --%>
               
            </tbody></table>
    <telerik:RadButton runat="server" ID="BtnReport" Text="مشاهده گزارش" AutoPostBack="true" Width="100px" Height="35px" OnClick="BtnReport_Click" OnClientClicked="LockButton" />
      <telerik:RadButton runat="server" ID="btnSave" Text="ذخیره " AutoPostBack="true" Width="100px" Height="35px" OnClick="btnSave_Click"/>
<telerik:RadButton runat="server" ID="btnClose" Text="بازگشت" OnClientClicked="CloseDialog" AutoPostBack="false" Width="100px" Height="35px" />
<Table style="width: 100%; height: auto; margin-top: 15px">
    <tr>
        <td style="width: 100%; height: auto; overflow: auto"><cc1:JGridView runat="server" id="RadGridReport"></cc1:JGridView>
            
        </td>
    </tr>
</Table>
        
	</div>

