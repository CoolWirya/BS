using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClassLibrary;
using WebClassLibrary;

namespace WebControllers.MainControls.Configuration
{
    public partial class JConfigControl : System.Web.UI.UserControl
    {
        private void LoadConfig()
        {
            try
            {
                if (JGlobal.MainFrame == null)
                    return;
                JConfig BConfig = new JConfig();
                MainDBNameTextBox.Text = BConfig.Database;
                //MainPasswordTextBox.Text = BConfig.Password;
                MainServerNameTextBox.Text = BConfig.Server;
                MainServerName2TextBox.Text = BConfig.WebServer;
                //MainUserNameTextBox.Text = BConfig.Username;

                //txtSmDB.Text = BConfig.DatabaseSaham;
                //txtSmPassword.Text = BConfig.PasswordSaham;
                //txtSmServer.Text = BConfig.ServerSaham;
                //txtSmUserName.Text = BConfig.UsernameSaham;

                MainMaxRecordsTextBox.Text = BConfig.MaxLenghList.ToString();
                //txtPersonSahamTable.Text = BConfig.PersonSahamTableName;
                //txtSheetSaham.Text = BConfig.SheetSahamTableName;
                MainCurrentLangTextBox.Text = BConfig.CurrentLang;
                if (BConfig.IntegratedSecurity)
                    MainWindowsAuthRadioButton.Checked = true;
                else
                    MainSQLAuthRadioButton.Checked = true;

                MainUserNameTextBox.Enabled = MainSQLAuthRadioButton.Checked;
                MainCurrentPasswordTextBox.Enabled = MainSQLAuthRadioButton.Checked;
                MainNewPasswordTextBox.Enabled = MainSQLAuthRadioButton.Checked;
                MainNewPasswordConfirmTextBox.Enabled = MainSQLAuthRadioButton.Checked;

                ArchiveUserNameTextBox.Enabled = MainSQLAuthRadioButton.Checked;
                ArchiveCurrentPasswordTextBox.Enabled = MainSQLAuthRadioButton.Checked;
                ArchiveNewPasswordTextBox.Enabled = MainSQLAuthRadioButton.Checked;
                ArchiveNewPasswordConfirmTextBox.Enabled = MainSQLAuthRadioButton.Checked;

                //txtSahamWebSite.Text = BConfig.SahamWebConfig;

                //ImageAddresstextBox.Text = BConfig.BaseFileAddress;
                //txtBascolFileName.Text = BConfig.TimeLogin.ToString();
                //jucCompanyDefault.SelectedCode = BConfig.CompanyDefault;

                ArchiveDBNameTextBox.Text = BConfig.DatabaseArchive;
                ArchiveServerNameTextBox.Text = BConfig.ServerArchive;
                //ArchiveUserNameTextBox.Text = BConfig.UsernameArchive;
                //ArchivePasswordTextBox.Text = BConfig.PasswordArchive;
                //txtLDAP.Text = BConfig.LDAPServer;
                //txtDomainName.Text = BConfig.DomainName;


                //RBGSMModem.Checked = (BConfig.SMSSendType == JSMSSendType.GSM);
                //RBWebServiceSend.Checked = (BConfig.SMSSendType == JSMSSendType.WebService);
            }
            catch
            {

            }
        }

        private void ApplyChanges()
        {
            JConfig BConfig = new JConfig();
            if (
                MainSQLAuthRadioButton.Checked
                &&
                (
                    string.IsNullOrWhiteSpace(MainUserNameTextBox.Text)
                    ||
                    string.IsNullOrWhiteSpace(ArchiveUserNameTextBox.Text)
                    ||
                    BConfig.Password != MainCurrentPasswordTextBox.Text
                    ||
                    BConfig.PasswordArchive != ArchiveCurrentPasswordTextBox.Text
                    ||
                    MainNewPasswordTextBox.Text != MainNewPasswordConfirmTextBox.Text
                    ||
                    ArchiveNewPasswordTextBox.Text != ArchiveNewPasswordConfirmTextBox.Text
                )
                )
                return;
            BConfig.Database = MainDBNameTextBox.Text;
            BConfig.Server = MainServerNameTextBox.Text;
            BConfig.WebServer = MainServerName2TextBox.Text;
            BConfig.Username = MainSQLAuthRadioButton.Checked ? MainUserNameTextBox.Text : BConfig.Username;
            BConfig.Password = string.IsNullOrWhiteSpace(MainNewPasswordTextBox.Text) ? BConfig.Password : MainNewPasswordTextBox.Text;

            //BConfig.DatabaseSaham = txtSmDB.Text;
            //BConfig.ServerSaham = txtSmServer.Text;
            //BConfig.UsernameSaham = txtSmUserName.Text;
            //BConfig.PasswordSaham = txtSmPassword.Text;

            BConfig.MaxLenghList = Convert.ToInt32(MainMaxRecordsTextBox.Text);
            //BConfig.PersonSahamTableName = txtPersonSahamTable.Text;
            //BConfig.SheetSahamTableName = txtSheetSaham.Text;
            BConfig.CurrentLang = MainCurrentLangTextBox.Text;
            BConfig.IntegratedSecurity = MainWindowsAuthRadioButton.Checked;
            //BConfig.BaseFileAddress = ImageAddresstextBox.Text;
            //BConfig.SahamWebConfig = txtSahamWebSite.Text;
            //BConfig.TimeLogin = txtBascolFileName.IntValue;
            //BConfig.CompanyDefault = Convert.ToInt32(jucCompanyDefault.SelectedCode);

            BConfig.DatabaseArchive = ArchiveDBNameTextBox.Text;
            BConfig.ServerArchive = ArchiveServerNameTextBox.Text;
            BConfig.UsernameArchive = MainSQLAuthRadioButton.Checked ? ArchiveUserNameTextBox.Text : BConfig.UsernameArchive;
            BConfig.PasswordArchive = string.IsNullOrWhiteSpace(ArchiveNewPasswordTextBox.Text) ? BConfig.PasswordArchive : ArchiveNewPasswordTextBox.Text;
            //BConfig.LDAPServer = txtLDAP.Text;
            //BConfig.DomainName = txtDomainName.Text;


            //if (RBGSMModem.Checked)
            //	BConfig.SMSSendType = JSMSSendType.GSM;
            //else
            //	if (RBWebServiceSend.Checked)
            //		BConfig.SMSSendType = JSMSSendType.WebService;


            BConfig.SaveToFile();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack)
                return;
            LoadConfig();
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            ApplyChanges();
        }
    }
}