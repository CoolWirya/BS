<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="JAgentUpdateControl.ascx.cs" Inherits="WebManagementShare.Forms.JAgentUpdateControl" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register Src="~/WebControllers/MainControls/Persons/JSearchPersonControl.ascx" TagPrefix="uc1" TagName="JSearchPersonControl" %>
<%@ Register Src="~/WebControllers/MainControls/Date/JDateControl.ascx" TagPrefix="uc1" TagName="JDateControl" %>

<div class="BigTitle">وکلا</div>
<div class="FormContent" style="top: 40px">
    <uc1:JSearchPersonControl runat="server" id="JSearchPersonControl"/>
                <table style="width:100%">
                    <tr class="Table_RowC">
                        <td>
                            <label>وضعیت:</label>
                       </td>
                        <td>
                            <telerik:RadComboBox ID="cmbEmploymentStatus" runat="server">
                                <Items>
                                    <telerik:RadComboBoxItem Text="رسمی" Value="Formal"/>
                                    <telerik:RadComboBoxItem Text="غیررسمی" Value="NotFormal" Selected="true"/>
                                </Items>
                            </telerik:RadComboBox>
                        </td>
                    </tr>
                    <tr class="Table_RowB">
                        <td style="width:20%">
                            <label>تعداد سهم مورد وکالت:</label>
                       </td>
                        <td style="width:30%">
                            <asp:Label Text="تعداد سهم:" runat="server" ID="lblShareCount" />
                        </td>
                        <td style="width:20%">
                            <label>تعداد موکلین:</label>
                       </td>
                        <td style="width:30%">
                            <asp:Label Text="تعداد سهم:" runat="server" ID="lblPersonCount" />
                        </td>
                    </tr>
                    <tr class="Table_RowC">
                        <td>
                            <label>تاریخ شروع وکالت:</label>
                       </td>
                        <td>
                            <uc1:JDateControl runat="server" id="txtStartDate" />
                        </td>
                        <td>
                            <label>تاریخ اتمام وکالت:</label>
                       </td>
                        <td>
                            <uc1:JDateControl runat="server" id="txtEndDate" />
                        </td>
                    </tr>
                </table>
</div>
<div class="FormButtons">
    <telerik:RadButton runat="server" ID="btnSave" Text="ثبت" AutoPostBack="true" Width="100px" OnClick="btnSave_Click" Height="35px" ValidationGroup="Bus" />
    <telerik:RadButton runat="server" ID="btnClose" Text="بازگشت" OnClientClicked="CloseDialog" AutoPostBack="false" Width="100px" Height="35px" />
<%--    <telerik:RadButton runat="server" ID="btnDelete" Text="حذف" AutoPostBack="true" Width="100px" Height="35px" OnClick="btnDelete_Click" CssClass="floatLeft" OnClientClicking="OnClientClicking" />--%>
</div>