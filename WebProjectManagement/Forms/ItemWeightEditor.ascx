<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ItemWeightEditor.ascx.cs" Inherits="WebProjectManagement.Forms.ItemWeightEditor" %>

<%@ Register TagPrefix="pm" Namespace="ProjectManagement.Controls.ExcelLike" Assembly="ProjectManagement" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<!--
    توضیحات این صفحه
    
    یک کنترل وجود دارد به نام 
    ExcelLikeTable

    در سمت سرور فیلد
   ExcelLikeTable.DataTable
     رو مقدار دهی کنید. 
    فیلد 
   ExcelLikeTable.ReadOnlyColumns
    ستون های غیر قابل تغییر رو تایین می کنه.

    بقیه ستون ها قابل ویرایش هستند.
    هر سلول جدول اگر غیر قابل ویرایش باشد یک 
    span
    است.
    اگر قابل ویرایش باشد یک
    <input type='input'
که دارای مقدار و یک
    <input type='hidden' 
    می باشد که دارای کلید مربوطه است
    -->
<script type="text/javascript">   

    $(document).ready(function () {
        var refresh = false;
        function ajaxRequest(address, data, that) {
            $.ajax({
                type: "POST",
                url: address,
                data: data,
                contentType: "application/json; charset=utf-8",
                success: function (msg) {
                    var m = msg.d;
                    console.log(m);
                    if (m.indexOf('(!!)') > -1) {
                        if (m.split('(!!)')[1].startsWith("+"))
                            $(".totalWeight").text(m.split('(!!)')[1].substr(1));
                        else
                            that.val(m.split('(!!)')[1]);
                        m = m.split('(!!)')[0];
                    }

                    if (m.length>0) {
                        var msg = $("#message");
                        msg.html(m);
                    }
                    if (refresh) {
                        refresh = false;
                        GetRadWindow()._iframe.contentWindow.location.href = GetRadWindow()._iframe.contentWindow.location.href;
                    }
                    return false;
                },
                error: function (xhr, status, error) {
                    $("#message").html(JSON.parse(xhr.responseText).Message);
                    return false;
                }
            });
        }
        // CheckWeightPercentage(string itemCode, string type, string value)
        $('input[type=text][id^="WeightPercentage_"]').blur(function () {
            var code = $("#hidden_" + $(this).attr("id")).val();
            ajaxRequest("Services/ProjectManagementService.asmx/CheckWeightPercentage", " {" +
                         " 'itemCode':'" + code + "'" +
                         ",'type':'<%= Request["Type"] %>'" +
                         ",'value':'" + $(this).val() + "'" +
                         "}",
                         $(this));
        });
        //EditItemDescription(string itemCode, string type, string description)
        $('input[type=text][id^="ItemDescription_"]').blur(function () {
            var code = $("#hidden_" + $(this).attr("id")).val();
            ajaxRequest("Services/ProjectManagementService.asmx/EditItemDescription",
                " {'itemCode':'" + code + "'" +
                         ",'type':'<%= Request["Type"] %>'" +
                         ",'description':'" + $(this).val() + "'}",
                         $(this));
        });
        //EditItemName(string itemCode,string type,string name)
        $('input[type=text][id^="Name_"]').blur(function () {
            var code = $("#hidden_" + $(this).attr("id")).val();
            ajaxRequest("Services/ProjectManagementService.asmx/EditItemName",
                " {'itemCode':'" + code + "'" +
                         ",'type':'<%= Request["Type"] %>'" +
                         ",'name':'" + $(this).val() + "'}",
                         $(this));
        });

        $('input[type=text]').keypress(function (e) {
            if (e.which == 13) {
                textboxes = $("input[type=text]");
                debugger;
                currentBoxNumber = textboxes.index(this);
                if (textboxes[currentBoxNumber + 1] != null) {
                    nextBox = textboxes[currentBoxNumber + 1]
                    nextBox.focus();
                    nextBox.select();
                    event.preventDefault();
                    return false
                }
            }
        });


        
        $('input[type=image][class="deleteItem"]').click(function () {
            var code = parseInt($(this).attr("tag"));
            if (confirm("آیا از حذف آیتم اطمینان دارید؟")) {
                ajaxRequest("Services/ProjectManagementService.asmx/DeleteAnItem",
                  ' {"itemCode":"' + code +
                  '","type":"<%= Request["Type"] %>","tag":"randomString"}',
                           $(this));
                refresh = true;
             //   $(this).parent().parent().remove();
            }
        });


        $('input[type=text][id^="WeightPercentage_0_1"]').focus();
        $('input[type=text][id="Name_0_0"]').focus();

    });

    function RefreshParentPage()//function in parent page
    {
        window.location.href = window.location.href;
    }
</script>

<script>
    function OnClienClosedTheWindow(sender, args) {
        RefreshParentPage();
    }
</script>
<style>
    .excellike{

    }
    input,span,p{
        text-align:center;
    }
    .ProjectOrTemplateNameLabel{
        margin:20px;
        font-size:20px;
        padding:20px;
    }
    table[id*=__ExcelLike_] tr:hover {
        background: rgba(200, 54, 54, 0.5);
    }
</style>
<p id="message" style="width: 95%;
    font-size: 25px;
    color: red;
    background: gray;
    text-shadow: 0px 0px 1px black;
    padding: 10px;
    position: fixed;">&nbsp;</p>

<div style="width: 100%;margin-top: 100px;">
    <telerik:RadToolBar runat="server" ID="tbrActions" OnButtonClick="tbrActions_ButtonClick" Width="100%">
        <Items>
            <telerik:RadToolBarButton ImageUrl="~/Images/Controls/toolbar_add.png" Text="افزودن آیتم اصلی" Value="AddMainNode" ></telerik:RadToolBarButton>
            </Items>
    </telerik:RadToolBar>
</div>
<asp:Label ID="lblProjectOrTemplateNname" runat="server" CssClass="ProjectOrTemplateNameLabel"></asp:Label>
<p style=""><strong>مجموع وزن ها : <strong class="totalWeight"></strong></strong></p>


<pm:ExcelLikeTable ID="excellike" runat="server" CssClass="excellike"/>

<p><strong>مجموع وزن ها : <strong class="totalWeight"></strong></strong></p>

<telerik:RadButton runat="server" ID="btnClose" Text="بازگشت" OnClientClicked="CloseDialog" AutoPostBack="false" Width="100px" Height="35px" />



