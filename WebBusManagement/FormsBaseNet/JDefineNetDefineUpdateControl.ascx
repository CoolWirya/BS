<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="JDefineNetDefineUpdateControl.ascx.cs" Inherits="WebBusManagement.FormsBaseNet.JDefineNetDefineUpdateControl" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register Src="~/WebControllers/MainControls/Date/JDateControl.ascx" TagPrefix="uc1" TagName="JDateControl" %>

<div class="BigTitle">ثبت سرویس های اتوبوس</div>
<div id="control_Lines_RadPageView1">
		<input type="hidden" id="hidEditCode" name="hidEditCode" value="0" runat="server" /> 
        <table style="width: 500px">
                <tbody>
                <tr class="Table_RowB">
                    <td style="width: 150px">گروه:</td>
                    <td>
                           <telerik:RadComboBox ID="cmbGroup" runat="server" Width="100%" Filter="Contains"></telerik:RadComboBox>
                           <span id="Span2" style="display:none;">*</span>
                    </td>
                </tr>
                <tr class="Table_RowB">
                    <td style="width: 150px">نام سرویس نت:</td>
                    <td>
                        <telerik:RadTextBox runat="server" ID="txtDefineName" Width="100%"></telerik:RadTextBox>
                        <span id="control_Lines_RequiredFieldValidatorTxtName" style="display:none;">*</span>
                    </td>
                </tr>
                <tr class="Table_RowC">
                    <td style="width: 150px">نوع سرویس:</td>
                    <td>
                           <telerik:RadComboBox runat="server" ID="cmbDefineType" Width="100%" Filter="Contains">
                               <Items>
                                   <telerik:RadComboBoxItem text="کیلومتر" Value="1" />
                                   <telerik:RadComboBoxItem text="زمان(روز)" Value="2" />
                               </Items>
                           </telerik:RadComboBox>
                        <span id="control_Lines_RequiredFieldValidatortxtLineNumber" style="display:none;">*</span>
                    </td>
                </tr>
                <tr class="Table_RowC">
                    <td style="width: 150px">میزان کارکرد سرویس:</td>
                    <td>
                           <telerik:RadTextBox runat="server" ID="txtDefineValue" Width="100%" InputType="Number" ></telerik:RadTextBox>
                        <span id="Span1" style="display:none;">*</span>
                    </td>
                </tr>
                 <tr class="Table_RowC">
                    <td style="width: 150px">محل انجام:</td>
                    <td>
                           <telerik:RadComboBox runat="server" ID="cmbPlace" Width="100%" Filter="Contains"></telerik:RadComboBox>
                    </td>
                </tr>
                  
            </tbody></table>
      <telerik:RadButton runat="server" ID="btnSave" Text="ذخیره " AutoPostBack="true" Width="100px" Height="35px" OnClick="btnSave_Click"/>
<telerik:RadButton runat="server" ID="btnClose" Text="بازگشت" OnClientClicked="CloseDialog" AutoPostBack="false" Width="100px" Height="35px" />
       
	</div>

