<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="JDictionaryUpdateControl.ascx.cs" Inherits="WebBusManagement.FormsMaintenance.JDictionaryUpdateControl" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>

<div class="BigTitle">لغت نامه</div>
<table style="width: 500px">
    <tr class="Table_RowB">
        <td style="width: 150px">عبارت:</td>
        <td>
            <telerik:RadTextBox runat="server" ID="txtName" Width="100%"></telerik:RadTextBox>
        </td>
    </tr>
     <tr class="Table_RowC">
        <td style="width: 150px">ترجمه:</td>
        <td>
            <telerik:RadTextBox runat="server" ID="txtText" Width="100%"></telerik:RadTextBox>
        </td>
    </tr>
    <tr class="Table_RowB">
        <td style="width: 150px">زبان:</td>
        <td>
            <telerik:RadComboBox runat="server" ID="cmbLang" Width="80px" Filter="Contains">
                <Items>
                    <telerik:RadComboBoxItem Text="فارسی" Value="Fa" Selected="true"/>
                    <telerik:RadComboBoxItem Text="انگلیسی" Value="En" />
                </Items>
            </telerik:RadComboBox>
        </td>
    </tr>
</table>
<div class="FormButtons">
<telerik:RadButton runat="server" ID="btnSave" Text="ذخیره" AutoPostBack="true" Width="100px" Height="35px" OnClick="btnSave_Click" />
<telerik:RadButton runat="server" ID="btnClose" Text="بازگشت" OnClientClicked="CloseDialog" AutoPostBack="false" Width="100px" Height="35px" OnClick="btnClose_Click" />
<telerik:RadButton runat="server" ID="btnDelete" Text="حذف" AutoPostBack="true" Width="100px" Height="35px" OnClick="btnDelete_Click" />
</div>
