<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ProjectUpdate.ascx.cs" Inherits="WebProjectManagement.Forms.ProjectUpdate" %>

<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register Src="~/WebControllers/MainControls/Date/JDateControl.ascx" TagPrefix="uc1" TagName="JDateControl" %>

<script type="text/javascript">
    //string code, string name,string startDate,string endDate,string description,string locationAddress
    $(document).ready(function () {
        $('#<%= btnSave.ClientID %>').click(function () {
            var tCode = 0, tType = 1;
          <%--  <% if (int.Parse(Request["Code"] != null ? Request["Code"] : "0") <= 0)
    { %>--%>
            tCode = $("#<%=  cmbTemplates.ClientID%> option:selected").val();
            <%--tType = "1";// $('#<%= //rdblTemplate.ClientID %> input:checked').val();
            <% } %>--%>
            $.ajax({
                type: 'POST',
                url: 'Services/ProjectManagementService.asmx/SaveProject',
                data: " {" +
						 "'code': '<%= Request["Code"]!=null?Request["Code"].ToString():null%>'  " +
						 ",'name':'" + $('#<%= txtName.ClientID%>').val() + "'" +
						 ",'totalWeight':'" + $('#<%= txtTotalWeight.ClientID%>').val() + "'" +
						 ",'startDate':'" + $('#<%= dateStart.ClientID%>_PersianDateTextBox1').val() + "'" +
						 ",'endDate': '" + $('#<%= dateEnd.ClientID%>_PersianDateTextBox1').val() + "'" +
						 ",'description':'" + $('#<%= txtDescription.ClientID %>').val() + "'" +
						 ",'locationAddress': '" + $('#<%= txtLocationAddress.ClientID %>').val() + "'" +
						 ",'templateCode': '" + tCode + "'" +
						 ",'templateType': '" + tType + "'" +
						 "}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (msg) {
                    alert('عملیات موفق');
                    var refreshButton = window.parent.document.getElementById('<%= ((WebControl)WebClassLibrary.SessionManager.Current.Session[WebProjectManagement.JWebProjectManagement._ConstClassName.Replace(".", "_") + "_Projects"]).ClientID %>_refreshStaticButton');
                    
                    $(refreshButton).click();
                    GetRadWindow().close();
                    GetRadWindow().BrowserWindow.RefreshGrid();
                    CloseDialog(null);


                },
                error: function (xhr, status, error) {
                    alert(JSON.parse(xhr.responseText).Message);
                }
            });
            return false;
        });
    });
</script>
<style>
    .pnlprompt {
    }
</style>
<table style="min-width: 500px; width: 50%;">
    <tr>
        <td class="Table_RowB">نام</td>
        <td class="Table_RowC">
            <telerik:RadTextBox runat="server" ID="txtName"></telerik:RadTextBox></td>
    </tr>
    <tr>
        <td class="Table_RowB">وزن کل</td>
        <td class="Table_RowC">
            <asp:TextBox runat="server" ID="txtTotalWeight" /></td>
    </tr>
    <tr>
        <td class="Table_RowB">تاریخ شروع پروژه</td>
        <td class="Table_RowC">
            <uc1:JDateControl runat="server" id="dateStart" />
        </td>
    </tr>
    <tr>
        <td class="Table_RowB">تاریخ پایان مورد انتظار</td>
        <td class="Table_RowC">
            <uc1:JDateControl runat="server" id="dateEnd" />
        </td>
    </tr>
    <% if (int.Parse(Request["Code"] != null ? Request["Code"] : "0") <= 0)
        { %>
    <tr>
        <td class="Table_RowB">الگو</td>
        <td class="Table_RowC">
            <%--<asp:Panel runat="server" ID="pnlTemplate">
                <asp:RadioButtonList runat="server" ID="rdblTemplate" OnSelectedIndexChanged="rdblTemplate_SelectedIndexChanged" AutoPostBack="true">
                    <asp:ListItem Text="بدون الگو" Value="0"></asp:ListItem>
                    <asp:ListItem Text="الگو" Value="1"></asp:ListItem>
                    <asp:ListItem Text="پروژه دیگر" Value="2"></asp:ListItem>
                </asp:RadioButtonList>                
            <telerik:RadComboBox runat="server" ID="cmbTemplates" Visible="false"></telerik:RadComboBox>
            </asp:Panel> --%>
            <asp:DropDownList runat="server" ID="cmbTemplates" />
        </td>
    </tr>
    <% } %>
    <tr>
        <td class="Table_RowB">مکان انجام پروژه</td>
        <td class="Table_RowC">
            <telerik:RadTextBox runat="server" ID="txtLocationAddress"></telerik:RadTextBox></td>
    </tr>
    <tr>
        <td class="Table_RowB">توضیحات پروژه</td>
        <td class="Table_RowC">
            <telerik:RadTextBox runat="server" ID="txtDescription" TextMode="MultiLine" MaxLength="250" Width="100%" Height="150px"></telerik:RadTextBox></td>
    </tr>
    <tr>
        <td class="Table_RowB">
            <telerik:RadButton runat="server" ID="btnSave" Text="ذخیره" AutoPostBack="false" Width="100px" Height="35px" ValidationGroup="Line" />
        </td>
        <% if (int.Parse(Request["Code"] != null ? Request["Code"] : "0") > 0)
            { %>
        <td class="Table_RowC">
            <telerik:RadButton runat="server" ID="RadButton2" Text="حذف" OnClick="RadButton2_Click" Width="100px" Height="35px" ValidationGroup="Line" />
        </td>
        <%} %>
        <td class="Table_RowB">
            <telerik:RadButton runat="server" ID="btnClose" Text="بازگشت" OnClientClicked="CloseDialog" AutoPostBack="false" Width="100px" Height="35px" />
        </td>
    </tr>
</table>
<asp:Panel runat="server" ID="pnlPrompt" CssClass="pnlprompt"></asp:Panel>

