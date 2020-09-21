<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AnnualRentalControl.ascx.cs" Inherits="WebRealEstate.Building.AnnualRental.AnnualRentalControl" %>
<%@ Register Assembly="JJson" Namespace="JJson.Controls" TagPrefix="JJson" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register Src="~/WebControllers/MainControls/Date/JDateControl.ascx" TagPrefix="uc1" TagName="JDateControl" %>
<%@ Register Src="~/WebControllers/MainControls/Grid/JGridViewControl.ascx" TagPrefix="uc1" TagName="JGridViewControl" %>


<table>
    <tr>
        <td>تاریخ شروع :
        </td>
        <td>
            <uc1:jdatecontrol runat="server" id="JDateControl" />
        </td>
        <td>تاریخ پایان :
        </td>
        <td>
            <uc1:jdatecontrol runat="server" id="JDateControl1" />
        </td>
        <td>مبلغ اجاره : </td>
        <td>
            <JJson:JJsonTextBox ID="JJsontxtRentP" runat="server" Event="textchange"></JJson:JJsonTextBox></td>
    </tr>
        <tr>
        <td>توضیحات :
        </td>
        <td>
            <JJson:JJsonTextBox ID="JJsontxtDsc" runat="server" Event="textchange"></JJson:JJsonTextBox>
        </td>
        <td>
            <JJson:JJsonButton ID="JJsonButtonRec" runat="server" Event="click" text="ثبت"/>
        </td>
        <td>
            <JJson:JJsonButton ID="JJsonButtonDel" runat="server" Event="click" text="حذف"/>  
        </td>
    </tr>
    <tr>
        <uc1:JGridViewControl runat="server" id="JGridViewControl" />
    </tr>
</table>
