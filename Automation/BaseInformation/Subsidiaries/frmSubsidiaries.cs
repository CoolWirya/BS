using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ClassLibrary;

namespace Automation
{
    public partial class JfrmSubsidiaries : ClassLibrary.JBaseForm
    {
        private JASubsidiaries _jClass;

        public JfrmSubsidiaries(JASubsidiaries jClass)
        {
            InitializeComponent();

            btnAction.Text = JLanguages._Text("Insert");

            if (jClass != null)
            {
                _jClass = jClass;
                btnAction.Text = JLanguages._Text("Update");
            }

        }

        private void btnAction_Click(object sender, EventArgs e)
        {
            try
            {
                if (_Validation())
                {
                    if (State == JFormState.Insert)
                    {

                        JASubsidiaries tmpJSubsidiaries = new JASubsidiaries();
                        //tmpJSubsidiaries.Nodes = _jClass.Nodes;
                        tmpJSubsidiaries.Name = txtNameCompany.Text.Trim();
                        tmpJSubsidiaries.managing_director = txtmanaging_Director.Text.Trim();
                        tmpJSubsidiaries.phone_number = txtPhone.Text;
                        tmpJSubsidiaries.address = txtAddress.Text;
                        tmpJSubsidiaries.server_name = txtServer_name.Text.Trim();
                        tmpJSubsidiaries.server_user = txtServer_User.Text.Trim();
                        tmpJSubsidiaries.server_pass = txtServer_Pass.Text;
                        tmpJSubsidiaries.database_name = txtDataBaseName.Text.Trim();
                        if (nedAccessCode.Text != "")
                        {
                            tmpJSubsidiaries.access_code = Convert.ToInt32(nedAccessCode.Text);
                        }
                        tmpJSubsidiaries.description = txtDescription.Text;
                        tmpJSubsidiaries.Insert();
                        Close();

                    }
                    else if (State == JFormState.Update)
                    {

                        _jClass.Name = txtNameCompany.Text.Trim();
                        _jClass.managing_director = txtmanaging_Director.Text.Trim();
                        _jClass.phone_number = txtPhone.Text;
                        _jClass.address = txtAddress.Text;
                        _jClass.server_name = txtServer_name.Text.Trim();
                        _jClass.server_user = txtServer_User.Text.Trim();
                        _jClass.server_pass = txtServer_Pass.Text;
                        _jClass.database_name = txtDataBaseName.Text.Trim();
                        if (nedAccessCode.Text != "")
                        {
                            _jClass.access_code = Convert.ToInt32(nedAccessCode.Text);
                        }
                        _jClass.description = txtDescription.Text;
                        _jClass.Update();
                        DialogResult = DialogResult.OK;
                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }
        }
        private bool _Validation()
        {
            //----------------- اعتبار سنجی نام --------
            if (txtNameCompany.Text.Trim() == "")
            {
                JMessages.Message(JLanguages._Text("Server Information Is Incorrect!"), JLanguages._Text("Error"), JMessageType.Error);
                txtNameCompany.Focus();
                return false;
            }

            JASubsidiaries JS = new  JASubsidiaries();
            JS.Name = txtNameCompany.Text.Trim();
            if ( ( State == JFormState.Insert && JS.Find()) ||
                 (State == JFormState.Update && txtNameCompany.Text.Trim() != _jClass.Name && JS.Find()))
            {
                JMessages.Message(JLanguages._Text("This Name is Exist in Database"), JLanguages._Text("Error"), JMessageType.Error);
                txtNameCompany.Focus();
                return false;
            }
            //-------------------------------------------------           
            //         اعتبار سنجی اطلاعات سرور
            System.Data.SqlClient.SqlConnection TestCnn = new System.Data.SqlClient.SqlConnection(
                        "Password=" + txtServer_Pass.Text +
                        ";User ID=" + txtServer_User.Text.Trim() +
                        ";Initial Catalog=" + txtDataBaseName.Text.Trim() +
                        ";Data Source=" + txtServer_name.Text.Trim());
            try
            {
                TestCnn.Open();
            }
            catch 
            {
                JMessages.Message(JLanguages._Text("Server Information Is Incorrect!"), JLanguages._Text("Error"), JMessageType.Error);
                txtServer_name.Focus();
                return false;
            }
            TestCnn.Close();
            TestCnn.Dispose();
            //--------------- اعتبار سنجی کد دسترسی سریع-----------------   
            if (nedAccessCode.Text.Trim() != "")
            {
                JS = new JASubsidiaries();
                JS.access_code = Convert.ToInt32(nedAccessCode.Text);
                if ((State == JFormState.Insert && JS.Find()) ||
                 (State == JFormState.Update && nedAccessCode.Text.Trim() != _jClass.access_code.ToString() && JS.Find()))
                {
                    JMessages.Message(JLanguages._Text("Access Code IS Reserved!"), JLanguages._Text("Error"), JMessageType.Error);
                    nedAccessCode.Focus();
                    return false;
                }

            }


            return true;
        }

        private void textEdit3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textEdit1_TextChanged(object sender, EventArgs e)
        {

        }

        private void JfrmSubsidiaries_Load(object sender, EventArgs e)
        {
            btnAction.Text = JLanguages._Text("Insert");

            if (_jClass != null && _jClass.Code != 0) 
            {
                txtNameCompany.Text = _jClass.Name;
                txtmanaging_Director.Text = _jClass.managing_director;
                txtPhone.Text = _jClass.phone_number;
                txtAddress.Text = _jClass.address;
                txtServer_name.Text = _jClass.server_name;
                txtServer_User.Text = _jClass.server_user;
                txtServer_Pass.Text = _jClass.server_pass;
                txtDataBaseName.Text = _jClass.database_name;
                nedAccessCode.Text = _jClass.access_code.ToString();
                txtDescription.Text = _jClass.description;
                btnAction.Text = JLanguages._Text("Update");
            }
        }

    }
}
