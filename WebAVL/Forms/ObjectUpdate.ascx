<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ObjectUpdate.ascx.cs" Inherits="WebAVL.Forms.ObjectUpdate" %>



<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register Src="~/WebAVL/Forms/DeviceModelSearch.ascx" TagPrefix="uc1" TagName="DeviceModelSearch" %>

<script type="text/javascript">
	$(document).ready(function () {
		$('#<%= btnSave.ClientID %>').click(function () {

    		$.ajax({
    			type: 'POST',
    			url: 'Services/WebBaseDefineService.asmx/SaveDevice',
    			data: " {" +
						 "'code': '<%= Request["Code"]!=null?Request["Code"].ToString():null%>'  " +
						 ",'obejectCode':'0'" +
						 ",'imei':'" + $('#<%= txtIMEI.ClientID%>').val() + "'" +
						 ",'deviceType':'" + $('#<%= deviceModelSearch.ClientID%>_txtCode').val() + "'" +
						 ",'SendType': '" + $find('<%= cmbSendType.ClientID%>').get_value() + "'" +
						 ",'dataFormat':'" + $('#<%= txtDataFormat.ClientID%>').val() + "'" +
						 ",'registerDateTime': '<%= DateTime.Today.ToString() %>'" +
						 "}",
            	contentType: "application/json; charset=utf-8",
            	dataType: "json",
            	success: function (msg) {
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
<div class="FormContent">
	<div class="BigTitle">دستگاه</div>
	<table>
		<tr>
			<td class="Table_RowB">IMEI:</td>
			<td class="Table_RowC">
				<telerik:RadTextBox runat="server" ID="txtIMEI"></telerik:RadTextBox></td>
		</tr>
		<tr>
			<td class="Table_RowB">مدل دستگاه:</td>
			<td class="Table_RowC">
                <uc1:DeviceModelSearch     runat="server" ID="deviceModelSearch"></uc1:DeviceModelSearch>     
            </td>
		</tr>
		<tr>
			<td class="Table_RowB">نوع ارسال اطلاعات:</td>
			<td class="Table_RowC">
                <telerik:RadComboBox  runat="server" ID="cmbSendType">
                </telerik:RadComboBox>
		</tr>
		<tr>
			<td class="Table_RowB">فرمت ارسال اطلاعات:</td>
			<td class="Table_RowC">
				<telerik:RadTextBox runat="server" ID="txtDataFormat" ></telerik:RadTextBox>
			</td>
		</tr>
	</table>
</div>
<div class="FormButtons">
	<telerik:RadButton runat="server" ID="btnSave" Text="ذخیره" AutoPostBack="false" Width="100px" Height="35px" ValidationGroup="Line" />
	<telerik:RadButton runat="server" ID="btnClose" Text="بازگشت" OnClientClicked="CloseDialog" AutoPostBack="false" Width="100px" Height="35px" />
</div>
