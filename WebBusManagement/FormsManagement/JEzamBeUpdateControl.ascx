<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="JEzamBeUpdateControl.ascx.cs" Inherits="WebBusManagement.FormsManagement.JEzamBeUpdateControl" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register Assembly="WebControllers" Namespace="WebControllers.MainControls.Grid" TagPrefix="cc1" %>
<%@ Register Src="~/WebControllers/MainControls/CustomListSelector/JCustomListSelectorControl.ascx" TagPrefix="uc1" TagName="JCustomListSelectorControl" %>

<script type="text/javascript">
    $(document).ready(function () {
        GetRadWindow().maximize();
    });
</script>
<input type="hidden" id="hidEditCode" name="hidEditCode" value="0" runat="server" /> 
<input type="hidden" id="hidIsService" name="hidIsService" value="False" runat="server" />
<div class="BigTitle">اعزام به</div>
<div style="width:50%; min-width: 300px; height: auto; float: right">
    <table style="width: 100%">
        <tr class="Table_RowB">
            <td style="width: 150px">شماره تعرفه:</td>
            <td>
                <telerik:RadTextBox runat="server" ID="txtTariffCode" Width="50px" ReadOnly="true"></telerik:RadTextBox>
            </td>
        </tr>
        <tr class="Table_RowC">
            <td style="width: 150px">تاریخ:</td>
            <td>
                <telerik:RadTextBox runat="server" ID="txtDate" Width="100px" ReadOnly="true"></telerik:RadTextBox>
            </td>
        </tr>
        <tr class="Table_RowB">
            <td style="width: 150px">راننده:</td>
            <td>
                <%--<telerik:RadComboBox runat="server" ID="cmbDriversName" Width="150px"></telerik:RadComboBox>--%>
                <uc1:JCustomListSelectorControl runat="server" id="JCustomListSelectorControl1" />

            </td>
        </tr>
        <tr class="Table_RowB">
            <td style="width: 150px">مسیر:</td>
            <td>
                <telerik:RadComboBox runat="server" ID="cmbLine" Width="90%" Filter="Contains"></telerik:RadComboBox>
            </td>
        </tr>
        <tr class="Table_RowB">
            <td style="width: 150px">اعزام به:</td>
            <td>
                <telerik:RadComboBox runat="server" ID="cmbEzamBe" Width="90%"></telerik:RadComboBox>
            </td>
        </tr>
        <tr class="Table_RowC">
            <td style="width: 150px">اتوبوس به جا:</td>
            <td>
                <telerik:RadComboBox runat="server" ID="cmbBus" Width="90%" Filter="Contains"></telerik:RadComboBox>
            </td>
        </tr>
        <tr class="Table_RowB">
            <td style="width: 150px">تعداد سرویس:</td>
            <td>
                <telerik:RadTextBox runat="server" ID="txtNumOfService" Width="100px"></telerik:RadTextBox>
            </td>
        </tr>
        <tr class="Table_RowC">
            <td>شروع به کار : </td>
            <td style="direction: ltr">
                <asp:RangeValidator ID="RangeValidator3" runat="server" ErrorMessage="00 تا 23" ControlToValidate="txtStartTimeHour" MinimumValue="00"
                    MaximumValue="23" Display="Dynamic" ValidationGroup="a" Type="Integer"></asp:RangeValidator>
                <telerik:RadTextBox runat="server" ID="txtStartTimeHour" Width="40px" MaxLength="2" EmptyMessage="ساعت"></telerik:RadTextBox>
                :
                    <telerik:RadTextBox runat="server" ID="txtStartTimeMinute" Width="40px" MaxLength="2" EmptyMessage="دقیقه"></telerik:RadTextBox>
                <asp:RangeValidator ID="RangeValidator4" runat="server" ErrorMessage="00 تا 59" ControlToValidate="txtStartTimeMinute" MinimumValue="00"
                    MaximumValue="59" Display="Dynamic" ValidationGroup="a" Type="Integer"></asp:RangeValidator>
            </td>
        </tr>
        <tr class="Table_RowB">
            <td>پایان کار : </td>
            <td style="direction: ltr">
                <asp:RangeValidator ID="RangeValidator1" runat="server" ErrorMessage="00 تا 23" ControlToValidate="txtFinishTimeHour" MinimumValue="00"
                    MaximumValue="23" Display="Dynamic" ValidationGroup="a" Type="Integer"></asp:RangeValidator>
                <telerik:RadTextBox runat="server" ID="txtFinishTimeHour" Width="40px" MaxLength="2" EmptyMessage="ساعت"></telerik:RadTextBox>
                :
                    <telerik:RadTextBox runat="server" ID="txtFinishTimeMinute" Width="40px" MaxLength="2" EmptyMessage="دقیقه"></telerik:RadTextBox>
                <asp:RangeValidator ID="RangeValidator2" runat="server" ErrorMessage="00 تا 59" ControlToValidate="txtFinishTimeMinute" MinimumValue="00"
                    MaximumValue="59" Display="Dynamic" ValidationGroup="a" Type="Integer"></asp:RangeValidator>
            </td>
        </tr>
<%--        <tr>
            <td></td>
            <td>
            </td>
        </tr>--%>
    </table>
</div>
<div style="float: right; width:50%; height: 75%; overflow-x:scroll;">
    <div style="width: 620px;">   
    <%-- <cc1:JGridView runat="server" id="RadGridReport">--%>

    <asp:GridView ID="RadGridReport" runat="server" Width="100%" HorizontalAlign="Center"
        RowStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" RowStyle-ForeColor="Black"
        OnSelectedIndexChanged="RadGridReport_SelectedIndexChanged" EnableModelValidation="True" OnRowDataBound="RadGridReport_RowDataBound">
        <Columns>
            <asp:ButtonField CommandName="Select" HeaderText="انتخاب" ShowHeader="True" Text="انتخاب"
                ButtonType="Link" />
        </Columns>
        <RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#F7F7F7" />
    </asp:GridView>
    <br />
    <center>
        <telerik:RadButton runat="server" ID="BtnIsOk" Text="تایید / عدم تایید" AutoPostBack="true" Width="100px" Height="35px" OnClick="BtnIsOk_Click" Visible="false" />
        <telerik:RadButton runat="server" ID="BtnDeleteEzamBe" Text="حذف" AutoPostBack="true" Width="100px" Height="35px" OnClick="BtnDeleteEzamBe_Click" Visible="false" />
    </center>
    </div>
</div>
<div class="FormButtons">
    <telerik:RadButton runat="server" ID="BtnSaveAndLoadGrid" Text="ذخیره" AutoPostBack="true" Width="100px" Height="35px" OnClick="BtnSaveAndLoadGrid_Click" ValidationGroup="a" />
    <telerik:RadButton runat="server" ID="btnSave" Text="ذخیره" AutoPostBack="true" Width="100px" Height="35px" OnClick="btnSave_Click" Visible="false" />
    <telerik:RadButton runat="server" ID="btnClose" Text="بازگشت" OnClientClicked="CloseDialog" AutoPostBack="false" Width="100px" Height="35px" />
    <%--<telerik:RadButton runat="server" ID="btnDelete" Text="حذف" AutoPostBack="true" Width="100px" Height="35px" OnClick="btnDelete_Click" CssClass="floatLeft" OnClientClicking="OnClientClicking" />--%>
</div>

