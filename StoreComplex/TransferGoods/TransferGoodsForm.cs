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
    public partial class JSCTransferGoodsForm : Globals.JBaseForm
    {
        int TransferCode;
        int Code;
        int receiptGoodCode;
        int contractCode;
        public JSCTransferGoodsForm(int pContractCode, int pTransferCode, int pCode)
        {
            InitializeComponent();
            contractCode = pContractCode;
            TransferCode = pTransferCode;
            Code = pCode;
            grdGoods.DataSource = JSCTransferGoods.GetExistGoods(pContractCode);
            if (pCode > 0)
            {
                State = ClassLibrary.JFormState.Update;
                Code = pCode;
                JSCTransferGood service = new JSCTransferGood(Code);
                //cmbGoods.SelectedValue = service.RecieptGoodCode;
                receiptGoodCode = service.RecieptGoodCode;
                txtGoodName.Text = (new StoreManagement.JGoods((new JSCReceiptGood(service.RecieptGoodCode)).GoodCode)).Name;
                txtCount.Text = service.Amount.ToString();
                txtDesc.Text = service.Description;
            }
            else
            {
                State = JFormState.Insert;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (receiptGoodCode == 0)
            {
                ClassLibrary.JMessages.Error("لطفا کالا را وارد کنید.", "");
                return;
            }
            if (txtCount.FloatValue == 0)
            {
                ClassLibrary.JMessages.Error("لطفا تعداد را وارد کنید.", "");
                return;
            }
            if(this.State == JFormState.Insert)
                if (txtCount.DecimalValue > maxCount)
                {
                    ClassLibrary.JMessages.Error("تعداد وارد شده بیشتر از تعداد ثبت شده در رسید است.", "");
                    return;
                }
            JSCTransferGood service = new JSCTransferGood(Code);
            service.TransferCode = TransferCode;
            service.Amount = txtCount.DecimalValue;
            service.Description = txtDesc.Text;
            service.RecieptGoodCode = receiptGoodCode;
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

        private void grdGoods_DoubleClick(object sender, EventArgs e)
        {

        }
        decimal maxCount;
        private void button1_Click(object sender, EventArgs e)
        {
            if (grdGoods.SelectedRow != null)
            {
                receiptGoodCode = Convert.ToInt32(grdGoods.SelectedRow["Code"]);
                DateTime receiptDate =Convert.ToDateTime(grdGoods.SelectedRow["Date"]);
                if (!JRenews.ReceiptHasRenew(receiptGoodCode,receiptDate))
                {
                    if (JMessages.Warning("این رسید کالا نیاز به تمدید اجاره دارد. آیا میخواهید حواله صادر گردد؟", "") != DialogResult.OK)
                        return;
                }
                    maxCount = Convert.ToDecimal(grdGoods.SelectedRow["Exist"]);
                    txtGoodName.Text = grdGoods.SelectedRow["GoodName"].ToString();
                    lbUnit.Text = grdGoods.SelectedRow["Measure"].ToString();
                    txtCount.Focus();
            }
        }
    }
}
