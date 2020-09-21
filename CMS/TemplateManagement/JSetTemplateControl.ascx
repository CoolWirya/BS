<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="JSetTemplateControl.ascx.cs" Inherits="CMS.TemplateManagement.JSetTemplateControl" %>
<%@ Register Assembly="CMSClassLibrary" Namespace="CMSClassLibrary.Controls" TagPrefix="JJson" %>
<%@ Register Assembly="CMSClassLibrary" Namespace="CMSClassLibrary.Components" TagPrefix="cc1" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="Telerik" %>
<Telerik:RadTabStrip runat="server" ID="RadTabs" SelectedIndex="0" Width="100%" MultiPageID="RadMultiPage1">
    <Tabs>
        <Telerik:RadTab Text="مشخصات" PageViewID="mdSpecifications"></Telerik:RadTab>

    </Tabs>
</Telerik:RadTabStrip>

<Telerik:RadMultiPage ID="RadMultiPage1" runat="server" SelectedIndex="0" RenderSelectedPageOnly="true" Width="100%">
    <Telerik:RadPageView ID="mdSpecifications" runat="server">
        <input type="hidden" id="hdnPCode" runat="server" />
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
                    <asp:Label ID="sitelbl" runat="server"></asp:Label>
                </td>
                <td>
                    <JJson:JJsonTextBox ID="txtSite" runat="server"></JJson:JJsonTextBox>
                </td>
                 <td>
                    <asp:Label ID="templatelbl" runat="server"></asp:Label>
                </td>
                <td>
                    <JJson:JJsonDropDownList ID="txtTemplate" runat="server">
                        
                    </JJson:JJsonDropDownList>
                </td>
                
            </tr>

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