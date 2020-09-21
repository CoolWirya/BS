<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="JAutomobileDefineUpdateControl.ascx.cs" Inherits="WebAutomobile.Forms.JAutomobileDefineUpdateControl" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register Src="~/WebControllers/ArchiveDocument/JArchiveControl.ascx" TagPrefix="uc1" TagName="JArchiveControl" %>

<telerik:RadCodeBlock>
    <script type="text/javascript">
        var alwaysShowUpload = false;
        function updatePictureAndInfo() {
            __doPostBack('upldPhoto', 'RadButton1Args');
            alwaysShowUpload = false;
        }

        function EnableAlwaysShowUpload() {
            alwaysShowUpload = true;
        }
    </script>
</telerik:RadCodeBlock>
<div class="BigTitle">اتومبیل</div>
<telerik:RadTabStrip runat="server" ID="RadTabStrip1"
    SelectedIndex="0" MultiPageID="RadMultiPage1" Width="100%">
    <Tabs>
        <telerik:RadTab Text="اتومبیل">
        </telerik:RadTab>
        <telerik:RadTab Text="تصویر">
        </telerik:RadTab>
    </Tabs>
</telerik:RadTabStrip>
<telerik:RadMultiPage runat="server" ID="RadMultiPage1" SelectedIndex="0"
    Width="700px">
    <telerik:RadPageView runat="server" ID="RadPageView1">
        <!-- AVL -->        
        <div style="position: fixed; left: 17px; top: 65px; text-align: center; background-color: #FFF; border: 1px dashed #808080; z-index: 250" onmouseover="$('#changeBtn').show();" onmouseout="if(alwaysShowUpload==false)$('#changeBtn').hide();">
            <telerik:RadBinaryImage runat="server" ID="imgPerson" ImageUrl="~/Images/Controls/nopersonimage.png" ResizeMode="Fit" Width="64" Height="64" />
            <div id="changeBtn" style="display: none;">
                <telerik:RadAsyncUpload ID="upldPhoto" runat="server" AllowedFileExtensions=".jpg,.png,.gif,jpeg,.tiff"
                    MaxFileInputsCount="1" MultipleFileSelection="Disabled" OnFileUploaded="upldPhoto_FileUploaded" HideFileInput="true" Width="80" OnClientFileSelected="EnableAlwaysShowUpload">
                </telerik:RadAsyncUpload>
                <telerik:RadButton runat="server" ID="btnChangeImage" Text="ذخیره" OnClientClick="updatePictureAndInfo(); return false;"></telerik:RadButton>
            </div>
        </div>
        <!-- -->
        <table style="width: 500px">
            <tr class="Table_RowB">
                <td style="width: 150px">شماره پلاک:</td>
                <td>ایران
                    <telerik:RadTextBox runat="server" ID="txtPelakIranCode" Width="60px"></telerik:RadTextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidatortxtPelakIranCode" runat="server" 
                        Display="Dynamic" ControlToValidate="txtPelakIranCode" ValidationGroup="Automobile" ErrorMessage="*"></asp:RequiredFieldValidator>
                    -
                    <telerik:RadTextBox runat="server" ID="txtPelakRightNumber" Width="70px"></telerik:RadTextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                        Display="Dynamic" ControlToValidate="txtPelakRightNumber" ValidationGroup="Automobile" ErrorMessage="*"></asp:RequiredFieldValidator>
                    <telerik:RadComboBox runat="server" ID="cmbPelakChar" Width="60px">
                        <Items>
                            <telerik:RadComboBoxItem Text="ا" Value="ا" />
                            <telerik:RadComboBoxItem Text="ب" Value="ب" />
                            <telerik:RadComboBoxItem Text="پ" Value="پ" />
                            <telerik:RadComboBoxItem Text="ت" Value="ت" />
                            <telerik:RadComboBoxItem Text="ث" Value="ث" />
                            <telerik:RadComboBoxItem Text="ج" Value="ج" />
                            <telerik:RadComboBoxItem Text="چ" Value="چ" />
                            <telerik:RadComboBoxItem Text="ح" Value="ح" />
                            <telerik:RadComboBoxItem Text="خ" Value="خ" />
                            <telerik:RadComboBoxItem Text="د" Value="د" />
                            <telerik:RadComboBoxItem Text="ذ" Value="ذ" />
                            <telerik:RadComboBoxItem Text="ر" Value="ر" />
                            <telerik:RadComboBoxItem Text="ز" Value="ز" />
                            <telerik:RadComboBoxItem Text="ژ" Value="ژ" />
                            <telerik:RadComboBoxItem Text="س" Value="س" />
                            <telerik:RadComboBoxItem Text="ش" Value="ش" />
                            <telerik:RadComboBoxItem Text="ص" Value="ص" />
                            <telerik:RadComboBoxItem Text="ض" Value="ض" />
                            <telerik:RadComboBoxItem Text="ط" Value="ط" />
                            <telerik:RadComboBoxItem Text="ظ" Value="ظ" />
                            <telerik:RadComboBoxItem Text="ع" Value="ع" />
                            <telerik:RadComboBoxItem Text="غ" Value="غ" />
                            <telerik:RadComboBoxItem Text="ف" Value="ف" />
                            <telerik:RadComboBoxItem Text="ق" Value="ق" />
                            <telerik:RadComboBoxItem Text="ک" Value="ک" />
                            <telerik:RadComboBoxItem Text="گ" Value="گ" />
                            <telerik:RadComboBoxItem Text="ل" Value="ل" />
                            <telerik:RadComboBoxItem Text="م" Value="م" />
                            <telerik:RadComboBoxItem Text="ن" Value="ن" />
                            <telerik:RadComboBoxItem Text="و" Value="و" />
                            <telerik:RadComboBoxItem Text="ه" Value="ه" />
                            <telerik:RadComboBoxItem Text="ی" Value="ی" />
                        </Items>
                    </telerik:RadComboBox>
                    <telerik:RadTextBox runat="server" ID="txtPelakLeftNumber" Width="60px"></telerik:RadTextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                        Display="Dynamic" ControlToValidate="txtPelakLeftNumber" ValidationGroup="Automobile" ErrorMessage="*"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr class="Table_RowC">
                <td style="width: 150px">نوع اتومبیل:</td>
                <td>
                    <telerik:RadComboBox runat="server" ID="cmbAutomobileType" Width="100%"></telerik:RadComboBox>
                </td>
            </tr>
            <tr class="Table_RowB">
                <td style="width: 150px">مدل:</td>
                <td>
                    <telerik:RadTextBox runat="server" ID="txtModel" Width="100%"></telerik:RadTextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                        Display="Dynamic" ControlToValidate="txtModel" ValidationGroup="Automobile" ErrorMessage="*"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr class="Table_RowC">
                <td style="width: 150px">شرکت سازنده:</td>
                <td>
                    <telerik:RadComboBox runat="server" ID="cmbManufacturerCompany" Width="100%"></telerik:RadComboBox>
                </td>
            </tr>
            <tr class="Table_RowB">
                <td style="width: 150px">ظرفیت:</td>
                <td>
                    <telerik:RadTextBox runat="server" ID="txtCapacity" Width="100%"></telerik:RadTextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                        Display="Dynamic" ControlToValidate="txtCapacity" ValidationGroup="Automobile" ErrorMessage="*"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr class="Table_RowC">
                <td style="width: 150px">وضعیت:</td>
                <td>
                    <asp:CheckBox ID="chkStatus" runat="server" Text="فعال" Checked="true" />
                </td>
            </tr>
        </table>
    </telerik:RadPageView>
    <telerik:RadPageView runat="server" ID="RadPageView2">
        <uc1:JArchiveControl runat="server" id="jArchiveControl" />
    </telerik:RadPageView>
</telerik:RadMultiPage>
<telerik:RadButton runat="server" ID="btnSave" Text="ذخیره" AutoPostBack="true" Width="100px" Height="35px" OnClick="btnSave_Click" ValidationGroup="Automobile"/>
<telerik:RadButton runat="server" ID="btnClose" Text="بازگشت" OnClientClicked="CloseDialog" AutoPostBack="false" Width="100px" Height="35px" />
     <telerik:RadButton runat="server" ID="btnDelete" Text="حذف" AutoPostBack="true" Width="100px" Height="35px" OnClick="btnDelete_Click" CssClass="floatLeft" Visible="false"/>
