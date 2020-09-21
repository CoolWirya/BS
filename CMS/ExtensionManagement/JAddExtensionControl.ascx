<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="JAddExtensionControl.ascx.cs" Inherits="CMS.ExtensionManagement.JAddExtensionControl" %>
<%@ Register Assembly="CMSClassLibrary" Namespace="CMSClassLibrary.Controls" TagPrefix="JJson" %>
<%@ Register Assembly="CMSClassLibrary" Namespace="CMSClassLibrary.Components" TagPrefix="cc1" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="Telerik" %>
<Telerik:RadTabStrip runat="server" ID="RadTabs" SelectedIndex="0" Width="100%" MultiPageID="RadMultiPage1">
    <Tabs>
        <Telerik:RadTab Text="مشخصات افزونه" PageViewID="mdSpecifications"></Telerik:RadTab>

    </Tabs>
</Telerik:RadTabStrip>

<Telerik:RadMultiPage ID="RadMultiPage1" runat="server" SelectedIndex="0" RenderSelectedPageOnly="true" Width="100%">
    <Telerik:RadPageView ID="mdSpecifications" runat="server">
        <input type="hidden" id="hdnPCode" runat="server" />
        <input type="hidden" id="hdnDateForInsert" runat="server" />
        <input type="hidden" id="hdnDateForUpdate" runat="server" />
        <table style="width: 80%">
          
            <tr>
                <td>
                    <asp:Label ID="Codelbl" runat="server"></asp:Label></td>
                <td>
                    <asp:Label ID="lblCode" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Titlelbl" runat="server"></asp:Label>
                </td>
                <td>
                    <JJson:JJsonTextBox ID="txtName" runat="server"></JJson:JJsonTextBox>
                </td>
                <td>
                    <asp:Label ID="Statelbl" runat="server"></asp:Label>
                </td>
                <td>
                    <JJson:JEnabled ID="txtState" runat="server" TrueString="Enabled" FalseString="Disabled"/>
                </td>
            </tr>
            
            <tr>
                <td>
                    <asp:Label ID="Typelbl" runat="server"></asp:Label>
                </td>
                <td>
                    <JJson:JJsonDropDownList ID="txtType" runat="server">
                        
                    </JJson:JJsonDropDownList>
                </td>
                <td>
                    <asp:Label ID="Paramlbl" runat="server"></asp:Label>
                </td>
                <td>
                   <JJson:JJsonTextBox ID="txtParam" runat="server"></JJson:JJsonTextBox>
                </td>

            </tr>
            <tr>
                <td>
                    <asp:Label ID="Classlbl" runat="server"></asp:Label>
                </td>
                <td colspan="3">
                    <JJson:JJsonTextBox ID="txtClass" runat="server"></JJson:JJsonTextBox>
                </td>
            </tr>
            
            <tr>
                <td>
                    <JJson:JJsonButton ID="btnOK" runat="server" Event="click" />
                </td>
                <td>
                    <asp:Button ID="btnCancel" runat="server"  OnClick="btnCancel_Click"/>
                </td>
            </tr>
        </table>
        
    </Telerik:RadPageView>
</Telerik:RadMultiPage>