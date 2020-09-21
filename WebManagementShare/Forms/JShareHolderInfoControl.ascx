<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="JShareHolderInfoControl.ascx.cs" Inherits="WebManagementShare.Controls.JShareHolderInfo" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register Src="~/WebControllers/MainControls/Grid/JGridViewControl.ascx" TagPrefix="uc1" TagName="JGridViewControl" %>
<%@ Register assembly="JJson" namespace="JJson.Controls" tagprefix="JJson" %>
<%@ Register assembly="CMSClassLibrary" namespace="CMSClassLibrary.Controls" tagprefix="JJson" %>
<%@ Register assembly="JComponents" namespace="JComponents" tagprefix="cc1" %>
<%@ Register Src="~/WebControllers/ArchiveDocument/JArchiveControl.ascx" TagPrefix="uc1" TagName="JArchiveControl" %>
<div class="BigTitle">اطلاعات سهامدار</div>
<div class="FormContent">
    <table style="width: 100%;padding-top:50px">
        <tr>
            <td>
                <table style="width: 100%">
                    <tr class="Table_RowA">
                        <td style="width: 150px">نام:
                        </td>
                        <td>
                            <asp:Label runat="server" ID="lblName" Text="" />
                        </td>
                    </tr>
                    <tr class="Table_RowB">
                        <td>نام پدر:
                        </td>
                        <td>
                            <asp:Label runat="server" ID="lblFatherName" Text="" />
                        </td>
                    </tr>
                    <tr class="Table_RowA">
                        <td>شماره شناسنامه:
                        </td>
                        <td>
                            <asp:Label runat="server" ID="lblShsh" Text="" />
                        </td>
                    </tr>
                    <tr class="Table_RowB">
                        <td>کد ملی:
                        </td>
                        <td>
                            <asp:Label runat="server" ID="lblMelliCode" Text="" />
                        </td>
                    </tr>
                    <tr class="Table_RowB">
                        <td>تاریخ تولد:
                        </td>
                        <td>
                            <asp:Label runat="server" ID="LbBrithday" />
                        </td>
                    </tr>
                    <tr class="Table_RowB">
                        <td>محل صدور:
                        </td>
                        <td>
                            <asp:Label runat="server" ID="LbSodoor" />
                        </td>
                    </tr>
                    <tr class="Table_RowB">
                        <td>وضعیت مدارک:</td>
                        <td>
                            <asp:CheckBox ID="cbShSh" runat="server" Enabled="False" OnCheckedChanged="CheckBox1_CheckedChanged" Text="شناسنامه" />
                            -------<asp:CheckBox ID="cbShMeli" runat="server" Enabled="False" OnCheckedChanged="CheckBox1_CheckedChanged" Text="کارت ملی" />
                            -------<asp:CheckBox ID="cbImage" runat="server" Enabled="False" OnCheckedChanged="CheckBox1_CheckedChanged" Text="تصویر پرسنلی" />
                            -------<asp:CheckBox ID="cbMosh" runat="server" Enabled="False" OnCheckedChanged="CheckBox1_CheckedChanged" Text="فرم مشخصات" />
                        </td>
                    </tr>
                </table>
            </td>
            <td style="width: 300px; text-align: center; vertical-align: middle">
                <telerik:RadBinaryImage runat="server" ID="imgPerson" ResizeMode="Fit" Width="200" Height="300" />
            </td>
        </tr>
    </table>
    <asp:Panel runat="server" ID="Panel_ViewInfo">
        <table style="width: 100%">
            <tr class="Table_RowB">
                <td style="width: 150px">پست الکترونیک:
                </td>
                <td>
                    <asp:Label runat="server" ID="lblEmail" Text="" />
                </td>
            </tr>
            <tr class="Table_RowA">
                <td style="width: 150px">آدرس:
                </td>
                <td>
                    <asp:Label runat="server" ID="lblAddress" Text="" />
                </td>
            </tr>
            <tr class="Table_RowB">
                <td style="width: 150px">تلفن ثابت:
                </td>
                <td>
                    <asp:Label runat="server" ID="lblTel" Text="" />
                </td>
            </tr>
            <tr class="Table_RowA">
                <td style="width: 150px">تلفن همراه:
                </td>
                <td>
                    <asp:Label runat="server" ID="lblMobile" Text="" />
                </td>
            </tr>
        </table>
        <div style="width: 100%; text-align: left">
            <telerik:RadButton runat="server" ID="btnEdit" Text="ویرایش اطلاعات" OnClick="btnEdit_Click" Height="50" />
        </div>
    </asp:Panel>
    <asp:Panel runat="server" ID="Panel_EditInfo" Visible="false">
        <table style="width: 100%">
            <tr class="Table_RowB">
                <td style="width: 150px">پست الکترونیک:
                </td>
                <td>
                    <telerik:RadTextBox runat="server" ID="txtEmail" Text="" Width="350" />
                </td>
            </tr>
            <tr class="Table_RowA">
                <td style="width: 150px">آدرس:
                </td>
                <td>
                    <telerik:RadTextBox runat="server" ID="txtAddress" Text="" Width="350" />
                </td>
            </tr>
            <tr class="Table_RowB">
                <td style="width: 150px">تلفن ثابت:
                </td>
                <td>
                    <telerik:RadTextBox runat="server" ID="txtTel" Text="" Width="350" />
                </td>
            </tr>
            <tr class="Table_RowA">
                <td style="width: 150px">تلفن همراه:
                </td>
                <td>
                    <telerik:RadTextBox runat="server" ID="txtMobile" Text="" Width="350" />
                </td>
            </tr>
            <tr class="Table_RowA">
                <td style="width: 150px">&nbsp;</td>
                <td>شما می توانید تصاویر اسکن شده مانند کارت ملی ، تصویر اول شناسنامه ، عکس پرسنلی خود را از طریق بخش زیر ارسال کنید. حتما قبل از ارسال اطلاعات عنوان فایل را در کادر توضیحات وارد نمایید.</td>
            </tr>
            <tr class="Table_RowA">
                <td style="width: 150px">اسناد و فایلهای مرتبط</td>
                <td>
                    <uc1:JArchiveControl ID="jArchiveControl1" runat="server" />
                </td>
            </tr>
        </table>
        <div style="width: 100%; text-align: left">
            <telerik:RadButton runat="server" ID="btnUpdate" Text="بروز رسانی" OnClick="btnUpdate_Click" Height="50" />
            <telerik:RadButton runat="server" ID="btnCancel" Text="لغو" OnClick="btnCancel_Click" Height="50" />
        </div>
    </asp:Panel>
</div>
