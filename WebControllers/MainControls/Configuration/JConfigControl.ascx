<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="JConfigControl.ascx.cs" Inherits="WebControllers.MainControls.Configuration.JConfigControl" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<script type="text/javascript">
    $(document).ready(function () {
        //var inArchive = false;
        function configureValidators() {
            if (typeof Page_Validators != 'undefined') {
                for (i = 0; i <= Page_Validators.length; i++) {
                    if (Page_Validators[i] != null) {
                        var isDisabled = $('#' + Page_Validators[i].controltovalidate).is(':disabled');
                        //var mostBeValidated = Page_Validators[i].controltovalidate.toString().toLowerCase().indexOf(inArchive ? "archive" : "main") >= 0;
                        if (isDisabled)
                            //Page_Validators[i].validationgroup = '_none_';
                            Page_Validators[i].validationGroup = '_none_';
                        else
                            Page_Validators[i].validationGroup = '';
                        //Page_Validators[i].enabled = !isDisabled & mostBeValidated;
                        //console.log(Page_Validators[i]);
                        //console.log(Page_Validators[i].enabled);
                        //console.log('**********************************************');
                    }
                }
            };
        };
        //configureValidators();
        <%--$('#<%=SaveButton.ClientID%>').click(function () {
            configureValidators();
            return true;
        });--%>
        $('#<%=MainConfigLink.ClientID%>').click(function () {
            $('#<%=MainConfigDiv.ClientID%>').slideToggle();
            $('#<%=ArchiveConfigDiv.ClientID%>').slideToggle();
            //inArchive = false;
            //configureValidators();
            return false;
        });
        $('#<%=ArchiveConfigLink.ClientID%>').click(function () {
            $('#<%=ArchiveConfigDiv.ClientID%>').slideToggle();
            $('#<%=MainConfigDiv.ClientID%>').slideToggle();
            //inArchive = true;
            //configureValidators();
            return false;
        });
        $('#<%=MainWindowsAuthRadioButton.ClientID%>').change(function () {
            if ($(this).attr('checked') == 'checked') {
                $('#<%=MainUserNameTextBox.ClientID%>').attr("disabled", "disabled");
                $('#<%=MainCurrentPasswordTextBox.ClientID%>').attr("disabled", "disabled");
                $('#<%=MainNewPasswordTextBox.ClientID%>').attr("disabled", "disabled");
                $('#<%=MainNewPasswordConfirmTextBox.ClientID%>').attr("disabled", "disabled");

                $('#<%=ArchiveUserNameTextBox.ClientID%>').attr("disabled", "disabled");
                $('#<%=ArchiveCurrentPasswordTextBox.ClientID%>').attr("disabled", "disabled");
                $('#<%=ArchiveNewPasswordTextBox.ClientID%>').attr("disabled", "disabled");
                $('#<%=ArchiveNewPasswordConfirmTextBox.ClientID%>').attr("disabled", "disabled");

                $('#<%=MainCurrentPasswordRequiredFieldValidator.ClientID%>').css('visibility', 'hidden');
                $('#<%=MainNewPasswordTextBoxRequiredFieldValidator.ClientID%>').css('visibility', 'hidden');
                $('#<%=ArchiveCurrentPasswordRequiredFieldValidator.ClientID%>').css('visibility', 'hidden');
                $('#<%=ArchiveNewPasswordRequiredFieldValidator.ClientID%>').css('visibility', 'hidden');
                $('#<%=MainUserNameRequiredFieldValidator.ClientID%>').css('visibility', 'hidden');
                $('#<%=ArchiveUserNameRequiredFieldValidator.ClientID%>').css('visibility', 'hidden');
                configureValidators();
            }
        });
        $('#<%=MainSQLAuthRadioButton.ClientID%>').change(function () {
            if ($(this).attr('checked') == 'checked') {
                $('#<%=MainUserNameTextBox.ClientID%>').removeAttr("disabled");
                $('#<%=MainCurrentPasswordTextBox.ClientID%>').removeAttr("disabled");
                $('#<%=MainNewPasswordTextBox.ClientID%>').removeAttr("disabled");
                $('#<%=MainNewPasswordConfirmTextBox.ClientID%>').removeAttr("disabled");

                $('#<%=ArchiveUserNameTextBox.ClientID%>').removeAttr("disabled");
                $('#<%=ArchiveCurrentPasswordTextBox.ClientID%>').removeAttr("disabled");
                $('#<%=ArchiveNewPasswordTextBox.ClientID%>').removeAttr("disabled");
                $('#<%=ArchiveNewPasswordConfirmTextBox.ClientID%>').removeAttr("disabled");

                $('#<%=MainCurrentPasswordRequiredFieldValidator.ClientID%>').css('visibility', 'visible');
                $('#<%=MainNewPasswordTextBoxRequiredFieldValidator.ClientID%>').css('visibility', 'visible');
                $('#<%=ArchiveCurrentPasswordRequiredFieldValidator.ClientID%>').css('visibility', 'visible');
                $('#<%=ArchiveNewPasswordRequiredFieldValidator.ClientID%>').css('visibility', 'visible');
                $('#<%=MainUserNameRequiredFieldValidator.ClientID%>').css('visibility', 'visible');
                $('#<%=ArchiveUserNameRequiredFieldValidator.ClientID%>').css('visibility', 'visible');
                configureValidators();
            }
        });
        <%--$('#<%=ArchiveWindowsAuthRadioButton.ClientID%>').change(function () {
            if ($(this).attr('checked') == 'checked') {
                $('#<%=ArchiveUserNameTextBox.ClientID%>').attr("disabled", "disabled");
                $('#<%=ArchiveCurrentPasswordTextBox.ClientID%>').attr("disabled", "disabled");
                $('#<%=ArchiveNewPasswordTextBox.ClientID%>').attr("disabled", "disabled");
                $('#<%=ArchiveNewPasswordConfirmTextBox.ClientID%>').attr("disabled", "disabled");
                //configureValidators();
            }
        });
        $('#<%=ArchiveSQLAuthRadioButton.ClientID%>').change(function () {
            if ($(this).attr('checked') == 'checked') {
                $('#<%=ArchiveUserNameTextBox.ClientID%>').removeAttr("disabled");
                $('#<%=ArchiveCurrentPasswordTextBox.ClientID%>').removeAttr("disabled");
                $('#<%=ArchiveNewPasswordTextBox.ClientID%>').removeAttr("disabled");
                $('#<%=ArchiveNewPasswordConfirmTextBox.ClientID%>').removeAttr("disabled");
                //configureValidators();
            }
        });--%>
    });
</script>
<div class="FormContent">
    <div class="BigTitle">تنظیمات</div>
    <asp:LinkButton Text="تنظیمات اصلی" ID="MainConfigLink" runat="server" />
    <br />
    <div id="MainConfigDiv" runat="server">
        <table>
            <tr>
                <td class="Table_RowB">نام سرور:</td>
                <td class="Table_RowC" colspan="7">
                    <asp:TextBox runat="server" ID="MainServerNameTextBox" />
                    <asp:TextBox runat="server" ID="MainServerName2TextBox" />
                </td>
            </tr>
            <tr>
                <td class="Table_RowB">نام بانک اطلاعاتی:</td>
                <td class="Table_RowC" colspan="7">
                    <asp:TextBox runat="server" ID="MainDBNameTextBox" />
                </td>
            </tr>
            <tr>
                <td class="Table_RowB"></td>
                <td class="Table_RowC" colspan="7">
                    <asp:RadioButton Text="Windows Authentication" runat="server" ID="MainWindowsAuthRadioButton" GroupName="MainConfig" Checked="true" />
                </td>
            </tr>
            <tr>
                <td class="Table_RowB"></td>
                <td class="Table_RowC" colspan="7">
                    <asp:RadioButton ID="MainSQLAuthRadioButton" Text="SQL Server Authentication" runat="server" GroupName="MainConfig" />
                </td>
            </tr>
            <tr>
                <td class="Table_RowB">نام کاربری:</td>
                <td class="Table_RowC" colspan="7">
                    <asp:TextBox runat="server" ID="MainUserNameTextBox" Enabled="false" />
                    <asp:RequiredFieldValidator ForeColor="Red" ID="MainUserNameRequiredFieldValidator" runat="server" ControlToValidate="MainUserNameTextBox" ErrorMessage="نام کاربری وارد نشده است"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="Table_RowB">کلمه عبور فعلی:</td>
                <td class="Table_RowC" colspan="7">
                    <asp:TextBox runat="server" ID="MainCurrentPasswordTextBox" Enabled="false" TextMode="Password" />
                    <asp:RequiredFieldValidator ForeColor="Red" ID="MainCurrentPasswordRequiredFieldValidator" runat="server" ControlToValidate="MainCurrentPasswordTextBox" ErrorMessage="کلمه عبور فعلی وارد نشده است"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
            <tr>
                <td class="Table_RowB">کلمه عبور جدید:</td>
                <td class="Table_RowC" colspan="7">
                    <asp:TextBox runat="server" ID="MainNewPasswordTextBox" Enabled="false" TextMode="Password" />
                    <asp:RequiredFieldValidator ForeColor="Red" ID="MainNewPasswordTextBoxRequiredFieldValidator" runat="server" ControlToValidate="MainNewPasswordTextBox" ErrorMessage="کلمه عبور جدید وارد نشده است"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="Table_RowB">تکرار کلمه عبور:</td>
                <td class="Table_RowC" colspan="7">
                    <asp:TextBox runat="server" ID="MainNewPasswordConfirmTextBox" Enabled="false" TextMode="Password" />
                    <asp:CompareValidator ForeColor="Red" ID="MainPasswordCompareValidator" runat="server" ControlToValidate="MainNewPasswordTextBox" ControlToCompare="MainNewPasswordConfirmTextBox" ErrorMessage="کلمه عبور و تکرار آن یکسان نیست"></asp:CompareValidator>
                </td>
            </tr>
            <tr>
                <td class="Table_RowB">حداکثر تعداد رکوردهای قابل نمایش:</td>
                <td class="Table_RowC" colspan="7">
                    <asp:TextBox runat="server" ID="MainMaxRecordsTextBox" />
                </td>
            </tr>
            <tr>
                <td class="Table_RowB">زبان جاری:</td>
                <td class="Table_RowC" colspan="7">
                    <asp:TextBox runat="server" ID="MainCurrentLangTextBox" />
                </td>
            </tr>
        </table>
    </div>
    <br />
    <asp:LinkButton Text="تنظیمات آرشیو" ID="ArchiveConfigLink" runat="server" />
    <br />
    <div id="ArchiveConfigDiv" runat="server" style="display: none">
        <table>
            <tr>
                <td class="Table_RowB">نام سرور:</td>
                <td class="Table_RowC" colspan="7">
                    <asp:TextBox runat="server" ID="ArchiveServerNameTextBox" />
                </td>
            </tr>
            <tr>
                <td class="Table_RowB">نام بانک اطلاعاتی:</td>
                <td class="Table_RowC" colspan="7">
                    <asp:TextBox runat="server" ID="ArchiveDBNameTextBox" />
                </td>
            </tr>
            <%--<tr>
                <td class="Table_RowB"></td>
                <td class="Table_RowC" colspan="7">
                    <asp:RadioButton Text="Windows Authentication" runat="server" ID="ArchiveWindowsAuthRadioButton" GroupName="ArchiveConfig" Checked="true" />
                </td>
            </tr>
            <tr>
                <td class="Table_RowB"></td>
                <td class="Table_RowC" colspan="7">
                    <asp:RadioButton ID="ArchiveSQLAuthRadioButton" Text="SQL Server Authentication" runat="server" GroupName="ArchiveConfig" />
                </td>
            </tr>--%>
            <tr>
                <td class="Table_RowB">نام کاربری:</td>
                <td class="Table_RowC" colspan="7">
                    <asp:TextBox runat="server" ID="ArchiveUserNameTextBox" Enabled="false" />
                    <asp:RequiredFieldValidator ForeColor="Red" ID="ArchiveUserNameRequiredFieldValidator" runat="server" ControlToValidate="ArchiveUserNameTextBox" ErrorMessage="نام کاربری وارد نشده است"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="Table_RowB">کلمه عبور فعلی:</td>
                <td class="Table_RowC" colspan="7">
                    <asp:TextBox runat="server" ID="ArchiveCurrentPasswordTextBox" Enabled="false" TextMode="Password" />
                    <asp:RequiredFieldValidator ForeColor="Red" ID="ArchiveCurrentPasswordRequiredFieldValidator" runat="server" ControlToValidate="ArchiveCurrentPasswordTextBox" ErrorMessage="کلمه عبور فعلی وارد نشده است"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="Table_RowB">کلمه عبور جدید:</td>
                <td class="Table_RowC" colspan="7">
                    <asp:TextBox runat="server" ID="ArchiveNewPasswordTextBox" Enabled="false" TextMode="Password" />
                    <asp:RequiredFieldValidator ForeColor="Red" ID="ArchiveNewPasswordRequiredFieldValidator" runat="server" ControlToValidate="ArchiveNewPasswordTextBox" ErrorMessage="کلمه عبور جدید وارد نشده است"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="Table_RowB">تکرار کلمه عبور:</td>
                <td class="Table_RowC" colspan="7">
                    <asp:TextBox runat="server" ID="ArchiveNewPasswordConfirmTextBox" Enabled="false" TextMode="Password" />
                    <asp:CompareValidator ForeColor="Red" ID="ArchiveNewPasswordCompareValidator" runat="server" ControlToValidate="ArchiveNewPasswordTextBox" ControlToCompare="ArchiveNewPasswordConfirmTextBox" ErrorMessage="کلمه عبور و تکرار آن یکسان نیست"></asp:CompareValidator>
                </td>
            </tr>
        </table>
    </div>
</div>
<div class="FormButtons">
    <telerik:RadButton runat="server" ID="SaveButton" Text="ذخیره" AutoPostBack="true" Width="100px" Height="35px" OnClick="btnSave_Click" />
    <telerik:RadButton runat="server" ID="CloseButton" Text="بازگشت" OnClientClicked="CloseDialog" AutoPostBack="false" Width="100px" Height="35px" />
</div>
