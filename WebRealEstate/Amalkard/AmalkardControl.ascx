<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AmalkardControl.ascx.cs" Inherits="WebRealEstate.Amalkard.AmalkardControl" %>
<%@ Register Assembly="JJson" Namespace="JJson.Controls" TagPrefix="JJson" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>

<table>
    <tr>
        <td>
            <telerik:RadTabStrip runat="server" ID="RadTabStrip1" OnTabClick="RadTabStrip1_TabClick"
                SelectedIndex="0" MultiPageID="RadMultiPage1" Width="100%">
                <Tabs>
                    <telerik:RadTab Text="اخطاریه ها" PageViewID="rpvWarning">
                    </telerik:RadTab>
                    <telerik:RadTab Text="تعهدات کتبی" PageViewID="rpvTaahod">
                    </telerik:RadTab>
                    <telerik:RadTab Text="خدمات" PageViewID="rpvService">
                    </telerik:RadTab>
                </Tabs>
            </telerik:RadTabStrip>
            <telerik:RadMultiPage runat="server" ID="RadMultiPage1" SelectedIndex="0" RenderSelectedPageOnly="true"
                Width="100%">
                <telerik:RadPageView runat="server" ID="rpvWarning">
                    <div runat="server" id="divNewProperty" style="display: block">
                        <div>
                            <telerik:RadGrid ID="gridView1" runat="server"></telerik:RadGrid>
                        </div>
                        <div>
                            <telerik:RadButton runat="server" ID="btnNew" OnClientClicked="ShowProperties" AutoPostBack="false" Text="جدید"></telerik:RadButton>
                        </div>
                </div>   
                </telerik:RadPageView>
           <telerik:RadPageView runat="server" ID="rpvTaahod">
                    <div runat="server" id="div1" style="display: block">
                        <div>
                            <telerik:RadGrid ID="RadGrid1" runat="server"></telerik:RadGrid>
                        </div>
                        <div>
                            <telerik:RadButton runat="server" ID="RadButton1" OnClientClicked="ShowProperties" AutoPostBack="false" Text="جدید"></telerik:RadButton>
                        </div>
                   </div>
                </telerik:RadPageView>
                  <telerik:RadPageView runat="server" ID="rpvServer">
                    <div runat="server" id="div2" style="display: block">
                        <div>
                            <telerik:RadGrid ID="RadGrid2" runat="server"></telerik:RadGrid>
                        </div>
                        <div>
                            <telerik:RadButton runat="server" ID="RadButton2" OnClientClicked="ShowProperties" AutoPostBack="false" Text="جدید"></telerik:RadButton>
                        </div>
                   </div>
                </telerik:RadPageView>
            </telerik:RadMultiPage>
        </td>
    </tr>
</table>
