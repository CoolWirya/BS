using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace StoreComplex
{
    public partial class JRenewForm : Globals.JBaseForm
    {
        int receiptGood;
        int renewCode;
        DataRow renewRow;
        public JRenewForm(DataRow pRenewRow, int pCode)
        {
            InitializeComponent();
            renewRow = pRenewRow;
            renewCode = pCode;
            txtDate.Date = (new ClassLibrary.JDataBase()).GetCurrentDateTime();
            ShowData();
        }

        private void ShowData()
        {
            if (renewRow != null)
            {
                lbExist.Text = renewRow["Exist"].ToString();
                lbDate.Text = renewRow["Date"].ToString();
                lbDesc.Text = renewRow["Description"].ToString();
                lbGood.Text = renewRow["GoodName"].ToString();
                lbUnit.Text = renewRow["Measure"].ToString();
                receiptGood = Convert.ToInt32(renewRow["Code"]);
            }
            if (renewCode > 0)
            {
                JRenew renew = new JRenew(renewCode);
                txtDate.Date = renew.Date;
                txtCost.Text = renew.Cost.ToString();
                txtDesc.Text = renew.Description;
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            //if (txtCost.DecimalValue == 0)
            //{
            //    ClassLibrary.JMessages.Error("لطفا مبلغ را وارد کنید.", "error");
            //    return;
            //}
            JRenew renew = new JRenew(renewCode);
            renew.ReceiptGoodCode = receiptGood;
            renew.Amount = Convert.ToDecimal(lbExist.Text);
            renew.Cost = txtCost.DecimalValue;
            //renew.Date = txtDate.Date;
            renew.Date = (new ClassLibrary.JDataBase()).GetCurrentDateTime();
            renew.Description = txtDesc.Text;
            if (renewCode > 0)
                renew.Update();
            else
                renew.Insert();
            DialogResult = DialogResult.OK;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
