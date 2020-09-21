<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="JMalfunctionViewControl.ascx.cs" 
    Inherits="WebOilManagement.FormsReports.JMalfunctionViewControl" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register Src="~/WebControllers/MainControls/Date/JDateControl.ascx" TagPrefix="uc1" TagName="JDateControl" %>
<%@ Register Src="~/WebControllers/MainControls/Grid/JGridViewControl.ascx" TagPrefix="uc1" TagName="JGridViewControl" %>




<div class="BigTitle">جزئیات خرابی</div>


<table style="width: 100%; height: auto; margin-top: 15px">
    <tr>
        <td style="width: 100%; height: auto; overflow: auto">
           
            <uc1:JGridViewControl runat="server" id="grdMalFunction" />
                
        </td>
    </tr>
</table>
