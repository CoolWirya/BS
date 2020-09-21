using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClassLibrary;

namespace Finance
{
    public partial class JTotalAccountsForm : JBaseForm
    {
        private JTotalAccount _newTotalAcount;
        public JTotalAccountsForm()
        {
            InitializeComponent();
            _newTotalAcount = new JTotalAccount();
        }
        public JTotalAccountsForm(int pCode)
        {
            InitializeComponent();
            _newTotalAcount = new JTotalAccount(pCode);
            _ShowData();

        }
        private void _ShowData()
        {
            txtCode.Text = _newTotalAcount.TotalAccountCode.ToString();
            txtName.Text = _newTotalAcount.Name.ToString();
            switch (Convert.ToInt32(_newTotalAcount.Type))
            {
                case 1:
                    rbNoMatter.Checked = true;
                    break;
                case 2:
                    rbDebTor.Checked = true;
                    break;
                case 3:
                    rbCreditor.Checked = true;
                    break;
            }

        }
        private bool _CheckField()
        {
            if (Convert.ToInt32(txtCode.Text) == 0)
            {
                JMessages.Error("کدحساب کل را وارد کنید", "خطا در ثبت اطلاعات");
                return false;
            }
            if (Convert.ToInt32(txtCode.Text) <0)
            {
                JMessages.Error("کد حساب کل نمی تواند منفی باشد", "خطا در ثبت اطلاعات");
                return false;
            }
            if (txtName.Text == "")
            {
                JMessages.Error("عنوان حساب کل را وارد کنید", "خطا در ثبت اطلاعات");
                return false;

            }
            return true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (_CheckField())
            {
                if (_Save())
                    btnSave.Enabled = false;

            }
        }

        private bool _Save()
        {
            try
            {
                _newTotalAcount.TotalAccountCode = Convert.ToInt32(txtCode.Text);
                _newTotalAcount.Name = txtName.Text.ToString();
                if (rbCreditor.Checked)
                    _newTotalAcount.Type = TypeOfTotalAccounts.Creditor;
                if (rbDebTor.Checked)
                    _newTotalAcount.Type = TypeOfTotalAccounts.Debtor;
                if (rbNoMatter.Checked)
                    _newTotalAcount.Type = TypeOfTotalAccounts.NoMatter;
                if (this.State == JFormState.Insert)
                {
                    if (_newTotalAcount.Insert() > 0)
                        return true;
                }
                else
                {
                    return _newTotalAcount.Update();
                }
                return false;
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return false;
            }
        }

        private void txtClose_Click(object sender, EventArgs e)
        {
            Close();
        }

   
    }
}
