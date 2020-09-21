using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Legal;

namespace StoreComplex
{
    public partial class JTransferListForm : Globals.JBaseForm
    {
        int ContractCode;
        public JTransferListForm(int pContractCode)
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
            grdTransfer.DataSource = JSCTransfers.GetDatatable(0, ContractCode);
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            int code = Convert.ToInt32(grdTransfer.SelectedRow["Code"]);
            JSCTransfer reciept = new JSCTransfer(code);
            int pCode = Convert.ToInt32(grdTransfer.SelectedRow["PCode"]);
            reciept.ShowDialog(pCode,ContractCode, code);
            grdTransfer.DataSource = JSCTransfers.GetDatatable(0, ContractCode);
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            int code = Convert.ToInt32(grdTransfer.SelectedRow["Code"]);
            JSCTransfer reciept = new JSCTransfer(0);
            int pCode = Convert.ToInt32(grdTransfer.SelectedRow["PCode"]);
            reciept.ShowDialog(pCode, ContractCode, 0);
            grdTransfer.DataSource = JSCTransfers.GetDatatable(0, ContractCode);
        }

    }
}
