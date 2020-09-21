using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Legal
{
    public partial class AgreementForm : JBaseContractForm
    {
        public AgreementForm()
        {
            InitializeComponent();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            ContractForms.NextForm();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            ContractForms.BackForm();
        }
    }
}
