using System;
using ClassLibrary;
using System.Data;

namespace StoreComplex
{
    public partial class JSCReceiptGoodsForm : Globals.JBaseForm
    {
        int ReceiptCode;
        int Code;
        public JSCReceiptGoodsForm(int pReceiptCode, int pCode)
        {
            InitializeComponent();
            ReceiptCode = pReceiptCode;
            Code = pCode;

            cmbGoods.DataSource = StoreManagement.JGoods.GetDataTable(0);
            cmbGoods.DisplayMember = "Name";
            cmbGoods.ValueMember = "Code";
            if (pCode > 0)
            {
                State = ClassLibrary.JFormState.Update;
                Code = pCode;
                JSCReceiptGood service = new JSCReceiptGood(Code);
                cmbGoods.SelectedValue = service.GoodCode;
                txtCost.Text = service.Cost.ToString();
                txtCount.Text = service.Amount.ToString();
                txtDesc.Text = service.Description;

                if (service.StoreType == JStoreType.Box.GetHashCode())
                    rbBox.Checked = true;
                if (service.StoreType == JStoreType.Counting.GetHashCode())
                    rbCounting.Checked = true;
                if (service.StoreType == JStoreType.Meter.GetHashCode())
                    rbMeter.Checked = true;
                if (service.StoreType == JStoreType.Ton.GetHashCode())
                    rbTon.Checked = true; 
          
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
            //if (txtCost.DecimalValue == 0)
            //{
            //    JMessages.Error("لطفاً مبلغ را وارد کنید.", "خطا");
            //    return;
            //}

            if (cmbGoods.SelectedValue == null)
            {
                ClassLibrary.JMessages.Error("لطفا کالا را وارد کنید.", "");
                return;
            }
            JSCReceiptGood service = new JSCReceiptGood(Code);
            service.ReceiptCode = ReceiptCode;
            service.Cost = txtCost.DecimalValue;
            service.Amount = txtCount.DecimalValue;
            service.Description = txtDesc.Text;
            service.GoodCode = Convert.ToInt32(cmbGoods.SelectedValue);
            if (rbBox.Checked)
                service.StoreType = JStoreType.Box.GetHashCode();
            if (rbCounting.Checked)
                service.StoreType = JStoreType.Counting.GetHashCode();
            if (rbMeter.Checked)
                service.StoreType = JStoreType.Meter.GetHashCode();
            if (rbTon.Checked)
                service.StoreType = JStoreType.Ton.GetHashCode();
            
         
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

        private void cmbGoods_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                StoreManagement.JGoods good = new StoreManagement.JGoods(Convert.ToInt32(cmbGoods.SelectedValue));
                lbUnit.Text = (new JSubBaseDefine(JBaseDefine.MeasureType, good.Measure)).Name;
            }
            catch
            {
                lbUnit.Text = "";
            }
        }
        
    }
}
