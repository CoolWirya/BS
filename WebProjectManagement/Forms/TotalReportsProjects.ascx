<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TotalReportsProjects.ascx.cs" Inherits="WebProjectManagement.Forms.TotalReportsProjects" %>

<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register Src="~/WebControllers/MainControls/Date/JDateControl.ascx" TagPrefix="uc1" TagName="JDateControl" %>

<table>
   <tr>
       <td>بازه ی اول</td>
       <td>
            <uc1:JDateControl runat="server" id="dateFirst" />
       </td>
       <td></td>
   </tr>    
   <tr>
       <td> بازه ی دوم</td>
       <td>
            <uc1:JDateControl runat="server" id="dateSecond" />
       </td>
       <td>
           <telerik:RadButton runat="server" ID="btnSave" Text="نمایش" Width="100px" Height="35px"
                OnClick="btnSave_Click"/>
       </td>
   </tr>    
</table>
<asp:Panel runat="server" ID="pnlData">

</asp:Panel>