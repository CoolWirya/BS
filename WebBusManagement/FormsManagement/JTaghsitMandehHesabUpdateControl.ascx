<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="JTaghsitMandehHesabUpdateControl.ascx.cs" Inherits="WebBusManagement.FormsManagement.JTaghsitMandehHesabUpdateControl" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register Src="~/WebControllers/MainControls/Date/JDateControl.ascx" TagPrefix="uc1" TagName="JDateControl" %>
<script type="text/javascript">
    var DocumentRemainPrice = 0;
    var TransactionRemainPrice = 0;
    function DocumentRemainCanged(source, eventArgs) {
        DocumentRemainPrice = parseInt(eventArgs.get_newValue());
        if(parseInt(<%=DocumentRemainMax%>) < 0) 
            DocumentRemainPrice = -DocumentRemainPrice;
        document.getElementById('<%=lblTotalRemain.ClientID%>').innerHTML =
            (DocumentRemainPrice + TransactionRemainPrice).toString().replace(/\B(?=(\d{3})+(?!\d))/g, ",");
    }
    function TransactionRemainCanged(source, eventArgs) {
        TransactionRemainPrice = parseInt(eventArgs.get_newValue());
        if (parseInt(<%=TransactionRemainMax%>) < 0)
            TransactionRemainPrice = -TransactionRemainPrice;
        document.getElementById('<%=lblTotalRemain.ClientID%>').innerHTML =
            (DocumentRemainPrice + TransactionRemainPrice).toString().replace(/\B(?=(\d{3})+(?!\d))/g, ",");
    }
</script>
<div class="BigTitle">تقسیط مانده حساب</div> 
<div class="FormContent" style="top:40px; margin-bottom: 55px">
    <table style="width: 500px; margin-top:10px;">
        <tr class="Table_RowB">
            <td style="width: 150px">مانده از تراکنش:</td>
            <td>
                <table>
                    <tr>
                        <td>
                            <telerik:RadNumericTextBox runat="server" id="txtTransactionRemain" InputType="Number" NumberFormat-DecimalSeparator="," 
                                NumberFormat-DecimalDigits="0" Value="0" Width="100px" MinValue="0" ClientEvents-OnValueChanged="TransactionRemainCanged">
                            </telerik:RadNumericTextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>    
                            <asp:Label ID="lblTransactionRemain" Text="" runat="server" />
                            <span> ریال </span>
                            <asp:Label ID="lblTransactionRemainType" Text="" runat="server" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr class="Table_RowC">
            <td style="width: 150px">مانده از سند:</td>
            <td>
                <table>
                    <tr>
                        <td>
                            <telerik:RadNumericTextBox runat="server" id="txtDocumentRemain" InputType="Number" NumberFormat-DecimalSeparator=","
                                 NumberFormat-DecimalDigits="0" Value="0" Width="100px" MinValue="0" ClientEvents-OnValueChanged="DocumentRemainCanged">
                            </telerik:RadNumericTextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>    
                            <asp:Label ID="lblDocumentRemain" Text="" runat="server" />
                            <span> ریال </span>
                            <asp:Label ID="lblDocumentRemainType" Text="" runat="server" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr class="Table_RowB">
            <td style="width: 150px">جمع:</td>
            <td>
                <asp:Label ID="lblTotalRemain" Text="0" runat="server" />
                <span> ریال </span>
            </td>
        </tr>
        <tr class="Table_RowC">
            <td style="width: 150px">تاریخ شروع:</td>
            <td>
                <uc1:JDateControl runat="server" id="txtFromDate" />
            </td>
        </tr>
        <tr class="Table_RowB">
            <td style="width: 150px">تعداد روز:</td>
            <td>
                <telerik:RadTextBox runat="server" id="txtDayCount" InputType="Number" Text="1" Width="50px" ></telerik:RadTextBox>
            </td>
        </tr>
    </table>
</div>
<div class="FormButtons">
    <telerik:RadButton runat="server" ID="btnSave" Text="ذخیره" AutoPostBack="true" Width="100px" Height="35px" OnClick="btnSave_Click" />
    <telerik:RadButton runat="server" ID="btnClose" Text="بازگشت" OnClientClicked="CloseDialog" AutoPostBack="false" Width="100px" Height="35px" />
</div>