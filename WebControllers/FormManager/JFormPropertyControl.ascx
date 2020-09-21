<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="JFormPropertyControl.ascx.cs" Inherits="WebControllers.FormManager.JFormPropertyControl" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>

<table>
    <tr>
        <td>
            <div>
                عنوان
                <br />
                <asp:TextBox runat="server" ID="txbTitle" />
            </div>
            <div>
                <table>
                    <tr>
                        <td>نوع فیلد
                            <br />
                            <asp:DropDownList runat="server" ID="txbDataType">
                            </asp:DropDownList>
                        </td>
                        <td>نوع مقداردهی
                            <br />
                            <asp:DropDownList runat="server" ID="txbListType">
                            </asp:DropDownList>
                        </td>
                        <td>ترتیب
                            <br />
                            <asp:TextBox runat="server" ID="txbOrder" />
                        </td>
                    </tr>
                </table>
            </div>
            <div>
                <table>
                    <tr>
                        <td>
                            <asp:CheckBox Text="مشاهده برای همه" runat="server" ID="chkAllView" Checked="true" OnCheckedChanged="chkAllView_CheckedChanged" />
                        </td>
                        <td>
                            <asp:CheckBox ID="chkAllEdit" Text="ویرایش برای همه" runat="server" Checked="true" OnCheckedChanged="chkAllEdit_CheckedChanged" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <div style="width: 200px; height: 300px; overflow-y: auto">
                                <asp:CheckBoxList runat="server" ID="clbPostViewList">
                                </asp:CheckBoxList>
                            </div>
                        </td>
                        <td>
                            <div style="width: 200px; height: 300px; overflow-y: auto">
                                <asp:CheckBoxList runat="server" ID="clbPostEditList">
                                </asp:CheckBoxList>
                            </div>
                        </td>
                    </tr>
                </table>
            </div>
        </td>
        <td>لیست مقادیر
            <br />
            <asp:TextBox runat="server" ID="txbListValue" TextMode="MultiLine" Height="393px" Width="228px" />
        </td>

    </tr>
</table>
<telerik:RadButton runat="server" ID="btnSave" Text="ذخیره" AutoPostBack="true" Width="100px" Height="35px" OnClick="btnSave_Click" />
<telerik:RadButton runat="server" ID="btnClose" Text="بستن" AutoPostBack="true" Width="100px" Height="35px" OnClick="btnClose_Click" />
