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
    public partial class JFinishForm : JBaseContractForm
    {
        public JFinishForm()
        {
            InitializeComponent();
        }

        public JFinishForm MakeForm()
        {
            JFinishForm form = new JFinishForm();
            return form;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (ContractForms.Save())
            {
                ClassLibrary.JMessages.Information("اطلاعات قرارداد با موفقیت ثبت شد", "");
                ContractForms.CloseAll();
                btnSave.Enabled = false;
                if (!ContractForms.Contract.Confirmed && ClassLibrary.JMessages.Question("آیا می خواهید قرارداد را تائید کنید؟", "تائید قرارداد؟") == DialogResult.Yes)
                {
                    JSubjectContract tmp = new JSubjectContract(ContractForms.Contract.Code);
                    tmp.ConfirmContract(tmp.ContractType.Code);
                    //Legal.JConfirmForm confirm = new Legal.JConfirmForm(ContractForms.Contract.Code);
                    //confirm.ShowDialog();
                }
            }
            else
            {
                ClassLibrary.JMessages.Error("عملیات ثبت با مشکل مواجه شده است.", "");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ContractForms.Cancel();
            Close();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            ContractForms.BackForm();
        }

        private void JFinishForm_Load(object sender, EventArgs e)
        {
            if (State== JStateContractForm.View)
            {
                btnSave.Enabled = false;
            }
        }
    }
}
