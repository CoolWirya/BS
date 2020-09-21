using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClassLibrary;

namespace ManagementShares
{
    public partial class JPollingForm : ClassLibrary.JBaseForm
    {
        int _AssemblyCode;
        int _Code;
        public JPollingForm(int ACode, int pCode)
        {
            InitializeComponent();
            _AssemblyCode = ACode;
            _Code = pCode;
            if (pCode > 0)
                ShowData();

        }
        private void ShowData()
        {
            JPolling polling = new JPolling(_Code);
            txtTitle.Text = polling.Title;
            txtMainMembers.Text = polling.MainMembers.ToString();
            txtAlternateMembers.Text = polling.AlternateMembers.ToString();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtTitle.Text.Trim() == "")
            {
                JMessages.Error("لطفاً عنوان را وارد کنید", "");
                return;
            }
            JPolling polling = new JPolling(_Code);
            polling.Title = txtTitle.Text;
            polling.MainMembers = txtMainMembers.IntValue;
            polling.AlternateMembers = txtAlternateMembers.IntValue;
            polling.ACode = _AssemblyCode;
            if (_Code == 0)
            {
                if (polling.Insert() > 0)
                    DialogResult = DialogResult.OK;
            }
            else
                if (polling.Update(null))
                    DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
