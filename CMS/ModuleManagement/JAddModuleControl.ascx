<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="JAddModuleControl.ascx.cs" Inherits="CMS.ModuleManagement.JAddModuleControl" %>
<%@ Register Assembly="CMSClassLibrary" Namespace="CMSClassLibrary.Controls" TagPrefix="JJson" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="Telerik" %>




<Telerik:RadTabStrip runat="server" ID="RadTabs" SelectedIndex="0" Width="100%" MultiPageID="RadMultiPage1">
    <Tabs>
        <Telerik:RadTab Text="مشخصات ماژول" PageViewID="mdSpecifications"></Telerik:RadTab>

    </Tabs>
</Telerik:RadTabStrip>

<Telerik:RadMultiPage ID="RadMultiPage1" runat="server" SelectedIndex="0" RenderSelectedPageOnly="true" Width="100%">
    <Telerik:RadPageView ID="mdSpecifications" runat="server">
        <table style="width: 80%">
            <tr>
                <td>کد ماژول:</td>
                <td>
                    <asp:Label ID="lblCode" runat="server"></asp:Label>
                </td>
                <td></td>
            </tr>
            <tr>
                <td>عنوان :
                </td>
                <td>
                    <JJson:JJsonTextBox ID="txtName" runat="server"></JJson:JJsonTextBox>
                </td>
                <td>نوع ماژول :
                </td>
                <td>
                    <JJson:JJsonDropDownList runat="server" ID="txtType"></JJson:JJsonDropDownList>
                </td>
            </tr>
           

            <tr>
                <td>موقعیت : 
                </td>
                <td>
                    <asp:DropDownList ID="txtPosition" runat="server">
                        <asp:ListItem Text="top" Value="top"></asp:ListItem>
                        <asp:ListItem Text="content1" Value="content1"></asp:ListItem>
                        <asp:ListItem Text="side" Value="side"></asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>ترتیب : 
                </td>
                <td>
                    <JJson:JJsonNumericTextBox ID="txtOrder" runat="server"></JJson:JJsonNumericTextBox>
                </td>
            </tr>
            <tr>
                
            
                <td>وضعیت :
                </td>
                <td>
                    <JJson:JEnabled ID="txtState" runat="server" TrueString="Enabled" FalseString="Disabled" TrueText="فعال" FalseText="غیرفعال" />

                </td>
                <td>پارامتر : 
                </td>
                <td colspan="3">
                    <JJson:JJsonTextBox ID="txtParams" runat="server" Width="300"></JJson:JJsonTextBox>
                </td>
               
            </tr>
            <tr>
                <asp:PlaceHolder ID="ParameterPlaceHolder" runat="server"></asp:PlaceHolder>
            </tr>
            <tr>
                <td>
                    <JJson:JJsonButton ID="btnOK" Text="ذخیره" runat="server" Event="click" />
                </td>
                <td>
                    <asp:Button ID="btnCancel" Text="انصراف" runat="server" OnClick="btnCancel_Click" />
                </td>
            </tr>
        </table>
    </Telerik:RadPageView>
</Telerik:RadMultiPage>
