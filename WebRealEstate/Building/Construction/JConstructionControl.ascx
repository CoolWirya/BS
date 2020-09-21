<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="JConstructionControl.ascx.cs" Inherits="WebRealEstate.Building.Construction.JConstructionControl" %>
<%@ Register Assembly="JJson" Namespace="JJson.Controls" TagPrefix="JJson" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register Src="~/WebControllers/MainControls/Grid/JGridViewControl.ascx" TagPrefix="uc1" TagName="JGridViewControl" %>

<table>
    <tr>
        <td>شماره مجتمع / بازار :
        </td>
        <td>
            <JJson:JJsonTextBox ID="JJsonTxtNum" runat="server" Event="textchange"></JJson:JJsonTextBox></td>
        <td></td>
        <td></td>
        <td>عنوان :
        </td>
        <td>
            <JJson:JJsonTextBox ID="JJsonTxtCaption" runat="server" Event="textchange"></JJson:JJsonTextBox></td>
        <td></td>
    </tr>
    <tr>
        <td>متراژ زیربنا :
        </td>
        <td>
            <JJson:JJsonTextBox ID="JJsonTextBox1" runat="server" Event="textchange"></JJson:JJsonTextBox>
        </td>
        <td>متر مربع</td>
        <td></td>
        <td>مازاد زیربنا :
        </td>
        <td>
            <JJson:JJsonTextBox ID="JJsonTextBox2" runat="server" Event="textchange"></JJson:JJsonTextBox></td>
        <td>متر مربع</td>
    </tr>
    <tr>
        <td>
            <telerik:RadTabStrip ID="RadTabStrip1" runat="server" OnTabClick="RadTabStrip1_TabClick">
                <Tabs>
                    <telerik:RadTab Text="ویژگی واحد تجاری" PageViewID="KindRoom"></telerik:RadTab>
                </Tabs>
                <Tabs>
                    <telerik:RadTab Text="طبقات" PageViewID="Floors"></telerik:RadTab>
                </Tabs>
            </telerik:RadTabStrip>
            <telerik:RadMultiPage runat="server" ID="RadMultiPage1" SelectedIndex="0" RenderSelectedPageOnly="true" Width="100%">
                <telerik:RadPageView runat="server" ID="KindRoom">
                    <div>
                        <uc1:JGridViewControl runat="server" id="JGridViewControl" />
                    </div>
                </telerik:RadPageView>
                <telerik:RadPageView runat="server" ID="Floors">
                    <table>
                        <tr>
                            <td>شماره طبقه :</td>
                            <td>
                                <JJson:JJsonTextBox ID="JJsonTxtNumFloor" runat="server" Event="textchange"></JJson:JJsonTextBox></td>
                            <td></td>
                            <td></td>
                            <td></td>
                            <td></td>
                            <td></td>
                        </tr>
                        <tr>
                            <td>عنوان طبقه :</td>
                            <td>
                                <JJson:JJsonTextBox ID="JJsonTextBox3" runat="server" Event="textchange"></JJson:JJsonTextBox></td>
                            <td></td>
                            <td></td>
                            <td></td>
                            <td>
                                <JJson:JJsonButton ID="JJsonButton1" runat="server" Event="click" Text="اضافه" /></td>
                            <td>
                                <JJson:JJsonButton ID="JJsonButton2" runat="server" Event="click" Text="حذف" /></td>
                        </tr>
                        <tr>
                            <td>متراژ :</td>
                            <td>
                                <JJson:JJsonTextBox ID="JJsonTextBox4" runat="server" Event="textchange"></JJson:JJsonTextBox></td>
                            <td>متر مربع</td>
                            <td></td>
                            <td></td>
                            <td></td>
                            <td></td>
                   </tr>
                        <tr>
                            <td>توضیحات :</td>
                            <td>
                                <JJson:JJsonTextBox ID="JJsonTextBox5" runat="server" Event="textchange"></JJson:JJsonTextBox></td>
                            <td></td>
                            <td></td>
                            <td></td>
                            <td></td>
                            <td></td>
                        </tr>
                        <tr>
                            <td>
                                <uc1:JGridViewControl runat="server" id="JGridViewControl1" />
                            </td>

                        </tr>
                    </table>
                </telerik:RadPageView>
            </telerik:RadMultiPage>
        </td>

    </tr>
    <tr>
        <td>
            <JJson:JJsonButton ID="JJsonBtnAgree" runat="server" Event="click" Text="تایید" /></td>
        <td>
            <JJson:JJsonButton ID="JJsonBtnSave" runat="server" Event="click" Text="ذخیره" /></td>
        <td></td>
        <td></td>
        <td></td>
        <td></td>
        <td>
            <JJson:JJsonButton ID="JJsonBtnExit" runat="server" Event="click" Text="خروج" /></td>
    </tr>
</table>
