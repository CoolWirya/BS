using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClassLibrary;

namespace Globals
{
    public partial class JUserForm : JBaseForm
    {
        private JUser _user;
		public int SelectPersonCode
		{
			get
			{
				return personUser.SelectedCode;
			}
			set
			{
				personUser.SelectedCode = value;
			}
		}
        public JUserForm()
        {
            InitializeComponent();
            _FillComboBox();
        }
        public JUserForm(int pCode)
        {
            InitializeComponent();
            _user = new JUser(pCode);
            ShowData();
            _FillComboBox();
        }
        private void _FillComboBox()
        {
            GetInfoActiveDirectory usersDomain = new GetInfoActiveDirectory();
            System.Collections.Generic.SortedList<string, string> ListUsers;
            
            
            
            ListUsers = usersDomain.GetUsersInGroup();
            for (int i = 0; i < ListUsers.Count-1; i++)
            {
                cmbDomainName.Items.Add(ListUsers.Keys[i]);
                if (_user!=null && _user.domainName != null && ListUsers.Keys[i] == _user.domainName)
                    cmbDomainName.SelectedItem = ListUsers.Keys[i];
                    
            }   
        }
        private void ShowData()
        {
            if (_user.Person != null)
            {
                personUser.SelectedCode = _user.Person.Code;
                     
                //txtPersonCode.Text = _user.Person.Code.ToString();
                //txtPersonName.Text = _user.Person.Name;
                //txtLastName.Text = _user.Person.Fam;
            }
            txtUserName.Text = _user.username;
            chActive.Checked = _user.Active;
			if (_user.lastlogin.Year > 1900)
				txtLastLogin.Text = _user.lastlogin.ToString();
            //txtPersonCode.Enabled = false;
            //btnSearch.Enabled = false;
            personUser.Enabled = false;

        }

        private void jSearchButton1_Click(object sender, EventArgs e)
        {
            //JPersonListForm search = new JPersonListForm();
            //if (search.ShowDialog() == DialogResult.OK)
            //{
            //    txtPersonCode.Text = search.SelectedRow["Code"].ToString();
            //    txtPersonName.Text = search.SelectedRow["Name"].ToString();
            //    txtLastName.Text = search.SelectedRow["Fam"].ToString();
            //}
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            try
            {
                #region CheckValues
                if (txtPassword.Text != txtRePasswor.Text)
                {
                    JMessages.Error("PasswordsDoNotMatch", "Error");
                    txtPassword.Focus();
                    return;
                }
                if (txtUserName.Text.Trim() == "" )
                {
                        string[] parameters = { "@Value" };
                        string[] values = { "UserName" };
                        string msg = JLanguages._Text("PleaseEnter", parameters, values);
                        JMessages.Error(msg, "Error");
                        txtUserName.Focus();
                        return ;
                }

                #endregion CheckValues

                if (State == JFormState.Insert)
                {
                    try
                    {
                        JUser user = new JUser();
                        if (personUser.SelectedCode > 0)
                            user.PCode = personUser.SelectedCode;
                        user.username = txtUserName.Text.Trim();
                        user.password = txtPassword.Text;
                        user.Active = chActive.Checked;
                        if (cmbDomainName.SelectedItem != null)
                        {
                            user.domainName = (cmbDomainName.SelectedItem).ToString();
                        }
                        int pcode = user.insert();
                        if (pcode > 0) Close();
                    }
                    catch (Exception ex)
                    {
                        JSystem.Except.AddException(ex);
                        JMessages.Message("ناموفق", "aa", JMessageType.Error);
                    }
                }
                if (State == JFormState.Update && _user != null)
                {
                    _user.PCode = personUser.SelectedCode;
                    if (cmbDomainName.SelectedItem != null)
                    {
                        _user.domainName = (cmbDomainName.SelectedItem).ToString();
                    }
                    _user.username = txtUserName.Text.Trim();
                    if (txtPassword.Text.Length > 0)
                        _user.password = txtPassword.Text;
                    _user.Active = chActive.Checked;
                    if (_user.Update())
                        Close();
                }
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);                
            }                        
        }
            
        private void txtPersonCode_Leave(object sender, EventArgs e)
        {
            //if (txtPersonCode.Text.Length > 0)
            //{
            //    JPerson person = new JPerson();
            //    if (!person.getData(Convert.ToInt32(txtPersonCode)))
            //    {
            //        JMessages.Error("PersonDoesNotExist", "Error");
            //    }
            //}
        }
    }
}
