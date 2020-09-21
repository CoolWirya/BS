<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Purchase.ascx.cs" Inherits="WebAVL.Forms.Purchase" %>

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

      function SetValue( price )
      {

      }

      $(document).ready(function () {
          $("#<%= txtAmount.ClientID %>").on('input',function () {
              var price=$(this).val().replace(',','').replace(',','').replace(',','').replace(',','')  * 1 / 1;
              if(price == '')
                  price=0;
              var tax=price* <%= Accounting.Config.getTaxPercentage() %> / 100;
              var txtCash = $("#txtCash").val().replace(',','').replace(',','').replace(',','') * 1 / 1;
              $("#txtCash").val(groupDigit( txtCash  ,',' ));
              $("#txtTax").val(groupDigit(tax,','));
              $("#txtcharge").val(groupDigit(price+tax,','));
              $("#txtdays").val(groupDigit((price)/ <%= AVL.RegisterDevice.JRegisterDevices.GetOneDayPrice(WebClassLibrary.SessionManager.Current.MainFrame.CurrentUserCode) %>,',').split('.')[0]);
              $("#txtdayskol").val(groupDigit((price+<%=Accounting.Cash.JCash.GetCash(WebClassLibrary.SessionManager.Current.MainFrame.CurrentUserCode ) %>)/ <%= AVL.RegisterDevice.JRegisterDevices.GetOneDayPrice(WebClassLibrary.SessionManager.Current.MainFrame.CurrentUserCode) %>,',').split('.')[0]);
              $(this).val(groupDigit(price,','));
          });
      });
      
      function groupDigit( num , separator){
          return parseInt(num).toLocaleString();
          //var parts = (''+(num<0?-num:num)).split("."), s=parts[0], L, i=L= s.length, o='';
          //while(i--){ o = (i===0?'':((L-i)%3?'':',')) 
          //                +s.charAt(i) +o }
          //return (num<0?'-':'') + o + (parts[1] ? '.' + parts[1] : ''); 
      }


    </script>
<asp:TextBox ID="txtCode" runat="server" Visible="false" style="text-align:left;direction:ltr"></asp:TextBox>
<asp:Label ID="lblError" runat="server" Text="" Visible="false"></asp:Label>
<table border="1" style="border-style:solid;border:medium;border-color:black; margin-right :10px;height:95%">       
    <tr>
        <td>
            تعداد دستگاه فعال در پنل:
        </td>
        <td style="text-align:center;color:brown"><b>
            <%=
AVL.JoinDevice.JJoinDevices.GetData(0,
    device.Code).Rows.Count-1 %>
            دستگاه
            </b>
        </td>
    </tr>
    <tr>
        <td>
            تعداد شارژ موجود به روز:
        </td>
        <td style="text-align:center">
            <input id="txtCash" type="text" disabled="disabled" style="text-align:left;direction:ltr" value="
                <%= Accounting.Cash.JCash.GetCash(WebClassLibrary.SessionManager.Current.MainFrame.CurrentUserCode) / AVL.RegisterDevice.JRegisterDevices.GetOneDayPrice(WebClassLibrary.SessionManager.Current.MainFrame.CurrentUserCode) %>" /> روز
        </td>
    </tr>
    <tr>
        <td>
            مبلغ را به ریال وارد کنید:
        </td>
        <td style="text-align:center">
            <asp:TextBox ID="txtAmount" runat="server" OnTextChanged="txtAmount_TextChanged" style="text-align:left;direction:ltr"></asp:TextBox> ریال
        </td>
    </tr>
    <tr>
        <td>
           مالیات بر ارزش افزوده:
        </td>
        <td style="text-align:center">
            <input id="txtTax" type="text" disabled="disabled" style="text-align:left;direction:ltr" /> ریال
        </td>
    </tr>
    <tr>
        <td>
            مبلغ قابل پرداخت:
        </td>
        <td style="text-align:center">
            <input id="txtcharge" type="text" disabled="disabled" style="text-align:left;direction:ltr" /> ریال
        </td>
    </tr>
    <tr>
        <td>
            تعداد روزی که شارژ می شود:

        </td>
        <td style="text-align:center">
            <input id="txtdays" type="text" disabled="disabled" style="text-align:left;direction:ltr" /> روز </td>
    </tr>
    <tr>
        <td>
            مجموع کل شارژ :

        </td>
        <td style="text-align:center">
            <input id="txtdayskol" type="text" disabled="disabled" style="text-align:left;direction:ltr" /> روز </td>
    </tr>
    <tr>
        <td colspan="2" style="text-align:center;vertical-align:central;height:30px">
        	<asp:Button runat="server" ID="btnSubmit" Width="120px" Height="30px"  Text="پرداخت" OnClick="btnSubmit_Click" style="text-align:center;font-weight:bold;vertical-align:central" ></asp:Button>
        </td>
        </tr>
    <tr>
        <td colspan="2" style="text-align:left">
            <image src="/images/logo_banks.jpg" alt="ا" style="height:100%"></image>
        </td>
    </tr>
    </table>
