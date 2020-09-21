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
    public partial class JAssemblyForm : Globals.JBaseForm
    {
        public int companyCode;
        int Code;
        JAssembly assembly = new JAssembly();
        public JAssemblyForm()
        {
            InitializeComponent();
        }
        public JAssemblyForm(int pCode)
        {
            InitializeComponent();
            assembly = new JAssembly(pCode);
            this.companyCode = assembly.CompanyCode;
            txtDate.Date = assembly.Date;
            txtTitle.Text = assembly.Title;
            txtCommands.Text = assembly.Commands;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void JAssemblyForm_Load(object sender, EventArgs e)
        {

        }
        private bool Save()
        {
            if (txtDate.Date == DateTime.MinValue)
            {
                JMessages.Error("لطفا تاریخ را وارد کنید.", "");
                return false;
            }
            if (txtTitle.Text == "")
            {
                JMessages.Error("لطفا عنوان مجمع را وارد کنید.", "");
                return false;
            }

            assembly.Title = txtTitle.Text.Trim();
            assembly.Date = txtDate.Date;
            assembly.CompanyCode = companyCode;
            assembly.Commands = txtCommands.Text;
            if (this.State == ClassLibrary.JFormState.Insert)
            {
                Code = assembly.Insert();
                return Code > 0;
            }

            if (this.State == ClassLibrary.JFormState.Update)
            {
                return assembly.Update(null);
            }
            return false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (Save())
            {
                btnSave.Enabled = false;
                this.State = JFormState.Update;
            }
            else
                JMessages.Error("عملیات ثبت با مشکل مواجه شده است.", "");

        }

        private void txtTitle_TextChanged(object sender, EventArgs e)
        {
            this.Text = txtTitle.Text;
            btnSave.Enabled = true;
        }
    }
}
