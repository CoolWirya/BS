<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="JSharePaymentTypeControl.ascx.cs" Inherits="WebManagementShare.Forms.JSharePaymentTypeControl" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register Src="~/WebControllers/MainControls/Grid/JGridViewControl.ascx" TagPrefix="uc1" TagName="JGridViewControl" %>

<style>
    .BigTitleLocal {
        font-size: 24px;
        font-family: MyBYekan;
        border-bottom: 3px solid #808080;
        margin-bottom: 10px;
        padding-right: 5px;
        background-color: #EEE;
    }
    .RbL {
    font-size : 50px;
    color:blue;
    }
</style>
<div class="BigTitleLocal">نحوه پرداخت سود</div>
<div class="FormContent">
    <table style="width: 100%; padding-top: 50px">
        <tr>
            <td style="text-align: right; direction: rtl; font-size: 20px; padding-right: 20px">
                <%=ShareHolderStr %>
                <%--<asp:RadioButtonList ID="RbChoiceSelectPayment" runat="server" Font-Size="40px" ForeColor="Blue" CssClass="RbL">
                    <asp:ListItem Enabled="true" Selected="True" Text="اینجانب ضمن تایید مشخصات فوق متقاضی افزایش تعداد سهام از محل سود تعلق گرفته می باشم" Value="0"></asp:ListItem>
                    <asp:ListItem Enabled="true" Text="اینجانب ضمن تایید مشخصات فوق درخواست می نمایم سود تعلق گرفته سهام به حساب بانکی خودم واریز گردد" Value="1"></asp:ListItem>
                </asp:RadioButtonList>--%>
                <div id="a1">لیست افرادی که متقاضی افزایش سهام می باشند</div>
                <div style="clear:both;height:2px"></div>
                <div id="a2" style="width:50%;height:auto;text-align:center;overflow:auto;float:right">
                    <uc1:JGridViewControl runat="server" id="RadGridReport" />
                </div>
                <%--<div style="clear:both;height:2px"></div>--%>
                <div style="width:50%;height:auto;text-align:center;overflow:auto;float:right">
                <div id="b1" style="font-size:20px;color:blue">لطفا یکی از گزینه های ذیل را انتخاب کنید : </div>
                <div style="clear:both;height:2px"></div>
                <asp:RadioButton ID="RbSaham" runat="server" Checked="true" GroupName="a"  Font-Size="40px" ForeColor="Blue" Text=""/>
                <div id="b2" style="font-size:25px;color:blue;text-align:right">اینجانب ضمن تایید مشخصات فوق متقاضی افزایش تعداد سهام از محل سود تعلق گرفته می باشم</div>
                <div style="clear:both;height:5px"></div>
                <asp:RadioButton ID="RbPool" runat="server" Checked="false" GroupName="a"  Font-Size="40px" ForeColor="Blue" Text=""/>
                <div id="b3" style="font-size:25px;color:blue;text-align:right">اینجانب ضمن تایید مشخصات فوق درخواست می نمایم سود تعلق گرفته سهام به حساب بانکی خودم واریز گردد</div>
                <div style="clear:both;height:2px"></div>
                    </div>
                <%=ShareHolderStrStatus %>
                <div style="clear:both;height:5px"></div>
                <center> 
                    <telerik:radbutton runat="server" id="btnSave" text="تایید می نمایم" autopostback="true" width="100px" height="35px" onclick="btnSave_Click" validationgroup="CPrint" />
    <telerik:radbutton runat="server" id="btnClose" text="تایید نمی نمایم" onclientclicked="CloseDialog" autopostback="false" width="100px" height="35px" />

                </center>
                <br />
                توجه - در صورت مغایرت شماره حساب باید شخصا به شرکت سیر طوس ماندگار مراجعه فرمایید
            </td>
        </tr>
    </table>
</div>
<input type="hidden" id="editemode" name="editmode" runat="server" value="0"/>
<script>
    if ($("#<%=editemode.ClientID %>").val() == 1)
    {
        $("#a1").css('display', 'none');
        $("#a2").css('display', 'none');
        $("#b1").css('display', 'none');
        $("#b2").css('display', 'none');
        $("#b3").css('display', 'none');
    }
</script>
