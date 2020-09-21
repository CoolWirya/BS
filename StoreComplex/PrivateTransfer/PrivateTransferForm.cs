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
    public partial class JPrivateTransferForm : Globals.JBaseForm
    {

        int TransferCode;
        int Code;
        int privateStorageCode;
        int contractCode;
        public JPrivateTransferForm(int pContractCode, int pTransferCode, int pCode)
        {
            InitializeComponent();
            contractCode = pContractCode;
            TransferCode = pTransferCode;
            Code = pCode;
            grdStorages.DataSource = JPrivateStorages.GetExistStorages(pContractCode);
            if (pCode > 0)
            {
                State = ClassLibrary.JFormState.Update;
                Code = pCode;
                JPrivateStorage service = new JPrivateStorage(Code);
                privateStorageCode = service.StorageCode;
                txtStorageTitle.Text = (new JSCStorage(privateStorageCode)).Title;
                txtCount.Text = service.BoxCount.ToString();
                txtDesc.Text = service.Description;
            }
            else
            {
                State = JFormState.Insert;
            }
        }

        decimal maxCount;
        private void button1_Click(object sender, EventArgs e)
        {
            if (grdStorages.SelectedRow != null)
            {
                privateStorageCode = Convert.ToInt32(grdStorages.SelectedRow["Code"]);
                DateTime receiptDate = Convert.ToDateTime(grdStorages.SelectedRow["Date"]);
                if (!JRenewPrivates.ReceiptHasRenew(privateStorageCode, receiptDate))
                {
                    if (JMessages.Warning("این رسید کالا نیاز به تمدید اجاره دارد. آیا میخواهید حواله صادر گردد؟", "") != DialogResult.OK)
                        return;
                }
                    maxCount = Convert.ToDecimal(grdStorages.SelectedRow["ExistBoxCount"]);
                    txtStorageTitle.Text = grdStorages.SelectedRow["StorageTitle"].ToString();
                    txtCount.Focus();
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (privateStorageCode == 0)
            {
                ClassLibrary.JMessages.Error("لطفا مورداجاره را انتخاب کنید.", "");
                return;
            }
            if (txtCount.FloatValue == 0)
            {
                ClassLibrary.JMessages.Error("لطفا تعداد باکس را وارد کنید.", "");
                return;
            }
            if (this.State == JFormState.Insert)
                if (txtCount.DecimalValue > maxCount)
                {
                    ClassLibrary.JMessages.Error("تعداد باکس وارد شده بیشتر از تعداد ثبت شده در رسید است.", "");
                    return;
                }
            JPrivateTransfer service = new JPrivateTransfer(Code);
            service.TransferCode = TransferCode;
            service.BoxCount = txtCount.DecimalValue;
            service.Description = txtDesc.Text;
            service.PrivateStorageCode = privateStorageCode;
            if (State == JFormState.Insert)
            {
                if (service.Insert() > 0)
                    DialogResult = System.Windows.Forms.DialogResult.OK;
            }
            if (State == JFormState.Update)
            {
                if (service.Update())
                    DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }
    }
}
