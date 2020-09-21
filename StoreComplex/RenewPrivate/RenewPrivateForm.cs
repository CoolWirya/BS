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
    public partial class JRenewPrivateForm : Globals.JBaseForm
    {
      int receiptGood;
        DataRow renewRow;
        public JRenewPrivateForm(DataRow pRenewRow)
        {
            InitializeComponent();
            //receiptGood = pReceiptGood;
            renewRow = pRenewRow;
            txtDate.Date = (new ClassLibrary.JDataBase()).GetCurrentDateTime();
            ShowData();
        }

        private void ShowData()
        {
            lbAmount.Text = renewRow["ExistBoxCount"].ToString();
            lbDate.Text = renewRow["IN_Renew_Date"].ToString();
            lbDesc.Text = renewRow["Description"].ToString();
            lbStorageName.Text = renewRow["StorageTitle"].ToString();
            receiptGood = Convert.ToInt32(renewRow["Code"]);
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            JRenewPrivate renew = new JRenewPrivate();
            renew.PrivateCode= receiptGood;
            renew.BoxCount= Convert.ToDecimal(lbAmount.Text);
            renew.Cost = txtCost.DecimalValue;
            renew.Date = (new ClassLibrary.JDataBase()).GetCurrentDateTime();
            renew.Description = txtDesc.Text;
            renew.Insert();
            DialogResult = DialogResult.OK;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
