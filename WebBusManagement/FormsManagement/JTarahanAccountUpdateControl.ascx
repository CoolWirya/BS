<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="JTarahanAccountUpdateControl.ascx.cs" Inherits="WebBusManagement.FormsManagement.JTarahanAccountUpdateControl" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register Assembly="WebControllers" Namespace="WebControllers.MainControls.Grid" TagPrefix="cc1" %>

<script type="text/javascript">
    $(document).ready(function () {
        GetRadWindow().maximize();
    });
</script>

<div class="BigTitle"></div>
<table style="width: 350px">
    <tr class="Table_RowB">
        <td style="width: 150px">پیمانکار:</td>
        <td>
            <telerik:RadComboBox runat="server" ID="cmbFleets" Width="100%" Filter="Contains">
            </telerik:RadComboBox>
        </td>
    </tr>
    <tr class="Table_RowC">
        <td style="width: 150px">سال:</td>
        <td>
            <telerik:RadComboBox runat="server" ID="cmbYears" Width="100%" Filter="Contains">
            </telerik:RadComboBox>
        </td>
    </tr>
    <tr class="Table_RowB">
        <td style="width: 150px">ماه:</td>
        <td>
            <telerik:RadComboBox runat="server" ID="cmbMount" Width="100%" Filter="Contains">
                <Items>
                    <telerik:RadComboBoxItem Value="1" Text="فروردین" Selected="true" />
                    <telerik:RadComboBoxItem Value="2" Text="اردیبهشت" />
                    <telerik:RadComboBoxItem Value="3" Text="خرداد" />
                    <telerik:RadComboBoxItem Value="4" Text="تیر" />
                    <telerik:RadComboBoxItem Value="5" Text="مرداد" />
                    <telerik:RadComboBoxItem Value="6" Text="شهریور" />
                    <telerik:RadComboBoxItem Value="7" Text="مهر" />
                    <telerik:RadComboBoxItem Value="8" Text="آبان" />
                    <telerik:RadComboBoxItem Value="9" Text="آذر" />
                    <telerik:RadComboBoxItem Value="10" Text="دی" />
                    <telerik:RadComboBoxItem Value="11" Text="بهمن" />
                    <telerik:RadComboBoxItem Value="12" Text="اسفند" />
                </Items>
            </telerik:RadComboBox>
        </td>
    </tr>
    <tr class="Table_RowC" id="InputData" runat="server">
        <td style="width: 150px"></td>
        <td>
            <table>
                <tr>
                    <td>1</td><td><input  runat="server" id="DocCode1" type="text" style="width:100px"/></td>
                    <td><input runat="server" id="Pay1" type="text" style="width:100px"/></td>
                </tr>
                <tr>
                    <td>2</td><td><input  runat="server" id="DocCode2" type="text" style="width:100px"/></td>
                    <td><input runat="server" id="Pay2" type="text" style="width:100px"/></td>
                </tr>
                <tr>
                    <td>3</td><td><input  runat="server" id="DocCode3" type="text" style="width:100px"/></td>
                    <td><input runat="server" id="Pay3" type="text" style="width:100px"/></td>
                </tr>
                <tr>
                    <td>4</td><td><input  runat="server" id="DocCode4" type="text" style="width:100px"/></td>
                    <td><input runat="server" id="Pay4" type="text" style="width:100px"/></td>
                </tr>
                <tr>
                    <td>5</td><td><input  runat="server" id="DocCode5" type="text" style="width:100px"/></td>
                    <td><input runat="server" id="Pay5" type="text" style="width:100px"/></td>
                </tr>
                <tr>
                    <td>6</td><td><input  runat="server" id="DocCode6" type="text" style="width:100px"/></td>
                    <td><input runat="server" id="Pay6" type="text" style="width:100px"/></td>
                </tr>
                <tr>
                    <td>7</td><td><input  runat="server" id="DocCode7" type="text" style="width:100px"/></td>
                    <td><input runat="server" id="Pay7" type="text" style="width:100px"/></td>
                </tr>
                <tr>
                    <td>8</td><td><input  runat="server" id="DocCode8" type="text" style="width:100px"/></td>
                    <td><input runat="server" id="Pay8" type="text" style="width:100px"/></td>
                </tr>
                <tr>
                    <td>9</td><td><input  runat="server" id="DocCode9" type="text" style="width:100px"/></td>
                    <td><input runat="server" id="Pay9" type="text" style="width:100px"/></td>
                </tr>
                <tr>
                    <td>10</td><td><input  runat="server" id="DocCode10" type="text" style="width:100px"/></td>
                    <td><input runat="server" id="Pay10" type="text" style="width:100px"/></td>
                </tr>
                <tr>
                    <td>11</td><td><input  runat="server" id="DocCode11" type="text" style="width:100px"/></td>
                    <td><input runat="server" id="Pay11" type="text" style="width:100px"/></td>
                </tr>
                <tr>
                    <td>12</td><td><input  runat="server" id="DocCode12" type="text" style="width:100px"/></td>
                    <td><input runat="server" id="Pay12" type="text" style="width:100px"/></td>
                </tr>
                <tr>
                    <td>13</td><td><input  runat="server" id="DocCode13" type="text" style="width:100px"/></td>
                    <td><input runat="server" id="Pay13" type="text" style="width:100px"/></td>
                </tr>
                <tr>
                    <td>14</td><td><input  runat="server" id="DocCode14" type="text" style="width:100px"/></td>
                    <td><input runat="server" id="Pay14" type="text" style="width:100px"/></td>
                </tr>
                <tr>
                    <td>15</td><td><input  runat="server" id="DocCode15" type="text" style="width:100px"/></td>
                    <td><input runat="server" id="Pay15" type="text" style="width:100px"/></td>
                </tr>
                <tr>
                    <td>16</td><td><input  runat="server" id="DocCode16" type="text" style="width:100px"/></td>
                    <td><input runat="server" id="Pay16" type="text" style="width:100px"/></td>
                </tr>
                <tr>
                    <td>17</td><td><input  runat="server" id="DocCode17" type="text" style="width:100px"/></td>
                    <td><input runat="server" id="Pay17" type="text" style="width:100px"/></td>
                </tr>
                <tr>
                    <td>18</td><td><input  runat="server" id="DocCode18" type="text" style="width:100px"/></td>
                    <td><input runat="server" id="Pay18" type="text" style="width:100px"/></td>
                </tr>
                <tr>
                    <td>19</td><td><input  runat="server" id="DocCode19" type="text" style="width:100px"/></td>
                    <td><input runat="server" id="Pay19" type="text" style="width:100px"/></td>
                </tr>
                <tr>
                    <td>20</td><td><input  runat="server" id="DocCode20" type="text" style="width:100px"/></td>
                    <td><input runat="server" id="Pay20" type="text" style="width:100px"/></td>
                </tr>
                <tr>
                    <td>21</td><td><input  runat="server" id="DocCode21" type="text" style="width:100px"/></td>
                    <td><input runat="server" id="Pay21" type="text" style="width:100px"/></td>
                </tr>
                <tr>
                    <td>22</td><td><input  runat="server" id="DocCode22" type="text" style="width:100px"/></td>
                    <td><input runat="server" id="Pay22" type="text" style="width:100px"/></td>
                </tr>
                <tr>
                    <td>23</td><td><input  runat="server" id="DocCode23" type="text" style="width:100px"/></td>
                    <td><input runat="server" id="Pay23" type="text" style="width:100px"/></td>
                </tr>
                <tr>
                    <td>24</td><td><input  runat="server" id="DocCode24" type="text" style="width:100px"/></td>
                    <td><input runat="server" id="Pay24" type="text" style="width:100px"/></td>
                </tr>
                <tr>
                    <td>25</td><td><input  runat="server" id="DocCode25" type="text" style="width:100px"/></td>
                    <td><input runat="server" id="Pay25" type="text" style="width:100px"/></td>
                </tr>
                <tr>
                    <td>26</td><td><input  runat="server" id="DocCode26" type="text" style="width:100px"/></td>
                    <td><input runat="server" id="Pay26" type="text" style="width:100px"/></td>
                </tr>
                <tr>
                    <td>27</td><td><input  runat="server" id="DocCode27" type="text" style="width:100px"/></td>
                    <td><input runat="server" id="Pay27" type="text" style="width:100px"/></td>
                </tr>
                <tr>
                    <td>28</td><td><input  runat="server" id="DocCode28" type="text" style="width:100px"/></td>
                    <td><input runat="server" id="Pay28" type="text" style="width:100px"/></td>
                </tr>
                <tr>
                    <td>29</td><td><input  runat="server" id="DocCode29" type="text" style="width:100px"/></td>
                    <td><input runat="server" id="Pay29" type="text" style="width:100px"/></td>
                </tr>
                <tr>
                    <td>30</td><td><input  runat="server" id="DocCode30" type="text" style="width:100px"/></td>
                    <td><input runat="server" id="Pay30" type="text" style="width:100px"/></td>
                </tr>
                <tr>
                    <td>31</td><td><input  runat="server" id="DocCode31" type="text" style="width:100px"/></td>
                    <td><input runat="server" id="Pay31" type="text" style="width:100px"/></td>
                </tr>
            </table>
        </td>
    </tr>
    <tr class="Table_RowC">
        <td style="width: 150px">جمع کاکرد:</td>
        <td>
            <asp:Label ID="lblTotalKarkard" Text="0" runat="server" />&nbsp;ریال
        </td>
    </tr>
    <tr class="Table_RowB">
        <td style="width: 150px">جمع پرداخت:</td>
        <td>
            <asp:Label ID="lblTotalPayment" Text="0" runat="server" />&nbsp;ریال
        </td>
    </tr>
</table>
<telerik:RadButton runat="server" ID="btnSave" Text="ذخیره" AutoPostBack="true" Width="100px" OnClick="btnSave_Click" Height="35px" ValidationGroup="Bus" />
<telerik:RadButton runat="server" ID="btnClose" Text="بازگشت" OnClientClicked="CloseDialog" AutoPostBack="false" Width="100px" Height="35px" />

<p>گزارش کارکرد و پرداخت</p>
<table style="width: 100%; height: auto; margin-top: 15px">
    <tr>
        <td style="width: 95%;  height: auto; overflow: auto;">
            <cc1:JGridView runat="server" id="RadGridReport">
            </cc1:JGridView>
        </td>
    </tr>
</table>

<p>گزارش بهره برداران</p>
<table style="width: 100%; height: auto; margin-top: 15px">
    <tr>
        <td style="width: 95%;  height: auto; overflow: auto;">
            <cc1:JGridView runat="server" id="JGridView1">
            </cc1:JGridView>
        </td>
    </tr>
</table>

<p>گزارش اتوبوسها</p>
<table style="width: 100%; height: auto; margin-top: 15px">
    <tr>
        <td style="width: 95%;  height: auto; overflow: auto;">
            <cc1:JGridView runat="server" id="JGridView2">
            </cc1:JGridView>
        </td>
    </tr>
</table>

<table style="width: 100%; height: auto; margin-top: 15px">
    <tr>
        <td style="width: 95%;  height: auto; overflow: auto;">
            <cc1:JGridView runat="server" id="JGridView3">
            </cc1:JGridView>
        </td>
    </tr>
</table>
<table style="width: 100%; height: auto; margin-top: 15px">
    <tr>
        <td style="width: 95%;  height: auto; overflow: auto;">
            <cc1:JGridView runat="server" id="JGridView4">
            </cc1:JGridView>
        </td>
    </tr>
</table>
