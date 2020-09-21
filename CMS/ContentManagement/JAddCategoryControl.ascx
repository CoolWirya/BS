<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="JAddCategoryControl.ascx.cs" Inherits="CMS.ContentManagement.JAddCategoryControl" %>
<%@ Register Assembly="CMSClassLibrary" Namespace="CMSClassLibrary.Controls" TagPrefix="JJson" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="Telerik" %>

<Telerik:RadTabStrip runat="server" ID="RadTabs" SelectedIndex="0" Width="100%" MultiPageID="RadMultiPage1">
    <Tabs>
        <Telerik:RadTab Text="تعریف دسته بندی" PageViewID="ctSpecifications"></Telerik:RadTab>

    </Tabs>
</Telerik:RadTabStrip>

<Telerik:RadMultiPage ID="RadMultiPage1" runat="server" SelectedIndex="0" RenderSelectedPageOnly="true" Width="100%">
    <Telerik:RadPageView ID="ctSpecifications" runat="server">
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
                    <JJson:JEnabled ID="txtState" runat="server" TrueString="Enabled" FalseString="Disabled" TrueText="فعال" FalseText="غیرفعال" />
                </td>
            </tr>
            <tr>
               
                <td>
                    <asp:Label ID="Accesslbl" runat="server"></asp:Label>
                </td>
                <td>
                    <JJson:JJsonDropDownList ID="txtAccess" runat="server">
                        <asp:ListItem Text="Public" Value="1"></asp:ListItem>
                    </JJson:JJsonDropDownList>
                </td>
            
                <td>
                    <asp:Label ID="Parentlbl" runat="server"></asp:Label>
                </td>
                <td>
                    <JJson:JJsonDropDownList ID="txtParent" runat="server">
                        
                    </JJson:JJsonDropDownList>
                </td>
               

            </tr>
           <tr>
               <td>
                   <asp:Label ID="Paramslbl" runat="server"></asp:Label>
               </td>
               <td>
                   <JJson:JJsonTextBox ID="txtParams" runat="server" TextMode="MultiLine" Width="300"></JJson:JJsonTextBox>
               </td>
           </tr>
            <tr>
               <td>
                   <asp:Label ID="Desclbl" runat="server"></asp:Label>
               </td>
               <td>
                   <JJson:JJsonTextBox ID="txtDesc" runat="server" TextMode="MultiLine" Width="300"></JJson:JJsonTextBox>
               </td>
           </tr>
            <tr>
                <td>
                    <JJson:JJsonButton ID="btnOK" runat="server" Event="click"  />
                </td>
                <td>
                    <asp:Button ID="btnCancel" runat="server" OnClick="btnCancel_Click" />
                </td>
            </tr>
        </table>
        
    </Telerik:RadPageView>
</Telerik:RadMultiPage>