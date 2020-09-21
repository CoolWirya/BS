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
    public partial class JShareCompanyForm : ClassLibrary.JBaseForm
    {
        int ShareCompanyCode;
        JShareCompany shareCompany;
        public JShareCompanyForm()
        {
            InitializeComponent();
            shareCompany = new JShareCompany();
        }
        public JShareCompanyForm(int pCode)
        {
            InitializeComponent();
            shareCompany = new JShareCompany(pCode);
            setForm();
            State = JFormState.Update;
        }

        private void setForm()
        {
            jucPerson1.SelectedCode = shareCompany.PCode;
            jucPerson1.Enabled = false;
            PriceText.Text = shareCompany.CurrentShareCost.ToString();
            TaxTransfer.Text = shareCompany.TaxTransfer.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private bool Save()
        {
            if (jucPerson1.SelectedCode == 0)
            {
                JMessages.Error("لطفا شخص را انتخاب کنید.", "");
                return false;
            }

            shareCompany.PCode = Convert.ToInt32(jucPerson1.SelectedCode);
            shareCompany.CurrentShareCost = Convert.ToDecimal(PriceText.Text);
            shareCompany.TaxTransfer = Convert.ToInt32(TaxTransfer.Text);
            if (this.State == ClassLibrary.JFormState.Insert)
            {
                ShareCompanyCode = shareCompany.Insert();
                return ShareCompanyCode > 0;
            }

            if (this.State == ClassLibrary.JFormState.Update)
            {
                return shareCompany.Update(null);
            }
            return false;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (Save())
            {
                btnOK.Enabled = false;
                State = JFormState.Update;
            }
        }

        private void txtShareCount_TextChanged(object sender, EventArgs e)
        {
            btnOK.Enabled = true;
        }
    }
}
