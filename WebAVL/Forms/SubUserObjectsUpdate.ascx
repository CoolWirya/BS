<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SubUserObjectsUpdate.ascx.cs" Inherits="WebAVL.Forms.SubUserObjectsUpdate" %>
<asp:CheckBoxList ID="chbObjects" runat="server"></asp:CheckBoxList>
<asp:Label ID="lblResult" runat="server" Text=""></asp:Label>
<script type="text/javascript">

    $('#<%=chbObjects.ClientID%> :input').change(function () {
        $.ajax({
            type: 'POST',
            url: '/Services/WebBaseDefineService.asmx/UserObjectCheckedChange',
            data: '{'
                    + '"ids":"' + $(this).val() + '"'
                    + ',"status":"' + $(this).attr("checked") + '"'
                    + ',"ParentUserCode":"<%:  ParentUserCode.ToString() %>"'
                    + ',"userCode":"<%: userCode.ToString() %>"'
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