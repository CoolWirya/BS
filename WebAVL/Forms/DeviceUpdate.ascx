<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DeviceUpdate.ascx.cs" Inherits="WebAVL.Forms.DeviceUpdate" %>

<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register Src="~/WebAVL/Forms/DeviceModelSearch.ascx" TagPrefix="uc1" TagName="DeviceModelSearch" %>
<%@ Register Src="~/WebAVL/Forms/JObjectListItemSearch.ascx" TagPrefix="uc2" TagName="ObjectListItemSearch" %>

<%@ Register Assembly="WebControllers" Namespace="WebControllers.MainControls.Grid" TagPrefix="cc1" %>

<script type="text/javascript">
    $(document).ready(function () {
        $('#<%= btnSave.ClientID %>').click(function () {
            
            $.ajax({
                type: 'POST',
                url: 'Services/WebBaseDefineService.asmx/SaveDevice',
                data: " {" +
						 "'code': '<%= Request["Code"]!=null?Request["Code"].ToString():null%>'  " +
						 ",'imei':'" + $('#<%= txtIMEI.ClientID%>').val() + "'" +
						 ",'deviceType':'" + $('#<%= deviceModelSearch.ClientID%>_txtCode').val() + "'" +
						 ",'SendType': '0'" +
						 ",'dataFormat':'0'" +
						 ",'registerDateTime': '<%= DateTime.Today.ToString() %>'" +
                         ",'speed':'0'" +
                         ",'Name':'" + $('#<%= txtName.ClientID%>').val() + "'" +
                         ",'ObjectCode':'" + $('#<%= objectListSearch.ClientID%>_txtCode').val() + "'" +
                         ",'config':'" + $('#<%= SaCheckbox.ClientID%>').attr('checked') + ","
                                      + $('#<%= SuCheckbox.ClientID%>').attr('checked') + ","
                                      + $('#<%= MoCheckbox.ClientID%>').attr('checked') + ","
                                      + $('#<%= TuCheckbox.ClientID%>').attr('checked') + ","
                                      + $('#<%= WeCheckbox.ClientID%>').attr('checked') + ","
                                      + $('#<%= ThCheckbox.ClientID%>').attr('checked') + ","
                                      + $('#<%= FrCheckbox.ClientID%>').attr('checked') + ","
                                      + $('#<%= OfTextbox.ClientID%>').val() + ","
                                      + $('#<%= toTextbox.ClientID%>').val() + ","
                                      + $('#<%= rateTextbox.ClientID%>').val() + ","
                                      + $('input[id*=RDOHigh]').is(":checked") + ","
                                      + $('input[id*=RDOLow]').is(":checked") +"'"+
						 "}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (msg) {
                    alert('عملیات موفق');
                    GetRadWindow().close();
                    //GetRadWindow().BrowserWindow.RefreshGrid();
                    //CloseDialog(null);
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
			<td class="Table_RowB">نام دلخواه برای دستگاه:</td>
			<td class="Table_RowC">
				<telerik:RadTextBox runat="server" ID="txtName"></telerik:RadTextBox></td>
		</tr>
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
			<td class="Table_RowB">تنظیمات  ارسال:</td>
			<td class="Table_RowC">
                <table border="1" style="width:100%; border:solid; border-width:1px">
                    <tr>
                        <td>شنبه</td>
                        <td>یک شنبه</td>
                        <td>دو شنبه</td>
                        <td>سه شنبه</td>
                        <td>چهار شنبه</td>
                        <td>پنج شنبه</td>
                        <td>جمعه</td>
                    </tr>
                    <tr>
                        <td><asp:CheckBox runat="server" ID="SaCheckbox" Checked="true"></asp:CheckBox></td>
                        <td><asp:CheckBox runat="server" ID="SuCheckbox" Checked="true"></asp:CheckBox></td>
                        <td><asp:CheckBox runat="server" ID="MoCheckbox" Checked="true"></asp:CheckBox></td>
                        <td><asp:CheckBox runat="server" ID="TuCheckbox" Checked="true"></asp:CheckBox></td>
                        <td><asp:CheckBox runat="server" ID="WeCheckbox" Checked="true"></asp:CheckBox></td>
                        <td><asp:CheckBox runat="server" ID="ThCheckbox" Checked="true"></asp:CheckBox></td>
                        <td><asp:CheckBox runat="server" ID="FrCheckbox"></asp:CheckBox></td>
                    </tr>
                    <tr >
                        <td colspan="1" style="width:20%"> ارسال از ساعت
                        </td>
                        <td colspan="1" style="width:20%"> ارسال تا ساعت
                        </td>
                        <td colspan="1" style="width:20%"> فاصله زمانی هر نقطه(ثانیه)
                        </td>
                        <td colspan="4" style="width:40%"> کیفیت ارسال
                        </td>
                    </tr>
                    <tr >
                        <td colspan="1">
                                <asp:TextBox runat="server" ID="OfTextbox" MaxLength="2" Width="30" Text="8"></asp:TextBox>   
                        </td>
                        <td colspan="1">
                                <asp:TextBox runat="server" ID="toTextbox" MaxLength="2" Width="30" Text="16"></asp:TextBox>   
                        </td>
                        <td colspan="1">
                                <asp:TextBox runat="server" ID="rateTextbox" MaxLength="3" Width="30" Text="120"></asp:TextBox> 
                        </td>
                        <td colspan="4">
                                <asp:RadioButton runat="server" ID="RDOHigh" Width="100%" GroupName="1" Text="کیفیت بالا - مصرف باطری زیاد"></asp:RadioButton> 
                            <br />
                                <asp:RadioButton runat="server" ID="RDOLow" Width="100%" GroupName="1" Text="کیفیت معمولی - مصرف باطری کم"></asp:RadioButton> 
                        </td>
                    </tr></table>  
            </td>
		</tr>
        <tr>
			<td class="Table_RowB"> تاریخچه اتصال دستگاه به متحرک ها </td>
			<td class="Table_RowC">
                <cc1:JGridView ID="JGrid" runat="server" SUID="DeviceUpdateGrid"  />
            </td>
        </tr>
        <tr>
			<td class="Table_RowB">  متحرک جدید</td>
			<td class="Table_RowC">
                <uc2:ObjectListItemSearch     runat="server" ID="objectListSearch"></uc2:ObjectListItemSearch>
            </td>
        </tr>
	</table>

</div>
<div >
	<telerik:RadButton runat="server" ID="btnSave" Text="ذخیره" AutoPostBack="false" Width="100px" Height="35px" ValidationGroup="Line" />
	<telerik:RadButton runat="server" ID="btnClose" Text="بازگشت" OnClientClicked="CloseDialog" AutoPostBack="false" Width="100px" Height="35px" />
</div>
