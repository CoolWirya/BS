<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="JTariffUpdateControl.ascx.cs" Inherits="WebBusManagement.FormsManagement.JTariffUpdateControl" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register Src="~/WebControllers/MainControls/Date/JDateControl.ascx" TagPrefix="uc1" TagName="JDateControl" %>
<%@ Register Src="~/WebControllers/MainControls/CustomListSelector/JCustomListSelectorControl.ascx" TagPrefix="uc3" TagName="JCustomListSelectorControl" %>
<script type="text/javascript">
    $(document).ready(function () {
        GetRadWindow().maximize();
        var height = $('#<%=this.Parent.Parent.ClientID%>').height();
        var width = $('#<%=this.Parent.Parent.ClientID%>').width();
        GetRadWindow().restore();
        GetRadWindow().setSize(width, height);
        GetRadWindow().center();
    });

    function ChangeServiceCode(Code) {
        alert('function ChangeServiceCode(Code)');
        window.location.href = 'TestPage1.aspx?intBatchID=' + Code.toString();
    }

</script>

<script runat=server>


</script>



<div class="BigTitle">تعرفه</div>
<div style="overflow:scroll; margin-bottom: 55px">   
<table style="width: 100%; height: auto; border: 1px solid black">
    <tr>
        <td colspan="8" style="padding-right: 38px">
            <telerik:RadTextBox runat="server" ID="txtTarrifCode" Width="60px" EmptyMessage="کد تعرفه"></telerik:RadTextBox>
            <telerik:RadButton runat="server" ID="BtnSearchTarrif" Text="جستجو" AutoPostBack="true" Width="60px" Height="18px" OnClick="BtnSearchTarrif_Click" />
        </td>
    </tr>
    <tr>
        <td>تاریخ</td>
        <td>
            <uc1:JDateControl runat="server" id="txtStartDate" />
        </td>
        <td>شیفت</td>
        <td>
            <telerik:RadComboBox runat="server" ID="cmbShift" Width="90%"></telerik:RadComboBox>
        </td>
        <td>نحوه همکاری</td>
        <td>
            <telerik:RadComboBox runat="server" ID="txtDriverWorkType" Width="90%"></telerik:RadComboBox>
        </td>
        <td>تعداد سرویس</td>
        <td>
            <telerik:RadTextBox runat="server" ID="txtNumOfService" Width="50px" MaxLength="5"></telerik:RadTextBox></td>
    </tr>
    <tr>
        <td>مسیر</td>
        <td>
            <telerik:RadComboBox runat="server" ID="cmbLine" Width="90%" Filter="Contains"></telerik:RadComboBox>
        </td>
        <td>منطقه</td>
        <td>
            <telerik:RadComboBox runat="server" ID="cmbZone" Width="90%"></telerik:RadComboBox>
        </td>
        <td>وضعیت</td>
        <td>
            <telerik:RadComboBox runat="server" ID="txtDriverWorkStatus" Width="90%"></telerik:RadComboBox>
        </td>
        <td>مشخصات</td>
        <td>
            <uc3:JCustomListSelectorControl runat="server" id="JCustomListSelectorControl1" />
        </td>
    </tr>
    <tr>
        <td>اتوبوس</td>
        <td>
            <telerik:RadComboBox runat="server" ID="cmbBus" Width="85%" Filter="Contains"></telerik:RadComboBox>
        </td>
        <td>عنوان شغلی</td>
        <td>
            <telerik:RadComboBox runat="server" ID="txtOnvaneShoghli" Width="90%"></telerik:RadComboBox>
        </td>
        <td>فعالیت</td>
        <td>
            <telerik:RadComboBox runat="server" ID="txtFaaliyat" Width="90%"></telerik:RadComboBox>
        </td>
        <td>گزارش</td>
        <td>
            <telerik:RadComboBox runat="server" ID="txtReportCode" Width="90%"></telerik:RadComboBox>
        </td>
    </tr>
    <tr>
        <td>حداقل تعداد تراکنش خط</td>
        <td>
            <telerik:RadTextBox runat="server" ID="txtTransactionCount" Width="150px"></telerik:RadTextBox>
        </td>
        <td>حداقل تعداد سرویس</td>
        <td>
            <telerik:RadTextBox runat="server" ID="txtMinNumOfService" Width="150px"></telerik:RadTextBox>
        </td>
        <td></td>
        <td>
           
        </td>
        <td></td>
        <td>
            
        </td>
    </tr>
</table>
<table style="width: 100%; height: auto; border: 1px solid black">
    <tr>
        <td style="width: 22%; display: inline-block; border-left: 1px solid black; vertical-align:top">
            <table style="width: 100%">
                <tr>
                    <td style="border-left: 1px solid black; border-bottom: 1px solid black">شروع به کار : </td>
                    <td style="direction: ltr; text-align: center; border-bottom: 1px solid black">
                        <asp:RangeValidator ID="RangeValidator3" runat="server" ErrorMessage="00 تا 23" ControlToValidate="txtStartTimeHour" MinimumValue="00"
                            MaximumValue="23" Display="Dynamic"></asp:RangeValidator>
                        <telerik:RadTextBox runat="server" ID="txtStartTimeHour" Width="40px" MaxLength="2" EmptyMessage="ساعت" ReadOnly="true"></telerik:RadTextBox>
                        :
                    <telerik:RadTextBox runat="server" ID="txtStartTimeMinute" Width="40px" MaxLength="2" EmptyMessage="دقیقه" ReadOnly="true"></telerik:RadTextBox>
                        <asp:RangeValidator ID="RangeValidator4" runat="server" ErrorMessage="00 تا 59" ControlToValidate="txtStartTimeMinute" MinimumValue="00"
                            MaximumValue="59" Display="Dynamic"></asp:RangeValidator>
                    </td>
                </tr>
                <tr>
                    <td style="border-left: 1px solid black; border-bottom: 1px solid black">پایان کار : </td>
                    <td style="direction: ltr; text-align: center; border-bottom: 1px solid black">
                        <asp:RangeValidator ID="RangeValidator1" runat="server" ErrorMessage="00 تا 23" ControlToValidate="txtFinishTimeHour" MinimumValue="00"
                            MaximumValue="23" Display="Dynamic"></asp:RangeValidator>
                        <telerik:RadTextBox runat="server" ID="txtFinishTimeHour" Width="40px" MaxLength="2" EmptyMessage="ساعت" ReadOnly="true"></telerik:RadTextBox>
                        :
                    <telerik:RadTextBox runat="server" ID="txtFinishTimeMinute" Width="40px" MaxLength="2" EmptyMessage="دقیقه" ReadOnly="true"></telerik:RadTextBox>
                        <asp:RangeValidator ID="RangeValidator2" runat="server" ErrorMessage="00 تا 59" ControlToValidate="txtFinishTimeMinute" MinimumValue="00"
                            MaximumValue="59" Display="Dynamic"></asp:RangeValidator>
                    </td>
                </tr>
                <tr>
                    <td style="border-left: 1px solid black; border-bottom: 1px solid black">اضافه سرویس : </td>
                    <td style="direction: ltr; text-align: center; border-bottom: 1px solid black">
                        <telerik:RadTextBox runat="server" ID="txtExtraServices" Width="93px" ReadOnly="true"></telerik:RadTextBox>
                    </td>
                </tr>
                <tr>
                    <td style="border-left: 1px solid black; border-bottom: 1px solid black">پاداش : </td>
                    <td style="direction: ltr; text-align: center; border-bottom: 1px solid black">
                        <telerik:RadTextBox runat="server" ID="RadTextBox2" Width="93px" ReadOnly="true"></telerik:RadTextBox>
                    </td>
                </tr>
                <tr>
                    <td style="border-left: 1px solid black; border-bottom: 1px solid black">شبکاری : </td>
                    <td style="direction: ltr; text-align: center; border-bottom: 1px solid black">
                        <telerik:RadTextBox runat="server" ID="RadTextBox3" Width="93px" ReadOnly="true"></telerik:RadTextBox>
                    </td>
                </tr>
                <tr>
                    <td style="border-left: 1px solid black; border-bottom: 1px solid black">کسری سرویس : </td>
                    <td style="direction: ltr; text-align: center; border-bottom: 1px solid black">
                        <telerik:RadTextBox runat="server" ID="txtServiceDeficiency" Width="93px" ReadOnly="true"></telerik:RadTextBox>
                    </td>
                </tr>
                <tr>
                    <td style="border-left: 1px solid black; border-bottom: 1px solid black">کسر کار : </td>
                    <td style="direction: ltr; text-align: center; border-bottom: 1px solid black">
                        <telerik:RadTextBox runat="server" ID="RadTextBox5" Width="93px" ReadOnly="true"></telerik:RadTextBox>
                    </td>
                </tr>
                <tr>
                    <td style="border-left: 1px solid black; border-bottom: 1px solid black">تعداد بلیط راننده : </td>
                    <td style="direction: ltr; text-align: center; border-bottom: 1px solid black">
                        <telerik:RadTextBox runat="server" ID="RadTextBox6" Width="93px" ReadOnly="true"></telerik:RadTextBox>
                    </td>
                </tr>
                <tr>
                    <td style="border-left: 1px solid black; border-bottom: 1px solid black">تعداد بلیط کمک : </td>
                    <td style="direction: ltr; text-align: center; border-bottom: 1px solid black">
                        <telerik:RadTextBox runat="server" ID="RadTextBox7" Width="93px" ReadOnly="true"></telerik:RadTextBox>
                    </td>
                </tr>
            </table>
            <table style="width: 100%">
                <tr>
                    <td style="border-left: 1px solid black; width: 20%; border-bottom: 1px solid black">مسیر</td>
                    <td style="border-left: 1px solid black; width: 20%; border-bottom: 1px solid black"></td>
                    <td style="border-left: 1px solid black; width: 20%; border-bottom: 1px solid black"></td>
                    <td style="border-left: 1px solid black; width: 20%; border-bottom: 1px solid black"></td>
                    <td style="border-bottom: 1px solid black"></td>
                </tr>
                <tr>
                    <td style="border-left: 1px solid black; width: 20%; border-bottom: 1px solid black">تعداد</td>
                    <td style="border-left: 1px solid black; width: 20%; border-bottom: 1px solid black"></td>
                    <td style="border-left: 1px solid black; width: 20%; border-bottom: 1px solid black"></td>
                    <td style="border-left: 1px solid black; width: 20%; border-bottom: 1px solid black"></td>
                    <td style="border-bottom: 1px solid black"></td>
                </tr>
                <tr>
                    <td colspan="5" style="height: 110px">امضاء بازرس</td>
                </tr>
            </table>
        </td>
        <td style="border-left: 1px solid black;width: 75%; max-height:400px; display: inline-block; overflow: scroll; vertical-align: top">
            <asp:Panel ID="PanelGrid" runat="server">
                
                <asp:GridView ID="RadGridReport"   runat="server" Width="100%" HorizontalAlign="Center"
                    RowStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" RowStyle-ForeColor="Black"
                    OnSelectedIndexChanged="RadGridReport_SelectedIndexChanged" EnableModelValidation="True" OnRowDataBound="RadGridReport_RowDataBound" OnRowCreated="RadGridReport_RowCreated"
                    OnRowCommand="RadGridReport_RowCommand">
                    <Columns>
                        <asp:ButtonField CommandName="Select" HeaderText="انتخاب" ShowHeader="True" Text="انتخاب"
                            ButtonType="Link" />
                <asp:TemplateField HeaderText="نمایش">
                    <ItemTemplate>
                        <asp:LinkButton ID="lbnShow" CommandName="Show" CommandArgument='<%# Eval("کد") %>' runat="server" Text="نمایش" ></asp:LinkButton><%--Visible='<%# (Bind("Event") == "Auto" || Bind("Event") == "Manual") ? "True" :"False" %>'--%>
                    </ItemTemplate>
                </asp:TemplateField>
                    </Columns> 
                    <RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Center" />
                    <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#F7F7F7" />
                </asp:GridView>
                <br />
                <center>
                <input type="hidden" id="EditCode" name="EditCode" value="0" runat="server" />
                <input type="hidden" id="IsService" name="IsService" value="" runat="server" />
                <telerik:RadButton runat="server" ID="BtnIsOk" Text="تایید / عدم تایید" AutoPostBack="true" Width="100px" Height="35px" OnClick="BtnIsOk_Click" Visible="false" />
                <telerik:RadButton runat="server" ID="BtnDeleteService" Text="حذف" AutoPostBack="true" Width="100px" Height="35px" OnClick="BtnDeleteService_Click" Visible="false" />
                </center>
            </asp:Panel>
            <asp:Panel ID="PanelTable" runat="server">
                <table style="width: 100%" id="TblEzam">
                    <tr>
                        <td style="border-left: 1px solid black; border-bottom: 1px solid black; text-align: center">ردیف</td>
                        <td style="border-left: 1px solid black; border-bottom: 1px solid black; text-align: center">اعزام</td>
                        <td style="border-left: 1px solid black; border-bottom: 1px solid black; text-align: center">کد راننده</td>
                        <td style="border-left: 1px solid black; border-bottom: 1px solid black; text-align: center">اتوبوس</td>
                        <td style="border-left: 1px solid black; border-bottom: 1px solid black; text-align: center">از ساعت</td>
                        <td style="border-left: 1px solid black; border-bottom: 1px solid black; text-align: center">ساعت</td>
                        <td style="border-left: 1px solid black; border-bottom: 1px solid black; text-align: center">تا ساعت</td>
                    </tr>
                    <tr style="height: 30px">
                        <td style="border-left: 1px solid black; border-bottom: 1px solid black; text-align: center">1</td>
                        <td style="border-left: 1px solid black; border-bottom: 1px solid black; text-align: center"></td>
                        <td style="border-left: 1px solid black; border-bottom: 1px solid black; text-align: center"></td>
                        <td style="border-left: 1px solid black; border-bottom: 1px solid black; text-align: center"></td>
                        <td style="border-left: 1px solid black; border-bottom: 1px solid black; text-align: center"></td>
                        <td style="border-left: 1px solid black; border-bottom: 1px solid black; text-align: center"></td>
                        <td style="border-left: 1px solid black; border-bottom: 1px solid black; text-align: center"></td>
                    </tr>
                    <tr style="height: 30px">
                        <td style="border-left: 1px solid black; border-bottom: 1px solid black; text-align: center">2</td>
                        <td style="border-left: 1px solid black; border-bottom: 1px solid black; text-align: center"></td>
                        <td style="border-left: 1px solid black; border-bottom: 1px solid black; text-align: center"></td>
                        <td style="border-left: 1px solid black; border-bottom: 1px solid black; text-align: center"></td>
                        <td style="border-left: 1px solid black; border-bottom: 1px solid black; text-align: center"></td>
                        <td style="border-left: 1px solid black; border-bottom: 1px solid black; text-align: center"></td>
                        <td style="border-left: 1px solid black; border-bottom: 1px solid black; text-align: center"></td>
                    </tr>
                    <tr style="height: 30px">
                        <td style="border-left: 1px solid black; border-bottom: 1px solid black; text-align: center">3</td>
                        <td style="border-left: 1px solid black; border-bottom: 1px solid black; text-align: center"></td>
                        <td style="border-left: 1px solid black; border-bottom: 1px solid black; text-align: center"></td>
                        <td style="border-left: 1px solid black; border-bottom: 1px solid black; text-align: center"></td>
                        <td style="border-left: 1px solid black; border-bottom: 1px solid black; text-align: center"></td>
                        <td style="border-left: 1px solid black; border-bottom: 1px solid black; text-align: center"></td>
                        <td style="border-left: 1px solid black; border-bottom: 1px solid black; text-align: center"></td>
                    </tr>
                    <tr style="height: 30px">
                        <td style="border-left: 1px solid black; border-bottom: 1px solid black; text-align: center">4</td>
                        <td style="border-left: 1px solid black; border-bottom: 1px solid black; text-align: center"></td>
                        <td style="border-left: 1px solid black; border-bottom: 1px solid black; text-align: center"></td>
                        <td style="border-left: 1px solid black; border-bottom: 1px solid black; text-align: center"></td>
                        <td style="border-left: 1px solid black; border-bottom: 1px solid black; text-align: center"></td>
                        <td style="border-left: 1px solid black; border-bottom: 1px solid black; text-align: center"></td>
                        <td style="border-left: 1px solid black; border-bottom: 1px solid black; text-align: center"></td>
                    </tr>
                    <tr style="height: 30px">
                        <td style="border-left: 1px solid black; border-bottom: 1px solid black; text-align: center">5</td>
                        <td style="border-left: 1px solid black; border-bottom: 1px solid black; text-align: center"></td>
                        <td style="border-left: 1px solid black; border-bottom: 1px solid black; text-align: center"></td>
                        <td style="border-left: 1px solid black; border-bottom: 1px solid black; text-align: center"></td>
                        <td style="border-left: 1px solid black; border-bottom: 1px solid black; text-align: center"></td>
                        <td style="border-left: 1px solid black; border-bottom: 1px solid black; text-align: center"></td>
                        <td style="border-left: 1px solid black; border-bottom: 1px solid black; text-align: center"></td>
                    </tr>
                    <tr style="height: 30px">
                        <td style="border-left: 1px solid black; border-bottom: 1px solid black; text-align: center">6</td>
                        <td style="border-left: 1px solid black; border-bottom: 1px solid black; text-align: center"></td>
                        <td style="border-left: 1px solid black; border-bottom: 1px solid black; text-align: center"></td>
                        <td style="border-left: 1px solid black; border-bottom: 1px solid black; text-align: center"></td>
                        <td style="border-left: 1px solid black; border-bottom: 1px solid black; text-align: center"></td>
                        <td style="border-left: 1px solid black; border-bottom: 1px solid black; text-align: center"></td>
                        <td style="border-left: 1px solid black; border-bottom: 1px solid black; text-align: center"></td>
                    </tr>
                    <tr style="height: 30px">
                        <td style="border-left: 1px solid black; border-bottom: 1px solid black; text-align: center">7</td>
                        <td style="border-left: 1px solid black; border-bottom: 1px solid black; text-align: center"></td>
                        <td style="border-left: 1px solid black; border-bottom: 1px solid black; text-align: center"></td>
                        <td style="border-left: 1px solid black; border-bottom: 1px solid black; text-align: center"></td>
                        <td style="border-left: 1px solid black; border-bottom: 1px solid black; text-align: center"></td>
                        <td style="border-left: 1px solid black; border-bottom: 1px solid black; text-align: center"></td>
                        <td style="border-left: 1px solid black; border-bottom: 1px solid black; text-align: center"></td>
                    </tr>
                    <tr style="height: 30px">
                        <td style="border-left: 1px solid black; border-bottom: 1px solid black; text-align: center">8</td>
                        <td style="border-left: 1px solid black; border-bottom: 1px solid black; text-align: center"></td>
                        <td style="border-left: 1px solid black; border-bottom: 1px solid black; text-align: center"></td>
                        <td style="border-left: 1px solid black; border-bottom: 1px solid black; text-align: center"></td>
                        <td style="border-left: 1px solid black; border-bottom: 1px solid black; text-align: center"></td>
                        <td style="border-left: 1px solid black; border-bottom: 1px solid black; text-align: center"></td>
                        <td style="border-left: 1px solid black; border-bottom: 1px solid black; text-align: center"></td>
                    </tr>
                    <tr style="height: 30px">
                        <td style="border-left: 1px solid black; border-bottom: 1px solid black; text-align: center">9</td>
                        <td style="border-left: 1px solid black; border-bottom: 1px solid black; text-align: center"></td>
                        <td style="border-left: 1px solid black; border-bottom: 1px solid black; text-align: center"></td>
                        <td style="border-left: 1px solid black; border-bottom: 1px solid black; text-align: center"></td>
                        <td style="border-left: 1px solid black; border-bottom: 1px solid black; text-align: center"></td>
                        <td style="border-left: 1px solid black; border-bottom: 1px solid black; text-align: center"></td>
                        <td style="border-left: 1px solid black; border-bottom: 1px solid black; text-align: center"></td>
                    </tr>
                    <tr style="height: 30px">
                        <td style="border-left: 1px solid black; border-bottom: 1px solid black; text-align: center">10</td>
                        <td style="border-left: 1px solid black; border-bottom: 1px solid black; text-align: center"></td>
                        <td style="border-left: 1px solid black; border-bottom: 1px solid black; text-align: center"></td>
                        <td style="border-left: 1px solid black; border-bottom: 1px solid black; text-align: center"></td>
                        <td style="border-left: 1px solid black; border-bottom: 1px solid black; text-align: center"></td>
                        <td style="border-left: 1px solid black; border-bottom: 1px solid black; text-align: center"></td>
                        <td style="border-left: 1px solid black; border-bottom: 1px solid black; text-align: center"></td>
                    </tr>
                </table>
            </asp:Panel>
        </td>
    </tr>
</table>
<div class="FormButtons">
    <telerik:RadButton runat="server" ID="btnSave" Text="ذخیره" AutoPostBack="true" Width="100px" Height="35px" OnClick="btnSave_Click" OnClientClicked="LockButton" ValidationGroup="Tariff" />
    <telerik:RadButton runat="server" ID="OkAllServicesButton" Text="تائید" AutoPostBack="true" Width="100px" Height="35px" OnClick="OkAllServicesButton_Click" OnClientClicked="LockButton" />
    <telerik:RadButton runat="server" ID="btnReCalculate" Text="بررسی مجدد" AutoPostBack="true" Width="100px" Height="35px" OnClick="btnReCalculate_Click"/>
    <telerik:RadButton runat="server" ID="btnPrint" Text="چاپ" AutoPostBack="true" Width="100px" Height="35px" OnClick="btnPrintClick"  OnClientClicked="LockButton" />
    <telerik:RadButton runat="server" ID="btnClose" Text="بازگشت" OnClientClicked="CloseDialog" AutoPostBack="false" Width="100px" Height="35px" />
    <telerik:RadButton runat="server" ID="btnInsertEzamBe" Text="ثبت اعزام به" AutoPostBack="true" Width="100px" Height="35px" OnClick="btnInsertEzamBe_Click" CssClass="floatLeft" Visible="false" />
    <telerik:RadButton runat="server" ID="btnDelete" Text="حذف" AutoPostBack="true" Width="100px" Height="35px" OnClick="btnDelete_Click" CssClass="floatLeft" OnClientClicking="OnClientClicking" />
</div>
</div>
