<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="JAddContentControl.ascx.cs" Inherits="CMS.ContentManagement.JAddContentControl" %>
<%@ Register Assembly="CMSClassLibrary" Namespace="CMSClassLibrary.Controls" TagPrefix="JJson" %>
<%@ Register Assembly="CMSClassLibrary" Namespace="CMSClassLibrary.Components" TagPrefix="cc1" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="Telerik" %>
<Telerik:RadTabStrip runat="server" ID="RadTabs" SelectedIndex="0" Width="100%" MultiPageID="RadMultiPage1">
    <Tabs>
        <Telerik:RadTab Text="مشخصات ماژول" PageViewID="mdSpecifications"></Telerik:RadTab>

    </Tabs>
</Telerik:RadTabStrip>

<Telerik:RadMultiPage ID="RadMultiPage1" runat="server" SelectedIndex="0" RenderSelectedPageOnly="true" Width="100%">
    <Telerik:RadPageView ID="mdSpecifications" runat="server">
        <input type="hidden" id="hdnPCode" runat="server" />
        <input type="hidden" id="hdnDateForInsert" runat="server" />
        <input type="hidden" id="hdnDateForUpdate" runat="server" />
        <input type="hidden" id="elrteText" runat="server"  /> 
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
                    <JJson:JEnabled ID="txtState" runat="server" TrueString="Enabled" FalseString="Disabled" TrueText="فعال" FalseText="غیرفعال" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Statuslbl" runat="server"></asp:Label>
                </td>
                <td>
                    <JJson:JJsonDropDownList ID="txtStatus" runat="server">
                        
                    </JJson:JJsonDropDownList>
                </td>
                <td>
                    <asp:Label ID="Accesslbl" runat="server"></asp:Label>
                </td>
                <td>
                    <JJson:JJsonDropDownList ID="txtAccess" runat="server">
                        <asp:ListItem Text="Public" Value="1"></asp:ListItem>
                    </JJson:JJsonDropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Categorylbl" runat="server"></asp:Label>
                </td>
                <td>
                    <JJson:JJsonDropDownList ID="txtCategory" runat="server">
                        <asp:ListItem Text="اطلاعات" Value="1"></asp:ListItem>
                        <asp:ListItem Text="انواع مبلمان" Value="2"></asp:ListItem>
                    </JJson:JJsonDropDownList>
                </td>
                

            </tr>
            <tr>
                <td>
                    <asp:Label ID="Textlbl" runat="server"></asp:Label>
                </td>
            </tr>
            <tr style="margin-top: 5px">
                <td></td>
                <td colspan="3">
                    <%--<cc1:JContentManager ID="ct" runat="server"></cc1:JContentManager>--%>
                    <JJson:JJsonEditor ID="txtText" runat="server"></JJson:JJsonEditor>
                </td>
            </tr>
            <tr>
                <td>
                    <JJson:JJsonButton ID="btnOK" runat="server" Event="click" OnClientClick="getContent();" />
                </td>
                <td>
                    <asp:Button ID="btnCancel" runat="server" OnClick="btnCancel_Click" />
                </td>
            </tr>
        </table>
        
    </Telerik:RadPageView>
</Telerik:RadMultiPage>