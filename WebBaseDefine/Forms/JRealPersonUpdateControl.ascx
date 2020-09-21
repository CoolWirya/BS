<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="JRealPersonUpdateControl.ascx.cs" Inherits="WebBaseDefine.Forms.JRealPersonUpdateControl" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register Src="~/WebControllers/MainControls/Date/JDateControl.ascx" TagPrefix="uc1" TagName="JDateControl" %>
<%@ Register Src="~/WebControllers/ArchiveDocument/JArchiveControl.ascx" TagPrefix="uc11" TagName="JArchiveControl" %>
<%@ Register Src="~/WebControllers/Property/JPropertyViewControl.ascx" TagPrefix="uc2" TagName="JPropertyViewControl" %>
<%--<%@ Register Src="~/WebBaseDefine/Forms/JFormObjectControl.ascx" TagPrefix="uc22" TagName="JFormObjectControl" %> --%>
<%@ Register Assembly="WebControllers" Namespace="WebControllers.MainControls.Grid" TagPrefix="cc1" %>



<script type="text/javascript">
    function ShowNewProperty() {
        document.getElementById("<%=divNewProperty.ClientID %>").style.display = 'block';
        document.getElementById("<%=divProperties.ClientID %>").style.display = 'none';
    }

    function ShowProperties() {
        document.getElementById("<%=divNewProperty.ClientID %>").style.display = 'none';
        document.getElementById("<%=divProperties.ClientID %>").style.display = 'block';
    }
</script>
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

<style type="text/css">
    .KeyCol {
        width: 100px;
    }
</style>

<div style="overflow-y: auto; position: fixed; top: 0; bottom: 55px; left: 0; right: 0">
    <div>
        <div style="position: fixed; left: 17px; top: 5px; text-align: center; background-color: #FFF; border: 1px dashed #808080; z-index: 250" onmouseover="$('#changeBtn').show();" onmouseout="if(alwaysShowUpload==false)$('#changeBtn').hide();">
            <telerik:RadBinaryImage runat="server" ID="imgPerson" ImageUrl="~/Images/Controls/nopersonimage.png" ResizeMode="Fit" Width="150" Height="150" />
            <div id="changeBtn" style="display: none;">
                <telerik:RadAsyncUpload ID="upldPhoto" runat="server" AllowedFileExtensions=".jpg,.png,.gif,jpeg,.tiff"
                    MaxFileInputsCount="1" MultipleFileSelection="Disabled" OnFileUploaded="upldPhoto_FileUploaded" HideFileInput="true" Width="80" OnClientFileSelected="EnableAlwaysShowUpload">
                </telerik:RadAsyncUpload>
                <telerik:RadButton runat="server" ID="btnChangeImage" Text="ذخیره" OnClientClick="updatePictureAndInfo(); return false;"></telerik:RadButton>
            </div>
        </div>
        <table style="width: 100%">
            <tr>
                <td class="KeyCol Table_RowC">کد:</td>
                <td class="Table_RowC">
                    <telerik:RadTextBox runat="server" ID="txtCode" ReadOnly="true"></telerik:RadTextBox></td>
                <td class="KeyCol Table_RowB">کد ملی:</td>
                <td class="Table_RowB">
                    <telerik:RadTextBox ID="txtCodeMelli" runat="server"></telerik:RadTextBox></td>
            </tr>
            <tr>
                <td class="KeyCol Table_RowB">نام خانوادگی:</td>
                <td class="Table_RowB">
                    <telerik:RadTextBox ID="txtFam" runat="server"></telerik:RadTextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ControlToValidate="txtFam" ValidationGroup="A"></asp:RequiredFieldValidator>
                </td>
                <td class="KeyCol Table_RowC">تاریخ تولد:</td>
                <td class="Table_RowC">
                    <uc1:JDateControl runat="server" id="txtBirthDate" />
                </td>
            </tr>
            <tr>
                <td class="KeyCol Table_RowC">نام:</td>
                <td class="Table_RowC">
                    <telerik:RadTextBox ID="txtName" runat="server"></telerik:RadTextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*" ControlToValidate="txtName" ValidationGroup="A"></asp:RequiredFieldValidator>
                </td>
                <td class="KeyCol Table_RowB">محل تولد:</td>
                <td class="Table_RowB">
                    <telerik:RadComboBox runat="server" ID="cmbBirthPlace"></telerik:RadComboBox>
                </td>
            </tr>
            <tr>
                <td class="KeyCol Table_RowB">نام پدر:</td>
                <td class="Table_RowB">
                    <telerik:RadTextBox ID="txtFather" runat="server"></telerik:RadTextBox></td>
                <td class="KeyCol Table_RowC">محل صدور:</td>
                <td class="Table_RowC">
                    <telerik:RadComboBox runat="server" ID="cmbIssuePlace"></telerik:RadComboBox>
                </td>
            </tr>
            <tr>
                <td class="KeyCol Table_RowC">شماره شناسنامه:</td>
                <td class="Table_RowC">
                    <telerik:RadTextBox ID="txtShSh" runat="server"></telerik:RadTextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*" ControlToValidate="txtShSh" ValidationGroup="A"></asp:RequiredFieldValidator>
                </td>
                <td class="KeyCol Table_RowB">جنسیت:</td>
                <td class="Table_RowB">
                    <telerik:RadComboBox runat="server" ID="cmbGender">
                        <Items>
                            <telerik:RadComboBoxItem Text="مرد" Value="1" />
                            <telerik:RadComboBoxItem Text="زن" Value="0" />
                        </Items>
                    </telerik:RadComboBox>
                </td>
            </tr>
            <tr>
                <td class="KeyCol Table_RowB">توضیحات:</td>
                <td class="Table_RowB">
                    <telerik:RadTextBox ID="txtDescription" TextMode="MultiLine" Rows="3" runat="server"></telerik:RadTextBox></td>
                <td class="KeyCol Table_RowC">کد تفصیلی:</td>
                <td class="Table_RowC">
                    <telerik:RadTextBox ID="txtTafsili" runat="server"></telerik:RadTextBox></td>
            </tr>
            <tr>
                <td class="KeyCol Table_RowC">شماره سهامدار:</td>
                <td class="Table_RowC">
                    <telerik:RadTextBox ID="txtShareHolderCode" runat="server"></telerik:RadTextBox></td>
                <td class="KeyCol Table_RowB">کد پرسنلی</td>
                <td class="Table_RowB">
                    <telerik:RadTextBox ID="txtPersonNumber" runat="server"></telerik:RadTextBox></td>
            </tr>
        </table>
    </div>
    <telerik:RadTabStrip runat="server" ID="RadTabStrip1"
        SelectedIndex="2" MultiPageID="RadMultiPage1" Width="100%">
        <Tabs>
            <telerik:RadTab Text="منزل">
            </telerik:RadTab>
            <telerik:RadTab Text="محل کار">
            </telerik:RadTab>
            <telerik:RadTab Text="تصاویر" Selected="True">
            </telerik:RadTab>
            <telerik:RadTab Text="ویژگی های شخص">
            </telerik:RadTab>
            <telerik:RadTab Text="کارت هوشمند">
            </telerik:RadTab>
            <telerik:RadTab Text="دارائی ها">
            </telerik:RadTab>
            <telerik:RadTab Text="سابقه قراردادها">
            </telerik:RadTab>
            <telerik:RadTab Text="ویژگی ها ">
            </telerik:RadTab>
        </Tabs>
    </telerik:RadTabStrip>
    <p></p>
    <telerik:RadMultiPage runat="server" ID="RadMultiPage1" SelectedIndex="2"
        Width="700px">
        <telerik:RadPageView runat="server" ID="RadPageView1">
            آدرس:&nbsp;
        <telerik:RadTextBox runat="server" ID="txtHomeAddress" TextMode="MultiLine" Rows="2" Columns="45"></telerik:RadTextBox>
            <table>
                <tr>
                    <td class="KeyCol Table_RowB">شهر:</td>
                    <td class="Table_RowB">
                        <telerik:RadComboBox runat="server" ID="cmbHomeCity"></telerik:RadComboBox>
                    </td>
                    <td class="KeyCol Table_RowC">کد پستی</td>
                    <td class="Table_RowC">
                        <telerik:RadTextBox ID="txtHomePostalCode" runat="server"></telerik:RadTextBox></td>
                </tr>
                <tr>
                    <td class="KeyCol Table_RowB">تلفن:</td>
                    <td class="Table_RowB">
                        <telerik:RadTextBox ID="txtHomeTel" runat="server"></telerik:RadTextBox></td>
                    <td class="KeyCol Table_RowC">فکس:</td>
                    <td class="Table_RowC">
                        <telerik:RadTextBox ID="txtHomeFax" runat="server"></telerik:RadTextBox></td>
                </tr>
                <tr>
                    <td class="KeyCol Table_RowB">همراه:</td>
                    <td class="Table_RowB">
                        <telerik:RadTextBox ID="txtHomeMobile" runat="server"></telerik:RadTextBox></td>
                    <td class="KeyCol Table_RowC">ایمیل:</td>
                    <td class="Table_RowC">
                        <telerik:RadTextBox ID="txtHomeEmail" runat="server"></telerik:RadTextBox></td>
                </tr>
            </table>
        </telerik:RadPageView>
        <telerik:RadPageView runat="server" ID="RadPageView2">
            آدرس:&nbsp;
        <telerik:RadTextBox runat="server" ID="txtWorkAddress" TextMode="MultiLine" Rows="2" Columns="45"></telerik:RadTextBox>
            <table>
                <tr>
                    <td class="KeyCol Table_RowB">شهر:</td>
                    <td class="Table_RowB">
                        <telerik:RadComboBox runat="server" ID="cmbWorkCity"></telerik:RadComboBox>
                    </td>
                    <td class="KeyCol Table_RowC">کد پستی</td>
                    <td class="Table_RowC">
                        <telerik:RadTextBox ID="txtWorkPostalCode" runat="server"></telerik:RadTextBox></td>
                </tr>
                <tr>
                    <td class="KeyCol Table_RowB">تلفن:</td>
                    <td class="Table_RowB">
                        <telerik:RadTextBox ID="txtWorkTel" runat="server"></telerik:RadTextBox></td>
                    <td class="KeyCol Table_RowC">فکس:</td>
                    <td class="Table_RowC">
                        <telerik:RadTextBox ID="txtWorkFax" runat="server"></telerik:RadTextBox></td>
                </tr>
                <tr>
                    <td class="KeyCol Table_RowB">وب سایت:</td>
                    <td class="Table_RowB">
                        <telerik:RadTextBox ID="txtWorkWebSite" runat="server"></telerik:RadTextBox></td>
                    <td class="KeyCol Table_RowC">ایمیل:</td>
                    <td class="Table_RowC">
                        <telerik:RadTextBox ID="txtWorkEmail" runat="server"></telerik:RadTextBox></td>
                </tr>
            </table>
        </telerik:RadPageView>
        <telerik:RadPageView runat="server" ID="RadPageView3">
            <uc11:JArchiveControl runat="server" id="jArchiveControl" />
        </telerik:RadPageView>
        <telerik:RadPageView runat="server" ID="RadPageView4">
            <uc2:JPropertyViewControl runat="server" id="jPropertyViewControl" />
        </telerik:RadPageView>
        <telerik:RadPageView runat="server" ID="RadPageView5">
            <telerik:RadGrid runat="server" ID="dgrSmartCard" />
        </telerik:RadPageView>
        <telerik:RadPageView runat="server" ID="RadPageView6">
            <telerik:RadGrid runat="server" ID="dgrAssets" />
        </telerik:RadPageView>
        <telerik:RadPageView runat="server" ID="RadPageView7">
            <telerik:RadGrid runat="server" ID="dgrContract" />
        </telerik:RadPageView>


         <telerik:RadPageView runat="server" ID="RadPageView8">
    
        اضافه کردن ویژگی

             <div>
                
   <%--<uc22:JFormObjectControl runat="server" id="JFormObjectControl1" /> --%>
         
           <div runat="server" id="divNewProperty" style="display: block">
     <%--
                <telerik:RadButton runat="server" ID="btnSaveProperty" AutoPostBack="true" ImageUrl="~/WebERP/Images/Controls/Save.png" Width="32" Height="32" Text="ذخیره" OnClick="btnSaveProperty_Click" ></telerik:RadButton>
                <telerik:RadButton runat="server" ID="btnBack" OnClientClicked="ShowProperties" AutoPostBack="false" Image-ImageUrl="~/Images/Controls/Return.png" Width="32" Height="32" Text="بازگشت"></telerik:RadButton>
          
            <telerik:RadGrid runat="server" AutoGenerateColumns="true" ID="gridView2" OnItemCommand="gridView2_ItemCommand" OnItemDataBound="gridView2_ItemDataBound"  ></telerik:RadGrid>
            <asp:GridView runat="server" AutoGenerateColumns="true" ID="gridView"  ></asp:GridView>
            <uc2:JPropertyViewControl runat="server" ID="jPropertyViewControl1" />
               
                      </div>
        </div>  
                  <telerik:RadButton runat="server" ID="btnSaveProp" Text="ذخیره" AutoPostBack="true" Width="100px" Height="35px" OnClick="btnSaveProp_Click" ValidationGroup="A" />       --%>  
    </div>
                 <div runat="server" id="divProperties"></div>

    </div>
        </telerik:RadPageView>
    </telerik:RadMultiPage>
</div>
<div style="position: fixed; bottom: 0px; height: 45px; width: 100%; vertical-align: middle; padding-top: 5px; padding-right: 5px" class="Table_RowD">
    <telerik:RadButton runat="server" ID="btnSave" Text="ذخیره" AutoPostBack="true" Width="100px" Height="35px" OnClick="btnSave_Click" ValidationGroup="A" />
    <telerik:RadButton runat="server" ID="btnClose" Text="بازگشت" OnClientClicked="CloseDialog" AutoPostBack="false" Width="100px" Height="35px" />
    <telerik:RadButton runat="server" ID="btnDelete" Text="حذف" AutoPostBack="true" Width="100px" Height="35px" OnClick="btnDelete_Click" CssClass="floatLeft" OnClientClicking="OnClientClicking" />
</div>
