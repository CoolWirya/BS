using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Finance
{
    public partial class JBankAccountControl : UserControl
    {
        private int _Code;
        public int PersonCode;

        public JBankAccountControl()
        {
            InitializeComponent();
            JBankTypes types = new JBankTypes();
            types.SetComboBox(cmbBankName);

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        public bool Save()
        {
            bool result;
            JBankAccount bank = new JBankAccount(PersonCode);
            bank.AccountNo = txtAccountNo.Text;
            if (cmbBankName.SelectedValue != null)
                bank.BankCode = Convert.ToInt32(cmbBankName.SelectedValue);
            bank.CardNo = txtCardNo.Text;
            bank.PCode = PersonCode;
            if (_Code == 0)
            {
                _Code = bank.Insert();
                result =  _Code > 0;
            }
            else
            {
                result = bank.Update();
            }
            return result;
        }

        public void LoadData()
        {
            JBankAccount bank = new JBankAccount(PersonCode);
            if (bank.Code > 0)
            {
                _Code = bank.Code;
                txtAccountNo.Text = bank.AccountNo;
                txtCardNo.Text = bank.CardNo;
                JBankTypes types = new JBankTypes();
                types.SetComboBox(cmbBankName, bank.BankCode);
            }
        }
    }
}
