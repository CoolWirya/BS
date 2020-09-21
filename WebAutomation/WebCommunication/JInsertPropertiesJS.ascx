<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="JInsertPropertiesJS.ascx.cs" Inherits="WebAutomation.WebCommunication.JInsertPropertiesJS" %>

<script type="text/javascript">

    function InsertProp(ObjCode) {
        ShowWarining('در  حال بارگذاری ...', false, 3);
        return $.ajax({
            type: 'POST',
            url: '/Services/UserControllerActionService.asmx/InsertDataToFormController',
            data: '{"pCode":' + ObjCode + ', "UserControllerName":"' + UserControllerName + ',"pClassName":"' + pClassName + ',"FormCode"'+ FormCode + '}',
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            error: function (xhr, status, error) {
                var err = eval("(" + xhr.responseText + ")");
                alert(err.Message);
            }
        });
    }
    </script>

<script>
    function fun1()
    {
        var ObjCode = 1;
        //bale aghaye mohandes.mamnoonam k vaghtetoono dar ekhtiar bande gharar dadin.
        //mitoonam y soal auobosrani beporsam?
        //
        $.when(InsertProp(ObjCode)).done(function (result) {
            if (result.d) {

                return d;
                // result.d is a boolean
                //or true or false return?  equal to your c# function return value
                //fun1 bezaram to Click btn?
            }
        });
    }
</script>