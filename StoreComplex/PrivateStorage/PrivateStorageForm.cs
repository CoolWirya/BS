using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClassLibrary;

namespace StoreComplex
{
    public partial class JPrivateStorageForm : Globals.JBaseForm
    {
        int ReceiptCode;
        int Code;
        public JPrivateStorageForm(int pReceiptCode, int pCode)
        {
            InitializeComponent();
            ReceiptCode = pReceiptCode;
            Code = pCode;

            cmbStorage.DataSource = StoreComplex.JSCStorages.GetDatatable(0);
            cmbStorage.DisplayMember = "Title";
            cmbStorage.ValueMember = "Code";
            if (pCode > 0)
            {
                State = ClassLibrary.JFormState.Update;
                Code = pCode;
                JPrivateStorage privateStorage = new JPrivateStorage(Code);
                cmbStorage.SelectedValue = privateStorage.StorageCode;
                txtCost.Text = privateStorage.Cost.ToString();
                txtBoxCount.Text = privateStorage.BoxCount.ToString();
                txtDesc.Text = privateStorage.Description;

            }
            else
            {
                State = JFormState.Insert;
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            //if (txtCost.DecimalValue == 0)
            //{
            //    JMessages.Error("لطفاً مبلغ را وارد کنید.", "خطا");
            //    return;
            //}

            //if (cmbStorage.SelectedValue == null)
            //{
            //    ClassLibrary.JMessages.Error("لطفا انبار را انتخاب کنید.", "");
            //    return;
            //}

            if (txtBoxCount.DecimalValue == 0)
            {
                JMessages.Error("لطفاً تعداد باکس را وارد کنید.", "خطا");
                return;
            }

            JPrivateStorage privateStorage = new JPrivateStorage(Code);
            privateStorage.ReceiptCode = ReceiptCode;
            privateStorage.Cost = txtCost.DecimalValue;
            privateStorage.BoxCount = txtBoxCount.DecimalValue;
            privateStorage.Description = txtDesc.Text;
            privateStorage.StorageCode = Convert.ToInt32(cmbStorage.SelectedValue);
          
            if (State == JFormState.Insert)
            {
                if (privateStorage.Insert() > 0)
                    DialogResult = System.Windows.Forms.DialogResult.OK;
            }
            if (State == JFormState.Update)
            {
                if (privateStorage.Update())
                    DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
