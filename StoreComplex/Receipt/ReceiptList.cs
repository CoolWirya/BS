using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Legal;
using ClassLibrary;

namespace StoreComplex
{
    public partial class JReceiptListForm : Globals.JBaseForm
    {
        int ContractCode;
        public JReceiptListForm(int pContractCode)
        {
            InitializeComponent();
            ContractCode = pContractCode;
            ShowData();
        }

        public void ShowData()
        {
            JSubjectContract contract = new JSubjectContract(ContractCode);
            DataTable owner = JPersonContract.GetPerson(ContractCode, ClassLibrary.Domains.Legal.JPersonPetitionType.Buyer);
            if (owner != null)
                txtOwnerName.Text = owner.Rows[0]["Name"].ToString();
            JSCGood good = new JSCGood();
            good.GetData(contract.SCGood);
            txtgoodType.Text = good.Name;
            txtCode.Text = contract.SCCode;
            grdReceipt.DataSource = JSCReceipts.GetDatatable(0, ContractCode);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            int code = Convert.ToInt32(grdReceipt.SelectedRow["Code"]);
            int pCode = Convert.ToInt32(grdReceipt.SelectedRow["PCode"]);
            JSCReceipt reciept = new JSCReceipt(code);
            reciept.ShowDialog(pCode, ContractCode, code);
            grdReceipt.DataSource = JSCReceipts.GetDatatable(0, ContractCode);
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            int code = Convert.ToInt32(grdReceipt.SelectedRow["Code"]);
            int pCode = Convert.ToInt32(grdReceipt.SelectedRow["PCode"]);
            JSCReceipt reciept = new JSCReceipt(0);
            reciept.ShowDialog(pCode, ContractCode, 0);
            grdReceipt.DataSource = JSCReceipts.GetDatatable(0, ContractCode);
        }
    }
}
