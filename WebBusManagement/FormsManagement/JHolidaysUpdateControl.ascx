<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="JHolidaysUpdateControl.ascx.cs" Inherits="WebBusManagement.FormsManagement.JHolidaysUpdateControl" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register Src="~/WebControllers/MainControls/Date/JDateControl.ascx" TagPrefix="uc1" TagName="JDateControl" %>
<div class="BigTitle">تعریف روزهای تعطیل</div>
<table style="width: 500px">
    <tr class="Table_RowB">
        <td style="width: 150px">تاریخ:</td>
        <td>
            <uc1:JDateControl runat="server" id="txtDate" />
        </td>
    </tr>
    <tr class="Table_RowC">
        <td style="width: 150px">توضیحات:</td>
        <td>
            <telerik:RadTextBox runat="server" ID="txtDescription" Width="100%" TextMode="MultiLine"></telerik:RadTextBox>
        </td>
    </tr>
     <tr class="Table_RowB">
        <td style="width: 150px">نوع:</td>
        <td>
           <telerik:RadComboBox runat="server" ID="rblHoliDaysType" Width="100%">
                <Items>
                    <telerik:RadComboBoxItem Value="1" Text="جمعه" Selected="true"/>
                    <telerik:RadComboBoxItem Value="2" Text="تعطیل رسمی"/>
                </Items>
            </telerik:RadComboBox>
        </td>
    </tr>
     <tr class="Table_RowC">
        <td style="width: 150px">شمسی/قمری:</td>
        <td>
           <telerik:RadComboBox runat="server" ID="rblDateType" Width="100%">
                <Items>
                    <telerik:RadComboBoxItem Value="1" Text="شمسی" Selected="true"/>
                    <telerik:RadComboBoxItem Value="2" Text="قمری"/>
                </Items>
            </telerik:RadComboBox>
        </td>
    </tr>
</table>
<div class="FormButtons">
    <telerik:RadButton runat="server" ID="btnSave" Text="ذخیره" AutoPostBack="true" Width="100px" OnClick="btnSave_Click" Height="35px" />
    <telerik:RadButton runat="server" ID="btnClose" Text="بازگشت" OnClientClicked="CloseDialog" AutoPostBack="false" Width="100px" Height="35px" />
    <telerik:RadButton runat="server" ID="btnDelete" Text="حذف" AutoPostBack="true" Width="100px" Height="35px" OnClick="btnDelete_Click" CssClass="floatLeft" OnClientClicking="OnClientClicking" />
</div>
