<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ObjectState.ascx.cs" Inherits="WebAVL.Forms.ObjectState" %>

<asp:CheckBoxList ID="chbObjects" runat="server" > </asp:CheckBoxList>
<asp:Label ID="lblResult" runat="server" Text=""></asp:Label>
<script type="text/javascript">

    $('#<%=chbObjects.ClientID%> :input').change(function () {
        $.ajax({
            type: 'POST',
            url: '/Services/WebBaseDefineService.asmx/ObjectCheckedChange',
            data: '{'
                    + '"ids":"' + $(this).val() + '"'
                    + ',"status":"' + $(this).attr("checked") + '"'
                    + '}',
			    contentType: "application/json; charset=utf-8",
			    dataType: "json",
			    success: function (msg) {
			        $('#<%=lblResult.ClientID%>').html(msg.d);

			    },
			    error: function (err) {
			        alert("خطا در اجرا");
			        //alert(err.responseText);
			    }
        });
        return false;
    });
</script>