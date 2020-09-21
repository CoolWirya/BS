<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="JReportSelectorControl.ascx.cs" Inherits="WebReport.Viewer.JReportSelector" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<asp:HiddenField ID="hfClassName" runat="server" />
<asp:HiddenField ID="hfObjectCode" runat="server" />
<asp:HiddenField ID="hfreportSUID" runat="server" />
<asp:HiddenField ID="hfQueryCode" runat="server" />
<%--comment--%>
<div class="FormContent">
    <div class="BigTitle">گزارش</div>
    <table style="width: 100%">
        <tr class="Table_RowB">
            <td style="width: 150px">نام گزارش :</td>
            <td>
                <telerik:RadTextBox ID="txtName" runat="server" Width="150px" ValidationGroup="New"></telerik:RadTextBox>
                <asp:RequiredFieldValidator runat="server" ID="rfvName" ValidationGroup="New" ControlToValidate="txtName" ForeColor="Red" Font-Size="Medium">*</asp:RequiredFieldValidator>
            </td>
        </tr>
    </table>
    <telerik:RadGrid runat="server" ID="dgrReports" Width="100%" AutoGenerateColumns="false">
        <MasterTableView>
            <Columns>
                <telerik:GridBoundColumn HeaderText="کد" DataField="Code" ItemStyle-Width="100px" ></telerik:GridBoundColumn>
                <telerik:GridBoundColumn HeaderText="نام کلاس" DataField="Class Name" Visible="false" ></telerik:GridBoundColumn>
                <telerik:GridBoundColumn HeaderText="کد شیء" DataField="Object Code" Visible="false"  ></telerik:GridBoundColumn>
                <telerik:GridBoundColumn HeaderText="نام"  DataField="Name" ></telerik:GridBoundColumn>

            </Columns>
        </MasterTableView>
        <ClientSettings>
            <Selecting AllowRowSelect="true" />
        </ClientSettings>
    </telerik:RadGrid>
</div>
<div class="FormButtons">
     <telerik:RadButton runat="server" ID="btnNew" Text="جدید" AutoPostBack="true" ValidationGroup="New" Width="100px" Height="35px" OnClick="btnNew_Click"  />
     <telerik:RadButton runat="server" ID="btnEdit" Text="ویرایش" AutoPostBack="true" Width="100px" Height="35px" OnClick="btnEdit_Click"  />
     <telerik:RadButton runat="server" ID="btnDelete" Text="حذف" AutoPostBack="true" Width="100px" Height="35px" OnClick="btnDelete_Click"  OnClientClicking="OnClientClicking" />


   
    <telerik:RadButton runat="server" ID="btnClose" Text="بازگشت" OnClientClicked="CloseDialog" AutoPostBack="false" Width="100px" CssClass="floatLeft"  Height="35px" />
     <telerik:RadButton  runat="server" ID="btnPreview" 
          AutoPostBack="true" Width="100px" Height="35px" Text="چاپ"  OnClick="btnPreview_Click" CssClass="floatLeft" ValidationGroup="District" >
          <Icon PrimaryIconCssClass="rbPrint"   PrimaryIconLeft="5px" PrimaryIconUrl="~\Weberp\Images\Controls\gridview_print.png"></Icon>
     </telerik:RadButton>
   
</div>
