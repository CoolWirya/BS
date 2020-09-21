<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ViewFactor.ascx.cs" Inherits="WebAccounting.Forms.ViewFactor" %>

<script lang="javascript" type="text/javascript">
      function postRefId(refIdValue) {
          var form = document.createElement("form");
          form.setAttribute("method", "POST");
          form.setAttribute("action", "<%= PgwSite %>");
            form.setAttribute("target", "_self");
            var hiddenField = document.createElement("input");
            hiddenField.setAttribute("name", "RefId");
            hiddenField.setAttribute("value", refIdValue);
            form.appendChild(hiddenField);
            document.body.appendChild(form);
            form.submit();
            document.body.removeChild(form);
        }
    </script>
<center>
<table style="border:solid; border-width:1px; border-color:darkgray; width:700px; ">
    <tr style="height:100px; text-align:center">
        <td>
            <h1>
                ایران فردیاب
            </h1>
            <br />
            <h2>شماره فاکتور <%= factor.Number %></h2>
        </td>
        <td>
            <h1 style="color:red"><%= PayState() %></h1>
            <br />
            <h2>تاریخ فاکتور <br /><%= ClassLibrary.JDateTime.FarsiDate(factor.RegisterDate) %></h2>
            
        </td>
    </tr>
    <tr style="height:100px">
        <td>
            <b>فاکتور برای :</b><%= FactorFor() %>
        </td>
        <td style="text-align:center">
            <image src="/images/BankMellat.png" style="align-content:center"></image>
            <br />
            <asp:Button ID="btnOnlinePay" runat="server" Text="پرداخت آنلاین" OnClick="btnOnlinePay_Click" />
        </td>
    </tr>
    <tr><td colspan="2" style="height:30px"><h3>جزئیات فاکتور</h3></td></tr>
    <tr><td colspan="2">
        <table style="border:solid; border-width:1px; border-color:darkgray; width:100%">
            <tr style="height:30px; border:solid; border-color:darkcyan; border-width:1px">
                <td>
                    توضیحات
                </td>
                <td>
                    مبلغ(ریال)
                </td>
            </tr>
                <%= FactorItem() %>
        </table>

        </td></tr>
    <tr>
        <td colspan="2">
            <table style="width:100%;">
                <tr style="height:30px;font-weight:bold">
                    <td>تاریخ تراکنش</td>
                    <td>روش پرداخت</td>
                    <td>شماره تراکنش</td>
                    <td>مبلغ</td>
                </tr>
                <tr>
                    <td><%= ClassLibrary.JDateTime.FarsiDate(paid.documentDateTime) %></td>
                    <td>پرداخت آنلاین بانک <%= paid.bankName %></td>
                    <td><%= paid.RefId %></td>
                    <td><%= Convert.ToInt64(paid.Price).ToString("N0") %></td>
                </tr>
            </table>
        </td>
    </tr>
    
</table>
</center>