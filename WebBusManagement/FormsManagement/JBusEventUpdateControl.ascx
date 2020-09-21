<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="JBusEventUpdateControl.ascx.cs" Inherits="WebBusManagement.FormsManagement.JBusEventUpdateControl" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>

<div class="BigTitle">وقایع</div>
<table style="width: 500px">
    <tr class="Table_RowB">
        <td style="width: 150px">نام واقعه:</td>
        <td>
            <telerik:RadTextBox runat="server" ID="txtTitle" Width="100%"></telerik:RadTextBox></td>
    </tr>
    <tr class="Table_RowC">
        <td style="width: 150px">وضعیت اتوبوس:</td>
        <td>
          <telerik:RadComboBox runat="server" ID="cmbBusActive" Width="100%" Filter="Contains">
                <Items>
                    <telerik:RadComboBoxItem Value="0" Text="غیر فعال" Selected="true" />
                    <telerik:RadComboBoxItem Value="1" Text="فعال" />
                </Items>
            </telerik:RadComboBox>
        </td>
    </tr>
    <tr class="Table_RowC">
        <td style="width: 150px">وضعیت راننده:</td>
        <td>
             <telerik:RadComboBox runat="server" ID="cmbDriverActive" Width="100%" Filter="Contains">
                <Items>
                    <telerik:RadComboBoxItem Value="0" Text="غیر فعال" Selected="true" />
                    <telerik:RadComboBoxItem Value="1" Text="فعال" />
                </Items>
            </telerik:RadComboBox>
        </td>
    </tr>
</table>
<div class="FormButtons">
    <telerik:RadButton runat="server" ID="btnSave" Text="ذخیره" AutoPostBack="true" Width="100px" Height="35px" OnClick="btnSave_Click" />
    <telerik:RadButton runat="server" ID="btnClose" Text="بازگشت" OnClientClicked="CloseDialog" AutoPostBack="false" Width="100px" Height="35px" />
     <telerik:RadButton runat="server" ID="btnDelete" Text="حذف" AutoPostBack="true" Width="100px" Height="35px" OnClick="btnDelete_Click" CssClass="floatLeft" OnClientClicking="OnClientClicking" />
</div>
