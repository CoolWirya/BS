<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="JAddUsageControl.ascx.cs" Inherits="WebRealEstate.Building.UnitBuild.JAddUsageControl" %>
<%@ Register Assembly="JJson" Namespace="JJson.Controls" TagPrefix="JJson" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register Src="~/WebControllers/MainControls/Grid/JGridViewControl.ascx" TagPrefix="uc1" TagName="JGridViewControl" %>
<%@ Register Src="~/WebControllers/MainControls/Date/JDateControl.ascx" TagPrefix="uc1" TagName="JDateControl" %>
<%@ Register Src="~/WebControllers/MainControls/Date/JDateControl.ascx" TagPrefix="uc1" TagName="JDateControl" %>
<%@ Register Src="~/WebControllers/MainControls/Date/JDateControl.ascx" TagPrefix="uc1" TagName="JDateControl" %>
<%@ Register Src="~/WebControllers/MainControls/Date/JDateControl.ascx" TagPrefix="uc1" TagName="JDateControl" %>
<%@ Register Src="~/WebControllers/MainControls/Persons/JSearchPersonControl.ascx" TagPrefix="uc1" TagName="JSearchPersonControl" %>
<%@ Register Src="~/WebControllers/MainControls/Grid/JGridViewControl.ascx" TagPrefix="uc1" TagName="JGridViewControl" %>
<%@ Register Src="~/WebControllers/MainControls/Date/JDateControl.ascx" TagPrefix="uc1" TagName="JDateControl" %>
<%@ Register Src="~/WebControllers/MainControls/Grid/JGridViewControl.ascx" TagPrefix="uc1" TagName="JGridViewControl" %>
<%@ Register Src="~/WebControllers/MainControls/Grid/JGridViewControl.ascx" TagPrefix="uc2" TagName="JGridViewControl" %>
<%@ Register Src="~/WebControllers/MainControls/Date/JDateControl.ascx" TagPrefix="uc2" TagName="JDateControl" %>
<%@ Register Src="~/WebControllers/MainControls/Grid/JGridViewControl.ascx" TagPrefix="uc3" TagName="JGridViewControl" %>
<%@ Register Src="~/WebControllers/MainControls/Grid/JGridViewControl.ascx" TagPrefix="uc4" TagName="JGridViewControl" %>
<%@ Register Src="~/WebControllers/MainControls/Grid/JGridViewControl.ascx" TagPrefix="uc5" TagName="JGridViewControl" %>
<table>
    <tr>
        <td>
            <telerik:RadTabStrip ID="RadTabStrip2" runat="server" OnTabClick="RadTabStrip1_TabClick">
                <Tabs>
                    <telerik:RadTab Text="کاربری" PageViewID="rpvD1"></telerik:RadTab>
                </Tabs>
                <Tabs>
                    <telerik:RadTab Text="ویژگی ها" PageViewID="rpvD2"></telerik:RadTab>
                </Tabs>
            </telerik:RadTabStrip>
            <telerik:RadMultiPage runat="server" ID="RadMultiPage2" SelectedIndex="0" RenderSelectedPageOnly="true" Width="100%">
                <telerik:RadPageView runat="server" ID="rpvD1">
                    <table>
                        <tr>
                            <td>
                                کد کاربری :
                            </td>
                            <td>
                                <asp:TextBox ID="txtUserCode" runat="server"></asp:TextBox>
                            </td>
                            <td>

                            </td>
                            <td>
                                عنوان :
                            </td>
                            <td>
                                <asp:TextBox ID="txtTitle" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                شرح :
                            </td>
                            <td>
                                <asp:TextBox ID="txtDsc" runat="server"></asp:TextBox>
                            </td>
                            <td>

                            </td>
                            <td>

                            </td>
                            <td>

                            </td>
                        </tr>
                   </table>
                </telerik:RadPageView>
                 <telerik:RadPageView runat="server" ID="rpvD2">
                    <table>
                   </table>
                </telerik:RadPageView>
                 </telerik:RadMultiPage>
            </td>
        </tr>
    <tr>
        <td>
            <asp:Button ID="btnExit" runat="server" Text="خروج" /></td>
        <td>
            <asp:Button ID="btnSave" runat="server" Text="ذخیره" />
        </td>

    </tr>

            </table>