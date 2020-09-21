using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClassLibrary;

namespace Legal
{
    public partial class JFinishForm : JBaseContractForm
    {
        public JFinishForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (ContractForms.SavePreview())
            if (ContractForms.Save())
            {
                JMessages.Message("Save Successfuly ", "", JMessageType.Information);
                JAmendmentForm tmp = new JAmendmentForm(ContractForms.GetContractData(ContractForms.Contract.Code));
                tmp.ShowDialog();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ContractForms.BackForm();
        }
    }
}
