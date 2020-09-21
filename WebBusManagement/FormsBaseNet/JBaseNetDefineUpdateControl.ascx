<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="JBaseNetDefineUpdateControl.ascx.cs" Inherits="WebBusManagement.FormsBaseNet.JBaseNetDefineUpdateControl" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register Src="~/WebControllers/MainControls/Date/JDateControl.ascx" TagPrefix="uc1" TagName="JDateControl" %>

<div class="BigTitle">ثبت سرویس های اتوبوس</div>
<div id="control_Lines_RadPageView1">
		<input type="hidden" id="hidEditCode" name="hidEditCode" value="0" runat="server" /> 
            <table style="width: 500px">
                <tbody><tr class="Table_RowB">
                    <td style="width: 150px">نام سرویس نت:</td>
                    <td>
                             <telerik:RadComboBox runat="server" ID="cmbNet"  Width="100%" Filter="Contains"></telerik:RadComboBox>
                        <span id="control_Lines_RequiredFieldValidatorTxtName" style="display:none;">*</span>
                    </td>
                </tr>
                <tr class="Table_RowC">
                    <td style="width: 150px">شماره اتوبوس:</td>
                    <td>
                           <telerik:RadComboBox runat="server" ID="cmbBus"  Width="100%" Filter="Contains"></telerik:RadComboBox>
                        <span id="control_Lines_RequiredFieldValidatortxtLineNumber" style="display:none;">*</span>
                    </td>
                </tr>
                <tr class="Table_RowC">
                    <td style="width: 150px">محل سرویس</td>
                    <td>
                        <telerik:RadComboBox runat="server" ID="cmbPlace"  Width="100%" Filter="Contains"></telerik:RadComboBox>
                        <span id="Span1" style="display:none;">*</span>
                    </td>
                </tr>
                <tr class="Table_RowB">
                    <td style="width: 150px">توضیحات:</td>
                    <td>
                           <telerik:RadTextBox ID="txtDesc" runat="server"  Width="100%"></telerik:RadTextBox>
                    </td>
                </tr>
               
                 <tr class="Table_RowC">
                    <td style="width: 150px">از تاریخ:</td>
                    <td>
                       <uc1:JDateControl runat="server" id="txtFromDate"  Width="100%" />
                    </td>
                </tr>

                 <tr class="Table_RowC">
                    <td style="width: 150px">تا تاریخ:</td>
                    <td>
                       <uc1:JDateControl runat="server" id="txtToDate"  Width="100%" />
                    </td>
                </tr>
                   
            </tbody></table>
      <telerik:RadButton runat="server" ID="btnSave" Text="ذخیره " AutoPostBack="true" Width="100px" Height="35px" OnClick="btnSave_Click"/>
<telerik:RadButton runat="server" ID="btnClose" Text="بازگشت" OnClientClicked="CloseDialog" AutoPostBack="false" Width="100px" Height="35px" />
       
	</div>

